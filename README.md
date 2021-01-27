# Zion.Common - Notification Pattern

A set of common classes and tools to improve your productivity.

## Give a Star! :star:

| Package |  Version | Popularity |
| ------- | ----- | ----- |
| `Zion.Common` | [![NuGet](https://img.shields.io/nuget/v/Zion.Common.svg)](https://nuget.org/packages/Zion.Common) | [![Nuget](https://img.shields.io/nuget/dt/Zion.Common.svg)](https://nuget.org/packages/Zion.Common) |


## How to use?

```
namespace Zion.Common
{
    public class ExampleNotificationPattern
    {
        public Zion.Common.NotificationPattern.Contract Example1 ()
        {
            var contract = new Zion.Common.NotificationPattern.Contract();

            contract.AddNotification(
                property: "property",
                message: "An error has occurred",
                ehError: true
            );
            
            contract.AddNotification(
                property: "property",
                message: "This is an example of a message that is not an error",
                ehError: false
            );

            return contract;
        }

        public Zion.Common.NotificationPattern.Contract Example2()
        {
            var contract = new Zion.Common.NotificationPattern.Contract();

            var notification = new Zion.Common.NotificationPattern.Notification(
                property: "property",
                message: "An error has occurred",
                ehError: true
            );

            contract.AddNotification(notification);

            return contract;
        }

        public void Example3()
        {
            var entity = new Entity("Alexandre Laranjeiras");

            if (entity.Name != "Alexandre Laranjeiras")
                entity.AddNotification(property: "Name", message: "The name is not equal");

            if (entity.Invalid)
            {
                Console.WriteLine("An error has ocurred");

                foreach (var notification in entity.Notifications)
                    Console.WriteLine(notification.Message);
            }
        }
    }

    public class Entity : Zion.Common.NotificationPattern.Notifiable
    {
        public string Name { get; private set; }

        public Entity(string name)
        {
            Name = name;
        }
    }
}

```