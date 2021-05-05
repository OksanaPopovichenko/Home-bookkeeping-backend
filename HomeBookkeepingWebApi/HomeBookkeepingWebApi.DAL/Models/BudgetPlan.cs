using HomeBookkeepingWebApi.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeBookkeepingWebApi.DAL.Models
{
    public class BudgetPlan : IIdentificated
    {
        public Guid Id { get; set; }

        public string UserEmail { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalValue { get; set; }

        [NotMapped]
        public decimal SpentValue { get; set; }

        [NotMapped]
        public decimal RestValue => TotalValue - SpentValue;
    }
}
