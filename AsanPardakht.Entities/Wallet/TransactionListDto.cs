using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsanPardakht.Entities.Wallet
{
    public class TransactionListDto
    {
        public decimal Money { get; set; }
        public string TransferType { get; set; }
        public string MoneyType { get; set; }
        public DateTime Time { get;set ; }
    }
}
