using System;
using System.Configuration;
using System.Data.SqlClient;

namespace RxWebApp.Data.Entities
{
    internal abstract class Entity
    {
        protected Entity()
        {
            Created = DateTime.Now;
        }

        public int Id { get; set; }

        public string Sub { get; set; }
        public string Loc { get; set; }
        public string Emp { get; set; }
        public string Out { get; set; }
        public DateTime Created { get; set; }

        public string Modifier { get; set; }

        public bool Deleted { get; set; }

        public int? EventModifierId { get; set; }

        public string EventModifierType { get; set; }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            string constr = ConfigurationManager.ConnectionStrings["DiscussionEntityModel"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(constr))
            {
                string query =
                    "INSERT INTO Discussion(Subject, Location, Employee, Outcome, DiscussionDate) VALUES (@Subject, @Location, @Employee, @Outcome, @DiscussionDate)";
                query += " SELECT SCOPE_IDENTITY()";
                using (var cmd = new SqlCommand(query))
                {
                    cmd.Connection = cn;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@Subject", Sub);
                    cmd.Parameters.AddWithValue("@Location", Loc);
                    cmd.Parameters.AddWithValue("@Employee", Emp);
                    cmd.Parameters.AddWithValue("@Outcome", Out);
                    cmd.Parameters.AddWithValue("@DiscussionDate", Created.ToShortDateString());
                    Id = Convert.ToInt32(cmd.ExecuteScalar());
                    cn.Close();

                }
            }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public bool HasTransaction()
        {
            throw new NotImplementedException();
        }
    }
}