select * from [dbo].[BuildingType]
select * from [dbo].[City]
select * from [dbo].[CityBuilding]
select * from [dbo].[Status]

delete from [dbo].[CityBuilding]
delete from City
delete from [dbo].[BuildingType]

DBCC CHECKIDENT (BuildingType, reseed, 0)
DBCC CHECKIDENT (City, reseed, 0)
DBCC CHECKIDENT (CityBuilding, reseed, 0)


INSERT INTO [dbo].[BuildingType] ([BuildingName], CreateDate, ModifyDate)VALUES ('Town hall' , GETDATE(), GETDATE())
INSERT INTO [dbo].[BuildingType] ([BuildingName], CreateDate, ModifyDate)VALUES ('Supermarket' , GETDATE(), GETDATE())
INSERT INTO [dbo].[BuildingType] ([BuildingName], CreateDate, ModifyDate)VALUES ('Restaurant' , GETDATE(), GETDATE())
INSERT INTO [dbo].[BuildingType] ([BuildingName], CreateDate, ModifyDate)VALUES ('Expo center' , GETDATE(), GETDATE())
INSERT INTO [dbo].[BuildingType] ([BuildingName], CreateDate, ModifyDate)VALUES ('Train station' , GETDATE(), GETDATE())
		  
