using System;

namespace Common.Domain.Implementation
{
    public class UserFactory : IUserFactory
    {
        private const string DefaultPassword = "secret";

        public UserFactory(IUserRepository repository, IAuthenticationPolicyProvider policy)
        {
            this.Repository = repository;
            this.Policy = policy;
        }

        private IUserRepository Repository { get; set; }
        private IAuthenticationPolicyProvider Policy { get; set; }

        public User Create(string username)
        {
            username = EnsureUsernameIsUnique(username).ToLowerInvariant();

            return new User
            {
                Username = username,
                FailedSignOnAttempts = 0,
                IsLocked = false,
                IsSupport = false,
                Password = this.Policy.GeneratePassword(username, DefaultPassword)
            };
        }

        private string EnsureUsernameIsUnique(string original)
        {
            bool unique = false;
            string username = original;
            int count = 0;

            do
            {
                if (this.Repository.GetByUserName(username) == null)
                {
                    unique = true;
                }
                else
                {
                    username = original + (count++).ToString();
                }

            } while (!unique);

            return username;
        }
    }
}
