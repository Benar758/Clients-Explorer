using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients_Explorer.Models
{
    /// <summary>
    /// Индивидуальный предприниматель
    /// </summary>
    public class Entrepreneur : Client
    {
        public Entrepreneur(string name, string taxesPayerNumber)
            : base(name, taxesPayerNumber)
        {
            Type = GetClientType();
            CreationDate = GetCurrentDate();
            RefreshDate = GetCurrentDate();
        }
    }
}
