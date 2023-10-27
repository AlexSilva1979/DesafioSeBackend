using AvaliacaoSesab.Enums;
using System.ComponentModel.DataAnnotations;


namespace AvaliacaoSesab.Models
{
    public class SearchModel
    {
        public string? Name { get; set; }
        public string? Document { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
       
    }
}
