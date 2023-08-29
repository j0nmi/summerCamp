using Context;
using Entidades.Entities;
using EntidadesDTO.Historial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Repositorios
{
    public class RepositorioHistorial : IRepositorioHistorial
    {
        private readonly ContextoConversor _context;
        private readonly IRepositorioMonedas repositorioMonedas;

        public RepositorioHistorial(ContextoConversor context, IRepositorioMonedas repositorioMonedas)
        {
            _context = context;
            this.repositorioMonedas = repositorioMonedas;
        }

        public IEnumerable<HistorialProcedure> obtener10Primeras(Guid usuario)
        {
            IEnumerable<Historial> resultad = _context.historial.
                FromSqlInterpolated($"EXECUTE dbo.Top10Historial {usuario}");

            var query =
                       from h in _context.historial
                       join m1 in _context.monedas on h.moneda1 equals m1.id
                       join m2 in _context.monedas on h.moneda2 equals m2.id
                       join u in _context.usuarios on h.idUsuario equals u.id

                       select new HistorialProcedure
                       {
                           id = h.id,
                           email = u.email,
                           moneda1 = m1.codigo,
                           moneda2 = m2.codigo,
                           resultadoConversion = h.resultadoConversion,
                           fechaConversion = h.fechaConversion,
                           cantidad = h.cantidad
                       };

           return query;
        }

        public async Task<IEnumerable<Historial>> obtenerTodas(Guid usuario)
        {
            var resultad = _context.historial.Where(m => m.idUsuario == usuario);

            return resultad;
        }

        public async Task<Historial> crearRegistroHistorial(Conversor conversion, Guid usuario)
        {

            Moneda monedaOrigen = await repositorioMonedas.obtenerMoneda(conversion.monedaOrigen);
            Moneda monedaDestino = await repositorioMonedas.obtenerMoneda(conversion.monedaDestino);

            Historial listaHistorial = new Historial();

            listaHistorial.idUsuario = usuario;
            listaHistorial.monedaOrigen = monedaOrigen;
            listaHistorial.monedaDestino = monedaDestino;
            listaHistorial.cantidad = conversion.cantidad;
            listaHistorial.fechaConversion = DateTime.Now;

            // CALCULO

            //Moneda monedaOrigen = await repositorioMonedas.obtenerMoneda(conversion.monedaOrigen);
            //Moneda monedaDestino = await repositorioMonedas.obtenerMoneda(conversion.monedaDestino);

            var resultado = ((1 / monedaOrigen.factor) * monedaDestino.factor) * conversion.cantidad;

            if (resultado != null) listaHistorial.resultadoConversion = resultado;
            else listaHistorial.resultadoConversion = 0;

            _context.Add(listaHistorial);
            _context.SaveChanges();
            return listaHistorial;
        }
        public async Task<string> VaciarHistorial(Guid usuario)
        {
            var parametros = new SqlParameter("@usuarioId", usuario);
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC dbo.BorrarHistorial {parametros}");

            _context.SaveChanges();
            return "Borrado";
        }
    }
}
