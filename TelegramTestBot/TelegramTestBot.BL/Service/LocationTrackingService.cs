using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramTestBot.BL.Service
{
    public class LocationTrackingService
    {
        private const double EarthRadiusKm = 6371.0;
        public bool CalculateDistance(double latitudeOfUser, double longitudeOfUser)
        {
            double latitudeOfUniversity = 59.881627;  // Широта 
            double longitudeOfUniversity = 30.314824; // Долгота 

            var dLat = DegreeToRadian(latitudeOfUser - latitudeOfUniversity);
            var dLon = DegreeToRadian(longitudeOfUser - longitudeOfUniversity);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(DegreeToRadian(latitudeOfUniversity)) * Math.Cos(DegreeToRadian(latitudeOfUser)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = Math.Round(EarthRadiusKm * c, 3);

            if (distance <= 0.500)
            {
                return true;
            }
            return false;
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
