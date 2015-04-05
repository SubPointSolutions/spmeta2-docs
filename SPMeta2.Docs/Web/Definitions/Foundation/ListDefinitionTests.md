﻿<properties 
	pageTitle="ListDefinition" 
    pageName="listdefinition"
    parentPageId="12771"
/>

###Provision scenario
We should be able to provision a single SharePoint list or library.

###Scope 
Can be added under web.

###Implementation
List and library provision is enabled via ListDefinition object.

Both CSOM/SSOM object models are supported. Provision checks if list exists looking up it by Url property, then creates a new list. You can deploy either single list or a set of the lists using AddList() extension method as per following examples.

###Samples

#### Simple list by template id
[TEST.CanDeployListByTemplateId]

#### Simple list by template name
[TEST.CanDeployListByTemplateName]

#### Style Library provision
[TEST.CanDeployOOTBListsLibrary]

#### Simple lists provision under giving webs
[TEST.CanDeploySimpleLists]