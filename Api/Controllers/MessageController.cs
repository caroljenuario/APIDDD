using Api.Model;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entitities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _Imapper;
        private readonly InterfaceMessage _Imessage;
        private readonly InterfaceServiceMessage _IServiceMessage;
        public MessageController(IMapper IMapper, InterfaceMessage Imessage, InterfaceServiceMessage IServiceMessage)
        {
            _Imapper = IMapper;
            _Imessage = Imessage;
            _IServiceMessage = IServiceMessage;
        }


        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Add")]

        public async Task<List<Notifies>> Add(MessageViewModel message)
        {
            message.userId = await GetIdUserLogged();
            var messageMap = _Imapper.Map<Message>(message);
            await _IServiceMessage.Add(messageMap);
            // await _Imessage.Add(messageMap);
            return messageMap.notifies;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Update")]
        public async Task<List<Notifies>> Update(MessageViewModel message)
        {
            var messageMap = _Imapper.Map<Message>(message);
           // await _Imessage.Update(messageMap);
            await _IServiceMessage.Update(messageMap);
            return messageMap.notifies;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Delete")]
        public async Task<List<Notifies>> Delete(MessageViewModel message)
        {
            var messageMap = _Imapper.Map<Message>(message);
            await _Imessage.Delete(messageMap);
            return messageMap.notifies;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/GetEntityById")]
        public async Task<MessageViewModel> GetEntityById(Message message)
        {
            message = await _Imessage.GetEntityById(message.MessageId);
            var messageMap = _Imapper.Map<MessageViewModel>(message);
            return messageMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/List")]
        public async Task<List<MessageViewModel>> List()
        {
            var message = await _Imessage.List();
            var messageMap = _Imapper.Map<List<MessageViewModel>>(message);
            return messageMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/ListActiveMessages")]
        public async Task<List<MessageViewModel>> ListActiveMessages()
        {
            var mensagens = await _IServiceMessage.ListActiveMessages();
            var messageMap = _Imapper.Map<List<MessageViewModel>>(mensagens);
            return messageMap;
        }
        private async Task<string> GetIdUserLogged()
        {
            if (User != null)
            {
                var idUser = User.FindFirst("idUser");
                return idUser.Value;
            }

            return string.Empty;

        }



    }
}
