using Social.AuthApi.Models;
using Social.Shared.FileShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Domain
{
    public class Messagess :Files
    {
       
        public int? UserId { get; set; }
        public string MessageText { get; set; }
        public Users Users { get; set; }
        public ImageFiles Photo { get; set; }
        public Messagess()
        {

        }

        public Messagess(int id, string text, ImageFiles photoPath, int userId, Users users) : this()
        {
            Id = id;
            UserId = userId;
            MessageText = text;
            Photo = photoPath;
            Users = users;
        }
    }
}