using Domain.Entity;
using Repository.Interface;
using System.Linq;

namespace Repository.Implements
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
           return _context.Lawyers;
        }

        public void Add(Lawyer lawyer)
        {
            lawyer.Id = _context.GenerateId();
            _context.Add(lawyer);
        }

        public Lawyer Find(int id)
        {
            return _context.Lawyers.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Lawyer lawyer)
        {
            var advogadoExistente = Find(lawyer.Id);
            if (advogadoExistente != null)
            {
                advogadoExistente.Name = lawyer.Name;
                advogadoExistente.Seniority = lawyer.Seniority;
                advogadoExistente.Address = lawyer.Address;
            }
        }

        public void Remove(Lawyer lawyer)
        {
            _context.Remove(lawyer);
        }

        public void Clear()
        {
            _context.Clear();
        }

    }
}
