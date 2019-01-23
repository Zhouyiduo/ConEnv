using ConEnv.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConEnv.ViewModel
{
    public class VMMain :NotificationObject
    {
        public VMMain()
        {
            //_envs.Add("Node v0.15");
            //_envs.Add("Node v0.12.18");

            //if (_envs.Count != 0)
            //{
            //    CurEnv = _envs[0];
            //}
        }

        private Soft _softIns = new Soft();
        public Soft SoftIns
        {
            set
            {
                _softIns = value;
                for (int i = 0; i < _softIns.Visons.Count; i++)
                {
                    Envs.Add(_softIns.Visons[i].Name);

                    if (i == 0)
                    {
                        CurEnv = _softIns.Visons[i].Name;
                    }
                }
            }
            get
            {
                return _softIns;
            }
        }

        private List<string> _envs = new List<string>();
        public List<string> Envs
        {
            get
            {
                return _envs;
            }
            set
            {
                _envs = value;
                this.RaisePropertyChanged("Envs");

            }
        }

        private string _curEnv;
        public string CurEnv
        {
            get
            {
                return _curEnv;
            }
            set
            {
                _curEnv = value;

                List<PathItem> items = new List<PathItem>();
                for (int i = 0; i < _softIns.Visons.Count; i++)
                {
                    if (_softIns.Visons[i].Name == _curEnv)
                    {
                       
                        for (int j = 0; j < _softIns.Visons[i].Path.Count; j++)
                        {
                            PathItem item = new PathItem();
                            item.Path = _softIns.Visons[i].Path[j];
                            items.Add(item);
                        }
                    }
                }

                Paths = items;

                this.RaisePropertyChanged("CurEnv");
            }
        }


        private List<PathItem> _paths = new List<PathItem>();
        public List<PathItem> Paths
        {
            get
            {
                return _paths;
            }
            set
            {
                _paths = value;
                this.RaisePropertyChanged("Paths");
            }
        }
    }
}
