﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.Models
{
    public class Training
    {
        internal object Category;

        public int TrainingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string shortDescription { get; set; }
        public string icon { get; set; }
        public string VideoUrl { get; set; }
        public string Type { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        
    }
}
