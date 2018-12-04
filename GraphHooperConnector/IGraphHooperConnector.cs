using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphHooperConnector
{
    public interface IGraphHooperConnector
    {
        Coordinate getCoordiantes(string location);

        RouteResponse getRouth(Coordinate src, Coordinate dest,int? azimuth =null);
    }
    public class Coordinate {
        public Coordinate() {
            latitude = null;
            longitude = null;
        }
        public Coordinate(double? latitude, double? longitude) {
            this.latitude = latitude;
            this.longitude = longitude;
        }
       public double? latitude { get; set; }
       public double? longitude { get; set; }

        public override string ToString() {
            return $"{latitude},{longitude}";
        }
    }
    public enum AvoidRoadTypes
    {
        Motorway, Ferry, Tunnel, Track
    }
}
