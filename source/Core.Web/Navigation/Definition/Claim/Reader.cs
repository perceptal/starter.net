using Common.Domain;

namespace Core.Web
{
    public class Reader : ClaimBase
    {
        private Reader(string securable, Right right)
            : base(securable, right)
        {
        }

        public static Reader For(string securable)
        {
            return new Reader(securable, Right.Reader);
        }

        public static implicit operator Claim(Reader builder)
        {
            return Build(builder);
        }
    }
}