namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed class ReportData
    {
        public ReportData() { }

        public ReportData(short reportId, string reportURL, byte reportCategoryId, string reportCategoryName, bool isLive, string text, string description)
        {
            ReportId = reportId;
            URL = reportURL;
            ReportCategoryId = reportCategoryId;
            ReportCategoryName = reportCategoryName;
            IsLive = isLive;
            Text = text;
            Description = description;
            EntityKeyValue = reportId.ToString();
        }

        public ReportData(short reportId, string reportURL, byte reportCategoryId, string reportCategoryName, bool isLive, string text, string description, byte reportTypeId)
        {
            ReportId = reportId;
            URL = reportURL;
            ReportCategoryId = reportCategoryId;
            ReportCategoryName = reportCategoryName;
            IsLive = isLive;
            Text = text;
            Description = description;
            ReportTypeId = reportTypeId;
            EntityKeyValue = reportId.ToString();
        }

        public short ReportId { get; set; }
        public string URL { get; set; }
        public byte ReportCategoryId { get; set; }
        public string ReportCategoryName { get; set; }
        public bool IsLive { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public byte ReportTypeId { get; set; }
        public string EntityKeyValue { get; set; }
        public bool RoleReport { get; set; } = false;
    }
}