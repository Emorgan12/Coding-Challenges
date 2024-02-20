using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numatic.Apps.CodingChallenges
{
    public class AppSettingsValidator : AbstractValidator<AppSettings>
    {

        public AppSettingsValidator()
        {

            RuleFor(setting => setting.DatabaseConnectionString)
                .NotNull()
                .NotEmpty()
                .WithMessage("DatabaseConnectionString must not be null or empty.");

        }

    }
}
