using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using MedicalDataVisualization.Models;

namespace MedicalDataVisualization.Services
{
    public class DataGeneratorService
    {
        private readonly ConcurrentQueue<MedicalDataPoint> _dataQueue;
        private readonly Random _random;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly DataStreamConfig _config;

        public DataGeneratorService(DataStreamConfig config)
        {
            _dataQueue = new ConcurrentQueue<MedicalDataPoint>();
            _random = new Random();
            _config = config;
        }

        public async Task StartGeneratingData()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    var dataPoint = GenerateDataPoint();
                    _dataQueue.Enqueue(dataPoint);

                    while (_dataQueue.Count > _config.BufferSize)
                    {
                        _dataQueue.TryDequeue(out _);
                    }

                    await Task.Delay(1000 / _config.SamplingRateHz);
                }
            }
            catch (TaskCanceledException)
            {
                // Handle cancellation
            }
        }

        private MedicalDataPoint GenerateDataPoint()
        {
            return new MedicalDataPoint
            {
                Timestamp = DateTime.Now,
                HeartRate = 60 + _random.NextDouble() * 40,
                BloodPressureSystolic = 120 + _random.NextDouble() * 20,
                BloodPressureDiastolic = 80 + _random.NextDouble() * 10,
                OxygenSaturation = 95 + _random.NextDouble() * 5,
                Temperature = 36.5 + _random.NextDouble()
            };
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
        }

        public ConcurrentQueue<MedicalDataPoint> GetDataQueue() => _dataQueue;
    }
}