using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSphere.Infrastructure.Settings;

namespace BankSphere.Infrastructure.Interfaces
{
    public interface IInfrastructureSettings
    {
        public SqlServerSettings SqlServerSettings { get; set; }
    }
}
