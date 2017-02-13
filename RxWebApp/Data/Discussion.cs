using System;
using System.Collections.Generic;
using RxWebApp.Data.Entities;

namespace RxWebApp.Data
{
    public sealed class Discussion
    {
        private readonly OrderEntity _backingField;
        private readonly List<DiscussionRow> _rows;

        internal Discussion(OrderEntity entity)
        {
            _backingField = entity;
            _rows = new List<DiscussionRow>();
        }

        public int Id => _backingField.Id;
        public int DiscussionId => _backingField.Id;
        public string Subject => _backingField.Sub;
        public string Location => _backingField.Loc;
        public string Employee => _backingField.Emp;
        public string Outcome => _backingField.Out;
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