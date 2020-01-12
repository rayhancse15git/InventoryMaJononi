﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMaJononi.Data;
using InventoryMaJononi.Models.AccountViewModels;
using InventoryMaJononi.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryMaJononi.Areas.User.Controllers
{
    [Area("User")]
    public class UserControlController : Controller
    {
        private readonly IUserService _iUserService;
    

        public UserControlController(IUserService iUserService)
        {
            _iUserService = iUserService;
 
        }


        public async Task<IActionResult> Index()
        {

            var model = new RegisterViewModel
            {
                allUsers = await _iUserService.GetAllUser()

            };

            // OR

            // List<ApplicationUser> users = await _userManager.Users.ToListAsync();


            return View(model);
        }
    }
}