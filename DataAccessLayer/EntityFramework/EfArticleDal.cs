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
    public class EfArticleDal:GenericRepository<Article>,IArticleDal
    {
      private readonly  BlogContext context=new BlogContext();

        public List<Article> GetArticlesByWriter(int id)
        {
          var values=context.Articles.Where(x=>x.AppUserId==id).Include(y=>y.Category).ToList();
            return values;
        }

        public List<Article> GetArticleWithWriter()
        {
            var values=context.Articles.Include(x=> x.AppUser).ToList();
            return values;
        }

        public List<Article> GetLatestArticles(int id)
        {
            return context.Articles.OrderByDescending(a => a.CreatedDate).Take(5).ToList();
        }

        public List<Category> GetLatestCategories(int id)
        {
            throw new NotImplementedException();
        }

        public AppUser GetWriterInfoByArticleWriter(int id)
        {
            var values = context.Articles.Where(x => x.ArticleId == id).Select(y => y.AppUser).FirstOrDefault();
            return values;
        }

        public List<Article> GetListAll() 
        {
            var values = context.Articles.Include(x => x.AppUser)
                                       .Include(y => y.Category)
                                       .ToList();
            return values;
        }

        public List<Article> GetListAll(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetLast4Article()
        {
            var values = context.Articles.OrderByDescending(y => y.CreatedDate).Take(4).ToList();
            return values;
        }

        public Article GetLatestArticleByWriter(int id)
        {
            var values = context.Articles.Where(x => x.AppUserId == id).OrderByDescending(z => z.CreatedDate).FirstOrDefault();

            return values;
        }

        public Article GetLatestArticleByWriterId(int id)
        {
            var values = context.Articles
          .Where(x => x.AppUserId == id)
          .OrderByDescending(z => z.CreatedDate)  
          .FirstOrDefault();

            return values;
        }
    }
}
