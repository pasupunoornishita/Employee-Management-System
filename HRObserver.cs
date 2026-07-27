using System;

namespace EmployeeManagementSystem.Observer
{
    public class HRObserver : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine(
                $"HR Notification: {message}");
        }
    }
}