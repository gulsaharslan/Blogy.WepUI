using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
		public List<Article> TGetArticleWithWriter();
        AppUser TGetWriterInfoByArticleWriter(int id);
        List<Article> TGetArticlesByWriter(int id);

        List<Article> TGetLatestArticles(int id);
        List<Article> TGetListAll();
        List<Article> TGetLast4Article();
        Article TGetLatestArticleByWriterId(int id);


    }
}
