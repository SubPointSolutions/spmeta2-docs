---
id: "listviewwebpartdefinition"
title: "ListViewWebPartDefinition"
scenario_model: "Web model"
scenario_category: "Web Parts"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
ListViewWebPart provision is enabled via ListViewWebPartDefinition object.

Both CSOM/SSOM object models are supported. You can deploy either single object or a set of the objects using AddListViewWebPart() extension method as per following examples

## Examples

### Add LVWP binded to list by Title
```cs
var travelRequests = new ListDefinition
{
    Title = "Travel Requests",
    Description = "A document library.",
    TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
    Url = "m2TravelRequests"
};
 
var listView = new ListViewWebPartDefinition
{
    Title = "Travel Request Default View by List Title",
    Id = "m2TravelRequestsView",
    ZoneIndex = 10,
    ZoneId = "Main",
    ListTitle = travelRequests.Title
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 List View provision",
    FileName = "listview-webpart-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
      .AddList(travelRequests)
      .AddHostList(BuiltInListDefinitions.SitePages, list =>
      {
          list.AddWebPartPage(webPartPage, page =>
          {
              page.AddListViewWebPart(listView);
          });
      });
});
 
DeployModel(model);
```

### Add LVWP binded to list by URL

```cs
var annualReviewsLibrary = new ListDefinition
{
    Title = "Annual Reviews",
    Description = "A document library.",
    TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
    Url = "m2AnnualReviews"
};
 
var listView = new ListViewWebPartDefinition
{
    Title = "Annual Reviews Default View by List Url",
    Id = "m2AnnualReviewsView",
    ZoneIndex = 10,
    ZoneId = "Main",
    ListUrl = annualReviewsLibrary.GetListUrl()
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 List View provision",
    FileName = "listview-webpart-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
      .AddList(annualReviewsLibrary)
      .AddHostList(BuiltInListDefinitions.SitePages, list =>
      {
          list.AddWebPartPage(webPartPage, page =>
          {
              page.AddListViewWebPart(listView);
          });
      });
});
 
DeployModel(model);

```

### Add LVWP binded to list view by Title

```cs
var incidentsLibrary = new ListDefinition
{
    Title = "Incidents library",
    Description = "A document library.",
    TemplateType = BuiltInListTemplateTypeId.DocumentLibrary,
    Url = "m2Incidents"
};
 
var incidentsView = new ListViewDefinition
{
    Title = "Last Incidents",
    Fields = new Collection<string>
    {
        BuiltInInternalFieldNames.Edit,
        BuiltInInternalFieldNames.ID,
        BuiltInInternalFieldNames.FileLeafRef
    },
    RowLimit = 10
};
 
var listView = new ListViewWebPartDefinition
{
    Title = "Last Incidents binding by List View Title",
    Id = "m2LastIncidentsView",
    ZoneIndex = 10,
    ZoneId = "Main",
    ListUrl = incidentsLibrary.GetListUrl(),
    ViewName = incidentsView.Title
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 List View provision",
    FileName = "listview-webpart-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
      .AddList(incidentsLibrary, list =>
      {
          list.AddListView(incidentsView);
      })
      .AddHostList(BuiltInListDefinitions.SitePages, list =>
      {
          list.AddWebPartPage(webPartPage, page =>
          {
              page.AddListViewWebPart(listView);
          });
      });
});
 
DeployModel(model);

```

### Add LVWP binded to calendar view
```cs
var companyEvents = new ListDefinition
{
    Title = "Company Events",
    Description = "A document library.",
    TemplateType = BuiltInListTemplateTypeId.Events,
    Url = "m2CompanyEvents"
};
 
var webPartPage = new WebPartPageDefinition
{
    Title = "SPMeta2 List View provision",
    FileName = "listview-webpart-provision.aspx",
    PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
};
 
var listView = new ListViewWebPartDefinition
{
    Title = "Company Events by List View Title",
    Id = "m2CompanyEvents",
    ZoneIndex = 10,
    ZoneId = "Main",
    ListUrl = companyEvents.GetListUrl(),
    ViewName = "Calendar"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web
      .AddList(companyEvents)
      .AddHostList(BuiltInListDefinitions.SitePages, list =>
      {
          list.AddWebPartPage(webPartPage, page =>
          {
              page.AddListViewWebPart(listView);
          });
      });
});
 
DeployModel(model);
```