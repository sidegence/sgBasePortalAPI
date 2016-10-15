using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using sgBasePortalAPI.Helpers;

namespace sgBasePortalAPI
{
    [Serializable]
    public class Announcement
    {
        public int id { get; set; }
        public string type { get; set; }
        public float basePrice { get; set; }
        public string contractDesignation { get; set; }
        public DateTime? drPublicationDate { get; set; }
        public DateTime? proposalDeadline { get; set; }
        public string contractingEntity { get; set; }

        public string ToLongString()
        {
            return
                string.Format("{0},\"{1}\",{2},\"{3}\",\"{4}\",\"{5}\",\"{6}\"",
                    id,
                    type,
                    basePrice,
                    contractDesignation,
                    drPublicationDate,
                    proposalDeadline,
                    contractingEntity
                );
        }
    }

    [Serializable]
    internal class AnnouncementJson
    {
        public int id { get; set; }
        public string type { get; set; }
        public string basePrice { get; set; }
        public string contractDesignation { get; set; }
        public string drPublicationDate { get; set; }
        public string proposalDeadline { get; set; }
        public string contractingEntity { get; set; }

        public Announcement ToAnnouncement()
        {
            return
                new Announcement()
                {
                    id = id,
                    type = StringHelper.ClearString(type),
                    basePrice = StringHelper.ClearFloat(basePrice),
                    contractDesignation = StringHelper.ClearString(contractDesignation),
                    drPublicationDate = StringHelper.ClearDate(drPublicationDate),
                    proposalDeadline = StringHelper.ClearDate(proposalDeadline),
                    contractingEntity = StringHelper.ClearString(contractingEntity),
                };
        }
    }
}
