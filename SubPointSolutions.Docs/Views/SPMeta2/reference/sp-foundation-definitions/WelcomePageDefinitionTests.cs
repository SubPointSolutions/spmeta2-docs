using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.CSOM.DefaultSyntax;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;
using SPMeta2.Utils;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class WelcomePageDefinitionTests : ProvisionTestBase
    {
        #region methods

      
        [TestMethod]
        [TestCategory("Docs.WelcomePageDefinition")]
        public void CanDeployWelcomePageToWeb()
        {
            var newWebHomePage = new WikiPageDefinition
            {
                FileName = "A new landing page for web.aspx",
                Content = "Hello, this is a new web landing page!"
            };

            var welcomePage = new WelcomePageDefinition
            {
                // should be relating to the web!
                Url = UrlUtility.CombineUrl(BuiltInListDefinitions.SitePages.GetListUrl(), newWebHomePage.FileName)
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddHostList(BuiltInListDefinitions.SitePages, list =>
                    {
                        list.AddWikiPage(newWebHomePage);
                    })
                    .AddWelcomePage(welcomePage);
            });

            DeployModel(model);
        }

     
        [TestMethod]
        [TestCategory("Docs.WelcomePageDefinition")]
        public void CanDeployWelcomePageToList()
        {
            var newListHomePage = new WikiPageDefinition
            {
                FileName = "A new landing page for list.aspx",
                Content = "Hello, this is a new list landing page!"
            };

            var welcomePage = new WelcomePageDefinition
            {
                // should be relating to the list!
                Url = newListHomePage.FileName
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddHostList(BuiltInListDefinitions.SitePages, list =>
                    {
                        list
                            .AddWikiPage(newListHomePage)
                            .AddWelcomePage(welcomePage);
                    });
            });

            DeployModel(model);
        }

       
        [TestMethod]
        [TestCategory("Docs.WelcomePageDefinition")]
        public void CanDeployWelcomePageToFolder()
        {
            var newFolderHomePage = new WikiPageDefinition
            {
                FileName = "A new landing page for folder.aspx",
                Content = "Hello, this is a new folder landing page!"
            };

            var welcomePage = new WelcomePageDefinition
            {
                // should be relating to the folder!
                Url = newFolderHomePage.FileName
            };

            var landingPageFolder = new FolderDefinition
            {
                Name = "A folder with custom landing page"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddHostList(BuiltInListDefinitions.SitePages, list =>
                    {
                        list
                            .AddFolder(landingPageFolder, folder =>
                            {
                                folder
                                    .AddWikiPage(newFolderHomePage)
                                    .AddWelcomePage(welcomePage);
                            });
                    });
            });

            DeployModel(model);
        }

        #endregion
    }
}