CREATE DATABASE scc_management

USE scc_management

-- TABLE
CREATE TABLE category (
	category_id   VARCHAR(20)  CONSTRAINT category_id_PK     PRIMARY KEY 
							   CONSTRAINT category_id_len_CK CHECK(LEN(category_id) >= 6),
	category_name NVARCHAR(60) CONSTRAINT category_name_UNIX UNIQUE NOT NULL					
)

CREATE TABLE manufacturer (
	manufacturer_id   VARCHAR(20)  CONSTRAINT manufacturer_id_PK     PRIMARY KEY
								   CONSTRAINT manufacturer_id_len_CK CHECK(LEN(manufacturer_id) >= 6),
	manufacturer_name NVARCHAR(60) CONSTRAINT manufacturer_name_UNIX UNIQUE NOT NULL					   
)

CREATE TABLE product (
	product_id			VARCHAR(20) CONSTRAINT product_id_PK              PRIMARY KEY 
									CONSTRAINT product_id_len_CK          CHECK(LEN(product_id) >= 6),
	product_name		VARCHAR(60) CONSTRAINT product_name_UNIX          UNIQUE NOT NULL,
	category_id			VARCHAR(20) CONSTRAINT product_category_id_FK     FOREIGN KEY REFERENCES category(category_id),
	manufacturer_id		VARCHAR(20) CONSTRAINT product_manufacturer_id_FK FOREIGN KEY REFERENCES manufacturer(manufacturer_id),
	unit_price			FLOAT       CONSTRAINT unit_price_CK              CHECK(unit_price > 0),
	stock				INT         CONSTRAINT stock_CK                   CHECK(stock >= 0),
	product_description NTEXT,
	picture_path        VARCHAR(100)
)

CREATE TABLE account (
	account_id       VARCHAR(8)   CONSTRAINT account_id_PK       PRIMARY KEY,	-- ID FORMAT : USER/AD + (LEFT(REPLACE(NEWID(),'-',''),4))
	account_username VARCHAR(60)  CONSTRAINT account_username_CK UNIQUE NOT NULL,
	account_email    VARCHAR(254) CONSTRAINT account_email_UNIX  UNIQUE NOT NULL,
	account_password VARCHAR(15)  NOT NULL,
	account_role     VARCHAR(5)   NOT NULL,
	account_banned   BIT
)

EXEC sp_rename 'account_username_CK', 'account_username_UNIX'

ALTER TABLE account
ADD CONSTRAINT account_username_len_CK CHECK(LEN(account.account_username) >= 6)

ALTER TABLE account
ADD CONSTRAINT account_password_len_CK CHECK(LEN(account.account_password) >= 8)

CREATE TABLE personal_info (
	account_id  VARCHAR(8)   CONSTRAINT personal_info_account_id_PK PRIMARY KEY,				
	fullname    NVARCHAR(60) NOT NULL,
	birthday    DATE,
	phonenumber VARCHAR(15),
	gender      NVARCHAR(3) 
)

