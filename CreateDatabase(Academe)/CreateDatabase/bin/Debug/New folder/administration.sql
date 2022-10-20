-- MySQL dump 10.11
--
-- Host: localhost    Database: administration
-- ------------------------------------------------------
-- Server version	5.0.96-community-nt

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `privileges`
--

DROP TABLE IF EXISTS `privileges`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `privileges` (
  `id` int(11) NOT NULL auto_increment,
  `locationId` varchar(30) default NULL,
  `privilege` varchar(50) default NULL,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `privileges`
--

LOCK TABLES `privileges` WRITE;
/*!40000 ALTER TABLE `privileges` DISABLE KEYS */;
/*!40000 ALTER TABLE `privileges` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roleforms`
--

DROP TABLE IF EXISTS `roleforms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roleforms` (
  `locationId` varchar(30) NOT NULL,
  `roleName` varchar(30) NOT NULL,
  `module` varchar(50) NOT NULL,
  `form` varchar(50) NOT NULL,
  `button` varchar(50) NOT NULL,
  `visible` tinyint(4) default NULL,
  `status` enum('Active','Deleted') default NULL,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`locationId`,`roleName`,`module`,`form`,`button`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roleforms`
--

LOCK TABLES `roleforms` WRITE;
/*!40000 ALTER TABLE `roleforms` DISABLE KEYS */;
/*!40000 ALTER TABLE `roleforms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolemenus`
--

DROP TABLE IF EXISTS `rolemenus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rolemenus` (
  `locationId` varchar(30) NOT NULL,
  `roleName` varchar(30) NOT NULL,
  `menu` varchar(100) NOT NULL,
  `enable` tinyint(4) default NULL,
  `status` enum('Active','Deleted') default NULL,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`locationId`,`roleName`,`menu`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rolemenus`
--

LOCK TABLES `rolemenus` WRITE;
/*!40000 ALTER TABLE `rolemenus` DISABLE KEYS */;
/*!40000 ALTER TABLE `rolemenus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roleprivileges`
--

DROP TABLE IF EXISTS `roleprivileges`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roleprivileges` (
  `locationId` varchar(30) NOT NULL,
  `roleName` varchar(30) NOT NULL,
  `privilege` varchar(50) NOT NULL,
  `allowed` tinyint(4) default NULL,
  `status` enum('Active','Deleted') default NULL,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`locationId`,`roleName`,`privilege`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roleprivileges`
--

LOCK TABLES `roleprivileges` WRITE;
/*!40000 ALTER TABLE `roleprivileges` DISABLE KEYS */;
/*!40000 ALTER TABLE `roleprivileges` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles` (
  `roleName` varchar(30) NOT NULL,
  `description` varchar(100) default NULL,
  `locationId` varchar(30) NOT NULL,
  `status` enum('Active','Deleted') default NULL,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`roleName`,`locationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES ('Accounting','Accounting','1','Active','admin','2011-06-10 16:42:15','admin','2011-06-10 16:42:15'),('Administrator','Administrator','1','Active','admin','2011-06-06 16:45:23','admin','2011-06-06 16:45:23'),('Cashier','Cashier','1','Active','admin','2011-06-10 16:41:45','admin','2011-06-10 16:41:45'),('Inventory','Inventory','1','Active','admin','2011-06-10 16:42:03','admin','2011-06-10 16:42:03'),('Store Manager','Store Manager','1','Active','admin','2011-06-10 16:42:40','admin','2011-06-10 16:42:40');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `systemconfig`
--

DROP TABLE IF EXISTS `systemconfig`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `systemconfig` (
  `Key` varchar(100) NOT NULL,
  `Value` varchar(100) default NULL,
  `Description` varchar(250) default NULL,
  `CreatedAt` datetime default NULL,
  `CreatedBy` varchar(50) default NULL,
  PRIMARY KEY  (`Key`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `systemconfig`
--

LOCK TABLES `systemconfig` WRITE;
/*!40000 ALTER TABLE `systemconfig` DISABLE KEYS */;
INSERT INTO `systemconfig` VALUES ('DESIGNATE_GROUP_TYPE','true','RESTO,FOLIO,CALLPLUS',NULL,NULL),('IS_GASOLINE_TRANSACTION','false','Determine if Gasoline Transaction',NULL,NULL),('SHOW_SOURCE_LOCATION','false','source location form will show after user login',NULL,NULL);
/*!40000 ALTER TABLE `systemconfig` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userroles`
--

DROP TABLE IF EXISTS `userroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `userroles` (
  `userId` varchar(30) NOT NULL,
  `roleName` varchar(30) NOT NULL,
  `locationId` varchar(30) NOT NULL,
  `status` enum('Active','Deleted') default NULL,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`userId`,`roleName`,`locationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userroles`
--

LOCK TABLES `userroles` WRITE;
/*!40000 ALTER TABLE `userroles` DISABLE KEYS */;
INSERT INTO `userroles` VALUES ('12345','Cashier','1','Deleted','admin','2013-06-29 14:44:03','admin','2013-06-29 14:45:50'),('admin','Administrator','1','Active','admin','2011-06-06 16:47:46','admin','2011-12-04 05:14:23'),('davidsad','Inventory','1','Active','admin','2013-06-29 14:45:39','admin','2013-06-29 14:45:39'),('veil','Accounting','1','Deleted','admin','2012-05-17 10:55:00','veil','2012-05-17 10:55:35'),('veil','Administrator','1','Deleted','admin','2012-05-17 10:55:00','veil','2012-05-17 10:55:35'),('veil','Cashier','1','Deleted','admin','2012-05-17 10:55:00','veil','2012-05-17 10:55:35'),('veil','Inventory','1','Deleted','admin','2012-05-17 10:55:00','veil','2012-05-17 10:55:35'),('veil','Store Manager','1','Deleted','admin','2012-05-17 10:55:00','veil','2012-05-17 10:55:35');
/*!40000 ALTER TABLE `userroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `username` varchar(30) NOT NULL,
  `password` text,
  `firstName` varchar(50) default NULL,
  `middleName` varchar(50) default NULL,
  `lastName` varchar(50) default NULL,
  `locationId` int(11) default NULL,
  `userType` enum('ADMIN','NON-ADMIN') default NULL,
  `status` enum('Active','Deleted') default 'Active',
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('12345','827ccb0eea8a706c4c34a16891f84e7b','qwerty','asdfg','zxcvb',1,'ADMIN','Deleted','admin','2013-06-29 14:44:03','admin','2013-06-29 14:45:50'),('admin','21232f297a57a5a743894a0e4a801fc3','admin','admin','admin',1,'ADMIN','Active','admin','2011-01-06 13:17:28','admin','2011-12-04 05:14:23'),('davidsad','827ccb0eea8a706c4c34a16891f84e7b','david','rty','saloon',1,'NON-ADMIN','Active','admin','2013-06-29 14:45:39','admin','2013-06-29 14:45:39'),('veil','81dc9bdb52d04dc20036dbd8313ed055','Veil','','Perez',1,'ADMIN','Deleted','admin','2012-05-17 10:55:00','veil','2012-05-17 10:55:35');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'administration'
--
DELIMITER ;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIfUserExists` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIfUserExists`(
 pUserName varchar(30)
 )
BEGIN
  select count(*) from users where username = pUserName and `status` = 'Active';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRole` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spDeleteRole`(
 pRoleName varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
  update roles
 set `status` = 'Deleted'
 , updatedBy = pUser
 , updatedAt = now()
 where roleName = pRoleName and locationId = pLocationId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteUser` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spDeleteUser`(
 pUserName varchar(30)
 , pUser varchar(30)
 )
BEGIN
  update users
 set `status` = 'Deleted'
 , updatedBy = pUser
 , updatedAt = now()
 where username = pUsername;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteUserRole` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spDeleteUserRole`(
 pUsername varchar(30)
 , pRoleName varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
  update userRoles
 set `status` = 'Deleted'
 , updatedBy = pUser
 , updatedAt = now()
 where userId = pUsername and roleName = pRoleName and locationId = pLocationId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAllLocations` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAllLocations`(
pPropertyId varchar(30)
)
BEGIN
select  locations.locationId,
	locations.name, 
	locations.owner
        from locations
	where propertyId = pPropertyId 
	and locations.status = 'Active';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGoodsReceiptHeader` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetGoodsReceiptHeader`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT 	grheader.propertyId, 
	grheader.locationId, 
	grheader.grID, 
	grheader.purchaseNo, 
	fGetSupplierName(grheader.supplierId, pPropertyId, pLocationId) As SupplierName, 
	grheader.grDate, 
	grheader.TotalAmount, 
	grheader.remarks, 
	grheader.createdBy, 
	createdAt, 
	grheader.updatedBy, 
	grheader.updatedAt
	FROM 
	grheader  
	WHERE
	grheader.propertyId = pPropertyId
	AND grheader.locationId = pLocationId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetInventoryItemsToLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetInventoryItemsToLocation`(
pPropertyId varchar(30),
pLocationIdFrom varchar(30),
pLocationIdTo varchar(30)
)
BEGIN
SELECT    itemlocations.itemId
	, fGetItemDescription(itemlocations.itemId) as Description
	, itemlocations.quantity
	, fGetLocalStocks(itemlocations.itemId, itemlocations.propertyID, pLocationIdTo) as LocalStocks
	, fGetMinStockLevel(itemlocations.itemId, itemlocations.propertyID, pLocationIdFrom) as MinStocks
	, fGetMaxStockLevel(itemlocations.itemId, itemlocations.propertyID, pLocationIdFrom) as MaxStocks
FROM  itemlocations LEFT JOIN items ON items.itemId = itemlocations.itemId
WHERE itemlocations.itemId IN ( SELECT itemlocations.itemId 
		                from itemlocations
			        where itemlocations.locationId = pLocationIdTo
			        and itemlocations.status = 'Active'
				and itemlocations.quantity <> 0 
			       )
	AND itemlocations.propertyID = pPropertyId
	AND itemlocations.locationId = pLocationIdFrom
	AND items.isInventoryItems = 'Yes'
	AND items.status = 'Active';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPrivileges` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetPrivileges`(
 pLocationId varchar(30)
 )
BEGIN
 	 select * from `privileges` where locationId = pLocationId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRole` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetRole`(
 pRoleName varchar(30)
 , pLocationId varchar(30)
 )
BEGIN
 	 select * from roles where roleName = pRoleName and locationId = pLocationId and `status` = 'Active';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoleForms` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetRoleForms`(
 pRoleName varchar(30)
 , pLocationId varchar(30)
 )
BEGIN
  select * from roleForms where roleName = pRoleName and locationId = pLocationId and `status` = 'Active';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoleMenus` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetRoleMenus`(
 pRoleName varchar(30)
 , pLocationId varchar(30)
 )
BEGIN
  select * from roleMenus where locationId = pLocationId and roleName = pRoleName and `status` = 'Active' and `enable` = 1;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRolePrivileges` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetRolePrivileges`(
 pRoleName varchar(30)
 , pLocationId varchar(30)
 )
BEGIN
 	 select * from rolePrivileges where roleName = pRoleName and locationId = pLocationId and `status` = 'Active';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoles` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetRoles`(
 pLocationId varchar(30)
 )
BEGIN
  select roleName, description from roles where locationId = pLocationId and `status` = 'Active';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetUserRoleForms` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetUserRoleForms`(
 pUsername varchar(30)
 , pLocationId varchar(30)
 )
BEGIN
 /*
 select distinct module, form, button, visible 
 from users 
 left join userRoles on users.username = userRoles.userId 
 left join roles on userRoles.roleName = roles.roleName 		
 left join roleForms on roles.roleName = roleForms.roleName 
 where users.username = pUsername 
 and userroles.status = 'Active'
 and roleforms.status = 'Active'
 and roleForms.locationId = pLocationId;
 */
 -- Gene 9/5/2011
 
 SELECT DISTINCT DISTINCT module, form, button, SUM(visible) AS visible
  FROM roleforms
  WHERE locationId = pLocationId
  AND `status` = 'Active' 
  AND roleName IN (SELECT roleName
  FROM userroles WHERE userId = pUsername
  AND `status` = 'Active')
  GROUP BY module, form, button;
  
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetUserRoleMenus` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetUserRoleMenus`(
 pUsername varchar(30)
 , pLocationId varchar(30)
 )
BEGIN
 /*
 select distinct menu 
 from users 
 left join userRoles on users.username = userRoles.userId 
 left join roles on userRoles.roleName = roles.roleName 
 left join roleMenus on roles.roleName = roleMenus.roleName
 where users.username = pUsername 
 and `enable` = 1  
 and `rolemenus`.`status` = 'Active'
 and `userroles`.`status` = 'Active'
 and roleMenus.locationId = pLocationId;
 */
 -- Gene - 9/5/2011
 
 SELECT DISTINCT `menu`
  FROM rolemenus
  WHERE locationId = pLocationId
  AND `status` = 'Active' 
  AND `enable` = 1
  AND roleName IN (SELECT roleName
  FROM userroles WHERE userId = pUsername
  AND `status` = 'Active');
  
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetUserRolePrivileges` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetUserRolePrivileges`(
 pUsername varchar(30)
 , pLocationId varchar(30)
 )
BEGIN
 
 select distinct privilege 
 from users 
 left join userRoles on users.username = userRoles.userId 
 left join roles on userRoles.roleName = roles.roleName 
 left join rolePrivileges on roles.roleName = rolePrivileges.roleName 
 where users.username = pUsername 
 and rolePrivileges.status = 'Active' 
 and rolePrivileges.locationId = pLocationId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetUserRoles` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetUserRoles`(
 pUsername varchar(30)
 , pLocationId varchar(30)
 )
BEGIN
  select roleName from userRoles where userId = pUsername and locationId = pLocationId and `status` = 'Active';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetUsers` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetUsers`(pLocationId varchar(30))
BEGIN
  select username, firstName, middleName, lastName, userType, `password` from users where locationId = pLocationId and `status` = 'Active';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRole` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertRole`(
 pRoleName varchar(30)
 , pDescription varchar(100)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
  insert into roles
 set roleName = pRoleName
 , description = pDescription
 , locationId = pLocationId
 , `status` = 'Active'
 , createdBy = pUser
 , createdAt = now()
 , updatedBy = pUser
 , updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoleForm` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertRoleForm`(
 pRoleName varchar(30)
 , pModule varchar(50)
 , pForm varchar(50)
 , pButton varchar(50)
 , pVisible tinyint(1)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
  insert into roleForms
 set locationId = pLocationId
 , roleName = pRoleName
 , module = pModule
 , form = pForm
 , button = pButton
 , visible = pVisible
 , `status` = 'Active'
 , createdBy = pUser
 , createdAt = now()
 , updatedBy = pUser
 , updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoleMenu` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertRoleMenu`(
 pRoleName varchar(30)
 , pMenu varchar(100)
 , pEnable tinyint(1)
 , pLocationId varchar(30)
 , pUser varchar(50)
 )
BEGIN
 
 insert into roleMenus
 set locationId = pLocationId
 , roleName = pRoleName
 , menu = pMenu
 , `enable` = pEnable
 , `status` = 'Active'
 , createdBy = pUser
 , createdAt = now()
 , updatedBy = pUser
 , updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRolePrivilege` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertRolePrivilege`(
 pLocationId varchar(30)
 , pRoleName varchar(30)
 , pPrivilege varchar(50)
 , pAllowed tinyint(1)
 , pUser varchar(30)
 )
BEGIN
 
 insert into rolePrivileges
 set locationId = pLocationId
 , roleName = pRoleName
 , privilege = pPrivilege
 , allowed = pAllowed
 , `status` = 'Active'
 , createdBy = pUser
 , createdAt = now()
 , updatedBy = pUser
 , updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertUser` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertUser`(
 pUsername varchar(30)
 , pPassword text
 , pFirstName varchar(50)
 , pMiddleName varchar(50)
 , pLastName varchar(50)
 , pLocationId varchar(30)
 , pUserType varchar(30)
 , pUser varchar(30)
 )
BEGIN
 set @users = 0;
 select count(*) into @users from users where username = pUsername limit 1;
  if @users = 1 then
  update users
 set 
 `password` = if(pPassword = "", `password`, MD5(pPassword))
 , firstName = pFirstName
 , middleName = pMiddleName
 , lastName = pLastName
 , locationId = pLocationId
 , userType = pUserType
 , `status` = 'Active'
 , updatedBy = pUser
 , updatedAt = now()
 where username = pUsername;
  else
  insert into users
 set username = pUsername 
 , password = MD5(pPassword)
 , firstName = pFirstName
 , middleName = pMiddleName
 , lastName = pLastName
 , locationId = pLocationId
 , userType = pUserType
 , `status` = 'Active'
 , createdBy = pUser
 , createdAt = now()
 , updatedBy = pUser
 , updatedAt = now();
  end if;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertUserRole` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertUserRole`(
 pUsername varchar(30)
 , pRoleName varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
  set @userRole = 0;
 select count(*) into @userRole from userRoles where userId = pUsername and locationId = pLocationId and roleName = pRoleName limit 1;
  if @userRole = 1 then
 		 update userRoles
 set `status` = 'Active'
 , updatedBy = pUser
 , updatedAt = now()
 where userId = pUsername and locationId = pLocationId and roleName = pRoleName;
  else
 		 insert into userRoles
 set userId = pUsername
 , roleName = pRoleName
 , locationId = pLocationId
 , `status` = 'Active'
 , createdBy = pUser
 , createdAt = now()
 , updatedBy = pUser
 , updatedAt = now();
  end if;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spLoginUser` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spLoginUser`(pUsername varchar(30), pPassword text, pLocationId varchar(30))
BEGIN
 select username, userType from users 
 where username = pUsername and `password` = md5(pPassword) and `status` = 'Active' and (locationId = pLocationId or userType = 'ADMIN');
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectSystemConfig` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectSystemConfig`()
BEGIN
select * from systemconfig;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRole` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateRole`(
 pRoleName varchar(30)
 , pDescription varchar(100)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
  update roles
 set description = pDescription
 , `status` = 'Active'
 , updatedBy = pUser
 , updatedAt = now()
 where roleName = pRoleName and locationId = pLocationId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoleForm` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateRoleForm`(
 pRoleName varchar(30)
 , pModule varchar(50)
 , pForm varchar(50)
 , pButton varchar(50)
 , pVisible tinyint(1)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
  update RoleForms
 set visible = pVisible
 , `status` = 'Active'
 , updatedBy = pUser
 , updatedAt = now()
 where locationId = pLocationId 
 and roleName = pRoleName 
 and module = pModule 
 and form = pForm 
 and button = pButton;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoleMenu` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateRoleMenu`(
 pRoleName varchar(30)
 , pMenu varchar(100)
 , pEnable tinyint(1)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 
 update roleMenus
 set `enable` = pEnable
 , `status` = 'Active'
 , updatedBy = pUser
 , updatedAt = now()
 where locationId = pLocationId and roleName = pRoleName and menu = pMenu;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRolePrivilege` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateRolePrivilege`(
 pLocationId varchar(30)
 , pRoleName varchar(30)
 , pPrivilege varchar(50)
 , pAllowed tinyint(1)
 , pUser varchar(30)
 
 )
BEGIN
 
 update rolePrivileges
 set allowed = pAllowed
 , `status` = 'Active'
 , updatedBy = pUser
 , updatedAt = now()
 where locationId = pLocationId and roleName = pRoleName and privilege = pPrivilege;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
DELIMITER ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-04-25 10:21:54
