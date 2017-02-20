using RxWebApp.Data;
using RxWebApp.Data.Entities;

namespace RxWebApp.Extensions
{
    internal static class EntityExtensions
    {
        public static Discussion ToObject(this DiscussionEntity entity)
        {
            // TODO: use ValueInjecter to do the custom conversion and possible flattening here.

            return new Discussion(entity);
        }
    }
}