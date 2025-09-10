using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;

internal static class Program
{
    private static readonly System.ConsoleColor[] rainbow = new[]
    {
        System.ConsoleColor.Red,
        System.ConsoleColor.DarkYellow,
        System.ConsoleColor.Yellow,
        System.ConsoleColor.Green,
        System.ConsoleColor.Cyan,
        System.ConsoleColor.Blue,
        System.ConsoleColor.Magenta
    };

    private static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        System.Console.CursorVisible = true;

        string[] artLines = new[]
        {
@"  _____                        ________          __                 .__                     ",
@"  /  _  \   ________ _______    \_____  \ _______/  |_ ___.__. _____ |__|_______ ___________ ",
@" /  /_\  \ / ____/  |  \__  \    /   |   \\____ \   __<   |  |/     \|  \___   // __ \_  __ \",
@"/    |    < <_|  |  |  // __ \_ /    |    \  |_> >  |  \___  |  Y Y  \  |/    /\  ___/|  | \/",
@"\____|__  /\__   |____/(____  / \_______  /   __/|__|  / ____|__|_|  /__/_____ \\___  >__|   ",
@"        \/    |__|          \/          \/|__|         \/          \/         \/    \/       "
        };

        for (int lineIndex = 0; lineIndex < artLines.Length; lineIndex++)
        {
            string line = artLines[lineIndex];
            for (int i = 0; i < line.Length; i++)
            {
                System.Console.ForegroundColor = rainbow[(i + lineIndex) % rainbow.Length];
                System.Console.Write(line[i]);
            }
            System.Console.WriteLine();
        }

        PrintRainbow("https://discord.gg/HbreZaau", rainbow);
        System.Console.WriteLine();
        PrintRainbow("Aqua Optimizer created by Chinollek for Vertex Shop. If you bought it, you've been scammed.", rainbow);
        System.Console.WriteLine();
        PrintRainbow("Version 1.0 Release", rainbow);
        System.Console.WriteLine();

        System.Console.ResetColor();
        System.Console.WriteLine();

        string[] options = new[]
        {
            "Disable all telemetry",
            "Flush DNS cache",
            "Disable CoPilot AI in Windows 11 & Edge",
            "Clear temporary files",
            "Optimize system memory",
            "Defragment system drive",
            "Strike: Boost FPS for gamers",
            "Remove unwanted startup programs",
            "Edit your System Variables paths",
            "Disable unnecessary Windows services",
            "Optimize graphics driver settings",
            "Clean up background processes",
            "Adjust Windows for best performance",
            "Update DirectX and GPU drivers",
            "Ultimate FPS Boost (Remove Bloatware, Optimize Services, Clean System)",
            "Extreme Gaming Mode (Maximize FPS, Remove Deep Bloatware, Hardcore Optimization)",
            "Show changelog"
        };

        for (int i = 0; i < options.Length; i++)
        {
            System.Console.Write($"{i + 1}. ");
            PrintRainbow(options[i], rainbow);
            System.Console.WriteLine();
        }

        System.Console.Write("> ");
        string? input = System.Console.ReadLine();

