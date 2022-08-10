using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace YulinTestOrg.Data
{
    [Index(nameof(MemberAccount))]
    public class RcgBetRecord
    {
        [Key]
        public Guid RecordId { get; set; }
        public string MemberAccount { get; set; }
        public long Id { get; set; }
        public int GameId { get; set; }
        public string Desk { get; set; }
        public string BetArea { get; set; }
        public decimal Bet { get; set; }
        public decimal Available { get; set; }
        public decimal WinLose { get; set; }
        public decimal WaterRate { get; set; }
        public string ActiveNo { get; set; }
        public string RunNo { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime ReportDT { get; set; }
        public string Ip { get; set; }
        public decimal Odds { get; set; }
        public long OriginRecordId { get; set; }
    }
}
