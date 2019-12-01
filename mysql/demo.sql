CREATE TABLE `db`.`Account` (
  `id` VARCHAR(100) NOT NULL,
  `name` VARCHAR(100) NULL,
  `password` VARCHAR(1000) NULL,
  `isDeleted` TINYINT NULL DEFAULT 0,
  `userid` VARCHAR(100) NULL,
  PRIMARY KEY (`id`));