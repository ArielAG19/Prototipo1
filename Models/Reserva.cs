namespace Prototipo1.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int ConsumoId { get; set; }
        public DateTime Fecha { get; set; }
    }

}
