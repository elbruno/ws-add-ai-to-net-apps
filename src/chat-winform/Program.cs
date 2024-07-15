using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_winform
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = Host.CreateApplicationBuilder();
            //builder.AddAppDefaults();
            builder.AddServiceDefaults();

            builder.Services.AddHttpClient<ChatApiClient>(
                client => client.BaseAddress = new($"{builder.Configuration["CHAT_SERVER"]}"));
            var app = builder.Build();

            Services = app.Services;
            app.Start();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.Run(ActivatorUtilities.CreateInstance<frmChat>(app.Services));
            //Application.Run(new frmChat());
        }

        public static IServiceProvider Services { get; private set; } = default!;
    }
}
