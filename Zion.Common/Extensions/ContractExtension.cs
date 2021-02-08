using System;

namespace Zion.Common.NotificationPattern
{
    public static class ContractExtension
    {
        public static Contract MergeContract(this Contract contractDestination, Contract contractSource)
        {
            if (contractSource == null)
                throw new ArgumentNullException("MergeContract received null values");

            contractDestination.AddNotifications(contractSource.Notifications);

            return contractDestination;
        }
    }
}
