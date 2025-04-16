using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BUIDCO.Domain.DynamicForm
{
    public class TemplateConfigDomain
    {
        public XDocument TemplateConfigXml { get; set; }
        public List<TemplateConfig> TemplateConfig { get; set; }
    }
    public class TemplateConfig
    {
        public int TEMPID { get; set; }
        public int FORMID { get; set; }
        public int TARGETCOLUMN { get; set; }
        public string SOURCECOLUMN { get; set; }
        public int CREATEDBY { get; set; }
        public string FORMNAME { get; set; }
        public string TARGETCOLUMNNAME { get; set; }
    }
}
