namespace RxWebApp.Data
{
    public sealed class DiscussionRow
    {
        internal DiscussionRow(Discussion parentOrder, int productId)
        {
            ParentOrder = parentOrder;
            ProductId = productId;
        }

        public int ProductId { get; private set; }

        internal Discussion ParentOrder { get; private set; }

        public int Quantity { get; set; }
    }
}