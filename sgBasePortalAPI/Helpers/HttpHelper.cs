using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sgBasePortalAPI.Helpers
{
    internal static class HttpHelper
    {
        internal static String GetRawJsonData(string url, int from, int to)
        {
            string
                response = string.Empty;

            MethodInfo
                method = typeof(WebHeaderCollection).GetMethod("AddWithoutValidate", BindingFlags.Instance | BindingFlags.NonPublic);

            HttpWebRequest
                httpWebRequest = (HttpWebRequest) WebRequest.Create(url);

            string 
                key = "Range",
                val = string.Format("items={0}-{1}", from, to);

            if (from >0 && to>0)
                method.Invoke(httpWebRequest.Headers, new object[] { key, val });

            using (WebResponse webResponse = httpWebRequest.GetResponse())
            {
                using (Stream stream = webResponse.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        response = streamReader.ReadToEnd();
                    }
                }
            }

            return
                response;
        }
    }
}
