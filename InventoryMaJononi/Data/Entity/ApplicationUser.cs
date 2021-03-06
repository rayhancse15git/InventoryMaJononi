﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data.MasterData;
using Microsoft.AspNetCore.Identity;

namespace InventoryMaJononi.Data.Entity
{
    public class ApplicationUser : IdentityUser
    {

        //public int? userTypeId { get; set; }
        //public UserType userType { get; set; }

        //[MaxLength(120)]
        //public string org { get; set; }
        //public int userId { get; set; }


        [Required]
        [MaxLength(20)]
        public string firstName { get; set; } 
        
        [Required]
        [MaxLength(20)]
        public string lastName { get; set; }

        public string fullName { get; set; }

        [Required]
        public string imgUrl { get; set; }
        
        public string employeeCode { get; set; }

        public int? branchId { get; set; }
        public Branch Branch { get; set; }

        public int? isVerified { get; set; }

        public int? isActive { get; set; }


        public DateTime? createdAt { get; set; }

        [MaxLength(120)]
        public string createdBy { get; set; }

        public DateTime? updatedAt { get; set; }

        [MaxLength(120)]
        public string updatedBy { get; set; }
    }
}
