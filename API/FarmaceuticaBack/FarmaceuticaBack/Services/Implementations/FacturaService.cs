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
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _repository;
        public FacturaService(IFacturaRepository repository)
        {
            this._repository = repository;
        }
        public Task<List<Factura>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<List<Factura>> GetByClient(int client)
        {
            return _repository.GetByClient(client);
        }

        public Task<List<Factura>> GetByDates(DateOnly startDate, DateOnly endDate)
        {
            return _repository.GetByDates(startDate, endDate);
        }

        public Task<List<Factura>> GetByEmployee(int employee)
        {
            return _repository.GetByEmployee(employee);
        }

        public Task<List<Factura>> GetByEstablishment(int establishment)
        {
            return _repository.GetByEstablishment(establishment);
        }

        public Task<Factura> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Task<bool> Insert(Factura factura)
        {
            return _repository.Insert(factura);
        }

        public Task<bool> Update(Factura factura)
        {
            return _repository.Update(factura);
        }
    }
}
