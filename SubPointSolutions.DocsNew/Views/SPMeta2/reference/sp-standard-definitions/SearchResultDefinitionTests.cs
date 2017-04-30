using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;



namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    [Category("Category=Site Collection Model/Site collection")]

    //[Browsable(false)]
    public class SearchResultDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.SearchResultDefinition")]

        [DisplayName("Add search result")]
        [Browsable(false)]
        public void CanDeploySimpleSearchResultDefinition()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {

            });

            DeployModel(model);
        }

        #endregion
    }
}