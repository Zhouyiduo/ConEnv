using ConEnv.NewVision.ViewModel;
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
using System.Windows.Shapes;

namespace ConEnv.NewVision.View
{
    /// <summary>
    /// VVisoName.xaml 的交互逻辑
    /// </summary>
    public partial class VVisoName : Window
    {
        public VVisoName()
        {
            InitializeComponent();
            this.DataContext = new VMVison();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
