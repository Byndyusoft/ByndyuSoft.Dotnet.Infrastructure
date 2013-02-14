namespace ByndyuSoft.Infrastructure.NHibernate
{
    using global::NHibernate;

    ///<summary>
    ///</summary>
    public interface ISessionProvider
    {
        ///<summary>
        ///</summary>
        ///<returns> </returns>
        ISession CurrentSession { get; }
    }
}