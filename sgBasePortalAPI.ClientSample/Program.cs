using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgBasePortalAPI.ClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new sgBasePortalAPI.Announcements();

            var announcements = api.Search();

            foreach (var announcement in announcements)
            {
                Console.WriteLine(announcement.ToLongString());
            }

            Console.ReadKey();
        }
    }
}
