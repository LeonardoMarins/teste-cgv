using Domain.Entity;
using System.Linq;

namespace Repository.Interface.ILawerRepository
{
    public interface ILawyerRepository
    {
        IQueryable<Lawyer> GetAll();

        void Add(Lawyer advogado);

        Lawyer Find(int id);

        void Update(Lawyer advogado);

        void Remove(Lawyer advogado);

        void SaveChanges();

        void Clear();
    }
}
