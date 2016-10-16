using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sgBasePortalAPI.Helpers;

namespace sgBasePortalAPI
{
    public class Entities
    {
        const string 
            BaseUrl = @"http://www.base.gov.pt/base2/rest/entidades";

        public Entities()
        {
        }

        public IEnumerable<Entity> Get(
            int fromResultIndex, 
            int toResultIndex, 
            List<KeyValuePair<EntityFilterColumn, string>> filterColumn,
            EntitySortColumn sortColumn, 
            Order order
        )
        {
            var
                url = BuildGetListRequestUrl(filterColumn, sortColumn, order);

            var
                rawJsonData = HttpHelper.GetRawJsonData(url, fromResultIndex, toResultIndex);
            
            return BuildGetListResponseObjects(rawJsonData);
        }

        public async Task<IEnumerable<Entity>> GetAsync(
            int fromResultIndex,
            int toResultIndex,
            List<KeyValuePair<EntityFilterColumn, string>> filterColumn,
            EntitySortColumn sortColumn,
            Order order
        )
        {
            var
                url = BuildGetListRequestUrl(filterColumn, sortColumn, order);

            var
                rawJsonData = await HttpHelper.GetRawJsonDataAsync(url, fromResultIndex, toResultIndex);

            return BuildGetListResponseObjects(rawJsonData);
        }

        public Entity Get(int id)
        {
            var
                url = BuildGetSingleRequestUrl(id);

            var
                rawJsonData = HttpHelper.GetRawJsonData(url, 0, 0);

            return 
                BuildGetSingleResponseObject(rawJsonData);
        }

        public async Task<Entity> GetAsync(int id)
        {
            var
                url = BuildGetSingleRequestUrl(id);

            var
                rawJsonData = await HttpHelper.GetRawJsonDataAsync(url, 0, 0);

            return
                BuildGetSingleResponseObject(rawJsonData);
        }

        private string BuildGetSingleRequestUrl(int id)
        {
            var
                url = string.Format("{0}/{1}", BaseUrl, id);

            return
                url;
        }

        private Entity BuildGetSingleResponseObject(string rawJsonData)
        {
            var
               objectFromJson = JsonConvert.DeserializeObject<EntityJson>(rawJsonData);

            var
                objectToTypes = objectFromJson.ToBaseObject();

            return objectToTypes;
        }

        private string BuildGetListRequestUrl(
            List<KeyValuePair<EntityFilterColumn, string>> filterColumn,
            EntitySortColumn sortColumn,
            Order order
        )
        {
            var
                url = string.Format("{0}?{1}sort({2}{3})",
                    BaseUrl,
                    filterColumn == null ? "" : string.Join("&", filterColumn.Select(_ => _.Key + "=" + _.Value)) + "&",
                    order == Order.Asc ? "+" : "-",
                    sortColumn.ToString()
                );

            return
                url;
        }

        private IEnumerable<Entity> BuildGetListResponseObjects(string rawJsonData)
        {
            var
               objectsFromJson = JsonConvert.DeserializeObject<List<EntityJson>>(rawJsonData);

            var
                objectsToTypes = objectsFromJson
                    .Select(_ => _.ToBaseObject())
                    .ToList();

            return objectsToTypes;

        }
    }
}
