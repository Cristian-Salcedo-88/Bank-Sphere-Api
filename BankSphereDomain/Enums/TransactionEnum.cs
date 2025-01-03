using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankSphere.Domain.Enums
{
    public enum TransactionEnum
    {
        [EnumMember(Value = "DEPOSITO")]
        Deposit,

        [EnumMember(Value = "RETIRO")]
        Withdrawal,

        [EnumMember(Value = "CANCELACION")]
        Cancelation
    }
}
