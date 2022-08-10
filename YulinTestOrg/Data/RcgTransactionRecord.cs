using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace YulinTestOrg.Data
{
    [Index(nameof(MemberAcount))]
    public class RcgTransactionRecord
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAcount { get; set; }

        [Key]
        public string TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal Balance { get; set; }
        public long TransactionTime { get; set; }

        /// <summary>
        /// true: 存入RCG
        /// false: 取回
        /// </summary>
        public bool TransactionType { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
