using System.ComponentModel.DataAnnotations;
using YulinTestOrg.Models.RcgApiModels;

namespace YulinTestOrg.Data
{
    public class RcgBetArea
    {
        [Key]
        public Guid Id { get; set; }
        public GameTypeEnum GameId { get; set; }
        public string GameName { get; set; }
        public string BetArea { get; set; }
        public string Context { get; set; }
        public string Lang { get; set; }
    }
}
