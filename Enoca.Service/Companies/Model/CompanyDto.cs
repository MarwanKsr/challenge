using Ardalis.GuardClauses;
using Enoca.Core.Domain.Companies;
using Enoca.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Service.Companies.Model
{
    public class CompanyDto
    {
        public long Id { get; private set; }
        public string CompanyName { get; private set; }
        public bool ApprovalStatus { get; private set; }
        public DateTime OrderStartTime { get; private set; }
        public DateTime OrderEndTime { get; private set; }

        public static CompanyDto FromEntity(Company company) => new()
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            ApprovalStatus = company.ApprovalStatus,
            OrderStartTime = company.OrderStartTime.ToLocalTime(),
            OrderEndTime = company.OrderEndTime.ToLocalTime()
        };
    }
}
