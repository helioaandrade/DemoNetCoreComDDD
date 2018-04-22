using Poc.DemoNetCore.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Utils.Helpers
{
    public static class TrackingHelper
    {
        /// <summary>
        /// https://stackoverflow.com/questions/27928/calculate-distance-between-two-latitude-longitude-points-haversine-formula?rq=1
        /// </summary>


        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public static double CalculateDistance(Localizacao location1, Localizacao location2)
        {
            double circumference = 40000.0; // Earth's circumference at the equator in km
            double distance = 0.0;

            //Calculate radians
            double latitude1Rad = DegreesToRadians(location1.Latitude);
            double longitude1Rad = DegreesToRadians(location1.Longitude);
            double latititude2Rad = DegreesToRadians(location2.Latitude);
            double longitude2Rad = DegreesToRadians(location2.Longitude);

            double logitudeDiff = Math.Abs(longitude1Rad - longitude2Rad);

            if (logitudeDiff > Math.PI)
            {
                logitudeDiff = 2.0 * Math.PI - logitudeDiff;
            }

            double angleCalculation =
                Math.Acos(
                  Math.Sin(latititude2Rad) * Math.Sin(latitude1Rad) +
                  Math.Cos(latititude2Rad) * Math.Cos(latitude1Rad) * Math.Cos(logitudeDiff));

            distance = circumference * angleCalculation / (2.0 * Math.PI);

            return distance;
        }

        public static double CalculateDistance(params Localizacao[] locations)
        {
            double totalDistance = 0.0;

            for (int i = 0; i < locations.Length - 1; i++)
            {
                Localizacao current = locations[i];
                Localizacao next = locations[i + 1];

                totalDistance += CalculateDistance(current, next);
            }

            return totalDistance;
        }
        static class DistanceAlgorithm
        {
            const double PIx = 3.141592653589793;
            const double RADIUS = 6378.16;

            /// <summary>
            /// Convert degrees to Radians
            /// </summary>
            /// <param name="x">Degrees</param>
            /// <returns>The equivalent in radians</returns>
            public static double Radians(double x)
            {
                return x * PIx / 180;
            }

            /// <summary>
            /// Calculate the distance between two places.
            /// </summary>
            /// <param name="lon1"></param>
            /// <param name="lat1"></param>
            /// <param name="lon2"></param>
            /// <param name="lat2"></param>
            /// <returns></returns>
            public static double DistanceBetweenPlaces(
                double lon1,
                double lat1,
                double lon2,
                double lat2)
            {
                double dlon = Radians(lon2 - lon1);
                double dlat = Radians(lat2 - lat1);

                double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
                double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                return angle * RADIUS;
            }
        }

    }
}
