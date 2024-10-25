﻿using FarmaceuticaBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaceuticaBack.Services.Contracts
{
    public interface IStockService
    {
        Task<bool> Add(Stock stock);
        Task<bool> Update(Stock stock);
        Task<List<Stock>> GetByEstablishment(int id);
        Task<List<Stock>> GetByEstablishmentAndArticle(int id, string? product, string? medicine);
    }
}
