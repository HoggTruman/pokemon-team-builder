using api.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace api.Tests;

public static class MockHelpers
{
    public static Mock<UserManager<AppUser>> CreateMockUserManager() // IUserStore<AppUser> store = null
    {
        var store = new Mock<IUserStore<AppUser>>().Object; //store ??
        var options = new Mock<IOptions<IdentityOptions>>();
        var idOptions = new IdentityOptions();
        idOptions.Lockout.AllowedForNewUsers = false;
        options.Setup(o => o.Value).Returns(idOptions);
        var userValidators = new List<IUserValidator<AppUser>>();
        var validator = new Mock<IUserValidator<AppUser>>();
        userValidators.Add(validator.Object);
        var pwdValidators = new List<PasswordValidator<AppUser>>();
        pwdValidators.Add(new PasswordValidator<AppUser>());

        var mockUserManager = new Mock<UserManager<AppUser>>(
            store, 
            options.Object, 
            new PasswordHasher<AppUser>(),
            userValidators, 
            pwdValidators, 
            new UpperInvariantLookupNormalizer(),
            new IdentityErrorDescriber(), 
            new Mock<IServiceProvider>().Object, // null
            new Mock<ILogger<UserManager<AppUser>>>().Object
        );

        // validator.Setup(v => v.ValidateAsync(userManager, It.IsAny<AppUser>()))
        //     .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();

        return mockUserManager;
    }
}