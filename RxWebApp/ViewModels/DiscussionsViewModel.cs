using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using RxWebApp.Data;

namespace RxWebApp.ViewModels
{
    public class DiscussionsViewModel
    {
        public DiscussionsViewModel(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate, IEnumerable<Discussion> AllDiscussions)
            : this(discussionId, subject, location, employee, outcome, discussionDate, AllDiscussions, null)
        {
        }

        public DiscussionsViewModel(int discussionId, string subject,string location, string employee, string outcome, DateTime discussionDate, IEnumerable<Offer> offers)
            : this(discussionId, subject, location, employee, outcome, discussionDate, null, offers)
        {
        }

        private DiscussionsViewModel(int discussionId, string subject, string location, string employee, string outcome, DateTime discussionDate, IEnumerable<Discussion> AllDiscussions, IEnumerable<Offer> offers)
        {
            DiscussionId = discussionId;
            Subject = subject;
            Location = location;
            Employee = employee;
            Outcome = outcome;
            DiscussionDate = discussionDate;

            AllOffers = new List<Offer>();
            this.AllDiscussions = new List<Discussion>();

            if (AllDiscussions != null)
            {
                foreach (var d in AllDiscussions)
                {
                    this.AllDiscussions.Add(d);
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
        public IList<Discussion> AllDiscussions { get; private set; }

        public IList<Offer> AllOffers { get; private set; }

        
    }
}