using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Web.Razor.Text;
using RxWebApp.Data.Entities;

namespace RxWebApp.Data
{
    internal interface IDiscussionRepository : IEntityRepository<OrderEntity>
    {
        IObservable<OrderEntity> CreateDiscussion(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate);

        IObservable<OrderEntity> CreateDiscussion(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate, IScheduler scheduler);

        IObservable<Unit> DeleteOrder(int orderId);

        IObservable<Unit> DeleteOrder(int orderId, IScheduler scheduler);
    }
}