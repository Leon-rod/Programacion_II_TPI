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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly FarmaceuticaContext _context;

        public PedidoRepository(FarmaceuticaContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> GetAll()
        {
            var pedidos = await _context.Pedidos
                .Include(c => c.IdPersonalCargosEstablecimientosNavigation)
                .Include(c => c.IdPersonalCargosEstablecimientosNavigation.IdPersonalNavigation)
                .Include(c => c.IdLogisticaNavigation)                
                .ToListAsync();
            return pedidos;
        }

        public async Task<List<Pedido>> GetByEstablecimiento(int id)
        {
            var pedidos = await _context.Pedidos                
                .Include(c => c.IdPersonalCargosEstablecimientosNavigation)
                .Where(e => e.IdPersonalCargosEstablecimientosNavigation.IdEstablecimiento == id)
                .ToListAsync();
            return pedidos;
        }

        public async Task<List<Pedido>> GetByFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            DateOnly fromDateOnly = DateOnly.FromDateTime(fechaDesde);
            DateOnly toDateOnly = DateOnly.FromDateTime(fechaHasta);

            var pedidos = await _context.Pedidos
                .Where(p => p.Fecha > fromDateOnly && p.Fecha < toDateOnly)
                .ToListAsync();

            return pedidos;
        }

        public async Task<Pedido> GetById(int id)
        {
            var p = await _context.Pedidos
                .Include(p => p.DetallesPedidos)
                .Include(p => p.DetallesPedidos)
                .Include(p => p.DetallesPedidos)
                .ThenInclude(p => p.IdMedicamentoLoteNavigation)
                .ThenInclude(p => p.IdMedicamentoNavigation)
                .Include(p => p.DetallesPedidos)
                .ThenInclude(p => p.IdProductoNavigation)                
                .FirstOrDefaultAsync(p => p.IdPedido == id);
            
            return p;
        }

        public async Task<List<Pedido>> GetByLogistica(string cuit)
        {
            var pedidos = await _context.Pedidos
                .Include(c => c.IdLogisticaNavigation)
                .Where(e => e.IdLogisticaNavigation.Cuit == cuit)
                .ToListAsync();
            return pedidos;
        }
    }
}
