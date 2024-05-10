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
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        private readonly BlogContext context = new BlogContext();

        public List<Message> GetLastThreeMessagesByWriter(int id)
        {
            var values = context.Messages.Where(x => x.ReceiverUserId == id).OrderByDescending(x=>x.MessageId).Take(3).ToList();
            return values;
        }

        public List<Message> GetMessagesByWriter(int id)
        {
            var values = context.Messages.Where(x => x.ReceiverUserId == id).Include(y => y.SenderUser).ToList();
            return values;
        }
        public List<Message> GetOutgoingMessageByWriter(int id)
        {
            var values = context.Messages.Where(x => x.SenderUserId == id).Include(y => y.ReceiverUser).ToList();
            return values;
        }



    }
}
