using Post.Application.Features.Posts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Features.Posts.Model
{
    public class PostListModel
    {
        public IList<PostListDto> Items { get; set; }
    }
}
