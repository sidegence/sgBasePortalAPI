using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sgBasePortalAPI.Helpers
{
    internal static class JsonHelper
    {
        internal static T Get<T, TJson>(
            string baseUrl,
            int id,
            Func<TJson, T> transform
        )
        {
            var
                url = string.Format("{0}/{1}", baseUrl, id);

            var
                rawJsonData = HttpHelper.GetRawJsonData(url, 0, 0);

            var
                objectFromJson = JsonConvert.DeserializeObject<TJson>(rawJsonData);

            return
                transform.Invoke(objectFromJson);
        }

        internal static async Task<T> GetAsync<T, TJson>(
            string baseUrl,
            int id,
            Func<TJson, T> transform
        )
        {
            var
                url = string.Format("{0}/{1}", baseUrl, id);

            var
                rawJsonData = await HttpHelper.GetRawJsonDataAsync(url, 0, 0);

            var
                objectFromJson = await Task.Run(() => JsonConvert.DeserializeObject<TJson>(rawJsonData));

            return
                transform.Invoke(objectFromJson);
        }

        internal static IEnumerable<T> Get<T, TJson, TFilterColumn, TSortColumn>(
            string baseUrl, 
            int fromResultIndex,
            int toResultIndex,
            List<KeyValuePair<TFilterColumn, string>> filterColumn,
            TSortColumn sortColumn,
            Order order,
            Func<TJson, T> transform
        )
        {
            var
                url = string.Format("{0}?{1}sort({2}{3})",
                    baseUrl,
                    filterColumn == null ? "" : string.Join("&", filterColumn.Select(_ => _.Key + "=" + _.Value)) + "&",
                    order == Order.Asc ? "+" : "-",
                    sortColumn.ToString()
                );

            var
                rawJsonData = HttpHelper.GetRawJsonData(url, fromResultIndex, toResultIndex);

            var
               objectsFromJson = JsonConvert.DeserializeObject<List<TJson>>(rawJsonData);

            var
                objectsToTypes = objectsFromJson
                    .Select(transform)
                    .ToList();

            return objectsToTypes;
        }

        internal static async Task<IEnumerable<T>> GetAsync<T, TJson, TFilterColumn, TSortColumn>(
            string baseUrl,
            int fromResultIndex,
            int toResultIndex,
            List<KeyValuePair<TFilterColumn, string>> filterColumn,
            TSortColumn sortColumn,
            Order order,
            Func<TJson, T> transform
        )
        {
            var
                url = string.Format("{0}?{1}sort({2}{3})",
                    baseUrl,
                    filterColumn == null ? "" : string.Join("&", filterColumn.Select(_ => _.Key + "=" + _.Value)) + "&",
                    order == Order.Asc ? "+" : "-",
                    sortColumn.ToString()
                );

            var
                rawJsonData = await HttpHelper.GetRawJsonDataAsync(url, fromResultIndex, toResultIndex);

            var
                objectsFromJson = await Task.Run(() => JsonConvert.DeserializeObject<List<TJson>>(rawJsonData));

            var
                objectsToTypes = objectsFromJson
                    .Select(transform)
                    .ToList();

            return objectsToTypes;
        }
    }
}
