CREATE SECURITY POLICY [Security].[AuthorizationHierarchy]
    ADD FILTER PREDICATE [Security].[fn_securityPredicate]([Uid]) ON [dbo].[People],
    ADD FILTER PREDICATE [Security].[fn_securityPredicate]([Uid]) ON [dbo].[Schools],
    ADD FILTER PREDICATE [Security].[fn_securityPredicate]([Uid]) ON [dbo].[Districts]
    WITH (STATE = OFF);

