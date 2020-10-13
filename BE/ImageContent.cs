using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class ImageContent
    {
        public int Id { get; set; }

        public string imagePath { get; set; }
        //key is detceted image content , value is probablity

        public Dictionary<string, double> ImageDetails { get; set; }

        public ImageContent(string imagePath)
        {
            this.imagePath = imagePath;
        }
    }
}

