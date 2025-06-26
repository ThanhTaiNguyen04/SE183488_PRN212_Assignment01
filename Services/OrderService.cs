using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Repositories;

namespace Services
{
    public class OrderService : IOrderService
    {
        private static OrderService _instance;
        private static readonly object _lock = new object();
        private readonly IOrderRepository iorderRepository;
        private OrderService()
        {
            iorderRepository = new OrderRepository();
        }
        public static OrderService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new OrderService();
                        }
                    }
                }
                return _instance;
            }
        }
        public bool AddOrder(Order order)
        {
            return iorderRepository.AddOrder(order);
        }
        public List<Order> GenerateSampleDataset()
        {
            return iorderRepository.GenerateSampleDataset();
        }
        public List<Order> GetOrders()
        {
            return iorderRepository.GetOrders();
        }
        public bool RemoveOrder(int orderId)
        {
            return iorderRepository.RemoveOrder(orderId);
        }
        public Order SearchOrder(int orderId)
        {
            return iorderRepository.SearchOrder(orderId);
        }
        public bool UpdateOrder(Order order)
        {
            return iorderRepository.UpdateOrder(order);
        }
    }
}
