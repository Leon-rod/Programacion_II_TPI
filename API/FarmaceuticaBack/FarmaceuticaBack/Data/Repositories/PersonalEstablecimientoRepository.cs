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
    public class PersonalEstablecimientoRepository : IPersonalEstablecimientoRepository
    {
        private readonly FarmaceuticaContext _context;
        public PersonalEstablecimientoRepository(FarmaceuticaContext context)
        {
            this._context = context;
        }
        public async Task<List<PersonalCargosEstablecimiento>> GetAll()
        {
            List<PersonalCargosEstablecimiento> result = await _context.PersonalCargosEstablecimientos
                .Include(p => p.IdEstablecimientoNavigation)
                .Include(p => p.IdPersonalNavigation)
                .ToListAsync();
            return result;
        }
    }
}