CREATE TABLE account_order (
	account_order_id VARCHAR(15) CONSTRAINT account_order_id_PK         PRIMARY KEY  -- (LEFT(REPLACE(NEWID(),'-',''),15)
	                             CONSTRAINT account_order_id_len_CK     CHECK(LEN(account_order_id) >= 6),
	account_id       VARCHAR(8)  CONSTRAINT account_order_account_id_FK FOREIGN KEY REFERENCES account(account_id),
	order_date       DATE NOT NULL,
	canceled         BIT
)

CREATE TABLE order_details (
	account_order_id VARCHAR(15) CONSTRAINT order_details_account_order_id_FK FOREIGN KEY REFERENCES account_order(account_order_id),
	product_id       VARCHAR(20) CONSTRAINT order_details_product_id_FK       FOREIGN KEY REFERENCES product(product_id),
	quantity         INT         CONSTRAINT quantity_CK                       CHECK(quantity > 0)
	CONSTRAINT order_details_id_PK PRIMARY KEY(account_order_id, product_id)
)
GO

-- FUNCTION
CREATE OR ALTER FUNCTION dbo.personal_info_account_id_in_account_tbl
(@account_id VARCHAR(8))
RETURNS BIT
AS
BEGIN
	IF(@account_id IN (SELECT account.account_id FROM account WHERE account.account_role = 'user'))
		RETURN 1

	RETURN 0
END
GO

ALTER TABLE personal_info
ADD CONSTRAINT personal_info_account_id_CK CHECK(dbo.personal_info_account_id_in_account_tbl(personal_info.account_id) = 1)
GO

ALTER TABLE personal_info
ADD CONSTRAINT personal_info_phonenumber_UNIX UNIQUE(phonenumber)
GO

-- PROCEDURE
CREATE OR ALTER PROCEDURE dbo.personal_info_delete_proc(@account_id VARCHAR(8)) AS
BEGIN
	DELETE FROM personal_info WHERE account_id = @account_id
END
GO

-- TRIGGER
CREATE OR ALTER TRIGGER account_table_delete_TRGR ON account FOR DELETE AS
BEGIN
	DECLARE @account_id VARCHAR(8)
	SET @account_id = (SELECT account_id FROM deleted)
	EXECUTE dbo.personal_info_delete_proc @account_id
END
GO

CREATE OR ALTER TRIGGER account_order_delete_TRGR ON account_order FOR DELETE AS 
BEGIN
	PRINT('Cannot delete rows in table account_order')
	ROLLBACK TRAN 
END
GO

CREATE OR ALTER TRIGGER order_details_delete_TRGR ON order_details FOR DELETE AS 
BEGIN
	PRINT('Cannot delete rows in table order_details')
	ROLLBACK TRAN 
END
GO

DISABLE TRIGGER account_order_delete_TRGR ON account_order GO
DISABLE TRIGGER order_details_delete_TRGR ON order_details GO

ENABLE TRIGGER account_order_delete_TRGR ON account_order GO
ENABLE TRIGGER order_details_delete_TRGR ON order_details GO

/*
-- TABLES THAT AUTO CREATE ON APP

CREATE TABLE <category_id>_spec_name (
	spec_column_id      VARCHAR(6)  CONSTRAINT spec_column_id_PK     PRIMARY KEY, -- id is column's name in table <category_id>_specifications excluding product_id
	alternative_name    VARCHAR(60) CONSTRAINT alternative_name_UNIX UNIQUE NOT NULL,
)

CREATE TABLE <category_id>_specifications (
	product_id VARCHAR(20) CONSTRAINT <category_id>_specifications_id_PK         PRIMARY KEY
						   CONSTRAINT <category_id>_specifications_product_id_FK FOREIGN KEY REFERENCES product(product_id),
	spec_1     VARCHAR(60),
	spec_2     VARCHAR(60),
	...
	spec_n     VARCHAR(60)
)

*/

INSERT INTO account VALUES ('USER0001', 'Nguyen A', 'user0001@gmail.com', '12345789', 'admin', 0)

INSERT INTO account VALUES ('USER0001', 'Nguyen A', 'user0001@gmail.com', '12345', 'user', 0)
INSERT INTO personal_info VALUES ('USER0001', N'Nguyễn Văn A', '1999/01/01', '09123456789', N'Nam')

SELECT * FROM account, personal_info WHERE account.account_id = personal_info.account_id

SELECT * FROM account
SELECT * FROM personal_info

DELETE FROM account WHERE account_id = 'USER6C76'

SELECT * FROM (SELECT LEFT(REPLACE(NEWID(),'-',''),10) AS [ID]) AS RandomID WHERE ID LIKE '%1%'


INSERT INTO category VALUES('CPU001', N'Vi xử lý')
INSERT INTO category VALUES('VGA001', N'Card đồ họa')

SELECT * FROM category

INSERT INTO manufacturer VALUES('HSX_INTEL', N'Intel');
INSERT INTO manufacturer VALUES('HSX_NVIDIA', N'Nvidia');

SELECT * FROM manufacturer

INSERT INTO product VALUES('CPUI448', 'CPU INTEL CORE I5-12400F', 'CPU001', 'HSX_INTEL', 3499000, 100, 
N'CPU Intel Core i5-12400F là CPU thế hệ thứ 12 của Intel (Alder Lake) trên nền Socket LGA 1700 với kiến trúc hoàn toàn mới cho hiệu năng vượt trội so với người tiền nhiệm.', 'cpu1.jpg');

INSERT INTO product VALUES('VGAS740', 'ASUS ROG MATRIX PLATINUM GEFORCE RTX 4090', 'VGA001', 'HSX_NVIDIA', 88799000, 100, 
N'ROG Matrix GeForce RTX 4090 mang đến hiệu năng đỉnh cao tuyệt đối mà vẫn đảm bảo hoạt động nhiệt độ ổn định.', 'vga1.jpg');

SELECT * FROM product

CREATE TABLE CPU001_specifications (
	product_id VARCHAR(20) CONSTRAINT CPU001_specifications_id_PK         PRIMARY KEY
						   CONSTRAINT CPU001_specifications_product_id_FK FOREIGN KEY REFERENCES product(product_id),
	spec_1 VARCHAR(20),
	spec_2 VARCHAR(10),
	spec_3 INT,
	spec_4 INT
)

INSERT INTO CPU001_specifications VALUES('CPUI448', 'LGA 1700', '4.4GHz', 6, 12)

CREATE TABLE CPU001_spec_name (
	spec_column_id      VARCHAR(10)  CONSTRAINT CPU001_spec_column_id_PK     PRIMARY KEY,
	alternative_name    NVARCHAR(60) CONSTRAINT CPU001_alternative_name_UNIX UNIQUE NOT NULL,
)

INSERT INTO CPU001_spec_name 
VALUES
	('spec_1', N'Socket'),
	('spec_2', N'Xung nhịp tối đa'),
	('spec_3', N'Số nhân'),
	('spec_4', N'Số luồng')

SELECT * FROM CPU001_specifications
SELECT * FROM CPU001_spec_name ORDER BY spec_column_id


CREATE TABLE VGA001_specifications (
	product_id VARCHAR(20) CONSTRAINT VGA001_specifications_id_PK         PRIMARY KEY
						   CONSTRAINT VGA001_specifications_product_id_FK FOREIGN KEY REFERENCES product(product_id),
	spec_1 VARCHAR(60),
	spec_2 VARCHAR(30),
	spec_3 VARCHAR(30),
	spec_4 VARCHAR(30),
	spec_5 VARCHAR(10)
)

INSERT INTO VGA001_specifications VALUES('VGAS740', 'NVIDIA GeForce RTX 4090', 'PCI Express 4.0', 'OpenGL 4.6', '24 GB GDDR6X', '1000W')

CREATE TABLE VGA001_spec_name (
	spec_column_id      VARCHAR(10)  CONSTRAINT VGA001_spec_column_id_PK     PRIMARY KEY,
	alternative_name    NVARCHAR(60) CONSTRAINT VGA001_alternative_name_UNIX UNIQUE NOT NULL,
)

INSERT INTO VGA001_spec_name 
VALUES
	('spec_1', N'Nhân đồ họa'),
	('spec_2', N'Bus tiêu chuẩn'),
	('spec_3', N'OpenGL'),
	('spec_4', N'Bộ nhớ Video'),
	('spec_5', N'Nguồn khuyến nghị')

SELECT * FROM VGA001_specifications
SELECT * FROM VGA001_spec_name ORDER BY spec_column_id

SELECT * FROM product, CPU001_specifications
WHERE product.product_id = CPU001_specifications.product_id

SELECT * FROM product, VGA001_specifications
WHERE product.product_id = VGA001_specifications.product_id

SELECT * FROM product, category, manufacturer WHERE product.category_id = category.category_id AND product.manufacturer_id = manufacturer.manufacturer_id;

SELECT * FROM product
WHERE product_name LIKE N'%CPU%';