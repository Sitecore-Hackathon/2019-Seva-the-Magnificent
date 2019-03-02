using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;

namespace Workflow.Controllers
{
    public class WorkflowDesignerViewModel
    {
        public IEnumerable<Item> Workflows { get; set; }
    }

    public class WorkflowDesignerController : Controller
    {
        public ActionResult Index()
        {
            var workflowsFolderPath = "/sitecore/system/Workflows";

            var database = Sitecore.Configuration.Factory.GetDatabase("master");

            var workflowRootItem = database.GetItem(workflowsFolderPath);

            var model = new WorkflowDesignerViewModel
            {
                Workflows = workflowRootItem.GetChildren()
            };
                

            return this.View("WorkflowDesigner", model);
        }
    }
}