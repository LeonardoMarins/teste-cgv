using System.Linq;
using System.Web.Mvc;
using Domain.Entity;
using GestaoAdvogados.ViewModels;
using Repository.Implements.LawyerRepository;
using Repository.Interface.ILawerRepository;

namespace GestaoAdvogados.Controllers
{
    public class LawyerController : Controller
    {
        private readonly ILawyerRepository _repository;

        public LawyerController() : this(new LawyerRepository()) { }

        public LawyerController(ILawyerRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var viewModels = _repository.GetAll()
                .Select(ToViewModel)
                .ToList();
            return View(viewModels);
        }

        public ActionResult Details(int id)
        {
            var lawyer = _repository.Find(id);
            if (lawyer == null) return HttpNotFound();
            return View(ToViewModel(lawyer));
        }

        public ActionResult Create()
        {
            return View(new LawyerViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LawyerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(ToEntity(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var lawyer = _repository.Find(id);
            if (lawyer == null) return HttpNotFound();
            return View(ToViewModel(lawyer));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LawyerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(ToEntity(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            var lawyer = _repository.Find(id);
            if (lawyer == null) return HttpNotFound();
            return View(ToViewModel(lawyer));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lawyer = _repository.Find(id);
            if (lawyer != null)
            {
                _repository.Remove(lawyer);
            }
            return RedirectToAction("Index");
        }

        private static LawyerViewModel ToViewModel(Lawyer l) => new LawyerViewModel
        {
            Id = l.Id,
            Name = l.Name,
            Seniority = l.Seniority,
            Address = new AddressViewModel
            {
                Street = l.Address.Street,
                Neighborhood = l.Address.Neighborhood,
                State = l.Address.State,
                ZipCode = l.Address.ZipCode,
                Number = l.Address.Number,
                Complement = l.Address.Complement
            }
        };

        private static Lawyer ToEntity(LawyerViewModel vm) => new Lawyer
        {
            Id = vm.Id,
            Name = vm.Name,
            Seniority = vm.Seniority,
            Address = new Address
            {
                Street = vm.Address.Street,
                Neighborhood = vm.Address.Neighborhood,
                State = vm.Address.State,
                ZipCode = vm.Address.ZipCode,
                Number = vm.Address.Number,
                Complement = vm.Address.Complement
            }
        };
    }
}
