namespace AvaliacaoSesab.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        
        public ICollection<PersonModel>? Person { get; set; }
    }
}
