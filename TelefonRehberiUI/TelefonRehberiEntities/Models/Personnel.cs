using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TelefonRehberiEntities.Models
{
    public partial class Personnel
    {
        public Personnel()
        {
            this.Personnel1 = new List<Personnel>();
        }

        public int Id { get; set; }

        [DisplayName("�sim"),Required(ErrorMessage ="{0} alan� bo� ge�ilemez."),
        StringLength(50,ErrorMessage ="{0} alan� max. {1} karakterden olu�mal�d�r.")]
        public string Name { get; set; }


        [DisplayName("Soyisim"),Required(ErrorMessage = "{0} alan� bo� ge�ilemez."),
        StringLength(50, ErrorMessage = "{0} alan� max. {1} karakterden olu�mal�d�r.")]
        public string Surname { get; set; }

        [DisplayName("Telefon"),Required(ErrorMessage = "{0} alan� bo� ge�ilemez.")]
        public string Phone { get; set; }

        [DisplayName("Departman")]
        public Nullable<int> DepartmentId { get; set; }

        [DisplayName("Y�neticisi")]
        public Nullable<int> ManagerId { get; set; }

        

        [DisplayName("Departman")]
        public virtual Department Department { get; set; }
        public virtual ICollection<Personnel> Personnel1 { get; set; }

        [DisplayName("Y�neticisi")]
        public virtual Personnel Personnel2 { get; set; }
    }
}
