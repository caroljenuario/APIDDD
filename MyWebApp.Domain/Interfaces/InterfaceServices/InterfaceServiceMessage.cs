using Entitities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    //metodos customizados
    public interface InterfaceServiceMessage
    {
        Task Add(Message Object);

        Task Update(Message Object);

        Task<List<Message>> ListActiveMessages();
    }
}
