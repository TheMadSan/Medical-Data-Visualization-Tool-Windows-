using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using MedicalDataVisualization.Services;
using MedicalDataVisualization.Models;

namespace MedicalDataVisualization.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DataGeneratorService _dataGenerator;
        private readonly DataProcessingService _dataProcessor;
        private bool _isRunning;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            var config = new DataStreamConfig();
            _dataGenerator = new DataGeneratorService(config);
            _dataProcessor = new DataProcessingService();
            
            StartCommand = new RelayCommand(async () => await Start(), () => !IsRunning);
            StopCommand = new RelayCommand(() => Stop(), () => IsRunning);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                _isRunning = value;
                OnPropertyChanged(nameof(IsRunning));
            }
        }

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }

        private async Task Start()
        {
            IsRunning = true;
            await _dataGenerator.StartGeneratingData();
        }

        private void Stop()
        {
            _dataGenerator.Stop();
            IsRunning = false;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object parameter) => _execute();
    }
}