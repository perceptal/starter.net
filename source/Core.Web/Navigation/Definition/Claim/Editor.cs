using Common.Domain;

namespace Core.Web
{
    public class Editor : ClaimBase
    {
        private Editor(string securable, Right right)
            : base(securable, right)
        {
        }

        public static Editor For(string securable)
        {
            return new Editor(securable, Right.Editor);
        }

        public static implicit operator Claim(Editor builder)
        {
            return Build(builder);
        }
    }
}