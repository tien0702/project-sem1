drop database if exists salesSystem;

create database if not exists salesSystem;

use salesSystem;

create table Cashier(
	cashierId int primary key auto_increment,
    userName varchar(30) not null,
    password varchar(100) not null,
    role int not null,
    firstName varchar(25),
    midlleName varchar(25),
    lastName varchar(25),
    phone varchar(11) unique,
    email varchar(50) unique,
    address varchar(150)
);
insert into Cashier(userName, password, role, firstName, midlleName, lastName, phone, email, address) values
				('Administrator', 'ec876c82eca6bf0024fc9d37569541e1', 1, 'Admin', '', '', '', '', ''),
                -- AdiminPF13
                ('Tientv', '928c29958130e9ee161059b4ee24bfc5', 2, 'Tiến', 'Văn', 'Trần', '01234567899', 'tientv@gmail.com', 'Thanh Hoá'),
                -- TienPF13
                ('Phucvv', '99feb164738b42ba9f03fdc7d1024afe', 2, 'Phúc', 'Văn', 'Vũ', '01478523699', 'phucvv@gmail.com', 'Hà Nội'),
                -- PhucPF13
                ('Phuocmh', '2918b929ee36abcbc26a0b52da2651af', 2, 'Phước', 'Hồng', 'Mạc', '09874563211', 'phuocmh@gmail.com', 'Hà Nội');
                -- PhuocPF13
                
			
select *from Cashier where userName = 'Administrator' and password='ec876c82eca6bf0024fc9d37569541e1';
create table Invoice(
	invoice_no int primary key,
    invoice_cashierId int not null,
	foreign key(invoice_cashierId) references Cashier(cashierId),
    date datetime not null,
    total_due numeric,
    status int not null,
    payment_method int not null,
    note varchar(50)
);
create table Category(
	category_id int auto_increment primary key not null,
    category_name varchar(150),
    is_active boolean
);
insert into Category(category_name, is_active) values 
			('Trà Sữa', true),
            ('Fresh Fruit Tea', true),
            ('Macchiato', true),
            ('Special Drink', true),
            ('Beauty Drinks', true);

select *from Category;

create table Topping(
	topping_id int auto_increment primary key not null,
    topping_name varchar(250) not null,
    unit_price numeric not null,
    is_active boolean
);
insert into Topping(topping_name, unit_price, is_active) values 
			('Trân Châu Sương Mai', 9000, true),
            ('Hạt Dẻ', 8000, true),
            ('Trân Châu Baby', 8000, true),
            ('Cream Cake', 9000, true),
            ('Khoai Môn', 9000, true),
            ('Trân Châu Hoàng Kim', 9000, true),
            ('Thạch Băng Tuyết', 8000, true),
            ('Machiato', 9000, true),
            ('Pudding', 8000, true),
            ('Rau Câu', 8000, true),
            ('Thạch Cafe', 8000, true),
            ('Trân Châu Sợi', 8000, true),
            ('Đậu Đỏ', 8000, true),
            ('Trân Châu Ruby', 8000, true);

select *from Topping;

create table Type(
	type_id int primary key,
    type_value varchar(40) not null
);

insert into Type(type_id, type_value) values 
				(1, 'Làm Nóng'), -- Làm nóng
                (2, 'Làm Lạnh'); -- Làm Lạnh
create table Sugar(
	sugar_id int not null primary key,
    percent varchar(50) not null
);

insert into Sugar(sugar_id, percent) values
				(1, 'Không Đường'), -- Không đường
                (2, '30% Đường'), -- 30%
                (3, '50% Đường'), -- 50%
                (4, '70% Đường'), -- 70%
                (5, '100% Đường'); -- 100% Đường
                
                
create table Ice(
	ice_id int not null primary key,
    percent varchar(50) not null
);

insert into Ice(ice_id, percent) values 
				(1, 'Không Đá Mát'), -- Không đá - mát
                (2, '30% Đá'), -- 30%
                (3, '50% Đá'), -- 50%
                (4, '70% Đá'), -- 70%
                (5, '100% Đá'), -- 100%
                (6, 'Không Đá'), -- Không đá
                (7, 'Làm Nóng'); -- Làm nóng

create table Product(
	product_id int auto_increment primary key not null,
    product_category_id int not null,
    foreign key(product_category_id) references Category(category_id),
    product_name varchar(150) not null,
    unit_price double not null,
    quantity int not null,
    is_active boolean not null
);

