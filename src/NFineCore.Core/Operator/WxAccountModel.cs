using System;
using System.Collections.Generic;
using System.Text;

namespace NFineCore.Core
{
    public class WxAccountModel
    {
        public long Id { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string Name { get; set; }
        public string AppType { get; set; }
    }
}
