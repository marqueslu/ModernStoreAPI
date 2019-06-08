using ModernStoreAPI.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStoreAPI.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly ModernStoreAPIDataContext _context;

        public Uow(ModernStoreAPIDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Do nothing :)
        }
    }
}
