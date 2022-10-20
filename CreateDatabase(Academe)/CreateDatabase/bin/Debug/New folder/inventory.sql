-- MySQL dump 10.11
--
-- Host: localhost    Database: inventory
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
-- Table structure for table `datecodes`
--

DROP TABLE IF EXISTS `datecodes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `datecodes` (
  `propertyId` varchar(30) default NULL,
  `locationId` varchar(30) default NULL,
  `itemId` varchar(30) default NULL,
  `dateCode` date default NULL,
  `status` enum('Active','Deleted') default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `datecodes`
--

LOCK TABLES `datecodes` WRITE;
/*!40000 ALTER TABLE `datecodes` DISABLE KEYS */;
/*!40000 ALTER TABLE `datecodes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `goodsreturndetails`
--

DROP TABLE IF EXISTS `goodsreturndetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `goodsreturndetails` (
  `propertyId` varchar(30) default NULL,
  `locationId` varchar(30) default NULL,
  `detailId` int(11) NOT NULL auto_increment,
  `gReturnId` varchar(30) default NULL,
  `itemId` varchar(30) default NULL,
  `unit` varchar(30) default NULL,
  `unitPrice` double(12,2) default '0.00',
  `serialNo` text,
  `lotNo` varchar(30) default NULL,
  `dateCode` date default NULL,
  `quantity` double(12,2) default '0.00',
  PRIMARY KEY  (`detailId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `goodsreturndetails`
--

