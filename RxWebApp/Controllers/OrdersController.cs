using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RxWebApp.Data;
using RxWebApp.Extensions;
using RxWebApp.Services;
using RxWebApp.ViewModels;

namespace RxWebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly List<Discussion> _allOrders;
        private readonly int _discussionId;
        private readonly string subject;
        private readonly string _location;
        private readonly string _employee;
        private readonly string _outcome;
        private readonly DateTime _discussionDate = DateTime.Now;

        public OrdersController()
        {
            _orderService = IoC.Instance.Resolve<IOrderService>();
            IoC.Instance.Resolve<IOfferService>();
            _allOrders = new List<Discussion>();
        }

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            return await _orderService
                .GetAllOrders()
                .Do(orders =>
                {
                    _allOrders.Clear();
                    foreach (Discussion order in orders)
                    {
                        _allOrders.Add(order);
                    }
                })
                .Select(orders => new DiscussionsViewModel(_discussionId, subject, _location, _employee, _outcome, _discussionDate, orders))
                .ToActionResult(View);
        }


        [HttpPost]
        public async Task<ActionResult> Create(string Subject, string Location, string Employee, string Outcome, DateTime DiscussionDate)
        {
            if (ModelState.IsValid)
            {
                return await _orderService
                    .CreateDiscussion(_discussionId, Subject, Location, Employee, Outcome, DiscussionDate)
                    .Do(order => _allOrders.Add(order))
                    .Select(_ => new DiscussionsViewModel(_discussionId, Subject, Location, Employee, Outcome, DiscussionDate, _allOrders))
                    .ToActionResult(viewModel => RedirectToAction("Index"));
            }
            return RedirectToAction("Index");
        }

    }
}