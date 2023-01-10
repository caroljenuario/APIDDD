using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitities.Entities
{
    public class Notifies
    {
        public Notifies()
        {
            notifies = new List<Notifies>();
        }

        [NotMapped]
        public string propertyName { get; set; }
        [NotMapped]
        public string message { get; set; }
        [NotMapped]
        public List<Notifies> notifies { get; set; }

        public bool validateStringProperty(string value, string property)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(property)) {

                notifies.Add(new Notifies
                {
                    message = "Required field",
                    propertyName = property
                });
                return false;
            }
            return true;
        }

        public bool validateIntProperty(int value, string property)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(property))
            {

                notifies.Add(new Notifies
                {
                    message = "Campo Obrigatorio",
                    propertyName = property
                });
                return false;
            }
            return true;
        }

    }
}
