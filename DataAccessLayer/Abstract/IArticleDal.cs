using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract
{
    public interface IArticleDal:IGenericDal<Article>
    {
        List<Article> GetArticleWithWriter();
        AppUser GetWriterInfoByArticleWriter(int id);
        List<Article> GetArticlesByWriter(int id);

        List<Article> GetLatestArticles(int id);
        List<Category> GetLatestCategories(int id);
        List<Article> GetListAll();
        List<Article> GetLast4Article();

    }
}
