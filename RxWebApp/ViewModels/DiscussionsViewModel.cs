using System;
using System.Collections.Generic;
using RxWebApp.Data;

namespace RxWebApp.ViewModels
{
    public class DiscussionsViewModel
    {
        public DiscussionsViewModel(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate, IEnumerable<Discussion> orders)
            : this(discussionId, subject, location, employee, outcome, discussionDate, orders, null)
        {
        }

        public DiscussionsViewModel(int discussionId, string subject,string location, string employee, string outcome, DateTime discussionDate, IEnumerable<Offer> offers)
            : this(discussionId, subject, location, employee, outcome, discussionDate, null, offers)
        {
        }

        private DiscussionsViewModel(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate, IEnumerable<Discussion> orders, IEnumerable<Offer> offers)
        {
            DiscussionId = discussionId;
            Subject = subject;
            Location = location;
            Employee = employee;
            Outcome = outcome;
            DiscussionDate = discussionDate;

            AllOffers = new List<Offer>();
            AllOrders = new List<Discussion>();

            if (orders != null)
            {
                foreach (Discussion o in orders)
                {
                    AllOrders.Add(o);
                }
            }

            if (offers != null)
            {
                foreach (Offer o in offers)
                {
                    AllOffers.Add(o);
                }
            }
        }

        public int DiscussionId { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }

        public string Employee { get; set; }
        public string Outcome { get; set; }
        public DateTime DiscussionDate { get; set; }
        public IList<Discussion> AllOrders { get; private set; }

        public IList<Offer> AllOffers { get; private set; }
    }
}