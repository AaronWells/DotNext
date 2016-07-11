
CREATE view [Security].[v_Authorization] WITH SCHEMABINDING as
	SELECT U.identifier, A2.uid 
	from dbo.Users U 
	join dbo.UserAuthorization UA on U.id = UA.user_id 		
	join dbo.[Authorization] A1 on UA.authorization_id = A1.id
	join dbo.[Authorization] A2 on A2.node.IsDescendantOf(A1.node) = 1;