using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Shared.Messages
{
    
    public class FollowRequestCommand
    {
        public string FollowerName { get; set; } 
        public string FollowedLastName { get; set; } 
        public string FollowedEmail { get; set; }
    }

}
