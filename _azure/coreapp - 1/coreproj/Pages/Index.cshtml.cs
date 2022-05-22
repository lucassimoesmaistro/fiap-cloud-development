using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using coreproj.Models;
using Microsoft.Extensions.Caching.Memory;

namespace coreproj.Pages
{
    public class IndexModel : PageModel
    {
        private IMemoryCache cache;
        private readonly ILogger<IndexModel> _logger;
        CourseActions action;

        public IEnumerable<Course> courseobj;
        public IndexModel(ILogger<IndexModel> logger,IMemoryCache cache)
        {
            this.cache = cache;
            _logger = logger;
            action = new CourseActions((List<Course>)cache.Get("dtset"));
        }

        public void OnGet()
        {
            courseobj = action.GetAllCourses();
        }
    }
}
