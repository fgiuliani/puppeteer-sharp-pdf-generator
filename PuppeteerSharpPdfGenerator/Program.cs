using System;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace PuppeteerSharpPdfGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter URL to generate PDF file:");

            string url = Console.ReadLine();

            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });

            await using var page = await browser.NewPageAsync();
            await page.GoToAsync(url);
            await page.PdfAsync($"{DateTime.Today.ToShortDateString().Replace("/", "-")}.pdf");

            Console.WriteLine("PDF File generated successfully.");
            Console.ReadLine();
        }
    }
}
