using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features.HealthcareGov.Models
{
    public class Article
    {
        public string url { get; set; }
        public string content { get; set; }
        public List<object> tags { get; set; }
        public string title { get; set; }
        public List<object> categories { get; set; }
        public string lang { get; set; }
        public string layout { get; set; }
    }
}
