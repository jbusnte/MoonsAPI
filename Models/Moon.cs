using System;

namespace MoonsAPI.Models
{
    public class Moon
    {
        public int MoonId { get; set; }
        public string MoonName { get; set; }
        public string DiscoveryYear { get; set; }
        public string DiscoveredBy { get; set; }
        public Parent Parent { get; set; }
    }
}
