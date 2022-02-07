using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using KudryavtsevAlexey.Forum.Domain.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace KudryavtsevAlexey.Forum.IntegrationTests.DataHelpers
{
	public static class UserHelper
	{
		public static ApplicationUser GetOne()
		{
			var password = "UserPassword1";

			var hashedPassword = HashPassword(password);

			var user = new ApplicationUser()
			{
				Name = "User1",
				UserName = "UserName1",
				Email = "UserEmail1@mail.ru",
				Location = "UserLocation1",
				Summary = "UserSummary1",
				PasswordHash = hashedPassword
			};

			return user;
		}

		public static List<ApplicationUser> GetMany()
		{
			var list = new List<ApplicationUser>();

			for (int i = 2; i < 6; i++)
			{
				var password = $"UserPassword{i}";

				var hashedPassword = HashPassword(password);

				var user = new ApplicationUser()
				{
					Name = $"User{i}",
					UserName = $"UserName{i}",
					Email = $"UserEmail{i}@mail.ru",
					Location = $"UserLocation{i}",
					Summary = $"UserSummary{i}",
					PasswordHash = hashedPassword
				};

				list.Add(user);
			}

			return list;
		}

		private static string HashPassword(string password)
		{
			byte[] salt = new byte[128 / 8];

			using (var rngCsp = new RNGCryptoServiceProvider())
			{
				rngCsp.GetNonZeroBytes(salt);
			}

			var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: password,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA256,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));

			return hashedPassword;
		}
	}
}
