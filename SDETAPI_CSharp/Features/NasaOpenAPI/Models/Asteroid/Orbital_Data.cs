namespace SDETAPI_CSharp.Features.NasaOpenAPI.Models.Asteroid
{
    public class Orbital_Data
    {
        public string orbit_id { get; set; }
        public string orbit_determination_date { get; set; }
        public string first_observation_date { get; set; }
        public string last_observation_date { get; set; }
        public int data_arc_in_days { get; set; }
        public int observations_used { get; set; }
        public string orbit_uncertainty { get; set; }
        public string minimum_orbit_intersection { get; set; }
        public string jupiter_tisserand_invariant { get; set; }
        public string epoch_osculation { get; set; }
        public string eccentricity { get; set; }
        public string semi_major_axis { get; set; }
        public string inclination { get; set; }
        public string ascending_node_longitude { get; set; }
        public string orbital_period { get; set; }
        public string perihelion_distance { get; set; }
        public string perihelion_argument { get; set; }
        public string aphelion_distance { get; set; }
        public string perihelion_time { get; set; }
        public string mean_anomaly { get; set; }
        public string mean_motion { get; set; }
        public string equinox { get; set; }
        public Orbit_Class orbit_class { get; set; }
    }

}
