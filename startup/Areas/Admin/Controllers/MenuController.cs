using Microsoft.AspNetCore.Mvc;
using startup.Models;

namespace startup.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class MenuController : Controller
	{
		private readonly DataContext _context;
		public MenuController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var mnList = _context.Menus.OrderBy(m => m.MenuId).ToList();
			return View(mnList);
		}

		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0) 
			{
				return NotFound();
			}
			var mn = _context.Menus.Find(id);
			if (mn == null) 
			{
				return NotFound();
			}
			return View(mn);
		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var deleMenu = _context.Menus.Find(id); if (deleMenu == null)
			{
				return NotFound();
			}
			_context.Menus.Remove(deleMenu);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
