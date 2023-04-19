using System;
using System.Collections.Generic;
using System.Text;

namespace AutoAppo_AdrianC.Models
{
    public class AppoStatus
    {

        public AppoStatus()
        {
            //Appointments = new HashSet<Appointment>();
        }

        public int AppoStatusId { get; set; }
        public string AppoStatusDescription { get; set; } = null!;

       //public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
