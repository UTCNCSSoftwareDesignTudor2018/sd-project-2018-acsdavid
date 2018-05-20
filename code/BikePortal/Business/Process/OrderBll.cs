using System.Collections.Generic;
using BikePortal.Business.Entity;
using BikePortal.DataAccess.Repository;

namespace BikePortal.Business.Process
{
    public class OrderBll : IOrderBll
    {
        private readonly IOrderRepository _orderRepository;

        public OrderBll(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IList<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order Get(int id)
        {
            return _orderRepository.Get(id);
        }

        public void Add(Order order)
        {
            _orderRepository.Insert(order);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }

        public void Delete(Order order)
        {
            _orderRepository.Delete(order);
        }
    }
}