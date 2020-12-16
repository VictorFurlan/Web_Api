using System.Collections.Generic;

namespace $safeprojectname$.Models
{
    public interface IStatusRepositorio
    {
        void Add(Status s);
        IEnumerable<Status> GetAll();
        Mpedido Find(string s);
        void Remove(string s);
        void Update(Status s);
    }
}
