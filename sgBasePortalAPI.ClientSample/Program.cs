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
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            var api = new Api();

            ConsoleKeyInfo input;
            do
            {
                Console.WriteLine("Usage: [0]Contract [1]ContractAsync [2]Contracts [3]ContractsAsync");
                input = Console.ReadKey();

                if (input.Key == ConsoleKey.D0)
                    Console.WriteLine(api.Contracts.Get(rnd.Next(0, 99999)).ToLongString());

                if (input.Key == ConsoleKey.D1)
                    Task.Run(async () =>
                    {
                        Console.WriteLine((await api.Contracts.GetAsync(rnd.Next(0, 99999))).ToLongString());
                    }).Wait();

                if (input.Key == ConsoleKey.D2)
                    foreach (var item in api.Contracts.Get(0, 1, null, ContractSortColumn.id, Order.Desc))
                        Console.WriteLine(item.ToLongString());

                if (input.Key == ConsoleKey.D3)
                    Task.Run(async () =>
                    {
                        foreach (var item in await api.Contracts.GetAsync(0, 1, null, ContractSortColumn.id, Order.Desc))
                            Console.WriteLine(item.ToLongString());
                    }).Wait();
               
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
