using Microsoft.SharePoint.WebPartPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using SPMeta2.Utils;
using SubPointSolutions.Docs.Code.Enumerations;
using SubPointSolutions.Docs.Code.Metadata;
using System.ComponentModel;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    

    [Category("Category=Web Model/Web parts")]
    //[Browsable(false)]
    public class WebPartDefinitionTests : ProvisionTestBase
    {
        #region methods

        [TestMethod]
        [TestCategory("Docs.WebPartDefinition")]

        [DisplayName("Add web part by type")]
        //[Browsable(false)]

        public void CanDeployWebpartByWebpartType()
        {
            // this would deploy a web part using WebpartType prop
            // you need to provide AssemblyQualifiedName of the target web part type
            // M2 would use reflection to create an instane of the web part in the runtime
            // that works only for SSOM, not CSOM support yet

            var contentEditorWebPart = new WebPartDefinition
            {
                Title = "About SharePoint SSOM",
                Id = "m2AboutSharePointSSOM",
                WebpartType = typeof(ContentEditorWebPart).AssemblyQualifiedName,
                ZoneIndex = 10,
                ZoneId = "Main"
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 webparts provision",
                FileName = "web-parts-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list.AddWebPartPage(webPartPage, page =>
                    {
                        page.AddWebPart(contentEditorWebPart);
                    });
                });
            });

            DeploySSOMModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.WebPartDefinition")]


        [DisplayName("Add web part by XML")]
        //[Browsable(false)]
        public void CanDeployWebpartByXML()
        {
            // this whould deploy the web part using WebpartXmlTemplate prop
            // you need to provide an XML template which you get from SharePoint
            // export the wenb part, and put it into WebpartXmlTemplate prop

            // here is a web part XML template
            // usually, you export that XML from SharePoint page, but M2 has pre-build class
            var contentEditorWebPartXml = BuiltInWebPartTemplates.ContentEditorWebPart;

            var contentEditorWebPart = new WebPartDefinition
            {
                Title = "About SharePoint XML",
                Id = "m2AboutSharePointXML",
                WebpartXmlTemplate = contentEditorWebPartXml,
                ZoneIndex = 20,
                ZoneId = "Main"
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 webparts provision",
                FileName = "web-parts-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list.AddWebPartPage(webPartPage, page =>
                    {
                        page.AddWebPart(contentEditorWebPart);
                    });
                });
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.WebPartDefinition")]

        [DisplayName("Add web part from Gallery File")]
        //[Browsable(false)]
        public void CanDeployWebpartByWebpartGalleryFileName()
        {
            // this would deploy the web part using WebpartFileName
            // you need to provide a file name ofthe web part template in the web part gallery
            // M2 would load this file, then use an XML as a web part template

            var contentEditorWebPart = new WebPartDefinition
            {
                Title = "About SharePoint web part gallery",
                Id = "m2AboutSharePointWebPartGallery",
                // shortcut to "MSContentEditor.dwp",
                WebpartFileName = BuiltInWebpartFileNames.MSContentEditor,
                ZoneIndex = 20,
                ZoneId = "Main"
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 webparts provision",
                FileName = "web-parts-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list.AddWebPartPage(webPartPage, page =>
                    {
                        page.AddWebPart(contentEditorWebPart);
                    });
                });
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.WebPartDefinition")]

        [DisplayName("Add web part with pre-configured XML")]
        //[Browsable(false)]

        public void CanDeployWebpartWithPreprocessedXML()
        {
            // this shows how to use M2 API to pre-process web part XML

            // here is a web part XML template
            // usually, you export that XML from SharePoint page, but M2 has pre-build class
            var contentEditorWebPartXml = BuiltInWebPartTemplates.ContentEditorWebPart;

            // let' set new some properties, shall we?
            // we load XML by WebpartXmlExtensions.LoadWebpartXmlDocument() method
            // it works well web both V2/V3 web part XML
            // then change properties and seehow it goes
            // then call ToString() to get string out of XML
            var wpXml = WebpartXmlExtensions
                           .LoadWebpartXmlDocument(contentEditorWebPartXml)
                           .SetOrUpdateProperty("FrameType", "Standard")
                           .SetOrUpdateProperty("Width", "500")
                           .SetOrUpdateProperty("Heigth", "200")
                           .SetOrUpdateContentEditorWebPartProperty("Content", "This is a new content!", true)
                           .ToString();

            var contentEditorWebPart = new WebPartDefinition
            {
                Title = "New content",
                Id = "m2AboutSharePointnewContent",
                WebpartXmlTemplate = wpXml,
                ZoneIndex = 20,
                ZoneId = "Main"
            };

            var webPartPage = new WebPartPageDefinition
            {
                Title = "M2 webparts provision",
                FileName = "web-parts-provision.aspx",
                PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    list.AddWebPartPage(webPartPage, page =>
                    {
                        page.AddWebPart(contentEditorWebPart);
                    });
                });
            });

            DeployCSOMModel(model);
        }

        #endregion
    }
}