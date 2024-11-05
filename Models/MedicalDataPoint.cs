using System;

namespace MedicalDataVisualization.Models
{
    public class MedicalDataPoint
    {
        public DateTime Timestamp { get; set; }
        public double HeartRate { get; set; }
        public double BloodPressureSystolic { get; set; }
        public double BloodPressureDiastolic { get; set; }
        public double OxygenSaturation { get; set; }
        public double Temperature { get; set; }
    }
}