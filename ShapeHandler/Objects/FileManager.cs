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
            var dir = AppDomain.CurrentDomain.BaseDirectory;

            if (!File.Exists(Path.Combine(dir, fileName)))
            {
                dir = Path.Combine(dir, "bin");
            }

            return dir;
        }
    }
}
