using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal :GenericRepository<AppUser>, IAppUserDal
    {
        private readonly BlogContext context = new BlogContext();
        public AppUser ChangeApproval(int id)
        {
            var writers = context.AppUsers.Find(id);
            if (writers.IsActive == true)
            {
                writers.IsActive = false;
            }
            else
            {
                writers.IsActive = true;
            }

            context.SaveChanges();
            return writers;
        }
    }
}
