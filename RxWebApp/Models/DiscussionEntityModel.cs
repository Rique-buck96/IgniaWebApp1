namespace RxWebApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DiscussionEntityModel : DbContext
    {
        public DiscussionEntityModel()
            : base("name=DiscussionEntityModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
