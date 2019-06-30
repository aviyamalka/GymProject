using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBabySitter{get;set;}
        public Address BranchAddress { get; set; }
        //public int AddressId { get; set; }
        public ICollection<Lesson> Lessons { get; set; }

    }
}
