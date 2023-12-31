﻿using System.ComponentModel.DataAnnotations;
using Zamiux.Web.Entities.Authorization;

namespace Zamiux.Web.Entities.User
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string UserEmail { get; set; }

        [MaxLength(300)]
        public string UserPassword { get; set; }

        public string EmailActivationCode { get; set; }

        public bool UserStatus { get; set; } = true;
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool isSuperUser { get; set; } = false;
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
