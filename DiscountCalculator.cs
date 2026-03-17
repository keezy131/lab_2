namespace SOLID_Fundamentals
{
    using System.Collections.Generic;

    // Создаем интерфейсы для стратегий
    public interface IDiscountStrategy
    {
        decimal CalculateDiscount(decimal orderAmount);
        bool IsMatch(string customerType);
    }

    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(decimal weight, string destination);
        bool IsMatch(string shippingMethod);
    }

    // Реализации стратегий скидок
    public class RegularDiscount : IDiscountStrategy
    {
        public bool IsMatch(string customerType) => customerType == "Regular";
        public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.05m;
    }

    public class PremiumDiscount : IDiscountStrategy
    {
        public bool IsMatch(string customerType) => customerType == "Premium";
        public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.10m;
    }

    public class VIPDiscount : IDiscountStrategy
    {
        public bool IsMatch(string customerType) => customerType == "VIP";
        public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.15m;
    }

    public class StudentDiscount : IDiscountStrategy
    {
        public bool IsMatch(string customerType) => customerType == "Student";
        public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.08m;
    }

    public class SeniorDiscount : IDiscountStrategy
    {
        public bool IsMatch(string customerType) => customerType == "Senior";
        public decimal CalculateDiscount(decimal orderAmount) => orderAmount * 0.07m;
    }

    // Реализации стратегий доставки
    public class StandardShipping : IShippingStrategy
    {
        public bool IsMatch(string shippingMethod) => shippingMethod == "Standard";
        public decimal CalculateShippingCost(decimal weight, string destination) => 5.00m + (weight * 0.5m);
    }

    public class ExpressShipping : IShippingStrategy
    {
        public bool IsMatch(string shippingMethod) => shippingMethod == "Express";
        public decimal CalculateShippingCost(decimal weight, string destination) => 15.00m + (weight * 1.0m);
    }

    public class OvernightShipping : IShippingStrategy
    {
        public bool IsMatch(string shippingMethod) => shippingMethod == "Overnight";
        public decimal CalculateShippingCost(decimal weight, string destination) => 25.00m + (weight * 2.0m);
    }

    public class InternationalShipping : IShippingStrategy
    {
        public bool IsMatch(string shippingMethod) => shippingMethod == "International";

        public decimal CalculateShippingCost(decimal weight, string destination)
        {
            return destination switch
            {
                "USA" => 30.00m,
                "Europe" => 35.00m,
                "Asia" => 40.00m,
                _ => 50.00m
            };
        }
    }

    // Исправленный класс - открыт для расширения, закрыт для изменения
    public class DiscountCalculator
    {
        private readonly List<IDiscountStrategy> _discountStrategies = new()
        {
            new RegularDiscount(),
            new PremiumDiscount(),
            new VIPDiscount(),
            new StudentDiscount(),
            new SeniorDiscount()
        };

        private readonly List<IShippingStrategy> _shippingStrategies = new()
        {
            new StandardShipping(),
            new ExpressShipping(),
            new OvernightShipping(),
            new InternationalShipping()
        };

        public decimal CalculateDiscount(string customerType, decimal orderAmount)
        {
            foreach (var strategy in _discountStrategies)
            {
                if (strategy.IsMatch(customerType))
                    return strategy.CalculateDiscount(orderAmount);
            }
            return 0;
        }

        public decimal CalculateShippingCost(string shippingMethod, decimal weight, string destination)
        {
            foreach (var strategy in _shippingStrategies)
            {
                if (strategy.IsMatch(shippingMethod))
                    return strategy.CalculateShippingCost(weight, destination);
            }
            return 0;
        }

        // Метод для добавления новых стратегий без изменения кода
        public void AddDiscountStrategy(IDiscountStrategy strategy)
        {
            _discountStrategies.Add(strategy);
        }

        public void AddShippingStrategy(IShippingStrategy strategy)
        {
            _shippingStrategies.Add(strategy);
        }
    }
}
