ALTER Procedure UpdateGold
@CityID as Varchar
AS
BEGIN
UPDATE City
	SET GoldCoins = (Select GoldCoins 
						FROM City 
						WHERE Cityid = @CityID) + 1
		WHERE CityId = @CityID
END


