using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients_Explorer.Models
{
    /// <summary>
    /// Юридическое лицо
    /// </summary>
    public class LegalEntity : Client
    {
        public LegalEntity(string name, string taxesPayerNumber)
            : base(name, taxesPayerNumber)
        {
            Type = GetClientType();
            CreationDate = GetCurrentDate();
            RefreshDate = GetCurrentDate();
            Founders = new List<Founder>();
        }
    }
}
