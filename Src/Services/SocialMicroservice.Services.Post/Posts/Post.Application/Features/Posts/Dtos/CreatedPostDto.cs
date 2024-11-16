using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Features.Posts.Dtos
{
    public class CreatedPostDto
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int? UserId { get; set; }
        public virtual ICollection<ImageFiles> PostImages { get; set; }
        public string PostText { get; set; }
    }
}
