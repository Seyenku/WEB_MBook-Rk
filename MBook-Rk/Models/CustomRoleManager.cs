using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MBook_Rk.Models
{
    public class CustomRoleManager : RoleManager<ApplicationRole>
    {
        private readonly IRoleStore<ApplicationRole> _roleStore;

        public CustomRoleManager(
            IRoleStore<ApplicationRole> store,
            IEnumerable<IRoleValidator<ApplicationRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<ApplicationRole>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
            _roleStore = store;
        }

        public override async Task<IdentityResult> CreateAsync(ApplicationRole role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            role.Id = Guid.NewGuid().ToString(); // Устанавливаем уникальный ID
            var validation = await ValidateRoleAsync(role);
            if (!validation.Succeeded)
                return validation;

            var result = await _roleStore.CreateAsync(role, CancellationToken.None);
            return result;
        }

        public override async Task<ApplicationRole> FindByNameAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                throw new ArgumentNullException(nameof(roleName));

            string normalizedRoleName = roleName.ToUpper(); // Приводим к `NormalizedName`
            Console.WriteLine($"DEBUG: Поиск роли {roleName} (нормализованное: {normalizedRoleName})");

            return await Roles.FirstOrDefaultAsync(r => r.NormalizedName == normalizedRoleName);
        }

        private async Task<IdentityResult> ValidateRoleAsync(ApplicationRole role)
        {
            var errors = new List<IdentityError>();
            foreach (var validator in RoleValidators)
            {
                var result = await validator.ValidateAsync(this, role);
                if (!result.Succeeded)
                    errors.AddRange(result.Errors);
            }
            return errors.Count > 0 ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }
    }
}
