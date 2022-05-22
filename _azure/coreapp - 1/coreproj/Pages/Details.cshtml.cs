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
    public class DetailsModel : PageModel
    {
        public Course obj;
        private IMemoryCache cache;
        public CourseActions action;
        public DetailsModel(IMemoryCache cache)
        {
            this.cache = cache;
            action = new CourseActions((List<Course>)cache.Get("dtset"));
        }
        
        public IActionResult OnGet(int Id)
        {
            obj = action.GetCourse(Id);
            if (obj == null)
            {
                return RedirectToPage("./DetailsError");
            }
            return Page();
        }
    }
}