using System;
using System.Collections.Generic;
using System.Linq;

namespace CajaAFP.Caja
{
    public class CajaService : ICajaService
    {
        private readonly List<Transaccion> _transacciones;

        public CajaService()
        {
            _transacciones = new List<Transaccion>();
        }

        public void RegistrarAporte(decimal monto, string idCliente)
        {
            var transaccion = new Transaccion
            {
                IdCliente = idCliente,
                Monto = monto,
                Tipo = "Aporte",
                Detalle = "Aporte registrado",
                Fecha = DateTime.Now
            };

            _transacciones.Add(transaccion);
        }

        public void ProcesarRetiro(decimal monto, string idCliente)
        {
            if (ConsultarSaldo(idCliente) < monto)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar el retiro.");
            }

            var transaccion = new Transaccion
            {
                IdCliente = idCliente,
                Monto = monto,
                Tipo = "Retiro",
                Detalle = "Retiro procesado",
                Fecha = DateTime.Now
            };

            _transacciones.Add(transaccion);
        }

        public void AplicarComision(string idCliente, decimal porcentaje)
        {
            var saldo = ConsultarSaldo(idCliente);
            var montoComision = saldo * porcentaje / 100;

            var transaccion = new Transaccion
            {
                IdCliente = idCliente,
                Monto = -montoComision,
                Tipo = "Comisión",
                Detalle = "Aplicación de comisión administrativa",
                Fecha = DateTime.Now
            };

            _transacciones.Add(transaccion);
        }

        public decimal CalcularInteres(string idCliente, decimal tasaAnual)
        {
            var saldo = ConsultarSaldo(idCliente);
            return saldo * (tasaAnual / 100);
        }


        public decimal ConsultarSaldo(string idCliente)
        {
            return _transacciones
                .Where(t => t.IdCliente == idCliente)
                .Sum(t => t.Tipo == "Aporte" ? t.Monto : -t.Monto);
        }

        public List<Transaccion> ObtenerTransacciones(string idCliente)
        {
            return _transacciones
                .Where(t => t.IdCliente == idCliente)
                .ToList();
        }
    }
}