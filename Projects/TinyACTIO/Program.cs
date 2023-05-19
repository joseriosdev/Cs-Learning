using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using TinyACTIO.Entities;
using TinyACTIO.Utilities;

namespace TinyACTIO
{
    public class App
    {
        static void Main(string[] args)
        {
            while(true)
                AppController.Run();
        }
    }
}
