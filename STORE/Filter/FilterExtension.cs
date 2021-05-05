using LinqKit;
using STORE.DTOs;
using STORE.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STORE.Filter
{
    public static class FilterExtension
    {
        public static ExpressionStarter<TEntity> FilterDateTimes<TEntity>(this ExpressionStarter<TEntity> expressionStarter, DateTime? top, DateTime? low) where TEntity : BaseEntity
        {
            if (top.HasValue && !low.HasValue)
            {
                expressionStarter.And(p => p.InsertedDate <= top.Value);
            }
            else if (!top.HasValue && low.HasValue)
            {
                expressionStarter.And(p => p.InsertedDate >= low.Value);
            }
            else if(top.HasValue && low.HasValue)
            {
                expressionStarter.And(p => p.InsertedDate >= low.Value && p.InsertedDate <= top.Value);
            }

            return expressionStarter;
        }
    }
}
