// using System.Globalization;
// using App.DAL.EF;
// using App.Domain;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Mvc.Testing;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
//
//
// namespace Tests;
//
// public class WebAppFactory : WebApplicationFactory<Program>
// {
//     public string DefaultUserId { get; set; } = "1";
//
//     protected override void ConfigureWebHost(IWebHostBuilder builder)
//     {
//         builder.ConfigureTestServices(services =>
//         {
//             services.Configure<TestAuthHandlerOptions>(options => options.DefaultUserId = DefaultUserId);
//
//             services.AddAuthentication(TestAuthHandler.AuthenticationScheme)
//                 .AddScheme<TestAuthHandlerOptions, TestAuthHandler>(TestAuthHandler.AuthenticationScheme, options => { });
//         });
//     }
// }