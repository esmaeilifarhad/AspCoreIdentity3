using identityProj.Models.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identityProj.ConfigStartup
{
    public static class Extensions
    {
        public static IServiceCollection AddAthenticate(this IServiceCollection service)
        {
            service.AddIdentity<IdentityUser, IdentityRole>(options=>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";
                options.Lockout.MaxFailedAccessAttempts = 2;
                //چند دقیقه اکانت قفل شود
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                //آیا لازم است ایمیل تایید شود یا خیر
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<PersianIdentityErrorDescriber>();


            return service;
        }
    }
    public class PersianIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
            => new IdentityError()
            {
                Code = nameof(DuplicateEmail),
                Description = $"ایمیل '{email}' قبلا توسط شخص دیگری انتخاب شده است"
            };

        public override IdentityError DuplicateUserName(string userName)
            => new IdentityError()
            {
                Code = nameof(DuplicateUserName),
                Description = $"نام کاربری {userName} قبلا توسط شخص دیگری انتخاب شده است"
            };

        public override IdentityError InvalidEmail(string email)
            => new IdentityError()
            {
                Code = nameof(InvalidEmail),
                Description = $"ایمیل '{email}' ، یک ایمیل معتبر نیست"
            };

        public override IdentityError DuplicateRoleName(string role)
            => new IdentityError()
            {
                Code = nameof(DuplicateRoleName),
                Description = $"مقام '{role}' قبلا ثبت شده است"
            };

        public override IdentityError InvalidRoleName(string role)
            => new IdentityError()
            {
                Code = nameof(InvalidRoleName),
                Description = $"نام '{role}' معتبر نیست"
            };

        public override IdentityError PasswordRequiresDigit()
            => new IdentityError()
            {
                Code = nameof(PasswordRequiresDigit),
                Description = $"رمز عبور باید حداقل دارای یک عدد باشد"
            };

        public override IdentityError PasswordRequiresLower()
            => new IdentityError()
            {
                Code = nameof(PasswordRequiresLower),
                Description = $"رمز عبور باید حداقل دارای یک کاراکتر انگلیسی کوچک باشد ('a'-'z')"
            };

        public override IdentityError PasswordRequiresUpper()
            => new IdentityError()
            {
                Code = nameof(PasswordRequiresUpper),
                Description = $"رمز عبور باید حداقل دارای یک کاراکتر انگلیسی بزرگ باشد ('A'-'Z')"
            };

        public override IdentityError PasswordRequiresNonAlphanumeric()
            => new IdentityError()
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = $"رمز عبور باید حداقل دارای یک کاراکتر ویژه باشد مثل '@#%^&'"
            };

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
            => new IdentityError()
            {
                Code = nameof(PasswordRequiresUniqueChars),
                Description = $"رمز عبور باید حداقل دارای {uniqueChars} کاراکتر منحصر به فرد باشد"
            };

        public override IdentityError PasswordTooShort(int length)
            => new IdentityError()
            {
                Code = nameof(PasswordTooShort),
                Description = $"رمز عبور نباید کمتر از {length} کاراکتر باشد"
            };

        public override IdentityError InvalidUserName(string userName)
            => new IdentityError()
            {
                Code = nameof(InvalidUserName),
                Description = $"نام کاربری '{userName}' معتبر نیست، نام کاربری فقط میتواند دارای حروف یا عدد باشد"
            };

        public override IdentityError UserNotInRole(string role)
            => new IdentityError()
            {
                Code = nameof(UserNotInRole),
                Description = $"کاربر در مقام '{role}' نیست"
            };

        public override IdentityError UserAlreadyInRole(string role)
            => new IdentityError()
            {
                Code = nameof(UserAlreadyInRole),
                Description = $"کاربر در مقام '{role}' است"
            };

        public override IdentityError DefaultError()
            => new IdentityError()
            {
                Code = nameof(DefaultError),
                Description = $"خطای پیشبینی نشده رخ داد"
            };
    }
}
