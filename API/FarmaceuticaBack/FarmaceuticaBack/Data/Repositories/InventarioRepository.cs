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
    public class InventarioRepository : IInventarioRepository
    {
        private readonly FarmaceuticaContext _context;

        public InventarioRepository(FarmaceuticaContext context)
        {   
            _context = context;
        }
        public Task<bool> CreateInventario(Inventario inv)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Inventario>> GetAll()
        {
            return await _context.Inventarios.ToListAsync() ;
        }

        public async Task<List<Inventario>> GetInventarioByFactura(int idFactura, DateTime from, DateTime to)
        {
            if(from == null || from == DateTime.MinValue || to == null || to == DateTime.MinValue)
            {
                return await _context.Inventarios
                    .Where(i => i.IdFactura == idFactura)
                    .ToListAsync();
            }
            else
            {
                DateOnly fromDateOnly = DateOnly.FromDateTime(from);
                DateOnly toDateOnly = DateOnly.FromDateTime(to);

                return await _context.Inventarios
                                     .Where(i => i.IdFactura == idFactura
                                                 ||( i.Fecha >= fromDateOnly
                                                 && i.Fecha <= toDateOnly))
                                     .ToListAsync();
            }
                                
        }

        public async Task<List<Inventario>> GetInventarioByPedido(int idPedido, DateTime from, DateTime to)
        {
            if (from == null || from == DateTime.MinValue || to == null || to == DateTime.MinValue)
            {
                return await _context.Inventarios
                    .Where(i => i.IdPedido == idPedido)
                    .ToListAsync();
            }
            else
            {
                DateOnly fromDateOnly = DateOnly.FromDateTime(from);
                DateOnly toDateOnly = DateOnly.FromDateTime(to);

                return await _context.Inventarios
                                     .Where(i => i.IdPedido == idPedido
                                                 || (i.Fecha >= fromDateOnly
                                                 && i.Fecha <= toDateOnly))
                                     .ToListAsync();
            }
        }

        public Task<List<Inventario>> GetInventarioByTipoMov(int mov, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateInventario(Inventario inv)
        {
            throw new NotImplementedException();
        }
    }
}