LOCK TABLES `goodsreturndetails` WRITE;
/*!40000 ALTER TABLE `goodsreturndetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `goodsreturndetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `goodsreturnheader`
--

DROP TABLE IF EXISTS `goodsreturnheader`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `goodsreturnheader` (
  `propertyId` varchar(30) default NULL,
  `locationId` varchar(30) default NULL,
  `gReturnId` int(11) NOT NULL auto_increment,
  `supplierId` varchar(30) default NULL,
  `returnedOn` datetime default NULL,
  `totalAmount` double(12,2) default NULL,
  `remarks` text,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  PRIMARY KEY  (`gReturnId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `goodsreturnheader`
--

LOCK TABLES `goodsreturnheader` WRITE;
/*!40000 ALTER TABLE `goodsreturnheader` DISABLE KEYS */;
/*!40000 ALTER TABLE `goodsreturnheader` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grdetails`
--

DROP TABLE IF EXISTS `grdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grdetails` (
  `propertyId` varchar(30) default '',
  `locationId` varchar(30) default '',
  `grDetailId` int(11) NOT NULL auto_increment,
  `grID` varchar(30) default '',
  `itemID` varchar(30) default '',
  `unit` varchar(30) default '',
  `unitPrice` double(12,2) default '0.00',
  `serialNo` tinytext,
  `lotNo` varchar(30) default NULL,
  `dateCode` date default NULL,
  `quantity` double(12,2) default '0.00',
  PRIMARY KEY  (`grDetailId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grdetails`
--

LOCK TABLES `grdetails` WRITE;
/*!40000 ALTER TABLE `grdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `grdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grheader`
--

DROP TABLE IF EXISTS `grheader`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grheader` (
  `propertyId` varchar(30) default NULL,
  `locationId` varchar(30) default NULL,
  `grID` int(11) NOT NULL auto_increment,
  `purchaseNo` varchar(30) default NULL,
  `supplierId` varchar(30) default NULL,
  `grDate` date default NULL,
  `TotalAmount` double(12,2) default '0.00',
  `remarks` text,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`grID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grheader`
--

LOCK TABLES `grheader` WRITE;
/*!40000 ALTER TABLE `grheader` DISABLE KEYS */;
/*!40000 ALTER TABLE `grheader` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itdetails`
--

DROP TABLE IF EXISTS `itdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itdetails` (
  `propertyId` varchar(30) NOT NULL,
  `detailId` int(11) NOT NULL auto_increment,
  `itId` int(11) NOT NULL,
  `itemId` varchar(30) NOT NULL,
  `unitCost` double(12,2) default '0.00',
  `quantity` double(12,2) NOT NULL default '0.00',
  `serialNo` text,
  `lotNo` varchar(30) default '',
  `dateCode` date default NULL,
  `stocksLost` double(12,2) default '0.00',
  `serialNoLost` text,
  PRIMARY KEY  (`detailId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itdetails`
--

LOCK TABLES `itdetails` WRITE;
/*!40000 ALTER TABLE `itdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `itdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itheaders`
--

DROP TABLE IF EXISTS `itheaders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itheaders` (
  `propertyId` varchar(30) default NULL,
  `itId` int(11) NOT NULL auto_increment,
  `itrId` int(11) default NULL,
  `transferedOn` date default NULL,
  `remarks` text,
  `transferFromLocationId` varchar(30) NOT NULL,
  `transferToLocationId` varchar(30) NOT NULL,
  `status` enum('On Process','Cancelled','Transferred') NOT NULL,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  `receivedBy` varchar(30) default NULL,
  `receivedAt` datetime default NULL,
  `sapReferenceNo` varchar(30) default NULL,
  `posted` tinyint(1) default '0',
  PRIMARY KEY  (`itId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itheaders`
--

LOCK TABLES `itheaders` WRITE;
/*!40000 ALTER TABLE `itheaders` DISABLE KEYS */;
/*!40000 ALTER TABLE `itheaders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itrdetails`
--

DROP TABLE IF EXISTS `itrdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itrdetails` (
  `propertyId` varchar(30) default '',
  `detailId` int(11) NOT NULL auto_increment,
  `itrId` int(11) NOT NULL,
  `itemId` varchar(30) NOT NULL,
  `unitCost` double(12,2) default '0.00',
  `quantity` double(12,2) NOT NULL default '0.00',
  PRIMARY KEY  (`detailId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itrdetails`
--

LOCK TABLES `itrdetails` WRITE;
/*!40000 ALTER TABLE `itrdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `itrdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itrheaders`
--

DROP TABLE IF EXISTS `itrheaders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `itrheaders` (
  `propertyId` varchar(30) default '',
  `itrId` int(11) NOT NULL auto_increment,
  `requestedBy` varchar(30) default '',
  `requestedOn` datetime default NULL,
  `requiredDate` datetime default NULL,
  `remarks` text,
  `LocationIdRequestFrom` varchar(30) NOT NULL default '',
  `LocationIdRequestTo` varchar(30) NOT NULL default '',
  `status` enum('On Process','Cancelled','Transferred') NOT NULL,
  `reasonforCancelling` text,
  `createdBy` varchar(30) default '',
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default '',
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`itrId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itrheaders`
--

LOCK TABLES `itrheaders` WRITE;
/*!40000 ALTER TABLE `itrheaders` DISABLE KEYS */;
/*!40000 ALTER TABLE `itrheaders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lotnumbers`
--

DROP TABLE IF EXISTS `lotnumbers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lotnumbers` (
  `propertyId` varchar(30) default NULL,
  `locationId` varchar(30) default NULL,
  `itemId` varchar(30) default NULL,
  `lotNo` varchar(30) NOT NULL,
  `status` enum('Active','Deleted') NOT NULL,
  PRIMARY KEY  (`lotNo`,`status`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lotnumbers`
--

LOCK TABLES `lotnumbers` WRITE;
/*!40000 ALTER TABLE `lotnumbers` DISABLE KEYS */;
/*!40000 ALTER TABLE `lotnumbers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `returneditemdetails`
--

DROP TABLE IF EXISTS `returneditemdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `returneditemdetails` (
  `propertyId` varchar(30) default NULL,
  `detailId` int(11) NOT NULL auto_increment,
  `returnId` varchar(30) default NULL,
  `itemId` varchar(30) default NULL,
  `serialNo` text,
  `lotNo` varchar(30) default NULL,
  `dateCode` date default NULL,
  `quantity` double(12,2) default NULL,
  PRIMARY KEY  (`detailId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `returneditemdetails`
--

LOCK TABLES `returneditemdetails` WRITE;
/*!40000 ALTER TABLE `returneditemdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `returneditemdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `returneditemheaders`
--

DROP TABLE IF EXISTS `returneditemheaders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `returneditemheaders` (
  `propertyId` varchar(30) default NULL,
  `locationId` varchar(30) default NULL,
  `returnId` int(11) NOT NULL auto_increment,
  `returnedBy` varchar(30) default NULL,
  `returnedOn` datetime default NULL,
  `amount` double(12,2) default '0.00',
  `remarks` text,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  PRIMARY KEY  (`returnId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `returneditemheaders`
--

LOCK TABLES `returneditemheaders` WRITE;
/*!40000 ALTER TABLE `returneditemheaders` DISABLE KEYS */;
/*!40000 ALTER TABLE `returneditemheaders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `serialnumbers`
--

DROP TABLE IF EXISTS `serialnumbers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `serialnumbers` (
  `propertyId` varchar(30) NOT NULL,
  `location` varchar(30) NOT NULL,
  `itemId` varchar(30) NOT NULL,
  `serialNo` varchar(30) NOT NULL,
  `status` enum('Active','Deleted') default NULL,
  PRIMARY KEY  (`itemId`,`serialNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `serialnumbers`
--

LOCK TABLES `serialnumbers` WRITE;
/*!40000 ALTER TABLE `serialnumbers` DISABLE KEYS */;
/*!40000 ALTER TABLE `serialnumbers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unsettledinventory`
--

DROP TABLE IF EXISTS `unsettledinventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unsettledinventory` (
  `propertyId` varchar(30) NOT NULL,
  `locationId` varchar(30) NOT NULL,
  `Id` int(11) NOT NULL auto_increment,
  `orderHeaderId` varchar(30) default '',
  `refNo` varchar(30) default '',
  `returnType` enum('Refund','Exchange','Void') default NULL,
  `itemId` varchar(30) NOT NULL,
  `unitCost` double(12,2) default NULL,
  `quantity` double(12,2) default '0.00',
  `inventoryStatus` enum('Unsettled','Settled','Deleted') default 'Unsettled',
  `returnReason` text,
  `createdBy` varchar(30) default '',
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default '',
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unsettledinventory`
--

LOCK TABLES `unsettledinventory` WRITE;
/*!40000 ALTER TABLE `unsettledinventory` DISABLE KEYS */;
/*!40000 ALTER TABLE `unsettledinventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wrdetails`
--

DROP TABLE IF EXISTS `wrdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wrdetails` (
  `propertyId` varchar(30) NOT NULL,
  `detailId` int(11) NOT NULL auto_increment,
  `wrId` varchar(30) NOT NULL,
  `itemId` varchar(30) NOT NULL,
  `serialNo` text,
  `lotNo` varchar(30) default '',
  `dateCode` date default NULL,
  `unitCost` double(12,2) default '0.00',
  `quantity` double(12,2) default '0.00',
  PRIMARY KEY  (`detailId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wrdetails`
--

LOCK TABLES `wrdetails` WRITE;
/*!40000 ALTER TABLE `wrdetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `wrdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wrheaders`
--

DROP TABLE IF EXISTS `wrheaders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wrheaders` (
  `propertyId` varchar(30) default NULL,
  `locationId` varchar(30) default NULL,
  `wrId` int(11) NOT NULL auto_increment,
  `wrDate` date default NULL,
  `requestedBy` varchar(30) default NULL,
  `remarks` text,
  `status` enum('On Process','Released') default NULL,
  `reasonforCancelling` text,
  `createdBy` varchar(30) default NULL,
  `createdAt` datetime default NULL,
  `updatedBy` varchar(30) default NULL,
  `updatedAt` datetime default NULL,
  PRIMARY KEY  (`wrId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wrheaders`
--

LOCK TABLES `wrheaders` WRITE;
/*!40000 ALTER TABLE `wrheaders` DISABLE KEYS */;
/*!40000 ALTER TABLE `wrheaders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'inventory'
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
	itemlocations.quantity as AvailableStocks
from 
	common.itemlocations
where   itemlocations.itemId = pItemId
and	itemlocations.propertyID = pPropertyId
and     itemlocations.locationId = pLocationTo
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetLocationName` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetLocationName`(
pLocationId varchar(30),
pPropertyId varchar(30)
) RETURNS varchar(30) CHARSET utf8
BEGIN
RETURN  (
SELECT  common.locations.name 
	FROM common.locations 
	WHERE common.locations.locationId = pLocationId
	AND common.locations.propertyId = pPropertyId
	);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fgetRequestedStocks` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fgetRequestedStocks`(
REQUESTID varchar(30),
PITEMID varchar(30)
) RETURNS decimal(12,2)
BEGIN
RETURN
(
	SELECT itrdetails.quantity
	FROM itrdetails 
	WHERE itrdetails.itrId = REQUESTID
	AND itrdetails.itemId = PITEMID 
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetSupplierName` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetSupplierName`(
pItemId varchar(30),
pPropertyId varchar(30),
pLocationId varchar(30)
) RETURNS varchar(30) CHARSET utf8
BEGIN
return (
	select  common.supplier.SupplierName 
		from common.supplier 
		where common.supplier.supplierId = pItemId
		and common.supplier.locationId = pLocationId
		and common.supplier.propertyId = pPropertyId
	);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTheLocationName` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTheLocationName`(
pLocationId varchar(30),
pPropertyId varchar(30)
) RETURNS varchar(30) CHARSET utf8
BEGIN
 return 
(SELECT common.locations.name 
	FROM common.locations 
	WHERE common.locations.locationId = pLocationId
	AND common.locations.propertyId = pPropertyId
);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fIsManagedBySerialNumber` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fIsManagedBySerialNumber`(
 pItemId varchar(30)
 ) RETURNS varchar(10) CHARSET latin1
BEGIN
 return (
	select common.items.managedBySerialNumbers 
	from common.items 
	where common.items.itemId = pItemId 
	group by common.items.itemId);
 END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCancelTransferRequest` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCancelTransferRequest`(
pPropertyId varchar(30),
pReason text,
pITRequestId varchar(30),
pUser varchar(30)
)
BEGIN
UPDATE  itrheaders 
	SET
	itrheaders.status = 'Cancelled',
	itrheaders.reasonforCancelling = pReason,
	itrheaders.updatedBy = pUser, 
	itrheaders.updatedAt = now()
	WHERE
	itrheaders.itrId = pITRequestId
	AND
	itrheaders.propertyId = pPropertyId;
    END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGoodsReceiptbyRequestId` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetGoodsReceiptbyRequestId`(
pPropertyId varchar(30),
pLocationId varchar(30),
pRequestId varchar(30)
)
BEGIN
SELECT 	propertyId, 
	locationId, 
	grID, 
	purchaseNo, 
	fGetSupplierName(supplierId) As SupplierName, 
	grDate, 
	TotalAmount, 
	remarks, 
	createdBy, 
	createdAt, 
	updatedBy, 
	updatedAt
	FROM 
	grheader  
	WHERE
	propertyId = pPropertyId
AND	locationId = pLocationId
AND	grID = pRequestId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGoodsReceiptDetailsById` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetGoodsReceiptDetailsById`(
pPropertyId varchar(30),
pLocationId varchar(30),
pRequestId varchar(30)
)
BEGIN
select 	grID, 
	itemID, 
	unit, 
	unitPrice, 
	quantity,
	common.fGetItemDescription(grdetails.itemID) as Description
	from 
	grdetails 
	where 
	propertyId = pPropertyId
AND	locationId = pLocationId
AND	grID = pRequestId;
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
/*!50003 DROP PROCEDURE IF EXISTS `spGetGoodsReceiptHeaderLimit` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetGoodsReceiptHeaderLimit`(
pPropertyId varchar(30),
pLocationId varchar(30),
pLimit int,
pOffset int
)
BEGIN
SET @SQL = concat("SELECT grheader.propertyId, 
	          grheader.locationId, 
	          grheader.grID, 
	          grheader.purchaseNo, 
	          fGetSupplierName(grheader.supplierId,", pPropertyId,",", pLocationId, ") As SupplierName, 
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
	          grheader.propertyId =", pPropertyId,
	          " AND grheader.locationId = ",pLocationId,
		  " LIMIT ",pLimit,",",pOffset);
PREPARE STMT FROM @SQL;
EXECUTE STMT;
DEALLOCATE PREPARE STMT;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGoodsReturnDetailsById` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetGoodsReturnDetailsById`(
pPropertyId varchar(30),
pLocationId varchar(30),
pReturnId varchar(30)
)
BEGIN
select 	gReturnId, 
	itemId, 
	unit, 
	unitPrice, 
	quantity,
	common.fGetItemDescription(goodsreturndetails.itemId) as Description,
	serialNo,
	lotNo,
	dateCode
	from 
	goodsreturndetails
	where 
	propertyId = pPropertyId
AND	locationId = pLocationId
AND	gReturnId = pReturnId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGoodsReturnHeader` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetGoodsReturnHeader`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN 
SELECT  goodsreturnheader.propertyId, 
	goodsreturnheader.locationId, 
	goodsreturnheader.gReturnId,
	fGetSupplierName(goodsreturnheader.supplierId, pPropertyId, pLocationId) As SupplierName, 
	goodsreturnheader.returnedOn, 
	goodsreturnheader.TotalAmount, 
	goodsreturnheader.remarks, 
	goodsreturnheader.createdBy, 
	goodsreturnheader.createdAt
	FROM goodsreturnheader
	WHERE
	goodsreturnheader.propertyId = pPropertyId
AND	goodsreturnheader.locationId = pLocationId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPurchaseNos` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetPurchaseNos`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT 	grheader.purchaseNo
FROM 	grheader  
	WHERE grheader.propertyId = pPropertyId
	AND grheader.locationId = pLocationId;
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
	common.fGetItemDescription(itrdetails.itemId) as Description,
	common.fGetLocalStocks(itrdetails.itemId, itrheaders.propertyId, itrheaders.LocationIdRequestTo) as LocalStocks,
	common.fGetMinStockLevel(itrdetails.itemId, itrheaders.propertyId, itrheaders.LocationIdRequestTo) as MinStockLevel,
	itrdetails.quantity,
        common.fIsManagedBySerialNumber(itrdetails.itemId) as MSerial,
	common.fIsManagedByLotNo(itrdetails.itemId) as MLotNo,
        common.fIsManagedByDateCode(itrdetails.itemId) as MDateCode
	FROM itrdetails 
	LEFT JOIN itrheaders ON itrdetails.itrId = itrheaders.itrId
	WHERE itrdetails.itrId = pRequestId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTranferRequestStatus` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTranferRequestStatus`(
pPropertyId varchar(30),
pITRequestId varchar(30)
)
BEGIN
SELECT  itrheaders.status
FROM 
	itrheaders
WHERE
	itrheaders.itrId = pITRequestId
	AND itrheaders.propertyId = pPropertyId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTransferredItemDetailsByLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTransferredItemDetailsByLocation`(
  pITransferId varchar(30)
, pPropertyId varchar(30)
)
BEGIN
/*SELECT  itdetails.itId,
	itdetails.itemId,
	itdetails.quantity,
	itdetails.propertyId,
	itdetails.detailId,
	common.fGetItemDescription(itdetails.itemId) as Description,
	itrdetails.quantity as RequestedStocks
	FROM itdetails
	LEFT JOIN itheaders ON itdetails.itId = itheaders.itId
	LEFT JOIN itrheaders ON itrheaders.itrId = itheaders.itrId
	LEFT JOIN itrdetails ON itrdetails.itrId = itrheaders.itrId
	WHERE itdetails.itId = pITransferId 
	AND itdetails.propertyId = pPropertyId;*/
	
