using System.Threading.Tasks;

namespace TKMaster.AulaEnsino.Core.Domain.Interfaces.Notifications
{
    public interface INotificationHandler<T> where T : class
    {
        Task Handler(T notification);
    }
}
