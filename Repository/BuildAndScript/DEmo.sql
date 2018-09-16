USE TODO

GO

CREATE TABLE Product(
    Id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    Name nvarchar(255) NOT NULL,
    Price int NOTNULL,
    MainProduct int NOTNULL
)

CREATE TABLE MainProduct(
    Id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    Name nvarchar(255) NOT NULL,
)

INSERT INTO[dbo].Product
    ([Name], [Price], MainProduct)
VALUES
    ('Sofa', 1900, 2)


INSERT INTO[dbo].Product
    ([Name], [Price], MainProduct)
VALUES
    ('Pepsi', 10, 1)

INSERT INTO[dbo].Product
    ([Name], [Price], MainProduct)
VALUES
    ('Nike', 990, 3)


INSERT INTO[dbo].MainProduct
    ([Name])
VALUES
    ('Food')


INSERT INTO[dbo].MainProduct
    ([Name])
VALUES
    ('Funiture')


INSERT INTO[dbo].MainProduct
    ([Name])
VALUES
    ('Other')