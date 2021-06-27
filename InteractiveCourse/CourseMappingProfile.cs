using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InteractiveCourse.Entities;
using InteractiveCourse.Models;

namespace InteractiveCourse
{
    public class CourseMappingProfile : Profile   
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseViewModel>();
                //.ForMember(m => m.Nr, c => c.MapFrom(s => s.Slide.Nr))
                //.ForMember(m => m.CourseContent, c =>c.MapFrom(s =>s.Slide.CourseContent));

            CreateMap<Slide, SlideViewModel>()
                .ForMember(m =>m.CourseName, c =>c.MapFrom(f =>f.Course.Name));
        }
    }
}
