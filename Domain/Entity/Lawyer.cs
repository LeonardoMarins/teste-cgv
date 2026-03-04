using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Lawyer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do advogado é obrigatório")]
        [StringLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres")]
        [Display(Name = "Nome do Advogado")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A senioridade é obrigatória")]
        [Display(Name = "Senioridade")]
        public Seniority Seniority { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        public Address Address { get; set; }
    }
}
