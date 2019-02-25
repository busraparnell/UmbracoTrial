using Umbraco.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using umbraco.BusinessLogic.Actions;
using umbraco;

namespace WebApp.Controllers
{
    [Tree("example", "personTree","Person")]
    [PluginController("Example")]
    public class PersonTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            if (id == Constants.System.Root.ToInvariantString())
            {
                var ctrl = new PersonApiController();
                var nodes = new TreeNodeCollection();
                foreach(var person in ctrl.GetAll())
                {
                    var node = CreateTreeNode(person.Id.ToString(), "-1",queryStrings,person.ToString());
                    nodes.Add(node);
                }
                return nodes;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            var menu = new MenuItemCollection();
            if (id == Constants.System.Root.ToInvariantString())
            {
                menu.Items.Add<CreateChildEntity, ActionNew>(ui.Text("actions", ActionNew.Instance.Alias));
                menu.Items.Add<RefreshNode, ActionRefresh>(ui.Text("actions", ActionRefresh.Instance.Alias),true);
                return menu;
            }
            else
            {
                menu.Items.Add<ActionDelete>(ui.Text("actions", ActionDelete.Instance.Alias));

            }
            return menu;
        }
    }
}