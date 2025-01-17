using System;
namespace CajaAFP.Caja
{ 
public class Transaccion
{
    public required string IdCliente { get; set; }
    public decimal Monto { get; set; }
    public required string Tipo { get; set; }
    public required string Detalle { get; set; } 
    public DateTime Fecha { get; set; }
}
}