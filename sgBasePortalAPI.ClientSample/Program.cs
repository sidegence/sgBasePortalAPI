using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using sgBasePortalAPI;
using sgBasePortalAPI.Helpers;

namespace sgBasePortalAPI.ClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var AnnouncementsApi = new Announcements();

            Console.WriteLine("Announcements");
            Console.WriteLine("Get 1");
            var announcement1 = AnnouncementsApi.Get(82919);
            Console.WriteLine(announcement1.ToLongString());

            Console.WriteLine("Get N");
            var filter = new List<KeyValuePair<AnnouncementFilterColumn, string>>()
            {
                new KeyValuePair<AnnouncementFilterColumn, string>(AnnouncementFilterColumn.emissora, "508100496"),
                new KeyValuePair<AnnouncementFilterColumn, string>(AnnouncementFilterColumn.desdedatapublicacao, "2015-10-01"),
                new KeyValuePair<AnnouncementFilterColumn, string>(AnnouncementFilterColumn.desdeprecobase, "200000"),
            };

            var announcements = AnnouncementsApi.Get(0, 0, filter, AnnouncementSortColumn.id, Order.Desc);
            foreach (var announcement2 in announcements)
            {
                Console.WriteLine(announcement2.ToLongString());
            }

            Console.ReadKey();
        }
    }
}
