using System.Collections.Generic; // Necesario para usar List<>
using Prototipo1.Models; // Necesario para usar las clases de modelo

namespace Prototipo1.ViewModels
{
    public class ListarReservasViewModel
    {
        public List<ReservasViewModel> Reservas { get; set; } = new List<ReservasViewModel>();
        public List<Empleado> Empleados { get; set; } = new List<Empleado>();
        public List<Consumo> Consumos { get; set; } = new List<Consumo>();
    }
}
