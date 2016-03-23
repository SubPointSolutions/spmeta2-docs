using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class TreeViewSettingsDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.TreeViewSettingsDefinition")]
        public void CanDeploySimpleTreeViewSettingsDefinition()
        {
            var treeViewSettings = new TreeViewSettingsDefinition
            {
                TreeViewEnabled = true,
                QuickLaunchEnabled = true
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddTreeViewSettings(treeViewSettings);
            });

            DeployModel(model);
        }

        #endregion
    }
}