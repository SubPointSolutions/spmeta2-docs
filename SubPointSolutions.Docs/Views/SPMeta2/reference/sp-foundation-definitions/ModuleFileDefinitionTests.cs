using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class ModuleFileDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.ModuleFileDefinition")]

    
        public void CanDeployModuleFilesToStyleLibrary()
        {
            var cssFile = new ModuleFileDefinition
            {
                FileName = "m2-styles.css",
                Overwrite = true,
                Content = Encoding.UTF8.GetBytes(".m2-content { padding:10px; border:1px red solid; } ")
            };

            var jsFile = new ModuleFileDefinition
            {
                FileName = "m2-app.js",
                Overwrite = true,
                Content = Encoding.UTF8.GetBytes(" alert('hello, m2!'); ")
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
                {
                    list
                        .AddModuleFile(cssFile)
                        .AddModuleFile(jsFile);
                });
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.ModuleFileDefinition")]

        public void CanDeployModuleFilesToFolders()
        {
            var cssFile = new ModuleFileDefinition
            {
                FileName = "m2-red.css",
                Overwrite = true,
                Content = Encoding.UTF8.GetBytes(".m2-red { color:red; } ")
            };

            var jsFile = new ModuleFileDefinition
            {
                FileName = "m2-logger-module.js",
                Overwrite = true,
                Content = Encoding.UTF8.GetBytes(" function(msg) { console.log(msg); } ")
            };

            var cssFolder = new FolderDefinition
            {
                Name = "m2-css"
            };

            var jsFolder = new FolderDefinition
            {
                Name = "m2-js"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
                {
                    list
                        .AddFolder(cssFolder, folder =>
                        {
                            folder.AddModuleFile(cssFile);
                        })
                        .AddFolder(jsFolder, folder =>
                        {
                            folder.AddModuleFile(jsFile);
                        });
                });
            });

            DeployModel(model);
        }

        #endregion
    }
}