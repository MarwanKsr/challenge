namespace Enoca.Api.Models.Company
{
    public class CompanyViewModel
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public bool ApprovalStatus { get; set; }
        public DateTime OrderStartTime { get; set; }
        public DateTime OrderEndTime { get; set; }
    }
}
