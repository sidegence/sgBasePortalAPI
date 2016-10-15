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
        public Announcements()
        {
        }

        public IEnumerable<Announcement> Search()
        {
            var 
                rawJsonData = HttpHelper.GetRawJsonData("http://www.base.gov.pt/base2/rest/anuncios?sort(-id)", 1, 1);

            var
               announcementJsonList = JsonConvert.DeserializeObject<List<AnnouncementJson>>(rawJsonData);

            var 
                announcementList = announcementJsonList
                    .Select(_ => _.ToAnnouncement())
                    .ToList();


            return announcementList;
        }
    }
}
