using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAppo_AdrianC.Models
{
    public class Service
    {
        public Service()
        {
            //Appointments = new HashSet<Appointment>();
        }

        public int ServiceId { get; set; }
        public string ServiceDescription { get; set; } = null!;
        public int ServiceTimeSpan { get; set; }
        public decimal ServiceEstimatedCost { get; set; }
        public bool? Active { get; set; }

        //public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
