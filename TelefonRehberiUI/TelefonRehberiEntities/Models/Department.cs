using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TelefonRehberiEntities.Models
{
    public partial class Department
    {
        public Department()
        {
            this.Personnels = new List<Personnel>();
        }

        public int Id { get; set; }

        [DisplayName("Departman Adý")]
        public string Name { get; set; }
        public virtual ICollection<Personnel> Personnels { get; set; }
    }
}
