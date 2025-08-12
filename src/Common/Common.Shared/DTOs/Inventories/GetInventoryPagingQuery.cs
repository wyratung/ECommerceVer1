using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared.DTOs.Inventories
{
    public class GetInventoryPagingQuery : PagingRequestParamaters
    {
        public string ItemNo() => _itemNo;

        private string _itemNo;

        public void SetItemNo(string itemNo) => _itemNo = itemNo;

        public string SearchTerm { get; set; } = null;
    }
}
