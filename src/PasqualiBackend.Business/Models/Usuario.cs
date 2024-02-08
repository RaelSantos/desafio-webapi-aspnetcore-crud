namespace PasqualiBackend.Business.Models
{
    public class Usuario : Entity
    {      
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Renda { get; set; }        
    }
}
