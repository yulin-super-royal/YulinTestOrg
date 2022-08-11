using System.ComponentModel.DataAnnotations;

namespace YulinTestOrg.Data
{
    public class RcgGameDesk
    {
        [Key]
        public string Id { get; set; }
        public int ServerNo { get; set; }
        public int LobbyNo { get; set; }
        public int GameNo { get; set; }
        public string Tag { get; set; }
        public string Name { get; set; }
        public string ServerProperty { get; set; }
    }
}
