﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Auction.Entities
{
   public class TeamOwner : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
