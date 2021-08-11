using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using InteractiveCourse.Entities;
using InteractiveCourse.Migrations;
using InteractiveCourse.Models;
using Microsoft.EntityFrameworkCore;
using PagedList.Mvc;
using PagedList;

namespace InteractiveCourse.Controllers
{
    public class CourseController : Controller
    {
        private readonly InteractiveCourseDbContext _dbContext;
        private readonly IMapper _mapper;

        public CourseController(InteractiveCourseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ActionResult<IEnumerable<CourseViewModel>> Index()
        {
            var courses = _dbContext.Courses.ToList();
            var courseViewModel = _mapper.Map<List<CourseViewModel>>(courses);
            return View(courseViewModel);
        }

        public IActionResult About()
        {
            return View();
        }
        public  ActionResult Courses(int coursesId, int ? page)
        {
            var phpCourse = _dbContext.Slides.Include(r=>r.Course).Where(x => x.CourseId == coursesId).ToList();
            var phpViewModel = _mapper.Map<List<SlideViewModel>>(phpCourse);
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }

            int limit = 1;

            int start = (int)(page - 1) * limit;

            int totalContent = phpViewModel.Count();
            ViewBag.totalContent = totalContent;
            ViewBag.pageCurrent = page;
            float numberPage = (float)(totalContent / limit);
            ViewBag.numberPage = (int)Math.Ceiling(numberPage);
            ViewBag.courseId = coursesId;
            ViewBag.LessonList = phpCourse.Select(x => x.SlideName).ToList();
            var dataContent = phpViewModel.OrderBy(s => s.Nr).Skip(start).Take(limit);
            var slideNameDb = _dbContext.Slides.Where(x => x.CourseId == coursesId).Select(x => x.SlideName);
            ViewBag.slideName = slideNameDb;



            return View(dataContent);
        }
        
    }
}
