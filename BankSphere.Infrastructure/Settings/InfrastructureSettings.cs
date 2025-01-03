using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSphere.Infrastructure.Interfaces;

namespace BankSphere.Infrastructure.Settings
{
    public class InfrastructureSettings : IInfrastructureSettings
    {
        public SqlServerSettings SqlServerSettings { get; set; }
    }
}
