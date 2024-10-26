using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Implementations
{
    public class DispensacionService : IDispensacionService
    {
        private readonly IDispensacionRepository _repository;
        public DispensacionService(IDispensacionRepository repository)
        {
            this._repository = repository;
        }
        public Task<bool> Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Task<List<Dispensacion>> GetByIdFactura(int id)
        {
            return _repository.GetByIdFactura(id);
        }

        public Task<bool> Insert(Dispensacion dispensacion)
        {
            return _repository.Insert(dispensacion);
        }
    }
}
