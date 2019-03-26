using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TelefonRehberiEntities.Models
{
   public partial class Admin
    {
        public int Id { get; set; }

        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez."),
       StringLength(50, ErrorMessage = "{0} alanı max. {1} karakterden oluşmalıdır.")]
        public string UserName { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."),
       StringLength(50, ErrorMessage = "{0} alanı max. {1} karakterden oluşmalıdır."),DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
