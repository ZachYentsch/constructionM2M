
namespace constructionM2M.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int ContractorId { get; set; }
        public int CompanyId { get; set; }
    }

    public class ContractorJobViewModel : Contractor
    {
        public int JobId { get; set; }
        public int CompanyId { get; set; }
        public int ContractorId { get; set; }
        public string Location { get; set; }
    }

    public class CompanyJobViewModel : Company
    {
        public int JobId { get; set; }
        public int CompanyId { get; set; }
        public int ContractorId { get; set; }
        public string Specialty { get; set; }

    }
}