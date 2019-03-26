using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberiBusinessLayer.Abstract;
using TelefonRehberiEntities.Models;

namespace TelefonRehberiBusinessLayer
{
   public class ManagerAdmin:ManagerBase<Admin>
    {
        public new BusinessLayerResult<Admin> Insert(Admin admin)
        {
            BusinessLayerResult<Admin> a = new BusinessLayerResult<Admin>();
            a.result = Find(x => x.UserName == admin.UserName);

            if(a.result!=null)
            {
                a.Errors.Add("Bu Kullanıcı Adı kullanılmaktadır.Lütfen başka bir tane deneyiniz.");
            }
            else
            {
                base.Insert(admin);
            }
            return a;
        }

        public BusinessLayerResult<Admin> Login(Admin admin)
        {
            BusinessLayerResult<Admin> a = new BusinessLayerResult<Admin>();
            a.result= Find(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if(a.result==null)
            {
                a.Errors.Add("Yanlış kullanıcı adı veya şifre.Lütfen tekrar deneyiniz.");
            }
            return a;
        }
    }
}
