namespace EmployeeManagementSystem.Observer
{
    public class NotificationService
        : INotificationService
    {
        private readonly EmployeeNotificationService
            _subject = new();

        public NotificationService()
        {
            _subject.Attach(new HRObserver());
            _subject.Attach(new ManagerObserver());
        }

        public void NotifyEmployeeAdded(string employeeName)
        {
            _subject.Notify(
                $"Employee {employeeName} Added");
        }
    }
}
