using AvaliacaoSesab.Enums;
using AvaliacaoSesab.Helper;
using System.ComponentModel.DataAnnotations;

namespace AvaliacaoSesab.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória.")]
        public string? Password { get; set; }
        public DateTime DateCreated { get; set; }

        public int ProfileId { get; set; }

        public ProfileModel? Profile { get; set; }

        public bool PassWordValid(string password)
        {

            return this.Password == Cryptography.CreateHash(password);

        }

        public void SetPasswordHash()
        {
            this.Password = Cryptography.CreateHash(this.Password);
        }
    }
}
