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
            Factura? factura = await _context.Facturas.FindAsync(idFactura);
            if (factura == null)
                return false;
            Dispensacion? dispensacion = await _context.Dispensaciones.FindAsync(idDispensacion);
            if (dispensacion == null)
                return false;
            _context.Dispensaciones.Remove(dispensacion);
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
            await _context.Dispensaciones.AddAsync(dispensacion);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
