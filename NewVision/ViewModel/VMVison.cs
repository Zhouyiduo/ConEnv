using ConEnv.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConEnv.NewVision.ViewModel
{
    public class VMVison : NotificationObject
    {
        private string _visonName;
        public string VisonName
        {
            get
            {
                return _visonName;
            }

            set
            {
                _visonName = value;
                this.RaisePropertyChanged("VisonName");
            }
        }
        
    }
}
