using CafeteriaWebApi.Data;
using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeteriaWebApi.Services.Implementations
{
    public class SaleOrderLineService : ISalesOrderLineService
    {
        private readonly CafeteriaContext _context;

        public SaleOrderLineService(CafeteriaContext context)
        {
            _context = context;
        }

        int ISalesOrderLineService.CreateSaleOrderLine(SaleOrderLine saleOrderLine)
        {
            throw new NotImplementedException();
        }

        public void DeleteSaleOrderLine(int IdSaleOrderLine)
        {
            throw new NotImplementedException();
        }

        public List<SaleOrderLine> GetSaleOrderLineById(int IdSaleOrderLine)
        {
            throw new NotImplementedException();
        }
    }
}