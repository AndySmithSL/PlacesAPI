using PlacesAPI.Code.Constants;
using PlacesAPI.Code.Interfaces;
using System.IO;
using System.Net;

namespace PlacesAPI.Code.Classes
{
    public class HttpWebRequestHandler : IRequestHandler
    {
        public string GetResponse(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.UserAgent = RequestConstants.UserAgentValue;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }

            return content;
        }
    }
}
