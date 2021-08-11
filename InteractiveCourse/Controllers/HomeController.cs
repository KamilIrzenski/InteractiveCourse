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
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Net.Smtp;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(string name, string subject, string email, string message)
        {
            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("kamildevkontakt@gmail.com"));
            msg.To.Add(new MailboxAddress("kirzenski@gmail.com"));
            msg.Subject = subject;
            msg.Body = new TextPart("html")
            {
                Text = "From: " + name + "<br>" +
                       "Contact Information: " + email + "<br>" +
                       "Message: " + message
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                client.Authenticate("kamildevkontakt@gmail.com", "poczta@Haslo1");
                client.Send(msg);
                client.Disconnect(false);

            }

            return View("Contact");

        }

    }
}
