﻿using Microsoft.SharePoint.Client;
using SPMeta2.CSOM.Services;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Syntax.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.CSOM.Services;

namespace SPMeta2.Samples.CSOMConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var siteUrl = "http://tesla-dev:31415/";
            var clientContext = new ClientContext(siteUrl);

            // define fields
            var clientDescriptionField = new FieldDefinition
            {
                Title = "Client Description",
                InternalName = "dcs_ClientDescription",
                Group = "SPMeta2.Samples",
                Id = new Guid("06975b67-01f5-47d7-9e2e-2702dfb8c217"),
                FieldType = BuiltInFieldTypes.Note,
            };

            var clientNumberField = new FieldDefinition
            {
                Title = "Client Number",
                InternalName = "dcs_ClientNumber",
                Group = "SPMeta2.Samples",
                Id = new Guid("22264486-7561-45ec-a6bc-591ba243693b"),
                FieldType = BuiltInFieldTypes.Number,
            };


            // define content type
            var customerAccountContentType = new ContentTypeDefinition
            {
                Name = "Customer Account",
                Id = new Guid("ddc46a66-19a0-460b-a723-c84d7f60a342"),
                ParentContentTypeId = BuiltInContentTypeId.Item,
                Group = "SPMeta2.Samples",
            };

            // define relationships and the model
            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site
                    .AddField(clientDescriptionField)
                    .AddField(clientNumberField)
                    .AddContentType(customerAccountContentType, contentType =>
                    {
                        contentType
                            .AddContentTypeFieldLink(clientDescriptionField)
                            .AddContentTypeFieldLink(clientNumberField);
                    });
            });

            // deploy the model to the SharePoint site over CSOM
            var csomProvisionService = new CSOMProvisionService();
            csomProvisionService.DeploySiteModel(clientContext, siteModel);
        }
    }
}
