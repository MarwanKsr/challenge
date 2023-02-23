using Ardalis.GuardClauses;
using Enoca.Core.Base;
using Enoca.Core.Resources;

namespace Enoca.Core.Domain.Companies
{
    public class Company : BaseEntity
    {
        protected Company() { }

        public Company(string companyName, bool approvalStatus, DateTime orderStartTime, DateTime orderEndTime)
        {
            SetCompanyName(companyName);
            SetApprovalStatus(approvalStatus);
            SetOrderStartTime(orderStartTime);
            SetOrderEndTime(orderEndTime);
        }
        public string CompanyName { get; private set; }
        public void SetCompanyName(string companyName)
        {
            Guard.Against.NullOrEmpty(companyName, nameof(companyName), nameof(_Company.Company_Exception_EmptyName));
            CompanyName = companyName;
        }
        public bool ApprovalStatus { get; private set; }
        public void SetApprovalStatus(bool approvalStatus) => ApprovalStatus = approvalStatus;
        public DateTime OrderStartTime { get; private set; }
        public void SetOrderStartTime(DateTime orderStartTime)
        {
            Guard.Against.Null(orderStartTime, nameof(orderStartTime), nameof(_Company.Company_Exception_InvalidOrderStartTime));
            OrderStartTime = orderStartTime.ToUniversalTime();
        }
        public DateTime OrderEndTime { get; private set; }
        public void SetOrderEndTime(DateTime orderEndTime)
        {
            Guard.Against.Null(orderEndTime, nameof(orderEndTime), nameof(_Company.Company_Exception_InvalidOrderEndTime));
            OrderEndTime = orderEndTime.ToUniversalTime();
        }
    }
}
