# Medical Data Visualization Tool

[Upflowchart TB
    subgraph UI["User Interface Layer"]
        MW["MainWindow.xaml"]
        CV["ChartView.xaml"]
    end

    subgraph VM["ViewModel Layer"]
        MVM["MainViewModel"]
        CVM["ChartViewModel"]
    end

    subgraph Services["Services Layer"]
        DGS["DataGeneratorService"]
        DPS["DataProcessingService"]
    end

    subgraph Models["Model Layer"]
        MDP["MedicalDataPoint"]
        DSC["DataStreamConfig"]
    end

    subgraph DataFlow["Data Flow"]
        Queue["ConcurrentQueue"]
        Buffer["ProcessingBuffer"]
    end

    MW --> MVM
    CV --> CVM
    MVM --> DGS
    MVM --> DPS
    CVM --> DPS
    DGS --> Queue
    DPS --> Buffer
    Queue --> DPS
    DGS --> MDP
    DGS --> DSC
loading system-architecture.mermaid…]()


A high-performance Windows desktop application for real-time medical data visualization using C# and .NET Framework. This application demonstrates advanced WPF development with MVVM architecture, capable of processing and visualizing 1M+ data points per second while maintaining sub-50ms refresh rates.

## 🚀 Features

- **Real-time Data Processing**: Handle 1M+ data points per second
- **Multi-threaded Architecture**: Optimized performance with concurrent operations
- **Medical Metrics Visualization**:
  - Heart Rate Monitoring
  - Blood Pressure (Systolic/Diastolic)
  - Oxygen Saturation
  - Body Temperature
- **Configurable Sampling Rates**: Adjustable data collection frequency
- **Buffer Management**: Efficient memory utilization
- **High-Performance UI**: Sub-50ms refresh rates

## 📋 System Requirements

- Windows 10 or later
- .NET 6.0 Runtime
- Visual Studio 2022 (for development)
- 8GB RAM (minimum)
- 4-core CPU (recommended)

## 🛠️ Technology Stack

- **Framework**: .NET 6.0
- **Language**: C# 10.0
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Architecture**: MVVM (Model-View-ViewModel)
- **Visualization**: LiveCharts
- **Threading**: TPL (Task Parallel Library)
- **Data Structures**: ConcurrentQueue

## 🏗️ Architecture

The application follows a clean MVVM architecture with four distinct layers:

- **UI Layer (Views)**:
  - `MainWindow.xaml`
  - `ChartView.xaml`
  - Responsible for user interaction and data visualization

- **ViewModel Layer**:
  - `MainViewModel`
  - `ChartViewModel`
  - Handles UI logic and data preparation

- **Services Layer**:
  - `DataGeneratorService`: Simulates medical sensor data
  - `DataProcessingService`: Processes raw data for visualization

- **Model Layer**:
  - `MedicalDataPoint`: Core data structure
  - `DataStreamConfig`: Configuration settings

## 🚀 Getting Started

### Prerequisites

```bash
# Clone the repository
git clone https://github.com/yourusername/medical-data-visualization.git

# Navigate to project directory
cd medical-data-visualization

# Restore NuGet packages
dotnet restore
```


## Building the Project

```bash
# Build the solution
dotnet build

# Run the application
dotnet run --project MedicalDataVisualization
```

## Running Tests

```bash
dotnet test
```

## 📊 Performance Metrics

- **Data Processing Rate**: 1M+ points/second
- **UI Refresh Rate**: < 50ms
- **Memory Usage**: ~200MB baseline
- **CPU Usage**: 15-30% (4-core system)

## 🔧 Configuration

The application can be configured through `DataStreamConfig.cs`:

```csharp
public class DataStreamConfig
{
    public int SamplingRateHz { get; set; } = 1000;
    public int BufferSize { get; set; } = 10000;
    public bool IsEnabled { get; set; } = true;
}
```
## 📝 Code Style

This project follows Microsoft's C# coding conventions and StyleCop rules. Key points:

- Use **PascalCase** for public members
- Use **camelCase** for private members
- Prefix private fields with an underscore
- Use **XML documentation** for public APIs

## 🔍 Testing

The project includes:

- **Unit Tests**
- **Integration Tests**
- **Performance Tests**

Run tests using:

```bash
dotnet test --filter "Category=Unit"
dotnet test --filter "Category=Integration"
dotnet test --filter "Category=Performance"
```

## 📦 Dependencies

- **LiveCharts.Wpf** (0.9.7)
- **Microsoft.NET.Test.Sdk** (17.5.0)
- **NUnit** (3.13.3)
- **Moq** (4.18.4)

## 🔐 Security

- **Input validation** for all user inputs
- **Secure data handling** practices
- **Memory management optimization**
- **Error logging and handling**


