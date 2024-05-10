using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
    public class EfCommentDal:GenericRepository<Comment>,ICommentDal
    {
        BlogContext context=new BlogContext();

        public int GetCommentCountByWriter(int id)
        {
            return context.Comments.Where(x=>x.AppUserId == id).Count();
        }

        public List<Comment> GetCommentsByArticleId(int id)
        {
            var values = context.Comments.Where(x=>x.ArticleId==id).ToList();
            return  values;
        }

        public List<Comment> GetCommentsByWriterId(int id)
        {
            var values=context.Comments.Where(x=>x.AppUserId==id).Include(c => c.Article).ToList();
            return values;
        }
    }
}
