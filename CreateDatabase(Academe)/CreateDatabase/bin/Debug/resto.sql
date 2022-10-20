-- MySQL dump 10.10
--
-- Host: localhost    Database: pos
-- ------------------------------------------------------
-- Server version	5.0.27-community-nt

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
-- Table structure for table `accumulatedtotal`
--

DROP TABLE IF EXISTS `accumulatedtotal`;
CREATE TABLE `accumulatedtotal` (
  `restoID` bigint(10) default '1',
  `totalSales` decimal(12,2) default '0.00'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `accumulatedtotal`
--

LOCK TABLES `accumulatedtotal` WRITE;
/*!40000 ALTER TABLE `accumulatedtotal` DISABLE KEYS */;
INSERT INTO `accumulatedtotal` VALUES (1,'0.00');
/*!40000 ALTER TABLE `accumulatedtotal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bike`
--

DROP TABLE IF EXISTS `bike`;
CREATE TABLE `bike` (
  `BIKE_ID` varchar(10) NOT NULL,
  `PLATE_NO` varchar(30) default NULL,
  `ENGINE_NO` varchar(30) default NULL,
  `MODEL` varchar(30) default NULL,
  `MAKE` varchar(30) default NULL,
  `STATUS` varchar(20) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-01-01 00:00:01',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-01-01 00:00:01',
  PRIMARY KEY  (`BIKE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bike`
--

LOCK TABLES `bike` WRITE;
/*!40000 ALTER TABLE `bike` DISABLE KEYS */;
INSERT INTO `bike` VALUES ('1','','','','','','','2006-01-01 00:00:01','','2006-01-01 00:00:01');
/*!40000 ALTER TABLE `bike` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bike_assign`
--

DROP TABLE IF EXISTS `bike_assign`;
CREATE TABLE `bike_assign` (
  `EMPLOYEE_ID` varchar(10) NOT NULL,
  `BIKE_ID` varchar(10) default NULL,
  `STATUS` varchar(7) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default NULL,
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default NULL,
  PRIMARY KEY  (`EMPLOYEE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bike_assign`
--

LOCK TABLES `bike_assign` WRITE;
/*!40000 ALTER TABLE `bike_assign` DISABLE KEYS */;
/*!40000 ALTER TABLE `bike_assign` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `button_setup`
--

DROP TABLE IF EXISTS `button_setup`;
CREATE TABLE `button_setup` (
  `RESTO_ID` int(11) NOT NULL default '1',
  `BUTTON_ID` varchar(20) NOT NULL,
  `TYPE` varchar(50) default NULL,
  `OBJECT` varchar(50) default NULL,
  `STATUS` varchar(7) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default NULL,
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default NULL,
  PRIMARY KEY  (`RESTO_ID`,`BUTTON_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `button_setup`
--

LOCK TABLES `button_setup` WRITE;
/*!40000 ALTER TABLE `button_setup` DISABLE KEYS */;
INSERT INTO `button_setup` VALUES (1,'F1','FUNCTION','F1','ACTIVE','root','2007-06-19 10:50:12','root','2007-06-19 10:50:12'),(1,'F12','FUNCTION','BANQUET BEV','ACTIVE','root','2007-07-03 10:33:08','root','2007-07-03 10:33:08'),(1,'F16','FUNCTION','COMPLIMENTARY','ACTIVE','root','2007-06-15 12:06:47','root','2007-06-15 12:06:47'),(1,'F17','FUNCTION','COUPON','ACTIVE','root','2007-06-15 15:33:30','root','2007-06-15 15:33:30'),(1,'F18','FUNCTION','XDEAL','ACTIVE','root','2007-06-16 13:42:09','root','2007-06-16 13:42:09'),(1,'F2','FUNCTION','F2','ACTIVE','root','2007-06-19 10:50:14','root','2007-06-19 10:50:14'),(1,'F5','ITEM','147','ACTIVE','root','2007-07-03 10:37:15','root','2007-07-03 10:37:15'),(1,'F6','FUNCTION','F5','ACTIVE','root','2007-07-03 10:37:07','root','2007-07-03 10:37:07'),(1,'F8','FUNCTION','F3','ACTIVE','root','2007-07-03 10:37:12','root','2007-07-03 10:37:12'),(1,'label35','ITEM','10','ACTIVE','root','2008-10-27 15:24:14','root','2008-10-27 15:24:14'),(1,'label40','ITEM','14','ACTIVE','root','2008-08-05 13:38:21','root','2008-08-05 13:38:21'),(1,'p1b1','ITEM','4','ACTIVE','root','2007-08-03 18:54:58','root','2007-08-03 18:54:58'),(1,'p1b15','ITEM','13','ACTIVE','root','2008-10-27 15:24:18','root','2008-10-27 15:24:18'),(1,'p1b8','ITEM','5','ACTIVE','root','2008-10-27 15:24:10','root','2008-10-27 15:24:10'),(1,'p2b10','ITEM','5','ACTIVE','root','2008-08-05 13:38:26','root','2008-08-05 13:38:26'),(1,'p2b16','ITEM','11','ACTIVE','root','2008-08-05 13:38:25','root','2008-08-05 13:38:25'),(1,'p2b18','ITEM','10','ACTIVE','root','2008-08-05 13:38:24','root','2008-08-05 13:38:24'),(1,'p2b3','ITEM','5','ACTIVE','root','2008-08-05 13:38:23','root','2008-08-05 13:38:23'),(1,'p3b1','ITEM','51','ACTIVE','root','2007-06-03 11:05:31','root','2007-06-03 11:05:31'),(1,'p4b5','ITEM','10','ACTIVE','root','2007-08-03 18:55:06','root','2007-08-03 18:55:06'),(1,'p4b6','ITEM','8','ACTIVE','root','2007-08-03 18:55:04','root','2007-08-03 18:55:04'),(1,'p4b7','ITEM','3','ACTIVE','root','2007-08-03 18:54:55','root','2007-08-03 18:54:55'),(1,'p5b11','FUNCTION','BANQUET FOOD','ACTIVE','root','2007-07-03 10:33:10','root','2007-07-03 10:33:10'),(2,'F1','FUNCTION','F1','ACTIVE','root','2007-07-21 14:56:34','root','2007-07-21 14:56:34'),(2,'F18','FUNCTION','SENIOR','ACTIVE','root','2007-07-26 12:00:46','root','2007-07-26 12:00:46'),(2,'F19','FUNCTION','F19','ACTIVE','root','2007-07-25 09:33:23','root','2007-07-25 09:33:23'),(2,'F2','FUNCTION','F2','ACTIVE','root','2007-07-21 14:56:38','root','2007-07-21 14:56:38'),(2,'F20','FUNCTION','F20','ACTIVE','root','2007-07-21 19:43:33','root','2007-07-21 19:43:33'),(2,'F3','FUNCTION','CORKAGE','ACTIVE','root','2007-07-21 15:27:37','root','2007-07-21 15:27:37'),(2,'F6','FUNCTION','F6','ACTIVE','root','2007-07-21 21:48:12','root','2007-07-21 21:48:12'),(2,'label22','ITEM','106','ACTIVE','root','2007-08-03 18:53:56','root','2007-08-03 18:53:56'),(2,'label28','ITEM','114','ACTIVE','root','2007-08-03 18:53:12','root','2007-08-03 18:53:12'),(2,'label29','ITEM','115','ACTIVE','root','2007-08-03 18:53:14','root','2007-08-03 18:53:14'),(2,'label30','ITEM','116','ACTIVE','root','2007-08-03 18:53:16','root','2007-08-03 18:53:16'),(2,'label31','ITEM','117','ACTIVE','root','2007-08-03 18:53:18','root','2007-08-03 18:53:18'),(2,'label32','ITEM','127','ACTIVE','root','2007-08-03 18:53:37','root','2007-08-03 18:53:37'),(2,'label33','ITEM','132','ACTIVE','root','2007-08-03 18:53:41','root','2007-08-03 18:53:41'),(2,'label34','ITEM','129','ACTIVE','root','2007-08-03 18:53:46','root','2007-08-03 18:53:46'),(2,'label35','ITEM','79','ACTIVE','root','2007-08-03 18:52:34','root','2007-08-03 18:52:34'),(2,'label36','ITEM','80','ACTIVE','root','2007-08-03 18:52:36','root','2007-08-03 18:52:36'),(2,'label37','ITEM','81','ACTIVE','root','2007-08-03 18:52:38','root','2007-08-03 18:52:38'),(2,'label38','ITEM','82','ACTIVE','root','2007-08-03 18:52:39','root','2007-08-03 18:52:39'),(2,'label39','ITEM','83','ACTIVE','root','2007-08-03 18:52:42','root','2007-08-03 18:52:42'),(2,'label40','ITEM','84','ACTIVE','root','2007-08-03 18:52:45','root','2007-08-03 18:52:45'),(2,'label41','ITEM','112','ACTIVE','root','2007-08-03 18:53:03','root','2007-08-03 18:53:03'),(2,'label42','ITEM','57','ACTIVE','root','2007-08-03 18:52:11','root','2007-08-03 18:52:11'),(2,'label43','ITEM','58','ACTIVE','root','2007-08-03 18:52:13','root','2007-08-03 18:52:13'),(2,'label44','ITEM','59','ACTIVE','root','2007-08-03 18:52:14','root','2007-08-03 18:52:14'),(2,'label45','ITEM','60','ACTIVE','root','2007-08-03 18:52:16','root','2007-08-03 18:52:16'),(2,'label46','ITEM','61','ACTIVE','root','2007-08-03 18:52:18','root','2007-08-03 18:52:18'),(2,'label47','ITEM','62','ACTIVE','root','2007-08-03 18:52:20','root','2007-08-03 18:52:20'),(2,'label48','ITEM','113','ACTIVE','root','2007-08-03 18:53:06','root','2007-08-03 18:53:06'),(2,'p1b1','ITEM','85','ACTIVE','root','2007-07-31 10:26:42','root','2007-07-31 10:26:42'),(2,'p1b10','ITEM','98','ACTIVE','root','2007-07-31 10:27:19','root','2007-07-31 10:27:19'),(2,'p1b11','ITEM','99','ACTIVE','root','2007-07-31 10:27:21','root','2007-07-31 10:27:21'),(2,'p1b12','ITEM','100','ACTIVE','root','2007-07-31 10:27:22','root','2007-07-31 10:27:22'),(2,'p1b13','ITEM','101','ACTIVE','root','2007-07-31 10:27:24','root','2007-07-31 10:27:24'),(2,'p1b14','ITEM','103','ACTIVE','root','2007-07-31 10:27:28','root','2007-07-31 10:27:28'),(2,'p1b15','ITEM','104','ACTIVE','root','2007-07-31 10:27:32','root','2007-07-31 10:27:32'),(2,'p1b16','ITEM','105','ACTIVE','root','2007-07-31 10:27:35','root','2007-07-31 10:27:35'),(2,'p1b17','ITEM','107','ACTIVE','root','2007-07-31 10:27:38','root','2007-07-31 10:27:38'),(2,'p1b18','ITEM','108','ACTIVE','root','2007-07-31 10:27:40','root','2007-07-31 10:27:40'),(2,'p1b19','ITEM','109','ACTIVE','root','2007-07-31 10:27:42','root','2007-07-31 10:27:42'),(2,'p1b2','ITEM','86','ACTIVE','root','2007-07-31 10:26:44','root','2007-07-31 10:26:44'),(2,'p1b20','ITEM','110','ACTIVE','root','2007-07-31 10:27:44','root','2007-07-31 10:27:44'),(2,'p1b3','ITEM','87','ACTIVE','root','2007-07-31 10:26:46','root','2007-07-31 10:26:46'),(2,'p1b4','ITEM','88','ACTIVE','root','2007-07-31 10:26:49','root','2007-07-31 10:26:49'),(2,'p1b5','ITEM','89','ACTIVE','root','2007-07-31 10:26:57','root','2007-07-31 10:26:57'),(2,'p1b6','ITEM','90','ACTIVE','root','2007-07-31 10:27:07','root','2007-07-31 10:27:07'),(2,'p1b7','ITEM','91','ACTIVE','root','2007-07-31 10:27:08','root','2007-07-31 10:27:08'),(2,'p1b8','ITEM','92','ACTIVE','root','2007-07-31 10:27:10','root','2007-07-31 10:27:10'),(2,'p1b9','ITEM','93','ACTIVE','root','2007-07-31 10:27:12','root','2007-07-31 10:27:12'),(2,'p2b1','ITEM','28','ACTIVE','root','2007-07-31 10:23:10','root','2007-07-31 10:23:10'),(2,'p2b10','ITEM','42','ACTIVE','root','2007-07-31 10:23:51','root','2007-07-31 10:23:51'),(2,'p2b11','ITEM','43','ACTIVE','root','2007-07-31 10:23:53','root','2007-07-31 10:23:53'),(2,'p2b12','ITEM','44','ACTIVE','root','2007-07-31 10:23:55','root','2007-07-31 10:23:55'),(2,'p2b13','ITEM','45','ACTIVE','root','2007-07-31 10:23:57','root','2007-07-31 10:23:57'),(2,'p2b14','ITEM','46','ACTIVE','root','2007-07-31 10:24:00','root','2007-07-31 10:24:00'),(2,'p2b15','ITEM','49','ACTIVE','root','2007-07-31 10:24:07','root','2007-07-31 10:24:07'),(2,'p2b16','ITEM','51','ACTIVE','root','2007-07-31 10:24:27','root','2007-07-31 10:24:27'),(2,'p2b17','ITEM','52','ACTIVE','root','2007-07-31 10:24:30','root','2007-07-31 10:24:30'),(2,'p2b18','ITEM','53','ACTIVE','root','2007-07-31 10:24:32','root','2007-07-31 10:24:32'),(2,'p2b19','ITEM','54','ACTIVE','root','2007-07-31 10:24:34','root','2007-07-31 10:24:34'),(2,'p2b2','ITEM','30','ACTIVE','root','2007-07-31 10:23:14','root','2007-07-31 10:23:14'),(2,'p2b20','ITEM','50','ACTIVE','root','2007-07-31 10:24:50','root','2007-07-31 10:24:50'),(2,'p2b21','ITEM','55','ACTIVE','root','2007-07-31 10:25:01','root','2007-07-31 10:25:01'),(2,'p2b22','ITEM','57','ACTIVE','root','2007-07-31 10:25:05','root','2007-07-31 10:25:05'),(2,'p2b23','ITEM','58','ACTIVE','root','2007-07-31 10:25:07','root','2007-07-31 10:25:07'),(2,'p2b24','ITEM','59','ACTIVE','root','2007-07-31 10:25:09','root','2007-07-31 10:25:09'),(2,'p2b25','ITEM','60','ACTIVE','root','2007-07-31 10:25:12','root','2007-07-31 10:25:12'),(2,'p2b26','ITEM','61','ACTIVE','root','2007-07-31 10:25:13','root','2007-07-31 10:25:13'),(2,'p2b27','ITEM','62','ACTIVE','root','2007-07-31 10:25:15','root','2007-07-31 10:25:15'),(2,'p2b28','ITEM','63','ACTIVE','root','2007-07-31 10:25:19','root','2007-07-31 10:25:19'),(2,'p2b29','ITEM','64','ACTIVE','root','2007-07-31 10:25:21','root','2007-07-31 10:25:21'),(2,'p2b3','ITEM','31','ACTIVE','root','2007-07-31 10:23:21','root','2007-07-31 10:23:21'),(2,'p2b30','ITEM','66','ACTIVE','root','2007-07-31 10:25:26','root','2007-07-31 10:25:26'),(2,'p2b31','ITEM','68','ACTIVE','root','2007-07-31 10:25:31','root','2007-07-31 10:25:31'),(2,'p2b32','ITEM','69','ACTIVE','root','2007-07-31 10:25:34','root','2007-07-31 10:25:34'),(2,'p2b33','ITEM','70','ACTIVE','root','2007-07-31 10:25:35','root','2007-07-31 10:25:35'),(2,'p2b34','ITEM','71','ACTIVE','root','2007-07-31 10:25:36','root','2007-07-31 10:25:36'),(2,'p2b35','ITEM','72','ACTIVE','root','2007-07-31 10:25:40','root','2007-07-31 10:25:40'),(2,'p2b36','ITEM','73','ACTIVE','root','2007-07-31 10:25:42','root','2007-07-31 10:25:42'),(2,'p2b37','ITEM','75','ACTIVE','root','2007-07-31 10:25:44','root','2007-07-31 10:25:44'),(2,'p2b38','ITEM','78','ACTIVE','root','2007-07-31 10:25:48','root','2007-07-31 10:25:48'),(2,'p2b39','ITEM','76','ACTIVE','root','2007-07-31 10:25:51','root','2007-07-31 10:25:51'),(2,'p2b4','ITEM','32','ACTIVE','root','2007-07-31 10:23:24','root','2007-07-31 10:23:24'),(2,'p2b40','ITEM','77','ACTIVE','root','2007-07-31 10:25:52','root','2007-07-31 10:25:52'),(2,'p2b41','ITEM','74','ACTIVE','root','2007-07-31 10:25:54','root','2007-07-31 10:25:54'),(2,'p2b42','ITEM','65','ACTIVE','root','2007-07-31 10:26:21','root','2007-07-31 10:26:21'),(2,'p2b5','ITEM','33','ACTIVE','root','2007-07-31 10:23:26','root','2007-07-31 10:23:26'),(2,'p2b6','ITEM','35','ACTIVE','root','2007-07-31 10:23:31','root','2007-07-31 10:23:31'),(2,'p2b7','ITEM','37','ACTIVE','root','2007-07-31 10:23:34','root','2007-07-31 10:23:34'),(2,'p2b8','ITEM','39','ACTIVE','root','2007-07-31 10:23:41','root','2007-07-31 10:23:41'),(2,'p2b9','ITEM','40','ACTIVE','root','2007-07-31 10:23:48','root','2007-07-31 10:23:48'),(2,'p3b1','ITEM','191','ACTIVE','root','2007-08-01 20:28:20','root','2007-08-01 20:28:20'),(2,'p3b10','ITEM','183','ACTIVE','root','2007-08-01 20:28:54','root','2007-08-01 20:28:54'),(2,'p3b11','ITEM','180','ACTIVE','root','2007-08-01 20:28:58','root','2007-08-01 20:28:58'),(2,'p3b12','ITEM','179','ACTIVE','root','2007-08-01 20:28:59','root','2007-08-01 20:28:59'),(2,'p3b13','ITEM','173','ACTIVE','root','2007-08-01 20:29:13','root','2007-08-01 20:29:13'),(2,'p3b14','ITEM','172','ACTIVE','root','2007-08-01 20:29:15','root','2007-08-01 20:29:15'),(2,'p3b15','ITEM','168','ACTIVE','root','2007-08-01 20:29:19','root','2007-08-01 20:29:19'),(2,'p3b16','ITEM','169','ACTIVE','root','2007-08-01 20:29:21','root','2007-08-01 20:29:21'),(2,'p3b17','ITEM','176','ACTIVE','root','2007-08-01 20:29:26','root','2007-08-01 20:29:26'),(2,'p3b18','ITEM','165','ACTIVE','root','2007-08-01 20:29:40','root','2007-08-01 20:29:40'),(2,'p3b19','ITEM','164','ACTIVE','root','2007-08-01 20:29:38','root','2007-08-01 20:29:38'),(2,'p3b2','ITEM','192','ACTIVE','root','2007-08-01 20:28:27','root','2007-08-01 20:28:27'),(2,'p3b20','ITEM','152','ACTIVE','root','2007-08-01 20:29:33','root','2007-08-01 20:29:33'),(2,'p3b21','ITEM','151','ACTIVE','root','2007-08-01 20:29:32','root','2007-08-01 20:29:32'),(2,'p3b22','ITEM','184','ACTIVE','root','2007-08-01 20:29:49','root','2007-08-01 20:29:49'),(2,'p3b23','ITEM','177','ACTIVE','root','2007-08-01 20:29:51','root','2007-08-01 20:29:51'),(2,'p3b24','ITEM','178','ACTIVE','root','2007-08-01 20:29:52','root','2007-08-01 20:29:52'),(2,'p3b25','ITEM','181','ACTIVE','root','2007-08-01 20:29:54','root','2007-08-01 20:29:54'),(2,'p3b26','ITEM','189','ACTIVE','root','2007-08-01 20:30:00','root','2007-08-01 20:30:00'),(2,'p3b27','ITEM','202','ACTIVE','root','2007-08-01 20:30:07','root','2007-08-01 20:30:07'),(2,'p3b28','ITEM','203','ACTIVE','root','2007-08-01 20:30:37','root','2007-08-01 20:30:37'),(2,'p3b3','ITEM','193','ACTIVE','root','2007-08-01 20:28:30','root','2007-08-01 20:28:30'),(2,'p3b39','ITEM','141','ACTIVE','root','2007-08-01 20:31:31','root','2007-08-01 20:31:31'),(2,'p3b4','ITEM','194','ACTIVE','root','2007-08-01 20:28:32','root','2007-08-01 20:28:32'),(2,'p3b40','ITEM','140','ACTIVE','root','2007-08-01 20:31:28','root','2007-08-01 20:31:28'),(2,'p3b41','ITEM','200','ACTIVE','root','2007-08-01 20:30:43','root','2007-08-01 20:30:43'),(2,'p3b42','ITEM','199','ACTIVE','root','2007-08-01 20:30:39','root','2007-08-01 20:30:39'),(2,'p3b5','ITEM','195','ACTIVE','root','2007-08-01 20:28:34','root','2007-08-01 20:28:34'),(2,'p3b6','ITEM','196','ACTIVE','root','2007-08-01 20:28:35','root','2007-08-01 20:28:35'),(2,'p3b7','ITEM','197','ACTIVE','root','2007-08-01 20:28:37','root','2007-08-01 20:28:37'),(2,'p3b8','ITEM','198','ACTIVE','root','2007-08-01 20:28:40','root','2007-08-01 20:28:40'),(2,'p3b9','ITEM','188','ACTIVE','root','2007-08-01 20:28:50','root','2007-08-01 20:28:50'),(2,'p4b1','ITEM','11','ACTIVE','root','2007-08-01 20:27:52','root','2007-08-01 20:27:52'),(2,'p4b10','ITEM','146','ACTIVE','root','2007-08-01 20:26:21','root','2007-08-01 20:26:21'),(2,'p4b11','ITEM','147','ACTIVE','root','2007-08-01 20:26:19','root','2007-08-01 20:26:19'),(2,'p4b12','ITEM','148','ACTIVE','root','2007-08-01 20:26:17','root','2007-08-01 20:26:17'),(2,'p4b13','ITEM','149','ACTIVE','root','2007-08-01 20:26:15','root','2007-08-01 20:26:15'),(2,'p4b14','ITEM','150','ACTIVE','root','2007-08-01 20:26:13','root','2007-08-01 20:26:13'),(2,'p4b15','ITEM','185','ACTIVE','root','2007-08-01 20:25:17','root','2007-08-01 20:25:17'),(2,'p4b16','ITEM','156','ACTIVE','root','2007-08-01 20:25:48','root','2007-08-01 20:25:48'),(2,'p4b17','ITEM','155','ACTIVE','root','2007-08-01 20:25:57','root','2007-08-01 20:25:57'),(2,'p4b18','ITEM','171','ACTIVE','root','2007-08-01 20:25:31','root','2007-08-01 20:25:31'),(2,'p4b19','ITEM','157','ACTIVE','root','2007-08-01 20:25:49','root','2007-08-01 20:25:49'),(2,'p4b2','ITEM','8','ACTIVE','root','2007-08-01 20:27:48','root','2007-08-01 20:27:48'),(2,'p4b20','ITEM','154','ACTIVE','root','2007-08-01 20:25:59','root','2007-08-01 20:25:59'),(2,'p4b21','ITEM','153','ACTIVE','root','2007-08-01 20:26:00','root','2007-08-01 20:26:00'),(2,'p4b22','ITEM','19','ACTIVE','root','2007-08-01 20:27:33','root','2007-08-01 20:27:33'),(2,'p4b23','ITEM','22','ACTIVE','root','2007-08-01 20:27:26','root','2007-08-01 20:27:26'),(2,'p4b24','ITEM','23','ACTIVE','root','2007-08-01 20:27:25','root','2007-08-01 20:27:25'),(2,'p4b25','ITEM','20','ACTIVE','root','2007-08-01 20:27:31','root','2007-08-01 20:27:31'),(2,'p4b26','ITEM','21','ACTIVE','root','2007-08-01 20:27:28','root','2007-08-01 20:27:28'),(2,'p4b27','ITEM','26','ACTIVE','root','2007-08-01 20:27:21','root','2007-08-01 20:27:21'),(2,'p4b28','ITEM','27','ACTIVE','root','2007-08-01 20:27:19','root','2007-08-01 20:27:19'),(2,'p4b29','ITEM','25','ACTIVE','root','2007-08-01 20:27:16','root','2007-08-01 20:27:16'),(2,'p4b3','ITEM','5','ACTIVE','root','2007-08-01 20:27:45','root','2007-08-01 20:27:45'),(2,'p4b30','ITEM','135','ACTIVE','root','2007-08-01 20:26:46','root','2007-08-01 20:26:46'),(2,'p4b31','ITEM','137','ACTIVE','root','2007-08-01 20:26:44','root','2007-08-01 20:26:44'),(2,'p4b32','ITEM','133','ACTIVE','root','2007-08-01 20:26:51','root','2007-08-01 20:26:51'),(2,'p4b33','ITEM','134','ACTIVE','root','2007-08-01 20:26:49','root','2007-08-01 20:26:49'),(2,'p4b34','ITEM','138','ACTIVE','root','2007-08-01 20:26:41','root','2007-08-01 20:26:41'),(2,'p4b35','ITEM','139','ACTIVE','root','2007-08-01 20:26:39','root','2007-08-01 20:26:39'),(2,'p4b36','ITEM','144','ACTIVE','root','2007-08-01 20:26:27','root','2007-08-01 20:26:27'),(2,'p4b37','ITEM','175','ACTIVE','root','2007-08-01 20:25:25','root','2007-08-01 20:25:25'),(2,'p4b38','ITEM','187','ACTIVE','root','2007-08-01 20:25:13','root','2007-08-01 20:25:13'),(2,'p4b39','ITEM','170','ACTIVE','root','2007-08-01 20:25:34','root','2007-08-01 20:25:34'),(2,'p4b4','ITEM','3','ACTIVE','root','2007-08-07 10:07:51','root','2007-08-07 10:07:51'),(2,'p4b40','ITEM','174','ACTIVE','root','2007-08-01 20:25:26','root','2007-08-01 20:25:26'),(2,'p4b41','ITEM','190','ACTIVE','root','2007-08-01 20:25:10','root','2007-08-01 20:25:10'),(2,'p4b42','ITEM','204','ACTIVE','root','2007-08-04 13:38:37','root','2007-08-04 13:38:37'),(2,'p4b5','ITEM','4','ACTIVE','root','2007-08-01 20:27:42','root','2007-08-01 20:27:42'),(2,'p4b6','ITEM','7','ACTIVE','root','2007-08-01 20:27:40','root','2007-08-01 20:27:40'),(2,'p4b7','ITEM','18','ACTIVE','root','2007-08-01 20:27:36','root','2007-08-01 20:27:36'),(2,'p4b8','ITEM','142','ACTIVE','root','2007-08-01 20:26:32','root','2007-08-01 20:26:32'),(2,'p4b9','ITEM','145','ACTIVE','root','2007-08-01 20:26:23','root','2007-08-01 20:26:23'),(3,'F7','ITEM','193','ACTIVE','JUN','2007-09-21 10:26:36','JUN','2007-09-21 10:26:36'),(3,'p1b1','ITEM','116','ACTIVE','root','2007-08-13 09:17:03','root','2007-08-13 09:17:03'),(3,'p1b10','ITEM','125','ACTIVE','root','2007-08-13 09:17:34','root','2007-08-13 09:17:34'),(3,'p1b11','ITEM','126','ACTIVE','root','2007-08-13 09:17:38','root','2007-08-13 09:17:38'),(3,'p1b12','ITEM','127','ACTIVE','root','2007-08-13 09:17:41','root','2007-08-13 09:17:41'),(3,'p1b2','ITEM','117','ACTIVE','root','2007-08-13 09:17:07','root','2007-08-13 09:17:07'),(3,'p1b3','ITEM','118','ACTIVE','root','2007-08-13 09:17:09','root','2007-08-13 09:17:09'),(3,'p1b4','ITEM','119','ACTIVE','root','2007-08-13 09:17:10','root','2007-08-13 09:17:10'),(3,'p1b5','ITEM','120','ACTIVE','root','2007-08-13 09:17:12','root','2007-08-13 09:17:12'),(3,'p1b6','ITEM','121','ACTIVE','root','2007-08-13 09:17:16','root','2007-08-13 09:17:16'),(3,'p1b7','ITEM','6','ACTIVE','MALOU','2007-09-22 18:14:56','MALOU','2007-09-22 18:14:56'),(3,'p1b8','ITEM','123','ACTIVE','root','2007-08-13 09:17:19','root','2007-08-13 09:17:19'),(3,'p1b9','ITEM','124','ACTIVE','root','2007-08-13 09:17:28','root','2007-08-13 09:17:28'),(3,'p2b1','ITEM','15','ACTIVE','root','2007-09-12 17:28:01','root','2007-09-12 17:28:01'),(3,'p2b2','ITEM','13','ACTIVE','root','2007-09-12 17:28:05','root','2007-09-12 17:28:05'),(3,'p2b3','ITEM','14','ACTIVE','root','2007-09-12 17:28:06','root','2007-09-12 17:28:06'),(3,'p3b1','ITEM','1','ACTIVE','root','2007-07-26 09:52:01','root','2007-07-26 09:52:01'),(3,'p3b11','ITEM','5','ACTIVE','root','2007-07-26 09:52:10','root','2007-07-26 09:52:10'),(3,'p3b12','ITEM','6','ACTIVE','root','2007-07-26 09:52:11','root','2007-07-26 09:52:11'),(3,'p3b13','ITEM','188','ACTIVE','root','2007-07-26 09:55:35','root','2007-07-26 09:55:35'),(3,'p3b16','ITEM','7','ACTIVE','root','2007-07-26 09:52:13','root','2007-07-26 09:52:13'),(3,'p3b17','ITEM','8','ACTIVE','root','2007-07-26 09:52:16','root','2007-07-26 09:52:16'),(3,'p3b18','ITEM','189','ACTIVE','root','2007-07-26 09:55:36','root','2007-07-26 09:55:36'),(3,'p3b2','ITEM','2','ACTIVE','root','2007-07-26 09:52:03','root','2007-07-26 09:52:03'),(3,'p3b3','ITEM','9','ACTIVE','root','2007-07-26 09:52:29','root','2007-07-26 09:52:29'),(3,'p3b4','ITEM','10','ACTIVE','root','2007-07-26 09:52:30','root','2007-07-26 09:52:30'),(3,'p3b40','ITEM','112','ACTIVE','LOURDES','2007-09-03 20:34:45','LOURDES','2007-09-03 20:34:45'),(3,'p3b41','ITEM','113','ACTIVE','LOURDES','2007-09-03 20:34:43','LOURDES','2007-09-03 20:34:43'),(3,'p3b42','ITEM','114','ACTIVE','LOURDES','2007-09-03 20:34:40','LOURDES','2007-09-03 20:34:40'),(3,'p4b1','ITEM','32','ACTIVE','root','2007-08-11 13:47:52','root','2007-08-11 13:47:52'),(3,'p4b10','ITEM','41','ACTIVE','root','2007-08-11 13:48:14','root','2007-08-11 13:48:14'),(3,'p4b11','ITEM','42','ACTIVE','root','2007-08-11 13:48:17','root','2007-08-11 13:48:17'),(3,'p4b12','ITEM','43','ACTIVE','root','2007-08-11 13:48:23','root','2007-08-11 13:48:23'),(3,'p4b13','ITEM','44','ACTIVE','root','2007-08-11 13:48:24','root','2007-08-11 13:48:24'),(3,'p4b14','ITEM','45','ACTIVE','root','2007-08-11 13:48:27','root','2007-08-11 13:48:27'),(3,'p4b15','ITEM','46','ACTIVE','root','2007-08-11 13:48:28','root','2007-08-11 13:48:28'),(3,'p4b16','ITEM','49','ACTIVE','root','2007-08-11 13:48:37','root','2007-08-11 13:48:37'),(3,'p4b17','ITEM','50','ACTIVE','root','2007-08-11 13:48:39','root','2007-08-11 13:48:39'),(3,'p4b18','ITEM','47','ACTIVE','root','2007-08-11 13:48:34','root','2007-08-11 13:48:34'),(3,'p4b19','ITEM','48','ACTIVE','root','2007-08-11 13:48:35','root','2007-08-11 13:48:35'),(3,'p4b2','ITEM','33','ACTIVE','root','2007-08-11 13:47:54','root','2007-08-11 13:47:54'),(3,'p4b20','ITEM','51','ACTIVE','root','2007-08-11 13:48:48','root','2007-08-11 13:48:48'),(3,'p4b21','ITEM','52','ACTIVE','root','2007-08-11 13:48:50','root','2007-08-11 13:48:50'),(3,'p4b22','ITEM','53','ACTIVE','root','2007-08-11 13:48:51','root','2007-08-11 13:48:51'),(3,'p4b23','ITEM','56','ACTIVE','root','2007-08-11 13:49:05','root','2007-08-11 13:49:05'),(3,'p4b24','ITEM','57','ACTIVE','root','2007-08-11 13:49:07','root','2007-08-11 13:49:07'),(3,'p4b25','ITEM','54','ACTIVE','root','2007-08-11 13:48:59','root','2007-08-11 13:48:59'),(3,'p4b26','ITEM','55','ACTIVE','root','2007-08-11 13:49:02','root','2007-08-11 13:49:02'),(3,'p4b27','ITEM','58','ACTIVE','root','2007-08-11 13:49:08','root','2007-08-11 13:49:08'),(3,'p4b28','ITEM','59','ACTIVE','root','2007-08-11 13:49:09','root','2007-08-11 13:49:09'),(3,'p4b29','ITEM','60','ACTIVE','root','2007-08-11 13:49:10','root','2007-08-11 13:49:10'),(3,'p4b3','ITEM','34','ACTIVE','root','2007-08-11 13:47:56','root','2007-08-11 13:47:56'),(3,'p4b30','ITEM','63','ACTIVE','root','2007-08-11 13:49:18','root','2007-08-11 13:49:18'),(3,'p4b32','ITEM','61','ACTIVE','root','2007-08-11 13:49:12','root','2007-08-11 13:49:12'),(3,'p4b33','ITEM','62','ACTIVE','root','2007-08-11 13:49:14','root','2007-08-11 13:49:14'),(3,'p4b4','ITEM','35','ACTIVE','root','2007-08-11 13:47:58','root','2007-08-11 13:47:58'),(3,'p4b5','ITEM','36','ACTIVE','root','2007-08-11 13:48:04','root','2007-08-11 13:48:04'),(3,'p4b6','ITEM','37','ACTIVE','root','2007-08-11 13:48:06','root','2007-08-11 13:48:06'),(3,'p4b7','ITEM','38','ACTIVE','root','2007-08-11 13:48:08','root','2007-08-11 13:48:08'),(3,'p4b8','ITEM','39','ACTIVE','root','2007-08-11 13:48:10','root','2007-08-11 13:48:10'),(3,'p4b9','ITEM','40','ACTIVE','root','2007-08-11 13:48:12','root','2007-08-11 13:48:12');
/*!40000 ALTER TABLE `button_setup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cashiers`
--

DROP TABLE IF EXISTS `cashiers`;
CREATE TABLE `cashiers` (
  `terminalid` int(4) NOT NULL,
  `terminal` varchar(30) default NULL,
  `cashierid` varchar(10) default NULL,
  `shiftcode` varchar(10) default NULL,
  `openingbalance` double(12,2) default '0.00',
  `openingadjustment` double(12,2) default '0.00',
  `beginningbalance` double(12,2) default '0.00',
  `chargeinamount` double(12,2) default '0.00',
  `cash` double(12,2) default '0.00',
  `creditcard` double(12,2) default '0.00',
  `cheque` double(12,2) default '0.00',
  `others` double(12,2) default '0.00',
  `adjustment` double(12,2) default '0.00',
  `amountremitted` double(12,2) default '0.00',
  `netamount` double(12,2) default '0.00',
  `restaurantid` int(5) default NULL,
  `STATUS` enum('OPEN','CLOSE') default 'CLOSE',
  `CREATETIME` datetime default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2001-01-01 01:01:01',
  `UPDATEDBY` varchar(20) default NULL,
  `REMARKS` text,
  PRIMARY KEY  (`terminalid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cashiers`
--

LOCK TABLES `cashiers` WRITE;
/*!40000 ALTER TABLE `cashiers` DISABLE KEYS */;
INSERT INTO `cashiers` VALUES (1,'Jinisys Cafe','1','1',0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1,'CLOSE','2001-01-01 01:01:01','ADMIN','2010-05-20 15:16:40','root','');
/*!40000 ALTER TABLE `cashiers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cashiers_logs`
--

DROP TABLE IF EXISTS `cashiers_logs`;
CREATE TABLE `cashiers_logs` (
  `transactiondate` date NOT NULL default '2006-01-01',
  `type` enum('OPEN','CLOSE') NOT NULL default 'OPEN',
  `terminalid` int(4) NOT NULL,
  `cashierid` varchar(10) default NULL,
  `shiftcode` varchar(10) NOT NULL,
  `openingbalance` double(12,2) default '0.00',
  `openingadjustment` double(12,2) default '0.00',
  `beginningbalance` double(12,2) default '0.00',
  `chargeinamount` double(12,2) default '0.00',
  `cash` double(12,2) default '0.00',
  `creditcard` double(12,2) default '0.00',
  `cheque` double(12,2) default '0.00',
  `others` double(12,2) default '0.00',
  `adjustment` double(12,2) default '0.00',
  `amountremitted` double(12,2) default '0.00',
  `netamount` double(12,2) default '0.00',
  `restaurantid` int(5) default NULL,
  `CREATETIME` datetime default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2001-01-01 01:01:01',
  `UPDATEDBY` varchar(20) default NULL,
  `REMARKS` text,
  PRIMARY KEY  (`transactiondate`,`type`,`terminalid`,`shiftcode`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cashiers_logs`
--

LOCK TABLES `cashiers_logs` WRITE;
/*!40000 ALTER TABLE `cashiers_logs` DISABLE KEYS */;
INSERT INTO `cashiers_logs` VALUES ('2010-05-20','CLOSE',1,'1','1',0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,1,'2010-05-20 15:16:40','root','2010-05-20 15:16:40','root','');
/*!40000 ALTER TABLE `cashiers_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
CREATE TABLE `company` (
  `companyid` varchar(20) NOT NULL,
  `companycode` varchar(50) default NULL,
  `companyname` varchar(150) default NULL,
  `companyURL` varchar(100) default NULL,
  `contactperson` varchar(50) default NULL,
  `designation` varchar(30) default NULL,
  `street1` varchar(50) default NULL,
  `city1` varchar(50) default NULL,
  `country1` varchar(30) default NULL,
  `zip1` varchar(10) default NULL,
  `street2` varchar(50) default NULL,
  `city2` varchar(30) default NULL,
  `country2` varchar(30) default NULL,
  `zip2` varchar(10) default NULL,
  `street3` varchar(50) default NULL,
  `city3` varchar(30) default NULL,
  `country3` varchar(30) default NULL,
  `zip3` varchar(10) default NULL,
  `email1` varchar(50) default NULL,
  `email2` varchar(50) default NULL,
  `email3` varchar(50) default NULL,
  `contactnumber1` varchar(15) default NULL,
  `contactnumber2` varchar(15) default NULL,
  `contactnumber3` varchar(15) default NULL,
  `contacttype1` varchar(15) default NULL,
  `contacttype2` varchar(15) default NULL,
  `contacttype3` varchar(15) default NULL,
  `stateflag` varchar(10) NOT NULL default 'ACTIVE',
  `HOTELID` int(5) NOT NULL default '0',
  `CREATETIME` datetime default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2001-01-01 01:01:01',
  `UPDATEDBY` varchar(20) default NULL,
  PRIMARY KEY  (`companyid`,`HOTELID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `complaint_reasons`
--

DROP TABLE IF EXISTS `complaint_reasons`;
CREATE TABLE `complaint_reasons` (
  `REASON_CODE` varchar(10) NOT NULL,
  `DESCRIPTION` text,
  `STATUS` varchar(10) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-08-08 00:00:00',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`REASON_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `complaint_reasons`
--

LOCK TABLES `complaint_reasons` WRITE;
/*!40000 ALTER TABLE `complaint_reasons` DISABLE KEYS */;
INSERT INTO `complaint_reasons` VALUES ('1','Missing Items','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00'),('2','Wrong Assembled Orders','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00'),('3','Delay in delivery leadtime','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00'),('4','Food safety','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00');
/*!40000 ALTER TABLE `complaint_reasons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `complaints`
--

DROP TABLE IF EXISTS `complaints`;
CREATE TABLE `complaints` (
  `COMPLAINT_ID` bigint(15) NOT NULL auto_increment,
  `ORDER_ID` varchar(100) default NULL,
  `CUSTOMER_ID` varchar(100) default NULL,
  `REASON_CODE` varchar(10) default NULL,
  `REMARKS` text,
  `STATUS` varchar(10) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-01-01 00:00:01',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`COMPLAINT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `complaints`
--

LOCK TABLES `complaints` WRITE;
/*!40000 ALTER TABLE `complaints` DISABLE KEYS */;
/*!40000 ALTER TABLE `complaints` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `creditcardtype`
--

DROP TABLE IF EXISTS `creditcardtype`;
CREATE TABLE `creditcardtype` (
  `creditCardId` varchar(5) NOT NULL,
  `creditCardCode` varchar(100) default NULL,
  `cardDescription` varchar(200) default NULL,
  `statusFlag` enum('ACTIVE','DELETED') default 'ACTIVE',
  `createdBy` varchar(50) default NULL,
  `createTime` datetime default '2008-08-08 08:08:08',
  `updatedBy` varchar(50) default NULL,
  `updateTime` datetime default '2008-08-08 08:08:08',
  PRIMARY KEY  (`creditCardId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `creditcardtype`
--

LOCK TABLES `creditcardtype` WRITE;
/*!40000 ALTER TABLE `creditcardtype` DISABLE KEYS */;
INSERT INTO `creditcardtype` VALUES ('1','VISA','VISA','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08'),('10','SOLO','SOLO','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08'),('11','ENROUTE','ENROUTE','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08'),('2','MASTERCARD','MASTERCARD','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08'),('3','AMERICAN EXPRESS','AMERICAN EXPRESS','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08'),('4','DINERS CLUB','DINERS CLUB','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08'),('5','JCB','JCB','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08'),('6','CARTE BLANCHE','CARTE BLANCE','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08'),('7','AUSTRALIAN BANKCARD','AUSTRALIAN BANKCARD','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08'),('8','DISCOVER','DISCOVER','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08'),('9','SWITCH','SWITCH','ACTIVE','ADMIN','2008-08-08 08:08:08','ADMIN','2008-08-08 08:08:08');
/*!40000 ALTER TABLE `creditcardtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `currencycodes`
--

DROP TABLE IF EXISTS `currencycodes`;
CREATE TABLE `currencycodes` (
  `currencycode` varchar(10) NOT NULL,
  `currency` varchar(20) default NULL,
  `conversionrate` decimal(12,2) NOT NULL default '0.00',
  `stateFlag` varchar(20) default NULL,
  `HOTELID` int(5) NOT NULL default '0',
  `CREATETIME` datetime default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2001-01-01 01:01:01',
  `UPDATEDBY` varchar(20) default NULL,
  PRIMARY KEY  (`currencycode`,`HOTELID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `currencycodes`
--

LOCK TABLES `currencycodes` WRITE;
/*!40000 ALTER TABLE `currencycodes` DISABLE KEYS */;
INSERT INTO `currencycodes` VALUES ('PHP','PHILIPPINES PESO','1.00','ACTIVE',1,'2001-01-01 01:01:01','ADMIN','2006-10-17 14:25:27','ADMIN'),('USD','US DOLLAR','50.00','ACTIVE',1,'2001-01-01 01:01:01','ADMIN','2006-12-28 17:34:57','ADMIN'),('YEN','JAPANESE YEN','0.77','ACTIVE',1,'2001-01-01 01:01:01','ADMIN','2006-11-11 13:30:14','ADMIN');
/*!40000 ALTER TABLE `currencycodes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
CREATE TABLE `customers` (
  `CUSTOMER_ID` varchar(100) NOT NULL,
  `CUSTOMER_TYPE` varchar(30) default NULL,
  `NAME` varchar(100) default NULL,
  `ACCOUNT_NAME` varchar(100) default NULL,
  `LAST_NAME` varchar(100) default NULL,
  `FIRST_NAME` varchar(100) default NULL,
  `PHONE_NO` varchar(100) default NULL,
  `ADDRESS1` text,
  `ADDRESS2` text,
  `CITY` varchar(100) default NULL,
  `PROVINCE` varchar(100) default NULL,
  `POSTAL_CODE` varchar(30) default NULL,
  `COUNTRY` varchar(100) default NULL,
  `TAX_REG_NO` varchar(100) default NULL,
  `TAXPAYER_ID` varchar(100) default NULL,
  `TYPE` varchar(100) default NULL,
  `CATEGORY` varchar(100) default NULL,
  `CLASS` varchar(100) default NULL,
  `STATUS` varchar(10) default 'ACTIVE',
  `HOTELID` int(5) default '1',
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-08-08 00:00:00',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`CUSTOMER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES ('BROADCOM','PERSON','BROADCOM NETWORKS, INC','BROADCOM','BALAGOSA','JOJO','2320485','GROUND FLR. CEBU HOLDINGS CENTER CARDINAL ROSALES AVE','6/F CEBU HOLDINGS CENTER CARDINAL ROSALES AVE','CEBU CITY','CEBU','6000','PHILES','','','','','','ACTIVE',1,'','2006-08-08 20:19:19','JINISYS','2006-08-15 21:05:59'),('JINISYS','ORGANIZATION','JINISYS','JINISYS','','','','','','','','','','0000','1234','INTERNAL','','SOFTWARE','ACTIVE',1,'','2006-08-08 16:12:00','','2006-08-08 16:20:58');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee account`
--

DROP TABLE IF EXISTS `employee account`;
CREATE TABLE `employee account` (
  `EMPLOYEE_ID` varchar(15) NOT NULL,
  `CREDIT LIMIT` decimal(12,2) default '10000.00',
  `CHARGE` decimal(12,2) default '0.00',
  `BALANCE` decimal(12,2) default '0.00',
  PRIMARY KEY  (`EMPLOYEE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee account`
--

LOCK TABLES `employee account` WRITE;
/*!40000 ALTER TABLE `employee account` DISABLE KEYS */;
INSERT INTO `employee account` VALUES ('100','10000.00','0.00','10000.00'),('200','10000.00','0.00','10000.00'),('300','10000.00','0.00','10000.00'),('400','10000.00','0.00','10000.00'),('500','10000.00','0.00','10000.00');
/*!40000 ALTER TABLE `employee account` ENABLE KEYS */;
UNLOCK TABLES;

/*!50003 SET @OLD_SQL_MODE=@@SQL_MODE*/;
DELIMITER ;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION" */;;
/*!50003 CREATE */ /*!50017 DEFINER=`root`@`localhost` */ /*!50003 TRIGGER `t_Insert` BEFORE INSERT ON `employee account` FOR EACH ROW begin
set new.balance=new.`credit limit`;
END */;;

/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION" */;;
/*!50003 CREATE */ /*!50017 DEFINER=`root`@`localhost` */ /*!50003 TRIGGER `t_Update` BEFORE UPDATE ON `employee account` FOR EACH ROW begin
set new.balance=new.`credit limit` - new.charge;
END */;;

DELIMITER ;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE */;

--
-- Table structure for table `employee status`
--

DROP TABLE IF EXISTS `employee status`;
CREATE TABLE `employee status` (
  `EMPLOYEE_ID` varchar(10) NOT NULL,
  `NICKNAME` varchar(30) default NULL,
  `STATUS` varchar(20) default NULL,
  PRIMARY KEY  (`EMPLOYEE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee status`
--

LOCK TABLES `employee status` WRITE;
/*!40000 ALTER TABLE `employee status` DISABLE KEYS */;
INSERT INTO `employee status` VALUES ('500','USER5','');
/*!40000 ALTER TABLE `employee status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
CREATE TABLE `employee` (
  `EMPLOYEE_ID` varchar(10) NOT NULL,
  `LASTNAME` varchar(30) default NULL,
  `FIRSTNAME` varchar(30) default NULL,
  `MIDDLENAME` varchar(30) default NULL,
  `NICKNAME` varchar(30) default NULL,
  `POSITION` varchar(20) default NULL,
  `ADDRESS` varchar(200) default NULL,
  `CONTACTNO` varchar(20) default NULL,
  `STATUS` varchar(20) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-01-01 00:00:01',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-01-01 00:00:01',
  `HOTEL_ID` int(5) default '1',
  PRIMARY KEY  (`EMPLOYEE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES ('100','USER1','USER1',' ','USER1','WAITER',' ',' ','ACTIVE','root','2010-05-21 13:52:24','root','2010-05-21 13:52:48',1),('200','USER2','USER2','  ','USER2','KITCHEN',' ',' ','ACTIVE','root','2010-05-21 13:53:15','root','2010-05-21 13:53:15',1),('300','USER3','USER3',' ','USER3','CASHIER',' ',' ','ACTIVE','root','2010-05-21 13:53:31','root','2010-05-21 13:53:31',1),('400','USER4','USER4',' ','USER4','WAITER',' ',' ','ACTIVE','root','2010-05-21 13:53:48','root','2010-05-21 13:53:48',1),('500','USER5','USER5',' ','USER5','KITCHEN CREW',' ',' ','ACTIVE','root','2010-05-21 13:54:07','root','2010-05-21 13:54:07',1);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

/*!50003 SET @OLD_SQL_MODE=@@SQL_MODE*/;
DELIMITER ;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION" */;;
/*!50003 CREATE */ /*!50017 DEFINER=`root`@`localhost` */ /*!50003 TRIGGER `t_InsertEmployee` BEFORE INSERT ON `employee` FOR EACH ROW begin
insert into `employee account` (employee_id) values (new.employee_id);
END */;;

DELIMITER ;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE */;

--
-- Table structure for table `employee_ledger`
--

DROP TABLE IF EXISTS `employee_ledger`;
CREATE TABLE `employee_ledger` (
  `id` int(11) NOT NULL auto_increment,
  `EMPLOYEE_ID` varchar(10) NOT NULL,
  `Date` date default NULL,
  `ORDER_ID` bigint(15) NOT NULL,
  `debit` double(12,2) default '0.00',
  `credit` double(12,2) default '0.00',
  `HOTELID` int(5) NOT NULL default '0',
  `CREATETIME` datetime NOT NULL default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2001-01-01 01:01:01',
  `UPDATEDBY` varchar(20) default NULL,
  `posttoacctng` varchar(1) default NULL,
  `closed` varchar(1) default '0',
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee_ledger`
--

LOCK TABLES `employee_ledger` WRITE;
/*!40000 ALTER TABLE `employee_ledger` DISABLE KEYS */;
/*!40000 ALTER TABLE `employee_ledger` ENABLE KEYS */;
UNLOCK TABLES;

/*!50003 SET @OLD_SQL_MODE=@@SQL_MODE*/;
DELIMITER ;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION" */;;
/*!50003 CREATE */ /*!50017 DEFINER=`root`@`localhost` */ /*!50003 TRIGGER `t_InsertLedger` BEFORE INSERT ON `employee_ledger` FOR EACH ROW begin
update `employee account`
set
charge=charge+new.debit
where employee_id=new.employee_id;
END */;;

DELIMITER ;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE */;

--
-- Table structure for table `food`
--

DROP TABLE IF EXISTS `food`;
CREATE TABLE `food` (
  `FOOD_ID` varchar(10) NOT NULL,
  `FOOD_DESC` varchar(250) default NULL,
  `STATUS` varchar(7) default NULL,
  `CREATETIME` datetime default '2006-01-01 00:00:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2006-01-01 00:00:01',
  `UPDATEDBY` varchar(20) default NULL,
  PRIMARY KEY  (`FOOD_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `food`
--

LOCK TABLES `food` WRITE;
/*!40000 ALTER TABLE `food` DISABLE KEYS */;
/*!40000 ALTER TABLE `food` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `function mapping`
--

DROP TABLE IF EXISTS `function mapping`;
CREATE TABLE `function mapping` (
  `RESTO_ID` int(11) NOT NULL default '1',
  `FUNCTION_ID` varchar(20) NOT NULL,
  `DESCRIPTION` varchar(100) default NULL,
  `OBJECT` varchar(20) default NULL,
  `METHOD` varchar(30) default NULL,
  `COST` decimal(12,2) default NULL,
  `STATUS` varchar(7) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default NULL,
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default NULL,
  PRIMARY KEY  (`RESTO_ID`,`FUNCTION_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `function mapping`
--

LOCK TABLES `function mapping` WRITE;
/*!40000 ALTER TABLE `function mapping` DISABLE KEYS */;
INSERT INTO `function mapping` VALUES (1,'F1','10 % ROOM SERVICE','POS','APPLY_ADDITIONAL','0.10','ACTIVE','','2006-08-08 21:23:28','ADMIN','2006-08-08 21:23:28'),(1,'F10','COMPLIMENTARY ORDER','POS','COMPLIMENTARY','0.00','ACTIVE','root','2007-06-15 12:06:30','root','2007-06-15 12:18:05'),(1,'F11','EX-DEALS','POS','EX-DEAL','0.00','ACTIVE','root','2007-06-15 14:57:25','root','2007-06-15 14:57:25'),(1,'F12','MEAL COUPON','POS','COUPON','0.00','ACTIVE','root','2007-06-15 14:57:04','root','2007-06-15 14:57:04'),(1,'F14','CORKAGE FEE','POS','OPEN_FOOD','0.00','ACTIVE','ADMIN','2006-08-08 21:23:28','ADMIN','2006-08-08 21:23:28'),(1,'F15','COOKING FEE','POS','OPEN_FOOD','0.00','ACTIVE','ADMIN','2006-08-08 21:23:28','ADMIN','2006-08-08 21:23:28'),(1,'F16','EMPLOYEE DISCOUNT','POS','APPLY_DISCOUNT_TRANSACTION','0.15','ACTIVE','root','2009-04-19 11:12:09','root','2009-04-19 11:12:09'),(1,'F17','SR. CITIZEN DISC. AMT.','POS','APPLY_DISCOUNT_AMOUNT','0.00','ACTIVE','ADMIN','2009-09-09 09:09:09','ADMIN','2009-09-09 09:09:09'),(1,'F2','DISCOUNT ITEM','POS','APPLY_DISCOUNT_ITEM','0.00','ACTIVE','ADMIN','2006-08-08 21:23:28','root','2007-07-20 12:33:46'),(1,'F3','DISCOUNT TRANSACTION','POS','APPLY_DISCOUNT_TRANSACTION','0.00','ACTIVE','root','2007-07-26 12:00:32','root','2007-07-26 12:00:32'),(1,'F4','OPEN FOOD','POS','OPEN_FOOD','0.00','ACTIVE','ROOT','2006-08-08 21:23:28','ADMIN','2006-08-08 21:23:28'),(1,'F5','OPEN BEVERAGE','POS','OPEN_BEVERAGE','0.00','ACTIVE','ADMIN','2006-08-08 21:23:28','ADMIN','2006-08-08 21:23:28'),(1,'F6','BANQUET FOOD','POS','BANQUET_FOOD','0.00','ACTIVE','root','2007-06-16 15:32:39','root','2007-06-16 15:32:39'),(1,'F7','BANQUET BEVERAGE','POS','BANQUET_BEVERAGE','0.00','ACTIVE','root','2007-07-03 10:32:44','root','2007-07-03 10:32:44'),(1,'F8','20% ITEM SR. CITIZEN DISC.','POS','APPLY_DISCOUNT_ITEM','0.20','ACTIVE','ADMIN','2006-08-08 21:23:28','root','2007-07-24 20:52:17'),(1,'F9','20% TRANS. SR. CITIZEN DISC.','POS','APPLY_DISCOUNT_TRANSACTION','0.20','ACTIVE','ADMIN','2006-08-08 21:23:28','ADMIN','2006-08-08 21:23:28');
/*!40000 ALTER TABLE `function mapping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group`
--

DROP TABLE IF EXISTS `group`;
CREATE TABLE `group` (
  `RESTO_ID` int(5) NOT NULL default '1',
  `GROUP_ID` varchar(50) NOT NULL,
  `MAINGROUP_ID` varchar(20) default NULL,
  `DESCRIPTION` varchar(100) default NULL,
  `STATUS` varchar(7) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default NULL,
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default NULL,
  PRIMARY KEY  (`RESTO_ID`,`GROUP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `group`
--

LOCK TABLES `group` WRITE;
/*!40000 ALTER TABLE `group` DISABLE KEYS */;
INSERT INTO `group` VALUES (1,'APPETIZERS','FOOD','APPETIZERS','ACTIVE','root','2010-05-21 14:28:41','root','2010-05-21 14:28:41'),(1,'BEER','BEVERAGES','BEERS','ACTIVE','root','2010-05-21 14:28:16','root','2010-05-21 14:28:16'),(1,'BREAKFAST','FOOD','BREAKFAST','ACTIVE','root','2010-05-21 14:25:55','root','2010-05-21 14:25:55'),(1,'BUFFET DINNER','BANQUET','BUFFET DINNER','ACTIVE','root','2010-05-21 14:27:52','root','2010-05-21 14:27:52'),(1,'BUFFET LUNCH','BANQUET','BUFFET LUNCH','ACTIVE','root','2010-05-21 14:27:07','root','2010-05-21 14:27:07'),(1,'CIGARETTES','OTHERS','CIGARETTES','ACTIVE','root','2010-05-21 14:29:24','root','2010-05-21 14:29:24'),(1,'DESSERTS','FOOD','DESSERTS','ACTIVE','root','2010-05-21 14:29:11','root','2010-05-21 14:29:11'),(1,'FRUIT SHAKES','BEVERAGES','SHAKES','ACTIVE','root','2010-10-13 14:04:04','root','2010-10-13 14:04:04'),(1,'JUICE','BEVERAGES','JUICE','ACTIVE','root','2010-05-21 14:26:32','root','2010-05-21 14:26:32'),(1,'SANDWICHES','FOOD','SANDWICHES','ACTIVE','root','2010-05-21 14:26:13','root','2010-05-21 14:26:13'),(1,'SOFTDRINKS','BEVERAGES','SOFTDRINKS','ACTIVE','root','2010-05-21 14:25:41','root','2010-05-21 14:25:41'),(1,'TEQUILA','BEVERAGES','TEQUILA','ACTIVE','root','2010-10-13 14:03:39','root','2010-10-13 14:03:39');
/*!40000 ALTER TABLE `group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `guests`
--

DROP TABLE IF EXISTS `guests`;
CREATE TABLE `guests` (
  `accountid` varchar(20) NOT NULL,
  `accountname` varchar(20) default NULL,
  `title` varchar(5) default NULL,
  `lastname` varchar(50) default NULL,
  `firstname` varchar(50) default NULL,
  `middlename` varchar(50) default NULL,
  `sex` varchar(6) default NULL,
  `street` varchar(100) default NULL,
  `city` varchar(100) default NULL,
  `country` varchar(100) default NULL,
  `zip` varchar(10) default NULL,
  `emailaddress` varchar(100) default NULL,
  `citizenship` varchar(100) default NULL,
  `passportid` varchar(30) default NULL,
  `TelephoneNo` varchar(50) default NULL,
  `MobileNo` varchar(50) default NULL,
  `FaxNo` varchar(50) default NULL,
  `guestImage` text,
  `noofvisits` int(4) default '1',
  `memo` text,
  `concierge` text,
  `remark` text,
  `stateflag` varchar(15) NOT NULL default 'ACTIVE',
  `HOTELID` int(5) NOT NULL default '0',
  `CREATETIME` datetime default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2001-01-01 01:01:01',
  `UPDATEDBY` varchar(20) default NULL,
  PRIMARY KEY  (`accountid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `guests`
--

LOCK TABLES `guests` WRITE;
/*!40000 ALTER TABLE `guests` DISABLE KEYS */;
/*!40000 ALTER TABLE `guests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `guibuttons`
--

DROP TABLE IF EXISTS `guibuttons`;
CREATE TABLE `guibuttons` (
  `ROLE_ID` varchar(100) NOT NULL,
  `GUI_NAME` varchar(100) NOT NULL,
  `BUTTON_NAME` varchar(100) NOT NULL,
  `VISIBLE` enum('N','Y') default NULL,
  `ENABLE` enum('N','Y') default NULL,
  `STATUS` varchar(10) default 'ACTIVE',
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-08-08 00:00:00',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`ROLE_ID`,`GUI_NAME`,`BUTTON_NAME`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `guibuttons`
--

LOCK TABLES `guibuttons` WRITE;
/*!40000 ALTER TABLE `guibuttons` DISABLE KEYS */;
/*!40000 ALTER TABLE `guibuttons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
CREATE TABLE `item` (
  `RESTO_ID` int(11) NOT NULL default '1',
  `ITEM_ID` int(20) NOT NULL auto_increment,
  `GROUP_ID` varchar(50) default 'BEVERAGES',
  `DESCRIPTION` varchar(100) default NULL,
  `UNIT` varchar(10) default NULL,
  `UNIT_COST` decimal(12,2) default '0.00',
  `SELLING_PRICE` decimal(12,2) default '0.00',
  `EVAT` decimal(6,3) default '12.000',
  `LOCAL_TAX` decimal(6,3) default '0.750',
  `SERVICE_CHARGE` decimal(6,3) default '10.000',
  `STATUS` varchar(15) default 'ACTIVE',
  `KITCHEN_DESIGNATION` varchar(100) default 'KITCHEN',
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-01-01 00:00:01',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-01-01 00:00:01',
  `AVAILABILITY` tinyint(1) default '1',
  PRIMARY KEY  (`ITEM_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
INSERT INTO `item` VALUES (1,1,'BEER','sample','order','0.00','0.00','12.000','0.750','10.000','DELETED','KITCHEN','','2006-01-01 00:00:01','root','2010-05-21 14:48:29',1),(1,2,'BEER','SAN MIG LIGHT','BOT','75.00','75.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-05-21 14:32:02','root','2010-05-21 14:32:02',1),(1,3,'BEER','SAN MIG PILSEN','BOT','75.00','75.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-05-21 14:32:26','root','2010-05-21 14:32:26',1),(1,4,'BEER','RED HORSE BEER','BOT','75.00','75.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-05-21 14:32:53','root','2010-05-21 14:32:53',1),(1,5,'BEER','CERVESA NEGRA','BOT','75.00','75.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-05-21 14:33:32','root','2010-05-21 14:33:32',1),(1,6,'BEER','COLT 45','BOT','75.00','75.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-05-21 14:34:26','root','2010-05-21 14:34:26',1),(1,7,'BREAKFAST','AMERICAN BREAKFAST','ORDER','270.00','270.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-05-21 14:34:50','root','2010-05-21 14:34:50',1),(1,8,'BREAKFAST','FILIPINO BREAKFAST','ORDER','250.00','250.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-05-21 14:35:24','root','2010-05-21 14:35:24',1),(1,9,'BREAKFAST','HUEVOS RANCHEROS BREAKFAST','ORDER','300.00','300.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-05-21 14:35:56','root','2010-05-21 14:35:56',1),(1,10,'BUFFET DINNER','BUFFET DINNER @ 350.00','ORDER','350.00','350.00','0.000','0.000','0.000','ACTIVE','BUFFET','root','2010-05-21 14:36:31','root','2010-05-21 14:36:31',1),(1,11,'BUFFET DINNER','BUFFET DINNER @ 370.00','ORDER','370.00','370.00','0.000','0.000','0.000','ACTIVE','BUFFET','root','2010-05-21 14:36:50','root','2010-05-21 14:36:50',1),(1,12,'BUFFET DINNER','BUFFET DINNER @ 280.00','ORDER','280.00','280.00','0.000','0.000','0.000','ACTIVE','BUFFET','root','2010-05-21 14:37:11','root','2010-05-21 14:37:11',1),(1,13,'BUFFET LUNCH','BUFFET LUNCH @ 350.00','ORDER','350.00','350.00','0.000','0.000','0.000','ACTIVE','BUFFET','root','2010-05-21 14:37:33','root','2010-05-21 14:37:33',1),(1,14,'BUFFET LUNCH','BUFFET LUNCH @ 370.00','ORDER','370.00','370.00','0.000','0.000','0.000','ACTIVE','BUFFET','root','2010-05-21 14:37:51','root','2010-05-21 14:37:51',1),(1,15,'BUFFET LUNCH','BUFFET LUNCH @ 280.00','ORDER','280.00','280.00','0.000','0.000','0.000','ACTIVE','BUFFET','root','2010-05-21 14:38:09','root','2010-05-21 14:38:09',1),(1,16,'CIGARETTES','MARLBORO RED','BOX','50.00','50.00','0.000','0.000','0.000','ACTIVE','SHOP','root','2010-05-21 14:38:37','root','2010-05-21 14:38:37',1),(1,17,'CIGARETTES','MARLBORO LIGHTS','BOX','50.00','50.00','0.000','0.000','0.000','ACTIVE','SHOP','root','2010-05-21 14:38:58','root','2010-05-21 14:38:58',1),(1,18,'CIGARETTES','WINSTON RED','BOX','50.00','50.00','0.000','0.000','0.000','ACTIVE','SHOP','root','2010-05-21 14:39:14','root','2010-05-21 14:39:14',1),(1,19,'DESSERTS','TROPICAL FRESH FRUIT PLATTER','ORDER','180.00','180.00','12.000','0.750','10.000','ACTIVE','KITCHEN','','2006-01-01 00:00:01','ryan','2009-07-27 15:51:52',1),(1,20,'DESSERTS','TIRAMISU\r\n','ORDER','95.00','95.00','12.000','0.750','10.000','ACTIVE','KITCHEN','cherry','2008-12-01 08:06:03','cherry','2008-12-01 08:06:03',1),(1,21,'DESSERTS','MAMON BUTTER','ORDER','45.00','45.00','12.000','0.750','10.000','ACTIVE','KITCHEN','cherry','2008-12-01 11:18:48','cherry','2008-12-01 11:18:48',1),(1,22,'DESSERTS','SMORES','ORDER','60.00','60.00','12.000','0.750','10.000','ACTIVE','KITCHEN','cherry','2008-12-01 20:28:56','cherry','2008-12-01 20:28:56',1),(1,23,'DESSERTS','BLUEBERRY PECAN ','ORDER','95.00','95.00','12.000','0.750','10.000','ACTIVE','KITCHEN','cherry','2008-12-01 20:32:26','cherry','2008-12-01 20:32:26',1),(1,24,'APPETIZERS','BICOL SHRIMP COCKTAIL','ORDER','240.00','240.00','12.000','0.750','10.000','ACTIVE','KITCHEN','ADMIN','2006-01-01 00:00:01','ADMIN','2006-01-01 00:00:01',1),(1,25,'APPETIZERS','CRISPY SPRING ROLLS','ORDER','140.00','140.00','12.000','0.750','10.000','ACTIVE','KITCHEN','ADMIN','2006-01-01 00:00:01','ryan','2009-07-27 14:40:13',1),(1,26,'APPETIZERS','ORIENTAL TUNA SASHIMI','ORDER','245.00','245.00','12.000','0.750','10.000','ACTIVE','KITCHEN','ADMIN','2006-01-01 00:00:01','ryan','2009-07-27 14:40:51',1),(1,27,'APPETIZERS','CALAMARES FRITO','ORDER','220.00','220.00','12.000','0.750','10.000','ACTIVE','KITCHEN','ADMIN','2006-01-01 00:00:01','ADMIN','2006-01-01 00:00:01',1),(1,28,'APPETIZERS','BAKED SCALLOPS','ORDER','225.00','225.00','12.000','0.750','10.000','ACTIVE','KITCHEN','ADMIN','2006-01-01 00:00:01','ryan','2009-07-27 14:41:37',1),(1,29,'JUICE','FRESH CALAMANSI JUICE @75','ORDER','75.00','75.00','12.000','0.750','10.000','ACTIVE','BAR','ryan','2009-09-02 11:23:26','ryan','2009-09-02 11:23:26',1),(1,30,'JUICE','CARROT JUICE @ 95.00','ORDER','95.00','95.00','12.000','0.750','10.000','ACTIVE','BAR','ryan','2009-09-11 15:56:32','ryan','2009-09-11 15:56:32',1),(1,31,'JUICE','FOUR SEASON JUICE @100','ORDER','100.00','100.00','12.000','0.750','10.000','ACTIVE','BAR','richard','2009-09-14 18:45:45','richard','2009-09-14 18:45:45',1),(1,32,'JUICE','WATER MELON JUICE @95','ORDER','95.00','95.00','12.000','0.750','10.000','ACTIVE','BAR','richard','2009-11-23 19:46:28','richard','2009-11-23 19:46:28',1),(1,33,'JUICE','PAPAYA JUICE  @120','ORDER','120.00','120.00','12.000','0.750','10.000','ACTIVE','BAR','richard','2010-01-22 16:49:40','richard','2010-01-22 16:49:40',1),(1,34,'SANDWICHES','RS - TUNA SANDWICH IN FRENCH BREAD OR CIABATTA BREAD @200.00','ORDER','200.00','200.00','12.000','0.750','10.000','ACTIVE','KITCHEN','richard','2009-08-21 21:43:25','richard','2009-08-21 21:43:25',1),(1,35,'SOFTDRINKS','SPRITE REG. CAN  @75','ORDER','75.00','75.00','12.000','0.750','10.000','ACTIVE','BAR','richard','2009-09-03 15:39:29','richard','2009-09-03 15:41:23',1),(1,36,'SOFTDRINKS','COKE ZERO CAN @75','CAN','75.00','75.00','12.000','0.750','10.000','ACTIVE','BAR','richard','2009-09-03 15:40:13','richard','2009-09-03 15:40:13',1),(1,37,'SOFTDRINKS','COKE LIGHT CAN @75','ORDER','75.00','75.00','12.000','0.750','10.000','ACTIVE','BAR','richard','2009-09-03 15:40:43','richard','2009-09-03 15:40:43',1),(1,38,'SOFTDRINKS','HEINEKEN @120','ORDER','120.00','120.00','12.000','0.750','10.000','ACTIVE','BAR','richard','2009-09-18 15:00:56','richard','2009-09-18 15:00:56',1),(1,39,'SANDWICHES','HAM AND CHEESE SANDWICH @250','ORDER','250.00','250.00','12.000','0.750','10.000','ACTIVE','KITCHEN','richard','2009-10-17 07:26:44','richard','2009-10-17 07:26:44',1),(1,40,'SANDWICHES','CHEEZE SANDWICH @180','ORDER','180.00','180.00','12.000','0.750','10.000','ACTIVE','KITCHEN','richard','2009-12-02 14:55:08','richard','2009-12-02 14:55:08',1),(1,41,'SANDWICHES','CHEESE SANDWICHE','ORDER','200.00','200.00','12.000','0.750','10.000','ACTIVE','KITCHEN','ryan','2010-01-04 07:21:21','ryan','2010-01-04 07:21:21',1),(1,42,'SANDWICHES','TUNA SANDWICH IN WHITE BREAD @30 (AT COST)','ORDER','30.00','30.00','12.000','0.750','10.000','ACTIVE','KITCHEN','ryan','2010-02-25 18:36:32','ryan','2010-02-25 19:59:51',1),(1,43,'SOFTDRINKS','RS - COKE ZERO (8 OZ) @35','BOT','35.00','35.00','12.000','0.750','10.000','ACTIVE','BAR','richard','2010-03-05 16:26:03','richard','2010-03-05 16:26:03',1),(1,44,'TEQUILA','EL HOMBRE GOLD 750(BOT)','BOT','220.00','900.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-10-13 14:08:37','root','2010-10-13 14:09:49',1),(1,45,'TEQUILA','EL HOMBRE (JIG)','JIGGER','11.00','150.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-10-13 14:09:21','root','2010-10-13 14:09:21',1),(1,46,'TEQUILA','EL HOMBRE 750 REG (BOT)','BOT','127.50','600.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-10-13 14:10:27','root','2010-10-13 14:10:27',1),(1,47,'TEQUILA','EL HOMBRE REG (JIG)','JIGGER','6.38','125.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-10-13 14:11:13','root','2010-10-13 14:11:13',1),(1,48,'TEQUILA','JOSE CUERVO GOLD (BOT)','BOT','806.43','1200.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-10-13 14:11:50','root','2010-10-13 14:11:50',1),(1,49,'TEQUILA','JOSE CUERVO GOLD (JIG)','JIGGER','40.32','250.00','0.000','0.000','0.000','ACTIVE','BAR','root','2010-10-13 14:12:23','root','2010-10-13 14:12:23',1),(1,50,'APPETIZERS','TENDERLOIN TIPS','ORDER','82.21','350.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:15:14','root','2010-10-13 14:15:14',1),(1,51,'APPETIZERS','KINILAW','ORDER','51.06','185.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:15:41','root','2010-10-13 14:15:41',1),(1,52,'APPETIZERS','FISH STICK','ORDER','63.27','225.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:16:20','root','2010-10-13 14:16:20',1),(1,53,'APPETIZERS','ONION RINGS','ORDER','56.49','150.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:17:10','root','2010-10-13 14:17:10',1),(1,54,'APPETIZERS','CHICKEN FINGERS','ORDER','55.99','225.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:17:42','root','2010-10-13 14:17:42',1),(1,55,'APPETIZERS','BEEF TAPA','ORDER','24.44','185.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:18:18','root','2010-10-13 14:18:18',1),(1,56,'DESSERTS','BANANA SPLIT','ORDER','26.33','150.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:21:15','root','2010-10-13 14:21:15',1),(1,57,'DESSERTS','MANGO CREPE','ORDER','37.21','125.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:21:55','root','2010-10-13 14:21:55',1),(1,58,'DESSERTS','SUNDAES','ORDER','20.80','95.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:22:33','root','2010-10-13 14:22:33',1),(1,59,'FRUIT SHAKES','MANGO SHAKES','ORDER','18.96','90.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:24:37','root','2010-10-13 14:24:37',1),(1,60,'FRUIT SHAKES','BANANA SHAKES','ORDER','9.15','60.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:25:12','root','2010-10-13 14:25:12',1),(1,61,'FRUIT SHAKES','PINEAPPLE SHAKES','ORDER','18.93','65.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:25:58','root','2010-10-13 14:25:58',1),(1,62,'FRUIT SHAKES','WATERMELON SHAKES','ORDER','8.99','65.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:26:20','root','2010-10-13 14:26:20',1),(1,63,'SANDWICHES','OLD FASHIONED HAMBURGER','ORDER','37.05','150.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:28:19','root','2010-10-13 14:28:19',1),(1,64,'SANDWICHES','CHUNKY CHICKEN SANDWICH','ORDER','23.28','85.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:28:57','root','2010-10-13 14:28:57',1),(1,65,'SANDWICHES','HOTDOG SANDWICH','ORDER','14.14','150.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:29:33','root','2010-10-13 14:29:33',1),(1,66,'BREAKFAST','CONTINENTAL BREAKFAST','ORDER','32.20','175.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:31:37','root','2010-10-13 14:31:37',1),(1,67,'BREAKFAST','GOLFERS BREAKFAST','ORDER','54.70','225.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:32:08','root','2010-10-13 14:32:08',1),(1,68,'BREAKFAST','RICE CRISPY WITH MILK','ORDER','0.00','87.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:32:38','root','2010-10-13 14:32:38',1),(1,69,'BREAKFAST','OATMEAL','ORDER','0.00','65.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:32:59','root','2010-10-13 14:32:59',1),(1,70,'BREAKFAST','HAM AND CHEESE OMELETTE','ORDER','24.00','140.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:33:31','root','2010-10-13 14:33:31',1),(1,71,'BREAKFAST','CHICKEN ARROZ CALDO','ORDER','0.00','65.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:33:58','root','2010-10-13 14:33:58',1),(1,72,'BREAKFAST','TUNA OMELETTE','ORDER','24.00','110.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:34:27','root','2010-10-13 14:34:27',1),(1,73,'BREAKFAST','SPANISH OMELETTE','ORDER','21.88','85.00','0.000','0.000','0.000','ACTIVE','KITCHEN','root','2010-10-13 14:34:53','root','2010-10-13 14:34:53',1);
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item_notes`
--

DROP TABLE IF EXISTS `item_notes`;
CREATE TABLE `item_notes` (
  `REMARKS` varchar(200) NOT NULL,
  `ITEM_ID` varchar(10) NOT NULL,
  `CREATED_BY` varchar(50) default NULL,
  `CREATE_TIME` datetime default '2008-01-01 00:00:01',
  `UPDATED_BY` varchar(50) default NULL,
  `UPDATE_TIME` datetime default '2008-01-01 00:00:01',
  `STATUS_FLAG` varchar(10) default 'ACTIVE',
  `ACCESS_COUNT` bigint(10) default '0',
  PRIMARY KEY  (`REMARKS`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `item_notes`
--

LOCK TABLES `item_notes` WRITE;
/*!40000 ALTER TABLE `item_notes` DISABLE KEYS */;
INSERT INTO `item_notes` VALUES ('FOR TAKE OUT','142','root','2010-02-02 18:30:18','root','2010-02-02 18:30:18','ACTIVE',0);
/*!40000 ALTER TABLE `item_notes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lookuptable`
--

DROP TABLE IF EXISTS `lookuptable`;
CREATE TABLE `lookuptable` (
  `Category` varchar(20) NOT NULL,
  `Code` varchar(10) NOT NULL,
  `Description` varchar(50) default NULL,
  `HOTELID` int(5) NOT NULL,
  `CREATETIME` datetime default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2001-01-01 01:01:01',
  `UPDATEDBY` varchar(20) default NULL,
  PRIMARY KEY  (`Category`,`Code`,`HOTELID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lookuptable`
--

LOCK TABLES `lookuptable` WRITE;
/*!40000 ALTER TABLE `lookuptable` DISABLE KEYS */;
/*!40000 ALTER TABLE `lookuptable` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `main_item_group`
--

DROP TABLE IF EXISTS `main_item_group`;
CREATE TABLE `main_item_group` (
  `ID` varchar(20) NOT NULL,
  `DESCRIPTION` varchar(30) default NULL,
  `STATUS` varchar(10) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default NULL,
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATEDTIME` datetime default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `main_item_group`
--

LOCK TABLES `main_item_group` WRITE;
/*!40000 ALTER TABLE `main_item_group` DISABLE KEYS */;
INSERT INTO `main_item_group` VALUES ('BANQUET','BANQUET REVENUE','ACTIVE','root','2010-01-27 16:56:54','root','2010-01-27 16:56:54'),('BEVERAGES','BEVERAGES','ACTIVE','root','2007-05-31 10:13:57','root','2007-05-31 10:13:57'),('FOOD','FOOD','ACTIVE','root','2007-05-31 10:13:22','root','2007-05-31 10:13:22'),('OTHERS','OTHERS','ACTIVE','martin','2007-06-06 17:33:54','martin','2007-06-06 17:33:54');
/*!40000 ALTER TABLE `main_item_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu detail`
--

DROP TABLE IF EXISTS `menu detail`;
CREATE TABLE `menu detail` (
  `MENU_ID` varchar(10) NOT NULL,
  `ITEM_ID` varchar(10) NOT NULL,
  `QUANTITY` int(10) default NULL,
  PRIMARY KEY  (`MENU_ID`,`ITEM_ID`),
  KEY `FOOD_ID` (`ITEM_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `menu detail`
--

LOCK TABLES `menu detail` WRITE;
/*!40000 ALTER TABLE `menu detail` DISABLE KEYS */;
INSERT INTO `menu detail` VALUES ('AUTO','82',1),('AUTO','92',1);
/*!40000 ALTER TABLE `menu detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
CREATE TABLE `menu` (
  `MENU_ID` varchar(10) NOT NULL,
  `DESCRIPTION` varchar(100) default NULL,
  `VAT` decimal(2,2) default NULL,
  `PRICE` decimal(10,2) default NULL,
  `STATUS` varchar(20) default NULL,
  `PICTURE` varchar(200) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-01-01 00:00:01',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-01-01 00:00:01',
  `SERVICE_CHARGE` decimal(2,2) default NULL,
  PRIMARY KEY  (`MENU_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_copy`
--

DROP TABLE IF EXISTS `menu_copy`;
CREATE TABLE `menu_copy` (
  `MENU_ID` varchar(10) NOT NULL,
  `DESCRIPTION` varchar(100) default NULL,
  `VAT` decimal(2,2) default NULL,
  `PRICE` decimal(10,2) default NULL,
  `STATUS` varchar(20) default NULL,
  `PICTURE` varchar(200) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-01-01 00:00:01',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-01-01 00:00:01',
  PRIMARY KEY  (`MENU_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `menu_copy`
--

LOCK TABLES `menu_copy` WRITE;
/*!40000 ALTER TABLE `menu_copy` DISABLE KEYS */;
/*!40000 ALTER TABLE `menu_copy` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menus`
--

DROP TABLE IF EXISTS `menus`;
CREATE TABLE `menus` (
  `Menu` varchar(30) NOT NULL,
  `Description` varchar(100) default NULL,
  PRIMARY KEY  (`Menu`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `menus`
--

LOCK TABLES `menus` WRITE;
/*!40000 ALTER TABLE `menus` DISABLE KEYS */;
INSERT INTO `menus` VALUES ('About',''),('Advance Deposit',''),('Agent',''),('All',''),('Arrange Icon',''),('Arrivals',''),('Cascade',''),('Clear',''),('Close',''),('Configuration',''),('Copy',''),('Currency Codes',''),('Cut',''),('Database Backup',''),('Delete',''),('Departure',''),('Edit',''),('Exit',''),('Expected Arrivals',''),('Expected Departure',''),('File',''),('Find',''),('Floor Occupancy',''),('Floor Plan',''),('Front Desk',''),('Group',''),('Group Blocking',''),('Group Reservation',''),('Guest',''),('Guests Report',''),('Help',''),('Horizontally',''),('Housekeeping Jobs',''),('In House Guests List',''),('Index',''),('Individual',''),('Log-Off',''),('Mail Recipient',''),('New',''),('Open',''),('Packages',''),('Page Setup',''),('Paste',''),('Print',''),('Print Preview',''),('Privileges',''),('Projected Revenue',''),('Rate Codes',''),('Rate Types',''),('Repeat',''),('Replace',''),('Report Generator',''),('Reports',''),('Reservation',''),('Room',''),('Room Amenities',''),('Room Availability',''),('Room Blocking',''),('Room Status',''),('Room Transfer',''),('Room Types',''),('Rooms',''),('Rooms Blocked by Date',''),('Rooms Report',''),('Sales Summary',''),('Save',''),('Scheduled For Engineering Job',''),('Search',''),('Send To',''),('Share',''),('Single Reservation',''),('Tile',''),('Transaction Codes',''),('Transaction Types',''),('Transactions',''),('Undo',''),('Utilities',''),('Vertically',''),('View Web Cam',''),('Window','');
/*!40000 ALTER TABLE `menus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operation`
--

DROP TABLE IF EXISTS `operation`;
CREATE TABLE `operation` (
  `OPERATION` varchar(30) NOT NULL,
  `DESCRIPTION` varchar(50) default NULL,
  `STATUS` varchar(7) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-01-01 00:00:01',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-01-01 00:00:01',
  PRIMARY KEY  (`OPERATION`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `operation`
--

LOCK TABLES `operation` WRITE;
/*!40000 ALTER TABLE `operation` DISABLE KEYS */;
INSERT INTO `operation` VALUES ('ASSEMBLE','ASSEMBLE','ACTIVE','ADMIN','2006-01-01 00:00:01','root','2007-01-05 18:44:16'),('DELIVER','FOR DELIVERY','ACTIVE','ADMIN','2006-01-01 00:00:01','root','2006-09-11 18:32:01'),('PREPARE','PREPARE ITEM','ACTIVE','','2006-08-16 17:53:48','root','2006-12-29 19:29:40'),('REGISTER','REGISTER','ACTIVE','ADMIN','2006-01-01 00:00:01','','2006-08-15 15:41:00');
/*!40000 ALTER TABLE `operation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order detail`
--

DROP TABLE IF EXISTS `order detail`;
CREATE TABLE `order detail` (
  `ID` bigint(20) NOT NULL auto_increment,
  `ORDER_ID` bigint(10) NOT NULL,
  `LINE_NO` int(4) NOT NULL,
  `ITEM_ID` varchar(30) NOT NULL,
  `DESCRIPTION` varchar(500) default NULL,
  `UNIT_PRICE` decimal(12,4) default NULL,
  `QUANTITY` int(4) default NULL,
  `DISCOUNT` decimal(12,4) default '0.0000',
  `VAT` decimal(12,4) default '0.0000',
  `LOCAL_TAX` decimal(12,4) default '0.0000',
  `AMOUNT` decimal(12,4) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2008-08-08 00:00:01',
  `UPDATEBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2008-08-08 00:00:01',
  `SERVICE_CHARGE` decimal(12,4) default '0.0000',
  `DITEM_ID` varchar(30) default NULL,
  `ROUTE` tinyint(1) default NULL,
  `SERVED` int(4) default NULL,
  `SERVED_BY` text,
  `TIME_SERVED` datetime default '2008-08-08 00:00:01',
  `OPERATION_STATUS` enum('NEW','ASSEMBLING','CHANGED','FINISH','CANCELLED') default 'NEW',
  `ITEM_NOTES` text,
  `ACKNOWLEDGE` tinyint(4) default '0',
  `ACKNOWLEDGE_BY` varchar(50) default NULL,
  `TIME_ACKNOWLEDGED` datetime default '2008-08-08 00:00:01',
  `IS_PRINTED` tinyint(1) default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `order detail`
--

LOCK TABLES `order detail` WRITE;
/*!40000 ALTER TABLE `order detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `order detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order header`
--

DROP TABLE IF EXISTS `order header`;
CREATE TABLE `order header` (
  `ORDER_ID` bigint(15) NOT NULL,
  `CUSTOMER_ID` varchar(500) default NULL,
  `ROUTE_ID` varchar(10) default NULL,
  `TABLE_NO` varchar(3) default NULL,
  `ASSIGNED_TO` varchar(10) default NULL,
  `ASSIGNED_TIME` datetime NOT NULL default '2006-01-01 00:00:01',
  `ORDER_DATE` datetime default '2006-01-01 00:00:01',
  `TOTAL_LINE_ITEMS` int(11) default NULL,
  `TOTAL_AMOUNT` decimal(12,4) default '0.0000',
  `TOTAL_DISCOUNT` decimal(12,4) default '0.0000',
  `TOTAL_PAYMENT` decimal(12,4) default '0.0000',
  `BALANCE` decimal(12,4) default '0.0000',
  `SEQ_NO` int(11) default NULL,
  `STATUS` varchar(30) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-01-01 00:00:01',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-01-01 00:00:01',
  `VAT_SALES` decimal(12,4) default '0.0000',
  `VAT_AMOUNT` decimal(12,4) default '0.0000',
  `NONVAT_SALES` decimal(12,4) default '0.0000',
  `SERVICE_CHARGE` decimal(12,4) default '0.0000',
  `LOCAL_TAX` decimal(12,4) default '0.0000',
  `ROOMSERVICE_CHARGE` decimal(12,4) default '0.0000',
  `EMPLOYEE_ID` varchar(20) default NULL,
  `SHIFT_CODE` varchar(10) default NULL,
  `TERMINAL_ID` varchar(10) default NULL,
  PRIMARY KEY  (`ORDER_ID`),
  KEY `FK_order header` (`CUSTOMER_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `order header`
--

LOCK TABLES `order header` WRITE;
/*!40000 ALTER TABLE `order header` DISABLE KEYS */;
/*!40000 ALTER TABLE `order header` ENABLE KEYS */;
UNLOCK TABLES;

/*!50003 SET @OLD_SQL_MODE=@@SQL_MODE*/;
DELIMITER ;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION" */;;
/*!50003 CREATE */ /*!50017 DEFINER=`root`@`localhost` */ /*!50003 TRIGGER `t_InsertOrderHeader` BEFORE INSERT ON `order header` FOR EACH ROW begin
if (new.service_charge>0) then
update service_charge set service_charge=service_charge+new.service_charge;
end if;
END */;;

DELIMITER ;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE */;

--
-- Table structure for table `order history`
--

DROP TABLE IF EXISTS `order history`;
CREATE TABLE `order history` (
  `id` int(15) NOT NULL auto_increment,
  `ORDER_ID` bigint(15) NOT NULL,
  `OPERATION` varchar(25) NOT NULL,
  `START_TIME` time NOT NULL default '00:00:00',
  `END_TIME` time default '00:00:00',
  `WAIT_DURATION` time default '00:00:00',
  `SERVICE_DURATION` time default '00:00:00',
  `ASSIGNED_TO` varchar(30) default NULL,
  `DISPOSITION` varchar(15) NOT NULL default 'PROCEED',
  PRIMARY KEY  (`id`,`ORDER_ID`,`OPERATION`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `order history`
--

LOCK TABLES `order history` WRITE;
/*!40000 ALTER TABLE `order history` DISABLE KEYS */;
/*!40000 ALTER TABLE `order history` ENABLE KEYS */;
UNLOCK TABLES;

/*!50003 SET @OLD_SQL_MODE=@@SQL_MODE*/;
DELIMITER ;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION" */;;
/*!50003 CREATE */ /*!50017 DEFINER=`root`@`localhost` */ /*!50003 TRIGGER `T_UpdateOrderStatus` AFTER INSERT ON `order history` FOR EACH ROW begin
if(new.operation!="NEWORDER") then
Update `order header` set `status`=new.operation where order_id = new.order_id;
end if;
if(new.operation="PREPARED") then
Update `order header` set `status`='SERVED' where order_id = new.order_id;
Update `employee status` set `status`='';
end if;
if(new.operation="ASSEMBLING") then
update `order header` set assigned_to=(select fGetEmployeeID(new.assigned_to)) where order_id=new.order_id;
end if;
END */;;

DELIMITER ;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE */;

--
-- Table structure for table `order_volume_criteria`
--

DROP TABLE IF EXISTS `order_volume_criteria`;
CREATE TABLE `order_volume_criteria` (
  `Type` varchar(20) default NULL,
  `Orders_per_week` int(11) default NULL,
  `Amount_per_week` decimal(10,2) default NULL,
  `Orders_per_month` int(11) default NULL,
  `Amount_per_month` decimal(10,2) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `order_volume_criteria`
--

LOCK TABLES `order_volume_criteria` WRITE;
/*!40000 ALTER TABLE `order_volume_criteria` DISABLE KEYS */;
INSERT INTO `order_volume_criteria` VALUES ('Heavy',6,'200.00',4,'400.00'),('Medium',3,'100.00',2,'200.00');
/*!40000 ALTER TABLE `order_volume_criteria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
CREATE TABLE `payment` (
  `ID` int(11) NOT NULL auto_increment,
  `ORDER_ID` varchar(10) NOT NULL,
  `PAYMENT_TYPE` varchar(17) NOT NULL,
  `AMOUNT` decimal(12,4) default NULL,
  `GIFTCHEQUE_NO` varchar(20) default 'FILLER',
  `CREDITCARD_NO` varchar(20) default 'FILLER',
  `CARD_CO` varchar(30) default 'FILLER',
  `APPROVAL_CODE` varchar(100) default NULL,
  `COUPON_NO` varchar(20) default NULL,
  `VALID_DATE` date default NULL,
  `COUPON_TYPE` varchar(25) default NULL,
  `ACCOUNT_ID` varchar(20) default 'FILLER',
  `PAYMENT_DATE` datetime default '2001-01-01 01:01:01',
  `COLLECTED_BY` varchar(30) default 'FILLER',
  `SHIFT_CODE` int(11) default NULL,
  `TERMINAL_ID` int(11) default NULL,
  `RESTAURANT_ID` int(11) default NULL,
  `STATUS` varchar(10) default 'OK',
  `postedToLedger` char(1) default '0',
  PRIMARY KEY  (`ID`,`ORDER_ID`,`PAYMENT_TYPE`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC COMMENT='InnoDB free: 20480 kB';

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

/*!50003 SET @OLD_SQL_MODE=@@SQL_MODE*/;
DELIMITER ;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION" */;;
/*!50003 CREATE */ /*!50017 DEFINER=`root`@`localhost` */ /*!50003 TRIGGER `t_updatePayment` AFTER UPDATE ON `payment` FOR EACH ROW begin
if(new.PAYMENT_TYPE='CASH' and new.`STATUS`='VOID') then
update cashiers,`order header` 
set cash = cash - if(new.amount > 
(`order header`.total_amount-`order header`.total_discount),
(`order header`.total_amount-`order header`.total_discount), new.amount),
netamount = cash + creditcard + others + adjustment + chargeinamount
where new.order_id = `order header`.order_id
AND shiftcode = new.shift_code and
terminalid = new.terminal_id;
end if;
if(new.PAYMENT_TYPE='Credit' and new.`STATUS`='VOID') then
update cashiers,`order header` 
set creditcard = creditcard - new.amount,
netamount = cash + creditcard + others + adjustment + chargeinamount
where new.order_id = `order header`.order_id
AND shiftcode = new.shift_code and
terminalid = new.terminal_id;
end if;
if(new.PAYMENT_TYPE='CHEQUE' and new.`STATUS`='VOID') then
update cashiers,`order header` 
set cheque = cheque - if(new.amount >
(`order header`.total_amount-`order header`.total_discount),
(`order header`.total_amount-`order header`.total_discount), new.amount),
netamount=cash + creditcard + others + adjustment + chargeinamount
where new.order_id = `order header`.order_id
AND shiftcode = new.shift_code and
terminalid = new.terminal_id;
end if;
END */;;

DELIMITER ;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE */;

--
-- Table structure for table `payment_ledger`
--

DROP TABLE IF EXISTS `payment_ledger`;
CREATE TABLE `payment_ledger` (
  `id` int(11) NOT NULL auto_increment,
  `EMPLOYEE_ID` varchar(10) NOT NULL,
  `Date` date default NULL,
  `ref_no` bigint(15) NOT NULL,
  `debit` double(12,2) default '0.00',
  `credit` double(12,2) default '0.00',
  `memo` text,
  `HOTELID` int(5) NOT NULL default '0',
  `CREATETIME` datetime NOT NULL default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2001-01-01 01:01:01',
  `UPDATEDBY` varchar(20) default NULL,
  `posttoacctng` varchar(1) default '0',
  `closed` varchar(1) default '0',
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `payment_ledger`
--

LOCK TABLES `payment_ledger` WRITE;
/*!40000 ALTER TABLE `payment_ledger` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment_ledger` ENABLE KEYS */;
UNLOCK TABLES;

/*!50003 SET @OLD_SQL_MODE=@@SQL_MODE*/;
DELIMITER ;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION" */;;
/*!50003 CREATE */ /*!50017 DEFINER=`root`@`localhost` */ /*!50003 TRIGGER `t_InsertPayment` BEFORE INSERT ON `payment_ledger` FOR EACH ROW begin
update `employee account`
set
charge=charge-new.credit
where employee_id=new.employee_id;
END */;;

DELIMITER ;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE */;

--
-- Table structure for table `restaurants`
--

DROP TABLE IF EXISTS `restaurants`;
CREATE TABLE `restaurants` (
  `RestaurantId` varchar(10) NOT NULL,
  `Description` varchar(100) default NULL,
  `AreaCode` varchar(10) default NULL,
  `TelephoneNo` varchar(30) default NULL,
  `Address` text,
  `Status` varchar(20) default NULL,
  `CreatedBy` varchar(30) default NULL,
  `CreateTime` datetime default '2006-01-01 00:00:01',
  `UpdatedBy` varchar(30) default NULL,
  `UpdateTime` datetime default '2006-01-01 00:00:01',
  PRIMARY KEY  (`RestaurantId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurants`
--

LOCK TABLES `restaurants` WRITE;
/*!40000 ALTER TABLE `restaurants` DISABLE KEYS */;
INSERT INTO `restaurants` VALUES ('1','JINISYS CAFE','32','4158647','GORORDO AVE., CEBU CITY','ACTIVE','JINISYS','2006-01-01 00:00:01','JINISYS','2006-08-05 16:26:56');
/*!40000 ALTER TABLE `restaurants` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_db_privileges`
--

DROP TABLE IF EXISTS `role_db_privileges`;
CREATE TABLE `role_db_privileges` (
  `ROLE_ID` varchar(100) NOT NULL,
  `DBPRIVILEGES` set('Select','Insert','Update','Delete','Create','Drop','Reload','Shutdown','Process','File','References','Alter','Index','Show_db','Super','Create_tmp_table','Lock_tables','Execute','Repl_slave','Repl_client','Create_view','Show_view','Create_routine','Alter_routine','Create_user') default NULL,
  `STATUS` varchar(10) default 'ACTIVE',
  `CREATEDBY` varchar(30) default NULL,
  `CREATETTIME` datetime default '2006-08-08 00:00:00',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`ROLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `role_db_privileges`
--

LOCK TABLES `role_db_privileges` WRITE;
/*!40000 ALTER TABLE `role_db_privileges` DISABLE KEYS */;
INSERT INTO `role_db_privileges` VALUES ('ADMINISTRATOR','','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('INSTRUCTOR','Select,Insert,Update,Delete,Create,Drop,Reload,Shutdown,Process,File,References,Alter,Index,Show_db,Super,Create_tmp_table,Lock_tables,Execute,Repl_slave,Repl_client,Create_view,Show_view,Create_routine,Alter_routine,Create_user','ACTIVE','ADMIN','2006-08-08 00:00:00','ADMIN','2006-08-08 00:00:00'),('IT','','ACTIVE','','2006-08-08 00:00:00','','2006-08-08 00:00:00'),('USER','','ACTIVE','','2006-08-08 00:00:00','','2006-08-08 00:00:00');
/*!40000 ALTER TABLE `role_db_privileges` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_menus`
--

DROP TABLE IF EXISTS `role_menus`;
CREATE TABLE `role_menus` (
  `ROLE_ID` varchar(100) NOT NULL,
  `MENU_NAME` varchar(100) NOT NULL,
  `VISIBLE` enum('N','Y') default 'N',
  `ENABLE` enum('N','Y') default 'N',
  `STATUS` varchar(10) default 'ACTIVE',
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-08-08 00:00:00',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`ROLE_ID`,`MENU_NAME`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `role_menus`
--

LOCK TABLES `role_menus` WRITE;
/*!40000 ALTER TABLE `role_menus` DISABLE KEYS */;
INSERT INTO `role_menus` VALUES ('ADMINISTRATOR','BIKE','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','BUTTON SETUP','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','CASHIER','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','CASHIER TRANSACTIONS','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','CHANGE PASSWORD','Y','Y','ACTIVE','','2006-08-08 00:00:00','','2006-08-08 00:00:00'),('ADMINISTRATOR','CLOSE SHIFT CASH DRAWER','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','COMPLIMENTARY ORDERS','Y','Y','ACTIVE','','2006-08-08 00:00:00','','2006-08-08 00:00:00'),('ADMINISTRATOR','CUSTOMERS','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','DAILY SUMMARIZED SALES BY DISCOUNT ','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','DETAILED SALES PER ITEM','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','DETAILED SALES PER ORDER','Y','Y','ACTIVE','','2006-08-08 00:00:00','','2006-08-08 00:00:00'),('ADMINISTRATOR','DETAILED VOID ORDERS','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','EDIT','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','EMPLOYEE','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','EMPLOYEE CREDIT','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','EMPLOYEE LEDGER','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','EMPLOYEE PAYMENTS','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','EMPLOYEE REPORTS','Y','Y','ACTIVE','','2006-08-08 00:00:00','','2006-08-08 00:00:00'),('ADMINISTRATOR','FILE','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','FOOD AND BEVERAGE','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','FOOD AND BEVERAGE PER SHIFT','Y','Y','ACTIVE','','2006-08-08 00:00:00','','2006-08-08 00:00:00'),('ADMINISTRATOR','FOOD AND BEVERAGE SALES','Y','Y','ACTIVE','','2006-08-08 00:00:00','','2006-08-08 00:00:00'),('ADMINISTRATOR','FUNCTION MAPPING','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','GROUP','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ITEM','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','KITCHEN STAFF REPORT','Y','Y','ACTIVE','','2006-08-08 00:00:00','','2006-08-08 00:00:00'),('ADMINISTRATOR','LOG-IN','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','LOG-OUT','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','MAIN GROUP','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','MAINTENANCE','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','MENU','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','OPEN SHIFT CASH DRAWER','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','RE-PRINT RECEIPT','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','REPORT GENERATOR','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','REPORTS','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','RESET DATABASE','Y','Y','ACTIVE','root','2006-08-08 00:00:00','root','2006-08-08 00:00:00'),('ADMINISTRATOR','RESTAURANT STAFF REPORT','Y','Y','ACTIVE','','2006-08-08 00:00:00','','2006-08-08 00:00:00'),('ADMINISTRATOR','ROLES','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ROUTE','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','SALES REPORT','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','SECURITY','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','SUMMARIZED CHARGES','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','SUMMARIZED SALES BY GROUP','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','SUMMARIZED SALES BY MAIN GROUP','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','SUMMARIZED SALES BY OUTLET','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','SUMMARIZED SALES BY PAYMENT','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','SYSTEM MENU','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','USERS','Y','Y','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('INSTRUCTOR','BIKE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','BUTTON SETUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','CASHIER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','CASHIER TRANSACTIONS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','CHANGE PASSWORD','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','CLOSE SHIFT CASH DRAWER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','COMPLIMENTARY ORDERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','CUSTOMERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','DAILY SUMMARIZED SALES BY DISCOUNT ','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','DETAILED SALES PER ITEM','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','DETAILED SALES PER ORDER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','DETAILED VOID ORDERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','EDIT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','EMPLOYEE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','EMPLOYEE CREDIT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','EMPLOYEE LEDGER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','EMPLOYEE PAYMENTS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','EMPLOYEE REPORTS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','FILE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','FOOD AND BEVERAGE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','FOOD AND BEVERAGE PER SHIFT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','FOOD AND BEVERAGE SALES','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','FUNCTION MAPPING','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','ITEM','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','KITCHEN STAFF REPORT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','LOG-IN','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','LOG-OUT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','MAIN GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','MAINTENANCE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','MENU','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','OPEN SHIFT CASH DRAWER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','RE-PRINT RECEIPT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','REPORT GENERATOR','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','REPORTS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','RESET DATABASE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','RESTAURANT STAFF REPORT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','ROLES','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','ROUTE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','SALES REPORT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','SECURITY','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','SUMMARIZED CHARGES','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','SUMMARIZED SALES BY GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','SUMMARIZED SALES BY MAIN GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','SUMMARIZED SALES BY OUTLET','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','SUMMARIZED SALES BY PAYMENT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','SYSTEM MENU','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('INSTRUCTOR','USERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:16','ADMIN','2010-05-21 13:58:16'),('IT','BIKE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','BUTTON SETUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','CASHIER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','CASHIER TRANSACTIONS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','CHANGE PASSWORD','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','CLOSE SHIFT CASH DRAWER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','COMPLIMENTARY ORDERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','CUSTOMERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','DAILY SUMMARIZED SALES BY DISCOUNT ','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','DETAILED SALES PER ITEM','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','DETAILED SALES PER ORDER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','DETAILED VOID ORDERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','EDIT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','EMPLOYEE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','EMPLOYEE CREDIT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','EMPLOYEE LEDGER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','EMPLOYEE PAYMENTS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','EMPLOYEE REPORTS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','FILE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','FOOD AND BEVERAGE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','FOOD AND BEVERAGE PER SHIFT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','FOOD AND BEVERAGE SALES','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','FUNCTION MAPPING','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','ITEM','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','KITCHEN STAFF REPORT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','LOG-IN','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','LOG-OUT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','MAIN GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','MAINTENANCE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','MENU','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','OPEN SHIFT CASH DRAWER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','RE-PRINT RECEIPT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','REPORT GENERATOR','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','REPORTS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','RESET DATABASE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','RESTAURANT STAFF REPORT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','ROLES','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','ROUTE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','SALES REPORT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','SECURITY','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','SUMMARIZED CHARGES','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','SUMMARIZED SALES BY GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','SUMMARIZED SALES BY MAIN GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','SUMMARIZED SALES BY OUTLET','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','SUMMARIZED SALES BY PAYMENT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','SYSTEM MENU','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('IT','USERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:41','ADMIN','2010-05-21 13:58:41'),('USER','BIKE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','BUTTON SETUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','CASHIER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','CASHIER TRANSACTIONS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','CHANGE PASSWORD','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','CLOSE SHIFT CASH DRAWER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','COMPLIMENTARY ORDERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','CUSTOMERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','DAILY SUMMARIZED SALES BY DISCOUNT ','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','DETAILED SALES PER ITEM','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','DETAILED SALES PER ORDER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','DETAILED VOID ORDERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','EDIT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','EMPLOYEE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','EMPLOYEE CREDIT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','EMPLOYEE LEDGER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','EMPLOYEE PAYMENTS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','EMPLOYEE REPORTS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','FILE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','FOOD AND BEVERAGE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','FOOD AND BEVERAGE PER SHIFT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','FOOD AND BEVERAGE SALES','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','FUNCTION MAPPING','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','ITEM','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','KITCHEN STAFF REPORT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','LOG-IN','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','LOG-OUT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','MAIN GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','MAINTENANCE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','MENU','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','OPEN SHIFT CASH DRAWER','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','RE-PRINT RECEIPT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','REPORT GENERATOR','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','REPORTS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','RESET DATABASE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','RESTAURANT STAFF REPORT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','ROLES','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','ROUTE','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','SALES REPORT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','SECURITY','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','SUMMARIZED CHARGES','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','SUMMARIZED SALES BY GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','SUMMARIZED SALES BY MAIN GROUP','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','SUMMARIZED SALES BY OUTLET','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','SUMMARIZED SALES BY PAYMENT','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','SYSTEM MENU','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48'),('USER','USERS','Y','Y','ACTIVE','ADMIN','2010-05-21 13:58:48','ADMIN','2010-05-21 13:58:48');
/*!40000 ALTER TABLE `role_menus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_privileges`
--

DROP TABLE IF EXISTS `role_privileges`;
CREATE TABLE `role_privileges` (
  `hotelID` int(4) NOT NULL default '1',
  `roleName` varchar(50) NOT NULL,
  `privilegeDescription` varchar(500) NOT NULL,
  `isAllowed` tinyint(1) default NULL,
  `createdBy` varchar(50) default NULL,
  `createTime` datetime default '2007-08-08 00:00:08',
  `updatedBy` varchar(50) default NULL,
  `updateTime` datetime default '2007-08-08 00:00:08',
  PRIMARY KEY  (`hotelID`,`roleName`,`privilegeDescription`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `role_privileges`
--

LOCK TABLES `role_privileges` WRITE;
/*!40000 ALTER TABLE `role_privileges` DISABLE KEYS */;
/*!40000 ALTER TABLE `role_privileges` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_table_privileges`
--

DROP TABLE IF EXISTS `role_table_privileges`;
CREATE TABLE `role_table_privileges` (
  `ROLE_ID` varchar(100) NOT NULL,
  `TABLE_NAME` varchar(100) NOT NULL,
  `TABLEPRIVILEGES` set('Select','Insert','Update','Delete','Create','Drop','Grant','References','Index','Alter','Create View','Show view') default NULL,
  `COLUMNPRIVILEGES` set('Select','Insert','Update','References') default NULL,
  `STATUS` varchar(10) default 'ACTIVE',
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-08-08 00:00:00',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`ROLE_ID`,`TABLE_NAME`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `role_table_privileges`
--

LOCK TABLES `role_table_privileges` WRITE;
/*!40000 ALTER TABLE `role_table_privileges` DISABLE KEYS */;
INSERT INTO `role_table_privileges` VALUES ('ADMINISTRATOR','BIKE','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','BIKE_ASSIGN','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','BUTTON_SETUP','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','COMPLAINTS','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','COMPLAINT_REASONS','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','CUSTOMERS','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','EMPLOYEE','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','FOOD','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','FUNCTION MAPPING','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','GROUP','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','GUIBUTTONS','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ITEM','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','MENU','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','MENU DETAIL','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','OPERATION','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ORDER DETAIL','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ORDER HEADER','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ORDER HISTORY','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','RESTAURANTS','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ROLES','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ROLE_DB_PRIVILEGES','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ROLE_MENUS','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ROLE_TABLE_PRIVILEGES','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ROUTE DETAIL','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','ROUTE HEADER','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','SEQ_ORDERS','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','SYSTEMMENUS','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','TRADINGAREAS','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','USERS','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40'),('ADMINISTRATOR','USER_ROLES','Select,Insert,Update,Delete,Create,Grant,References,Index,Alter,Create View,Show view','Select,Insert,Update,References','ACTIVE','root','2009-02-23 20:18:40','root','2009-02-23 20:18:40');
/*!40000 ALTER TABLE `role_table_privileges` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_ui_privileges`
--

DROP TABLE IF EXISTS `role_ui_privileges`;
CREATE TABLE `role_ui_privileges` (
  `roleName` varchar(100) NOT NULL,
  `module` varchar(100) NOT NULL,
  `formName` varchar(100) NOT NULL,
  `buttonName` varchar(100) NOT NULL,
  `isVisible` tinyint(1) default '0',
  `statusFlag` enum('ACTIVE','DELETED') default 'ACTIVE',
  `createdDate` datetime default '2008-08-08 08:08:08',
  `createdBy` varchar(50) default NULL,
  `updatedDate` datetime default '2008-08-08 08:08:08',
  `updatedBy` varchar(50) default NULL,
  PRIMARY KEY  (`roleName`,`module`,`formName`,`buttonName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `role_ui_privileges`
--

LOCK TABLES `role_ui_privileges` WRITE;
/*!40000 ALTER TABLE `role_ui_privileges` DISABLE KEYS */;
INSERT INTO `role_ui_privileges` VALUES ('ADMINISTRATOR','BUSINESSSHAREDCLASSES','PROGRESSFORM','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CASHIERTRANSACTIONSUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CASHIERTRANSACTIONSUI','BTNPREVIEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CASHIERTRANSACTIONSUI','BUTTON1',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CASHTERMINALLISTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CASHTERMINALLISTUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CASHTERMINALLISTUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CASHTERMINALLISTUI','BTNEDIT',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CASHTERMINALLISTUI','BTNINSERT',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CASHTERMINALLISTUI','BTNSELECT',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CASHTERMINALLISTUI','BUTTON1',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CLOSESHIFTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CLOSESHIFTUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','CLOSESHIFTUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','EMPLOYEEPAYMENT','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','OPENSHIFTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','OPENSHIFTUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CASHIER','OPENSHIFTUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','COMMON','MESSAGEBOX','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEASSIGNUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEASSIGNUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEASSIGNUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEASSIGNUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEASSIGNUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEASSIGNUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEASSIGNUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEASSIGNUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BIKEUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BUTTONSUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BUTTONSUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BUTTONSUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BUTTONSUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BUTTONSUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BUTTONSUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BUTTONSUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','BUTTONSUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','CUSTOMERUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','EMPLOYEEUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','EMPLOYEEUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','EMPLOYEEUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','EMPLOYEEUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','EMPLOYEEUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','EMPLOYEEUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','EMPLOYEEUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','EMPLOYEEUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','FUNCTIONUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','FUNCTIONUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','FUNCTIONUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','FUNCTIONUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','FUNCTIONUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','FUNCTIONUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','FUNCTIONUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','FUNCTIONUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','GROUPUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','GROUPUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','GROUPUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','GROUPUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','GROUPUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','GROUPUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','GROUPUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','GROUPUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ITEMUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ITEMUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ITEMUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ITEMUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ITEMUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ITEMUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ITEMUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ITEMUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MAINGROUPUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MAINGROUPUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MAINGROUPUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MAINGROUPUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MAINGROUPUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MAINGROUPUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MAINGROUPUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MAINGROUPUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MENUASSIGNMENTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MENUUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MENUUI','BTNBROWSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MENUUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MENUUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MENUUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MENUUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MENUUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MENUUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','MENUUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','OPERATIONUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','OPERATIONUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','OPERATIONUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','OPERATIONUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','OPERATIONUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','OPERATIONUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','OPERATIONUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','OPERATIONUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','RESTAURANTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ROUTEUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ROUTEUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ROUTEUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ROUTEUI','BTNDELETE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ROUTEUI','BTNNEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ROUTEUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ROUTEUI','BTNSAVE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','ROUTEUI','BTNSEARCH',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','CONFIGURATION','TRADINGAREAUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','POSMAIN','RESETUI','',1,'ACTIVE','2008-08-08 08:08:08','root','2008-08-08 08:08:08','root'),('ADMINISTRATOR','POSMAIN','RESETUI','BTNCANCEL',1,'ACTIVE','2008-08-08 08:08:08','root','2008-08-08 08:08:08','root'),('ADMINISTRATOR','POSMAIN','RESETUI','BTNOK',1,'ACTIVE','2008-08-08 08:08:08','root','2008-08-08 08:08:08','root'),('ADMINISTRATOR','REPORTS','CASHIERTRANSACTIONUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','CASHIERTRANSACTIONUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','CASHIERTRANSACTIONUI','BTNPRINT',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','CASHIERTRANSACTIONUI','BTNSHOW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','DETAILEDSALESPERORDER','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','DETAILEDSALESPERORDER','BTNPREVIEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','DETAILEDSALESPERORDER','BTNPRINT',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','DETAILEDSALES_PER_ITEM','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','DETAILEDSALES_PER_ITEM','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2009-11-07 15:50:02','root'),('ADMINISTRATOR','REPORTS','DETAILEDSALES_PER_ITEM','BTNSHOW',1,'ACTIVE','2009-11-07 14:05:44','root','2009-11-07 15:50:02','root'),('ADMINISTRATOR','REPORTS','EMPLOYEELEDGERDETAILSUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','EMPLOYEEREPORTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','EMPLOYEEREPORTUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','EMPLOYEEREPORTUI','BTNPRINT',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','EMPLOYEEREPORTUI','BTNSHOWALL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','EMPLOYEEREPORTUI','BTNVIEWDETAILS',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','FOODANDBEVREPORT','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','FOODANDBEVREPORT','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','FOODANDBEVREPORT','BTNSHOW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','PARAMPRINTRECEIPTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','PARAMPRINTRECEIPTUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','PARAMPRINTRECEIPTUI','BTNPREVIEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','REPORTDATEPARAM','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','REPORTPARAMDATEUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','REPORTPREVIEWUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','REPORTSUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','REPORTSUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','REPORTSUI','BTNPREVIEW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','REPORTSUI','BUTTON1',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','SALESREPORT','',1,'ACTIVE','2009-12-02 15:21:25','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','SALESREPORT','BTNCLOSE',1,'ACTIVE','2009-12-02 15:21:25','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','SALESREPORT','BTNPREVIEW',1,'ACTIVE','2009-12-02 15:21:25','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','SALESREPORT','BTNPRINT',1,'ACTIVE','2009-12-02 15:21:25','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','BTNSHOW',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','AUTHENTICATEUSERUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','AUTHENTICATEUSERUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','AUTHENTICATEUSERUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','CHANGEPASSWORDUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','FORM1','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','LOGINUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','LOGINUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','LOGINUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','ROLEUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','SYSTEMMENUUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','SYSTEMROLE','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','SECURITY','USERUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ADDCOMPLAINTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ADDFOLIOTRANSACTIONUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ADDFOLIOTRANSACTIONUI','BTNCANCEL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ADDFOLIOTRANSACTIONUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ADDITEMNOTESUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ADDITEMNOTESUI','BTNCLEAR',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ADDITEMNOTESUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ADDITEMNOTESUI','BTNMANUAL',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ADDITEMNOTESUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ADDITEMNOTESUI','BTNREMOVELASTNOTE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ASSIGNTABLEUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','CALLERINFOUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','COMPLAINTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','CUSTOMERLISTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','MANUALINPUTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTN0',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTN1',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTN2',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTN3',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTN4',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTN5',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTN6',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTN7',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTN8',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTN9',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTNASTER',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTNCLEAR',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTNCLOSE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTNENTER',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','NUMPADUI','BTNSHARP',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ORDERASSIGNMENTUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','ORDERSTATUSUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','POS','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','POS','BTNLOOKUPHIDE',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:08','root'),('ADMINISTRATOR','TRANSACTION','POS','BTNLOOKUPSELECT',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:08','root'),('ADMINISTRATOR','TRANSACTION','POS','BTNMENU',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:08','root'),('ADMINISTRATOR','TRANSACTION','POS','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:08','root'),('ADMINISTRATOR','TRANSACTION','POS','BTNVIEWCHECKIN',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:08','root'),('ADMINISTRATOR','TRANSACTION','POS','BTNWALKIN',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:08','root'),('ADMINISTRATOR','TRANSACTION','SAVEDORDERSUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','SAVEDORDERSUI','BTNVOID',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','SAVEDORDERSUI','BTNVOIDPAYMENT',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','SAVEDORDERSUI','BUTTON1',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','VIEWCHECKINUI','',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('ADMINISTRATOR','TRANSACTION','VIEWCHECKINUI','BTNOK',1,'ACTIVE','2009-11-07 14:05:44','root','2010-05-20 18:52:07','root'),('INSTRUCTOR','BUSINESSSHAREDCLASSES','PROGRESSFORM','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CASHIERTRANSACTIONSUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CASHIERTRANSACTIONSUI','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CASHIERTRANSACTIONSUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CASHTERMINALLISTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CASHTERMINALLISTUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CASHTERMINALLISTUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CASHTERMINALLISTUI','BTNEDIT',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CASHTERMINALLISTUI','BTNINSERT',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CASHTERMINALLISTUI','BTNSELECT',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CASHTERMINALLISTUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CLOSESHIFTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CLOSESHIFTUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','CLOSESHIFTUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','EMPLOYEEPAYMENT','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','OPENSHIFTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','OPENSHIFTUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CASHIER','OPENSHIFTUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','COMMON','MESSAGEBOX','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEASSIGNUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEASSIGNUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEASSIGNUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEASSIGNUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEASSIGNUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEASSIGNUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEASSIGNUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEASSIGNUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BIKEUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BUTTONSUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BUTTONSUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BUTTONSUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BUTTONSUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BUTTONSUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BUTTONSUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BUTTONSUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','BUTTONSUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','CUSTOMERUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','EMPLOYEEUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','EMPLOYEEUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','EMPLOYEEUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','EMPLOYEEUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','EMPLOYEEUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','EMPLOYEEUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','EMPLOYEEUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','EMPLOYEEUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','FUNCTIONUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','FUNCTIONUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','FUNCTIONUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','FUNCTIONUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','FUNCTIONUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','FUNCTIONUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','FUNCTIONUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','FUNCTIONUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','GROUPUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','GROUPUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','GROUPUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','GROUPUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','GROUPUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','GROUPUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','GROUPUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','GROUPUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ITEMUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ITEMUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ITEMUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ITEMUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ITEMUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ITEMUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ITEMUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ITEMUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MAINGROUPUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MAINGROUPUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MAINGROUPUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MAINGROUPUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MAINGROUPUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MAINGROUPUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MAINGROUPUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MAINGROUPUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MENUASSIGNMENTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MENUUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MENUUI','BTNBROWSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MENUUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MENUUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MENUUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MENUUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MENUUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MENUUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','MENUUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','OPERATIONUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','OPERATIONUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','OPERATIONUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','OPERATIONUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','OPERATIONUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','OPERATIONUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','OPERATIONUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','OPERATIONUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','RESTAURANTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ROUTEUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ROUTEUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ROUTEUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ROUTEUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ROUTEUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ROUTEUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ROUTEUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','ROUTEUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','CONFIGURATION','TRADINGAREAUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','POSMAIN','RESETUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:00:27','ADMIN'),('INSTRUCTOR','POSMAIN','RESETUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:00:27','ADMIN'),('INSTRUCTOR','POSMAIN','RESETUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:00:27','ADMIN'),('INSTRUCTOR','REPORTS','CASHIERTRANSACTIONUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','CASHIERTRANSACTIONUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','CASHIERTRANSACTIONUI','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','CASHIERTRANSACTIONUI','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','DETAILEDSALESPERORDER','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','DETAILEDSALESPERORDER','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','DETAILEDSALESPERORDER','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','DETAILEDSALES_PER_ITEM','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','DETAILEDSALES_PER_ITEM','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:00:27','ADMIN'),('INSTRUCTOR','REPORTS','DETAILEDSALES_PER_ITEM','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:00:27','ADMIN'),('INSTRUCTOR','REPORTS','EMPLOYEELEDGERDETAILSUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','EMPLOYEEREPORTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','EMPLOYEEREPORTUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','EMPLOYEEREPORTUI','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','EMPLOYEEREPORTUI','BTNSHOWALL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','EMPLOYEEREPORTUI','BTNVIEWDETAILS',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','FOODANDBEVREPORT','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','FOODANDBEVREPORT','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','FOODANDBEVREPORT','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','PARAMPRINTRECEIPTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','PARAMPRINTRECEIPTUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','PARAMPRINTRECEIPTUI','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','REPORTDATEPARAM','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','REPORTPARAMDATEUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','REPORTPREVIEWUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','REPORTSUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','REPORTSUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','REPORTSUI','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','REPORTSUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','SALESREPORT','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','SALESREPORT','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','SALESREPORT','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','SALESREPORT','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','AUTHENTICATEUSERUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','AUTHENTICATEUSERUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','AUTHENTICATEUSERUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','CHANGEPASSWORDUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','FORM1','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','LOGINUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','LOGINUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','LOGINUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','ROLEUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','SYSTEMMENUUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','SYSTEMROLE','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','SECURITY','USERUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ADDCOMPLAINTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ADDFOLIOTRANSACTIONUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ADDFOLIOTRANSACTIONUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ADDFOLIOTRANSACTIONUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ADDITEMNOTESUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ADDITEMNOTESUI','BTNCLEAR',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ADDITEMNOTESUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ADDITEMNOTESUI','BTNMANUAL',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ADDITEMNOTESUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ADDITEMNOTESUI','BTNREMOVELASTNOTE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ASSIGNTABLEUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','CALLERINFOUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','COMPLAINTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','CUSTOMERLISTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','MANUALINPUTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTN0',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTN1',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTN2',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTN3',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTN4',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTN5',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTN6',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTN7',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTN8',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTN9',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTNASTER',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTNCLEAR',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTNENTER',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','NUMPADUI','BTNSHARP',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ORDERASSIGNMENTUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','ORDERSTATUSUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','POS','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','POS','BTNLOOKUPHIDE',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','POS','BTNLOOKUPSELECT',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','POS','BTNMENU',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','POS','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','POS','BTNVIEWCHECKIN',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','POS','BTNWALKIN',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','SAVEDORDERSUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','SAVEDORDERSUI','BTNVOID',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','SAVEDORDERSUI','BTNVOIDPAYMENT',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','SAVEDORDERSUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','VIEWCHECKINUI','',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('INSTRUCTOR','TRANSACTION','VIEWCHECKINUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:27','ADMIN','2010-05-21 14:13:08','root'),('IT','BUSINESSSHAREDCLASSES','PROGRESSFORM','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CASHIERTRANSACTIONSUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CASHIERTRANSACTIONSUI','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CASHIERTRANSACTIONSUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CASHTERMINALLISTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CASHTERMINALLISTUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CASHTERMINALLISTUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CASHTERMINALLISTUI','BTNEDIT',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CASHTERMINALLISTUI','BTNINSERT',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CASHTERMINALLISTUI','BTNSELECT',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CASHTERMINALLISTUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CLOSESHIFTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CLOSESHIFTUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','CLOSESHIFTUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','EMPLOYEEPAYMENT','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','OPENSHIFTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','OPENSHIFTUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CASHIER','OPENSHIFTUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','COMMON','MESSAGEBOX','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEASSIGNUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEASSIGNUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEASSIGNUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEASSIGNUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEASSIGNUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEASSIGNUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEASSIGNUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEASSIGNUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BIKEUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BUTTONSUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BUTTONSUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BUTTONSUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BUTTONSUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BUTTONSUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BUTTONSUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BUTTONSUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','BUTTONSUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','CUSTOMERUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','EMPLOYEEUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','EMPLOYEEUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','EMPLOYEEUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','EMPLOYEEUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','EMPLOYEEUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','EMPLOYEEUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','EMPLOYEEUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','EMPLOYEEUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','FUNCTIONUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','FUNCTIONUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','FUNCTIONUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','FUNCTIONUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','FUNCTIONUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','FUNCTIONUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','FUNCTIONUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','FUNCTIONUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','GROUPUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','GROUPUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','GROUPUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','GROUPUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','GROUPUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','GROUPUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','GROUPUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','GROUPUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ITEMUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ITEMUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ITEMUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ITEMUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ITEMUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ITEMUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ITEMUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ITEMUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MAINGROUPUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MAINGROUPUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MAINGROUPUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MAINGROUPUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MAINGROUPUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MAINGROUPUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MAINGROUPUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MAINGROUPUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MENUASSIGNMENTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MENUUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MENUUI','BTNBROWSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MENUUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MENUUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MENUUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MENUUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MENUUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MENUUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','MENUUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','OPERATIONUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','OPERATIONUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','OPERATIONUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','OPERATIONUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','OPERATIONUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','OPERATIONUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','OPERATIONUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','OPERATIONUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','RESTAURANTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ROUTEUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ROUTEUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ROUTEUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ROUTEUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ROUTEUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ROUTEUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ROUTEUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','ROUTEUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','CONFIGURATION','TRADINGAREAUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','POSMAIN','RESETUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:00:22','ADMIN'),('IT','POSMAIN','RESETUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:00:22','ADMIN'),('IT','POSMAIN','RESETUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:00:22','ADMIN'),('IT','REPORTS','CASHIERTRANSACTIONUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','CASHIERTRANSACTIONUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','CASHIERTRANSACTIONUI','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','CASHIERTRANSACTIONUI','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','DETAILEDSALESPERORDER','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','DETAILEDSALESPERORDER','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','DETAILEDSALESPERORDER','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','DETAILEDSALES_PER_ITEM','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','DETAILEDSALES_PER_ITEM','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:00:22','ADMIN'),('IT','REPORTS','DETAILEDSALES_PER_ITEM','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:00:22','ADMIN'),('IT','REPORTS','EMPLOYEELEDGERDETAILSUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','EMPLOYEEREPORTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','EMPLOYEEREPORTUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','EMPLOYEEREPORTUI','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','EMPLOYEEREPORTUI','BTNSHOWALL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','EMPLOYEEREPORTUI','BTNVIEWDETAILS',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','FOODANDBEVREPORT','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','FOODANDBEVREPORT','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','FOODANDBEVREPORT','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','PARAMPRINTRECEIPTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','PARAMPRINTRECEIPTUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','PARAMPRINTRECEIPTUI','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','REPORTDATEPARAM','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','REPORTPARAMDATEUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','REPORTPREVIEWUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','REPORTSUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','REPORTSUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','REPORTSUI','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','REPORTSUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','SALESREPORT','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','SALESREPORT','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','SALESREPORT','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','SALESREPORT','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','AUTHENTICATEUSERUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','AUTHENTICATEUSERUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','AUTHENTICATEUSERUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','CHANGEPASSWORDUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','FORM1','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','LOGINUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','LOGINUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','LOGINUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','ROLEUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','SYSTEMMENUUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','SYSTEMROLE','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','SECURITY','USERUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ADDCOMPLAINTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ADDFOLIOTRANSACTIONUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ADDFOLIOTRANSACTIONUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ADDFOLIOTRANSACTIONUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ADDITEMNOTESUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ADDITEMNOTESUI','BTNCLEAR',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ADDITEMNOTESUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ADDITEMNOTESUI','BTNMANUAL',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ADDITEMNOTESUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ADDITEMNOTESUI','BTNREMOVELASTNOTE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ASSIGNTABLEUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','CALLERINFOUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','COMPLAINTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','CUSTOMERLISTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','MANUALINPUTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTN0',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTN1',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTN2',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTN3',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTN4',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTN5',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTN6',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTN7',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTN8',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTN9',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTNASTER',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTNCLEAR',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTNENTER',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','NUMPADUI','BTNSHARP',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ORDERASSIGNMENTUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','ORDERSTATUSUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','POS','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','POS','BTNLOOKUPHIDE',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','POS','BTNLOOKUPSELECT',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','POS','BTNMENU',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','POS','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','POS','BTNVIEWCHECKIN',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','POS','BTNWALKIN',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','SAVEDORDERSUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','SAVEDORDERSUI','BTNVOID',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','SAVEDORDERSUI','BTNVOIDPAYMENT',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','SAVEDORDERSUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','VIEWCHECKINUI','',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('IT','TRANSACTION','VIEWCHECKINUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:22','ADMIN','2010-05-21 14:13:03','root'),('USER','BUSINESSSHAREDCLASSES','PROGRESSFORM','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CASHIERTRANSACTIONSUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CASHIERTRANSACTIONSUI','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CASHIERTRANSACTIONSUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CASHTERMINALLISTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CASHTERMINALLISTUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CASHTERMINALLISTUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CASHTERMINALLISTUI','BTNEDIT',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CASHTERMINALLISTUI','BTNINSERT',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CASHTERMINALLISTUI','BTNSELECT',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CASHTERMINALLISTUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CLOSESHIFTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CLOSESHIFTUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','CLOSESHIFTUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','EMPLOYEEPAYMENT','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','OPENSHIFTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','OPENSHIFTUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CASHIER','OPENSHIFTUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','COMMON','MESSAGEBOX','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEASSIGNUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEASSIGNUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEASSIGNUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEASSIGNUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEASSIGNUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEASSIGNUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEASSIGNUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEASSIGNUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BIKEUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BUTTONSUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BUTTONSUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BUTTONSUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BUTTONSUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BUTTONSUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BUTTONSUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BUTTONSUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','BUTTONSUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','CUSTOMERUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','EMPLOYEEUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','EMPLOYEEUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','EMPLOYEEUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','EMPLOYEEUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','EMPLOYEEUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','EMPLOYEEUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','EMPLOYEEUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','EMPLOYEEUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','FUNCTIONUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','FUNCTIONUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','FUNCTIONUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','FUNCTIONUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','FUNCTIONUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','FUNCTIONUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','FUNCTIONUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','FUNCTIONUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','GROUPUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','GROUPUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','GROUPUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','GROUPUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','GROUPUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','GROUPUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','GROUPUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','GROUPUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ITEMUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ITEMUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ITEMUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ITEMUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ITEMUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ITEMUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ITEMUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ITEMUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MAINGROUPUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MAINGROUPUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MAINGROUPUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MAINGROUPUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MAINGROUPUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MAINGROUPUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MAINGROUPUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MAINGROUPUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MENUASSIGNMENTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MENUUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MENUUI','BTNBROWSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MENUUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MENUUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MENUUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MENUUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MENUUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MENUUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','MENUUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','OPERATIONUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','OPERATIONUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','OPERATIONUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','OPERATIONUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','OPERATIONUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','OPERATIONUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','OPERATIONUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','OPERATIONUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','RESTAURANTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ROUTEUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ROUTEUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ROUTEUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ROUTEUI','BTNDELETE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ROUTEUI','BTNNEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ROUTEUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ROUTEUI','BTNSAVE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','ROUTEUI','BTNSEARCH',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','CONFIGURATION','TRADINGAREAUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','POSMAIN','RESETUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:00:14','ADMIN'),('USER','POSMAIN','RESETUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:00:14','ADMIN'),('USER','POSMAIN','RESETUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:00:14','ADMIN'),('USER','REPORTS','CASHIERTRANSACTIONUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','CASHIERTRANSACTIONUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','CASHIERTRANSACTIONUI','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','CASHIERTRANSACTIONUI','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','DETAILEDSALESPERORDER','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','DETAILEDSALESPERORDER','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','DETAILEDSALESPERORDER','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','DETAILEDSALES_PER_ITEM','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','DETAILEDSALES_PER_ITEM','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:00:14','ADMIN'),('USER','REPORTS','DETAILEDSALES_PER_ITEM','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:00:14','ADMIN'),('USER','REPORTS','EMPLOYEELEDGERDETAILSUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','EMPLOYEEREPORTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','EMPLOYEEREPORTUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','EMPLOYEEREPORTUI','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','EMPLOYEEREPORTUI','BTNSHOWALL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','EMPLOYEEREPORTUI','BTNVIEWDETAILS',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','FOODANDBEVREPORT','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','FOODANDBEVREPORT','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','FOODANDBEVREPORT','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','PARAMPRINTRECEIPTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','PARAMPRINTRECEIPTUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','PARAMPRINTRECEIPTUI','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','REPORTDATEPARAM','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','REPORTPARAMDATEUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','REPORTPREVIEWUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','REPORTSUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','REPORTSUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','REPORTSUI','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','REPORTSUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','SALESREPORT','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','SALESREPORT','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','SALESREPORT','BTNPREVIEW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','SALESREPORT','BTNPRINT',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','REPORTS','SUMMARIZEDSALES_BY_SALESITEMGROUPUI','BTNSHOW',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','AUTHENTICATEUSERUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','AUTHENTICATEUSERUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','AUTHENTICATEUSERUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','CHANGEPASSWORDUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','FORM1','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','LOGINUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','LOGINUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','LOGINUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','ROLEUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','SYSTEMMENUUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','SYSTEMROLE','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','SECURITY','USERUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ADDCOMPLAINTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ADDFOLIOTRANSACTIONUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ADDFOLIOTRANSACTIONUI','BTNCANCEL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ADDFOLIOTRANSACTIONUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ADDITEMNOTESUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ADDITEMNOTESUI','BTNCLEAR',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ADDITEMNOTESUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ADDITEMNOTESUI','BTNMANUAL',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ADDITEMNOTESUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ADDITEMNOTESUI','BTNREMOVELASTNOTE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ASSIGNTABLEUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','CALLERINFOUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','COMPLAINTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','CUSTOMERLISTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','MANUALINPUTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTN0',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTN1',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTN2',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTN3',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTN4',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTN5',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTN6',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTN7',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTN8',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTN9',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTNASTER',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTNCLEAR',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTNCLOSE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTNENTER',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','NUMPADUI','BTNSHARP',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ORDERASSIGNMENTUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','ORDERSTATUSUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','POS','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','POS','BTNLOOKUPHIDE',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','POS','BTNLOOKUPSELECT',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','POS','BTNMENU',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','POS','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','POS','BTNVIEWCHECKIN',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','POS','BTNWALKIN',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','SAVEDORDERSUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','SAVEDORDERSUI','BTNVOID',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','SAVEDORDERSUI','BTNVOIDPAYMENT',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','SAVEDORDERSUI','BUTTON1',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','VIEWCHECKINUI','',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root'),('USER','TRANSACTION','VIEWCHECKINUI','BTNOK',1,'ACTIVE','2010-05-21 14:00:14','ADMIN','2010-05-21 14:05:05','root');
/*!40000 ALTER TABLE `role_ui_privileges` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rolemenu`
--

DROP TABLE IF EXISTS `rolemenu`;
CREATE TABLE `rolemenu` (
  `RoleName` varchar(30) NOT NULL,
  `Menu` varchar(50) NOT NULL,
  `Enable` tinyint(1) default '0',
  `stateFlag` varchar(20) default NULL,
  `CreatedBy` varchar(30) default NULL,
  `CreateTime` datetime default '2001-01-01 00:00:00',
  `UpdatedBy` varchar(30) default NULL,
  `UpdateTime` datetime default '2001-01-01 00:00:00',
  PRIMARY KEY  (`RoleName`,`Menu`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `rolemenu`
--

LOCK TABLES `rolemenu` WRITE;
/*!40000 ALTER TABLE `rolemenu` DISABLE KEYS */;
INSERT INTO `rolemenu` VALUES ('ADMINISTRATOR','Backup',0,'ACTIVE','root','2010-05-20 18:52:07','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Bike',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Bike Assignment',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Button Setup',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Cashier',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Cashier Transactions',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Change Password',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Close Shift Cash Drawer',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Complimentary Orders',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Customers',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Daily Kitchen Operation',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Daily Sales Receipt',1,'ACTIVE','root','2009-12-03 12:12:35','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Daily Sales Report',1,'ACTIVE','root','2009-12-02 15:21:25','root','2009-12-02 15:21:25'),('ADMINISTRATOR','Daily Summarized Sales Discount',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Detailed Sales Per Item',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Detailed Sales Per Order',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Detailed Void Orders',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','E-Journal',0,'ACTIVE','root','2010-05-20 18:52:07','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Employee',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Employee Ledger',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Employee Payments',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Employee Reports',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Exit',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','File',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Food and Beverage per Shift',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Food And Beverage Sales',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Function Mapping',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Group',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Item',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Kitchen Staff Report',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Log-out',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Main Group',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Maintenance',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Menu',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','New',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Open',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Open Shift Cash Drawer',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Operation',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Re-print Receipt',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Report Generator',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Reports',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Reset Database',1,'ACTIVE','root','2010-05-20 18:52:07','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Restaurant',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Restaurant Staff Report',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Roles',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Route',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Sales',1,'ACTIVE','root','2009-12-03 12:12:35','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Sales Report',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Save',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Security',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Summarized Charges',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Summarized Items By Group',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Summarized Sales By Group',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Summarized Sales By Main Group',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Summarized Sales By Outlet',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Summarized Sales By Payment',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','System Menu',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Tools',1,'ACTIVE','root','2010-05-20 18:52:07','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Trading area',0,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('ADMINISTRATOR','Users',1,'ACTIVE','root','2009-11-07 14:05:44','root','2010-05-20 18:52:07'),('INSTRUCTOR','Backup',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Bike',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Bike Assignment',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Button Setup',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Cashier',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Cashier Transactions',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Change Password',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Close Shift Cash Drawer',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Complimentary Orders',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Customers',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Daily Kitchen Operation',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Daily Sales Receipt',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Daily Summarized Sales Discount',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Detailed Sales Per Item',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Detailed Sales Per Order',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Detailed Void Orders',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','E-Journal',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Employee',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Employee Ledger',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Employee Payments',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Employee Reports',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Exit',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','File',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Food and Beverage per Shift',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Food And Beverage Sales',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Function Mapping',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Group',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Item',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Kitchen Staff Report',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Log-out',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Main Group',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Maintenance',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Menu',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','New',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Open',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Open Shift Cash Drawer',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Operation',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Re-print Receipt',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Report Generator',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Reports',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Reset Database',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Restaurant',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Restaurant Staff Report',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Roles',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Route',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Sales',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Sales Report',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Save',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Security',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Summarized Charges',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Summarized Items By Group',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Summarized Sales By Group',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Summarized Sales By Main Group',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Summarized Sales By Outlet',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Summarized Sales By Payment',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','System Menu',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Tools',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Trading area',0,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('INSTRUCTOR','Users',1,'ACTIVE','root','2010-05-21 14:07:42','root','2010-05-21 14:13:08'),('IT','Backup',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Bike',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Bike Assignment',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Button Setup',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Cashier',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Cashier Transactions',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Change Password',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Close Shift Cash Drawer',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Complimentary Orders',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Customers',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Daily Kitchen Operation',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Daily Sales Receipt',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Daily Summarized Sales Discount',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Detailed Sales Per Item',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Detailed Sales Per Order',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Detailed Void Orders',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','E-Journal',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Employee',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Employee Ledger',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Employee Payments',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Employee Reports',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Exit',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','File',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Food and Beverage per Shift',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Food And Beverage Sales',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Function Mapping',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Group',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Item',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Kitchen Staff Report',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Log-out',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Main Group',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Maintenance',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Menu',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','New',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Open',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Open Shift Cash Drawer',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Operation',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Re-print Receipt',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Report Generator',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Reports',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Reset Database',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Restaurant',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Restaurant Staff Report',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Roles',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Route',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Sales',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Sales Report',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Save',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Security',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Summarized Charges',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Summarized Items By Group',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Summarized Sales By Group',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Summarized Sales By Main Group',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Summarized Sales By Outlet',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Summarized Sales By Payment',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','System Menu',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Tools',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Trading area',0,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('IT','Users',1,'ACTIVE','root','2010-05-21 14:06:34','root','2010-05-21 14:13:03'),('USER','Backup',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Bike',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Bike Assignment',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Button Setup',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Cashier',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Cashier Transactions',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Change Password',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Close Shift Cash Drawer',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Complimentary Orders',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Customers',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Daily Kitchen Operation',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Daily Sales Receipt',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Daily Summarized Sales Discount',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Detailed Sales Per Item',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Detailed Sales Per Order',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Detailed Void Orders',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','E-Journal',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Employee',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Employee Ledger',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Employee Payments',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Employee Reports',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Exit',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','File',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Food and Beverage per Shift',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Food And Beverage Sales',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Function Mapping',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Group',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Item',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Kitchen Staff Report',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Log-out',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Main Group',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Maintenance',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Menu',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','New',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Open',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Open Shift Cash Drawer',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Operation',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Re-print Receipt',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Report Generator',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Reports',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Reset Database',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Restaurant',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Restaurant Staff Report',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Roles',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Route',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Sales',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Sales Report',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Save',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Security',1,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Summarized Charges',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Summarized Items By Group',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Summarized Sales By Group',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Summarized Sales By Main Group',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Summarized Sales By Outlet',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Summarized Sales By Payment',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','System Menu',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Tools',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Trading area',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05'),('USER','Users',0,'ACTIVE','root','2010-05-21 14:05:05','root','2010-05-21 14:05:05');
/*!40000 ALTER TABLE `rolemenu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles` (
  `ROLE_ID` varchar(100) NOT NULL,
  `DESCRIPTION` varchar(150) default NULL,
  `STATUS` varchar(10) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-08-08 00:00:00',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`ROLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES ('ADMINISTRATOR','SYSTEM ADMINISTRATOR','ACTIVE','JINISYS','2006-08-12 19:53:48','root','2009-02-23 20:18:40'),('INSTRUCTOR','SCHOOL INSTRUCTOR','ACTIVE','ADMIN','2006-08-08 00:00:00','ADMIN','2006-08-08 00:00:00');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `route detail`
--

DROP TABLE IF EXISTS `route detail`;
CREATE TABLE `route detail` (
  `ROUTE_ID` varchar(10) NOT NULL,
  `SEQ_NO` int(11) default NULL,
  `OPERATION` varchar(30) NOT NULL,
  `TIME_DURATION` varchar(20) default NULL,
  PRIMARY KEY  (`ROUTE_ID`,`OPERATION`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `route detail`
--

LOCK TABLES `route detail` WRITE;
/*!40000 ALTER TABLE `route detail` DISABLE KEYS */;
INSERT INTO `route detail` VALUES ('ROUTE 15',20,'ASSEMBLE','00:05:00'),('ROUTE 15',10,'NEW','00:05:00'),('ROUTE 15',30,'SERVED','00:05:00'),('ROUTE-30',20,'ASSEMBLE','00:10:00'),('ROUTE-30',30,'DELIVER','00:15:00'),('ROUTE-30',10,'REGISTER','00:05:00'),('ROUTE-45',20,'ASSEMBLE','00:20:00'),('ROUTE-45',30,'DELIVER','00:20:00'),('ROUTE-45',10,'REGISTER','00:05:00'),('ROUTE-50',20,'ASSEMBLE','00:10:00'),('ROUTE-50',40,'DELIVER','00:20:00'),('ROUTE-50',30,'PREPARE','00:10:00'),('ROUTE-50',10,'REGISTER','00:10:00');
/*!40000 ALTER TABLE `route detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `route header`
--

DROP TABLE IF EXISTS `route header`;
CREATE TABLE `route header` (
  `ROUTE_ID` varchar(10) NOT NULL,
  `DESCRIPTION` varchar(100) default NULL,
  `TOTAL_TIME` varchar(20) default NULL,
  `DEFAULT` tinyint(4) default NULL,
  `STATUS` varchar(7) default NULL,
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-01-01 00:00:01',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-01-01 00:00:01',
  PRIMARY KEY  (`ROUTE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `route header`
--

LOCK TABLES `route header` WRITE;
/*!40000 ALTER TABLE `route header` DISABLE KEYS */;
INSERT INTO `route header` VALUES ('COMBO MEAL','STANDARD ROUTE FOR COMBO MEAL','00:39:00',1,'DELETED','ADMIN','2006-08-08 20:00:59','ADMIN','2006-08-11 20:08:32'),('DRINKS','STANDARD ROUTE FOR DRINKS','00:40:15',1,'DELETED','ADMIN','2006-08-09 18:24:26','ADMIN','2006-08-11 20:08:21'),('FOOD','STANDARD ROUTE FOR FOOD','09:30:15',1,'DELETED','ADMIN','2006-08-08 20:06:50','ADMIN','2006-08-11 20:08:25'),('ROUTE 15','STANDARD ROUTE FOR 15 MINS','00:15:00',0,'ACTIVE','root','2006-09-14 18:23:48','root','2006-09-14 18:23:48'),('ROUTE-30','STANDARD ROUTE FOR 30 MINS','00:30:00',0,'ACTIVE','root','2006-09-02 13:41:47','root','2006-09-14 18:24:15'),('ROUTE-45','STANDARD ROUTE FOR 45 MINS','00:45:00',0,'ACTIVE','ADMIN','2006-08-11 20:11:33','root','2006-09-14 18:24:38'),('ROUTE-50','STANDARD ROUTE FOR 50 MINS','00:50:00',0,'ACTIVE','','2006-08-16 17:56:13','','2006-08-16 17:56:13');
/*!40000 ALTER TABLE `route header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `routing`
--

DROP TABLE IF EXISTS `routing`;
CREATE TABLE `routing` (
  `OrderID` varchar(30) NOT NULL,
  `Details` varchar(500) default NULL,
  `AssignTo` varchar(30) default NULL,
  `EllapseTime` datetime default NULL,
  `Status` varbinary(30) default NULL,
  PRIMARY KEY  (`OrderID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `routing`
--

LOCK TABLES `routing` WRITE;
/*!40000 ALTER TABLE `routing` DISABLE KEYS */;
/*!40000 ALTER TABLE `routing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seq_customer`
--

DROP TABLE IF EXISTS `seq_customer`;
CREATE TABLE `seq_customer` (
  `id` bigint(20) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `seq_customer`
--

LOCK TABLES `seq_customer` WRITE;
/*!40000 ALTER TABLE `seq_customer` DISABLE KEYS */;
INSERT INTO `seq_customer` VALUES (1);
/*!40000 ALTER TABLE `seq_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seq_orders`
--

DROP TABLE IF EXISTS `seq_orders`;
CREATE TABLE `seq_orders` (
  `id` bigint(20) NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `seq_orders`
--

LOCK TABLES `seq_orders` WRITE;
/*!40000 ALTER TABLE `seq_orders` DISABLE KEYS */;
INSERT INTO `seq_orders` VALUES (1);
/*!40000 ALTER TABLE `seq_orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service_charge`
--

DROP TABLE IF EXISTS `service_charge`;
CREATE TABLE `service_charge` (
  `SERVICE_CHARGE` decimal(12,2) default '0.00'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `service_charge`
--

LOCK TABLES `service_charge` WRITE;
/*!40000 ALTER TABLE `service_charge` DISABLE KEYS */;
INSERT INTO `service_charge` VALUES ('0.00');
/*!40000 ALTER TABLE `service_charge` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `system_privileges`
--

DROP TABLE IF EXISTS `system_privileges`;
CREATE TABLE `system_privileges` (
  `id` int(10) NOT NULL auto_increment,
  `privilegeDescription` varchar(100) default NULL,
  `createdBy` varchar(50) default NULL,
  `createTime` datetime default '2008-08-08 01:01:01',
  `updatedBy` varchar(50) default NULL,
  `updateTime` datetime default '2008-08-08 01:01:01',
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `system_privileges`
--

LOCK TABLES `system_privileges` WRITE;
/*!40000 ALTER TABLE `system_privileges` DISABLE KEYS */;
/*!40000 ALTER TABLE `system_privileges` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `systemmenus`
--

DROP TABLE IF EXISTS `systemmenus`;
CREATE TABLE `systemmenus` (
  `MENU_NAME` varchar(30) NOT NULL,
  `DESCRIPTION` text,
  `STATUS` varchar(10) default 'ACTIVE',
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-08-08 00:00:00',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`MENU_NAME`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `systemmenus`
--

LOCK TABLES `systemmenus` WRITE;
/*!40000 ALTER TABLE `systemmenus` DISABLE KEYS */;
INSERT INTO `systemmenus` VALUES ('BIKE','BIKE','ACTIVE','root','2007-03-21 20:19:33','root','2007-03-21 20:19:33'),('BUTTON SETUP','SEP UP THE BUTTONS IN MAIN POS WINDOW','ACTIVE','root','2007-03-22 17:31:14','root','2007-03-22 17:31:14'),('CASHIER','CASHIER','ACTIVE','root','2007-03-21 20:03:11','root','2007-03-21 20:03:11'),('CASHIER TRANSACTIONS','FOR CASHIER TRANSACTIONS ','ACTIVE','root','2007-03-30 13:06:39','root','2007-03-30 13:06:39'),('CLOSE SHIFT CASH DRAWER','CLOSE SHIFT CASH DRAWER','ACTIVE','root','2007-03-22 16:06:08','root','2007-03-22 16:06:08'),('CLOSE SHIFT CLOSE DRAWER','CLOSE SHIFT CLOSE DRAWER','DELETED','root','2007-03-22 16:04:41','root','2007-03-22 16:05:54'),('CUSTOMERS','CONFIGURATION FOR CUSTOMERS','ACTIVE','root','2007-03-22 19:14:03','root','2007-03-22 19:14:03'),('DETAILED SALES PER ITEM','DETAILED SALES PER ITEM','ACTIVE','root','2007-06-01 21:36:33','root','2007-06-01 21:36:33'),('EDIT','EDIT','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00'),('EMPLOYEE','CONFIGURATION FOR EMPLOYEE','ACTIVE','root','2007-03-22 19:12:55','root','2007-03-22 19:12:55'),('EMPLOYEE CREDIT','EMPLOYEE CREDIT','ACTIVE','root','2007-05-23 10:23:24','root','2007-05-23 10:23:24'),('EMPLOYEE CREDIT ACCOUNT','EMPLOYEE CREDIT ACCOUNT','DELETED','root','2007-05-22 14:14:42','root','2007-05-23 10:23:10'),('EMPLOYEE PAYMENTS','EMPLOYEE PAYMENTS','ACTIVE','root','2007-05-25 11:06:55','root','2007-05-25 11:06:55'),('FILE','FILE','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00'),('FOOD AND BEVERAGE','FOOD AND BEVERAGE','ACTIVE','root','2007-04-21 16:21:18','root','2007-04-21 16:21:36'),('GROUP','GROUP','ACTIVE','root','2007-05-31 09:42:05','root','2007-05-31 09:42:05'),('ITEM','ITEM','ACTIVE','root','2007-03-21 20:19:49','root','2007-03-21 20:19:49'),('LOG-IN','LOG-IN','ACTIVE',NULL,'2006-08-08 00:00:00',NULL,'2006-08-08 00:00:00'),('LOG-OUT','LOG-OUT USER','ACTIVE','root','2007-03-21 20:13:36','root','2007-03-21 20:13:36'),('MAIN GROUP','MAIN GROUP','ACTIVE','root','2007-05-31 09:41:13','root','2007-05-31 09:41:13'),('MAINTENANCE','MAINTENANCE','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00'),('MENU','MENU GUD','ACTIVE','root','2007-03-28 15:59:50','root','2007-03-28 15:59:50'),('OPEN SHIFT CASH DRAWER','OPEN SHIFT CASH DRAWER','ACTIVE','root','2007-03-22 16:04:30','root','2007-03-22 16:04:30'),('OPERATION','OPERATION','ACTIVE','root','2007-03-21 20:19:39','root','2007-03-21 20:19:39'),('RE-PRINT RECEIPT','RE-PRINT RECEIPT','ACTIVE','root','2009-02-23 20:18:20','root','2009-02-23 20:18:20'),('REPORT GENERATOR','GENERATE REPORTS','ACTIVE','root','2007-05-18 10:54:46','root','2007-05-18 10:54:46'),('REPORTS','REPORTS','ACTIVE','root','2007-03-21 20:03:21','root','2007-03-21 20:03:21'),('ROSE','ROSE','DELETED','root','2007-05-31 17:13:41','root','2007-05-31 17:13:47'),('ROUTE','ROUTE PROCESS','ACTIVE','root','2007-03-22 19:12:23','root','2007-03-22 19:12:23'),('SALES REPORT','SALES REPORT','ACTIVE','root','2007-04-21 15:53:57','root','2007-04-21 15:53:57'),('SECURITY','SECURITY','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00'),('SUMMARIZED SALES BY GROUP','SUMMARIZED SALES BY GROUP','ACTIVE','root','2007-06-01 23:40:55','root','2007-06-01 23:40:55'),('SYSTEM MENU','SYSTEM MENU','ACTIVE',NULL,'2006-08-08 00:00:00',NULL,'2006-08-08 00:00:00'),('USERS','USERS','ACTIVE','root','2007-03-21 20:23:56','root','2007-03-21 20:23:56');
/*!40000 ALTER TABLE `systemmenus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `table_assignment`
--

DROP TABLE IF EXISTS `table_assignment`;
CREATE TABLE `table_assignment` (
  `TABLE_NO` varchar(5) NOT NULL,
  `ROOM_ID` varchar(50) default NULL,
  `FOLIO_ID` varchar(20) default NULL,
  `NAME` varchar(100) default NULL,
  `STATUS` varchar(20) default NULL,
  `ORDER_ID` int(10) default NULL,
  `TERMINAL_ID` varchar(5) default NULL,
  PRIMARY KEY  (`TABLE_NO`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `table_assignment`
--

LOCK TABLES `table_assignment` WRITE;
/*!40000 ALTER TABLE `table_assignment` DISABLE KEYS */;
/*!40000 ALTER TABLE `table_assignment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tables`
--

DROP TABLE IF EXISTS `tables`;
CREATE TABLE `tables` (
  `TABLE_NO` varchar(5) NOT NULL,
  `DESCRIPTION` varchar(300) default NULL,
  `STATUS` varchar(20) default NULL,
  `CREATETIME` datetime default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default NULL,
  `UPDATEDBY` varchar(30) default '2001-01-01 01:01:01',
  PRIMARY KEY  (`TABLE_NO`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tables`
--

LOCK TABLES `tables` WRITE;
/*!40000 ALTER TABLE `tables` DISABLE KEYS */;
INSERT INTO `tables` VALUES ('01','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('02','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('03','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('04','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('05','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('06','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('07','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('08','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('09','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('10','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('11','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('12','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('13','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('14','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('15','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('16','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('17','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('18','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('19','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('20','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('21','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('22','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('23','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('24','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('25','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('26','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('27','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('28','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('29','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('30','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('31','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('32','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('33','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('34','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('35','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('36','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('37','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('38','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('39','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('40','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('41','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('42','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('43','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('44','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('45','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('46','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('47','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('48','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('49','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin'),('50','','ACTIVE','2008-12-11 16:10:30','admin','2008-12-11 16:10:30','admin');
/*!40000 ALTER TABLE `tables` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tradingareas`
--

DROP TABLE IF EXISTS `tradingareas`;
CREATE TABLE `tradingareas` (
  `AREA_CODE` varchar(10) NOT NULL,
  `DESCRIPTION` varchar(100) default NULL,
  `STATUS` varchar(10) default 'ACTIVE',
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-08-08 00:00:00',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`AREA_CODE`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tradingareas`
--

LOCK TABLES `tradingareas` WRITE;
/*!40000 ALTER TABLE `tradingareas` DISABLE KEYS */;
INSERT INTO `tradingareas` VALUES ('B. ROD','B. RODRIGUEZ','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00'),('JONES','JONES','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00'),('MANGO','MANGO','ACTIVE','JINISYS','2006-08-08 00:00:00','JINISYS','2006-08-08 00:00:00');
/*!40000 ALTER TABLE `tradingareas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_roles`
--

DROP TABLE IF EXISTS `user_roles`;
CREATE TABLE `user_roles` (
  `USER_ID` varchar(30) NOT NULL,
  `ROLE_ID` varchar(50) NOT NULL,
  `STATUS` varchar(10) default 'ACTIVE',
  `CREATEDBY` varchar(30) default NULL,
  `CREATETIME` datetime default '2006-08-08 00:00:00',
  `UPDATEDBY` varchar(30) default NULL,
  `UPDATETIME` datetime default '2006-08-08 00:00:00',
  PRIMARY KEY  (`USER_ID`,`ROLE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_roles`
--

LOCK TABLES `user_roles` WRITE;
/*!40000 ALTER TABLE `user_roles` DISABLE KEYS */;
INSERT INTO `user_roles` VALUES ('instructor','INSTRUCTOR','ACTIVE','root','2010-05-21 14:09:49','root','2010-05-21 14:09:49'),('root','ADMINISTRATOR','ACTIVE','root','2009-09-10 11:06:21','root','2009-09-10 11:06:21');
/*!40000 ALTER TABLE `user_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userprivilege`
--

DROP TABLE IF EXISTS `userprivilege`;
CREATE TABLE `userprivilege` (
  `hotelid` int(5) unsigned zerofill NOT NULL default '00000',
  `userid` varchar(20) NOT NULL default '',
  `access` varchar(20) NOT NULL default '',
  `level` int(11) NOT NULL default '0',
  `stateflag` varchar(10) NOT NULL default '',
  `CREATETIME` datetime default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2001-01-01 01:01:01',
  `UPDATEDBY` varchar(20) default NULL,
  PRIMARY KEY  (`hotelid`,`userid`,`access`,`level`),
  KEY `privilege_index` (`hotelid`,`access`,`level`),
  KEY `FK_userprivilege` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

--
-- Dumping data for table `userprivilege`
--

LOCK TABLES `userprivilege` WRITE;
/*!40000 ALTER TABLE `userprivilege` DISABLE KEYS */;
/*!40000 ALTER TABLE `userprivilege` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `userId` varchar(30) NOT NULL,
  `LastName` varchar(50) default NULL,
  `FirstName` varchar(50) default NULL,
  `MiddleName` varchar(50) default NULL,
  `Department` varchar(50) default NULL,
  `Designation` varchar(30) default NULL,
  `Password` text,
  `Status` varchar(10) default NULL,
  `Createdby` varchar(30) default NULL,
  `CreateTime` datetime default '2006-01-01 00:00:01',
  `Updatedby` varchar(30) default NULL,
  `UpdateTime` datetime default '2006-01-01 00:00:01',
  PRIMARY KEY  (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('instructor','INSTRUCTOR',' ',' ',' ','TEACHER','175cca0310b93021a7d3cfb3e4877ab6','ACTIVE','root','2010-05-21 14:09:49','root','2010-05-21 14:09:49'),('root','INC','JINISYS','INC','SOFTWARE','SYS_AD','c970f9108250bdee586687c39028bd86','ACTIVE','JINISYS','2006-01-01 00:00:01','root','2009-09-10 11:06:21');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendors`
--

DROP TABLE IF EXISTS `vendors`;
CREATE TABLE `vendors` (
  `VendorID` varchar(20) NOT NULL,
  `Name` varchar(100) default NULL,
  `HOTELID` int(5) default NULL,
  `CREATETIME` datetime default '2001-01-01 01:01:01',
  `CREATEDBY` varchar(20) default NULL,
  `UPDATETIME` datetime default '2001-01-01 01:01:01',
  `UPDATEDBY` varchar(20) default NULL,
  PRIMARY KEY  (`VendorID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vendors`
--

LOCK TABLES `vendors` WRITE;
/*!40000 ALTER TABLE `vendors` DISABLE KEYS */;
INSERT INTO `vendors` VALUES ('101','BIR-1',NULL,NULL,NULL,NULL,NULL),('102','BIR-2',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `vendors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'pos'
--
DELIMITER ;;
/*!50003 DROP FUNCTION IF EXISTS `fGetAccountCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetAccountCharge`(orderid varchar(15)) RETURNS decimal(10,2)
BEGIN
return (select sum(amount) from payment where order_id=orderid
and (payment_type='ACCOUNT' OR payment_type='ACCOUNT_EMPLOYEE'));
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCashPayment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetCashPayment`(orderid varchar(15)) RETURNS decimal(10,2)
BEGIN
return (select sum(amount) from payment where order_id=orderid
and (payment_type='CASH' or payment_type='XDEAL') and `status`<>'VOID');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCashPaymentPerOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetCashPaymentPerOrder`(
pOrderID int(11)
) RETURNS decimal(12,2)
BEGIN
return (
select
if(`order header`.balance = 0 ,payment.amount, payment.amount + `order header`.balance)
as  Cash
from payment left join
`order header` on payment.order_id = `order header`.order_id
where
payment.order_id = pOrderID
and payment.payment_type = 'CASH'
limit 0,1
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetComplimentaryPaymentPerOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetComplimentaryPaymentPerOrder`(
pOrderID int(11)
) RETURNS decimal(12,2)
BEGIN
return (
select
payment.amount as  Complimentary
from payment left join
`order header` on payment.order_id = `order header`.order_id
where
payment.order_id = pOrderID
and ((payment.payment_type = 'COMPLIMENTARY'
and Coupon_No = 'COMPLIMENTARY') or
(payment.payment_type = 'Coupon'
and Coupon_No = 'COMPLIMENTARY'))
limit 0,1
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCouponPaymentPerOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetCouponPaymentPerOrder`(
pOrderID int(11)
) RETURNS decimal(12,2)
BEGIN
return (
select
payment.amount as  Coupon
from payment left join
`order header` on payment.order_id = `order header`.order_id
where
payment.order_id = pOrderID
and payment.payment_type = 'Coupon'
and payment.Coupon_No != 'COMPLIMENTARY'
limit 0,1
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCreditCardPaymentPerOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetCreditCardPaymentPerOrder`(
pOrderID int(11)
) RETURNS decimal(12,2)
BEGIN
return (
select
payment.amount  as  CreditCard
from payment left join
`order header` on payment.order_id = `order header`.order_id
where
payment.order_id = pOrderID 
and payment.payment_type = 'Credit'
limit 0,1
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCreditPayment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetCreditPayment`(orderid varchar(15)) RETURNS decimal(10,2)
BEGIN
return (select sum(amount) from payment where order_id=orderid
and payment_type='Credit');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetCustomerNamePerOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetCustomerNamePerOrder`(
pCustomerID varchar(20),
pEmployeeID varchar(20)
) RETURNS text CHARSET latin1
BEGIN
return (
case substring(pCustomerID,1,2)
when 'F-' then
getguestnamefromhotel(pCustomerID)
when 'WA' then
'WALK-IN CUSTOMER'
else
fGetEmployeeName(pEmployeeID)
end
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetDiscount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetDiscount`(pOrderID int(15)) RETURNS decimal(12,2)
BEGIN
return (
select sum(`order detail`.unit_price)
from `order detail`
where unit_price < 0 and
order_id = pOrderID
and operation_status <> 'CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetDiscountBEV` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetDiscountBEV`(pOrderID int(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.unit_price) from `order detail`, item, `group`, `order header`
where `order detail`.order_id=pOrderID and `order header`.order_id=`order detail`.order_id
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.ditem_id=item.item_id and `order detail`.item_id<>item.item_id and
item.group_id=`group`.group_id and `group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetEmployeeAccountPaymentPerOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetEmployeeAccountPaymentPerOrder`(
pOrderID int(11)
) RETURNS decimal(12,2)
BEGIN
return (
select
payment.amount as  ACCOUNT_EMPLOYEE
from payment left join
`order header` on payment.order_id = `order header`.order_id
where
payment.order_id = pOrderID
and payment.payment_type = 'ACCOUNT_EMPLOYEE'
limit 0,1
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetEmployeeID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetEmployeeID`(pNickname varchar(30)) RETURNS varchar(30) CHARSET latin1
BEGIN
return (select employee_id from employee where nickname=pNickname and `position`='KITCHEN CREW');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetEmployeeName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetEmployeeName`(pID varchar(20)) RETURNS varchar(50) CHARSET latin1
BEGIN
return (select concat(firstname, ' ', lastname) from employee where
employee_id=pID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetEmployeeNameByOrderID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetEmployeeNameByOrderID`(pEmpId bigint(15)) RETURNS varchar(50) CHARSET latin1
BEGIN
return (select concat(lastname,' ' ,firstname) from employee,`order header`
where `order header`.employee_id=pEmpId and `order header`.employee_id=employee.employee_id);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetEmployeeNickName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetEmployeeNickName`(pID varchar(20)) RETURNS varchar(50) CHARSET latin1
BEGIN
return (select nickname from employee where
employee_id=pID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetExDealPaymentPerOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetExDealPaymentPerOrder`(
pOrderID int(11)
) RETURNS decimal(12,2)
BEGIN
return (
select
payment.amount as  Exdeal
from payment left join
`order header` on payment.order_id = `order header`.order_id
where
payment.order_id = pOrderID
and payment.payment_type = 'XDEAL'
limit 0,1
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetGuestAccountPaymentPerOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetGuestAccountPaymentPerOrder`(
pOrderID int(11)
) RETURNS decimal(12,2)
BEGIN
return (
select
payment.amount as  Account
from payment left join
`order header` on payment.order_id = `order header`.order_id
where
payment.order_id = pOrderID
and payment.payment_type = 'Account'
limit 0,1
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetGuestName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetGuestName`(pFolioID varchar(30)) RETURNS text CHARSET latin1
BEGIN
return (select if(folio.foliotype='GROUP', if(substring(folio.companyid,1,1)='G', `hotelmgtsystem`.fGetCompanyName(folio.companyid), `hotelmgtsystem`.fGetGuestName(folio.companyid)), `hotelmgtsystem`.fGetGuestName(folio.accountid)) from `hotelmgtsystem`.folio where folio.folioid=pFolioID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetHotelFolioAccountID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetHotelFolioAccountID`(pFolioID varchar(15)) RETURNS varchar(15) CHARSET latin1
BEGIN
return (select accountId from `hotelmgtsystem`.folio where `hotelmgtsystem`.folio.folioid = pFolioID );
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetLastIDInOrderHistory` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetLastIDInOrderHistory`(pOrderID int(11)) RETURNS int(11)
BEGIN
return(Select max(id) from `order history` where order_id=pOrderid);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetMonthToDateGrossSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetMonthToDateGrossSales`(pMonth int, pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount) from `order header` where month(order_date)=pMonth and year(order_date)=pYear and status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetMonthToDateNonVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetMonthToDateNonVATSales`(pMonth int, pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(nonvat_sales) from `order header` where month(order_date)=pMonth and year(order_date)=pYear and status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetMonthToDateVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetMonthToDateVATSales`(pMonth int, pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(vat_sales) from `order header` where month(order_date)=pMonth and year(order_date)=pYear and status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetOrderIDs` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetOrderIDs`(pEmpID varchar(30)) RETURNS text CHARSET latin1
BEGIN
return (SELECT GROUP_CONCAT(`order header`.order_id separator ', ')
from `order header`, employee
where employee.employee_id=pEmpID and
employee.employee_id=`order header`.assigned_to 
and (`order header`.`status`='NEWORDER' or `order header`.`status`='ASSEMBLING')
group by employee.employee_id);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetOrders`(pEmpId varchar(30)) RETURNS text CHARSET latin1
BEGIN
return (SELECT GROUP_CONCAT(concat(`order detail`.QUANTITY,' pc(s) ',menu.DESCRIPTION) SEPARATOR '\n')
from menu, `order detail`, `order header`, employee
where employee.employee_id=pEmpId and 
employee.employee_id=`order header`.assigned_to AND 
menu.MENU_ID=`order detail`.ITEM_ID and `order header`.ORDER_ID=`order detail`.ORDER_ID
and NOT(`order header`.`status`='CANCELLED' or `order header`.`status`='SERVED')
AND `order detail`.route=true
group by employee.employee_id);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetPaymentsPerOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetPaymentsPerOrder`(
pOrderID varchar(20)
) RETURNS text CHARSET latin1
BEGIN
return (
select 
GROUP_CONCAT( 
PAYMENT_TYPE,' : ', format(AMOUNT,2) ,
if(PAYMENT_TYPE = 'CASH', concat('\r\nChange: ',
if(payment.amount > `order header`.TOTAL_AMOUNT,
format((payment.amount - `order header`.TOTAL_AMOUNT),2),0.00)),''),
if(PAYMENT_TYPE = 'Credit',concat('\r\nApproval Code: ',APPROVAL_CODE),''),
if(PAYMENT_TYPE = 'Coupon',concat('\r\nCoupon Type: ',Coupon_Type),''),
if(PAYMENT_TYPE = 'Coupon',concat('\r\nCoupon No: ',COUPON_NO),'')
SEPARATOR '\r\n' ) 
from payment 
left join `order header` on
`order header`.ORDER_ID = payment.ORDER_ID
where payment.ORDER_ID = pOrderID
group by payment.ORDER_ID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetServiceChargebyOrderID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetServiceChargebyOrderID`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.service_charge) 
from `order detail`, item, `group`
where `order detail`.order_id=pOrderID
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.item_id=item.item_id and 
item.group_id=`group`.group_id and `group`.maingroup_id<>'BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetServiceChargebyOrderIDBev` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetServiceChargebyOrderIDBev`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.service_charge) 
from `order detail`, item, `group`
where `order detail`.order_id=pOrderID
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.item_id=item.item_id and 
item.group_id=`group`.group_id and `group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetServiceChargeForEmployee` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetServiceChargeForEmployee`(pMonth int(2)) RETURNS decimal(12,2)
BEGIN
return (select sum(distinct `order header`.service_charge)/
count(distinct(`employee account`.employee_id)) as Employee_Payment
from `order header`, employee, service_charge
where month(`order header`.order_date)=pMonth);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTaxbyOrderID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTaxbyOrderID`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (
Select sum((`order detail`.unit_price*`order detail`.quantity)-`order detail`.amount-`order detail`.service_charge)
from `order detail`, item, `group`, payment
where `order detail`.order_id=pOrderID
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.order_id=payment.order_id
and `order detail`.item_id=item.item_id
and item.group_id=`group`.group_id and `group`.maingroup_id<>'BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTaxbyOrderIDBEV` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTaxbyOrderIDBEV`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (
Select sum((`order detail`.unit_price*`order detail`.quantity)-`order detail`.amount-`order detail`.service_charge)
from `order detail`, item, `group`, payment
where `order detail`.order_id=pOrderID
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.order_id=payment.order_id
and `order detail`.item_id=item.item_id
and item.group_id=`group`.group_id and `group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalAccount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalAccount`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select
sum(`order detail`.unit_price * `order detail`.quantity) from `order detail`, item, `group`, `order header`,
payment
where `order detail`.order_id=pOrderID and `order header`.order_id=`order detail`.order_id
and `order detail`.operation_status <> 'CANCELLED'
and `order header`.order_id=payment.order_id and payment.payment_type='ACCOUNT'
and `order detail`.item_id=item.item_id and
item.group_id=`group`.group_id and
`group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalAccountEmp` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalAccountEmp`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.unit_price * `order detail`.quantity) from `order detail`, item, `group`, `order header`, payment
where `order detail`.order_id=pOrderID and `order header`.order_id=`order detail`.order_id
and `order detail`.operation_status <> 'CANCELLED'
and `order header`.order_id=payment.order_id and payment.payment_type='ACCOUNT_EMPLOYEE'
and `order detail`.item_id=item.item_id and 
item.group_id=`group`.group_id and `group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalAmount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalAmount`(pEmployeeID varchar(30)) RETURNS double(12,2)
BEGIN
return (select sum(`order header`.total_amount) as amt from `order header` where `order header`.assigned_to=pEmployeeID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalAmountbyOrderID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalAmountbyOrderID`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.unit_price * `order detail`.quantity) from `order detail`, item, `group`, `order header`
where `order detail`.order_id=pOrderID and `order header`.order_id=`order detail`.order_id
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.item_id=item.item_id and 
item.group_id=`group`.group_id and `group`.maingroup_id<>'BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalAmountbyOrderIDBEV` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalAmountbyOrderIDBEV`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.unit_price * `order detail`.quantity) from `order detail`, item, `group`, `order header`
where `order detail`.order_id=pOrderID and `order header`.order_id=`order detail`.order_id
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.item_id=item.item_id and 
item.group_id=`group`.group_id and `group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalBEVbyOrderID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalBEVbyOrderID`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.unit_price * `order detail`.quantity) from `order detail`, item, `group`, `order header`
where `order detail`.order_id=pOrderID and `order header`.order_id=`order detail`.order_id
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.item_id=item.item_id and 
item.group_id=`group`.group_id and `group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalCash` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalCash`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.unit_price * `order detail`.quantity) from `order detail`, item, `group`, `order header`, payment
where `order detail`.order_id = pOrderID and `order header`.order_id=`order detail`.order_id
and `order detail`.operation_status <> 'CANCELLED'
and `order header`.order_id = payment.order_id and payment.payment_type='CASH'
and `order detail`.item_id=item.item_id and 
item.group_id=`group`.group_id and `group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalCharges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetTotalCharges`(pStartDate date,
pEndDate date) RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount) from `order header` 
where `order header`.`status`='SERVED'
AND `order header`.total_payment=0.00 and 
(`order header`.ORDER_DATE >= pStartDate and
`order header`.ORDER_DATE <= pEndDate));
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalCredit` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalCredit`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.unit_price * `order detail`.quantity) from `order detail`, item, `group`, `order header`, payment
where `order detail`.order_id=pOrderID and `order header`.order_id=`order detail`.order_id
and `order detail`.operation_status <> 'CANCELLED'
and `order header`.order_id=payment.order_id and payment.payment_type='CREDIT'
and `order detail`.item_id=item.item_id and 
item.group_id=`group`.group_id and `group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalDiscount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetTotalDiscount`(pStartDate date,
pEndDate date) RETURNS decimal(12,2)
BEGIN
return (select sum(total_discount) from `order header` 
where `order header`.`status`='SERVED' and 
(`order header`.ORDER_DATE >= pStartDate and
`order header`.ORDER_DATE <= pEndDate));
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalDiscountPerItem` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetTotalDiscountPerItem`(pStartDate date,
pEndDate date, pItemID varchar(10)) RETURNS decimal(12,2)
BEGIN
return (select sum(discount) from `order detail`, `order header`
where `order detail`.`operation_status`!='CANCELLED' and 
(`order header`.ORDER_DATE >= pStartDate and
`order header`.ORDER_DATE <= pEndDate) and `order detail`.order_id=`order header`.order_id and item_id=pItemID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalFoodbyOrderID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalFoodbyOrderID`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.unit_price * `order detail`.quantity) from `order detail`, item, `group`, `order header`
where `order detail`.order_id=pOrderID and `order header`.order_id=`order detail`.order_id
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.item_id=item.item_id and 
item.group_id=`group`.group_id and `group`.maingroup_id<>'BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalGrossSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetTotalGrossSales`() RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount) from `order header` where status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalNonVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetTotalNonVATSales`() RETURNS decimal(12,2)
BEGIN
return (select sum(nonvat_sales) from `order header` where status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalOthers` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetTotalOthers`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.unit_price * `order detail`.quantity) from `order detail`, item, `group`, `order header`, payment
where `order detail`.order_id=pOrderID and `order header`.order_id=`order detail`.order_id
and `order detail`.operation_status <> 'CANCELLED'
and `order header`.order_id=payment.order_id and (payment.payment_type<>'CASH'
and payment.payment_type<>'CREDIT' and payment.payment_type<>'ACCOUNT' and payment.payment_type<>'ACCOUNT_EMPLOYEE')
and `order detail`.item_id=item.item_id and 
item.group_id=`group`.group_id and `group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalPaymentType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetTotalPaymentType`(pOrderID int(11)) RETURNS int(2)
BEGIN
return (select count(payment_type) from payment where order_id=pOrderID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetTotalVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetTotalVATSales`() RETURNS decimal(12,2)
BEGIN
return (select sum(vat_sales) from `order header` where status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVatSalesbyOrderID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetVatSalesbyOrderID`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.amount) from `order detail`, item, `group`
where `order detail`.order_id=pOrderID
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.item_id=item.item_id
and item.group_id=`group`.group_id and `group`.maingroup_id<>'BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVatSalesbyOrderIDBEV` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fGetVatSalesbyOrderIDBEV`(pOrderID bigint(15)) RETURNS decimal(12,2)
BEGIN
return (Select sum(`order detail`.amount) from `order detail`, item, `group`
where `order detail`.order_id=pOrderID
and `order detail`.operation_status <> 'CANCELLED'
and `order detail`.item_id=item.item_id
and item.group_id=`group`.group_id and `group`.maingroup_id='BEVERAGES');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVoidMonthToDateGrossSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetVoidMonthToDateGrossSales`(pMonth int, pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount) from `order header` where month(order_date)=pMonth and year(order_date)=pYear and status='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVoidMonthToDateNonVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetVoidMonthToDateNonVATSales`(pMonth int, pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(nonvat_sales) from `order header` where month(order_date)=pMonth and year(order_date)=pYear and status='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVoidMonthToDateVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetVoidMonthToDateVATSales`(pMonth int, pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(vat_sales) from `order header` where month(order_date)=pMonth and year(order_date)=pYear and status='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVoidTotalGrossSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetVoidTotalGrossSales`() RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount) from `order header` where status='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVoidTotalNonVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetVoidTotalNonVATSales`() RETURNS decimal(12,2)
BEGIN
return (select sum(nonvat_sales) from `order header` where status='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVoidTotalVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetVoidTotalVATSales`() RETURNS decimal(12,2)
BEGIN
return (select sum(vat_sales) from `order header` where status='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVoidYearToDateGrossSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetVoidYearToDateGrossSales`(pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount) from `order header` where year(order_date)=pYear and status='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVoidYearToDateNonVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetVoidYearToDateNonVATSales`(pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(nonvat_sales) from `order header` where year(order_date)=pYear and status='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetVoidYearToDateVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetVoidYearToDateVATSales`(pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(vat_sales) from `order header` where year(order_date)=pYear and status='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetYearToDateGrossSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetYearToDateGrossSales`(pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(total_amount) from `order header` where year(order_date)=pYear and status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetYearToDateNonVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetYearToDateNonVATSales`(pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(nonvat_sales) from `order header` where year(order_date)=pYear and status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fGetYearToDateVATSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `fGetYearToDateVATSales`(pYear int) RETURNS decimal(12,2)
BEGIN
return (select sum(vat_sales) from `order header` where year(order_date)=pYear and status!='CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `fReturnOrderHistory` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 FUNCTION `fReturnOrderHistory`(
pOrderId	varchar(10),
pOperation	varchar(25)) RETURNS tinyint(1)
BEGIN
if (select count(order_id) from `order history` where order_id=pOrderId and operation=pOperation)>=1 then
return 1;
else
return 0;
end if;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `GetComplaintCount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `GetComplaintCount`(pDate datetime) RETURNS int(2)
BEGIN
return(select count(complaints.ORDER_ID) from `order header`,complaints where
`order header`.ORDER_ID=complaints.ORDER_ID and date(ORDER_DATE)=pDate);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `GetFolioType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `GetFolioType`(
pFolioId varchar(30)
) RETURNS text CHARSET latin1
BEGIN
return (
select FolioType
from `hotelmgtsystem`.folio
where
`hotelmgtsystem`.folio.folioid = pFolioId);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `getguestnamefromhotel` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `getguestnamefromhotel`(
pFolioId varchar(30)
) RETURNS text CHARSET latin1
BEGIN
return (
select distinct if(foliotype='GROUP', groupname, (
concat(
'Room: ', `hotelmgtsystem`.folioschedules.roomid, ' - ',
`hotelmgtsystem`.guests.LastName,', ', 
`hotelmgtsystem`.guests.FirstName))) as GuestName
from 
`hotelmgtsystem`.folio
left join `hotelmgtsystem`.folioschedules
on `hotelmgtsystem`.folioschedules.folioid = `hotelmgtsystem`.folio.folioid
left join `hotelmgtsystem`.guests on (`hotelmgtsystem`.guests.accountid = `hotelmgtsystem`.folio.AccountID)
where
`hotelmgtsystem`.folio.folioid = pFolioId
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `getguestroomfromhotel` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `getguestroomfromhotel`(
pFolioId varchar(30)
) RETURNS text CHARSET latin1
BEGIN
return (
select folioschedules.roomid
from `hotelmgtsystem`.folioschedules, `hotelmgtsystem`.folio
where
`hotelmgtsystem`.folioschedules.folioid=pFolioId and
`hotelmgtsystem`.folioschedules.folioid = if(`hotelmgtsystem`.folio.masterfolio="" or 
`hotelmgtsystem`.folio.masterfolio="0", `hotelmgtsystem`.folio.folioid,folio.masterfolio)
limit 0,1);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `GetLastRouteOperation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `GetLastRouteOperation`(
orderid varchar(20)
) RETURNS varchar(30) CHARSET latin1
BEGIN
return (select operation from `order history`  where order_id=orderid order by id desc limit 1);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `GetOrderCount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `GetOrderCount`(pStartDate date) RETURNS int(3)
BEGIN
return (select count(`order header`.ORDER_ID) from `order header` where date(ORDER_DATE)=pStartDate);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `GetRemarks` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `GetRemarks`(
orderId varchar(20)
) RETURNS text CHARSET latin1
BEGIN
return (select GROUP_CONCAT(concat(`order detail`.QUANTITY,' pc(s) ',item.DESCRIPTION)) from item,`order detail`,`order header`
where item.ITEM_ID=`order detail`.ITEM_ID and `order header`.ORDER_ID=`order detail`.ORDER_ID
and `order detail`.ORDER_ID=orderId
group by `order header`.ORDER_ID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `GetRemarks_Routed` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `GetRemarks_Routed`(
orderId varchar(20), pRestoID int(5)
) RETURNS text CHARSET latin1
BEGIN
return (select GROUP_CONCAT(concat(`order detail`.QUANTITY,' pc(s) ',item.DESCRIPTION)) from item,`order detail`,`order header`
where item.ITEM_ID=`order detail`.ITEM_ID and `order header`.ORDER_ID=`order detail`.ORDER_ID
and `order detail`.route=true
and `order detail`.ORDER_ID=orderId and item.resto_id=pRestoID
group by `order header`.ORDER_ID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `GetStudentName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `GetStudentName`(
pStudID varchar(30)
) RETURNS text CHARSET latin1
BEGIN
return (
select concat(student_student_info.LastName,', ', student_student_info.FirstName) as GuestName
from student_student_info
where
student_student_info.stud_id = pStudID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `GetTotalAmount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `GetTotalAmount`(pStartDate date) RETURNS decimal(12,2)
BEGIN
return (select sum(TOTAL_AMOUNT) from `order header` where date(ORDER_DATE)=pStartDate);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `GetTotalLineItemsMonthly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `GetTotalLineItemsMonthly`(pMonth int(2)) RETURNS int(5)
BEGIN
return (select sum(TOTAL_LINE_ITEMS) from `order header` 
where Month(ORDER_DATE)=pMonth);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP FUNCTION IF EXISTS `GetTotalLineItemsWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 FUNCTION `GetTotalLineItemsWeekly`(pStartDate datetime) RETURNS int(5)
BEGIN
return (select sum(TOTAL_LINE_ITEMS) from `order header` 
where ORDER_DATE between date(pStartDate) and adddate(pStartDate, interval 7 DAY)
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `GetTranCodeAccountSide` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `GetTranCodeAccountSide`(
in ptrancode varchar(20),
in photelid int(5)
)
BEGIN
select acctside from transactioncode
where
trancode = ptrancode and
hotelid = photelid and 
stateflag = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `pSelectAccount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `pSelectAccount`(
pHotelId int(5)
)
BEGIN
Select accountid,lastname,firstname from guests
Where HotelId=pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `showTables` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `showTables`()
BEGIN
show tables from pos;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spAcknowledgeOrderDetailChange` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spAcknowledgeOrderDetailChange`(
pId bigint(20),
pAcknowledgeBy varchar(50)
)
BEGIN
update `order detail` set acknowledge = 1,
acknowledge_by = pAcknowledgeBy,
TIME_ACKNOWLEDGED = now()
where
id = pId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spAddRoomAmenity` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spAddRoomAmenity`(
in proomid varchar(10),
in pamenityid varchar(20),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into roomamenities
values
(
proomid,
pamenityid,
photelid,
now(),
pcreatedby,
now(),
pcreatedby,
'ACTIVE'
);
update amenities 
set stateflag = 'ASSIGNED' where
amenityid = pamenityid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spArrivalsView` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spArrivalsView`()
BEGIN
select distinct folioid from folioschedules 
where 
departuredate = now();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spAuthenticateUser` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spAuthenticateUser`(
puserId       varchar(30),
pPassword     text
)
BEGIN
select userId from users
where
`Password` = MD5(pPassword) and
userId = pUserId and status='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCancelAllOrderedItems` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCancelAllOrderedItems`(
in pId	bigint
)
BEGIN
update `order detail` 
set OPERATION_STATUS = 'CANCELLED' where
ID  = pId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCancelRoomEvent` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spCancelRoomEvent`(
in pEventID varchar(20),
in pEventType varchar(30),
in pEventType1 varchar(30),
in pHotelId int(5)
)
BEGIN
Update Roomevents set EventType=pEventType1 where EventID=pEventID and EventType=pEventType and hotelId=pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spChangeFolioPackage` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spChangeFolioPackage`(
in pFolioID varchar(20),
in pHotelID int(5),
in pPackageID varchar(20)
)
BEGIN
Update Folio set packageID=pPackageID where folioID=pFOlioID and hotelID=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spChangePassword` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spChangePassword`(pUserID varchar(50), pPassword varchar(50))
BEGIN
update users set `password`=md5(pPassword) where userid=pUserID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCheckConflictRoomEvents` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spCheckConflictRoomEvents`( in pRoomid varchar(20),
in pEventDate date,
in pHotelID int(5)
)
BEGIN
Select EventNo 
from roomevents 
where roomid = proomid and
Eventdate = pEventDate and
hotelid = pHotelid and not
(eventtype = '' or eventtype = 'CANCELLED'
or eventtype = 'NO SHOW' or
EventType = 'CHECKED OUT');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCleanAll` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spCleanAll`()
BEGIN
delete from `order detail`;
delete from `order header`;
delete from `order history`;
delete from payment;
delete from payment_ledger;
update seq_orders set id = 0;
update service_charge set SERVICE_CHARGE = 0;
delete from table_assignment;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCountRoomTypes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spCountRoomTypes`(in pHotelID int(5))
BEGIN
select roomtypecode,count(roomtypecode) as vacant from rooms where 
HotelID=pHOtelID
group by roomtypecode ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spCurrentBlockRoom` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spCurrentBlockRoom`()
BEGIN
select roomid,"BLOCKING" as eventtype from blockingdetails
where date(now())>=date(blockfrom) and  date(now())<=date(blockto);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteAccountPrivileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteAccountPrivileges`(
in pAccountId varchar(20),
In pHotelId int(5)
)
BEGIN
DELETE from accountprivileges WHERE AccountId=pAccountId 	AND HotelId=pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteAllFolioRouting` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteAllFolioRouting`(
in pHotelId int(5),
in pFolioId varchar(20)
)
BEGIN
Delete from foliorouting where folioId=pFolioId and hotelId=pHOtelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteAllPackageDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteAllPackageDetails`(
in pPackageId varchar(20),
in pHotelId int(5)
)
BEGIN
DELETE FROM packagedetails WHERE packageID=pPackageId and HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteAllPrivilegeDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteAllPrivilegeDetails`(
in pPrivilegeId varchar(20),
in pHotelId int(5)
)
BEGIN
DELETE FROM privilegedetails WHERE PrivilegeID=pPrivilegeId and HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteAmenity` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteAmenity`(
in pamenityid varchar(20), 
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update amenities 
set 
stateflag = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where amenities.amenityid = pamenityid and hotelid = photelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteBike` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteBike`(
pBikeId varchar(15),
pUpdatedBy   varchar(30)    
)
BEGIN
update bike 
set
`Status`='DELETED',
UpdatedBy=pUpdatedBy,   
UpdateTime=now()
where 
BIKE_ID=pBikeId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteBikeAssign` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteBikeAssign`(
pEMPLOYEE_ID  varchar(10),  
pUPDATEDBY    varchar(30)
)
BEGIN
update bike_assign
set 
`STATUS`='DELETED',
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
where 
EMPLOYEE_ID=pEMPLOYEE_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteBlocking` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteBlocking`(
in pRoomID int(11),
in pFrom date
)
BEGIN
Delete from Blocking where roomID=pRoomid and `from`=pFrom;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteButton` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteButton`(
pRestoID	int(5),
pBUTTON_ID   varchar(20), 
pUPDATEDBY   varchar(30)
)
BEGIN
delete from button_setup 
where
BUTTON_ID=pBUTTON_ID
and Resto_ID=pRestoID;	
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteCashier` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteCashier`(
in pcashierid varchar(10)
)
BEGIN
delete from cashier
where 
cashierid = pcashierid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteCompany` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteCompany`(
in pcompanyid varchar(12),
in pHotelID int(5),	
in pupdatedby varchar(20)
)
BEGIN
update company
set
stateflag = 'DELETED',
updatetime = now(),
updatedby = pupdatedby
where
companyid = pcompanyid and hotelId=pHOtelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteComplaint` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteComplaint`(
pCOMPLAINT_ID  bigint(15),
pUPDATEDBY varchar(30)
)
BEGIN
update `complaints` 
set
`STATUS` = 'DELETED',
UPDATEDBY = pUPDATEDBY, 
UPDATETIME = now()
where
COMPLAINT_ID = pCOMPLAINT_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteCurrencyCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteCurrencyCode`(
in pcurrencycode varchar(10),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
UPDATE CurrencyCodes
SET
stateFlag='DELETED',
UPDATEDBY=pupdatedby,
UPDATETIME=now()
WHERE
currencycode=pcurrencycode AND HOTELID=photelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteCustomer` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteCustomer`(
pCUSTOMER_ID varchar(100),
pUpdatedBy varchar(30),
pHotelID int(5)
)
BEGIN
update customers
set
`status` = 'DELETED',
UPDATEDBY = pUpdatedBy,
UPDATETIME = now()
where
CUSTOMER_ID = pCUSTOMER_ID
and HOTELID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteDepartment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteDepartment`(
in pDeptId      varchar(20),       
in pHotelId     int(5)        
)
BEGIN
Update department set stateFlag='DELETED' 
Where DeptId=pDeptId and HotelId=pHotelId;
end */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteEmployee` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteEmployee`(
pEMPLOYEE_ID  varchar(10),
pUPDATEDBY    varchar(30),
pRestoID int(5)
)
BEGIN
delete from employee where employee_id=pEmployee_id;
delete from `employee status` where employee_id=pEmployee_id;
delete from `employee account` where employee_id=pEmployee_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteEnggJobRoomEvent` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteEnggJobRoomEvent`(
in peventid varchar(20),
in photelid int(5)
)
BEGIN
delete from roomevents
where
eventid = peventid and hotelid = photelid and eventtype = 'ENGINEERING JOB';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteEngineeringJob` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteEngineeringJob`(
IN penggjobno varchar(20),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update engineeringjobs
set 
stateflag = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where enggjobno = penggjobno and hotelid = photelid;  
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteEngineeringService` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteEngineeringService`(
in penggserviceid varchar(20),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update engineeringservices
set    
engineeringservices.stateflag = 'DELETED',
updatetime = now(),
updatedby = pupdatedby
where  enggserviceid = penggserviceid and hotelid = photelid;	
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFloor` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFloor`(
in pfloor varchar(25),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update floors
set
stateflag = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where
`floor` = pfloor and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFolio` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFolio`(in pFolioID varchar(12))
BEGIN
Delete from Folio where folioId=pFolioID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFolioPackage` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFolioPackage`(
in pFolioId varchar(20),
in pHotelId int(5))
BEGIN
delete from foliopackage where
folioid = pFolioId and 
hotelId= pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFolioRecurringCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFolioRecurringCharge`(
in pHotelId int(5),
in pFolioId varchar(20),
in pTranCode varchar(20)
)
BEGIN
Delete from 
FolioRecurringCharge 
where 
folioId=pFolioId and 
hotelId=pHotelId and 
TransactionCode=pTranCode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFolioRecurringCharges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFolioRecurringCharges`(
in pFolioId varchar(20),
in pHotelId int(5)
)
BEGIN
Delete from 
FolioRecurringCharge 
where 
folioId=pFolioId and 
hotelId=pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFolioRouting` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFolioRouting`(
in pHotelId int(5),
in pFolioId varchar(20),
in pTranCode varchar(20)
)
BEGIN
Delete from foliorouting where folioId=pFolioId and hotelId=pHOtelId and TransactionCode=pTranCode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFolioRoutings` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFolioRoutings`(
in pFolioId varchar(20),
in pHotelId int(5)
)
BEGIN
Delete from foliorouting where folioId=pFolioId and hotelId=pHOtelId ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFolioSchedule` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFolioSchedule`(
in pFolioID varchar(20),
in pHotelID int(5)
)
BEGIN
Delete from FolioSchedules where folioID=pFolioID and hotelID=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFolioScheduleRefArrivalDate` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFolioScheduleRefArrivalDate`(
in pArrivalDate date,
in pEventID varchar(20),
in pHotelID int(5)
)
BEGIN
Delete from folioSchedules where fromdate=pArrivalDate and folioid=pEventID and hotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFolioSchedules` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFolioSchedules`(
in pFolioID varchar(20),
in pRoomID varchar(20),
in pHotelID int(5)
)
BEGIN
Delete from folioSchedules where folioID=pFolioID and roomID=pRoomID and hotelid=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFolioTransaction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFolioTransaction`(
in ptrandate datetime,
in pFolioID varchar(20),
in ptrancode varchar(5)
)
BEGIN
delete from foliotransactions where 
transactiondate=ptrandate and 
folioid=pFolioID and 
transactioncode=ptrancode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteFunction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteFunction`(
pFUNCTION_ID  varchar(20),  
pUPDATEDBY    varchar(30)  
)
BEGIN
update `function mapping`
set 
`STATUS`='DELETED',
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
where
FUNCTION_ID=pFUNCTION_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteGroup`(
pGROUP_ID     varchar(10),
pUPDATEDBY varchar(30),
pRESTOID	INT(5)
)
BEGIN
update `group` set
`STATUS`='DELETED',
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
Where 
GROUP_ID=pGROUP_ID AND RESTO_ID=pRESTOID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteGuest` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteGuest`(
in paccountid varchar(12),
in pHotelId int(5),
in pupdatedby varchar(20)
)
BEGIN
update guests 
set 
stateflag = 'DELETED',
updatetime = now(),
updatedby  = pupdatedby
where
accountid = paccountid and hotelId=pHOtelID
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteHotel` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteHotel`(
pHotelId int(3)
)
BEGIN
Update Hotel 
set stateFlag='DELETED'
Where HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteHouseKeeper` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteHouseKeeper`(
in phousekeeperid varchar(20),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update housekeepers
set 
stateflag = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where housekeeperid = phousekeeperid and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteHouseKeepingJob` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteHouseKeepingJob`(in phousekeepingjobno int)
BEGIN
update housekeepingjobs
set    housekeepingjobs.stateflag = 'DELETED'
where  housekeepingjobs.housekeepingjobno = phousekeepingjobno;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteIndividualRoleMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteIndividualRoleMenu`(
pRoleName varchar(30),
pMenu varchar(50),
pHotelId     int(5) 
)
BEGIN
Delete from RoleMenu Where RoleName=pRoleName and Menu=pMenu and HotelId=pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteItem` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteItem`(
pITEM_ID varchar(30),
pUpdatedBy varchar(30)
)
BEGIN
update item set
`STATUS`='DELETED',
UpdatedBy=pUpdatedBy,
UpdateTime=now()
Where 
ITEM_ID=pITEM_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteMainGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteMainGroup`(
pGROUP_ID     varchar(10),
pUPDATEDBY varchar(30)
)
BEGIN
update `main_item_group` set
`STATUS`='DELETED',
UPDATEDBY=pUPDATEDBY,
UPDATEDTIME=now()
Where 
ID=pGROUP_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteMenu`(
pMENU_ID       varchar(10),       
pUPDATEDBY     varchar(30)
)
BEGIN
update menu
set 
`STATUS`='DELETED',
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
where
MENU_ID=pMENU_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteMenuDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteMenuDetail`(
pMENU_ID     varchar(10)
)
BEGIN
delete from `menu detail` WHERE MENU_ID=pMENU_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteOperation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteOperation`(
pOPERATION  varchar(30), 
pUPDATEDBY     varchar(30) 
)
BEGIN
update operation
set 
`STATUS`='DELETED',
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
where
OPERATION=pOPERATION;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteOrderDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteOrderDetail`(
pORDER_ID long
)
BEGIN
delete from `order detail` where ORDER_ID=pORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteOrderHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteOrderHeader`(
pOrderId int(11)
)
BEGIN
delete from `order header` where order_id=pOrderId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeletePackageDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeletePackageDetail`(
in pPackageId varchar(20) ,
in pTransactionCode varchar(20),
in pHotelID int(5)
)
BEGIN
UPDATE 
packagedetails 
SET 
stateFlag='DELETED'
WHERE 
PackageID=pPackageID AND 
TransactionCode=pTransactionCode AND
HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeletePackages` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeletePackages`(
in pPackageID varchar(20),
in pHotelID int(5)
)
BEGIN
UPDATE packageheader 
SET 
stateFlag='DELETED'
WHERE 
PackageID=pPackageID
AND HotelID=pHotelID;
UPDATE packagedetails
SET 
stateFlag='DELETED'
WHERE 
PackageID=pPackageID
AND HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeletePayment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeletePayment`(
pORDER_ID varchar(10)
)
BEGIN
delete from payment where ORDER_ID=pORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeletePrivilegeDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeletePrivilegeDetail`(
in pPrivilegeId varchar(20) ,
in pTransactionCode varchar(20),
in pHotelID int(5)
)
BEGIN
UPDATE 
privilegedetails 
SET 
stateFlag='DELETED'
WHERE 
PrivilegeID=pPrivilegeID AND 
TransactionCode=pTransactionCode AND
HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeletePrivilegeHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeletePrivilegeHeader`(
in pPrivilegeID varchar(20),
in pHotelID int(5)
)
BEGIN
UPDATE privilegeheader 
SET 
stateFlag='DELETED'
WHERE 
PrivilegeID=pPrivilegeID
AND HotelID=pHotelID;
UPDATE privilegedetails
SET 
stateFlag='DELETED'
WHERE 
PrivilegeID=pPrivilegeID
AND HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeletePromo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeletePromo`(IN ppromocode INT)
BEGIN
update promos
set promos.stateflag = 'DELETED'
where promos.promocode = ppromocode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRateCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRateCode`(
in pratecode varchar(50),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update ratecodes
set 
stateflag = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where ratecode = pratecode and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRateType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRateType`(
in proomtypecode varchar(50),
in pratecode varchar(50),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update ratetypes
set `status` = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where
roomtypecode = proomtypecode and
ratecode = pratecode and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRestaurant` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRestaurant`(
pRestaurantId  varchar(10), 
pUpdatedby     varchar(30)
)
BEGIN
update `restaurants` 
set	
`Status` = 'DELETED',
UpdatedBy = pUpdatedBy,
UpdateTime = now()
where
RestaurantId = pRestaurantId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRole` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRole`(
pRoleName varchar(30),
pHotelId int(5)
)
BEGIN
Delete from Roles
Where ROLE_ID=pRoleName;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRoleMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRoleMenu`(
pRoleName varchar(30),
pHotelId     int(5) 
)
BEGIN
Delete from RoleMenu Where RoleName=pRoleName  and HotelId=pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRole_DB_Privileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRole_DB_Privileges`(
pROLE_ID       varchar(100)  
)
BEGIN
delete from role_db_privileges
where
ROLE_ID = pROLE_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRole_Menu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRole_Menu`(
pRole_ID      varchar(100)
)
BEGIN
DELETE FROM role_menus WHERE
ROLE_ID = pRole_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRole_SystemMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRole_SystemMenu`(
pRole_ID      varchar(100),
pMenuName varchar(100)
)
BEGIN
DELETE FROM role_menus WHERE
ROLE_ID = pRole_ID and Menu_Name=pMenuName;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRole_Table_privileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRole_Table_privileges`(
pROLE_ID           varchar(100)
)
BEGIN
delete from role_table_privileges
where
ROLE_ID = pRole_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRoom` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRoom`(
in proomid varchar(10),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update rooms 
set 
stateflag = 'DELETED',
updatetime = now(),
updatedby = pupdatedby
where roomid = proomid and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRoomAmenity` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRoomAmenity`( 
in pamenityid varchar(20),
in proomid varchar(10),
in photelid int(5)
)
BEGIN
UPDATE roomamenities
set stateflag = 'DELETED' 
where amenityid = pamenityid and roomid = proomid and hotelid = photelid;
update amenities set amenities.stateflag = 'UNASSIGNED'
where amenities.amenityid = pamenityid and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRoomBlock` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRoomBlock`(
in pblockid int(11),in proomid varchar(10)
)
BEGIN
delete from blockingdetails where
blockid = pblockid and roomid = proomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRoomBlockNoDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRoomBlockNoDetail`(
)
BEGIN
delete from roomblock 
where not exists
(select * from blockingdetails 
where blockingdetails.blockid = roomblock.blockid);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRoomEvent` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRoomEvent`(
in pEventID varchar(20),
in pRoomID varchar(20),
in pEventType varchar(25),
in pHotelID int(5),
in pEventdate date
)
BEGIN
Delete from Roomevents where EventID=pEventID and RoomID=pRoomID and eventtype=pEventType and hotelID=pHotelID and EventDate=pEventDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRoomEventByEventType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRoomEventByEventType`(
in peventtype varchar(30)
)
BEGIN
Delete from Roomevents 
where EventID = pEventID and Roomevents.EventType = peventtype;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRoomEvents` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRoomEvents`(
in pEventID varchar(20),
in pRoomID varchar(20),
in pEventType varchar(25),
in pHotelID int(5)
)
BEGIN
Delete from Roomevents where EventID=pEventID and RoomID=pRoomID and eventtype=pEventType and hotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRoomType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRoomType`(
in proomtypecode varchar(20),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update roomtypes 
set 
roomtypes.stateflag='DELETED',
updatedby = pupdatedby,
updatetime = now()
where roomtypecode = proomtypecode and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRoute` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRoute`(
pROUTEID varchar(10),
pUPDATEDBY varchar(30)
)
BEGIN
update `route header`
set
`STATUS`='DELETED',
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
where
ROUTE_ID=pROUTEID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteRouteDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteRouteDetail`(
pROUTE_ID       varchar(10)
)
BEGIN
delete from `route detail` where ROUTE_ID=pROUTE_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteSystemMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteSystemMenu`(
pMENU_NAME    varchar(30), 
pUPDATEDBY    varchar(30)
)
BEGIN
update systemmenus
set
`status` = 'DELETED',
UPDATEDBY = pUPDATEDBY, 
UPDATETIME = NOW()
WHERE
MENU_NAME = pMENU_NAME;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteTableAssignment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteTableAssignment`(
pTableNo varchar(10)
)
BEGIN
delete from table_assignment  where table_no=pTableNo;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteTbleAssignment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteTbleAssignment`(
pOrderID varchar(10)
)
BEGIN
delete from table_assignment  where order_id=pOrderID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteTradingArea` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteTradingArea`(
pAREA_CODE       varchar(10),       
pUPDATEDBY     varchar(30)
)
BEGIN
update TRADINGAREAS
set 
`STATUS`='DELETED',
UPDATEDBY = pUPDATEDBY,
UPDATETIME = now()
where
AREA_CODE = pAREA_CODE;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteTransactionCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteTransactionCode`(
in ptrancode varchar(20),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update transactioncode
set
stateflag = 'DELETED',
updatetime = now(),
updatedby = pupdatedby
where
trancode = ptrancode and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteTranType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteTranType`(
in ptrantypeid varchar(20),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update trantypes
set
stateflag = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where
trantypeid = ptrantypeid and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteUser` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteUser`(
pUserId varchar(30),
pUpdatedBy varchar(30)
)
BEGIN
update users
set
`status` = 'DELETED',
UPDATEDBY = pUpdatedBy,
UPDATETIME = now()
where
UserId = pUserId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteUserRole` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteUserRole`(
in pUserId varchar(20),
in pHotelId int(5)
)
BEGIN
delete from userRole
where
userid = pUserId and
hotelid = pHotelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDeleteUserRoles` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDeleteUserRoles`(
in pUserId varchar(20)
)
BEGIN
delete from user_roles
where
user_id = pUserId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDepartureView` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDepartureView`(
in pdate date
)
BEGIN
select folioid from folioschedules
where
arrivaldate = pdate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDisplayCharges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDisplayCharges`(in photelid int(5))
BEGIN
select * from Transactioncode where trantypeid=1 and hotelid=photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDisplayCompanyAccounts` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDisplayCompanyAccounts`()
BEGIN
Select 
(companyid) as `ID#`,
COMPANYCODE as CODE,
(COMPANYNAME) AS `NAME OF COMPANY`,
COMPANYURL,CONTACTPERSON,DESIGNATION
from company
where stateflag <>'DELETED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDisplayListOfGuest` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDisplayListOfGuest`(in pHotelID int(5))
BEGIN
select *
from guests
where hotelid=pHotelID and stateflag='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDisplayReservationList` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spDisplayReservationList`()
BEGIN
Select schedule.Roomid,(roomtype.`name`) as RoomType,concat(account.firstname, ' ' , account.lastname) as `Name of Guest`,schedule.`From`,schedule.`To`,event.eventtype from room,schedule,folio,roomtype,account,event where schedule.Roomid=room.roomid and folio.folioid=schedule.folioid and folio.accountid=account.accountid and schedule.eventid=event.eventid and room.roomtypeid=roomtype.roomtypeid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spDistributeServiceCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spDistributeServiceCharge`(pMonth int(2))
BEGIN
update `employee account` set payment=fGetServiceChargeForEmployee(pMonth);
update service_charge set service_charge=0.00;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spFilterGuest` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spFilterGuest`(
in pFirstname varchar(50),
in pLastname varchar(50),
in pMiddleName varchar(50)
)
BEGIN
select * from guests
where
firstname like concat(pfirstname,'%') and
lastname like concat(plastname,'%') and
middlename like concat(pMiddlename,'%')
and stateflag <> 'DELETED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spFilterGuestRecord` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spFilterGuestRecord`(
in pAccountName varchar(30),
in pFirstname varchar(50),
in pLastName varchar(50),
in pMiddleName varchar(50),
in pCitizenship varchar(100),
in pSex varchar(6)
)
BEGIN
Select AccountId,AccountName,FirstName,MiddleName,LastName,Sex,CitizenShip from guests where  firstname=pFirstName and lastname=pLastName and middlename=pMiddlename and citizenship=pCitizenship and sex=pSex;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spFilterQuery` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spFilterQuery`(
in pFields varchar(100),
in pTable varchar(25),
in pRefField varchar(25),
in pRefData varchar(50)
)
BEGIN
select pFields from pTable where pRefField like pRefData;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spFilterReservation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spFilterReservation`(IN pStatus VARCHAR(15))
BEGIN
Select (Folio.FolioID) as `ID`,folio.FolioType,guest.Firstname,guest.Lastname,folio.AccountType,Folio.Status 
from folio,guest
where folio.accountid=guest.accountid and folio.status=pStatus;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spFinishOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spFinishOrder`(
pORDER_ID varchar(20),
pOPERATION varchar(30),
pEND_TIME datetime,
pSERVICE_DURATION datetime,
pSEQ_NO int(11),
pSTATUS varchar(30),
pASSIGNED_TO varchar(30)
)
BEGIN
update `order header`
set
SEQ_NO=pSEQ_NO,
`STATUS`=pSTATUS,
ASSIGNED_TO=pASSIGNED_TO
where
`order header`.ORDER_ID=pORDER_ID;
update `order history`
set
END_TIME=pEND_TIME,
SERVICE_DURATION=sec_to_time((time_to_sec(pEND_TIME)-time_to_sec(START_TIME)))
where
`order history`.ORDER_ID=pORDER_ID and OPERATION=pOPERATION;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAccountID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAccountID`(
IN pAccountID int
)
BEGIN
Select accountid from guests where accountid=pAccountID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAccountIDFromFolio` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAccountIDFromFolio`(pFolioID varchar(12))
BEGIN
Select Accountid from folio where folioid = pFolioID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAccountIDofAgent` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAccountIDofAgent`(pfolioid int(10))
BEGIN
select agents.Accountid from agents,folio
where agents.accountid = folio.agentcode and folio.folioid=pfolioid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAccountPrivileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAccountPrivileges`(
in pAccountId varchar(20),
in pHotelId int(5)
)
BEGIN
select 
AccountPrivileges.*,TransactionCode.Memo
from
accountPrivileges,
transactioncode
where
transactioncode.hotelid = accountprivileges.hotelId and
transactioncode.trancode = accountprivileges.transactionCode and
accountid = pAccountId and
accountprivileges.hotelid = pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetActiveComplaints` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetActiveComplaints`()
BEGIN
select COMPLAINT_ID, ORDER_ID, CUSTOMER_ID, 
REASON_CODE, REMARKS 
from complaints 
where
`status` = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetActiveKitchenCrew` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetActiveKitchenCrew`()
BEGIN
Select employee.employee_id, employee.NICKNAME, fGetOrders(employee.employee_id) as Orders,
fGetOrderIDs(employee.employee_id) as Order_ID
from employee, `employee status`
where employee.position='KITCHEN CREW' and employee.employee_id=`employee status`.employee_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetActiveOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetActiveOrders`()
BEGIN
select 
distinct
`order header`.TABLE_NO,
`order header`.ORDER_ID,
`order header`.CUSTOMER_ID,
`order header`.ROUTE_ID,
`order header`.ASSIGNED_TO,
`order header`.ASSIGNED_TIME,
`order header`.ORDER_DATE,
`order header`.TOTAL_LINE_ITEMS,
`order header`.TOTAL_AMOUNT,
`order header`.TOTAL_PAYMENT,
`order header`.BALANCE,
`order header`.SEQ_NO
from `order header`,payment
where
`order header`.order_id !=
payment.order_id and date(`order header`.order_date) = curdate()
order by `order header`.TABLE_NO;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetActiveReasons` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetActiveReasons`()
BEGIN
select REASON_CODE,DESCRIPTION
from 
complaint_reasons
where 
`STATUS`= 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAdminAccount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetAdminAccount`(
pUSERID	VARCHAR(30),
pPASSWORD	VARCHAR(30))
BEGIN
Select users.userId from users, user_roles
where users.userId=pUSERID and users.userId=user_roles.user_id
and users.password=md5(pPASSWORD)
and (user_roles.role_id='ADMINISTRATOR' OR user_roles.role_id='ACCOUNTING'
OR user_roles.role_id='COST-ACCOUNT' OR user_roles.role_id='SUPERVISOR');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAgentByFolio` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAgentByFolio`(pfolioid varchar(12))
BEGIN
select agentcode from folio where folioid = pfolioid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAgentCommissions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAgentCommissions`(
pAccountID varchar(11)
)
BEGIN
select * from AgentCommission where Accountid = pAccountID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAgentInfo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAgentInfo`(
in paccountid int(4)
)
BEGIN
select * from agents where accountid = paccountid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAgents` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAgents`()
BEGIN
select accountid as ID,AgentName as `Name of Agent`,Address,ContactNumber from agents;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAllActiveOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAllActiveOrders`()
BEGIN
Select 
`order header`.ORDER_ID,
customers.NAME ,
TOTAL_AMOUNT as AMOUNT,
GetRemarks(`order header`.ORDER_ID) as REMARKS,
NICKNAME  ,
ASSIGNED_TIME,
`order header`.`STATUS`
from 
`order header` ,employee ,`order detail`, customers
where
`order header`.ASSIGNED_TO = employee.EMPLOYEE_ID and 
`order header`.	ORDER_ID=`order detail`.ORDER_ID and 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID and 
not (`order header`.status = 'RETURNED' or `order header`.status = 'Delivered' OR `order header`.status = 'Cancelled')
group by NICKNAME,`order header`.ORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetApplicablePackages` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetApplicablePackages`(
in pHotelID int(5)
)
BEGIN
select 
* 
from 
packageHeader 
where 
(curdate() between date(fromdate) and date(todate))
and hotelid = photelId and stateFlag='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAssignedOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAssignedOrder`(in pPosition varchar(30))
BEGIN
Select 
`order header`.ORDER_ID,
TOTAL_AMOUNT as AMOUNT,
GetRemarks_Routed(`order header`.ORDER_ID) as REMARKS,
NICKNAME  ,
ASSIGNED_TIME,
if (`order header`.`STATUS`='SERVED','',`order header`.`status`),
`order header`.customer_id as customer_name
from 
employee left join `order header` on (employee.EMPLOYEE_ID=`order header`.ASSIGNED_TO)
where employee.POSITION=pPosition
group by NICKNAME,`order header`.ORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetAssignedOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetAssignedOrders`(in pPosition varchar(30),
in pRestoId int(4))
BEGIN
Select 
`order header`.ORDER_ID,
TOTAL_AMOUNT as AMOUNT,
GetRemarks_Routed(`order header`.ORDER_ID, pRestoId) as REMARKS,
NICKNAME  ,
ASSIGNED_TIME,
`order header`.`STATUS`,
`order header`.customer_id as customer_name
from 
employee left join `order header` on (employee.EMPLOYEE_ID=`order header`.ASSIGNED_TO)
left join `order detail` on (`order header`.order_id = `order detail`.order_id) 
where employee.POSITION=pPosition 
group by NICKNAME,`order header`.ORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetBanquetSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetBanquetSales`()
BEGIN
select sum(unit_price) as `gross sales`, sum(amount) as `net sales`, sum(service_charge) as `service charges`,
sum(unit_price-amount-service_charge) as vat from `order detail`
where item_id='BANQUET';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetBlockedRoomInDate` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetBlockedRoomInDate`(
in pDate varchar(20)
)
BEGIN
select roomid from blockingdetails
where date(pDate) between date(blockfrom) and  date(blockto) ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetBreakDownOfChargePayment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetBreakDownOfChargePayment`(pfolioid varchar(20))
BEGIN
select foliotransactions.transactioncode as AccountID,foliotransactions.folioid,foliotransactions.subfolio,transactioncode.memo,sum(foliotransactions.netbaseamount) as Amount
from foliotransactions,transactioncode,folio,cardco
where foliotransactions.transactioncode=transactioncode.trancode and transactioncode.trancode=cardco.vendorid
and foliotransactions.posttoledger='0' and foliotransactions.folioid=folio.folioid and foliotransactions.folioid=pFolioID
group by foliotransactions.transactioncode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCalls` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCalls`()
BEGIN
select * from `callmgtsystem`.`log` force index(primary)
where PostFlag = 0
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCashierTransactions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetCashierTransactions`(
in pTerminalId varchar(30),
in pShiftCode int(2),
in pStartDate date,
in pEndDate date
)
BEGIN
select 
ORDER_ID, 
if(CUSTOMER_ID="",concat(fGetEmployeeName(employee_id)," (Employee)"),
if(CUSTOMER_ID="WALK-IN CUSTOMER",
"WALK-IN CUSTOMER",
concat(GetGuestNamefromHotel(trim(CUSTOMER_ID))," (Guest)"))) 
as CUSTOMER_ID, 
if(customer_id="", "EMPLOYEE", IF(CUSTOMER_ID="WALK-IN CUSTOMER", "WALK-IN CUSTOMER", "GUEST")) AS CUSTOMER_TYPE,
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
SHIFT_CODE, (cashiers.Terminal) as TERMINAL_ID
from `order header`,cashiers
where Terminal_Id = pTerminalId and
Shift_Code = pShiftCode and
cashiers.terminalid = `order header`.terminal_id and
(date(Order_Date) >= pStartDate and date(Order_Date) <= pEndDate)
and `order header`.status<>'CANCELLED'
order by order_date,order_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCashierTransactionsByDate` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCashierTransactionsByDate`(
pDate date
)
BEGIN
select 
cashiers_logs.createdby,
cashiers_logs.shiftcode,
cashiers_logs.terminalid,
cashiers_logs.cashierid,
cashiers_logs.restaurantid,
time_format(cashiers_logs.createtime,'%r')
from 
cashiers_logs
where 
cashiers_logs.type='CLOSE'
and transactiondate=pDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCharges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCharges`(
in pFolioID varchar(20), 
in photelid int(5),
in pSubFolio varchar(1)
)
BEGIN
select sum(baseamount),subfolio
from 
folioTransactions 
where 
acctside = 'DEBIT' and
folioId= pFolioId and 
hotelid = pHotelId AND
`status` = 'ACTIVE' and
subfolio = pSubFolio
group by subfolio;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetChildFolios` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetChildFolios`(
in pFolioID varchar(20),in pHotelID int(5)
)
BEGIN
select 
folio.folioId,
noOfAdults,
noofchild,
folio.status,
folio.todate,
folio.fromdate,
folio.accountid,
folio.packageid,
folio.arrivaldate
from 
folio
where 
folio.masterfolio=pFolioID and hotelID=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetChildFoliosAllFields` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetChildFoliosAllFields`(
in pFolioID varchar(12),in photelid int(5)
)
BEGIN
select 
*
from 
folio
where 
folio.masterfolio=pFolioID and `status`='CHECKED IN' and hotelid=photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCommission` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCommission`(pfolioID varchar(20),
ptrancode varchar(20)
)
BEGIN
Select distinct percentcommission from agentcommission,folio,foliotransactions
where foliotransactions.folioid =folio.folioid and
folio.agentid = agentcommission.accountid and 
agentcommission.trancode = ptrancode and foliotransactions.folioid=pfolioid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCompanyAccount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCompanyAccount`(
in pCompanyId varchar(20),
in pHotelId int(5)
)
BEGIN
Select *
from 
company
where 
(companyid = pCompanyId or companycode = pCompanyId)and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCompanyFolios` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCompanyFolios`(
in photelid int(5)
)
BEGIN
Select 
company.CompanyId,
folio.groupname,
company.companyname,
folioid
from 	
folio,company
where 
company.companyid = folio.companyid and
folio.accountType= "COMPANY" and 
`status` = 'CHECKED IN' and folio.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCompanyInfo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCompanyInfo`(
in pFolioId varchar(20),
in pHotelId int(5)
)
BEGIN
Select company.*
from 
company,
folio
where 
folio.folioid = pfolioid and
company.companyid = folio.companyid and
folio.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCompanyPrivelege` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCompanyPrivelege`(
in pCompanyId varchar(20),
in photelid int(5)
)
BEGIN
select
transactioncode,
basis,
percentoff,
amountoff
from
companyprivilegedetails,
companyprivilegeheader
where
companyprivilegedetails.privilegeid = companyprivilegeheader.privilegeid and
companyprivilegedetails.hotelid = companyprivilegeheader.hotelid and
companyprivilegeheader.companyid = pCompanyId and
companyprivilegeheader.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCompanyPrivilege` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCompanyPrivilege`(in pCompanyID varchar(20),in pHotelId int(5))
BEGIN
Select *,transactioncode.memo from CompanyPrivilegeheader,CompanyPrivilegedetails,transactioncode where CompanyPrivilegeheader.companyID=pcompanyID and CompanyPrivilegeheader.hotelId=pHotelId and CompanyPrivilegeheader.privilegeid=CompanyPrivilegedetails.privilegeid and CompanyPrivilegedetails.transactioncode=transactioncode.trancode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCompanyRefCompanyName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCompanyRefCompanyName`(
in pCompanyName varchar(100)
)
BEGIN
select * from company where companyname=pCompanyName;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCreditBalanceEmployee` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetCreditBalanceEmployee`(
pEmployeeID	varchar(15))
BEGIN
select balance from `employee account` where employee_id=pEmployeeID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCurrency` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCurrency`(in pCurrencyCode varchar(10))
BEGIN
Select CURRENCYCODE,CURRENCY,CONVERSIONRATE from CurrencyCodes where currencycode=pCurrencyCode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCurrencyCodes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCurrencyCodes`(in pHOtelid int(5))
BEGIN
Select * from currencyCodes where hotelid =photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCurrencyRate` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCurrencyRate`(
in pcurrencycode varchar(15)
)
BEGIN
select currencyrate from currencycodes where currencycode=pcurrencycode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGETCURRENCYRATEANDCODE` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGETCURRENCYRATEANDCODE`()
BEGIN
Select CurrencyCode,ConversionRate from currencyCodes;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCurrentRoomOccupied` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCurrentRoomOccupied`(
in pFolioID VARCHAR(20),
in pHotelId int(5)
)
BEGIN
select 
RoomID 
from 
roomevents force index(eventid,`eventdate`)
where 
EventID = pFolioID and 
`eventdate`= curdate() and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCustomer` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCustomer`(
pPHONE_NO varchar(12)
)
BEGIN
Select * from Customers where PHONE_NO=pPHONE_NO;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCustomerAssigned` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCustomerAssigned`(
pTableNo varchar(10)
)
BEGIN
select * from table_assignment where table_assignment.table_no=pTableNo and table_assignment.Status='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCustomerByID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCustomerByID`(
pCUSTOMER_ID varchar(12)
)
BEGIN
Select * from Customers where CUSTOMER_ID=pCUSTOMER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCustomerFromOrderHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCustomerFromOrderHeader`(
pORDER_ID          bigint(15) 
)
BEGIN
select CUSTOMER_ID from `order header` 
where
ORDER_ID = pORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCustomerOrderHistory` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetCustomerOrderHistory`(
pCUSTOMER_ID varchar(30)
)
BEGIN
select ORDER_ID as `Order Id`,ORDER_DATE as `Order Date`,GetRemarks(ORDER_ID) as Items from `order header`
where CUSTOMER_ID=pCUSTOMER_ID and `STATUS`='FINISHED'
order by ORDER_DATE DESC;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetCustomers` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetCustomers`(pHotelid int(5))
BEGIN
select customer_id, concat(last_name,', ',first_name) as name from customers
where hotelid=pHotelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetDataToApplyCommission` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetDataToApplyCommission`(pfolioID varchar(20),in psubfolio varchar(1),in pHotelID int(5))
BEGIN
select foliotransactions.transactioncode,foliotransactions.subfolio,folio.AgentID ,sum(foliotransactions.netbaseamount) as NetAmount from foliotransactions,folio
where  folio.folioid=foliotransactions.folioid and  folio.folioid=pfolioID and foliotransactions.posttoledger="0" and foliotransactions.hotelid=pHotelID and subfolio=psubfolio
group by transactioncode,folio.AgentID,foliotransactions.subfolio;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetDataToBePostedToLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetDataToBePostedToLedger`(pfolioid int(10))
BEGIN
select * from vdatatobepostedtoledger where folioid=pfolioid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetDataToPostServiceCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetDataToPostServiceCharge`(
pFolioid varchar(20),
pHotelid int(5)
)
BEGIN
select transactioncode.deptid,foliotransactions.transactioncode as trancode,sum(foliotransactions.servicecharge) as amount 
from transactioncode,foliotransactions
where transactioncode.trancode = foliotransactions.transactioncode and foliotransactions.folioid = pFolioid and foliotransactions.hotelid = pHotelid and foliotransactions.posttoledger="0"
group by transactioncode.deptid,foliotransactions.transactioncode
having sum(foliotransactions.servicecharge) > 0;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEmployee` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetEmployee`(pHotelId int(5))
BEGIN
Select employee.Employee_ID, concat(Lastname, ', ', Firstname) as `name`, `employee account`.`credit limit`, `employee account`.balance
from Employee, `employee account` where status='ACTIVE' and employee.employee_id=`employee account`.employee_id
and balance>=0 and employee.hotel_id=pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEmployeeAccounts` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetEmployeeAccounts`()
BEGIN
select employee.EMPLOYEE_ID,
employee.LASTNAME,
employee.FIRSTNAME,
`employee account`.CHARGE
from employee left join `employee account`
on `employee account`.EMPLOYEE_ID = employee.EMPLOYEE_ID
where employee.EMPLOYEE_ID != 'COMP';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEmployeeID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetEmployeeID`( in pNICKNAME varchar(20))
BEGIN
Select EMPLOYEE_ID from employee 
where NICKNAME=pNICKNAME; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEmployeeLedgerOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetEmployeeLedgerOrders`(
in pEmployeeId varchar(20)
)
BEGIN
select 
employee_ledger.ORDER_ID, 
`order header`.*,
employee.*,
`employee account`.charge as CurrentBalance
from 
employee_ledger 
left join employee on employee_ledger.EMPLOYEE_ID = employee.EMPLOYEE_ID
left join `order header` on employee_ledger.ORDER_ID = `order header`.ORDER_ID
left join `employee account` on `employee account`.EMPLOYEE_ID = employee_ledger.EMPLOYEE_ID
where employee_ledger.employee_id = pEmployeeId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEmployeeName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetEmployeeName`(pName varchar(30))
BEGIN
select concat(lastname,', ', firstname) as `name`, employee.employee_id, charge 
from employee, `employee account`
where (lastname like concat(pName,'%') or concat(lastname,', ',firstname) like concat(pName,'%')) and employee.employee_id=`employee account`.employee_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEmployeeNickname` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetEmployeeNickname`(empid varchar(15))
BEGIN
select nickname from employee where SUBSTRING_INDEX(employee_id,'-',-1)=empid and `position`='KITCHEN CREW';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEmployeeNickNameByPosition` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetEmployeeNickNameByPosition`( pPOSITION varchar(30))
BEGIN
select NickName from Employee
where POSITION=pPOSITION; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEmployeeOrderHistory` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetEmployeeOrderHistory`(
pEMPLOYEE_ID varchar(30)
)
BEGIN
select ORDER_ID as `Order Id`,ORDER_DATE as `Order Date`,GetRemarks(ORDER_ID) as Items from `order header`
where EMPLOYEE_ID=pEMPLOYEE_ID and `STATUS`='FINISHED'
order by ORDER_DATE DESC;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetEndTime` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetEndTime`(
pORDER_ID varchar(20),
pOPERATION varchar(30)
)
BEGIN
select END_TIME from `order history`,`order header` 
where 
`order history`.ORDER_ID=`order header`.ORDER_ID
and OPERATION=pOPERATION and `order history`.ORDER_ID=pORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFloorLayoutImage` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFloorLayoutImage`(
in photelid int(5),
in pfloor varchar(10)
)
BEGIN
select floorlayoutimage
from floors
where
hotelid = photelid and `floor` = pfloor;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFloors` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFloors`()
BEGIN
select  hotelid,`floor`,floorlayoutimage
from
floors
where
not stateflag = 'DELETED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolio` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolio`(in pFolioID varchar(20), in pHotelID int(5))
BEGIN
Select * from Folio where folioID = pFolioID and hotelId=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioId` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioId`(
in pRoomId varchar(10)
)
BEGIN
select eventid from roomevents
where	
roomid = pRoomId and `eventdate` = curdate() and (eventtype = 'IN HOUSE' or eventtype='RESERVATION');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioPackage` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioPackage`(in pFolioID varchar(20),in pHOtelId int(5))
BEGIN
select 
foliopackage.*,
transactioncode.memo 
from 	foliopackage,
transactioncode 
where 
foliopackage.folioid=pFolioid and 
foliopackage.hotelId=pHOtelID and 
foliopackage.transactioncode=transactioncode.trancode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioPrivilege` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioPrivilege`(
in pFolioid varchar(20),
in pHotelid int(5)
)
BEGIN
select 
folioprivilege.*,
transactioncode.memo 
from folioprivilege,
transactioncode
where
transactioncode.trancode = folioprivilege.TransactionCode and
transactioncode.hotelid = folioprivilege.hotelid and
folioid = pfolioid and
folioprivilege.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioRouting` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioRouting`(in pFolioID varchar(20),in pHOtelId int(5))
BEGIN
Select TransactionCode, HotelID, FolioID, SubFOlio, Basis, PercentCharged, 
AmountCharged, CreateTime, CreatedBy, UpdateTime, UpdatedBy from FOlioRouting where folioid=pFolioID and hotelID=pHOtelID
order by transactionCode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFoliotoCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFoliotoCharge`(
in pTelephoneNo varchar(20),
in pHotelId int(5)
)
BEGIN
select
roomevents.eventid
from 
roomevents,
rooms
where
roomevents.eventtype = 'IN HOUSE' and
date(roomevents.eventdate) = curdate() and
roomevents.roomid = rooms.roomid and
rooms.telephoneNo = pTelephoneNo and
rooms.hotelid = roomevents.hotelid and
roomevents.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioTransaction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioTransaction`(
in pFolioID varchar(20),
in pTranDate varchar(30),
in pTranCode varchar(5),
in pHotelID int(5)
)
BEGIN
Select 
TransactionDate,        
TransactionCode,        
ReferenceNo,        
Memo,         
AcctSide,      
CurrencyCode,      
ConversionRate,         
CurrencyAmount,      
BaseAmount,       
Discount,        
ServiceCharge,        
GovernmentTax,      
LocalTax,         
NetBaseAmount,       
RouteSequence,    
SourceFolio,        
SourceSubFolio,       
TerminalID,         
`Status`,    
PostToLedger,
HotelID,   
FolioID,      
SubFOlio,       
AccountID,          
CREATETIME,    
CREATEDBY,     
UPDATETIME,       
UPDATEDBY
from folioTransactions
where folioid=pFolioID and transactiondate=pTranDate and TransactionCode=pTranCode and hotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioTransactionLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioTransactionLedger`(
in pHotelId int(5),
IN pFolioID varchar(20),
in pSubFolio varchar(20)
)
BEGIN
select HOTELID, FOLIOID, SUBFOLIO, ACCOUNTID, CHARGES, PAYCASH, PAYCARD, PAYCHEQUE, 
PAYGIFTCHEQUE, BALANCEFORWARDED, BALANCENET, DISCOUNT, GOVERNMENTTAX, 
LOCALTAX, SERVICECHARGE, AGENTCOMMISSION, TOTALNET, POSTTOLEDGER, 
CREATETIME, CREATEDBY, UPDATETIME, UPDATEDBY 
from `folioledger` force index(folioid,subfolio)
where 
HOtelID=pHotelId and FolioId=pFolioID and SubFolio=pSubFolio;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioTransactionRefTranCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioTransactionRefTranCode`(
in pTranCode varchar(20),
in pHotelId int(5)
)
BEGIN
Select * FROM transactionCode where trancode=pTrancode and hotelID =pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioTransactions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioTransactions`(
in pFolioID varchar(20),
in pSubFolio varchar(50),
in pHotelID int(5)
)
BEGIN
Select       
TransactionDate,        
TransactionCode,        
ReferenceNo,        
Memo,         
AcctSide,      
CurrencyCode,      
ConversionRate,         
CurrencyAmount,      
BaseAmount,       
Discount,        
ServiceCharge,        
GovernmentTax,      
LocalTax,         
NetBaseAmount,       
RouteSequence,    
SourceFolio,        
SourceSubFolio,       
TerminalID,         
`Status`,    
PostToLedger,
HotelID,   
FolioID,      
SubFOlio,       
AccountID,          
CREATETIME,    
CREATEDBY,     
UPDATETIME,       
UPDATEDBY
from 
folioTransactions
where folioid=pFolioID and `status`='ACTIVE' and subfolio=pSubFolio and hotelID=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioTransPackage` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioTransPackage`(
in pfolioid varchar(20),
in ptrancode varchar(20),
in photelid int(5)
)
BEGIN
select * from foliopackage
where
folioid = pfolioid and
transactioncode = pTrancode and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioTransPrivilege` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioTransPrivilege`(
in pFolioId varchar(20),
in pTransactionCode varchar(20),
in pHotelid int(5)
)
BEGIN
select * 
from 
FolioPrivilege
where
folioid = pFolioId and
transactioncode = pTransactionCode and
hotelid = pHotelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFolioTransRouting` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFolioTransRouting`(
in pfolioid varchar(20),
in ptrancode varchar(20),
in photelid int(5)
)
BEGIN
select * from foliorouting
where
folioid = pfolioid and
transactioncode = pTrancode and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetFunction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetFunction`(pRESTOID int(10),
pFUNCTION_ID varchar(20)
)
BEGIN
select FUNCTION_ID,DESCRIPTION,OBJECT,METHOD,COST from `function mapping` where FUNCTION_ID=pFUNCTION_ID 
and `STATUS`='ACTIVE' AND RESTO_ID=pRESTOID;      
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGuestByCriteria` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGuestByCriteria`(
in plastname varchar(50),
in pfirstname varchar(50)
)
BEGIN
select 
LASTNAME,
FIRSTNAME,
MIDDLENAME,
TITLE,
accountid,
accountname,
sex,
street,
city,
country,
zip,
emailaddress,
citizenship,
passportid,
TelephoneNo,
MobileNo,
FaxNo,
guestImage,
noofvisits,
memo
from guests
where
firstname like pfirstname and
lastname like plastname
and stateflag <> 'DELETED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGuestFolioHistory` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGuestFolioHistory`(
in pAccountID varchar(20),
in pHotelID int(5)
)
BEGIN
select *
from folio
where 
folio.accountid=pAccountid and 
hotelid=pHotelId 
order by folio.folioid desc
limit 0, 15;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGuestFolioInfo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGuestFolioInfo`(
in pFolioId varchar(20),
in photelid int(5)
)
BEGIN
select 
guests.accountid,
concat(guests.firstname, " ",guests.lastname) as GuestName,
concat(guests.street," , ",guests.city," , ",guests.country) as GuestAddress,
folio.masterfolio,
folio.foliotype,
folio.companyid,
folio.remarks
from
folio
left join
guests on
guests.accountid = folio.accountid and
guests.hotelid = folio.hotelid
where
folio.folioid = pFolioId and
folio.hotelid = pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGuestInfo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGuestInfo`(
in pfolioid varchar(20)
)
BEGIN
select 
date(folioschedules.fromdate) as ARRIVALDATE,
DATE(folioschedules.todate) as DEPARTUREDATE,
concat(folioschedules.roomid," ",folioschedules.roomtype) as ROOM,
folioschedules.RATE,
folioschedules.DAYS,
folio.noofadults,
folio.noofchild,
guests.TITLE,
guests.LASTNAME,
guests.FIRSTNAME,
guests.MIDDLENAME,
guests.CITIZENSHIP,	
guests.PASSPORTID,
guests.TelephoneNo,
concat(guests.street," ",guests.city," ", guests.country, " ",guests.zip) as ADDRESS
from
folioschedules,
guests,
folio
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
folio.folioid = pfolioid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGuestPrivelege` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGuestPrivelege`(
in pAccountid varchar(20),
in photelid int(5)
)
BEGIN
select
trancode,
basis,
percentoff,
amountoff
from
guestprivilegedetails,
guestprivilegeheader
where
guestprivilegedetails.privilegeid = guestprivilegeheader.privilegeid and
guestprivilegedetails.hotelid = guestprivilegeheader.hotelid and
guestprivilegeheader.companyid = pAccountid and
guestprivilegeheader.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGuestPrivilege` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGuestPrivilege`(in pAccountId varchar(20),in pHotelId int(5))
BEGIN
Select *,transactioncode.memo from guestprivilegeheader,guestprivilegedetails,transactioncode where guestPrivilegeheader.accountid=pAccountId and guestPrivilegeheader.hotelId=pHotelId and guestPrivilegeheader.privilegeid=guestprivilegedetails.privilegeid and guestprivilegedetails.trancode=transactioncode.trancode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGuestRecord` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGuestRecord`(
in pAccountid varchar(12),
in pHotelID int(5)
)
BEGIN
Select * from Guests where accountid=pAccountid and HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGuestRefName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGuestRefName`(
in pLastname varchar(50),
in pFirstname varchar(50),
in pMiddlename varchar(50),
in photelid int(5)
)
BEGIN
select *
from guests
where
Lastname=pLastname and
Firstname=pFirstname and
Middlename=pMiddlename and
hotelid = photelid
and stateflag = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetGuestsToTransfer` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetGuestsToTransfer`()
BEGIN
select 
folio.folioid,
concat(guests.lastname,", ",guests.firstname) as GUESTNAME,
folioschedules.roomid,
folioschedules.type
from
folio,
guests,
folioschedules
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and 
exists(
select * 
from 
folioschedules 
where departuredate = curdate()) 
and
folio.status = 'CHECKED IN' and
folioschedules.arrivaldate = adddate(curdate(),1);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetHKForecast` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetHKForecast`(
pFromDate datetime,
pToDate datetime		
)
BEGIN
select EVENTDATE,count(*) as TotalRooms,count(EventType) as TotalCheckOut from RoomEvents
WHERE date(EVENTDATE) between pFromDate and pToDate
group by date(EVENTDATE);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetHKForecastDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetHKForecastDetail`(
pFromDate datetime,
pToDate datetime
)
BEGIN
select EVENTDATE,RoomID,EventType from RoomEvents
WHERE date(EVENTDATE) between pFromDate and pToDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetHK_Housekeepers` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetHK_Housekeepers`()
BEGIN
select CONCAT(housekeeperid,'-',lastname,',',firstname) as HouseKeeper from hk_housekeepers where stateflag='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetHouseKeepingLogs` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetHouseKeepingLogs`()
BEGIN
select Hk_Date,roomid, concat(housekeepers.housekeeperid,'-',housekeepers.`firstname`,' ',housekeepers.`lastname`) as housekeeper, TransID, Time from `hk_log`,`housekeepers`
WHERE 
(housekeepers.`housekeeperid`=hk_log.`housekeeperid` and TransID ='FINISH' and parseFlag=0) or 		(housekeepers.`housekeeperid`=hk_log.`housekeeperid` and parseFlag=0);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetHouseKeeping_Logs` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetHouseKeeping_Logs`(IN pStatus VARCHAR(30), IN pDate DATE)
BEGIN
if pStatus='ALL' then
(
Select rooms.`roomid` as RoomId,rooms.roomtypecode as RoomType,starttime as StartTime,endtime as EndTime,
elapsedtime as Duration,concat(hk_housekeepers.housekeeperid,'-',lastname,', ',firstname) as Housekeeper,cleaningstatus,rooms.stateflag
from
rooms left join hk_housekeepingjobs on  hk_housekeepingjobs.`roomid`=rooms.`roomid`
left join hk_housekeepers on hk_housekeepers.housekeeperid=hk_housekeepingjobs.housekeeperid
WHERE housekeepingdate =pDate
)
Union
(Select rooms.`roomid` as RoomId,rooms.roomtypecode as RoomType,'' as StartTime,'' as EndTime,
'' as Duration,'' as Housekeeper,cleaningstatus,rooms.stateflag
from rooms
WHERE  rooms.`roomid` not in(Select roomid from `hk_housekeepingjobs` WHERE housekeepingdate=pDate)
);
else
(
Select rooms.`roomid` as RoomId,rooms.roomtypecode as RoomType,starttime as StartTime,endtime as EndTime,
elapsedtime as Duration,concat(hk_housekeepers.housekeeperid,'-',lastname,', ',firstname) as Housekeeper,cleaningstatus,rooms.stateflag
from
rooms
left join hk_housekeepingjobs on  hk_housekeepingjobs.`roomid`=rooms.`roomid`
left join hk_housekeepers on hk_housekeepers.housekeeperid=hk_housekeepingjobs.housekeeperid
WHERE cleaningstatus=pStatus and housekeepingdate =pDate
)
UNION
(Select rooms.`roomid` as RoomId,rooms.roomtypecode as RoomType,'' as StartTime,'' as EndTime,
'' as Duration,'' as Housekeeper,cleaningstatus,rooms.stateflag
from rooms
WHERE cleaningstatus=pStatus and rooms.`roomid` not in(Select roomid from `hk_housekeepingjobs` WHERE housekeepingdate=pDate)
)
;
end if;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetIndividualFolios` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetIndividualFolios`(
in photelid int(5)
)
BEGIN
Select 
concat(guests.lastname," , ",guests.firstname) as GuestName,
folioid,
foliotype,
fromdate,
todate,
(noofAdults+noofChild) as NoOfGuest, 
companyid,
groupname,
masterfolio,
folio.accountid
from 	
folio,guests 
where 
guests.accountid = folio.accountid and
folio.accountType= "GUEST" and 
`status` = 'CHECKED IN' and folio.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItem` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetItem`(
in pItem_ID varchar(20),
in pResto_id int(10)
)
BEGIN
Select *,maingroup_id from `item`, `group`
where item_id=pItem_ID and item.group_id=group.group_id
AND ITEM.RESTO_ID=pResto_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemAvailability` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetItemAvailability`(
in pITEM_ID int(10),
in pRESTO_ID int(10)
)
BEGIN
select AVAILABILITY 
from `item` 
where 
ITEM_ID = pITEM_ID and
RESTO_ID = pRESTO_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetItemNotes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetItemNotes`()
BEGIN
select * from item_notes where status_flag = 'ACTIVE'
ORDER BY item_id, access_count desc;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetKitchenOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetKitchenOrders`()
BEGIN
select `order header`.order_id,
GetRemarks_Routed(`order header`.order_id) as remarks,
nickname,
`order header`.assigned_time,
`order header`.`status`,
`order header`.customer_id as customer_name,
if(`order header`.status='served','','assembling') as emp_status
from `order header`, employee
where employee.position='KITCHEN CREW' and employee.employee_id=`order header`.assigned_to
group by nickname, `order header`.order_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetLastOperation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetLastOperation`(
pORDER_ID varchar(20)
)
BEGIN
select operation from `route detail`,`order header` 
where `order header`.ROUTE_ID =`route detail`.ROUTE_ID and
`order header`.ORDER_ID=pORDER_ID
order by `route detail`.seq_no desc limit 1;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetLastOrderID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetLastOrderID`()
BEGIN
select max(order_id) + 1 from `order header`;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetLedgerType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetLedgerType`( pTrancode varchar(11))
BEGIN
select ledger from transactioncode where trancode=ptrancode;	
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetLookUpValue` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetLookUpValue`(
in pCategory varchar(25)
)
BEGIN
select Code,Description from Lookuptable where category=pCategory;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetMainItemGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetMainItemGroup`(pGroupID varchar(30))
BEGIN
select maingroup_id from `group` where group_id=pGroupID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetMenu`(
in pMenu_id varchar(10)
)
BEGIN
Select * from `menu`
where menu_id=pMenu_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetMenus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetMenus`(
pMenu varchar(30) 
)
BEGIN
Select * from Menus where menu=pMenu;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetName`(
in pAccountID varchar(20),photelID int(5)
)
BEGIN
select concat(firstname," ",lastname) from guests where accountid=pAccountID and hotelid=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetNextOperation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetNextOperation`()
BEGIN
select `route detail`.OPERATION from `route detail`,`order header`
where `route detail`.SEQ_NO > `order header`.SEQ_NO and
`order header`.ROUTE_ID=`route detail`.ROUTE_ID ORDER BY `route detail`.SEQ_NO asc limit 1;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetOrder`(
pORDER_ID          bigint(15) 
)
BEGIN
select * from `order header` 
where ORDER_ID = pORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetOrderDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetOrderDetails`(
pORDER_ID          bigint(15) 
)
BEGIN
select * from `order detail` 
where ORDER_ID = pORDER_ID
and operation_status != 'CANCELLED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetOrderDetailsForKitchenDisplay` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetOrderDetailsForKitchenDisplay`(
pResto int(5)
)
BEGIN
select `order detail`.*,
item.description,
item.unit,
item.kitchen_designation,
table_assignment.TABLE_NO
from `order detail` left join item on item.item_id = `order detail`.item_id
left join table_assignment on table_assignment.order_id = `order detail`.order_id
where served < quantity and item.resto_id=pResto and 
if(`order detail`.operation_status = 'CANCELLED',`order detail`.ACKNOWLEDGE = 0,`order detail`.OPERATION_STATUS != "")
order by
`order detail`.createtime
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetOrderDetailsForRouting` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetOrderDetailsForRouting`(
pORDER_ID          bigint(15), pResto int(5)
)
BEGIN
select `order detail`.*,
item.description,
item.unit,
table_assignment.TABLE_NO
from `order detail` left join item on item.item_id = `order detail`.item_id
left join table_assignment on table_assignment.order_id = `order detail`.order_id
where `order detail`.ORDER_ID = pORDER_ID and
served < quantity and item.resto_id=pResto;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetOrderForCancel` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetOrderForCancel`()
BEGIN
Select 
`order header`.ORDER_ID,
TOTAL_AMOUNT as AMOUNT,
GetRemarks_Routed(`order header`.ORDER_ID) as REMARKS,
NICKNAME  ,
ASSIGNED_TIME,
`order header`.`STATUS`
from 
employee left join `order header` on (employee.EMPLOYEE_ID=`order header`.ASSIGNED_TO) left join `order detail` on (`order header`.ORDER_ID=`order detail`.ORDER_ID)
where employee.POSITION='KITCHEN CREW'
group by NICKNAME,`order header`.ORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetOrderIdByTableNo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetOrderIdByTableNo`(
pTableNo varchar(20)
)
BEGIN
select  table_assignment.order_id from table_assignment
where 
table_assignment.status='ACTIVE'
and table_assignment.table_no=pTableNo;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetOrders`()
BEGIN
select order_id, if(customer_id="", fgetEmployeeName(employee_id), if(customer_id="WALK-IN CUSTOMER", "WALK-IN", getguestnamefromhotel(customer_id))) as customer_id, getremarks(order_id) as `order`, total_line_items,
total_amount, total_payment from `order header` 
where 
date(order_date)=curdate()
and `status`<>'CANCELLED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetOutOfOrderRooms` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetOutOfOrderRooms`()
BEGIN
select roomid, roomtypecode
from
rooms
where
stateflag = 'OUT OF ORDER';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetOutOfOrderRoomsReport` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetOutOfOrderRoomsReport`()
BEGIN
select roomevents.roomid,rooms.roomtypecode,rooms.stateflag 
from roomevents,
rooms
where
roomevents.roomid = rooms.roomid 
and
roomevents.eventtype = 'ENGINEERING JOB' 
and 
roomevents.date = date(adddate(now(),1));
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPackageDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetPackageDetails`(in pPackageID varchar(20))
BEGIN
select distinct packageDetails.transactionCOde,packageDetails.percentOff,packageDetails.amountOff,transactionCode.Memo,packagedetails.basis,packageHeader.daysapplied from packageDetails,transactioncode,packageheader where packageheader.packageid = packagedetails.packageid and packagedetails.packageid=pPackageID and packagedetails.transactioncode=transactioncode.trancode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPackageHeaderInfo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetPackageHeaderInfo`(
in pPackageId varchar(20),
in pHotelId int(5)
)
BEGIN
Select * FROM packageHeader where PackageId=pPackageId and hotelID =pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPackages` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetPackages`(in pHotelID int(5))
BEGIN
select * from packageHeader where hotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPayments` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetPayments`(
in pFolioID varchar(20), 
in photelid int(5),
in pSubFolio varchar(1)
)
BEGIN
select sum(baseamount),subfolio
from 
folioTransactions 
where 
acctside = 'CREDIT' and
folioId= pFolioId and 
hotelid = pHotelId AND
`status` = 'ACTIVE' and
subfolio = pSubFolio
group by subfolio;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPercentSrvCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetPercentSrvCharge`(
ptrancode varchar(20),
pdeptid varchar(20),
pHotelid int(5)
)
BEGIN
select percentSrvChrg from servicecharge
where trancode=ptrancode and deptid = pdeptid and hotelid=pHotelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetPreviousOperation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetPreviousOperation`(
pORDER_ID varchar(30)
)
BEGIN
select `route detail`.OPERATION from `route detail`,`order header`
where 
`route detail`.SEQ_NO <`order header`.SEQ_NO and
`order header`.ROUTE_ID=`route detail`.ROUTE_ID and
`order header`.ORDER_ID=pORDER_ID limit 1; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRateAmount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRateAmount`(
in pRateTypeCode varchar(100),
in pRoomTypeCode varchar(50)
)
BEGIN
select rateamount from ratetypes where RATECODE=pRateTypeCode and roomtypecode=pRoomTypeCode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRateTypes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRateTypes`()
BEGIN
Select * from RATECODES;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetReceiptDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetReceiptDetails`(
pORDER_ID bigint(10)
)
BEGIN
select QUANTITY,DESCRIPTION,AMOUNT from `order detail`,menu
WHERE `order detail`.ORDER_ID=pORDER_ID and `order detail`.ITEM_ID=menu.MENU_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRecurringCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRecurringCharge`(
in pFolioID varchar(20),
in pHOtelId int(5))
BEGIN
Select * 
from 
foliorecurringcharge 
where folioid=pFolioID and hotelID=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoleMenus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoleMenus`(
in pRoleName varchar(30)
)
BEGIN
select * 
from 
rolemenu 
where
rolename = pRoleName;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRolePrivileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetRolePrivileges`(
in pRoleName varchar(50)
)
BEGIN
select * from role_privileges
where roleName = pRoleName ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoleSystemPrivileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetRoleSystemPrivileges`(
in pRoleName varchar(50)
)
BEGIN
select * from `role_privileges`
where 
roleName = pRoleName;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoleUIPrivileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoleUIPrivileges`(
in pRoleName varchar(100)
)
BEGIN
select * from 
role_ui_privileges
where
roleName = pRoleName and
statusFlag = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoom` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoom`(
in pRoomid varchar(20),
in photelid int(5)
)
BEGIN
select *
from rooms
where
stateflag != 'DELETED' and 
roomid = pRoomid and 
hotelid = photelid
order by roomid
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomAmenity` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomAmenity`(in pRoomID int(11))
BEGIN
Select AmenityId from RoomAmenities where RoomId =pRoomID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomAndTypeOccupied` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomAndTypeOccupied`(in pFrom date,
in pTo date,
in pHOtelID int(5)
)
BEGIN
select distinct roomevents.roomid,rooms.roomtypecode from 
roomevents,rooms
where roomevents.roomid=rooms.roomid and 
(date(roomevents.eventdate) >pFrom and date(roomevents.eventdate) 
<=pTo) and roomevents.eventtype<>'CHECKED OUT'
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomBlocksConflict` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomBlocksConflict`(
in pFrom date,
in pTo date,
in pRoom varchar(1000),
in pHOtelID int(5)
)
BEGIN
select  distinct roomevents.roomid from 
roomevents,rooms
where roomevents.roomid=rooms.roomid and 
(date(roomevents.eventdate) >pFrom and date(roomevents.eventdate) 
<=pTo) and roomevents.eventtype<>'CHECKED OUT' and roomevents.roomid in (pRoom)
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomCharges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomCharges`(
)
BEGIN
select 	
folioschedules.folioid,
folio.masterfolio,
roomevents.roomid,
folioschedules.rate,
transactioncode.trancode,
transactioncode.govtTax,
transactioncode.serviceCharge,
transactioncode.LocalTax 
from 	
folio,
folioschedules,
transactioncode,
roomevents
where 
folio.folioid = folioschedules.folioid
and 	transactioncode.memo = 'ROOM CHARGE'
and	roomevents.date = curdate()
and 	roomevents.eventtype = 'IN HOUSE' 
and 	folioschedules.folioid = roomevents.eventid 
and 	folioschedules.roomid = roomevents.roomid		
and	roomevents.chargeflag = 0;
end */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomChargeTranCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomChargeTranCode`(
in pHotelId int(5)
)
BEGIN
select * 
from 
transactioncode
where
hotelid = pHotelId and
(memo = 'ROOM CHARGE' or memo = 'ROOM RATE' or memo = 'ROOM CHARGES') and
stateflag = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomEvent` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomEvent`(
in pEventNo int(5),
in pHotelid int(5)
)
BEGIN
select * from roomevents
where
eventno = pEventNo and
hotelid = pHotelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomEvents` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomEvents`(
in pEventID int(11)
)
BEGIN
Select * from roomevents where eventid=pEventID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomIDs` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomIDs`(
in photelid int(5)
)
BEGIN
select RoomID
from rooms
where
stateflag != 'DELETED' and 
hotelid = photelid
order by roomid
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomPromo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomPromo`(in pRoomID varchar(12))
BEGIN
Select promos.percentoff,roomTypes.roomtypeid from promos,roomtypes,rooms
where rooms.roomid = pRoomid and
roomtypes.roomtypeid = rooms.roomtypeid and
roomtypes.promocode= promos.promocode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomRate` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomRate`(
in proomid varchar(10), in pHotelId int(4) )
BEGIN
select ratetypes.rateamount,roomtypes.roomtypecode from ratetypes,roomtypes,rooms
where (rooms.roomid = proomid and
roomtypes.roomtypecode = rooms.roomtypecode and
ratetypes.roomtypecode = roomtypes.roomtypecode and rooms.hotelid = pHotelId);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomsToCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomsToCharge`(
in pDate date,
in pHotelId int(5)
)
BEGIN
select 	
eventid,
roomid,
roomrate
from 	
roomevents
where 	
eventDate = pDate and
eventType = 'IN HOUSE' and
chargeFlag = '0' and
hotelid = photelid;
end */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomType`(in pRoomID varchar(12))
BEGIN
Select roomTypes.roomtypecode from Rooms,RoomTypes where rooms.roomtypecode=roomtypes.roomtypecode and rooms.roomid=pRoomID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoomTypes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoomTypes`()
BEGIN
Select distinct roomtypecode from roomtypes;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetRoutingDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetRoutingDetails`(in pFolioID varchar(20),in pHOtelId int(5),in pTCode varchar(20))
BEGIN
select
TransactionCode, HotelID, FolioID, SubFOlio, Basis, PercentCharged, 
AmountCharged, CreateTime, CreatedBy, UpdateTime, UpdatedBy from FOlioRouting where folioid=pFolioID and hotelID=pHOtelID and transactioncode=pTCode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetSchedule` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetSchedule`(in pFolioID varchar(20), in pHotelID int(5))
BEGIN
Select 	RoomID,
`RoomType`,
(FROMDATE) as `From`,
(TODATE) as `To`,
Days, 
RateType,
Rate,
breakfast
from 
folioschedules force index(hotelid,folioid)
where 
folioID=pFolioID  and hotelID=pHOtelID
order by FROMDATE;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetSequenceID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetSequenceID`()
BEGIN
update sequence set id = last_insert_id(id+1);
Select last_insert_id() as id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetSequenceOperation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetSequenceOperation`(
pOPERATION varchar(30),
pORDER_ID varchar(30)
)
BEGIN
select `route detail`.SEQ_NO from `route detail`,`order header`,`route header`
where 
`route detail`.OPERATION=pOPERATION and
`route detail`.ROUTE_ID=`route header`.ROUTE_ID and
`route header`.ROUTE_ID=`order header`.ROUTE_ID and
`order header`.ORDER_ID=pORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetServiceCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetServiceCharge`()
BEGIN
select * from TransactionCode where Memo = 'SERVICE CHARGE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetServiceTime` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetServiceTime`(
pOrderId varchar(20),
pOperation varchar(30)
)
BEGIN
select time_duration from `route detail`,`order history`,`order header`
where 
`order header`.ROUTE_ID=`route detail`.ROUTE_ID and
`order history`.ORDER_ID=`order header`.ORDER_ID and
`order header`.ORDER_ID=pOrderId and `route detail`.OPERATION=pOperation;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetSystemPrivileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetSystemPrivileges`()
BEGIN
select * from `system_privileges`;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTableData` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTableData`(pTerminalID varchar(5))
BEGIN
select `tables`.table_no as table_no,table_assignment.room_id,table_assignment.folio_id,table_assignment.Name,table_assignment.Status, table_assignment.order_id from `tables` left join table_assignment on tables.table_no=table_assignment.table_no 
where (table_assignment.Status  is null) or(table_assignment.Status !='SERVED') and terminal_id=pTerminalID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTableNoByOrderId` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTableNoByOrderId`(
pOrderId int(11)
)
BEGIN
select  table_assignment.table_no from table_assignment
where 
table_assignment.status='ACTIVE'
and table_assignment.order_id=pOrderId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTerminalName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTerminalName`(pTerminalID int(4))
BEGIN
select terminal from cashiers where terminalid=pTerminalID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTotalChargesEmployee` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spGetTotalChargesEmployee`(pEmpId varchar(15))
BEGIN
select concat(firstname, ', ', lastname) as `name`, charge from employee, `employee account` 
where employee.employee_id=`employee account`.employee_id and employee.employee_id=pEmpId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTranCodeGovtTax` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTranCodeGovtTax`()
BEGIN
select trancode from transactioncode where
memo = 'GOVERNMENT TAX' or memo = 'VAT TAX';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTranCodeLocalCall` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTranCodeLocalCall`(
in photelid int(5)
)
BEGIN
select * from transactioncode where
(memo = 'LOCAL CALL' or memo = 'VAT TAX') and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTranCodeLocalTax` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTranCodeLocalTax`()
BEGIN
select trancode from transactioncode where
memo = 'LOCAL TAX';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTranCodeLongDistanceCall` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTranCodeLongDistanceCall`(
in photelid int(5)
)
BEGIN
select * from transactioncode where
(memo = 'IDD CALL' or memo = 'TELEPHONE CHARGES') and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTranCodeMemo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTranCodeMemo`()
BEGIN
select Trancode,Memo,AcctSide,ServiceCharge,GovtTax,LocalTax from transactioncode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTranCodeNDDCall` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTranCodeNDDCall`(
in photelid int(5)
)
BEGIN
select * from transactioncode where
memo = 'NDD CALL' and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTranCodeRoomCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTranCodeRoomCharge`()
BEGIN
select trancode from transactioncode where
memo = 'ROOM CHARGE' or memo = 'ROOM CHARGES';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTranCodeServiceCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTranCodeServiceCharge`()
BEGIN
select trancode from transactioncode where
memo = 'SERVICE CHARGE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTransactionCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTransactionCode`(
in pTranCode varchar(20),
in pHotelId int(5)
)
BEGIN
select * 
from transactionCode 
where 
tranCode=pTranCode and 
hotelid = pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTransactionCodes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTransactionCodes`(in pHotelID int(5))
BEGIN
select * from TransactionCode
where HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetTranTypeId` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetTranTypeId`(
in ptrancode varchar(20),
in photelid int(5)
)
BEGIN
select 
trantypeid 
from transactioncode 
where
trancode = ptrancode and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetUserOldPass` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetUserOldPass`(
in pUserId varchar(20),
in pHotelID int(5)
)
BEGIN
Select aes_decrypt(`password`,'password')
from 
users
where
userid = puserId and hotelid = pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetUserRoles` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetUserRoles`(
in pUserId varchar(20)
)
BEGIN
select user_roles.role_id,
roles.description
from user_Roles,roles
where
user_roles.role_id = roles.role_id and
user_id = pUserId and
user_roles.status = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGetVoidedFolioTransactions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGetVoidedFolioTransactions`(
in pFolioID varchar(20),
in photelid int(5)
)
BEGIN
Select  
*
from 
folioTransactions 
where 
`status`='VOID' and 
folioID=pFolioID and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spGroupFolioTransactions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spGroupFolioTransactions`(
in pFolioid varchar(20)
)
BEGIN
select distinct
folio.folioid,
folio.foliotype,
company.companyName,
concat(company.street1,", ",company.city1) as CityAdd,
concat(company.country1, " ",company.zip1) as CountryAdd,
trandate,
referenceno,
transactioncode,
foliotransactions.memo,
updatedby,
if(acctside='DEBIT',baseamount,0.00) as CHARGES,  
if(acctside='CREDIT',baseamount,0.00) as CREDIT
from
company,
folio,
foliotransactions
where
company.companycode = folio.companycode and
foliotransactions.folioid = folio.folioid and
folio.folioid = pFolioId
order by foliotransactions.trandate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spHKSalesReport` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spHKSalesReport`(
pStartDate date,
pEndDate date
)
BEGIN
select 
order_id,
if(account_id='','WALK-IN',account_id) as customer,
payment_date,
amount
from `payment`
where 
date(payment_date) between pStartDate and pEndDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertAccountPrivilege` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertAccountPrivilege`(
pHotelID          int(5),     
pAccountID        varchar(20),       
pPrivilegeID      varchar(20),    
pTransactionCode  varchar(20),   
pBasis            varchar(1),   
pPercentOff       decimal(3,2),      
pAmountOff        decimal(12,2),  
pCreatedBy        varchar(20)       
)
BEGIN
insert into `accountprivileges` 
(HotelID, AccountID, PrivilegeID, TransactionCode, 
Basis, PercentOff, AmountOff,stateFlag, Createtime, 
CreatedBy, UpdateTime, UpdatedBy)
values
(pHotelID, pAccountID, pPrivilegeID, pTransactionCode, 
pBasis, pPercentOff, pAmountOff,'ACTIVE', now(), 
pCreatedBy, now(), pCreatedBy);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertAmenity` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertAmenity`(
IN pamenityid varchar(20), 
IN pname VARCHAR(50), 
IN pdescription VARCHAR(50),
in photelId int(5),
in pcreatedBy varchar(50)
)
BEGIN
insert into amenities
values(
pamenityid,
pname,
pdescription,
'ACTIVE',
pHotelId,
now(),
pcreatedBy,
now(),
pcreatedBy
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertBike` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertBike`(
pBikeId      varchar(15),  
pPlateNo     varchar(30), 
pEngineNo    varchar(30),
pModel       varchar(30),
pMake        varchar(30),
pCreatedBy   varchar(30)        
)
BEGIN
insert into `bike` 
(BIKE_ID, PLATE_NO, ENGINE_NO, MODEL, MAKE, 
`Status`, CreatedBy, CreateTime, UpdatedBy, 
UpdateTime)
values
(pBikeId, pPlateNo, pEngineNo, pModel, pMake, 
'ACTIVE', pCreatedBy, now(), pCreatedBy, 
now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertBikeAssign` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertBikeAssign`(
pEMPLOYEE_ID  varchar(10),  
pBIKE_ID      varchar(10), 
pCREATEDBY    varchar(30)
)
BEGIN
insert into `bike_assign` 
(EMPLOYEE_ID, BIKE_ID, `STATUS`, CREATEDBY, 
CREATETIME, UPDATEDBY, UPDATETIME)
values
(pEMPLOYEE_ID, pBIKE_ID, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertBlockDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertBlockDetails`(
in pBlockid int(11),
in pRoomId int(11),
in pBlockFrom date,
in pBlockTo date
)
BEGIN
Insert into blockingdetails(blockid,roomid,blockfrom,blockto)
values(pBlockid,pRoomId,pBlockFrom,pBlockTo);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertButton` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertButton`(
pRestoID     int(10),
pBUTTON_ID   varchar(20), 
pTYPE        varchar(50), 
pOBJECT      varchar(50), 
pCREATEDBY   varchar(30) 
)
BEGIN
insert into `button_setup` 
(RESTO_ID,BUTTON_ID, `TYPE`, OBJECT, `STATUS`, CREATEDBY, 
CREATETIME, UPDATEDBY, UPDATETIME)
values
(pRestoID, pBUTTON_ID, pTYPE, pOBJECT, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCallCharges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertCallCharges`(  
in pCallNo int(4),
in pTrunkNo int(4),            
in pCallDate date,             
in pCallTime time,             
in pDuration time,             
in pCost decimal(9,2)
)
BEGIN
insert into callcharges
(
CallNo,
TrunkNo,
CallDate,
CallTime,
Duration,
Cost
)
values
(
pCallNo,
pTrunkNo,
pCallDate,
pCallTime,
pDuration,
pCost
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCallLog` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertCallLog`(pDay varchar(10),
pCallDate date,
pCallTime time,
pDuration time,
pTrunk varchar(11),
pDigits varchar(26),
pLocation varchar(10),
pDestination varchar(26),
pDialID	varchar(16),
pPIN   varchar(16),
pCallType varchar(10),
pRemarks varchar(10),
pCost decimal(9,2),
pExtension varchar(11),
pSerial varchar(11),
pAccCode varchar(11)
)
BEGIN
insert into `log`
(			
`Day`,
`CallDate`,
`Calltime`,
`Duration`,
`Trunk`,
`Digits`,	
`Location`,
`Destination`,
`DialID`,
`PIN`,
`CallType`,
`Remarks`,
`Cost`,
`Extension`,
`Serial`,
`AccCode`
)	
values
(
pDay,
pCallDate,
pCalltime,
pDuration,
pTrunk,
pDigits,
pLocation,
pDestination,
pDialID,
pPIN,
pCallType,
pRemarks,
pCost,
pExtension,
pSerial,
pAccCode);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCashier` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertCashier`(
in pterminalid int(5),
in pterminal varchar(10),
in pcashierid varchar(10),
in pshiftcode varchar(10),
in popeningbalance double(9,2),
in popeningadjustment double(9,2),
in pbeginningbalance double(9,2),
in pchargeinamount double(9,2),
in pcash double(9,2),
in pcreditcard double(9,2),
in pcheck double(9,2),
in pothers double(9,2),
in padjustment double(9,2),
in pnetamount double(9,2),
in prestaurantid int(5)
)
BEGIN
insert into cashier
(
terminalid,
terminal,
cashierid,
shiftcode,
openingbalance,
openingadjustment,
beginningbalance,
chargeinamount,
cash,
creditcard,
`check`,
others,
adjustment,
netamount,
restaurantid
)
values
(
pterminalid,
pterminal,
pcashierid,
pshiftcode,
popeningbalance,
popeningadjustment,
pbeginningbalance,
pchargeinamount,
pcash,
pcreditcard,
pcheck,
pothers,
padjustment,
pnetamount,
prestaurantid
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCashier_Logs` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertCashier_Logs`(
pAuditDate           date,
pType                enum('OPEN','CLOSE'), 
pTerminalid          int(4), 
pCashierid           varchar(10), 
pShiftcode           varchar(10), 
pOpeningbalance      double(12,2), 
pOpeningadjustment   double(12,2), 
pBeginningbalance    double(12,2), 
pChargeinamount      double(12,2), 
pCash                double(12,2), 
pCreditcard          double(12,2), 
pCheque              double(12,2), 
pOthers              double(12,2), 
pAdjustment          double(12,2),
pAmountRemitted	     double(12,2),
pNetamount           double(12,2), 
pCREATEDBY           varchar(20),
pRemarks	     text,
prestaurantid	int(5)
)
BEGIN
insert into `cashiers_logs`
values
(
pAuditDate,
pType, 
pTerminalid, 
pCashierid, 
pShiftcode, 
pOpeningbalance, 
pOpeningadjustment, 
pBeginningbalance, 
pChargeinamount, 
pCash, 
pCreditcard, 
pCheque, 
pOthers, 
pAdjustment,
pAmountRemitted,
pNetamount, 
prestaurantid,
now(), 
pCREATEDBY, 
now(), 
pCREATEDBY,
pRemarks
)
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCompanyAccount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertCompanyAccount`(
in pcompanyid varchar(20),
in `pcompanycode` varchar(50),         
in `pcompanyname` varchar(150),
in `pcompanyurl` varchar(100),                  
in `pcontactperson` varchar(50),         
in `pdesignation` varchar(30),           
in `pstreet1` varchar(50),                 
in `pcity1`  varchar(50),                   
in `pcountry1` varchar(30),                
in `pzip1` varchar(10),                    
in `pstreet2` varchar(50),                 
in `pcity2` varchar(30),                   
in `pcountry2` varchar(30),                
in `pzip2` varchar(10),                    
in `pstreet3` varchar(50),                 
in `pcity3` varchar(30),                   
in `pcountry3` varchar(30),                
in `pzip3` varchar(10),                    
in `pemail1` varchar(50),                  
in `pemail2` varchar(50),                  
in `pemail3` varchar(50),                  
in `pcontactnumber1` varchar(15),          
in `pcontactnumber2` varchar(15),          
in `pcontactnumber3` varchar(15),          
in `pcontacttype1` varchar(15),            
in `pcontacttype2` varchar(15),            
in `pcontacttype3` varchar(15),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into company 
values
(
pcompanyid,
`pcompanycode`,         
`pcompanyname`,
`pcompanyurl`,                  
`pcontactperson`,         
`pdesignation`,           
`pstreet1` ,                 
`pcity1` ,                   
`pcountry1` ,                
`pzip1` ,                    
`pstreet2` ,                 
`pcity2` ,                   
`pcountry2` ,                
`pzip2` ,                    
`pstreet3` ,                 
`pcity3` ,                   
`pcountry3` ,                
`pzip3` ,                    
`pemail1` ,                  
`pemail2` ,                  
`pemail3` ,                  
`pcontactnumber1` ,          
`pcontactnumber2` ,          
`pcontactnumber3` ,          
`pcontacttype1` ,            
`pcontacttype2` ,            
`pcontacttype3`,
'ACTIVE',
photelid,
now(),
pcreatedby,
now(),
pcreatedby
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertComplaint` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertComplaint`(
pORDER_ID       varchar(100), 
pCUSTOMER_ID    varchar(100), 
pREASON_CODE    varchar(10), 
pREMARKS        text, 
pCREATEDBY      varchar(30)
)
BEGIN
insert into `complaints` 
(ORDER_ID, CUSTOMER_ID, 
REASON_CODE, REMARKS, STATUS, CREATEDBY, 
CREATETIME, UPDATEDBY, UPDATETIME
)
values
(pORDER_ID, pCUSTOMER_ID, 
pREASON_CODE, pREMARKS, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now()
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCurrencyCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertCurrencyCode`(
pcurrencycode    varchar(10),        
pcurrency        varchar(20),        
pconversionrate  decimal(12,2),    
pHOTELID         int(5),         
pCREATEDBY       varchar(20)      
)
BEGIN
insert into `currencycodes` 
(currencycode, currency, conversionrate, 
stateFlag,HOTELID, CREATETIME, CREATEDBY, UPDATETIME, 
UPDATEDBY)
values
(pcurrencycode, pcurrency, pconversionrate,'ACTIVE', 
pHOTELID, now(), pCREATEDBY, now(), 
pCREATEDBY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCustomer` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertCustomer`(
pCUSTOMER_ID     varchar(100), 
pCUSTOMER_TYPE   varchar(30), 
pNAME            varchar(100), 
pACCOUNT_NAME    varchar(100), 
pLAST_NAME       varchar(100), 
pFIRST_NAME      varchar(100), 
pPHONE_NO        varchar(100), 
pADDRESS1        text, 
pADDRESS2        text, 
pCITY            varchar(100), 
pPROVINCE        varchar(100), 
pPOSTAL_CODE     varchar(30), 
pCOUNTRY         varchar(100), 
pTAX_REG_NO      varchar(100), 
pTAXPAYER_ID     varchar(100), 
pTYPE            varchar(100), 
pCATEGORY        varchar(100), 
pCLASS           varchar(100), 
pCREATEDBY       varchar(30),
pHOTELID	int(5)
)
BEGIN
insert into customers
values
(pCUSTOMER_ID, pCUSTOMER_TYPE, pNAME, pACCOUNT_NAME, 
pLAST_NAME, pFIRST_NAME, 
pPHONE_NO, pADDRESS1, pADDRESS2, pCITY, pPROVINCE, 
pPOSTAL_CODE, 
pCOUNTRY, pTAX_REG_NO, pTAXPAYER_ID, 
pTYPE, pCATEGORY, pCLASS, 
'ACTIVE',pHOTELID, pCREATEDBY, now(), pCREATEDBY, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertCustomerLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertCustomerLedger`(
pCUSTOMERID	varchar(10),
pORDER_ID	bigint(15),
pDEBIT		decimal(12,2),
pCREDIT		decimal(12,2),
pHOTELID	int(5),
pCREATEDBY	varchar(20)
)
BEGIN
insert into customer_ledger 
(
CUSTOMER_ID,
DATE,
ORDER_ID,
debit,
credit,
HOTELID,
CREATETIME,
CREATEDBY,
UPDATETIME,
UPDATEDBY,
posttoacctng,
closed
)
values
(
pCUSTOMERID,
curdate(),
pORDER_ID,
pDEBIT,
pCREDIT,
pHOTELID,
now(),
pCREATEDBY,
now(),
pCREATEDBY,
'0',
'0'
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertDepartment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertDepartment`(
in pDeptId      varchar(20),       
in pName        varchar(100),       
in pHotelId     int(5),         
in pCreatedBy   varchar(30)  
)
BEGIN
insert into `department`
(DeptId, Name, HotelId, stateFlag, CreatedBy, CreateTime, UpdatedBy, UpdateTime)
values
(pDeptId, pName, pHotelId,'ACTIVE', pCreatedBy, now(), pCreatedBy, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertEmpLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertEmpLedger`(
pEMPLOYEE_ID	varchar(10),
pORDER_ID	bigint(15),
pDEBIT		decimal(12,2),
pCREDIT		decimal(12,2),
pHOTELID	int(5),
pCREATEDBY	varchar(20)
)
BEGIN
insert into employee_ledger 
(
EMPLOYEE_ID,
DATE,
ORDER_ID,
debit,
credit,
HOTELID,
CREATETIME,
CREATEDBY,
UPDATETIME,
UPDATEDBY,
posttoacctng,
closed
)
values
(
pEMPLOYEE_ID,
curdate(),
pORDER_ID,
pDEBIT,
pCREDIT,
pHOTELID,
now(),
pCREATEDBY,
now(),
pCREATEDBY,
'0',
'0'
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertEmployee` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertEmployee`(
pEMPLOYEE_ID  varchar(10),      
pLASTNAME     varchar(30),          
pFIRSTNAME    varchar(30),          
pMIDDLENAME    varchar(30),   
pNICKNAME   varchar(30),	
pPOSITION     varchar(20),         
pADDRESS      varchar(200),       
pCONTACTNO        varchar(20),         
pCREATEDBY    varchar(30),
pHOTELID	int(5)
)
BEGIN
insert into `employee` 
(EMPLOYEE_ID, LASTNAME, FIRSTNAME,MIDDLENAME,NICKNAME, 
POSITION, ADDRESS, CONTACTNO, `STATUS`, CREATEDBY, 
CREATETIME, UPDATEDBY, UPDATETIME, HOTEL_ID)
values
(pEMPLOYEE_ID, pLASTNAME, pFIRSTNAME,pMIDDLENAME,pNICKNAME, 
pPOSITION, pADDRESS, pCONTACTNO, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now(), pHOTELID);
if pPosition='KITCHEN CREW' then
insert into `employee status` values(pEmployee_id,pNICKNAME,'');
end if;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertEngineeringJob` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertEngineeringJob`(
in penggjobno varchar(20),
in penggserviceid varchar(20),
in passignedperson varchar(50),
in proomid varchar(10),
in pstartdate varchar(15),
in penddate varchar(15),
in pstarttime varchar(15),
in pendtime varchar(15),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into engineeringjobs
values(
penggjobno,
penggserviceid,
passignedperson,
proomid,
pstartdate,
penddate,
pstarttime,
pendtime,
'ACTIVE',
photelid,
now(),
pcreatedby,
now(),
pcreatedby);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertEngineeringService` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertEngineeringService`(
in photelid int(5),
IN penggserviceid varchar(20), 
IN pservicename VARCHAR(50), 
IN pdescription VARCHAR(100),
in pcreatedby varchar(20)
)
BEGIN
insert into 
engineeringservices
values(
photelid,
penggserviceid,
pservicename,
pdescription,
'ACTIVE',
now(),
pcreatedby,
now(),
pcreatedby
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFloor` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertFloor`(
in pHotelId int(5),
in pFloor varchar(25),
in pFloorLayoutImage text,
in pupdatedBy varchar(20)
)
BEGIN
insert into floors
values
(
pHotelId,
pFloor,
pFloorLayoutImage,
'ACTIVE',
now(),
pupdatedby,
now(),
pupdatedby
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFolio` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertFolio`(
in pHotelID int(5),      
in pFolioID varchar(20),              
in pAccountID varchar(20),   
in pEventID int(10),
in pFolioType varchar(25),    
in pGroupName varchar(100),      
in pAccountType  varchar(25),    
in pNoOfAdults int(2),    
in pNoOfCHild int(2),     
in pMasterFolio varchar(20),     
in pCompanyID varchar(20),      
in pAgentID varchar(20),       
in pSource varchar(50),     
in pFROMDATE datetime,  
in pTODATE datetime,    
in pARRIVALDATE datetime,       
in pPACKAGEID varchar(20),    
in pStatus varchar(15),
in pRemarks text
)
BEGIN
insert into folio
(
HotelID,      
FolioID,              
AccountID,   
EventID,
FolioType,    
GroupName,      
AccountType,    
NoOfAdults,    
NoOfCHild,     
MasterFolio,     
CompanyID,      
AgentID,       
Source,     
FROMDATE,  
TODATE,    
ARRIVALDATE,
PACKAGEID,    
`Status`,
Remarks
)
values
(
pHotelID,
pFolioID,
pAccountID ,
pEventID ,
pFolioType, 
pGroupName ,
pAccountType,
pNoOfAdults,
pNoOfCHild ,
pMasterFolio,
pCompanyID ,
pAgentID,
pSource ,
pFROMDATE, 
pTODATE ,
pARRIVALDATE,
pPACKAGEID,
pStatus,
pRemarks
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFolioLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertFolioLedger`(
in pHtelID int(5),
in pFolioID varchar(20),
in pSubFolio varchar(2),
in pAccountid varchar(20),
in pCharges decimal(12,2),
in pPaycash decimal(12,2),
in pPaycard decimal(12,2),
in pPaycheque decimal(12,2),
in pPayGiftCheque decimal (12,2),
in pBalanceFowarded decimal(12,2),
in pBalanceNet decimal(12,2),
in pDiscount decimal(12,2),
in pGovernmentTax decimal(12,2),
in pLocalTax decimal(12,2),
in pServiceCharge decimal(12,2),
in pAgentComission decimal(12,2),
in pTotalNet decimal(12,2),
in pPostToLedger decimal(12,2),
in pCreatedBy varchar(20)
)
BEGIN
insert into folioledger 
values
(
pHtelID,
pFolioID,
pSubfolio,
pAccountid,
pCharges,
pPaycash ,
pPaycard,
pPaycheque,
pPayGiftCheque,
pBalanceFowarded,
pBalanceNet,
pDiscount,
pGovernmentTax,
pLocalTax,
pServiceCharge,
pAgentComission,
pTotalNet,
pPostToLedger,
now(),
pCreatedBy,
now(),
pCreatedBy
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFolioPackages` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertFolioPackages`(
in pHotelId int(5),
in pFolioID varchar(20),
in pTransactionCode varchar(20),
in pBasis varchar(2),
in pPercentOff decimal(2,2),
in pAmountOff decimal(12,2),
in pDaysApplied varchar(50),
in pCreatedby varchar(20)
)
BEGIN
insert into 
foliopackage
values
(
pHotelId,
pFolioID,
pTransactionCode,
pBasis,
(pPercentOff/100),
pAmountOff,
pDaysApplied,
now(),
pCreatedBy,
now(),
pCreatedBy
)
on duplicate key update 
Basis = pBasis,
PercentOff = (pPercentOff/100),
AmountOff = pAmountOff,
DaysApplied = pDaysApplied,
updatedBy = pCreatedBy,
updatetime = now()
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFolioPrivilege` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertFolioPrivilege`(
in pHotelID          int(5),
in pFolioID          varchar(20),
in pTransactionCode  varchar(20),
in pBasis            varchar(1),
in pPercentoff       decimal(2,2),
in pAmountOff        decimal(12,2)
)
BEGIN
insert into
folioprivilege
values
(
pHotelId,
pFolioId,
pTransactionCode,
pBasis,
pPercentOff,
pAmountOff
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFolioRecurringCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertFolioRecurringCharge`(
pHotelID int(5),
pFolioID varchar(20),
pTransactionCode  varchar(20),
pMemo varchar(20),
pAmount decimal(12,2),
pFromDate datetime,
pTodate datetime,
pCreatedBy varchar(20)
)
BEGIN
insert into 
`foliorecurringcharge` 
values
(
pHotelID, 
pFolioID,
pTransactionCode,
pMemo,
pAmount, 
pFromDate, 
pTodate, 
now(), 
pCreatedBy, 
now(), 
pCreatedBy
)
on duplicate key update
Amount = pAmount,
FromDate = pFromDate,
Todate = pTodate,
updatedby = pCreatedBy,
updateTime = now()
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFolioSchedule` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertFolioSchedule`(
pHOTELID     int(5),        
pFolioId     varchar(20),        
pRoomID      varchar(10),        
pRoomType    varchar(50),     
pFROMDATE    datetime,          
pTODATE      datetime,         
pDays        int(3),        
pRATETYPE    varchar(25),      
pRATE        decimal(12,2),       
pBREAKFAST   varchar(11),       
pCREATEDBY   varchar(20),         
pUPDATEDBY   varchar(20)     
)
BEGIN
insert into `folioschedules`
(
HOTELID,
FolioId,
RoomID ,
RoomType,
FROMDATE, 
TODATE,  
Days,   
RATETYPE,    
RATE,        
BREAKFAST,   
CREATEDBY,   
UPDATETIME,  
UPDATEDBY,   
CREATETIME
)
values
(
pHOTELID,
pFolioId,
pRoomID ,
pRoomType,
pFROMDATE, 
pTODATE,  
pDays,   
pRATETYPE,    
pRATE,        
pBREAKFAST,   
pCREATEDBY,   
now(),
pUPDATEDBY,   
now()
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertFunction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertFunction`(
pRESTO_ID	INT(10),
pFUNCTION_ID  varchar(20),  
pDESCRIPTION  varchar(100), 
pOBJECT       varchar(20),  
pMETHOD       varchar(30),
pCREATEDBY    varchar(30),
pCOST		DECIMAL(12,2)
)
BEGIN
insert into `function mapping` 
(RESTO_ID, FUNCTION_ID, DESCRIPTION, OBJECT, METHOD, 
`STATUS`, CREATEDBY, CREATETIME, UPDATEDBY, 
UPDATETIME,COST)
values
(pRESTO_ID, pFUNCTION_ID, pDESCRIPTION, pOBJECT, pMETHOD, 
'ACTIVE', pCREATEDBY, now(), pCREATEDBY, 
now(),pCOST);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertGroup`(
pGROUP_ID     varchar(20),
pMAINGROUP_ID VARCHAR(20),
pDESCRIPTION  varchar(100), 
pCREATEDBY    varchar(30),
pRESTOID	int(5)
)
BEGIN
insert into `group` 
(RESTO_ID, GROUP_ID, MAINGROUP_ID, DESCRIPTION, STATUS, CREATEDBY, 
CREATETIME, UPDATEDBY, UPDATETIME)
values
(pRESTOID, pGROUP_ID, pMAINGROUP_ID, pDESCRIPTION, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertGroupFolio` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertGroupFolio`(
IN pFolioID varchar(12),
IN pAccountID varchar(12),
in pEventID varchar(12),
IN pFolioType VARCHAR(25), 
in pOrgName varchar(75),
IN pBreakFast VARCHAR(15), 
iN pPromo VARCHAR(30), 
in pAccountType varchar(25),
IN pStatus VARCHAR(15), 
IN pSource VARCHAR(15),
in pNoAdult int(2),
in pNoChild int(2),
in pCompanyCode varchar(100)
)
BEGIN
insert into folio
(
folioId,Accountid,EventId,Foliotype,groupName,BreakFast,Promo,AccountType,`Status`,Source,NoofAdults,NoofChild,companycode
)
values
(
pFolioID,pAccountID,pEventId,pFolioType,pOrgName,pBreakFast,pPromo,pAccountType,pStatus,pSource,pNoAdult,pNoChild,pCompanyCode
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertGuest` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertGuest`(
paccountid     varchar(20)   ,       
paccountname   varchar(20)   ,
ptitle         varchar(5)   ,
plastname      varchar(50)  ,
pfirstname     varchar(50)  ,
pmiddlename    varchar(50)   ,
psex           varchar(6)    ,
pstreet        varchar(100)  ,
pcity          varchar(100)  ,
pcountry       varchar(100)  ,
pzip           varchar(10)   ,
pemailaddress  varchar(100)  ,
pcitizenship   varchar(100)  ,
ppassportid    varchar(30)   ,
pTelephoneNo   varchar(50)   ,
pMobileNo      varchar(50)  ,
pFaxNo         varchar(50)   ,
pguestImage    text          ,
pmemo          text          ,
pconcierge     text          ,
premarks       text          ,
pHOTELID       int(5)        ,
pCREATEDBY     varchar(20)   
)
BEGIN
insert into guests (
)
values
(
paccountid, 
paccountname, 
ptitle, 
plastname, 
pfirstname,
pmiddlename, 
psex, 
pstreet, 
pcity, 
pcountry, 
pzip, 
pemailaddress, 
pcitizenship, 
ppassportid, 
pTelephoneNo, 
pMobileNo, 
pFaxNo, 
pguestImage,
1, 
pmemo, 
pconcierge, 
premarks,
'ACTIVE', 
pHOTELID, 
now(), 
pCREATEDBY, 
now(), 
pCREATEDBY
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertHotel` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertHotel`(
pHotelID     int(3),
pHotelName   varchar(100),
pNoOfFloors  int(5),      
pNoOfRooms   int(5),      
pCreatedBy   varchar(20)
)
BEGIN
insert into `hotel` 
(HotelID, HotelName, NoOfFloors, NoOfRooms, 
stateFlag, CreatedBy, CreateTime, UpdatedBy, 
UpdateTime)
values
(pHotelID, pHotelName, pNoOfFloors, pNoOfRooms, 
'ACTIVE', pCreatedBy, now(), pCreatedBy, 
now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertHouseKeeper` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertHouseKeeper`(
in photelid int(5),
IN phousekeeperid VARCHAR(20), 
IN plastname VARCHAR(50), 
IN pfirstname VARCHAR(50), 
IN pmiddlename VARCHAR(50),
in pcreatedby varchar(20)
)
BEGIN
insert into housekeepers
values(
photelid,
phousekeeperid,
plastname,
pfirstname,
pmiddlename,
'ACTIVE',
now(),
pcreatedby,
now(),
pcreatedby
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertHousekeepingJob` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertHousekeepingJob`(
in phousekeepingjobno varchar(20),	
in proomid varchar(10),
in pstarttime varchar(15),
in pendtime varchar(15),
in pelapsedtime	varchar(30),
in phousekeeperid varchar(10),
in pmemo varchar(100),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into housekeepingjobs
values
(
phousekeepingjobno,
proomid,
now(),
pstarttime,
pendtime,
pelapsedtime,
phousekeeperid,
pmemo,
photelid,
now(),
pcreatedby,
now(),
pcreatedby,
'ACTIVE'
);
update rooms set cleaningstatus = 'CLEAN' where roomid = proomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertHouseKeepingLog` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertHouseKeepingLog`(
pHkDate         date,    
proomid         varchar(10),    
phousekeeperid  varchar(10) ,     
pTransID        varchar(20) ,  
pTime           time        ,     
pparseFlag      tinyint(4)   
)
BEGIN
insert into `hk_log` 
(Hk_Date,roomid, housekeeperid, TransID, `Time`, 
parseFlag)
values
(pHkDate,proomid, phousekeeperid, pTransID, pTime, 
pparseFlag);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItem` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertItem`(
pRestoID int(10),
pGROUP_ID varchar(50),
pDESCRIPTION varchAR(100),
pUNIT varchar(15),
pUNIT_COST decimal(12,2),
pPRICE decimal(12,2),
pVAT DECIMAL(6,3),
pLOCAL_TAX DECIMAL(6,3),
pSERVICE_CHARGE DECIMAL(6,3),
pKITCHEN_DESIGNATION varchar(100),
pCreatedBy varchar(30),
pAVAILABILITY tinyint(1)
)
BEGIN
insert into `item` 
(RESTO_ID, GROUP_ID, DESCRIPTION, UNIT, UNIT_COST,
SELLING_PRICE, EVAT, LOCAL_TAX,SERVICE_CHARGE,`STATUS`,KITCHEN_DESIGNATION, CREATEDBY, CREATETIME, UPDATEDBY, 
UPDATETIME,AVAILABILITY)
values
(pRestoID, pGROUP_ID, pDESCRIPTION, pUNIT, pUNIT_COST,
pPRICE, pVAT, pLOCAL_TAX,pSERVICE_CHARGE, 'ACTIVE',pKITCHEN_DESIGNATION, pCreatedBy, now(), pCreatedBy, 
now(),pAVAILABILITY);
select last_insert_id();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertItemNote` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertItemNote`(
pITEM_ID        varchar(10), 
pREMARKS        varchar(200), 
pCREATED_BY     varchar(50)
)
BEGIN
insert into `item_notes` 
(REMARKS, ITEM_ID, CREATED_BY, CREATE_TIME, 
UPDATED_BY, UPDATE_TIME, STATUS_FLAG, ACCESS_COUNT
)
values
(pREMARKS, pITEM_ID, pCREATED_BY, now(), 
pCREATED_BY, now(), 'ACTIVE', 0 )
on duplicate key
update ACCESS_COUNT = ACCESS_COUNT + 1;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMainGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertMainGroup`(
pMAINGROUP_ID VARCHAR(20),
pDESCRIPTION  varchar(100), 
pCREATEDBY    varchar(30)
)
BEGIN
insert into `main_item_group` 
(ID, DESCRIPTION, STATUS, CREATEDBY, 
CREATETIME, UPDATEDBY, UPDATEdTIME)
values
(pMAINGROUP_ID, pDESCRIPTION, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertMenu`(
pMENU_ID       varchar(10),       
pDESCRIPTION  varchar(100),   
pVAT	 	decimal(2,2),
pPRICE		decimal(12,2),
pPICTURE	varchar(200),     
pCREATEDBY     varchar(30),
pSERVICECHARGE	decimal(12,2)
)
BEGIN
insert into `menu` 
(MENU_ID, DESCRIPTION,VAT,PRICE, `STATUS`,PICTURE, CREATEDBY, 
CREATETIME, UPDATEDBY, UPDATETIME, SERVICE_CHARGE)
values
(pMENU_ID, pDESCRIPTION,pVAT,pPRICE,'ACTIVE',pPICTURE, pCREATEDBY, 
now(), pCREATEDBY, now(), pSERVICECHARGE);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMenuDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertMenuDetail`(
pMENU_ID     varchar(10),  
pITEM_ID     varchar(10),   
pQUANTITY  	int
)
BEGIN
insert into `menu detail` 
(MENU_ID, ITEM_ID, QUANTITY)
values
(pMENU_ID, pITEM_ID, pQUANTITY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMySqlUser` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertMySqlUser`(
pUser                   varchar(30), 
pPassword               char(41), 
pSelect_priv            enum('N','Y'), 
pInsert_priv            enum('N','Y'), 
pUpdate_priv            enum('N','Y'), 
pDelete_priv            enum('N','Y'), 
pCreate_priv            enum('N','Y'), 
pDrop_priv              enum('N','Y'), 
pReload_priv            enum('N','Y'), 
pShutdown_priv          enum('N','Y'), 
pProcess_priv           enum('N','Y'), 
pFile_priv              enum('N','Y'), 
pGrant_priv             enum('N','Y'), 
pReferences_priv        enum('N','Y'), 
pIndex_priv             enum('N','Y'), 
pAlter_priv             enum('N','Y'), 
pShow_db_priv           enum('N','Y'), 
pSuper_priv             enum('N','Y'), 
pCreate_tmp_table_priv  enum('N','Y'), 
pLock_tables_priv       enum('N','Y'),
pExecute_priv           enum('N','Y'), 
pRepl_slave_priv        enum('N','Y'), 
pRepl_client_priv       enum('N','Y'), 
pCreate_view_priv       enum('N','Y'), 
pShow_view_priv         enum('N','Y'), 
pCreate_routine_priv    enum('N','Y'), 
pAlter_routine_priv     enum('N','Y'), 
pCreate_user_priv       enum('N','Y')
)
BEGIN
insert into `mysql`.`user`
values
('localhost',pUser, Password(pPassword), pSelect_priv, pInsert_priv, 
pUpdate_priv, pDelete_priv, pCreate_priv, 
pDrop_priv, pReload_priv, pShutdown_priv, 
pProcess_priv, pFile_priv, pGrant_priv, 
pReferences_priv, pIndex_priv, pAlter_priv, 
pShow_db_priv, pSuper_priv, pCreate_tmp_table_priv, 
pLock_tables_priv, pExecute_priv, pRepl_slave_priv, 
pRepl_client_priv, pCreate_view_priv, pShow_view_priv, 
pCreate_routine_priv, pAlter_routine_priv, 
pCreate_user_priv, "", "", 
"", "", 0, 
0, 0, 0);
insert into `mysql`.`user`
values
('%',pUser, Password(pPassword), pSelect_priv, pInsert_priv, 
pUpdate_priv, pDelete_priv, pCreate_priv, 
pDrop_priv, pReload_priv, pShutdown_priv, 
pProcess_priv, pFile_priv, pGrant_priv, 
pReferences_priv, pIndex_priv, pAlter_priv, 
pShow_db_priv, pSuper_priv, pCreate_tmp_table_priv, 
pLock_tables_priv, pExecute_priv, pRepl_slave_priv, 
pRepl_client_priv, pCreate_view_priv, pShow_view_priv, 
pCreate_routine_priv, pAlter_routine_priv, 
pCreate_user_priv, "", "", 
"", "", 0, 
0, 0, 0);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertMySqlUserTablePrivs` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertMySqlUserTablePrivs`(
pUser          char(16), 
pTable_name    char(64), 
pGrantor       char(77), 
pTable_priv    set('Select','Insert','Update','Delete','Create','Drop','Grant','References','Index','Alter','Create View','Show view'), 
pColumn_priv   set('Select','Insert','Update','References')
)
BEGIN
insert into `mysql`.`tables_priv` 
set Host = '%', Db = '', `User` = pUser, 
Table_name = pTable_name, Grantor = pGrantor, 
`Timestamp` = now(), Table_priv = pTable_priv, 
Column_priv = pColumn_priv;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertNewCompany` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertNewCompany`(
in `pcompanycode` varchar(10),         
in `pcompanyname` varchar(150),
in `pcompanyurl` varchar(100),                  
in `pcontactperson` varchar(50),         
in `pdesignation` varchar(30),         
in `pstreet1` varchar(50),                 
in `pcity1` varchar(50),                   
in `pcountry1` varchar(30),                
in `pzip1` varchar(10),                     
in `pemail1` varchar(50) ,                                 
in `pcontactnumber1` varchar(15)           
)
BEGIN
insert into company 
(
`companycode`,         
`companyname`,
`companyurl`,                  
`contactperson`,         
`designation`,          
`street1` ,                 
`city1` ,                   
`country1` ,                
`zip1` ,                                   
`email1` ,                     
`contactnumber1`          
)
values
(	       
`pcompanycode`,         
`pcompanyname`,
`pcompanyurl`,                  
`pcontactperson`,         
`pdesignation`,           
`pstreet1` ,                 
`pcity1` ,                   
`pcountry1` ,                
`pzip1` ,                                     
`pemail1` ,                  
`pcontactnumber1`                 
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertNewOperation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertNewOperation`(
pORDER_ID varchar(20),
pOPERATION varchar(30)
)
BEGIN
insert into `order history`(ORDER_ID,OPERATION)
values(pORDER_ID,pOPERATION);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertOperation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertOperation`(
pOPERATION  varchar(10), 
pDESCRIPTION     varchar(50),
pCREATEDBY     varchar(30) 
)
BEGIN
insert into `operation` 
(OPERATION, DESCRIPTION, `STATUS`, CREATEDBY, 
CREATETIME, UPDATEDBY, UPDATETIME)
values
(pOPERATION, pDESCRIPTION, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertOrderDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertOrderDetail`(
pORDER_ID    bigint(10), 
pLINE_NO     int(4), 
pITEM_ID     varchar(30), 
pDESCRIPTION     varchar(500), 
pUNIT_PRICE  decimal(12,4), 
pQUANTITY    decimal(12,4), 
pDISCOUNT decimal(12,4),
pVAT	     decimal(12,4),
pLOCAL_TAX   decimal(12,4),
pAMOUNT      decimal(12,4), 
pCREATEDBY   varchar(30),
pSERVICE_CHARGE decimal(12,4),
pDISCITEM	varchar(30),
pROUTE		tinyint(1),
pNOTE		text
)
BEGIN
insert into `order detail` (
ORDER_ID, 
LINE_NO, 
ITEM_ID, 
DESCRIPTION,
UNIT_PRICE, 
QUANTITY, 
DISCOUNT,
VAT, 
LOCAL_TAX,
AMOUNT, 
CREATEDBY, 
CREATETIME, 
UPDATEBY, 
UPDATETIME, 
SERVICE_CHARGE, 
DITEM_ID, 
ROUTE, 
SERVED, 
SERVED_BY, 
OPERATION_STATUS, 
ITEM_NOTES
)
values(
pORDER_ID, 
pLINE_NO, 
pITEM_ID, 
pDESCRIPTION,
pUNIT_PRICE, 
pQUANTITY,
pDISCOUNT,
pVAT,
pLOCAL_TAX,
pAMOUNT, 
pCREATEDBY, 
now(), 
pCREATEDBY, 
now(), 
pSERVICE_CHARGE, 
pDISCITEM, 
pROUTE,
0,
'',
'NEW',
pNOTE
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertOrderHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertOrderHeader`(
pORDER_ID          bigint(15), 
pCUSTOMER_ID       varchar(20), 
pROUTE_ID          varchar(10),
pASSIGNED_TO        varchar(10), 
pASSIGNED_TIME     datetime ,
pORDER_DATE        datetime , 
pTOTAL_LINE_ITEMS  int(11), 
pTOTAL_AMOUNT      decimal(12,4), 
pTOTAL_DISCOUNT decimal(12,4),
pTOTAL_PAYMENT     decimal(12,4), 
pBALANCE           decimal(12,4), 
pStatus            varchar(30), 
pCREATEDBY         varchar(30),
pVAT_SALES           decimal(12,4),
pVAT_AMOUNT          decimal(12,4),
pNONVAT_SALES        decimal(12,4),
pSERVICE_CHARGE      decimal(12,4),
pLOCAL_TAX      decimal(12,4),
pROOMSERVICE_CHARGE  decimal(12,4),
pEMPLOYEE_ID	     varchar(20),
pSHIFTCODE	varchar(10),
pTERMINALID	int(4)
)
BEGIN
insert into `order header` (
ORDER_ID, 
CUSTOMER_ID, 
ROUTE_ID, 
ASSIGNED_TO, 
ASSIGNED_TIME, 
ORDER_DATE, 
TOTAL_LINE_ITEMS, 
TOTAL_AMOUNT, 
TOTAL_DISCOUNT,
TOTAL_PAYMENT, 
BALANCE,
`STATUS`, 
CREATEDBY, 
CREATETIME, 
UPDATEDBY, 
UPDATETIME, 
VAT_SALES, 
VAT_AMOUNT, 
NONVAT_SALES, 
SERVICE_CHARGE, 
LOCAL_TAX,
ROOMSERVICE_CHARGE, 
EMPLOYEE_ID,
SHIFT_CODE,
TERMINAL_ID
)
values(
pORDER_ID, 
pCUSTOMER_ID, 
pROUTE_ID, 
pASSIGNED_TO, 
pASSIGNED_TIME, 
pORDER_DATE, 
pTOTAL_LINE_ITEMS, 
pTOTAL_AMOUNT, 
pTOTAL_DISCOUNT,
pTOTAL_PAYMENT, 
pBALANCE,
pStatus, 
pCREATEDBY, 
now(), 
pCREATEDBY, 
now(), 
pVAT_SALES, 
pVAT_AMOUNT, 
pNONVAT_SALES, 
pSERVICE_CHARGE, 
pLOCAL_TAX,
pROOMSERVICE_CHARGE, 
pEMPLOYEE_ID,
pSHIFTCODE,
pTERMINALID
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertOrderHistory` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertOrderHistory`(
pORDER_ID      bigint(15), 
pOPERATION     varchar(25),
pASSIGNED_TO	varchar(30),
pDISPOSITION   varchar(15)
)
BEGIN
insert into `order history`
(order_id,operation,start_time,assigned_to,disposition)
values
(pORDER_ID, pOPERATION, curtime(), pASSIGNED_TO, pDISPOSITION
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPackageDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertPackageDetails`(
pPackageID        varchar(20), 
pTransactionCode  varchar(20),   
pBasis            varchar(1),        
pPercentOff       decimal(2,2),   
pAmountOff        decimal(12,2),   
pHotelID          int(5),        
pCreatedBy        varchar(20)          
)
BEGIN
insert into `packagedetails` 
(PackageID, TransactionCode, Basis, PercentOff, 
AmountOff, HotelID,stateFlag, CreateTime, CreatedBy, 
Updatedby, UpdateTime)
values
(pPackageID, pTransactionCode, pBasis, pPercentOff, 
pAmountOff, pHotelID,'ACTIVE', now(), pCreatedBy, 
pCreatedBy, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPackageHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertPackageHeader`(
pPackageID    varchar(20),        
pDescription  varchar(100),          
pFromDate     datetime,           
pToDate       datetime,            
pDaysApplied  varchar(50),           
pHotelID      int(5),          
pCreatedBy    varchar(50)        
)
BEGIN
insert into `packageheader` 
(PackageID, Description, FromDate, ToDate, 
DaysApplied, stateFlag, HotelID, CreatedBy, 
CreateTime, UpdatedBy, updateTime)
values
(pPackageID, pDescription,pFromDate, pToDate, 
pDaysApplied, 'ACTIVE', pHotelID, pCreatedBy, 
now(), pCreatedBy, now());			
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPayment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertPayment`( 
pORDER_ID bigint(12),
pPAYMENT_TYPE varchar(20),
pAMOUNT decimal(12,4),
pGIFTCHEQUE_NO   varchar(20) ,
pCREDITCARD_NO   varchar(20), 
pCARD_CO         varchar(30), 
pAPPROVAL_CODE   varchar(30), 
pACCOUNT_ID      varchar(20), 
pPAYMENT_DATE datetime,
pCOLLECTED_BY varchar(30),
pSHIFT_CODE 	int(11),
pTERMINAL_ID 	int(11),
pRESTAURANT_ID	int(5),
pCOUPON_NO	varchar(20),
pVALIDDATE	date,
pCOUPONTYPE	varchar(30)
)
BEGIN
insert into `payment` 
(ORDER_ID, PAYMENT_TYPE, AMOUNT, GIFTCHEQUE_NO, 
CREDITCARD_NO, CARD_CO,APPROVAL_CODE, ACCOUNT_ID, 
PAYMENT_DATE, COLLECTED_BY,SHIFT_CODE,TERMINAL_ID,RESTAURANT_ID,
COUPON_NO, VALID_DATE, COUPON_TYPE)
values
(pORDER_ID, pPAYMENT_TYPE, pAMOUNT, pGIFTCHEQUE_NO,
pCREDITCARD_NO, pCARD_CO, pAPPROVAL_CODE, pACCOUNT_ID, pPAYMENT_DATE, 
pCOLLECTED_BY,pSHIFT_CODE,pTERMINAL_ID,pRESTAURANT_ID,
pCOUPON_NO, pVALIDDATE, pCOUPONTYPE);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPaymentLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertPaymentLedger`(
pEMPLOYEE_ID	varchar(10),
pREFNO		varchar(30),
pDEBIT		decimal(12,2),
pCREDIT		decimal(12,2),
pMEMO		text,
pHOTELID	int(5),
pCREATEDBY	varchar(20)
)
BEGIN
insert into payment_ledger 
(
EMPLOYEE_ID,
DATE,
ref_no,
debit,
credit,
memo,
HOTELID,
CREATETIME,
CREATEDBY,
UPDATETIME,
UPDATEDBY,
posttoacctng,
closed
)
values
(
pEMPLOYEE_ID,
curdate(),
pREFNO,
pDEBIT,
pCREDIT,
pMEMO,
pHOTELID,
now(),
pCREATEDBY,
now(),
pCREATEDBY,
'0',
'0'
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPrivilegeDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertPrivilegeDetails`(
pPrivilegeID        varchar(20), 
pTransactionCode  varchar(20),   
pBasis            varchar(1),        
pPercentOff       decimal(2,2),   
pAmountOff        decimal(12,2),   
pHotelID          int(5),        
pCreatedBy        varchar(20)          
)
BEGIN
insert into `privilegedetails` 
(PrivilegeID, TransactionCode, Basis, PercentOff, 
AmountOff, HotelID,stateFlag, CreateTime, CreatedBy, 
Updatedby, UpdateTime)
values
(pPrivilegeID, pTransactionCode, pBasis, pPercentOff, 
pAmountOff, pHotelID,'ACTIVE', now(), pCreatedBy, 
pCreatedBy, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPrivilegeHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertPrivilegeHeader`(
pPrivilegeID    varchar(20),        
pDescription  varchar(100),          
pFromDate     datetime,           
pToDate       datetime,            
pDaysApplied  varchar(50),           
pHotelID      int(5),          
pCreatedBy    varchar(50)        
)
BEGIN
insert into `privilegeheader` 
(PrivilegeID, Description, FromDate, ToDate, 
DaysApplied, stateFlag, HotelID, CreatedBy, 
CreateTime, UpdatedBy, updateTime)
values
(pPrivilegeID, pDescription,pFromDate, pToDate, 
pDaysApplied, 'ACTIVE', pHotelID, pCreatedBy, 
now(), pCreatedBy, now());	
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertPromo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertPromo`(in ppromocode int,in ppromoname varchar(20),in ppercentoff int,in pstartdate date,in penddate date, in pbreakfastflag bool)
BEGIN
insert into promos(promocode,promoname,percentoff,startdate,enddate,breakfastflag)
values(ppromocode,ppromoname,ppercentoff,pstartdate,penddate,pbreakfastflag);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRateCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRateCode`(
in pratecode varchar(20), 
in pdescription varchar(30),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into ratecodes
values(
pratecode, 
pdescription,
'ACTIVE',
photelid,
now(),
pcreatedby,
now(),
pcreatedby
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRateType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRateType`(
in proomtypecode varchar(50),
in pratecode varchar(50),
in prateamount double(13,2),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into ratetypes
values(
proomtypecode,
pratecode,
prateamount,
photelid,
now(),
pcreatedby,
now(),
pcreatedby,
'ACTIVE');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRestaurant` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRestaurant`(
pRestaurantId  varchar(10), 
pDescription   varchar(100), 
pAreaCode      varchar(10), 
pTelephoneNo   varchar(30), 
pAddress       text, 
pCreatedBy     varchar(30)
)
BEGIN
insert into `restaurants` 
values
(pRestaurantId, pDescription, pAreaCode, pTelephoneNo, 
pAddress, 'ACTIVE', pCreatedBy, now(), 
pCreatedBy, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRestaurantLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRestaurantLedger`(
pMemo varchar(50),
pDate date,
pRefNo varchar(20),
pDebit double(12,2),
pCredit double(12,2),
pHOTELID int(5),
pCREATEDBY varchar(30),
pposttoacctng varchar(2),
pclosed varchar(2),
pRESTAURANT_ID varchar(10)
)
BEGIN
insert into `hotelmgtsystem`.`restaurantledger` 
(`Memo`, `Date`, `refno`, `debit`, `credit`, 
`HOTELID`, 
`CREATETIME`, 
`CREATEDBY`, 
`UPDATETIME`, 
`UPDATEDBY`, 
`posttoacctng`, 
`closed`, 
`RESTAURANT_ID`
)
values
(pMemo, pDate, prefno, pdebit, pcredit, pHOTELID,now(), 
pCREATEDBY, 
now(), 
pCREATEDBY, 
pposttoacctng, 
pclosed, 
pRESTAURANT_ID
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRole` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRole`(
pROLE_ID       varchar(100), 
pDESCRIPTION   varchar(150), 
PCREATEDBY     varchar(30)
)
BEGIN
insert into `roles`
values
(pROLE_ID, pDESCRIPTION, 'ACTIVE', PCREATEDBY, 
NOW(), PCREATEDBY, NOW());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoleMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRoleMenu`(
pRoleName   varchar(30),       
pMenu        varchar(50),         
pEnable      tinyint(1),
pCreatedBy   varchar(30) 
)
BEGIN
insert into `rolemenu` 
(RoleName, Menu, `Enable`, stateFlag, CreatedBy, CreateTime, UpdatedBy, 
UpdateTime)
values
(pRoleName, pMenu, pEnable, 'ACTIVE',pCreatedBy,now(),pCreatedBy,now())
on duplicate key update 
`Enable` = pEnable, 
updatedby = pCreatedby, 		
updateTime = now();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoleUIPrivilege` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRoleUIPrivilege`(
in pRoleName     varchar(100),
in pModule       varchar(100),
in pFormName     varchar(100),
in pButtonName   varchar(100),
in pIsVisible    tinyint(1),
in pCreatedBy    varchar(50)
)
BEGIN
insert into `role_ui_privileges` 
(roleName, module, formName, buttonName, 
isVisible, statusFlag, createdDate, createdBy, 
updatedDate, updatedBy)
values
(pRoleName, pModule, pFormName, pButtonName, 
pIsVisible, 'ACTIVE', now(), pCreatedBy, 
now(), pCreatedBy)
on duplicate key update 
isVisible = pIsVisible, 
updatedby = pCreatedby, 		
updatedDate = now();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRole_DB_Privileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRole_DB_Privileges`(
pROLE_ID        varchar(100), 
pDBPRIVILEGES   set('Select','Insert','Update','Delete','Create','Drop',
'Reload','Shutdown','Process','File','Index','References','Alter','Show_db',
'Super','Create_tmp_table','Lock_tables','Execute','Repl_slave','Repl_client',
'Create_view','Show_view','Create_routine','Alter_routine','Create_user'), 
pCREATEDBY      varchar(30) 
)
BEGIN
insert into `role_db_privileges` 
values
(pROLE_ID, pDBPRIVILEGES, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now()
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRole_Menu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRole_Menu`(
pROLE_ID      varchar(100), 
pMENU_NAME    varchar(100), 
pVISIBLE      enum('N','Y'), 
pENABLE       enum('N','Y'),
pCREATEDBY    varchar(30)
)
BEGIN
insert into `role_menus` 
values
(pROLE_ID, pMENU_NAME, pVISIBLE, pENABLE, 
'ACTIVE', pCREATEDBY, now(), pCREATEDBY, 
now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRole_Table_privileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRole_Table_privileges`(
pROLE_ID            varchar(100), 
pTABLE_NAME         varchar(100), 
pTABLEPRIVILEGES    set('Select','Insert','Update','Delete','Create','Drop','Grant','References','Index','Alter','Create View','Show view'), 
pCOLUMNPRIVILEGES   set('Select','Insert','Update','References'),
pCREATEDBY          varchar(30)
)
BEGIN
insert into `role_table_privileges`
values
(pROLE_ID, pTABLE_NAME, pTABLEPRIVILEGES, 
pCOLUMNPRIVILEGES, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoom` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRoom`(
in proomid varchar(10),
in photelid int(5),
in proomtypecode varchar(20),
in pfloor tinyint(5),
in pwindows int(1),
in pdirfacing varchar(10),
in padjleft varchar(10),
in padjright varchar(10),
in proomimage varchar(80),
in psmokingtype tinyint(1),
in ptelephoneno varchar(15),
in pcreatedby varchar(20)
)
BEGIN
insert into rooms
values(
proomid,
photelid,
proomtypecode,
pfloor,
pwindows,
pdirfacing,
padjleft,
padjright,
proomimage,
'VACANT',
'CLEAN',
psmokingtype,
'0',
'0',
ptelephoneno,
now(),
pcreatedby,
now(),
pcreatedby
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoomAmenity` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRoomAmenity`(
in proomid int,in pamenityid int
)
BEGIN
insert into roomamenities(roomid,amenityid)
values (proomid,pamenityid);
update amenities set amenities.stateflag = 'ASSIGNED'
where amenities.amenityid = pamenityid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoomBlock` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRoomBlock`(
in pBlockid int(11),
in pReason text,
in pHotelID int(11)
)
BEGIN
Insert into RoomBlock(blockid,reason,HotelID)
values(pBlockID,pReason,pHotelID);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoomEvents` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRoomEvents`(
pEventID     varchar(20),        
pRoomID      varchar(10),       
pEVENTDATE   datetime,      
pEventType   varchar(25),       
pRoomRate    decimal(12,2),       
pCREATEDBY   varchar(20),      
pHOTELID  int(5)
)
BEGIN
insert into roomevents
(
EventID,
RoomID,
EVENTDATE,
EventType,
RoomRate,
CREATETIME,
CREATEDBY,
UPDATETIME,
Updatedby,
HOTELID)  
values(
pEventID ,
pRoomID  ,
pEVENTDATE,
pEventType ,
pRoomRate   ,
now(),
pCREATEDBY   ,
now(),
pCREATEDBY   ,
pHOTELID  
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoomSchedule` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRoomSchedule`(
in pScheduleNo varchar(12),
in pRoomID varchar(12),
in pDate date,
in pEvent int(5),
in pEventType varchar(20)
)
BEGIN
insert into RoomSchedule(scheduleno,roomid,`date`,eventID,eventType)
values(pScheduleNO,pRoomnID,pDate,pEvent,pEventType);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoomType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRoomType`(
in proomtypecode varchar(20),
in pmaxoccupants int,
in pnoofbeds int,
in pnoofadult int,
in pnoofchild int ,
in psharetype varchar(15),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into roomtypes
values(	
proomtypecode,
pmaxoccupants,
pnoofbeds,
pnoofadult,
pnoofchild, 
psharetype,
'ACTIVE',
photelid,
now(),
pcreatedby,
now(),
pcreatedby);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRoute` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRoute`(
pROUTEID      varchar(10),      
pDESCRIPTION  varchar(100),       
pTOTAL_TIME   varchar(20),        
pDEFAULT      tinyint(4),        
pCREATEDBY    varchar(30)  
)
BEGIN
insert into `route header` 
(ROUTE_ID, DESCRIPTION, TOTAL_TIME, `DEFAULT`,`STATUS`,
CREATEDBY, CREATETIME, UPDATEDBY, UPDATETIME
)
values
(pROUTEID, pDESCRIPTION, pTOTAL_TIME, pDEFAULT,'ACTIVE', 
pCREATEDBY, now(), pCREATEDBY, now()
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertRouteDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertRouteDetail`(
pROUTE_ID       varchar(10),      
pSEQ_NO         int(11),         
pOPERATION   varchar(10),      
pTIME_DURATION  datetime      
)
BEGIN
insert into `route detail` 
(ROUTE_ID, SEQ_NO, OPERATION, TIME_DURATION
)
values
(pROUTE_ID, pSEQ_NO, pOPERATION, pTIME_DURATION
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSchedule` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertSchedule`(
in pScheduleNo varchar(12),
in pRoomNo varchar(12),
in pType varchar(15),
in pFrom date,
in pTo date,
in pDays int(3),
in pPromo int(3),
in pAmount double(10,2)
)
BEGIN
insert into Schedule(Scheduleno,Roomno,`Type`,`Fro`,`To`,Days,pDiscount,Amount)
values(pScheduleNo,RoomNo,pType,pFrom,pTo,pDays,pPromo,pAmount);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertStudentAccount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spInsertStudentAccount`(pStudID varchar(10), credit 
decimal(12,2))
BEGIN
update 
student_studcharge_account
set 
total_credit=total_credit+credit,
balance=credit_limit-total_credit
where stud_id=pStudID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertSystemMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertSystemMenu`(
pMENU_NAME    varchar(50), 
pDESCRIPTION  text, 
pCREATEDBY    varchar(30)
)
BEGIN
insert into systemmenus
values
(pMENU_NAME, 
pDESCRIPTION, 
'ACTIVE', 
pCREATEDBY, 
now(), pCREATEDBY, 
now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertTableAssignment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertTableAssignment`(
pTableNo varchar(10),
pRoomId varchar(30),
pFolioId varchar(20),
pName varchar(100),
pStatus varchar(20),
pOrder_id int(10),
pTerminalID varchar(5)
)
BEGIN
insert into `table_assignment` 
(TABLE_NO, ROOM_ID, FOLIO_ID, NAME, `STATUS`,ORDER_ID, TERMINAL_ID
)
values(pTableNo, pRoomId, pFolioId, pName, pStatus,pOrder_id, pTerminalId);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertTradingArea` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertTradingArea`(
pArea_Code  varchar(10), 
pDescription     varchar(100),
pCreatedBy varchar(30)
)
BEGIN
insert into tradingareas
values
(pArea_Code, pDescription, 'ACTIVE', pCreatedBy, 
now(), pCreatedBy, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertTransactionCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertTransactionCode`(
in ptrancode varchar(20),
in ptrantypeid varchar(20),
in pacctgroupid int(5),
in pmemo varchar(100),
in pacctside varchar(10),
in paccountno varchar(10),
in pservicecharge double(12,2),
in pgovttax double(12,2),
in plocaltax double(12,2),
in pdefaultamount double(12,2),
in pwarningamount double(12,2),
in pDepartmentId varchar(20),
in psystem varchar(20),
in pbaseamount double(9,2),
in pledger varchar(20),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into transactioncode
values
(
ptrancode,
ptrantypeid,
pacctgroupid,
pmemo,
pacctside,
paccountno,
pservicecharge,
pgovttax,
plocaltax,
pdefaultamount,
pwarningamount,
pDepartmentId,
psystem,
pbaseamount,
pledger,
photelid,
now(),
pcreatedby,
now(),
pcreatedby,
'ACTIVE'
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertTranType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertTranType`(
in ptrantypeid varchar(20),
in ptrantype varchar(50),
in pacctgroup varchar(20),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into trantypes
values
(
ptrantypeid,
ptrantype,
pacctgroup,
photelid,
now(),
pcreatedby,
now(),
pcreatedby,
'ACTIVE'
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertUser` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertUser`(
puserId        varchar(30), 
pLastName      varchar(50), 
pFirstName     varchar(50), 
pMiddleName    varchar(50), 
pDepartment    varchar(50), 
pDesignation   varchar(30), 
pPassword text,
pCreatedby     varchar(30)
)
BEGIN
insert into `users` 
values
(puserId, 
pLastName, 
pFirstName, 
pMiddleName, 
pDepartment, 
pDesignation, 
md5(pPassword), 
'ACTIVE', 
pCreatedby, 
now(), 
pCreatedby, 
now()
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertUserRole` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertUserRole`(
in pUserId varchar(20),
in pRoleName varchar(30),
in pHotelId int(5),
in pCreatedBy varchar(20)
)
BEGIN
insert into userroles
values
(
pUserId,
pRoleName,
pHotelId,
pCreatedBy,
now(),
pcreatedBy,
now(),
'ACTIVE'
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spInsertUser_Roles` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spInsertUser_Roles`(
pUSER_ID      varchar(30), 
pROLE_ID      varchar(50), 
pCREATEDBY    varchar(30) 
)
BEGIN
insert into `user_roles`
values
(pUSER_ID, pROLE_ID, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now());
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostAP` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostAP`(
in pAcctID varchar(20), 
in prefno varchar(20), 
in pdebit varchar(20), 
in pcredit varchar(20), 
in preffolio varchar(20), 
in psubfolio varchar(50),
in pHOTELID int(5), 
in pUPDATEDBY varchar(20)
)
BEGIN
insert into apLedger values	
(
pAcctID,
curdate(),
prefno,
pdebit,
pcredit, 
preffolio, 
psubfolio,
pHOTELID,
now(),  
pUPDATEDBY,
now(),
pUPDATEDBY,
0
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostAR` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostAR`(
in pAcctID varchar(20), 
in prefno varchar(20), 
in pdebit varchar(20), 
in pcredit varchar(20), 
in preffolio varchar(20), 
in psubfolio varchar(50),
in pHOTELID int(5), 
in pUPDATEDBY varchar(20)
)
BEGIN
insert into arLedger values	
(
pAcctID,
curdate(),
prefno,
pdebit,
pcredit, 
preffolio, 
psubfolio,
pHOTELID,
now(),  
pUPDATEDBY,
now(),
pUPDATEDBY,
0
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostCallCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostCallCharge`(
in pfolioid int(6),
in ptransactioncode varchar(7),
in pmemo varchar(20),
in pbaseamount decimal(9,2),
in pupdatetime varchar(15),
in pupdatedby VARCHAR(20),
in pterminalid int(4)
)
BEGIN
insert into foliotransactions
(
folioid,
trandate,
transactioncode,
memo,
acctside,
currencycode,
currencyamount,
conversionrate,
baseamount,
updatetime,
updatedby,	
terminalid
)
values(
pfolioid,
now(),
ptransactioncode,
pmemo,
'DEBIT',
'Php',
pbaseamount,
'1.0',
pbaseamount,
pupdatetime,
pupdatedby,
pterminalid
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostCallToTransactions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostCallToTransactions`(in pfolioid int(4),
in ptrandate datetime,
in preferenceno varchar(10),
in ptransactioncode varchar(7),
in pmemo varchar(20),
in pacctside varchar(10),
in pbaseamount decimal(9,2),
in pupdatetime varchar(15),
in pupdatedby VARCHAR(20),
in pterminalid int(4))
BEGIN
insert into
foliotransactions 
(folioid,
trandate,
referenceno,
transactioncode,
memo,
acctside,
baseamount,
updatetime,
updatedbyl,
terminalid )
values
(pfolioid,
ptrandate,
preferenceno,
ptransactioncode,
pmemo,
pacctside,
pbaseamount,
pupdatetime,
pupdatedbyl,
pterminalid );
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostCityLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostCityLedger`(
in pAcctID varchar(20), 
in prefno varchar(20), 
in pdebit varchar(20), 
in pcredit varchar(20), 
in preffolio varchar(20), 
in psubfolio varchar(50),
in pHOTELID int(5), 
in pCREATEDBY varchar(20)
)
BEGIN
insert into cityledger values	
(
pAcctID,
curdate(),
prefno,
pdebit,
pcredit, 
preffolio, 
psubfolio,
pHOTELID,
now(),  
pCREATEDBY, 
now(),
pCreatedBy, 
'0'
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostComledger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostComledger`(
in pAcctID varchar(20), 
in prefno varchar(20), 
in pdebit varchar(20), 
in pcredit varchar(20), 
in preffolio varchar(20), 
in psubfolio varchar(50),
in pHOTELID int(5), 
in pCREATEDBY varchar(20)
)
BEGIN
insert into comledger values	
(
pAcctID,
curdate(),
prefno,
pdebit,
pcredit, 
preffolio, 
psubfolio,
pHOTELID,
now(),  
pCREATEDBY, 
now(),
pCREATEDBY, 
0
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostCreditCardLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostCreditCardLedger`(
in pAcctID varchar(20), 
in prefno varchar(20), 
in pdebit decimal(12,2), 
in pcredit decimal(12,2),  
in preffolio varchar(20), 
in psubfolio varchar(50),
in pHOTELID int(5), 
in pCREATEDBY varchar(20)
)
BEGIN
insert into creditcardledger values	
(
pAcctID,
curdate(),
prefno,
pdebit,
pcredit, 
preffolio, 
psubfolio,
pHOTELID,
now(),  
pCREATEDBY, 
now(),
pCREATEDBY, 
0
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostCS` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostCS`(
paccountid varchar(20),
prefno varchar(20),
pdebit decimal(9,2),
pCredit decimal(9,2),	
pdiscount decimal(9,2),
pcashCredit decimal(9,2),
pcashdebit decimal(9,2),
prefFolio varchar(20),
pSubFolio varchar(20),
photelID varchar(5),
pCreatedby varchar(20)
)
BEGIN
insert into csledger(AcctID, `date`, refNo, debit, credit, discount, 
cashcredit, cashdebit, refFolio, subfolio, 
HOTELID, CREATETIME, CREATEDBY, UPDATETIME, 
UPDATEDBY, posttoacctng)
values
(paccountid,curdate(),prefno,pdebit,pcredit,pdiscount,pcashcredit,pcashdebit,preffolio,psubfolio,photelid,now(),pcreatedby,now(),pCreatedby,0);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostDepledger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostDepledger`(
in pAcctID varchar(20), 
in prefno varchar(20), 
in pdebit varchar(20), 
in pcredit varchar(20), 
in preffolio varchar(20), 
in psubfolio varchar(50),
in pHOTELID int(5), 
in pCREATEDBY varchar(20),
in pUPDATEDBY varchar(20)
)
BEGIN
insert into cityledger values	
(
pAcctID,
curdate(),
prefno,
pdebit,
pcredit, 
preffolio, 
psubfolio,
pHOTELID,
now(),  
pCREATEDBY, 
now(),
pUPDATEDBY, 
0
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostRoomCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostRoomCharge`(
in ptrandate varchar(20),
in proomid varchar(10),
in preferenceno varchar(20),
in pamount double(13,2),
in ptrancode varchar(5)
)
BEGIN
insert into transactions(trandate,roomid,referenceno,amount,trancode)
values(ptrandate,proomid,preferenceno,pamount,ptrancode);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostSalesLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostSalesLedger`(
in pAcctID varchar(20), 
in prefno varchar(20), 
in pdebit varchar(20), 
in pcredit varchar(20), 
in pnetSales decimal(12,2),
in preffolio varchar(20), 
in psubfolio varchar(50),
in pHOTELID int(5), 
in pUPDATEDBY varchar(20)
)
BEGIN
insert into SalesLedger values	
(
pAcctID,
curdate(),
prefno,
pdebit,
pcredit, 
pnetsales,
preffolio, 
psubfolio,
pHOTELID,
now(),  
pUPDATEDBY,
now(),
pUPDATEDBY,
0
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPostsrvchrgledger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPostsrvchrgledger`(
in pDepartmentId varchar(20), 
in prefno varchar(20), 
in pdebit Decimal(12,2), 
in pcredit decimal(12,2), 
in preffolio varchar(20), 
in psubfolio varchar(50),
in pHOTELID int(5), 
in pCREATEDBY varchar(20)
)
BEGIN
insert into Srvchrgledger values	
(
pDepartmentId,
curdate(),
prefno,
pdebit,
pcredit, 
preffolio, 
psubfolio,
pHOTELID,
now(),  
pCREATEDBY,
now(),
pCREATEDBY, 
0
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPrintCustomerReceipt` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPrintCustomerReceipt`(
pOrderId varchar(10), pRestoID int(5)
)
BEGIN
select 
OrderHeader.Customer_ID,
if(OrderHeader.status='CANCELLED', concat(lpad(OrderDetail.order_id, 10, '0'), ' [VOID]'), lpad(OrderDetail.order_id, 10, '0')) as order_id, 
OrderDetail.ITEM_ID, 
OrderDetail.DESCRIPTION, 
OrderDetail.UNIT_PRICE, 
sum(OrderDetail.QUANTITY) as Quantity, 
sum(OrderDetail.DISCOUNT) as DISCOUNT, 
sum(OrderDetail.VAT) as VAT, 
sum(OrderDetail.LOCAL_TAX) as LOCAL_TAX, 
sum(OrderDetail.AMOUNT) as VatSales, 
(sum(OrderDetail.quantity) * OrderDetail.unit_price - sum(OrderDetail.discount)) as Amount,
sum(OrderDetail.SERVICE_CHARGE) as SERVICE_CHARGE,
fGetPaymentsPerOrder(pOrderId) as Payments,
fGetCustomerNamePerOrder(OrderHeader.Customer_ID,OrderHeader.EMPLOYEE_ID) as CustomerName,
OrderHeader.table_no,
OrderHeader.order_date
from `order detail` OrderDetail
left join `order header` OrderHeader on
OrderHeader.order_id = OrderDetail.order_id
where
OrderDetail.ORDER_ID = pOrderId and
OrderDetail.OPERATION_STATUS <> 'CANCELLED'
GROUP BY
OrderDetail.item_id,
OrderDetail.unit_price,
OrderDetail.DISCOUNT;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPrintCustomerReceipt1` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPrintCustomerReceipt1`(
pOrderId varchar(10), pRestoID int(5)
)
BEGIN
select 
OrderHeader.Customer_ID,
if(OrderHeader.status='CANCELLED', concat(OrderDetail.order_id, ' [VOID]'), OrderDetail.ORDER_ID) as order_id, 
OrderDetail.ITEM_ID, 
OrderDetail.DESCRIPTION, 
OrderDetail.UNIT_PRICE, 
sum(OrderDetail.QUANTITY) as Quantity, 
OrderHeader.Total_Discount as DISCOUNT, 
sum(OrderDetail.VAT) as VAT, 
sum(OrderDetail.LOCAL_TAX) as LOCAL_TAX, 
sum(OrderDetail.AMOUNT) as VatSales, 
(sum(OrderDetail.quantity) * OrderDetail.unit_price) as Amount,
sum(OrderDetail.SERVICE_CHARGE) as SERVICE_CHARGE,
fGetPaymentsPerOrder(pOrderId) as Payments,
fGetCustomerNamePerOrder(OrderHeader.Customer_ID,OrderHeader.EMPLOYEE_ID) as CustomerName,
OrderHeader.table_no,
OrderHeader.order_date
from `order detail` OrderDetail
left join `order header` OrderHeader on
OrderHeader.order_id = OrderDetail.order_id
where
OrderDetail.ORDER_ID = pOrderId and
OrderDetail.OPERATION_STATUS <> 'CANCELLED'
GROUP BY
OrderDetail.item_id,
OrderDetail.unit_price,
OrderDetail.DISCOUNT;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPrintEmployeeReceipt` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spPrintEmployeeReceipt`(pRefNo varchar(20))
BEGIN
select concat(lastname,', ', firstname) as name, credit, memo, ref_no, charge as balance, (charge + credit) as charges
from employee, payment_ledger, `employee account`
where ref_no=pRefNo and employee.employee_id=payment_ledger.employee_id
and `employee account`.employee_id=employee.employee_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spPrintReceipt` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spPrintReceipt`(
pOrderId varchar(10), pRestoID int(5)
)
BEGIN
select distinct
lpad(`order header`.ORDER_ID, 10, '0') as OrderNo,
if(fGetCashPayment(pOrderId)>0,fGetCashPayment(pOrderId),0.00) as CASH_PAYMENT,
if(fGetCreditPayment(pOrderId)>0,fGetCreditPayment(pOrderId),0.00) as CREDIT_PAYMENT,
IF(fGetAccountCharge(pOrderId)>0,fGetAccountCharge(pOrderId),"") as ACCOUNT_CHARGE,
(total_payment-total_amount) as CASH_CHANGE,
if(payment.payment_type='COMPLIMENTARY' or payment.payment_type='COUPON'
or payment.payment_type="XDEAL",payment.payment_type,'') as complimentary,
if(payment.payment_type='COUPON',payment.coupon_type,'') as coupon_type,
if(payment.COUPON_TYPE = 'COMPLIMENTARY','', payment.COUPON_NO) as COUPON_NO,	
payment.APPROVAL_CODE,
`order header`.order_date,
time(assigned_time) as time_ordered,
if (substring(`order detail`.item_id,1,1)='F' or 
substring(`order detail`.item_id,1,8)='BANQUET' or
`order detail`.item_id='SENIOR',
`function mapping`.description,
item.description) as item_desc,
if(`order detail`.item_id = 'F1' or
`order detail`.item_id = 'F2' or
`order detail`.item_id = 'F3' or
`order detail`.item_id = 'F8' or
`order detail`.item_id = 'F9', 0,`order detail`.quantity) as qty,
`order detail`.unit_price,
`order detail`.discount,
(`order detail`.quantity * `order detail`.unit_price - `order detail`.discount) as amount,
`order detail`.vat, 
`order detail`.service_charge,
`order header`.table_no,
`order header`.total_amount,
`order header`.vat_sales,
`order header`.vat_amount,
`order header`.local_tax,
if(lcase(`order header`.customer_id='walk-in customer'),'Walk-in Customer',getguestnamefromhotel(`order header`.customer_id)) as customer_id,
if(`order header`.employee_id="", "", fGetEmployeeName(`order header`.employee_id)) as employee_id,
if(lcase(`order header`.customer_id!='walk-in customer') or `order header`.customer_id!="" or `order header`.customer_id!=null, getguestroomfromhotel(`order header`.customer_id),"N/A") as roomid,
`order header`.table_no,
`order header`.order_date
from
`order header` left join payment on(payment.order_id=`order header`.order_id)
left join `order detail` on `order detail`.order_id=`order header`.order_id and `order detail`.`operation_status` <> 'CANCELLED'
left join item on (`order detail`.item_id=item.item_id)
left join `function mapping` on (`order detail`.item_id=`function mapping`.function_id)
where
`order header`.ORDER_ID=pOrderId 
and `order header`.`status` <> 'CANCELLED' 
and (item.resto_id=pRestoID or `function mapping`.resto_id=pRestoID)
order by 
`order detail`.line_no;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spProductMixMonthly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spProductMixMonthly`(
pMonth int(2)
)
BEGIN
select concat('Report for ', MonthName(ORDER_DATE)) as Coverage, 
`order detail`.ITEM_ID, DESCRIPTION, count(distinct CUSTOMER_ID) as TotalCust ,
sum(QUANTITY) as UnitsSold,GetTotalLineItemsMonthly(pMonth) as AllQty,
((sum(QUANTITY)/GetTotalLineItemsMonthly(pMonth)) * 100) as Percentage 
from `order detail` ,item,`order header`
where 
`item`.ITEM_ID=`order detail`.ITEM_ID and
`order header`.`status`!='CANCELLED' and
`order header`.ORDER_ID=`order detail`.ORDER_ID and 
Month(ORDER_DATE)=pMonth
group by `order detail`.ITEM_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spProductMixWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spProductMixWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage, 
`order detail`.ITEM_ID, DESCRIPTION, count(distinct CUSTOMER_ID) as TotalCust ,sum(QUANTITY) as UnitsSold,
GetTotalLineItemsWeekly(pStartDate) as AllQty,((sum(QUANTITY)/1000) * 100) as Percentage
from `order detail` ,item,`order header`
where 
`ITEM`.ITEM_ID=`order detail`.ITEM_ID and
`order header`.ORDER_ID=`order detail`.ORDER_ID and 
`order header`.`status`!='CANCELLED' and
ORDER_DATE between date(pStartDate) and adddate(pStartDate, interval 7 DAY) 
group by `order detail`.ITEM_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spRecallFolioTransaction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spRecallFolioTransaction`(
in photelid int(5),
in pfolioid varchar(20),
in psubfolio varchar(1),
in paccountid varchar(20),
in ptrandate datetime,
in ptrancode varchar(20),
in pupdatedby varchar(20)
)
BEGIN
update foliotransactions
set 
`status` = 'ACTIVE',
updatedby = pupdatedby,
updatetime = now()
where
hotelid = photelid and
folioid = pfolioid and
subfolio = psubfolio and
accountid = paccountid and
transactiondate = ptrandate and
transactioncode = ptrancode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spRemoveFolioTransactionForTransfer` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spRemoveFolioTransactionForTransfer`(
in pTransactionCode varchar(20),
in pTranDate 	    datetime,
in pFolioID          varchar(20),
in pSubFolio         varchar(1),
in pHotelID          int(5) 
)
BEGIN
delete from folioTransactions
where
transactioncode = pTransactionCode and
transactiondate = pTranDate and
folioid = pfolioid and
subfolio = pSubFolio and
hotelid = pHotelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spRemovePackage` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spRemovePackage`(in pFolioID varchar(20), IN photelid int(5))
BEGIN
Update folio set `packageid`="" where folioID=pFolioID and hotelid=photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spRemoveUserRole` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spRemoveUserRole`(
in pUserId      varchar(20),
in pHotelId     int(5),
in pRoleName    varchar(30),
in pUpdatedBy   varchar(30)
)
BEGIN
update userroles
set
stateflag = 'DELETED',
updatetime = now(),
updatedby = pUpdatedBy
where
userid = pUserId and
hotelid = pHotelId and
roleName = pRoleName;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportActualGuestDeparture` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportActualGuestDeparture`(in pHotelID int(5))
BEGIN
select 
folio.folioid,
guests.accountid,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folio.remarks,
folioschedules.days,
folioschedules.roomid, folioschedules.roomtype
from
guests,
folioschedules,
folio
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
date(folioschedules.todate) = curdate() and
folio.status = 'CHECKED OUT' and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportActualGuestsArrival` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportActualGuestsArrival`(
in photelid int(5)
)
BEGIN
select 
folio.folioid,
guests.accountid,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folioschedules.roomid, 
folioschedules.roomtype,
folio.remarks,
folioschedules.todate as departure
from
guests,
folioschedules,
folio
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
date(folioschedules.fromdate) = curdate() and
folio.status = 'CHECKED IN' and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportActualGuestsDeparture` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportActualGuestsDeparture`(
in photelid int(5)
)
BEGIN
select 
folio.folioid,
guests.accountid,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folioschedules.roomid, folioschedules.roomtype
from
guests,
folioschedules,
folio
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
date(folioschedules.todate) = curdate() and
folio.status = 'CHECKED OUT' and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportAllCashierTransactions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportAllCashierTransactions`(
in pterminalid int(4),
in prestaurantid int(5),
in pshiftcode int(5),
in pStartDate date,
in pEndDate date
)
BEGIN
select distinct
concat(cashiers_logs.terminalid) as Terminal,
cashiers_logs.cashierid,
cashiers_logs.shiftcode,
cashiers_logs.openingbalance,
cashiers_logs.openingadjustment,
cashiers_logs.beginningbalance,
cashiers_logs.chargeinamount,
cashiers_logs.cash,
cashiers_logs.creditcard,
cashiers_logs.cheque,	
cashiers_logs.others,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.remarks,
cashiers_logs.amountremitted,
payment.payment_date,
payment.order_id,
payment.payment_type,
payment.amount,
if(payment.payment_type='CASH','WALK-IN',payment.ACCOUNT_ID) as ACCOUNT
from 	
cashiers_logs,
payment,
`order header`
where
cashiers_logs.terminalid = payment.terminal_id and
`order header`.order_id=payment.order_id and
payment.terminal_id = pterminalid and date(`order header`.order_date) >= pStartDate and date(`order header`.order_date) <= pEndDate and
payment.restaurant_id = cashiers_logs.restaurantid and
payment.shift_code=pshiftcode and
cashiers_logs.restaurantid = prestaurantid and
cashiers_logs.shiftcode=pshiftcode and
cashiers_logs.type='CLOSE'
order by payment.payment_date;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportAllIndividualFolio` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportAllIndividualFolio`(
in photelid int(5)
)
BEGIN
select distinct
folio.folioid,
folio.foliotype,
folioschedules.roomid,
folioschedules.roomtype,
(folio.noofadults+folio.noofchild) as TotalGuests,
folioschedules.fromdate as ARRIVALDATE,
folioschedules.todate as DEPARTUREDATE,  
concat(guests.firstname," ",guests.lastname) as GuestName,
concat(guests.street,", ",guests.city) as CityAdd,
concat(guests.country, " ",guests.zip) as CountryAdd,
transactiondate,
referenceno,
transactioncode,
foliotransactions.netbaseamount,
foliotransactions.governmenttax,
foliotransactions.localtax,
foliotransactions.discount,
foliotransactions.memo,
foliotransactions.updatedby,
if(acctside='DEBIT',baseamount,0.00) as CHARGES,  
if(acctside='CREDIT',baseamount,0.00) as CREDIT
from
guests,
folio,
folioschedules,
foliotransactions
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
date(folioschedules.fromdate) <= curdate() and
foliotransactions.folioid = folio.folioid and
foliotransactions.status = 'ACTIVE' and
folio.hotelid = photelid 
order by foliotransactions.transactiondate
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportAnnualSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportAnnualSales`(pYear int, pRestoID varchar(5))
BEGIN
select
`order header`.order_id as OrderID,
if(`order header`.customer_id='WALK-IN CUSTOMER', 
`order header`.customer_id, 
if(`order header`.employee_id!='', 
fGetEmployeeName(`order header`.employee_id), 
fGetGuestName(`order header`.customer_id))) as CustomerName,
date(order_date) as OrderDate,
total_line_items as TotalItems,
total_amount+total_discount as GrossSales,
total_discount as Discount,
vat_sales as VatSales,
nonvat_sales as NonVatSales,
vat_amount as GovernmentTax,
local_tax as LocalTax,
service_charge as ServiceCharge,
fGetMonthToDateGrossSales(month(now()), pYear) as MonthToDateGrossSales,
fGetYearToDateGrossSales(pYear) as YearToDateGrossSales,
fGetTotalGrossSales() as TotalGrossSales,
fGetMonthToDateVATSales(month(now()), pYear) as MonthToDateVatSales,
fGetYearToDateVATSales(pYear) as YearToDateVatSales,
fGetTotalVATSales() as TotalVatSales,
fGetMonthToDateNonVATSales(month(now()), pYear) as MonthToDateNonVatSales,
fGetYearToDateNonVATSales(pYear) as YearToDateNonVatSales,
fGetTotalNonVATSales() as TotalNonVatSales,
(0) as MonthToDateGovtTax,
(0) as YearToDateGovtTax,
(0) as TotalGovtTax,
(0) as MonthToDateLocalTax,
(0) as YearToDateLocalTax,
(0) as TotalLocalTax,
(0) as MonthToDateServiceCharge,
(0) as YearToDateServiceCharge,
(0) as TotalServiceCharge
from `order header` where year(order_date)=pYear and `order header`.status!='CANCELLED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCancelledOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCancelledOrders`()
BEGIN
select `order header`.ORDER_ID,NAME,ORDER_DATE,TOTAL_LINE_ITEMS,TOTAL_AMOUNT
from 
`order header`,customers
where 
(`order header`.CUSTOMER_ID=customers.CUSTOMER_ID or `order header`.customer_id='WALK-IN CUSTOMER' or `order header`.customer_id='') and
`order header`.STATUS='CANCELLED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCancelledOrdersDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCancelledOrdersDaily`(
pDate date
)
BEGIN
select DISTINCT concat('Report for ' , pDate)as Coverage,`order header`.ORDER_ID,ORDER_DATE,TOTAL_LINE_ITEMS,TOTAL_AMOUNT
from 
`order header`,customers
where 
(`order header`.CUSTOMER_ID=customers.name or `order header`.customer_id='WALK-IN CUSTOMER' or `order header`.customer_id='') and
lcase(`order header`.STATUS)='CANCELLED' and date(ORDER_DATE)=pDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCancelledOrderSummary` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCancelledOrderSummary`()
BEGIN
select count(ORDER_ID) as TotalOrders,
if(sum(TOTAL_LINE_ITEMS)is null,0,sum(TOTAL_LINE_ITEMS)) as TotalItem,
if(sum(TOTAL_AMOUNT)is null,0,sum(TOTAL_AMOUNT)) as TotalAmount,
if(sum(TOTAL_PAYMENT)is null,0,sum(TOTAL_PAYMENT)) as TotalPayment 
from `order header` where `STATUS`='CANCELLED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCancelledOrderSummaryDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCancelledOrderSummaryDaily`(
pDate date
)
BEGIN
select concat('Report for ' , date_format(pDate,'%b-%d-%Y'))as Coverage,
count(ORDER_ID) as TotalOrders,
if(sum(TOTAL_LINE_ITEMS)is null,0,sum(TOTAL_LINE_ITEMS)) as TotalItem,
if(sum(TOTAL_AMOUNT)is null,0,sum(TOTAL_AMOUNT)) as TotalAmount,
if(sum(TOTAL_PAYMENT)is null,0,sum(TOTAL_PAYMENT)) as TotalPayment 
from `order header` 
where `STATUS`='CANCELLED'
and date(ORDER_DATE)=pDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCancelledOrderSummaryWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCancelledOrderSummaryWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage,count(ORDER_ID) as TotalOrders,if(sum(TOTAL_LINE_ITEMS)is null,0,sum(TOTAL_LINE_ITEMS)) as TotalItem,if(sum(TOTAL_AMOUNT)is null,0,sum(TOTAL_AMOUNT)) as TotalAmount,if(sum(TOTAL_PAYMENT)is null,0,sum(TOTAL_PAYMENT))  as TotalPayment from `order header` 
where `STATUS`='CANCELLED'
and 
ORDER_DATE between date(pStartDate) and adddate(pStartDate, interval 7 DAY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCancelledOrdersWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCancelledOrdersWeekly`(
pStartDate date
)
BEGIN
select distinct concat('Report from ',pStartDate,' to ',adddate(pStartDate, interval 7 DAY))as Coverage, `order header`.ORDER_ID,ORDER_DATE,TOTAL_LINE_ITEMS,TOTAL_AMOUNT
from 
`order header`,customers
where 
(`order header`.CUSTOMER_ID=customers.name or `order header`.customer_id='WALK-IN CUSTOMER' or `order header`.customer_id='') and
lcase(`order header`.STATUS)='CANCELLED' and 
ORDER_DATE between date(pStartDate) and adddate(pStartDate, interval 7 DAY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCashierChargesTransaction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCashierChargesTransaction`(
in pterminalid int(4),
in pHotelId int(5)
)
BEGIN
select 
concat(cashiers.terminalid,"-",cashiers.terminal) as Terminal,
cashiers.cashierid,
cashiers.shiftcode,
cashiers.openingbalance,
cashiers.openingadjustment,
cashiers.beginningbalance,
cashiers.chargeinamount,
cashiers.cash,
cashiers.creditcard,
cashiers.cheque,	
cashiers.others,
cashiers.adjustment,
cashiers.netamount,
foliotransactions.transactiondate,
foliotransactions.referenceno,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT
from 	cashiers,
foliotransactions,
transactioncode
where
foliotransactions.terminalid = cashiers.terminalid and
foliotransactions.transactioncode = transactioncode.trancode and
transactioncode.trantypeid = '1' and
date(foliotransactions.transactiondate) = curdate() and 
foliotransactions.terminalid = pterminalid and
foliotransactions.hotelid = cashiers.hotelid and
cashiers.hotelid = pHotelId
order by transactiondate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCashierPaymentTransaction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCashierPaymentTransaction`(
in pterminalid int(4),
in pHotelId int(5)
)
BEGIN
select 
concat(cashiers.terminalid,"-",cashiers.terminal) as Terminal,
cashiers.cashierid,
cashiers.shiftcode,
cashiers.openingbalance,
cashiers.openingadjustment,
cashiers.beginningbalance,
cashiers.chargeinamount,
cashiers.cash,
cashiers.creditcard,
cashiers.cheque,	
cashiers.others,
cashiers.adjustment,
cashiers.netamount,
foliotransactions.transactionDate,
foliotransactions.referenceno,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT
from 	cashiers,
foliotransactions,
transactioncode
where
foliotransactions.terminalid = cashiers.terminalid and
foliotransactions.transactioncode = transactioncode.trancode and
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 9) and
date(foliotransactions.transactionDate) = curdate() and 
cashiers.terminalid = pterminalid and
foliotransactions.hotelid = cashiers.hotelid and
cashiers.hotelid = pHotelid
order by transactiondate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCashierShiftTransactions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCashierShiftTransactions`(
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
cashiers_logs.chargeinamount,
cashiers_logs.cash,
cashiers_logs.creditcard,
cashiers_logs.cheque,	
cashiers_logs.others,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.remarks,
cashiers_logs.amountremitted,
cashiers_logs.createdby
from
cashiers_logs
where
cashiers_logs.terminalid = pterminalid and
cashiers_logs.restaurantid = prestaurantid and
cashiers_logs.shiftcode=pshiftcode and
cashiers_logs.type='CLOSE' and
cashiers_logs.transactiondate=pTransactionDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportComplimentaryOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportComplimentaryOrders`(
in pStartDate date, 
in pEndDate date)
BEGIN
SELECT 
`order header`.order_date, 
`order header`.order_id, 
if(`order header`.employee_id='',`hotelmgtsystem`.folioschedules.roomid,'') as roomid,
if(`order header`.employee_id='',
concat(`hotelmgtsystem`.guests.lastname, ', ', `hotelmgtsystem`.guests.firstname),
concat(employee.lastname,', ', employee.firstname)) as `Customer Name`,
if(`order header`.employee_id='',
`order header`.customer_id, `order header`.employee_id) as customer_id,
vat_sales, 
service_charge, 
local_tax,
vat_amount, 
total_amount
from `order header` left join employee on `order header`.employee_id=employee.employee_id
left join `hotelmgtsystem`.folio 
left join `hotelmgtsystem`.folioschedules on `hotelmgtsystem`.folio.folioid=`hotelmgtsystem`.folioschedules.folioid
on `order header`.customer_id=`hotelmgtsystem`.folio.folioid
left join `hotelmgtsystem`.guests on `hotelmgtsystem`.folio.accountid=`hotelmgtsystem`.guests.accountid,
payment
where `order header`.order_id=payment.order_id
and payment.status <> 'VOID'
and payment.payment_type = 'Complimentary'  
and (date(`order header`.ORDER_DATE) >= pStartDate 
and date(`order header`.ORDER_DATE) <= pEndDate);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCustomerComplaintProfile` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCustomerComplaintProfile`()
BEGIN
select complaints.ORDER_ID,ORDER_DATE,TOTAL_AMOUNT,complaints.CUSTOMER_ID,REMARKS 
from `order header`, complaints
where 
`order header`.CUSTOMER_ID=complaints.CUSTOMER_ID
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCustomerComplaintProfileDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCustomerComplaintProfileDaily`(
pDate datetime
)
BEGIN
select concat('Report for ' , date_format(pDate,'%b-%d-%Y'))as Coverage,'MC-DO' as StoreName,customers.NAME,`order header`.ORDER_ID,DESCRIPTION
from `order header`, complaints,customers,complaint_reasons
where 
`order header`.ORDER_ID=complaints.ORDER_ID and 
customers.CUSTOMER_ID=complaints.CUSTOMER_ID and
complaint_reasons.REASON_CODE=complaints.REASON_CODE and
`order header`.`STATUS`='RETURNED'and date(ORDER_DATE)=pDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportCustomerComplaintSummaryDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportCustomerComplaintSummaryDaily`(
pDate datetime
)
BEGIN
select concat('Report for ' , date_format(pDate,'%b-%d-%Y'))as Coverage, GetComplaintCount(pDate) as TotalComplaint,count(complaints.COMPLAINT_ID) as ComplaintTypeCount,DESCRIPTION 
from `order header`,complaints,complaint_reasons
where 
`order header`.ORDER_ID=complaints.ORDER_ID and
date(ORDER_DATE)=pDate and
complaint_reasons.REASON_CODE=complaints.REASON_CODE
group by complaints.REASON_CODE;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDailyHotelRevenue` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDailyHotelRevenue`(
in pHotelId int(4),
in pStartDate date,
in pEndDate date
)
BEGIN
(
select
foliotransactions.postingDate,
foliotransactions.transactionDate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource`,
foliotransactions.`FolioID`,
guests.accountid,
concat(guests.`lastname`,", " , guests.`firstname`) as GuestName,
foliotransactions.transactioncode,
foliotransactions.baseAmount,
foliotransactions.netBaseAmount,
foliotransactions.grossAmount,
foliotransactions.discount,
foliotransactions.serviceCharge,
foliotransactions.governmentTax,
foliotransactions.localTax,
foliotransactions.mealAmount,
foliotransactions.`Memo`,
foliotransactions.subFolio,
foliotransactions.netAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as Amount,
foliotransactions.`CREATEDBY`,
folioschedules.roomid,
folioschedules.roomtype,
company.companyName,
'' as REMARKS
from
foliotransactions
left join transactioncode on transactioncode.tranCode = foliotransactions.transactioncode
left join folioschedules on folioschedules.folioid = foliotransactions.folioid
left join folio on folioschedules.folioid = folio.folioid
left join company on folio.companyid = company.companyid
left join guests on guests.accountid = folio.accountid
where
date(foliotransactions.`TransactionDate`) >= pStartDate and 
date(foliotransactions.`TransactionDate`) <= pEndDate and
foliotransactions.status = 'ACTIVE' and
transactioncode.tranTypeID = 1
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
nonguesttransaction.baseAmount,
nonguesttransaction.netBaseAmount,
nonguesttransaction.grossAmount,
nonguesttransaction.discount,
nonguesttransaction.serviceCharge,
nonguesttransaction.governmentTax,
nonguesttransaction.localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
nonguesttransaction.netAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netbaseAmount,
(nonguesttransaction.netbaseAmount * -1) ) as DEBIT,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
"" as roomtype,
nonguesttransaction.companyName,
'' as REMARKS
from nonguesttransaction force index(primary)
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
where
date(nonguesttransaction.transactionDate) >= pStartDate and 
date(nonguesttransaction.`TransactionDate`) <= pEndDate and
nonguesttransaction.statusFlag = 'ACTIVE' and
nonguesttransaction.hotelID = pHotelId and
transactioncode.tranTypeID = 1
)
UNION
(
select
payment.payment_date,
payment.payment_date,
payment.order_id,
'POSCHECK#' as TransactionSource,
`order header`.customer_id,
`order header`.customer_id,
fGetCustomerNamePerOrder(`order header`.Customer_ID,
`order header`.EMPLOYEE_ID) as GuestName,
'1201' as transactioncode,
`order header`.total_payment as baseAmount,
`order header`.total_payment as netBaseAmount,
`order header`.total_payment as grossAmount,
0 as discount,
`order header`.service_charge as serviceCharge,
`order header`.vat_amount as governmentTax,
`order header`.local_Tax as localTax,
0 as mealAmount,
'RESTAURANT - DINE-IN' as `Memo`,
'DINE-IN' as subFolio,
`order header`.vat_sales as netAmount,
`order header`.total_payment as Amount,
`order header`.`CREATEDBY`,
'' as roomid,
'' as roomtype,
'' as companyName,
payment.payment_type as REMARKS
from
`payment`
left join `order header` on payment.order_id = `order header`.order_id
where
date(payment.payment_date) >= pStartDate and 
date(payment.payment_date) <= pEndDate and
payment.`status` != 'VOID' and
(payment.payment_type = 'CASH'
or payment.payment_type = 'Credit'
or payment.payment_type = 'ACCOUNT_EMPLOYEE')
)
order by transactionCode, transactionSource, ReferenceNo;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDailyKitchenOperation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDailyKitchenOperation`(
pStartDate date,
pEndDate date
)
BEGIN
select 
date(CREATETIME) as REPORT_DATE, 
ORDER_ID, 
ITEM_ID, 
QUANTITY, 
DESCRIPTION,
CREATEDBY, 
CREATETIME, UPDATEBY, UPDATETIME, 
SERVED, SERVED_BY, TIME_SERVED, 
OPERATION_STATUS, ITEM_NOTES, ACKNOWLEDGE, ACKNOWLEDGE_BY, 
TIME_ACKNOWLEDGED
from `order detail`
where
date(createTime) >= pStartDate and date(createTime) <= pEndDate
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDailySales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDailySales`(pDate date, pRestoID varchar(5))
BEGIN
select
`order header`.order_id as OrderID,
if(`order header`.customer_id='WALK-IN CUSTOMER', 
`order header`.customer_id, 
if(`order header`.employee_id!='', 
fGetEmployeeName(`order header`.employee_id), 
fGetGuestName(`order header`.customer_id))) as CustomerName,
date(order_date) as OrderDate,
total_line_items as TotalItems,
total_amount+total_discount as GrossSales,
total_discount as Discount,
vat_sales as VatSales,
nonvat_sales as NonVatSales,
vat_amount as GovernmentTax,
local_tax as LocalTax,
service_charge as ServiceCharge,
fGetMonthToDateGrossSales(month(pDate), year(pDate)) as MonthToDateGrossSales,
fGetYearToDateGrossSales(year(pDate)) as YearToDateGrossSales,
fGetTotalGrossSales() as TotalGrossSales,
fGetMonthToDateVATSales(month(pDate), year(pDate)) as MonthToDateVatSales,
fGetYearToDateVATSales(year(pDate)) as YearToDateVatSales,
fGetTotalVATSales() as TotalVatSales,
fGetMonthToDateNonVATSales(month(pDate), year(pDate)) as MonthToDateNonVatSales,
fGetYearToDateNonVATSales(year(pDate)) as YearToDateNonVatSales,
fGetTotalNonVATSales() as TotalNonVatSales,
(0) as MonthToDateGovtTax,
(0) as YearToDateGovtTax,
(0) as TotalGovtTax,
(0) as MonthToDateLocalTax,
(0) as YearToDateLocalTax,
(0) as TotalLocalTax,
(0) as MonthToDateServiceCharge,
(0) as YearToDateServiceCharge,
(0) as TotalServiceCharge
from `order header` where date(order_date)=pDate AND `order header`.status!='CANCELLED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDailyStaffPerformance` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDailyStaffPerformance`(
pStartDate date,
pEndDate date
)
BEGIN
select 
order_id,
Quantity,
Description,
concat(UPDATEBY,"-",
if(substring(SERVED_BY,2,length(UPDATEBY)) = UPDATEBY,"",SERVED_BY)) as "STAFF",
UPDATETIME,
TIME_SERVED,
OPERATION_STATUS,
Item_Notes,
date(UPDATETIME) as TRANS_DATE
from `order detail`
where
OPERATION_STATUS <> 'CANCELLED' and
date(UPDATETIME) >= pStartDate and date(UPDATETIME) <= pEndDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDailySummarizedSalesDiscount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDailySummarizedSalesDiscount`(pDate date)
BEGIN
select distinct group.maingroup_id, 
if(substring(`order detail`.item_id,1,1)<>'F', sum(`order detail`.unit_price),
0.00) as `cash sales`, 
sum(distinct nonvat_sales) as `total discount`,
sum(distinct `order header`.total_amount) as net 
from `order header` left join payment on (`order header`.order_id=payment.order_id),
`order detail`, item, `group`
where not(`order header`.`status`='CANCELLED')
and `order header`.order_id=payment.order_id
and `order header`.order_id=`order detail`.order_id
and `order detail`.item_id=item.item_id
and item.group_id=group.group_id
and date(`order header`.order_date)=pDate
and `order header`.balance<=0.00
and payment.status<>'VOID'
group by group.maingroup_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDailyTransactions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportDailyTransactions`(
in photelid int(5)
)
BEGIN
select 	
foliotransactions.*,
if(acctside='DEBIT',baseamount,0.00) as CHARGES,  
if(acctside='CREDIT',baseamount,0.00) as CREDIT
from foliotransactions
where
date(transactiondate) = curdate() and
foliotransactions.hotelid = photelid
order by transactiondate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDeliveredOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportDeliveredOrders`()
BEGIN
select `order header`.ORDER_ID,NAME,ORDER_DATE,TOTAL_LINE_ITEMS,TOTAL_AMOUNT
from 
`order header`,customers
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID and
lcase(`order header`.`STATUS`)='DELIVERED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDeliveredOrdersDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportDeliveredOrdersDaily`(
pDate datetime
)
BEGIN
select concat('Report for ' , date_format(pDate,'%b-%d-%Y'))as Coverage,`order header`.ORDER_ID,NAME,ORDER_DATE,TOTAL_LINE_ITEMS,TOTAL_AMOUNT
from 
`order header`,customers
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID and
lcase(`order header`.`STATUS`)='DELIVERED' and date(ORDER_DATE)=pDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDeliveredOrderSummary` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportDeliveredOrderSummary`(
pStartDate datetime
)
BEGIN
select count(ORDER_ID) as TotalOrders,if(sum(TOTAL_LINE_ITEMS)is null,0,sum(TOTAL_LINE_ITEMS)) as TotalItem,if(sum(TOTAL_AMOUNT)is null,0,sum(TOTAL_AMOUNT)) as TotalAmount,if(sum(TOTAL_PAYMENT)is null,0,sum(TOTAL_PAYMENT))  as TotalPayment from `order header` 
where lcase(`STATUS`)='DELIVERED'
and ORDER_DATE between date(pStartDate) and adddate(pStartDate, interval 7 DAY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDeliveredOrderSummaryDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportDeliveredOrderSummaryDaily`(
pDate datetime
)
BEGIN
select concat('Report for ' , date_format(pDate,'%b-%d-%Y'))as Coverage,count(ORDER_ID) as TotalOrders,if(sum(TOTAL_LINE_ITEMS)is null,0,sum(TOTAL_LINE_ITEMS)) as TotalItem,if(sum(TOTAL_AMOUNT)is null,0,sum(TOTAL_AMOUNT)) as TotalAmount,if(sum(TOTAL_PAYMENT)is null,0,sum(TOTAL_PAYMENT))  as TotalPayment 
from `order header`
where lcase(`STATUS`)='DELIVERED' and date(ORDER_DATE)=pDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDeliveredOrderSummaryWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportDeliveredOrderSummaryWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage,count(ORDER_ID) as TotalOrders,if(sum(TOTAL_LINE_ITEMS)is null,0,sum(TOTAL_LINE_ITEMS)) as TotalItem,if(sum(TOTAL_AMOUNT)is null,0,sum(TOTAL_AMOUNT)) as TotalAmount,if(sum(TOTAL_PAYMENT)is null,0,sum(TOTAL_PAYMENT))  as TotalPayment from `order header` 
where lcase(`STATUS`)='DELIVERED' and 
ORDER_DATE between date(pStartDate) and adddate(pStartDate, interval 7 DAY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDeliveredOrdersWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportDeliveredOrdersWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage,`order header`.ORDER_ID,NAME,ORDER_DATE,TOTAL_LINE_ITEMS,TOTAL_AMOUNT
from 
`order header`,customers
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID and
lcase(`order header`.`STATUS`)='DELIVERED' and 
ORDER_DATE between date(pStartDate) and adddate(pStartDate, interval 7 DAY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDependentFolios` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportDependentFolios`(
in pMasterFolio varchar(20),
in pHotelId int(5)
)
BEGIN
select distinct
(folio.folioid) as DepFolioId,
(folio.noofadults+folio.noofchild) as TotalGuests,
folio.foliotype,
folio.masterfolio,
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.fromdate as ARRIVALDATE,
folioschedules.todate as DEPARTUREDATE,  
concat(guests.firstname," ",guests.lastname) as GuestName,
concat(guests.street,", ",guests.city) as CityAdd,
concat(guests.country, " ",guests.zip) as CountryAdd,
transactiondate,
referenceno,
transactioncode,
foliotransactions.memo,
foliotransactions.netbaseamount,
foliotransactions.governmenttax,
foliotransactions.localtax,
foliotransactions.discount,
foliotransactions.updatedby,
if(acctside='DEBIT',baseamount,0.00) as CHARGES,  
if(acctside='CREDIT',baseamount,0.00) as CREDIT
from
guests,
folio,
folioschedules,
foliotransactions
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
date(folioschedules.fromdate) <= curdate() and
foliotransactions.folioid = folio.folioid and
folio.masterfolio = pMasterFolio and 	
foliotransactions.status = 'ACTIVE' and
folio.hotelid = pHotelId and
foliotransactions.subfolio = 'B'
order by foliotransactions.transactiondate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDetailedSalesPerOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDetailedSalesPerOrder`(
in pStartDate date,
in pEndDate date,
in pRestoID int(5)
)
BEGIN
select 
`order header`.ORDER_DATE, 
`order header`.ORDER_ID, 
if(`order header`.customer_id="", fGetEmployeeName(`order header`.employee_id),
if(`order header`.customer_id="WALK-IN CUSTOMER", "WALK-IN", getGuestNameFromHotel(`order header`.customer_id))) as CUSTOMER_ID, 
`order detail`.ITEM_ID, 
`order detail`.description,
`order detail`.UNIT_PRICE as UnitPrice, 
sum(`order detail`.QUANTITY) as QUANTITY,
sum(`order detail`.quantity * `order detail`.unit_price) as GrossAmount,
sum(`order detail`.discount) as Discount,
sum(`order detail`.vat + `order detail`.local_tax) as Vat,
sum(`order detail`.service_charge) as ServiceCharge,
sum(`order detail`.amount) as NetAmount,
`order detail`.createdby
from 
`order header`, 
`order detail`,
payment
where
`order header`.order_id = `order detail`.order_id and
`order header`.order_id=payment.order_id and
(`order header`.ORDER_DATE >= pStartDate and
`order header`.ORDER_DATE <= pEndDate)
and payment.status<>'VOID'
and `order detail`.operation_status!='CANCELLED'
group by `order detail`.item_id, `order detail`.order_id
order by `order header`.order_date;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDetailedVoidItems` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDetailedVoidItems`(in pStartDate date, in pEndDate date)
BEGIN
select distinct
`order header`.order_date, 
`order header`.order_id, 
table_no, 
vat_sales, 
`order header`.service_charge, 
vat_amount,
total_amount, 
`order header`.createdby,
`order detail`.quantity,
`order detail`.item_id,
`order detail`.description,
`order detail`.unit_price
from 
`order header`,
`order detail`
where `order detail`.operation_status='CANCELLED' and 
`order header`.order_id = `order detail`.order_id
and date(`order header`.order_date) between pStartDate and pEndDate
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDetailedVoidOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDetailedVoidOrders`(in pStartDate date, in pEndDate date)
BEGIN
select distinct
`order header`.order_date, 
`order header`.order_id, 
table_no, 
vat_sales, 
`order header`.service_charge, 
vat_amount,
total_amount, 
`order header`.createdby,
`order detail`.quantity,
`order detail`.item_id,
`order detail`.description,
`order detail`.unit_price
from 
`order header`,
`order detail`
where `order header`.status='CANCELLED' and 
`order header`.order_id = `order detail`.order_id
and date(`order header`.order_date) between pStartDate and pEndDate
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportDetailed_Sales_Per_Item` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportDetailed_Sales_Per_Item`(
in pMainGroup varchar(30),
in pGroup varchar(50),
in pStartDate date,
in pEndDate date,
in pRestoID int(5)
)
BEGIN
select 
`order header`.ORDER_DATE, 
`order header`.ORDER_ID, 
if(`order header`.customer_id="", fGetEmployeeName(`order header`.employee_id),
if(`order header`.customer_id="WALK-IN CUSTOMER", "WALK-IN", getGuestNameFromHotel(`order header`.customer_id))) as CUSTOMER_ID, 
`order detail`.ITEM_ID, 
item.description,
`order detail`.UNIT_PRICE as GROSS, 
`order detail`.QUANTITY, 
(`order detail`.UNIT_PRICE - (`order detail`.unit_price/(1+item.service_charge+item.evat)*item.evat) - `order detail`.SERVICE_CHARGE) as Nett,
(`order detail`.unit_price/(1+item.service_charge+item.evat)*item.evat) as VAT,
`order detail`.SERVICE_CHARGE,
`order detail`.CREATEDBY,
item.group_id,
group.maingroup_id
from 
`order header`, 
`order detail`,
item,
`group`,
payment
where
`order header`.order_id = `order detail`.order_id and
`order header`.order_id=payment.order_id and
item.item_id = `order detail`.item_id and
group.group_id = item.group_id and
if(pMainGroup = 'All',group.maingroup_id <> '',
group.maingroup_id = pMainGroup) and
if(pGroup = 'All',group.group_id <> '',group.group_id = pGroup) and
(`order header`.ORDER_DATE >= pStartDate and
`order header`.ORDER_DATE <= pEndDate)
and payment.status<>'VOID'
and item.resto_id=pRestoID
and group.resto_id=pRestoID
and `order detail`.operation_status!='CANCELLED'
order by `order header`.order_date;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportEDRoomTransfer` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportEDRoomTransfer`(
IN photelid int(5)
)
BEGIN
select folioid
from folioschedules 
where date(fromdate) = adddate(curdate(),1);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportEmployeeAccount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportEmployeeAccount`(pDate date)
BEGIN
select concat('Report for ' , employee_ledger.date)as coverage,
employee.employee_id, concat(employee.lastname,', ', employee.firstname) as `name`,employee_ledger.date,
employee_ledger.order_id, employee_ledger.debit, payment_ledger.credit,`employee account`.balance
from employee, employee_ledger, `employee account`, payment_ledger
where employee.employee_id=employee_ledger.employee_id and
employee_ledger.employee_id=`employee account`.employee_id
and employee_ledger.employee_id=payment_ledger.employee_id
and employee_ledger.date=pDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportEmployeeAccountMonth` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportEmployeeAccountMonth`(pMonth int(2))
BEGIN
select concat('Report for the month of ' , date_format(employee_ledger.date,'%M'))as coverage,
employee.employee_id, concat(employee.lastname,', ', employee.firstname) as `name`,employee_ledger.date,
employee_ledger.order_id, employee_ledger.debit, if(payment_ledger.EMPLOYEE_ID=employee.EMPLOYEE_ID,payment_ledger.credit,0.00) as credit,`employee account`.balance
from employee, employee_ledger, `employee account`, payment_ledger
where (employee.employee_id=employee_ledger.employee_id and
employee_ledger.employee_id=`employee account`.employee_id
and employee_ledger.employee_id=payment_ledger.employee_id
and month(employee_ledger.date)=pMonth) 
or (employee.employee_id=employee_ledger.employee_id and
employee_ledger.employee_id=`employee account`.employee_id
and month(employee_ledger.date)=pMonth);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportEmployeeLedgerDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportEmployeeLedgerDetails`(
pEmployeeId varchar(20)
)
BEGIN
select 
employee_ledger.ORDER_ID, 
`order header`.*,
employee.*,
`employee account`.charge as CurrentBalance,
`order detail`.*
from 
employee_ledger 
left join employee on employee_ledger.EMPLOYEE_ID = employee.EMPLOYEE_ID
left join `order header` on (employee_ledger.ORDER_ID = `order header`.ORDER_ID
and `order header`.status != 'CANCELLED')
left join `employee account` on `employee account`.EMPLOYEE_ID = employee_ledger.EMPLOYEE_ID
left join `order detail` on (`order detail`.ORDER_ID = `order header`.ORDER_ID
and `order detail`.operation_status != 'CANCELLED')
where employee_ledger.employee_id = pEmployeeId	;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportExpectedGuestsArrival` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportExpectedGuestsArrival`(
in photelid int(5)
)
BEGIN
select 
concat(guests.firstname,"  ",guests.lastname) as GuestName,
guests.memo,
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.todate as departure,
FOLIO.remarks
from 
guests,
folio,
folioschedules 
where 
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and 
date(folioschedules.fromdate) = adddate(curdate(),1) and
not exists
(
select *
from 
folioschedules 
where date(todate) = curdate() AND folio.folioid = folioschedules.folioid
) and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportExpectedGuestsDeparture` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportExpectedGuestsDeparture`(
in photelid int(5)
)
BEGIN
select 
folio.folioid,
concat(guests.firstname,"  ",guests.lastname) as GuestName,
folioschedules.roomid,
folioschedules.roomtype,
folio.remarks
from 
guests,
folio,
folioschedules 
where 
guests.accountid = folio.accountid and
folio.folioid = folioschedules.folioid  and 
folio.status = 'CHECKED IN' and
date(folioschedules.todate) = adddate(curdate(),1) and
folio.hotelid = guests.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = pHotelID and
not exists(
select folioid
from folioschedules 
where date(fromdate) = adddate(curdate(),1) and
folio.folioid = folioschedules.folioid
)
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFoodAndBeverage` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFoodAndBeverage`(pDate date, pShiftCode varchar(5))
BEGIN
set sql_big_selects = 1;
select distinct
`order header`.order_id,
sum(if(`group`.maingroup_id='FOOD', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as Food,
sum(if(`group`.maingroup_id='BEVERAGES', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as Beverages,
sum(if(`group`.maingroup_id is null or `group`.maingroup_id = 'OTHERS', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as OtherSales,
sum(if(`group`.maingroup_id='BANQUET', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as BanquetSales,
sum(`order detail`.amount) as VatSales,
sum(`order detail`.service_charge) as ServiceCharge,
sum(`order detail`.vat) as Vat,
sum(`order detail`.discount) as Discount,
sum(`order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount) as TotalAmount,
fGetCashPaymentPerOrder(`order header`.order_id) as  Cash,
fGetCreditCardPaymentPerOrder(`order header`.order_id) as CreditCard,
fGetCouponPaymentPerOrder(`order header`.order_id) as Coupon,
fGetGuestAccountPaymentPerOrder(`order header`.order_id) as GuestAccount,
fGetEmployeeAccountPaymentPerOrder(`order header`.order_id) as EmployeeLedger,
fGetComplimentaryPaymentPerOrder(`order header`.order_id) as Complimentary,
fGetExDealPaymentPerOrder(`order header`.order_id) as ExDeal,
if(`order header`.customer_id = 'WALK-IN CUSTOMER',
'Walk-in Customer',
concat(`hotelmgtsystem`.guests.lastname, ', ', `hotelmgtsystem`.guests.firstname)) 
as `Customer Name`,
(select `hotelmgtsystem`.roomevents.roomid from `hotelmgtsystem`.roomevents where `hotelmgtsystem`.roomevents.eventid=`order header`.customer_id and `hotelmgtsystem`.roomevents.transferflag!=1 and `hotelmgtsystem`.roomevents.eventdate=pDate) as RoomNo,
concat(employee.lastname, ', ' , employee.firstname) as EmployeeName,
`order header`.createdby as Cashier,
`order header`.shift_code ,
`order header`.terminal_id
from 
`order header` 
left join `order detail` 
on (`order header`.order_id = `order detail`.order_id
and `order detail`.`OPERATION_STATUS` <> 'CANCELLED') 
left join item 
on item.item_id = `order detail`.item_id
left join `group` 
on item.group_id = `group`.group_id
left join `hotelmgtsystem`.folio 
on `hotelmgtsystem`.folio.folioid = `order header`.customer_id
left join `hotelmgtsystem`.guests 
on `hotelmgtsystem`.guests.accountid = `hotelmgtsystem`.folio.accountid
left join employee on `order header`.employee_id=employee.employee_id
where 
`order header`.`status`<>'CANCELLED'
and date(`order header`.order_date)= pDate
and if(pShiftCode = '',true, `order header`.shift_code = pShiftCode)
group by
`order header`.order_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportFoodAndBeverageSalesDateRange` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportFoodAndBeverageSalesDateRange`(
pStartDate date, 
pEndDate date
)
BEGIN
set sql_big_selects = 1;
select distinct
`order header`.order_id,
sum(if(`group`.maingroup_id='FOOD', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as Food,
sum(if(`group`.maingroup_id='BEVERAGES', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as Beverages,
sum(if(`group`.maingroup_id is null, `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as OtherSales,
sum(if(`group`.maingroup_id='BANQUET', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as BanquetSales,
sum(`order detail`.amount) as VatSales,
sum(`order detail`.service_charge) as ServiceCharge,
sum(`order detail`.vat) as Vat,
sum(`order detail`.discount) as Discount,
sum(`order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount) as TotalAmount,
fGetCashPaymentPerOrder(`order header`.order_id) as  Cash,
fGetCreditCardPaymentPerOrder(`order header`.order_id) as CreditCard,
fGetCouponPaymentPerOrder(`order header`.order_id) as Coupon,
fGetGuestAccountPaymentPerOrder(`order header`.order_id) as GuestAccount,
fGetEmployeeAccountPaymentPerOrder(`order header`.order_id) as EmployeeLedger,
fGetComplimentaryPaymentPerOrder(`order header`.order_id) as Complimentary,
fGetExDealPaymentPerOrder(`order header`.order_id) as ExDeal,
if(`order header`.customer_id = 'WALK-IN CUSTOMER',
'Walk-in Customer',
concat(`hotelmgtsystem`.guests.lastname, ', ', `hotelmgtsystem`.guests.firstname)) 
as `Customer Name`,
(select `hotelmgtsystem`.roomevents.roomid from `hotelmgtsystem`.roomevents where `hotelmgtsystem`.roomevents.eventid=`order header`.customer_id and `hotelmgtsystem`.roomevents.transferflag!=1 and `hotelmgtsystem`.roomevents.eventdate between pStartDate and pEndDate) as RoomNo,
concat(employee.lastname, ', ' , employee.firstname) as EmployeeName,
`order header`.createdby as Cashier,
`order header`.shift_code ,
`order header`.terminal_id
from 
`order header` 
left join `order detail` 
on (`order header`.order_id = `order detail`.order_id
and `order detail`.`OPERATION_STATUS` <> 'CANCELLED') 
left join item 
on item.item_id = `order detail`.item_id
left join `group` 
on item.group_id = `group`.group_id
left join `hotelmgtsystem`.folio 
on `hotelmgtsystem`.folio.folioid = `order header`.customer_id
left join `hotelmgtsystem`.guests 
on `hotelmgtsystem`.guests.accountid = `hotelmgtsystem`.folio.accountid
left join employee on `order header`.employee_id=employee.employee_id
where 
`order header`.`status`<>'CANCELLED'
and date(`order header`.order_date) >= pStartDate
and date(`order header`.order_date) <= pEndDate
group by
`order header`.order_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportGroupBill` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportGroupBill`(
in pFolioId varchar(20),
in pHotelId int(5)
)
BEGIN
select distinct
folio.folioid,
folio.foliotype,
company.companyName,
concat(company.street1,", ",company.city1) as CityAdd,
concat(company.country1, " ",company.zip1) as CountryAdd,
foliotransactions.transactiondate,
foliotransactions.referenceno,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.netbaseamount,
foliotransactions.governmenttax,
foliotransactions.localtax,
foliotransactions.discount,
foliotransactions.updatedby,
if(acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT
from
company,
folio
left join foliotransactions on foliotransactions.folioid = folio.folioid 
and foliotransactions.status = 'ACTIVE'
where
company.companyid = folio.companyid and
folio.folioid = pFolioId and 	
folio.hotelid = pHotelId
order by foliotransactions.transactiondate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportHeavyUsersMonthly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportHeavyUsersMonthly`(
pMonth int(2)
)
BEGIN
select 
concat('Report for ', Monthname(ORDER_DATE)) as Coverage,
count(`order header`.CUSTOMER_ID) as Num,
NAME,
PHONE_NO,
sum(TOTAL_AMOUNT),
AVG(TOTAL_AMOUNT) as AVG_CHECK 
from 
`order header`,
customers
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and Month(ORDER_DATE)=pMonth
group by 
`order header`.CUSTOMER_ID
having count(`order header`.CUSTOMER_ID) >= (select Orders_per_month from 		order_volume_criteria 
Where Lcase(`Type`)='Heavy')  ; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportHeavyUsersSummaryMonthly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportHeavyUsersSummaryMonthly`(
pMonth int(2)
)
BEGIN
select 
concat('Report for ', Monthname(ORDER_DATE)) as Coverage,
count(`order header`.ORDER_ID),
sum(TOTAL_AMOUNT) as SALES_VALUE,
AVG(TOTAL_AMOUNT) as AVG_AMOUNT,
count(distinct `order header`.CUSTOMER_ID) as Cust_Count
from 
customers,
`order header`
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and Month(ORDER_DATE)=pMonth
group by `order header`.CUSTOMER_ID
having count(`order header`.CUSTOMER_ID) >= (select Orders_per_month from 	 	order_volume_criteria 
Where Lcase(`Type`)='Heavy')  ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportHeavyUsersSummaryWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportHeavyUsersSummaryWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage,count(`order header`.ORDER_ID),sum(TOTAL_AMOUNT) as SALES_VALUE,AVG(TOTAL_AMOUNT) as AVG_AMOUNT,count(distinct `order header`.CUSTOMER_ID) as Cust_Count
from customers,`order header`
where `order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and date(ORDER_DATE) between date(pStartDate) and adddate(pStartDate, interval 7 DAY)
group by `order header`.CUSTOMER_ID
having count(`order header`.CUSTOMER_ID) >= (select Orders_per_month from order_volume_criteria 
Where Lcase(`Type`)='Heavy')  ; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportHeavyUsersWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportHeavyUsersWeekly`(
pStartDate datetime
)
BEGIN
select 
concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage,
count(`order header`.CUSTOMER_ID) as Num,
NAME,
PHONE_NO,
sum(TOTAL_AMOUNT),
AVG(TOTAL_AMOUNT) as AVG_CHECK 
from 
`order header`, 
customers
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and date(ORDER_DATE) between date(pStartDate) 
and adddate(pStartDate, interval 7 DAY)
group by `order header`.CUSTOMER_ID
having count(`order header`.CUSTOMER_ID) >= (select Orders_per_month from order_volume_criteria 
Where Lcase(`Type`)='Heavy')  ; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportHousekeepingJobs` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportHousekeepingJobs`(
in photelid int(5)
)
BEGIN
select 
housekeepingjobs.roomid,
housekeepingjobs.housekeepingdate,
housekeepingjobs.starttime,
housekeepingjobs.endtime,
concat(
if(housekeepingjobs.elapsedtime div 60 > 0,
concat(housekeepingjobs.elapsedtime div 60 ," Hr(s) "),""),
housekeepingjobs.elapsedtime % 60, " Min(s)") as ElapseTime,
(housekeepingjobs.elapsedtime/1) as ElapsedTime,
concat(	housekeepingjobs.housekeeperid, "-",housekeepers.lastname,", ",housekeepers.firstname) as HOUSEKEEPER,
housekeepingjobs.updatedby
from
housekeepingjobs,
housekeepers
where
housekeepers.housekeeperid = housekeepingjobs.housekeeperid and
housekeepingjobs.housekeepingdate = curdate() and
housekeepingjobs.hotelid = housekeepers.hotelid and
housekeepingjobs.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportIndividualGuestBill` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportIndividualGuestBill`(
in pfolioid varchar(20),
in photelid int(5)
)
BEGIN
select distinct
folio.folioid,
(folio.noofadults+folio.noofchild) as TotalGuests,
folio.foliotype,
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.fromdate as ARRIVALDATE,
folioschedules.todate as DEPARTUREDATE,  
concat(guests.firstname," ",guests.lastname) as GuestName,
concat(guests.street,", ",guests.city) as CityAdd,
concat(guests.country, " ",guests.zip) as CountryAdd,
foliotransactions.transactiondate,
foliotransactions.SubFolio,
foliotransactions.referenceno,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.netbaseamount,
foliotransactions.governmenttax,
foliotransactions.localtax,
foliotransactions.discount,
foliotransactions.updatedby,
if(acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT
from
guests,
folioschedules,
folio
left join foliotransactions on foliotransactions.folioid = folio.folioid and
foliotransactions.status = 'ACTIVE'
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
date(folioschedules.fromdate) <= curdate() and
folio.folioid = pfolioid and 	
folio.hotelid = pHotelId
order by foliotransactions.transactiondate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportIndividualGuestBillSubReport` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportIndividualGuestBillSubReport`(
in pfolioid varchar(20)
)
BEGIN
Select 
folioid,
transactioncode,
GovernmentTax,
netbaseamount,
if(memo='CASH','PAYMENTS',memo) as memo,
if(acctside='DEBIT',baseamount,0.00) as CHARGES,  
if(acctside='CREDIT',baseamount,0.00) as CREDIT
from 
foliotransactions 
WHERE 
folioid=pfolioid and foliotransactions.status = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportIndividualGuestSubReport` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportIndividualGuestSubReport`(
in pfolioid varchar(20),
in pSubFolio varchar(1)
)
BEGIN
Select 
folioid,
SubFolio,
transactioncode,
netbaseamount,
memo 
from 
foliotransactions 
WHERE 
folioid=pfolioid and SubFolio=pSubFolio;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportINHouseGuest` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportINHouseGuest`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select distinct
`hotelmgtsystem`.folio.folioid,
concat(`hotelmgtsystem`.guests.lastname," , ",`hotelmgtsystem`.guests.firstname) as GuestName,
concat(`hotelmgtsystem`.guests.street,", ",`hotelmgtsystem`.guests.city, ", ",`hotelmgtsystem`.guests.country) as Address1,
concat(`hotelmgtsystem`.folioschedules.roomid," [",getfoliotype(`hotelmgtsystem`.folio.folioid),"]") as roomid,
`hotelmgtsystem`.folioschedules.rate,
`hotelmgtsystem`.folio.remarks,
`hotelmgtsystem`.folioschedules.fromdate AS arrivaldate,
`hotelmgtsystem`.folioschedules.todate AS departuredate
from
`hotelmgtsystem`.guests,
`hotelmgtsystem`.folio left join `hotelmgtsystem`.company on `hotelmgtsystem`.company.companyid = `hotelmgtsystem`.folio.companyid,
`hotelmgtsystem`.folioschedules
where
`hotelmgtsystem`.guests.accountid = `hotelmgtsystem`.folio.accountid and
`hotelmgtsystem`.folioschedules.folioid = if(`hotelmgtsystem`.folio.masterfolio="" or `hotelmgtsystem`.folio.masterfolio="0", `hotelmgtsystem`.folio.folioid,folio.masterfolio) and
`hotelmgtsystem`.folio.status = 'CHECKED IN' and
`hotelmgtsystem`.guests.hotelid = `hotelmgtsystem`.folio.hotelid and
`hotelmgtsystem`.folioschedules.hotelid = `hotelmgtsystem`.folio.hotelid and
`hotelmgtsystem`.folio.hotelid = photelid
order by `hotelmgtsystem`.folioschedules.roomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportInHouseGuests` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportInHouseGuests`(
in photelid int(5)
)
BEGIN
select 	distinct
folio.folioid,
concat(guests.firstname," ",guests.lastname) as GuestName,
concat(folioschedules.roomid," [",getfoliotype(folio.folioid),"]") as roomid,
folioschedules.rate,
folio.remarks,
folioschedules.fromdate AS arrivaldate,
folioschedules.todate AS departuredate
from
guests,
folio,
folioschedules
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
folio.status = 'CHECKED IN' and
(curdate() between date(folioschedules.fromdate) and date(folioschedules.todate)) and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid
order by folioschedules.roomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportMediumUsersMonthly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportMediumUsersMonthly`(
pMonth int(2)
)
BEGIN
select concat('Report for ', Monthname(ORDER_DATE)) as Coverage,
count(`order header`.CUSTOMER_ID) as Num,
NAME,
PHONE_NO,
sum(TOTAL_AMOUNT),
AVG(TOTAL_AMOUNT) as AVG_CHECK 
from 
`order header`, customers
where `order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and Month(ORDER_DATE)=pMonth
group by `order header`.CUSTOMER_ID
having count(`order header`.CUSTOMER_ID) >= (select Orders_per_month from order_volume_criteria Where Lcase(`Type`)='MEDIUM') 
and count(`order header`.CUSTOMER_ID) <= (select Orders_per_month from order_volume_criteria Where Lcase(`Type`)='HEAVY') ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportMediumUsersSummaryMonthly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportMediumUsersSummaryMonthly`(
pMonth int(2)
)
BEGIN
select concat('Report for ', Monthname(ORDER_DATE)) as Coverage,
count(`order header`.ORDER_ID),
sum(TOTAL_AMOUNT) as SALES_VALUE,
AVG(TOTAL_AMOUNT) as AVG_AMOUNT,
count(distinct `order header`.CUSTOMER_ID) as Cust_Count
from 
customers,
`order header`
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and Month(ORDER_DATE)=pMonth
group by `order header`.CUSTOMER_ID
having count(`order header`.CUSTOMER_ID) >= (select Orders_per_month from order_volume_criteria Where Lcase(`Type`)='MEDIUM') 
and count(`order header`.CUSTOMER_ID) <= (select Orders_per_month from order_volume_criteria Where Lcase(`Type`)='HEAVY') ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportMediumUsersSummaryWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportMediumUsersSummaryWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage,
count(`order header`.ORDER_ID),
sum(TOTAL_AMOUNT) as SALES_VALUE,
AVG(TOTAL_AMOUNT) as AVG_AMOUNT,
count(distinct `order header`.CUSTOMER_ID) as Cust_Count
from 
customers,`order header`
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and date(ORDER_DATE) between date(pStartDate) and adddate(pStartDate, interval 7 DAY)
group by `order header`.CUSTOMER_ID
having count(`order header`.CUSTOMER_ID) >= (select Orders_per_month from order_volume_criteria Where Lcase(`Type`)='MEDIUM') 
and count(`order header`.CUSTOMER_ID) <= (select Orders_per_month from order_volume_criteria Where Lcase(`Type`)='HEAVY') ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportMediumUsersWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportMediumUsersWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage,
count(`order header`.CUSTOMER_ID) as Num,
NAME,
PHONE_NO,
sum(TOTAL_AMOUNT),
AVG(TOTAL_AMOUNT) as AVG_CHECK from `order header`,
customers
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and date(ORDER_DATE) between date(pStartDate) and adddate(pStartDate, interval 7 DAY)
group by `order header`.CUSTOMER_ID
having count(`order header`.CUSTOMER_ID) >= (select Orders_per_month from order_volume_criteria Where Lcase(`Type`)='MEDIUM') 
and count(`order header`.CUSTOMER_ID) <= (select Orders_per_month from order_volume_criteria Where Lcase(`Type`)='HEAVY') ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportMonthlySales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportMonthlySales`(pMonth int, pYear int, pRestoID varchar(5))
BEGIN
select
`order header`.order_id as OrderID,
if(`order header`.customer_id='WALK-IN CUSTOMER', 
`order header`.customer_id, 
if(`order header`.employee_id!='', 
fGetEmployeeName(`order header`.employee_id), 
fGetGuestName(`order header`.customer_id))) as CustomerName,
date(order_date) as OrderDate,
total_line_items as TotalItems,
total_amount+total_discount as GrossSales,
total_discount as Discount,
vat_sales as VatSales,
nonvat_sales as NonVatSales,
vat_amount as GovernmentTax,
local_tax as LocalTax,
service_charge as ServiceCharge,
fGetMonthToDateGrossSales(pMonth, pYear) as MonthToDateGrossSales,
fGetYearToDateGrossSales(pYear) as YearToDateGrossSales,
fGetTotalGrossSales() as TotalGrossSales,
fGetMonthToDateVATSales(pMonth, pYear) as MonthToDateVatSales,
fGetYearToDateVATSales(pYear) as YearToDateVatSales,
fGetTotalVATSales() as TotalVatSales,
fGetMonthToDateNonVATSales(pMonth, pYear) as MonthToDateNonVatSales,
fGetYearToDateNonVATSales(pYear) as YearToDateNonVatSales,
fGetTotalNonVATSales() as TotalNonVatSales,
(0) as MonthToDateGovtTax,
(0) as YearToDateGovtTax,
(0) as TotalGovtTax,
(0) as MonthToDateLocalTax,
(0) as YearToDateLocalTax,
(0) as TotalLocalTax,
(0) as MonthToDateServiceCharge,
(0) as YearToDateServiceCharge,
(0) as TotalServiceCharge
from `order header` where month(order_date)=pMonth and year(order_date)=pYear and `order header`.status!='CANCELLED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportNewCustomers` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportNewCustomers`()
BEGIN
select CUSTOMER_ID,CUSTOMER_TYPE,NAME,concat(FIRST_NAME,' ',LAST_NAME) as OWNER,ADDRESS1,PHONE_NO,CREATETIME AS DATE_REGISTERED 
from customers 
where 
`STATUS`='ACTIVE' AND date(CREATETIME) between date(pStartDate) and adddate(pStartDate, interval 7 DAY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportNewCustomersMonthly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportNewCustomersMonthly`(
pMonth int(2)
)
BEGIN
select concat('Report for ', Monthname(ORDER_DATE)) as Coverage, NAME,PHONE_NO,sum(TOTAL_AMOUNT),customers.CREATETIME from customers,`order header` where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and customers.`STATUS`='ACTIVE'
and Month(customers.CREATETIME)=pMonth
group by `order header`.CUSTOMER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportNewCustomersSummaryMonthly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportNewCustomersSummaryMonthly`(
pMonth int(2)
)
BEGIN
select concat('Report for ', Monthname(customers.CREATETIME)) as Coverage,count(`order header`.ORDER_ID),sum(TOTAL_AMOUNT) as SALES_VALUE,AVG(TOTAL_AMOUNT) as AVG_AMOUNT,count(distinct `order header`.CUSTOMER_ID) as Cust_Count from customers,
`order header` where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and customers.`STATUS`='ACTIVE'
and Month(customers.CREATETIME)=pMonth
group by Monthname(customers.CREATETIME);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportNewCustomersSummaryWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportNewCustomersSummaryWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage,count(`order header`.ORDER_ID),sum(TOTAL_AMOUNT) as SALES_VALUE,AVG(TOTAL_AMOUNT) as AVG_AMOUNT,count(distinct `order header`.CUSTOMER_ID) as Cust_Count from customers,
`order header` where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID
and customers.`STATUS`='ACTIVE'
and date(customers.CREATETIME) between date(pStartDate) and adddate(pStartDate, interval 7 DAY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportNewCustomersWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportNewCustomersWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage,CUSTOMER_ID,CUSTOMER_TYPE,NAME,concat(FIRST_NAME,' ',LAST_NAME) as OWNER,ADDRESS1,PHONE_NO,CREATETIME AS DATE_REGISTERED 
from customers 
where 
`STATUS`='ACTIVE' AND date(CREATETIME) between date(pStartDate) and adddate(pStartDate, interval 7 DAY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportOutOfOrderRooms` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportOutOfOrderRooms`(
in photelid int(5)
)
BEGIN
select 
roomevents.roomid,
rooms.roomtypecode,
rooms.cleaningstatus,
rooms.`floor`
from 
roomevents,
rooms
where 
eventtype = 'ENGINEERING JOB' and
date(eventdate) = curdate() and 
roomevents.hotelid = rooms.hotelid and
roomevents.hotelid = photelid and 
rooms.roomid = roomevents.roomid
order by roomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportRestaurantEmployeePerformance` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportRestaurantEmployeePerformance`(pStartDate date, pEndDate date)
BEGIN
select employee.employee_id, 
concat(employee.lastname, ', ', employee.firstname) as employeeName, 
if(`order header`.customer_id='WALK-IN CUSTOMER', customer_id, fGetGuestName(`order header`.customer_id)) as customerName, 
`order header`.order_id, 
sum(`order header`.total_amount) as total_amount, 
`order header`.total_discount, 
`order header`.service_charge, 
`order header`.createTime, 
`order header`.order_date, 
(select count(`order header`.order_id) from `order header` where `order header`.assigned_to=employee.employee_id and date(order_date)>=pStartDate and date(order_date)<=pEndDate group by `order header`.assigned_to) as orderCount 
from `order header`, employee where `order header`.assigned_to=employee.employee_id and date(order_date)>=pStartDate and date(order_date)<=pEndDate group by employee_id order by total_amount desc, `order header`.createTime;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportReturnedOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportReturnedOrders`()
BEGIN
select `order header`.ORDER_ID,NAME,ORDER_DATE,TOTAL_AMOUNT,REMARKS
from 
`order header`,customers,complaints
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID and
`order header`.ORDER_ID =complaints.ORDER_ID and
`order header`.STATUS='RETURNED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportReturnedOrdersDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportReturnedOrdersDaily`(
pDate datetime
)
BEGIN
select concat('Report for ' , date_format(pDate,'%b-%d-%Y'))as Coverage,`order header`.ORDER_ID,NAME,ORDER_DATE,TOTAL_AMOUNT,REMARKS
from 
`order header`,customers,complaints
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID and
`order header`.ORDER_ID =complaints.ORDER_ID and
`order header`.STATUS='RETURNED' and date(ORDER_DATE)=pDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportReturnedOrderSummary` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportReturnedOrderSummary`()
BEGIN
select count(ORDER_ID) as TotalOrders,if(sum(TOTAL_LINE_ITEMS)is null,0,sum(TOTAL_LINE_ITEMS)) as TotalItem,if(sum(TOTAL_AMOUNT)is null,0,sum(TOTAL_AMOUNT)) as TotalAmount,if(sum(TOTAL_PAYMENT)is null,0,sum(TOTAL_PAYMENT))  as TotalPayment from `order header` where `STATUS`='RETURNED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportReturnedOrderSummaryDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportReturnedOrderSummaryDaily`(
pDate datetime
)
BEGIN
select concat('Report for ' , date_format(pDate,'%b-%d-%Y'))as Coverage, count(ORDER_ID) as TotalOrders,if(sum(TOTAL_LINE_ITEMS)is null,0,sum(TOTAL_LINE_ITEMS)) as TotalItem,if(sum(TOTAL_AMOUNT)is null,0,sum(TOTAL_AMOUNT)) as TotalAmount,if(sum(TOTAL_PAYMENT)is null,0,sum(TOTAL_PAYMENT))  as TotalPayment from `order header` where `STATUS`='RETURNED' 
and 
date(ORDER_DATE)=pDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportReturnedOrderSummaryWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportReturnedOrderSummaryWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage,count(ORDER_ID) as TotalOrders,if(sum(TOTAL_LINE_ITEMS)is null,0,sum(TOTAL_LINE_ITEMS)) as TotalItem,if(sum(TOTAL_AMOUNT)is null,0,sum(TOTAL_AMOUNT)) as TotalAmount,if(sum(TOTAL_PAYMENT)is null,0,sum(TOTAL_PAYMENT))  as TotalPayment from `order header` 
where `STATUS`='RETURNED' and 
date(ORDER_DATE) between date(pStartDate) and adddate(pStartDate, interval 7 DAY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportReturnedOrdersWeekly` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportReturnedOrdersWeekly`(
pStartDate datetime
)
BEGIN
select concat('Report from ',date_format(pStartDate,'%d-%b-%Y'),' to ',date_format(adddate(pStartDate, interval 7 DAY),'%d-%b-%Y'))as Coverage, `order header`.ORDER_ID,NAME,ORDER_DATE,TOTAL_AMOUNT,REMARKS
from 
`order header`,customers,complaints
where 
`order header`.CUSTOMER_ID=customers.CUSTOMER_ID and
`order header`.ORDER_ID =complaints.ORDER_ID and
`order header`.STATUS='RETURNED' 
and 
date(ORDER_DATE) between date(pStartDate) and adddate(pStartDate, interval 7 DAY);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportRidersReportDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportRidersReportDaily`(
pStartDate datetime
)
BEGIN
select concat('Report for ' , date_format(pStartDate,'%b-%d-%Y'))as Coverage,`order header`.ORDER_ID,TOTAL_AMOUNT,`order history`.ASSIGNED_TO from `order header`,`order history`
where `order header`.ORDER_ID=`order history`.ORDER_ID
and date(ORDER_DATE)=pStartDate
and `order history`.OPERATION='DELIVER' and concat(START_TIME,'') <> "00:00:00";
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportRoomAvailability` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportRoomAvailability`(
in photelid int(5)
)
BEGIN
select roomid,roomtypecode,stateflag,cleaningstatus,`floor` from rooms
where stateflag = 'VACANT' and hotelid = photelid
order by roomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportRoomCleaningStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportRoomCleaningStatus`(
in photelid int(5)
)
BEGIN
select 
roomid,
roomtypecode,
stateflag,
cleaningstatus
from 
rooms
where 
rooms.stateflag <> 'DELETED' and
rooms.hotelid = photelid
order by roomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportRoomOccupancy` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportRoomOccupancy`(
in pDateFrom date,
in pDateTo date,
in photelid int(5)
)
BEGIN
select roomevents.*,
folio.folioid,
concat(guests.lastname,", ",guests.firstname) as GUESTNAME
from 
roomevents,
folio,
guests
where 
roomevents.eventid = folio.folioid and
folio.accountid = guests.accountid and
(eventtype = 'IN HOUSE' or eventtype = 'CHECKED OUT') and 
roomevents.hotelid = photelid and
eventdate between pDateFrom and pDAteTo;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportRoomTransfer` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportRoomTransfer`(
in photelid int(5)
)
BEGIN
select 
folio.folioid,
concat(guests.firstname,"  ",guests.lastname) as GuestName,
folioschedules.roomid,
folioschedules.roomtype,
folio.remarks
from 
guests,
folio,
folioschedules 
where 
guests.accountid = folio.accountid and
folio.folioid = folioschedules.folioid  and 
folio.status = 'CHECKED IN' and
date(folioschedules.todate) = curdate() and
folio.hotelid = guests.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid  and
exists(
select folioid
from folioschedules 
where date(fromdate) = adddate(curdate(),1) and
folio.folioid = folioschedules.folioid
)
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportRunnersReportDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportRunnersReportDaily`(
pStartDate date
)
BEGIN
select concat('Report for ' , date_format(pStartDate,'%b-%d-%Y'))as Coverage,`order header`.ORDER_ID,TOTAL_AMOUNT,`order history`.ASSIGNED_TO from `order header`,`order history`
where `order header`.ORDER_ID=`order history`.ORDER_ID
and date(ORDER_DATE)=pStartDate
and `order history`.OPERATION='ASSEMBLING' and concat(START_TIME,'') <> "00:00:00";
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportSales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportSales`(
in pTrandate date,
in pHotelid int(5)
)
BEGIN
select distinct
foliotransactions.transactiondate,
foliotransactions.folioid,
foliotransactions.referenceno, 
foliotransactions.baseamount,
foliotransactions.updatetime,
concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE
from 	foliotransactions,
folioschedules,
transactioncode,
trantypes 
where 	
folioschedules.folioid = foliotransactions.folioid and
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
trantypes.trantypeid = '1' and
date(transactiondate) = pTrandate and
folioschedules.hotelid = foliotransactions.hotelid and
transactioncode.hotelid = foliotransactions.hotelid and
trantypes.hotelid = foliotransactions.hotelid and
foliotransactions.hotelid = photelid and
foliotransactions.status = 'ACTIVE'
order by transactiondate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportSalesSummary` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportSalesSummary`(
in pTrandate date,
in pHotelid int(5)
)
BEGIN
(
select  SUM(foliotransactions.baseamount) as Amount,
concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE
from 	
foliotransactions force index(FolioID,SubFolio,AccountID),
transactioncode force index(primary) ,
trantypes force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
date(transactiondate) = pTrandate	
group by foliotransactions.transactioncode
order by foliotransactions.transactioncode
)
UNION(
Select 0 AS Amount,concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE 
from 	transactioncode
WHERE  transactioncode.trancode NOT IN(Select transactioncode from foliotransactions)
);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportServiceCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportServiceCharge`(pMonth int(2))
BEGIN
select concat('Report for the month of ' , date_format(order_date,'%M'))as coverage,
order_date, order_id, customer_id, service_charge
from `order header`
where month(order_date)=pmonth and 
service_charge>0.00 group by order_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportServiceTime_BreakDown` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportServiceTime_BreakDown`()
BEGIN
select `order header`.ORDER_ID,OPERATION,START_TIME,END_TIME,WAIT_DURATION,SERVICE_DURATION,`order history`.ASSIGNED_TO from
`order header`, `order history`
WHERE 
`order header`.ORDER_ID=`order history`.ORDER_ID 
group by ORDER_ID,OPERATION order by ORDER_ID ASC;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportServiceTime_BreakDownDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportServiceTime_BreakDownDaily`(
pDate date
)
BEGIN
select concat('Report for ' , date_format(pDate,'%b-%d-%Y'))as Coverage, 
`order header`.ORDER_ID,`order header`.customer_id,
`order header`.TOTAL_AMOUNT,OPERATION,
START_TIME,END_TIME,WAIT_DURATION,SERVICE_DURATION,`order history`.ASSIGNED_TO 
from
`order header`, `order history`
WHERE 
`order header`.ORDER_ID=`order history`.ORDER_ID 
and date( `order header`.order_date) =date( pDate)
group by ORDER_ID,OPERATION order by ORDER_ID,START_TIME ASC;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportServiceTime_BreakDownSummaryDaily` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportServiceTime_BreakDownSummaryDaily`(
pDate date
)
BEGIN
select concat('Report for ' , date_format(pDate,'%b-%d-%Y'))as Coverage,GetOrderCount(pDate) as TotalOrder,`order history`.OPERATION,sec_to_time(AVG(time_to_sec(SERVICE_DURATION))) as AVG_SERVICE_TIME,GetTotalAmount(pDate) as TOTAL_AMOUNT from `order header`,`order history`
where `order header`.ORDER_ID=`order history`.ORDER_ID
and date(ORDER_DATE)=pDate
group by `order history`.OPERATION;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportSummarizedCharges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportSummarizedCharges`(in pStartDate date, in pEndDate date)
BEGIN
SELECT `order header`.order_date, `order header`.order_id, 
if(`order header`.employee_id='',`hotelmgtsystem`.folioschedules.roomid,'') as roomid,
if(`order header`.employee_id='',
concat(`hotelmgtsystem`.guests.lastname, ', ', `hotelmgtsystem`.guests.firstname),
concat(employee.lastname,', ', employee.firstname)) as `Customer Name`,
if(`order header`.employee_id='',
`order header`.customer_id, `order header`.employee_id) as customer_id,
vat_sales, service_charge, vat_amount, total_amount
from `order header` left join employee on `order header`.employee_id=employee.employee_id
left join `hotelmgtsystem`.folio 
left join `hotelmgtsystem`.folioschedules on `hotelmgtsystem`.folio.folioid=`hotelmgtsystem`.folioschedules.folioid
on `order header`.customer_id=`hotelmgtsystem`.folio.folioid
left join `hotelmgtsystem`.guests on `hotelmgtsystem`.folio.accountid=`hotelmgtsystem`.guests.accountid,
payment
where `order header`.order_id=payment.order_id
and payment.status<>'VOID' and `order header`.customer_id<>'WALK-IN CUSTOMER' and
(date(`order header`.ORDER_DATE) >= pStartDate and
date(`order header`.ORDER_DATE) <= pEndDate);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportSummarizedSalesByMainGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportSummarizedSalesByMainGroup`(in pStartDate date, in pEndDate date, pRestoID int(2))
BEGIN
select 
main_item_group.description as particulars,
sum(distinct item.unit_cost) as unit_cost,
sum(distinct abs(`order detail`.unit_price)) as net,
sum(distinct `order detail`.vat) as evat,
sum(distinct `order detail`.service_charge) as service_charge,
sum(distinct abs(`order detail`.unit_price)) as gross
from `order header`,payment, `order detail`, item, `group`, main_item_group
where `order header`.order_id=payment.order_id and `order header`.order_id=`order detail`.order_id
and `order detail`.item_id=item.item_id and payment.status<>'VOID'
and item.group_id=group.group_id and group.maingroup_id=main_item_group.id
and item.resto_id=pRestoID
and `order detail`.operation_status!='CANCELLED'
group by main_item_group.id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportSummarizedSalesByOutlet` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportSummarizedSalesByOutlet`(
in pMainGroup varchar(30),
in pGroup varchar(50),
in pStartDate date,
in pEndDate date,
in pTerminal int(4)
)
BEGIN
select 
cashiers.terminal,
`order header`.ORDER_DATE, 
`order header`.ORDER_ID, 
count(distinct `order header`.CUSTOMER_ID) as customer_id, 
`order detail`.ITEM_ID, 
item.description,
sum(`order detail`.UNIT_PRICE * `order detail`.quantity) as GROSS, 
sum(`order detail`.QUANTITY) as quantity, 
SUM(`order detail`.UNIT_PRICE * `order detail`.quantity) - (SUM(`order detail`.vat) - SUM(`order detail`.SERVICE_CHARGE)) as Nett,
sum(`order detail`.VAT) as VAT,
sum(`order detail`.SERVICE_CHARGE) as service_charge,
`order detail`.CREATEDBY,
item.group_id,
group.maingroup_id
from 
`order header`, 
`order detail`,
item,
`group`, cashiers, payment
where
`order header`.order_id = `order detail`.order_id and
`order header`.order_id=payment.order_id and
item.item_id = `order detail`.item_id and
group.group_id = item.group_id and
if(pMainGroup = 'All',group.maingroup_id <> '',
group.maingroup_id = pMainGroup) and
if(pGroup = 'All',group.group_id <> '',group.group_id = pGroup) and
(`order header`.ORDER_DATE >= pStartDate and
`order header`.ORDER_DATE <= pEndDate)
and if(pTerminal = 0, true, `order header`.terminal_id=cashiers.terminalid
and `order header`.terminal_id=pTerminal)
and payment.status<>'VOID' and `order detail`.operation_status!='CANCELLED'
group by group.maingroup_id, group.group_id, item.item_id
order by `order header`.order_date;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportSummarizedSalesByPayment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportSummarizedSalesByPayment`(in pStartDate date,
in pEndDate date)
BEGIN
select payment_type, 
if(lcase(payment_type='complimentary' or payment_type='xdeal'), sum(abs(`order header`.total_amount)), sum((payment.amount-abs(`order header`.balance))-service_charge-vat_amount-nonvat_sales)) as net, 
sum(service_charge/fGetTotalPaymentType(`order header`.order_id)) as `service charge`, 
if(lcase(payment_type='complimentary' or payment_type='xdeal'), sum(abs(`order header`.total_amount)+nonvat_sales), ROUND(sum((payment.amount-abs(`order header`.balance))+nonvat_sales))) as gross,
sum(vat_amount/fGetTotalPaymentType(`order header`.order_id)) as evat,
sum(nonvat_sales) as discounts, 
sum(roomservice_charge) as others, 
if(lcase(payment_type='complimentary' or payment_type='xdeal'), sum(`order header`.total_amount), sum(payment.amount-abs(`order header`.balance))) as total
from `order header`, payment
where `order header`.order_id=payment.order_id
and (`order header`.ORDER_DATE >= pStartDate and
`order header`.ORDER_DATE <= pEndDate)
and payment.status<>'VOID'
group by payment.payment_type;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportSummarizedSales_By_SalesFunctionGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportSummarizedSales_By_SalesFunctionGroup`(
in pStartDate date,
in pEndDate date,
in pRestoID int(5)
)
BEGIN
select 
sum(`order detail`.QUANTITY) as QUANTITY,
`ORDER DETAIL`.UNIT_PRICE AS selling_price,
(sum(`order detail`.QUANTITY) * `order detail`.unit_price) as COST,
(sum(`order detail`.QUANTITY) * `order detail`.unit_price) as SALES,
`function mapping`.description
from 
`order header`, 
`order detail` LEFT JOIN 
`function mapping` ON (`ORDER DETAIL`.ITEM_ID=`function mapping`.function_id),
PAYMENT
where
`order header`.order_id = `order detail`.order_id and
`order header`.order_id=payment.order_id and
(`order header`.ORDER_DATE >= pStartDate and
`order header`.ORDER_DATE <= pEndDate)
and payment.status<>'VOID'
and `function mapping`.resto_id=pRestoID
and `order detail`.operation_status!='CANCELLED'
group by (`function mapping`.function_id)
order by `order header`.order_date;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportSummarizedSales_By_SalesItemGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportSummarizedSales_By_SalesItemGroup`(
in pStartDate date,
in pEndDate date,
in pRestoID int(5)
)
BEGIN
select 
sum(`order detail`.QUANTITY) as QUANTITY,
item.unit_cost,
`ORDER DETAIL`.UNIT_PRICE AS selling_price,
(sum(`order detail`.QUANTITY * item.unit_cost)) as COST,
(sum(`order detail`.QUANTITY * `order detail`.unit_price)) as SALES,
item.description,
item.group_id,
group.maingroup_id,
fGetTotalDiscountPerItem(pStartDate,pEndDate, item.item_id) as discountItem,
fGetTotalDiscount(pStartDate,pEndDate) as discount,
if(fGetTotalCharges(pStartDate,pEndDate) is null, 0.00, 
fGetTotalCharges(pStartDate,pEndDate)) as account_charges
from 
`order header`, 
`order detail` LEFT JOIN 
item ON (`ORDER DETAIL`.ITEM_ID=ITEM.ITEM_ID) LEFT JOIN `group` ON (ITEM.GROUP_ID=GROUP.GROUP_ID),
PAYMENT
where
`order header`.order_id = `order detail`.order_id and
`order header`.order_id=payment.order_id and
(`order header`.ORDER_DATE >= pStartDate and
`order header`.ORDER_DATE <= pEndDate)
and payment.status<>'VOID'
and item.resto_id=pRestoID
and group.resto_id=pRestoID
and `order detail`.operation_status!='CANCELLED'
group by (item.item_id)
order by `order header`.order_date;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportTransactionRegister` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportTransactionRegister`()
BEGIN
select foliotransactions.transactiondate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource` as ReferenceType,
foliotransactions.`FolioID`,
concat(guests.`lastname`,", " , guests.`firstname`) as GuestName,
foliotransactions.transactioncode,
foliotransactions.`Memo`,
if(AcctSide='DEBIT',foliotransactions.`BaseAmount`,0.00) as DEBIT,
if(AcctSide='CREDIT',foliotransactions.`BaseAmount`,0.00) as CREDIT,
foliotransactions.`CREATEDBY`
from
foliotransactions,
`guests`
where
foliotransactions.`AccountID`=guests.`accountid`
and date(foliotransactions.`TransactionDate`)=curdate() and
foliotransactions.Status='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportTrunkLineSummary` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportTrunkLineSummary`(
pGroupId varchar(30)
)
BEGIN
Select 
trunkgroups.PhoneNo as Trunkgroup,
concat(concat(Extension,"-"),Owner) as Trunk,
Count(*) as TotalCall,
CallType,
concat(sec_to_time(sum(time_to_sec(Duration))),'') as TotalDuration,
sum(Cost) as TotalCost,
concat(sec_to_time(Avg(time_to_sec(Duration))),'') as AvgDuration,
Avg(Cost) as AvgCost
from 
trunkgroups force index(primary),
trunklines force index(primary),
`log` force index(primary),
extension
Where 
trunklines.TrunkGroup = trunkgroups.TrunkGroupID
and log.Trunk=trunklines.TrunkNum and trunkgroups.TrunkGroupID=pGroupId
and log.Extension=pExtension
group by trunknum,CallType;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportTrunkLineSummaryDate` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportTrunkLineSummaryDate`(
pDate datetime
)
BEGIN
Select 
concat('Report for ', date_format(date(pDate),'%d-%b-%Y')) as Coverage,
trunklines.PhoneNo as PhoneNo,
concat(concat(Extension,"-"),Owner) as Trunk,
Count(*) as TotalCall,
CallType,
concat(sec_to_time(sum(time_to_sec(Duration))),'') as TotalDuration,
sum(Cost) as TotalCost,
concat(sec_to_time(Avg(time_to_sec(Duration))),'') as AvgDuration,
Avg(Cost) as AvgCost
from 
trunklines force index(primary),
`log` force index(primary),
extension
Where 
log.Trunk=trunklines.TrunkNum 
and log.Extension=extension.ExtNum 
and date(CallDate)=pDate
group by PhoneNo,log.Extension,CallType;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportVoidedDailySales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReportVoidedDailySales`(pDate date, pRestoID varchar(5))
BEGIN
select
`order header`.order_id as OrderID,
if(`order header`.customer_id='WALK-IN CUSTOMER', 
`order header`.customer_id, 
if(`order header`.employee_id!='', 
fGetEmployeeName(`order header`.employee_id), 
fGetGuestName(`order header`.customer_id))) as CustomerName,
date(order_date) as OrderDate,
total_line_items as TotalItems,
total_amount+total_discount as GrossSales,
total_discount as Discount,
vat_sales as VatSales,
nonvat_sales as NonVatSales,
vat_amount as GovernmentTax,
local_tax as LocalTax,
service_charge as ServiceCharge,
fGetVoidMonthToDateGrossSales(month(pDate), year(pDate)) as MonthToDateGrossSales,
fGetVoidYearToDateGrossSales(year(pDate)) as YearToDateGrossSales,
fGetVoidTotalGrossSales() as TotalGrossSales,
fGetVoidMonthToDateVATSales(month(pDate), year(pDate)) as MonthToDateVatSales,
fGetVoidYearToDateVATSales(year(pDate)) as YearToDateVatSales,
fGetVoidTotalVATSales() as TotalVatSales,
fGetVoidMonthToDateNonVATSales(month(pDate), year(pDate)) as MonthToDateNonVatSales,
fGetVoidYearToDateNonVATSales(year(pDate)) as YearToDateNonVatSales,
fGetVoidTotalNonVATSales() as TotalNonVatSales,
(0) as MonthToDateGovtTax,
(0) as YearToDateGovtTax,
(0) as TotalGovtTax,
(0) as MonthToDateLocalTax,
(0) as YearToDateLocalTax,
(0) as TotalLocalTax,
(0) as MonthToDateServiceCharge,
(0) as YearToDateServiceCharge,
(0) as TotalServiceCharge
from `order header` where date(order_date)=pDate AND `order header`.status='CANCELLED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportVoidFoodAndBeverage` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportVoidFoodAndBeverage`(pDate date, pShiftCode varchar(5))
BEGIN
set sql_big_selects = 1;
select distinct
`order header`.order_id,
sum(if(`group`.maingroup_id='FOOD', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as Food,
sum(if(`group`.maingroup_id='BEVERAGES', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as Beverages,
sum(if(`group`.maingroup_id is null, `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as OtherSales,
sum(if(`group`.maingroup_id='BANQUET', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as BanquetSales,
sum(`order detail`.amount) as VatSales,
sum(`order detail`.service_charge) as ServiceCharge,
sum(`order detail`.vat) as Vat,
sum(`order detail`.discount) as Discount,
sum(`order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount) as TotalAmount,
fGetCashPaymentPerOrder(`order header`.order_id) as  Cash,
fGetCreditCardPaymentPerOrder(`order header`.order_id) as CreditCard,
fGetCouponPaymentPerOrder(`order header`.order_id) as Coupon,
fGetGuestAccountPaymentPerOrder(`order header`.order_id) as GuestAccount,
fGetEmployeeAccountPaymentPerOrder(`order header`.order_id) as EmployeeLedger,
fGetComplimentaryPaymentPerOrder(`order header`.order_id) as Complimentary,
fGetExDealPaymentPerOrder(`order header`.order_id) as ExDeal,
if(`order header`.customer_id = 'WALK-IN CUSTOMER',
'Walk-in Customer',
concat(`hotelmgtsystem`.guests.lastname, ', ', `hotelmgtsystem`.guests.firstname)) 
as `Customer Name`,
`hotelmgtsystem`.folioschedules.roomid as RoomNo,
concat(employee.lastname, ', ' , employee.firstname) as EmployeeName,
`order header`.createdby as Cashier,
`order header`.shift_code ,
`order header`.terminal_id
from 
`order header` 
left join `order detail` 
on (`order header`.order_id = `order detail`.order_id) 
left join item 
on item.item_id = `order detail`.item_id
left join `group` 
on item.group_id = `group`.group_id
left join `hotelmgtsystem`.folio 
on `hotelmgtsystem`.folio.folioid = `order header`.customer_id
left join `hotelmgtsystem`.folioschedules 
on `hotelmgtsystem`.folioschedules.folioid = `hotelmgtsystem`.folio.folioid
left join `hotelmgtsystem`.guests 
on `hotelmgtsystem`.guests.accountid = `hotelmgtsystem`.folio.accountid
left join employee on `order header`.employee_id=employee.employee_id
where 
`order header`.`status`='CANCELLED'
and date(`order header`.order_date)= pDate
and if(pShiftCode = '',true, `order header`.shift_code = pShiftCode)
group by
`order header`.order_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReportVoidFoodAndBeverageSalesDateRange` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReportVoidFoodAndBeverageSalesDateRange`(
pStartDate date, 
pEndDate date
)
BEGIN
set sql_big_selects = 1;
select distinct
`order header`.order_id,
sum(if(`group`.maingroup_id='FOOD', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as Food,
sum(if(`group`.maingroup_id='BEVERAGES', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as Beverages,
sum(if(`group`.maingroup_id is null, `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as OtherSales,
sum(if(`group`.maingroup_id='BANQUET', `order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount,0)) as BanquetSales,
sum(`order detail`.amount) as VatSales,
sum(`order detail`.service_charge) as ServiceCharge,
sum(`order detail`.vat) as Vat,
sum(`order detail`.discount) as Discount,
sum(`order detail`.unit_price * 
`order detail`.quantity - 
`order detail`.discount) as TotalAmount,
fGetCashPaymentPerOrder(`order header`.order_id) as  Cash,
fGetCreditCardPaymentPerOrder(`order header`.order_id) as CreditCard,
fGetCouponPaymentPerOrder(`order header`.order_id) as Coupon,
fGetGuestAccountPaymentPerOrder(`order header`.order_id) as GuestAccount,
fGetEmployeeAccountPaymentPerOrder(`order header`.order_id) as EmployeeLedger,
fGetComplimentaryPaymentPerOrder(`order header`.order_id) as Complimentary,
fGetExDealPaymentPerOrder(`order header`.order_id) as ExDeal,
if(`order header`.customer_id = 'WALK-IN CUSTOMER',
'Walk-in Customer',
concat(`hotelmgtsystem`.guests.lastname, ', ', `hotelmgtsystem`.guests.firstname)) 
as `Customer Name`,
`hotelmgtsystem`.folioschedules.roomid as RoomNo,
concat(employee.lastname, ', ' , employee.firstname) as EmployeeName,
`order header`.createdby as Cashier,
`order header`.shift_code ,
`order header`.terminal_id
from 
`order header` 
left join `order detail` 
on (`order header`.order_id = `order detail`.order_id) 
left join item 
on item.item_id = `order detail`.item_id
left join `group` 
on item.group_id = `group`.group_id
left join `hotelmgtsystem`.folio 
on `hotelmgtsystem`.folio.folioid = `order header`.customer_id
left join `hotelmgtsystem`.folioschedules 
on `hotelmgtsystem`.folioschedules.folioid = `hotelmgtsystem`.folio.folioid
left join `hotelmgtsystem`.guests 
on `hotelmgtsystem`.guests.accountid = `hotelmgtsystem`.folio.accountid
left join employee on `order header`.employee_id=employee.employee_id
where 
`order header`.`status`='CANCELLED'
and date(`order header`.order_date) >= pStartDate
and date(`order header`.order_date) <= pEndDate
group by
`order header`.order_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReport_DailySales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReport_DailySales`(
startDate date,
endDate date
)
BEGIN
select distinct
`order header`.ORDER_ID, 
`order header`.ROUTE_ID,
`order header`.ASSIGNED_TO,
`order header`.TOTAL_LINE_ITEMS,
`order header`.TOTAL_AMOUNT,
`order header`.TOTAL_PAYMENT,
`order header`.CUSTOMER_ID
from `order header`
where 
(`order header`.`STATUS` != 'RETURNED' and `order header`.`STATUS` != 'CANCELLED' and `order header`.`status`!='STOPPED') and
date(order_date) between startDate and endDate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReport_HourlySales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReport_HourlySales`(
pDate date
)
BEGIN
select date_format(createTime,'%l %p') as `Hour`, total_amount, customer_id
from `order header` 
where date(createTime) = pDate and (`STATUS` != 'RETURNED' and  `STATUS` != 'CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReport_MonthlySales` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReport_MonthlySales`(
pMonth int(10)
)
BEGIN
select distinct
date_format(date(`order header`.ORDER_date),'%d-%b-%Y') as Order_date, 
`order header`.ORDER_ID, 
`order header`.ROUTE_ID,
`order header`.ASSIGNED_TO,
`order header`.TOTAL_LINE_ITEMS,
`order header`.TOTAL_AMOUNT,
`order header`.TOTAL_PAYMENT,
`order header`.customer_id
from `order header`
where 
(`order header`.`status` != 'RETURNED' and `order header`.`status` != 'STOPPED' and `order header`.`status`!='CANCELLED') and
MONTH(order_date) = if(pMonth<>"",pMonth,month(curdate()))
order by date(order_date);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReport_SalesTrendGraph` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spReport_SalesTrendGraph`(
pMonth int(2),
pStartWeek date
)
BEGIN
select 
date_format(date(Order_Date), '%d-%b-%Y') as orderDate, 
count(Order_id) as Orders
from `order header`
where
(`status` != 'RETURNED' and `status` != 'STOPPED') and
if( pMonth > 0 , Month(order_date) = pMonth
,date(Order_Date) between pStartWeek and addDate(pStartWeek,7) )
group by order_date;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spReset` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spReset`()
BEGIN
START TRANSACTION;
update cashiers set openingbalance = 0.00 , openingadjustment = 0.00, beginningbalance = 0.00, chargeinamount = 0.00, cash = 0.00, creditcard = 0.00, cheque = 0.00, others = 0.00, adjustment = 0.00, amountremitted = 0.00, netamount = 0.00, `status` = 'CLOSE';
delete from cashiers_logs;
delete from complaints;
delete from `employee account`;
delete from employee_ledger;
delete from `group` where `status` = 'DELETED';
delete from item where `status` = 'DELETED';
delete from `order detail`;
delete from `order header`;
delete from `order history`;
delete from payment;
delete from payment_ledger;
update seq_orders set id = 1;
delete from table_assignment;
COMMIT;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spRoomIsCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spRoomIsCharge`( in pRoomid varchar(20),
in pEventDate date,
IN pEventID varchar(20),
in pHotelID int(5)
)
BEGIN
Select ChargeFlag 
from roomevents 
where roomid = proomid and
Eventdate = pEventDate and
hotelid = pHotelid and 
eventid = pEventID and
(
EventType <> 'CHECKED OUT'
or EventType<>'CANCELLED');
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spRoomTransferView` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spRoomTransferView`()
BEGIN
select folioid from folioschedules
where
departuredate = now();
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSaveFolioRouting` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSaveFolioRouting`(
pHotelID int(5),
pFolioID varchar(20),
pSubFOlio varchar(1),
pTransactionCode  varchar(20),
pBasis varchar(1),
pPercentCharged   decimal(12,2),
pAmountCharged decimal(12,2),
pCreatedBy varchar(20),
pUpdatedBy  varchar(20)
)
BEGIN
insert into folioROuting
values
(photelid,pfolioid,pSubFolio,pTransactionCode,pBasis,if(pBasis = "P",(pPercentCharged/100),"0"),if(pBasis = "A", pAmounTCharged,"0"),now(),pCreatedby,now(),pUpdatedBy)
on duplicate key update 
Basis = pBasis, 
PercentCharged = if(pBasis="P", (pPercentCharged/100),"0"), 
AmountCharged = if(pBasis="A", pAmountCharged,"0"), 
updateTime = now(), 
updatedby = pUpdatedBy;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSearchAccountName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSearchAccountName`(
in pAccountName varchar(30)
)
BEGIN
Select AccountId,AccountName,FirstName,MiddleName,LastName,Age,Sex,CitizenShip from guestS where accountname=pAccountname;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSearchGuestRefName` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSearchGuestRefName`(
in plastname varchar(30),
in  pfirstname varchar(30),
in  pmiddlename varchar(30)
)
BEGIN
Select * from guests where lastname=plastname and firstname=pfirstname and middlename=pmiddlename;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveBikeAssign` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveBikeAssign`(
)
BEGIN
select bike_assign.EMPLOYEE_ID,
concat(FIRSTNAME,' ', LASTNAME) as Name,
bike_assign.BIKE_ID,
MODEL
from 
bike_assign,
employee,
bike
where 
bike_assign.EMPLOYEE_ID=employee.EMPLOYEE_ID and
bike_assign.BIKE_ID=bike.BIKE_ID and
bike_assign.`STATUS`='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveBikes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveBikes`()
BEGIN
select BIKE_ID,PLATE_NO,ENGINE_NO,MODEL,MAKE from bike where `Status`='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveButtons` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveButtons`(pRestoID int(10))
BEGIN
select BUTTON_ID,`TYPE`,OBJECT  from button_setup where `STATUS`='ACTIVE'
and  RESTO_ID=pRestoID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveCustomers` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveCustomers`()
BEGIN
select 
CUSTOMER_ID, CUSTOMER_TYPE, NAME, ACCOUNT_NAME,
LAST_NAME, FIRST_NAME, PHONE_NO, ADDRESS1, ADDRESS2, CITY, PROVINCE, 
POSTAL_CODE, COUNTRY, TAX_REG_NO, 
TAXPAYER_ID, `TYPE`, CATEGORY, CLASS, 
`STATUS`
from customers 
where `STATUS` = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveEmployees` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveEmployees`(pHotelID int(5)
)
BEGIN
select EMPLOYEE_ID,LASTNAME,FIRSTNAME,MIDDLENAME,NICKNAME,POSITION,ADDRESS,CONTACTNO from employee where `STATUS`='ACTIVE'
and hotel_id=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveFunction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveFunction`()
BEGIN
select FUNCTION_ID as `Function Id`,DESCRIPTION as Description,OBJECT as Object, METHOD as Method
from `function mapping`
where `STATUS`='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveFunctions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveFunctions`(pRestoID int(10))
BEGIN
select FUNCTION_ID ,DESCRIPTION,OBJECT , METHOD, COST
from `function mapping`
where `STATUS`='ACTIVE'
and RESTO_ID=pRestoID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveGroup`(pRESTOID INT(5))
BEGIN
select GROUP_ID,DESCRIPTION, MAINGROUP_ID from `group` where `STATUS`='ACTIVE'
AND RESTO_ID=pRESTOID
order by group_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spselectactiveitems` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spselectactiveitems`(pRestoID int(10))
BEGIN
select ITEM_ID, item.GROUP_ID, MAINGROUP_ID, item.DESCRIPTION, 
UNIT,UNIT_COST, SELLING_PRICE, EVAT, SERVICE_CHARGE, LOCAL_TAX,
item.KITCHEN_DESIGNATION, item.availability
from item, `group` where item.group_id=group.group_id
and ITEM.resto_id=pRestoID AND GROUP.RESTO_ID=pRestoID and item.status='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveMainGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveMainGroup`()
BEGIN
select id,DESCRIPTION from `main_item_group` where `STATUS`='ACTIVE'
order by id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveMenu`()
BEGIN
select 
MENU_ID,
substring(item.group_id,1,length(item.group_id)) as Group_Id,
menu.DESCRIPTION,
menu.VAT,
menu.SERVICE_CHARGE,
menu.PRICE,
menu.PICTURE 
from 
menu 
left join item on item.item_id = menu.menu_id
where menu.`STATUS`='ACTIVE' 
order by menu_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveOperations` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveOperations`(
)
BEGIN
select OPERATION,DESCRIPTION from operation where `STATUS`='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveRestaurants` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveRestaurants`()
BEGIN
select RestaurantId, Description, AreaCode, TelephoneNo, Address from restaurants
where
Status = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveRoles` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveRoles`()
BEGIN
select role_id, description
from
roles
where
`status` = 'ACTIVE' and role_id!='ADMINISTRATOR';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveRoute` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveRoute`()
BEGIN
select  ROUTE_ID,DESCRIPTION,TOTAL_TIME,`DEFAULT` from `route header` where `STATUS`='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveSystemMenus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveSystemMenus`()
BEGIN
select MENU_NAME,DESCRIPTION
from
systemmenus
where
`status` = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveTradingAreas` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveTradingAreas`()
BEGIN
select Area_Code, Description from tradingareas
where
`Status` = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectActiveUsers` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectActiveUsers`()
BEGIN
select 
userId,
concat(FirstName," ",LastName) as Name,
LastName,
FirstName,
MiddleName,
Department,
Designation,
`Password` 
from users 
where `STATUS`='ACTIVE' ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectAmenities` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectAmenities`(
in photelid int(5)
)
BEGIN
select 	amenityid,
name,
description
from amenities
where stateflag != 'DELETED' and hotelid = photelid
order by amenityid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectAmenitiesForRoom` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectAmenitiesForRoom`(
in photelid int(5)
)
BEGIN
select amenityid,name
from amenities
where (stateflag = 'ACTIVE' or stateflag = 'UNASSIGNED') AND
hotelid = photelid
order by amenityid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectBlockID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectBlockID`()
BEGIN
select blockid from roomblock
order by blockid desc
limit 0,1;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectBlocks` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectBlocks`(
in pNow date
)
BEGIN
select roomblock.blockId,blockingdetails.roomid,if(pNow>=blockingdetails.blockfrom,pNow,blockingdetails.blockfrom)as blockfrom,blockingdetails.blockto,roomblock.reason from roomblock,blockingdetails where roomblock.blockid=blockingdetails.blockid and ( pNow<=blockingdetails.blockto);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectCashiers` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectCashiers`()
BEGIN
select * from cashiers;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectCashierTerminals` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectCashierTerminals`()
BEGIN
select * from Cashiers;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectCashTerminals` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectCashTerminals`(pRestoID int (5), pTerminalID varchar(5))
BEGIN
select * from Cashiers 
where restaurantid=pRestoID and terminalid=pTerminalID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectCompany` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectCompany`(
in photelid int(5)
)
BEGIN
select 
*
from company 
where stateflag <>'DELETED' and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectCreditCardTypes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spSelectCreditCardTypes`()
BEGIN
select * from creditcardtype
where statusFlag = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectCurrencyCodes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectCurrencyCodes`(
in photelid int(5)
)
BEGIN
Select * from currencycodes 
Where HOTELID=photelid AND stateFlag='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectCurrentDayRoomStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectCurrentDayRoomStatus`(
in pDate date,
in pHotelID int(5)
)
BEGIN
select distinct
rooms.roomid,
roomevents.eventtype 
from rooms use index(roomid)
left join roomevents use index(roomid,eventtype,eventdate) on 
rooms.roomid = roomevents.roomid and 
roomevents.hotelid=pHotelID and
roomevents.EventDate= pdate and 
roomevents.eventtype<>'CHECKED OUT'  and
roomevents.eventtype <> 'NO SHOW' and 
roomevents.eventtype <> 'CANCELLED'
order by rooms.roomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectDepartments` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectDepartments`(
in pHotelId int(5)
)
BEGIN
select * from department
where
hotelid = pHotelId and
stateflag = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectEmpCharges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectEmpCharges`()
BEGIN
Select id,EMPLOYEE_ID,Date,ORDER_ID,debit,credit from employee_ledger where closed='0';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectEngineeringJobs` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectEngineeringJobs`(
in photelid int(5)
)
BEGIN
select 	engineeringjobs.*,
engineeringservices.servicename
from 
engineeringjobs,
engineeringservices
where 
engineeringjobs.enggserviceid = engineeringservices.enggserviceid 
and engineeringjobs.stateflag <> 'DELETED' and engineeringjobs.hotelid = photelid
order by 
engineeringjobs.enggjobno;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectEngineeringServices` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectEngineeringServices`(
in photelid int(5)
)
BEGIN
select * from engineeringservices
where 
stateflag = 'ACTIVE' and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectFolioForRoom` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectFolioForRoom`()
BEGIN
select folio.folioid,folioschedules.roomid,folioschedules.arrivaldate,folio.status from folio,folioschedules 
where folio.folioid=folioschedules.folioid and folio.status='Checked In' order by folioid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectFolios` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectFolios`()
BEGIN
select * from folio;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectFolioTransactions` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectFolioTransactions`(in photelID int(5))
BEGIN
Select * FROM FOLIOTRANSACTIONS where hotelID =pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectFolioTransactionsByDate` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectFolioTransactionsByDate`(pdate date)
BEGIN
select * from foliotransactions where date(trandate)=pdate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectFolioTransactionsByMonth` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectFolioTransactionsByMonth`(pmonth int(1),
pyear int(4))
BEGIN
Select * from foliotransactions where month(trandate) =pmonth and year(trandate)=pyear; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectFolioTransactionsByRange` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectFolioTransactionsByRange`( pFromDate date,
pToDate date)
BEGIN
Select * from foliotransactions where (date(trandate) >= pFromDate and date(trandate)<=pToDate) and posttoledger='0';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectFolioTransactionsForBilling` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectFolioTransactionsForBilling`(
in pfolioid int(4)
)
BEGIN
select * from foliotransactions
where
folioid = pfolioid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectGetReservationList` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectGetReservationList`()
BEGIN
Select distinct folioSchedules.roomid,(roomtypes.roomtypename) as `Room Type`,
CONCAT(guest.firstname,' ',guest.Lastname) as Name,event.eventtype,
folio.accountType,folio.`status` from folio,guest,event,rooms,folioSchedules,roomtypes where 
folio.eventid=event.eventid and folio.accountid=guest.accountid
and folioSchedules.FolioId=folio.folioid and rooms.roomtypeid=roomtypes.roomtypeid and
folioSchedules.roomid=rooms.roomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectGetRoomList` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectGetRoomList`()
BEGIN
Select room.roomid
, roomtype.name,roomtype.roomrate,(roompromo.name) as RoomPromo,roompromo.percentoff, 
roomtype.maxoccupants,room.floor, room.smokingtype, room.windows,
room.stateflag, room.amount, room.breakfastflag, room.shareflag
from `room`,roomtype,`roompromo`,`roompromoasgt` 
where room.roomtypeid=roomtype.roomtypeid and 
roompromoasgt.roompromoid=roompromo.roompromoid and roomtype.roomtypeid=roompromoasgt.roomtypeid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectGroupFolioRecurringCharges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectGroupFolioRecurringCharges`(
in pHotelId int(4)
)
BEGIN
select 
foliorecurringcharge.TransactionCode, 
foliorecurringcharge.Memo,
foliorecurringcharge.Amount,
folio.companyId,
folio.folioid
from foliorecurringcharge,folio
where
foliorecurringcharge.hotelid = folio.hotelId and
foliorecurringcharge.folioid = folio.folioid and
folio.folioType = "GROUP" and
folio.hotelid = pHotelId and
( curdate() >= date(foliorecurringcharge.FromDate) and
curdate() <= date(foliorecurringcharge.ToDate) )
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectGuest` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectGuest`()
BEGIN
Select * from Guests WHERE stateflag<>'DELETED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectGuests` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectGuests`(in pHotelID int(5))
BEGIN
select 
*
from 
guests 
where 
stateflag <> 'DELETED' and 
hotelid = photelid
order by accountid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectHKLog` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectHKLog`()
BEGIN
Select * from hk_log;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectHotel` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectHotel`()
BEGIN
Select * from Hotel Where stateFlag='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectHouseKeepers` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectHouseKeepers`(
in photelid int(5)
)
BEGIN
select *
from housekeepers
where stateflag <> 'DELETED' and hotelid = photelid
order by housekeeperid
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectItemForMenuDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectItemForMenuDetail`()
BEGIN
Select ITEM_ID,DESCRIPTION from item where `STATUS`='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectItemsInButton` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spSelectItemsInButton`(in pRestoID int(10))
BEGIN
select distinct ITEM_ID, item.GROUP_ID, MAINGROUP_ID, item.DESCRIPTION, 
UNIT,UNIT_COST, SELLING_PRICE, EVAT*100 as EVAT, SERVICE_CHARGE*100 AS SERVICE_CHARGE
from item, `group`, button_setup
where item.item_id in (button_setup.object) and item.group_id=group.group_id
and ITEM.resto_id=pRestoID AND GROUP.RESTO_ID=pRestoID and item.status='ACTIVE'
and button_setup.resto_id=pRestoID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectMenuDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectMenuDetails`(
pMENU_ID varchar(10)
)
BEGIN
select `menu detail`.ITEM_ID,DESCRIPTION,QUANTITY from item,`menu detail`
where  
`menu detail`.ITEM_ID=item.ITEM_ID
and MENU_ID=pMENU_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectMenus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectMenus`(
)
BEGIN
Select * from menus;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectOperationForRouteDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectOperationForRouteDetail`()
BEGIN
select OPERATION,DESCRIPTION from operation where `STATUS`='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectOrderStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectOrderStatus`(
pCriteria varchar(30), pRestoID int(5)
)
BEGIN
If pCriteria='ALL' then
select 
`order header`.ORDER_ID,
`order header`.createtime,
`customers`.NAME,
`order header`.TOTAL_AMOUNT  as AMOUNT,
'' as REMARKS,
`order header`.ASSIGNED_TIME,
fGetEmployeeNickName(`order header`.assigned_to) as NickName,
GetLastRouteOperation(`order header`.order_id) as operation,
`order history`.START_TIME,
`order header`.`STATUS`
from 
`order header` left join `customers` on `order header`.CUSTOMER_ID=customers.CUSTOMER_ID,
`order history`
where
`order header`.ORDER_ID=`order history`.ORDER_ID and
`order header`.ASSIGNED_TO !="" and
`order history`.END_TIME="00:00:00" and !(lcase(`order header`.`status`) ="cancelled"
or lcase(`order history`.DISPOSITION) ="done" or lcase(`order header`.`status`="served"))		
group by `order header`.ORDER_ID
order by `order header`.ORDER_ID DESC ;
else
select 
`order header`.ORDER_ID,
`order header`.createtime,
`customers`.NAME,
`order header`.TOTAL_AMOUNT as AMOUNT,
'' as REMARKS,
fGetEmployeeNickName(`order header`.assigned_to) as NickName,
`order header`.ASSIGNED_TIME,
GetLastRouteOperation(`order header`.order_id) as operation,
`order history`.START_TIME,
`order header`.`STATUS`
from 
`order header` left join `customers` on `order header`.CUSTOMER_ID=customers.CUSTOMER_ID,
`order history`
where
`order header`.ORDER_ID=`order history`.ORDER_ID and
`order header`.ASSIGNED_TO !="" and
`order history`.END_TIME="00:00:00" and 
`order history`.OPERATION=pCriteria and
!(lcase(`order header`.`status`) ="cancelled"
or lcase(`order history`.DISPOSITION) ="done" or lcase(`order header`.`status`="served"))			
group by `order header`.ORDER_ID
order by `order header`.ORDER_ID DESC ;
end if;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectOrderStatus_1` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectOrderStatus_1`(
pCriteria varchar(30)
)
BEGIN
If pCriteria='ALL' then
select 
`order header`.ORDER_ID,
`order header`.CUSTOMER_ID AS NAME,
`order header`.TOTAL_AMOUNT  as AMOUNT,
GetRemarks(`order header`.ORDER_ID) as REMARKS,
`employee`.NICKNAME,
`order header`.ASSIGNED_TIME,
`order history`.OPERATION,
`order history`.START_TIME,
`order header`.`STATUS`
from 
`order header`,
`order history`,
`customers`,
`employee`
where
`order header`.ORDER_ID=`order history`.ORDER_ID and
`order header`.ASSIGNED_TO=`employee`.EMPLOYEE_ID and
`order header`.ASSIGNED_TO !="" and
`order history`.END_TIME="00:00:00" and lcase(`order history`.DISPOSITION) !="STOP"	
group by `order header`.ORDER_ID;
else
select 
`order header`.ORDER_ID,
`order header`.CUSTOMER_ID as NAME,
`order header`.TOTAL_AMOUNT as AMOUNT,
GetRemarks(`order header`.ORDER_ID) as REMARKS,
`employee`.NICKNAME,
`order header`.ASSIGNED_TIME,
`order history`.OPERATION,
`order history`.START_TIME,
`order header`.`STATUS`
from 
`order header`,
`order history`,
`customers`,
`employee`
where
`order header`.ORDER_ID=`order history`.ORDER_ID and
`order header`.ASSIGNED_TO=`employee`.EMPLOYEE_ID and
`order header`.ASSIGNED_TO !="" and
`order history`.END_TIME="00:00:00" and 
`order history`.OPERATION=pCriteria and
lcase(`order history`.DISPOSITION) !="STOP"	
group by `order header`.ORDER_ID;
end if;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectPackageDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectPackageDetails`(
in pPackageID varchar(20),
in pHotelId int(5)
)
BEGIN
SELECT packagedetails.PackageID,packagedetails.TransactionCode,transactioncode.memo,Basis        ,PercentOff,AmountOff 
FROM 
packagedetails,
transactioncode 
WHERE
packagedetails.transactioncode = transactioncode.trancode 
AND
packagedetails.PackageID=pPackageID 
AND 	
packagedetails.HotelID=pHotelID
AND 	
packagedetails.stateFlag='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectPackageHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectPackageHeader`(
pHotelId int(5)
)
BEGIN
SELECT * FROM packageheader WHERE HotelID=pHotelId AND stateFlag='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectPreparedOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectPreparedOrders`()
BEGIN
Select 
`order header`.ORDER_ID,
`customers`.name,
TOTAL_AMOUNT as AMOUNT,
GetRemarks_Routed(`order header`.ORDER_ID) as REMARKS,
NICKNAME  ,
ASSIGNED_TIME,
`order header`.`STATUS`
from 
`order header` 	left join  employee on (`order header`.ASSIGNED_TO=employee.EMPLOYEE_ID) inner join customers on (`order header`.customer_id=customers.Customer_id)
where `order header`.`status`='SERVED'
group by NICKNAME,`order header`.ORDER_ID,`customers`.name;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectPrivilegeDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectPrivilegeDetails`(
in pPrivilegeID varchar(20),
in pHotelId int(5)
)
BEGIN
SELECT privilegedetails.PrivilegeID,privilegedetails.TransactionCode,transactioncode.memo,Basis        ,PercentOff,AmountOff 
FROM 
privilegedetails,
transactioncode 
WHERE
privilegedetails.transactioncode = transactioncode.trancode 
AND
privilegedetails.PrivilegeID=pPrivilegeID 
AND 	
privilegedetails.HotelID=pHotelID
AND 	
privilegedetails.stateFlag='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectPrivilegeHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectPrivilegeHeader`(
pHotelId int(5)
)
BEGIN
SELECT * FROM privilegeheader WHERE HotelID=pHotelId AND stateFlag='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectPrivileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectPrivileges`(
pHotelId int(5)
)
BEGIN
Select privilegeheader.PrivilegeID,TransactionCode,Memo,Basis,PercentOff,AmountOff
From 
privilegeheader,
privilegedetails,
transactioncode
Where 
(privilegeheader.PrivilegeID=privilegedetails.PrivilegeID)
AND
(privilegedetails.TransactionCode=transactioncode.TranCode)
AND
(privilegeheader.stateFlag='ACTIVE' AND privilegeheader.HotelId=pHotelId);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectPromos` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectPromos`()
BEGIN
select promos.promoname,promos.percentoff,
promos.startdate,promos.enddate,
promos.promocode
from promos where promos.stateflag <> 'deleted'
order by promos.promocode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRateCodes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRateCodes`( in photelid int(5))
BEGIN
select *
from ratecodes where hotelid = photelid and stateflag = 'ACTIVE'
order by ratecode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRateTypes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRateTypes`(
in photelid int(5)
)
BEGIN
select 	
roomtypecode,
ratecode,	
rateamount
from ratetypes 
where hotelid = photelid and status != 'DELETED'
order by roomtypecode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectReservationList` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectReservationList`()
BEGIN
Select (Folio.FolioID) as `ID`,folio.FolioType,guest.Firstname,guest.Lastname,folio.AccountType,Folio.Status 
from folio,guest
where folio.accountid=guest.accountid and folio.status<>'Checked Out' and folio.status<>'No Show' and folio.status<>'Cancelled';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRiderEmployee` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRiderEmployee`()
BEGIN
select EMPLOYEE_ID,concat(FIRSTNAME,' ',LASTNAME) as Name from employee
Where 
POSITION='BIKER' and 
`STATUS`='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRoleMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spSelectRoleMenu`(
pRoleName varchar(30)
)
BEGIN
Select * 
FROM 
rolemenu 
Where 
RoleName=pRoleName;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRoleMenus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRoleMenus`(
pRole_Id      varchar(100)
)
BEGIN
select ROLE_ID, MENU_NAME, VISIBLE, `ENABLE`
from
role_menus
where
role_id = pRole_Id and `status` = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRoles` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spSelectRoles`(
)
BEGIN
Select * from Roles where role_id!='ADMINISTRATOR' and `status`='ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRole_Db_Privileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRole_Db_Privileges`(
pRole_Id      varchar(100)
)
BEGIN
select DBPRIVILEGES 
from
role_db_privileges
where
role_id = pRole_Id and `status` = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRole_Table_Privileges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRole_Table_Privileges`(
pRole_Id      varchar(100)
)
BEGIN
select table_name, tableprivileges, columnprivileges 
from
role_table_privileges
where
role_id = pRole_Id and `status` = 'ACTIVE';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRoomAmenities` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRoomAmenities`(
in proomid varchar(10),
in photelid int(5)
)
BEGIN
select roomamenities.amenityid,amenities.name
from roomamenities,amenities
where roomamenities.amenityid = amenities.amenityid and roomamenities.roomid = proomid
and roomamenities.hotelid  = photelid AND roomamenities.stateflag <> 'DELETED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRoomByCleaningStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRoomByCleaningStatus`(
in pcleaningstatus varchar(11)
)
BEGIN
select rooms.roomid,
rooms.roomtypecode,rooms.stateflag,
rooms.cleaningstatus
from rooms
where rooms.stateflag <> 'deleted'
and rooms.cleaningstatus = pcleaningstatus;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRoomEvent` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRoomEvent`(
in pDate date,
in pEndDate date
)
BEGIN
set  sql_big_selects=1;
select 
if(roomevents.eventtype = 'ENGINEERING JOB',"",concat(Guests.Lastname," ", left(Guests.Firstname,1),".")) as Lastname ,roomevents.`eventdate`,roomevents.roomid ,roomevents.eventtype 
from roomevents force index(`primary`) left join folio force index(folioid) on roomevents.eventid = folio.folioid left join guests on guests.accountid = folio.accountid   
where  ( roomevents.eventdate between pDate and pEndDate ) 
And roomevents.eventtype<>'CHECKED OUT' And roomevents.eventtype<>'NO SHOW' and roomevents.eventtype<>'CANCELLED'
order by roomevents.eventid,roomevents.eventdate,roomevents.roomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRoomId` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRoomId`()
BEGIN
select rooms.roomid
from rooms where rooms.stateflag <> 'deleted'
order by rooms.roomid
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRoomIDByRoomType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRoomIDByRoomType`(
in proomtypecode varchar(50),
in photelid int(5)
)
BEGIN
select rooms.roomid
from rooms 
where rooms.stateflag <> 'DELETED' and 
rooms.roomtypecode = proomtypecode and 
rooms.hotelid = photelid
order by rooms.roomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRooms` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRooms`(
in photelid int(5)
)
BEGIN
select *
from rooms,roomtypes
where
rooms.roomtypecode = roomtypes.roomtypecode and
rooms.stateflag != 'DELETED' and 
rooms.hotelid = photelid and roomtypes.hotelid = photelid
order by roomid
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRoomTypes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRoomTypes`(
in photelid int(5)
)
BEGIN
select roomtypecode,
maxoccupants,
noofadult,
noofchild,
noofbeds,
sharetype
from roomtypes
where roomtypes.stateflag <> 'DELETED' and hotelid = photelid
order by roomtypes.roomtypecode
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRouteDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRouteDetails`(
pROUTE_ID varchar(10)
)
BEGIN
select SEQ_NO,`route detail`.OPERATION,DESCRIPTION,TIME_DURATION 
from `route detail`,operation 
WHERE 
`route detail`.OPERATION=operation.OPERATION and
ROUTE_ID=pROUTE_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectRouting` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectRouting`()
BEGIN
select * from Routing;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectStudentAccount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spSelectStudentAccount`(pStudID varchar(20))
BEGIN
select student_info.stud_id, concat(lastname,', ', firstname), credit_limit, 
total_credit, balance from student_student_info, student_studcharge_account
where student_info.stud_id=pStudID and student_info.stude_id=studcharge_account.stud_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectSummaryOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectSummaryOrders`()
BEGIN
select `order header`.order_id, 
fGetTotalAmountbyOrderID(`order header`.order_id) as amount,
fGetVatSalesbyOrderID(`order header`.order_id) as `vat sales`, 
fGetTaxbyOrderID(`order header`.order_id) as tax,
fGetServiceChargebyOrderID(`order header`.order_id) as `service charge`, payment.payment_type,
`order header`.customer_id,
concat(`hotelmgtsystem`.guests.lastname, ', ', `hotelmgtsystem`.guests.firstname) as `Guest Name`,
`hotelmgtsystem`.folioschedules.roomid
from `order header` left join `hotelmgtsystem`.folio
left join `hotelmgtsystem`.folioschedules on `hotelmgtsystem`.folio.folioid=`hotelmgtsystem`.folioschedules.folioid
on `order header`.customer_id=`hotelmgtsystem`.folio.folioid 
left join `hotelmgtsystem`.guests on `hotelmgtsystem`.folio.accountid=`hotelmgtsystem`.guests.accountid,
`order detail`, `group`, item, payment
where `order header`.order_id=`order detail`.order_id and `order detail`.item_id=item.item_id
and `order header`.order_id=payment.order_id and item.group_id=`group`.group_id and
payment.payment_type<>'account_employee'
group by `order header`.order_id;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectTransactionCodes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectTransactionCodes`(
in photelid int(5)
)
BEGIN
select * from transactioncode
where stateflag = 'ACTIVE' and hotelid = photelid
order by trancode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectTransactionTypes` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectTransactionTypes`(
in photelid int(5)
)
BEGIN
select * 
from 
TranTypes 
where stateflag = 'ACTIVE' and
hotelid = photelid
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectUnpaidOrders` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectUnpaidOrders`()
BEGIN
select 
`order header`.ORDER_ID,
`order header`.CUSTOMER_ID AS NAME,
`order header`.TOTAL_AMOUNT  as AMOUNT,
GetRemarks(`order header`.ORDER_ID) as REMARKS,
`employee`.NICKNAME,
`order header`.ASSIGNED_TIME,
`order history`.OPERATION,
`order history`.START_TIME,
`order header`.`STATUS`
from 
`order header`,
`order history`,
`customers`,
`employee`
where
`order header`.ORDER_ID=`order history`.ORDER_ID and
`order header`.ASSIGNED_TO=`employee`.EMPLOYEE_ID and
`order header`.ASSIGNED_TO !="" and
`order history`.END_TIME="00:00:00" and lcase(`order history`.DISPOSITION) !="STOP"	and `order header`.`balance`>0
group by `order header`.ORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectUserRoles` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectUserRoles`(
pUser_Id      varchar(100)
)
BEGIN
select USER_ROLES.USER_ID, ROLES.ROLE_ID, ROLES.DESCRIPTION
from
user_roles, ROLES
where
USER_ROLES.ROLE_ID = ROLES.ROLE_ID AND
USER_ROLES.`status` = 'ACTIVE' AND
ROLES.`STATUS` = 'ACTIVE' AND
USER_ROLES.USER_ID = pUser_Id ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectUsers` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectUsers`(
)
BEGIN
select
*
from users
where
stateflag <> 'DELETED';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSelectYesterdayRoomOccupancy` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSelectYesterdayRoomOccupancy`(
in pdate date
)
BEGIN
select 
rooms.roomid,
roomevents.chargeflag
from rooms 
left join roomevents on 
rooms.roomid = roomevents.roomid and 
roomevents.`eventdate`= pdate and 
(roomevents.eventtype = 'IN HOUSE' or roomevents.eventtype = 'CHECKED OUT')
order by rooms.roomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetActualArrival` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetActualArrival`(
pFolioID varchar(20),
pUpdatedby varchar(20),
pHotelid int(5)
)
BEGIN
Update folio set ArrivalDate = now(),
updatedby = pUpdatedby,
updatetime = now()
where folioid = pfolioID and 
hotelid = pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetChildFolioStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetChildFolioStatus`(
in pMasterFolio varchar(20),
in pStatus varchar(15),
in pHotelID int(5)
)
BEGIN
Update folio set `status`=pStatus where masterfolio=pMasterFolio and hotelID=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetChildFollioStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetChildFollioStatus`(
in pMasterFolio varchar(12),
in pStatus varchar(15)
)
BEGIN
Update folio set `status`=pStatus where masterfolio=pMasterFolio;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetEventType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetEventType`(
in pEventType varchar(20),
in pEventID varchar(20),
in pHOtelId int(5)
)
BEGIN
update Roomevents set eventtype=pEventType where EventID=pEventID and hotelID=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetFolioScheduleType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetFolioScheduleType`(
in pTYpe varchar(30),
in pFolioID varchar(12),
in pHOtelID int(5)
)
BEGIN
update FolioSchedules set `type`=pType where folioId=pFolioID and hotelID =pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetFolioTransactionStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetFolioTransactionStatus`(
in pfolioid varchar(12),
in ptrandate datetime,
in ptrancode varchar(5),
in pStatus varchar(10)
)
BEGIN
update foliotransactions set `status`=pStatus 
where folioid=pfolioid 	and transactiondate=ptrandate and transactioncode=ptrancode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetMasterFolio` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetMasterFolio`(
in pMasterFolio varchar(20),
in pFolioID varchar(20),
in pHotelID int(5)
)
BEGIN
Update folio set MasterFolio=pMasterFolio
where folioID=pFolioID and hotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetNoOfVisits` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetNoOfVisits`(
in pAccountId varchar(20)
)
BEGIN
update guests set noofvisits=noofvisits+1 where accountid=pAccountid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetOccupiedRoomsDirty` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetOccupiedRoomsDirty`(
in pHotelid int(5)
)
BEGIN
update 
rooms
set 
cleaningstatus = 'DIRTY'
where 
stateflag = 'OCCUPIED' and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetOrderDetailAsPrinted` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spSetOrderDetailAsPrinted`(
in pID bigint(20)
)
BEGIN
update `order detail` set IS_PRINTED = 1 where
id = pID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetPosted` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetPosted`(in pfolioid varchar(20),in pHOtelID int(5))
BEGIN
update foliotransactions set posttoledger = "1" 
where folioid=pfolioid  and hotelid=pHOtelID;
update folioledger set posttoledger="1" 
where folioid=pfolioid  and hotelid=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetRoomAsCharged` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetRoomAsCharged`(
in proomid varchar(10),
in pdate date,
in photelid int(5)
)
BEGIN
update roomevents
set
chargeflag = 1
where
eventtype='IN HOUSE'
and	`eventdate` = pDate
and	roomid = proomid and hotelid= photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetRoomCleaningStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetRoomCleaningStatus`(
in pRoomID varchar(10),
in pStateFlag varchar(20),
in pUpdatedby varchar(20),
in pHotelId int(5)
)
BEGIN
update rooms 
set 
cleaningStatus=pStateFlag,
updateTime = now(),
updatedby = pUpdatedby
where 	
roomid=pRoomID and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spSetRoomStateFlag` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spSetRoomStateFlag`(
in pRoomID varchar(10),
in pStateFlag varchar(20),
in pUpdatedby varchar(20),
in pHotelId int(5)
)
BEGIN
update rooms 
set 
stateflag=pStateFlag,
updateTime = now(),
updatedby = pUpdatedby
where 	
roomid=pRoomID and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spTakeOrder` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spTakeOrder`(
pORDER_ID varchar(15),
pOPERATION varchar(20),
pSTART_TIME datetime,
pWAIT_DURATION datetime,
pSTATUS varchar(30),
pSEQ_NO int(11),
pASSIGNED_TO varchar(30)
)
BEGIN
update `order header`
set
`STATUS`=pSTATUS,
SEQ_NO=pSEQ_NO
where
`order header`.ORDER_ID=pORDER_ID;
update `order history`
set
START_TIME=pSTART_TIME,
DISPOSITION='PROCEED',
ASSIGNED_TO=pASSIGNED_TO,
WAIT_DURATION=pWAIT_DURATION
where
`order history`.ORDER_ID=pORDER_ID and `order history`.OPERATION=pOPERATION
and DISPOSITION != 'STOP';
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spTransferFolioTransaction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spTransferFolioTransaction`(
in pFromFolioid varchar(20),
in pToFolioID varchar(20),
in proutecode varchar(100),
in ptrandate datetime,
in pHotelID int(5)
)
BEGIN
update foliotransactions 
set
folioid = pToFolioID,
routesequence = proutecode
where
transactiondate = ptrandate and
folioid = pFromfolioid and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateAmenity` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateAmenity`(
IN pamenityid varchar(20),
IN pname VARCHAR(50),
IN pdescription VARCHAR(50),
in photelid int(5),
in pupdatedBy varchar(50)
)
BEGIN
update amenities 
set 
name = pname,
description = pdescription,
updatetime = now(),
updatedby = pupdatedBy
where amenityid = pamenityid and hotelid = photelid; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateBike` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateBike`(
pBikeId      varchar(15),  
pPlateNo     varchar(30), 
pEngineNo    varchar(30),
pModel       varchar(30),
pMake        varchar(30),
pUpdatedBy   varchar(30)       
)
BEGIN
update bike 
set
PLATE_NO=pPlateNo,
ENGINE_NO=pEngineNo,
MODEL=pModel,
MAKE=pMake,
UPDATEDBY=pUpdatedBy,   
UPDATETIME=now()
where 
BIKE_ID=pBikeId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateBikeAssign` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateBikeAssign`(
pEMPLOYEE_ID  varchar(10),  
pBIKE_ID      varchar(10), 
pUPDATEDBY    varchar(30)
)
BEGIN
update bike_assign
set 
BIKE_ID=pBIKE_ID,
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
where 
EMPLOYEE_ID=pEMPLOYEE_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateButton` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateButton`(
pResto_ID    int(5),
pBUTTON_ID   varchar(20), 
pTYPE        varchar(50), 
pOBJECT      varchar(50), 
pUPDATEDBY   varchar(30) 
)
BEGIN
update button_setup
set
`TYPE`=pTYPE,
OBJECT=pOBJECT,
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
where
BUTTON_ID=pBUTTON_ID
and Resto_ID=pResto_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateCallCharge` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateCallCharge`(
in pCallNo int(4)
)
BEGIN
update callcharges
set PostedToFolio = 1
where
CallNo = pCallNo;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateCashier` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateCashier`(
pTerminalId          int(4),
pCashierId           varchar(10),
pShiftCode           varchar(10),
pOpeningbalance      double(12,2), 
pOpeningadjustment   double(12,2), 
pBeginningbalance    double(12,2), 
pChargeinamount      double(12,2), 
pCash     	     double(12,2), 
pCreditcard          double(12,2), 
pCheque              double(12,2), 
pOthers              double(12,2), 
pAdjustment          double(12,2),
pAmountRemitted	     double(12,2),
pNetamount           double(12,2),
pStatus              enum('OPEN','CLOSE'),
pUpatedBy            varchar(20),
pRemarks	     text,
pRestaurantId	int(5)
)
BEGIN
update `cashiers` 
set 
shiftCode = pShiftCode,
openingbalance = pOpeningbalance, 
openingadjustment = pOpeningadjustment, 
beginningbalance = pBeginningbalance, 
chargeinamount = pChargeinamount, 
cash = pCash, 
creditcard = pCreditcard, 
cheque = pCheque, 
others = pOthers, 
adjustment = pAdjustment, 
amountremitted = pAmountRemitted,
netamount =pNetamount, 
`STATUS` = pStatus,
UpdateTime = now(), 
UPDATEDBY = pUpatedBy,
Remarks = pRemarks
where
terminalid = pTerminalId and
cashierid = pCashierId and
restaurantid=pRestaurantId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateCashierCash` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateCashierCash`(
pCash double(12,2),
pTerminalid int(4),
pShiftCode varchar(10),
pRestaurantID	int(5)
)
BEGIN
UPDATE cashiers set cash= cash + pCash
where terminalid=pTerminalid and shiftcode=pShiftCode
and restaurantid=pRestaurantID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateCashierCreditCard` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateCashierCreditCard`(
pAmount double(12,2),
pTerminalid int(4),
pShiftCode varchar(10),
pRestoID	int(5)
)
BEGIN
UPDATE cashiers set creditcard = creditcard + pAmount
where terminalid=pTerminalid and shiftcode=pShiftCode
and restaurantid=pRestoID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateCompanyAccount` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateCompanyAccount`(
in `pcompanyid` varchar(20),       
in `pcompanycode` varchar(50),         
in `pcompanyname` varchar(150),
in `pcompanyurl` varchar(100),                  
in `pcontactperson` varchar(50),         
in `pdesignation` varchar(30),         
in `pstreet1` varchar(50),                 
in `pcity1` varchar(50),                   
in `pcountry1` varchar(30),                
in `pzip1` varchar(10),                    
in `pstreet2` varchar(50),                 
in `pcity2` varchar(30),                   
in `pcountry2` varchar(30) ,                
in `pzip2` varchar(10) ,                    
in `pstreet3` varchar(50) ,                 
in `pcity3` varchar(30) ,                   
in `pcountry3` varchar(30) ,                
in `pzip3` varchar(10) ,                    
in `pemail1` varchar(50) ,                  
in `pemail2` varchar(50) ,                  
in `pemail3` varchar(50) ,                  
in `pcontactnumber1` varchar(15) ,          
in `pcontactnumber2` varchar(15) ,          
in `pcontactnumber3` varchar(15) ,          
in `pcontacttype1` varchar(15) ,            
in `pcontacttype2` varchar(15) ,            
in `pcontacttype3` varchar(15),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update company 
set
`companycode` = `pcompanycode`,         
`companyname` = `pcompanyname`,
`companyurl` = `pcompanyurl`,                  
`contactperson` = `pcontactperson`,         
`designation` = `pdesignation`,          
`street1`  = `pstreet1` ,                 
`city1`  =`pcity1`,                   
`country1`  =`pcountry1` ,                
`zip1` = `pzip1` ,                    
`street2` = `pstreet2` ,                 
`city2` = `pcity2` ,                   
`country2` = `pcountry2` ,                
`zip2` = `pzip2` ,                    
`street3` = `pstreet3`,                 
`city3` = `pcity3` ,                   
`country3` = `pcountry3` ,                
`zip3` = `pzip3` ,                    
`email1` = `pemail1` ,                  
`email2` = `pemail2` ,                  
`email3` = `pemail3` ,                  
`contactnumber1` = `pcontactnumber1` ,          
`contactnumber2` = `pcontactnumber2` ,          
`contactnumber3` = `pcontactnumber3` ,          
`contacttype1` = `pcontacttype1` ,            
`contacttype2` = `pcontacttype2` ,            
`contacttype3` =`pcontacttype3`,
updatedby = pupdatedby,
updatetime = now()
where
`companyid` = `pcompanyid` and 
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateCompanyInfoFromFolio` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateCompanyInfoFromFolio`(
in `pcompanyid` varchar(20),       
in `pcompanycode` varchar(10),         
in `pcompanyname` varchar(150),
in `pcompanyurl` varchar(100),                  
in `pcontactperson` varchar(50),         
in `pdesignation` varchar(30),         
in `pstreet1` varchar(50),                 
in `pcity1` varchar(50),                   
in `pcountry1` varchar(30),                
in `pzip1` varchar(10),                    
in `pemail1` varchar(50) ,                                  
in `pcontactnumber1` varchar(15)           
)
BEGIN
update company 
set
`companycode` = `pcompanycode`,         
`companyname` = `pcompanyname`,
`companyurl` = `pcompanyurl`,                  
`contactperson` = `pcontactperson`,         
`designation` = `pdesignation`,          
`street1`  = `pstreet1` ,                 
`city1`  =`pcity1`,                   
`country1`  =`pcountry1` ,                
`zip1` = `pzip1` ,                                   
`email1` = `pemail1` ,                  
`contactnumber1` = `pcontactnumber1`           
where
`companyid` = `pcompanyid`;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateComplaint` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateComplaint`(
pCOMPLAINT_ID  bigint(15),
pCUSTOMER_ID   varchar(100),
pREASON_CODE   varchar(10),
pREMARKS       text,
pSTATUS        varchar(10),
pUPDATEDBY varchar(30)
)
BEGIN
update `complaints` 
set
CUSTOMER_ID = pCUSTOMER_ID, 
REASON_CODE = pREASON_CODE, 
REMARKS = pREMARKS, 
`STATUS` = pSTATUS,
UPDATEDBY = pUPDATEDBY, 
UPDATETIME = now()
where
COMPLAINT_ID = pCOMPLAINT_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateCurrencyCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateCurrencyCode`(
pcurrencycode    varchar(10),        
pcurrency        varchar(20),        
pconversionrate  decimal(12,2), 
pHotelId	int(5),   
pUPDATEDBY       varchar(20)   
)
BEGIN
UPDATE CurrencyCodes
SET
currency=pcurrency,
conversionrate=pconversionrate,
UPDATETIME=now(),
UPDATEDBY=pUPDATEDBY
Where 
currencycode=pcurrencycode AND HOTELID=pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateCustomer` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateCustomer`(
pCUSTOMER_ID     varchar(100), 
pCUSTOMER_TYPE   varchar(30), 
pNAME            varchar(100), 
pACCOUNT_NAME    varchar(100), 
pLAST_NAME       varchar(100), 
pFIRST_NAME      varchar(100), 
pPHONE_NO        varchar(100), 
pADDRESS1        text, 
pADDRESS2        text, 
pCITY            varchar(100), 
pPROVINCE        varchar(100), 
pPOSTAL_CODE     varchar(30), 
pCOUNTRY         varchar(100), 
pTAX_REG_NO      varchar(100), 
pTAXPAYER_ID     varchar(100), 
pTYPE            varchar(100), 
pCATEGORY        varchar(100), 
pCLASS           varchar(100), 
pUPDATEDBY       varchar(30)
)
BEGIN
update customerS set
CUSTOMER_TYPE = pCUSTOMER_TYPE, 
NAME = pNAME, 
ACCOUNT_NAME = pACCOUNT_NAME, 
LAST_NAME = pLAST_NAME, 
FIRST_NAME = pFIRST_NAME, 
PHONE_NO = pPHONE_NO, 
ADDRESS1 = pADDRESS1, 
ADDRESS2 = pADDRESS2, 
CITY = pCITY, 
PROVINCE = pPROVINCE, 
POSTAL_CODE = pPOSTAL_CODE, 
COUNTRY = pCOUNTRY, 
TAX_REG_NO = pTAX_REG_NO, 
TAXPAYER_ID = pTAXPAYER_ID, 
`TYPE` = pTYPE, 
CATEGORY = pCATEGORY, 
CLASS = pCLASS, 
UPDATEDBY = pUPDATEDBY,
UPDATETIME = NOW()
WHERE
CUSTOMER_ID = pCUSTOMER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateDepartment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateDepartment`(
in pDeptId      varchar(20),       
in pName        varchar(100),       
in pHotelId     int(5),         
in pUpdatedBy   varchar(30)  
)
BEGIN
Update department 
set
Name=pName,UpdatedBy=pUpdatedBy,UpdateTime=now() 
Where DeptId=pDeptId and HotelId=pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateEmployee` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateEmployee`(
pEMPLOYEE_ID  varchar(10),      
pLASTNAME     varchar(30),          
pFIRSTNAME    varchar(30),          
pMIDDLENAME   varchar(30), 
pNICKNAME     varchar(30),       
pPOSITION     varchar(20),         
pADDRESS      varchar(200),       
pCONTACTNO    varchar(20),         
pUPDATEDBY    varchar(30)
)
BEGIN
update employee 
set 
LASTNAME=pLASTNAME,           
FIRSTNAME=pFIRSTNAME,        
MIDDLENAME=pMIDDLENAME,
NICKNAME=pNICKNAME,
POSITION=pPOSITION,      
ADDRESS=pADDRESS,     
CONTACTNO=pCONTACTNO,           
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
where
EMPLOYEE_ID=pEMPLOYEE_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateEngineeringJob` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateEngineeringJob`(
in penggjobno varchar(20),
in penggserviceid varchar(20),
in passignedperson varchar(50),
in proomid varchar(10),
in pstartdate varchar(15),
in penddate varchar(15),
in pstarttime varchar(15),
in pendtime varchar(15),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update engineeringjobs
set
enggserviceid = penggserviceid,
assignedperson = passignedperson,
roomid = proomid,
startdate = pstartdate,
enddate = penddate,
starttime = pstarttime,
endtime = pendtime,
updatetime = now(),
updatedby = pupdatedby
where
enggjobno = penggjobno and
hotelid = photelid
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateEngineeringService` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateEngineeringService`(
in photelid int(5),
IN penggserviceid varchar(20), 
IN pservicename VARCHAR(50), 
IN pdescription VARCHAR(100),
in pupdatedby varchar(20)
)
BEGIN
update engineeringservices 
set 
servicename = pservicename,
description=pdescription,
updatetime = now(),
updatedby = pupdatedby
where enggserviceid = penggserviceid and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFloorLayoutImage` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFloorLayoutImage`(
in pFloorLayoutImage text,
in pFloor varchar(25),
in pHotelId int(5),
in pupdatedby varchar(20)
)
BEGIN
UPDATE floors
set
FloorLayoutImage = pFloorLayoutImage,
updatedby = pupdatedby,
updatetime = now()
where
`Floor` = pFloor
and HotelId = pHotelId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolio` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolio`(
in pHotelID int(5),      
in pFolioID varchar(20),              
in pAccountID varchar(20),   
in pEventID int(10),
in pFolioType varchar(25),    
in pGroupName varchar(100),      
in pAccountType  varchar(25),    
in pNoOfAdults int(2),    
in pNoOfCHild int(2),     
in pMasterFolio varchar(20),     
in pCompanyID varchar(20),      
in pAgentID varchar(20),       
in pSource varchar(50),     
in pFROMDATE datetime,  
in pTODATE datetime,    
in pARRIVALDATE datetime,
in pPACKAGEID varchar(20),    
in pCREATEDBY varchar(20),      
in pStatus varchar(15),
in pRemarks text
)
BEGIN
Update folio set       
AccountID=pAccountID,   
EventID=pEventID,
FolioType=pFolioType,    
GroupName=pGroupName,      
AccountType=pAccountType,    
NoOfAdults=pNoOfAdults,    
NoOfCHild=pNoOfCHild,     
MasterFolio=pMasterFolio,     
CompanyID=pCompanyID,      
AgentID=pAgentID,       
Source=pSource,     
FROMDATE=pFROMDATE,  
TODATE=pTODATE,    
ARRIVALDATE=pARRIVALDATE,    
PACKAGEID=pPACKAGEID,    
CREATETIME=now(),      
CREATEDBY=pCREATEDBY,      
UPDATETIME=now(),       
UPDATEDBY=pCREATEDBY,   
`Status`=pStatus,
Remarks=pRemarks
where folioID=pFolioID and hotelid=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolioBalance` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolioBalance`(in pFolioID varchar(12))
BEGIN
update folio set balance=totalcharges-totalPayments where folioid=pFolioID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolioLedger` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolioLedger`(
in pFolioId varchar(20),
in pSubFolio varchar(1),
in pAccountid varchar(20),
in pHotelid int(5),
in pUpdatedBy varchar(20)
)
BEGIN
update folioledger
set
accountid = pAccountid,
updatetime = now(),
updatedby = pUpdatedBy
where
hotelid = pHotelid and
folioid = pFolioId and
subFolio = pSubFolio;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolioLedgerCharges` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolioLedgerCharges`(
in pfolioid varchar(20),
in photelid int(5),
in psubfolio varchar(1),
in pcharges decimal(12,2),
in pdiscount decimal(12,2),
in pgovernmenttax decimal(12,2),
in plocaltax decimal(12,2),
in pservicecharge decimal(12,2),
in pupdatedby varchar(20)
)
BEGIN
update folioledger
set 
charges = charges + pcharges,
discount = discount + pdiscount,
governmenttax = governmenttax + pgovernmenttax,
localtax = localtax + plocaltax,
servicecharge = servicecharge + pservicecharge,
balancenet = balancenet + pcharges,
updatetime = now(),
updatedby = pupdatedby
where
folioid = pfolioid and
hotelid = photelid and
subfolio = psubfolio; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolioLedgerChargesVOID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolioLedgerChargesVOID`(
in pfolioid varchar(20),
in photelid int(5),
in psubfolio varchar(1),
in pcharges decimal(12,2),
in pdiscount decimal(12,2),
in pgovernmenttax decimal(12,2),
in plocaltax decimal(12,2),
in pservicecharge decimal(12,2),
in pupdatedby varchar(20)
)
BEGIN
update folioledger
set 
charges = charges - pcharges,
discount = discount - pdiscount,
governmenttax = governmenttax - pgovernmenttax,
localtax = localtax - plocaltax,
servicecharge = servicecharge - pservicecharge,
balancenet = balancenet - pcharges,
updatetime = now(),
updatedby = pupdatedby
where
folioid = pfolioid and
hotelid = photelid and
subfolio = psubfolio; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolioLedgerPayments` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolioLedgerPayments`(
in pfolioid varchar(20),
in photelid int(5),
in psubfolio varchar(1),
in pPayCash decimal(12,2),
in pPayCard decimal(12,2),
in pPayCheque decimal(12,2),
in pPaygiftCheque decimal(12,2),
in pbalanceforwarded decimal(12,2),
in pupdatedby varchar(20)
)
BEGIN
update folioledger
set 
paycash = paycash + pPayCash,
paycard = paycard + pPayCard,
paycheque = paycheque + pPayCheque,
paygiftcheque = PaygiftCheque + pPaygiftCheque,
balanceforwarded = balanceforwarded + pbalanceforwarded,
balancenet = balancenet - 
(pPayCash+pPayCard+pPayCheque+pPaygiftCheque+pbalanceforwarded),
updatetime = now(),
updatedby = pupdatedby
where
folioid = pfolioid and
hotelid = photelid and
subfolio = psubfolio; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolioLedgerPaymentsVOID` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolioLedgerPaymentsVOID`(
in pfolioid varchar(20),
in photelid int(5),
in psubfolio varchar(1),
in pPayCash decimal(12,2),
in pPayCard decimal(12,2),
in pPayCheque decimal(12,2),
in pPaygiftCheque decimal(12,2),
in pbalanceforwarded decimal(12,2),
in pupdatedby varchar(20)
)
BEGIN
update folioledger
set 
paycash = paycash - pPayCash,
paycard = paycard - pPayCard,
paycheque = paycheque - pPayCheque,
paygiftcheque = PaygiftCheque - pPaygiftCheque,
balanceforwarded = balanceforwarded - pbalanceforwarded,
balancenet = balancenet + 
(pPayCash+pPayCard+pPayCheque+pPaygiftCheque+pbalanceforwarded),
updatetime = now(),
updatedby = pupdatedby
where
folioid = pfolioid and
hotelid = photelid and
subfolio = psubfolio; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolioRateType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolioRateType`(in pRateType varchar(25))
BEGIN
update folio set rateType=pRateType where folioID=pFolioID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolioSchedules` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolioSchedules`(    
pFolioId     varchar(20),        
pRoomID      varchar(10),        
pRoomType    varchar(50),     
pFROMDATE    datetime,          
pTODATE      datetime,         
pDays        int(3),        
pRATETYPE    varchar(25),      
pRATE        decimal(12,2),       
pBREAKFAST   varchar(11),       
pUPDATEDBY   varchar(20),
pHotelID int(5)
)
BEGIN
update folioSchedules set 
RoomType=pRoomType,
fromDATE=pfromDATE,
TODATE=pTODATE,  
Days=pDays,   
RATETYPE=pRATETYPE,    
RATE=pRATE,       
BREAKFAST=pBREAKFAST,  
updatetime=now(),
UPDATEDBY=pUPDATEDBY   
where folioID=pFolioID and 
RoomID=pRoomID and 
hotelID =pHotelID and
fromDate = pFromDate and
toDate = pTodate;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolioStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolioStatus`(in pStatus varchar(15),in pFolioID varchar(20),in pHotelID int(5))
BEGIN
Update folio set `status`=pStatus where folioID=pFolioID and hotelID=pHOtelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFolioTransaction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFolioTransaction`(
in pHotelID int(5),   
in pFolioID varchar(20),      
in pSubFOlio varchar(1),       
in pAccountID varchar(20),        
in pTransactionDate datetime,        
in pTransactionCode varchar(20),        
in pReferenceNo varchar(20),        
in pMemo varchar(50),         
in pAcctSide varchar(10),      
in pCurrencyCode varchar(3),      
in pConversionRate decimal(12,4),         
in pCurrencyAmount decimal(12,2),      
in pBaseAmount decimal(12,2),       
in pDiscount decimal(12,2),        
in pServiceCharge decimal(12,2),        
in pGovernmentTax decimal(12,2),      
in pLocalTax decimal(12,2),         
in pNetBaseAmount decimal(12,2),       
in pRouteSequence  varchar(100),    
in pSourceFolio varchar(20),        
in pSourceSubFolio varchar(1),       
in pTerminalID varchar(10),         
in pStatus varchar(10),    
in pPostToLedger varchar(1),              
in pUPDATEDBY varchar(20)
)
BEGIN
update foliotransactions
set 
ReferenceNo=pReferenceNo,        
CurrencyCode=pCurrencyCode,      
ConversionRate=pConversionRate,         
CurrencyAmount=pCurrencyAmount,      
BaseAmount=pBaseAmount,       
Discount=pDiscount,        
ServiceCharge=pServiceCharge,        
GovernmentTax=pGovernmentTax,      
LocalTax=pLocalTax,         
NetBaseAmount=pNetBaseAmount,       
RouteSequence=pRouteSequence,    
SourceFolio=pSourceFolio,        
SourceSubFolio=pSourceSubFolio,       
TerminalID=pTerminalID,         
`Status`=pStatus,    
SubFOlio=pSubFOlio,       
AccountID=pAccountID,          
UPDATETIME=Now(),       
UPDATEDBY=pUPDATEDBY
where
folioid=pfolioid 
and
transactiondate=pTransactionDate
and
transactioncode=ptransactioncode and hotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateFunction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateFunction`(
pFUNCTION_ID  varchar(20),  
pDESCRIPTION  varchar(100), 
pOBJECT       varchar(20),  
pMETHOD       varchar(30),
pUPDATEDBY    varchar(30),
pCOST		DECIMAL(12,2)
)
BEGIN
update `function mapping`
set 
DESCRIPTION=pDESCRIPTION,
OBJECT=pOBJECT,
METHOD=pMETHOD,
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now(),
COST=pCOST
where
FUNCTION_ID=pFUNCTION_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateGroup`(
pGROUP_ID     varchar(20),
pMAINGROUP_ID VARCHAR(20),
pDESCRIPTION  varchar(100), 
pUPDATEDBY varchar(30),
pRESTOID	INT(5)
)
BEGIN
update `group` set
MAINGROUP_ID=pMAINGROUP_ID,
DESCRIPTION=pDESCRIPTION,
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
Where 
GROUP_ID=pGROUP_ID AND RESTO_ID=pRESTOID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateGuest` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateGuest`(
in paccountid varchar(20),
in paccountname varchar(20),
in ptitle varchar(5),
in plastname varchar(50),
in pfirstname varchar(50),
in pmiddlename varchar(50),
in psex varchar(6),
in pstreet varchar(100),
in pcity varchar(100),
in pcountry varchar(100),
in pzip varchar(10),
in pemailaddress varchar(100),
in pcitizenship varchar(100),
in ppassportid varchar(30),
in pTelephoneNo varchar(50),
in pMobileNo varchar(50),
in pFaxNo varchar(50),
in pguestImage text,
in pmemo text,
in pconcierge text,
in premarks text,
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update guests 
set 
`accountname` = `paccountname`,             
`title` = `ptitle` ,                   
`lastname` = `plastname`,                
`firstname` = `pfirstname`,               
`middlename` = `pmiddlename`,
sex = psex,
`street` = `pstreet`,                 
`city` = `pcity`,                   
`country` = `pcountry` ,                
`zip` = `pzip`,                    
`emailaddress` =`pemailaddress`,                                                        
`citizenship` = `pcitizenship` ,            
`passportid` = `ppassportid` ,              
`telephoneNo` = `pTelephoneNo` ,          
`mobileNo` = `pmobileNo` ,          
`faxNo` = `pfaxNo` ,          
`guestImage` = `pguestImage`,
memo = pmemo,
concierge = pconcierge,
remark = premarks,
updatetime = now(),
updatedby = pupdatedby
where
`accountid` = `paccountid` and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateHKParseFlag` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateHKParseFlag`(
pHkDate         date,    
proomid         varchar(10),    
phousekeeperid  varchar(10) ,     
pTime           time            
)
BEGIN
update hk_log 
set ParseFlag=1 
where
Hk_Date  = pHkDate and
roomid   = proomid and 
housekeeperid = phousekeeperid and
`Time`        = pTime;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateHotel` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateHotel`(
pHotelID     int(3),
pHotelName   varchar(100),
pNoOfFloors  int(5),      
pNoOfRooms   int(5),      
pUpdatedBy   varchar(20)
)
BEGIN
Update Hotel 
set
HotelName=pHotelName,
NoOfFloors=pNoOfFloors,
NoOfRooms=pNoOfRooms,
UpdatedBy=pUpdatedBy,
UpdateTime=now()
Where
HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateHouseKeeper` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateHouseKeeper`(
in photelid int(5),
IN phousekeeperid VARCHAR(20), 
IN plastname VARCHAR(50), 
IN pfirstname VARCHAR(50), 
IN pmiddlename VARCHAR(50),
in pupdatedby varchar(20)
)
BEGIN
update housekeepers
set 
lastname = plastname,
firstname = pfirstname,
middlename = pmiddlename,
updatetime = now(),
updatedby = pupdatedby
where housekeeperid = phousekeeperid and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateHouseKeepingJobDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateHouseKeepingJobDetail`(
in ptimestart varchar(8),
in ptimeend varchar(8),
in proomstatus varchar(15),
in phousekeepingjobno varchar(10),
in proomid varchar(10)
)
BEGIN
update housekeepingjobdetail
set 
timestart = ptimestart,
timeend = ptimeend,
roomstatus = proomstatus 
where 
housekeepingjobno = phousekeepingjobno and roomid = proomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateHouseKeepingLog` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateHouseKeepingLog`(IN pRoomId VARCHAR(10), IN pStatus VARCHAR(30), IN pHouseKeeperId VARCHAR(10), IN pStartTime VARCHAR(20), IN pEndTime VARCHAR(20), IN pDuration VARCHAR(20))
BEGIN
Update rooms
set
rooms.`cleaningstatus`=pStatus
WHERE
rooms.`roomid`=pRoomId;
Update hk_housekeepingjobs
set
starttime=pStartTime,
endtime=pEndTime,
elapsedtime=pDuration
where
hk_housekeepingjobs.`roomid`=pRoomId
and isFinished=0
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItem` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateItem`(
pITEM_ID varchar(20),
pGROUP_ID varchar(50),
pDESCRIPTION varchar(100),
pUNIT varchar(10),
pUNIT_COST DECIMAL(12,2),
pPRICE decimal(12,2),
pVAT DECIMAL(6,3),
pLOCAL_TAX DECIMAL(6,3),
pSERVICE_CHARGE DECIMAL(6,3),
pKITCHEN_DESIGNATION varchar(100),
pUpdatedBy varchar(30),
pAVAILABILITY tinyint(1)
)
BEGIN
update item set
GROUP_ID=pGROUP_ID,
DESCRIPTION=pDESCRIPTION,
UNIT=pUNIT,
UNIT_COST=pUNIT_COST,
SELLING_PRICE=pPRICE,
EVAT=pVAT,
LOCAL_TAX=pLOCAL_TAX,
SERVICE_CHARGE=pSERVICE_CHARGE,
KITCHEN_DESIGNATION = pKITCHEN_DESIGNATION,
UpdatedBy=pUpdatedBy,
UpdateTime=now(),
AVAILABILITY = pAVAILABILITY
Where 
ITEM_ID=pITEM_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateItemAvailability` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateItemAvailability`(
pRESTO_ID int(4),
pITEM_ID int(10),
pAVAILABILITY tinyint(1),
pUPDATEDBY varchar(50)
)
BEGIN
update `item` 
set 
AVAILABILITY = pAVAILABILITY,
UPDATETIME = now(),
UPDATEDBY = pUPDATEDBY
where
ITEM_ID = pITEM_ID and 
RESTO_ID = pRESTO_ID and
AVAILABILITY != pAVAILABILITY;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateLog` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateLog`(
in pCallNumber int(11)
)
BEGIN
update `callmgtsystem`.`log` 
set PostFlag = 1
where
CallNumber = pCallNumber;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateMainGroup` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateMainGroup`(
pMAINGROUP_ID VARCHAR(20),
pDESCRIPTION  varchar(100), 
pUPDATEDBY varchar(30)
)
BEGIN
update `main_item_group` set
DESCRIPTION=pDESCRIPTION,
UPDATEDBY=pUPDATEDBY,
UPDATEdTIME=now()
Where 
ID=pMAINGROUP_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateMenu`(
pMENU_ID       varchar(10),       
pDESCRIPTION  varchar(100),   
pVAT	 	decimal(2,2),
pPRICE		decimal(12,2),
pPICTURE	varchar(200),     
pUPDATEDBY     varchar(30),
pSERVICECHARGE	decimal(12,2)
)
BEGIN
update menu
set 
DESCRIPTION=pDESCRIPTION,
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now(),
VAT=pVAT,
PRICE=pPrice,
PICTURE=pPICTURE,
SERVICE_CHARGE=pSERVICECHARGE
where 
MENU_ID=pMENU_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateMenuRole` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateMenuRole`(
pRoleName    varchar(30),  
pMenu        varchar(50), 
pEnable      tinyint(4),  
pC           tinyint(4), 
pU           tinyint(4),  
pD           tinyint(4), 
pHotelId     int(5)    
)
BEGIN
Update rolemenu 
set 
`Enable`  =pEnable  ,
C   =pC,
U   =pU,
D   =pD
Where RoleName=pRoleName and HotelId=pHotelId and Menu =pMenu;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateMySqlUser` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateMySqlUser`(
pUser                   char(16), 
pPassword               char(41), 
pSelect_priv            enum('N','Y'), 
pInsert_priv            enum('N','Y'), 
pUpdate_priv            enum('N','Y'), 
pDelete_priv            enum('N','Y'), 
pCreate_priv            enum('N','Y'), 
pDrop_priv              enum('N','Y'), 
pReload_priv            enum('N','Y'), 
pShutdown_priv          enum('N','Y'), 
pProcess_priv           enum('N','Y'), 
pFile_priv              enum('N','Y'), 
pGrant_priv             enum('N','Y'), 
pReferences_priv        enum('N','Y'), 
pIndex_priv             enum('N','Y'), 
pAlter_priv             enum('N','Y'), 
pShow_db_priv           enum('N','Y'), 
pSuper_priv             enum('N','Y'), 
pCreate_tmp_table_priv  enum('N','Y'), 
pLock_tables_priv       enum('N','Y'),
pExecute_priv           enum('N','Y'), 
pRepl_slave_priv        enum('N','Y'), 
pRepl_client_priv       enum('N','Y'), 
pCreate_view_priv       enum('N','Y'), 
pShow_view_priv         enum('N','Y'), 
pCreate_routine_priv    enum('N','Y'), 
pAlter_routine_priv     enum('N','Y'), 
pCreate_user_priv       enum('N','Y')
)
BEGIN
update `mysql`.`user`
set
`Password` = Password(pPassword), 
Select_priv = pSelect_priv, 
Insert_priv = pInsert_priv, 
Update_priv = pUpdate_priv, 
Delete_priv = pDelete_priv, 
Create_priv = pCreate_priv, 
Drop_priv = pDrop_priv, 
Reload_priv = pReload_priv, 
Shutdown_priv = pShutdown_priv, 
Process_priv = pProcess_priv, 
File_priv = pFile_priv, 
Grant_priv = pGrant_priv, 
References_priv = pReferences_priv, 
Index_priv = pIndex_priv, 
Alter_priv = pAlter_priv, 
Show_db_priv = pShow_db_priv, 
Super_priv = pSuper_priv, 
Create_tmp_table_priv = pCreate_tmp_table_priv, 
Lock_tables_priv = pLock_tables_priv, 
Execute_priv = pExecute_priv, 
Repl_slave_priv = pRepl_slave_priv, 
Repl_client_priv = pRepl_client_priv, 
Create_view_priv = pCreate_view_priv, 
Show_view_priv = pShow_view_priv, 
Create_routine_priv = pCreate_routine_priv, 
Alter_routine_priv = pAlter_routine_priv, 
Create_user_priv = pCreate_user_priv
where
`User` = pUser;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOperation` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateOperation`(
pOPERATION varchar(30), 
pDESCRIPTION    varchar(50),
pUPDATEDBY     varchar(30) 
)
BEGIN
update operation 
set
DESCRIPTION=pDESCRIPTION,
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
WHERE 
OPERATION=pOPERATION;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOrderAssignment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateOrderAssignment`(
pOrderID int(2),
pAssignedTo varchar(30),
pAssignedTime DATETIME,
pRouteID  varchar(10),
pStatus	varchar(15),
pCustomer varchar(100)
)
BEGIN
update `order header`
set assigned_time=pAssignedTime, assigned_To=passignedTo, route_id=pRouteID, `status`=pStatus, customer_id=pCustomer
where
`order header`.ORDER_ID=pOrderID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOrderDetail` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateOrderDetail`(
pID	     bigint(20),
pQUANTITY    decimal(12,2), 
pDiscount decimal(12,2),
pVAT	     decimal(12,2),
pAMOUNT      decimal(12,2), 
pSERVICE_CHARGE decimal(12,2),
pLOCAL_TAX   decimal(12,2),
pROUTE		tinyint(1),
pITEM_NOTES		text
)
BEGIN
update `order detail` 
set 
QUANTITY = pQUANTITY, 
Discount = pDiscount,
VAT = pVAT, 
AMOUNT = pAMOUNT, 
SERVICE_CHARGE = pSERVICE_CHARGE, 
LOCAL_TAX = pLOCAL_TAX,
ROUTE = pROUTE,
ITEM_NOTES = pITEM_NOTES
where
ID = pID and 
not(
QUANTITY = pQUANTITY and
VAT = pVAT and
AMOUNT = pAMOUNT and
SERVICE_CHARGE = pSERVICE_CHARGE and
ROUTE = pROUTE and
ITEM_NOTES = pITEM_NOTES);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOrderDetailForRouting` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateOrderDetailForRouting`(
pId		bigint(20),
pQtyServed  	int(4),
pSERVEDBY varchar(50)
)
BEGIN
update `order detail`
set 
`SERVED` = `SERVED` + pQtyServed,
SERVED_BY = concat(SERVED_BY , ",", pSERVEDBY),
operation_status = if(QUANTITY=SERVED,'FINISH',operation_status),
TIME_SERVED = now()
where
id = pId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOrderDetailOperationStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateOrderDetailOperationStatus`(
pID	bigint(20),
pOPERATION_STATUS  enum('NEW','ASSEMBLING','CHANGED','FINISH','CANCELLED'),
pUPDATEBY varchar(30)
)
BEGIN
update `order detail` 
set operation_status = pOPERATION_STATUS,
UPDATEBY = pUPDATEBY,
UPDATETIME = now()
where 
ID = pID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOrderHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateOrderHeader`(
pORDER_ID          bigint(15), 
pCUSTOMER_ID	 varchar(20),
pTOTAL_LINE_ITEMS  int(11), 
pTOTAL_AMOUNT      decimal(12,2),
pTOTAL_DISCOUNT decimal(12,2),
pVAT_SALES	decimal(12,2),
pVAT_AMOUNT	decimal(12,2),
pNONVAT_SALES	decimal(12,2),
pSERVICE_CHARGE	decimal(12,2),
pLOCAL_TAX	decimal(12,2),
pROOMSERVICE_CHARGE	decimal(12,2),
pEMPLOYEE_ID	varchar(15)
)
BEGIN
update `order header` set 
CUSTOMER_ID=pCUSTOMER_ID,
TOTAL_LINE_ITEMS=pTOTAL_LINE_ITEMS,
TOTAL_AMOUNT=pTOTAL_AMOUNT,	
TOTAL_DISCOUNT=pTOTAL_DISCOUNT,	
TOTAL_PAYMENT = 0, BALANCE = pToTAL_AMOUNT,
VAT_SALES=pVAT_SALES, VAT_AMOUNT=pVAT_AMOUNT,
NONVAT_SALES=pNONVAT_SALES, SERVICE_CHARGE=pSERVICE_CHARGE,
LOCAL_TAX = pLOCAL_TAX,
ROOMSERVICE_CHARGE=pROOMSERVICE_CHARGE,
EMPLOYEE_ID=pEMPLOYEE_ID
WHERE ORDER_ID=pORDER_ID;
delete from payment where ORDER_ID = pORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOrderHeaderBalance` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateOrderHeaderBalance`(
pORDER_ID          bigint(15),  
pAMOUNT		decimal(12,2)
)
BEGIN
if(select total_payment from `order header` where order_id=pORDER_ID)=(select balance from `order header` WHERE order_id=pORDER_ID) then
update `order header` set total_payment=0.00 where `order header`.order_id=pOrder_id;
end if;
update `order header`
set
TOTAL_PAYMENT = TOTAL_PAYMENT+ pAMOUNT,
BALANCE=TOTAL_AMOUNT - TOTAL_PAYMENT
where 
ORDER_ID =pORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOrderHeaderSeqNo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateOrderHeaderSeqNo`(
pORDER_ID varchar(20),
pSEQ_NO int(11)
)
BEGIN
update `order header`
set
SEQ_NO=pSEQ_NO
where 
ORDER_ID=pORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOrderHistory` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateOrderHistory`(
pOrderID	bigint(15),
pOperation	varchar(25),
pDisposition	varchar(15))
BEGIN
update `order history`
set operation=pOperation,
disposition=pDisposition
where order_id=pOrderID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOrderHistoryEndTime` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateOrderHistoryEndTime`(
porder_id int(11)
)
BEGIN
if(GetLastRouteOperation(porder_id)="NEWORDER") then
update `order history` 
set end_time = time(now()), wait_duration=timediff(time(now()),start_time) 
where id = fGetLastIDInOrderHistory(porder_id);
elseif(GetLastRouteOperation(porder_id)="ASSEMBLING") then
update `order history` 
set end_time = time(now()), service_duration=timediff(time(now()),start_time) 
where id = fGetLastIDInOrderHistory(porder_id);
end if;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateOrderStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateOrderStatus`(
pSTATUS varchar(30),
pORDER_ID int(10)	
)
BEGIN
update `order header` 
set 
`STATUS`=pSTATUS
where ORDER_ID = pORDER_ID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePackageDetails` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdatePackageDetails`(
pPackageID        varchar(20), 
pTransactionCode  varchar(20),   
pBasis            varchar(1),        
pPercentOff       decimal(2,2),   
pAmountOff        decimal(12,2),   
pHotelID          int(5),        
pUpdatedBy        varchar(20)  
)
BEGIN
UPDATE PackageDetails 
SET 
TransactionCode=pTransactionCode,
Basis=pBasis,
percentOff=pPercentOff,
AmountOff=pAmountOff,
UpdatedBy=pUpdatedBy,
UpdateTime=now()
WHERE
PackageID=pPackageID AND HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePackageHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdatePackageHeader`(
pPackageID    varchar(20),        
pDescription  varchar(100),          
pFromDate     datetime,           
pToDate       datetime,            
pDaysApplied  varchar(50),           
pHotelID      int(5),          
pUpdatedBy    varchar(50) 
)
BEGIN
UPDATE PackageHeader 
SET 
Description=pDescription,
FromDate=pFromDate,
ToDate=pToDate,
DaysApplied=pDaysApplied,
UpdateTime =now(),
UpdatedBy=pUpdatedBy
WHERE
PackageID=pPackageID AND HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePrivilegeHeader` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdatePrivilegeHeader`(
pPrivilegeID    varchar(20),        
pDescription  varchar(100),          
pFromDate     datetime,           
pToDate       datetime,            
pDaysApplied  varchar(50),           
pHotelID      int(5),          
pUpdatedBy    varchar(50) 
)
BEGIN
UPDATE privilegeheader 
SET 
Description=pDescription,
FromDate=pFromDate,
ToDate=pToDate,
DaysApplied=pDaysApplied,
UpdateTime =now(),
UpdatedBy=pUpdatedBy
WHERE
PrivilegeID=pPrivilegeID AND HotelID=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdatePromo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdatePromo`(
in ppromoname varchar(20), in ppercentoff int,
in pstartdate date, in penddate date,
in ppromocode int
)
BEGIN
update promos
set	promoname = ppromoname,
percentoff = ppercentoff,
startdate = pstartdate,
enddate = penddate
where promocode = ppromocode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRateCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRateCode`(
in pratecode varchar(10),
in pdescription varchar(30),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update ratecodes
set 
description = pdescription,
updatetime = now(),
updatedby = pupdatedby
where ratecode = pratecode and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRateType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRateType`(	
in proomtypecode varchar(50),
in pratecode varchar(50),
in prateamount double(13,2),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update ratetypes
set	
rateamount = prateamount,
updatedby = pupdatedby,
updatetime = now()
where 
roomtypecode = proomtypecode and
ratecode = pratecode and
hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRestaurant` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRestaurant`(
pRestaurantId  varchar(10), 
pDescription   varchar(100), 
pAreaCode      varchar(10), 
pTelephoneNo   varchar(30), 
pAddress       text, 
pUpdatedby     varchar(30)
)
BEGIN
update `restaurants` 
set	
Description = pDescription, 
AreaCode = pAreaCode, 
TelephoneNo = pTelephoneNo, 
Address = pAddress,
UpdatedBy = pUpdatedBy,
UpdateTime = now()
where
RestaurantId = pRestaurantId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRole` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRole`(
pROLE_ID       varchar(100),
pDESCRIPTION   varchar(150), 
pUpdatedBy     varchar(30)	
)
BEGIN
update `roles`
set
DESCRIPTION = pDESCRIPTION, 
UPDATEDBY = pUpdatedBy, 
UPDATETIME = now()
where
ROLE_ID = pROLE_ID; 
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoom` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRoom`(
in proomid varchar(10),
in photelid int(5),
in proomtypecode varchar(20),
in pfloor int(4),
in pwindows tinyint(1),
in pdirfacing varchar(10),
in padjleft varchar(10),
in padjright varchar(10),
in proomimage varchar(80),
in psmokingtype tinyint(1),
in ptelephoneNo varchar(15),
in pupdatedby varchar(20)
)
BEGIN
update rooms 
set 	
roomtypecode = proomtypecode,
`floor` = pfloor,
windows = pwindows,
dirfacing = pdirfacing,
adjleft = padjleft,
adjright = padjright,
roomimage = proomimage,
smokingtype = psmokingtype,
telephoneNo = pTelephoneNo,
updatetime = now(),
updatedby = pupdatedby
where roomid = proomid and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoomCleaningStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRoomCleaningStatus`(
in pcleaningstatus varchar(11), in proomid int
)
BEGIN
update rooms set rooms.cleaningstatus = pcleaningstatus
where rooms.roomid = proomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoomCoordinates` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRoomCoordinates`(
in proomid varchar(10),
in pxcoordinate int(5),
in pycoordinate int(5),
in photelid int(5)
)
BEGIN
update rooms
set
xcoordinate = pxcoordinate,
ycoordinate = pycoordinate
where
rooms.roomid = proomid and
rooms.hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoomEvents` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRoomEvents`(
in pEventType varchar(20),
in pFolioID varchar(20),
in pRoomID varchar(10),
in pHotelID int(5),
in pUpdatedBy varchar(40)
)
BEGIN
update Roomevents set eventtype=pEventType,updatedby=pUpdatedBy,updatetime=now()
where EventId = pFolioID and 
roomid=pRoomID and
Hotelid = pHotelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoomEventsRate` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRoomEventsRate`(
in pFolioId varchar(20),
in pRoomId varchar(10),
in pDateTo date,
in pRoomRate double(12,2),
in pUpdatedBy varchar(20),
in pHotelId int(5)
)
BEGIN
update roomevents
set
RoomRate = pRoomRate,
Updatedby = pUpdatedBy,
UpdateTime = now()	
where
EventId = pFolioId and
RoomId = pRoomId and
EventDate <= pDateTo and
HotelId = pHotelId and
ChargeFlag = '0' and
eventType  <> "CHECKED OUT";
end */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoomRate` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRoomRate`(
in pHotelID int(5),
in pFrom date,
in pTo date,
in pEventID varchar(20),
in pRoomID varchar (20),
in pRoomRate decimal(12,2) 
)
BEGIN
Update RoomEvents set RoomRate = pRoomRate
where RoomID = pRoomID and EventID=pEventID and 
HotelID=pHotelID and 
(date(Eventdate)>=pFrom and date(EventDate)<=pTo);
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoomStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRoomStatus`(
in pstateflag varchar(20),
in proomid varchar(10)
)
BEGIN
update rooms
set
stateflag = pstateflag 	
where
roomid = proomid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoomType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRoomType`(
in proomtypecode varchar(20),
in pmaxoccupants int(2),
in pnoofbeds int(2),
in pnoofadult int(2),
in pnoofchild int(2), 
in psharetype varchar(15),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update roomtypes
set	
maxoccupants = pmaxoccupants,
noofadult = pnoofadult,
noofchild = pnoofchild,
noofbeds = pnoofbeds,
sharetype = psharetype,
updatedby = pupdatedby,
updatetime = now()
where roomtypecode = proomtypecode and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateRoute` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateRoute`(
pROUTEID      varchar(10),      
pDESCRIPTION  varchar(100),       
pTOTAL_TIME   varchar(20),        
pDEFAULT      tinyint(4),        
pUPDATEDBY    varchar(30)  
)
BEGIN
update `route header`
set
DESCRIPTION=pDESCRIPTION,
TOTAL_TIME=pTOTAL_TIME,
`DEFAULT`=pDEFAULT,
UPDATEDBY=pUPDATEDBY,
UPDATETIME=now()
where
ROUTE_ID=pROUTEID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateSystemMenu` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateSystemMenu`(
pMENU_NAME    varchar(30), 
pDESCRIPTION  text, 
pUPDATEDBY    varchar(30)
)
BEGIN
update systemmenus
set
DESCRIPTION = pDESCRIPTION, 
UPDATEDBY = pUPDATEDBY, 
UPDATETIME = NOW()
WHERE
MENU_NAME = pMENU_NAME;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTableNo` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateTableNo`(
pOrderId int(10),
pTableNo varchar(10)
)
BEGIN
update `order header` set table_no=pTableNo where `order header`.order_id=pOrderId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTableStatus` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateTableStatus`(
pTableNo varchar(10),
pStatus varchar(30)
)
BEGIN
update table_assignment set `status`=pStatus where table_no=pTableNo;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTotalNetAgentComm` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateTotalNetAgentComm`(
in pHotelID int(5),
in pFolioID varchar(20),
in pSubFolio varchar(1),
in pCommission decimal(12,2),
in pTotalNet decimal(12,2)
)
BEGIN
Update folioledger set AgentCommission = AgentCommission + pCommission,TotalNet =TotalNet+pTotalNet
where Folioid=pFolioID and subfolio = pSubFolio and Hotelid=pHotelID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTradingArea` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateTradingArea`(
pArea_Code  varchar(10), 
pDescription     varchar(100),
pUpdatedBy varchar(30)
)
BEGIN
update tradingareas
set
Description = pDescription,
UpdatedBy = pUpdatedby,
updateTime = now()
where
Area_Code = pArea_Code;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTransactionCode` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateTransactionCode`(
in ptrancode varchar(20),
in ptrantypeid varchar(20),
in pacctgroupid int(5),
in pmemo varchar(100),
in pacctside varchar(10),
in paccountno varchar(10),
in pservicecharge double(12,2),
in pgovttax double(12,2),
in plocaltax double(12,2),
in pdefaultamount double(12,2),
in pwarningamount double(12,2),
in pDepartmentId varchar(20),
in psystem varchar(20),
in pbaseamount double(9,2),
in pledger varchar(20),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update transactioncode
set
trantypeid = ptrantypeid,
acctgroupid = pacctgroupid,
memo = pmemo,
acctside = pacctside,
accountno = paccountno,
servicecharge = pservicecharge,
govttax = pgovttax,
localtax = plocaltax,
defaultamount = pdefaultamount,
warningamount = pwarningamount,
deptid = pdepartmentid,
system = psystem,
baseamount = pbaseamount,
ledger = pledger,
updatedby = pupdatedby,
updatetime = now()
where
trancode = ptrancode and hotelid = photelid
;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateTranType` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateTranType`(
in ptrantypeid varchar(2),
in ptrantype varchar(50),
in pacctgroup varchar(20),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update trantypes
set
trantype = ptrantype,
acctgroup = pacctgroup,
updatetime = now(),
updatedby = pupdatedby
where
trantypeid = ptrantypeid 
and hotelid = photelid;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateUser` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spUpdateUser`(
pUserId        varchar(30), 
pLastName      varchar(50), 
pFirstName     varchar(50), 
pMiddleName    varchar(50), 
pDepartment    varchar(50), 
pDesignation   varchar(30), 
pPassword text,
pUpdatedBy     varchar(30)
)
BEGIN
update `users` 
set
LastName = pLastName, 
FirstName = pFirstName, 
MiddleName = pMiddleName, 
Department = pDepartment, 
Designation = pDesignation, 
UpdatedBy = pUpdatedBy, 
UpdateTime = now()
where
UserId = pUserId;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spUpdateUserPassword` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spUpdateUserPassword`(
in pUserID varchar(50),
in pPassword varchar(50)
)
BEGIN
update users
set `password` = md5(pPassword)
where userId = pUserID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spVerifyLogin` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spVerifyLogin`(
in puserid varchar(20),
in `ppassword` varchar(20)
)
BEGIN
select 
UserId,
md5(ppassword),
EmployeeIdNo,
LastName,
FirstName,
Department,
Designation,
Stateflag,
HotelId   
from users
where
userid = puserid
and	`Password` = md5(ppassword) ;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spVoidFolioTransaction` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`%`*/ /*!50003 PROCEDURE `spVoidFolioTransaction`(
in photelid int(5),
in pfolioid varchar(20),
in psubfolio varchar(1),
in paccountid varchar(20),
in ptrandate datetime,
in ptrancode varchar(20),
in pupdatedby varchar(20)
)
BEGIN
update foliotransactions
set 
`status` = 'VOID',
updatedby = pupdatedby,
updatetime = now()
where
hotelid = photelid and
folioid = pfolioid and
subfolio = psubfolio and
accountid = paccountid and
transactiondate = ptrandate and
transactioncode = ptrancode;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spVoidOrderPayment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spVoidOrderPayment`(pORDERID int(10),
pAMOUNT decimal(12,2))
BEGIN
update `order header` set balance=pAMOUNT, total_payment=0.00,
`status`='PREPARED' where order_id=pORDERID;
END */;;
/*!50003 SET SESSION SQL_MODE=@OLD_SQL_MODE*/;;
/*!50003 DROP PROCEDURE IF EXISTS `spVoidPayment` */;;
/*!50003 SET SESSION SQL_MODE="STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER"*/;;
/*!50003 CREATE*/ /*!50020 DEFINER=`root`@`localhost`*/ /*!50003 PROCEDURE `spVoidPayment`(
pORDER_ID int(10))
BEGIN
update payment set `status`='VOID' where order_id=pORDER_ID;
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

-- Dump completed on 2010-10-13 10:29:20
