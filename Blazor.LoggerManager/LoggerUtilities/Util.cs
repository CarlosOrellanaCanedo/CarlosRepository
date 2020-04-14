using System;
using System.IO;
using System.Threading;
using Blazor.LoggerManager.Logger;

namespace Blazor.LoggerManager.LoggerUtilities
{
    public static class Util
    {
        public static string GetImagesAndVideoFullPath()
        {
            try
            {
                var resultsPath = ConfigurationVariable.TestCaseResultsPath;
                var imagesAndVideos = Path.Combine(resultsPath, "ImagesAndVideos.txt");

                using (StreamWriter sw = (File.Exists(imagesAndVideos)) 
                    ? File.AppendText(imagesAndVideos) : File.CreateText(imagesAndVideos))
                
                return resultsPath;
            }
            catch (Exception ex)
            {
                LoggerManagerClass.Instance.Error(ex.Message);
                return string.Empty;
            }
        }

        public static string GetCurrectTc()
        {
            try
            {
                var resultsPath = ConfigurationVariable.TestCaseResultsPath;
                var currentTc = Path.Combine(resultsPath, "CurrentTc.txt");

                using (var sw = new StreamReader(currentTc))
                {
                    return sw.ReadLine();
                }

            }
            catch (Exception ex)
            {
                //Log
                LoggerManagerClass.Instance.Error(ex.Message);

                return string.Empty;
            }
        }

        public static void CreateFolder(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch (Exception ex)
            {
                //Log
                LoggerManagerClass.Instance.Error(ex.Message);
            }
        }

        public static void SaveCurrentTc(string tcName)
        {
            try
            {
                var resultsPath = ConfigurationVariable.TestCaseResultsPath;
                var currentTc = Path.Combine(resultsPath, "CurrentTc.txt");

                using (var sw = new StreamWriter(currentTc, false))
                {
                    sw.WriteLine(tcName);
                }
                Thread.Sleep(500);

                //Log
                LoggerManagerClass.Instance.Information($"Currect test case saved to: {currentTc}");
            }
            catch (Exception ex)
            {
                //Log
                LoggerManagerClass.Instance.Error(ex.Message);
            }
        }
    }
}
