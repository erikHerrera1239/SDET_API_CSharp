using System.Collections.Generic;

namespace SDETAPI_CSharp.Features.HealthcareGov.Models
{
    public class Blog
    {
        public List<string> categories { get; set; }
        public string title { get; set; }
        public string lang { get; set; }
        public string layout { get; set; }
        public List<string> topics { get; set; }
        public string date { get; set; }
        public List<object> tags { get; set; }
        public string content { get; set; }
        public string url { get; set; }
    }
}
