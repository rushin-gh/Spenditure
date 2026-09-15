--CREATE TABLE Expense
--(
--    id int PRIMARY KEY IDENTITY(1, 1),
--    title varchar(250) NOT NULL,
--    amount decimal(12, 3) NOT NULL,
--    [desc] varchar(1000),
--    createdAt datetime2(3) NOT NULL DEFAULT SYSDATETIME(),
--    createdBy varchar(100) NOT NULL,
--    modifiedAt datetime2(3),
--    modifiedBy varchar(100),
--    [status] bit NOT NULL DEFAULT 1
--);

--INSERT INTO Expense (title, amount, [desc], createdBy)
--VALUES
--('Electricity Bill', 2450.750, 'Monthly electricity bill', 'admin'),
--('Grocery Shopping', 1850.500, 'Weekly groceries and household items', 'admin'),
--('Internet Bill', 999.000, 'Monthly broadband bill', 'admin'),
--('Restaurant', 1250.250, 'Dinner with friends', 'john'),
--('Fuel', 2200.000, 'Car fuel expense', 'john'),
--('Mobile Recharge', 599.000, 'Monthly mobile recharge', 'admin'),
--('Amazon Purchase', 3499.990, 'Office accessories', 'john'),
--('Movie Tickets', 850.000, 'Movie tickets for two people', 'john'),
--('Water Bill', 450.500, 'Monthly water bill', 'admin'),
--('Cab', 675.750, 'Cab fare for office commute', 'john');

--select * from Expense;

--update expense
--set createdBy = 'system'
--where createdBy = 'admin'

--update expense
--set status = 0
--where id = 5