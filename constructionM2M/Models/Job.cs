
namespace constructionM2M.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int ContractorId { get; set; }
        public int CompanyId { get; set; }
    }

    public class JobViewModel : Contractor
    {
        public int JobId { get; set; }
        public int CompanyId { get; set; }
        public int ContractorId { get; set; }
    }
}