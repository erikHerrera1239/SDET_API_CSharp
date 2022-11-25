using System.Collections.Generic;

namespace SDETAPI_CSharp.Features.HealthcareGov.Models
{
    public class Glossary
    {
        public string date { get; set; }
        public string url { get; set; }
        public string content { get; set; }
        public List<string> tags { get; set; }
        public string title { get; set; }
        public List<string> categories { get; set; }
        public string lang { get; set; }
        public string layout { get; set; }
    }

}
