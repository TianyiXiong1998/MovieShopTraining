using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MovieCRM.Core.Entities;
using MovieCRM.Core.Models;

namespace MovieCRM.Core.Contracts.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignUpModel model);
        Task<SignInResult> SignIn(SignInModel model);
    }
}
