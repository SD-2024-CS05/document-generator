using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeHandler
{
    public class HTMLGraph
    {
        private List<string> nodes;

        public HTMLGraph()
        {
            nodes = new List<string>();
            LoadNodesFromJsonFiles();
        }

        private void LoadNodesFromJsonFiles()
        {
            string folderPath = Path.GetDirectoryName(typeof(HTMLGraph).Assembly.Location);
            string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

            foreach (string jsonFile in jsonFiles)
            {
                string nodeName = Path.GetFileNameWithoutExtension(jsonFile);

            }
        }
    }
}
