CREATE FUNCTION Security.fn_securityPredicate(@uid AS uniqueidentifier)
	RETURNS TABLE
WITH SCHEMABINDING
AS
RETURN 
	SELECT 1 as fn_securitypredicate_result
	from Security.[v_Authorization] A
	where A.uid = @uid AND CAST(SESSION_CONTEXT(N'UserId') AS nvarchar(100)) =  A.identifier;