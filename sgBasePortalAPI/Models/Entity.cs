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
    public class Entity
    {
        public int id { get; set; }
        public string description { get; set; }
        public string nif { get; set; }

        public string ToLongString()
        {
            return
                string.Format("\"{0}\",\"{1}\",{2}\"",
                    id,
                    description,
                    nif
                );
        }
    }
}
