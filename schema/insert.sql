INSERT INTO [dbo].[Principal]
           ([Id]
           ,[Username]
           ,[CreateTime]
           ,[Version]
           ,[Password]
           ,[Email])
     VALUES
           ('FBE76230-FD68-4A88-B023-EB824D2AB9A8','su', SYSDATETIME(),1
           ,'26857F0074D5E2393884B7B1AA9EFC5E919D1111CEF6E3B06C13DBA5119CF882C317F8F4987A30E533EB786F138A876DF4B3258A195BEE819692600B7B6236BF'
           ,'su@user.com');
INSERT INTO [dbo].[User]
           ([Id]
           ,[FirstName]
           ,[LastName])
     VALUES
           ('FBE76230-FD68-4A88-B023-EB824D2AB9A8','su','su');


