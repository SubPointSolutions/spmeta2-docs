---
id: "taxonomytermdefinition"
title: "TaxonomyTermDefinition"
scenario_model: "Web model"
scenario_category: "Taxonomy"
---

## API support
[+] SSOM [+] CSOM

## Can be deployed under
List

## Notes
Both CSOM/SSOM object models are supported.

Provision checks if term exists, and then creates a new one.

## Examples

### Add taxonomy terms

```cs
// define term store
var defaultSiteTermStore = new TaxonomyTermStoreDefinition
{
    UseDefaultSiteCollectionTermStore = true
};
 
// define group
var clientsGroup = new TaxonomyTermGroupDefinition
{
    Name = "Clients"
};
 
// define term sets
var smallBusiness = new TaxonomyTermSetDefinition
{
    Name = "Small Business"
};
 
var mediumBusiness = new TaxonomyTermSetDefinition
{
    Name = "Medium Business"
};
 
var enterpriseBusiness = new TaxonomyTermSetDefinition
{
    Name = "Enterprise Business"
};
 
// define terms
var microsoft = new TaxonomyTermDefinition
{
    Name = "Microsoft"
};
 
var apple = new TaxonomyTermDefinition
{
    Name = "Apple"
};
 
var oracle = new TaxonomyTermDefinition
{
    Name = "Oracle"
};
 
var subPointSolutions = new TaxonomyTermDefinition
{
    Name = "SubPoint Solutions"
};
 
// setup the model
var model = SPMeta2Model.NewSiteModel(site =>
{
    site.AddTaxonomyTermStore(defaultSiteTermStore, termStore =>
    {
        termStore.AddTaxonomyTermGroup(clientsGroup, group =>
        {
            group
                .AddTaxonomyTermSet(smallBusiness, termSet =>
                {
                    termSet.AddTaxonomyTerm(subPointSolutions);
                })
                .AddTaxonomyTermSet(mediumBusiness)
                .AddTaxonomyTermSet(enterpriseBusiness, termSet =>
                {
                    termSet
                        .AddTaxonomyTerm(microsoft)
                        .AddTaxonomyTerm(apple)
                        .AddTaxonomyTerm(oracle);
                });
        });
    });
});
 
DeployModel(model);
```