using Microsoft.AspNetCore.Mvc;
using startup.Models;

namespace startup.Components
{
    [ViewComponent(Name ="Post")]
    public class PostComponent : ViewComponent
    {
        private readonly DataContext _Context;
        public PostComponent(DataContext context)
        {
            _Context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _Context.Posts
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.PostID descending
                              select p).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}