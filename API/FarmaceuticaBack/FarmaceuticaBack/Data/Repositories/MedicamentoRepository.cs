using FarmaceuticaBack.Data.Contracts;
using FarmaceuticaBack.Data.Models;
using FarmaceuticaBack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Data.Repositories
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly FarmaceuticaContext _context;
        public MedicamentoRepository(FarmaceuticaContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int? id)
        {
            var oMedicamento = await _context.Medicamentos.FindAsync(id);
            if (oMedicamento != null)
            {
                oMedicamento.Activo = false;
                _context.Update(oMedicamento);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<Medicamento>> GetAll()
        {
            var List = await _context.Medicamentos
                            .Include(m => m.IdLaboratorioNavigation)
                            .Include(m=> m.IdMonodrogaNavigation)
                            .Include(m => m.IdMarcaNavigation)
                            .Include(m => m.IdPresentacionNavigation)
                            .ToListAsync();
            return List;
        }

        public async Task<List<Medicamento>> GetByFiltro(MedicamentoFiltro oFiltro)
        {
            IQueryable<Medicamento> query = _context.Medicamentos.AsQueryable(); 
            Type t = oFiltro.GetType();
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo p in properties)
            {
                if (p.PropertyType == typeof(string))
                {
                    string nombre = (string)p.GetValue(oFiltro);
                    if(nombre != "Seleccionar" && nombre != null && nombre != "string")
                    {
                        query = query.Include(m => m.IdLaboratorioNavigation)
                             .Include(m => m.IdMonodrogaNavigation)
                                .Include(m => m.IdMarcaNavigation)
                                .Include(m => m.IdPresentacionNavigation)
                                .Where(m => m.NombreComercial.Contains(nombre));
                    }
                }
                else
                {
                    int? valor = (int)p.GetValue(oFiltro);

                    if (valor != null && valor != 0)
                    {

                        // chicos para que esto funcione el filtro tiene que tener el mismo nombre que la propiedad de la clase
                        query = query.Include(m => m.IdLaboratorioNavigation)
                                .Include(m => m.IdMonodrogaNavigation)
                                .Include(m => m.IdMarcaNavigation)
                                .Include(m => m.IdPresentacionNavigation)
                                .Where(m => EF.Property<int>(m, p.Name) == valor);
                    }
                }

            }
            return await query.ToListAsync();

        }

        public async Task<int> GetLastId()
        {
            var lastId = await _context.Medicamentos
                .OrderByDescending(m => m.IdMedicamento)
                .Select(m => m.IdMedicamento)            
                .FirstOrDefaultAsync();       

                 return lastId;
        }

        public async Task<Medicamento> GetMedicamentoById(int id)
        {
            return await _context.Medicamentos
                                 .Include(m => m.IdLaboratorioNavigation)
                                .Include(m => m.IdMonodrogaNavigation)
                                .Include(m => m.IdMarcaNavigation)
                                .Include(m => m.IdPresentacionNavigation)
                                .Where(m => m.IdMedicamento == id)
                                 .FirstOrDefaultAsync();
        }

        public async Task<bool> Save(Medicamento oMedicamento)
        {
            _context.Medicamentos.Add(oMedicamento);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Medicamento oMedicamento)
        {
            var bMedicamento = await _context.Medicamentos.FindAsync(oMedicamento.IdMedicamento);
            if (bMedicamento != null)
            {
                bMedicamento.IdMonodroga = oMedicamento.IdMonodroga;
                bMedicamento.NombreComercial = oMedicamento.NombreComercial;
                bMedicamento.IdLaboratorio = oMedicamento.IdLaboratorio;
                bMedicamento.IdMarca = oMedicamento.IdMarca;
                bMedicamento.VentaLibre = oMedicamento.VentaLibre;
                bMedicamento.IdPresentacion = oMedicamento.IdPresentacion;
                bMedicamento.Descripcion = oMedicamento.Descripcion;
                bMedicamento.Precio = oMedicamento.Precio;
                bMedicamento.Activo = oMedicamento.Activo;
                _context.Update(bMedicamento);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
