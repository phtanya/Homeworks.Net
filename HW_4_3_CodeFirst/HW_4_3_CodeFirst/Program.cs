using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HW_4_3_CodeFirst
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var dbContex = new DataBaseContext();
            _ = await dbContex.SaveChangesAsync();
        }
    }
}