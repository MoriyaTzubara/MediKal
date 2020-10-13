using BE;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.ImaggaHelper;

namespace DAL
{
    public class CheckImages
    {
        public void GetDescribtions(ImageContent current)
        {
            string apiKey = "acc_24c272f71461e5c";
            string apiSecret = "e530b13cdad750e7b0b20de12304b34a";
            string image = current.imagePath;

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));
            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            request.AddFile("image", image);

            IRestResponse response = client.Execute(request);

            Root DetailsTree = JsonConvert.DeserializeObject<Root>(response.Content);

            foreach (var item in DetailsTree.result.tags)
            {
                current.ImageDetails.Add(item.tag.en, item.confidence);
            }


        }
    }

}
