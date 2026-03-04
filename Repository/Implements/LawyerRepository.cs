using Domain.Entity;
using Repository.Interface.ILawerRepository;
using System.Linq;

namespace Repository.Implements.LawyerRepository
{
    public class LawyerRepository : ILawyerRepository
    {
        private readonly LawyerContext _context;
        public LawyerRepository()
        {
            _context = LawyerContext.Instance;
        }

        public IQueryable<Lawyer> GetAll()
        {
           return _context.Advogados;
        }

        public void Add(Lawyer advogado)
        {
            advogado.Id = _context.GerarId();
            _context.Add(advogado);
        }

        public Lawyer Find(int id)
        {
            return _context.Advogados.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Lawyer advogado)
        {
            var advogadoExistente = Find(advogado.Id);
            if (advogadoExistente != null)
            {
                advogadoExistente.Name = advogado.Name;
                advogadoExistente.Seniority = advogado.Seniority;
                advogadoExistente.Address = advogado.Address;
            }
        }

        public void Remove(Lawyer advogado)
        {
            _context.Remove(advogado);
        }

        public void Clear()
        {
            _context.Clear();
        }

    }
}
