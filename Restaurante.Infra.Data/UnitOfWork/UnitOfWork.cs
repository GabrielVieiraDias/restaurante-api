using System;
using System.Collections.Generic;
using System.Text;
using Restaurante.Domain.Interfaces.UnitOfWork;
using Restaurante.Infra.Data.Context;

namespace Restaurante.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextDb _context;

        public UnitOfWork(ContextDb context)
        {
            _context = context;
        }

        public void Begin()
        {
            _context.Begin();
        }

        public void Commit()
        {
            _context.Commit();
        }

        public void RollBack()
        {
            _context.RollBack();
        }
    }
}
