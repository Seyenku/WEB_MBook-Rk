using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace MBook_Rk.Models
{
    public class CustomUserManager : UserManager<ApplicationUser>
    {
        public CustomUserManager(
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            var user = await Users.FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
            return user;
        }

        public override async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrEmpty(user.Id)) // Проверяем, есть ли ID, если нет — создаем
                user.Id = Guid.NewGuid().ToString();

            var result = await ValidateUser(user);
            if (!result.Succeeded)
                return result;

            user.PasswordHash = PasswordHasher.HashPassword(user, password);
            user.SecurityStamp = Guid.NewGuid().ToString(); // Обязательно устанавливаем SecurityStamp

            await Store.CreateAsync(user, CancellationToken.None);
            return IdentityResult.Success;
        }

        private async Task<IdentityResult> ValidateUser(ApplicationUser user)
        {
            var errors = new List<IdentityError>();
            foreach (var validator in UserValidators)
            {
                var result = await validator.ValidateAsync(this, user);
                if (!result.Succeeded)
                {
                    errors.AddRange(result.Errors);
                }
            }
            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }
            return IdentityResult.Success;
        }
    }
}