using InteractiveCourse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InteractiveCourse.Entities;

namespace InteractiveCourse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InteractiveCourseDbContext _dbContext;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, InteractiveCourseDbContext dbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var courses = _dbContext.Courses.ToList();
            var courseViewModel = _mapper.Map<List<CourseViewModel>>(courses);
            return View(courseViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
