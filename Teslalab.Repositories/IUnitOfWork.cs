﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teslalab.Server.Models.Models;

namespace Teslalab.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task CommitChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public UnitOfWork(UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        private IUserRepository _user;

        public IUserRepository Users
        {
            get
            {
                if (_user == null)
                    _user = new IdentityUserRepository(_userManager, _roleManager);

                return _user;
            }
        }

        public async Task CommitChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}