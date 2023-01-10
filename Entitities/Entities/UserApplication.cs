using Microsoft.AspNetCore.Identity;
using Entitities.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitities.Entities
{
    public class UserApplication: IdentityUser
    {
        [Column("rg")]
        public string rg { get; set; }

        [Column("type")]
        public UserType? type { get; set; }
    }
}
