using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_1_Class
{
    public struct Result
    {
        private bool _status;
        public Result(bool status)
        {
            _status = status;
        }

        public bool Status
        {
            get { return _status; }
        }
    }
}