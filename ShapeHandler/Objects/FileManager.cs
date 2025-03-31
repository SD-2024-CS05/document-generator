using System;
using System.IO;

namespace ShapeHandler.Objects
{
    public static class FileManager
    {
        public static string GetFilePath(string fileName, string holdingDir = "")
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(baseDir, fileName);

                if (!File.Exists(filePath) && !string.IsNullOrEmpty(holdingDir))
                {
                    filePath = Path.Combine(baseDir, holdingDir, fileName);
                }

                if (!File.Exists(filePath))
                {
                    filePath = Path.Combine(baseDir, "bin", fileName);
                }

                return filePath;
            }
            catch (Exception e)
            {
                throw new Exception("Could not find the file: " + fileName, e);
            }
        }
    }
}
