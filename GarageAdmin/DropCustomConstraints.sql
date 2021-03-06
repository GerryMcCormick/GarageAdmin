﻿/* DROP CUSTOM CONSTRAINTS 

   THIS SCRIPT MUST BE RUN BEFORE UPDATING DB FROM MODEL */

USE [GarageAdmin]

/* DROP UNIQUE CONSTRAINTS */

ALTER TABLE [dbo].[Cars] DROP CONSTRAINT UC_RegNumber;

ALTER TABLE [dbo].[ServiceParts] DROP CONSTRAINT UC_ServiceIdPartId;


/* DROP CHECK CONSTRAINTS */

ALTER TABLE [dbo].[Services] DROP CONSTRAINT CHK_DateServiced;

ALTER TABLE [dbo].[Invoices] DROP CONSTRAINT CHK_ReceivedPaymentOn;

ALTER TABLE [dbo].[Invoices] DROP CONSTRAINT CHK_DateIssued;

ALTER TABLE [dbo].[Services] DROP CONSTRAINT CHK_DurationInHours;

ALTER TABLE [dbo].[Parts] DROP CONSTRAINT CHK_Price;

ALTER TABLE [dbo].[Parts] DROP CONSTRAINT CHK_NoInStock;

ALTER TABLE [dbo].[ServiceParts] DROP CONSTRAINT CHK_Quantity;