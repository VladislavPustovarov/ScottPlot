﻿namespace ScottPlotTests.UnitTests;

public class ReportTests
{
    [Test]
    public void Test_HtmlReport_SaveToDisk()
    {
        ScottPlot.Reporting.HtmlReport report = new()
        {
            Title = "Test Report",
            Description = "This report was generated by ScottPlot.UnitTests",
        };

        Plot plot1 = new();
        plot1.Add.Signal(Generate.Sin());
        report.AddPlotPng(plot1, "Sine", "A sine wave starts at zero");

        Plot plot2 = new();
        plot2.Add.Signal(Generate.Cos());
        report.AddPlotPng(plot2, "Cosine", "A cosine wave starts at one");
        report.AddPlotSvg(plot2, "Cosine SVG", "Vector graphics can be scaled infinitely");

        report.AddHeading("Extra Heading");
        report.AddParagraph("Paragraph");
        report.AddHtml("This <code>code</code> is <b>formatted</b>");

        string saveAs = Path.GetFullPath("report.html");
        report.SaveAs(saveAs);
        System.Console.WriteLine(saveAs);
    }
}
