using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.CSOM.DefaultSyntax;
using SPMeta2.Definitions;
using SPMeta2.Docs.ProvisionSamples.Base;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;


using SubPointSolutions.Docs.Code.Resources;

namespace SubPointSolutions.Docs.Views.Views.SPMeta2.reference
{
    [TestClass]
    

    [Category("Category=Web Model/SharePoint 2013 workflow")]
    //[Browsable(false)]
    public class SP2013WorkflowSubscriptionDefinitionTests : ProvisionTestBase
    {
        #region methods

       [DisplayName("Add SP2013 workflow to web")]
        //[Browsable(false)]
        public void CanDeploySimpleSP2013WorkflowSubscriptionToWeb()
        {
            var writeToHistoryListWorkflow = new SP2013WorkflowDefinition
            {
                DisplayName = "M2 - Write to history list",
                Override = true,
                Xaml = WorkflowTemplates.WriteToHistoryListWorkflow
            };

            var taskList = new ListDefinition
            {
                Title = "Write To History List Tasks",
                TemplateType = BuiltInListTemplateTypeId.Tasks,
                Url = "m2WriteToHistoryListTasks"
            };

            var historyList = new ListDefinition
            {
                Title = "Write To History List History",
                TemplateType = BuiltInListTemplateTypeId.WorkflowHistory,
                Url = "m2WriteToHistoryListHistory"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                  .AddSP2013Workflow(writeToHistoryListWorkflow)
                  .AddList(historyList)
                  .AddList(taskList)
                  .AddSP2013WorkflowSubscription(new SP2013WorkflowSubscriptionDefinition
                  {
                      Name = "Write To History Web Workflow",
                      WorkflowDisplayName = writeToHistoryListWorkflow.DisplayName,
                      HistoryListUrl = historyList.GetListUrl(),
                      TaskListUrl = taskList.GetListUrl()
                  });
            });

            DeployModel(model);
        }

        [TestMethod]
        [TestCategory("Docs.SP2013WorkflowSubscriptionDefinition")]

        [DisplayName("Add SP2013 workflow to list")]
        //[Browsable(false)]
        public void CanDeploySimpleSP2013WorkflowSubscriptionToList()
        {
            var writeToHistoryListWorkflow = new SP2013WorkflowDefinition
            {
                DisplayName = "M2 - Write to history list",
                Override = true,
                Xaml = WorkflowTemplates.WriteToHistoryListWorkflow
            };

            var taskList = new ListDefinition
            {
                Title = "Workflow Enabled List Tasks",
                TemplateType = BuiltInListTemplateTypeId.Tasks,
                Url = "m2WorkflowEnabledListTasks"
            };

            var historyList = new ListDefinition
            {
                Title = "Workflow Enabled List History",
                TemplateType = BuiltInListTemplateTypeId.WorkflowHistory,
                Url = "m2WorkflowEnabledListHistory"
            };

            var workflowEnabledList = new ListDefinition
            {
                Title = "Workflow Enabled List",
                Description = "Workflow enabled list.",
                TemplateType = BuiltInListTemplateTypeId.GenericList,
                Url = "WorkflowEnabledList"
            };

            var model = SPMeta2Model.NewWebModel(web =>
            {
                web
                    .AddSP2013Workflow(writeToHistoryListWorkflow)
                    .AddList(historyList)
                    .AddList(taskList)
                    .AddList(workflowEnabledList, list =>
                    {
                        list
                            .AddSP2013WorkflowSubscription(new SP2013WorkflowSubscriptionDefinition
                            {
                                Name = "Write To History List Workflow",
                                WorkflowDisplayName = writeToHistoryListWorkflow.DisplayName,
                                HistoryListUrl = historyList.GetListUrl(),
                                TaskListUrl = taskList.GetListUrl()
                            });
                    });
            });

            DeployModel(model);
        }

        #endregion
    }
}