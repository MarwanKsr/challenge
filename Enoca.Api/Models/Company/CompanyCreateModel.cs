namespace Enoca.Api.Models.Company
{
    public class CompanyCreateModel
    {
        public string CompanyName { get; set; }
        public bool ApprovalStatus { get; set; }
        public DateTime OrderStartTime { get; set; } = DateTime.Now;
        public DateTime OrderEndTime { get; set; } = DateTime.Now;
    }
}
