using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Coordinates
    {
        public long PlaceId { get; set; }
        public string Licence { get; set; }
        public string OsmType { get; set; }
        public long OsmId { get; set; }
        public string[] Boundingbox { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string DisplayName { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public float Importance { get; set; }
    }
}
