using TKMaster.Common.Util.Domain.Notifications;

namespace TKMaster.Common.Domain.Interfaces;

public interface INotificationHandler<T> where T : class
{
    Task Handle(T notification);

    IList<Notification> GetNotifications();
}