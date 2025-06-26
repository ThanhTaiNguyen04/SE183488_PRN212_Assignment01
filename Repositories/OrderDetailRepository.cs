using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        OrderDetailDAO orderDetailDAO = new OrderDetailDAO();

        public bool AddOrderDetail(OrderDetail detail)
        {
            return orderDetailDAO.AddOrderDetail(detail);
        }

        public List<OrderDetail> GenerateSampleDataset()
        {
            return orderDetailDAO.GenerateSampleDataset();
        }

        public List<OrderDetail> GetOrderDetails()
        {
            return orderDetailDAO.GetOrderDetails();
        }

        public bool RemoveOrderDetail(int orderId, int productId)
        {
            return orderDetailDAO.RemoveOrderDetail(orderId, productId);
        }

        public OrderDetail SearchOrderDetail(int orderId, int productId)
        {
            return orderDetailDAO.SearchOrderDetail(orderId, productId);
        }

        public bool UpdateOrderDetail(OrderDetail detail)
        {
            return orderDetailDAO.UpdateOrderDetail(detail);
        }
    }
}