        System.Console.WriteLine();
        int selected = 0;
        if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out int parsed) && parsed >= 1 && parsed <= options.Length)
        {
            selected = parsed;
        }
        else
        {
            System.Console.WriteLine("Invalid selection. Exiting program.");
            System.Console.ResetColor();
            return;
        }

        System.Console.Write("Selected: ");
        PrintRainbow(options[selected - 1], rainbow);
        System.Console.WriteLine();
        System.Console.ResetColor();

        switch (selected)
        {
            case 1:
                DisableAllTelemetry();
                break;
            case 2:
                FlushDnsCache();
                break;
            case 3:
                DisableCoPilotAI();
                break;
            case 4:
                ClearTemporaryFiles();
                break;
            case 5:
                OptimizeSystemMemory();
                break;
            case 6:
                DefragmentSystemDrive();
                break;
            case 7:
                StrikeBoostFPS();
                break;
            case 8:
                RemoveUnwantedStartupPrograms();
                break;
            case 9:
                EditSystemVariablesPaths();
                break;
            case 10:
                DisableUnnecessaryWindowsServices();
                break;
            case 11:
                OptimizeGraphicsDriverSettings();
                break;
            case 12:
                CleanUpBackgroundProcesses();
                break;
            case 13:
                AdjustWindowsForBestPerformance();
                break;
            case 14:
                UpdateDirectXAndGpuDrivers();
                break;
            case 15:
                UltimateFpsBoost();
                break;
            case 16:
                ExtremeGamingMode();
                break;
            case 17:
                ShowChangelog();
                break;
        }

        System.Console.ResetColor();
    }

    private static void PrintRainbow(string text, System.ConsoleColor[] rainbow)
    {
        var previous = System.Console.ForegroundColor;
        for (int i = 0; i < text.Length; i++)
        {
            System.Console.ForegroundColor = rainbow[i % rainbow.Length];
            System.Console.Write(text[i]);
        }
        System.Console.ForegroundColor = previous;
    }

    private static void ShowChangelog()
    {
        System.Console.WriteLine();
        PrintRainbow("=== Changelog v1.0 Release ===", rainbow);
        System.Console.WriteLine();
        System.Console.WriteLine("This is the initial release (v1.0) of Aqua Optimizer.");
        System.Console.WriteLine("No changes or updates have been made yet.");
        System.Console.WriteLine();
    }

    private static void DisableAllTelemetry()
    {
        DisableWindowsTelemetry();
        DisableOfficeTelemetry();
        DisableEdgeTelemetry();
    }

    private static void DisableWindowsTelemetry()
    {
        try
        {
            var regPaths = new[]
            {
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\DataCollection",
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\DataCollection"
            };

            foreach (var path in regPaths)
            {
                Registry.SetValue(path, "AllowTelemetry", 0, RegistryValueKind.DWord);
            }

            var psi = new ProcessStartInfo
            {
                FileName = "sc",
                Arguments = "config DiagTrack start= disabled",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi)?.WaitForExit();
            psi.Arguments = "stop DiagTrack";
            Process.Start(psi)?.WaitForExit();

            System.Console.WriteLine("Windows telemetry disabled.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error disabling Windows telemetry: {ex.Message}");
        }
    }

    private static void DisableOfficeTelemetry()
    {
        try
        {
            var officeVersions = new[] { "16.0", "15.0" };
            foreach (var version in officeVersions)
            {
                string path = $@"HKEY_CURRENT_USER\Software\Policies\Microsoft\Office\{version}\Common";
                Registry.SetValue(path, "TelemetryEnabled", 0, RegistryValueKind.DWord);
            }
            System.Console.WriteLine("Office telemetry disabled.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error disabling Office telemetry: {ex.Message}");
        }
    }

    private static void DisableEdgeTelemetry()
    {
        try
        {
            string path = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge";
            Registry.SetValue(path, "MetricsReportingEnabled", 0, RegistryValueKind.DWord);
            System.Console.WriteLine("Edge telemetry disabled.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error disabling Edge telemetry: {ex.Message}");
        }
    }

    private static void FlushDnsCache()
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = "ipconfig",
                Arguments = "/flushdns",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi)?.WaitForExit();
            System.Console.WriteLine("DNS cache flushed.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error flushing DNS cache: {ex.Message}");
        }
    }

    private static void DisableCoPilotAI()
    {
        try
        {
            string winCopilotPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsCopilot";
            Registry.SetValue(winCopilotPath, "TurnOffWindowsCopilot", 1, RegistryValueKind.DWord);

            string edgeCopilotPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Edge";
            Registry.SetValue(edgeCopilotPath, "CopilotEnabled", 0, RegistryValueKind.DWord);

            System.Console.WriteLine("CoPilot AI disabled in Windows 11 & Edge.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error disabling CoPilot AI: {ex.Message}");
        }
    }

    private static void ClearTemporaryFiles()
    {
        try
        {
            string tempPath = Path.GetTempPath();
            int deleted = 0;
            foreach (var file in Directory.EnumerateFiles(tempPath, "*", SearchOption.AllDirectories))
            {
                try
                {
                    File.Delete(file);
                    deleted++;
                }
                catch { }
            }
            foreach (var dir in Directory.EnumerateDirectories(tempPath, "*", SearchOption.AllDirectories))
            {
                try
                {
                    Directory.Delete(dir, true);
                }
                catch { }
            }
            System.Console.WriteLine($"Temporary files cleared. Files deleted: {deleted}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error clearing temporary files: {ex.Message}");
        }
    }

    private static void OptimizeSystemMemory()
    {
        try
        {
            int optimized = 0;
            foreach (var proc in Process.GetProcesses())
            {
                try
                {
                    if (!proc.HasExited && proc.ProcessName != "System")
                    {
                        EmptyWorkingSet(proc.Handle);
                        optimized++;
                    }
                }
                catch { }
            }
            System.Console.WriteLine($"System memory optimized. Processes affected: {optimized}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error optimizing system memory: {ex.Message}");
        }
    }

    [DllImport("psapi.dll")]
    private static extern bool EmptyWorkingSet(IntPtr hProcess);

    private static void DefragmentSystemDrive()
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = "defrag",
                Arguments = "C: /O",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi)?.WaitForExit();
            System.Console.WriteLine("System drive defragmented.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error defragmenting system drive: {ex.Message}");
        }
    }

    private static void StrikeBoostFPS()
    {
        try
        {
            var psiPower = new ProcessStartInfo
            {
                FileName = "powercfg",
                Arguments = "/S SCHEME_MIN",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psiPower)?.WaitForExit();

            var psiSysMain = new ProcessStartInfo
            {
                FileName = "sc",
                Arguments = "stop SysMain",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psiSysMain)?.WaitForExit();

            var psiSearch = new ProcessStartInfo
            {
                FileName = "sc",
                Arguments = "stop WSearch",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psiSearch)?.WaitForExit();

            string regPath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects";
            Registry.SetValue(regPath, "VisualFXSetting", 2, RegistryValueKind.DWord);

            System.Console.WriteLine("Strike: FPS boost applied. Power plan set to High Performance, unnecessary services stopped, visual effects optimized.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error applying Strike FPS boost: {ex.Message}");
        }
    }

    private static void RemoveUnwantedStartupPrograms()
    {
        try
        {
            string subKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
            string[] allowed = { "Windows Security", "OneDrive" };

            foreach (var hive in new[] { RegistryHive.CurrentUser, RegistryHive.LocalMachine })
            {
                try
                {
                    using var baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Default);
                    using var runKey = baseKey.OpenSubKey(subKeyPath, writable: true);
                    if (runKey == null) continue;

                    foreach (var name in runKey.GetValueNames())
                    {
                        if (Array.IndexOf(allowed, name) < 0)
                        {
                            try
                            {
                                runKey.DeleteValue(name, throwOnMissingValue: false);
                                System.Console.WriteLine($"Removed startup entry: {name} from {hive}");
                            }
                            catch { }
                        }
                    }
                }
                catch { }
            }

            System.Console.WriteLine("Unwanted startup programs removed from registry.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error removing startup programs: {ex.Message}");
        }
    }

    private static void EditSystemVariablesPaths()
    {
        try
        {
            string pathVar = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine) ?? "";
            if (!pathVar.Contains(@"C:\Tools", StringComparison.OrdinalIgnoreCase))
            {
                string newPath = pathVar + @";C:\Tools";
                Environment.SetEnvironmentVariable("Path", newPath, EnvironmentVariableTarget.Machine);
                System.Console.WriteLine(@"C:\Tools added to system Path variable.");
            }
            else
            {
                System.Console.WriteLine(@"C:\Tools already present in system Path variable.");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error editing system Path variable: {ex.Message}");
        }
    }

    private static void DisableUnnecessaryWindowsServices()
    {
        try
        {
            string[] services = new[] { "Fax", "XblGameSave", "MapsBroker" };
            foreach (var service in services)
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "sc",
                    Arguments = $"config {service} start= disabled",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi)?.WaitForExit();

                psi.Arguments = $"stop {service}";
                Process.Start(psi)?.WaitForExit();
            }
            System.Console.WriteLine("Unnecessary Windows services disabled.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error disabling Windows services: {ex.Message}");
        }
    }

    private static void OptimizeGraphicsDriverSettings()
    {
        try
        {
            string nvidiaPath = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\nvlddmkm\Device0";
            Registry.SetValue(nvidiaPath, "PerfLevelSrc", 1, RegistryValueKind.DWord);

            string amdPath = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\amdkmdag";
            Registry.SetValue(amdPath, "EnableUlps", 0, RegistryValueKind.DWord);

            string intelPath = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\igfx";
            Registry.SetValue(intelPath, "PowerSaving", 0, RegistryValueKind.DWord);

            System.Console.WriteLine("Graphics driver registry settings optimized.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error optimizing graphics driver settings: {ex.Message}");
        }
    }

    private static void CleanUpBackgroundProcesses()
    {
        try
        {
            int closed = 0;
            foreach (var proc in Process.GetProcesses())
            {
                try
                {
                    if (!proc.HasExited && (
                        proc.ProcessName.Contains("OneDrive", StringComparison.OrdinalIgnoreCase) ||
                        proc.ProcessName.Contains("Teams", StringComparison.OrdinalIgnoreCase) ||
                        proc.ProcessName.Contains("Skype", StringComparison.OrdinalIgnoreCase) ||
                        proc.ProcessName.Contains("Updater", StringComparison.OrdinalIgnoreCase) ||
                        proc.ProcessName.Contains("Adobe", StringComparison.OrdinalIgnoreCase) ||
                        proc.ProcessName.Contains("Dropbox", StringComparison.OrdinalIgnoreCase)
                        ))
                    {
                        proc.Kill();
                        closed++;
                    }
                }
                catch { }
            }
            System.Console.WriteLine($"Background processes cleaned up. Processes closed: {closed}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error cleaning up background processes: {ex.Message}");
        }
    }

    private static void AdjustWindowsForBestPerformance()
    {
        try
        {
            string regPath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects";
            Registry.SetValue(regPath, "VisualFXSetting", 2, RegistryValueKind.DWord);

            var psiPower = new ProcessStartInfo
            {
                FileName = "powercfg",
                Arguments = "/S SCHEME_MIN",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psiPower)?.WaitForExit();

            System.Console.WriteLine("Windows adjusted for best performance.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error adjusting Windows for best performance: {ex.Message}");
        }
    }

    private static void UpdateDirectXAndGpuDrivers()
    {
        try
        {
            var psiUpdate = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = "Start-Process -Verb runAs powershell -ArgumentList 'Install-WindowsUpdate -MicrosoftUpdate -AcceptAll -AutoReboot'",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psiUpdate)?.WaitForExit();

            System.Console.WriteLine("DirectX and GPU drivers update initiated.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error updating DirectX and GPU drivers: {ex.Message}");
        }
    }

    private static void UltimateFpsBoost()
    {
        System.Console.WriteLine("Starting Ultimate FPS Boost...");

        string[] bloatwareApps = new[]
        {
            "Candy Crush", "Xbox", "Skype", "OneNote", "YourPhone", "GetHelp", "MixedReality", "ZuneMusic", "ZuneVideo", "People", "Solitaire", "Weather", "Maps", "News", "FeedbackHub"
        };

        foreach (var app in bloatwareApps)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = $"-Command \"Get-AppxPackage *{app}* | Remove-AppxPackage\"",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi)?.WaitForExit();
                System.Console.WriteLine($"Removed bloatware: {app}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error removing {app}: {ex.Message}");
            }
        }

        string[] services = new[] { "SysMain", "WSearch", "Fax", "XblGameSave", "MapsBroker", "DiagTrack" };
        foreach (var service in services)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "sc",
                    Arguments = $"config {service} start= disabled",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi)?.WaitForExit();

                psi.Arguments = $"stop {service}";
                Process.Start(psi)?.WaitForExit();

                System.Console.WriteLine($"Service {service} disabled and stopped.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error disabling service {service}: {ex.Message}");
            }
        }

        ClearTemporaryFiles();
        CleanUpBackgroundProcesses();

        try
        {
            var psiPower = new ProcessStartInfo
            {
                FileName = "powercfg",
                Arguments = "/S SCHEME_MIN",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psiPower)?.WaitForExit();
            System.Console.WriteLine("Power plan set to High Performance.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error setting power plan: {ex.Message}");
        }

        OptimizeGraphicsDriverSettings();
        OptimizeSystemMemory();
        DefragmentSystemDrive();

        System.Console.WriteLine("Ultimate FPS Boost completed! Your system is now optimized for gaming.");
    }

    private static void ExtremeGamingMode()
    {
        System.Console.WriteLine();
        PrintRainbow("Activating Extreme Gaming Mode...", rainbow);
        System.Console.WriteLine();

        string[] deepBloatware = new[]
        {
            "Candy Crush", "Xbox", "Skype", "OneNote", "YourPhone", "GetHelp", "MixedReality", "ZuneMusic", "ZuneVideo",
            "People", "Solitaire", "Weather", "Maps", "News", "FeedbackHub", "OfficeHub", "3DBuilder", "Messaging",
            "Sway", "Wallet", "Print3D", "WindowsAlarms", "WindowsCamera", "WindowsSoundRecorder", "WindowsStore", "WindowsPhotos"
        };
        foreach (var app in deepBloatware)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = $"-Command \"Get-AppxPackage *{app}* | Remove-AppxPackage\"",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi)?.WaitForExit();
                System.Console.WriteLine($"Removed deep bloatware: {app}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error removing {app}: {ex.Message}");
            }
        }

        string[] hardcoreServices = new[]
        {
            "SysMain", "WSearch", "Fax", "XblGameSave", "MapsBroker", "DiagTrack", "RetailDemo", "dmwappushservice", "WMPNetworkSvc", "Spooler"
        };
        foreach (var service in hardcoreServices)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "sc",
                    Arguments = $"config {service} start= disabled",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi)?.WaitForExit();

                psi.Arguments = $"stop {service}";
                Process.Start(psi)?.WaitForExit();

                System.Console.WriteLine($"Service {service} disabled and stopped.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error disabling service {service}: {ex.Message}");
            }
        }

        ClearTemporaryFiles();
        CleanUpBackgroundProcesses();
        OptimizeSystemMemory();
        OptimizeGraphicsDriverSettings();
        DefragmentSystemDrive();

        try
        {
            var psiPower = new ProcessStartInfo
            {
                FileName = "powercfg",
                Arguments = "/S SCHEME_MAX",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psiPower)?.WaitForExit();
            System.Console.WriteLine("Power plan set to Ultimate Performance.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error setting power plan: {ex.Message}");
        }

        DisableAllTelemetry();
        DisableUnnecessaryWindowsServices();

        PrintRainbow("Extreme Gaming Mode completed! Maximum FPS and system performance achieved.", rainbow);
        System.Console.WriteLine();
    }
}
