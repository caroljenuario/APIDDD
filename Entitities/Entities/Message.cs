using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApp.Entitities.Entities
{
    [Table("MESSAGE")]
    public class Message: Notifies
    {
        [Column("messageId")]
        public int MessageId { get; set; }

        [Column("messageTitle")]
        public string messageTitle { get; set; }
        
        [Column("isActive")]
        public bool isActive { get; set; }

        [Column("registrationDate")]
        public DateTime registrationDate { get; set; }

        [Column("changeDate")]
        public DateTime changeDate { get; set; }
        [ForeignKey("UserAplication")]
        [Column(Order = 1)] 
        public string userId { get; set; }
        public virtual UserApplication UserApplication { get; set; }




    }
}
