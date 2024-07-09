using api.Data;
using api.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
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


    public static Mock<SignInManager<AppUser>> CreateMockSignInManager()
    {
        var userManager = CreateMockUserManager().Object;
        var contextAccessor = new Mock<IHttpContextAccessor>().Object;
        var claimsFactory = new Mock<IUserClaimsPrincipalFactory<AppUser>>().Object;
        
        var options = new Mock<IOptions<IdentityOptions>>();
        var idOptions = new IdentityOptions();
        idOptions.Lockout.AllowedForNewUsers = false;
        options.Setup(o => o.Value).Returns(idOptions);
        
        var logger = new Mock<ILogger<SignInManager<AppUser>>>().Object;
        var schemes = new Mock<IAuthenticationSchemeProvider>().Object;
        var confirmation = new Mock<IUserConfirmation<AppUser>>().Object;


        var mockSignInManager = new Mock<SignInManager<AppUser>>(
            userManager,
            contextAccessor,
            claimsFactory,
            options.Object,
            logger,
            schemes,
            confirmation
        );

        return mockSignInManager;
    }


    public static Mock<IServiceScopeFactory> CreateMockServiceScopeFactory()
    {
        var mockServiceProvider = new Mock<IServiceProvider>();
        mockServiceProvider.Setup(x => x.GetService(typeof(ApplicationDbContext)))
            .Returns(Utility.CreateTestDbContext());

        var mockScope = new Mock<IServiceScope>();
        mockScope.Setup(x => x.ServiceProvider)
            .Returns(mockServiceProvider.Object);

        var mockScopeFactory = new Mock<IServiceScopeFactory>();        
        mockScopeFactory.Setup(x => x.CreateScope())
            .Returns(mockScope.Object);

        return mockScopeFactory;
    }
}