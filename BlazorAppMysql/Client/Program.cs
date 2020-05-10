using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;

namespace BlazorAppMysql.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // 
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSyncfusionBlazor();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU0NTI4QDMxMzgyZTMxMmUzMGkzZmxGN2hDS1hhdjV6NmdDSnpMRzRqbEhrdGw1OHY0U2dIbG5iaWVmY289");
            await builder.Build().RunAsync();
        }
    }
}
