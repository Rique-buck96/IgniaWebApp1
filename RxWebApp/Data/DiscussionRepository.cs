using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using RxWebApp.Data.Entities;

namespace RxWebApp.Data
{
    internal sealed class DiscussionRepository : RepositoryBase, IDiscussionRepository
    {
        private static int _discussionIdCounter;

        public DiscussionRepository(IDataContextFactory dbFactory)
            : base(dbFactory)
        {
            _discussionIdCounter = 0;
        }

        public IObservable<OrderEntity> CreateDiscussion(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate)
        {
            //CreateOrder(customerId, null);
            return CreateDiscussion(discussionId, subject, location, employee, outcome, discussionDate, null);
        }

        public IObservable<OrderEntity> CreateDiscussion(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate, IScheduler scheduler)
        {
            var order = new OrderEntity { /*DiscussionId = discussionId,*/ Id = _discussionIdCounter++, Sub = subject, Loc = location, Emp = employee, Out = outcome};
            if (scheduler != null)
            {
                return Observable.Return(order, scheduler);
            }
            return Observable.Return(order);
        }

        public IObservable<Unit> DeleteOrder(int orderId)
        {
            return DeleteOrder(orderId, null);
        }

        public IObservable<Unit> DeleteOrder(int orderId, IScheduler scheduler)
        {
            if (scheduler != null)
            {
                return Observable.Return(new Unit(), scheduler);
            }
            return Observable.Return(new Unit());
        }
    }
}