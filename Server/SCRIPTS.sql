create database QLBH;
use QLBH;
CREATE TABLE IF NOT EXISTS USERS(
    ID INT not null AUTO_INCREMENT,
    USERNAME VARCHAR(30) not null unique,
    PASS_WORD VARCHAR(20) not null,
    EMAIL VARCHAR(50) not null unique,
	Primary Key (ID)
);
CREATE TABLE IF NOT EXISTS USERS_DETAIL(
    ID INT not null AUTO_INCREMENT,
    ID_USERNAME INT not null,
    REAL_NAME VARCHAR(50) not null,
    PHONE_NUMBER VARCHAR(10) not null,
    ADDRESS VARCHAR(200) not null,
	Primary Key (ID)
);

CREATE TABLE IF NOT EXISTS PRODUCTS(
    ID INT not null AUTO_INCREMENT,
    CATEGORY VARCHAR(20) not null ,
    NAME_PRODUCT VARCHAR(100) not null,
    PRICE FLOAT not null, 
    SALE_PERCENT TINYINT,
    RATING NUMERIC(1),
    PRODUCT_DETAIL TEXT,
    IMAGE VARCHAR(200),
    Primary Key (ID)
);

CREATE TABLE IF NOT EXISTS ORDERS(
    ID INT not null AUTO_INCREMENT,
    ID_USER INT not null,
    ORDER_DATE DATETIME,
    CONFIRMATION NUMERIC(1) not null,
    Primary Key (ID)
);
CREATE TABLE IF NOT EXISTS ORDERS_DETAIL(
    ID INT not null AUTO_INCREMENT,
    ID_ORDER INT not null,
    ID_PRODUCT INT not null, 
    QUANTITY VARCHAR(200),
    Primary Key (ID)
);

ALTER TABLE users_detail ADD CONSTRAINT fk_user FOREIGN KEY(ID_USERNAME) REFERENCES users(ID);
ALTER TABLE orders ADD CONSTRAINT fk_order FOREIGN KEY(ID_USER) REFERENCES users(ID);
ALTER TABLE orders_detail ADD CONSTRAINT fk_order_detail_1 FOREIGN KEY(ID_ORDER) REFERENCES orders(ID);
ALTER TABLE orders_detail ADD CONSTRAINT fk_order_detail_2 FOREIGN KEY(ID_PRODUCT) REFERENCES product(ID);

