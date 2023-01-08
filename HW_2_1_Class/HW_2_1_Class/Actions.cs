using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_1_Class
{
    public static class Actions
    {
        public static Result InfoActions()
        {
            var item = new LogLevel(DateTime.Now, "Information about status", LogType.Info);
            Logger.GetInstance().Log(item);
            return new Result(true);
        }

        public static Result WarningActions()
        {
            var item = new LogLevel(DateTime.Now, "Warning!!!", LogType.Warning);
            Logger.GetInstance().Log(item);
            return new Result(true);
        }

        public static Result ErrorActions()
        {
            var item = new LogLevel(DateTime.Now, "You have an error!!!", LogType.Error);
            Logger.GetInstance().Log(item);
            return new Result(false);
        }
    }
}
