using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Features.Posts.Dtos
{
    public class PostListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string? UserName { get; set; }

        public string PostText { get; set; }
    }
}
