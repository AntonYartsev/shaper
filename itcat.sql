-- live preview this code:
-- https://www.db-fiddle.com/f/kWyhGAcxLy6Fbf7ouskgBb/4

create table items (
  	id int not null primary key,
    name varchar(50) not null
);

create table categories (
	id int not null primary key,
    name varchar(50) not null
);

create table refs (
	itemId int,
  	catId int,
  	foreign key (itemId) references items(id),
  	foreign key (catId) references categories(id)
);

-- simple procedure to seed items
DELIMITER $$
CREATE PROCEDURE populateItems(IN count INT)
    BEGIN
        DECLARE i INT;
        DECLARE catId INT;
        DECLARE itemName char(100);

        -- seed items
        SET i = 1;
        WHILE i <= count DO
        	SET catId = CEIL(RAND() * (4 - 1));
            INSERT INTO items (id,name) VALUES (i,(select concat(name,' #',i) from categories where id = catId));
            -- and set drink cat.
            INSERT INTO refs (itemId,catId) VALUES (i, catId);
            SET i = i + 1;
        END WHILE;

        -- seed little bit (7) items without cats
        WHILE i <= (count+7) DO
            INSERT INTO items (id,name) VALUES (i,"unknown liquid");
            SET i = i + 1;
        END WHILE;

		-- add some hot categories for first 2 items
        SET i = 1;
        WHILE i <= (2) DO
        	SET catId = 4;
            INSERT INTO refs (itemId,catId) VALUES (i, catId);
            SET i = i + 1;
        END WHILE;

		-- and some cold
        SET i = 1;
        WHILE i <= (3) DO
        	SET catId = 5;
            INSERT INTO refs (itemId,catId) VALUES (i, catId);
            SET i = i + 1;
        END WHILE;
    END$$
DELIMITER ;

-- seed categories
insert into categories (id,name) values (1,'tea');
insert into categories (id,name) values (2,'coffee');
insert into categories (id,name) values (3,'water');
insert into categories (id,name) values (4,'hot');
insert into categories (id,name) values (5,'ice');

-- seed items
call populateItems(20);

-- select all items with categories
select
	i.name,
    c.name
from
	items i
left join
	refs r on r.itemId = i.id
left join
	categories c on c.id = r.catId