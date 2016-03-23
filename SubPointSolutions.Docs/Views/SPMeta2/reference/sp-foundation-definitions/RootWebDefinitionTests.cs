using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class RootWebDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.RootWebDefinition")]
        public void CanUpdateRootWebProperties()
        {
            var rootWeb = new RootWebDefinition
            {
                Title = "M2 CRM",
                Description = "Custom CRM application build on top of M2 framework."
            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddRootWeb(rootWeb);
            });

            DeployModel(model);
        }

     

        [TestMethod]
        [TestCategory("Docs.RootWebDefinition")]
        public void CanProvisionRootWebLists()
        {
            var rootWeb = new RootWebDefinition
            {

            };

            var model = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddRootWeb(rootWeb, web =>
                {
                    web
                      .AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
                      {
                          // do stuff with 'Style Library'
                      })
                      .AddHostList(BuiltInListDefinitions.Catalogs.MasterPage, list =>
                      {
                          // do stuff with 'Master Page Library'
                      });
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}