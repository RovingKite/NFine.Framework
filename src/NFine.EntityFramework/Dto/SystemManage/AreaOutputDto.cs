using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.EntityFramework.Dto.SystemManage
{
    public class AreaOutputDto
    {
        public string ParentId { get; set; }
        public int? Layers { get; set; }
        public string EnCode { get; set; }
        public string FullName { get; set; }

        public int? SortCode { get; set; }
        public DateTime? CreatedTime { get; set; }
        public bool? EnabledMark { get; set; }
    }
}
