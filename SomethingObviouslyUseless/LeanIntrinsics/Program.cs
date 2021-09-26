using System.Diagnostics;

var startInfo = new ProcessStartInfo("ipconfig", "/all");
using var process = Process.Start(startInfo)!;
await process.WaitForExitAsync();