using HomeBookkeepingWebApi.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBookkeepingWebApi.DAL.Models
{
    public class Purchase : IIdentificated
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string UserEmail { get; set; }

        public DateTime Date { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
