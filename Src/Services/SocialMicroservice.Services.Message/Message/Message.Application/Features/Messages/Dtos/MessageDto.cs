using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Features.Messages.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

        public string MessageText { get; set; }
    }
}
