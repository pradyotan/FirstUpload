using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Uno.Helpers
{
    public class FileHelper
    {
        public static string CreateFilePath(string uploader)
        {
            try
            {
                // Temporary file name.
                var fileName = string.Format("{0}.jpg", Guid.NewGuid().ToString("N"));

                // Temporary file path.
                var tmpFilePath = HostingEnvironment.MapPath(string.Format("~/Images/{0}/{1}", uploader, fileName));

                return tmpFilePath;
            }
            catch (Exception ex)
            {
                return "FAIL";

            }
        }

        public static bool SaveImage(string imageString, string filePath)
        {
            try
            {
                // Save to temporary files folder.
                File.WriteAllBytes(filePath, Convert.FromBase64String(imageString));

                // Was the file actually saved?
                return File.Exists(filePath);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static void DeleteFile(string filePath)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                    File.Delete(filePath);
            }
            catch
            {
                // ToDo: Log it.
            }
        }

    }
}