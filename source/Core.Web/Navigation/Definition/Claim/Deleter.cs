using Common.Domain;

namespace Core.Web
{
    public class Deleter : ClaimBase
    {
        private Deleter(string securable, Right right)
            : base(securable, right)
        {
        }

        public static Deleter For(string securable)
        {
            return new Deleter(securable, Right.Deleter);
        }

        public static implicit operator Claim(Deleter builder)
        {
            return Build(builder);
        }
    }
}