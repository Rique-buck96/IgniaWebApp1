using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using RxWebApp.Data;
using RxWebApp.Extensions;

namespace RxWebApp.Services
{
    internal sealed class OrderService : IOrderService
    {
        private readonly Dictionary<int, Discussion> _allOrders;
        private readonly IDiscussionRepository _orderRepository;

        public OrderService(IDiscussionRepository orderRepository)
        {
            _allOrders = new Dictionary<int, Discussion>();
            _orderRepository = orderRepository;

            // Populate with dummy orders
            //Observable.Range(0, 10)
            //    .SelectMany(i => _orderRepository.CreateDiscussion(i, "Test" + i, "Building" + i, "Jane", "Success", DateTime.Now))
            //    .Select(dbOrder => dbOrder.ToObject())
            //    .Subscribe(order =>
            //    {
            //        _allOrders.Add(order.Id, order);
            //    });
        }

        public IObservable<IEnumerable<Discussion>> GetAllOrders()
        {
            return Observable.Return(_allOrders.Values);
        }

        public IObservable<IEnumerable<Discussion>> GetAllOrders(IScheduler scheduler)
        {
            return Observable.Return(_allOrders.Values, scheduler);
        }

        #region CRUD

        public IObservable<Discussion> CreateDiscussion(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate)
        {
            return _orderRepository
                .CreateDiscussion(discussionId, subject, location, employee, outcome, discussionDate)
                .Select(dbOrder => dbOrder.ToObject())
                .Do(order => _allOrders.Add(order.DiscussionId, order));
        }

        public IObservable<Discussion> CreateDiscussion(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate, IScheduler scheduler)
        {
            return _orderRepository
                .CreateDiscussion(discussionId, subject, location, employee, outcome, discussionDate, scheduler)
                .Select(dbOrder => dbOrder.ToObject())
                .Do(order => _allOrders.Add(order.DiscussionId, order));
        }

        public IObservable<Unit> DeleteOrder(int orderId)
        {
            return _orderRepository
                .DeleteOrder(orderId)
                .Do(_ =>
                {
                    _allOrders.Remove(orderId);
                });
        }

        public IObservable<Unit> DeleteOrder(int orderId, IScheduler scheduler)
        {
            return _orderRepository
                .DeleteOrder(orderId, scheduler)
                .Do(_ =>
                {
                    _allOrders.Remove(orderId);
                });
        }

        #endregion
    }
}