using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		public IActionResult Create()
		{
			var mnList = (from m in _context.Menus
						  select new SelectListItem()
						  {
							  Text = m.MenuName,
							  Value = m.MenuId.ToString(),
						  }).ToList();
			mnList.Insert(0, new SelectListItem()
			{
				Text = "----Select----",
				Value = "0"
			});
			ViewBag.mnList = mnList;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Menu mn)
		{
			if (ModelState.IsValid)
			{
				_context.Menus.Add(mn);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(mn);
		}
        public IActionResult Edit(int? id)
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

            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuId.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = String.Empty
            });
            ViewBag.mnList = mnList;

            return View(mn);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}
