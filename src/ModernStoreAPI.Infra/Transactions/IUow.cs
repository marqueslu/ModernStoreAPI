using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Infra.Transactions
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
