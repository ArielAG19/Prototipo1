using System;

namespace Prototipo1.ViewModels
{
    public class ReservasViewModel
    {
        public int EmpleadoId { get; set; }
        public string? NombreEmpleado { get; set; }
        public int ConsumoId { get; set; }
        public string? TipoConsumo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
