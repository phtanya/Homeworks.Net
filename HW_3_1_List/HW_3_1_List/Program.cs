namespace HW_3_1_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyList<int> numbers = new MyList<int>();
            ListComparer sort = new ListComparer();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(13);
            numbers.Add(3);
            numbers.Add(78);
            numbers.Add(33);
            numbers.Sort(sort);
            numbers.Remove(33);
            numbers.RemoveAt(3);
        }
    }
}