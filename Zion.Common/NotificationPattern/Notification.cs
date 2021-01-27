using System.Collections.Generic;

namespace Zion.Common.NotificationPattern
{
    public class Notification
    {
        public Notification(string property, string message, bool ehError = true)
        {
            Property = property;
            Message = message;
            EhError = ehError;
        }

        public string Property { get; private set; }
        public string Message { get; private set; }
        public bool EhError { get; set; }

        public override bool Equals(object obj)
        {
            var notification = obj as Notification;
            return notification != null &&
                   Property == notification.Property &&
                   Message == notification.Message;
        }

        public override int GetHashCode()
        {
            var hashCode = -1618876500;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Property);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Message);
            return hashCode;
        }
    }
}
