<properties
	  pageTitle="TaxonomyTermStoreDefinition"
    pageName="TaxonomyTermStoreDefinition"
    parentPageId="12821"
/>

###Provision scenario
We should be able to lookup an **existing taxonomy term store** to provision term groups, term sets and terms.

###Scope
Should be deployed under site.

###Implementation
Term store lookup is enabled via TaxonomyTermStoreDefinition object.

Both CSOM/SSOM object models are supported. 

Provision used Name, Id or UseDefaultSiteCollectionTermStore properties to lookup **existing termstore**. 

###Samples
#### Lookup existing term store by Name
[TEST.LookupTermStoreByName]

#### Lookup default site term store
[TEST.LookupDefaultSiteTermStore]