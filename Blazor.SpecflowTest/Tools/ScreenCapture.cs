using Blazor.Core.Controls;
using Blazor.Utilities.TestUtilities;
using System;
using System.Globalization;
using System.IO;

namespace Blazor.SpecflowTest.Tools
{
    public static class ScreenCapture
    {
        public static void TakeScreenshot()
        {
            //Path to save the image
            var imagePath = Path.Combine(Util.GetImagesAndVideoFullPath(), Util.GetCurrectTc());
            var fullImagePath = Path.Combine(imagePath,
                Util.GetCurrectTc() +
                DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture) + ".png");

            //Capture Desktop Image
            SeleniumActions.TakeScreenshotAllScreen(fullImagePath);
        }
    }
}
