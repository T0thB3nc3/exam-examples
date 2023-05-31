create database szinkronstudio;

use szinkronstudio;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `CategoryModel` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_CategoryModel` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Versenyzok` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Title` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Length` int NOT NULL,
    `DubProducer` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CategoryId` int NOT NULL,
    `AnnouncedInHungary` datetime(6) NULL,
    CONSTRAINT `PK_Versenyzok` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Versenyzok_CategoryModel_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `CategoryModel` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

INSERT INTO `CategoryModel` (`Id`, `Name`)
VALUES (1, 'Romantic');
INSERT INTO `CategoryModel` (`Id`, `Name`)
VALUES (2, 'Sci-Fi');
INSERT INTO `CategoryModel` (`Id`, `Name`)
VALUES (3, 'Action');
INSERT INTO `CategoryModel` (`Id`, `Name`)
VALUES (4, 'Comedy');
INSERT INTO `CategoryModel` (`Id`, `Name`)
VALUES (5, 'Documentary');
INSERT INTO `CategoryModel` (`Id`, `Name`)
VALUES (6, 'Cartoon');

INSERT INTO `Versenyzok` (`Id`, `AnnouncedInHungary`, `CategoryId`, `DubProducer`, `Length`, `Title`)
VALUES ('1920/915', NULL, 1, 'Adolf Stalin', 135, 'My Fellow Jonathan');
INSERT INTO `Versenyzok` (`Id`, `AnnouncedInHungary`, `CategoryId`, `DubProducer`, `Length`, `Title`)
VALUES ('1972/521', NULL, 2, 'Bull Shark Testosterone', 79, 'Space Amoeba');
INSERT INTO `Versenyzok` (`Id`, `AnnouncedInHungary`, `CategoryId`, `DubProducer`, `Length`, `Title`)
VALUES ('1998/315', NULL, 5, 'Ben Dover', 234, 'Nature of Harambe');
INSERT INTO `Versenyzok` (`Id`, `AnnouncedInHungary`, `CategoryId`, `DubProducer`, `Length`, `Title`)
VALUES ('2004/032', NULL, 3, 'Carl Johnson', 96, 'Gangs of the Grove Street');
INSERT INTO `Versenyzok` (`Id`, `AnnouncedInHungary`, `CategoryId`, `DubProducer`, `Length`, `Title`)
VALUES ('2020/14', NULL, 6, 'US Government', 71, 'Mickey and the Nazis');
INSERT INTO `Versenyzok` (`Id`, `AnnouncedInHungary`, `CategoryId`, `DubProducer`, `Length`, `Title`)
VALUES ('2020/15', NULL, 4, 'John Doe', 126, 'Johnny and the Two A**holes');

CREATE UNIQUE INDEX `IX_CategoryModel_Name` ON `CategoryModel` (`Name`);

CREATE INDEX `IX_Versenyzok_CategoryId` ON `Versenyzok` (`CategoryId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230330062746_Init', '6.0.7');

COMMIT;

