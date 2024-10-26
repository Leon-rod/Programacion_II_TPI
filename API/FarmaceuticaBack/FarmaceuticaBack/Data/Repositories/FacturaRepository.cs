using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly FarmaceuticaContext _context;
        public FacturaRepository(FarmaceuticaContext context)
        {
            this._context = context;
        }

        public Task<List<Factura>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Factura>> GetByClient(int client)
        {
            throw new NotImplementedException();
        }

        public Task<List<Factura>> GetByDates(DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Factura>> GetByEmployee(int employee)
        {
            throw new NotImplementedException();
        }

        public Task<Factura> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
