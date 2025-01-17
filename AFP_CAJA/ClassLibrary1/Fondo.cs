using System;

namespace CajaAFP.Caja
{
    public class Fondo
    {
        public required string Nombre { get; set; }
        public decimal Rentabilidad { get; set; } 
        public decimal Comision { get; set; } 
        public decimal Total { get; set; } 
    }
}
