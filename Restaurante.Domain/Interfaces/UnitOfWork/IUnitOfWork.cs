using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void RollBack();
    }
}
