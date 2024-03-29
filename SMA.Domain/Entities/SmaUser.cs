﻿using SMA.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Domain.Entities
{
    public class SmaUser : BaseEntitites
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public bool IsFacebook { get; set; }
        public bool IsGoogle { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public List<long> Roles { get; set; }
        public List<long> Permission { get; set; }

    }
}