select  itdetails.itId,
	itdetails.itemId,
	itdetails.quantity,
	itdetails.propertyId,
	itdetails.detailId,
	common.fGetItemDescription(itdetails.itemId) as Description,
	fgetRequestedStocks(itheaders.itrId, itdetails.itemId) as RequestedStocks
	FROM itdetails
	LEFT JOIN itheaders ON itdetails.itId = itheaders.itId
	WHERE itdetails.itId = pITransferId 
	AND itdetails.propertyId = pPropertyId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTransferredItemHeaderByLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTransferredItemHeaderByLocation`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  
	itheaders.itId,
	itheaders.itrId,
	itheaders.remarks,
	itheaders.transferFromLocationId,
	itheaders.transferToLocationId,
	fGetTheLocationName(itheaders.transferFromLocationId, itheaders.propertyId) as LocationNameTo,
	fGetTheLocationName(itheaders.transferToLocationId, itheaders.propertyId) as LocationNameFrom,
	itheaders.status,
	itheaders.createdBy,
	itheaders.createdAt,
	itheaders.receivedBy,
	itheaders.receivedAt,
	itheaders.transferedOn
	FROM
	itheaders
	WHERE itheaders.propertyId = pPropertyId
	AND itheaders.transferToLocationId = pLocationId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTransferRequestDetailsByID` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTransferRequestDetailsByID`(
pPropertyId varchar(30),
pITRequestId varchar(30)
)
BEGIN
SELECT  itrdetails.itemId,
	itrdetails.quantity,
	common.fGetItemDescription(itrdetails.itemId) as Description,
	common.fGetAvailableStocks(itrdetails.itemId, pPropertyId, itrheaders.LocationIdRequestTo) as AvailableStocks,
	common.fGetLocalStocks(itrdetails.itemId, pPropertyId, itrheaders.LocationIdRequestFrom) as LocalStocks,
	common.fGetMaxStockLevel(itrdetails.itemId, pPropertyId, itrheaders.LocationIdRequestFrom) as MaxStocks,
	itrdetails.detailId
	FROM
	itrheaders
	LEFT JOIN
	itrdetails
	ON
	itrheaders.itrId = itrdetails.itrId
	WHERE 
	itrdetails.itrId = pITRequestId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTransferRequestHeaderByLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTransferRequestHeaderByLocation`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  itrheaders.itrId, 
	itrheaders.requestedBy, 
	itrheaders.requestedOn,
	itrheaders.requiredDate,
	itrheaders.status,
	itrheaders.remarks, 
	itrheaders.LocationIdRequestFrom, 
	itrheaders.LocationIdRequestTo,
	fGetTheLocationName(itrheaders.LocationIdRequestFrom, itrheaders.propertyId) as LocationNameTo,
	fGetTheLocationName(itrheaders.LocationIdRequestTo, itrheaders.propertyId) as LocationNameFrom,
	itrheaders.createdAt,
	itheaders.itId,
	itheaders.createdBy,
	itheaders.transferedOn
	FROM itrheaders
	LEFT JOIN itheaders ON itrheaders.itrId = itheaders.itrId
	WHERE
	itrheaders.propertyId = pPropertyId
