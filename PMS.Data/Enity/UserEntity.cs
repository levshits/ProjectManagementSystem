﻿using System;
using System.Collections.Generic;
using Levshits.Data.Entity;

namespace PMS.Data.Enity
{
    public class UserEntity: PrincipalEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Avatar { get; set; }
        
    }
}