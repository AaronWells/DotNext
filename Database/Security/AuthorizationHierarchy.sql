CREATE SECURITY POLICY [Security].[AuthorizationHierarchy]
    ADD FILTER PREDICATE [Security].[fn_securityPredicate]([uid]) ON [dbo].[People],
    ADD FILTER PREDICATE [Security].[fn_securityPredicate]([uid]) ON [dbo].[Schools],
    ADD FILTER PREDICATE [Security].[fn_securityPredicate]([uid]) ON [dbo].[Districts]
    WITH (STATE = OFF);

