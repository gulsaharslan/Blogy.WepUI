using Blogy.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        List<Message> TGetMessagesByWriter(int id);
        List<Message> TGetOutgoingMessageByWriter(int id);

        List<Message> TGetLastThreeMessagesByWriter(int id);
    }
}
