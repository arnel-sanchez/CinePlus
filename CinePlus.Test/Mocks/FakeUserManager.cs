using CinePlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;

namespace CinePlus.Test.Mocks
{
    class FakeUserManager : UserManager<User>
    {
        public class FakeIdentityResult : IdentityResult
        {
            public FakeIdentityResult(bool var)
            {
                Succeeded = var;
            }
        }

        public FakeUserManager()
            : base(new Mock<IUserStore<User>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<IPasswordHasher<User>>().Object,
                  new IUserValidator<User>[0],
                  new IPasswordValidator<User>[0],
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<IServiceProvider>().Object,
                  new Mock<ILogger<UserManager<User>>>().Object)
        { }

        public override async Task<User> FindByNameAsync(string userName)
        {
            if (userName == "valid")
            {
                var a = new ValueTask<User>(new User { Name = "valid", Role = Roles.Client });
                return await a.AsTask();
            }
            else if(userName == "partner")
            {
                var a = new ValueTask<User>(new User { Name = "partner", Role = Roles.Partner });
                return await a.AsTask();
            }
            else return null;
        }

        public override async Task<User> FindByIdAsync(string id)
        {
            if (id == "valid")
            {
                var a = new ValueTask<User>(new User { Name = "valid", Role = Roles.Client });
                return await a.AsTask();
            }
            else return null;
        }

        public override async Task<IdentityResult> CreateAsync(User user, string password)
        {
            if(password == "valid" && user.Email == "valid" && user.UserName == "valid" )
            {
                var a = new ValueTask<IdentityResult>(new FakeIdentityResult(true));
                return await a.AsTask();
            }
            else
            {
                var a = new ValueTask<IdentityResult>(new FakeIdentityResult(false) );
                return await a.AsTask();
            }
        }

        public override async Task<bool> CheckPasswordAsync(User user, string password)
        {
            if (password == "valid" && user.Name == "valid")
            {
                var a = new ValueTask<bool>(true);
                return await a.AsTask();
            }
            else
            {
                var a = new ValueTask<bool>(false);
                return await a.AsTask();
            }
        }

        public override async Task<IdentityResult> UpdateAsync(User user)
        {
            if (user.Name == "valid")
            {
                var a = new ValueTask<IdentityResult>(new FakeIdentityResult(true));
                return await a.AsTask();
            }
            else
            {
                var a = new ValueTask<IdentityResult>(new FakeIdentityResult(false));
                return await a.AsTask();
            }
        }
    }
}
