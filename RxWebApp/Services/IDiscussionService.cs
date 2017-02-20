using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;
using RxWebApp.Data;

namespace RxWebApp.Services
{
    internal interface IDiscussionService
    {
        IObservable<IEnumerable<Discussion>> GetAllOrders(IScheduler scheduler);
        IObservable<IEnumerable<Discussion>> GetAllOrders();

        IObservable<Discussion> CreateDiscussion(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate, IScheduler scheduler);
        IObservable<Discussion> CreateDiscussion(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDated);

        IObservable<Unit> DeleteOrder(int orderId, IScheduler scheduler);
        IObservable<Unit> DeleteOrder(int orderId);
    }
}