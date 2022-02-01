using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
namespace Finder.Ccode
{
    public class ArrayToList
    {
           // DUT reports
        public static List<ReportDutInfo> strToReportDutInfoInList(string[] uutPath)
        {
            int len = uutPath.Length - 1;
            List<ReportDutInfo> UUTReport = new List<ReportDutInfo>();
            return strToReportDutInfoInList(uutPath, len, UUTReport);
        }
        public static List<ReportDutInfo> strToReportDutInfoInList(string[] uutPath, int len, List<ReportDutInfo> UUTReport)
        {
            if (len == -1)
            {
                return UUTReport;
            }

            strToReportDutInfoInList(uutPath, len - 1, UUTReport);
            ReportDutInfo r1 = new ReportDutInfo(uutPath[len]); 
            UUTReport.Add(r1);
            return UUTReport;
        }

        //  run reports
        public static List<ReportTestRunInfo> strToReportTestRunInfoInList(string[] reportPath, string key)
        {
            int len = reportPath.Length - 1;
            List<ReportTestRunInfo> uutReport = new List<ReportTestRunInfo>();          
            return strToReportTestRunInfoInList(reportPath, len, uutReport, key);
        }
        public static List<ReportTestRunInfo> strToReportTestRunInfoInList(string[] reportPath, int len, List<ReportTestRunInfo> uutReport, string key)
        {
            if (len == -1)
            {
                return uutReport;
            }

            strToReportTestRunInfoInList(reportPath, len - 1, uutReport, key);
            ReportTestRunInfo runReports = new ReportTestRunInfo(reportPath[len], key);
            runReports.searchKeyWord();
            uutReport.Add(runReports);
            return uutReport;
        }



        //public static List<T> toList<T>(T[] sA1)
        //{
        //    int len = sA1.Length - 1;
        //    List<T> UUTReport = new List<T>();
        //    return toList(sA1, len, UUTReport);
        //}
        //public static List<T> toList<T>(T[] sA1, int len, List<T> UUTReport)
        //{
        //    if (len == -1)
        //    {
        //        return UUTReport;
        //    }

        //    toList(sA1, len - 1, UUTReport);
        //    UUTReport.Add(sA1[len]);
        //    return UUTReport;
        //}


        //public static List<T> toList<T>(T[] sA1,object referenceDataType)
        //{
        //    int len = sA1.Length - 1;
        //    List<T> UUTReport = new List<T>();
        //    return toList(sA1, len, UUTReport, referenceDataType);
        //}
        //public static List<T> toList<T>(T[] sA1, int len, List<T> UUTReport, object referenceDataType)
        //{
        //    if (len == -1)
        //    {
        //        return UUTReport;
        //    }

        //    toList(sA1, len - 1, UUTReport, referenceDataType);
        //    referenceDataType = new object(sA1[len]);
        //    UUTReport.Add(sA1[len]);
        //    return UUTReport;
        //}





    }

}
