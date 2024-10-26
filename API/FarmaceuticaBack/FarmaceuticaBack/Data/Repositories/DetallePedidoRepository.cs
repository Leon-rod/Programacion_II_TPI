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
    public class DetallePedidoRepository : IDetallePedidoRepository
    {
        private readonly FarmaceuticaContext _context;
        public DetallePedidoRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int idPedido, int idDetalleP)
        {
            var dp = await _context.DetallesPedidos.FirstOrDefaultAsync(d => d.IdPedido == idPedido && d.IdDetallePedido == idDetalleP);
            if (dp != null)
            {
                _context.DetallesPedidos.Remove(dp);
            }
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<DetallesPedido> GetByDetallePedido(int idPedido, int idDetalleP)
        {
            return await _context.DetallesPedidos.FirstOrDefaultAsync(d => d.IdPedido == idPedido && d.IdDetallePedido == idDetalleP);            
        }

        public async Task<List<DetallesPedido>> GetByPedido(int id)
        {
            var dp = await _context.DetallesPedidos.Where(d => d.IdPedido == id).ToListAsync();
            return dp;
        }

        public async Task<bool> Save(DetallesPedido dp)
        {
            int id = await _context.DetallesPedidos.MaxAsync(p => p.IdDetallePedido) + 1;
            dp.IdDetallePedido = id;
            
            await _context.AddAsync(dp);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
