using LabsLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mstudz_5.Models;
using System.Diagnostics;

namespace topi_lab5.Controllers
{
	[Authorize]
	public class LabsController : Controller
	{
		private readonly ILogger<LabsController> _logger;

		public LabsController(ILogger<LabsController> logger)
		{
			_logger = logger;
		}

		public IActionResult Lab1()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Lab1(Lab1DataModel model)
		{
			var labRunner = new Lab1(model.FirstLine, model.SecondLine, model.ThirdLine, model.FourthLine, model.FifthLine);

			try
			{
				model.Calculated = labRunner.Run();
			}
			catch (ArgumentException e)
			{
				model.ErrorValue = e.Message;
			}
			catch (Exception e)
			{
				model.ErrorValue = e.Message;
			}

			return View(model);
		}

		public IActionResult Lab2()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Lab2(Lab2DataModel model)
		{
			var labRunner = new Lab2(model.FirstLine, model.SecondLine);

			try
			{
				model.Calculated = labRunner.Run();
			}
			catch (ArgumentException e)
			{
				model.ErrorValue = e.Message;
			}
			catch (Exception e)
			{
				model.ErrorValue = e.Message;
			}

			return View(model);
		}

		public IActionResult Lab3()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Lab3(Lab2DataModel model)
		{
			var labRunner = new Lab2(model.FirstLine, model.SecondLine);

			try
			{
				model.Calculated = labRunner.Run();
			}
			catch (ArgumentException e)
			{
				model.ErrorValue = e.Message;
			}
			catch (Exception e)
			{
				model.ErrorValue = e.Message;
			}

			return View(model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}