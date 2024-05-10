using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Concrete
{
   
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetListAll()
        {
            return _messageDal.GetListAll();
        }

        public List<Message> TGetMessagesByWriter(int id)
        {
            return _messageDal.GetMessagesByWriter(id);
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
          _messageDal.Update(entity);
        }

        public List<Message> TGetOutgoingMessageByWriter(int id)
        {
            return _messageDal.GetOutgoingMessageByWriter(id);
        }

        public List<Message> TGetLastThreeMessagesByWriter(int id)
        {
            return _messageDal.GetLastThreeMessagesByWriter(id);
        }
    }
}