AND     itrheaders.LocationIdRequestTo = pLocationId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTransferRequestHeaderFromLocation` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTransferRequestHeaderFromLocation`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  itrheaders.itrId, 
	itrheaders.requestedBy, 
	itrheaders.requestedOn,
	itrheaders.requiredDate,
	itrheaders.status,
	itrheaders.remarks, 
	itrheaders.LocationIdRequestFrom, 
	itrheaders.LocationIdRequestTo,
	fGetTheLocationName(itrheaders.LocationIdRequestTo, itrheaders.propertyId) as LocationNameTo,
	fGetTheLocationName(itrheaders.LocationIdRequestTo, itrheaders.propertyId) as LocationNameFrom,
	itrheaders.createdAt,
	itheaders.itId
	FROM itrheaders
	LEFT JOIN itheaders ON itrheaders.itrId = itheaders.itrId
	WHERE
	itrheaders.propertyId = pPropertyId
AND     itrheaders.LocationIdRequestFrom = pLocationId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetUnsettledInventories` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetUnsettledInventories`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT  -- unsettledorderHeaderId as OrderId,
        -- unsettledcreatedAt as OrderDate,
	-- unsettleditemId,
	-- common.fGetItemDescription(unsettleditemId) as Description,
	-- unsettledquantity,
	-- unsettledreturnType,
	-- unsettledreturnReason,
	-- unsettledinventoryStatus,
	-- unsettledId
        orderHeaderId as OrderId,
        createdAt as OrderDate,
	itemId,
	common.fGetItemDescription(itemId) as Description,
	quantity,
	returnType,
	returnReason,
	inventoryStatus,
	Id
	FROM unsettledinventory
	WHERE -- unsettledpropertyId  = pPropertyId
                 propertyId  = pPropertyId
	AND -- unsettledlocationId = pLocationId;
                 locationId = pLocationId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetWithdrawalDetailsByID` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetWithdrawalDetailsByID`(
pPropertyId varchar(30),
pRequestId varchar(30)
)
BEGIN
SELECT 	
	wrdetails.itemId,
	wrdetails.detailId,
	wrdetails.serialNo,
	wrdetails.lotNo,
	wrdetails.dateCode,
	wrdetails.quantity,
	common.fGetItemDescription(wrdetails.itemId) as Description,
	common.fGetLocalStocks(wrdetails.itemId, wrheaders.propertyId, wrheaders.locationId) as LocalStocks,
	common.fGetMinStockLevel(wrdetails.itemId, wrheaders.propertyId, wrheaders.locationId) as MinStocks,
	common.fGetMaxStockLevel(wrdetails.itemId, wrheaders.propertyId, wrheaders.locationId) as MaxStocks,
	wrdetails.unitCost
	FROM
	wrdetails
	LEFT JOIN wrheaders
	ON wrheaders.wrId = wrdetails.wrId
	WHERE wrdetails.propertyId = pPropertyId
	AND wrdetails.wrId = pRequestId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetWithdrawalHeader` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetWithdrawalHeader`(
pPropertyId varchar(30),
pLocationId varchar(30)
)
BEGIN
SELECT 	
	wrheaders.wrId, 
	wrheaders.wrDate,
	wrheaders.requestedBy, 
	wrheaders.createdAt,
	wrheaders.remarks, 
	wrheaders.status, 
	wrheaders.reasonforCancelling
	FROM
	wrheaders
	WHERE wrheaders.propertyId = pPropertyId
	AND wrheaders.locationId = pLocationId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertGoodsReturnDetails` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertGoodsReturnDetails`(
  pReturnId varchar(30)
, pItemId varchar(30)
, pUnit varchar(30)
, pUnitPrice double(12,2)
, pQty double(12,2)
, pSerialNo text
, pPropertyId varchar(30)
, pLocationId varchar(30)
)
BEGIN
INSERT INTO goodsreturndetails
SET
  goodsreturndetails.propertyId = pPropertyId
