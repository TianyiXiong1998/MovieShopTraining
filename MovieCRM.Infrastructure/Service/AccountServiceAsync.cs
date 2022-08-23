using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MovieCRM.Core.Contracts.Repository;
using MovieCRM.Core.Contracts.Service;
using MovieCRM.Core.Models;

namespace MovieCRM.Infrastructure.Service
{
    public class AccountServiceAsync : IAccountServiceAsync
    {
        private readonly IAccountRepository accountRepository;
        public AccountServiceAsync(IAccountRepository account)
        {
            accountRepository = account;
        }

        public Task<SignInResult> SignInAsync(SignInModel model)
        {
            return accountRepository.SignIn(model);
        }

        public Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            return accountRepository.SignUp(model);
        }
    }
}
