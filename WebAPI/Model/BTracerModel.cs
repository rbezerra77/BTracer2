using System;
using System.Numerics;

namespace WebAPI.Model
{
    public class BTracerModel
    {
        public String id { get; set; }
        public String orderno { get; set; }
        public String  process { get; set; }
        public String  operation { get; set; }
        public String  production { get; set; }
        public String  year { get; set; }
        public String  lastsequence { get; set; }
        public String  tckr_type { get; set; }
        public String  comments { get; set; }
        public String  usage { get; set; }
        public String  farm { get; set; }
        public String  farmer { get; set; }
        public String  variety { get; set; }
        public String  weather { get; set; }
        public String  region { get; set; }
    }
}