, goodsreturndetails.locationId = pLocationId
, goodsreturndetails.gReturnId=  pReturnId
, goodsreturndetails.itemId = pItemId
, goodsreturndetails.unit = pUnit
, goodsreturndetails.unitPrice = pUnitPrice
, goodsreturndetails.quantity= pQty
, goodsreturndetails.serialNo = pSerialNo;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertGoodsReturnHeader` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertGoodsReturnHeader`(
  pReturnedOn datetime
, pSupplierId varchar(30)
, pTotalAmount double(12,2)
, pRemarks text	
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser varchar(30)
)
BEGIN
INSERT INTO goodsreturnheader
SET
  goodsreturnheader.propertyId = pPropertyId
, goodsreturnheader.locationId = pLocationId
, goodsreturnheader.returnedOn = pReturnedOn
, goodsreturnheader.supplierId = pSupplierId
, goodsreturnheader.totalAmount = pTotalAmount
, goodsreturnheader.remarks = pRemarks
, goodsreturnheader.createdBy = pUser
, goodsreturnheader.createdAt = now();
  select last_insert_id();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertGRDetails` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertGRDetails`(
  pGrId varchar(30)
, pItemId varchar(30)
, pUnit varchar(30)
, pUnitPrice double(12,2)
, pQty double(12,2)
, pSerialNo text
, pPropertyId varchar(30)
, pLocationId varchar(30)
)
BEGIN
INSERT INTO
grdetails
SET
  grdetails.propertyId = pPropertyId
