using Common.Domain;

namespace Core.Web
{
    public class Creator : ClaimBase
    {
        private Creator(string securable, Right right)
            : base(securable, right)
        {
        }

        public static Creator For(string securable)
        {
            return new Creator(securable, Right.Creator);
        }

        public static implicit operator Claim(Creator builder)
        {
            return Build(builder);
        }
    }
}