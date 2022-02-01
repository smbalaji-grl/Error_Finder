namespace Finder.Ccode
{
    public class ReportTestRunInfo
    {
        private string folderPath;
        private string key;
        private bool Found = false;
        private List<int> searchFoundLines;
        public ReportTestRunInfo(string s1, string s2)
        {
            this.folderPath = s1;
            this.key = s2;
          
        }
        override
        public string ToString()
        {
            return Path.GetFileName(folderPath);
        }
        public List<int> searchKeyWord()
        {
            string[] allFiles = Directory.GetFiles(folderPath, "*.log");
            searchFoundLines= new List<int>();
            if (allFiles.Length != 0)
            {
                foreach (string file in allFiles)
                {
                    int lineNumber = 0;
                    foreach (string line in System.IO.File.ReadLines(file))
                    {
                        lineNumber++;
                        if (line.Contains(this.key))
                        {
                            searchFoundLines.Add(lineNumber);
                        }
                    }
                }
                if (searchFoundLines != null)
                {
                    Found = true;
                }
            }
            return searchFoundLines;

        }
        public List<int> sendLines()
        {
           
            return searchFoundLines;
        }



        public bool isFound()
        {
            return Found;
        }

    }
}