insert into Product(product_category_id, product_name, quantity, is_active, unit_price) values
				-- Trà Sữa
					(1, 'Matcha Đậu Đỏ', '50', true, "25000"),                          -- 1
                    (1, 'Tiger Sugar', '50', true, "25000"),                            -- 2
                    (1, 'Sữa Tươi Khoai Môn Hoàng Kim', '50', true, "25000"),           -- 3                          
                    (1, 'Sữa Tươi Trân Châu Baby kem Cafe', '50', true, "25000"),       -- 4
                    (1, 'Ô Long Trân Châu Baby Kem Cafe', '50', true, "25000"),         -- 5
                    (1, 'Trà Xanh', '50', true, "25000"),                               -- 6
                    (1, 'Trà Sữa Ba Anh Em', '50', true, "25000"),                      -- 7
                    (1, 'Trà Xanh Sữa Vị Nhài', '50', true, "25000"),                   -- 8
                    (1, 'Trà Sữa Hạnh Phúc', '50', true, "25000"),                      -- 9
                    (1, 'Trà Sữa Matcha', '50', true, "25000"),                         -- 10
                    (1, 'Trà Sữa Ô Long', '50', true, "25000"),                         -- 11
                    (1, 'Ô Long Thái Cực', '50', true, "25000"),                        -- 12
                    (1, 'Trà Sữa Caramal Grilles 130', '50', true, "25000"),            -- 13
                    (1, 'Trà Sữa Khoai Môn Hoàng Kim', '50', true, "25000"),            -- 14
                    (1, 'Trà Sữa Dâu Tây', '50', true, "25000"),                        -- 15
                    (1, 'Trà Sữa Trân Châu Hoàng Gia', '50', true, "25000"),            -- 16
                    (1, 'Hồng Trà', '50', true, "25000"),                               -- 17
                    (1, 'Trà Sữa Panda', '50', true, "25000"),                          -- 18
                    (1, 'Trà Sữa Kim Cương Đen Okinawa', '50', true, "25000"),          -- 19
                    (1, 'Trà Sữa Socola', '50', true, "25000"),                         -- 20
                    (1, 'Trà Sữa Bạc Hà', '50', true, "25000"),                         -- 21
                    (1, 'Trà Sữa', '50', true, "25000"),                                -- 22
                -- Fresh Fruit Tea
                    (2, 'Trà Dứa Hồng Hạc', '50', true, "25000"),                       -- 23
                    (2, 'Probi Bưởi Trân Châu Sương Mai', '50', true, "25000"),         -- 24
                    (2, 'Probi Xoài Trân Châu Sương Mai', '50', true, "25000"),         -- 25
                    (2, 'Hồng Long Xoài Trân Châu Baby', '50', true, "25000"),          -- 26
                    (2, 'Trà Xanh Chanh Leo', '50', true, "25000"),                     -- 27
                    (2, 'Trà Xanh Xoài', '50', true, "25000"),                          -- 28
                    (2, 'Trà Dứa Nhiệt Đới', '50', true, "25000"),                      -- 29
                    (2, 'Hồng Long Pha Lê Tuyết', '50', true, "25000"),                 -- 30
                    (2, 'Hồng Long Bạch Ngọc', '50', true, "25000"),                    -- 31
                    (2, 'Hồng Trà Bưởi Mật Ong', '50', true, "25000"),                  -- 32
                -- Macchiato
                    (3, 'Ô Long Kem Phô Mai', '50', true, "25000"),                     -- 33
                    (3, 'Dâu Tằm Kem Phô Mai', '50', true, "25000"),                    -- 34
                    (3, 'Hồng Trà Kem Phô Mai', '50', true, "25000"),                   -- 35
                    (3, 'Trà Xanh Kem Phô Mai', '50', true, "25000"),                   -- 36
                    (3, 'Socola Kem Phô Mai', '50', true, "25000"),                     -- 37
                    (3, 'Matcha Kem Phô Mai', '50', true, "25000"),                     -- 38
                -- Special Drink
                    (4, 'Song Long Bạch Ngọc', '50', true, "48000"),                    -- 39
                    (4, 'Choco Creamcake Hạt Dẻ', '50', true, "25000"),                 -- 40
					(4, 'Ruby Creamcake Hạt Dẻ', '50', true, "25000"),                  -- 41
                    (4, 'Chanh Leo Trân Châu Sương Mai', '50', true, "25000"),          -- 42
                    (4, 'Probi Bưởi Trân Châu Sương Mai', '50', true, "25000"),         -- 43
                    (4, 'Probi Xoài Trân Châu Sương Mai', '50', true, "25000"),         -- 44
                    (4, 'Cream - Catcher Cafe', '50', true, "25000"),                   -- 45
                    (4, 'Energy - Booster Cafe', '50', true, "25000"),                  -- 46
                -- Beauty Drinks
                    (5, 'Sữa Chua Thanh Long Hạt Dẻ', '50', true, "42000"),             -- 47
                    (5, 'Sữa Chua Dâu Tằm Hoàng Kim', '50', true, "39000"),             -- 48
                    (5, 'Sữa Chua Dâu Tằm Hạt Dẻ', '50', true, "42000"),                -- 49
                    (5, 'Sữa Chua Trắng', '50', true, "32000");                         -- 50

create table ProductTypes(
	product_id int not null,
    type_id int not null,
    primary key(product_id, type_id),
    foreign key(product_id) references Product(product_id),
    foreign key(type_id) references Type(type_id)
);


