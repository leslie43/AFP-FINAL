using System.Collections.Generic;

namespace CajaAFP.Caja
{
    public interface ICajaService
    {
        void RegistrarAporte(decimal monto, string idCliente, string detalle);
        void ProcesarRetiro(decimal monto, string idCliente,  string detalle);
        decimal ConsultarSaldo(string idCliente);
        List<Transaccion> ObtenerTransacciones(string idCliente);
        decimal CalcularInteres(string idCliente, decimal tasaAnual);
        string GenerarEstadoCuenta(string idCliente);
        void AplicarComision(string idCliente, decimal porcentaje);
    }

}
