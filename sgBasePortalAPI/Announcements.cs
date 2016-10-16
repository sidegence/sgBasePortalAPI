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
            Url = @"http://www.base.gov.pt/base2/rest/anuncios";

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
                url = string.Format("{0}?{1}sort({2}{3})", 
                    Url,
                    announcementFilterColumn == null ? "" : string.Join("&", announcementFilterColumn.Select(_ => _.Key +"="+ _.Value)) + "&",
                    order == Order.Asc ? "+" : "-",
                    announcementSortColumn.ToString()
                );

            var
                rawJsonData = HttpHelper.GetRawJsonData(url, fromResultIndex, toResultIndex);
            
            var
               announcementJsonList = JsonConvert.DeserializeObject<List<AnnouncementJson>>(rawJsonData);

            var 
                announcementList = announcementJsonList
                    .Select(_ => _.ToAnnouncement())
                    .ToList();


            return announcementList;
        }

        public Announcement Get(int id)
        {
            var
                url = string.Format("{0}/{1}", Url, id);

            var
                rawJsonData = HttpHelper.GetRawJsonData(url, 0, 0);

            var
               announcementJson = JsonConvert.DeserializeObject<AnnouncementJson>(rawJsonData);

            var
                announcement = announcementJson
                    .ToAnnouncement();

            return announcement;
        }
    }
}
