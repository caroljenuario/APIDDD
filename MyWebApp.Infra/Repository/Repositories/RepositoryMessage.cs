using Domain.Interfaces;
using Entitities.Entities;
using Infra.Configuration;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Repositories
{
    public class RepositoryMessage: RepositoryGeneric<Message>, InterfaceMessage
    {
        private readonly DbContextOptions<Context> _OptionsBuilder;

        public RepositoryMessage()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }


    }
}
