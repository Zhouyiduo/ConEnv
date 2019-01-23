using ConEnv.Tools;
using ConEnv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using ConEnv.NewVision.View;
using ConEnv.NewVision.ViewModel;
using ConEnv.Model;

namespace ConEnv.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new VMMain();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string pathEnv = SysEnvironment.GetSysEnvironmentByName("Path");
        //    List<string> paths = ToListByString(pathEnv);
        //    VMMain mainview  = this.DataContext as VMMain;

        //    for (int i = 0; i < mainview.Envs.Count; i++)
        //    {
                
        //        if (mainview.CurEnv == mainview.Envs[i])// 加上选中的项
        //        {
        //            bool bExist = false;
        //            for (int j = 0; j < paths.Count; j++)
        //            {
        //                if( paths[j] == mainview.CurEnv)
        //                {
        //                    bExist = true;
        //                    break;
        //                }
        //            }

        //            if (!bExist)
        //            {
        //                paths.Add(mainview.CurEnv);
        //            }

        //        }
        //        else //去掉没有选中的项
        //        {
        //            int nPos = -1;
        //            for (int j = 0; j < paths.Count; j++)
        //            {
        //                if (paths[j] == mainview.CurEnv)
        //                {
        //                    nPos = j;
        //                    break;
        //                }
        //            }

        //            if (nPos  != -1)
        //            {
        //                paths.RemoveAt(nPos);
        //            }
        //        }
        //    }
   
        //    return;
        //}

        private void Btn_Clk_New_Vision(object sender, RoutedEventArgs e)
        {
            VVisoName visoName = new VVisoName();
            if (visoName.ShowDialog() != true)
            {
                return;
            }

            VMVison vMVison = visoName.DataContext as VMVison;

            if ( vMVison == null )
                return;

            VMMain vmmain = DataContext as VMMain;

            List<string> envs = new List<string>();
            foreach (string srtCur in vmmain.Envs)
            {
                envs.Add(srtCur);
            }

            envs.Add(vMVison.VisonName);
            vmmain.Envs = envs;

            vmmain.CurEnv = vMVison.VisonName;

        }

        private void Btn_Clk_New_Path(object sender, RoutedEventArgs e)
        {
            var d = new CommonOpenFileDialog();
            d.IsFolderPicker = true; //set to false if need to select files
            d.Title = "选择一个软件版本路径";
            d.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            var result = d.ShowDialog();
            PathItem sPahth = new PathItem();
            if (result == CommonFileDialogResult.Ok)
            {
                sPahth.Des = "Path";
                sPahth.Path = d.FileName;
            }
            else
            {
                return;
            }

            VMMain vmmain = DataContext as VMMain;
            List<PathItem> paths = new List<PathItem>();
            foreach ( PathItem srtCur in vmmain.Paths )
            {
                paths.Add(srtCur);
            }

            paths.Add(sPahth);
            vmmain.Paths = paths;

            return;
        }

        private void Btn_Clk_Set_Cur(object sender, RoutedEventArgs e)
        {

            VMMain vmmain = this.DataContext as VMMain;
            for (int i = 0; i < vmmain.SoftIns.Visons.Count; i++)
             {
                if (vmmain.SoftIns.Visons[i].Name == vmmain.CurEnv)// 添加环境变量
                {
                    for ( int j = 0; j < vmmain.SoftIns.Visons[i].Path.Count();j++ )
                    {
                        SysEnvironment.AddPath( vmmain.SoftIns.Visons[i].Path[j] );
                    }
                }
                else // 减少环境变量
                {
                    for (int j = 0; j < vmmain.SoftIns.Visons[i].Path.Count(); j++)
                    {
                         SysEnvironment.SubPath(vmmain.SoftIns.Visons[i].Path[j]);
                    }
                }
            }
            
        }

        private void Btn_Clk_Save(object sender, RoutedEventArgs e)
        {
            Vison vison = new Vison();

            VMMain vmmain = this.DataContext as VMMain;
            vison.Name = vmmain.CurEnv;

            for (int i = 0; i < vmmain.Paths.Count; i++)
            {
                vison.Path.Add(vmmain.Paths[i].Path);
            }

            int nPos = -1;
            for (int i = 0; i < vmmain.SoftIns.Visons.Count; i++)
            {
                if ( vmmain.SoftIns.Visons[i].Name == vmmain.CurEnv )
                {
                    nPos = i;
                    break;
                }
            }

            if (nPos == -1)
            {
                vmmain.SoftIns.Visons.Add(vison);
            }
            else
            {
                vmmain.SoftIns.Visons[nPos] = vison;
            }


            System.Windows.MessageBox.Show("保存完成！");
            return;
        }

        private void Btn_Clk_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }


        private List<string> ToListByString(string ss)
        {
            List<string> ress = new List<string>();
            ress = ss.Split(',').ToList() ;
             
            return ress;
        }

        private string getPath(string sVision)
        {
            string sPath = "";

            return sPath;
        }

        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            // 重置创建一个软件变量赋值
            VMMain vmmain = this.DataContext as VMMain;
            vmmain.SoftIns = new Soft();
        }


        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".xml";
            ofd.Filter = "xml file|*.xml";
            if (ofd.ShowDialog() == true)
            {
                VMMain mainview = this.DataContext as VMMain;
                Soft softIns = new Soft();
                Soft.Open(ref softIns,ofd.FileName);
                mainview.SoftIns = softIns;
            }
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog ofd = new Microsoft.Win32.SaveFileDialog();
            ofd.DefaultExt = ".xml";
            ofd.Filter = "xml file|*.xml";
            if (ofd.ShowDialog() == true)
            {
                VMMain mainview = this.DataContext as VMMain;
                Soft.Save(mainview.SoftIns,ofd.FileName);
            }
        }


        
    }
}