insert into ProductTypes(product_id, type_id) value
		-- Trà Sữa
            -- Tiger Sugar                        1
                (1, 2), -- lạnh
            -- Matcha Đậu Đỏ                      2
                (2, 2), -- lạnh
            -- Sữa Tươi Khoai Môn Hoàng Kim       3
                (3, 1), -- nóng
                (3, 2), -- lạnh
            -- Sữa Tươi Trân Châu Baby kem Cafe   4
                (4, 2), -- lạnh
            -- Ô Long Trân Châu Baby Kem Cafe     5
                (5, 2), -- lạnh
            -- Trà Xanh                           6
                (6, 1), -- nóng
                (6, 2), -- lạnh
            --Trà Sữa Ba Anh Em                  7
                (7, 1), --nóng
                (7, 2), --lạnh
            -- Trà Xanh Sữa Vị Nhài               8
                (8, 1), -- nóng
                (8, 2), -- lạnh
            -- Trà Sữa Hạnh Phúc                  9
                (9, 1), -- nóng
                (9, 2), -- lạnh
            -- Trà Sữa Matcha                     10
                (10, 1), -- nóng
                (10, 2), -- lạnh
            -- Trà Sữa Ô Long                     11
                (11, 1), -- nóng
                (11, 2), -- lạnh
            -- Ô Long Thái Cực                    12
                (12, 1), -- nóng
                (12, 2), -- lạnh
            -- Trà Sữa Caramal Grilles 130        13
                (13, 1), -- nóng
                (13, 2), -- lạnh
            -- Trà Sữa Khoai Môn Hoàng Kim        14
                (14, 1), -- nóng
                (14, 2), -- lạnh
            -- Trà Sữa Bạc Hà                     15
                (15, 1), -- nóng
                (15, 2), -- lạnh
            -- Trà Sữa Dâu Tây                    16
                (16, 1), -- nóng
                (16, 2), -- lạnh
            -- Trà Sữa Trân Châu Hoàng Gia        17
                (17, 1), -- nóng
                (17, 2), -- lạnh
            -- Hồng Trà                           18
                (18, 1), -- nóng
                (18, 2), -- lạnh
            -- Trà Sữa Panda                      19
                (19, 1), -- nóng
                (19, 2), -- lạnh
            -- Trà Sữa Kim Cương Đen Okinawa      20
                (20, 1), -- nóng
                (20, 2), -- lạnh
            -- Trà Sữa Socola                     21
                (21, 1), -- nóng
                (21, 2), -- lạnh
            -- Trà Sữa                            22
                (22, 1), -- nóng
                (22, 2), -- lạnh
        -- Fresh Fruit Tea
            -- Trà Dứa Hồng Hạc                  23
                (23, 2), -- lạnh
            -- Hồng Long Xoài Trân Châu Baby     24
                (24, 2), -- lạnh
            -- Probi Bưởi Chân Châu Sương Mai    25
                (25, 2), -- lạnh
            -- Probi Xoài Trân Châu Sương Mai    26
                (26, 2), -- lạnh
            -- Trà Xanh Chanh Leo                27
                (27, 2), -- lạnh
            -- Trà Xanh Xoài                     28
                (28, 2), -- lạnh
            -- Trà Dứa Nhiệt Đới                 29
                (29, 2), -- lạnh
            -- Hồng Long Pha Lê Tuyết            30
                (30, 2), -- lạnh
            -- Hồng Long Bạch Ngọc               31
                (31, 2), -- lạnh
            -- Hồng Trà Bưởi Mật Ong             32
                (32, 1), -- nóng
                (32, 2), -- lạnh  
        -- Macchiato
            -- Ô Long Kem Phô Mai                 33
                (33, 2), -- lạnh
            -- Dâu Tằm Kem Phô Mai                34
                (34, 2), -- lạnh
            -- Hồng Trà Kem Phô Mai               35
                (35, 2), -- lạnh
            -- Trà Xanh Kem Phô Mai               36
                (36, 2), -- lạnh
            -- Socola Kem Phô Mai                 37
                (37, 2), -- lạnh
            -- Matcha Kem Phô Mai                 38
                (38, 2), -- lạnh
        -- Special Drink
            -- Song Long Bạch Ngọc                39
                (39, 2), -- lạnh
            -- Choco Creamcake Hạt Dẻ             40
                (40, 2), -- lạnh
            -- Ruby Creamcake Hạt Dẻ              41
                (41, 2), -- lạnh
            -- Chanh Leo Trân Châu Sương Mai      42
                (42, 2), -- lạnh
            -- Probi Bưởi Trân Châu Sương Mai     43
                (43, 2), -- lạnh
            -- Probi Xoài Trân Châu Sương Mai     44
                (44, 2), -- lạnh
            -- Cream - Catcher Cafe               45
                (45, 2), -- lạnh
            -- Energy - Booster Cafe              46
                (46, 2), -- lạnh
        -- Beauty Drinks
            -- Sữa Chua Thanh Long Hạt Dẻ         47
                (47, 2), -- lạnh
            -- Sữa Chua Dâu Tằm Hoàng Kim         48
                (48, 2), -- lạnh
            -- Sữa Chua Dâu Tằm Hạt Dẻ            49
                (49, 2), -- lạnh
            -- Sữa Chua Trắng                     50
                (50, 2); -- lạnh
