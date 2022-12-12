using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_1_Class
{
    internal class Logger
    {
        private LogLevel[] _storage = new LogLevel[20];
        private int _index = 0;
        private static Logger? _instance;

        private Logger()
        {
        }

        public LogLevel[] Storage
        {
            get { return _storage; }
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }

            return _instance;
        }

        public void Log(LogLevel item)
        {
            _storage[_index] = item;
            _index++;
        }
    }
}
