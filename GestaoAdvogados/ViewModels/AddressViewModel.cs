using Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoAdvogados.ViewModels
{
    [Serializable]
    public class AddressViewModel
    {
        [Required(ErrorMessage = "O logradouro é obrigatório")]
        [StringLength(300, ErrorMessage = "O logradouro deve ter no máximo 300 caracteres")]
        [Display(Name = "Logradouro")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        [StringLength(100, ErrorMessage = "O bairro deve ter no máximo 100 caracteres")]
        [Display(Name = "Bairro")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        [Display(Name = "Estado")]
        public State State { get; set; } = State.RJ;

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP deve estar no formato 00000-000")]
        [Display(Name = "CEP")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        [RegularExpression(@"^\d+$", ErrorMessage = "O número deve conter apenas dígitos")]
        [Display(Name = "Número")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O complemento é obrigatório")]
        [StringLength(100, ErrorMessage = "O complemento deve ter no máximo 100 caracteres")]
        [Display(Name = "Complemento")]
        public string Complement { get; set; }
    }
}
