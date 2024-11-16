
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Features.Messages.Dtos
{
    public class CreatedMessageDto
    {
        public int Id { get; set; }
        public int? UserName { get; set; }
        public ImageFiles PhotoPath { get; set; }
    }
}
