using System.ComponentModel.DataAnnotations;

namespace AvaliacaoSesab.Models
{
    public class LoginModel
    {
        public string? Email { get; set; }
        public string? PassWord { get; set; }
    }
}
