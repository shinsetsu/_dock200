/****** Script for SelectTopNRows command from SSMS  ******/









--+=	Add equals
---=	Subtract equals
--*=	Multiply equals
--/=	Divide equals
--%=	Modulo equals
--&=	Bitwise AND equals
--^-=	Bitwise exclusive equals
--|*=	Bitwise OR equals

--ALL	TRUE if all of the subquery values meet the condition	
--AND	TRUE if all the conditions separated by AND is TRUE	
--ANY	TRUE if any of the subquery values meet the condition	
--BETWEEN	TRUE if the operand is within the range of comparisons	
--EXISTS	TRUE if the subquery returns one or more records	
--IN	TRUE if the operand is equal to one of a list of expressions	
--LIKE	TRUE if the operand matches a pattern	
--NOT	Displays a record if the condition(s) is NOT TRUE	
--OR	TRUE if any of the conditions separated by OR is TRUE	
--SOME	TRUE if any of the subquery values meet the condition




CREATE DATABASE databasename;
DROP DATABASE databasename;
BACKUP DATABASE databasename TO DISK = 'filepath';
CREATE TABLE table_name (    column1 datatype,    column2 datatype,    column3 datatype,   ....);
DROP TABLE table_name;
CREATE TABLE Persons (    ID int NOT NULL,    LastName varchar(255) NOT NULL,    FirstName varchar(255),    Age int,    CHECK (Age>=18));
CREATE INDEX index_nameON table_name (column1, column2, ...);



SELECT *  FROM _d200.dbo.shinSiteMetrics

SELECT  *  FROM _d200.dbo.shinIps2



SELECT  count(TABLE_NAME) as "_d200TblCount" FROM   _d200.INFORMATION_SCHEMA.TABLES T1 where T1.TABLE_NAME != '__EFMigrationsHistory'



SELECT  * FROM   _d200.INFORMATION_SCHEMA.TABLES T1 where T1.TABLE_NAME != '__EFMigrationsHistory'




