using System.Collections.Generic;

namespace CajaAFP.Caja
{
    public interface ICajaService
    {
        void RegistrarAporte(decimal monto, string idCliente);
        void ProcesarRetiro(decimal monto, string idCliente);
        decimal ConsultarSaldo(string idCliente);
        List<Transaccion> ObtenerTransacciones(string idCliente);
    }
}