create table ProductSugar(
	product_id int,
    sugar_id int,
    primary key (product_id, sugar_id),
    foreign key(product_id) references Product(product_id),
    foreign key(sugar_id) references Sugar(sugar_id)
); 
create table ProductIce(
	product_id int,
    ice_id int,
    primary key(product_id, ice_id),
    foreign key(product_id) references Product(product_id),
    foreign key(ice_id) references Ice(ice_id)
);
insert into ProductSugar(product_id, sugar_id) values 
-- 1- Không đường, 2- 30%, 3- 50%, 4- 70%, 5- 100%
		-- Trà Sữa
            --Tiger Sugar                        1
                (1, 4), -- 70%
                (1, 5), -- 100%
            -- Matcha Đậu Đỏ                      2
                (2, 1), -- 0%
                (2, 2), -- 30%
                (2, 3), -- 50%
                (2, 4), -- 70%
                (2, 5), -- 100%
            -- Sữa Tươi Khoai Môn Hoàng Kim       3
                (3, 4), -- 70%
                (3, 5), -- 100%
            -- Sữa Tươi Trân Châu Baby kem Cafe   4
                (4, 1), -- 0%
                (4, 2), -- 30%
                (4, 3), -- 50%
                (4, 4), -- 70%
                (4, 5), -- 100%
            -- Ô Long Trân Châu Baby Kem Cafe     5
                (5, 1), -- 0%
                (5, 2), -- 30%
                (5, 3), -- 50%
                (5, 4), -- 70%
                (5, 5), -- 100%
            -- Trà Xanh                           6
                (6, 1), -- 0%
                (6, 2), -- 30%
                (6, 3), -- 50%
                (6, 4), -- 70%
                (6, 5), -- 100%
            -- Trà Sữa Ba Anh Em                  7
                (7, 1), -- 0%
                (7, 2), -- 30%
                (7, 3), -- 50%
                (7, 4), -- 70%
                (7, 5), -- 100%
            -- Trà Xanh Sữa Vị Nhài               8
                (8, 1), -- 0%
                (8, 2), -- 30%
                (8, 3), -- 50%
                (8, 4), -- 70%
                (8, 5), -- 100%
            -- Trà Sữa Hạnh Phúc                  9
                (9, 1), -- 0%
                (9, 2), -- 30%
                (9, 3), -- 50%
                (9, 4), -- 70%
                (9, 5), -- 100%
            -- Trà Sữa Matcha                     10
                (10, 1), -- 0%
                (10, 2), -- 30%
                (10, 3), -- 50%
                (10, 4), -- 70%
                (10, 5), -- 100%
            -- Trà Sữa Ô Long                     11
                (11, 1), -- 0%
                (11, 2), -- 30%
                (11, 3), -- 50%
                (11, 4), -- 70%
                (11, 5), -- 100%
            -- Ô Long Thái Cực                    12
                (12, 1), -- 0%
                (12, 2), -- 30%
                (12, 3), -- 50%
                (12, 4), -- 70%
                (12, 5), -- 100%
            -- Trà Sữa Caramal Grilles 130        13
                (13, 4), -- 70%
                (13, 5), -- 100%
            -- Trà Sữa Khoai Môn Hoàng Kim        14
                (14, 1), -- 0%
                (14, 2), -- 30%
                (14, 3), -- 50%
                (14, 4), -- 70%
                (14, 5), -- 100%
            -- Trà Sữa Bạc Hà                     15
                (15, 4), -- 70%
                (15, 5), -- 100%
            -- Trà Sữa Dâu Tây                    16
                (16, 1), -- 0%
                (16, 2), -- 30%
                (16, 3), -- 50%
                (16, 4), -- 70%
                (16, 5), -- 100%
            -- Trà Sữa Trân Châu Hoàng Gia        17
                (17, 1), -- 0%
                (17, 2), -- 30%
                (17, 3), -- 50%
                (17, 4), -- 70%
                (17, 5), -- 100%
            -- Hồng Trà                           18
                (18, 1), -- 0%
                (18, 2), -- 30%
                (18, 3), -- 50%
                (18, 4), -- 70%
                (18, 5), -- 100%
            -- Trà Sữa Panda                      19
                (19, 1), -- 0%
                (19, 2), -- 30%
                (19, 3), -- 50%
                (19, 4), -- 70%
                (19, 5), -- 100%
            -- Trà Sữa Kim Cương Đen Okinawa      20
                (20, 4), -- 70%
                (20, 5), -- 100%
            -- Trà Sữa Socola                     21
                (21, 1), -- 0%
                (21, 2), -- 30%
                (21, 3), -- 50%
                (21, 4), -- 70%
                (21, 5), -- 100%
            -- Trà Sữa                            22
                (22, 1), -- 0%
                (22, 2), -- 30%
                (22, 3), -- 50%
                (22, 4), -- 70%
                (22, 5), -- 100%
        -- Fresh Fruit Tea
            --Trà Dứa Hồng Hạc                  23
                (23, 1), -- 0%
                (23, 2), -- 30%
                (23, 3), -- 50%
                (23, 4), -- 70%
                (23, 5), -- 100%
            -- Hồng Long Xoài Trân Châu Baby     24
                (24, 2), -- 30%
                (24, 3), -- 50%
                (24, 4), -- 70%
                (24, 5), -- 100%
            -- Probi Bưởi Chân Châu Sương Mai    25
                (25, 1), -- 0%
                (25, 2), -- 30%
                (25, 3), -- 50%
                (25, 4), -- 70%
                (25, 5), -- 100%
            -- Probi Xoài Trân Châu Sương Mai    26
                (26, 1), -- 0%
                (26, 2), -- 30%
                (26, 3), -- 50%
                (26, 4), -- 70%
                (26, 5), -- 100%
            -- Trà Xanh Chanh Leo                27
                (27, 1), -- 0%
                (27, 2), -- 30%
                (27, 3), -- 50%
                (27, 4), -- 70%
                (27, 5), -- 100%
            -- Trà Xanh Xoài                     28
                (28, 1), -- 0%
                (28, 2), -- 30%
                (28, 3), -- 50%
                (28, 4), -- 70%
                (28, 5), -- 100%
            -- Trà Dứa Nhiệt Đới                 29
                (29, 1), -- 0%
                (29, 2), -- 30%
                (29, 3), -- 50%
                (29, 4), -- 70%
                (29, 5), -- 100%
            -- Hồng Long Pha Lê Tuyết            30
                (30, 5), -- 100%
            -- Hồng Long Bạch Ngọc               31
                (31, 5), -- 100%
            -- Hồng Trà Bưởi Mật Ong             32
                (32, 1), -- 0%
                (32, 2), -- 30%
                (32, 3), -- 50%
                (32, 4), -- 70%
                (32, 5), -- 100% 
        -- Macchiato
            -- Ô Long Kem Phô Mai                 33
                (33, 1), -- 0%
                (33, 2), -- 30%
                (33, 3), -- 50%
                (33, 4), -- 70%
                (33, 5), -- 100% 
            -- Dâu Tằm Kem Phô Mai                34
                (34, 1), -- 0%
                (34, 2), -- 30%
                (34, 3), -- 50%
                (34, 4), -- 70%
                (34, 5), -- 100% 
            -- Hồng Trà Kem Phô Mai               35
                (35, 1), -- 0%
                (35, 2), -- 30%
                (35, 3), -- 50%
                (35, 4), -- 70%
                (35, 5), -- 100% 
            -- Trà Xanh Kem Phô Mai               36
                (36, 4), -- 70%
                (36, 5), -- 100%
            -- Socola Kem Phô Mai                 37
                (37, 1), -- 0%
                (37, 2), -- 30%
                (37, 3), -- 50%
                (37, 4), -- 70%
                (37, 5), -- 100% 
            -- Matcha Kem Phô Mai                 38
                (38, 1), -- 0%
                (38, 2), -- 30%
                (38, 3), -- 50%
                (38, 4), -- 70%
                (38, 5), -- 100% 
        -- Special Drink
            -- Song Long Bạch Ngọc                39
                (39, 1), -- 0%
                (39, 2), -- 30%
                (39, 3), -- 50%
                (39, 4), -- 70%
                (39, 5), -- 100%
            -- Choco Creamcake Hạt Dẻ             40
                (40, 1), -- 0%
                (40, 2), -- 30%
                (40, 3), -- 50%
                (40, 4), -- 70%
                (40, 5), -- 100%
            -- Ruby Creamcake Hạt Dẻ              41
                (41, 1), -- 0%
                (41, 2), -- 30%
                (41, 3), -- 50%
                (41, 4), -- 70%
                (41, 5), -- 100%
            -- Chanh Leo Trân Châu Sương Mai      42
                (42, 5), -- 100%
            -- Probi Bưởi Trân Châu Sương Mai     43
                (43, 1), -- 0%
                (43, 2), -- 30%
                (43, 3), -- 50%
                (43, 4), -- 70%
                (43, 5), -- 100%
            -- Probi Xoài Trân Châu Sương Mai     44
                (44, 1), -- 0%
                (44, 2), -- 30%
                (44, 3), -- 50%
                (44, 4), -- 70%
                (44, 5), -- 100%
            -- Cream - Catcher Cafe               45
                (45, 4), --70%
                (45, 5)  --100%
            -- Energy - Booster Cafe              46
                (46, 4), -- 70%
                (46, 5); -- 100%
        -- Beauty Drinks
            -- Sữa Chua Thanh Long Hạt Dẻ         47
            -- Sữa Chua Dâu Tằm Hoàng Kim         48
            -- Sữa Chua Dâu Tằm Hạt Dẻ            49
            -- Sữa Chua Trắng                     50
            
