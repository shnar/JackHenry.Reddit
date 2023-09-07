using JackHenry.Reddit.Web.Models;
using JackHenry.Reddit.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JackHenry.Reddit.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();

			model.UserInfos = await ApiService.GetMostUsers();
			model.PostInfos = await ApiService.GetMostPosts();

            return View(model);
        }

		public async Task<IActionResult> MostPosts()
		{
			var model = await ApiService.GetMostPosts();
			return PartialView("_ViewMostPosts", model);
		}

		public async Task<IActionResult> MostUsers()
		{
			var model = await ApiService.GetMostUsers();
			return PartialView("_ViewMostUsers", model);
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