, grdetails.locationId = pLocationId
, grdetails.grID = pGrId
, grdetails.itemID = pItemId
, grdetails.unit = pUnit
, grdetails.unitPrice = pUnitPrice
, grdetails.quantity= pQty
, grdetails.serialNo = pSerialNo;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertGRHeader` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertGRHeader`(
  pPurchaseNo varchar(30)
, pDateReceived datetime
, pSupplierId varchar(30)
, pTotalAmount double(12,2)
, pRemarks text	
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser varchar(30)
)
BEGIN
INSERT INTO
grheader
SET
  grheader.propertyId = pPropertyId
, grheader.locationId = pLocationId
, grheader.purchaseNo = pPurchaseNo
, grheader.grDate = pDateReceived
, grheader.supplierId = pSupplierId
, grheader.TotalAmount = pTotalAmount
, grheader.remarks = pRemarks
, grheader.createdBy = pUser
, grheader.createdAt = now()
, grheader.updatedBy = pUser
, grheader.updatedAt = now();
select last_insert_id();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertTransferedItemDetails` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertTransferedItemDetails`(
  pITransferId varchar(30)
, pItemId varchar(30)
, pQuantity varchar(30)
, pSerialNo text
, pPropertyId varchar(30)
)
BEGIN
INSERT INTO
	itdetails
SET
	itdetails.itId =  pITransferId,
	itdetails.itemId = pItemId,
	itdetails.quantity = pQuantity,
	itdetails.serialNo = pSerialNo,
	itdetails.propertyId = pPropertyId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertTransferedItemHeader` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertTransferedItemHeader`(
  pITRequestId varchar(30)
, pTransferedON date
, pRemarks text
, pFromLocationId varchar(30)
, pToLocationId varchar(30)
, pStatus varchar(30)
, pPropertyId varchar(30)
, pUser varchar(30)
)
BEGIN
INSERT INTO
	itheaders
SET
	itheaders.itrId = pITRequestId,
	itheaders.transferedOn = pTransferedON,
	itheaders.remarks = pRemarks,
	itheaders.transferFromLocationId = pFromLocationId,
	itheaders.transferToLocationId = pToLocationId,
	itheaders.status = pStatus,
	itheaders.propertyId = pPropertyId,
	itheaders.createdBy = pUser,
	itheaders.createdAt = now(),
	itheaders.updatedBy = pUser,
	itheaders.updatedAt = now();
	select last_insert_id();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertTransferRequestDetails` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertTransferRequestDetails`(
  pItrId varchar(30)
, pItemId varchar(30)
, pQty double(12,2)
, pPropertyId varchar(30)
)
BEGIN
INSERT INTO
itrdetails
SET
  itrdetails.itrId = pItrId
, itrdetails.itemId = pItemId
, itrdetails.quantity = pQty
, itrdetails.propertyId = pPropertyId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertTransferRequestHeader` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertTransferRequestHeader`(
  pRequestedBy varchar(30)
, pRequestedOn datetime
, pRequiredDate datetime
, pRemarks text
, pLocationTo varchar(30)
, pLocationId varchar(30)
, pPropertyId varchar(30)
, pUser varchar(30)
)
BEGIN
INSERT INTO
itrheaders
SET
  itrheaders.requestedBy = pRequestedBy
, itrheaders.requestedOn = pRequestedOn
, itrheaders.requiredDate = pRequiredDate
, itrheaders.remarks = pRemarks 
, itrheaders.LocationIdRequestFrom = pLocationId
, itrheaders.LocationIdRequestTo = pLocationTo
, itrheaders.status = 'On Process'
, itrheaders.propertyId = pPropertyId
, itrheaders.createdBy = pUser
, itrheaders.createdAt = now()
, itrheaders.updatedBy = pUser
, itrheaders.updatedAt = now();
select last_insert_id();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertUnsettledInventory` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertUnsettledInventory`(                                  
 pOrderHeaderId varchar(30),                                       
 prefNo varchar(30),                                               
 preturnType varchar(30),                   
 pitemId varchar(30),    
 pUnitCost double(12,2),                                            
 pquantity double(12,2),                                       
 pinventoryStatus varchar(30),                                     
 preturnReason text,                                                          
 pPropertyId varchar(30),
 pLocationId varchar(30),
 pUser varchar(30)
)
BEGIN
INSERT INTO unsettledInventory
SET
	unsettledInventory.orderHeaderId = pOrderHeaderId,
	unsettledInventory.refNo = prefNo,
	unsettledInventory.returnType = preturnType,
	unsettledInventory.itemId = pitemId,
	unsettledInventory.unitCost = pUnitCost,
	unsettledInventory.quantity = pquantity,
	unsettledInventory.inventoryStatus = pinventoryStatus,
	unsettledInventory.returnReason = preturnReason,
	unsettledInventory.propertyId = pPropertyId,
	unsettledInventory.locationId = pLocationId,
	unsettledInventory.createdBy = pUser,
	unsettledInventory.createdAt = now(),
	unsettledInventory.updatedBy = pUser,
	unsettledInventory.updatedAt = now();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertWithdrawalHeader` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertWithdrawalHeader`(
  pRequestedBy varchar(30)
, pRequestedOn datetime
, pRemarks text
, pPropertyId varchar(30)
, pLocationId varchar(30)
, pUser varchar(30)
)
BEGIN
INSERT INTO
wrheaders	
SET
  wrheaders.requestedBy = pRequestedBy
