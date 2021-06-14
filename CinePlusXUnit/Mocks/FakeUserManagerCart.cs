using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using CinePlus.Models;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.CodeAnalysis.Editing;
using  Moq;
using Microsoft.Extensions.Options;

namespace CinePlusXUnit.Mocks
{
    class FakeUserManagerCart : UserManager<User>
    {
        public FakeUserManagerCart()
            : base(new Mock<IUserStore<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<User>>().Object,
                new IUserValidator<User>[0],
                new IPasswordValidator<User>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<User>>>().Object)
        {

        }

        public override async Task<User> FindByNameAsync(string userName)
        {
            var a = new ValueTask<User>(new User { Name = "valid", Role = Roles.Client });
            return await a.AsTask();
        }
    }
}
