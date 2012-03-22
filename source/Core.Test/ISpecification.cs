namespace Xunit
{
    public interface ISpecification
    {
        void Act();
        void EstablishContext();
    }
}