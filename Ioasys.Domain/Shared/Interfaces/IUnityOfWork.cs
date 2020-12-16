namespace Ioasys.Domain.Shared.Interfaces
{
    public interface IUnityOfWork
    {
        bool Commit();
    }
}
