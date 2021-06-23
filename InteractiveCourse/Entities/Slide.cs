using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveCourse.Entities
{
    public class Slide
    {
        public int Nr { get; set; }
        public string CourseContent { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course{ get; set; }  
    }
}
