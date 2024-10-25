using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _repository;

        public InventarioService(IInventarioRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> CreateInventario(Inventario inv)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Inventario>> GetAll()
        {
            return await _repository.GetAll();
        }


        public async Task<List<Inventario>> GetInventarioByFactura(int idFactura, DateTime from, DateTime to)
        {
            return await _repository.GetInventarioByFactura(idFactura, from, to);
        }

        public async Task<List<Inventario>> GetInventarioByPedido(int idPedido, DateTime from, DateTime to)
        {
            return await _repository.GetInventarioByPedido(idPedido, from, to);
        }

        public async Task<List<Inventario>> GetInventarioByTipoMov(int mov, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateInventario(Inventario inv)
        {
            throw new NotImplementedException();
        }
    }
}
