/* ADD CONSTRAINTS THAT COULD NOT BE ADDED VIA ENTITY FRAMEWORK MODEL FIRST */

USE [GarageAdmin]

/* ADD UNIQUE CONSTRAINTS */

-- Car Reg Number must be unique
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT UC_RegNumber UNIQUE (RegNumber);

-- This was originally to be a composite key for the ServiceParts table,
-- but Entity Framework seems to work better when we use an int as our PK.
-- So instead adding a unique constraint for these 2 columns combined.
ALTER TABLE [dbo].[ServiceParts]
ADD CONSTRAINT UC_ServiceIdPartId UNIQUE (ServiceId, PartId);


/* ADD CHECK CONSTRAINTS */

-- DateServiced can not be in the future
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT CHK_DateServiced CHECK(DateServiced <= GETDATE());

-- ReceivedPaymentOn can not be in the future
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT CHK_ReceivedPaymentOn CHECK(ReceivedPaymentOn <= GETDATE());

-- DateIssued can not be in the future
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT CHK_DateIssued CHECK(DateIssued <= GETDATE());

-- DurationInHours must be greater than 0
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT CHK_DurationInHours CHECK(DurationInHours > 0);

-- Price must be greater than 0
ALTER TABLE [dbo].[Parts]
ADD CONSTRAINT CHK_Price CHECK(Price > 0);

-- NoInStock must be greater than or equal to 0
ALTER TABLE [dbo].[Parts]
ADD CONSTRAINT CHK_NoInStock CHECK(NoInStock >= 0);

-- Quantity must be greater than 0
ALTER TABLE [dbo].[ServiceParts]
ADD CONSTRAINT CHK_Quantity CHECK(Quantity > 0);