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
    type_value int not null
);

insert into Type(type_id, type_value) values 
				(1, 1),
                (2, -1);
create table Sugar(
	sugar_id int not null primary key,
    percent float not null
);

insert into Sugar(sugar_id, percent) values
				(1, 1),
                (7, 0.7),
                (5, 0.5),
                (3, 0.3),
                (0, 0);
                
create table Ice(
	ice_id int not null primary key,
    percent float not null
);

insert into Ice(ice_id, percent) values 
				(0, 0),
                (3, 0.3),
                (5, 0.5),
                (7, 0.7),
                (1, 1),
                (2, -1);

create table Product(
	product_id int auto_increment primary key not null,
    product_category_id int not null,
    product_topping_id int not null default 1,
    foreign key(product_category_id) references Category(category_id),
    foreign key(product_topping_id) references Topping(topping_id),
    product_name varchar(150) not null,
    unit_price double not null,
    quantity int not null,
    is_active boolean not null
);

insert into Product(product_category_id, product_name, quantity, is_active, unit_price) values
					-- Trà Sữa
					(1, 'Matcha Đậu Đỏ', '50', true, "25000"),
                    (1, 'Tiger Sugar', '50', true, "25000"),
                    (1, 'Sữa Tươi Khoai Môn Hoàng Kim', '50', true, "25000"),
                    (1, 'Sữa Tươi Trân Châu Baby kem Cafe', '50', true, "25000"),
                    (1, 'Ô Long Trân Châu Baby Kem Cafe', '50', true, "25000"),
                    (1, 'Trà Xanh', '50', true, "25000"),
                    (1, 'Trà Sữa Hạnh Phúc', '50', true, "25000"),
                    (1, 'Trà Sữa Matcha', '50', true, "25000"),
                    (1, 'Trà Sữa Ô Long', '50', true, "25000"),
                    (1, 'Ô Long Thái Cực', '50', true, "25000"),
                    (1, 'Trà Sữa Caramal Grilles 130', '50', true, "25000"),
                    (1, 'Trà Sữa Khoai Môn Hoàng Kim', '50', true, "25000"),
                    (1, 'Trà Sữa Ba Anh Em', '50', true, "25000"),
                    (1, 'Trà Sữa Vị Nhài', '50', true, "25000"),
                    (1, 'Hồng Trà', '50', true, "25000"),
                    (1, 'Trà Sữa Panda', '50', true, "25000"),
                    (1, 'Matcha Đậu Đỏ', '50', true, "25000"),
                    (1, 'Trà Sữa Kim Cương Đen Okinawa', '50', true, "25000"),
                    (1, 'Trà Sữa Socola', '50', true, "25000"),
                    (1, 'Trà Sữa Bạc Hà', '50', true, "25000"),
                    (1, 'Trà Sữa Dâu Tây', '50', true, "25000"),
                    (1, 'Trà Sữa Trân Châu Hoàng Gia', '50', true, "25000"),
                    -- Fresh Fruit Tea
                    (2, 'Trà Dứa Hồng Hạc', '50', true, "25000"),
                    (2, 'Hồng Long Xoài Trân Châu Baby', '50', true, "25000"),
                    (2, 'Probi Bưởi Chân Châu Sương Mai', '50', true, "25000"),
                    (2, 'Probi Xoài Trân Châu Sương Mai', '50', true, "25000"),
                    (2, 'Trà Xanh Chanh Leo', '50', true, "25000"),
                    (2, 'Trà Xanh Xoài', '50', true, "25000"),
                    (2, 'Trà Dứa Nhiệt Đới', '50', true, "25000"),
                    (2, 'Hồng Long Pha Lê Tuyết', '50', true, "25000"),
                    (2, 'Hồng Long Bạch Ngọc', '50', true, "25000"),
                    (2, 'Hồng Trà Bưởi Mật Ong', '50', true, "25000"),
                    -- Macchiato
                    (3, 'Ô Long Kem Phô Mai', '50', true, "25000"),
                    (3, 'Dâu Tằm Kem Phô Mai', '50', true, "25000"),
                    (3, 'Hồng Trà Kem Phô Mai', '50', true, "25000"),
                    (3, 'Trà Xanh Kem Phô Mai', '50', true, "25000"),
                    (3, 'Socola Kem Phô Mai', '50', true, "25000"),
                    -- Special Drink
                    (4, 'Song Long Bạch Ngọc', '50', true, "48000"),
                    (4, 'Choco Creamcake Hạt Dẻ', '50', true, "25000"),
                    (4, 'Ruby Creamcake Hạt Dẻ', '50', true, "25000"),
                    (4, 'Chanh Leo Trân Châu Sương Mai', '50', true, "25000"),
                    -- Beauty Drinks
                    (5, 'Sữa Chua Thanh Long Hạt Dẻ', '50', true, "42000"),
                    (5, 'Sữa Chua Dâu Tằm Hoàng Kim', '50', true, "39000"),
                    (5, 'Sữa Chua Dâu Tằm Hạt Dẻ', '50', true, "42000"),
                    (5, 'Sữa Chua Trắng', '50', true, "32000");

create table ProductTypes(
	product_id int not null,
    type_id int not null,
    primary key(product_id, type_id),
    foreign key(product_id) references Product(product_id),
    foreign key(type_id) references Type(type_id)
);

insert into ProductTypes(product_id, type_id) value
			(1, 1);
            -- Matcha Đậu Đỏ

create table ProductSugar(
	product_id int,
    sugar_id int,
    primary key (product_id, sugar_id),
    foreign key(product_id) references Product(product_id),
    foreign key(sugar_id) references Sugar(sugar_id)
);
insert into ProductSugar(product_id, sugar_id) values 
			(1, 0),
            (1, 3),
            (1, 5),
            (1, 7),
            (1, 1); 
            -- Matcha Đậu Đỏ

create table ProductIce(
	product_id int,
    ice_id int,
    primary key(product_id, ice_id),
    foreign key(product_id) references Product(product_id),
    foreign key(ice_id) references Ice(ice_id)
);
insert into ProductIce(product_id, ice_id) values
						(1, 0), -- Không đá
						(1, 3), -- 30%
						(1, 5), -- 50%
						(1, 7), -- 70%
						(1, 1), -- 100%
						(1, 2); -- Làm nóng
                        -- Matcha Đậu Đỏ
select *from Product, Ice, ProductIce where Product.product_id = ProductIce.product_id and Ice.ice_id = ProductIce.ice_id;

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

-- create user 'PF13vtca'@'localhost' identified by 'tienvtca';
-- grant all privileges on *.* to 'PF13vtca'@'localhost';