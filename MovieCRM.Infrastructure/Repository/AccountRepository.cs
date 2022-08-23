using Microsoft.AspNetCore.Identity;
using MovieCRM.Core.Contracts.Repository;
using MovieCRM.Core.Entities;
using MovieCRM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCRM.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountRepository(UserManager<ApplicationUser> um, SignInManager<ApplicationUser> s)
        {
            userManager = um;
            signInManager = s;
        }

        public Task<SignInResult> SignIn(SignInModel model)
        {
            return signInManager.PasswordSignInAsync(model.Email, model.PassWord,model.Remember,false);
        }

        public Task<IdentityResult> SignUp(SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user.Name = model.Name;
            user.Email = model.Email;
            user.UserName = model.Email;
            return userManager.CreateAsync(user,model.Password);

        }
    }
}
