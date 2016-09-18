update profilebasicinfo set age = CONVERT(int,ROUND(DATEDIFF(hour,DateOfBirth,GETDATE())/8766.0,0))

/*

DECLARE @dob  datetime
SET @dob='1992-01-09 00:00:00'

SELECT DATEDIFF(hour,@dob,GETDATE())/8766.0 AS AgeYearsDecimal
    ,CONVERT(int,ROUND(DATEDIFF(hour,@dob,GETDATE())/8766.0,0)) AS AgeYearsIntRound
    ,DATEDIFF(hour,@dob,GETDATE())/8766 AS AgeYearsIntTrunc

	select * from profilebasicinfo
	select CONVERT(int,ROUND(DATEDIFF(hour,DateOfBirth,GETDATE())/8766.0,0)) AS AgeYearsIntRound from profilebasicinfo*/

	update profilebasicinfo set age = CONVERT(int,ROUND(DATEDIFF(hour,DateOfBirth,GETDATE())/8766.0,0))