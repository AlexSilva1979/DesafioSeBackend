using AvaliacaoSesab.Enums;
using System.ComponentModel.DataAnnotations;


namespace AvaliacaoSesab.Models
{
    public class PersonModel
    {
        #region propiedades
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O Nome é obrigatório."),
        StringLength(100, MinimumLength = 10,
                          ErrorMessage = "Intervalo permitido de 10 a 100 caracteres.")]

        public string? Name { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório."),
            StringLength(11, MinimumLength = 11,
                          ErrorMessage = "O CPF precisa ter 11 digitos.")]
        public string? Document { get; set; }


        [Required(ErrorMessage = "E-mail é obrigatório.")]
        public string? Email{ get; set; }

        public ICollection<AddressModel>? Address { get; set; }

        public ProfileEnum Profile { get; set; }

        public DateTime CreatedDate { get; set; }
        #endregion

       
    }
}
