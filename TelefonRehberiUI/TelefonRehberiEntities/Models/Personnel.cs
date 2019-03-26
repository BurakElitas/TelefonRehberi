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

        [DisplayName("Ýsim"),Required(ErrorMessage ="{0} alaný boþ geçilemez."),
        StringLength(50,ErrorMessage ="{0} alaný max. {1} karakterden oluþmalýdýr.")]
        public string Name { get; set; }


        [DisplayName("Soyisim"),Required(ErrorMessage = "{0} alaný boþ geçilemez."),
        StringLength(50, ErrorMessage = "{0} alaný max. {1} karakterden oluþmalýdýr.")]
        public string Surname { get; set; }

        [DisplayName("Telefon"),Required(ErrorMessage = "{0} alaný boþ geçilemez.")]
        public string Phone { get; set; }

        [DisplayName("Departman")]
        public Nullable<int> DepartmentId { get; set; }

        [DisplayName("Yöneticisi")]
        public Nullable<int> ManagerId { get; set; }

        

        [DisplayName("Departman")]
        public virtual Department Department { get; set; }
        public virtual ICollection<Personnel> Personnel1 { get; set; }

        [DisplayName("Yöneticisi")]
        public virtual Personnel Personnel2 { get; set; }
    }
}