, wrheaders.wrDate = pRequestedOn
, wrheaders.remarks = pRemarks 
, wrheaders.status = 'Released'
, wrheaders.locationId = pLocationId
, wrheaders.propertyId = pPropertyId
, wrheaders.createdBy = pUser
, wrheaders.createdAt = now()
, wrheaders.updatedBy = pUser
, wrheaders.updatedAt = now();
select last_insert_id();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertWithdrawDetails` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertWithdrawDetails`(
  pWRequestId varchar(30)
, pItemId varchar(30)
, pUnitCost double(12,2)
, pQty double(12,2)
, pSerialNo text
, pPropertyId varchar(30)
)
BEGIN
INSERT INTO
wrdetails
SET
  wrdetails.wrId = pWRequestId
, wrdetails.itemId = pItemId
, wrdetails.unitCost = pUnitCost
, wrdetails.quantity = pQty
, wrdetails.serialNo = pSerialNo
, wrdetails.propertyId = pPropertyId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportGoodsReceipts` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportGoodsReceipts`(
PROPERTYID VARCHAR(30),
LOCATIONID VARCHAR(30),
DATE1 DATE,
DATE2 DATE,
PERIOD VARCHAR(30)
)
BEGIN
select  grdetails.propertyId, 
	grdetails.locationId,
	grheader.grID, 
	grdetails.grDetailId, 
	grheader.purchaseNo, 
	grheader.supplierId, 
	grheader.grDate, 
	grheader.TotalAmount, 
	grheader.remarks, 
	grdetails.itemID, 
	grdetails.serialNo, 
	grdetails.lotNo, 
	grdetails.dateCode, 
	grdetails.unit, 
	grdetails.unitPrice, 
	grdetails.quantity,
	grheader.createdBy, 
	grheader.createdAt, 
	grheader.updatedBy, 
	grheader.updatedAt,
	common.fGetItemDescription(grdetails.itemID) as Description,
	common.fGetSupplierName(supplierId, PROPERTYID, LOCATIONID) as SupplierName
	from grheader 
	left join grdetails on grdetails.grID = grheader.grID
	Where grheader.locationId = LOCATIONID
	AND grheader.propertyId = PROPERTYID
AND 	IF(PERIOD = 'MONTHLY', MONTH(grheader.grDate) = MONTH(DATE1) AND YEAR(grheader.grDate) = YEAR(DATE1),
            IF(PERIOD = 'DAILY', DATE(grheader.grDate) = DATE(DATE1), 
                 IF(PERIOD = 'YEARLY', YEAR(grheader.grDate) = YEAR(DATE1),
                     IF(PERIOD = 'RANGE', DATE(grheader.grDate) >= DATE(DATE1) AND DATE(grheader.grDate) <= DATE(DATE2), 0)
	           )
	      )
          );
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportItemTranfer` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportItemTranfer`(
PROPERTYID VARCHAR(30),
LOCATIONID VARCHAR(30),
DATE1 DATE,
DATE2 DATE,
PERIOD VARCHAR(30)
)
BEGIN
 -- get all transferred items from the source location to destination
select 	itheaders.itId, 
	itheaders.itrId, 
	itheaders.remarks, 
	itheaders.transferedOn,
	itheaders.transferFromLocationId, 
	itheaders.transferToLocationId, 
	itheaders.status,  
	itdetails.propertyId, 
	itdetails.detailId, 
	itdetails.itemId, 
	itdetails.unitCost, 
	itdetails.quantity, 
	itdetails.serialNo, 
	itdetails.lotNo, 
	itdetails.dateCode, 
	itdetails.stocksLost, 
	itdetails.serialNoLost,
	common.fGetLocationName(itheaders.transferFromLocationId) as FromLocation,
	common.fGetLocationName(itheaders.transferToLocationId) as ToLocation,
	common.fGetItemDescription(itdetails.itemId) as Description
	from itheaders 
	left join itdetails on itheaders.itId = itdetails.itId
	Where itheaders.transferToLocationId = LOCATIONID
	AND itheaders.propertyId = PROPERTYID
	AND itheaders.status = 'Transferred'
AND 	IF(PERIOD = 'MONTHLY', MONTH(itheaders.transferedOn) = MONTH(DATE1) AND YEAR(itheaders.transferedOn) = YEAR(DATE1),
            IF(PERIOD = 'DAILY', DATE(itheaders.transferedOn) = DATE(DATE1), 
                 IF(PERIOD = 'YEARLY', YEAR(itheaders.transferedOn) = YEAR(DATE1),
                     IF(PERIOD = 'RANGE', DATE(itheaders.transferedOn) >= DATE(DATE1) AND DATE(itheaders.transferedOn) <= DATE(DATE2), 0)
	           )
	      )
          );
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportUnsettledInventory` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportUnsettledInventory`(
PROPERTYID VARCHAR(30),
LOCATIONID VARCHAR(30),
DATE1 DATE,
DATE2 DATE,
PERIOD VARCHAR(30)
)
BEGIN
SELECT /*	unsettledpropertyId,
unsettledlocationId,
unsettledId,
unsettledorderHeaderId,
unsettledrefNo,
unsettledreturnType,
unsettleditemId,
unsettledquantity,
unsettledinventoryStatus,
unsettledreturnReason,
unsettledcreatedBy,
unsettledcreatedAt,
unsettledupdatedBy,
unsettledupdatedAt, 
common.fGetItemDescription(unsettleditemId) AS Description,
unsettledunitCost */
	propertyId,