insert into ProductIce(product_id, ice_id) values
-- 1- Không đá mát, 2- 30%, 3-50%, 4-70%, 5- 100%, 6- Không đá, 7-Làm nóng
				-- Trà Sữa
			-- Tiger Sugar                        1
                (1, 6), -- Không đá
                (1, 2), -- 30% đá
                (1, 3), -- 50% đá
                (1, 4), -- 70% đá
                (1, 5), -- 100% đá
                (1, 7), -- Làm nóng
            -- Matcha Đậu Đỏ                      2
                (2, 6), -- Không đá
                (2, 2), -- 30% đá
                (2, 3), -- 50% đá
                (2, 4), -- 70% đá
                (2, 5), -- 100% đá
                (2, 7), -- Làm nóng
            -- Sữa Tươi Khoai Môn Hoàng Kim       3
                (3, 6), -- Không đá
                (3, 3), -- 30% đá
                (3, 3), -- 50% đá
                (3, 4), -- 70% đá
                (3, 5), -- 100% đá
                (3, 7), -- Làm nóng
            -- Sữa Tươi Trân Châu Baby kem Cafe   4
                (4, 5), -- 100% đá
            -- Ô Long Trân Châu Baby Kem Cafe     5
                (5, 5), -- 100% đá
            -- Trà Xanh                           6
                (6, 6), -- Không đá
                (6, 2), -- 30% đá
                (6, 3), -- 50% đá
                (6, 4), -- 70% đá
                (6, 5), -- 100% đá
                (6, 7), -- Làm nóng
            -- Trà Sữa Ba Anh Em                  7
                (7, 6), -- Không đá
                (7, 2), -- 30% đá
                (7, 3), -- 50% đá
                (7, 4), -- 70% đá
                (7, 5), -- 100% đá
                (7, 7), -- Làm nóng
            -- Trà Xanh Sữa Vị Nhài               8
                (8, 6), -- Không đá
                (8, 2), -- 30% đá
                (8, 3), -- 50% đá
                (8, 4), -- 70% đá
                (8, 5), -- 100% đá
                (8, 7), -- Làm nóng
            -- Trà Sữa Hạnh Phúc                  9
                (9, 6), -- Không đá
                (9, 2), -- 30% đá
                (9, 3), -- 50% đá
                (9, 4), -- 70% đá
                (9, 5), -- 100% đá
                (9, 7), -- Làm nóng
            -- Trà Sữa Matcha                     10
                (10, 6), -- Không đá
                (10, 2), -- 30% đá
                (10, 3), -- 50% đá
                (10, 4), -- 70% đá
                (10, 5), -- 100% đá
                (10, 7), -- Làm nóng
            -- Trà Sữa Ô Long                     11
                (11, 6), -- Không đá
                (11, 2), -- 30% đá
                (11, 3), -- 50% đá
                (11, 4), -- 70% đá
                (11, 5), -- 100% đá
                (11, 7), -- Làm nóng
            -- Ô Long Thái Cực                    12
                (12, 6), -- Không đá
                (12, 2), -- 30% đá
                (12, 3), -- 50% đá
                (12, 4), -- 70% đá
                (12, 5), -- 100% đá
                (12, 7), -- Làm nóng
            -- Trà Sữa Caramal Grilles 130        13
                (13, 6), -- Không đá
                (13, 2), -- 30% đá
                (13, 3), -- 50% đá
                (13, 4), -- 70% đá
                (13, 5), -- 100% đá
                (13, 7), -- Làm nóng
            -- Trà Sữa Khoai Môn Hoàng Kim        14
                (14, 6), -- Không đá
                (14, 2), -- 30% đá
                (14, 3), -- 50% đá
                (14, 4), -- 70% đá
                (14, 5), -- 100% đá
                (14, 7), -- Làm nóng
            -- Trà Sữa Bạc Hà                     15
                (15, 6), -- Không đá
                (15, 2), -- 30% đá
                (15, 3), -- 50% đá
                (15, 4), -- 70% đá
                (15, 5), -- 100% đá
                (15, 7), -- Làm nóng
            -- Trà Sữa Dâu Tây                    16
                (16, 6), -- Không đá
                (16, 2), -- 30% đá
                (16, 3), -- 50% đá
                (16, 4), -- 70% đá
                (16, 5), -- 100% đá
                (16, 7), -- Làm nóng
            -- Trà Sữa Trân Châu Hoàng Gia        17
                (17, 6), -- Không đá
                (17, 2), -- 30% đá
                (17, 3), -- 50% đá
                (17, 4), -- 70% đá
                (17, 5), -- 100% đá
                (17, 7), -- Làm nóng
            -- Hồng Trà                           18
                (18, 6), -- Không đá
                (18, 2), -- 30% đá
                (18, 3), -- 50% đá
                (18, 4), -- 70% đá
                (18, 5), -- 100% đá
                (18, 7), -- Làm nóng
            -- Trà Sữa Panda                      19
                (19, 6), -- Không đá
                (19, 2), -- 30% đá
                (19, 3), -- 50% đá
                (19, 4), -- 70% đá
                (19, 5), -- 100% đá
                (19, 7), -- Làm nóng
            -- Trà Sữa Kim Cương Đen Okinawa      20
                (20, 6), -- Không đá
                (20, 2), -- 30% đá
                (20, 3), -- 50% đá
                (20, 4), -- 70% đá
                (20, 5), -- 100% đá
                (20, 7), -- Làm nóng
            -- Trà Sữa Socola                     21
                (21, 6), -- Không đá
                (21, 2), -- 30% đá
                (21, 3), -- 50% đá
                (21, 4), -- 70% đá
                (21, 5), -- 100% đá
                (21, 7), -- Làm nóng
            -- Trà Sữa                            22
                (22, 6), -- Không đá
                (22, 2), -- 30% đá
                (22, 3), -- 50% đá
                (22, 4), -- 70% đá
                (22, 5), -- 100% đá
                (22, 7), -- Làm nóng
        -- Fresh Fruit Tea
            -- Trà Dứa Hồng Hạc                   23
                (23, 6), -- Không đá
                (23, 2), -- 30% đá
                (23, 3), -- 50% đá
                (23, 4), -- 70% đá
                (23, 5), -- 100% đá
                (23, 7), -- Làm nóng
            -- Hồng Long Xoài Trân Châu Baby      24
                (24, 5), -- 100% đá
            -- Probi Bưởi Chân Châu Sương Mai     25
                (25, 6), -- Không đá
                (25, 2), -- 30% đá
                (25, 3), -- 50% đá
                (25, 4), -- 70% đá
                (25, 5), -- 100% đá
                (25, 7), -- Làm nóng
            -- Probi Xoài Trân Châu Sương Mai     26
                (26, 6), -- Không đá
                (26, 2), -- 30% đá
                (26, 3), -- 50% đá
                (26, 4), -- 70% đá
                (26, 5), -- 100% đá
                (26, 7), -- Làm nóng
            -- Trà Xanh Chanh Leo                 27
                (27, 6), -- Không đá
                (27, 2), -- 30% đá
                (27, 3), -- 50% đá
                (27, 4), -- 70% đá
                (27, 5), -- 100% đá
                (27, 7), -- Làm nóng
            -- Trà Xanh Xoài                      28
                (28, 6), -- Không đá
                (28, 2), -- 30% đá
                (28, 3), -- 50% đá
                (28, 4), -- 70% đá
                (28, 5), -- 100% đá
                (28, 7), -- Làm nóng
            -- Trà Dứa Nhiệt Đới                  29
                (29, 6), -- Không đá
                (29, 2), -- 30% đá
                (29, 3), -- 50% đá
                (29, 4), -- 70% đá
                (29, 5), -- 100% đá
                (29, 7), -- Làm nóng
            -- Hồng Long Pha Lê Tuyết             30
                (30, 6), -- Không đá
                (30, 2), -- 30% đá
                (30, 3), -- 50% đá
                (30, 4), -- 70% đá
                (30, 5), -- 100% đá
                (30, 7), -- Làm nóng
            -- Hồng Long Bạch Ngọc                31
                (31, 6), -- Không đá
                (31, 2), -- 30% đá
                (31, 3), -- 50% đá
                (31, 4), -- 70% đá
                (31, 5), -- 100% đá
                (31, 7), -- Làm nóng
            -- Hồng Trà Bưởi Mật Ong              32
                (32, 6), -- Không đá
                (32, 2), -- 30% đá
                (32, 3), -- 50% đá
                (32, 4), -- 70% đá
                (32, 5), -- 100% đá
                (32, 7), -- Làm nóng
        -- Macchiat
            -- Ô Long Kem Phô Mai                 33
                (33, 4), -- 70% đá
                (33, 5), -- 100% đá
            -- Dâu Tằm Kem Phô Mai                34
                (34, 4), -- 70% đá
                (34, 5), -- 100% đá
            -- Hồng Trà Kem Phô Mai               35
                (35, 4), -- 70% đá
                (35, 5), -- 100% đá
            -- Trà Xanh Kem Phô Mai               36
                (36, 6), -- Không đá
                (36, 2), -- 30% đá
                (36, 3), -- 50% đá
                (36, 4), -- 70% đá
                (36, 5), -- 100% đá
                (36, 7), -- Làm nóng
            -- Socola Kem Phô Mai                 37
                (37, 4), -- 70% đá
                (37, 5), -- 100% đá
            -- Matcha Kem Phô Mai                 38
                (38, 6), -- Không đá
                (38, 4), -- 70% đá
                (38, 5), -- 100% đá
        -- Special Drink
            -- Song Long Bạch Ngọc                39
                (39, 5), -- 100% đá
            -- Choco Creamcake Hạt Dẻ             40
                (40, 5), -- 100% đá
            -- Ruby Creamcake Hạt Dẻ              41
                (41, 5), -- 100% đá
            -- Chanh Leo Trân Châu Sương Mai      42
                (42, 5), -- 100% đá
            -- Probi Bưởi Trân Châu Sương Mai     43
                (43, 6), -- Không đá
                (43, 2), -- 30% đá
                (43, 3), -- 50% đá
                (43, 4), -- 70% đá
                (43, 5), -- 100% đá
                (43, 7), -- Làm nóng
            -- Probi Xoài Trân Châu Sương Mai     44
                (44, 6), -- Không đá
                (44, 2), -- 30% đá
                (44, 3), -- 50% đá
                (44, 4), -- 70% đá
                (44, 5), -- 100% đá
                (44, 7), -- Làm nóng
            -- Cream - Catcher Cafe               45
                (45, 6), -- Không đá
                (45, 2), -- 30% đá
                (45, 3), -- 50% đá
                (45, 4), -- 70% đá
                (45, 5), -- 100% đá
                (45, 7), -- Làm nóng
            -- Energy - Booster Cafe              46
                (46, 6), -- Không đá
                (46, 2), -- 30% đá
                (46, 3), -- 50% đá
                (46, 4), -- 70% đá
                (46, 5), -- 100% đá
                (46, 7); -- Làm nóng 
        -- Beauty Drinks
            -- Sữa Chua Thanh Long Hạt Dẻ         47
            -- Sữa Chua Dâu Tằm Hoàng Kim         48
            -- Sữa Chua Dâu Tằm Hạt Dẻ            49
            -- Sữa Chua Trắng                     50 -- 
                        
