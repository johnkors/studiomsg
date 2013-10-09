using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace studiomsg.web.Controllers
{
	[Authorize]
    public class ProdusentController : Controller
    {
        public ActionResult Index()
        {
            var studioMessageTypes = new List<StudioMessageType>
                                             {
                                                 new StudioMessageType {Name = "E-post", Value = "em"},
                                                 new StudioMessageType {Name = "Twitter", Value = "tw"},
                                                 new StudioMessageType {Name = "Facebook", Value = "fb"}
                                             };

            var defaultModel = new StudioMessage();
            defaultModel.AvailableTypes = studioMessageTypes;
            defaultModel.ValuedOfSelectedMessageType = studioMessageTypes.FirstOrDefault().Value;
            return View(defaultModel);

        }


    }

    public class StudioMessageType
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class StudioMessage
    {
        public string Message { get; set; }
        public string ValuedOfSelectedMessageType { get; set; }
        public List<StudioMessageType> AvailableTypes { get; set; }

        public StudioMessageType SelectedMsgType
        {
            get { return (from c in AvailableTypes where c.Value == ValuedOfSelectedMessageType select c).FirstOrDefault(); }
        }
    }
}
