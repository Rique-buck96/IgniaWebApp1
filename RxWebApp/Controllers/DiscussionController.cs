using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    public class DiscussionController : Controller
    {
        private readonly IDiscussionService _discussionService;
        private readonly List<Discussion> _allDiscussions;
        private int _discussionId;
        private string _subject;
        private string _location;
        private string _employee;
        private string _outcome;
        private DateTime _discussionDate;

        public DiscussionController()
        {
            _discussionService = IoC.Instance.Resolve<IDiscussionService>();
            IoC.Instance.Resolve<IOfferService>();
            _allDiscussions = new List<Discussion>();
        }

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            //Read();
            return await _discussionService
                .GetAllOrders()
                .Do(discussions =>
                {
                    //_allDiscussions.Clear();
                    
                    foreach (var discussion in discussions)
                    {
                        _allDiscussions.Add(discussion);
                    }
                })
                .Select(orders => new DiscussionsViewModel(_discussionId, _subject, _location, _employee, _outcome, _discussionDate, orders))
                .ToActionResult(View);
        }


        [HttpPost]
        public async Task<ActionResult> Create(string Subject, string Location, string Employee, string Outcome, DateTime DiscussionDate)
        {
            if (ModelState.IsValid)
            {
                return await _discussionService
                    .CreateDiscussion(_discussionId, Subject, Location, Employee, Outcome, DiscussionDate)
                    .Do(order => _allDiscussions.Add(order))
                    .Select(_ => new DiscussionsViewModel(_discussionId, Subject, Location, Employee, Outcome, DiscussionDate, _allDiscussions))
                    .ToActionResult(viewModel => RedirectToAction("Index"));
            }
            return RedirectToAction("Index");
        }

        //public void Read()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["DiscussionEntityModel"].ConnectionString;
        //    using (SqlConnection cn = new SqlConnection(constr))
        //    {
        //        string query = "SELECT * FROM Discussion";
        //        using (var cmd = new SqlCommand(query))
        //        {
        //            cmd.Connection = cn;
        //            cn.Open();
        //            var rd = cmd.ExecuteReader();

        //            while (rd.Read())
        //            {
        //                _discussionId = rd.GetInt32(0);
        //                _subject = rd.GetString(1);
        //                _location = rd.GetString(2);
        //                _employee = rd.GetString(3);
        //                _outcome = rd.GetString(4);
        //                _discussionDate = rd.GetDateTime(5);

        //                //_allDiscussions.Add(_discussionId, ds);
        //            }
        //        }
        //    }
        //}
    }
}