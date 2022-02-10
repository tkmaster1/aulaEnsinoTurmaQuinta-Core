﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Notifications;

namespace TKMaster.AulaEnsino.Core.Domain.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        #region Properties

        private IList<DomainNotification> _notifications;

        #endregion

        #region Constructor

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        #endregion

        #region Methods

        public Task Handler(DomainNotification message)
        {
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public virtual IList<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

        #endregion
    }
}
