using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HBOD.Models
{
    public class Registration
    {
        public int CustomerID { get; set; }
        public int HairstylistID { get; set; }
        public int BarberID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Hairstylist Hairstylist { get; set; }
        public virtual Barber Barber { get; set; }
      
    }
}