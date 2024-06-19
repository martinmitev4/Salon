CREATE TABLE [dbo].[Cars] (
    [CarId]                           INT            IDENTITY (1, 1) NOT NULL,
    [ManufacturerId]                  INT            NOT NULL,
    [Model_Name]                      NVARCHAR (MAX) NULL,
    [God]                             NVARCHAR (MAX) NULL,
    [Image]                           NVARCHAR (MAX) NULL,
    [Power]                           NVARCHAR (MAX) NULL,
    [Price_PriceId]                   INT            NULL,
    CONSTRAINT [PK_dbo.Cars] PRIMARY KEY CLUSTERED ([CarId] ASC),
    CONSTRAINT [FK_dbo.Cars_dbo.Manufacturers_ManufacturerId] FOREIGN KEY ([ManufacturerId]) REFERENCES [dbo].[Manufacturers] ([ManufacturerId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Cars_dbo.Car_dealership_Car_dealership_Car_dealershipId] FOREIGN KEY ([Car_dealership_Car_dealershipId]) REFERENCES [dbo].[Car_dealership] ([Car_dealershipId]),
    CONSTRAINT [FK_dbo.Cars_dbo.Prices_Price_PriceId] FOREIGN KEY ([Price_PriceId]) REFERENCES [dbo].[Prices] ([PriceId])
);


GO
CREATE NONCLUSTERED INDEX [IX_ManufacturerId]
    ON [dbo].[Cars]([ManufacturerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Car_dealership_Car_dealershipId]
    ON [dbo].[Cars]([Car_dealership_Car_dealershipId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Price_PriceId]
    ON [dbo].[Cars]([Price_PriceId] ASC);

