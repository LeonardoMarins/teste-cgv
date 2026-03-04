using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implements
{
    public class LawyerContext
    {
        private static LawyerContext _instance;
        private static readonly object _lock = new object();

        private readonly List<Lawyer> _advogados;
        private int _proximoId;

        private LawyerContext()
        {
            _advogados = new List<Lawyer>();
            _proximoId = 1;
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

        public IQueryable<Lawyer> Advogados => _advogados.AsQueryable();

        public int GerarId()
        {
            return _proximoId++;
        }

        public void Add(Lawyer advogado)
        {
            _advogados.Add(advogado);
        }

        public void Remove(Lawyer advogado)
        {
            _advogados.Remove(advogado);
        }

        public Lawyer Find(int id)
        {
            return _advogados.FirstOrDefault(a => a.Id == id);
        }

        public void Clear()
        {
            _advogados.Clear();
            _proximoId = 1;
        }
    }
}