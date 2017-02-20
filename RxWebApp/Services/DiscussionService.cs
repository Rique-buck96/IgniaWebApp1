using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using RxWebApp.Data;
using RxWebApp.Extensions;

namespace RxWebApp.Services
{
    internal sealed class DiscussionService : IDiscussionService
    {
        private readonly Dictionary<int, Discussion> _allDiscussions;
        private readonly IDiscussionRepository _discussionRepository;

        public DiscussionService(IDiscussionRepository discussionRepository)
        {
            _allDiscussions = new Dictionary<int, Discussion>();
            _discussionRepository = discussionRepository;

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
            return Observable.Return(_allDiscussions.Values);
        }

        public IObservable<IEnumerable<Discussion>> GetAllOrders(IScheduler scheduler)
        {
            return Observable.Return(_allDiscussions.Values, scheduler);
        }

        #region CRUD

        public IObservable<Discussion> CreateDiscussion(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate)
        {
            return _discussionRepository
                .CreateDiscussion(discussionId, subject, location, employee, outcome, discussionDate)
                .Select(dbOrder => dbOrder.ToObject())
                .Do(order => _allDiscussions.Add(order.DiscussionId, order));

        }

        public IObservable<Discussion> CreateDiscussion(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate, IScheduler scheduler)
        {
            return _discussionRepository
                .CreateDiscussion(discussionId, subject, location, employee, outcome, discussionDate, scheduler)
                .Select(dbOrder => dbOrder.ToObject())
                .Do(order => _allDiscussions.Add(order.DiscussionId, order));
        }

        public IObservable<Unit> DeleteOrder(int orderId)
        {
            return _discussionRepository
                .DeleteOrder(orderId)
                .Do(_ =>
                {
                    _allDiscussions.Remove(orderId);
                });
        }

        public IObservable<Unit> DeleteOrder(int orderId, IScheduler scheduler)
        {
            return _discussionRepository
                .DeleteOrder(orderId, scheduler)
                .Do(_ =>
                {
                    _allDiscussions.Remove(orderId);
                });
        }

        #endregion
    }
}