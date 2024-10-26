﻿using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface IPedidoService
    {
        Task<List<Pedido>> GetAll();
        Task<Pedido> GetById(int id);
        Task<List<Pedido>> GetByFecha(DateTime fechaDesde, DateTime fechaHasta);
        Task<List<Pedido>> GetByLogistica(string id);
        Task<List<Pedido>> GetByEstablecimiento(int id);
    }
}