/* Ví da */
INSERT INTO PRODUCT (CATEGORY,NAME_PRODUCT,PRICE,SALE_PERCENT,RATING,PRODUCT_DETAIL,IMAGE) 
 VALUES ('Ví da','Ví nam dáng ngang cổ điển VNTAN-31N',430000,5,4,
'Chất liệu da bò, da thật 100%,Màu sắc: Nâu,Kích thước: 9,5cm x 12cm,Kiểu dáng thời trang, đường viền độc đáo,
Bảo hành 12 tháng','VNTAN-31N_1.jpeg, VNTAN-31N_2.jpeg, VNTAN-31N_2.jpeg'),
 ('Ví da','Ví nam da cá sấu một mặt dáng ngang VTA990N-C-CF',990000,10,5,
'Thiết kế dáng ngang, gồm bộ phận chân cá sấu, Lớp lót da bò nguyên miếng,Màu sắc: Cafe,
 Kích thước: 9,5cm x 12cm, Sản xuất tại Đồ Da Tâm Anh, Bảo hành 12 tháng','VTA990N_1.jpeg, VTA990N_2.jpeg, VTA990N_2.jpeg'),
 ('Ví da','Ví da nam da đà điểu màu cafe VTA870N-CF',870000,12,4,
'Chất liệu mặt ngoài: Da đà điểu thật 100%, Chất liệu mặt trong: Da bò thật 100%, Kiểu dáng: Ví ngang,
Đường chỉ may tỉ mỉ, chắc chắn, Hoạ tiết vân da đẹp, màu sắc độc đáo lạ mắt, da mềm và bền gấp 5 lần các loại da khác cùng độ thoáng khí cao, 
Cấu tạo: Gồm 2 ngăn chính; 10 ngăn đựng thẻ, cmt, Màu: Cafe, Kích thước: 9cm x 12cm','VTA990N_1.jpeg, VTA990N_2.jpeg, VTA990N_2.jpeg'),
('Ví da','Ví da nam da đà điểu màu cafe VTA870N-CF',870000,12,4,
'Chất liệu mặt ngoài: Da đà điểu thật 100%, Chất liệu mặt trong: Da bò thật 100%, Kiểu dáng: Ví ngang,
Đường chỉ may tỉ mỉ, chắc chắn, Hoạ tiết vân da đẹp, màu sắc độc đáo lạ mắt, da mềm và bền gấp 5 lần các loại da khác cùng độ thoáng khí cao, 
Cấu tạo: Gồm 2 ngăn chính; 10 ngăn đựng thẻ, cmt, Màu: Cafe, Kích thước: 9cm x 12cm','VTA870N_1.jpeg, VTA870N_2.jpeg, VTA870N_2.jpeg'),
('Ví da','Ví cầm tay công sở nam VCTTA761116-N',1200000,3,5,
'Chất liệu da bò cao cấp, da thật 100%, Màu sắc: Nâu, Kích thước: 21,2cm x 12,5cm x 4,5cm,
Kiểu dáng thời trang, sang trọng, cầm tay chắc chắn, Nhiều ngăn rộng rãi đựng tiền mặt, thẻ atm, giấy tờ, điện thoại,
 Bảo hành 12 tháng','VCTTA761116_1.jpeg,VCTTA761116_2.jpeg,VCTTA761116_2.jpeg'),
 ('Ví da','Ví nam dáng đứng viền chỉ nổi VNTAD-31N',430000,5,4,
'Chất liệu da bò, da thật 100%, Màu sắc: Nâu, Kích thước: 9,5cm x 12cm, Kiểu dáng thời trang, đường viền độc đáo,
 Sản xuất tại Đồ Da Tâm Anh, Bảo hành 12 tháng','VNTAD_1.jpeg, VNTAD_2.jpeg, VNTAD_3.jpeg'),
 ('Ví da','Ví nam da thật da cá sấu VTA1500N-B-D',1500000,2,5,
'Chất liệu da cá sấu thật 100%, Thiết kế dáng ngang, gồm bộ phận bụng cá sấu ở 2 mặt trong và ngoài ví, vân da phẳng dễ dàng đút túi quần, không bị cộm,
 Ví cá sấu gồm 2 ngăn lớn chính, 1 ngăn khoá kéo cùng nhiều ngăn đựng thẻ, card tiện lợi, 
 Đen, Kích thước: 9,5cm x 12cm, Sản xuất tại Đồ Da Tâm Anh, Bảo hành 12 tháng','VTA1500N_1.jpeg, VTA1500N_2.jpeg, VTA1500N_3.jpeg'),
('Ví da','Ví nam da kỳ đà dáng ngang họa tiết nổi VTA930N-XA',930000,5,4,
'Chất liệu mặt ngoài: Da kỳ đà thật 100%, Chất liệu mặt trong: Da bò thật 100%, Kiểu dáng: Ví ngang, 
Đường chỉ may tỉ mỉ, chắc chắn, Hoạ tiết vân da đẹp, màu sắc loang độc đáo lạ mắt của da kỳ đà, 
Cấu tạo: Gồm 2 ngăn chính; 1 ngăn khóa kéo và 10 ngăn đựng thẻ, Màu: Xám, Kích thước: 9cm x 12cm','VTA930N_1.jpeg,  VTA930N_2.jpeg, VTA930N_3.jpeg'),
('Ví da','Ví nam dài cầm tay da bò VTADD810-A-D',900000,10,3,
'Chất liệu da bò nguyên miếng, da thật 100%, Thiết kế thời trang, Kích thước: 9,5cm x 18,5cm,
 Bảo hành 12 tháng, Xuất xứ: Đồ da Tâm Anh, Giá tốt nhất thị trường','VTADD810_1.jpeg, VTADD810_2.jpeg, VTADD810_3.jpeg'),
 ('Ví da','Ví nam da bò viền chỉ đen VNTAN-665D',290000,15,3,
'Chất liệu da bò nguyên miếng, da thật 100%, Thiết kế lớp lót nguyên miếng, có ngăn khóa kéo, 
Kiểu dáng thời trang, sang trọng, Sản xuất tại Đồ Da Tâm Anh, Kích thước (Dài x Rộng): 9.5 x 12.5, 
Bảo hành 12 tháng','VNTAN_1.jpeg, VNTAN_2.jpeg, VNTAN_3.jpeg');
 
 /* Quần áo */
 INSERT INTO PRODUCT (CATEGORY,NAME_PRODUCT,PRICE,SALE_PERCENT,RATING,PRODUCT_DETAIL,IMAGE)
values ('Quần áo','ÁO THUN NGỰC IN CHỮ MÀU ĐEN AT852',215000,0,4,
'Chất liệu: 100% vải cotton bốn chiều, Form: Slim-fit, Ưu điểm: Mềm mịn, thoáng mát, hút ẩm nhanh, 
Phong cách trẻ trung tinh tế, năng động. Kết hợp tinh tế với nhiều phong cách: Street Style, Casual, Sport Chic','AT852_1.jpeg, AT852_2.jpeg, AT852_3.jpeg'),
('Quần áo','ÁO SƠ MI PHỐI NẸP MÀU XANH BIỂN ASM1304',275000,3,4,
'Chất liệu: 100% cotton, Form: Regular, Lấy ý tưởng từ sức trẻ phóng khoáng, thiết kế sơ mi với chất liệu cotton 100% oxford thể hiện sự trẻ trung mới mẻ, khơi dậy tinh thần tự do của những  chàng trai hiện đại.','ASM1304_1.jpeg,  ASM1304_2.jpeg, ASM1304_3.jpeg'),
('Quần áo','ÁO SƠ MI KAKI THÊU CHỮ MÀU ĐEN ASM1302',300000,5,5,
'Chất liệu: kaki, 100% cotton, Form: Regular, Lấy ý tưởng từ sức trẻ phóng khoáng, thiết kế sơ mi với chất liệu cotton 100% kaki thể hiện sự trẻ trung mới mẻ, khơi dậy tinh thần tự do của những  chàng trai hiện đại.','ASM1302_1.jpeg,  ASM1302_2.jpeg, ASM1302_3.jpeg'),
('Quần áo','ÁO LEN CỔ TRÒN MUỐI TIÊU MÀU XÁM CHUỘT AL125',400000,10,3,
'Chất liệu: Len mi-lăng, Form: Slimfit,  Ưu điểm: Mềm, nhẹ, giữ ấm tốt trong thời tiết se lạnh.
Phong cách: Thu - Đông kết hợp tinh tế với nhiều style (phối jeans, quần tây, kaki, sơ mi...)','AL125_1.jpeg, AL125_2.jpeg, AL125_3.jpeg'),
('Quần áo','QUẦN JOGGER KAKI XÁM J12',275000,5,3,
'Chất liệu: 99% cotton, 1% spandex, Forn: Jogger, Ưu điểm: Form dáng căn bản năng động và thoải mái, thích hợp mix&match với phong cách sport style, casual,..','J12_1.jpeg, J12_2.jpeg, J12_3.jpeg'),
('Quần áo','QUẦN KAKI SLIMFIT MÀU ĐEN QK183',345000,10,4,
'Chất liệu: 98% cotton, 2% spandex, Form: Slim-Fit, Chất vải dày dặn và bền bỉ, Form Slimfit trẻ trung và nam tính, đặc biệt phù hợp với phong thái năng động của các chàng trai trẻ.','QK183_1. jpeg,  QK183_2. jpeg, QK183_3. jpeg'),
('Quần áo','QUẦN SHORT JEAN REGULAR NGẮN 197',325000,10,4,'Chất liệu: 100% cotton, 
Form: Regular, Ưu điểm: Chất liệu jean bền bỉ và mềm mại.
Form dáng đơn giản kết hợp với mọi kiểu áo sơ mi, áo thun, Hoodie, giày thể thao,.. đều dễ dàng bật nên phong cách trẻ trung và năng động.
','197_1.jpeg,197_2.jpeg,197_3.jpeg'),
('Quần áo','ÁO LEN CỔ LỌ TRƠN MÀU ĐEN AL124',275000,15,4,'Chất liệu: Len trơn, Form: Slimfit, Ưu điểm: Mềm, nhẹ, giữ ấm tốt trong thời tiết se lạnh.
Phong cách: Thu - Đông kết hợp tinh tế với nhiều style (phối Vest, jeans, quần tây, kaki, ...)
','AL124_1. jpeg, AL124_2.jpeg, AL124_3.jpeg');

/* Thắt lưng */

INSERT INTO PRODUCT (CATEGORY,NAME_PRODUCT,PRICE,SALE_PERCENT,RATING,PRODUCT_DETAIL,IMAGE)
values ('Thắt lưng','Thắt lưng da bò thời trang D590-1163-15B',59000,10,4,'•	Detail: Mặt khóa ngũ kim sáng bóng
•	Thiết kế khóa trượt thời trang, tiện dụng
•	Đường chỉ may tinh tế, chắc chắn
•	Kích thước (độ rộng dây x độ dài dây): 3,2 cm x 120 cm
','D590_1.jpeg, D590_2.jpeg, D590_3.jpeg'),
('Thắt lưng','Thắt lưng da bò mặt lăn cách điệu D590-1419-1D',59000,5,5,'•	Detail: Thiết kế khóa lăn thời trang, tiện dụng
•	Đường chỉ may tinh tế, chắc chắn
•	Màu sắc: Đen 
•	Dễ dàng kết hợp với các trang phục công sở, lịch sự
•	Kích thước (độ rộng dây x độ dài dây): 3,2 cm x 105~125cm
','1419_1.jpeg,1419_2.jpeg,1419_3.jpeg'),
('Thắt lưng','Thắt lưng da bò cao cấp D590-1107D',300000,10,4,'•	Detail: Mặt khóa ngũ kim cao cấp
•	Thiết kế khóa trượt thời trang, tiện dụng
•	Đường chỉ may tinh tế, chắc chắn
•	Kích thước (độ rộng dây x độ dài dây): 3,2 cm x 120 cm
','1107D_1.jpeg, 1107D_2.jpeg, 1107D_3.jpeg'),

('Thắt lưng','Dây lưng nam da bò D790-03B',790000,10,5,'•	Detail: Mặt khóa ngũ kim không gỉ
•	Khóa cài
•	Đường chỉ may tỉ mỉ, chắc chắn theo tiêu chuẩn xuất khẩu Châu Âu
•	Kích thước (Độ rộng dây x Độ dài dây): 2.9cm x 120cm
','03B_1.jpeg, 03B_2.jpeg, 03B_3.jpeg'),

('Thắt lưng','Dây lưng nam da bò khóa kim D690-A0026B',690000,5,5,'•	Detail: Chất liệu: Da bò thật toàn bộ từ châu Âu
•	Đường may chi tiết, tỉ mỉ theo tiêu chuẩn.
•	Mặt khóa xỏ kim sang trọng, tiện lợi, không hoen gỉ.
•	Thiết kế độc đáo, hiện đại, phù hợp với các quý ông thành đạt.
•	Kết hợp cùng quần âu, kaki, trang phục công sở đơn giản, lịch lãm.  
•	Màu: Bạc
•	Kích thước (độ rộng x độ dài dây): 3.4 x 105 ~ 115 cm
','A0026B_1.jpeg, A0026B_2.jpeg, A0026B_3.jpeg'),

('Thắt lưng','Thắt lưng nam da cá sấu da bụng DLA1500-01-B-XD',1500000,10,5,'•	Detail:  Thắt lưng da cá sấu mềm mại | cao cấp 
•	Dây thắt lưng nguyên miếng da bụng cá sấu với những vân da chữ nhật lớn
•	Mặt khóa lăn hợp kim phối màu luôn được đảm bảo về độ chống xước và hoen gỉ
•	Màu sắc: Xanh dương
•	Kích thước: 3.5 x 105cm ~120cm
','DLA1500_1.jpeg, DLA1500_2.jpeg, DLA1500_3.jpeg'),

('Thắt lưng','Dây thắt lưng cá sấu da lưng DLA1500-02-DL-D',1500000,10,4,'•	Detail: Dây thắt lưng da cá sấu mềm mại | cao cấp 
•	Thiết kế độc đáo bởi được ghép từ 3 phần da lưng, bụng, đuôi
•	Khóa kẹp rút tiện dụng, dễ dàng điều chỉnh vừa vặn với cơ thể 
•	Màu sắc: Đen 
•	Kích thước: 3.3cm x 110cm ~ 120cm
','DLA15001_1.jpeg, DLA15001_2.jpeg, DLA15001_3.jpeg'),

('Thắt lưng','Thắt lưng da bò mặt khóa lăn cao cấp D890-01V',800000,5,4,'•	Detail: Mặt khóa ngũ kim sáng bóng
•	Thiết kế khóa trượt tiện dụng
•	Đường chỉ may tinh tế, chắc chắn
•	Kích thước (độ rộng dây x độ dài dây): 3,2 cm x 120 cm
','D890_1.jpeg, D890_2.jpeg, D890_3.jpeg'),

('Thắt lưng','Dây lưng nam da bò cao cấp D890-11B',800000,5,5,'•	Detail: Mặt khóa ngũ kim sáng bóng
•	Thiết kế khóa trượt tiện dụng
•	Đường chỉ may tinh tế, chắc chắn
•	Kích thước (độ rộng dây x độ dài dây): 3,2 cm x 120 cm

','11B_1.jpeg,11B_2.jpeg,11B_3.jpeg');


/* Nón*/

INSERT INTO PRODUCT (CATEGORY,NAME_PRODUCT,PRICE,SALE_PERCENT,RATING,PRODUCT_DETAIL,IMAGE)
values ('Nón','NÓN TRẮNG N374',95000,10,5,'Detail: Nón Lưỡi Trai Trắng N374 thiết kế kiểu dáng thể thao năng động. May từ chất liệu kaki dày dặn, bền, thoáng khí, không phai màu, dễ giặt và dễ bảo quản. Nón có thể điều chỉnh kích thước tùy theo nhu cầu sử dụng. Có thể dùng cho cả nam và nữ
','N374_1.jpeg,  N374_2.jpeg'),

('Nón','NÓN ĐỎ ĐÔ N363',100000,20,4,'Detail: Nón Lưỡi Trai Đỏ Đô N363 chất liệu kaki rất bền, thoáng khí, không phai màu, dễ giặt và dễ bảo quản. Logo trên nón được thêu tỉ mỉ, phá cách tạo điểm nhấn riêng. Nón có thể điều chỉnh kích thước tùy theo nhu cầu sử dụng. Có thể dùng cho cả nam và nữ.
','N363_1.jpeg, N363_2.jpeg'),

('Nón','NÓN TRẮNG N362',115000,10,4,'Detail: Nón Lưỡi Trai Trắng N362 chất liệu kaki rất bền, thoáng khí, không phai màu, dễ giặt và dễ bảo quản. Logo trên nón được thêu tỉ mỉ, phá cách tạo điểm nhấn riêng. Nón có thể điều chỉnh kích thước tùy theo nhu cầu sử dụng. Có thể dùng cho cả nam và nữ.
','N362_1.jpeg, N362_2.jpeg'),

('Nón','NÓN TRẮNG N375',95000,5,5,'Detail: Nón Lưỡi Trai Trắng N375 thiết kế kiểu dáng thể thao năng động. May từ chất liệu kaki dày dặn, bền, thoáng khí, không phai màu, dễ giặt và dễ bảo quản. Nón có thể điều chỉnh kích thước tùy theo nhu cầu sử dụng. Có thể dùng cho cả nam và nữ.
','N375_1.jpeg, N375_2.jpeg'),

('Nón','NÓN ĐEN N376',95000,10,4,'Detail: Nón Lưỡi Trai Đen N376 thiết kế kiểu dáng thể thao năng động. May từ chất liệu kaki dày dặn, bền, thoáng khí, không phai màu, dễ giặt và dễ bảo quản. Nón có thể điều chỉnh kích thước tùy theo nhu cầu sử dụng. Có thể dùng cho cả nam và nữ.
','N376_1.jpeg, N376_2.jpeg'),

('Nón','NÓN XANH N367-1',175000,10,5,'Detail: Nón Lưỡi Trai Xanh N367-1 chất liệu kaki dày dặn, bền, thoáng khí, không phai màu, dễ giặt và dễ bảo quản. Logo trên nón được thêu tỉ mỉ, phá cách tạo điểm nhấn riêng. Nón có thể điều chỉnh kích thước tùy theo nhu cầu sử dụng. Có thể dùng cho cả nam và nữ.
','N367_1.jpeg, N367_2.jpeg'),

('Nón','NÓN ĐỎ ĐÔ N325',95000,5,3,'Detail: Màu đỏ đô bắt mắt đi kèm chất liệu nỉ mềm mịn, tạo vẻ thu hút cho chiếc Nón Đỏ Đô N325. Hoạ tiết tròn màu trắng ở góc nón càng làm tăng thêm vẻ cuốn hút cho nó. Form nón đẹp, màu sắc nổi bật và bền màu theo thời gian.
','N325_1.jpeg,N325_2.jpeg');


/*Mắt kính*/
INSERT INTO PRODUCT(CATEGORY,NAME_PRODUCT,PRICE,SALE_PERCENT,RATING,PRODUCT_DETAIL,IMAGE)
values ('Mắt kính','MẮT KÍNH ĐEN MK261',305000,10,5,'Detail: Mắt Kính Đen MK261 kiểu dáng thời trang, sang trọng, gọng nhẹ không gây áp lực cho mũi và tai, rất thoải mái khi đeo. Thích hợp cả nam và nữ khi đi chơi, dạo phố, du lịch hay chụp ảnh.
','MK261_1.jpeg,MK261_2.jpeg'),

('Mắt kính','MẮT KÍNH ĐỎ MK260',285000,10,4,'Detail:  Mắt Kính Đỏ MK260 kiểu dáng thời trang, sang trọng, gọng nhẹ không gây áp lực cho mũi và tai, rất thoải mái khi đeo. Thích hợp cả nam và nữ khi đi chơi, dạo phố, du lịch hay chụp ảnh.
','MK260_1.jpeg,MK260_2.jpeg'),

('Mắt kính','MẮT KÍNH ĐEN MK262',285000,5,4,'Detail: Mắt Kính Đen MK260 kiểu dáng thời trang, sang trọng, gọng nhẹ không gây áp lực cho mũi và tai, rất thoải mái khi đeo. Thích hợp cả nam và nữ khi đi chơi, dạo phố, du lịch hay chụp ảnh.
','MK262_1.jpeg,MK262_2.jpeg'),

('Mắt kính','MẮT KÍNH VÀNG MK259',345000,15,4,'Detail: Mắt Kính Vàng MK259 kiểu dáng thời trang, sang trọng, gọng nhẹ không gây áp lực cho mũi và tai, rất thoải mái khi đeo. Thích hợp cả nam và nữ khi đi chơi, dạo phố, du lịch hay chụp ảnh
','MK259_1.jpeg,MK259_2.jpeg'),

('Mắt kính','MẮT KÍNH ĐEN MK258',345000,5,5,'Detail: Mắt Kính Đen MK258 kiểu dáng thời trang, sang trọng, gọng nhẹ không gây áp lực cho mũi và tai, rất thoải mái khi đeo. Thích hợp cả nam và nữ khi đi chơi, dạo phố, du lịch hay chụp ảnh.
','MK258_1.jpeg,MK258_2.jpeg'),

('Mắt kính','MẮT KÍNH XANH RÊU MK251',235000,10,5,'Detail: Mắt Kính Xanh Rêu MK251 kiểu dáng thời trang, sang trọng, gọng nhẹ không gây áp lực cho mũi và tai, rất thoải mái khi đeo. Thích hợp cả nam và nữ khi đi chơi, dạo phố, du lịch hay chụp ảnh.
','MK251_1.jpeg'),

('Mắt kính','MẮT KÍNH ĐEN MK227',125000,10,4,'Detail: Mắt Kính Đen MK227 kiểu dáng thời trang, gọng nhựa nhẹ không gây áp lực cho mũi và tai, rất thoải mái khi đeo. Thích hợp cả nam và nữ khi đi chơi, dạo phố, du lịch hay chụp ảnh.
','MK227_1.jpeg,MK227_2.jpeg'),

('Mắt kính','MẮT KÍNH ĐEN MK220',325000,5,4,'Detail: Mắt Kính Đen MK220 kiểu dáng thời trang, gọng nhựa nhẹ không gây áp lực cho mũi và tai, rất thoải mái khi đeo. Thích hợp cả nam và nữ khi đi chơi, dạo phố, du lịch hay chụp ảnh.
','MK220_1.jpeg,MK220_2.jpeg'),

('Mắt kính','MẮT KÍNH ĐEN MK215',325000,5,5,'Detail: Mắt Kính Đen MK215 kiểu dáng thời trang, gọng nhựa nhẹ không gây áp lực cho mũi và tai, rất thoải mái khi đeo. Thích hợp cả nam và nữ khi đi chơi, dạo phố, du lịch hay chụp ảnh.
','MK215_1.jpeg,MK215_2.jpeg');


/* Giày*/

INSERT INTO PRODUCT(CATEGORY,NAME_PRODUCT,PRICE,SALE_PERCENT,RATING,PRODUCT_DETAIL,IMAGE)
values ('Giày','GIÀY BOOT TĂNG CHIỀU CAO BÒ G122',362000,30,4,'Detail: Giày Boot Tăng Chiều Cao Bò G122 nổi bật với màu da bò cá tính, hiện đại. Chất da mềm, bền đẹp, phối những đường chỉ màu vàng bắt mắt. Đường nét thiết kế tinh tế, thuộc kiểu boot cổ thấp sành điệu, thích hợp cho những chàng trại bụi bặm, cá tính. Đặc biệt, giày có lót trong êm mềm, có khả năng nâng tổng chiều cao của người dùng lên đến 5-6cm một cách tự nhiên mà người ngoài khó nhận biết được.
','G122_1.jpeg,G122_2.jpeg'),

('Giày','GIÀY BOOT TĂNG CHIỀU CAO MÀU BÒ G130',365000,25,5,'Detail: Giày Boot Tăng Chiều Cao Màu Bò G130 với đường nét thiết kế đẹp mắt kết hợp màu da bò sang trọng. Tính năng đặc biệt của sản phẩm là giúp tăng chiều cao lên đến 5-6cm một cách tự nhiên và thoải mái. Thiết kế theo form Giày Boot cá tính, bụi bặm, ôm chân vừa phải với dây cột rất tiện lợi. Chất liệu 100% da bò thật, êm mềm và rất bền, đồng hành cùng bạn trên những chặng đường dài.
','G130_1.jpeg,G130_2.jpeg'),

('Giày','GIÀY MỌI XANH ĐEN G168',287000,15,4,'Detail: Giày Mọi Xanh Đen G168 chất liệu da bò 100% bền, mang thoải mái và dễ di chuyển. Đế cao su chất lượng cao, bền và độ bám tốt, tránh trơn trượt. Giày có độ thoáng khí tốt đi cùng phần đệm lót êm ái..
','G168_1.jpeg, G168_2.jpeg'),

('Giày','GIÀY MỌI MÀU BÒ G86',300000,15,4,'Detail: Giày Mọi Màu Bò G86 chất liệu 100% da bò thật, bền đẹp và thoải mái. Màu da bò mang đến sự lịch lãm, khẳng định đẳng cấp cho người sử dụng. Thiết kế phá cách và sang trọng. Đường nét tinh tế, họa tiết chuông tua rua phối hợp đẹp mắt. Chỉ may đều đẹp, chắc chắn, lót trong êm ái. Đế cao su tăng ma sát, chống trơn trượt
','G86_1.jpeg,G86_2.jpeg'),

('Giày','GIÀY TĂNG CHIỀU CAO NÂU G206',500000,10,4,'Detail:  Giày Tăng Chiều Cao Nâu G206 chất liệu da sang trọng, bền, nam tính. Kiểu dáng đơn giản, tinh tế, thoải mái khi sử dụng. Đế tăng chiều cao bí mật 5-6cm. Dễ dàng kết hợp trang phục cho giới văn phòng, sinh viên...
','G206_1.jpeg, G206_2.jpeg'),

('Giày','GIÀY TĂNG CHIỀU CAO ĐEN G200',700000,25,4,'Detail: Giày Tăng Chiều Cao Đen G200 chất liệu da sang trọng, bền, nam tính. Kiểu dáng ôm chân tạo cảm giác thon gọn, đi lại êm ái, dễ chịu. Đế tăng chiều cao bí mật 5-6cm. Dễ dàng kết hợp trang phục cho giới văn phòng, sinh viên.
','G200_1.jpeg, G200_2.jpeg'),

('Giày','GIÀY TĂNG CHIỀU CAO NÂU G201',400000,10,5,'Detail: Giày Tăng Chiều Cao Nâu G201 chất liệu da sang trọng, bền, nam tính. Kiểu dáng ôm chân tạo cảm giác thon gọn, đi lại êm ái, dễ chịu. Đế tăng chiều cao bí mật 5-6cm. Dễ dàng kết hợp trang phục cho giới văn phòng, sinh viên...
','G201_1.jpeg,G201_2.jpeg');


/*Add users*/
INSERT INTO users(USERNAME,PASS_WORD,EMAIL) 
values('CuongNguyen','12345678','dinhcuong130698@gmail.com'),
      ('HuuDinh','12345678','huudinh98@gmail.com'),
      ('XuanAn','12345678','xuanan1998@gmail.com');
	
ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY '1234'