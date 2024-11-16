using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Message.Application.Services.SignalHub
{
    public class BaseUserId : ControllerBase
    {
        public int getIdFromRequest() //todo authentication behavior?
        {
            int userId = 1;
            return userId;
        }
    }
}
