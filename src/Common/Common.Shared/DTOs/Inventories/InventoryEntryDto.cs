﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Shared.DTOs.Inventories
{
    public class InventoryEntryDto
    {
        public string Id { get; set; }

        public EDocumentType DocumentType { get; set; }

        public string ItemNo { get; set; }

        public int Quantity { get; set; }

        public string DocumentNo { get; set; }

        public string ExternalDocumentNo { get; set; }
    }
}
