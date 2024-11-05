# Medical Data Visualization Tool

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
