
https://docs.efproject.net/en/latest/miscellaneous/configuring-dbcontext.html
https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-entity-framework-row-level-security/
https://docs.asp.net/en/latest/fundamentals/middleware.html#writing-middleware
https://docs.efproject.net/en/latest/platforms/aspnetcore/existing-db.html#reverse-engineer-your-model
https://docs.asp.net/en/latest/tutorials/first-web-api.html#register-the-repository

Deploy the database project, and then run the SampleData.sql script against the deployed database.
Use the following statement to impersonate a local user on the database:
ALTER SECURITY POLICY [Security].[AuthorizationHierarchy] WITH ( STATE = ON );

