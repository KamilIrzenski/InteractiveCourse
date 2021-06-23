using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveCourse.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Slide> Slides { get; set; }

       // public virtual Slide Slide { get; set; }
    }

}

