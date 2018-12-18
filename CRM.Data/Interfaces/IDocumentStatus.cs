using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Interfaces
{
    public interface IDocumentStatus
    {
        DateTime? Created { get; set; }
        DateTime? LastUpdated { get; set; }
        DateTime? Archived { get; set; }
        DateTime? Deleted { get; set; }
    }
}
