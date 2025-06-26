using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        OrderDAO orderDAO = new OrderDAO();

        public bool AddOrder(Order order)
        {
            return orderDAO.AddOrder(order);
        }

        public List<Order> GenerateSampleDataset()
        {
            return orderDAO.GenerateSampleDataset();
        }

        public List<Order> GetOrders()
        {
            return orderDAO.GetOrders();
        }

        public bool RemoveOrder(int orderId)
        {
            return orderDAO.RemoveOrder(orderId);
        }

        public Order SearchOrder(int orderId)
        {
            return orderDAO.SearchOrder(orderId);
        }

        public bool UpdateOrder(Order order)
        {
            return orderDAO.UpdateOrder(order);
        }
    }
}
