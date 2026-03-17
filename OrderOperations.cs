namespace SOLID_Fundamentals
{
    using System;
    using System.Collections.Generic;

    // Разбиваем на маленькие интерфейсы
    public interface IOrderBasicOperations
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }

    public interface IOrderPaymentOperations
    {
        void ProcessPayment(Order order);
    }

    public interface IOrderShippingOperations
    {
        void ShipOrder(Order order);
    }

    public interface IOrderDocumentOperations
    {
        void GenerateInvoice(Order order);
        void GenerateReport(DateTime from, DateTime to);
        void ExportToExcel(string filePath);
    }

    public interface IOrderNotificationOperations
    {
        void SendNotification(Order order);
    }

    public interface IDatabaseOperations
    {
        void BackupDatabase();
        void RestoreDatabase();
    }

    // Менеджер реализует все интерфейсы
    public class OrderManager : IOrderBasicOperations, IOrderPaymentOperations,
                               IOrderShippingOperations, IOrderDocumentOperations,
                               IOrderNotificationOperations, IDatabaseOperations
    {
        public void CreateOrder(Order order)
        {
            Console.WriteLine("Order created");
        }

        public void UpdateOrder(Order order)
        {
            Console.WriteLine("Order updated");
        }

        public void DeleteOrder(int orderId)
        {
            Console.WriteLine("Order deleted");
        }

        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Payment processed");
        }

        public void ShipOrder(Order order)
        {
            Console.WriteLine("Order shipped");
        }

        public void GenerateInvoice(Order order)
        {
            Console.WriteLine("Invoice generated");
        }

        public void SendNotification(Order order)
        {
            Console.WriteLine("Notification sent");
        }

        public void GenerateReport(DateTime from, DateTime to)
        {
            Console.WriteLine("Report generated");
        }

        public void ExportToExcel(string filePath)
        {
            Console.WriteLine("Exported to Excel");
        }

        public void BackupDatabase()
        {
            Console.WriteLine("Database backed up");
        }

        public void RestoreDatabase()
        {
            Console.WriteLine("Database restored");
        }
    }

    // Портал клиента реализует только нужные методы
    public class CustomerPortal : IOrderBasicOperations
    {
        public void CreateOrder(Order order)
        {
            Console.WriteLine("Order created by customer");
        }

        public void UpdateOrder(Order order)
        {
            Console.WriteLine("Order updated by customer");
        }

        public void DeleteOrder(int orderId)
        {
            Console.WriteLine("Order deleted by customer");
        }
    }
}
