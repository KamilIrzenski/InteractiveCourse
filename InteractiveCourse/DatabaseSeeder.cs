using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractiveCourse.Entities;

namespace InteractiveCourse
{
    public class DatabaseSeeder
    {
        private readonly InteractiveCourseDbContext _dbContext;

        public DatabaseSeeder(InteractiveCourseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Courses.Any())
                {
                    var courses = GetCourses();
                    _dbContext.Courses.AddRange(courses);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Slides.Any())
                {
                    var slides = GetSlides();
                    _dbContext.Slides.AddRange(slides);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Course> GetCourses()
        {
            var courses = new List<Course>()
            {
                new Course()
                {
                    Name = "MySQL",
                    PictureName = "featured4"
                },
                new Course()
                {
                    Name = "PHP",
                    PictureName = "featured3"
                },
                new Course()
                {
                    Name = "HTML",
                    PictureName = "featured5"
                },
                new Course()
                {
                    Name = "PROJECT",
                    PictureName = "featured6"
                },
            };
            return courses;
        }

        private IEnumerable<Slide> GetSlides()
        {
            var slides = new List<Slide>()
            {
                new Slide()
                {
                    CourseId = 1,
                    Nr = 1,
                    CourseContent =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Facilisis magna etiam tempor orci eu. Natoque penatibus et magnis dis. Tempor orci dapibus ultrices in iaculis. Tristique senectus et netus et. Orci a scelerisque purus semper eget duis at. Eleifend donec pretium vulputate sapien nec sagittis aliquam. Feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper. Enim praesent elementum facilisis leo vel. Feugiat nisl pretium fusce id velit ut tortor. Fermentum posuere urna nec tincidunt praesent. Cursus in hac habitasse platea dictumst. Neque convallis a cras semper auctor neque vitae tempus quam. Potenti nullam ac tortor vitae purus faucibus ornare. Montes nascetur ridiculus mus mauris vitae ultricies leo. Vulputate ut pharetra sit amet aliquam id. "

                },
                new Slide()
                {
                    CourseId = 2,
                    Nr = 1,
                    CourseContent =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Facilisis magna etiam tempor orci eu. Natoque penatibus et magnis dis. Tempor orci dapibus ultrices in iaculis. Tristique senectus et netus et. Orci a scelerisque purus semper eget duis at. Eleifend donec pretium vulputate sapien nec sagittis aliquam. Feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper. Enim praesent elementum facilisis leo vel. Feugiat nisl pretium fusce id velit ut tortor. Fermentum posuere urna nec tincidunt praesent. Cursus in hac habitasse platea dictumst. Neque convallis a cras semper auctor neque vitae tempus quam. Potenti nullam ac tortor vitae purus faucibus ornare. Montes nascetur ridiculus mus mauris vitae ultricies leo. Vulputate ut pharetra sit amet aliquam id."
                },
                new Slide()
                {
                    CourseId = 3,
                    Nr = 1,
                    CourseContent =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Facilisis magna etiam tempor orci eu. Natoque penatibus et magnis dis. Tempor orci dapibus ultrices in iaculis. Tristique senectus et netus et. Orci a scelerisque purus semper eget duis at. Eleifend donec pretium vulputate sapien nec sagittis aliquam. Feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper. Enim praesent elementum facilisis leo vel. Feugiat nisl pretium fusce id velit ut tortor. Fermentum posuere urna nec tincidunt praesent. Cursus in hac habitasse platea dictumst. Neque convallis a cras semper auctor neque vitae tempus quam. Potenti nullam ac tortor vitae purus faucibus ornare. Montes nascetur ridiculus mus mauris vitae ultricies leo. Vulputate ut pharetra sit amet aliquam id."
                },
                new Slide()
                {
                    CourseId = 4,
                    Nr = 1,
                    CourseContent =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Facilisis magna etiam tempor orci eu. Natoque penatibus et magnis dis. Tempor orci dapibus ultrices in iaculis. Tristique senectus et netus et. Orci a scelerisque purus semper eget duis at. Eleifend donec pretium vulputate sapien nec sagittis aliquam. Feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper. Enim praesent elementum facilisis leo vel. Feugiat nisl pretium fusce id velit ut tortor. Fermentum posuere urna nec tincidunt praesent. Cursus in hac habitasse platea dictumst. Neque convallis a cras semper auctor neque vitae tempus quam. Potenti nullam ac tortor vitae purus faucibus ornare. Montes nascetur ridiculus mus mauris vitae ultricies leo. Vulputate ut pharetra sit amet aliquam id."
                },
            };
            return slides;
        }
    }
}

