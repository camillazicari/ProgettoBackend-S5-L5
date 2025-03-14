namespace ProgettoBackend_S5_L5.Models
{
    public class Oltre10PtModel
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateOnly DataViolazione { get; set; }
        public int Punti {  get; set; }
        public decimal Importo { get; set; }
    }
}
