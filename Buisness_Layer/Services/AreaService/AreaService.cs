using Common.FetchCoordinates;
using Core.Data;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Services.AreaService
{
    public class AreaService : IAreaService
    {
        private readonly List<AreaModel> _areas;
        private readonly ICoordinatesService _coordinatesService;
        private const double _EarthRadiusKm = 6371.0;
        public AreaService(ICoordinatesService coordinatesService)
        {
            _areas = AreaDb.areas;
            _coordinatesService = coordinatesService;
        }
        public async Task<string> GetAreaInspector(string targetAddress)
        {
            if(string.IsNullOrEmpty(targetAddress))
            {
                return "";
            }
            var targetCoordinates=await _coordinatesService.GetCoordinates(targetAddress);
            var target_latitude = Convert.ToDouble(targetCoordinates.Lat);
            var target_longitude = Convert.ToDouble(targetCoordinates.Lon);
            foreach (var area in _areas)
            {
                var startCoordinates = await _coordinatesService.GetCoordinates(area.StartAddress);
                var start_latitude = Convert.ToDouble(startCoordinates.Lat);
                var start_longitude = Convert.ToDouble(startCoordinates.Lon);
                var endCoordinates = await _coordinatesService.GetCoordinates(area.EndAddress);
                var end_latitude = Convert.ToDouble(endCoordinates.Lat);
                var end_longitude = Convert.ToDouble(endCoordinates.Lon);
                if (IsCoordinateBetweenPoints(start_latitude,start_longitude,end_latitude,end_longitude,target_latitude,target_longitude))
                {
                    return area.AreaInspector;
                }
            }
            
            return "";
        }
        bool IsCoordinateBetweenPoints(double startLat, double startLon, double endLat, double endLon, double targetLat, double targetLon)
        {
            bool withinLatBounds = (targetLat >= Math.Min(startLat, endLat)) && (targetLat <= Math.Max(startLat, endLat));
            bool withinLonBounds = (targetLon >= Math.Min(startLon, endLon)) && (targetLon <= Math.Max(startLon, endLon));

            return withinLatBounds && withinLonBounds;
        }

        
    }
}
