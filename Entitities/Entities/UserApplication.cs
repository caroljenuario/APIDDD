using Microsoft.AspNetCore.Identity;
using MyWebApp.Entitities.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApp.Entitities.Entities
{
    public class UserApplication: IdentityUser
    {
        [Column("rg")]
        public string rg { get; set; }

        [Column("type")]
        public UserType? type { get; set; }
    }
}
