using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sgBasePortalAPI.Helpers;

namespace sgBasePortalAPI
{
    public class Announcements
    {
        const string 
            BaseUrl = @"http://www.base.gov.pt/base2/rest/anuncios";

        public Announcements()
        {
        }

        public IEnumerable<Announcement> Get(
            int fromResultIndex, 
            int toResultIndex, 
            List<KeyValuePair<AnnouncementFilterColumn,string>> announcementFilterColumn, 
            AnnouncementSortColumn announcementSortColumn, 
            Order order
        )
        {
            var
                url = BuildGetListAnnouncementsRequest(announcementFilterColumn, announcementSortColumn, order);

            var
                rawJsonData = HttpHelper.GetRawJsonData(url, fromResultIndex, toResultIndex);
            
            return BuildGetListAnnouncementsResponse(rawJsonData);
        }

        public async Task<IEnumerable<Announcement>> GetAsync(
            int fromResultIndex,
            int toResultIndex,
            List<KeyValuePair<AnnouncementFilterColumn, string>> announcementFilterColumn,
            AnnouncementSortColumn announcementSortColumn,
            Order order
        )
        {
            var
                url = BuildGetListAnnouncementsRequest(announcementFilterColumn, announcementSortColumn, order);

            var
                rawJsonData = await HttpHelper.GetRawJsonDataAsync(url, fromResultIndex, toResultIndex);

            return BuildGetListAnnouncementsResponse(rawJsonData);
        }

        public Announcement Get(int id)
        {
            var
                url = BuildGetSingleAnnouncementRequest(id);

            var
                rawJsonData = HttpHelper.GetRawJsonData(url, 0, 0);

            return 
                BuildGetSingleAnnouncementResponse(rawJsonData);
        }

        public async Task<Announcement> GetAsync(int id)
        {
            var
                url = BuildGetSingleAnnouncementRequest(id);

            var
                rawJsonData = await HttpHelper.GetRawJsonDataAsync(url, 0, 0);

            return 
                BuildGetSingleAnnouncementResponse(rawJsonData);
        }

        private string BuildGetSingleAnnouncementRequest(int id)
        {
            var
                url = string.Format("{0}/{1}", BaseUrl, id);

            return
                url;
        }

        private Announcement BuildGetSingleAnnouncementResponse(string rawJsonData)
        {
            var
               objectFromJson = JsonConvert.DeserializeObject<AnnouncementJson>(rawJsonData);

            var
                objectToTypes = objectFromJson.ToBaseObject();

            return objectToTypes;
        }

        private string BuildGetListAnnouncementsRequest(
            List<KeyValuePair<AnnouncementFilterColumn, string>> announcementFilterColumn,
            AnnouncementSortColumn announcementSortColumn,
            Order order
        )
        {
            var
                url = string.Format("{0}?{1}sort({2}{3})",
                    BaseUrl,
                    announcementFilterColumn == null ? "" : string.Join("&", announcementFilterColumn.Select(_ => _.Key + "=" + _.Value)) + "&",
                    order == Order.Asc ? "+" : "-",
                    announcementSortColumn.ToString()
                );

            return
                url;
        }

        private IEnumerable<Announcement> BuildGetListAnnouncementsResponse(string rawJsonData)
        {
            var
               objectsFromJson = JsonConvert.DeserializeObject<List<AnnouncementJson>>(rawJsonData);

            var
                objectsToTypes = objectsFromJson
                    .Select(_ => _.ToBaseObject())
                    .ToList();

            return objectsToTypes;
        }
    }
}
