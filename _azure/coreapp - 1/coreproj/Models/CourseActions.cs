using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreproj.Models
{
    
    public class CourseActions
    {
        
        List<Course> courseobj;

        public CourseActions(List<Course> p_courseobj)
        {            
            courseobj= p_courseobj;
        }

        public List<Course> GetAllCourses()
        {
            return courseobj;
        }

        public Course GetCourse(int id)
        {
            return courseobj.FirstOrDefault(c => c.Id == id);
        }

        public Course UpdateCourse(Course newobj)
        {
            Course obj;
            obj = GetCourse(newobj.Id);
            if (obj != null)
            {
                obj.Name = newobj.Name;
                obj.rating = newobj.rating;                
            }
            return obj;
           }

        public void AddCourse(Course p_obj)
        {
            List<Course> l_obj = GetAllCourses();

            l_obj.Add(p_obj);
        }
    }
}
