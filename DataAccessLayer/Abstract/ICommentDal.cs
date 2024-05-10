﻿using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment> 
    { 
        List<Comment> GetCommentsByArticleId(int id);
        List<Comment> GetCommentsByWriterId(int id);
        int GetCommentCountByWriter(int id);
    }
}
