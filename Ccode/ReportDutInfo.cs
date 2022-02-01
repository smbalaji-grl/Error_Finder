namespace Finder.Ccode
{
    public class ReportDutInfo
    {
        private string folderPath;
        private List<ReportTestRunInfo> Runs ;

        public ReportDutInfo(string s1)
        {
            folderPath = s1;
        }
       
        public string ToString()
        {
            return Path.GetFileName(folderPath);
        }
        public List<ReportTestRunInfo> getRunsAndSettingRunFields(string key)
        {
            string[] runs =  Directory.GetDirectories(this.folderPath);
            this.Runs=  ArrayToList.strToReportTestRunInfoInList(runs, key);
            return this.Runs;         
        }
       
       
    }
}
