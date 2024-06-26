﻿using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
        List<Message> GetMessagesByWriter(int id);
        List<Message> GetOutgoingMessageByWriter(int id);
        List<Message> GetLastThreeMessagesByWriter(int id);

    }
}
