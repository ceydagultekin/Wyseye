using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WyseyeCase.Interface;
using WyseyeCase.Models;
using WyseyeCase.Models.Model;

namespace WyseyeCase.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICar carRepository;

		public HomeController(ILogger<HomeController> logger,ICar carRepository)
		{
			_logger = logger;
			this.carRepository= carRepository;
		}

		public async Task<IActionResult> Index()
		{
			var cars = await carRepository.GetCarsAsync();
			return View(cars);
		}

		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult AddCar()
		{
			return View("AddCar");
		}

		[HttpPost]
		public async Task<IActionResult> AddCar(Car car)
		{
			if(ModelState.IsValid)
			{
				await carRepository.AddCar(car);
				return RedirectToAction("Index");
			}
			return View(car);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
