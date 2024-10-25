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
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        public StockService(IStockRepository stockRepository)
        {
            this._stockRepository = stockRepository;
        }
        public Task<bool> Add(Stock stock)
        {
            return _stockRepository.Add(stock);
        }

        public Task<List<Stock>> GetByEstablishment(int id)
        {
            return _stockRepository.GetByEstablishment(id);
        }

        public Task<List<Stock>> GetByEstablishmentAndArticle(int id, string? product, string? medicine)
        {
            return _stockRepository.GetByEstablishmentAndArticle(id, product, medicine);
        }

        public Task<bool> Update(Stock stock)
        {
            return _stockRepository.Update(stock);
        }
    }
}
