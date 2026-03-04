using Domain;
using Domain.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoAdvogados.ViewModels
{
    [Serializable]
    public class LawyerViewModel
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
        public AddressViewModel Address { get; set; }
    }
}
