namespace YulinTestOrg.Utility.Setting
{
    public class Rcgsetting
    {
        public string ApiUrl { get; set; }
        public Organizationinfo OrganizationInfo { get; set; }
    }

    public class Organizationinfo
    {
        public Guid OrganizationId { get; set; }
        public string ClientSecret { get; set; }
        public string DesKey { get; set; }
        public string DesIV { get; set; }
        public string SystemCode { get; set; }
        public string WebId { get; set; }
    }
}
