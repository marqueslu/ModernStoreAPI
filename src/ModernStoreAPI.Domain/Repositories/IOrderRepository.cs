using ModernStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
