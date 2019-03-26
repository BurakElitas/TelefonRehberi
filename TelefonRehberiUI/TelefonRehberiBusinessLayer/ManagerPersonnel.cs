using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberiBusinessLayer.Abstract;
using TelefonRehberiEntities.Models;

namespace TelefonRehberiBusinessLayer
{
   public class ManagerPersonnel:ManagerBase<Personnel>
    {
        public new BusinessLayerResult<Personnel> Delete(int id)
        {
            BusinessLayerResult<Personnel> personel = new BusinessLayerResult<Personnel>();

            personel.result = Find(x => x.Id == id);

            if (personel.result != null)
            {
               if(!personel.result.Personnel1.Any())
                {
                    base.Delete(personel.result);
                }
               else
                {
                    personel.Errors.Add("Bu çalışan Yönetici konumundadır.Silme işlemi yapılamaz.");
                }
            }
            else
            {
                personel.Errors.Add("Böyle bir kayıt bulunamadı.");
            }



            return personel;
        }
    }
}
