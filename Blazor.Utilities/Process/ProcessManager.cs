﻿using System;

namespace Blazor.Utilities.Process
{
    public static class ProcessManager
    {
        /// <summary>Closes the process.</summary>
        /// <param name="processName">Name of the process.</param>
        public static void KillProcess(string processName)
        {
            try
            {
                foreach (var process in System.Diagnostics.Process.GetProcessesByName(processName))
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
