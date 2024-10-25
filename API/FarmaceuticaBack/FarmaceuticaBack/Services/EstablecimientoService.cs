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
    public class EstablecimientoService : IEstablecimientoService
    {
        private readonly IEstablecimientoRepository _repository;
        public EstablecimientoService(IEstablecimientoRepository repository)
        {
            this._repository = repository;
        }
        public Task<List<Establecimiento>> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
