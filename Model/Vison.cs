using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConEnv.Model
{
    public class Vison
    {
        public string Name
        {
            set;
            get;
        }

        private List<string> _path = new List<string>();
        public List<string> Path
        {
            set
            {
                _path = value;
            }
            get
            {
                return _path;
            }
        }

    }
}