create table InvoiceDetail(
	invoice_no int not null,
    product_id int not null,
    quantity int not null,
    unit_price numeric not null,
    primary key(invoice_no, product_id),
    foreign key(invoice_no) references Invoice(invoice_no),
    foreign key(product_id) references Product(product_id)
);

create table ProductToppings(
	product_id int,
    topping_id int,
    primary key(product_id, topping_id),
    foreign key(product_id) references Product(product_id),
    foreign key(topping_id) references Topping(topping_id)
);
insert into ProductToppings(product_id, topping_id) value 
			(1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7), (1, 8), (1, 9), (1, 10), (1, 11), (1, 12), (1, 13), (1, 14),  --
			(2, 1), (2, 2), (2, 3), (2, 4), (2, 5), (2, 6), (2, 7), (2, 8), (2, 9), (2, 10), (2, 11), (2, 12), (2, 13), (2, 14), --
			(3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (3, 7), (3, 8), (3, 9), (3, 10), (3, 11), (3, 12), (3, 13), (3, 14),  --
			(4, 1), (4, 2), (4, 3), (4, 4), (4, 5), (4, 6), (4, 7), (4, 8), (4, 9), (4, 10), (4, 11), (4, 12), (4, 13), (4, 14),  --
			(5, 1), (5, 2), (5, 3), (5, 4), (5, 5), (5, 6), (5, 7), (5, 8), (5, 9), (5, 10), (5, 11), (5, 12), (5, 13), (5, 14),  --
			(6, 1), (6, 2), (6, 3), (6, 4), (6, 5), (6, 6), (6, 7), (6, 8), (6, 9), (6, 10), (6, 11), (6, 12), (6, 13), (6, 14),  --
			(7, 1), (7, 2), (7, 3), (7, 4), (7, 5), (7, 6), (7, 7), (7, 8), (7, 9), (7, 10), (7, 11), (7, 12), (7, 13), (7, 14),  --
			(8, 1), (8, 2), (8, 3), (8, 4), (8, 5), (8, 6), (8, 7), (8, 8), (8, 9), (8, 10), (8, 11), (8, 12), (8, 13), (8, 14),  --
			(9, 1), (9, 2), (9, 3), (9, 4), (9, 5), (9, 6), (9, 7), (9, 8), (9, 9), (9, 10), (9, 11), (9, 12), (9, 13), (9, 14),  --
			(10, 1), (10, 2), (10, 3), (10, 4), (10, 5), (10, 6), (10, 7), (10, 8), (10, 9), (10, 10), (10, 11), (10, 12), (10, 13), (10, 14),  --
			(11, 1), (11, 2), (11, 3), (11, 4), (11, 5), (11, 6), (11, 7), (11, 8), (11, 9), (11, 10), (11, 11), (11, 12), (11, 13), (11, 14),  --
			(12, 1), (12, 2), (12, 3), (12, 4), (12, 5), (12, 6), (12, 7), (12, 8), (12, 9), (12, 10), (12, 11), (12, 12), (12, 13), (12, 14),  --
			(13, 1), (13, 2), (13, 3), (13, 4), (13, 5), (13, 6), (13, 7), (13, 8), (13, 9), (13, 10), (13, 11), (13, 12), (13, 13), (13, 14),  --
			(14, 1), (14, 2), (14, 3), (14, 4), (14, 5), (14, 6), (14, 7), (14, 8), (14, 9), (14, 10), (14, 11), (14, 12), (14, 13), (14, 14),  --
			(15, 1), (15, 2), (15, 3), (15, 4), (15, 5), (15, 6), (15, 7), (15, 8), (15, 9), (15, 10), (15, 11), (15, 12), (15, 13), (15, 14),  --
			(16, 1), (16, 2), (16, 3), (16, 4), (16, 5), (16, 6), (16, 7), (16, 8), (16, 9), (16, 10), (16, 11), (16, 12), (16, 13), (16, 14),  --
			(17, 1), (17, 2), (17, 3), (17, 4), (17, 5), (17, 6), (17, 7), (17, 8), (17, 9), (17, 10), (17, 11), (17, 12), (17, 13), (17, 14),  --
			(18, 1), (18, 2), (18, 3), (18, 4), (18, 5), (18, 6), (18, 7), (18, 8), (18, 9), (18, 10), (18, 11), (18, 12), (18, 13), (18, 14),  --
			(19, 1), (19, 2), (19, 3), (19, 4), (19, 5), (19, 6), (19, 7), (19, 8), (19, 9), (19, 10), (19, 11), (19, 12), (19, 13), (19, 14), --
			(20, 1), (20, 2), (20, 3), (20, 4), (20, 5), (20, 6), (20, 7), (20, 8), (20, 9), (20, 10), (20, 11), (20, 12), (20, 13), (20, 14),  --
			(21, 1), (21, 2), (21, 3), (21, 4), (21, 5), (21, 6), (21, 7), (21, 8), (21, 9), (21, 10), (21, 11), (21, 12), (21, 13), (21, 14),  --
			(22, 1), (22, 2), (22, 3), (22, 4), (22, 5), (22, 6), (22, 7), (22, 8), (22, 9), (22, 10), (22, 11), (22, 12), (22, 13), (22, 14);  --
create table InvoiceDetailTopping(
	invoice_no int not null,
    product_id int not null,
    topping_id int not null,
    quantity int not null,
    unit_price numeric,
    primary key(invoice_no, product_id, topping_id),
    foreign key(invoice_no) references Invoice(invoice_no),
    foreign key(product_id) references Product(product_id),
    foreign key(topping_id) references Topping(topping_id)
);

select *from Product, Topping, ProductToppings where (ProductToppings.product_id = 3) and (ProductToppings.topping_id = Topping.topping_id) and (Product.product_id = ProductToppings.product_id);
select *from Product, Type, ProductTypes where (ProductTypes.product_id = 3) and (ProductTypes.type_id = Type.type_id) and (Product.product_id = ProductTypes.product_id);
select *from Product, Sugar, ProductSugar where (ProductSugar.product_id = 3) and (ProductSugar.sugar_id = Sugar.sugar_id) and (Product.product_id = ProductSugar.product_id);
select *from Product, Ice, ProductIce where (ProductIce.product_id = 3) and (ProductIce.ice_id = Ice.ice_id) and (Product.product_id = ProductIce.product_id);


-- create user 'PF13vtca'@'localhost' identified by 'tienvtca';
-- grant all privileges on *.* to 'PF13vtca'@'localhost';