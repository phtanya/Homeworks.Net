using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_1_Class
{
    public static class Starter
    {
        public static void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                int number = new Random().Next(1, 4);
                Result result = new ();

                switch (number)
                {
                    case 1:
                        result = Actions.InfoActions();
                        break;
                    case 2:
                        result = Actions.WarningActions();
                        break;
                    case 3:
                        result = Actions.ErrorActions();
                        break;
                }

                if (!result.Status)
                {
                    var item = new LogLevel(DateTime.Now, "Status is false", LogType.Error);
                    Logger.GetInstance().Log(item);
                }
            }

            var text = new StringBuilder();
            for (int i = 0; i < Logger.GetInstance().Storage.Length; i++)
            {
                if (Logger.GetInstance().Storage[i] == null)
                {
                    break;
                }

                var item = Logger.GetInstance().Storage[i];
                text.AppendLine(item.Time.ToLocalTime() + " Type: " + item.Type + " Message: " + item.Message);
            }

            File.WriteAllText("logger.txt", text.ToString());
        }
    }
}
