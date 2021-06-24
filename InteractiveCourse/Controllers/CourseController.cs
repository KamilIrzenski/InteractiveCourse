using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InteractiveCourse.Entities;
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
        public  ActionResult Php(int coursesId, int ? page)
        {
            var phpCourse = _dbContext.Slides.Where(x => x.CourseId == coursesId).ToList();
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
            var dataContent = phpViewModel.OrderBy(s => s.Nr).Skip(start).Take(limit);


            return View(dataContent);
        }
        public async Task<ViewResult> MySql()
        {
            var mySqlCourse = _dbContext.Slides.Where(x => x.CourseId == 1).ToListAsync();
            return View(await mySqlCourse);
        }
        public async Task<ViewResult> Project()
        {
            var projectCourse = _dbContext.Slides.Where(x => x.CourseId == 4).ToListAsync();
            return View(await projectCourse);
        }
        public async Task<ViewResult> Html()
        {
            var htmlCourse = _dbContext.Slides.Where(x => x.CourseId == 3).ToListAsync();
            return View(await htmlCourse);
        }

        //[HttpGet("{nr}")]
        //public ActionResult<SlideViewModel> GetSlide([FromRoute] int nr)
        //{
        //    var slide = _dbContext.Slides.FirstOrDefault(x => x.Nr == nr);

        //    if (slide is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(slide);
        //}

       

    }
}
