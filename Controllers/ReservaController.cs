using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Prototipo1.Models;
using Prototipo1.ViewModels;  // Asegúrate de incluir el espacio de nombres del ViewModel

namespace Prototipo1.Controllers
{
    public class ReservaController : Controller
    {
        // Datos Mock
        private static List<Empleado> empleados = new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Juan", CreditosDisponibles = 2 },
            new Empleado { Id = 2, Nombre = "Ana", CreditosDisponibles = 3 }
        };

        private static List<Consumo> consumos = new List<Consumo>
        {
            new Consumo { Id = 1, Tipo = "Desayuno", CostoCredito = 1 },
            new Consumo { Id = 2, Tipo = "Almuerzo", CostoCredito = 2 },
            new Consumo { Id = 3, Tipo = "Merienda", CostoCredito = 1 }
        };

        private static List<Reserva> reservas = new List<Reserva>();

        // Método para hacer una reserva
        public IActionResult CrearReserva(int empleadoId, int consumoId)
        {
            var empleado = empleados.FirstOrDefault(e => e.Id == empleadoId);
            var consumo = consumos.FirstOrDefault(c => c.Id == consumoId);

            if (empleado != null && consumo != null && empleado.CreditosDisponibles >= consumo.CostoCredito)
            {
                empleado.CreditosDisponibles -= consumo.CostoCredito;

                var nuevaReserva = new Reserva
                {
                    Id = reservas.Count + 1,
                    EmpleadoId = empleadoId,
                    ConsumoId = consumoId,
                    Fecha = DateTime.Now
                };

                reservas.Add(nuevaReserva);
                return View("ReservaExitosa", nuevaReserva);  // Vista de éxito
            }

            return View("Error");  // Vista de error si no hay suficientes créditos
        }

        // Método para listar reservas
        public IActionResult ListarReservas()
        {
            // Agregar una reserva de prueba si no hay reservas
            if (!reservas.Any())
            {
                reservas.Add(new Reserva
                {
                    Id = 1,
                    EmpleadoId = 1, // Cambia según sea necesario
                    ConsumoId = 1,  // Cambia según sea necesario
                    Fecha = DateTime.Now
                });
            }

            // Crear una instancia de ListarReservasViewModel
            var listarReservasViewModel = new ListarReservasViewModel
            {
                Reservas = reservas.Select(r => new ReservasViewModel
                {
                    EmpleadoId = r.EmpleadoId,
                    NombreEmpleado = empleados.FirstOrDefault(e => e.Id == r.EmpleadoId)?.Nombre,
                    ConsumoId = r.ConsumoId,
                    TipoConsumo = consumos.FirstOrDefault(c => c.Id == r.ConsumoId)?.Tipo,
                    Fecha = r.Fecha
                }).ToList(),
                Empleados = empleados,
                Consumos = consumos
            };

            return View(listarReservasViewModel);  // Retornar el ViewModel a la vistaodel a la vista
        }
    }
}
