using System;
using System.Collections.Generic;
using System.Linq;

namespace Zion.Common.NotificationPattern
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications = new List<Notification>();

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public IReadOnlyCollection<Notification> Errors =>
            _notifications.Where(x => x.EhError == true).ToList();

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        public void AddNotification(string property, string message, bool ehError = true)
        {
            _notifications.Add(new Notification(property, message, ehError));
        }

        public void AddNotification(Notification notification)
        {
            if (notification == null)
                throw new ArgumentNullException();

            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications) => 
            _notifications.AddRange(notifications);

        public void AddNotifications(ICollection<Notification> notifications) => 
            _notifications.AddRange(notifications);

        public void AddNotifications(Notifiable item)
        {
            AddNotifications(item.Notifications);
        }

        public void AddNotifications(params Notifiable[] items)
        {
            foreach (var item in items)
                AddNotifications(item);
        }

        public void RemoveNotification(Notification notification) => 
            _notifications.Remove(notification);

        public void RemoveNotification(string property)
        {
            _notifications.RemoveAll(x => x.Property == property);
        }

        public void RemoveAllNotifications()
        {
            foreach (var notification in _notifications)
                _notifications.Remove(notification);
        }

        public bool Valid => !_notifications.Where(x => x.EhError == true).Any();

        public bool Invalid => !Valid;
    }
}
