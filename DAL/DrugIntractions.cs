using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class DrugIntractions
    {
        public string NDCtoRX(string drugCodeNDC)
        {
            string RXcode = "";

            string url = "https://rxnav.nlm.nih.gov/REST/rxcui?idtype=NDC&id=" + drugCodeNDC;
            string xml = new WebClient().DownloadString(url);
            XDocument doc = new XDocument();
            doc = XDocument.Parse(xml);


            RXcode = doc.Descendants("idGroup").Descendants("rxnormId").FirstOrDefault().ToString().Remove(0, 10).Remove(6);
            return RXcode;

        }
        public List<string> CheckPerscription(List<string> drugsCodes)
        {
            List<string> result = new List<string>();

            List<string> drugsCodesRx = new List<string>();
            foreach (var item in drugsCodes)
            {
                drugsCodesRx.Add(NDCtoRX(item));
            }

            string url = "https://rxnav.nlm.nih.gov/REST/interaction/list?rxcuis=";
            foreach (var item in drugsCodesRx)
            {
                url = url + item + "+";
            }
            url = url.Remove(url.Length - 1);

            string xml = new WebClient().DownloadString(url);
            XDocument doc = new XDocument();
            doc = XDocument.Parse(xml);


            if (!xml.Contains("comment"))
            {
                return new List<string>() { "There is no interaction" };
            };
            XElement root = XElement.Parse(xml);

            string comment = root.Elements("fullInteractionTypeGroup").Descendants("fullInteractionType").Descendants("comment").Select(s => s.Value)
             .Aggregate(new StringBuilder(), (s, i) => s.Append(i), s => s.ToString());
            string severity = root.Elements("fullInteractionTypeGroup").Descendants("fullInteractionType").Descendants("interactionPair").FirstOrDefault().Descendants("severity").Select(s => s.Value)
              .Aggregate(new StringBuilder(), (s, i) => s.Append("severity degrees: " + i + " "), s => s.ToString());
            string description = root.Elements("fullInteractionTypeGroup").Descendants("fullInteractionType").Descendants("interactionPair").FirstOrDefault().Descendants("description").Select(s => s.Value)
              .Aggregate(new StringBuilder(), (s, i) => s.Append(i + " "), s => s.ToString());

            result.Add(comment);
            result.Add(severity);
            result.Add(description);
            return result;

        }
    }
}

