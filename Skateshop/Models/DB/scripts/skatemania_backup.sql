drop database if exists skatemania;
create database skatemania;

use skatemania;

create table Item(
	ID int auto_increment,
    Manufacturer varchar(50),
    Size varchar(50),
    Image varchar(50),
    Price real,
    Description varchar(100),
    ItemType int,
    primary key(ID)
    );
    
insert into Item values (null, "Flip", '8.13"', "decks/deck1", 64.99, "Penny Loveshroom Purple", 0);
insert into Item values (null, "SK8DLX", '8.25"', "decks/deck2", 54.99, "Rose Black", 0);
insert into Item values (null, "JART", '8"', "decks/deck3", 49.99, "Renaissance II Weedsuschrist Multi", 0);
insert into Item values (null, "Tensor", '6"', "trucks/truck1", 49.99, "Alloys Regular Truck 2er Pack RAW", 1);
insert into Item values (null, "Tensor", '5.5"', "trucks/truck2", 49.99, "Alloys Regular Truck 2er Pack Black", 1);
insert into Item values (null, "Tensor", '5.5"', "trucks/truck3", 49.99, "Magnesium Light Tens Truck All Terrain 2er Pack Silver", 1);
insert into Item values (null, "SPITFIRE", "54mm 99A", "wheels/wheels1", 59.99, "Formula Four (White Blue)", 2);
insert into Item values (null, "HAZE WHEELS", "52mm 85A", "wheels/wheels2", 44.99, "Deflated Dolls (White)", 2);
insert into Item values (null, "BONES", "52mm 100A", "wheels/wheels3", 34.99, "100\'S-OG #18 V4 (Black Red)", 2);
insert into Item values (null, "BONES", "", "bearings/bearings1", 115.99, "Ceramic Super Reds", 3);
insert into Item values (null, "BONES", "" , "bearings/bearings2", 84.99, "Super Swiss 6 Ball", 3);
insert into Item values (null, "BONES", "" , "bearings/bearings3", 79.99, "Swiss 7 Ball", 3);
insert into Item values (null, "TEST", "TEST", "", 420.69, "TEST", 4);

select * from Item;
show fields from Item;