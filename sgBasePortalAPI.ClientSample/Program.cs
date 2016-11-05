using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using sgBasePortalAPI;
using sgBasePortalAPI.Helpers;

namespace sgBasePortalAPI.ClientSample
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            var api = new Api();
            var items = 5;
            Stopwatch stopwatch = new Stopwatch();

            ConsoleKeyInfo input;
            do
            {
                Console.WriteLine("Usage:");
                Console.WriteLine(string.Format("[+][-] items to return in collections: {0}", items));
                Console.WriteLine(string.Format("[0]Contract [1]ContractAsync [2]Contracts({0}) [3]ContractsAsync({0})", items));
                Console.WriteLine(string.Format("[4]Entity [5]EntityAsync [6]Entities({0}) [7]EntitiesAsync({0})", items));
                Console.WriteLine(string.Format("[8]Announcement [9]AnnouncementAsync [A]Announcements({0}) [B]AnnouncementAsync({0})", items));
                input = Console.ReadKey(true);
                Console.Clear();

                stopwatch.Restart();

                if (input.Key == ConsoleKey.OemPlus)
                    items += 1;

                if (input.Key == ConsoleKey.OemMinus)
                    items -= 1;

                if (input.Key == ConsoleKey.D0)
                    Console.WriteLine(api.Contracts.Get(rnd.Next(0, 99999)).ToLongString());

                if (input.Key == ConsoleKey.D1)
                    Task.Run(async () =>
                    {
                        Console.WriteLine((await api.Contracts.GetAsync(rnd.Next(0, 99999))).ToLongString());
                    }).Wait();

                if (input.Key == ConsoleKey.D2)
                    foreach (var item in api.Contracts.Get(0, items-1, null, ContractSortColumn.id, Order.Desc))
                        Console.WriteLine(item.ToLongString() + "\n");

                if (input.Key == ConsoleKey.D3)
                    Task.Run(async () =>
                    {
                        foreach (var item in await api.Contracts.GetAsync(0, items-1, null, ContractSortColumn.id, Order.Desc))
                            Console.WriteLine(item.ToLongString() + "\n");
                    }).Wait();

                if (input.Key == ConsoleKey.D4)
                    Console.WriteLine(api.Entities.Get(rnd.Next(0, 99999)).ToLongString());

                if (input.Key == ConsoleKey.D5)
                    Task.Run(async () =>
                    {
                        Console.WriteLine((await api.Entities.GetAsync(rnd.Next(0, 99999))).ToLongString());
                    }).Wait();

                if (input.Key == ConsoleKey.D6)
                    foreach (var item in api.Entities.Get(0, items - 1, null, EntitySortColumn.id, Order.Desc))
                        Console.WriteLine(item.ToLongString() + "\n");

                if (input.Key == ConsoleKey.D7)
                    Task.Run(async () =>
                    {
                        foreach (var item in await api.Entities.GetAsync(0, items - 1, null, EntitySortColumn.id, Order.Desc))
                            Console.WriteLine(item.ToLongString() + "\n");
                    }).Wait();

                if (input.Key == ConsoleKey.D8)
                    Console.WriteLine(api.Announcements.Get(rnd.Next(0, 99999)).ToLongString());

                if (input.Key == ConsoleKey.D9)
                    Task.Run(async () =>
                    {
                        Console.WriteLine((await api.Announcements.GetAsync(rnd.Next(0, 99999))).ToLongString());
                    }).Wait();

                if (input.Key == ConsoleKey.A)
                    foreach (var item in api.Announcements.Get(0, items - 1, null, AnnouncementSortColumn.id, Order.Desc))
                        Console.WriteLine(item.ToLongString() + "\n");

                if (input.Key == ConsoleKey.B)
                    Task.Run(async () =>
                    {
                        foreach (var item in await api.Announcements.GetAsync(0, items - 1, null, AnnouncementSortColumn.id, Order.Desc))
                            Console.WriteLine(item.ToLongString() + "\n");
                    }).Wait();

                stopwatch.Stop();
                Console.WriteLine("\nElapsed {0} ms\n", stopwatch.ElapsedMilliseconds);
            }
            while (input.Key != ConsoleKey.Escape);

            var filter1 = new List<KeyValuePair<AnnouncementFilterColumn, string>>()
            {
                new KeyValuePair<AnnouncementFilterColumn, string>(AnnouncementFilterColumn.emissora, "508100496"),
                new KeyValuePair<AnnouncementFilterColumn, string>(AnnouncementFilterColumn.desdedatapublicacao, "2015-10-01"),
                new KeyValuePair<AnnouncementFilterColumn, string>(AnnouncementFilterColumn.desdeprecobase, "200000"),
            };

            var filter2 = new List<KeyValuePair<EntityFilterColumn, string>>()
            {
                new KeyValuePair<EntityFilterColumn, string>(EntityFilterColumn.texto, "508100496"),
            };
        }
    }
}
