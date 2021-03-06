---
id: "fielddefinition"
title: "FieldDefinition"
scenario_model: "Farm model"
scenario_category: "Fields"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
Site, Web, List

## Notes
Provision checks if field exists looking up it by Id/Name property, then creates a new site field.

We suggest to use BuiltInFieldTypes to benefit OOTB SharePoint field types.

## Examples

### Add field to site


```cs
// use BuiltInFieldTypes class to refer to OOTB SharePoint fields
 
var customerRefererence = new FieldDefinition
{
    Title = "Customer Reference",
    InternalName = "dcs_CustomerReference",
    Group = "SPMeta2.Samples",
    Id = new Guid("D3B94B32-3F97-4B5B-99BE-95D17F83618B"),
    FieldType = BuiltInFieldTypes.Text,
};
 
var isAciveClient = new FieldDefinition
{
    Title = "Is Active Customer",
    InternalName = "dcs_IsActiveCustomer",
    Group = "SPMeta2.Samples",
    Id = new Guid("C846CA90-5EE0-4FDF-882B-6FB17625C6F9"),
    FieldType = BuiltInFieldTypes.Boolean,
};
 
var additionalInformation = new FieldDefinition
{
    Title = "Customer Additional Information",
    InternalName = "dcs_CustomerAdditionalInfo",
    Group = "SPMeta2.Samples",
    Id = new Guid("A5221F56-D4F4-4831-AF51-AA9776FA990D"),
    FieldType = BuiltInFieldTypes.Note,
};
 
var customerBalance = new FieldDefinition
{
    Title = "Customer Balance",
    InternalName = "dcs_CustomerBalance",
    Group = "SPMeta2.Samples",
    Id = new Guid("3C0A0358-BF74-4F79-855B-F85F5BF24028"),
    FieldType = BuiltInFieldTypes.Number,
};
 
var model = SPMeta2Model.NewSiteModel(site =>
{
    site
        .AddField(customerRefererence)
        .AddField(isAciveClient)
        .AddField(additionalInformation)
        .AddField(customerBalance);
});
 
DeployModel(model);
```

### Add field to web

```cs
var textField = new FieldDefinition
{
    Title = "Simple text field",
    InternalName = "dcs_SimpleTextField",
    Group = "SPMeta2.Samples",
    Id = new Guid("c3afc5ee-c416-4a05-91b3-116de4a205de"),
    FieldType = BuiltInFieldTypes.Text,
};
 
var booleanField = new FieldDefinition
{
    Title = "Simple boolean field",
    InternalName = "dcs_SimpleBooleanField",
    Group = "SPMeta2.Samples",
    Id = new Guid("1f0a5ba9-7b00-433d-8d93-dcfb4f87bfca"),
    FieldType = BuiltInFieldTypes.Boolean,
};
 
var listWithFields = new ListDefinition
{
    Title = "List with fields",
    Description = "Custom list with list-scoped fields.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    Url = "ListWithFields"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddField(textField);
    web.AddField(booleanField);
});
 
DeployModel(model);
```

### Add field to list

```cs
var textField = new FieldDefinition
{
    Title = "Simple text field",
    InternalName = "dcs_SimpleTextField",
    Group = "SPMeta2.Samples",
    Id = new Guid("c3afc5ee-c416-4a05-91b3-116de4a205de"),
    FieldType = BuiltInFieldTypes.Text,
};
 
var booleanField = new FieldDefinition
{
    Title = "Simple boolean field",
    InternalName = "dcs_SimpleBooleanField",
    Group = "SPMeta2.Samples",
    Id = new Guid("1f0a5ba9-7b00-433d-8d93-dcfb4f87bfca"),
    FieldType = BuiltInFieldTypes.Boolean,
};
 
var listWithFields = new ListDefinition
{
    Title = "List with fields",
    Description = "Custom list with list-scoped fields.",
    TemplateType = BuiltInListTemplateTypeId.GenericList,
    Url = "ListWithFields"
};
 
var model = SPMeta2Model.NewWebModel(web =>
{
    web.AddList(listWithFields, list =>
    {
        list.AddField(textField);
        list.AddField(booleanField);
    });
});
 
DeployModel(model);
```