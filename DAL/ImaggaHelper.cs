﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ImaggaHelper
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Tag2
        {
            public string en { get; set; }
        }

        public class Tag
        {
            public double confidence { get; set; }
            public Tag2 tag { get; set; }
        }

        public class Result
        {
            public List<Tag> tags { get; set; }
        }

        public class Status
        {
            public string text { get; set; }
            public string type { get; set; }
        }

        public class Root
        {
            public Result result { get; set; }
            public Status status { get; set; }
        }

    }
}
