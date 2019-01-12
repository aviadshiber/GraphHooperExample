using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace GraphHooperConnector {
    public class GraphHooperConnectorImpl : IGraphHooperConnector {
        private GeocodingApi geoApi;
        private RoutingApi routeApi;
        private string apiKey;
        private const string DEFAULT_BASE_URL = "https://graphhopper.com/api/1";
        //aditonal configurations

        bool? reverse { get; set; } = null;  // bool? | Set to true to do a reverse Geocoding request, see point parameter (optional) 
        public bool? pointsEncoded { get; set; } = false;  // bool? | IMPORTANT- TODO - currently you have to pass false for the swagger client - Have not found a way to force add a parameter. If `false` the coordinates in `point` and `snapped_waypoints` are returned as array using the order [lon,lat,elevation] for every point. If `true` the coordinates will be encoded as string leading to less bandwith usage. You'll need a special handling for the decoding of this string on the client-side. We provide open source code in [Java](https://github.com/graphhopper/graphhopper/blob/d70b63660ac5200b03c38ba3406b8f93976628a6/web/src/main/java/com/graphhopper/http/WebHelper.java#L43) and [JavaScript](https://github.com/graphhopper/graphhopper/blob/d70b63660ac5200b03c38ba3406b8f93976628a6/web/src/main/webapp/js/ghrequest.js#L139). It is especially important to use no 3rd party client if you set `elevation=true`!
        private string locale = "en";  // string | The locale of the resulting turn instructions. E.g. `pt_PT` for Portuguese or `de` for German (optional) 
        private bool? instructions = true;  // bool? | If instruction should be calculated and returned (optional) 
        public string vehicle { get; set; } = "foot";  // string | The vehicle for which the route should be calculated. Other vehicles are foot, small_truck, ... (optional) 
        private bool? elevation = false;  // bool? | If `true` a third dimension - the elevation - is included in the polyline or in the GeoJson. If enabled you have to use a modified version of the decoding method or set points_encoded to `false`. See the points_encoded attribute for more details. Additionally a request can fail if the vehicle does not support elevation. See the features object for every vehicle. (optional) 
        public bool? calcPoints { get; set; } = true;  // bool? | If the points for the route should be calculated at all printing out only distance and time. (optional) 
        List<string> pointHint = null; // List<string> | Optional parameter. Specifies a hint for each `point` parameter to prefer a certain street for the closest location lookup. E.g. if there is an address or house with two or more neighboring streets you can control for which street the closest location is looked up. (optional) 
        public bool? chDisable { get; } = true;  // bool? | Use this parameter in combination with one or more parameters of this table (optional) 
        public string weighting { get; set; } = "short_fastest";  // string | Which kind of 'best' route calculation you need. Other option is `shortest` (e.g. for `vehicle=foot` or `bike`), `short_fastest` if time and distance is expensive e.g. for `vehicle=truck` (optional) 
        public bool? edgeTraversal { get; set; } = null;  // bool? | Use `true` if you want to consider turn restrictions for bike and motor vehicles. Keep in mind that the response time is roughly 2 times slower. (optional) 
        private string algorithm = null;  // string | The algorithm to calculate the route. Other options are `dijkstra`, `astar`, `astarbi`, `alternative_route` and `round_trip` (optional) 

        public int? headingPenalty = null;  // int? | Penalty for omitting a specified heading. The penalty corresponds to the accepted time delay in seconds in comparison to the route without a heading. (optional) 
        public bool? passThrough = null;  // bool? | If `true` u-turns are avoided at via-points with regard to the `heading_penalty`. (optional) 

        private int? roundTripDistance = null;  // int? | If `algorithm=round_trip` this parameter configures approximative length of the resulting round trip (optional) 
        private long? roundTripSeed = null;  // long? | If `algorithm=round_trip` this parameter introduces randomness if e.g. the first try wasn't good. (optional) 
        private int? alternativeRouteMaxPaths = null;  // int? | If `algorithm=alternative_route` this parameter sets the number of maximum paths which should be calculated. Increasing can lead to worse alternatives. (optional) 
        private int? alternativeRouteMaxWeightFactor = null;  // int? | If `algorithm=alternative_route` this parameter sets the factor by which the alternatives routes can be longer than the optimal route. Increasing can lead to worse alternatives. (optional) 
        private int? alternativeRouteMaxShareFactor = null;  // int? | If `algorithm=alternative_route` this parameter specifies how much alternatives routes can have maximum in common with the optimal route. Increasing can lead to worse alternatives. (optional) 
        private string avoid = null; // string | comma separate list to avoid certain roads. You can avoid motorway, ferry, tunnel or track (optional) 

        List<string> details = null; // List<string> | List of additional trip attributes to be returned. Try some of the following: `average_speed`, `street_name`, `edge_id`, `time`, `distance`. (optional) 
        const int RESULT_LIMIT = 1;
        public GraphHooperConnectorImpl(string apiKey, string baseUrl = DEFAULT_BASE_URL) {
            this.apiKey = apiKey;
            //geocoding is not supported as part of graphhopper server: https://github.com/graphhopper/directions-api/issues/2
            geoApi = new GeocodingApi(DEFAULT_BASE_URL);
            routeApi = new RoutingApi(baseUrl);

        }

        public Coordinate getCoordiantes(string location) {
            GeocodingResponse result = geoApi.GeocodeGet(apiKey, location, locale, RESULT_LIMIT, reverse);
            Coordinate coordinate = new Coordinate();
            if (result != null && result.Hits.Count > 0) {
                coordinate.latitude = result.Hits[0].Point.Lat;
                coordinate.longitude = result.Hits[0].Point.Lng;

            }
            return coordinate;
        }

        public async Task<Coordinate> getCoordiantesAsync(string location) {
            GeocodingResponse result =await geoApi.GeocodeGetAsync(apiKey, location, locale, RESULT_LIMIT, reverse);
            Coordinate coordinate = new Coordinate();
            if (result != null && result.Hits.Count > 0) {
                coordinate.latitude =  result.Hits[0].Point.Lat;
                coordinate.longitude =  result.Hits[0].Point.Lng;
            }
            return coordinate;
        }


        public RouteResponse getRouth(Coordinate src, Coordinate dest, int? azimuth = null) {
            var points = new List<string> { src.ToString(), dest.ToString() };
            RouteResponse result = routeApi.RouteGet(points, pointsEncoded, apiKey, locale, instructions, vehicle, elevation, calcPoints, pointHint, chDisable, weighting, edgeTraversal, algorithm, azimuth, headingPenalty, passThrough, details, roundTripDistance, roundTripSeed, alternativeRouteMaxPaths, alternativeRouteMaxWeightFactor, alternativeRouteMaxShareFactor, avoid?.ToString().ToLower());
            return result;
        }

        public async Task<RouteResponse> getRouthAsync(Coordinate src, Coordinate dest, int? azimuth = null) {
            var points = new List<string> { src.ToString(), dest.ToString() };
            return await routeApi.RouteGetAsync(points, pointsEncoded, apiKey, locale, instructions, vehicle, elevation, calcPoints, pointHint, chDisable, weighting, edgeTraversal, algorithm, azimuth, headingPenalty, passThrough, details, roundTripDistance, roundTripSeed, alternativeRouteMaxPaths, alternativeRouteMaxWeightFactor, alternativeRouteMaxShareFactor, avoid?.ToString().ToLower()); ;
        }

        public GraphHooperConnectorImpl Algorithem(RoutingAlgorithem algo) {
            this.alternativeRouteMaxPaths = null;
            this.alternativeRouteMaxShareFactor = null;
            this.alternativeRouteMaxWeightFactor = null;
            this.roundTripSeed = null;
            this.roundTripDistance = null;
            this.algorithm = algo.getAlgorithemName();
            if (algo is RoundTrip) {
                RoundTrip rt = (RoundTrip)algo;
                this.roundTripSeed = rt.roundTripSeed;
                this.roundTripDistance = rt.roundTripDistance;
            } else if (algo is AlternativeRoute) {
                AlternativeRoute ar = (AlternativeRoute)algo;
                this.alternativeRouteMaxPaths = ar.alternativeRouteMaxPaths;
                this.alternativeRouteMaxShareFactor = ar.alternativeRouteMaxShareFactor;
                this.alternativeRouteMaxWeightFactor = ar.alternativeRouteMaxWeightFactor;
            }
            return this;
        }
        public GraphHooperConnectorImpl Local(string local) {
            this.locale = local;
            return this;
        }
        public string getLocal() {
            return this.locale;
        }
        public GraphHooperConnectorImpl Elevation(bool? value) {
            this.elevation = value;
            return this;
        }
        public bool? getElevation() {
            return this.elevation;
        }
        public GraphHooperConnectorImpl HeadingPenalty(int? penalty, bool? avoidUTurns = null) {
            this.headingPenalty = penalty;
            this.passThrough = avoidUTurns;
            return this;
        }
        public int? getHeadingPenalty() {
            return this.headingPenalty;
        }
        public bool? getAvoidUturns() {
            return this.passThrough;
        }
        public GraphHooperConnectorImpl AvoidRoad(List<AvoidRoadTypes> types) {
            if (types.Count > 0) {
                this.avoid = "";
                for (int i = 0; i < types.Count; i++) {

                    this.avoid += types[i].ToString();
                    if (i < types.Count - 1) {
                        this.avoid += ",";
                    }
                }
            } else {
                this.avoid = null;
            }
            return this;
        }
      




    }

}
