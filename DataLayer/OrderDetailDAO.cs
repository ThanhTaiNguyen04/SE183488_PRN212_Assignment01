using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer;

namespace DataLayer
{
    public class OrderDetailDAO
    {
        static List<OrderDetail> orderDetails = new List<OrderDetail>();
        private bool isGenerated = false;
        public List<OrderDetail> GenerateSampleDataset()
        {
            if (isGenerated) {
                return orderDetails;
            }

            orderDetails.Add(new OrderDetail()
            {
                OrderID = 1,
                ProductID = 1,
                UnitPrice = 18.0,
                Quantity = 5,
                Discount = 0.1
            });

            orderDetails.Add(new OrderDetail()
            {
                OrderID = 1,
                ProductID = 2,
                UnitPrice = 19.0,
                Quantity = 3,
                Discount = 0.0
            });

            orderDetails.Add(new OrderDetail()
            {
                OrderID = 2,
                ProductID = 3,
                UnitPrice = 10.0,
                Quantity = 10,
                Discount = 0.05
            });

            orderDetails.Add(new OrderDetail()
            {
                OrderID = 3,
                ProductID = 4,
                UnitPrice = 22.0,
                Quantity = 2,
                Discount = 0.2
            });

            orderDetails.Add(new OrderDetail()
            {
                OrderID = 4,
                ProductID = 5,
                UnitPrice = 25.0,
                Quantity = 1,
                Discount = 0.0
            });
            isGenerated = true;
            return orderDetails;
        }
        public List<OrderDetail> GetOrderDetails()
        {
            return orderDetails;
        }

        // Them chi tiet don hang moi
        public bool AddOrderDetail(OrderDetail detail)
        {
            var exist = orderDetails.FirstOrDefault(d =>
                d.OrderID == detail.OrderID && d.ProductID == detail.ProductID);

            if (exist != null)
            {
                return false;
            }

            orderDetails.Add(detail);
            return true;
        }
        public bool RemoveOrderDetail(int orderId, int productId)
        {
            var detail = orderDetails.FirstOrDefault(d =>
                d.OrderID == orderId && d.ProductID == productId);

            if (detail == null)
            {
                return false;
            }

            orderDetails.Remove(detail);
            return true;
        }

        public OrderDetail SearchOrderDetail(int orderId, int productId)
        {
            return orderDetails.FirstOrDefault(d =>
                d.OrderID == orderId && d.ProductID == productId);
        }

        public bool UpdateOrderDetail(OrderDetail detail)
        {
            var existing = orderDetails.FirstOrDefault(d =>
                d.OrderID == detail.OrderID && d.ProductID == detail.ProductID);

            if (existing == null)
            {
                return false;
            }

            existing.UnitPrice = detail.UnitPrice;
            existing.Quantity = detail.Quantity;
            existing.Discount = detail.Discount;

            return true;
        }
    }
}
