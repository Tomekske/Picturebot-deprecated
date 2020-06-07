using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ElectronNET.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PicturebotElectron.Models;

namespace PicturebotElectron.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Electron.IpcMain.On("getData", (args) =>
            {
                var mainWindow = Electron.WindowManager.BrowserWindows.First();
                Console.WriteLine("sendDataaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                Electron.IpcMain.Send(mainWindow, "sendData", "Hello IPC World!");
            });

            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
