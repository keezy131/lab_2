namespace SOLID_Fundamentals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Класс только для хранения заказов
    public class OrderRepository
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public Order GetOrder(int orderId)
        {
            return orders.FirstOrDefault(o => o.Id == orderId);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }
    }

    // Класс только для валидации
    public class OrderValidator
    {
        public void Validate(Order order)
        {
            if (order.TotalAmount <= 0)
                throw new Exception("Invalid order amount");
        }
    }

    // Класс только для платежей
    public class PaymentService
    {
        public void ProcessPayment(string paymentMethod, decimal amount)
        {
            // логика платежа
        }
    }

    // Класс только для инвентаря
    public class InventoryService
    {
        public void UpdateInventory(List<string> items)
        {
            // логика обновления
        }
    }

    // Класс только для уведомлений
    public class EmailService2
    {
        public void SendEmail(string to, string message)
        {
            Console.WriteLine($"Email sent to {to}: {message}");
        }
    }

    // Класс только для логирования
    public class LogService
    {
        public void Log(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }
    }

    // Класс только для квитанций
    public class ReceiptService
    {
        public void GenerateReceipt(Order order)
        {
            Console.WriteLine($"Receipt generated for order {order.Id}");
        }
    }

    // Класс только для отчетов
    public class ReportService
    {
        public void GenerateMonthlyReport(List<Order> orders)
        {
            decimal totalRevenue = orders.Sum(o => o.TotalAmount);
            int totalOrders = orders.Count;
            Console.WriteLine($"Monthly Report: {totalOrders} orders, Revenue: {totalRevenue:C}");
        }
    }

    // Класс только для экспорта
    public class ExportService
    {
        public void ExportToExcel(string filePath)
        {
            Console.WriteLine($"Exporting to {filePath}");
        }
    }

    // Главный класс теперь только координирует работу
    public class OrderProcessor
    {
        private readonly OrderRepository _repository;
        private readonly OrderValidator _validator;
        private readonly PaymentService _paymentService;
        private readonly InventoryService _inventoryService;
        private readonly EmailService2 _emailService;
        private readonly LogService _logService;
        private readonly ReceiptService _receiptService;
        private readonly ReportService _reportService;
        private readonly ExportService _exportService;

        public OrderProcessor()
        {
            _repository = new OrderRepository();
            _validator = new OrderValidator();
            _paymentService = new PaymentService();
            _inventoryService = new InventoryService();
            _emailService = new EmailService2();
            _logService = new LogService();
            _receiptService = new ReceiptService();
            _reportService = new ReportService();
            _exportService = new ExportService();
        }

        public void AddOrder(Order order)
        {
            _repository.AddOrder(order);
            Console.WriteLine($"Order {order.Id} added");
        }

        public void ProcessOrder(int orderId)
        {
            var order = _repository.GetOrder(orderId);
            if (order != null)
            {
                Console.WriteLine($"Processing order {orderId}");

                _validator.Validate(order);
                _paymentService.ProcessPayment(order.PaymentMethod, order.TotalAmount);
                _inventoryService.UpdateInventory(order.Items);
                _emailService.SendEmail(order.CustomerEmail, $"Order {orderId} processed");
                _logService.Log($"Order {orderId} processed at {DateTime.Now}");
                _receiptService.GenerateReceipt(order);
            }
        }

        public void GenerateMonthlyReport()
        {
            var orders = _repository.GetAllOrders();
            _reportService.GenerateMonthlyReport(orders);
        }

        public void ExportToExcel(string filePath)
        {
            _exportService.ExportToExcel(filePath);
        }
    }
}
