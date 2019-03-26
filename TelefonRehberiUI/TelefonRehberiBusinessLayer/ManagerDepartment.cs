using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberiBusinessLayer.Abstract;
using TelefonRehberiEntities.Models;

namespace TelefonRehberiBusinessLayer
{
   public class ManagerDepartment:ManagerBase<Department>
    {
        public new BusinessLayerResult<Department> Delete(int id)
        {
            BusinessLayerResult<Department> department = new BusinessLayerResult<Department>();

            department.result = Find(x => x.Id == id);

            if (department.result != null)
            {
                if (!department.result.Personnels.Any())
                {
                    base.Delete(department.result);
                }
                else
                {
                    department.Errors.Add("Bu departmana kayıtlı personel vardır.Silme işlemi yapılamaz.");
                }
            }
            else
            {
                department.Errors.Add("Böyle bir kayıt bulunamadı.");
            }



            return department;
        }
    }
}
