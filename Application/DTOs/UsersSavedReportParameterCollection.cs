namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public class UsersSavedReportParameterCollection
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ReportId { get; set; }
        public string Name { get; set; }
        public string ParametersJson { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}