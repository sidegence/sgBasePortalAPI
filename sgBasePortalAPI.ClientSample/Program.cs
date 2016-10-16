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
            var filter1 = new List<KeyValuePair<AnnouncementFilterColumn, string>>()
            {
                new KeyValuePair<AnnouncementFilterColumn, string>(AnnouncementFilterColumn.emissora, "508100496"),
                new KeyValuePair<AnnouncementFilterColumn, string>(AnnouncementFilterColumn.desdedatapublicacao, "2015-10-01"),
                new KeyValuePair<AnnouncementFilterColumn, string>(AnnouncementFilterColumn.desdeprecobase, "200000"),
            };

            var announcements2 = AnnouncementsApi.Get(0, 1, filter1, AnnouncementSortColumn.id, Order.Desc);
            foreach (var announcement3 in announcements2)
            {
                Console.WriteLine(announcement3.ToLongString());
            }

            Console.WriteLine("Get 1 Async");
            Task.Run(async () =>
            {
                var announcement4 = await AnnouncementsApi.GetAsync(82919);
                Console.WriteLine(announcement4.ToLongString());
            }).Wait();

            Console.WriteLine("Get N Async");
            Task.Run(async () =>
            {
                var announcements5 = await AnnouncementsApi.GetAsync(0, 1, null, AnnouncementSortColumn.id, Order.Desc);
                foreach (var announcement6 in announcements5)
                {
                    Console.WriteLine(announcement6.ToLongString());
                }
            }).Wait();

            var EntitiesApi = new Entities();

            Console.WriteLine("Entities");
            Console.WriteLine("Get 1");
            var item1 = EntitiesApi.Get(12);
            Console.WriteLine(item1.ToLongString());

            Console.WriteLine("Get N");
            var filter2 = new List<KeyValuePair<EntityFilterColumn, string>>()
            {
                new KeyValuePair<EntityFilterColumn, string>(EntityFilterColumn.texto, "508100496"),
            };

            var item2 = EntitiesApi.Get(0, 1, null, EntitySortColumn.id, Order.Desc);
            foreach (var item3 in item2)
            {
                Console.WriteLine(item3.ToLongString());
            }

            Console.WriteLine("Get 1 Async");
            Task.Run(async () =>
            {
                var item4 = await EntitiesApi.GetAsync(12);
                Console.WriteLine(item4.ToLongString());
            }).Wait();

            Console.WriteLine("Get N Async");
            Task.Run(async () =>
            {
                var item5 = await EntitiesApi.GetAsync(0, 1, null, EntitySortColumn.id, Order.Desc);
                foreach (var item6 in item5)
                {
                    Console.WriteLine(item6.ToLongString());
                }
            }).Wait();

            Console.ReadKey();
        }
    }
}
