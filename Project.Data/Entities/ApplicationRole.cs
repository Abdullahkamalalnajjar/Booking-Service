﻿using Microsoft.AspNetCore.Identity;

namespace Project.Data.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsDefualt { get; set; }
        public bool IsDeleted { get; set; }

    }
}
