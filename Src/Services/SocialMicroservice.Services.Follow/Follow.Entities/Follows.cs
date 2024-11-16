
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Follow.Core.DataAccess;
namespace Follow.Entities
{
    public class Follows : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserMail { get; set; }
    }
}
