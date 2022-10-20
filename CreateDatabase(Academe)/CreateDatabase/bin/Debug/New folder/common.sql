-- MySQL dump 10.11
--
-- Host: localhost    Database: common
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
-- Table structure for table `calibration`
--

DROP TABLE IF EXISTS `calibration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `calibration` (
  `id` int(11) NOT NULL auto_increment,
  `pumpid` varchar(30) default NULL,
  `datecreated` datetime default NULL,
  `calibrationliter` decimal(12,2) default '0.00',
  `shiftid` varchar(30) default NULL,
  `locationid` varchar(30) default NULL,
  `propertyid` varchar(30) default NULL,
  `updatedDate` datetime default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `calibration`
--

LOCK TABLES `calibration` WRITE;
/*!40000 ALTER TABLE `calibration` DISABLE KEYS */;
/*!40000 ALTER TABLE `calibration` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `capitalcosthistory`
--

DROP TABLE IF EXISTS `capitalcosthistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `capitalcosthistory` (
  `PropertyID` int(11) default NULL,
  `capitalId` varchar(30) default NULL,
  `locationId` varchar(30) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `capitalcosthistory`
--

LOCK TABLES `capitalcosthistory` WRITE;
/*!40000 ALTER TABLE `capitalcosthistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `capitalcosthistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fuelmaingrouptracker`
--

DROP TABLE IF EXISTS `fuelmaingrouptracker`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fuelmaingrouptracker` (
  `id` int(11) NOT NULL auto_increment,
  `MaingroupID` varchar(30) default NULL,
  `locationID` varchar(30) default NULL,
  `propertyID` varchar(30) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fuelmaingrouptracker`
--

LOCK TABLES `fuelmaingrouptracker` WRITE;
/*!40000 ALTER TABLE `fuelmaingrouptracker` DISABLE KEYS */;
/*!40000 ALTER TABLE `fuelmaingrouptracker` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fueltype`
--

DROP TABLE IF EXISTS `fueltype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fueltype` (
  `id` int(11) NOT NULL auto_increment,
  `FuelType` varchar(30) default NULL,
  `Status` enum('Active','Inactive') default 'Active',
  `LocationID` varchar(30) default NULL,
  `PropertyID` varchar(30) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fueltype`
--

LOCK TABLES `fueltype` WRITE;
/*!40000 ALTER TABLE `fueltype` DISABLE KEYS */;
/*!40000 ALTER TABLE `fueltype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemdetails`
--

DROP TABLE IF EXISTS `itemdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemdetails` (
  `propertyId` varchar(30) NOT NULL default '',
  `locationId` varchar(30) NOT NULL default '',
  `detailId` varchar(30) NOT NULL default '',
  `itemId` varchar(30) default '',
  `description` varchar(255) default '',
  `serialNumbers` varchar(50) default '',
  `createdBy` varchar(30) default '',
  `createdAt` datetime default '1900-01-01 00:00:00',
  `updatedBy` varchar(30) default '',
  `updatedAt` datetime default '1900-01-01 00:00:00',
  PRIMARY KEY  (`propertyId`,`locationId`,`detailId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemdetails`
--

LOCK TABLES `itemdetails` WRITE;
/*!40000 ALTER TABLE `itemdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemgroups`
--

DROP TABLE IF EXISTS `itemgroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemgroups` (
  `propertyId` varchar(30) NOT NULL,
  `locationId` varchar(30) NOT NULL,
  `groupId` varchar(30) NOT NULL,
  `mainGroupId` varchar(30) default NULL,
  `groupType` varchar(50) default NULL,
  `description` varchar(200) default NULL,
  `status` enum('Active','Deleted') default 'Active',
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default '1900-01-01 00:00:00',
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default '1900-01-01 00:00:00',
  PRIMARY KEY  (`propertyId`,`locationId`,`groupId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemgroups`
--

LOCK TABLES `itemgroups` WRITE;
/*!40000 ALTER TABLE `itemgroups` DISABLE KEYS */;
INSERT INTO `itemgroups` VALUES ('1','1','BREAKFAST','FOOD','RESTO','BREAKFAST','Active','instructor','2014-04-22 17:40:16','instructor','2014-03-04 09:24:15'),('1','1','CHICKEN DISHES','FOOD','RESTO','CHICKEN DISHES','Active','instructor','2014-03-02 17:03:36','instructor','2014-04-22 17:39:57'),('1','1','DESSERT','FOOD','RESTO','DESSERT','Active','instructor','2014-03-05 13:34:46','instructor','2014-03-05 13:34:46'),('1','1','FRUITS','DESSERT','RESTO','FRIUTS','Active','instructor','2014-03-04 18:58:33','instructor','2014-03-04 18:58:33'),('1','1','SHAKE','DESSERT','RESTO','SHAKE','Active','instructor','2014-03-04 09:24:48','instructor','2014-03-04 09:24:48'),('1','1','SOFTDRINKS','BEVERAGE','RESTO','SOFTDRINKS','Active','instructor','2014-03-02 17:03:14','instructor','2014-03-02 17:03:14'),('1','1','SWEETS','DESSERT','RESTO','SWEETS','Active','instructor','2014-03-02 17:16:19','instructor','2014-03-02 17:20:45'),('1','1','TEA','BEVERAGE','RESTO','TEA','Active','instructor','2014-03-03 18:36:38','instructor','2014-03-03 18:36:38');
/*!40000 ALTER TABLE `itemgroups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemledger`
--

DROP TABLE IF EXISTS `itemledger`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemledger` (
  `propertyId` varchar(30) collate utf8_unicode_ci default '',
  `locationId` varchar(30) collate utf8_unicode_ci default '',
  `ledgerId` int(11) NOT NULL auto_increment,
  `itemId` varchar(30) collate utf8_unicode_ci default '',
  `moduleName` varchar(100) collate utf8_unicode_ci default '',
  `documentId` varchar(30) collate utf8_unicode_ci default '',
  `fromLocation` varchar(30) collate utf8_unicode_ci default '',
  `toLocation` varchar(30) collate utf8_unicode_ci default '',
  `beginningBalance` double(12,2) default '0.00',
  `quantity` double(12,2) default '0.00',
  `serialNo` text collate utf8_unicode_ci,
  `dateCode` datetime default NULL,
  `lotNo` varchar(30) collate utf8_unicode_ci default '',
  `inventoryAction` varchar(30) collate utf8_unicode_ci default '',
  `endingBalance` double(12,2) default '0.00',
  `createdBy` varchar(30) collate utf8_unicode_ci default '',
  `createdAt` datetime default '1900-01-01 00:00:00',
  `updatedBy` varchar(30) collate utf8_unicode_ci default '',
  `updatedAt` datetime default '1900-01-01 00:00:00',
  PRIMARY KEY  (`ledgerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemledger`
--

LOCK TABLES `itemledger` WRITE;
/*!40000 ALTER TABLE `itemledger` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemledger` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemlocations`
--

DROP TABLE IF EXISTS `itemlocations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itemlocations` (
  `propertyId` varchar(30) NOT NULL,
  `locationId` varchar(30) NOT NULL,
  `itemId` int(11) NOT NULL,
  `quantity` double(12,5) default '0.00000',
  `sellingPrice` double(12,2) default '0.00',
  `preparationArea` varchar(30) default NULL,
  `minStockLevel` double(12,2) default '0.00',
  `maxStockLevel` double(12,2) default '0.00',
  `localTax` double(12,2) default '0.00',
  `evat` double(12,2) default '0.00',
  `serviceCharge` double(12,2) default '0.00',
  `status` enum('Active','Deleted') default 'Active',
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default '1900-01-01 00:00:00',
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default '1900-01-01 00:00:00',
  PRIMARY KEY  (`propertyId`,`locationId`,`itemId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemlocations`
--

LOCK TABLES `itemlocations` WRITE;
/*!40000 ALTER TABLE `itemlocations` DISABLE KEYS */;
INSERT INTO `itemlocations` VALUES ('1','1',1,0.00000,150.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-02 17:04:52','instructor','2014-03-03 18:28:03'),('1','1',2,0.00000,180.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-02 17:05:50','instructor','2014-03-02 17:05:50'),('1','1',3,0.00000,150.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-02 17:07:04','instructor','2014-03-02 17:07:04'),('1','1',4,0.00000,15.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-02 17:07:42','instructor','2014-03-02 17:07:42'),('1','1',5,0.00000,15.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-02 17:08:11','instructor','2014-03-02 17:08:11'),('1','1',6,0.00000,160.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-02 17:09:12','instructor','2014-03-02 17:09:12'),('1','1',7,0.00000,40.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-02 17:17:19','instructor','2014-03-02 17:18:07'),('1','1',8,0.00000,50.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-02 17:19:18','instructor','2014-03-02 17:19:18'),('1','1',9,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Deleted','instructor','2014-03-02 17:21:36','instructor','2014-04-22 17:48:56'),('1','1',10,0.00000,20.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 17:41:52','instructor','2014-04-22 17:46:51'),('1','1',11,0.00000,65.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 17:44:28','instructor','2014-04-22 17:44:28'),('1','1',12,0.00000,15.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 17:45:53','instructor','2014-04-22 17:45:53'),('1','1',13,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 17:47:54','instructor','2014-04-22 17:47:54'),('1','1',14,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 17:48:48','instructor','2014-04-23 12:02:32'),('1','1',15,0.00000,50.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 17:50:06','instructor','2014-04-22 17:50:06'),('1','1',16,0.00000,55.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 17:53:22','instructor','2014-04-22 17:53:22'),('1','1',17,0.00000,90.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 17:54:30','instructor','2014-04-22 17:54:30'),('1','1',18,0.00000,200.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 17:56:56','instructor','2014-04-22 17:56:56'),('1','1',19,0.00000,250.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Deleted','instructor','2014-04-22 17:57:53','instructor','2014-03-04 09:44:24'),('1','1',20,0.00000,150.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 17:59:01','instructor','2014-04-22 17:59:01'),('1','1',21,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 18:00:17','instructor','2014-04-22 18:00:17'),('1','1',22,0.00000,80.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 18:01:46','instructor','2014-04-22 18:01:46'),('1','1',23,0.00000,15.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 18:04:52','instructor','2014-04-22 18:04:52'),('1','1',24,0.00000,45.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-03 18:37:28','instructor','2014-03-03 18:37:28'),('1','1',25,0.00000,35.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-03 18:37:58','instructor','2014-03-03 18:37:58'),('1','1',26,0.00000,45.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-04-22 18:42:07','instructor','2014-04-22 18:42:07'),('1','1',27,0.00000,40.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 18:59:25','instructor','2014-03-04 18:59:25'),('1','1',28,0.00000,25.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 19:00:15','instructor','2014-03-04 19:00:15'),('1','1',29,0.00000,30.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 19:01:40','instructor','2014-04-23 12:02:48'),('1','1',30,0.00000,100.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:12:56','instructor','2014-03-04 09:12:56'),('1','1',31,0.00000,100.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:13:38','instructor','2014-03-04 09:13:38'),('1','1',32,0.00000,15.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:14:37','instructor','2014-03-04 09:15:45'),('1','1',33,0.00000,45.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:15:34','instructor','2014-03-04 09:15:34'),('1','1',34,0.00000,120.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:17:29','instructor','2014-03-04 09:19:53'),('1','1',35,0.00000,150.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:18:21','instructor','2014-03-04 09:19:37'),('1','1',36,0.00000,100.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:19:07','instructor','2014-03-04 09:19:07'),('1','1',37,0.00000,180.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:20:50','instructor','2014-03-04 09:20:50'),('1','1',38,0.00000,100.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:21:48','instructor','2014-03-04 09:21:48'),('1','1',39,0.00000,150.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:23:27','instructor','2014-03-04 09:23:27'),('1','1',40,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:25:29','instructor','2014-03-04 09:25:29'),('1','1',41,0.00000,50.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:26:00','instructor','2014-03-04 09:26:00'),('1','1',42,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:26:27','instructor','2014-03-04 09:26:27'),('1','1',43,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:27:09','instructor','2014-03-04 09:27:09'),('1','1',44,0.00000,50.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:27:58','instructor','2014-03-04 09:27:58'),('1','1',45,0.00000,50.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:28:59','instructor','2014-03-04 09:28:59'),('1','1',46,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:29:29','instructor','2014-03-04 09:29:29'),('1','1',47,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:30:03','instructor','2014-03-04 09:30:03'),('1','1',48,0.00000,50.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:30:40','instructor','2014-03-04 09:30:40'),('1','1',49,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 09:33:50','instructor','2014-03-04 09:35:03'),('1','1',50,0.00000,50.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 10:13:44','instructor','2014-03-04 10:13:44'),('1','1',51,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 10:33:05','instructor','2014-03-04 10:33:05'),('1','1',52,0.00000,50.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 10:35:06','instructor','2014-03-04 10:35:06'),('1','1',53,0.00000,55.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:43:53','instructor','2014-03-04 12:44:30'),('1','1',54,0.00000,60.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:45:59','instructor','2014-03-04 12:45:59'),('1','1',55,0.00000,65.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:46:34','instructor','2014-03-04 12:46:34'),('1','1',56,0.00000,65.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:47:08','instructor','2014-03-04 12:47:08'),('1','1',57,0.00000,65.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:47:40','instructor','2014-03-04 12:47:40'),('1','1',58,0.00000,65.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:48:18','instructor','2014-03-04 12:48:18'),('1','1',59,0.00000,60.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:49:05','instructor','2014-03-04 12:49:05'),('1','1',60,0.00000,65.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:49:56','instructor','2014-03-04 12:49:56'),('1','1',61,0.00000,65.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:50:35','instructor','2014-03-04 12:50:35'),('1','1',62,0.00000,75.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:51:26','instructor','2014-03-04 12:51:26'),('1','1',63,0.00000,75.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:52:01','instructor','2014-03-04 12:52:01'),('1','1',64,0.00000,75.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:52:33','instructor','2014-03-04 12:52:33'),('1','1',65,0.00000,180.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:53:07','instructor','2014-03-04 12:53:07'),('1','1',66,0.00000,180.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:53:47','instructor','2014-03-04 12:53:47'),('1','1',67,0.00000,70.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:55:44','instructor','2014-03-04 12:55:44'),('1','1',68,0.00000,65.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:56:47','instructor','2014-03-04 12:56:47'),('1','1',69,0.00000,100.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:57:41','instructor','2014-03-04 12:57:41'),('1','1',70,0.00000,90.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 12:58:32','instructor','2014-03-04 12:58:32'),('1','1',71,0.00000,80.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 13:00:57','instructor','2014-03-04 13:00:57'),('1','1',72,0.00000,65.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-04 13:01:39','instructor','2014-03-04 13:01:39'),('1','1',73,0.00000,55.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-05 13:36:20','instructor','2014-03-05 13:36:20'),('1','1',74,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-05 13:36:50','instructor','2014-03-05 13:36:50'),('1','1',75,0.00000,55.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-05 13:37:40','instructor','2014-03-05 13:37:40'),('1','1',76,0.00000,55.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-05 13:38:17','instructor','2014-03-05 13:38:17'),('1','1',77,0.00000,70.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-05 13:38:52','instructor','2014-03-05 13:38:52'),('1','1',78,0.00000,170.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-06 14:03:31','instructor','2014-03-06 14:03:31'),('1','1',79,0.00000,120.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-06 14:04:07','instructor','2014-03-06 14:04:07'),('1','1',80,0.00000,150.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-06 14:04:46','instructor','2014-03-06 14:04:46'),('1','1',81,0.00000,160.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-06 14:05:22','instructor','2014-03-06 14:05:22'),('1','1',82,0.00000,180.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-07 14:16:12','instructor','2014-03-07 14:16:12'),('1','1',83,0.00000,200.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-07 14:17:43','instructor','2014-03-07 14:17:43'),('1','1',84,0.00000,150.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-07 14:19:41','instructor','2014-03-07 14:19:41'),('1','1',85,0.00000,190.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-07 14:20:37','instructor','2014-03-07 14:20:37'),('1','1',86,0.00000,250.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-07 14:21:19','instructor','2014-03-07 14:21:19'),('1','1',87,0.00000,85.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-08 14:58:14','instructor','2014-03-08 14:59:07'),('1','1',88,0.00000,80.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-08 14:58:56','instructor','2014-03-08 14:58:56'),('1','1',89,0.00000,45.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-09 15:13:27','instructor','2014-03-09 15:13:27'),('1','1',90,0.00000,45.00,'BAR',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-09 15:14:03','instructor','2014-03-09 15:14:03'),('1','1',91,0.00000,45.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-09 15:15:03','instructor','2014-03-09 15:15:03'),('1','1',92,0.00000,35.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-09 15:19:59','instructor','2014-03-09 15:19:59'),('1','1',93,0.00000,40.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-09 15:21:11','instructor','2014-03-09 15:21:11'),('1','1',94,0.00000,20.00,'KITCHEN',0.00,0.00,0.00,12.00,0.00,'Active','instructor','2014-03-09 15:21:55','instructor','2014-03-09 15:21:55');
/*!40000 ALTER TABLE `itemlocations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `items`
--

DROP TABLE IF EXISTS `items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `items` (
  `itemId` int(11) NOT NULL auto_increment,
  `groupId` varchar(30) default '',
  `description` varchar(255) default '',
  `unit` varchar(10) default '',
  `unitCost` double(12,2) default '0.00',
  `sellingPrice` double(12,2) default '0.00',
  `managedBySerialNumbers` enum('Yes','No') default 'No',
  `managedByDateCode` enum('Yes','No') default 'No',
  `managedByLotNo` enum('Yes','No') default 'No',
  `isInventoryItems` enum('Yes','No') default 'No',
  `status` enum('Active','Deleted') default 'Active',
  `createdBy` varchar(30) default '',
  `createdAt` datetime default '1900-01-01 00:00:00',
  `updatedBy` varchar(30) default '',
  `updatedAt` datetime default '1900-01-01 00:00:00',
  `itemIdSAP` varchar(50) default '',
  PRIMARY KEY  (`itemId`)
) ENGINE=InnoDB AUTO_INCREMENT=95 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `items`
--

LOCK TABLES `items` WRITE;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` VALUES (1,'CHICKEN DISHES','FRIED CHICKEN','SERVING',0.00,150.00,'No','No','No','No','Active','instructor','2014-03-02 17:04:52','instructor','2014-03-03 18:28:03',''),(2,'CHICKEN DISHES','CHICKEN FILLET','SERVING',0.00,180.00,'No','No','No','No','Active','instructor','2014-03-02 17:05:50','instructor','2014-03-02 17:05:50',''),(3,'CHICKEN DISHES','FRIED CHICKEN','SERVING',0.00,150.00,'No','No','No','No','Active','instructor','2014-03-02 17:07:04','instructor','2014-03-02 17:07:04',''),(4,'SOFTDRINKS','PEPSI','SHOT',0.00,15.00,'No','No','No','No','Active','instructor','2014-03-02 17:07:42','instructor','2014-03-02 17:07:42',''),(5,'SOFTDRINKS','MERIENDA','SHOT',0.00,15.00,'No','No','No','No','Active','instructor','2014-03-02 17:08:11','instructor','2014-03-02 17:08:11',''),(6,'CHICKEN DISHES','TINOLANG MANOK','SERVING',0.00,160.00,'No','No','No','No','Active','instructor','2014-03-02 17:09:12','instructor','2014-03-02 17:09:12',''),(7,'SWEETS','CAKE','SERVING',0.00,40.00,'No','No','No','No','Active','instructor','2014-03-02 17:17:19','instructor','2014-03-02 17:18:07',''),(8,'SWEETS','LECHE FLAN','SERVING',0.00,50.00,'No','No','No','No','Active','instructor','2014-03-02 17:19:18','instructor','2014-03-02 17:19:18',''),(9,'BROWNIES','BROWNIES','SERVING',0.00,45.00,'No','No','No','No','Deleted','instructor','2014-03-02 17:21:35','instructor','2014-04-22 17:48:56',''),(10,'SOFTDRINKS','MOUNTAIN DEW','SHOT',0.00,20.00,'No','No','No','No','Active','instructor','2014-04-22 17:41:52','instructor','2014-04-22 17:46:51',''),(11,'BREAKFAST','FRIED RICE W/ EGG','SERVING',0.00,65.00,'No','No','No','No','Active','instructor','2014-04-22 17:44:28','instructor','2014-04-22 17:44:28',''),(12,'SOFTDRINKS','COKE','SHOT',0.00,15.00,'No','No','No','No','Active','instructor','2014-04-22 17:45:53','instructor','2014-04-22 17:45:53',''),(13,'SWEETS','BROWNIES','SHOT',0.00,45.00,'No','No','No','No','Active','instructor','2014-04-22 17:47:54','instructor','2014-04-22 17:47:54',''),(14,'SWEETS','COOKIES','SERVING',0.00,45.00,'No','No','No','No','Active','instructor','2014-04-22 17:48:48','instructor','2014-04-23 12:02:32',''),(15,'BREAKFAST','BREAD W/ HOTDOG AND HAM','SERVING',0.00,50.00,'No','No','No','No','Active','instructor','2014-04-22 17:50:06','instructor','2014-04-22 17:50:06',''),(16,'BREAKFAST','OATMEAL','SERVING',0.00,55.00,'No','No','No','No','Active','instructor','2014-04-22 17:53:22','instructor','2014-04-22 17:53:22',''),(17,'BREAKFAST','CHEESE TOAST','SERVING',0.00,90.00,'No','No','No','No','Active','instructor','2014-04-22 17:54:30','instructor','2014-04-22 17:54:30',''),(18,'BREAKFAST','FRENCH TOAST','SERVING',0.00,200.00,'No','No','No','No','Active','instructor','2014-04-22 17:56:56','instructor','2014-04-22 17:56:56',''),(19,'BREAKFAST','FRESHLY SQUEEZED ORANGE JUICE','SERVING',0.00,250.00,'No','No','No','No','Deleted','instructor','2014-04-22 17:57:53','instructor','2014-03-04 09:44:24',''),(20,'BREAKFAST','EGGS ROYALE','SERVING',0.00,150.00,'No','No','No','No','Active','instructor','2014-04-22 17:59:01','instructor','2014-04-22 17:59:01',''),(21,'BREAKFAST','SUNNY SIDE UP','SERVING',0.00,45.00,'No','No','No','No','Active','instructor','2014-04-22 18:00:17','instructor','2014-04-22 18:00:17',''),(22,'BREAKFAST','SCRAMBLED EGG CREPE W/ DICED TOMATOES','SERVING',0.00,80.00,'No','No','No','No','Active','instructor','2014-04-22 18:01:46','instructor','2014-04-22 18:01:46',''),(23,'SOFTDRINKS','SPRITE','SHOT',0.00,15.00,'No','No','No','No','Active','instructor','2014-04-22 18:04:52','instructor','2014-04-22 18:04:52',''),(24,'TEA','GREEN TEA','SHOT',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-03 18:37:28','instructor','2014-03-03 18:37:28',''),(25,'TEA','LIPTON TEA','SHOT',0.00,35.00,'No','No','No','No','Active','instructor','2014-03-03 18:37:58','instructor','2014-03-03 18:37:58',''),(26,'TEA','ICE TEA','SHOT',0.00,45.00,'No','No','No','No','Active','instructor','2014-04-22 18:42:07','instructor','2014-04-22 18:42:07',''),(27,'FRUITS','WATERMELON','SERVING',0.00,40.00,'No','No','No','No','Active','instructor','2014-03-04 18:59:25','instructor','2014-03-04 18:59:25',''),(28,'FRUITS','ORANGE','SERVING',0.00,25.00,'No','No','No','No','Active','instructor','2014-03-04 19:00:15','instructor','2014-03-04 19:00:15',''),(29,'FRUITS','APPLE','SERVING',0.00,30.00,'No','No','No','No','Active','instructor','2014-03-04 19:01:40','instructor','2014-04-23 12:02:48',''),(30,'FRUITS','GRAPES','SERVING',0.00,100.00,'No','No','No','No','Active','instructor','2014-03-04 09:12:56','instructor','2014-03-04 09:12:56',''),(31,'FRUITS','STRAWBERRY','SERVING',0.00,100.00,'No','No','No','No','Active','instructor','2014-03-04 09:13:38','instructor','2014-03-04 09:13:38',''),(32,'SOFTDRINKS','ROYAL','SHOT',0.00,15.00,'No','No','No','No','Active','instructor','2014-03-04 09:14:37','instructor','2014-03-04 09:15:45',''),(33,'TEA','LEMONADE TEA','SHOT',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-04 09:15:34','instructor','2014-03-04 09:15:34',''),(34,'DESSERT','MACARONI SALAD','SERVING',0.00,120.00,'No','No','No','No','Active','instructor','2014-03-04 09:17:29','instructor','2014-03-04 09:19:53',''),(35,'DESSERT','FRUIT SALAD','SERVING',0.00,150.00,'No','No','No','No','Active','instructor','2014-03-04 09:18:21','instructor','2014-03-04 09:19:37',''),(36,'DESSERT','BUKO SALAD','SERVING',0.00,100.00,'No','No','No','No','Active','instructor','2014-03-04 09:19:07','instructor','2014-03-04 09:19:07',''),(37,'DESSERT','SPECIAL HALO-HALO','SERVING',0.00,180.00,'No','No','No','No','Active','instructor','2014-03-04 09:20:50','instructor','2014-03-04 09:20:50',''),(38,'DESSERT','MIXED-IN ICECREAM','SERVING',0.00,100.00,'No','No','No','No','Active','instructor','2014-03-04 09:21:48','instructor','2014-03-04 09:21:48',''),(39,'FRUITS','CHERRY','SERVING',0.00,150.00,'No','No','No','No','Active','instructor','2014-03-04 09:23:27','instructor','2014-03-04 09:23:27',''),(40,'SHAKE','MOCHA SHAKE','SERVING',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-04 09:25:29','instructor','2014-03-04 09:25:29',''),(41,'SHAKE','FRUIT SHAKE','SERVING',0.00,50.00,'No','No','No','No','Active','instructor','2014-03-04 09:26:00','instructor','2014-03-04 09:26:00',''),(42,'SHAKE','MANGO SHAKE','SERVING',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-04 09:26:27','instructor','2014-03-04 09:26:27',''),(43,'SHAKE','COOKIES AND CREAM','SERVING',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-04 09:27:09','instructor','2014-03-04 09:27:09',''),(44,'SHAKE','DOUBLE DUTCH ','SERVING',0.00,50.00,'No','No','No','No','Active','instructor','2014-03-04 09:27:58','instructor','2014-03-04 09:27:58',''),(45,'SHAKE','APPLE SHAKE','SERVING',0.00,50.00,'No','No','No','No','Active','instructor','2014-03-04 09:28:59','instructor','2014-03-04 09:28:59',''),(46,'SHAKE','AVOCADO SHAKE','SERVING',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-04 09:29:29','instructor','2014-03-04 09:29:29',''),(47,'SHAKE','UBE SHAKE','SERVING',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-04 09:30:03','instructor','2014-03-04 09:30:03',''),(48,'SHAKE','MILKY SHAKE','SERVING',0.00,50.00,'No','No','No','No','Active','instructor','2014-03-04 09:30:40','instructor','2014-03-04 09:30:40',''),(49,'SHAKE','CHOCOLATE SHAKE','SERVING',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-04 09:33:50','instructor','2014-03-04 09:35:03',''),(50,'SHAKE','PANDAN SHAKE','SERVING',0.00,50.00,'No','No','No','No','Active','instructor','2014-03-04 10:13:44','instructor','2014-03-04 10:13:44',''),(51,'BREAKFAST','CHEESE BURGER','SERVING',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-04 10:33:05','instructor','2014-03-04 10:33:05',''),(52,'BREAKFAST','BURGER W/ EGG AND CHEESE','SERVING',0.00,50.00,'No','No','No','No','Active','instructor','2014-03-04 10:35:06','instructor','2014-03-04 10:35:06',''),(53,'SHAKE','MOCHA FRAPPUCCINO','SERVING',0.00,55.00,'No','No','No','No','Active','instructor','2014-03-04 12:43:53','instructor','2014-03-04 12:44:30',''),(54,'SHAKE','MCDONALDS SHAMROCK','SERVING',0.00,60.00,'No','No','No','No','Active','instructor','2014-03-04 12:45:59','instructor','2014-03-04 12:45:59',''),(55,'SHAKE','WEIGHT WATCHERS MILK','SERVING',0.00,65.00,'No','No','No','No','Active','instructor','2014-03-04 12:46:34','instructor','2014-03-04 12:46:34',''),(56,'SHAKE','PUMPKIN SHAKE','SERVING',0.00,65.00,'No','No','No','No','Active','instructor','2014-03-04 12:47:07','instructor','2014-03-04 12:47:07',''),(57,'SHAKE','CREAMSICLE FREEZE','SERVING',0.00,65.00,'No','No','No','No','Active','instructor','2014-03-04 12:47:40','instructor','2014-03-04 12:47:40',''),(58,'SHAKE','SNOW CREAM IN A BLENDER','SERVING',0.00,65.00,'No','No','No','No','Active','instructor','2014-03-04 12:48:18','instructor','2014-03-04 12:48:18',''),(59,'SHAKE','EASY BANANA MILKSHAKE','SERVING',0.00,60.00,'No','No','No','No','Active','instructor','2014-03-04 12:49:05','instructor','2014-03-04 12:49:05',''),(60,'SHAKE','BANANA SHAKE SMOOTHIE','SERVING',0.00,65.00,'No','No','No','No','Active','instructor','2014-03-04 12:49:56','instructor','2014-03-04 12:49:56',''),(61,'SHAKE','FRUIT LASSI','SERVING',0.00,65.00,'No','No','No','No','Active','instructor','2014-03-04 12:50:35','instructor','2014-03-04 12:50:35',''),(62,'SHAKE','CHOCOLATE ALMOND COFFEE FRAPPER','SERVING',0.00,75.00,'No','No','No','No','Active','instructor','2014-03-04 12:51:26','instructor','2014-03-04 12:51:26',''),(63,'SHAKE','ORIGINAL BRONX EGG CREAM','SERVING',0.00,75.00,'No','No','No','No','Active','instructor','2014-03-04 12:52:01','instructor','2014-03-04 12:52:01',''),(64,'SHAKE','IRISH PIRATE','SERVING',0.00,75.00,'No','No','No','No','Active','instructor','2014-03-04 12:52:33','instructor','2014-03-04 12:52:33',''),(65,'CHICKEN DISHES','CHICKEN CURRY','SERVING',0.00,180.00,'No','No','No','No','Active','instructor','2014-03-04 12:53:07','instructor','2014-03-04 12:53:07',''),(66,'CHICKEN DISHES','BUTTER CHICKEN','SERVING',0.00,180.00,'No','No','No','No','Active','instructor','2014-03-04 12:53:47','instructor','2014-03-04 12:53:47',''),(67,'TEA','BERRY QUICK CITRUS ICE TEA','SHOT',0.00,70.00,'No','No','No','No','Active','instructor','2014-03-04 12:55:44','instructor','2014-03-04 12:55:44',''),(68,'TEA','CITRUS TEA PUNCH','SHOT',0.00,65.00,'No','No','No','No','Active','instructor','2014-03-04 12:56:47','instructor','2014-03-04 12:56:47',''),(69,'TEA','BAVARIAN WILD BERRY FRUIT TEA POPS','SHOT',0.00,100.00,'No','No','No','No','Active','instructor','2014-03-04 12:57:41','instructor','2014-03-04 12:57:41',''),(70,'TEA','FRUITY GREEN TEA SMOTHIE','SHOT',0.00,90.00,'No','No','No','No','Active','instructor','2014-03-04 12:58:32','instructor','2014-03-04 12:58:32',''),(71,'BREAKFAST','PANCAKES','SERVING',0.00,80.00,'No','No','No','No','Active','instructor','2014-03-04 13:00:57','instructor','2014-03-04 13:00:57',''),(72,'BREAKFAST','CRUMB TOP BANANA MUFFINS','SERVING',0.00,65.00,'No','No','No','No','Active','instructor','2014-03-04 13:01:39','instructor','2014-03-04 13:01:39',''),(73,'DESSERT','ICE CREAM','SERVING',0.00,55.00,'No','No','No','No','Active','instructor','2014-03-05 13:36:20','instructor','2014-03-05 13:36:20',''),(74,'DESSERT','HALO HALO','SERVING',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-05 13:36:50','instructor','2014-03-05 13:36:50',''),(75,'DESSERT','MOCHA FRAPPUCCINO','SERVING',0.00,55.00,'No','No','No','No','Active','instructor','2014-03-05 13:37:40','instructor','2014-03-05 13:37:40',''),(76,'DESSERT','MCDONALDS SHAMROCK','SERVING',0.00,55.00,'No','No','No','No','Active','instructor','2014-03-05 13:38:17','instructor','2014-03-05 13:38:17',''),(77,'DESSERT','CREAMSICLE FREEZE','SERVING',0.00,70.00,'No','No','No','No','Active','instructor','2014-03-05 13:38:52','instructor','2014-03-05 13:38:52',''),(78,'CHICKEN DISHES','ARROZ CON POLLO W/ APPLES','SERVING',0.00,170.00,'No','No','No','No','Active','instructor','2014-03-06 14:03:31','instructor','2014-03-06 14:03:31',''),(79,'CHICKEN DISHES','CHICKEM MARSALA','SERVING',0.00,120.00,'No','No','No','No','Active','instructor','2014-03-06 14:04:07','instructor','2014-03-06 14:04:07',''),(80,'CHICKEN DISHES','CHICKEN STIR-FRY','SERVING',0.00,150.00,'No','No','No','No','Active','instructor','2014-03-06 14:04:46','instructor','2014-03-06 14:04:46',''),(81,'CHICKEN DISHES','COCONUT CHICKEN AND RICE','SERVING',0.00,160.00,'No','No','No','No','Active','instructor','2014-03-06 14:05:22','instructor','2014-03-06 14:05:22',''),(82,'CHICKEN DISHES','CHICKEN STAGONFF','SERVING',0.00,180.00,'No','No','No','No','Active','instructor','2014-03-07 14:16:12','instructor','2014-03-07 14:16:12',''),(83,'CHICKEN DISHES','MEDITERRANEAN CHICKEN','SERVING',0.00,200.00,'No','No','No','No','Active','instructor','2014-03-07 14:17:43','instructor','2014-03-07 14:17:43',''),(84,'CHICKEN DISHES','CHICKEN SANDWICHES W/ MELTED CHEESE','SERVING',0.00,150.00,'No','No','No','No','Active','instructor','2014-03-07 14:19:40','instructor','2014-03-07 14:19:40',''),(85,'CHICKEN DISHES','SLOW-COOKER CHICKEN W/ BACON','SERVING',0.00,190.00,'No','No','No','No','Active','instructor','2014-03-07 14:20:37','instructor','2014-03-07 14:20:37',''),(86,'CHICKEN DISHES','QUICK CHICKEN CURRY','SERVING',0.00,250.00,'No','No','No','No','Active','instructor','2014-03-07 14:21:19','instructor','2014-03-07 14:21:19',''),(87,'TEA','ICED COFFEE','SHOT',0.00,85.00,'No','No','No','No','Active','instructor','2014-03-08 14:58:14','instructor','2014-03-08 14:59:07',''),(88,'TEA','STRAWBERRY JULIUS','SHOT',0.00,80.00,'No','No','No','No','Active','instructor','2014-03-08 14:58:55','instructor','2014-03-08 14:58:55',''),(89,'SOFTDRINKS','FANTA COCA COLA','SHOT',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-09 15:13:27','instructor','2014-03-09 15:13:27',''),(90,'SOFTDRINKS','COKE ZERO','SHOT',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-09 15:14:03','instructor','2014-03-09 15:14:03',''),(91,'SOFTDRINKS','DIET COKE','SHOT',0.00,45.00,'No','No','No','No','Active','instructor','2014-03-09 15:15:03','instructor','2014-03-09 15:15:03',''),(92,'DESSERT','BIBINGKA MELTED W/ CHEESE','SERVING',0.00,35.00,'No','No','No','No','Active','instructor','2014-03-09 15:19:59','instructor','2014-03-09 15:19:59',''),(93,'DESSERT','PASTILLAS DE LECHE AND YEMA','SERVING',0.00,40.00,'No','No','No','No','Active','instructor','2014-03-09 15:21:11','instructor','2014-03-09 15:21:11',''),(94,'DESSERT','BUKO PIE','SERVING',0.00,20.00,'No','No','No','No','Active','instructor','2014-03-09 15:21:55','instructor','2014-03-09 15:21:55','');
/*!40000 ALTER TABLE `items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `locations`
--

DROP TABLE IF EXISTS `locations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `locations` (
  `propertyId` varchar(30) default '',
  `locationId` int(11) NOT NULL auto_increment,
  `name` varchar(30) NOT NULL default '',
  `owner` varchar(50) default '',
  `contactPerson` varchar(50) default '',
  `telephoneNumber` varchar(20) default '',
  `faxNumber` varchar(20) default '',
  `address` varchar(50) default '',
  `status` enum('Active','Deleted') default 'Active',
  `createdBy` varchar(30) default '',
  `createdAt` datetime default '1900-01-01 00:00:00',
  `updatedBy` varchar(30) default '',
  `updatedAt` datetime default '1900-01-01 00:00:00',
  PRIMARY KEY  (`locationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `locations`
--

LOCK TABLES `locations` WRITE;
/*!40000 ALTER TABLE `locations` DISABLE KEYS */;
/*!40000 ALTER TABLE `locations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `maingroups`
--

DROP TABLE IF EXISTS `maingroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `maingroups` (
  `propertyId` varchar(30) NOT NULL default '',
  `locationId` varchar(30) NOT NULL default '',
  `mainGroupId` varchar(30) NOT NULL default '',
  `description` varchar(255) default '',
  `status` enum('Active','Deleted') default 'Active',
  `createdBy` varchar(30) default '',
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default '',
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`propertyId`,`locationId`,`mainGroupId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `maingroups`
--

LOCK TABLES `maingroups` WRITE;
/*!40000 ALTER TABLE `maingroups` DISABLE KEYS */;
INSERT INTO `maingroups` VALUES ('1','1','BEVERAGE','BEVERAGE','Active','instructor','2014-03-02 16:59:00','instructor','2014-03-02 16:59:00'),('1','1','DESSERT','DESSERT','Deleted','instructor','2014-03-02 17:15:21','instructor','2014-03-05 13:30:07'),('1','1','FOOD','FOOD','Active','instructor','2014-03-02 16:58:43','instructor','2014-03-02 16:58:43');
/*!40000 ALTER TABLE `maingroups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `preparationarea`
--

DROP TABLE IF EXISTS `preparationarea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `preparationarea` (
  `propertyId` varchar(30) NOT NULL,
  `locationId` varchar(30) NOT NULL,
  `preparationCode` varchar(30) NOT NULL,
  `description` varchar(255) default NULL,
  `printerAssigned` varchar(300) default NULL,
  `status` enum('Active','Deleted') default 'Active',
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`propertyId`,`locationId`,`preparationCode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `preparationarea`
--

LOCK TABLES `preparationarea` WRITE;
/*!40000 ALTER TABLE `preparationarea` DISABLE KEYS */;
INSERT INTO `preparationarea` VALUES ('1','1','KITCHEN','kitchen','EPSON TM-T88V ReceiptE4','Active','admin','2014-02-10 11:59:34','admin','2014-02-11 10:42:22'),('1','1','RESTO','resto','EPSON TM-T81 Receipt','Active','admin','2014-02-10 11:59:25','admin','2014-02-11 10:42:32');
/*!40000 ALTER TABLE `preparationarea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pricehistory`
--

DROP TABLE IF EXISTS `pricehistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pricehistory` (
  `PriceID` bigint(20) NOT NULL auto_increment,
  `tankId` varchar(30) default NULL,
  `Price` decimal(12,2) default NULL,
  `dateCreated` datetime default NULL,
  PRIMARY KEY  (`PriceID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pricehistory`
--

LOCK TABLES `pricehistory` WRITE;
/*!40000 ALTER TABLE `pricehistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `pricehistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pumpreadings`
--

DROP TABLE IF EXISTS `pumpreadings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pumpreadings` (
  `id` bigint(20) NOT NULL auto_increment,
  `ShiftID` varchar(10) default NULL,
  `TransferFrom` datetime default '2001-01-01 01:01:01',
  `TransferTo` datetime default '2001-01-01 01:01:01',
  `StartCount` decimal(12,2) default '0.00',
  `EndCount` decimal(12,2) default '0.00',
  `TotalLiters` decimal(12,2) default '0.00',
  `PumpID` varchar(30) default NULL,
  `LocationID` varchar(30) default NULL,
  `PropertyID` varchar(30) default NULL,
  `Status` enum('Open','Closed') default 'Closed',
  `uprice` decimal(12,2) default '0.00',
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pumpreadings`
--

LOCK TABLES `pumpreadings` WRITE;
/*!40000 ALTER TABLE `pumpreadings` DISABLE KEYS */;
/*!40000 ALTER TABLE `pumpreadings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pumps`
--

DROP TABLE IF EXISTS `pumps`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pumps` (
  `PumpID` varchar(30) default NULL,
  `FuelType` varchar(60) default NULL,
  `ItemID` varchar(30) default NULL,
  `TankID` varchar(30) default NULL,
  `LocationID` varchar(30) default NULL,
  `PropertyID` varchar(30) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pumps`
--

LOCK TABLES `pumps` WRITE;
/*!40000 ALTER TABLE `pumps` DISABLE KEYS */;
/*!40000 ALTER TABLE `pumps` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pumptransactions`
--

DROP TABLE IF EXISTS `pumptransactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pumptransactions` (
  `id` bigint(20) NOT NULL auto_increment,
  `OrderDetailID` varchar(30) default NULL,
  `ItemID` varchar(30) default NULL,
  `PumpID` varchar(30) default NULL,
  `Liters` decimal(12,5) default NULL,
  `UnitPrice` decimal(12,2) default NULL,
  `Amount` decimal(12,4) default NULL,
  `CreatedDate` datetime default NULL,
  `Discount` decimal(12,4) default NULL,
  `ShiftID` varchar(10) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pumptransactions`
--

LOCK TABLES `pumptransactions` WRITE;
/*!40000 ALTER TABLE `pumptransactions` DISABLE KEYS */;
/*!40000 ALTER TABLE `pumptransactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sapconnections`
--

DROP TABLE IF EXISTS `sapconnections`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sapconnections` (
  `name` varchar(30) NOT NULL,
  `companyDatabase` varchar(30) default NULL,
  `companyUsername` varchar(30) default NULL,
  `companyPassword` varchar(30) default NULL,
  `databaseServer` varchar(30) default NULL,
  `databaseUsername` varchar(30) default NULL,
  `databasePassword` varchar(30) default NULL,
  `status` enum('ACTIVE','DELETED') default 'ACTIVE',
  PRIMARY KEY  (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sapconnections`
--

LOCK TABLES `sapconnections` WRITE;
/*!40000 ALTER TABLE `sapconnections` DISABLE KEYS */;
INSERT INTO `sapconnections` VALUES ('sap crown','CROWN2014_DB','manager','1234','192.168.1.11','sa','p@ssw0rd123','ACTIVE');
/*!40000 ALTER TABLE `sapconnections` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shiftingdate`
--

DROP TABLE IF EXISTS `shiftingdate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `shiftingdate` (
  `id` smallint(4) NOT NULL auto_increment,
  `shiftid` varchar(10) default NULL,
  `ShiftStart` datetime default NULL,
  `ShiftEnd` datetime default NULL,
  `locationid` varchar(10) default NULL,
  `propertyid` varchar(10) default NULL,
  `isHasOpenTrans` smallint(1) default '0' COMMENT '0 none, 1 has transaction made order header reference',
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shiftingdate`
--

LOCK TABLES `shiftingdate` WRITE;
/*!40000 ALTER TABLE `shiftingdate` DISABLE KEYS */;
/*!40000 ALTER TABLE `shiftingdate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sqlconnections`
--

DROP TABLE IF EXISTS `sqlconnections`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sqlconnections` (
  `name` varchar(30) NOT NULL,
  `server` varchar(30) default NULL,
  `port` varchar(30) default NULL,
  `database` varchar(30) default NULL,
  `username` varchar(30) default NULL,
  `password` varchar(30) default NULL,
  `status` enum('ACTIVE','DELETED') default 'ACTIVE',
  PRIMARY KEY  (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sqlconnections`
--

LOCK TABLES `sqlconnections` WRITE;
/*!40000 ALTER TABLE `sqlconnections` DISABLE KEYS */;
INSERT INTO `sqlconnections` VALUES ('server','192.168.1.11','3307','common','root','j1n15y5admin','ACTIVE');
/*!40000 ALTER TABLE `sqlconnections` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplieditems`
--

DROP TABLE IF EXISTS `supplieditems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `supplieditems` (
  `propertyId` varchar(30) default '',
  `locationId` varchar(30) default '',
  `supItemId` int(11) NOT NULL auto_increment,
  `itemId` varchar(30) default '',
  `supplierId` varchar(30) default '',
  `status` enum('Active','Deleted') default 'Active',
  `createdBy` varchar(30) default '',
  `createdAt` datetime default '1900-01-01 00:00:00',
  `updatedBy` varchar(30) default '',
  `updatedAt` datetime default '1900-01-01 00:00:00',
  PRIMARY KEY  (`supItemId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplieditems`
--

LOCK TABLES `supplieditems` WRITE;
/*!40000 ALTER TABLE `supplieditems` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplieditems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `supplier` (
  `propertyId` varchar(30) NOT NULL default '',
  `locationId` varchar(30) NOT NULL default '',
  `supplierId` varchar(30) NOT NULL,
  `SupplierName` varchar(200) default '',
  `Address1` varchar(200) default '',
  `Address2` varchar(200) default '',
  `contactPerson` varchar(50) default '',
  `postalAddress` varchar(50) default '',
  `phone` varchar(15) default '',
  `mobile` varchar(20) default '',
  `fax` varchar(20) default '',
  `email` varchar(50) default '',
  `url` varchar(100) default '',
  `defaultDiscount` double(12,2) default '0.00',
  `status` enum('Active','Deleted') default 'Active',
  `createdBy` varchar(30) default '',
  `createdAt` datetime default '1900-01-01 00:00:00',
  `UpdatedBy` varchar(30) default '',
  `UpdatedAt` datetime default '1900-01-01 00:00:00',
  PRIMARY KEY  (`propertyId`,`locationId`,`supplierId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tanks`
--

DROP TABLE IF EXISTS `tanks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tanks` (
  `TankID` bigint(20) NOT NULL auto_increment,
  `FuelType` varchar(60) default NULL,
  `Qty` decimal(12,5) default '0.00000',
  `CreatedDate` datetime default NULL,
  `CreatedBy` varchar(30) default NULL,
  `LocationID` varchar(30) default NULL,
  `PropertyID` varchar(30) default NULL,
  `TankName` varchar(30) default NULL,
  `Status` enum('Active','Inactive') default 'Active',
  `UpdatedDate` datetime default NULL,
  `UpdatedBy` varchar(30) default NULL,
  `CapitalCost` decimal(12,2) default '0.00',
  `SalesPrice` decimal(12,2) default '0.00',
  PRIMARY KEY  (`TankID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tanks`
--

LOCK TABLES `tanks` WRITE;
/*!40000 ALTER TABLE `tanks` DISABLE KEYS */;
/*!40000 ALTER TABLE `tanks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tanksdipping`
--

DROP TABLE IF EXISTS `tanksdipping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tanksdipping` (
  `id` bigint(20) NOT NULL auto_increment,
  `StartReading` decimal(12,2) default '0.00',
  `EndReading` decimal(12,2) default '0.00',
  `Totalliters` decimal(12,2) default '0.00',
  `CreatedTime` datetime default NULL,
  `shiftid` int(11) default NULL,
  `tankid` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tanksdipping`
--

LOCK TABLES `tanksdipping` WRITE;
/*!40000 ALTER TABLE `tanksdipping` DISABLE KEYS */;
/*!40000 ALTER TABLE `tanksdipping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unitconvertion`
--

DROP TABLE IF EXISTS `unitconvertion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unitconvertion` (
  `propertyId` varchar(30) default '',
  `locationId` varchar(30) default '',
  `convertionId` int(11) NOT NULL auto_increment,
  `itemId` varchar(30) default NULL,
  `fromUnit` varchar(30) default NULL,
  `fromQty` double(12,2) default '0.00',
  `toUnit` varchar(30) default NULL,
  `toQty` double(12,2) default '0.00',
  PRIMARY KEY  (`convertionId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unitconvertion`
--

LOCK TABLES `unitconvertion` WRITE;
/*!40000 ALTER TABLE `unitconvertion` DISABLE KEYS */;
/*!40000 ALTER TABLE `unitconvertion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `units`
--

DROP TABLE IF EXISTS `units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `units` (
  `propertyId` varchar(30) NOT NULL default '',
  `locationId` varchar(30) NOT NULL default '',
  `unitName` varchar(30) NOT NULL,
  `description` varchar(255) default '',
  `status` enum('Active','Deleted') default 'Active',
  `createdBy` varchar(30) default '',
  `createdAt` datetime default '1900-01-01 00:00:00',
  `updatedBy` varchar(30) default '',
  `updatedAt` datetime default '1900-01-01 00:00:00',
  PRIMARY KEY  (`propertyId`,`locationId`,`unitName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `units`
--

LOCK TABLES `units` WRITE;
/*!40000 ALTER TABLE `units` DISABLE KEYS */;
INSERT INTO `units` VALUES ('1','1','',NULL,'Deleted','','1900-01-01 00:00:00','','1900-01-01 00:00:00'),('1','1','GLAS','GLAS','Active','','1900-01-01 00:00:00','','1900-01-01 00:00:00'),('1','1','PACK','PACK','Active','','1900-01-01 00:00:00','','1900-01-01 00:00:00'),('1','1','PC','PC','Active','admin','2014-02-06 14:16:20','admin','2014-02-06 14:16:20'),('1','1','SERVING','SERVING','Active','','1900-01-01 00:00:00','','1900-01-01 00:00:00'),('1','1','SHOT','SHOT','Active','','1900-01-01 00:00:00','','1900-01-01 00:00:00'),('1','1','TUBE','TUBE','Active','','1900-01-01 00:00:00','','1900-01-01 00:00:00');
/*!40000 ALTER TABLE `units` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'common'
--
DELIMITER ;;
/*!50003 DROP FUNCTION IF EXISTS `fGetAvailableStocks` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetAvailableStocks`(
  pItemId varchar(30)
, pPropertyId varchar(30)
, pLocationTo varchar(30)) RETURNS varchar(30) CHARSET utf8
BEGIN
 return 
(select 
	itemlocations.quantity
from 
	itemlocations
where   itemlocations.itemId = pItemId
and	itemlocations.propertyID = pPropertyId
and     itemlocations.locationId = pLocationTo
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCreditApprovalCode` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetCreditApprovalCode`(
  pOrderId varchar(10)
) RETURNS varchar(100) CHARSET latin1
BEGIN
    
    return
    (
     ifnull((select APPROVAL_CODE 
     from pos.payment
     where payment.ORDER_ID = pOrderId
     and payment.PAYMENT_TYPE = 'CREDIT'), '')
    
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCurCashRemmited` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetCurCashRemmited`(
 pDate date
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
	/*Select IFNULL(sum(AMOUNT),0) as cashRemitted
	
	from pos.`payment`
	
	where payment_type = 'CASH'
	and `status` = 'OK'
	and date(PAYMENT_DATE) = pDate
	group by DATE(PAYMENT_DATE)*/
	
	/*select ifnull(sum(total_amount),0) as cashRemitted
	
	from pos.`order header`
	where customer_id = "WALK-IN"
	and date(order_date) = pDate
	and `status` = "SERVED"
	group by DATE(order_date)*/
	select ifnull(sum(amountremitted), 0) as cashRemitted
	from pos.cashiers_logs where transactiondate = pDate
	and type = 'Close'
	group by transactiondate
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCurFuelReceivable` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetCurFuelReceivable`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pDate date
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
     SELECT sum(Debit) AS rTotal
	from 
	( select distinct hotelmgtsystem.cityledger.Id,
			  hotelmgtsystem.cityledger.Debit
	FROM pumptransactions INNER JOIN hotelmgtsystem.cityledger 
		ON pumptransactions.OrderDetailID = hotelmgtsystem.cityledger.RefNo 
		AND DATE(pumptransactions.CreatedDate) = pDate
	WHERE fIsPumpPropertyOf( pLocationId, pPropertyId, pumptransactions.ItemID) = 1) as temp
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCurFuelSellingPrice` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetCurFuelSellingPrice`(
pItemId int(11)
) RETURNS decimal(12,2)
BEGIN
    
    RETURN
    (
     /*SELECT  AVG(pricehistory.Price)
	FROM tanks RIGHT JOIN 
		pricehistory ON tanks.tankId = pricehistory.tankId 
		AND tanks.LocationID = pLocationId AND tanks.PropertyID = pPropertyId
	WHERE tanks.FuelType = pFuelType
	and date(pricehistory.dateCreated) = pDate */
	
/*SELECT	AVG(pricehistory.Price) AS price
	FROM tanks RIGHT JOIN 
		pricehistory ON tanks.tankId = pricehistory.tankId 
		AND tanks.LocationID = pLocationId AND tanks.PropertyID = pPropertyId		
	WHERE tanks.FuelType = pFuelType
	GROUP BY DATE(dateCreated)	
	ORDER BY dateCreated DESC		
	LIMIT 1	*/
	
	select 	sellingPrice 
	from itemlocations
	where itemid = pItemId
    
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCurShiftDiscAmount` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetCurShiftDiscAmount`(
   pDate date
 , pShift varchar(10)
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
	select ifNUll(sum(od.qty * od.discountrate), 0)
	from pos.`order header` h
	inner join pos.`order_detail_discqty` od
	on h.order_id = od.orderid
	where od.discountrate > 0
	and date(h.order_date) = pDate
	and h.SHIFT_CODE = pShift
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCurShiftFuelSellingPrice` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetCurShiftFuelSellingPrice`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pPumpId varchar(30)
, pDate date
, pShiftId varchar(10)
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
    SELECT unitprice 
	FROM pumptransactions 
	WHERE fIsPumpPropertyOf(pLocationId, pPropertyId, pumptransactions.ItemID) = 1 
	AND DATE(pumptransactions.CreatedDate) = pDate
	AND pumptransactions.ShiftId = pShiftId  
	AND fGetFuelType(pLocationId, pPropertyId,pumptransactions.PumpID) = fGetFuelType(pLocationId, pPropertyId, pPumpId)
	GROUP BY fGetFuelType(pLocationId, pPropertyId,pumptransactions.PumpID)
    
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCustomerName` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetCustomerName`(
 pId varchar(30)
) RETURNS varchar(50) CHARSET latin1
BEGIN
    
    RETURN
    (
	Select concat(pos.employee.LASTNAME, ', ', pos.employee.FIRSTNAME) as `name`
	from pos.employee
	where pos.employee.EMPLOYEE_ID = pId
    
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetDiscountedFuelLitersPerPump` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetDiscountedFuelLitersPerPump`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pPumpId varchar(30)
, pDate date
, pShiftId varchar(10)
) RETURNS decimal(12,2)
BEGIN
    
    return
    (	select SUM(pumptransactions.Liters) AS Liters       
	FROM pumptransactions
	WHERE pumptransactions.pumpid = pPumpId
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, pumptransactions.ItemID) = 1
	and date(pumptransactions.CreatedDate) = pDate
	and pumptransactions.Discount != 0
	and pumptransactions.ShiftId = pShiftId
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetEndingBalance` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetEndingBalance`(
pItemID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30)) RETURNS varchar(30) CHARSET utf8
BEGIN
return  (select itemlocations.quantity from itemlocations where itemlocations.itemId=pItemID and locationid=pLocationID and propertyid=pPropertyID);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetEndShiftOfTheDay` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetEndShiftOfTheDay`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pDate date
) RETURNS varchar(10) CHARSET latin1
BEGIN
    
    return
    (
     SELECT MAX(pumpreadings.shiftid) FROM pumpreadings WHERE DATE(pumpreadings.TransferFrom) = pDate
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFirstShiftOfTheDay` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetFirstShiftOfTheDay`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pDate date
) RETURNS varchar(10) CHARSET latin1
BEGIN
    
    return
    (
     SELECT  DISTINCT shiftid	 
	FROM pumpreadings
	WHERE DATE(transferfrom) = pDate
	and pumpreadings.`StartCount` != 0
	ORDER BY transferfrom
	LIMIT 1
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFuelDelivery` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetFuelDelivery`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pFuelType varchar(30)
, pDate date
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
         SELECT itemledger.quantity
	    FROM pumps LEFT JOIN itemledger ON pumps.ItemID = itemledger.itemId AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId
	    WHERE pumps.FuelType = pFuelType
	    AND itemledger.moduleName = 'Goods Receipt'
	    AND DATE(itemledger.updatedAt) = pDate	    
	    GROUP BY pumps.FuelType 
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFuelDiscountPerPump` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetFuelDiscountPerPump`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pPumpId VARCHAR(30)
, pDate DATE
, pShiftId VARCHAR(10)
) RETURNS decimal(12,2)
BEGIN
    
    RETURN
    (
     SELECT AVG(pumptransactions.Discount / pumptransactions.Liters)  AS DiscountPHP    
	FROM pumptransactions
	WHERE pumptransactions.pumpid = pPumpId
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, pumptransactions.ItemID) = 1
	AND DATE(pumptransactions.CreatedDate) = pDate
	AND pumptransactions.Discount != 0
	AND pumptransactions.ShiftId = pShiftId
    
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFuelItemId` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetFuelItemId`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pPumpId varchar(30)
) RETURNS varchar(10) CHARSET latin1
BEGIN
    
    return
    (
     SELECT pumps.ItemID
	FROM pumps
	WHERE pumps.LocationID = pLocationId
	AND pumps.PropertyID = pPropertyId
	AND pumps.PumpID = pPumpId  
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFuelMonthToDateGrossSales` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetFuelMonthToDateGrossSales`(pMonth int, pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount) + sum(total_discount) from pos.`order header` where month(order_date)=pMonth and year(order_date)=pYear and status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFuelOpeningStock` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetFuelOpeningStock`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pFuelType varchar(30)
, pDate date
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
          SELECT itemledger.beginningBalance
	    FROM pumps LEFT JOIN itemledger ON pumps.ItemID = itemledger.itemId AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId
	    WHERE pumps.FuelType = pFuelType
	    AND DATE(itemledger.updatedAt) = pDate
	    GROUP BY pumps.FuelType 
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFuelSales` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetFuelSales`(
   pDate date
 , pShift varchar(10)
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
	select sum(((p.totalliters - ifnull((SELECT calibrationliter  FROM calibration c WHERE c.shiftid = p.shiftid AND DATE(c.datecreated) = DATE(p.transferfrom) AND c.pumpid = p.PumpID),0)) * p.uprice)) AS sales 
	FROM pumpreadings p WHERE DATE(p.TransferFrom) = pDate AND p.shiftid = pShift
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFuelTotalGrossSales` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetFuelTotalGrossSales`() RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount)+ SUM(total_discount) FROM pos.`order header` where status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFuelType` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetFuelType`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pPumpId varchar(30)
) RETURNS varchar(30) CHARSET latin1
BEGIN
    
    return
    (
     SELECT  pumps.FuelType 
	FROM pumps
	WHERE pumps.PumpID = pPumpId
	AND pumps.LocationID = pLocationId
	AND pumps.PropertyID = pPropertyId
    
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFuelTypeAbrv` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetFuelTypeAbrv`(pItemId varchar(30)) RETURNS varchar(30) CHARSET latin1
BEGIN
 return (select substring(items.description,1,3)
	 from items 
	 where items.itemId = pItemId 
	 Group by items.itemId
	);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetFuelYearToDateGrossSales` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetFuelYearToDateGrossSales`(pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount) + SUM(total_discount) FROM pos.`order header` where year(order_date)=pYear and status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetItemDescription` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetItemDescription`(pItemId varchar(30)) RETURNS varchar(30) CHARSET utf8
BEGIN
 return (select items.description 
	 from items 
	 where items.itemId = pItemId 
	 Group by items.itemId
	);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fgetItemGroups` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fgetItemGroups`( 
  pItemId varchar(30)
, pPropertyId varchar(30) ) RETURNS varchar(30) CHARSET utf8
BEGIN
 return 
(select 
	itemgroups.groupId
	from itemgroups 
	left join items
	on items.groupId = itemgroups.groupId	
	where items.itemId = pItemId
	group by itemgroups.groupId
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetItemMainGroup` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetItemMainGroup`(pItemId varchar(30)) RETURNS varchar(30) CHARSET utf8
BEGIN
 return (SELECT 
	itemgroups.`mainGroupId`
	FROM itemgroups 
	LEFT JOIN items
	ON items.groupId = itemgroups.groupId	
	WHERE items.itemId = pItemId
	GROUP BY itemgroups.groupId
	);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetLocalStocks` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetLocalStocks`(
pItemId varchar(30)
, pPropertyId varchar(30)
, pLocationId varchar(30)) RETURNS varchar(30) CHARSET utf8
BEGIN
 return 
(select 
	itemlocations.quantity
from 
	itemlocations 
where   itemlocations.itemId = pItemId
and	itemlocations.propertyID = pPropertyId
and     itemlocations.locationId = pLocationId
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetLocationName` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetLocationName`(pLocationId varchar(30)) RETURNS varchar(30) CHARSET utf8
BEGIN
RETURN  (
SELECT  locations.name 
	FROM locations 
	WHERE locations.locationId = pLocationId
	);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetMaxDocumentID` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetMaxDocumentID`() RETURNS varchar(30) CHARSET utf8
BEGIN
  return (select MAX(CAST(documentId AS SIGNED))+1  AS MAXCOUNT from itemledger); 
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetMaxStockLevel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetMaxStockLevel`(
pItemId varchar(30)
, pPropertyId varchar(30)
, pLocationId varchar(30)) RETURNS varchar(30) CHARSET utf8
BEGIN
 return 
(select 
	itemlocations.maxStockLevel
from 
	itemlocations 
where   itemlocations.itemId = pItemId
and	itemlocations.propertyID = pPropertyId
and     itemlocations.locationId = pLocationId
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetMinStockLevel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetMinStockLevel`(
pItemId varchar(30)
, pPropertyId varchar(30)
, pLocationId varchar(30)) RETURNS varchar(30) CHARSET utf8
BEGIN
 return 
(select 
	itemlocations.minStockLevel
from 
	itemlocations 
where   itemlocations.itemId = pItemId
and	itemlocations.propertyID = pPropertyId
and     itemlocations.locationId = pLocationId
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetMonthPumpEndCountOfLastShift` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetMonthPumpEndCountOfLastShift`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pPumpId varchar(30)
, pMonth int
, pYear int
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
     SELECT pumpreadings.EndCount
	    FROM pumpreadings
	    WHERE pumpreadings.LocationID = pLocationId
	    AND pumpreadings.PropertyID = pPropertyId
	    AND DATE_FORMAT(pumpreadings.TransferTo, "%Y-%m") = CONCAT(pYear, '-', IF(LENGTH(pMonth) = 1, CONCAT('0', pMonth), pMonth))
	    AND pumpreadings.PumpID = pPumpId
	    ORDER BY pumpreadings.TransferFrom DESC 
	    LIMIT 1
    
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetMonthPumpStartCountOfFirstShift` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetMonthPumpStartCountOfFirstShift`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pPumpId VARCHAR(30)
, pMonth int
, pYear int
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
     SELECT pumpreadings.StartCount
	    FROM pumpreadings
	    WHERE pumpreadings.LocationID = pLocationId
	    AND pumpreadings.PropertyID = pPropertyId
	    AND DATE_FORMAT(pumpreadings.TransferFrom, "%Y-%m") = CONCAT(pYear, '-', IF(LENGTH(pMonth) = 1, CONCAT('0', pMonth), pMonth))
	    AND pumpreadings.PumpID = pPumpId
	    AND pumpreadings.`StartCount` != 0
	    ORDER BY pumpreadings.TransferFrom
	    LIMIT 1
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetOrderItemDescription` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetOrderItemDescription`(
pOrderId int(11)
) RETURNS text CHARSET latin1
BEGIN
return (
	SELECT GROUP_CONCAT(CONCAT(groupId, ' (', items.description,')')) AS description
	FROM pumptransactions INNER JOIN items
	ON pumptransactions.itemid = items.itemid
	WHERE pumptransactions.orderdetailid = pOrderId
	GROUP BY orderdetailid
	);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetPaymentType` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetPaymentType`(
  pOrderId VARCHAR(10)
) RETURNS varchar(100) CHARSET latin1
BEGIN
    
    RETURN
    (
     SELECT GROUP_CONCAT(IF(PAYMENT_TYPE = 'ACCOUNT_NONSTAY', 'ON ACCOUNT', PAYMENT_TYPE))
     FROM pos.payment
     WHERE payment.ORDER_ID = pOrderId
     GROUP BY ORDER_ID 
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetPumpEndCountOfLastShift` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetPumpEndCountOfLastShift`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pPumpId varchar(30)
, pShiftId varchar(3)
, pDate date
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
     SELECT pumpreadings.EndCount
	    FROM pumpreadings
	    WHERE pumpreadings.LocationID = pLocationId
	    AND pumpreadings.PropertyID = pPropertyId
	    AND DATE(pumpreadings.TransferFrom) = pDate
	    AND pumpreadings.PumpID = pPumpId
	    AND pumpreadings.ShiftID = pShiftId
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetPumpStartCountOfFirstShift` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetPumpStartCountOfFirstShift`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pPumpId VARCHAR(30)
, pShiftId VARCHAR(3)
, pDate DATE
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
     SELECT pumpreadings.StartCount
	    FROM pumpreadings
	    WHERE pumpreadings.LocationID = pLocationId
	    AND pumpreadings.PropertyID = pPropertyId
	    AND DATE(pumpreadings.TransferFrom) = pDate
	    AND pumpreadings.PumpID = pPumpId
	    AND pumpreadings.ShiftID = pShiftId
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetReadingFuelSales` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetReadingFuelSales`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pFuelType VARCHAR(30)
, pDate Date
) RETURNS decimal(12,2)
BEGIN
    
    RETURN
    ( 
	SELECT  SUM(totalliters) AS rLiters		
		FROM pumpreadings 
		wHERE DATE(transferto) = pDate
		and fGetFuelType(pLocationId, pPropertyId, pumpreadings.PumpID) = pFuelType
		and pumpreadings.LocationId = pLocationId
		and pumpreadings.PropertyId = pPropertyId
		GROUP BY description
         );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetSalesDiscount` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetSalesDiscount`(
   pDate date
 , pShift varchar(10)
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
	SELECT SUM(p.totalliters * (SELECT cost FROM pos.`function mapping` pf WHERE pf.function_id = 'F18' )) AS disc
FROM pumpreadings p
WHERE INSTR((SELECT `VALUE` FROM pos.`system_config` WHERE `KEY` = 'FOR_GASOLINE_LISTOFDISC_PUMP'),p.PumpID) -- p.PumpID IN ('PUMP3', 'PUMP4')
AND DATE(p.transferfrom) = pDate
AND p.shiftid = pShift
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetSalesDiscountByPump` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetSalesDiscountByPump`(
   pDate date
 , pShift varchar(10)
 , pPumpId varchar(30)
 , pLocationId VARCHAR(30)
 , pPropertyId VARCHAR(30)
) RETURNS decimal(12,2)
BEGIN
    
    return
    ifnull((
	SELECT p.totalliters * (SELECT cost FROM pos.`function mapping` pf WHERE pf.function_id = 'F18' ) AS disc
FROM pumpreadings p
WHERE INSTR((SELECT `VALUE` FROM pos.`system_config` WHERE `KEY` = 'FOR_GASOLINE_LISTOFDISC_PUMP'),p.PumpID) -- p.PumpID IN ('PUMP3', 'PUMP4')
AND DATE(p.transferfrom) = pDate
AND p.shiftid = pShift
and p.PumpID = pPumpId
and p.locationid = pLocationId
and p.propertyid = pPropertyId
    ), 0);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetSellingPrice` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetSellingPrice`(
  pItemId varchar(30)
, pPropertyId varchar(30)
) RETURNS varchar(30) CHARSET utf8
BEGIN
 return 
(	/*select items.sellingPrice 
	from items 
	where items.itemId = pItemId
	and items.status = 'Active'*/
	select sellingPrice 
	from `itemlocations` 
	where itemId = pItemId
	and status = 'Active'
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetShiftEndDate` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetShiftEndDate`(
pLocationId varchar(10),
pPropertyId varchar(10),
pShiftID varchar(10)) RETURNS datetime
BEGIN
 return
    (
     SELECT shiftEnd
	FROM shiftingDate
	WHERE LocationID = pLocationId
	AND PropertyID = pPropertyId
	AND shiftid=pShiftID  
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetShiftStartDate` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetShiftStartDate`(
pLocationId varchar(10),
pPropertyId varchar(10),
pShiftID varchar(10)) RETURNS datetime
BEGIN
 return
    (
     SELECT shiftstart
	FROM shiftingDate
	WHERE LocationID = pLocationId
	AND PropertyID = pPropertyId
	AND shiftid=pShiftID  
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetSupplierName` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetSupplierName`( 
PSUPPLIERID varchar(30)
,PROPERTYID varchar(30) 
,LOCATIONID varchar(30)
 ) RETURNS varchar(30) CHARSET utf8
BEGIN
 return 
(
 select supplier.SupplierName 
	from supplier 
	where supplierId = PSUPPLIERID
	and supplier.propertyId = PROPERTYID
	and supplier.locationId = LOCATIONID
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTankName` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTankName`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pFuelType varchar(30)
) RETURNS varchar(30) CHARSET latin1
BEGIN
    
    return
    (
     SELECT  tankName 
	FROM tanks
	WHERE  tanks.FuelType = pFuelType
	AND tanks.LocationID = pLocationId
	AND tanks.PropertyID = pPropertyId
    
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalFuelCharges` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetTotalFuelCharges`(pStartDate date,
pEndDate date) RETURNS decimal(12,2)
BEGIN
return (
SELECT SUM(payment.amount)
FROM pos.`order header` 
   INNER JOIN
   pos.payment
   ON `order header`.order_id = payment.order_id
   AND payment.status != 'VOID'
WHERE
   payment.payment_type LIKE 'ACCOUNT%'
   AND DATE(`order header`.order_date) BETWEEN pStartDate AND pEndDate
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalFuelGrossSales` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetTotalFuelGrossSales`() RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount + TOTAL_DISCOUNT) from pos.`order header` where status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalInhouseAmount` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalInhouseAmount`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pPumpId varchar(30)
, pDate date
, pShiftId varchar(10)
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
     SELECT SUM(employee_ledger.debit) AS rInhouseAmount	
	FROM pos.employee_ledger 
	INNER JOIN pumptransactions 
	ON pos.employee_ledger.ORDER_ID = pumptransactions.OrderDetailID 
	AND pos.employee_ledger.Date = pDate
	WHERE fIsPumpPropertyOf(pLocationId, pPropertyId,pumptransactions.ItemID) = 1
	AND fGetFuelType(pLocationId, pPropertyId,pumptransactions.PumpID) = fGetFuelType(pLocationId, pPropertyId, pPumpId)
	and pumptransactions.ShiftId = pShiftId	
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalSoldFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalSoldFuel`(
  pItemId varchar(30)
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pShiftId varchar(10)
, pSDate date
, pEDate date
) RETURNS decimal(12,2)
BEGIN
 return 
(select 
	ifNULL(sum(Liters),0.0)
from 
	pumptransactions 
where   ItemId = pItemId
and	If(pShiftId = 'ALL', True, ShiftId = pShiftId)
and 	date(`CreatedDate`) between pSDate and pEDate
and 	fIsPumpPropertyOf(pLocationId, pPropertyId, pItemId) = 1
group by ItemId
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTransactionFuelSales` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTransactionFuelSales`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pFuelType varchar(30)
, pDate date
) RETURNS decimal(12,2)
BEGIN
    
    return
    (
         SELECT SUM(Liters) AS rLiters		
		FROM pumptransactions LEFT JOIN pumps ON pumptransactions.ItemID = pumps.ItemID AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId
		WHERE DATE(createdDate) = pDate
		AND pumps.FuelType = pFuelType	
		GROUP BY pumps.FuelType
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetUnpostedStocks` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetUnpostedStocks`(
    pItemId VARCHAR(30),
    pLocationId VARCHAR(30)
  -- July 26, 2012 - Julz
  -- RETURNS VARCHAR(30) CHARSET latin1
) RETURNS varchar(30) CHARSET latin1
BEGIN
RETURN 
(
SELECT 
	-- July 25, 2012 - Julz
	-- SUM(pos.`order detail`.quantity) AS stocksCount 
	IFNULL(SUM(dtl.quantity), 0) as stocksCount
FROM pos.`order detail` dtl
left join pos.`order header` hdr
on dtl.ORDER_ID = hdr.ORDER_ID
WHERE dtl.OPERATION_STATUS <> 'CANCELLED' 
AND dtl.postedToAcctg = 0 
AND dtl.item_id = pItemId
and hdr.`STATUS` <> 'CANCELLED'
and hdr.TERMINAL_ID in (select terminalid from pos.`cashiers` c where c.restaurantid = pLocationId)
);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fHasTransBforStocking` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fHasTransBforStocking`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pFuelType VARCHAR(60)
, pLedgerId INT(11)
, pDate DATE
) RETURNS int(5)
BEGIN
    
    RETURN
    (
     SELECT COUNT(ledgerId) AS isOk
	FROM pumps LEFT JOIN itemledger ON pumps.ItemID = itemledger.itemId
	AND pumps.LocationID = pLocationId
	AND pumps.PropertyID = pPropertyId
	AND pumps.FuelType = pFuelType
	WHERE ledgerId < pLedgerId
	AND moduleName NOT IN ('Goods Receipt', 'Inventory - Restock')
	AND DATE(itemledger.updatedAt) = pDate
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fIsManagedByDateCode` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fIsManagedByDateCode`(
 pItemId varchar(30)
 ) RETURNS varchar(10) CHARSET latin1
BEGIN
 return (
	select items.managedByDateCode 
	from items 
	where items.itemId = pItemId 
	group by items.itemId
	);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fIsManagedByLotNo` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fIsManagedByLotNo`(
 pItemId varchar(30)
 ) RETURNS varchar(10) CHARSET latin1
BEGIN
 return (
	select items.managedByLotNo 
	from items 
	where items.itemId = pItemId 
	group by items.itemId);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fIsManagedBySerialNumber` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fIsManagedBySerialNumber`(
 pItemId varchar(30)
 ) RETURNS varchar(10) CHARSET latin1
BEGIN
 return (
	select items.managedBySerialNumbers 
	from items 
	where items.itemId = pItemId 
	group by items.itemId);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fIsPumpPropertyOf` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fIsPumpPropertyOf`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pItemId varchar(30)
) RETURNS varchar(10) CHARSET latin1
BEGIN
    
    return
    (
     SELECT IF(pumps.PropertyID = pPropertyId AND pumps.LocationID = pLocationId, TRUE, FALSE) AS isPropertyOf
	FROM pumps 
	WHERE pumps.ItemID = pItemId
    
    );
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fReturnNumbersInString` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fReturnNumbersInString`(in_string varchar(50)) RETURNS int(11)
    NO SQL
BEGIN
DECLARE ctrNumber varchar(50);
DECLARE finNumber varchar(50) default ' ';
DECLARE sChar varchar(2);
DECLARE inti INTEGER default 1;
IF length(in_string) > 0 THEN
WHILE(inti <= length(in_string)) DO
    SET sChar= SUBSTRING(in_string,inti,1);
    SET ctrNumber= FIND_IN_SET(sChar,'0,1,2,3,4,5,6,7,8,9');
    IF ctrNumber > 0 THEN
       SET finNumber=CONCAT(finNumber,sChar);
    ELSE
       SET finNumber=CONCAT(finNumber,'');
    END IF;
    SET inti=inti+1;
END WHILE;
RETURN CAST(finNumber AS SIGNED INTEGER) ;
ELSE
  RETURN 0;
END IF;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckDuplicateSupplieditem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckDuplicateSupplieditem`(
pItemid varchar(30),
pSupplierID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select count(itemid) as cnt from supplieditems where itemid=pItemid and supplierid=pSupplierID and status='active' 
and locationid=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckHasOpenTrans` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckHasOpenTrans`()
BEGIN
    select shiftingdate.isHasOpenTrans from shiftingdate,pos.cashiers where shiftingdate.shiftid=pos.cashiers.shiftcode;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIfCalibrationExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIfCalibrationExist`(
pShiftID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
    select if(count(id)>0,'True','False') as isExist from calibration where date(Now())=date(datecreated) and shiftid=pShiftID and locationid=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIfFuelMaingroupTrackerExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIfFuelMaingroupTrackerExist`(
pMaingroupID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select count(maingroupid) as cnt from fuelmaingrouptracker where Maingroupid=pMaingroupID and locationID=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIfFuelTypeExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spCheckIfFuelTypeExist`(
pFuelType varchar(30),
pPropertyID varchar(30),
pLocationID varchar(30))
BEGIN
select count(id) from fueltype where fueltype.FuelType=pFuelType and propertyid=pPropertyID and LocationID=pLocationID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIfItemGroupsExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spCheckIfItemGroupsExist`(
pPropertyid varchar(30),
pGroupid varchar(30)
)
BEGIN
select count(*) from itemgroups where propertyid=pPropertyid and groupid=pGroupid;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIfItemIsFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIfItemIsFuel`(
pItemID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select count(itemid) as cnt from pumps where itemid=pItemID and locationid=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIfItemLocationsExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spCheckIfItemLocationsExist`(
pPropertyid varchar(30),
pLocationid varchar(30),
pItemid varchar(30)
)
BEGIN
select count(*) from itemlocations where propertyid=pPropertyid and locationid=pLocationid and itemid=pItemid;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIfPumpHasTransaction` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIfPumpHasTransaction`(
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select itemid from pumps where pumpid=pPumpID and locationid=pLocationID
and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIFPumpReadingExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIFPumpReadingExist`(
pShiftID varchar(30),
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select count(shiftid) as cnt from pumpreadings where shiftid=pShiftID
and PumpID=pPumpID and locationid=pLocationID and propertyid=pPropertyID and  CURDATE() = DATE(pumpreadings.TransferFrom); -- and pumpreadings.Status='Open';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIFPumpsExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIFPumpsExist`(
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select count(PumpID) as cnt from pumps where pumpid=pPumpID and LocationID=pLocationID and propertyID=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIFPumpTransactionExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIFPumpTransactionExist`(
pOrderDetailID bigint,
pItemID varchar(30))
BEGIN
select count(OrderDetailID) as cnt from pumptransactions where OrderDetailID=pOrderDetailID and ItemID=pItemID;
 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIfTankExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIfTankExist`(
pTankName varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select count(TankID) as cnt from Tanks where TankName=pTankName and LocationID=pLocationID and PropertyID=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIFTankHasTransaction` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIFTankHasTransaction`(
pTankID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
 select pumpid from pumps where  tankid=pTankID and locationid=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckIfUserExists` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckIfUserExists`(
 pUserName varchar(30)
 )
BEGIN
  select count(*) from users where username = pUserName and `status` = 'Active';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckItemExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spCheckItemExist`(pItemIdSAP varchar(30))
BEGIN
select itemId from items where itemIDSAP=pItemIdSAP;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckItemExistFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCheckItemExistFuel`(
pGroupID varchar(30),
pDescription varchar(30))
BEGIN
select count(itemid) from items where groupid=pGroupID and description=pDescription and status='Active';
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFuelType` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spDeleteFuelType`(
pID varchar(30))
BEGIN
   delete from fueltype where id=pID;
     END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteGroup` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteGroup`(
pGroupName varchar(30), 
pPropertyId varchar(30),
pLocationId varchar(30), 
pUser varchar(30))
BEGIN
 UPDATE
      itemgroups
 SET
      itemgroups.status = 'Deleted'
    , itemgroups.updatedBy = pUser
    , itemgroups.updatedAt = now()
 WHERE
      itemgroups.groupId = pGroupName
 AND  itemgroups.locationId = pLocationId
 AND  itemgroups.propertyId = pPropertyId;	
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteItem`(
pItemId varchar(30), 
pPropertyId varchar(30), 
pLocationId varchar(30), 
pUser varchar(30))
BEGIN
 UPDATE
 items
 SET
 items.status = 'Deleted'
 , items.updatedBy = pUser
 , items.updatedAt = now()
 WHERE
      items.itemId = pItemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteItemLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteItemLocation`(
 pItemId varchar(30), 
 pPropertyId varchar(30),
 pLocationId varchar(30),  
 pUser varchar(30)
 )
BEGIN
 UPDATE
      itemlocations
 SET 
     `status` = 'Deleted', 
      updatedBy = pUser, 
      updatedAt = now()
 where 
      itemId = pItemId 
 AND  locationId = pLocationId
 AND  propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteLocation`(
   pPropertyId varchar(30),
   pLocationId varchar(20)
 , pUser varchar(50)
 )
BEGIN
 update
 locations
 set
 `status` = 'Deleted'
 , updatedBy = pUser
 , updatedAt = now()
 where
      locationId = pLocationId
 AND  propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteMainGroup` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteMainGroup`(
pMainGroupName varchar(30), 
pPropertyId varchar(30),
pLocationId varchar(30), 
pUser varchar(30))
BEGIN
 update
 maingroups
 set
 `status` = 'Deleted'
 , updatedBy = pUser
 , updatedAt = now()
 where
      mainGroupId = pMainGroupName
 AND  locationId = pLocationId
 AND  propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeletePreparationArea` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeletePreparationArea`(
pPrepCode varchar(30), 
pPropertyId varchar(30), 
pLocationId varchar(30), 
pUser varchar(30))
BEGIN
 UPDATE preparationarea
 SET 	preparationarea.status = 'Deleted',
	preparationarea.updatedAt = now(),
	preparationarea.updatedBy = pUser
 WHERE  preparationarea.preparationCode = pPrepCode
	AND preparationarea.locationId = pLocationId 
	AND preparationarea.propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeletePumpItemID` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spDeletePumpItemID`(
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30),
pItemID varchar(30))
BEGIN
  update pumps set -- FuelType=pFuelType,
 ItemID='' where PumpID=pPumpID and LocationID=pLocationID and PropertyID=pPropertyID;
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
/*!50003 DROP PROCEDURE IF EXISTS `SpDeleteSuppliedItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `SpDeleteSuppliedItem`(
pSuppliedItemId varchar(30), 
pPropertyId varchar(30),
pLocationId varchar(30),
pUser varchar(30)
)
BEGIN
 UPDATE
 supplieditems
  SET
   supplieditems.status = 'Deleted'
 , supplieditems.updatedBy = pUser
 , supplieditems.updatedAt = now()
 WHERE
  supplieditems.supItemId = pSuppliedItemId
  AND supplieditems.PropertyID = pPropertyId
  AND supplieditems.locationId = pLocationId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteSupplier` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteSupplier`(
pSupplierId varchar(30), 
pPropertyId varchar(30), 
pLocationId varchar(30), 
pUser varchar(30))
BEGIN
 UPDATE supplier
 SET 	supplier.status = 'Deleted',
	supplier.updatedAt = now(),
	supplier.updatedBy = pUser
 WHERE  supplier.supplierId = pSupplierId
	AND supplier.locationId = pLocationId 
	AND supplier.propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteTank` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spDeleteTank`(
pTankID varchar(30),
pUser varchar(30))
BEGIN
delete from tanks where tankid=pTankID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteUnit` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteUnit`(
  pName varchar(30)
, pPropertyId varchar(30)
, pLocationId varchar(20)
, pUser varchar(30))
BEGIN
 update
 units
 set
   units.status = 'Deleted'
 , units.updatedBy = pUser
 , units.updatedAt = now()
 where
 units.unitName = pName
 AND units.locationId = pLocationId
 AND units.propertyId = pPropertyId;
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
/*!50003 DROP PROCEDURE IF EXISTS `spGetActualStocks` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetActualStocks`(
    pItemId varchar(30),
    pLocationId varchar(30),
    pPropertyId varchar(30)
    )
BEGIN
	select itemlocations.`quantity` as currentStocks, 
	-- July 25, 2012 - Julz
	-- omitted bec. checking of NULL value now applied directly to stored function called
	-- coalesce(fGetUnpostedStocks(pItemId),0) as unpostedStocks
	fGetUnpostedStocks(pItemId, pLocationId) as unpostedStocks	
	from
	itemlocations
	left join items on itemlocations.`itemId` = items.`itemId`
	where
	itemlocations.`locationId` = pLocationId
	and itemlocations.`propertyId` = pPropertyId
	-- July 26, 2012 -Julz
	-- and itemIdSAP = pItemId
	and items.`itemId` = pItemId
	;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAllItemsByLocationForResto` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAllItemsByLocationForResto`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
/*SELECT  itemlocations.itemId,
	itemlocations.quantity,
	itemlocations.sellingPrice,
	itemlocations.preparationArea,
	itemlocations.minStockLevel,
 	itemlocations.maxStockLevel,
	fGetLocationName(itemlocations.locationId) as locationName,
	fGetItemDescription(itemlocations.itemId) as Description,
	fgetItemGroups(itemlocations.itemId, itemlocations.propertyID) as GroupId,
	items.isInventoryItems
	FROM itemlocations
	LEFT JOIN items ON items.itemId = itemlocations.itemId
	WHERE itemlocations.locationId = pLocationId
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active'
	GROUP BY itemlocations.itemId;*/
SELECT  itemlocations.itemId,
	itemlocations.sellingPrice,
	itemlocations.evat,
	itemlocations.preparationArea as KITCHEN_DESIGNATION,
	itemlocations.serviceCharge as SERVICE_CHARGE,
	
	-- July 30, 2012 - Julz		
	-- fGetItemDescription(itemlocations.itemId) as Description,
	-- fgetItemGroups(itemlocations.itemId, itemlocations.propertyId) as groupId,
	
	items.description as Description,
	items.groupId,
	-- 
	items.unit,
	items.unitCost,
	itemlocations.localTax
	FROM itemlocations
left join items on itemlocations.itemId = items.itemId
	WHERE itemlocations.locationId = pLocationId
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active'
	order by Description
;
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
/*!50003 DROP PROCEDURE IF EXISTS `spGetCalibration` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetCalibration`(
pPropertyID varchar(30),
pLocationID varchar(30),
pshiftid varchar(30))
BEGIN
select pumps.PumpID,pumps.FuelType,now(),
IFNULL((select calibrationliter from calibration where calibration.pumpid=pumps.PumpID and date(calibration.datecreated)=date(now()) and calibration.shiftid=pshiftid
and calibration.locationid=pLocationID and calibration.propertyid=pPropertyID),0) as calibliters 
from pumps,items,tanks where 
pumps.ItemID=items.itemId and pumps.TankID=tanks.TankID
and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetDuplicateItemFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetDuplicateItemFuel`(
pItemID varchar(30),
pPropertyID varchar(30),
pLocationID varchar(30))
BEGIN
select itemid from pumps where fueltype=(select pumps.FuelType from pumps where itemid=pItemID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID limit 1);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetDuplicateItemLocationsFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetDuplicateItemLocationsFuel`(
pItemID varchar(30),
pPropertyID varchar(30),
pLocationID varchar(30))
BEGIN
select pumps.itemid from pumps,itemlocations where 
pumps.fueltype=(select pumps.FuelType from pumps where itemid=pItemID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID limit 1)
and pumps.ItemID=itemlocations.itemId;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEmployeeAll` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetEmployeeAll`(pHOtelID int(5))
BEGIN
Select employee.Employee_ID, concat(Firstname, ' ',Lastname ) as `name`
from Employee where status='ACTIVE' and hotel_id=pHOtelID and Position in ('ROOM ATTENDANT','BAR ATENDANT') order by Firstname;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFuelCashierTransactions` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetFuelCashierTransactions`(
IN pTerminalId VARCHAR(30),
IN pShiftCode INT(2),
IN pStartDate DATE,
IN pEndDate DATE
)
BEGIN
SELECT 
ORDER_ID, 
IF(pos.`order header`.customer_id='WALK-IN', 'WALK-IN', 
	IF(`order header`.employee_id != '', 
	pos.fGetEmployeeName(`order header`.employee_id), 
	(SELECT CONCAT(firstname, ' ', lastname) FROM hotelmgtsystem.guests WHERE accountid = `order header`.customer_id))) AS CUSTOMER_ID,
IF(customer_id="", "EMPLOYEE", IF(CUSTOMER_ID="WALK-IN", "WALK-IN CUSTOMER", "GUEST")) AS CUSTOMER_TYPE,
ROUTE_ID, 
TABLE_NO, 
ASSIGNED_TO, 
ASSIGNED_TIME, 
ORDER_DATE, 
TOTAL_LINE_ITEMS, 
TOTAL_AMOUNT, 
TOTAL_PAYMENT, 
BALANCE, SEQ_NO, 
`order header`.STATUS, `order header`.CREATEDBY, `order header`.CREATETIME, 
`order header`.UPDATEDBY, `order header`.UPDATETIME, VAT_SALES, VAT_AMOUNT, NONVAT_SALES, 
SERVICE_CHARGE, ROOMSERVICE_CHARGE, 
SHIFT_CODE, (cashiers.Terminal) AS TERMINAL_ID
FROM pos.`order header`, pos.cashiers
WHERE Terminal_Id = pTerminalId AND
Shift_Code = pShiftCode AND
cashiers.terminalid = `order header`.terminal_id AND
(DATE(Order_Date) >= pStartDate AND DATE(Order_Date) <= pEndDate)
AND `order header`.status<>'CANCELLED'
ORDER BY order_date,order_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFuelCustomers` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetFuelCustomers`()
BEGIN
SELECT 	AccountId,
	concat(LastName	, ', ', FirstName) as customer
	from hotelmgtsystem.guests
	where AccountName = ''
	order by customer
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFuelMainGrouptracker` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetFuelMainGrouptracker`(
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
           select fuelmaingrouptracker.MaingroupID from fuelmaingrouptracker where locationID=pLocationID and propertyID=pPropertyID;
       END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFuelMonthlySalesperTank` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetFuelMonthlySalesperTank`(pDate DATETIME)
BEGIN
	/*
	SYSTEM : FUEL POS
	PURPOSE : retrieve sales data per tank, per day in a month
		  used for complex tank sales report
	TABLE RELATIONSHIP : ( 1---n... means one to many cardinality)
		  TANKS 1------------------n TANKSDIPPING
		    |1                           |1
		    |                            |
		    |                            |n
		     -------n PUMPS 1-----------n ITEMS
	CREATED BY : J. VILLACERAN
	CREATED DATE : 12-DEC-2012
	*/ 
	-- SQL4
	SELECT tankname, FuelType, DAYDATE, OPENINGSTOCK, DELIVERY, (SALES - VOIDEDLITERS) AS SALES, DIPPING, ENDINGSTOCK, IF(DIPPING = 0, 0, DIPPING - ENDINGSTOCK)  AS "VARIANCE" /*(DIPPING - ENDINGSTOCK) AS "VARIANCE"*/
	FROM (
	-- SQL3
	SELECT tankname, FuelType, DAYDATE, SUM(OPENINGSTOCK) AS OPENINGSTOCK, SUM(DELIVERY) AS DELIVERY, SUM(SALES) AS SALES, SUM(DIPPING) AS DIPPING, SUM(ENDINGSTOCK) AS ENDINGSTOCK, SUM(VOIDEDLITERS) AS VOIDEDLITERS
	FROM ( 
		-- get beginning balance for the day
		SELECT tankName , FuelType, daydate, beginningBalance AS openingstock, 0 AS delivery, 0 AS sales, 0 AS dipping, 0 AS endingstock, 0 AS voidedliters FROM 
		(
		SELECT tankName , FuelType, daydate, beginningBalance ,  @row_num := IF(@prev_date = daydate AND @prev_tank = tankName, @row_num+1,1) AS RowNumber,
		@prev_tank := tankName,
		@prev_date := daydate  
		FROM (
		SELECT  t.tankName , t.FuelType, l.beginningBalance, DATE_FORMAT(createdAt, '%d') AS daydate, l.ledgerID 
		FROM tanks t
		LEFT JOIN pumps p ON p.tankID = t.tankID
		LEFT JOIN itemledger l ON l.itemID = p.itemid
		WHERE DATE_FORMAT(createdAt, '%Y-%m') =  DATE_FORMAT(pDate, '%Y-%m')
		ORDER BY tankname, daydate, ledgerid
		) sql1, (SELECT @row_num := 1) X , 
			(SELECT @prev_date := '') Y,
			(SELECT @prev_tank := '') z  
		) sql2 WHERE rownumber = 1 
		UNION ALL 
		-- get total daily delivery for the month per tank
		SELECT  t.tankName , t.FuelType, DATE_FORMAT(createdAt, '%d') AS daydate, 0 AS openingstock, SUM(l.quantity) AS delivery,  0 AS sales, 0 AS dipping, 0 AS endingstock, 0 AS voidedliters
		FROM tanks t
		LEFT JOIN pumps p ON p.tankID = t.tankID
		LEFT JOIN itemledger l ON l.itemID = p.itemid
		WHERE  l.inventoryAction = 'IN' AND DATE_FORMAT(createdAt, '%Y-%m') =  DATE_FORMAT(pDate, '%Y-%m') AND moduleName != 'Void'
		GROUP BY t.tankName ,daydate
		UNION ALL 
		-- get total daily sales for the month per tank
		SELECT t.tankName, t.FuelType, DATE_FORMAT(createdAt, '%d') AS daydate, 0 AS openingstock, 0 AS delivery,  SUM(quantity) AS sales, 0 AS dipping, 0 AS endingstock, 0 AS voidedliters
		FROM tanks t
		LEFT JOIN pumps p ON p.tankID = t.tankID
		LEFT JOIN itemledger l ON l.itemID = p.itemid
		WHERE  l.inventoryAction = 'OUT'  AND l.moduleName = 'Sold Items' AND DATE_FORMAT(createdAt, '%Y-%m') =  DATE_FORMAT(pDate, '%Y-%m')
		GROUP BY tankName, daydate
		UNION ALL 
		
		-- get total daily tank dipping for the month per tank	
		
		/* SELECT t.tankname, t.FuelType,  DATE_FORMAT(td.createdTime, '%d') AS daydate ,0 AS openingstock, 0 AS delivery,  0 AS sales, SUM(td.TotalLiters) AS dipping ,0 AS endingstock, 0 AS voidedliters
		FROM tanksdipping td 
		LEFT JOIN tanks t ON t.tankid = td.tankid
		WHERE  DATE_FORMAT(td.createdTime, '%Y-%m') =   DATE_FORMAT(pDate, '%Y-%m')
		GROUP BY tankname, daydate */
		
		SELECT t.tankname, t.FuelType,  DATE_FORMAT(td.createdTime, '%d') AS daydate ,0 AS openingstock, 0 AS delivery,  0 AS sales, td.`EndReading` AS dipping, 0 AS endingstock, 0 AS voidedliters
		FROM tanksdipping td 
		LEFT JOIN tanks t ON t.tankid = td.tankid
		INNER JOIN (SELECT MAX(id) AS id FROM tanksdipping GROUP BY tankid, DATE(createdTime) ) AS td2 ON td.`id` = td2.id
		WHERE  DATE_FORMAT(td.createdTime, '%Y-%m') =   DATE_FORMAT(pDate, '%Y-%m')
		GROUP BY tankname, daydate 
		
		UNION ALL 
		SELECT tankName , FuelType, daydate,  0 AS openingstock, 0 AS delivery, 0 AS sales, 0 AS dipping,  endingbalance AS endingstock, 0 AS voidedliters FROM 
		(
		SELECT tankName , FuelType, daydate, endingbalance ,  @row_num := IF(@prev_date = daydate AND @prev_tank = tankName, @row_num+1,1) AS RowNumber,
		@prev_tank := tankName,
		@prev_date := daydate  
		FROM (
		SELECT  t.tankName , t.FuelType,  DATE_FORMAT(createdAt, '%d') AS daydate, l.ledgerID , l.endingbalance 
		FROM tanks t
		LEFT JOIN pumps p ON p.tankID = t.tankID
		LEFT JOIN itemledger l ON l.itemID = p .itemid
		WHERE DATE_FORMAT(createdAt, '%Y-%m') =  DATE_FORMAT(pDate, '%Y-%m')
		ORDER BY tankname ASC , createdAt DESC , daydate ASC, ledgerid ASC  
		) sql1, (SELECT @row_num := 1) X , 
			(SELECT @prev_date := '') Y,
			(SELECT @prev_tank := '') z  
		) sql2 WHERE rownumber = 1 
		UNION ALL 
		-- get total voided items for the month per tank
		SELECT  t.tankName , t.FuelType, DATE_FORMAT(createdAt, '%d') AS daydate, 0 AS openingstock, 0 AS delivery,  0 AS sales, 0 AS dipping, 0 AS endingstock, SUM(l.quantity) AS voidedliters
		FROM tanks t
		LEFT JOIN pumps p ON p.tankID = t.tankID
		LEFT JOIN itemledger l ON l.itemID = p.itemid
		WHERE  l.inventoryAction = 'IN' AND DATE_FORMAT(createdAt, '%Y-%m') =  DATE_FORMAT(pDate, '%Y-%m') AND moduleName = 'Void'
		GROUP BY t.tankName ,daydate
	) SQL3 GROUP BY tankName, DAYDATE 
	) SQL4 ;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFuelTankNameType` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFuelTankNameType`()
BEGIN
SELECT 
  tankname,
  fueltype 
FROM
  tanks 
WHERE `status` = 'Active' 
 ;	
	
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFuelType` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetFuelType`(
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select FuelType,fueltype.Status,id from fueltype where locationid=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGroupByMainGroup` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGroupByMainGroup`(
pMainGroupId varchar(30), 
pPropertyId varchar(30),
pLocationId varchar(30))
BEGIN
 select
 itemgroups.groupId, 
 itemgroups.description
 from
 itemgroups
 where
 itemgroups.mainGroupId = pMainGroupId
 and itemgroups.locationId = pLocationId
 and itemgroups.propertyId = pPropertyId
 and itemgroups.status = 'Active';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGroups` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGroups`(
pPropertyId varchar(30),
pLocationId varchar(30))
BEGIN
 SELECT
     itemgroups.groupId	
   , itemgroups.description
   , itemgroups.mainGroupId
   , itemgroups.groupType
 FROM
     itemgroups
 WHERE
     itemgroups.status = 'Active'
  AND itemgroups.locationId = pLocationId
  AND itemgroups.propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGroupsALL` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGroupsALL`(
pPropertyId varchar(30),
pLocationId varchar(30))
BEGIN
 SELECT
     itemgroups.groupId	
   , itemgroups.description
   , itemgroups.mainGroupId
   -- , itemgroups.groupType
   , if((select pumps.FuelType from pumps where pumpid=itemgroups.groupId and pumps.LocationID=itemgroups.locationId 
      and pumps.PropertyID=itemgroups.propertyId and itemgroups.locationId=pLocationId and itemgroups.propertyId=pPropertyId) <> '',
     (select pumps.FuelType from pumps where pumpid=itemgroups.groupId and pumps.LocationID=itemgroups.locationId 
      and pumps.PropertyID=itemgroups.propertyId and itemgroups.locationId=pLocationId and itemgroups.propertyId=pPropertyId),
      itemgroups.groupType) as grouptypes
 FROM
     itemgroups
 WHERE
     itemgroups.status = 'Active'
  AND itemgroups.locationId = pLocationId
  AND itemgroups.propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGroupsForFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetGroupsForFuel`(
pMaingroupID varchar(30),
pPropertyID varchar(30),
pLocationID varchar(30))
BEGIN
select concat(itemgroups.groupId,' (',items.description,')') as groupid,
itemgroups.description,itemgroups.mainGroupId,itemgroups.groupType,pumps.ItemID,fReturnNumbersInString(itemgroups.groupId) AS numbr from items,itemlocations,itemgroups,pumps where itemgroups.mainGroupId=pMaingroupID
and itemgroups.groupId=pumps.PumpID and itemgroups.propertyId=pumps.PropertyID and itemgroups.locationId=pumps.LocationID 
and pumps.ItemID=itemlocations.itemId
and pumps.ItemID=items.itemId
and itemgroups.propertyid=pPropertyID and itemgroups.locationid=pLocationID and itemgroups.status='Active' order by numbr;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGroupsForFueltoItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetGroupsForFueltoItem`(
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
 SELECT itemgroups.groupId,if((select count(id) as cnt from fuelmaingrouptracker where fuelmaingrouptracker.MaingroupID=itemgroups.mainGroupId and 
itemgroups.locationId=1 and itemgroups.propertyId=1)>0,
 concat(itemgroups.groupId,' (',(select pumps.FuelType from pumps where pumpid=itemgroups.groupId and locationid=pLocationID and propertyid=pPropertyID),')'),
itemgroups.groupId) as Description
   , itemgroups.mainGroupId
   , itemgroups.groupType
 FROM itemgroups WHERE  itemgroups.status = 'Active'
  AND itemgroups.locationId = pLocationID  AND itemgroups.propertyId = pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetInventoryItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetInventoryItem`(
pItemId varchar(30),
pPropertyId varchar(30),
pLocationId varchar(30)
 )
BEGIN
SELECT  items.isInventoryItems
	FROM items
	WHERE items.itemId = pItemId
	AND items.status = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetInventoryItemOnlyByLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetInventoryItemOnlyByLocation`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  itemlocations.itemId,
	itemlocations.quantity,
	itemlocations.sellingPrice,
	itemlocations.preparationArea,
	itemlocations.minStockLevel,
 	itemlocations.maxStockLevel,
	fGetLocationName(itemlocations.locationId) as locationName,
 	fIsManagedBySerialNumber(itemlocations.itemId) as MSerialNumber,
	fIsManagedByLotNo(itemlocations.itemId) as MLotNo,
	fIsManagedByDateCode(itemlocations.itemId) as MDateCode,
	fGetItemDescription(itemlocations.itemId) as Description,
	fgetItemGroups(itemlocations.itemId, itemlocations.propertyID) as GroupId,
	items.isInventoryItems,
	items.unitCost
	FROM itemlocations
	LEFT JOIN items ON items.itemId = itemlocations.itemId
	WHERE itemlocations.locationId = pLocationId
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active'
	AND items.isInventoryItems = 'Yes'
	GROUP BY itemlocations.itemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetInventoryItemOnlyByLocationForFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetInventoryItemOnlyByLocationForFuel`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  itemlocations.itemId,
	itemlocations.quantity,
	itemlocations.sellingPrice,
	itemlocations.preparationArea,
	itemlocations.minStockLevel,
 	itemlocations.maxStockLevel,
	fGetLocationName(itemlocations.locationId) as locationName,
 	fIsManagedBySerialNumber(itemlocations.itemId) as MSerialNumber,
	fIsManagedByLotNo(itemlocations.itemId) as MLotNo,
	fIsManagedByDateCode(itemlocations.itemId) as MDateCode,
	fGetItemDescription(itemlocations.itemId) as Description,
	fgetItemGroups(itemlocations.itemId, itemlocations.propertyID) as GroupId,
	items.isInventoryItems,
	items.unitCost,
        (select count(*) from pumps where pumps.ItemID=itemlocations.itemId and pumps.LocationID=pLocationId and pumps.PropertyID=pPropertyId) as cnt
	FROM itemlocations
	LEFT JOIN items ON items.itemId = itemlocations.itemId
	WHERE itemlocations.locationId = pLocationId
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active'
	AND items.isInventoryItems = 'Yes'
	GROUP BY itemlocations.itemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetInventoryItemOnlyByLocationForFuelbyDistinct` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetInventoryItemOnlyByLocationForFuelbyDistinct`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  itemlocations.itemId,
	itemlocations.quantity,
	itemlocations.sellingPrice,
	itemlocations.preparationArea,
	itemlocations.minStockLevel,
 	itemlocations.maxStockLevel,
	fGetLocationName(itemlocations.locationId) as locationName,
 	fIsManagedBySerialNumber(itemlocations.itemId) as MSerialNumber,
	fIsManagedByLotNo(itemlocations.itemId) as MLotNo,
	fIsManagedByDateCode(itemlocations.itemId) as MDateCode,
	fGetItemDescription(itemlocations.itemId) as Description,
	fgetItemGroups(itemlocations.itemId, itemlocations.propertyID) as GroupId,
	items.isInventoryItems,
	items.unitCost
       	FROM itemlocations
	LEFT JOIN items ON items.itemId = itemlocations.itemId
        LEFT JOIN pumps ON pumps.ItemID = itemlocations.itemId
	WHERE itemlocations.locationId = pLocationId
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active'
	AND items.isInventoryItems = 'Yes' 
        and pumps.LocationID=pLocationId and pumps.PropertyID=itemlocations.propertyId group by pumps.FuelType; 
	-- GROUP BY itemlocations.itemId;
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
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemLedger` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetItemLedger`(
pDateFrom datetime,
pDateTo datetime,
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT   itemledger.itemId as `ITEM ID`,
	 fGetItemDescription(itemledger.itemId) as DESCRIPTION,
	 itemledger.moduleName AS `MODULE NAME`,
	 fGetLocationName(itemledger.fromLocation) as `FROM LOCATION`,
	 fGetLocationName(itemledger.toLocation) as `TO LOCATION`,
	 itemledger.beginningBalance `BEGINNING BALANCE`,
	 itemledger.quantity as `QUANTITY`,
	 itemledger.endingBalance as `ENDING BALANCE`,
	 itemledger.serialNo as `SERIAL NO`,
	 itemledger.lotNo as `LOT NO`,
	 itemledger.dateCode as `DATE CODE`,
	 itemledger.inventoryAction as `INV ACTION`
	 -- itemledger.createdAt AS `CREATED AT`,
	 -- itemledger.createdBy AS `CREATED BY`
	 FROM itemledger 
	 -- WHERE (DATE(itemledger.createdAt) >= pDateFrom AND DATE(itemledger.createdAt) <= pDateTo)
	WHERE (DATE(itemledger.createdAt) BETWEEN date(pDateFrom) AND date(pDateTo))
	 AND itemledger.propertyId = pPropertyId
	 AND itemledger.locationId = pLocationId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemQuantity` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetItemQuantity`(
pItemId varchar(30),
pPropertyId varchar(30),
pLocationId varchar(30)
 )
BEGIN
SELECT  itemlocations.quantity 
	FROM itemlocations 
	WHERE itemlocations.propertyId = pPropertyId
	AND itemlocations.locationId = pLocationId
	AND itemlocations.itemId = pItemId
	AND itemlocations.status = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItems` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetItems`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
select 	items.itemId, 
	items.groupId, 
	items.description, 
	items.unit, 
	items.unitCost, 
	items.sellingPrice, 
	items.managedBySerialNumbers, 
	items.status,
	items.managedByDateCode,
	items.managedByLotNo,
	items.isInventoryItems
FROM    items 
WHERE   items.status = 'Active'
	-- AND items.propertyId = pPropertyId
	-- AND items.locationId = pLocationId
	ORDER BY  LPAD(items.itemId,100,0);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemsByGroup` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetItemsByGroup`(
pPropertyId varchar(30),
pLocationId varchar(30),
pGroupId varchar(30)
)
BEGIN
select 	items.itemId
FROM    items 
WHERE   items.status = 'Active'
    AND items.groupId = pGroupId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemsByLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetItemsByLocation`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  itemlocations.itemId,
	itemlocations.quantity,
	itemlocations.sellingPrice,
	itemlocations.preparationArea,
	itemlocations.minStockLevel,
 	itemlocations.maxStockLevel,
	itemlocations.localTax,
	itemlocations.evat,
	itemlocations.serviceCharge,
	fGetLocationName(itemlocations.locationId) as locationName,
 	fIsManagedBySerialNumber(itemlocations.itemId) as MSerialNumber,
	fIsManagedByLotNo(itemlocations.itemId) as MLotNo,
	fIsManagedByDateCode(itemlocations.itemId) as MDateCode,
	fGetItemDescription(itemlocations.itemId) as Description,
	fgetItemGroups(itemlocations.itemId, itemlocations.propertyId) as GroupId,
	items.isInventoryItems
	FROM itemlocations
	LEFT JOIN items ON items.itemId = itemlocations.itemId
	WHERE itemlocations.locationId = pLocationId
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active'
	GROUP BY itemlocations.itemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemsByLocationForFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetItemsByLocationForFuel`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  itemlocations.itemId,
	itemlocations.quantity,
	itemlocations.sellingPrice,
	itemlocations.preparationArea,
	itemlocations.minStockLevel,
 	itemlocations.maxStockLevel,
	itemlocations.localTax,
	itemlocations.evat,
	itemlocations.serviceCharge,
	fGetLocationName(itemlocations.locationId) as locationName,
 	fIsManagedBySerialNumber(itemlocations.itemId) as MSerialNumber,
	fIsManagedByLotNo(itemlocations.itemId) as MLotNo,
	fIsManagedByDateCode(itemlocations.itemId) as MDateCode,
	
 if((select count(*) as cnt from pumps where pumps.ItemID=itemlocations.itemId and pumps.LocationID=pLocationId and pumps.PropertyID=pPropertyId)>0,
 concat(fgetItemGroups(itemlocations.itemId, itemlocations.propertyId),' (',fGetItemDescription(itemlocations.itemId),')'),
 fGetItemDescription(itemlocations.itemId)) as Description,
      --  fGetItemDescription(itemlocations.itemId) as Description,
	fgetItemGroups(itemlocations.itemId, itemlocations.propertyId) as GroupId,
	items.isInventoryItems,
        (select count(*) from pumps where pumps.ItemID=itemlocations.itemId and pumps.LocationID=pLocationId and pumps.PropertyID=pPropertyId) as cnt
	FROM itemlocations
	LEFT JOIN items ON items.itemId = itemlocations.itemId
	WHERE itemlocations.locationId = pLocationId
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active'
	GROUP BY itemlocations.itemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemsByLocationForFuelbyDistinct` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetItemsByLocationForFuelbyDistinct`(
pPropertyId varchar(30),
pLocationId varchar(30))
BEGIN
SELECT  itemlocations.itemId,
	itemlocations.quantity,
	itemlocations.sellingPrice,
	itemlocations.preparationArea,
	itemlocations.minStockLevel,
 	itemlocations.maxStockLevel,
	itemlocations.localTax,
	itemlocations.evat,
	itemlocations.serviceCharge,
	fGetLocationName(itemlocations.locationId) as locationName,
 	fIsManagedBySerialNumber(itemlocations.itemId) as MSerialNumber,
	fIsManagedByLotNo(itemlocations.itemId) as MLotNo,
	fIsManagedByDateCode(itemlocations.itemId) as MDateCode,
	
        fGetItemDescription(itemlocations.itemId) as Description,
	fgetItemGroups(itemlocations.itemId, itemlocations.propertyId) as GroupId,
	items.isInventoryItems,
        (select count(*) from pumps where pumps.ItemID=itemlocations.itemId and pumps.LocationID=pLocationId and pumps.PropertyID=pPropertyId) as cnt
	FROM itemlocations -- ,pumps
	LEFT JOIN items ON items.itemId = itemlocations.itemId
        LEFT JOIN pumps on pumps.ItemID = itemlocations.itemId
	WHERE itemlocations.locationId = pLocationId
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active' and pumps.LocationID=pLocationId and pumps.PropertyID=itemlocations.propertyId group by pumps.FuelType; 
        -- and itemlocations.itemId=pumps.ItemID and pumps.LocationID=pLocationId and pumps.PropertyID=pPropertyId group by pumps.FuelType;
	-- GROUP BY itemlocations.itemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemSellingPrice` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetItemSellingPrice`(
pItemId varchar(30),
pPropertyId varchar(30),
pLocationId varchar(30)
 )
BEGIN
SELECT  itemlocations.sellingPrice 
	FROM itemlocations 
	WHERE itemlocations.propertyId = pPropertyId
	AND itemlocations.locationId = pLocationId
	AND itemlocations.itemId = pItemId
	AND itemlocations.status = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemsForFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetItemsForFuel`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
select 	items.itemId, 
	items.groupId,
 if((select count(*) as cnt from pumps where pumps.ItemID=items.itemId)>0,
 concat(items.groupId,' (',items.description,')'),
 items.description) as description,
     --  items.description,
	items.unit, 
	items.unitCost, 
	items.sellingPrice, 
	items.managedBySerialNumbers, 
	items.status,
	items.managedByDateCode,
	items.managedByLotNo,
	items.isInventoryItems,
        (select count(*) from pumps where pumps.ItemID=items.itemId and pumps.LocationID=pLocationId and pumps.PropertyID=pPropertyId) as cnt,
         concat(items.groupId,' (',(select pumps.FuelType from pumps where pumps.PumpID=items.groupId),')') as pumpType
 -- if((select count(*) as cnt from pumps where pumps.ItemID=items.itemId)>0,
 -- concat(items.description,' (',items.groupId,')'),
 -- items.description) as descConcat
FROM    items 
WHERE   items.status = 'Active'
	-- AND items.propertyId = pPropertyId
	-- AND items.locationId = pLocationId
	ORDER BY  LPAD(items.itemId,100,0);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemsForFuelbyDistinct` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetItemsForFuelbyDistinct`(
pPropertyId varchar(30),
pLocationId varchar(30))
BEGIN
select 	items.itemId,  
	items.groupId,
        items.description,
	items.unit, 
	items.unitCost, 
	items.sellingPrice, 
	items.managedBySerialNumbers, 
	items.status,
	items.managedByDateCode,
	items.managedByLotNo,
	items.isInventoryItems   
FROM    items,pumps
WHERE   items.status = 'Active' and items.itemId=pumps.ItemID and pumps.LocationID=pLocationId and pumps.PropertyID=pPropertyId group by pumps.FuelType
	-- AND items.propertyId = pPropertyId
	-- AND items.locationId = pLocationId
	ORDER BY  LPAD(items.itemId,100,0);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemsNotInSuppliedItems` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetItemsNotInSuppliedItems`(
pPropertyId varchar(30),
pLocationId varchar(30),
pSupplierId varchar(30)
)
BEGIN
select 	items.itemId, 
	items.groupId, 
	items.description, 
	items.unit, 
	items.unitCost, 
	items.sellingPrice, 
	items.managedBySerialNumbers, 
	items.status,
	items.managedByDateCode,
	items.managedByLotNo,
	items.isInventoryItems
FROM    items
WHERE   items.itemId NOT IN
			(
			SELECT itemId FROM supplieditems 
			WHERE locationId = pLocationId 
			AND propertyId = pPropertyId 
			AND supplieditems.status ='Active'
			AND supplieditems.supplierId = pSupplierId
			)
	AND items.status = 'Active'
	ORDER BY items.description;
/* FROM    items, itemlocations
WHERE   itemlocations.itemId = items.itemId
	AND itemlocations.status = 'Active'
	AND itemlocations.propertyId = pPropertyId
	AND itemlocations.locationId = pLocationId
	AND itemlocations.itemId NOT IN
			(
			SELECT itemId FROM supplieditems 
			WHERE locationId = pLocationId 
			AND propertyId = pPropertyId 
			AND supplieditems.status ='Active'
			AND supplieditems.supplierId = pSupplierId
			)
	ORDER BY items.description;*/
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemsNotInSuppliedItemsFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetItemsNotInSuppliedItemsFuel`(
pPropertyId varchar(30),
pLocationId varchar(30),
pSupplierId varchar(30)
)
BEGIN
select 	items.itemId, 
	items.groupId, 
	items.description, 
	items.unit, 
	items.unitCost, 
	items.sellingPrice, 
	items.managedBySerialNumbers, 
	items.status,
	items.managedByDateCode,
	items.managedByLotNo,
	items.isInventoryItems,
        (select count(pumps.ItemID) from pumps where pumps.ItemID=items.itemId and pumps.LocationID=pLocationId and pumps.PropertyID=pPropertyId) as cnt 
FROM    items
WHERE   items.itemId NOT IN
			(
			SELECT itemId FROM supplieditems 
			WHERE locationId = pLocationId 
			AND propertyId = pPropertyId 
			AND supplieditems.status ='Active'
			AND supplieditems.supplierId = pSupplierId
			)
	AND items.status = 'Active'
	ORDER BY items.description;
/* FROM    items, itemlocations
WHERE   itemlocations.itemId = items.itemId
	AND itemlocations.status = 'Active'
	AND itemlocations.propertyId = pPropertyId
	AND itemlocations.locationId = pLocationId
	AND itemlocations.itemId NOT IN
			(
			SELECT itemId FROM supplieditems 
			WHERE locationId = pLocationId 
			AND propertyId = pPropertyId 
			AND supplieditems.status ='Active'
			AND supplieditems.supplierId = pSupplierId
			)
	ORDER BY items.description;*/
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemsNotInSuppliedItemsFuelDistinct` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetItemsNotInSuppliedItemsFuelDistinct`(
pPropertyId varchar(30),
pLocationId varchar(30),
pSupplierId varchar(30)
)
BEGIN
select 	items.itemId, 
	items.groupId, 
	items.description, 
	items.unit, 
	items.unitCost, 
	items.sellingPrice, 
	items.managedBySerialNumbers, 
	items.status,
	items.managedByDateCode,
	items.managedByLotNo,
	items.isInventoryItems,
        (select count(pumps.ItemID) from pumps where pumps.ItemID=items.itemId and pumps.LocationID=pLocationId and pumps.PropertyID=pPropertyId) as cnt 
FROM    items,pumps
WHERE   items.itemId NOT IN
			(
			SELECT itemId FROM supplieditems 
			WHERE locationId = pLocationId 
			AND propertyId = pPropertyId 
			AND supplieditems.status ='Active'
			AND supplieditems.supplierId = pSupplierId
			)
	AND items.status = 'Active' 
        and items.itemId=pumps.ItemID and 
         pumps.LocationID=pLocationId and pumps.PropertyID=pPropertyId group by pumps.FuelType; 
  -- ORDER BY items.description;
/* FROM    items, itemlocations
WHERE   itemlocations.itemId = items.itemId
	AND itemlocations.status = 'Active'
	AND itemlocations.propertyId = pPropertyId
	AND itemlocations.locationId = pLocationId
	AND itemlocations.itemId NOT IN
			(
			SELECT itemId FROM supplieditems 
			WHERE locationId = pLocationId 
			AND propertyId = pPropertyId 
			AND supplieditems.status ='Active'
			AND supplieditems.supplierId = pSupplierId
			)
	ORDER BY items.description;*/
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemStocks` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetItemStocks`(
pItemId varchar(30),
pPropertyId varchar(30),
pLocationId varchar(30)
 )
BEGIN
SELECT 
	itemlocations.itemId, 
	itemlocations.locationId, 
	itemlocations.quantity, 
	itemlocations.sellingPrice, 
	itemlocations.preparationArea, 
	itemlocations.minStockLevel, 
	itemlocations.maxStockLevel, 
	itemlocations.localTax, 
	itemlocations.serviceCharge,
	itemlocations.evat,
	items.groupId,
	itemgroups.mainGroupId,
	items.description,
	items.unit,
	items.unitCost,
	itemlocations.sellingPrice,
	items.isInventoryItems
	FROM itemlocations
	LEFT JOIN items ON itemlocations.itemId = items.itemId
	LEFT JOIN itemgroups ON itemgroups.groupId = items.groupId
	WHERE itemlocations.itemId = pItemId 
	AND itemlocations.quantity >= 0
	AND itemlocations.locationId = pLocationId 
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetIventoryList` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetIventoryList`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  itemlocations.itemId,
	fGetItemDescription(itemlocations.itemId) as Description,
	items.unit as UOM,
	items.unitCost,
	itemlocations.sellingPrice as SalePrice,
	-- itemlocations.minStockLevel as MinStock,
	-- itemlocations.maxStockLevel as MaxStock,
        itemlocations.quantity
	FROM itemlocations LEFT JOIN items 
	ON itemlocations.itemId = items.itemId
	WHERE itemlocations.locationId = pLocationId
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active'
	AND items.isInventoryItems = 'Yes'
	GROUP BY itemlocations.itemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetIventoryListFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetIventoryListFuel`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  itemlocations.itemId,
	fGetItemDescription(itemlocations.itemId) as Description,
	items.unit as UOM,
	items.unitCost,
	itemlocations.sellingPrice as SalePrice,
	-- itemlocations.minStockLevel as MinStock,
	-- itemlocations.maxStockLevel as MaxStock,
        itemlocations.quantity
	FROM itemlocations LEFT JOIN items 
	ON itemlocations.itemId = items.itemId
        LEFT JOIN pumps ON pumps.ItemID = itemlocations.itemId
	WHERE itemlocations.locationId = pLocationId
	AND itemlocations.propertyId = pPropertyId 
	AND itemlocations.status = 'Active'
	AND items.isInventoryItems = 'Yes'
         and pumps.LocationID=pLocationId and pumps.PropertyID=itemlocations.propertyId group by pumps.FuelType; 
	-- GROUP BY itemlocations.itemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetLocations` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetLocations`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
select 
	locationId, 
	`name`, 
	`owner`, 
	contactPerson, 
	telephoneNumber, 
	faxNumber, 
	address
 from locations
 where propertyId = pPropertyId 
AND `status` = 'Active';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetLocationsAtRequest` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetLocationsAtRequest`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT
	locationId, 
	`name`, 
	`owner`, 
	contactPerson, 
	telephoneNumber, 
	faxNumber, 
	address
FROM locations
WHERE propertyId = pPropertyId 
AND locationId <> pLocationId
AND `status` = 'Active';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetMainGroups` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetMainGroups`(
pPropertyId varchar(30),
pLocationId varchar(30))
BEGIN
 select 
   mainGroupId
 , description
 , locationid
 from  maingroups 
 where `status` = 'Active'
 and locationid = pLocationId
 AND propertyId = pPropertyId
 order by mainGroupId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetMainGroupsForFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetMainGroupsForFuel`(
pPropertyId varchar(30),
pLocationId varchar(30))
BEGIN
 select 
  maingroups.mainGroupId
 , maingroups.description
 , maingroups.locationid
 from  maingroups,fuelmaingrouptracker
 where `status` = 'Active'
 and maingroups.locationid = pLocationId
 AND maingroups.propertyId = pPropertyId 
 and maingroups.mainGroupId <> fuelmaingrouptracker.MaingroupID
 and fuelmaingrouptracker.locationID=pLocationId
 and fuelmaingrouptracker.propertyID=pPropertyId
 order by maingroups.mainGroupId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetMostSellableFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetMostSellableFuel`(
pShiftCode varchar(15),
pPropertyID int(11),
pLocationID int(11),
pStartDate date,
pEndDate date)
BEGIN 
	select maingroups.mainGroupId,
	itemgroups.groupId,
	items.itemId,
	items.description, 
	IFNULL(fGetTotalSoldFuel(items.itemId, pPropertyID, pLocationID, pShiftCode, pStartDate, pEndDate), 0.0) AS soldStocks
	
FROM maingroups
INNER JOIN itemgroups
	ON maingroups.mainGroupId = itemgroups.mainGroupId
	AND maingroups.propertyId = itemgroups.propertyId
	AND maingroups.locationId = itemgroups.locationId
	AND maingroups.status != 'DELETED' 
	AND itemgroups.status != 'DELETED'
INNER JOIN items
	ON itemgroups.groupId = items.groupId
	AND items.status != 'DELETED'
INNER JOIN itemlocations
	ON items.itemId = itemlocations.itemId
	AND itemlocations.propertyId = pPropertyID
	AND itemlocations.locationId = pLocationID
	AND itemlocations.status != 'DELETED';	
	      
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetMostSellableItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetMostSellableItem`(
pShiftCode varchar(15),
pPropertyID int,
pLocationID int,
pStartDate date,
pEndDate date)
BEGIN   
select  maingroups.mainGroupId,itemgroups.groupid,items.itemId as item_id,items.description,
(select sum(quantity)  from itemledger where itemid=item_id and modulename='Sold Items'
and propertyid=pPropertyID and locationid=pLocationID
and (date(createdAt) >= pStartDate and date(createdAt) <= pEndDate)) as soldStocks
from itemgroups,maingroups,items,pos.`order detail`,pos.`order header` 
where itemgroups.mainGroupId=maingroups.mainGroupId and 
itemgroups.groupId=items.groupId and
maingroups.status='Active' and maingroups.propertyId=pPropertyID and maingroups.locationId=pLocationID 
and `order detail`.ORDER_ID=`order header`.ORDER_ID and `order header`.SHIFT_CODE=pShiftCode
and  items.itemId=`order detail`.ITEM_ID
group by   `order detail`.ITEM_ID  order by soldStocks desc;
       
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPreparationAreas` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetPreparationAreas`(
pPropertyId varchar(30),
pLocationId varchar(30))
BEGIN
 SELECT
     preparationarea.preparationCode
   , preparationarea.description
   , preparationarea.printerAssigned
 FROM
     preparationarea
 WHERE
     preparationarea.status = 'Active'
 AND preparationarea.locationId = pLocationId
 AND preparationarea.propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPreviousTransFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetPreviousTransFuel`(
pShiftCode varchar(30),
pTerminalID varchar(30),
pRestaurantID varchar(30))
BEGIN
select `order header`.ORDER_ID,`order header`.CUSTOMER_ID,`order header`.UPDATETIME,`order header`.TOTAL_AMOUNT,
(select if(`order header`.customer_id='',(select concat(employee.lastname,', ',employee.FIRSTNAME) from employee 
where employee.EMPLOYEE_ID=`order header`.EMPLOYEE_ID),
if(`order header`.CUSTOMER_ID='WALK-IN','WALK-IN',
(select concat(hotelmgtsystem.guests.LastName, ', ' ,hotelmgtsystem.guests.FirstName) from hotelmgtsystem.guests where hotelmgtsystem.guests.AccountId=`order header`.CUSTOMER_ID))  )) as AccountName
from `order header`
where shift_code=pShiftCode and `order header`.TERMINAL_ID=pTerminalID 
and `order header`.CREATETIME >= (select cashiers_logs.CREATETIME from cashiers_logs 
where cashiers_logs.shiftcode=`order header`.SHIFT_CODE and cashiers_logs.terminalid=pTerminalID and cashiers_logs.restaurantid=pRestaurantID)
and `order header`.`STATUS` <> 'CANCELLED';
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPrice` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetPrice`(
pItemID varchar(30),
pPropertyID varchar(30),
pLocationID varchar(30))
BEGIN
select IFNULL(itemlocations.sellingPrice,0) as selingPrice from itemlocations,items where items.itemId=itemlocations.itemId and items.itemIdSAP=pItemID and propertyid=pPropertyID and locationid=pLocationID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPumpActive` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetPumpActive`(
pPropertyID varchar(30),
pLocationID varchar(30))
BEGIN
select pumps.PumpID from pumps,items,tanks where 
pumps.ItemID=items.itemId and pumps.TankID=tanks.TankID
and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPumpItemIDbyTank` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetPumpItemIDbyTank`(
ptankid varchar(30),
pPropertyid varchar(30),
pLocationID varchar(30))
BEGIN
select itemid from pumps where tankid=ptankid and locationid=pLocationID and propertyid=pPropertyid;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPumpReadingsCurrent` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetPumpReadingsCurrent`(
pPropertyID varchar(30),
pLocationID varchar(30),
pShiftID varchar(30))
BEGIN
 
select  pumpreadings.TransferFrom,if(pumpreadings.TransferTo='2001-01-01 01:01:01',Now(),pumpreadings.TransferTo) as TransferTO,
pumpreadings.StartCount,pumpreadings.EndCount,pumpreadings.PumpID, pumpreadings.id,pumpreadings.TotalLiters,
(select sum(pumptransactions.Liters) from pumptransactions,`pos`.`order header` where pumptransactions.ShiftID=pShiftID 
and pumptransactions.OrderDetailID=`pos`.`order header`.ORDER_ID and `pos`.`order header`.`STATUS`='SERVED'
and pumptransactions.PumpID=pumpreadings.PumpID 
and createdDate>=fGetShiftStartDate(pLocationID,pPropertyID,pShiftID) and createddate<=fGetShiftEndDate(pLocationID,pPropertyID,pShiftID))
as PosSales,
(select pumps.ItemID from pumps where pumps.PumpID=pumpreadings.PumpID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID)
as ItemID,
(select tanks.SalesPrice from tanks left join pumps on tanks.TankID=pumps.TankID where pumps.PumpID=pumpreadings.PumpID) as UnitPrice,
(select sum(pumptransactions.Liters) from pumptransactions,`pos`.`order header` where pumptransactions.ShiftID=pShiftID 
and pumptransactions.OrderDetailID=`pos`.`order header`.ORDER_ID and `pos`.`order header`.`STATUS`='CANCELLED'
and pumptransactions.PumpID=pumpreadings.PumpID 
and createdDate>=fGetShiftStartDate(pLocationID,pPropertyID,pShiftID) and createddate<=fGetShiftEndDate(pLocationID,pPropertyID,pShiftID))
as VoidedLiters
 from pumpreadings where 
shiftid=pShiftID -- (select shiftid from pumpreadings where id=(select max(id) from pumpreadings)) 
and date(transferfrom)=(select max(date(transferfrom)) from pumpreadings where locationid=pLocationID and propertyid=pPropertyID)
and locationid=pLocationID and propertyid=pPropertyID group by pumpid;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPumpReadingsPrevious` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetPumpReadingsPrevious`(
pPropertyID varchar(30),
pLocationID varchar(30),
pShiftID varchar(30))
BEGIN
/* if (select count(shiftid) as cnt from pumpreadings where shiftid=pShiftID and locationid=pLocationID and propertyid=pShiftID and status='Open' limit 1)>0 then
select  pumpreadings.TransferFrom,if(pumpreadings.TransferTo='2001-01-01 01:01:01','',pumpreadings.TransferTo) as TransferTO,pumpreadings.StartCount,pumpreadings.EndCount,pumpreadings.PumpID, pumpreadings.id from pumpreadings,pumps where 
pumpreadings.LocationID = pumps.LocationID and pumpreadings.PropertyID = pumps.PropertyID and 
pumpreadings.PumpID = pumps.PumpID and pumpreadings.LocationID=pLocationID 
and pumpreadings.PropertyID=pPropertyID and pumpreadings.ShiftID=pShiftID and status='Open';
else */
select (select pos.cashiers.UPDATETIME from pos.cashiers limit 1) as StartShift,Now() as TransferTO,
endcount as StartCount,
EndCount,
pumpid as pumpIds,id,pumpreadings.TotalLiters,
(select endcount from pumpreadings where pumpid=pumpIds and 
pumpreadings.Status='Open' and pumpreadings.LocationID=pLocationID and pumpreadings.PropertyID=pPropertyID) as StartCnt,
ifnull((select sum(pumptransactions.Liters) from pumptransactions,`POS`.`order header` where pumptransactions.ShiftID=pShiftID 
and `pos`.`order header`.ORDER_ID=pumptransactions.OrderDetailID and `pos`.`order header`.`STATUS`='SERVED'
and pumptransactions.PumpID=pumpreadings.PumpID 
and createdDate>=fGetShiftStartDate(pLocationID,pPropertyID,pShiftID) and createddate<=fGetShiftEndDate(pLocationID,pPropertyID,pShiftID)),0)
as PosSales,
(select pumps.ItemID from pumps where pumps.PumpID=pumpreadings.PumpID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID)
as ItemID,
(select tanks.SalesPrice from tanks left join pumps on tanks.TankID=pumps.TankID where pumps.PumpID=pumpreadings.PumpID) as UnitPrice,
(select sum(pumptransactions.Liters) from pumptransactions,`POS`.`order header` where pumptransactions.ShiftID=pShiftID 
and `pos`.`order header`.ORDER_ID=pumptransactions.OrderDetailID and `pos`.`order header`.`STATUS`='CANCELLED'
and pumptransactions.PumpID=pumpreadings.PumpID 
and createdDate>=fGetShiftStartDate(pLocationID,pPropertyID,pShiftID) and createddate<=fGetShiftEndDate(pLocationID,pPropertyID,pShiftID))
as VoidedLiters,fReturnNumbersInString(pumpid) as nmber,
ifnull((select calibrationliter from calibration where calibration.pumpid=pumpreadings.PumpID and date(calibration.datecreated)= curdate() and calibration.shiftid=pumpreadings.ShiftID),0) as calibrateLiters
from pumpreadings where shiftid=pShiftID
and date(transferfrom)=(select max(date(transferfrom)) from pumpreadings)
and locationid=pLocationID and propertyid=pPropertyID group by pumpid order by nmber; 
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPumpReadingsPreviousDrawer` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetPumpReadingsPreviousDrawer`(
pPropertyID varchar(30),
pLocationID varchar(30),
pShiftID varchar(30))
BEGIN
/* if (select count(shiftid) as cnt from pumpreadings where shiftid=pShiftID and locationid=pLocationID and propertyid=pShiftID and status='Open' limit 1)>0 then
select  pumpreadings.TransferFrom,if(pumpreadings.TransferTo='2001-01-01 01:01:01','',pumpreadings.TransferTo) as TransferTO,pumpreadings.StartCount,pumpreadings.EndCount,pumpreadings.PumpID, pumpreadings.id from pumpreadings,pumps where 
pumpreadings.LocationID = pumps.LocationID and pumpreadings.PropertyID = pumps.PropertyID and 
pumpreadings.PumpID = pumps.PumpID and pumpreadings.LocationID=pLocationID 
and pumpreadings.PropertyID=pPropertyID and pumpreadings.ShiftID=pShiftID and status='Open';
else */
select (select pos.cashiers.UPDATETIME from pos.cashiers limit 1) as StartShift,Now() as TransferTO,
StartCount,
EndCount,
pumpid as pumpIds,id,TotaLliters,
(select endcount from pumpreadings where pumpid=pumpIds and 
pumpreadings.Status='Open' and pumpreadings.LocationID=pLocationID and pumpreadings.PropertyID=pPropertyID) as StartCnt,
ifnull((select sum(pumptransactions.Liters) from pumptransactions,`POS`.`order header` where pumptransactions.ShiftID=pShiftID 
and `pos`.`order header`.ORDER_ID=pumptransactions.OrderDetailID and `pos`.`order header`.`STATUS`='SERVED'
and pumptransactions.PumpID=pumpreadings.PumpID 
and createdDate>=fGetShiftStartDate(pLocationID,pPropertyID,pShiftID) and createddate<=fGetShiftEndDate(pLocationID,pPropertyID,pShiftID)),0)
as PosSales,
(select pumps.ItemID from pumps where pumps.PumpID=pumpreadings.PumpID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID)
as ItemID,
(select tanks.SalesPrice from tanks left join pumps on tanks.TankID=pumps.TankID where pumps.PumpID=pumpreadings.PumpID) as UnitPrice,
(select sum(pumptransactions.Liters) from pumptransactions,`POS`.`order header` where pumptransactions.ShiftID=pShiftID 
and `pos`.`order header`.ORDER_ID=pumptransactions.OrderDetailID and `pos`.`order header`.`STATUS`='CANCELLED'
and pumptransactions.PumpID=pumpreadings.PumpID 
and createdDate>=fGetShiftStartDate(pLocationID,pPropertyID,pShiftID) and createddate<=fGetShiftEndDate(pLocationID,pPropertyID,pShiftID))
as VoidedLiters,
fReturnNumbersInString(pumpid) as nmber,
ifnull((select calibrationliter from calibration where calibration.pumpid=pumpreadings.PumpID and date(calibration.datecreated)= curdate() and calibration.shiftid=pumpreadings.ShiftID),0) as calibrateLiters
from pumpreadings where shiftid=pShiftID
and date(transferfrom)=(select max(date(transferfrom)) from pumpreadings)
and locationid=pLocationID and propertyid=pPropertyID group by pumpid order by nmber; 
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRequestedItemsToTransferByID` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetRequestedItemsToTransferByID`(
pRequestId varchar(30)
)
BEGIN
SELECT  itrdetails.itrId, 
	itrdetails.itemId, 
	fGetItemDescription(itrdetails.itemId) as Description,
	fGetLocalStocks(itrdetails.itemId, itrheaders.propertyId, itrheaders.LocationIdRequestTo) as LocalStocks,
	fGetMinStockLevel(itrdetails.itemId, itrheaders.propertyId, itrheaders.LocationIdRequestTo) as MinStockLevel,
	itrdetails.quantity,
	fIsManageBySerialNo as MSerial,
	fIsManagedByLotNo as MLotNo,
	fIsManageByDateCode as MDateCode
	FROM itrdetails 
	LEFT JOIN itrheaders ON itrdetails.itrId = itrheaders.itrId
	WHERE itrdetails.itrId = pRequestId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetSAPConnections` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetSAPConnections`()
BEGIN
 
 select `name`, companyDatabase, companyUsername, companyPassword, databaseServer, databaseUsername, databasePassword
 from sapConnections
 where `status` = 'ACTIVE';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetSQLConnections` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetSQLConnections`()
BEGIN
 
 select sqlConnections.name, sqlConnections.server, sqlConnections.port, sqlConnections.database, sqlConnections.username, sqlConnections.password
 from sqlConnections
 where sqlConnections.status = 'ACTIVE';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetSuppliedItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetSuppliedItem`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT 	supplieditems.supItemId, 
	items.description, 
	supplier.SupplierName 
	FROM supplieditems, items, supplier 
	WHERE supplieditems.itemId = items.itemId 
	AND supplieditems.supplierId = supplier.supplierId
	AND supplieditems.status = 'Active'
	AND supplieditems.propertyID = pPropertyId
	AND supplieditems.locationId = pLocationId
	GROUP BY supItemId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetSuppliedItemBySupplier` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetSuppliedItemBySupplier`(
PROPERTYID varchar(30),
LOCATIONID varchar(30),
PSUPPLIERID varchar(30)
)
BEGIN
SELECT  items.itemId, 
	items.description, 
	items.unit,
	items.unitCost,
	fGetSupplierName(supplieditems.supplierId, PROPERTYID, LOCATIONID) as SupplierName,
	items.managedBySerialNumbers,
	items.managedByLotNo,
	items.managedByDateCode,
	items.groupId,
	supplieditems.supplierId,
	fGetLocalStocks(items.itemId, PROPERTYID, LOCATIONID) as CurrentStock
FROM 	supplieditems left join items on supplieditems.itemId = items.itemId
        Where items.itemId IN ( 
				select itemlocations.itemId 
				from itemlocations
				where itemlocations.propertyId = PROPERTYID
				and itemlocations.locationId = LOCATIONID
				and itemlocations.status = 'Active'
			       )
	AND supplieditems.supplierId = PSUPPLIERID
	and items.isInventoryItems = 'Yes'
	and supplieditems.locationId = LOCATIONID
	and supplieditems.propertyId = PROPERTYID
	group by itemid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetSuppliers` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetSuppliers`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
select 	supplierId, 
	SupplierName, 
	Address1, 
	Address2, 
	contactPerson, 
	postalAddress, 
	phone, 
	mobile, 
	fax, 
	email, 
	url, 
	defaultDiscount
	 
	from 
	supplier 
	where supplier.locationId = pLocationId
	AND supplier.PropertyID = pPropertyId
	and supplier.status <> 'Deleted';
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTanks` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTanks`(
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select tankid,concat(TankName,' (',Fueltype,')') as TankNames from Tanks where locationid=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTanksCost` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTanksCost`(
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select capitalcost from tanks,pumps where tanks.TankID=pumps.TankID and pumps.PumpID=pPumpID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTanksDipping` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTanksDipping`()
BEGIN
select tanks.TankID,tanks.TankName,tanks.FuelType,
ifnull((select tanksdipping.EndReading from tanksdipping where tanksdipping.tankid=tanks.TankID and tanksdipping.CreatedTime=
(select max(tanksdipping.CreatedTime) from tanksdipping where tanksdipping.tankid=tanks.TankID)),0) as StatReading
from tanks where tanks.Status='Active';
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTanksInfo` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTanksInfo`(
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select tankid,TankName,Fueltype,Qty,CreatedDate,CreatedBy,capitalcost,SalesPrice from Tanks where locationid=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTanksSalesPrice` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTanksSalesPrice`(
pItemID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select SalesPrice from tanks,pumps where tanks.TankID=pumps.TankID and pumps.ItemID=pItemID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTanksSalesPriceByPump` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTanksSalesPriceByPump`(
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
select SalesPrice from tanks,pumps where tanks.TankID=pumps.TankID and pumps.PumpID=pPumpID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTanksTypeByPump` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTanksTypeByPump`(
pLocationID varchar(30),
pPropertyID varchar(30),
pPumpID varchar(30))
BEGIN
select concat(tanks.TankName,' (',tanks.Fueltype,')') as TankNames from Tanks,pumps where tanks.LocationID=pLocationID and tanks.propertyid=pPropertyID
and pumps.TankID=tanks.TankID and pumps.PumpID=pPumpID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetUnits` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetUnits`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT unitName, description 
FROM units 
WHERE 
    locationid = pLocationId
AND propertyId = pPropertyId
AND `status` = 'Active';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCalibration` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertCalibration`(
pPumpID varchar(30),
pCalibrationLiter varchar(10),
pShiftID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
insert into calibration (pumpid,datecreated,calibrationliter,shiftid,locationid,propertyid) 
values (pPumpID,Now(),pCalibrationLiter,pShiftID,pLocationID,pPropertyID);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFuelMaingroupTracker` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertFuelMaingroupTracker`(
pMaingroupID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
insert into fuelmaingrouptracker (MaingroupID,locationID,propertyID) values 
(pMaingroupID,pLocationID,pPropertyID);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFuelType` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertFuelType`(
pLocationID varchar(30),
pPropertyID varchar(30),
pFuelType varchar(30),
pStatus varchar(30))
BEGIN
insert into fueltype (FuelType,Status,LocationID,PropertyID) values (pFuelType,pStatus,pLocationID,pPropertyID);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertGroup` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertGroup`(
   pGroupId varchar(30)
 , pDescription text
 , pMainGroupId varchar(30)
 , pGroupType varchar(30)
 , pProperty varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 INSERT INTO
 itemgroups
 SET
   itemgroups.groupId = pGroupId
 , itemgroups.description = pDescription
 , itemgroups.mainGroupId = pMainGroupId
 , itemgroups.groupType = pGroupType
 , itemgroups.locationId = pLocationId
 , itemgroups.propertyId = pProperty
 , itemgroups.status = 'Active'
 , itemgroups.createdBy = pUser
 , itemgroups.createdAt = now()
 , itemgroups.updatedBy = pUser
 , itemgroups.updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertItem`(
  pItemId varchar(30)
, pDescription varchar(255)
, pUnit varchar(30)
, pUnitCost double(12,2)
, pSellPrice double(12,2)
, pManagedBySerialNumbers varchar(30)
, pManagedByDateCode varchar(30)
, pManagedByLotNo varchar(30)
, pIsInventory varchar(30)
, pGroupId varchar(30)
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser varchar(30)
)
BEGIN
INSERT INTO
items
SET
  items.description = pDescription
, items.unit = pUnit
, items.unitCost = pUnitCost
, items.sellingPrice = pSellPrice
, items.managedBySerialNumbers = pManagedBySerialNumbers
, items.managedByDateCode = pManagedByDateCode
, items.managedByLotNo = pManagedByLotNo
, items.groupId =  pGroupId
, items.isInventoryItems = pIsInventory 
, items.status = 'Active'
, items.createdBy = pUser
, items.createdAt = now()
, items.updatedBy = pUser
, items.updatedAt = now();
select last_insert_id();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItem1` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertItem1`(
  pItemId varchar(30)
, pDescription varchar(255)
, pUnit varchar(30)
, pUnitCost double(12,2)
, pSellPrice double(12,2)
, pManagedBySerialNumbers varchar(30)
, pManagedByDateCode varchar(30)
, pManagedByLotNo varchar(30)
, pIsInventory varchar(30)
, pGroupId varchar(30)
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser varchar(30)
, pItemIdSAP varchar(30)
)
BEGIN
INSERT INTO
items
SET
  items.description = pDescription
, items.unit = pUnit
, items.unitCost = pUnitCost
, items.sellingPrice = pSellPrice
, items.managedBySerialNumbers = pManagedBySerialNumbers
, items.managedByDateCode = pManagedByDateCode
, items.managedByLotNo = pManagedByLotNo
, items.groupId =  pGroupId
, items.isInventoryItems = pIsInventory 
, items.status = 'Active'
, items.createdBy = pUser
, items.createdAt = now()
, items.updatedBy = pUser
, items.updatedAt = now()
, items.itemIdSAP=pItemIdSAP;
select last_insert_id();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemByLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertItemByLocation`(
   pItemId varchar(30)
 , pSellingPrice double (12,2)
 , pMinStockLevel double (12,2)
 , pMaxStockLevel double (12,2)
 , pLocalTax double (12,2)
 , pEvat double (12,2)
 , pServiceCharge varchar(30)
 , pPreparationArea varchar(30)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 INSERT INTO
 itemlocations
 SET
    itemlocations.itemId = pItemId
 ,  itemlocations.sellingPrice = pSellingPrice
 ,  itemlocations.minStockLevel = pMinStockLevel
 ,  itemlocations.maxStockLevel = pMaxStockLevel
 ,  itemlocations.localTax = pLocalTax
 ,  itemlocations.evat = pEvat
 ,  itemlocations.serviceCharge = pServiceCharge
 ,  itemlocations.preparationArea = pPreparationArea
 ,  itemlocations.propertyId = pPropertyId
 ,  itemlocations.locationId =  pLocationId
 ,  itemlocations.status = 'Active'
 ,  itemlocations.createdBy = pUser
 ,  itemlocations.createdAt = now()
 ,  itemlocations.updatedBy = pUser
 ,  itemlocations.updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemByLocation1` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertItemByLocation1`(
   pItemId varchar(30)
 , pSellingPrice double (12,2)
 , pMinStockLevel double (12,2)
 , pMaxStockLevel double (12,2)
 , pLocalTax double (12,2)
 , pEvat double (12,2)
 , pServiceCharge varchar(30)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 , pQty double(12,2)
 )
BEGIN
 INSERT INTO
 itemlocations
 SET
    itemlocations.itemId = pItemId
 ,  itemlocations.sellingPrice = pSellingPrice
 -- ,  itemlocations.minStockLevel = pMinStockLevel
 -- ,  itemlocations.localTax = pLocalTax
 -- ,  itemlocations.evat = pEvat
 -- ,  itemlocations.serviceCharge = pServiceCharge
 ,  itemlocations.propertyId = pPropertyId
 ,  itemlocations.locationId =  pLocationId
 ,  itemlocations.status = 'Active'
 ,  itemlocations.createdBy = pUser
 ,  itemlocations.createdAt = now()
 ,  itemlocations.updatedBy = pUser
 ,  itemlocations.updatedAt = now()
 ,  itemlocations.quantity=pQty;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertitemledgerFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertitemledgerFuel`(
  pItemId varchar(30)
, pModuleName varchar(100)
, pDocumentId varchar(30)
, pFromLocation varchar(30)
, pToLocation varchar(30)
, pQty double(12,2)
, pSerialNo text
, pAction varchar(30)
, pQtyWholeNumber varchar(30)
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser varchar(30)
)
BEGIN
INSERT INTO
itemledger
SET
  itemledger.propertyID = pPropertyId
, itemledger.locationId = pLocationId
, itemledger.itemID = pItemId
, itemledger.moduleName = pModuleName
, itemledger.documentId = pDocumentId -- fGetMaxDocumentID()
, itemledger.fromLocation = pFromLocation
, itemledger.toLocation = pToLocation
, itemledger.beginningBalance = fGetEndingBalance(pItemId,pLocationId,pPropertyId)  -- (select itemledger.endingBalance from itemledger where itemledger.ledgerId=(SELECT max(itemledger.ledgerId) from itemledger where itemledger.itemid=pItemId))
, itemledger.quantity = pQtyWholeNumber
, itemledger.serialNo = pSerialNo
, itemledger.inventoryAction = pAction
, itemledger.endingBalance = (itemledger.beginningBalance  + pQty )
, itemledger.createdBy = pUser
, itemledger.createdAt = now()
, itemledger.updatedBy = pUser
, itemledger.updatedAt = now();
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemToLedger` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertItemToLedger`(
  pItemId varchar(30)
, pModuleName varchar(100)
, pDocumentId varchar(30)
, pFromLocation varchar(30)
, pToLocation varchar(30)
, pBeginningbBalance double(12,2)
, pQty double(12,2)
, pSerialNo text
, pAction varchar(30)
, pEndBalance double(12,2)
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser varchar(30)
)
BEGIN
INSERT INTO
itemledger
SET
  itemledger.propertyID = pPropertyId
, itemledger.locationId = pLocationId
, itemledger.itemID = pItemId
, itemledger.moduleName = pModuleName
, itemledger.documentId = pDocumentId
, itemledger.fromLocation = pFromLocation
, itemledger.toLocation = pToLocation
, itemledger.beginningBalance = pBeginningbBalance
, itemledger.quantity = pQty
, itemledger.serialNo = pSerialNo
, itemledger.inventoryAction = pAction
, itemledger.endingBalance = pEndBalance
, itemledger.createdBy = pUser
, itemledger.createdAt = now()
, itemledger.updatedBy = pUser
, itemledger.updatedAt = now();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertLocation`(
   pName varchar(30)
 , pOwner varchar(50)
 , pContactPerson varchar(50)
 , pTelephoneNumber varchar(20)
 , pFaxNumber varchar(20)
 , pAddress varchar(50)
 , pPropertyId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 insert into
 locations
 set
 `name` = pName
 , `owner` = pOwner
 , contactPerson = pContactPerson
 , telephoneNumber = pTelephoneNumber
 , faxNumber = pFaxNumber
 , address = pAddress
 , propertyId = pPropertyId
 , `status` = 'Active'
 , createdBy = pUser
 , createdAt = now()
 , updatedBy = pUser
 , updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMainGroup` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertMainGroup`(
   pName varchar(30)
 , pDescription varchar(200)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 insert into
 maingroups
 set
  mainGroupId = pName
 , description = pDescription
 , locationId = pLocationId
 , propertyId = pPropertyId
 , `status` = 'Active'
 , createdBy = pUser
 , createdAt = now()
 , updatedBy = pUser
 , updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertNewITemAtLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertNewITemAtLocation`(
   pItemId varchar(30)
 , pQty double(12,2)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 INSERT INTO
 itemlocations
 SET
   itemId = pItemId
 , quantity = pQty
 , sellingPrice = fGetSellingPrice(itemId, pPropertyId)
 , propertyId = pPropertyId
 , locationId =  pLocationId
 , `status` = 'Active'
 , createdBy = pUser
 , createdAt = now()
 , updatedBy = pUser
 , updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPreparationArea` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertPreparationArea`(
   pName varchar(30)
 , pDescription varchar(255)
 , pPrinterAssigned varchar(300)
 , pPropertyId varchar(30)
 , pLocationId varchar(30) 
 , pUser varchar(30)
 )
BEGIN
INSERT INTO preparationarea
SET
   preparationarea.preparationCode = pName
 , preparationarea.description = pDescription
 , preparationarea.propertyId = pPropertyId
 , preparationarea.locationId = pLocationId
 , preparationarea.`printerAssigned` = pPrinterAssigned
 , preparationarea.status = 'Active'
 , preparationarea.createdBy = pUser
 , preparationarea.createdAt = now()
 , preparationarea.updatedBy = pUser
 , preparationarea.updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPreparationAreaForResto` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertPreparationAreaForResto`(
   pName varchar(30)
 , pDescription varchar(255)
 , pPrinterAssigned varchar(300)
 , pPropertyId varchar(30)
 , pLocationId varchar(30) 
 , pUser varchar(30)
)
BEGIN
INSERT INTO preparationarea
SET
   preparationarea.preparationCode = pName
 , preparationarea.description = pDescription
 , preparationarea.printerAssigned = pPrinterAssigned
 , preparationarea.propertyId = pPropertyId
 , preparationarea.locationId = pLocationId
 , preparationarea.status = 'Active'
 , preparationarea.createdBy = pUser
 , preparationarea.createdAt = now()
 , preparationarea.updatedBy = pUser
 , preparationarea.updatedAt = now();
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPriceHistory` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertPriceHistory`(
pItemID varchar(30),
pPrice varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
insert into pricehistory (tankid,price,datecreated) values (
(select Tankid from pumps where itemid=pItemID and locationID=pLocationID and PropertyID=pPropertyID limit 1),
pPrice,Now());
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPumpReadings` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertPumpReadings`(
pShiftID varchar(30),
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
/*
if (select count(shiftid) as shiftid from pumpreadings where shiftid=26 and locationid=1 and propertyid=1) > 0 then
update pumpreadings set transferfrom=pTransferFrom,transferto=pTransferTO,
startcount=pStartCount,endcount=pEndcount,TotalLiters=pTotalLiters  where id=pID;
else
*/
insert into pumpreadings (ShiftID,PumpID,TransferFrom,TransferTo,LocationID,PropertyID) values(pShiftID,pPumpID,Now(),Now(),pLocationID,pPropertyID);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPumps` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertPumps`(
pPumpID varchar(30),
pTankID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
   insert into pumps (PumpID,FuelType,TankID,LocationID,PropertyID) values 
(pPumpID,(select fueltype from tanks where tankid=pTankID and locationid=pLocationID and propertyID=pPropertyID),
pTankID,pLocationID,pPropertyID);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPumpTransactions` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertPumpTransactions`(
pOrderDetailID bigint,
pItemID varchar(30),
pQtyByLiters decimal(12,4),
pUnitprice decimal(12,2),
pAmount decimal(12,4),
pDiscount decimal(12,4),
pShiftID varchar(10))
BEGIN
insert into pumptransactions (OrderDetailID,itemid,pumpID,Liters,Unitprice,Amount,CreatedDate,Discount,ShiftID)
values (pOrderDetailID,pItemID,(select groupid from Items where ItemId=pItemID),
pQtyByLiters,pUnitprice,pAmount,Now(),pDiscount,pShiftID);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSAPConnection` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertSAPConnection`(
 pName varchar(30)
 , pCompanyDatabase varchar(30)
 , pDatabaseServer varchar(30)
 , pCompanyUsername varchar(30)
 , pCompanyPassword varchar(30)
 , pDatabaseUsername varchar(30)
 , pDatabasePassword varchar(30)	
 )
BEGIN
  set @sapConnection = 0;
 	 select count(*) into @sapConnection from sapConnections where sapConnections.name = pName limit 1;
  if @sapConnection = 1 then
 update sapConnections
 set sapConnections.companyDatabase = pCompanyDatabase
 , sapConnections.databaseServer = pDatabaseServer
 , sapConnections.companyUsername = pCompanyUsername
 , sapConnections.companyPassword = pCompanyPassword
 , sapConnections.databaseUsername = pDatabaseUsername
 , sapConnections.databasePassword = pDatabasePassword
 , sapConnections.status = 'ACTIVE'
 where sapConnections.name = pName;
 else
 insert into sapConnections
 set sapConnections.name = pName
 , sapConnections.companyDatabase = pCompanyDatabase
 , sapConnections.databaseServer = pDatabaseServer
 , sapConnections.companyUsername = pCompanyUsername
 , sapConnections.companyPassword = pCompanyPassword
 , sapConnections.databaseUsername = pDatabaseUsername
 , sapConnections.databasePassword = pDatabasePassword;
 end if;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSQLConnection` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertSQLConnection`(
 pName varchar(30)
 , pServer varchar(30)
 , pPort varchar(30)
 , pDatabase varchar(30)
 , pUsername varchar(30)
 , pPassword varchar(30)
 )
BEGIN
  set @sqlConnection = 0;
  select count(*) into @sqlConnection from sqlConnections where sqlConnections.name = pName limit 1;
  if @sqlConnection = 1 then
 update sqlConnections
 set sqlConnections.server = pServer
 , sqlConnections.port = pPort
 , sqlConnections.database = pDatabase
 , sqlConnections.username = pUsername
 , sqlConnections.password = pPassword
 , sqlConnections.status = 'ACTIVE'
 where sqlConnections.name = pName;
 else
 insert into sqlConnections
 set sqlConnections.name = pName
 , sqlConnections.server = pServer
 , sqlConnections.port = pPort
 , sqlConnections.database = pDatabase
 , sqlConnections.username = pUsername
 , sqlConnections.password = pPassword;
 end if;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSuppliedItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertSuppliedItem`(
  pSupplierId varchar(30)
, pItemId varchar(30)
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser varchar(30)
)
BEGIN
INSERT INTO
supplieditems
SET
  supplieditems.itemId = pItemId
, supplieditems.supplierId = pSupplierId
, supplieditems.locationId = pLocationId
, supplieditems.propertyId = pPropertyId
, supplieditems.status = 'Active'
, supplieditems.createdBy = pUser
, supplieditems.createdAt = now()
, supplieditems.updatedBy = pUser
, supplieditems.updatedAt = now();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSupplier` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertSupplier`(
  pSupplierId varchar(30)
, pSupplierName varchar(200)
, pAddress1 varchar(200)
, pAddress2 varchar(200)
, pcontactPerson varchar(50)
, pPostal varchar(50)
, pPhone varchar(15)
, pMobile varchar(20)
, pFax varchar(20)
, pEmail varchar(50)
, pUrl varchar(100)
, pDiscount double(12,2)
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser  varchar(30)
)
BEGIN
INSERT INTO
supplier
SET
  supplier.supplierId = pSupplierId
, supplier.SupplierName = pSupplierName
, supplier.Address1 = pAddress1
, supplier.Address2 = pAddress2
, supplier.contactPerson = pcontactPerson
, supplier.postalAddress = pPostal
, supplier.phone = pPhone
, supplier.mobile = pMobile
, supplier.fax = pFax
, supplier.email = pEmail
, supplier.url = pUrl
, supplier.defaultDiscount = pDiscount
, supplier.locationId = pLocationId
, supplier.propertyId = pPropertyId
, supplier.status = 'Active'
, supplier.createdBy = pUser
, supplier.createdAt = now()
, supplier.updatedBy = pUser
, supplier.updatedAt = now();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertTanks` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertTanks`(
pTankName varchar(30),
pFuelType varchar(30),
pCreatedBy varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30),
pCost varchar(10),
pSalesPrice varchar(10))
BEGIN
insert into Tanks (TankName,FuelType,CreatedDate,CreatedBy,LocationID,PropertyID,CapitalCost,SalesPrice) 
values (pTankName,pFuelType,Now(),pCreatedBy,pLocationID,pPropertyID,pCost,pSalesPrice);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertTanksDipping` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertTanksDipping`(
pStartReading decimal(12,2),
pEndReading decimal(12,2),
pTotalLiters decimal(12,2),
pShiftID varchar(30),
pTankid varchar(30))
BEGIN
insert into tanksdipping (StartReading,EndReading,Totalliters,createdtime,shiftid,tankid) 
values (pStartReading,pEndReading,pTotalLiters,Now(),pShiftID,pTankid);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertUnit` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertUnit`(
   pName varchar(30)
 , pDescription text
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 insert into
 units
 set
   units.unitName = pName
 , units.description = pDescription
 , units.locationId = pLocationId
 , units.propertyId = pPropertyId
 , units.status = 'Active'
 , units.createdBy = pUser
 , units.createdAt = now()
 , units.updatedBy = pUser
 , units.updatedAt = now();
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spRemoveStockAtLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spRemoveStockAtLocation`(
   pItemId varchar(30)
 , pQty double(12,2)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
UPDATE  itemlocations
SET	itemlocations.quantity = quantity - pQty,
	itemlocations.updatedBy = pUser,
	itemlocations.updatedAt = now()
	WHERE 
        itemlocations.propertyId = pPropertyId
	AND itemlocations.locationId =  pLocationId
	AND itemlocations.status = 'Active'
	AND itemlocations.itemId = pItemId
	AND itemlocations.quantity >= pQty
	;
/*
	if (ROW_COUNT() > 0) then
		select 
		itemlocations.quantity 
		from itemlocations 
		where itemlocations.itemId = pItemId 
		and itemlocations.locationId = pLocationId 
		and itemlocations.propertyId = pPropertyId
		and itemlocations.status = 'Active';
	else
		select 'NONE' from dual;
	end if;
*/
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportAllFuelCashierTransactions` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportAllFuelCashierTransactions`(
IN pterminalid INT(4),
IN prestaurantid INT(5),
IN pshiftcode INT(5),
IN pStartDate DATE,
IN pEndDate DATE
)
BEGIN
SELECT DISTINCT
CONCAT(cashiers_logs.terminalid) AS Terminal,
cashiers_logs.cashierid,
cashiers_logs.shiftcode,
cashiers_logs.openingbalance,
cashiers_logs.openingadjustment,
cashiers_logs.beginningbalance,
cashiers_logs.chargeinamount,
cashiers_logs.cash,
cashiers_logs.creditcard,
cashiers_logs.cheque,	
(SELECT SUM(amount) FROM pos.payment WHERE shift_code=pShiftCode AND terminal_id=pTerminalID AND DATE(payment_Date) BETWEEN pStartDate AND pEndDate AND `status`!='VOID' AND payment_type = 'ACCOUNT_NONSTAY') AS others,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.remarks,
cashiers_logs.amountremitted,
payment.payment_date,
payment.order_id,
IF(payment.payment_type = 'ACCOUNT_NONSTAY', 'ON ACCOUNT', payment.payment_type) AS payment_type,
payment.amount AS paidAmount,
ABS(`order header`.balance) AS `change`,
payment.amount - ABS(`order header`.balance) AS amount,
IF(payment.payment_type='CASH','WALK-IN',payment.ACCOUNT_ID) AS ACCOUNT,
cashiers_logs.updatedby AS cashier,
IF(payment.payment_type='CREDIT', CONCAT((SELECT carddescription FROM pos.creditcardtype WHERE creditcardid=payment.card_co), " :\nCREDIT CARD # : ", payment.creditcard_no, "\nAPPROVAL CODE : ", payment.approval_code), '') AS details
FROM 	
pos.cashiers_logs,
pos.payment,
pos.`order header`
WHERE
cashiers_logs.terminalid = pterminalid AND
`order header`.order_id=payment.order_id AND
payment.terminal_id = pterminalid AND DATE(`order header`.order_date) >= pStartDate AND DATE(`order header`.order_date) <= pEndDate AND
payment.restaurant_id = prestaurantid AND
payment.shift_code=pshiftcode AND
cashiers_logs.restaurantid = prestaurantid AND
cashiers_logs.shiftcode=pshiftcode AND
cashiers_logs.type='CLOSE' AND cashiers_logs.transactiondate BETWEEN pStartDate AND pEndDate
ORDER BY payment.payment_date;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDailyFuelSalesReceipt` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDailyFuelSalesReceipt`(pDate varchar(30))
BEGIN
/*SELECT
`order header`.order_id AS OrderID,
IF(pos.`order header`.customer_id='WALK-IN', 'WALK-IN', 
	IF(`order header`.employee_id != '', 
	pos.fGetEmployeeName(`order header`.employee_id), 
	(SELECT CONCAT(firstname, ' ', lastname) FROM hotelmgtsystem.guests WHERE accountid = `order header`.customer_id))) AS CustomerName,
ROUND(pumptransactions.`Liters`,2) as qty,
CONCAT(SUBSTRING(Description, 1, LOCATE(' ', Description, 1) - 1),' @ ', ROUND(pumptransactions.`UnitPrice`,2)) AS detail,
DATE(order_date) AS OrderDate,
total_amount AS GrossSales,
total_amount + total_discount AS GrossSalesWDisc,
vat_sales AS VatSales,
vat_amount AS GovernmentTax,
if(fGetPaymentType(`order header`.order_id) = 'CASH', total_amount, 0) AS Cash,
IF(fGetPaymentType(`order header`.order_id) = 'CREDIT', total_amount + total_discount, 0) AS Credit,
IF(fGetPaymentType(`order header`.order_id) = 'ACCT. EMPLOYEE', total_amount + total_discount, 0) AS AcctEmployee,
IF(fGetPaymentType(`order header`.order_id) = 'ON ACCOUNT', total_amount, 0) AS AcctCustomer,
fGetTotalFuelGrossSales() AS TotalGrossSales,
pos.fGetTotalVATSales() AS TotalVatSales,
pos.fGetTotalVATAmount() as TotalGovtTax,
shift_code,
terminal_id
FROM pos.`order header`INNER JOIN pumptransactions ON pos.`order header`.ORDER_ID = pumptransactions.OrderDetailID
inner join pos.`order detail` on pumptransactions.OrderDetailID = pos.`order detail`.`ORDER_ID` and pos.`order detail`.`OPERATION_STATUS` != 'CANCELLED'
WHERE DATE(order_date)= pDate AND `order header`.STATUS!='CANCELLED'
AND `order header`.order_id IN (SELECT DISTINCT order_id FROM pos.payment)*/
select 	OrderID,
	if(CustomerName = 'WALK-IN', 'WALK-IN', concat(CustomerName, ' (', fGetFuelTypeAbrv(itemid), ')')) as CustomerName,
	qty,
	detail,
	OrderDate,
	GrossSales,
	GrossSalesWDisc,
	VatSales,
	GovernmentTax,
	Cash,
	Credit,
	AcctEmployee,
	AcctCustomer,
	TotalGrossSales,
	TotalVatSales,
	TotalGovtTax,
	shift_code,
	terminal_id
from
(
SELECT
pumptransactions.itemid,
`order header`.order_id AS OrderID,
IF(pos.`order header`.customer_id='WALK-IN', 'WALK-IN',  
	(SELECT substring(CONCAT(firstname, ' ', lastname),1,12) FROM hotelmgtsystem.guests WHERE accountid = `order header`.customer_id)) AS CustomerName,
ROUND(pumptransactions.`Liters`,2) as qty,
CONCAT(SUBSTRING(Description, 1, LOCATE(' ', Description, 1) - 1),' @ ', ROUND(pumptransactions.`UnitPrice`,2)) AS detail,
DATE(order_date) AS OrderDate,
total_amount AS GrossSales,
total_amount + total_discount AS GrossSalesWDisc,
vat_sales AS VatSales,
vat_amount AS GovernmentTax,
if(fGetPaymentType(`order header`.order_id) = 'CASH', total_amount, 0) AS Cash,
IF(fGetPaymentType(`order header`.order_id) = 'CREDIT', total_amount + total_discount, 0) AS Credit,
IF(fGetPaymentType(`order header`.order_id) = 'ACCT. EMPLOYEE', total_amount + total_discount, 0) AS AcctEmployee,
IF(fGetPaymentType(`order header`.order_id) = 'ON ACCOUNT', total_amount, 0) AS AcctCustomer,
fGetTotalFuelGrossSales() AS TotalGrossSales,
pos.fGetTotalVATSales() AS TotalVatSales,
pos.fGetTotalVATAmount() as TotalGovtTax,
shift_code,
terminal_id
FROM pos.`order header`INNER JOIN pumptransactions ON pos.`order header`.ORDER_ID = pumptransactions.OrderDetailID
inner join pos.`order detail` on pumptransactions.OrderDetailID = pos.`order detail`.`ORDER_ID` and pos.`order detail`.`OPERATION_STATUS` != 'CANCELLED'
WHERE DATE(order_date)= pdate AND `order header`.STATUS!='CANCELLED'
AND `order header`.order_id IN (SELECT DISTINCT order_id FROM pos.payment)) as sql1;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDailyFuelSalesRevenue` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDailyFuelSalesRevenue`(
    IN pTerminalId INT(4),
	IN pLocationId INT(4),
	IN pDate DATE)
BEGIN
	SELECT
	dtl.`ITEM_ID`,
	dtl.`ORDER_ID`,
	dtl.`UNIT_PRICE`,
        fGetItemDescription(dtl.`ITEM_ID`) AS ItemName,
        dtl.AMOUNT AS NetAmount,
	dtl.`VAT`,
	dtl.`QUANTITY`,
	ROUND(od.`discountRate` * od.`qty`, 2) as DISCOUNT,
	(dtl.`AMOUNT` + dtl.`VAT` + dtl.`DISCOUNT`) AS AMOUNT,
	ROUND((dtl.`DISCOUNT` /  (dtl.`UNIT_PRICE` * dtl.`QUANTITY`)) * 100, 2)  AS DiscountRate, 										    
	ROUND(dtl.`UNIT_PRICE` / (1 + (itml.`evat`/100)),2) AS NETPRICE, 			    
	IF(hdr.`CUSTOMER_ID` = '', hdr.`EMPLOYEE_ID`, hdr.`CUSTOMER_ID`) AS CUSTOMER_ID,
	IF(hdr.customer_id='WALK-IN', 'WALK-IN', 
	IF(hdr.employee_id != '', 
	pos.fGetEmployeeName(hdr.employee_id), 
	(SELECT CONCAT(firstname, ' ', lastname) FROM hotelmgtsystem.guests WHERE accountid = hdr.customer_id))) AS CustomerName
	FROM
	pos.`order detail` dtl
	LEFT JOIN pos.`order header` hdr
	ON dtl.`ORDER_ID` = hdr.`ORDER_ID`
	left join pos.`order_detail_discqty` od
	on hdr.`ORDER_ID` = od.orderid 
	LEFT JOIN `itemlocations` itml
	ON itml.`itemId` = dtl.`ITEM_ID` AND itml.`locationId` = pLocationId
	WHERE DATE(hdr.`ORDER_DATE`) = pDate
	AND dtl.`OPERATION_STATUS` <> 'CANCELLED'		
	AND hdr.`STATUS` = 'SERVED'
	AND hdr.`TERMINAL_ID` = pTerminalId
	group by hdr.`ORDER_ID`
	ORDER BY dtl.ORDER_ID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDailyHotelRevenue` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDailyHotelRevenue`(
in pHotelId int(4),
in pStartDate date,
in pEndDate date
)
BEGIN
/*(
select
foliotransactions.postingDate,
foliotransactions.transactionDate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource`,
foliotransactions.`FolioID`,
guests.accountid,
if(folioschedules.`RoomType`='FUNCTION',
	IF(folio.`AccountType` = 'PERSONAL',
	(SELECT CONCAT(`firstName`," " , `lastName`) FROM guests WHERE guests.`AccountId` = folio.`CompanyId`),
	(SELECT CompanyName FROM company WHERE CompanyId = folio.`CompanyId`)),
concat(guests.`firstName`," " , guests.`lastName`)
) as GuestName,
foliotransactions.transactioncode,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`baseAmount`, (foliotransactions.`baseAmount` * -1) ) as baseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`, (foliotransactions.`netBaseAmount` * -1) ) as netBaseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`grossAmount`, (foliotransactions.`grossAmount` * -1) ) as grossAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`discount`, (foliotransactions.`discount` * -1) ) as discount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`serviceCharge`, (foliotransactions.`serviceCharge` * -1) ) as serviceCharge,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`governmentTax`, (foliotransactions.`governmentTax` * -1) ) as governmentTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`localTax`, (foliotransactions.`localTax` * -1) ) as localTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`mealAmount`, (foliotransactions.`mealAmount` * -1) ) as mealAmount,
foliotransactions.`Memo`, 
foliotransactions.subFolio,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netAmount`, (foliotransactions.`netAmount` * -1) ) as netAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`, (foliotransactions.`netBaseAmount` * -1) ) as Amount,
foliotransactions.`CREATEDBY`,
folioschedules.roomid,
folioschedules.roomtype,
company.companyName,
'' as REMARKS,
folioschedules.RateType,
folio.NoOfAdults+folio.NoOfChild as pax
from
foliotransactions
left join transactioncode on transactioncode.tranCode = foliotransactions.transactioncode
left join folioschedules on folioschedules.folioid = foliotransactions.folioid
left join folio on (folioschedules.folioid = folio.folioid)
left join company on folio.companyid = company.companyid
left join guests on guests.accountid = folio.accountid
where
date(foliotransactions.`TransactionDate`) >= pStartDate and 
date(foliotransactions.`TransactionDate`) <= pEndDate and
foliotransactions.status = 'ACTIVE' and
transactioncode.tranTypeID = 1 group by folioid, referenceno, transactionsource
)
UNION
(
select
nonguesttransaction.postingDate,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource,
nonguesttransaction.referenceFolioId as FolioId,
nonguesttransaction.accountId,
if(nonguesttransaction.guestName="","WALK-IN GUEST",nonguesttransaction.guestName) as GuestName,
nonguesttransaction.transactionCode, 
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.baseAmount, (nonguesttransaction.baseAmount * -1) ) as baseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netBaseAmount, (nonguesttransaction.netBaseAmount * -1) ) as netBaseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.grossAmount, (nonguesttransaction.grossAmount * -1) ) as grossAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.discount, (nonguesttransaction.discount * -1) ) as discount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.serviceCharge, (nonguesttransaction.serviceCharge * -1) ) as serviceCharge,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.governmentTax, (nonguesttransaction.governmentTax * -1) ) as governmentTax,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.localTax, (nonguesttransaction.localTax * -1) ) as localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netAmount, (nonguesttransaction.netAmount * -1) ) as netAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netbaseAmount, (nonguesttransaction.netbaseAmount * -1) ) as Amount,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
'' as roomtype,
nonguesttransaction.companyName,
'' as REMARKS,
'' as RateType,
0 as pax
from nonguesttransaction force index(primary)
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
where
date(nonguesttransaction.transactionDate) >= pStartDate and 
date(nonguesttransaction.`TransactionDate`) <= pEndDate and
nonguesttransaction.statusFlag = 'ACTIVE' and
nonguesttransaction.hotelID = pHotelId and
transactioncode.tranTypeID = 1 group by folioid, referenceno, transactionsource
)
UNION
(
select
h.createtime,
h.order_date,
h.order_id,
'POSCHECK#' as TransactionSource,
h.customer_id,
h.customer_id,
pos.fGetCustomerNamePerOrder(h.Customer_ID,
h.EMPLOYEE_ID) as GuestName,
(case g.maingroup_id
when 'FOOD' then
'1200'
when 'BEVERAGES' then
'1202'
when 'BANQUET' then
'1203'
else
'1402'
end) as TransCode,
sum(d.Unit_Price * d.Quantity) as baseAmount,
sum(d.Amount) as VatSale,
sum(d.Unit_Price * d.Quantity) as grossAmount,
sum(d.discount) as discount,
sum(d.service_charge) as ServiceCharge,
sum(d.VAT) as governmentTax,
sum(d.LOCAL_TAX) as localTax,
0 as mealAmount,
concat('RESTAURANT - DINE-IN - ',g.maingroup_id) as `Memo`,
'DINE-IN' as subFolio,
(sum(d.Unit_Price * d.Quantity)-sum(d.discount)) as netAmount,
sum(d.Amount) as Amount,
d.createdBy,
'' as roomid,
'' as roomtype,
'' as companyName,
'' as Remarks,
'' as RateType,
0 as pax
from 
pos.`order detail` d
left join 
pos.`order header` h on d.Order_Id = h.Order_Id
left join pos.item i on i.Item_ID = d.Item_Id
left join pos.`group` g on g.group_id = i.group_id
left join pos.payment p on h.order_id = p.order_id
where
g.maingroup_id is not null
and date(h.order_date) >= pStartDate 
and date(h.order_date) <= pEndDate 
and p.`status` != 'VOID' 
and p.payment_type IN ('CASH','Credit','ACCOUNT_EMPLOYEE')
and d.operation_status!='CANCELLED'
group by
g.maingroup_id,
h.order_id
)
union
(
select
h.createtime,
h.order_date,
h.order_id,
'POSCHECK#' as TransactionSource,
h.customer_id,
h.customer_id,
pos.fGetCustomerNamePerOrder(h.Customer_ID,
h.EMPLOYEE_ID) as GuestName,
(case METHOD
when 'OPEN_FOOD' then
'1200'
when 'OPEN_BEVERAGE' then
'1202'
when 'BANQUET_FOOD' then
'1200'
WHEN 'BANQUET_BEVERAGE' THEN
'1202'
end) as TransCode,
sum(d.Unit_Price * d.Quantity) as baseAmount,
sum(d.Amount) as VatSale,
sum(d.Unit_Price * d.Quantity) as grossAmount,
sum(d.discount) as discount,
sum(d.service_charge) as ServiceCharge,
sum(d.VAT) as governmentTax,
sum(d.LOCAL_TAX) as localTax,
0 as mealAmount,
concat('RESTAURANT - DINE-IN - ',d.description) as `Memo`,
'DINE-IN' as subFolio,
(sum(d.Unit_Price * d.Quantity)-sum(d.discount)) as netAmount,
sum(d.Amount) as Amount,
d.createdBy,
'' as roomid,
'' as roomtype,
'' as companyName,
'' as Remarks,
'' as RateType,
0 as pax
from 
pos.`order detail` d
left join 
pos.`order header` h on d.Order_Id = h.Order_Id
left join pos.`function mapping` i on i.function_id = d.Item_Id
left join pos.payment p on h.order_id = p.order_id
where
date(h.order_date) >= pStartDate
and date(h.order_date) <= pEndDate
and p.`status` != 'VOID'
and p.payment_type IN ('CASH','Credit','ACCOUNT_EMPLOYEE')
and d.operation_status!='CANCELLED'
and METHOD is not null and METHOD != ""
group by
i.function_id,
h.order_id
)*/
(
select
foliotransactions.postingDate,
foliotransactions.transactionDate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource`,
foliotransactions.`FolioID`,
guests.accountid,
if(folioschedules.`RoomType`='FUNCTION',
	IF(folio.`AccountType` = 'PERSONAL',
	(SELECT CONCAT(`firstName`," " , `lastName`) FROM guests WHERE guests.`AccountId` = folio.`CompanyId`),
	(SELECT CompanyName FROM company WHERE CompanyId = folio.`CompanyId`)),
concat(guests.`firstName`," " , guests.`lastName`)
) as GuestName,
foliotransactions.transactioncode,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`baseAmount`, (foliotransactions.`baseAmount` * -1) ) as baseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`, (foliotransactions.`netBaseAmount` * -1) ) as netBaseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`grossAmount`, (foliotransactions.`grossAmount` * -1) ) as grossAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`discount`, (foliotransactions.`discount` * -1) ) as discount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`serviceCharge`, (foliotransactions.`serviceCharge` * -1) ) as serviceCharge,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`governmentTax`, (foliotransactions.`governmentTax` * -1) ) as governmentTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`localTax`, (foliotransactions.`localTax` * -1) ) as localTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`mealAmount`, (foliotransactions.`mealAmount` * -1) ) as mealAmount,
foliotransactions.`Memo`, 
foliotransactions.subFolio,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netAmount`, (foliotransactions.`netAmount` * -1) ) as netAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`, (foliotransactions.`netBaseAmount` * -1) ) as Amount,
foliotransactions.`CREATEDBY`,
folioschedules.roomid,
folioschedules.roomtype,
company.companyName,
'' as REMARKS,
folioschedules.RateType,
folio.NoOfAdults+folio.NoOfChild as pax
from
foliotransactions
left join transactioncode on transactioncode.tranCode = foliotransactions.transactioncode
left join folioschedules on folioschedules.folioid = foliotransactions.folioid
left join folio on (folioschedules.folioid = folio.folioid)
left join company on folio.companyid = company.companyid
left join guests on guests.accountid = folio.accountid
where
date(foliotransactions.`TransactionDate`) >= pStartDate and 
date(foliotransactions.`TransactionDate`) <= pEndDate and
foliotransactions.status = 'ACTIVE' and
transactioncode.tranTypeID = 1 group by folioid, referenceno, transactionsource
)
UNION
(
select
nonguesttransaction.postingDate,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource,
nonguesttransaction.referenceFolioId as FolioId,
nonguesttransaction.accountId,
if(nonguesttransaction.guestName="","WALK-IN GUEST",nonguesttransaction.guestName) as GuestName,
nonguesttransaction.transactionCode, 
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.baseAmount, (nonguesttransaction.baseAmount * -1) ) as baseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netBaseAmount, (nonguesttransaction.netBaseAmount * -1) ) as netBaseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.grossAmount, (nonguesttransaction.grossAmount * -1) ) as grossAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.discount, (nonguesttransaction.discount * -1) ) as discount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.serviceCharge, (nonguesttransaction.serviceCharge * -1) ) as serviceCharge,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.governmentTax, (nonguesttransaction.governmentTax * -1) ) as governmentTax,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.localTax, (nonguesttransaction.localTax * -1) ) as localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netAmount, (nonguesttransaction.netAmount * -1) ) as netAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netbaseAmount, (nonguesttransaction.netbaseAmount * -1) ) as Amount,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
'' as roomtype,
nonguesttransaction.companyName,
'' as REMARKS,
'' as RateType,
0 as pax
from nonguesttransaction force index(primary)
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
where
date(nonguesttransaction.transactionDate) >= pStartDate and 
date(nonguesttransaction.`TransactionDate`) <= pEndDate and
nonguesttransaction.statusFlag = 'ACTIVE' and
nonguesttransaction.hotelID = pHotelId and
transactioncode.tranTypeID = 1 group by folioid, referenceno, transactionsource
)
UNION
(
select
h.createtime,
h.order_date,
h.order_id,
'POSCHECK#' as TransactionSource,
h.customer_id,
h.customer_id,
pos.fGetCustomerNamePerOrder(h.Customer_ID,
h.EMPLOYEE_ID) as GuestName,
(case g.maingroup_id
when 'FOOD' then
'1200'
when 'BEVERAGES' then
'1202'
when 'BANQUET' then
'1203'
else
'1402'
end) as TransCode,
sum(d.Unit_Price * d.Quantity) as baseAmount,
sum(d.Amount) as VatSale,
sum(d.Unit_Price * d.Quantity) as grossAmount,
sum(d.discount) as discount,
sum(d.service_charge) as ServiceCharge,
sum(d.VAT) as governmentTax,
sum(d.LOCAL_TAX) as localTax,
0 as mealAmount,
concat('RESTAURANT - DINE-IN - ',g.maingroup_id) as `Memo`,
'DINE-IN' as subFolio,
(sum(d.Unit_Price * d.Quantity)-sum(d.discount)) as netAmount,
sum(d.Amount) as Amount,
d.createdBy,
'' as roomid,
'' as roomtype,
'' as companyName,
'' as Remarks,
'' as RateType,
0 as pax
from 
pos.`order detail` d
left join 
pos.`order header` h on d.Order_Id = h.Order_Id
left join items i on i.itemId = d.Item_Id
left join itemgroups g on g.groupId = i.groupId
left join pos.payment p on h.order_id = p.order_id
where
g.mainGroupId is not null
and date(h.order_date) >= pStartDate 
and date(h.order_date) <= pEndDate 
and p.`status` != 'VOID' 
and p.payment_type IN ('CASH','Credit','ACCOUNT_EMPLOYEE')
and d.operation_status!='CANCELLED'
group by
g.mainGroupId,
h.order_id
)
union
(
select
h.createtime,
h.order_date,
h.order_id,
'POSCHECK#' as TransactionSource,
h.customer_id,
h.customer_id,
pos.fGetCustomerNamePerOrder(h.Customer_ID,
h.EMPLOYEE_ID) as GuestName,
(case METHOD
when 'OPEN_FOOD' then
'1200'
when 'OPEN_BEVERAGE' then
'1202'
when 'BANQUET_FOOD' then
'1200'
WHEN 'BANQUET_BEVERAGE' THEN
'1202'
end) as TransCode,
sum(d.Unit_Price * d.Quantity) as baseAmount,
sum(d.Amount) as VatSale,
sum(d.Unit_Price * d.Quantity) as grossAmount,
sum(d.discount) as discount,
sum(d.service_charge) as ServiceCharge,
sum(d.VAT) as governmentTax,
sum(d.LOCAL_TAX) as localTax,
0 as mealAmount,
concat('RESTAURANT - DINE-IN - ',d.description) as `Memo`,
'DINE-IN' as subFolio,
(sum(d.Unit_Price * d.Quantity)-sum(d.discount)) as netAmount,
sum(d.Amount) as Amount,
d.createdBy,
'' as roomid,
'' as roomtype,
'' as companyName,
'' as Remarks,
'' as RateType,
0 as pax
from 
pos.`order detail` d
left join 
pos.`order header` h on d.Order_Id = h.Order_Id
left join pos.`function mapping` i on i.function_id = d.Item_Id
left join pos.payment p on h.order_id = p.order_id
where
date(h.order_date) >= pStartDate
and date(h.order_date) <= pEndDate
and p.`status` != 'VOID'
and p.payment_type IN ('CASH','Credit','ACCOUNT_EMPLOYEE')
and d.operation_status!='CANCELLED'
and METHOD is not null and METHOD != ""
group by
i.function_id,
h.order_id
)
order by transactionCode, transactionSource, ReferenceNo;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDailyVoidedFuelSalesReceipt` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDailyVoidedFuelSalesReceipt`(pDates varchar(30))
BEGIN
select IF(CustomerName = 'WALK-IN', concat(round(qty,2), ', CASH', ', ', (SELECT returnReason FROM inventory.`unsettledinventory` WHERE orderHeaderId = OrderID)), CONCAT(qty, ', ', CustomerName, ' (', fGetFuelTypeAbrv(itemid), ')', ', ', (select returnReason from inventory.`unsettledinventory` where orderHeaderId = OrderID))) AS CustomerName,
       OrderDate,
       qty,
       itemid,
       GrossSales, 
       OrderID   
from
(SELECT
`order header`.order_id AS OrderID,
IF(pos.`order header`.customer_id='WALK-IN', 'WALK-IN', 
	IF(`order header`.employee_id != '', 
	pos.fGetEmployeeName(`order header`.employee_id), 
	(SELECT CONCAT(firstname, ' ', lastname) FROM hotelmgtsystem.guests WHERE accountid = `order header`.customer_id))) AS CustomerName,
DATE(order_date) AS OrderDate,
pos.`order detail`.`QUANTITY` as qty,
pos.`order detail`.`ITEM_ID` as itemid,
total_amount+total_discount AS GrossSales
FROM pos.`order header` inner join pos.`order detail` 
on pos.`order header`.`ORDER_ID` = pos.`order detail`.`ORDER_ID`
WHERE DATE(order_date)= pDates AND `order header`.STATUS='CANCELLED'
and pos.`order header`.`ORDER_ID` in (select distinct orderHeaderId from inventory.`unsettledinventory`)
group by pos.`order header`.`ORDER_ID`) as sql1;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDefaultFuelAnnualSales` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDefaultFuelAnnualSales`(pYear int)
BEGIN
select
`order header`.order_id as OrderID,
IF(pos.`order header`.customer_id='WALK-IN', 'WALK-IN', 
	IF(`order header`.employee_id != '', 
	pos.fGetEmployeeName(`order header`.employee_id), 
	(SELECT CONCAT(firstname, ' ', lastname) FROM hotelmgtsystem.guests WHERE accountid = `order header`.customer_id))) AS CustomerName,
pumptransactions.`UnitPrice` AS sPrice,
pumptransactions.`Liters`,
fGetOrderItemDescription(`order header`.order_id) AS description,
fGetCreditApprovalCode(`order header`.order_id) AS AprCode,
fGetPaymentType(`order header`.order_id) AS pType,
total_amount+total_discount as GrossSales,
ROUND(`discountRate` * `order_detail_discqty`.`qty`, 2) AS Discount,
vat_sales as VatSales,
nonvat_sales as NonVatSales,
vat_amount as GovernmentTax,
fGetFuelMonthToDateGrossSales(month(now()), pYear) as MonthToDateGrossSales,
fGetFuelYearToDateGrossSales(pYear) as YearToDateGrossSales,
fGetFuelTotalGrossSales() as TotalGrossSales,
pos.fGetMonthToDateVATSales(month(now()), pYear) as MonthToDateVatSales,
pos.fGetYearToDateVATSales(pYear) as YearToDateVatSales,
pos.fGetTotalVATSales() as TotalVatSales
from pos.`order header` INNER JOIN pumptransactions ON pos.`order header`.ORDER_ID = pumptransactions.OrderDetailID
LEFT JOIN  pos.`order_detail_discqty` ON pumptransactions.OrderDetailID = pos.`order_detail_discqty`.`orderid`
where year(order_date)=pYear and `order header`.status!='CANCELLED'
AND `order header`.order_id IN (SELECT DISTINCT order_id FROM pos.payment)
GROUP BY pos.`order header`.`ORDER_ID`;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDefaultFuelDailySales` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDefaultFuelDailySales`(pDate date)
BEGIN
SELECT
`order header`.order_id AS OrderID,
IF(pos.`order header`.customer_id='WALK-IN', 'WALK-IN', 
	IF(`order header`.employee_id != '', 
	pos.fGetEmployeeName(`order header`.employee_id), 
	(SELECT CONCAT(firstname, ' ', lastname) FROM hotelmgtsystem.guests WHERE accountid = `order header`.customer_id))) AS CustomerName,
pumptransactions.`UnitPrice` as sPrice,
pumptransactions.`Liters`,
fGetOrderItemDescription(`order header`.order_id) AS description,
fGetCreditApprovalCode(`order header`.order_id) AS AprCode,
fGetPaymentType(`order header`.order_id) AS pType,
total_amount+total_discount AS GrossSales,
round(`discountRate` * `order_detail_discqty`.`qty`, 2)  AS Discount,
vat_sales AS VatSales,
vat_amount AS GovernmentTax,
fGetFuelMonthToDateGrossSales(MONTH(pDate), YEAR(pDate)) AS MonthToDateGrossSales,
fGetFuelYearToDateGrossSales(YEAR(pDate)) AS YearToDateGrossSales,
fGetFuelTotalGrossSales() AS TotalGrossSales,
pos.fGetMonthToDateVATSales(MONTH(pDate), YEAR(pDate)) AS MonthToDateVatSales,
pos.fGetYearToDateVATSales(YEAR(pDate)) AS YearToDateVatSales,
pos.fGetTotalVATSales() AS TotalVatSales
FROM pos.`order header` INNER JOIN pumptransactions ON pos.`order header`.ORDER_ID = pumptransactions.OrderDetailID
left join pos.`order_detail_discqty` on pumptransactions.OrderDetailID = pos.`order_detail_discqty`.`orderid`
WHERE DATE(order_date)= pDate AND `order header`.STATUS!='CANCELLED'
AND `order header`.order_id IN (SELECT DISTINCT order_id FROM pos.payment)
group by pos.`order header`.`ORDER_ID`;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDefaultFuelMonthlySales` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDefaultFuelMonthlySales`(pMonth int, pYear int)
BEGIN
SELECT
`order header`.order_id AS OrderID,
IF(pos.`order header`.customer_id='WALK-IN', 'WALK-IN', 
	IF(`order header`.employee_id != '', 
	pos.fGetEmployeeName(`order header`.employee_id), 
	(SELECT CONCAT(firstname, ' ', lastname) FROM hotelmgtsystem.guests WHERE accountid = `order header`.customer_id))) AS CustomerName,
pumptransactions.`UnitPrice` AS sPrice,
pumptransactions.`Liters`,
fGetOrderItemDescription(`order header`.order_id) AS description,
fGetCreditApprovalCode(`order header`.order_id) AS AprCode,
fGetPaymentType(`order header`.order_id) AS pType,
total_amount+total_discount AS GrossSales,
ROUND(`discountRate` * `order_detail_discqty`.`qty`, 2) AS Discount,
vat_sales AS VatSales,
nonvat_sales AS NonVatSales,
vat_amount AS GovernmentTax,
fGetFuelMonthToDateGrossSales(pMonth, pYear) AS MonthToDateGrossSales,
fGetFuelYearToDateGrossSales(pYear) AS YearToDateGrossSales,
fGetFuelTotalGrossSales() AS TotalGrossSales,
pos.fGetMonthToDateVATSales(pMonth, pYear) AS MonthToDateVatSales,
pos.fGetYearToDateVATSales(pYear) AS YearToDateVatSales,
pos.fGetTotalVATSales() AS TotalVatSales
FROM pos.`order header` INNER JOIN pumptransactions ON pos.`order header`.ORDER_ID = pumptransactions.OrderDetailID
left join  pos.`order_detail_discqty` ON pumptransactions.OrderDetailID = pos.`order_detail_discqty`.`orderid`
WHERE MONTH(order_date)=pMonth AND YEAR(order_date)=pYear AND `order header`.STATUS!='CANCELLED'
AND `order header`.order_id IN (SELECT DISTINCT order_id FROM pos.payment)
GROUP BY pos.`order header`.`ORDER_ID`;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDetailedFuelSalesPerItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDetailedFuelSalesPerItem`(
in pMainGroup varchar(30),
in pGroup varchar(50),
in pStartDate date,
in pEndDate date,
IN pRestoID int(11)
)
BEGIN
SELECT
0 as id,
hdr.`ORDER_DATE`,
hdr.`ORDER_ID`,
IF(hdr.`CUSTOMER_ID`="", pos.fGetEmployeeName(hdr.`EMPLOYEE_ID`),
IF(hdr.`CUSTOMER_ID`="WALK-IN", "WALK-IN", (SELECT CONCAT(firstname, ' ', lastname) FROM hotelmgtsystem.guests WHERE accountid = hdr.customer_id))) AS CUSTOMER_ID, 
dtl.`ITEM_ID`, 
itm.`description`,
dtl.`UNIT_PRICE` AS UnitPrice,
dtl.`QUANTITY`,
ROUND(od.`discountRate` * od.`qty`, 2) as DISCOUNT,
hdr.total_amount +hdr.total_discount AS GROSS,
(dtl.`AMOUNT`) AS Nett, 
dtl.`VAT`,
itm.`groupId` AS group_id,
grp.`mainGroupId` AS maingroup_id
FROM pos.`order detail` dtl
LEFT JOIN pos.`order header` hdr
ON dtl.`ORDER_ID` = hdr.`ORDER_ID`
LEFT JOIN pos.`order_detail_discqty` od
ON hdr.`ORDER_ID` = od.orderid 
LEFT JOIN `items` itm
ON dtl.`ITEM_ID` = itm.`itemId`
LEFT JOIN `itemgroups`grp
ON itm.`groupId` = grp.`groupId`
WHERE
IF(pMainGroup = 'All',grp.`mainGroupId`<> '',
grp.`mainGroupId`= pMainGroup) AND
IF(pGroup = 'All',grp.`groupId`<> '',grp.`groupId` = pGroup) AND
(hdr.`ORDER_DATE`>= pStartDate AND
hdr.`ORDER_DATE` <= pEndDate)
AND grp.`locationId` = pRestoID
AND dtl.`OPERATION_STATUS` <> 'CANCELLED'
GROUP BY hdr.`ORDER_ID`
ORDER BY hdr.`ORDER_DATE`;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDetailedFuelSalesPerOrder` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDetailedFuelSalesPerOrder`(
in pStartDate date,
in pEndDate date
)
BEGIN
SELECT
hdr.`ORDER_DATE`,
hdr.`ORDER_ID`,
IF(hdr.`CUSTOMER_ID`="", pos.fGetEmployeeName(hdr.`EMPLOYEE_ID`),
IF(hdr.`CUSTOMER_ID`="WALK-IN", "WALK-IN", pos.getGuestNameFromHotel(hdr.`CUSTOMER_ID`))) AS CUSTOMER_ID, 
dtl.`ITEM_ID`, 
dtl.`DESCRIPTION`,
dtl.`UNIT_PRICE` AS UnitPrice, 
SUM(dtl.`QUANTITY`) AS QUANTITY,
hdr.total_amount +hdr.total_discount as GrossAmount,
ROUND(od.`discountRate` * od.`qty`, 2)  AS Discount,
SUM(dtl.`VAT`) AS Vat,
SUM(dtl.`AMOUNT`) AS NetAmount
FROM pos.`order detail` dtl
LEFT JOIN pos.`order header` hdr
ON dtl.`ORDER_ID` = hdr.`ORDER_ID`
LEFT JOIN pos.`order_detail_discqty` od
ON hdr.`ORDER_ID` = od.orderid 
WHERE
(hdr.`ORDER_DATE` >= pStartDate AND
hdr.`ORDER_DATE` <= pEndDate)
AND dtl.`OPERATION_STATUS`!='CANCELLED'
GROUP BY dtl.`ITEM_ID`, dtl.`ORDER_ID`
ORDER BY hdr.`ORDER_DATE`;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelAnnualAcctReceivable` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportFuelAnnualAcctReceivable`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pYear int
)
BEGIN
SELECT  CONCAT(hotelmgtsystem.guests.LastName, ', ', hotelmgtsystem.guests.FirstName) AS `name`,
	IFNULL(MONTHNAME(DATE(hotelmgtsystem.cityledger.CreateTime)), '') AS `month`,
	IFNULL((SELECT SUM(hotelmgtsystem.cityledger.debit) FROM hotelmgtsystem.cityledger WHERE DAYOFMONTH(hotelmgtsystem.cityledger.`CreateTime`) BETWEEN 1 AND 15 AND hotelmgtsystem.cityledger.RefFolio = hotelmgtsystem.guests.AccountId), 0) AS firstHalf,
	IFNULL((SELECT SUM(hotelmgtsystem.cityledger.debit) FROM hotelmgtsystem.cityledger WHERE DAYOFMONTH(hotelmgtsystem.cityledger.`CreateTime`) BETWEEN 16 AND 31 AND hotelmgtsystem.cityledger.RefFolio =  hotelmgtsystem.guests.AccountId), 0) AS secondHalf
		
	FROM hotelmgtsystem.guests LEFT JOIN hotelmgtsystem.cityledger 
	ON hotelmgtsystem.guests.AccountId =  hotelmgtsystem.cityledger.AcctID
	where year(hotelmgtsystem.cityledger.CreateTime) = pYear
	GROUP BY `name`
	order by `month`
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelAnnualCustReceivable` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportFuelAnnualCustReceivable`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pYear INT
, pCustomerId varchar(30)
)
BEGIN
select 	`name`,
	MONTH(`date`) AS `date`,
	SUM(amount) AS amount
	
	from
	(SELECT CONCAT(hotelmgtsystem.guests.LastName, ', ', hotelmgtsystem.guests.FirstName) AS `name`,
		date(pumptransactions.CreatedDate) AS `date`,
		hotelmgtsystem.cityledger.Debit AS amount
	FROM pumptransactions INNER JOIN hotelmgtsystem.cityledger 
		ON pumptransactions.OrderDetailID = hotelmgtsystem.cityledger.RefNo 
		AND YEAR(pumptransactions.CreatedDate) = pYear
		INNER JOIN hotelmgtsystem.guests ON hotelmgtsystem.cityledger.AcctID = hotelmgtsystem.guests.AccountId
	WHERE fIsPumpPropertyOf(pLocationId, pPropertyId, pumptransactions.ItemID) = 1
	AND hotelmgtsystem.cityledger.AcctID = pCustomerId
	GROUP BY hotelmgtsystem.cityledger.RefNo) as temp
	GROUP BY MONTH(`date`)
	
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelAnnualPaymentToSupplier` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelAnnualPaymentToSupplier`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pYear varchar(10)
)
BEGIN
SELECT  inventory.grheader.grDate,
	inventory.grheader.purchaseNo,
	GROUP_CONCAT((SELECT pumps.FuelType FROM pumps WHERE pumps.ItemID = inventory.grdetails.itemID AND pumps.LocationID = 1 AND pumps.PropertyID = 1)) AS description,
	inventory.grheader.TotalAmount
  FROM  inventory.grheader right join inventory.grdetails on inventory.grheader.grID = inventory.grdetails.grID
	WHERE year(inventory.grheader.grDate) = pYear
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, inventory.grdetails.itemID) = 1
	group by inventory.grheader.purchaseNo; -- 1 means the transacted item belongs to current locationId and propertyId
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelAnnualPumpReading` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelAnnualPumpReading`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pYear int(10)
)
BEGIN
 SELECT MONTH(TransferFrom) AS `date`,
	PumpID,
	FuelType,
	fGetMonthPumpStartCountOfFirstShift(pLocationId, pPropertyId, PumpID, MONTH(TransferFrom), YEAR(TransferFrom) ) AS rStartCount,
	fGetMonthPumpEndCountOfLastShift(pLocationId, pPropertyId, PumpID, MONTH(TransferFrom), YEAR(TransferFrom)  ) AS rLastEndCount,
	SUM(lastEndCount - StartCount) AS rLiters,
	SUM((lastEndCount - StartCount) * Price) AS rTSales,
	SUM(DiscountPHP * DiscountedLiters) AS rTDAmount,
	SUM(DISTINCT InhouseAmount) AS rInhouseAmount,
	SUM(CashRemitted) AS rCashRemitted
FROM
(SELECT pumpreadings.TransferFrom,
	pumpreadings.ShiftID,
	pumpreadings.PumpID, 
	fGetFuelType(pLocationId, pPropertyId, pumpreadings.PumpID) AS FuelType,
	pumpreadings.StartCount,
	pumpreadings.EndCount AS lastEndCount,
	fGetCurShiftFuelSellingPrice(pLocationId, pPropertyId, pumpreadings.PumpID, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID) AS Price, 
	IFNULL(fGetFuelDiscountPerPump(pLocationId, pPropertyId, pumpreadings.PumpID, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID), 0) AS DiscountPHP,
	IFNULL(fGetDiscountedFuelLitersPerPump(pLocationId, pPropertyId, pumpreadings.PumpID, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID), 0) AS DiscountedLiters,
	IFNULL(fGetTotalInhouseAmount(pLocationId, pPropertyId, pumpreadings.PumpID, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID), 0) AS InhouseAmount,
	IFNULL(fGetCurCashRemmited(pLocationId, pPropertyId, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID), 0) AS CashRemitted
	FROM pumpreadings
	WHERE pumpreadings.LocationID = pLocationId
	AND pumpreadings.PropertyID = pPropertyId
	AND pumpreadings.`StartCount` != 0
	AND YEAR(pumpreadings.TransferFrom) = pYear
	) AS temp
	GROUP BY `date`, PumpID
	ORDER BY `date`, FuelType, PumpID	
;
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelAnnualPurchaseSummary` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelAnnualPurchaseSummary`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pYear VARCHAR(10)
)
BEGIN
SELECT 	inventory.grheader.grDate,
	inventory.grheader.purchaseNo,
	(SELECT pumps.FuelType FROM pumps WHERE pumps.ItemID = inventory.grdetails.itemID AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId) AS description,
	inventory.grdetails.quantity,
	inventory.grdetails.unitPrice
  FROM  inventory.grdetails LEFT JOIN inventory.grheader ON inventory.grdetails.grID = inventory.grheader.grID
	WHERE YEAR(inventory.grheader.grDate) = pYear
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, inventory.grdetails.itemID) = 1
	GROUP BY inventory.grdetails.grDetailId; -- 1 means the transacted item belongs to current locationId and propertyId
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelAnnualSalesSummary` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportFuelAnnualSalesSummary`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pYear int
)
BEGIN
SELECT 	pumptransactions.CreatedDate AS rDate,
	IFNULL(SUM(pumptransactions.Liters * pumptransactions.UnitPrice), 0) AS rAmount,
	IFNULL(SUM(IFNULL(pos.employee_ledger.debit, 0)) + ifnull(fGetCurFuelReceivable(pLocationId, pPropertyId, DATE(pumptransactions.CreatedDate)), 0), 0) AS rReceivable,
	IFNULL(SUM(pumptransactions.Liters * pumptransactions.UnitPrice * (pumptransactions.Discount / 100)), 0) AS rDiscount
		
	FROM pumptransactions LEFT JOIN pos.employee_ledger
	ON pumptransactions.OrderDetailID = pos.employee_ledger.ORDER_ID
	WHERE YEAR(pumptransactions.CreatedDate) = pYear
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, pumptransactions.ItemID) = 1
	GROUP BY DAY(pumptransactions.CreatedDate)
	
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelAnnualTankAnalysis` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportFuelAnnualTankAnalysis`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pYear varchar(10)
)
BEGIN
SELECT 	fGetTankName(pLocationId, pPropertyId, fuel) AS tankName,
	fuel,
	`date`,
	SUM(openingStock) AS rOStock,
	0.0 AS rReadingOStock,
	0.0 AS rTransactionOStock,
	SUM(delivery) AS rDelivery,
	SUM(readingSales) AS rReadingSales,
	SUM(transactionSales) AS rTransactionSales,
	0.0 as rEndReadingSales,
	0.0 as rEndTransactionSales
	FROM 
(select * 
	from
	(SELECT pumps.FuelType AS fuel,
		Month(itemledger.updatedAt) AS `date`,
		itemledger.beginningBalance AS openingStock,
		0 AS delivery,
		0 AS readingSales,
		0 AS transactionSales
			FROM pumps LEFT JOIN itemledger ON pumps.ItemID = itemledger.itemId AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId
			WHERE DATE(itemledger.updatedAt) LIKE CONCAT(pYear, '-', '%', '-', '01')
			AND itemledger.moduleName != 'Goods Receipt'
			AND itemledger.moduleName != 'Inventory - Restock'
			ORDER BY itemledger.createdAt ASC -- ordered so that when applied with group, beginning balance will have the value of the oldest transaction
			) AS tempTbl GROUP BY fuel, `date`
UNION ALL
SELECT 	pumps.FuelType AS fuel,
	month(itemledger.updatedAt) AS `date`,
	IF(fHasTransBforStocking(pLocationId, pPropertyId, pumps.FuelType, itemledger.ledgerId, DATE(itemledger.updatedAt)) = 0  AND DAY(DATE(itemledger.updatedAt)) = 1 , -SUM(itemledger.quantity), 0) AS openingStock, -- This will be added to above value to avoid doubled value if Goods Receipts falls on the 1st day of the month.
	itemledger.quantity AS delivery,
	0 AS readingSales,
	0 AS transactionSales
		FROM pumps LEFT JOIN itemledger ON pumps.ItemID = itemledger.itemId AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId
		WHERE itemledger.moduleName IN ('Goods Receipt', 'Inventory - Restock')
		AND YEAR(itemledger.updatedAt) = pYear
		GROUP BY pumps.FuelType, `date`
UNION ALL	
SELECT  fGetFuelType(pLocationId, pPropertyId, pumpreadings.PumpID) AS fuel,
	month(transferto) AS `date`,
	0 AS openingStock,
	0 AS delivery,
	SUM(totalliters) AS readingSales,
	0 AS transactionSales	
		FROM pumpreadings 
		WHERE YEAR(transferto) = pYear
		AND pumpreadings.LocationId = pLocationId
		AND pumpreadings.PropertyId = pPropertyId
		GROUP BY fuel, `date`
UNION ALL
		
SELECT 	pumps.FuelType as fuel,
	month(pumptransactions.CreatedDate) AS `date`,
	0 AS openingStock,
	0 AS delivery,
	0 AS readingSales,
	SUM(Liters) AS transactionSales		
		FROM pumptransactions LEFT JOIN pumps ON pumptransactions.ItemID = pumps.ItemID AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId
		where YEAR(pumptransactions.CreatedDate) = pYear
		GROUP BY pumps.FuelType, `date`) AS temp
		GROUP BY `date`, fuel
		ORDER BY fuel, `date`		
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelCashierShiftTransactions` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelCashierShiftTransactions`(
in pterminalid int(4),
in prestaurantid int(5),
in pshiftcode int(5),
in pTransactiondate date
)
BEGIN
select 
concat(cashiers_logs.terminalid) as Terminal,
cashiers_logs.cashierid,
cashiers_logs.shiftcode,
cashiers_logs.transactiondate,
cashiers_logs.openingbalance,
cashiers_logs.openingadjustment,
cashiers_logs.beginningbalance,
cashiers_logs.cash,
cashiers_logs.creditcard,
ifnull((select sum(amount) from pos.payment where shift_code=pShiftCode and terminal_id=pTerminalID and date(payment_Date)=pTransactionDate and `status`!='VOID' and payment_type = 'ACCOUNT_NONSTAY'),0) as chargeinguestamount,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.remarks,
cashiers_logs.amountremitted,
cashiers_logs.createdby,
fGetSalesDiscount(pTransactiondate, pshiftcode) as others -- others is used as discount
from
pos.cashiers_logs
where
cashiers_logs.terminalid = pterminalid and
cashiers_logs.restaurantid = prestaurantid and
cashiers_logs.shiftcode=pshiftcode and
cashiers_logs.type='CLOSE' and
cashiers_logs.transactiondate=pTransactionDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelDailyInhouseTransaction` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelDailyInhouseTransaction`(
pDate DATE
)
BEGIN
 /*SELECT pumptransactions.OrderDetailID,
	fGetFuelType(pLocationId, pPropertyId,pumptransactions.PumpID) AS FuelType,
	CONCAT(pos.employee.FIRSTNAME, ' ', pos.employee.LASTNAME) AS CompanyName,
	pumptransactions.Liters,
	pumptransactions.UnitPrice,
	employee_ledger.debit AS rInhouseAmount
	FROM pos.employee_ledger 
	INNER JOIN pumptransactions 
	ON pos.employee_ledger.ORDER_ID = pumptransactions.OrderDetailID 
	AND pos.employee_ledger.Date = pDate 
	INNER JOIN pos.employee ON pos.employee_ledger.EMPLOYEE_ID = pos.employee.EMPLOYEE_ID
	WHERE fIsPumpPropertyOf(pLocationId, pPropertyId,pumptransactions.ItemID) = 1;*/
	
select  fGetItemDescription(d.itemid) as DESCRIPTION,
	concat(lastname, ',', firstname) as company, 
	sum(d.liters) AS LITERS, 
	sum(h.total_amount) as amount
	
	-- from pos.`order detail` d
	-- left join pos.`order header` h on h.order_id = d.order_id
	
	FROM pumptransactions d
	INNER JOIN pos.`order header` h ON d.orderdetailid = h.order_id
	left join hotelmgtsystem.guests g on g.accountid = h.customer_id
	where h.status = 'SERVED '-- operation_status = 'NEW' 
	and customer_id != 'WALK-IN' 
	and date(h.order_date) = pDate
	group by   DESCRIPTION, h.customer_id;
	
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelDailyPaymentToSupplier` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelDailyPaymentToSupplier`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pMonth int
, pYear int
)
BEGIN
SELECT  DATE(inventory.grheader.grDate) AS grDate,
	inventory.grheader.purchaseNo,
	GROUP_CONCAT((SELECT pumps.FuelType FROM pumps WHERE pumps.ItemID = inventory.grdetails.itemID AND pumps.LocationID = 1 AND pumps.PropertyID = 1)) AS description,
	inventory.grheader.TotalAmount
  FROM  inventory.grheader right join inventory.grdetails on inventory.grheader.grID = inventory.grdetails.grID
	WHERE MONTH(inventory.grheader.grDate) = pMonth
	AND YEAR(inventory.grheader.grDate) = pYear
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, inventory.grdetails.itemID) = 1
	group by inventory.grheader.purchaseNo; -- 1 means the transacted item belongs to current locationId and propertyId
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelDailyPumpReading` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelDailyPumpReading`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pDate date
)
BEGIN
 /*SELECT pumpreadings.ShiftID,
	pumpreadings.PumpID, 
	fGetFuelType(pLocationId, pPropertyId, pumpreadings.PumpID) AS FuelType,
	pumpreadings.StartCount,
	pumpreadings.EndCount AS lastEndCount,
	fGetCurShiftFuelSellingPrice(pLocationId, pPropertyId, pumpreadings.PumpID, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID) AS Price, 
	ifNULL(fGetFuelDiscountPerPump(pLocationId, pPropertyId, pumpreadings.PumpID, pDate, pumpreadings.ShiftID), 0) as DiscountPHP,
	IFNULL(fGetDiscountedFuelLitersPerPump(pLocationId, pPropertyId, pumpreadings.PumpID, pDate, pumpreadings.ShiftID), 0) as DiscountedLiters,
	IFNULL(fGetTotalInhouseAmount(pLocationId, pPropertyId, pumpreadings.PumpID, pDate, pumpreadings.ShiftID), 0) as InhouseAmount,
	IFNULL(fGetCurCashRemmited(pLocationId, pPropertyId, pDate, pumpreadings.ShiftID), 0) as CashRemitted
	
	FROM pumpreadings
	WHERE pumpreadings.LocationID = pLocationId
	AND pumpreadings.PropertyID = pLocationId
	AND DATE(pumpreadings.TransferFrom) = pDate
	and pumpreadings.StartCount != 0 */
	
SELECT 	i.description,
	MAX(p.pumpid) AS pumpid, 
	MIN(p.startcount) AS beginning, 
	MAX(p.endcount) AS final,
	SUM(p.totalliters) AS issues, 
	uprice, 
	(uprice * SUM(p.totalliters - IFNULL((SELECT calibrationliter  FROM calibration c WHERE c.shiftid = p.shiftid AND DATE(c.datecreated) = DATE(p.transferfrom) AND c.pumpid = p.PumpID),0))) AS total
	
	FROM pumpreadings p
	LEFT JOIN items i ON i.groupId = p.PumpID
	WHERE DATE(p.transferfrom) = pDate AND -- i.description = 'DIESEL'
	p.LocationID = pLocationId
	AND p.PropertyID = pLocationId
	group BY p.pumpid, uprice
	
	;
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelDailyPumpReadingByShift` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelDailyPumpReadingByShift`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pDate date
, pShiftId varchar(10)
)
BEGIN
select ShiftID, PumpID, FuelType, round(SellingPrice,2) as SellingPrice, StartCount, EndCount, TotalLiters, round((SellingPrice * TotalLiters),2) as TotalAmount
from
(
 SELECT pumpreadings.ShiftID,
	pumpreadings.PumpID, 
	fGetFuelType(pLocationId, pPropertyId, pumpreadings.PumpID) AS FuelType,
	-- if(instr((select `VALUE` from pos.`system_config` where `KEY` = 'FOR_GASOLINE_LISTOFDISC_PUMP'),pumpreadings.PumpID), fGetSellingPrice(itemid, pPropertyId) - (select Cost from pos.`function mapping` where function_id = 'F18'),fGetSellingPrice(itemid, pPropertyId)) as SellingPrice,
	pumpreadings.uprice as SellingPrice,
	pumpreadings.StartCount,
	pumpreadings.EndCount,
	
	-- pumpreadings.TotalLiters
	(pumpreadings.TotalLiters - IFNULL((SELECT calibrationliter  FROM calibration c WHERE c.shiftid = pumpreadings.shiftid AND DATE(c.datecreated) = DATE(pumpreadings.transferfrom) AND c.pumpid = pumpreadings.PumpID),0)) as Totalliters -- less Calibration
	
FROM pumpreadings
left join pumps
on pumpreadings.`PumpID` = pumps.`PumpID`
WHERE pumpreadings.LocationID = pLocationId
AND pumpreadings.PropertyID = pLocationId
AND DATE(pumpreadings.TransferFrom) = pDate
AND pumpreadings.ShiftID = pShiftId
) as dtl
;	
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelDailyPurchaseSummary` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelDailyPurchaseSummary`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pMonth INT
, pYear INT
)
BEGIN
SELECT  inventory.grheader.grDate,
	inventory.grheader.purchaseNo,
	(SELECT pumps.FuelType FROM pumps WHERE pumps.ItemID = inventory.grdetails.itemID AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId) AS description,
	inventory.grdetails.quantity,
	inventory.grdetails.unitPrice
  FROM  inventory.grdetails LEFT JOIN inventory.grheader ON inventory.grdetails.grID = inventory.grheader.grID
	WHERE MONTH(inventory.grheader.grDate) = pMonth
	AND YEAR(inventory.grheader.grDate) = pYear
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, inventory.grdetails.itemID) = 1
	GROUP BY inventory.grdetails.grDetailId; -- 1 means the transacted item belongs to current locationId and propertyId
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelDailySalesByPump` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelDailySalesByPump`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pDate date
)
BEGIN
 SELECT pumps.PumpID,
	pumps.FuelType,
	pumptransactions.Liters,
	pumptransactions.UnitPrice,
	pumptransactions.amount
	
  FROM 	pumps 
	LEFT JOIN pumptransactions ON pumps.ItemID = pumptransactions.ItemID 
	WHERE pumps.LocationID = pLocationId 
	AND pumps.PropertyID = pPropertyId 
	AND Date(`createdDate`) = pDate
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, pumptransactions.ItemID) = 1; -- 1 means the transacted item belongs to current locationId and propertyId
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelDailySalesSummary` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportFuelDailySalesSummary`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pMonth int
, pYear int
)
BEGIN
SELECT 	DATE(pumptransactions.CreatedDate) AS rDate,
	SUM(pumptransactions.Liters * pumptransactions.UnitPrice) AS rAmount,
	SUM(ifnull(pos.employee_ledger.debit, 0)) AS rReceivable,
	SUM(pumptransactions.Liters * pumptransactions.UnitPrice * (pumptransactions.Discount / 100)) AS rDiscount,
	IFNULL(fGetCurFuelReceivable(pLocationId, pPropertyId, DATE(pumptransactions.CreatedDate)), 0) as rAcctReceivable
		
	FROM pumptransactions LEFT JOIN pos.employee_ledger
	ON pumptransactions.OrderDetailID = pos.employee_ledger.ORDER_ID
	WHERE MONTH(pumptransactions.CreatedDate) = pMonth
	AND YEAR(pumptransactions.CreatedDate) = pYear
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, pumptransactions.ItemID) = 1
	GROUP BY DAY(pumptransactions.CreatedDate)
	ORDER BY rDate
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelDiscount` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelDiscount`(
pDate DATE
)
BEGIN
 /*select FuelType,
	pumpid, 
	disc_php, 
	sum(qty) as liters, 
	sum(discount) as amount
	from (
	select 
	FuelType,
	p.pumpid, 
	od.qty , -- p.liters, 
	-- floor(liters),  
	discountRate as disc_php, -- discount/floor(liters) as disc_php, 
	round(od.qty * discountRate, 2) as discount
	
	from pumptransactions p
	left join pumps on pumps.PumpID = p.PumpID
	left join pos.`order_detail_discqty` od
	on p.OrderDetailID = od.orderid
	where discountRate > 0 
	and date(p.CreatedDate) = pDate
	) sql1 group by pumpid, disc_php*/
	
	SELECT 
	p.FuelType,
	p.pumpid, 
	(SELECT cost FROM pos.`function mapping` pf WHERE pf.function_id = 'F18' ) AS disc_php,
	SUM(pr.totalliters) AS totalliters,
	SUM(((SELECT cost FROM pos.`function mapping` pf WHERE pf.function_id = 'F18' ) * pr.totalliters)) AS amount
	
	FROM pumpreadings pr
	INNER JOIN pumps p
	ON pr.PumpID = p.PumpId
	AND DATE(pr.TransferFrom) = pDate
	AND INSTR((SELECT `VALUE` FROM pos.`system_config` WHERE `KEY` = 'FOR_GASOLINE_LISTOFDISC_PUMP'),pr.PumpID)
	GROUP BY pr.pumpid;	
	
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelMonthlyAcctReceivable` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportFuelMonthlyAcctReceivable`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pMonth int
, pYear int
)
BEGIN
SELECT  CONCAT(hotelmgtsystem.guests.LastName, ', ', hotelmgtsystem.guests.FirstName) AS `name`,
	IFNULL(MONTHNAME(DATE(hotelmgtsystem.cityledger.CreateTime)), '') AS `month`,
	IFNULL((SELECT SUM(hotelmgtsystem.cityledger.debit) FROM hotelmgtsystem.cityledger WHERE DAYOFMONTH(hotelmgtsystem.cityledger.`CreateTime`) BETWEEN 1 AND 15 AND hotelmgtsystem.cityledger.RefFolio = hotelmgtsystem.guests.AccountId), 0) AS firstHalf,
	IFNULL((SELECT SUM(hotelmgtsystem.cityledger.debit) FROM hotelmgtsystem.cityledger WHERE DAYOFMONTH(hotelmgtsystem.cityledger.`CreateTime`) BETWEEN 16 AND 31 AND hotelmgtsystem.cityledger.RefFolio =  hotelmgtsystem.guests.AccountId), 0) AS secondHalf
		
	FROM hotelmgtsystem.guests LEFT JOIN hotelmgtsystem.cityledger 
	ON hotelmgtsystem.guests.AccountId =  hotelmgtsystem.cityledger.AcctID
	where month(hotelmgtsystem.cityledger.CreateTime) = pMonth
	and year(hotelmgtsystem.cityledger.CreateTime) = pYear
	GROUP BY `name`
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelMonthlyCustReceivable` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportFuelMonthlyCustReceivable`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pMonth INT
, pYear INT
, pCustomerId varchar(30)
)
BEGIN
SELECT  CONCAT(hotelmgtsystem.guests.LastName, ', ', hotelmgtsystem.guests.FirstName) AS `name`,
	date(pumptransactions.CreatedDate) AS `date`,
	hotelmgtsystem.cityledger.Debit AS amount
	FROM pumptransactions INNER JOIN hotelmgtsystem.cityledger 
		ON pumptransactions.OrderDetailID = hotelmgtsystem.cityledger.RefNo 
		AND MONTH(pumptransactions.CreatedDate) = pMonth
		AND YEAR(pumptransactions.CreatedDate) = pYear
		INNER JOIN hotelmgtsystem.guests ON hotelmgtsystem.cityledger.AcctID = hotelmgtsystem.guests.AccountId
	WHERE fIsPumpPropertyOf(pLocationId, pPropertyId, pumptransactions.ItemID) = 1
	AND hotelmgtsystem.cityledger.AcctID = pCustomerId
	GROUP BY hotelmgtsystem.cityledger.RefNo
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelMonthlyPumpReading` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelMonthlyPumpReading`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pDate DATE
)
BEGIN
 /*SELECT DATE(TransferFrom) AS `date`,
	PumpID,
	FuelType,
	fGetPumpStartCountOfFirstShift(pLocationId, pPropertyId, PumpID, fGetFirstShiftOfTheDay(pLocationId, pPropertyId, DATE(TransferFrom)), DATE(TransferFrom)) AS rStartCount,
	fGetPumpEndCountOfLastShift(pLocationId, pPropertyId, PumpID, fGetEndShiftOfTheDay(pLocationId, pPropertyId, DATE(TransferFrom)) , DATE(TransferFrom)) AS rLastEndCount,
	SUM(lastEndCount - StartCount) AS rLiters,
	SUM((lastEndCount - StartCount) * Price) AS rTSales,
	SUM(DiscountPHP * DiscountedLiters) AS rTDAmount,
	SUM(DISTINCT InhouseAmount) AS rInhouseAmount,
	SUM(CashRemitted) AS rCashRemitted
FROM
(SELECT pumpreadings.TransferFrom,
	pumpreadings.ShiftID,
	pumpreadings.PumpID, 
	fGetFuelType(1, 1, pumpreadings.PumpID) AS FuelType,
	pumpreadings.StartCount,
	pumpreadings.EndCount AS lastEndCount,
	fGetCurShiftFuelSellingPrice(pLocationId, pPropertyId, pumpreadings.PumpID, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID) AS Price, 
	IFNULL(fGetFuelDiscountPerPump(pLocationId, pPropertyId, pumpreadings.PumpID, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID), 0) AS DiscountPHP,
	IFNULL(fGetDiscountedFuelLitersPerPump(pLocationId, pPropertyId, pumpreadings.PumpID, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID), 0) AS DiscountedLiters,
	IFNULL(fGetTotalInhouseAmount(pLocationId, pPropertyId, pumpreadings.PumpID, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID), 0) AS InhouseAmount,
	IFNULL(fGetCurCashRemmited(pLocationId, pPropertyId, DATE(pumpreadings.TransferFrom), pumpreadings.ShiftID), 0) AS CashRemitted
	FROM pumpreadings
	WHERE pumpreadings.LocationID = pLocationId
	AND pumpreadings.PropertyID = pPropertyId
	and pumpreadings.`StartCount` != 0
	AND DATE_FORMAT(pumpreadings.TransferFrom, "%Y-%m") = CONCAT(pYear, '-', IF(LENGTH(pMonth) = 1, CONCAT('0', pMonth), pMonth))
	) AS temp
	GROUP BY `date`, PumpID
	ORDER BY `date`, FuelType, PumpID */
	
SELECT sql1.* ,
IF(sql1.sales = 0, 0, (sql1.sales - sql1.onAccount - sql1.discount )) AS total,
cRemitted - IF(sql1.sales = 0, 0, (sql1.sales - sql1.onAccount - sql1.discount)) AS cashOverrage
FROM
(SELECT  cl.`shiftcode` AS shiftid, 
        cl.`transactiondate` AS `date` ,  
        -- (SELECT IFNULL(SUM((totalliters - ) * uprice), 0) AS sales FROM pumpreadings p WHERE p.ShiftID = cl.`shiftcode` AND DATE(TransferFrom) = cl.`transactiondate` AND p.startcount != 0) - AS sales,
        fGetFuelSales(cl.`transactiondate`, cl.`shiftcode`) as sales,
	-- (SELECT IFNULL(SUM(d.qty * d.discountRate), 0) AS disc FROM pos.`order_detail_discqty` d INNER JOIN pos.`order header` h ON  d.orderid = h.order_id  AND d.discountrate > 0 WHERE shift_code = cl.`shiftcode` AND DATE(h.order_date) = cl.`transactiondate` AND h.status = 'SERVED') AS discount,
	fGetSalesDiscount(cl.`transactiondate`, cl.`shiftcode`) as discount,
        (SELECT IFNULL(SUM(c.debit),0) FROM hotelmgtsystem.`cityledger` c INNER JOIN pos.`order header` h ON c.refno = h.order_id AND h.status = 'SERVED' WHERE shift_code = cl.`shiftcode` AND DATE(h.order_date) = cl.`transactiondate`) AS onAccount,
        cl.`amountremitted` AS cRemitted
        	
FROM pos.`cashiers_logs` cl
WHERE cl.`type` = 'CLOSE'
AND DATE_FORMAT(cl.`transactiondate`, "%Y-%m") = DATE_FORMAT(pDate, "%Y-%m")) AS sql1
	
	
;
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelMonthlyTankAnalysis` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportFuelMonthlyTankAnalysis`(
  pLocationId varchar(30)
, pPropertyId varchar(30)
, pMonth varchar(3)
, pYear varchar(10)
)
BEGIN
SELECT 	fGetTankName(pLocationId, pPropertyId, fuel) as tankName,
	fuel,
	`date`,
	SUM(openingStock) AS rOStock,
	0.0 as rReadingOStock,
	0.0 as rTransactionOStock,
	SUM(delivery) AS rDelivery,
	SUM(readingSales) AS rReadingSales,
	SUM(transactionSales) AS rTransactionSales,
	0.0 as rEndReadingSales,
	0.0 as rEndTransactionSales
	FROM 
(select * 
	from
	(SELECT pumps.FuelType AS fuel,
		DATE(itemledger.updatedAt) AS `date`,
		itemledger.beginningBalance AS openingStock,
		0 AS delivery,
		0 AS readingSales,
		0 AS transactionSales
			FROM pumps LEFT JOIN itemledger ON pumps.ItemID = itemledger.itemId AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId
			WHERE DATE(itemledger.updatedAt) = CONCAT(pYear, '-', IF(LENGTH(pMonth) = 1, CONCAT('0', pMonth), pMonth), '-01')
			and itemledger.moduleName != 'Goods Receipt'
			and itemledger.moduleName != 'Inventory - Restock'
			ORDER BY itemledger.createdAt ASC -- ordered so that when applied with group, beginning balance will have the value of the oldest transaction
			) AS tempTbl GROUP BY fuel, `date`
UNION ALL
SELECT 	pumps.FuelType AS fuel,
	DATE(itemledger.updatedAt) AS `date`,
	IF(fHasTransBforStocking(pLocationId, pPropertyId, pumps.FuelType, itemledger.ledgerId, DATE(itemledger.updatedAt)) = 0  AND DAY(DATE(itemledger.updatedAt)) = 1 , -SUM(itemledger.quantity), 0) AS openingStock, -- This will be added to above value to avoid doubled value if Goods Receipts falls on the 1st day of the month.
	sum(itemledger.quantity) AS delivery,
	0 AS readingSales,
	0 AS transactionSales
		FROM pumps LEFT JOIN itemledger ON pumps.ItemID = itemledger.itemId AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId
		WHERE itemledger.moduleName in ('Goods Receipt', 'Inventory - Restock')
		AND DATE_FORMAT(itemledger.updatedAt, "%Y-%m") =  CONCAT(pYear, '-', IF(LENGTH(pMonth) = 1, CONCAT('0', pMonth), pMonth))
		GROUP BY pumps.FuelType,`date`
UNION ALL	
SELECT  fGetFuelType(pLocationId, pPropertyId, pumpreadings.PumpID) AS fuel,
	DATE(transferfrom) AS `date`,
	0 AS openingStock,
	0 AS delivery,
	SUM(totalliters) AS readingSales,
	0 AS transactionSales	
		FROM pumpreadings 
		WHERE DATE_FORMAT(transferfrom, "%Y-%m") = CONCAT(pYear, '-', IF(LENGTH(pMonth) = 1, CONCAT('0', pMonth), pMonth))
		AND pumpreadings.LocationId = pLocationId
		AND pumpreadings.PropertyId = pPropertyId
		GROUP BY fuel,`date`
UNION ALL
		
SELECT 	pumps.FuelType as fuel,
	DATE(pumptransactions.CreatedDate) AS `date`,
	0 AS openingStock,
	0 AS delivery,
	0 AS readingSales,
	SUM(Liters) AS transactionSales		
		FROM pumptransactions LEFT JOIN pumps ON pumptransactions.ItemID = pumps.ItemID AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId
		where DATE_FORMAT(pumptransactions.CreatedDate, "%Y-%m") = CONCAT(pYear, '-', IF(LENGTH(pMonth) = 1, CONCAT('0', pMonth), pMonth))
		GROUP BY pumps.FuelType,`date`) AS temp
		GROUP BY `date`, fuel
		ORDER BY fuel, `date`		
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelPaymentToSupplier` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelPaymentToSupplier`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pDate date
)
BEGIN
SELECT  inventory.grheader.grDate,
	inventory.grheader.purchaseNo,
	GROUP_CONCAT((SELECT pumps.FuelType FROM pumps WHERE pumps.ItemID = inventory.grdetails.itemID AND pumps.LocationID = 1 AND pumps.PropertyID = 1)) AS description,
	inventory.grheader.TotalAmount
  FROM  inventory.grheader right join inventory.grdetails on inventory.grheader.grID = inventory.grdetails.grID
	WHERE date(inventory.grheader.grDate) = pDate
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, inventory.grdetails.itemID) = 1
	group by inventory.grheader.purchaseNo; -- 1 means the transacted item belongs to current locationId and propertyId
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFuelPurchaseSummary` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFuelPurchaseSummary`(
  pLocationId VARCHAR(30)
, pPropertyId VARCHAR(30)
, pDate DATE
)
BEGIN
SELECT 	inventory.grheader.grDate,
	inventory.grheader.purchaseNo,
	(SELECT pumps.FuelType FROM pumps WHERE pumps.ItemID = inventory.grdetails.itemID AND pumps.LocationID = pLocationId AND pumps.PropertyID = pPropertyId) AS description,
	inventory.grdetails.quantity,
	inventory.grdetails.unitPrice
  FROM  inventory.grdetails LEFT JOIN inventory.grheader ON inventory.grdetails.grID = inventory.grheader.grID
	WHERE DATE(inventory.grheader.grDate) = pDate
	AND fIsPumpPropertyOf(pLocationId, pPropertyId, inventory.grdetails.itemID) = 1
	GROUP BY inventory.grdetails.grDetailId; -- 1 means the transacted item belongs to current locationId and propertyId
  END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportGoodsReceipt` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportGoodsReceipt`(
PROPERTYID VARCHAR(30),
LOCATIONID VARCHAR(30),
DATE1 DATE,
DATE2 DATE,
PERIOD VARCHAR(30),
INVACTION VARCHAR(30),
INVMODULENAME VARCHAR(30)
)
BEGIN
SELECT  items.itemId,
	items.description,
	items.unitCost,
	sum(itemledger.quantity) AS TotalQty,
	sum(items.unitCost * itemledger.quantity) AS TotalCost,
	itemledger.moduleName,
	itemledger.inventoryAction AS `Action`
FROM 	items 
	LEFT JOIN itemledger ON items.itemId = itemledger.itemId
	LEFT JOIN itemlocations ON items.itemId = itemlocations.itemId
WHERE   itemledger.quantity IS NOT NULL
AND 	itemledger.inventoryAction = INVACTION
AND 	itemledger.moduleName like INVMODULENAME
AND	itemledger.locationId = itemlocations.locationId
AND	itemlocations.locationId = LOCATIONID
AND	itemlocations.propertyId = itemledger.propertyId
AND	itemlocations.propertyId = PROPERTYID 
AND 	IF(PERIOD = 'MONTHLY', MONTH(itemledger.createdAt) = MONTH(DATE1) AND YEAR(itemledger.createdAt) = YEAR(DATE1),
            IF(PERIOD = 'DAILY', DATE(itemledger.createdAt) = DATE(DATE1), 
                 IF(PERIOD = 'YEARLY', YEAR(itemledger.createdAt) = YEAR(DATE1),
                     IF(PERIOD = 'RANGE', DATE(itemledger.createdAt) >= DATE(DATE1) AND DATE(itemledger.createdAt) <= DATE(DATE2), 0)
	           )
	      )
          )
GROUP BY items.itemId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportItemInventory` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportItemInventory`(
pPropertyId VARCHAR(30),
pLocationId VARCHAR(30),
pTransactionDate DATETIME,
pTransactionDateEnd DATETIME,
pPeriod VARCHAR(30)
)
BEGIN
select  itemledger.propertyId,
	itemledger.locationId,
	itemledger.itemId,
	itemledger.beginningBalance,
	itemledger.moduleName,
	itemledger.quantity,
	itemledger.inventoryAction,
	itemledger.endingBalance,
	itemledger.createdBy,
	items.description,
	items.unitCost,
	items.sellingPrice
from 
	itemledger left join items on items.itemId = itemledger.itemId
where
	itemledger.locationId = pLocationId and
        itemledger.propertyId = pPropertyId and
	IF(pPeriod = 'MONTHLY', MONTH(itemledger.createdAt) = MONTH(pTransactionDate) AND YEAR(itemledger.createdAt) = YEAR(pTransactionDate),
            IF(pPeriod = 'DAILY', DATE(itemledger.createdAt) = DATE(pTransactionDate), 
                 IF(pPeriod = 'YEARLY', YEAR(itemledger.createdAt) = YEAR(pTransactionDate),
                     IF(pPeriod = 'RANGE', DATE(itemledger.createdAt) >= DATE(pTransactionDate) AND DATE(itemledger.createdAt) <= DATE(pTransactionDateEnd), 0)
	           )
	      )
          );
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportItemInventoryPerShift` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportItemInventoryPerShift`(
pPropertyId VARCHAR(30),
pLocationId VARCHAR(30),
pShiftCode VARCHAR(10),
pTransactionDate DATETIME
)
BEGIN
Select 	mLedger.itemid,
	mLedger.beginningbalance,
	mLedger.endingbalance,
	mLedger.propertyId,
        mLedger.locationId,
        mLedger.moduleName,
        mLedger.quantity,
        mLedger.inventoryAction,
        items.groupId,
	items.description,
        items.unitCost,
        items.sellingPrice,
	mLedger.createdBy
from    itemledger mLedger left join items on items.itemId = mLedger.itemId
where   mLedger.locationId = pLocationId and
        mLedger.propertyId = pPropertyId and
	DATE(mledger.createdAt) = DATE(pTransactionDate) and time(mledger.createdAt) BETWEEN
	(Select time(pos.cashiers_logs.CREATETIME) from pos.cashiers_logs
        where pos.cashiers_logs.shiftcode = pShiftCode and 
        pos.cashiers_logs.transactiondate = DATE(pTransactionDate) and
        pos.cashiers_logs.type = 'OPEN') and 
        (Select time(pos.cashiers_logs.CREATETIME) from pos.cashiers_logs
        where pos.cashiers_logs.shiftcode = pShiftCode and 
        pos.cashiers_logs.transactiondate = DATE(pTransactionDate) and
        pos.cashiers_logs.type = 'CLOSE');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportSummarizedFuelCharges` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportSummarizedFuelCharges`(in pStartDate date, in pEndDate date)
BEGIN
SELECT
  `order header`.order_date,
  `order header`.order_id,
  IF(`order header`.employee_id != '', pos.fGetEmployeeName(`order header`.employee_id), 
	(SELECT CONCAT(firstname, ' ', lastname) FROM hotelmgtsystem.guests WHERE accountid = `order header`.customer_id)) AS CustomerName,
  IF(`order header`.employee_id='', `order header`.customer_id, `order header`.employee_id) AS customer_id,
  TOTAL_DISCOUNT,
  vat_sales,
  vat_amount,
  total_amount + TOTAL_DISCOUNT as total_amount
FROM pos.`order header`
  INNER JOIN
  pos.payment
  ON `order header`.order_id = payment.order_id
WHERE payment.status <> 'VOID'
    AND payment.PAYMENT_TYPE LIKE 'ACCOUNT%'
    AND (DATE(`order header`.ORDER_DATE) >= pStartDate
         AND DATE(`order header`.ORDER_DATE) <= pEndDate);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportSummarizedFuelSalesByItemGroup` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportSummarizedFuelSalesByItemGroup`(
IN pStartDate DATE,
IN pEndDate DATE,
IN pRestoID INT(5)
)
BEGIN
SET SQL_BIG_SELECTS=1;
SELECT
  0 AS id,
  SUM(dtl.QUANTITY) AS QUANTITY,
  itm.`unitCost`   AS unit_cost,
  dtl.`UNIT_PRICE` AS selling_price,
  (SUM(dtl.QUANTITY * itm.unitCost)) AS COST,
  (SUM(dtl.QUANTITY * dtl.unit_price)) AS SALES,
  itm.description,
  itm.groupId      AS group_id,
  grp.mainGroupId  AS maingroup_id,
  pos.fGetTotalDiscountPerItem(pStartDate,pEndDate, itm.itemId) AS discountItem,
  pos.fGetTotalDiscount(pStartDate,pEndDate) AS discount,
  IFNULL(fGetTotalFuelCharges(pStartDate,pEndDate), 0.00) AS account_charges
FROM pos.`order detail` dtl
  LEFT JOIN pos.`order header` hdr
    ON dtl.`ORDER_ID` = hdr.`ORDER_ID`
  RIGHT JOIN `items` itm
    ON dtl.`ITEM_ID` = itm.`itemId`
  LEFT JOIN `itemgroups` grp
    ON itm.`groupId` = grp.`groupId`
WHERE (hdr.ORDER_DATE >= pStartDate
       AND hdr.ORDER_DATE <= pEndDate)
    AND dtl.operation_status != 'CANCELLED'
    AND grp.locationId = pRestoID
GROUP BY itm.`itemId`
ORDER BY hdr.order_date;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spResetFuelTrans` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spResetFuelTrans`()
BEGIN
truncate fuelmaingrouptracker;
truncate fueltype;
truncate itemgroups;
truncate itemledger;
truncate itemlocations;
truncate items;
truncate maingroups;
truncate pricehistory;
truncate pumpreadings;
truncate pumps;
truncate pumptransactions;
truncate supplieditems;
truncate supplier;
truncate tanks;
truncate shiftingdate;
truncate locations;
DELETE FROM inventory.wrheaders;
DELETE FROM inventory.wrdetails;
DELETE FROM inventory.itdetails;
DELETE FROM inventory.itheaders;
DELETE FROM inventory.itrdetails;
DELETE FROM inventory.itrheaders;
DELETE FROM inventory.unsettledinventory;
DELETE FROM inventory.grdetails;
DELETE FROM inventory.grheader;
DELETE FROM inventory.datecodes;
DELETE FROM inventory.serialnumbers;
DELETE FROM inventory.lotnumbers;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spResetInventoryTransaction` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spResetInventoryTransaction`()
BEGIN
DELETE FROM inventory.wrheaders;
DELETE FROM inventory.wrdetails;
DELETE FROM inventory.itdetails;
DELETE FROM inventory.itheaders;
DELETE FROM inventory.itrdetails;
DELETE FROM inventory.itrheaders;
DELETE FROM inventory.unsettledinventory;
DELETE FROM inventory.grdetails;
DELETE FROM inventory.grheader;
DELETE FROM inventory.datecodes;
DELETE FROM inventory.serialnumbers;
DELETE FROM inventory.lotnumbers;
DELETE FROM itemledger;
Delete from items;
Delete from itemgroups;
Delete from itemlocations;
Delete from itemledger;
UPDATE itemlocations set itemlocations.quantity = 0;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spRestockITemAtLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spRestockITemAtLocation`(
   pItemId varchar(30)
 , pQty double(12,2)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
UPDATE
     itemlocations
SET
     quantity = quantity + pQty
   , updatedBy = pUser
   , updatedAt = now()
WHERE propertyId = pPropertyId
AND locationId =  pLocationId
AND `status` = 'Active'
AND itemId = pItemId;
/*
	-- Gene 06/27/2012
	if (ROW_COUNT() > 0) then
		select 
		itemlocations.quantity 
		from itemlocations 
		where itemlocations.itemId = pItemId 
		and itemlocations.locationId = pLocationId 
		and itemlocations.propertyId = pPropertyId
		and itemlocations.status = 'Active';
	else
		select 'NONE' from dual;
	end if;
	-- >>
*/
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spRestockTanks` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spRestockTanks`(
pItemID varchar(30),
pQtyByLiters decimal(12,2),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
update tanks set tanks.Qty=pQtyByLiters where 
tanks.TankID=(select pumps.TankID from pumps where pumps.ItemID=pItemID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReturnGroupIDinItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReturnGroupIDinItem`(pItemID varchar(30))
BEGIN
select groupid from items where itemid=pItemID and `status`='Active';
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReturnItemsAtLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReturnItemsAtLocation`(
   pItemId varchar(30)
 , pQty double(12,2)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
UPDATE  itemlocations
SET	itemlocations.quantity = quantity + pQty,
	itemlocations.updatedBy = pUser,
	itemlocations.updatedAt = now()
	WHERE 
        itemlocations.propertyId = pPropertyId
	AND itemlocations.locationId =  pLocationId
	AND itemlocations.status = 'Active'
	AND itemlocations.itemId = pItemId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSearchItemAtLocationIfExist` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spSearchItemAtLocationIfExist`(
pItemId varchar(30),
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT COUNT(itemId) 
FROM itemlocations
WHERE 
    itemlocations.status = 'Active'
AND itemlocations.itemId = pItemId
AND itemlocations.locationId = pLocationId
AND itemlocations.propertyId = pPropertyId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateCalibration` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateCalibration`(
pPumpID varchar(30),
pCalibrationLiter varchar(10),
pShiftID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
update calibration set pumpid=pPumpID,updateddate=Now(),calibrationliter=pCalibrationLiter where shiftid=pShiftID and date(datecreated)=date(Now())
and locationid=pLocationID and propertyid=pPropertyID and pumpid=pPumpID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFuelType` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateFuelType`(
pLocationID varchar(30),
pPropertyID varchar(30),
pFuelType varchar(30),
pStatus varchar(30),
pID varchar(30))
BEGIN
update fueltype set fueltype.FuelType=pFuelType,fueltype.Status=pStatus,LocationID=pLocationID,PropertyID=pPropertyID
where id=pID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateGroup` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateGroup`(
 pGroupId varchar(30)
 , pDescription text
 , pMainGroupId varchar(30)
 , pGroupType varchar(30)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 update
 itemgroups
 set
   itemgroups.description = pDescription
 , itemgroups.mainGroupId = pMainGroupId
 , itemgroups.groupType = pGroupType
 , itemgroups.updatedBy = pUser
 , itemgroups.updatedAt = now()
 where
 itemgroups.groupId = pGroupId
 and itemgroups.locationId = pLocationId
 and itemgroups.propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateItem`(
   pItemId varchar(30)
 , pDescription text
 , pUnit varchar(30)
 , pUnitCost double(12,2)
 , pSellingPrice double(12,2)
 , pManagedBySerialNumbers varchar(30)
 , pManagedByDateCode varchar(30)
 , pManagedByLotNo varchar(30)
 , pIsInventory varchar(30)
 , pGroupId varchar(30)
 , pPropertyId varchar(30)
 , pLocationId	varchar(30) 
 , pUser varchar(30)
 )
BEGIN
 update
 items
 set
   items.description = pDescription
 , items.unit = pUnit
 , items.unitCost = pUnitCost
 , items.sellingPrice = pSellingPrice
 , items.managedBySerialNumbers = pManagedBySerialNumbers
 , items.managedByDateCode = pManagedByDateCode
 , items.managedByLotNo = pManagedByLotNo
 , items.isInventoryItems = pIsInventory 
 , items.groupId =  pGroupId
 , items.status = 'Active'
 , items.updatedBy = pUser
 , items.updatedAt = now()
 where items.itemId = pItemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItem2` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateItem2`(
   pItemId varchar(30)
 , pUnitCost double(12,2)
 , pSellingPrice double(12,2)
 , pPropertyId varchar(30)
 , pLocationId	varchar(30) 
 , pUser varchar(30)
 )
BEGIN
 update
 items
 set
   items.unitCost = pUnitCost
 , items.sellingPrice = pSellingPrice
 , items.status = 'Active'
 , items.updatedBy = pUser
 , items.updatedAt = now()
 where items.itemId = pItemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItemByLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateItemByLocation`(
   pItemId varchar(30)
 , pSellingPrice double (12,2)
 , pMinStockLevel double (12,2)
 , pMaxStockLevel double (12,2)
 , pLocalTax double (12,2)
 , pEvat double (12,2)
 , pServiceCharge varchar(30)
 , pPreparationArea varchar(30)
 , pPropertyId varchar(30)
 , pLocationId varchar(30) 
 , pUser varchar(30)
 )
BEGIN
UPDATE itemlocations
SET
   itemlocations.sellingPrice = pSellingPrice
 , itemlocations.minStockLevel = pMinStockLevel
 , itemlocations.maxStockLevel = pMaxStockLevel
 , itemlocations.localTax = pLocalTax
 , itemlocations.evat = pEvat
 , itemlocations.serviceCharge = pServiceCharge
 , itemlocations.preparationArea = pPreparationArea
 , itemlocations.status = 'Active'
 , itemlocations.createdBy = pUser
 , itemlocations.createdAt = now()
 , itemlocations.updatedBy = pUser
 , itemlocations.updatedAt = now()
WHERE itemlocations.itemId = pItemId
  AND itemlocations.locationId = pLocationId
  AND itemlocations.propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItemByLocation1` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateItemByLocation1`(
   pItemId varchar(30)
 , pSellingPrice double (12,2)
 , pMinStockLevel double (12,2)
 , pMaxStockLevel double (12,2)
 , pLocalTax double (12,2)
 , pEvat double (12,2)
 , pServiceCharge varchar(30)
 , pPropertyId varchar(30)
 , pLocationId varchar(30) 
 , pUser varchar(30)
 , pQty double(12,2)
 )
BEGIN
UPDATE itemlocations
SET
   itemlocations.sellingPrice = pSellingPrice
 , itemlocations.minStockLevel = pMinStockLevel
 , itemlocations.maxStockLevel = pMaxStockLevel
 -- , itemlocations.localTax = pLocalTax
 -- , itemlocations.evat = pEvat
 -- , itemlocations.serviceCharge = pServiceCharge
 , itemlocations.status = 'Active'
 , itemlocations.createdBy = pUser
 , itemlocations.createdAt = now()
 , itemlocations.updatedBy = pUser
 , itemlocations.updatedAt = now()
 ,  itemlocations.quantity=pQty
WHERE itemlocations.itemId = pItemId
  AND itemlocations.locationId = pLocationId
  AND itemlocations.propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItemForFuel` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateItemForFuel`(
   pItemId varchar(30)
 , pDescription text
 , pUnit varchar(30)
 , pUnitCost double(12,2)
 , pSellingPrice double(12,2)
 , pManagedBySerialNumbers varchar(30)
 , pManagedByDateCode varchar(30)
 , pManagedByLotNo varchar(30)
 , pIsInventory varchar(30)
 , pGroupId varchar(30)
 , pPropertyId varchar(30)
 , pLocationId	varchar(30) 
 , pUser varchar(30)
 )
BEGIN
 update
 items
 set
   items.description = pDescription
 , items.unit = pUnit
 , items.unitCost = pUnitCost
 , items.sellingPrice = pSellingPrice
 , items.managedBySerialNumbers = pManagedBySerialNumbers
 , items.managedByDateCode = pManagedByDateCode
 , items.managedByLotNo = pManagedByLotNo
 , items.isInventoryItems = pIsInventory 
 -- , items.groupId =  pGroupId
 , items.status = 'Active'
 , items.updatedBy = pUser
 , items.updatedAt = now()
 where items.itemId = pItemId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItemForResto` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateItemForResto`(
	pItemId varchar(30)
 , pDescription varchar(255)
 , pGroupId varchar(30)
 , pUnit varchar(10)
 , pUnitCost double(12,2)
 , pSellingPrice double(12,2)
 , pUser varchar(30)
)
BEGIN
	update
	 items
	 set
       items.description = pDescription
     , items.groupId = pGroupId
	 , items.unit = pUnit
	 , items.unitCost = pUnitCost
	 , items.sellingPrice = pSellingPrice
	 , items.status = 'Active'
	 , items.updatedBy = pUser
	 , items.updatedAt = now()
	 where items.itemId = pItemId;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItemLocationForResto` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateItemLocationForResto`(
	pItemId varchar(30)
 , pSellingPrice double (12,2)
 , pLocalTax double (12,2)
 , pEvat double (12,2)
 , pServiceCharge varchar(30)
 , pPreparationArea varchar(30)
 , pPropertyId varchar(30)
 , pLocationId varchar(30) 
 , pUser varchar(30)
)
BEGIN
	UPDATE itemlocations
	SET
	   itemlocations.sellingPrice = pSellingPrice	 
	 , itemlocations.localTax = pLocalTax
	 , itemlocations.evat = pEvat
	 , itemlocations.serviceCharge = pServiceCharge
	 , itemlocations.preparationArea = pPreparationArea
	 , itemlocations.status = 'Active'	 
	 , itemlocations.updatedBy = pUser
	 , itemlocations.updatedAt = now()
	WHERE itemlocations.itemId = pItemId
	  AND itemlocations.locationId = pLocationId
	  AND itemlocations.propertyId = pPropertyId;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItemlocationprice` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateItemlocationprice`(
pSellingprice varchar(30),
pItemID varchar(30),
pUnitCost varchar(30),
pRopertyID varchar(30),
pLocationID varchar(30))
BEGIN
    update itemlocations set sellingPrice=pSellingprice where itemid=pItemID and propertyid=pRopertyID and locationid=pLocationID;
    update items set unitcost=pUnitCost where itemid=pItemID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItemPreparationArea` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateItemPreparationArea`(
   pItemid varchar(30)
 , pPropertyId varchar(30)
 , pLocationId	varchar(30)
 , pPreparationArea varchar(30)
 )
BEGIN
 update itemlocations set preparationArea=pPreparationArea where propertyid=pPropertyId and locationid=pLocationId and itemid=pItemid;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateLocation`(
   pName varchar(30)
 , pOwner varchar(50)
 , pContactPerson varchar(50)
 , pTelephoneNumber varchar(20)
 , pFaxNumber varchar(20)
 , pAddress varchar(50)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 update
 locations
 set
 `name` = pName
 , `owner` = pOwner
 , contactPerson = pContactPerson
 , telephoneNumber = pTelephoneNumber
 , faxNumber = pFaxNumber
 , address = pAddress
 , `status` = 'Active'
 , updatedBy = pUser
 , updatedAt = now()
 where
 locationId = pLocationId
 AND propertyId =  pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateMainGroup` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateMainGroup`(
   pName varchar(30)
 , pDescription varchar(255)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 update 
 maingroups
 set
 description = pDescription
 , updatedBy = pUser
 , updatedAt = now()
 where
 mainGroupId = pName
 and locationId = pLocationId
 and propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePreparationArea` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdatePreparationArea`(
   pName varchar(30)
 , pDescription varchar(255)
 , pPrinterAssigned varchar(300)
 , pPropertyId varchar(30)
 , pLocationId varchar(30) 
 , pUser varchar(30)
 )
BEGIN
UPDATE preparationarea
SET
	  preparationarea.description = pDescription
	, preparationarea.updatedBy = pUser
	, preparationarea.updatedAt = now()
	, preparationarea.`printerAssigned` = pPrinterAssigned
	WHERE preparationarea.preparationCode = pName
        AND preparationarea.locationId = pLocationId
	AND preparationarea.propertyId = pPropertyId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePreparationAreaForResto` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdatePreparationAreaForResto`(
   pName varchar(30)
 , pDescription varchar(255)
 , pPrinterAssigned varchar(300)
 , pPropertyId varchar(30)
 , pLocationId varchar(30) 
 , pUser varchar(30)
)
BEGIN
UPDATE preparationarea
SET
	  preparationarea.description = pDescription
	, preparationarea.printerAssigned = pPrinterAssigned
	, preparationarea.updatedBy = pUser
	, preparationarea.updatedAt = now()
	WHERE preparationarea.preparationCode = pName
        AND preparationarea.locationId = pLocationId
	AND preparationarea.propertyId = pPropertyId;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePrice` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdatePrice`(
pItemId varchar(30),
pSellingPrice varchar(30),
pUser varchar(30),
pPropertyId varchar(30),
pLocationId varchar(30))
BEGIN
UPDATE itemlocations
SET
   itemlocations.sellingPrice = pSellingPrice
 , itemlocations.status = 'Active'
 , itemlocations.createdBy = pUser
 , itemlocations.createdAt = now()
 , itemlocations.updatedBy = pUser
 , itemlocations.updatedAt = now()
 WHERE itemlocations.itemId = pItemId
  AND itemlocations.locationId = pLocationId
  AND itemlocations.propertyId = pPropertyId;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePumpReadings` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdatePumpReadings`(
pShiftID varchar(30),
pTransferFrom DATETIME,
pTransferTO datetime,
pStartcount DECIMAL(12,2),
pEndcount decimal(12,2),
pTotalLiters decimal(12,2),
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30),
pID bigint,
pUnitprice varchar(30))
BEGIN
update pumpreadings set transferfrom=pTransferFrom,transferto=pTransferTO,
startcount=pStartCount,endcount=pEndcount,TotalLiters=pTotalLiters,pumpreadings.Status='Open',pumpreadings.uprice=pUnitprice  where id=pID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePumpReadingsStatus` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdatePumpReadingsStatus`(
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
update pumpreadings set pumpreadings.Status='Closed' where locationid=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePumps` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdatePumps`(
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30),
pFuelType varchar(50))
BEGIN
  update pumps set -- FuelType=pFuelType,
 ItemID=(select max(itemid) from items) where PumpID=pPumpID and LocationID=pLocationID and PropertyID=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePumpsItemID` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdatePumpsItemID`(
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30),
pItemID varchar(30))
BEGIN
  update items set groupid='' where groupid=pPumpID;
  update items set groupid=pPumpID where ItemID=pItemID;
  update pumps set ItemID='' where ItemID=pItemID;
  update pumps set -- FuelType=pFuelType,
 ItemID=pItemID where PumpID=pPumpID and LocationID=pLocationID and PropertyID=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePumpsTank` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdatePumpsTank`(
pTankID varchar(30),
pPumpID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30),
pPumpNewValue varchar(30))
BEGIN
update pumps set tankid=pTankID,FuelType=(select fueltype from Tanks where Tankid=pTankID and locationID=pLocationID
and propertyid=pPropertyID),pumpid=pPumpNewValue where pumpid=pPumpID and locationid=pLocationID and propertyid=pPropertyID;
update itemgroups set groupid=pPumpNewValue where propertyid=pPropertyID and locationid=pLocationID and groupid=pPumpID;
update items set items.groupId=pPumpNewValue where items.itemId=(select pumps.ItemID from pumps where pumps.LocationID=pLocationID and
pumps.PropertyID=pPropertyID and pumps.TankID=pTankID and pumps.PumpID=pPumpNewValue);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePumpTransactions` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdatePumpTransactions`(
pOrderDetailID bigint,
pItemID varchar(30),
pQtyByLiters decimal(12,4),
pUnitprice decimal(12,2),
pAmount decimal(12,4),
pDiscount decimal(12,4),
pShiftID varchar(10))
BEGIN
update pumptransactions set pumpID=(select groupid from Items where ItemId=pItemID),
Liters=pQtyByLiters,Unitprice=pUnitprice,Amount=pAmount,CreatedDate=Now(),Discount=pDiscount,ShiftID=pShiftID where OrderDetailID=pOrderDetailID and 
ItemID=pItemID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateShiftingDate` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateShiftingDate`(
pShiftID varchar(5),
pLocationID varchar(10),
pPropertyID varchar(10))
BEGIN
  if (select count(*) from shiftingdate where shiftid=pShiftID and locationid=pLocationID and propertyid=pPropertyID) > 0 then
 update shiftingdate set ShiftStart=Now(),ShiftEnd=Now() where shiftid=pShiftID and locationid=pLocationID and propertyid=pPropertyID;
   else
 insert shiftingdate (shiftid,Shiftstart,shiftEnd,locationid,propertyid) values (pShiftID,Now(),Now(),pLocationID,pPropertyID);
 end if;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateShiftingDateClose` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateShiftingDateClose`(
pShiftID varchar(5),
pLocationID varchar(10),
pPropertyID varchar(10))
BEGIN
 -- if (select count(*) from shiftingdate where shiftid=pShiftID and locationid=pLocationID and propertyid=pPropertyID) > 0 then
 update shiftingdate set ShiftEnd=Now() where shiftid=pShiftID and locationid=pLocationID and propertyid=pPropertyID;
 --  else
 -- insert shiftingdate (shiftid,Shiftstart,shiftEnd,locationid,propertyid) values (pShiftID,Now(),Now(),pLocationID,pPropertyID);
 -- end if;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateShiftingDateOpenTrans` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateShiftingDateOpenTrans`(
pState varchar(5),
pShiftID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
    update shiftingdate set isHasOpenTrans=pState where shiftid=pShiftID and locationid=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateStocksAtItemLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateStocksAtItemLocation`(
   pItemId varchar(30)
 , pQty double(12,2)
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
UPDATE  itemlocations
SET	itemlocations.quantity = quantity - pQty,
    	itemlocations.updatedBy = pUser,
    	itemlocations.updatedAt = now()
	WHERE itemlocations.itemId = pItemId
	AND  itemlocations.propertyId = pPropertyId
	AND  itemlocations.locationId =  pLocationId
	AND  itemlocations.status = 'Active';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateSuppliedItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateSuppliedItem`(
  pSupItemId varchar(30)
, pSupplierId varchar(30)
, pItemId varchar(30)
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser varchar(30)
)
BEGIN
 update
 supplieditems
 set
  supplieditems.itemId = pItemId
, supplieditems.supplierId = pSupplierId
, supplieditems.locationId = pLocationId
, supplieditems.propertyID = pPropertyId
, supplieditems.status = 'Active'
, supplieditems.createdBy = pUser
, supplieditems.createdAt = now()
, supplieditems.updatedBy = pUser
, supplieditems.updatedAt = now()
WHERE 
  supplieditems.supItemId = pSupItemId
and supplieditems.locationId = pLocationId
and supplieditems.propertyId = pPropertyId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateSupplier` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateSupplier`(
  pSupplierId varchar(30)
, pSupplierName varchar(200)
, pAddress1 varchar(200)
, pAddress2 varchar(200)
, pcontactPerson varchar(50)
, pPostal varchar(50)
, pPhone varchar(15)
, pMobile varchar(20)
, pFax varchar(20)
, pEmail varchar(50)
, pUrl varchar(100)
, pDiscount double(12,2)
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser  varchar(30)
)
BEGIN
UPDATE
supplier
SET
  supplier.supplierId = pSupplierId
, supplier.SupplierName = pSupplierName
, supplier.Address1 = pAddress1
, supplier.Address2 = pAddress2
, supplier.contactPerson = pcontactPerson
, supplier.postalAddress = pPostal
, supplier.phone = pPhone
, supplier.mobile = pMobile
, supplier.fax = pFax
, supplier.email = pEmail
, supplier.url = pUrl
, supplier.defaultDiscount = pDiscount
, supplier.locationId = pLocationId
, supplier.status = 'Active'
, supplier.createdBy = pUser
, supplier.createdAt = now()
, supplier.updatedBy = pUser
, supplier.updatedAt = now()
 WHERE
 supplier.supplierId = pSupplierId
 AND supplier.locationId = pLocationId
 and supplier.propertyId = pPropertyId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTanks` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateTanks`(
pItemID varchar(30),
pQtyByLiters decimal(12,2),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
update tanks set tanks.Qty=tanks.Qty-pQtyByLiters where 
tanks.TankID=(select pumps.TankID from pumps where pumps.ItemID=pItemID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTanksCostPrice` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateTanksCostPrice`(
pCost varchar(10),
pSalesPrice varchar(10),
pItemID varchar(15),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
    update tanks set capitalcost=pCost,SalesPrice=pSalesPrice where TankID=pItemID and locationid=pLocationID and propertyid=pPropertyID;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTanksInformation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateTanksInformation`(
pTankID varchar(30),
pFuelType varchar(30),
pTankName varchar(30),
pCreatedBy varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30),
pCost varchar(15),
pSalesPrice varchar(15))
BEGIN
update tanks set FuelType=pFuelType,TankName=pTankName,
CreatedDate=Now(),CreatedBy=pCreatedBy,capitalcost=pCost,SalesPrice=pSalesPrice
where TankID=pTankID and LocationID=pLocationID and PropertyID=pPropertyID ;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTanksToItemLocations` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateTanksToItemLocations`(
pItemID varchar(30),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
update itemlocations set 
quantity=(select tanks.Qty from tanks where 
tanks.TankID=(select pumps.TankID from pumps where pumps.ItemID=pItemID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID))
where itemlocations.itemId=pItemID and itemlocations.locationId=pLocationID and itemlocations.propertyId=pPropertyID;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTanksVariance` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateTanksVariance`(
pItemID varchar(30),
pQtyByLiters decimal(12,2),
pLocationID varchar(30),
pPropertyID varchar(30))
BEGIN
update tanks set tanks.Qty=tanks.Qty + pQtyByLiters where 
tanks.TankID=(select pumps.TankID from pumps where pumps.ItemID=pItemID and pumps.LocationID=pLocationID and pumps.PropertyID=pPropertyID);
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateUnit` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateUnit`(
   pName varchar(30)
 , pDescription text
 , pPropertyId varchar(30)
 , pLocationId varchar(30)
 , pUser varchar(30)
 )
BEGIN
 update
 units
 set
   units.description = pDescription
 , units.status = 'Active'
 , units.updatedBy = pUser
 , units.updatedAt = now()
 where
 units.unitName = pName
 AND units.locationId = pLocationId
 AND units.propertyId = pPropertyId;
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spVerifyItemAtItemlocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spVerifyItemAtItemlocation`(
  pPropertyId varchar(30)
, pLocationId varchar(30)
, pItemId varchar(30)
)
BEGIN
SELECT itemId From itemlocations 
WHERE itemId = pItemId 
AND propertyID = pPropertyId
AND locationId = pLocationId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spVerifySuppliedItem` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spVerifySuppliedItem`(
pSupplierId varchar(30),
pItemId varchar(30),
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT 
COUNT(supItemId) 
FROM 
supplieditems 
WHERE 
supplierId = pSupplierId 
AND itemId = pItemId 
AND locationId = pLocationId 
AND propertyId = pPropertyId
AND `status` = 'Active';
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

-- Dump completed on 2014-04-25 10:22:17
