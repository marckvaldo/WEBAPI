using Cart.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Business.interfaces.Notifications
{
    public interface INotifier
    {
        bool HasNotification();

        List<Notification> GetNotification();

        void Handle(Notification notification);

    }
}
