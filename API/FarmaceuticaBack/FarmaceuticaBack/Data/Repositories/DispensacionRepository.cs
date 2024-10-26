using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Repositories
{
    public class DispensacionRepository : IDispensacionRepository
    {
        private readonly FarmaceuticaContext _context;
        public DispensacionRepository(FarmaceuticaContext context)
        {
            this._context = context;
        }
        public async Task<bool> Delete(int idFactura, int idDispensacion)
        {
            Dispensacion? dispensacion = await _context.Dispensaciones
                .Include(d => d.IdFacturaNavigation)
                .FirstOrDefaultAsync(d => d.IdFactura == idFactura && d.IdDispensacion == idDispensacion 
                && d.IdFacturaNavigation.Fecha == DateOnly.FromDateTime(DateTime.Today.Date));
            if (dispensacion == null)
                return false;
            _context.Database.ExecuteSqlRaw("DELETE FROM DISPENSACIONES WHERE ID_DISPENSACION = {0} AND ID_FACTURA = {1}"
                ,idDispensacion,idFactura);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Dispensacion>> GetByIdFactura(int id)
        {
            List<Dispensacion> dispensacionList = await _context.Dispensaciones
                .Where(d => d.IdFactura == id)
                .ToListAsync();
            return dispensacionList;
        }

        public async Task<bool> Insert(Dispensacion dispensacion)
        {
            await _context.Database.ExecuteSqlRawAsync("INSERT INTO DISPENSACIONES(ID_FACTURA,ID_DISPENSACION,ID_MEDICAMENTO_LOTE,ID_COBERTURA,ID_PRODUCTO,DESCUENTO,PRECIO_UNITARIO,CANTIDAD,MATRICULA,CODIGO_VALIDACION) " +
                "VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})",dispensacion.IdFactura,dispensacion.IdDispensacion,dispensacion.IdMedicamentoLote,
                dispensacion.IdCobertura,dispensacion.IdProducto,dispensacion.Descuento,dispensacion.PrecioUnitario,dispensacion.Cantidad,dispensacion.Matricula,dispensacion.CodigoValidacion);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
