using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_2_Delegate
{
    public class Customer
    {
        public Customer(string name, Topic topic)
        {
            Name = name;
            Topics = topic;
        }

        public enum Topic
        {
            Auto,
            Garden,
            Fashion,
            Medicine
        }

        public string Name { get; set; }

        public Topic Topics { get; set; }

        public void MagazinTopics()
        {
            switch (Topics)
            {
                case Topic.Auto:
                    Console.WriteLine($"Hey {Name}! You subscribed for online version of Auto magazine.");
                    break;
                case Topic.Garden:
                    Console.WriteLine($"Hey {Name}! You subscribed for online version of Garten magazine");
                    break;
                case Topic.Fashion:
                    Console.WriteLine($"Hey {Name}! You subscribed for online version of Fasion magazine");
                    break;
                case Topic.Medicine:
                    Console.WriteLine($"Hey {Name}! You subscribed for online version of Medicine magazine");
                    break;
                default:
                    Console.WriteLine($"Hey {Name}! Smth went wrong...");
                    break;
            }
        }
    }
}
