using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features.NasaOpenAPI.Models.Asteroid
{
    public class AsteroidResponseModel
    {
        public Links links { get; set; }
        public string id { get; set; }
        public string neo_reference_id { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
        public string nasa_jpl_url { get; set; }
        public float absolute_magnitude_h { get; set; }
        public Estimated_Diameter estimated_diameter { get; set; }
        public bool is_potentially_hazardous_asteroid { get; set; }
        public Close_Approach_Data[] close_approach_data { get; set; }
        public Orbital_Data orbital_data { get; set; }
        public bool is_sentry_object { get; set; }
    }
}
