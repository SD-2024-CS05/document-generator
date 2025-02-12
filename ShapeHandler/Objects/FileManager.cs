using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler.Objects
{
    public static class FileManager
    {
        public static string GetFilePath(string fileName)
        {
            try
            {
                var dir = AppDomain.CurrentDomain.BaseDirectory;

                if (!File.Exists(Path.Combine(dir, fileName)))
                {
                    dir = Path.Combine(dir, "bin", fileName);
                } else
                {
                    dir = Path.Combine(dir, fileName);
                }

                return dir;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
