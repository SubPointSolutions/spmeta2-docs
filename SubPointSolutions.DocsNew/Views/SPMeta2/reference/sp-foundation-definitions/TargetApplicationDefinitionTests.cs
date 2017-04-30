using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;



namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    

   [Category("Category=Farm Model/Farm")]
    //[Browsable(false)]
    public class TargetApplicationDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.TargetApplicationDefinition")]

        [DisplayName("Add Target Application")]
        [Browsable(false)]
        public void CanDeploySimpleTargetApplicationDefinition()
        {
            var model = SPMeta2Model.NewSiteModel(site =>
            {
         
            });

            DeployModel(model);
        }

        #endregion
    }
}