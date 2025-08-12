using Common.Shared.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Shared.DTOs.Inventories
{
    public class PurchaseProductDto
    {
        public EDocumentType DocumentType { get; } = EDocumentType.Purchase;

        public string? ItemNo { get; set; }

        public string? DocumentNo { get; set; }

        public string? ExternalDocumentNo { get; set; }

        public int Quantity { get; set; }
    }
}
