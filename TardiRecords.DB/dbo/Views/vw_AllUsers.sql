
CREATE VIEW [dbo].[vw_AllUsers]
AS
SELECT NU.Id AS AspNetUserId, AU.id AS AppUserId, NU.Email, AU.firstName, AU.lastName
FROM AspNetUsers NU INNER JOIN AppUsers AU ON NU.Id=AU.aspNetUserId