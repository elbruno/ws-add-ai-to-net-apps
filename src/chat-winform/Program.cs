using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
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
            builder.AddAppDefaults();

            var app = builder.Build();
            Services = app.Services;
            app.Start();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmChat());
		}

        public static IServiceProvider Services { get; private set; } = default!;
    }
}