locationId,
Id,
orderHeaderId,
refNo,
returnType,
itemId,
quantity,
inventoryStatus,
returnReason,
createdBy,
createdAt,
updatedBy,
updatedAt, 
common.fGetItemDescription(itemId) AS Description,
unitCost
FROM unsettledinventory
WHERE inventoryStatus = 'Settled'
AND locationId = LOCATIONID
AND propertyId = PROPERTYID
AND 	IF(PERIOD = 'MONTHLY', MONTH(createdAt) = MONTH(DATE1) AND YEAR(createdAt) = YEAR(DATE1),
            IF(PERIOD = 'DAILY', DATE(createdAt) = DATE(DATE1),
                 IF(PERIOD = 'YEARLY', YEAR(createdAt) = YEAR(DATE1),
                     IF(PERIOD = 'RANGE', DATE(createdAt) >= DATE(DATE1) AND DATE(createdAt) <= DATE(DATE2), 0)
           )
      )
          );
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportWithdrawals` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportWithdrawals`(
PROPERTYID VARCHAR(30),
LOCATIONID VARCHAR(30),
DATE1 DATE,
DATE2 DATE,
PERIOD VARCHAR(30)
)
BEGIN
select 	wrheaders.propertyId, 
	wrheaders.locationId, 
	wrheaders.wrId, 
	wrheaders.wrDate,
	wrheaders.requestedBy, 
	wrheaders.remarks, 
	wrheaders.status, 
	wrheaders.reasonforCancelling, 
	wrheaders.createdBy, 
	wrheaders.createdAt, 
	wrheaders.updatedBy, 
	wrheaders.updatedAt,
	wrdetails.detailId, 
	wrdetails.itemId, 
	wrdetails.serialNo, 
	wrdetails.lotNo, 
	wrdetails.dateCode, 
	wrdetails.unitCost, 
	wrdetails.quantity,
	common.fGetItemDescription(wrdetails.itemId) as Description
	from wrheaders 
	left join wrdetails on wrheaders.wrId = wrdetails.wrId
	Where wrheaders.locationId = LOCATIONID
	AND wrheaders.propertyId = PROPERTYID
	AND wrheaders.status = 'Released'
AND 	IF(PERIOD = 'MONTHLY', MONTH(wrheaders.wrDate) = MONTH(DATE1) AND YEAR(wrheaders.wrDate) = YEAR(DATE1),
            IF(PERIOD = 'DAILY', DATE(wrheaders.wrDate) = DATE(DATE1), 
                 IF(PERIOD = 'YEARLY', YEAR(wrheaders.wrDate) = YEAR(DATE1),
                     IF(PERIOD = 'RANGE', DATE(wrheaders.wrDate) >= DATE(DATE1) AND DATE(wrheaders.wrDate) <= DATE(DATE2), 0)
	           )
	      )
          );
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spResetInventoryTransaction` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spResetInventoryTransaction`()
BEGIN
DELETE FROM wrheaders;
DELETE FROM wrheaders;
DELETE FROM itdetails;
DELETE FROM itheaders;
DELETE FROM itrdetails;
DELETE FROM itrheaders;
DELETE FROM unsettledinventory;
DELETE FROM grdetails;
DELETE FROM grheader;
DELETE FROM datecodes;
DELETE FROM serialnumbers;
DELETE FROM lotnumbers;
DELETE FROM common.itemledger;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateStatusOfUnsettledInventory` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateStatusOfUnsettledInventory`(   
 pId varchar(30),                                                                  
 pinventoryStatus varchar(30),                                                                                              
 pPropertyId varchar(30),
 pLocationId varchar(30),
 pUser varchar(30)
)
BEGIN
UPDATE  unsettledInventory
SET	unsettledInventory.inventoryStatus = pinventoryStatus,
	unsettledInventory.updatedBy = pUser,
	unsettledInventory.updatedAt = now()
WHERE   unsettledInventory.propertyId = pPropertyId 
AND	unsettledInventory.locationId = pLocationId
AND	unsettledInventory.Id = pId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTransferRequestDetails` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateTransferRequestDetails`(
  pItrId varchar(30)
, pItemId varchar(30)
, pDetailId varchar(30)
, pQty double(12,2)
, pPropertyId varchar(30)
)
BEGIN
UPDATE
	itrdetails
SET
	itrdetails.quantity = pQty
	WHERE itrdetails.itemId = pItemId
	AND itrdetails.detailId = pDetailId
	AND itrdetails.propertyId = pPropertyId
	AND itrdetails.itrId = pItrId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTransferRequestHeader` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateTransferRequestHeader`(
  pITRequestId varchar(30)
, pRequiredDate datetime
, pRemarks text
, pPropertyId varchar(30)
, pUser varchar(30)
)
BEGIN
UPDATE
itrheaders
SET
  itrheaders.requiredDate = pRequiredDate
, itrheaders.remarks = pRemarks 
, itrheaders.updatedBy = pUser
, itrheaders.updatedAt = now()
WHERE
  itrheaders.itrId = pITRequestId
AND itrheaders.propertyId = pPropertyId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTransferRequestHeaderStatus` */;;
/*!50003 SET SESSION SQL_MODE="NO_AUTO_VALUE_ON_ZERO"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateTransferRequestHeaderStatus`(
  pITRequestId varchar(30)
, pPropertyId varchar(30)
, pStatus varchar(30)
)
BEGIN
UPDATE
itrheaders
SET
  itrheaders.status = pStatus
WHERE
  itrheaders.itrId = pITRequestId
  
AND itrheaders.propertyId = pPropertyId;
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

-- Dump completed on 2014-04-25 10:23:07
