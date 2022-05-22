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
    public class EditModel : PageModel
    {
        [BindProperty]
        public Course obj { get; set; }
        CourseActions action;
        private IMemoryCache cache;

        public EditModel(IMemoryCache cache)
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

        public IActionResult OnPost()
        {
            
            obj = action.UpdateCourse(obj);
            return RedirectToPage("./Details", new { Id = obj.Id });
            
        }

    }
}