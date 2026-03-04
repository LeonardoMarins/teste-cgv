using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implements
{
    public class LawyerContext
    {
        private static LawyerContext _instance;
        private static readonly object _lock = new object();

        private readonly List<Lawyer> _lawyer;
        private int _nextId;

        private LawyerContext()
        {
            _lawyer = new List<Lawyer>();
            _nextId = 1;
        }

        public static LawyerContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new LawyerContext();
                    }
                }
                return _instance;
            }
        }

        public IQueryable<Lawyer> Lawyers => _lawyer.AsQueryable();

        public int GenerateId()
        {
            return _nextId++;
        }

        public void Add(Lawyer advogado)
        {
            _lawyer.Add(advogado);
        }

        public void Remove(Lawyer advogado)
        {
            _lawyer.Remove(advogado);
        }

        public Lawyer Find(int id)
        {
            return _lawyer.FirstOrDefault(a => a.Id == id);
        }

        public void Clear()
        {
            _lawyer.Clear();
            _nextId = 1;
        }
    }
}