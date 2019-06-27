using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace algorithm
{
    public class Copy : ICloneable
    {
        public string name { get; set; }
        public string Age { get; set; }
        public object Clone()
        {
            string str=JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Copy>(str);            
        }
    }
}
