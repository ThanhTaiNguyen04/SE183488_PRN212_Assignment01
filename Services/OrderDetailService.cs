using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Repositories;

namespace Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private static OrderDetailService _instance;
        private static readonly object _lock = new object();
        private readonly IOrderDetailRepository iorderDetailRepository;
        private OrderDetailService()
        {
            iorderDetailRepository = new OrderDetailRepository();
        }
        public static OrderDetailService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new OrderDetailService();
                        }
                    }
                }
                return _instance;
            }
        }
        public bool AddOrderDetail(OrderDetail detail)
        {
            return iorderDetailRepository.AddOrderDetail(detail);
        }
        public List<OrderDetail> GenerateSampleDataset()
        {
            return iorderDetailRepository.GenerateSampleDataset();
        }
        public List<OrderDetail> GetOrderDetails()
        {
            return iorderDetailRepository.GetOrderDetails();
        }
        public bool RemoveOrderDetail(int orderId, int productId)
        {
            return iorderDetailRepository.RemoveOrderDetail(orderId, productId);
        }
        public OrderDetail SearchOrderDetail(int orderId, int productId)
        {
            return iorderDetailRepository.SearchOrderDetail(orderId, productId);
        }
        public bool UpdateOrderDetail(OrderDetail detail)
        {
            return iorderDetailRepository.UpdateOrderDetail(detail);
        }
    }
}
