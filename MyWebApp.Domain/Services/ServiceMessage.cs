using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entitities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceMessage: InterfaceServiceMessage
    {
       private readonly InterfaceMessage _iMessage;

       public ServiceMessage(InterfaceMessage InterfaceMessage)
        {
            _iMessage = InterfaceMessage;
        }

        //implementacao de metodos customizados(validar se possui titulo, salvas datas de cadastro/atualizacao horario atuais,
        //listar so usuarios ativos)
        public async Task Add(Message Object)
        {
            var validateTitle = Object.validateStringProperty(Object.messageTitle, "Title");
            if (validateTitle)
            {
                Object.registrationDate = DateTime.Now;
                Object.changeDate  = DateTime.Now;
                Object.isActive = true;
                await _iMessage.Add(Object);
            }
        }

        public async Task<List<Message>> ListActiveMessages()
        {
            return await _iMessage.ListMessage(n => n.isActive);
        }

        public async Task Update(Message Object)
        {
            var validateTitle = Object.validateStringProperty(Object.messageTitle, "Title");
            if (validateTitle)
            {
                Object.changeDate = DateTime.Now;
                await _iMessage.Update(Object);
            }
        }
    }
}
