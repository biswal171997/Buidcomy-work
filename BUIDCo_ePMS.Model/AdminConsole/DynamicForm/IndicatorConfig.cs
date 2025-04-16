using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace BUIDCO.Domain.DynamicForm
{
    public class IndicatorConfigDomain
    {
        public XElement IndicatorConfigXml { get; set; }
        public List<IndicatorConfig> IndicatorConfig { get; set; }
    }
        public class IndicatorConfig
    {
        public int ID { get; set; }
        public int FORMID { get; set; }
        public string PERIODICITY { get; set; }
        public int INDICATORID { get; set; }
        public string PVCH_LABEL_NAME { get; set; }
        public string FORMNAME { get; set; }
    }
}
