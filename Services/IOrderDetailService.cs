using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace Services
{
    public interface IOrderDetailService
    {
        public List<OrderDetail> GenerateSampleDataset();
        public List<OrderDetail> GetOrderDetails();
        public bool AddOrderDetail(OrderDetail orderDetail);
        public bool RemoveOrderDetail(int orderId, int productId);
        public OrderDetail SearchOrderDetail(int orderId, int productId);
        public bool UpdateOrderDetail(OrderDetail orderDetail);
    }
}
