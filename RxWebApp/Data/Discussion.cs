using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using RxWebApp.Data.Entities;

namespace RxWebApp.Data
{
    [Table("Discussion")]
    public sealed class Discussion
    {
        private readonly DiscussionEntity _backingField;
        private readonly List<DiscussionRow> _rows;

        internal Discussion(DiscussionEntity entity)
        {
            _backingField = entity;
            _rows = new List<DiscussionRow>();
        }

        [Key]
        [Column(Order=0)]
        public int DiscussionId => _backingField.Id;

        [Column(Order=1)]
        [StringLength(50)]
        public string Subject => _backingField.Sub;
        [Column(Order = 2)]
        [StringLength(50)]
        public string Location => _backingField.Loc;
        [Column(Order = 3)]
        [StringLength(50)]
        public string Employee => _backingField.Emp;
        [Column(Order = 4)]
        [StringLength(500)]
        public string Outcome => _backingField.Out;
        [Column(Order = 5)]
        public DateTime DiscussionDate => _backingField.Created;

        public decimal TotalSum => 42m;

        public IEnumerable<DiscussionRow> OrderRows => _rows;

        #region CRUD

        public DiscussionRow CreateRow(int productId, int quantity = 1)
        {
                var row = new DiscussionRow(this, productId);
                row.Quantity = quantity;
                _rows.Add(row);
                return row;
        }

        public void DeleteRow(DiscussionRow row)
        {
            if (row != null && row.ParentOrder == this)
            {
                _rows.Remove(row);
            }
        }

      
        #endregion
    }
}