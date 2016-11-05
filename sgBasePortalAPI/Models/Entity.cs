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
    public enum EntitySortColumn
    {
        id,
        country,
        description,
        nif,
    }

    public enum EntityFilterColumn
    {
        texto,
    }

    [Serializable]
    public class Entity
    {
        public int id { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public string nif { get; set; }

        public string location { get; set; }
        public float sumTotalContractsGiven { get; set; }
        public float sumTotalContractsReceived { get; set; }
        public int totalContractsGiven { get; set; }
        public int totalContractsReceived { get; set; }

        public string ToLongString()
        {
            return
                JsonConvert.SerializeObject(this);
        }
    }

    [Serializable]
    internal class EntityJson
    {
        public int id { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public string nif { get; set; }

        public string location { get; set; }
        public string sumTotalContractsGiven { get; set; }
        public string sumTotalContractsReceived { get; set; }
        public string totalContractsGiven { get; set; }
        public string totalContractsReceived { get; set; }

        public Entity ToBaseObject()
        {
            return
                new Entity()
                {
                    id = id,
                    country = StringHelper.ClearString(country),
                    description = StringHelper.ClearString(description),
                    nif = StringHelper.ClearString(nif),

                    location = StringHelper.ClearString(location),
                    sumTotalContractsGiven = StringHelper.ClearFloat(sumTotalContractsGiven),
                    sumTotalContractsReceived = StringHelper.ClearFloat(sumTotalContractsReceived),
                    totalContractsGiven = StringHelper.ClearInt(totalContractsGiven),
                    totalContractsReceived = StringHelper.ClearInt(totalContractsReceived),
                };
        }
    }

}
