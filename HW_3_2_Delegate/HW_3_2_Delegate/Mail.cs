using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_2_Delegate
{
    public delegate void NotifyHandler();
    public class Mail
    {
        public int RealeseDate { get; set; } = 2;
        public void IsReleaseDate()
        {
            Random rnd = new Random();
            int today = rnd.Next(1, 3);

            if (today == RealeseDate)
            {
                Console.WriteLine("Its time to read your magazine! Check your E-Mail.");
            }
            else
            {
                Console.WriteLine($"Sorry! You need to wait until release date...");
            }
        }
    }
}
