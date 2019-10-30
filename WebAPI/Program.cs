/*
 * Copyright (c) 2019, TopCoder, Inc. All rights reserved.
 */
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI
{
    /// <summary>
    /// Entry class of the app.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method of the app.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the web host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>The web host builder.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
