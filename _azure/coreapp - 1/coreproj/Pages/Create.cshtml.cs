using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using coreproj.Models;
using Microsoft.Extensions.Caching.Memory;

namespace coreproj.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Course obj { get; set; }
        CourseActions action;
        int count;
        private IMemoryCache cache;

        public CreateModel(IMemoryCache cache)
        {
            this.cache = cache;
            action = new CourseActions((List<Course>)cache.Get("dtset"));
            count = (int)cache.Get("count");
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            count++;
            cache.Set("count", count);
            obj.Id = count;
            action.AddCourse(obj);
            return RedirectToPage("./Details", new { Id = obj.Id });
        }
    }
}