using Blazor.Core.Controls;
using Blazor.LoggerManager.LoggerUtilities;
using System;
using System.Globalization;
using System.IO;

namespace Blazor.SpecflowTest.Tools
{
    public static class ScreenCapture
    {
        /// <summary>
        /// The method helps to take an screen shot when a step in the test cases failed
        /// </summary>
        public static void TakeScreenshot()
        {
            //Path to save the image
            var imagePath = Path.Combine(ConfigurationVariable.TestCaseResultsImageVideoPath, Util.GetCurrectTc());
            var fullImagePath = Path.Combine(imagePath,
                Util.GetCurrectTc() +
                DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture) + ".png");

            ConfigurationVariable.ScreenPath = fullImagePath;
            //Capture Desktop Image
            SeleniumActions.TakeScreenshotAllScreen(fullImagePath);
        }
    }
}
