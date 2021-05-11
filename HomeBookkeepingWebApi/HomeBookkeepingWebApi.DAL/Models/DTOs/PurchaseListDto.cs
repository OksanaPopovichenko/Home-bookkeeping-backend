using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBookkeepingWebApi.DAL.Models.DTOs
{
    public class PurchasesListDto
    {
        public List<Purchase> Purchases { get; set; }
        public Dictionary<string, decimal> TotalPriceByGroup { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
