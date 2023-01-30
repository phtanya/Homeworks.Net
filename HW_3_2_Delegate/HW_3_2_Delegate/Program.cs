namespace HW_3_2_Delegate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mail k = new Mail();
            Customer user1 = new Customer("Alex", Customer.Topic.Medicine);
            NotifyHandler del = user1.MagazinTopics;
            del += k.IsReleaseDate;
            del.Invoke();
        }
    }
}