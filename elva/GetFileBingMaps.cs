using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace elva
{
    class GetFileBingMaps : IFileGetter
    {
        private string ApiKey { get { return "Ai_nhtBtkXgf-1d3TP3gnQGWx-avNrboHS2nzGmcozHIouVgqr99GFZXU9oLtOzP"; } }
        private string BaseAddress { get { return @"https://dev.virtualearth.net/REST/V1/Imagery/Map/Road/"; } }
        public Stream GetFile(string name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(BaseAddress);
            sb.Append(String.Format("/{0}", name));
            sb.Append(String.Format("?zoom={0}", 14));
            sb.Append(String.Format("&size=400,400"));
            sb.Append("&he=1");
            sb.Append(string.Format("&key=" + ApiKey));
            string url = sb.ToString();
            using (WebClient client = new WebClient())
            {
                var uri = new Uri(url);
                return client.OpenRead(uri);
            }
        }
    }
}
