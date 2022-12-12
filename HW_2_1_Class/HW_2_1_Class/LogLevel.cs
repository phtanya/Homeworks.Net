using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_1_Class
{
    public class LogLevel
    {
        private string? _message;
        private LogType _type;
        private DateTime _time;

        public LogLevel(DateTime time, string? message, LogType type)
        {
            _time = time;
            _message = message;
            _type = type;
        }

        public DateTime Time
        {
            get { return _time; }
        }

        public string? Message
        {
            get { return _message; }
        }

        public LogType Type
        {
            get { return _type; }
        }
    }
}
