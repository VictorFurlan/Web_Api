using System.Collections.Generic;
using System.Linq;

namespace $safeprojectname$.Models
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly DBContext _context;
        public PedidoRepositorio(DBContext context)
        {
            _context = context;
            Add(new Mpedido { pedido = "1223" });
        }

        public IEnumerable<Mpedido> GetAll()
        {
            return _context.LPedidos.ToList();
        }

        public void Add(Mpedido p)
        {
            _context.LPedidos.Add(p);
            _context.SaveChanges();
        }

        public Mpedido Find(string key)
        {
            return _context.LPedidos.FirstOrDefault(t => t.pedido.Equals(key));
        }

        public void Remove(string key)
        {
            var entity = _context.LPedidos.First(t => t.pedido.Equals(key));
            _context.LPedidos.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Mpedido p)
        {
            _context.LPedidos.Update(p);
            _context.SaveChanges();
        }
    }
}
