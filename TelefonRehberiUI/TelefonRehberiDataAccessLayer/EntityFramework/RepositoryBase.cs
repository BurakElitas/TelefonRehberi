using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.DataAccessLayer.EntityFramework;

namespace TelefonRehberiDataAccessLayer.EntityFramework
{
   public class RepositoryBase
    {
        private static TelefonRehberiContext context;
        public static TelefonRehberiContext CreateContext
        {
            get
            {
                if (context == null)
                {
                    context = new TelefonRehberiContext();
                }
                return context;
            }
        }
    }
}
