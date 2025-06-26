using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace Repositories
{
    public interface IOrderRepository
    {
        public List<Order> GenerateSampleDataset();
        public List<Order> GetOrders();
        public bool AddOrder(Order order);
        public bool RemoveOrder(int orderId);
        public Order SearchOrder(int orderId);
        public bool UpdateOrder(Order order);
    }
}
