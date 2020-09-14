﻿using Microsoft.AspNetCore.Identity;

namespace WebStoreGusev.Domain.Entities.Identity
{
    public class Role :IdentityRole
    {
        public const string Administrator = "Administrators";
        public const string User = "Users";
    }
}
