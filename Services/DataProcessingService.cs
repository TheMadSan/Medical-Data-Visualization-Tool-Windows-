using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalDataVisualization.Models;

namespace MedicalDataVisualization.Services
{
    public class DataProcessingService
    {
        private readonly object _lockObject = new object();
        private readonly Queue<double> _processingBuffer;
        private readonly int _bufferSize;

        public DataProcessingService(int bufferSize = 1000)
        {
            _bufferSize = bufferSize;
            _processingBuffer = new Queue<double>();
        }

        public async Task<Dictionary<string, double>> ProcessDataBatch(IEnumerable<MedicalDataPoint> dataPoints)
        {
            return await Task.Run(() =>
            {
                var results = new Dictionary<string, double>();

                lock (_lockObject)
                {
                    var points = dataPoints.ToList();
                    
                    results.Add("AverageHeartRate", points.Average(p => p.HeartRate));
                    results.Add("AverageSystolic", points.Average(p => p.BloodPressureSystolic));
                    results.Add("AverageDiastolic", points.Average(p => p.BloodPressureDiastolic));
                    results.Add("AverageO2", points.Average(p => p.OxygenSaturation));
                    results.Add("AverageTemp", points.Average(p => p.Temperature));
                }

                return results;
            });
        }
    }
}