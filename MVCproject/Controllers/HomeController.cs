using Microsoft.AspNetCore.Mvc;
using MVCproject.Helpers;
using MVCproject.Interfaces;
using MVCproject.Models;
using MVCproject.ViewModels;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace MVCproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClubRepository _clubRepository;

        public HomeController(ILogger<HomeController> logger, IClubRepository clubRepository)
        {
            _logger = logger;
            _clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ipInfo = new IPInfo();
            var homeVM = new HomeViewModel();
            try
            {
                string url = "https://ipinfo.io/95.134.36.105?token=a4d7cb2e6026a8";
                var info = new WebClient().DownloadString(url);
                ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
                homeVM.City = ipInfo.City;
                homeVM.State = ipInfo.Region;
                if (homeVM.City != null)
                {
                    homeVM.Clubs = await _clubRepository.GetClubByCity(homeVM.City);
                }
                else
                {
                    homeVM.Clubs = null;
                }
                return View(homeVM);
            }
            catch(Exception ex)
            {
                homeVM.Clubs = null;
            }
            return View(homeVM);
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
