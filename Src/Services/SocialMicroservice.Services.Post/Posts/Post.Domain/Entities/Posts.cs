

using Social.AuthApi.Models;
using Social.Shared.FileShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Domain.Entities
{
    public class Postss : Files
    {
        public string Description { get; set; }
        public virtual ICollection<Users> Likes { get; set; }
        public int? UserId { get; set; }
        public virtual Users User { get; set; }
        // public int? PostImageId { get; set; }
        public virtual ICollection<ImageFiles> PostImages { get; set; }
       // public virtual ImageFiles PostImage { get; set; }
        public string PostText { get; set; }
        public Postss()
        {
            PostImages = new HashSet<ImageFiles>();
            Likes = new HashSet<Users>();
        }


        public Postss(int id, string postText, int userId, string description, ICollection<Users> likes, ICollection<ImageFiles> paths) : this()
        {
            Id = id;
            PostText = postText;
            Description = description;
            UserId = userId;
            Likes = likes;
            //PostImage = path;
            PostImages = paths;
        }
    }
}
