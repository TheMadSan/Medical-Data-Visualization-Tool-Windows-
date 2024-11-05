namespace MedicalDataVisualization.Models
{
    public class DataStreamConfig
    {
        public int SamplingRateHz { get; set; } = 1000;
        public int BufferSize { get; set; } = 10000;
        public bool IsEnabled { get; set; } = true;
    }
}