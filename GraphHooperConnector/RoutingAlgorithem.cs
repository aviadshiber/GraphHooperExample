using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphHooperConnector
{
    public interface RoutingAlgorithem
    {
        string getAlgorithemName();
    }
    // `dijkstra`, `astar`, `astarbi`, `alternative_route` and `round_trip` 
    public class Dijkstra : RoutingAlgorithem
    {
        public string getAlgorithemName()
        {
            return "dijkstra";
        }
    }
    public class Astar : RoutingAlgorithem
    {
        public string getAlgorithemName()
        {
            return "astar";
        }
    }
    public class Astarbi : RoutingAlgorithem
    {
        public string getAlgorithemName()
        {
            return "astarbi";
        }
    }
    public class AlternativeRoute : RoutingAlgorithem
    {
        public int? alternativeRouteMaxPaths { get; set; } = null;  // int? |this parameter sets the number of maximum paths which should be calculated. Increasing can lead to worse alternatives. (optional) 
        public int? alternativeRouteMaxWeightFactor { get; set; } = null;  // int? |this parameter sets the factor by which the alternatives routes can be longer than the optimal route. Increasing can lead to worse alternatives. (optional) 
        public int? alternativeRouteMaxShareFactor { get; set; } = null;  // int? | this parameter specifies how much alternatives routes can have maximum in common with the optimal route. Increasing can lead to worse alternatives. (optional) 
        public string getAlgorithemName()
        {
            return "alternative_route";
        }
    }
    public class RoundTrip : RoutingAlgorithem
    {
        public int? roundTripDistance { get; set; } = null;  // int? | this parameter configures approximative length of the resulting round trip (optional) 
        public long? roundTripSeed { get; set; } = null;  // long? | this parameter introduces randomness if e.g. the first try wasn't good. (optional) 
        public string getAlgorithemName()
        {
            return "round_trip";
        }
    }



}
