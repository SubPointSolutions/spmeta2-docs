﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;

using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Docs.ProvisionSamples.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using SubPointSolutions.Docs.Code.Definitions;

namespace SPMeta2.Docs.ProvisionSamples.Provision.Definitions
{
    [TestClass]
    public class ListDefinitionTests : ProvisionTestBase
    {
        #region methods


       

        [TestMethod]
        [TestCategory("Docs.ListDefinition")]
        public void CanDeployListByTemplateId()
        {
            var genericList = new ListDefinition
            {
                Title = "Generic list",
                Description = "A generic list.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                Url = "GenericList"
            };

            var documentLibrary = new ListDefinition
            {
                Title = "Document library",
                Description = "A document library.",
                TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
                Url = "DocumentLibrary"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(genericList);
                web.AddList(documentLibrary);
            });

            DeployModel(model);
        }


        [TestMethod]
        [TestCategory("Docs.ListDefinition")]
        public void CanDeployListByTemplateName()
        {
            var contactsList = new ListDefinition
            {
                Title = "Some Assert",
                Description = "Some Assert.",
                TemplateName = BuiltInListTemplates.AssetLibrary.InternalName,
                Url = "SomeAssert"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(contactsList);
            });

            DeployModel(model);
        }



        [TestMethod]
        [TestCategory("Docs.ListDefinition")]
        public void CanDeployStyleLibrary()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
                {
                    // do stuff
                });
            });

            DeployModel(model);
        }


        [TestMethod]
        [TestCategory("Docs.ListDefinition")]
        public void CanDeployOOTBListsLibrary()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web.AddHostList(BuiltInListDefinitions.StyleLibrary, list =>
                {
                    // do stuff
                });

                web.AddHostList(BuiltInListDefinitions.Catalogs.MasterPage, list =>
                {
                    // do stuff
                });

                web.AddHostList(BuiltInListDefinitions.SitePages, list =>
                {
                    // do stuff
                });

                web.AddHostList(BuiltInListDefinitions.SiteAssets, list =>
                {
                    // do stuff
                });
            });

            DeployModel(model);
        }

       
        [TestMethod]
        [TestCategory("Docs.ListDefinition")]
        public void CanDeploySimpleLists()
        {
            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddWeb(DocWebs.AboutOurCompany, aboutWeb =>
                    {
                        aboutWeb
                            .AddList(DocLists.AboutUsLists.ManagementTeam)
                            .AddList(DocLists.AboutUsLists.OurClients);
                    })
                    .AddWeb(DocWebs.DepartmentWebs.HR, hrWeb =>
                    {
                        hrWeb
                            .AddList(DocLists.HRLists.AnnualReviews)
                            .AddList(DocLists.HRLists.Poicies)
                            .AddList(DocLists.HRLists.Procedures);
                    })
                    .AddWeb(DocWebs.Departments, departmentWeb =>
                    {
                        departmentWeb
                            .AddList(DocLists.DepartmentsLists.IssueRegister)
                            .AddList(DocLists.DepartmentsLists.TeamEvents)
                            .AddList(DocLists.DepartmentsLists.TeamTasks);
                    });
            });

            DeployModel(model);
        }

        #endregion
    }
}