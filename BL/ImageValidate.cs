using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ImageValidate
    {
        public bool Validate(string ImagePath)
        {

            List<string> namesOfDrugs = new List<string> { "medicine", "pills", "pill", "pharmacy", "medical","medication"
            ,"drugs","drug","healthy","pill","bottle","prescription drug", "health"};

            bool Result = false;

            List<string> descriptions = new List<string>();
            ImageContent img = new ImageContent(ImagePath);
            double confidence = 50.0;
            img.ImageDetails = new Dictionary<string, double>();
            CheckImages dal = new CheckImages();
            dal.GetDescribtions(img);
            //check the confidence
            foreach (var item in img.ImageDetails)
            {
                if (item.Value > confidence)
                    descriptions.Add(item.Key);
            }
            //check if the image is suitable
            foreach (var item in descriptions)
            {
                //if item exist in our list
                foreach (var name in namesOfDrugs)
                {
                    if (name == item)
                        return true;
                }

            }

            return Result;
        }
    }
}
