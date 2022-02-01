using Finder.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NPOI.SS.Formula.Functions;
using Finder.Ccode;

string[] allFiles = Directory.GetDirectories(@"C:\GRL\USBPD-C2-Browser-App\Report\TempReport");// return all UUT report(in string) in array from string input
string key = "FW Write";
List<ReportDutInfo> uutReports = ArrayToList.strToReportDutInfoInList(allFiles);               // convert string to ReportDutInfo,initialize folder path field(in string to iterate) & put in lists.

foreach (ReportDutInfo uutReport in uutReports)
{
    Console.WriteLine(uutReport.ToString());                                                   // print DUT folder path
    List<ReportTestRunInfo> runReports = uutReport.getRunsAndSettingRunFields(key);            // get the ReportTestRunInfo ,set all the fields ,finding error,setting error lines.  
    foreach (ReportTestRunInfo runReport in runReports)
    {
        Console.WriteLine(runReport.ToString());                                              // print Run folder path
        if (runReport.isFound() == true)                                                       // return true if error is found on logger
        {
            List<int> erroLine = runReport.sendLines();                                         // return lines number inwhich line eror found
            //foreach (int line in erroLine)
            //{
            //    Console.WriteLine(line);
            //}
            Console.WriteLine(erroLine.Count());
            Console.WriteLine("-------");
        }
    }
}
Console.WriteLine("-------");

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
