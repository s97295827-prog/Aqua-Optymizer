# Aqua Optimizer

## Usage

1. Run the executable as **Administrator** (right-click > Run as administrator).
2. The program will display a colorful ASCII banner and a numbered menu.
3. Enter the number of the desired action and press **Enter**.
4. Follow any on-screen instructions.

## Safety Notes

- Many actions are **irreversible** (e.g., removing bloatware, disabling services).
- Always test on a non-production system first.
- Create a system restore point before using.
- Some features may require a system restart.

## Troubleshooting

- If you see permission errors, run the program as Administrator.
- If you see missing .NET errors, install [.NET 8 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or use the self-contained publish option.
- If system commands (e.g., `sc`, `defrag`, `powercfg`) are not found, ensure you are running on Windows.

## Release & Distribution

- To create a release, zip the contents of your publish folder and upload it to your GitHub release page.
- Tag your release in git:

Aqua Optimizer is a Windows console utility that applies various system optimizations, disables telemetry, cleans up temporary files, manages services, and more. It is designed for advanced users who want to quickly tune their Windows system for performance or gaming.

## Features

- Disable all telemetry (Windows, Office, Edge)
- Flush DNS cache
- Disable CoPilot AI in Windows 11 & Edge
- Clear temporary files
- Optimize system memory
- Defragment system drive
- Boost FPS for gamers (Strike mode)
- Remove unwanted startup programs
- Edit system variable paths
- Disable unnecessary Windows services
- Optimize graphics driver settings (NVIDIA, AMD, Intel)
- Clean up background processes
- Adjust Windows for best performance
- Update DirectX and GPU drivers
- Ultimate FPS Boost (removes bloatware, optimizes services, cleans system)
- Extreme Gaming Mode (max FPS, deep bloatware removal, hardcore optimization)
- Show changelog

## Requirements

- Windows 10 or 11
- .NET 8.0 Runtime (or publish as self-contained)
- Administrator privileges (required for most features)

## Installation

### Method 1: Using Visual Studio

1. Open the solution in Visual Studio 2022 or newer.
2. Set configuration to **Release**.
3. Build the project (`Build > Build Solution`).
4. (Optional) Use **Publish** to create a single executable:
   - Right-click the project > **Publish...**
   - Choose **Folder** profile.
   - Set target runtime (e.g. `win-x64`).
   - Enable **Produce single file** and **Trim unused assemblies** if desired.
   - Click **Publish**.

### Method 2: Using .NET CLI

1. Open a terminal in the project directory.
2. Build the project:
