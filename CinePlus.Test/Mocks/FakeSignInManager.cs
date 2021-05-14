using CinePlus.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading.Tasks;

namespace CinePlus.Test.Mocks
{
    public class FakeSignInResult : SignInResult
    {
        public FakeSignInResult(bool a)
        {
            Succeeded = a;
        }
    }

    public class FakeSignInManager : SignInManager<User>
    {
        public FakeSignInManager(FakeHttpContextAccessor request) 
            : base(new FakeUserManager(),
                request,
                new Mock<IUserClaimsPrincipalFactory<User>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<ILogger<SignInManager<User>>>().Object,
                new Mock<IAuthenticationSchemeProvider>().Object,
                new Mock<IUserConfirmation<User>>().Object)
        { }

        public override async Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            if (user.Name == "valid" && password == "valid")
            {
                var a = new ValueTask<SignInResult>(new FakeSignInResult(true));
                return await a.AsTask();
            }
            else
            {
                var a = new ValueTask<SignInResult>(new FakeSignInResult(false));
                return await a.AsTask();
            }
        }

        public override async Task SignOutAsync()
        {
            var a = new ValueTask();
            await a.AsTask();
        }
    }
}
