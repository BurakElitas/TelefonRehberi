using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelefonRehberiEntities.Models;

namespace TelefonRehberiUI.Models
{
    public static class CurrentSession
    {
        public static Admin Admin
        {
            get
            {
              return Get<Admin>("Admin");
            }
        }

        public static void Set<T>(string key,T obj)
        {
            if(HttpContext.Current.Session[key]==null)
            {
                HttpContext.Current.Session[key] = obj;
            }
        }

        public static T Get<T>(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return (T)(HttpContext.Current.Session[key]);
            }
            else
                return default(T);
        }

        public static void Remove(string key)
        {
            if(HttpContext.Current.Session[key]!=null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }

       
    }
}