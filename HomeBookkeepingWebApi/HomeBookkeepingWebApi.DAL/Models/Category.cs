using HomeBookkeepingWebApi.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBookkeepingWebApi.DAL.Models
{
    public class Category : IIdentificated
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Purchase> Purchases { get; set; }
    }
}
