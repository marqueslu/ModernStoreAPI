using ModernStoreAPI.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ModernStoreAPI.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);        
    }
}
