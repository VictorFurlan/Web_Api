using System.Collections.Generic;

namespace $safeprojectname$.Models
{
    public interface IPedidoRepositorio
    {
        void Add(Mpedido p);
        IEnumerable<Mpedido> GetAll();
        Mpedido Find(string p);
        void Remove(string p);
        void Update(Mpedido p);
    }
}
