using System.Collections.Generic;
using System.Linq;

namespace $safeprojectname$.Models
{
    public class StatusRepositorio : IStatusRepositorio
    {
        private readonly DBContext _context;
        public StatusRepositorio(DBContext context)
        {
            _context = context;
            Add(new Status { pedido = "1223" });
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.LStatus.ToList();
        }

        public void Add(Status s)
        {
            _context.LStatus.Add(s);
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

        public void Update(Status s)
        {
            _context.LStatus.Update(s);
            _context.SaveChanges();
        }
    }
}
