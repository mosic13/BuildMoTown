

select * from city
Select * from CityBuilding
Select * from BuildingType


select c.cityid, c.cityname, c.goldcoins, count(cb.cityid) as count From city c
inner join cityBuilding cb on c.Cityid = cb.cityid
--having cb.buildingid
group by  c.cityid, c.cityname, c.goldcoins,cb.cityid



select cb.*,c.cityid,c.cityname,c.goldcoins, bt.buildingname from CityBuilding cb
Inner join City c on c.CityId = cb.cityid
Inner join BuildingType bt on bt.buildingId = cb.BuildingId
where cb.cityid = 4


