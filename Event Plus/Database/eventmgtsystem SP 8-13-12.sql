/*
SQLyog Enterprise - MySQL GUI v7.02 
MySQL - 5.0.27-community-nt : Database - eventmgtsystem
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

USE `eventmgtsystem`;

/* Procedure structure for procedure `getRoomReservationStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `getRoomReservationStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `getRoomReservationStatus`(
in pHotelId int(4),
in pRoomId varchar(50),
in pDate date
)
BEGIN
select eventType from roomevents
where roomid = pRoomId and hotelid = pHotelId
and date(eventDate)=pDate and 
(eventtype='RESERVATION' or eventtype = 'ENGINEERING JOB')
union all
select 'BLOCKED' as eventType from blockingdetails
where roomid=pRoomId and pDate between date(blockfrom) and date(blockto)
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `GetTranCodeAccountSide` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetTranCodeAccountSide` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetTranCodeAccountSide`(
in ptrancode varchar(20),
in photelid int(5)
)
BEGIN
select acctside from transactioncode
where
trancode = ptrancode and
hotelid = photelid and 
stateflag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `pSelectAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `pSelectAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `pSelectAccount`(
pHotelId int(5)
)
BEGIN
Select accountid,lastname,firstname from guests
Where HotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spAcknowledgeShiftEndorsement` */

/*!50003 DROP PROCEDURE IF EXISTS  `spAcknowledgeShiftEndorsement` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spAcknowledgeShiftEndorsement`(
pId                  int(10),
pEndorsementRemarks  text,
pAcknowledgedBy      varchar(50),
pAcknowledgeAtTerminal varchar(10),
pAcknowledgeAtShiftCode varchar(10)
)
BEGIN
update shiftendorsements set
statusFlag = 'ACKNOWLEDGED',
updateTime = now(),
endorsementRemarks = pEndorsementRemarks,
acknowledgedBy = pAcknowledgedBy,
acknowledgeAtTerminal = pAcknowledgeAtTerminal,
acknowledgeAtShiftCode = pAcknowledgeAtShiftCode
where
id = pId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spActivateRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `spActivateRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spActivateRoom`(proomid varchar(10),pupdatedby varchar(20),photelid int(5))
BEGIN
update rooms set stateflag = 'VACANT',updatetime = now(),updatedby = pupdatedby where roomid = proomid and hotelid = photelid;  
END */$$
DELIMITER ;

/* Procedure structure for procedure `spAddRoomAmenity` */

/*!50003 DROP PROCEDURE IF EXISTS  `spAddRoomAmenity` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spAddRoomAmenity`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spArrivalsView` */

/*!50003 DROP PROCEDURE IF EXISTS  `spArrivalsView` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spArrivalsView`()
BEGIN
select distinct folioid from folioschedules 
where 
departuredate = now();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spAuthenticateUser` */

/*!50003 DROP PROCEDURE IF EXISTS  `spAuthenticateUser` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spAuthenticateUser`(
in pUserId varchar(20),
in pPassword text
)
BEGIN
Select 
HotelId 
from 
users force index(primary)
WHERE 
userid = pUserId and `password` = md5(pPassword) and stateflag!='DELETED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spBanquetFoodBevRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spBanquetFoodBevRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spBanquetFoodBevRequirements`(pFolioID varchar(35))
BEGIN
select event_meal_requirements.eventDate, event_meal_requirements.venue, event_meal_requirements.startTime, event_meal_requirements.endTime, event_meal_requirements.setup, event_meal_requirements.over, event_meal_requirements.remarks, event_meal_header.mealType, event_meal_details.description
from event_meal_requirements, event_meal_header, event_meal_details
where event_meal_requirements.folioid=pFolioID and event_meal_requirements.folioid=event_meal_header.folioid and event_meal_header.eventDate=event_meal_requirements.eventdate and event_meal_header.mealID=event_meal_details.mealID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCancelRoomEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCancelRoomEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spCancelRoomEvent`(
in pEventID varchar(20),
in pEventType varchar(30),
in pEventType1 varchar(30),
in pHotelId int(5)
)
BEGIN
Update Roomevents set EventType=pEventType1 where EventID=pEventID and EventType=pEventType and hotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spChangeFolioPackage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spChangeFolioPackage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spChangeFolioPackage`(
in pFolioID varchar(20),
in pHotelID int(5),
in pPackageID varchar(20)
)
BEGIN
Update Folio set packageID=pPackageID where folioID=pFOlioID and hotelID=pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spChangeUserPassword` */

/*!50003 DROP PROCEDURE IF EXISTS  `spChangeUserPassword` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spChangeUserPassword`(
in pUserId varchar(20),
in pPassword varchar(20)
)
BEGIN
update users
set       
`Password` = md5(pPassword)
where
userid = pUserId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCheckConflictRoomEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCheckConflictRoomEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spCheckConflictRoomEvents`( in pRoomid varchar(20),
in pEventDate date,
in pHotelID int(5),
in pFolioId varchar(20)
)
BEGIN
Select roomevents.eventno
from roomevents left join folio on folio.folioid = roomevents.eventid 
where
roomevents.roomid = proomid and
roomevents.Eventdate = pEventDate and
roomevents.eventid != pFolioId and
roomevents.hotelid = pHotelid and 
roomevents.transferflag != 1 and 
if(eventtype='ENGINEERING JOB', true, (folio.status!='CANCELLED' AND FOLIO.STATUS!='DELETED' AND FOLIO.STATUS!='REMOVED' AND FOLIO.STATUS!='NO SHOW' AND date(folio.departuredate)!=pEventDate and folio.status!='CLOSED'))
and
(if(roomevents.eventtype='ENGINEERING JOB', true, folio.foliotype != 'SHARE') );
end */$$
DELIMITER ;

/* Procedure structure for procedure `spCheckEventIfExists` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCheckEventIfExists` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spCheckEventIfExists`(
pFolioId varchar(30),
pAccountId varchar(30),
pHotelId int
)
BEGIN
select 1 from folio where folioID = pFolioId and companyID = pAccountId and hotelID = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCheckFunctionIsConflict` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCheckFunctionIsConflict` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spCheckFunctionIsConflict`(
pRoom varchar(30),
pDate date,
pTime time,
pFolioID varchar(30)
)
BEGIN
select 1 from folioschedules where roomid = pRoom and pDate between date(folioschedules.fromdate) and date(folioschedules.todate) and pTime between time(starttime) and time(endtime) and folioschedules.folioid != pFolioID and fGetFolioStatus(folioid) != 'CLOSED' and fGetFolioStatus(folioid)!='CANCELLED' and fGetFolioStatus(folioid)!='NO SHOW' and fGetFolioStatus(folioid)!='WAIT LIST'
union all
select 1 from roomevents left join engineeringjobs on engineeringjobs.enggjobno = roomevents.eventid where substring(roomevents.eventid,1,1) = 'E' and roomevents.eventdate = pDate and pTime between roomevents.startTime and roomevents.endTime and engineeringjobs.stateflag != 'DELETED' and roomevents.roomid = pRoom;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCheckIfGuestIsCheckedIn` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCheckIfGuestIsCheckedIn` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spCheckIfGuestIsCheckedIn`(in pAccountID varchar(20), in pHotelid int(5),
in pRoomNo varchar(10))
BEGIN
select count(folio.folioid) from folio, folioschedules where folio.accountid=pAccountID and folio.hotelid=pHotelID and folio.`status`='ONGOING' and folio.folioid=folioschedules.folioid and roomid!=pRoomNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCheckIfRoomIsBlock` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCheckIfRoomIsBlock` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spCheckIfRoomIsBlock`(
pRoomId varchar(10),
pDate date,
pFolioID varchar(20)
)
BEGIN
if(pFolioID!="") then
select rooms.roomid,
blockingdetails.blockfrom,
blockingdetails.blockto,
roomblock.folioid
from rooms,blockingdetails, roomblock
where
rooms.roomid=blockingdetails.roomid and
pDate between date(blockingdetails.blockfrom) and date(blockingdetails.blockto) and
rooms.roomid=pRoomId and blockingdetails.blockid=roomblock.blockid and roomblock.folioid!=pfolioid and date(blockingdetails.blockto)!=pDate;
else
select rooms.roomid,
blockingdetails.blockfrom,
blockingdetails.blockto,
roomblock.folioid
from rooms,blockingdetails, roomblock
where
rooms.roomid=blockingdetails.roomid and
pDate between date(blockingdetails.blockfrom) and date(blockingdetails.blockto) and
rooms.roomid=pRoomId and blockingdetails.blockid=roomblock.blockid and date(blockingdetails.blockto)!=pDate;
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCheckMealHeaderExists` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCheckMealHeaderExists` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spCheckMealHeaderExists`(pMealType varchar(30), pEventDate date, pFolioID varchar(20))
BEGIN
select * from event_meal_requirements where mealType=pMealType and date(eventDate)=pEventDate and folioID=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCloseCityLedgerAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCloseCityLedgerAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spCloseCityLedgerAccount`(
in pAccountId varchar(20),
in pHotelId int(5)
)
BEGIN
update cityledger 
set closed = '1' where
acctId = pAccountId and
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spClosePaymentLedgerAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spClosePaymentLedgerAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spClosePaymentLedgerAccount`()
BEGIN
update paymentledger
set 
closed = '1' 
where
acctId = pAcctId and
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCountGroupWaitList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCountGroupWaitList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spCountGroupWaitList`(pDate date)
BEGIN
select count(distinct event_rooms.folioid) as groupCount from event_rooms, folio where noOfRooms>blockedRooms and event_rooms.folioid=folio.folioid and (folio.status='TENTATIVE' or folio.status='CONFIRMED'or folio.status='WAIT LIST') and date(folio.fromDate)>=pDate and folio.foliotype='GROUP';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCountNoOfPax` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCountNoOfPax` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spCountNoOfPax`(
in pDate DateTime,
in pHotelId int(5),
in pFilter varchar(50)
)
BEGIN
if(pFilter = 'ALL')then
select roomtype, DateNow, sum(Pax) as Pax, sum(rooms) as rooms from
(select folioschedules.roomtype, pDate as DateNow,sum(folio.noofadults) as Pax, count(folio.folioid) as rooms
from folio,
folioschedules
where
folio.folioid = folioschedules.folioid and
folio.hotelid = folioschedules.hotelid and
folio.hotelid = pHotelId and
(folio.Status ='ONGOING' or folio.Status ='CONFIRMED' or folio.status='WAIT LIST' or folio.status='TENTATIVE') and
(pDate >= date(folioschedules.fromdate)
and pdate < date(folioschedules.todate)) and folioschedules.roomtype!='FUNCTION'
group by roomtype 
union
select rooms.roomtypecode as roomtype, pDate as DateNow, 0 as Pax, count(roomblock.folioid) as `rooms` from rooms, roomblock, blockingdetails where roomblock.blockid=blockingdetails.blockid and rooms.roomid=blockingdetails.roomid and roomblock.folioid!='' and pDate>=date(blockingdetails.blockfrom) and pDate<date(blockingdetails.blockto) and rooms.roomtypecode!='FUNCTION' group by roomtype) as paxTable group by roomtype;
elseif(pFilter = 'CONFIRMED WAIT LIST') THEN
select roomtype, DateNow, sum(Pax) as Pax, sum(rooms) as rooms from
(select folioschedules.roomtype, pDate as DateNow, sum(folio.noofadults) as Pax, count(folio.folioid) as rooms
from folio,
folioschedules
where
folio.folioid = folioschedules.folioid and
folio.hotelid = folioschedules.hotelid and
folio.hotelid = pHotelId and
(folio.status = 'WAIT LIST' or folio.Status ='CONFIRMED' or folio.status='TENTATIVE') and
(pDate >= date(folioschedules.fromdate)
and pdate < date(folioschedules.todate)) and folioschedules.roomtype!='FUNCTION'
group by roomtype
union
select rooms.roomtypecode as roomtype, pDate as DateNow, 0 as Pax, count(roomblock.folioid) as `rooms` from rooms, roomblock, blockingdetails where roomblock.blockid=blockingdetails.blockid and rooms.roomid=blockingdetails.roomid and roomblock.folioid!='' and pDate>=date(blockingdetails.blockfrom) and pDate<date(blockingdetails.blockto) and rooms.roomtypecode!='FUNCTION' group by roomtype) as paxTable group by roomtype;
elseif(pFilter = 'CONFIRMED ONGOING') THEN
select folioschedules.roomtype, pDate as DateNow,sum(folio.noofadults) as Pax, count(folio.folioid) as rooms
from folio,
folioschedules
where
folio.folioid = folioschedules.folioid and
folio.hotelid = folioschedules.hotelid and
folio.hotelid = pHotelId and
(folio.status = 'ONGOING' or folio.Status ='CONFIRMED' or folio.status='TENTATIVE') and
(pDate >= date(folioschedules.fromdate)
and pdate < date(folioschedules.todate)) and folioschedules.roomtype!='FUNCTION'
group by (folioschedules.roomtype);
elseif(pFilter = 'ONGOING WAIT LIST') THEN
select roomtype, DateNow, sum(Pax) as Pax, sum(rooms) as rooms from
(select folioschedules.roomtype, pDate as DateNow,sum(folio.noofadults) as Pax, count(folio.folioid) as rooms
from folio,
folioschedules
where
folio.folioid = folioschedules.folioid and
folio.hotelid = folioschedules.hotelid and
folio.hotelid = pHotelId and
(folio.status = 'WAIT LIST' or folio.Status ='ONGOING') and
(pDate >= date(folioschedules.fromdate)
and pdate < date(folioschedules.todate)) and folioschedules.roomtype!='FUNCTION'
group by roomtype 
union
select rooms.roomtypecode as roomtype, pDate as DateNow, 0 as Pax, count(roomblock.folioid) as `rooms` from rooms, roomblock, blockingdetails where roomblock.blockid=blockingdetails.blockid and rooms.roomid=blockingdetails.roomid and roomblock.folioid!='' and pDate>=date(blockingdetails.blockfrom) and pDate<date(blockingdetails.blockto) and rooms.roomtypecode!='FUNCTION' group by roomtype) as paxTable group by roomtype;
elseif(pFilter='CONFIRMED') then
select folioschedules.roomtype, pDate as DateNow,sum(folio.noofadults) as Pax, count(folio.folioid) as rooms
from folio,
folioschedules
where
folio.folioid = folioschedules.folioid and
folio.hotelid = folioschedules.hotelid and
folio.hotelid = pHotelId and
(folio.Status ='CONFIRMED' or folio.status='TENTATIVE') and
(pDate >= date(folioschedules.fromdate)
and pdate < date(folioschedules.todate)) and folioschedules.roomtype!='FUNCTION'
group by (folioschedules.roomtype);
elseif(pFilter='WAIT LIST') then
select roomtype, DateNow, sum(Pax) as Pax, sum(rooms) as rooms from
(select folioschedules.roomtype, pDate as DateNow,sum(folio.noofadults) as Pax, count(folio.folioid) as rooms
from folio,
folioschedules
where
folio.folioid = folioschedules.folioid and
folio.hotelid = folioschedules.hotelid and
folio.hotelid = pHotelId and
(folio.Status ='WAIT LIST') and
(pDate >= date(folioschedules.fromdate)
and pdate < date(folioschedules.todate)) and folioschedules.roomtype!='FUNCTION'
group by roomtype 
union 
select rooms.roomtypecode as roomtype, pDate as DateNow, 0 as Pax, count(roomblock.folioid) as `rooms` from rooms, roomblock, blockingdetails where roomblock.blockid=blockingdetails.blockid and rooms.roomid=blockingdetails.roomid and roomblock.folioid!='' and pDate>=date(blockingdetails.blockfrom) and pDate<date(blockingdetails.blockto) and rooms.roomtypecode!='FUNCTION' group by roomtype) as paxTable group by roomtype;
else
select folioschedules.roomtype, pDate as DateNow,sum(folio.noofadults) as Pax, count(folio.folioid) as rooms
from folio,
folioschedules
where
folio.folioid = folioschedules.folioid and
folio.hotelid = folioschedules.hotelid and
folio.hotelid = pHotelId and
folio.Status ='ONGOING' and
(pDate >= date(folioschedules.fromdate)
and pdate < date(folioschedules.todate)) AND folioschedules.roomtype!='FUNCTION'
group by (folioschedules.roomtype);
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCountOccupiedRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCountOccupiedRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spCountOccupiedRooms`(in pStartDate varchar(20),
in pHotelID int(3)
)
BEGIN
select distinct roomtypecode,count(roomtypecode) as OccupiedRooms,eventdate from rooms,roomevents 
where not (roomevents.eventtype='CLOSED' or roomevents.eventtype='CANCELLED' or roomevents.eventtype='NO SHOW' )  and roomevents.transferflag<>'1' and
roomevents.roomid = rooms.roomid  and rooms.HotelID=pHotelID and roomevents.eventdate >=pStartDate
group by roomtypecode,eventdate ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCountRefNoExistence` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCountRefNoExistence` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spCountRefNoExistence`(pTrancode varchar(40),
prefno varchar(20),
pHotelID int(3)
)
BEGIN
set  sql_big_selects=1;
select sum(transactioncode) from
(
select count(transactioncode) as transactionCode from folioTransactions force index (`primary`)
where transactionsource=pTrancode and (ReferenceNo=pRefno OR referenceNo=concat(pRefNo,'(VOID)')) and (`status`='ACTIVE' or `status`='VOID')
union
select count(transactioncode) as transactionCode from nonguesttransaction force index (`primary`)
where transactionsource=pTrancode and (ReferenceNo=pRefno OR referenceNo=concat(pRefNo,'(VOID)')) and (`statusflag`='ACTIVE' or `statusflag`='VOID')) as transactionTable;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spCountRoomTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spCountRoomTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spCountRoomTypes`(in pHotelID int(5))
BEGIN
select roomtypecode,count(roomtypecode) as vacant from rooms where 
HotelID=pHOtelID
group by roomtypecode ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeActivateSchedules` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeActivateSchedules` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeActivateSchedules`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
update folioschedules set `status` = 'DELETED' where folioId = pFolioID and HOTELID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeductCompanyXDealAmount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeductCompanyXDealAmount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeductCompanyXDealAmount`(
in pCompanyId varchar(20),
in pAmount double(12,2),
in pHotelId int(4)
)
BEGIN
update company
set X_DEAL_AMOUNT = X_DEAL_AMOUNT - pAmount
where companyId = pCompanyId
and hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteAccountPrivileges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteAccountPrivileges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteAccountPrivileges`(
in pAccountId varchar(20),
In pHotelId int(5)
)
BEGIN
DELETE from accountprivileges 
WHERE AccountId=pAccountId 
AND HotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteAgent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteAgent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteAgent`(
in pAgentID         int(10),
in pUPDATED_BY       varchar(50), 
in pHOTEL_ID         int(4)
)
BEGIN
delete from agents where 
agentID = pAgentID and
HOTEL_ID = pHOTEL_ID
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteAllFolioRoomEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteAllFolioRoomEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteAllFolioRoomEvents`(
in pFolioId varchar(20),
in pHotelId int(4)
)
BEGIN
delete from 
roomevents
where
EventID = pFolioId and
HOTELID = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteAllFolioRouting` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteAllFolioRouting` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteAllFolioRouting`(
in pHotelId int(5),
in pFolioId varchar(20)
)
BEGIN
Delete from foliorouting where folioId=pFolioId and hotelId=pHOtelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteAllPackageDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteAllPackageDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteAllPackageDetails`(
in pPackageId varchar(20),
in pHotelId int(5)
)
BEGIN
DELETE FROM packagedetails WHERE packageID=pPackageId and HotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteAllPrivilegeDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteAllPrivilegeDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteAllPrivilegeDetails`(
in pPrivilegeId varchar(20),
in pHotelId int(5)
)
BEGIN
DELETE FROM privilegedetails WHERE PrivilegeID=pPrivilegeId and HotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteAmenity` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteAmenity` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteAmenity`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteAppliedRate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteAppliedRate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteAppliedRate`(pAppliedRateID varchar(5), pHotelID int(5), pUser varchar(20))
BEGIN
update appliedRates set `status`='inactive', updatedby=puser, updatetime=now() where appliedRateID=pAppliedRateID and hotelid=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteAppliedRates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteAppliedRates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteAppliedRates`(
pAppliedRateID bigint(10),
pHotelID int(10),
pUser varchar(20))
BEGIN
update appliedRates set `status`='deleted', updatedby=pUser, updatetime=now() where appliedRateID=pAppliedRateID and hotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteBackOfficeConfig` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteBackOfficeConfig` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteBackOfficeConfig`(
in pHotelId int(4)
)
BEGIN
delete from back_office_config
where HOTEL_ID = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteBlocking` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteBlocking` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteBlocking`(
in pRoomID int(11),
in pFrom date
)
BEGIN
Delete from Blocking where roomID=pRoomid and `from`=pFrom;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteCashier` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteCashier` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteCashier`(
in pcashierid varchar(10)
)
BEGIN
delete from cashier
where 
cashierid = pcashierid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteCompany` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteCompany` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteCompany`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteContact` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteContact` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteContact`(
pConctactId int(20)
)
BEGIN
update contacts
set statusFlag = 'DELETED'
where
id = pConctactId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteContactPersons` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteContactPersons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteContactPersons`(
pAccountID varchar(30),
pHotelID int(5),
pUpdatedBy varchar(20)
)
BEGIN
update contactpersons
set
`status` = 'DELETED',
updatedBy = pUpdatedBy,
updatedOn = now()
where accountID = pAccountID and hotelID = pHotelID and (personType = 'Contact Person' or personType = 'Decision Maker');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteContractAmendment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteContractAmendment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteContractAmendment`(pID bigint(12))
BEGIN
update ContractAmmendments set StateFlag='DELETED' where id = pID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteContractAmendments` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteContractAmendments` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteContractAmendments`(pAmmendmentID varchar(50), pFolioID varchar(30))
BEGIN
UPDATE ContractAmmendments set StateFlag='DELETED' where AmmendmentID = pAmmendmentID and FolioID = pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteCurrencyCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteCurrencyCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteCurrencyCode`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteDepartment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteDepartment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteDepartment`(
in pDeptId      varchar(20),       
in pHotelId     int(5)        
)
BEGIN
Update department set stateFlag='DELETED' 
Where DeptId=pDeptId and HotelId=pHotelId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteDriver` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteDriver` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteDriver`(
in pDriverId         int(10),
in pUPDATED_BY       varchar(50), 
in pHOTEL_ID         int(4)
)
BEGIN
update drivers
set 
STATUS_FLAG = "DELETED",
UPDATED_DATE = now(), 
UPDATED_BY = pUPDATED_BY
where
driverId = pDriverId and
HOTEL_ID = pHOTEL_ID
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEnggJobRoomEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEnggJobRoomEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteEnggJobRoomEvent`(
in peventid varchar(20),
in photelid int(5)
)
BEGIN
delete from roomevents
where
eventid = peventid and hotelid = photelid and eventtype = 'ENGINEERING JOB';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEngineeringJob` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEngineeringJob` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteEngineeringJob`(
IN penggjobno varchar(20),
in photelid int(5),
in pupdatedby varchar(20),
in pEndDate varchar(20),
in pEndTime varchar(20)
)
BEGIN
update engineeringjobs
set 
stateflag = 'DELETED',
updatedby = pupdatedby,
updatetime = now(),
endDate = pEndDate,
endTime = pEndTime
where enggjobno = penggjobno and hotelid = photelid;  
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEngineeringService` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEngineeringService` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteEngineeringService`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteEvent`(pFolioID varchar(30))
BEGIN
delete from event_booking_info where folioid=pfolioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEventContact` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEventContact` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteEventContact`(
pFolioID varchar(30),
pHotelID int
)
BEGIN
delete from event_contacts where folioID = pFolioID and hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEventEMDAction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEventEMDAction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteEventEMDAction`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
delete from event_EMD_actions where folioID = pFolioID and hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEventOfficers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEventOfficers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteEventOfficers`(
pFolioID varchar(20),
pHotelID int,
pUpdatedBy varchar(20)
)
BEGIN
update event_officers set `status` = 'DELETED', updatedBy = pUpdatedBy where folioID = pFolioID and hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEventPackage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEventPackage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteEventPackage`(pPackageID bigint(20), pHotelD int(10), pUser varchar(20))
BEGIN
update event_package_header set `status`='deleted' where hotelID=pHotelD and packageID=pPackageID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEventPackageDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEventPackageDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteEventPackageDetails`(pPackageID int(20))
BEGIN
delete from event_package_detail where packageID=pPackageID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEventPackageRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEventPackageRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteEventPackageRequirements`(pPackageID int(20))
BEGIN
delete from event_package_requirement where packageID=pPackageID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteEventType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteEventType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteEventType`(
in pTypeID    varchar(10),
in pUPDATED_BY       varchar(50)
)
BEGIN
update event_type
set 
`status` = "DELETED",
UPDATETIME = now(), 
UPDATEDBY = pUPDATED_BY
where
typeID = pTypeID 
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFloor` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFloor` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFloor`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolio`(in pFolioID varchar(12))
BEGIN
Delete from Folio where folioId=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioInclusions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioInclusions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioInclusions`(
in pFolioId varchar(30),
in pHotelId int(5))
BEGIN
delete from FolioInclusions where
folioid = pFolioId and 
hotelId= pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioPackage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioPackage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioPackage`(
in pFolioId varchar(20),
in pHotelId int(5))
BEGIN
delete from foliopackage where
folioid = pFolioId and 
hotelId= pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioPrivilege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioPrivilege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioPrivilege`(
in pFolioID varchar(20),
in pHotelID int(4)
)
BEGIN
delete from folioprivilege where FolioID = pFolioID and
HotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioRecurringCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioRecurringCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioRecurringCharge`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioRecurringCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioRecurringCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioRecurringCharges`(
in pHotelId int(5),
in pFolioId varchar(20)
)
BEGIN
Delete from 
FolioRecurringCharge 
where 
folioId=pFolioId and 
hotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioRouting` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioRouting` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioRouting`(
in pHotelId int(5),
in pFolioId varchar(20),
in pTranCode varchar(20)
)
BEGIN
Delete from foliorouting where folioId=pFolioId and hotelId=pHOtelId and TransactionCode=pTranCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioRoutings` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioRoutings` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioRoutings`(
in pFolioId varchar(20),
in pHotelId int(5)
)
BEGIN
Delete from foliorouting where folioId=pFolioId and hotelId=pHOtelId ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioSchedule` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioSchedule` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioSchedule`(
in pFolioID varchar(20),
in pHotelID int(5)
)
BEGIN
Delete from FolioSchedules where folioID=pFolioID and hotelID=pHOtelID and `status` = 'DELETED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioScheduleRefArrivalDate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioScheduleRefArrivalDate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioScheduleRefArrivalDate`(
in pArrivalDate date,
in pEventID varchar(20),
in pHotelID int(5)
)
BEGIN
Delete from folioSchedules where fromdate=pArrivalDate and folioid=pEventID and hotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioSchedules` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioSchedules` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioSchedules`(
in pFolioID varchar(20),
in pRoomID varchar(20),
in pHotelID int(5)
)
BEGIN
Delete from folioSchedules where folioID=pFolioID and roomID=pRoomID and hotelid=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteFolioTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteFolioTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteFolioTransaction`(
in ptrandate datetime,
in pFolioID varchar(20),
in ptrancode varchar(5)
)
BEGIN
delete from foliotransactions where 
transactiondate=ptrandate and 
folioid=pFolioID and 
transactioncode=ptrancode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteGroup` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteGroup` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteGroup`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteGroupBookingDropDown` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteGroupBookingDropDown` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteGroupBookingDropDown`(
pId int,
pUpdatedBy varchar(20)
)
BEGIN
update groupbookingdropdown set `StatusFlag` = 'DELETED' where ID = pId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteGuest` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteGuest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteGuest`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteHotel` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteHotel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteHotel`(
pHotelId int(3)
)
BEGIN
Update Hotel 
set stateFlag='DELETED'
Where HotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteHouseKeeper` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteHouseKeeper` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteHouseKeeper`(
in phousekeeperid varchar(20),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update hk_housekeepers
set 
stateflag = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where housekeeperid = phousekeeperid and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteHouseKeepingJob` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteHouseKeepingJob` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteHouseKeepingJob`(in phousekeepingjobno int)
BEGIN
update housekeepingjobs
set    housekeepingjobs.stateflag = 'DELETED'
where  housekeepingjobs.housekeepingjobno = phousekeepingjobno;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteIncumbentOfficers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteIncumbentOfficers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteIncumbentOfficers`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
delete from event_incumbent_officers where folioID = pFolioID and hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteIndividualRoleMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteIndividualRoleMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteIndividualRoleMenu`(
pRoleName varchar(30),
pMenu varchar(50),
pHotelId     int(5) 
)
BEGIN
Delete from RoleMenu Where RoleName=pRoleName and Menu=pMenu and HotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteItem`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteMainGroup` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteMainGroup` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteMainGroup`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteMainMealHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteMainMealHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteMainMealHeader`(pFolioID varchar(20), pEventDate date)
BEGIN
declare pMealID bigint(10);
delete from event_meal_requirements where folioID=pFolioID and date(eventDate)=date(pEventDate);
set pMealID=(select mealID from event_meal_header where folioID=pFolioID and date(eventDate)=date(pEventDate) limit 1);
delete from event_meal_header where folioID=pFolioID and date(eventDate)=pEventDate;
delete from event_meal_details where mealID=pMealID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteMealGroup` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteMealGroup` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteMealGroup`(pGroupID bigint(20), pHotelID int(10), pUser varchar(20))
BEGIN
update meal_group set `status`='deleted', updatedby=pUser, updatetime=now() where groupID=pGroupID and hotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteMealItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteMealItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteMealItem`(pItemID varchar(30), pHotelID int(10), pUser varchar(20))
BEGIN
update meal_items set `status`='deleted', updatedby=pUser, updatetime=now() where hotelID=pHotelID and itemID=pItemID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteMealMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteMealMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteMealMenu`(pMenuID bigint(10), pHotelID int(10), pUser varchar(20))
BEGIN
update meal_menu set `status`='deleted', updatedby=pUser, updatetime=now() where hotel_id=pHotelID and menuID=pMenuID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteMenu`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteMenuDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteMenuDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteMenuDetail`(
pMENU_ID     varchar(10)
)
BEGIN
delete from `menu detail` WHERE MENU_ID=pMENU_ID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeletePackageDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeletePackageDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeletePackageDetail`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeletePackages` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeletePackages` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeletePackages`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeletePrivilegeDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeletePrivilegeDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeletePrivilegeDetail`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeletePrivilegeHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeletePrivilegeHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeletePrivilegeHeader`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeletePromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeletePromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeletePromo`(IN ppromocode INT)
BEGIN
update promos
set promos.stateflag = 'DELETED'
where promos.promocode = ppromocode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRateCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRateCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRateCode`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRateType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRateType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRateType`(
in proomtypecode varchar(50),
in pratecode varchar(50),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update ratetypes
set `statusFlag` = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where
roomtypecode = proomtypecode and
ratecode = pratecode and
hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRequirement` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRequirement` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRequirement`(
in pRequirementId         int(10),
in pUPDATED_BY       varchar(50), 
in pHOTEL_ID         int(4)
)
BEGIN
update requirement_header
set 
`status` = "DELETED",
UPDATETIME = now(), 
UPDATEDBY = pUPDATED_BY
where
requirementID = pRequirementId and
hotelID = pHOTEL_ID
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRole`(
pRoleName varchar(30),
pHotelId int(5)
)
BEGIN
Delete from Roles
Where RoleName=pRoleName AND HotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoleMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoleMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoleMenu`(
pRoleName varchar(30),
pHotelId     int(5) 
)
BEGIN
Delete from RoleMenu Where RoleName=pRoleName  and HotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoom`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomAmenities` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomAmenities` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoomAmenities`(
in pRoomId varchar(20),
in pHotelId int(4)
)
BEGIN
delete from roomamenities
where
roomid = pRoomId and
hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomAmenity` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomAmenity` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoomAmenity`( 
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomBlock` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomBlock` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoomBlock`(
in pblockid int(11),in proomid varchar(10)
)
BEGIN
delete from blockingdetails where
blockid = pblockid and roomid = proomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomBlockedByEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomBlockedByEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteRoomBlockedByEvent`(pRoomID varchar(10), pFolio varchar(20))
BEGIN
delete blockingdetails from blockingdetails,roomblock where roomid=pRoomID and blockingdetails.blockid=roomblock.blockid and folioid=pFolio;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomBlockNoDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomBlockNoDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoomBlockNoDetail`(
)
BEGIN
delete from roomblock 
where not exists
(select * from blockingdetails 
where blockingdetails.blockid = roomblock.blockid);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoomEvent`(
in pEventID varchar(20),
in pRoomID varchar(20),
in pEventType varchar(25),
in pHotelID int(5),
in pEventdate date
)
BEGIN
Delete from Roomevents where EventID=pEventID and RoomID=pRoomID and eventtype=pEventType and hotelID=pHotelID and EventDate=pEventDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomEventByEventType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomEventByEventType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoomEventByEventType`(
in peventtype varchar(30)
)
BEGIN
Delete from Roomevents 
where EventID = pEventID and Roomevents.EventType = peventtype;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoomEvents`(
in pEventID varchar(20),
in pRoomID varchar(20),
in pEventType varchar(25),
in pHotelID int(5)
)
BEGIN
Delete from Roomevents where EventID=pEventID and RoomID=pRoomID and eventtype=pEventType and hotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteRoomRequirements`(pFolioID varchar(20))
BEGIN
delete from event_rooms where folioID=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomsEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomsEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoomsEvents`(
in pEventID varchar(20),
in pRoomID varchar(20),
in pHotelID int(5)
)
BEGIN
Delete from Roomevents where EventID=pEventID and RoomID=pRoomID and hotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomSuperType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomSuperType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoomSuperType`(
in pRoomSuperType varchar(50),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update roomsupertype 
set 
stateflag = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where roomsupertype = proomsupertype and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteRoomType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteRoomType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteRoomType`(
in proomtypecode varchar(20),
in pupdatedby varchar(20),
in photelid int(5)
)
BEGIN
update roomtypes 
set 
roomtypes.statusFlag = 'DELETED',
updatedby = pupdatedby,
updatetime = now()
where roomtypecode = proomtypecode and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteTransactionCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteTransactionCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteTransactionCode`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteTransactionCodeSubAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteTransactionCodeSubAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteTransactionCodeSubAccount`(
pTransactionCode         varchar(20), 
pSubAccountCode          varchar(20), 
pUpdatedBy               varchar(50), 
pHotelId                 int(4)
)
BEGIN
update `transctioncode_subaccount` 
set 
statusFlag = 'DELETED',
updatedBy = pUpdatedBy, 
updatedDate = now()
where
transactionCode = pTransactionCode and 
subAccountCode = pSubAccountCode and
hotelId = pHotelId
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteTransactionSourceDocument` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteTransactionSourceDocument` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDeleteTransactionSourceDocument`(
in pTransactionSourceId int(10),
in pUpdatedBy varchar(50)
)
BEGIN
update transactionsourcedocuments	
set 
statusFlag = 'DELETED',
updatedDate = now(),
updatedBy = pUpdatedBy
where
transactionSourceId = pTransactionSourceId
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteTranType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteTranType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteTranType`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteUser` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteUser` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteUser`(
in pUserId varchar(30)
)
BEGIN
update users
set
Stateflag = 'DELETED'
where UserId = pUserId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteUserRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteUserRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteUserRole`(
in pUserId varchar(20),
in pHotelId int(5)
)
BEGIN
delete from userRole
where
userid = pUserId and
hotelid = pHotelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDeleteUserRoles` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDeleteUserRoles` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteUserRoles`(
in pUserId varchar(20),
in pHotelId int(5)
)
BEGIN
delete from userRoles
where
userid = pUserId and
hotelid = pHotelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDepartureView` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDepartureView` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDepartureView`(
in pdate date
)
BEGIN
select folioid from folioschedules
where
arrivaldate = pdate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDisplayAllRoomRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDisplayAllRoomRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDisplayAllRoomRequirements`(pFolioID varchar(20))
BEGIN
select * from event_rooms where folioID=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDisplayCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDisplayCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDisplayCharges`(in photelid int(5))
BEGIN
select * from Transactioncode where trantypeid=1 and hotelid=photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDisplayCompanyAccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDisplayCompanyAccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDisplayCompanyAccounts`()
BEGIN
Select 
(companyid) as `ID#`,
COMPANYCODE as CODE,
(COMPANYNAME) AS `NAME OF COMPANY`,
COMPANYURL,CONTACTPERSON,DESIGNATION,
ACCOUNT_TYPE, THRESHOLD_VALUE, TOTAL_SALES_CONTRIBUTION,
concat(STREET1,', ',CITY1,', ',COUNTRY1,', ',ZIP1) AS COMPANYADDRESS, contactnumber1
from company
where stateflag <>'DELETED' order by companyname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDisplayEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDisplayEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDisplayEvent`(pFolioID varchar(20))
BEGIN
set sql_big_selects=1;
select * from events where folioID=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDisplayFoodRequirement` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDisplayFoodRequirement` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDisplayFoodRequirement`(pEventDate date, pFolioID varchar(30))
BEGIN
select * from event_meal_requirements where date(eventDate)=pEventDate and folioid=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDisplayFoodRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDisplayFoodRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spDisplayFoodRequirements`(pFolioID varchar(20))
BEGIN
select * from event_meal_requirements where folioID=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDisplayListOfGuest` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDisplayListOfGuest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDisplayListOfGuest`(in pHotelID int(5))
BEGIN
select *
from guests
where hotelid=pHotelID and stateflag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spDisplayReservationList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spDisplayReservationList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spDisplayReservationList`()
BEGIN
Select schedule.Roomid,(roomtype.`name`) as RoomType,concat(account.firstname, ' ' , account.lastname) as `Name of Guest`,schedule.`From`,schedule.`To`,event.eventtype from room,schedule,folio,roomtype,account,event where schedule.Roomid=room.roomid and folio.folioid=schedule.folioid and folio.accountid=account.accountid and schedule.eventid=event.eventid and room.roomtypeid=roomtype.roomtypeid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spExact_DeleteCostCenter` */

/*!50003 DROP PROCEDURE IF EXISTS  `spExact_DeleteCostCenter` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spExact_DeleteCostCenter`(
pCostCenterCode  varchar(20), 
pUpdatedBy       varchar(20)
)
BEGIN
update `exact_costcenter` 
set 
StatusFlag = 'DELETED', 
UpdatedDate = now(), 
UpdatedBy = pUpdatedBy
where 
CostCenterCode = pCostCenterCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_DeleteGLaccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_DeleteGLaccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_DeleteGLaccounts`(
pAccountID       varchar(30),  
pUpdatedBy       varchar(30)
)
BEGIN
update `exact_glaccounts` 
set 
StatusFlag = 'DELETED',
UpdatedDate = now(), 
UpdatedBy = pUpdatedBy
where
AccountID = pAccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_DeleteJournalEntryCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_DeleteJournalEntryCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_DeleteJournalEntryCode`(
pJournalEntryCode  varchar(30), 
pUpdatedBy         varchar(30)
)
BEGIN
update `exact_journalentrycodes` 
set 
StatusFlag = 'DELETED', 
UpdatedBy = pUpdatedBy, 
UpdatedDate = now()
where
JournalEntryCode = pJournalEntryCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_GetAllCostCenters` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_GetAllCostCenters` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_GetAllCostCenters`(
in pHotelID int(4)
)
BEGIN
select * from exact_costcenter
order by CostCenterCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_GetAllGLaccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_GetAllGLaccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_GetAllGLaccounts`(
in pHotelID int(4)
)
BEGIN
select * from exact_glaccounts
order by AccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_GetAllJournalEntryCodes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_GetAllJournalEntryCodes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_GetAllJournalEntryCodes`(
in pHotelID int(4)
)
BEGIN
select * from exact_journalentrycodes
order by JournalEntryCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_GetNewGuests` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_GetNewGuests` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_GetNewGuests`(
pHotelID int(4),
pExportDate date
)
BEGIN
select * from guests
where
date(createtime) > pExportDate
order by createtime asc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_GetTransactionCodeMapping` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_GetTransactionCodeMapping` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_GetTransactionCodeMapping`(
in pHotelID int(4),
in pTransactionCode varchar(20)
)
BEGIN
select 
exact_gltofoliomapping.*, 
exact_glaccounts.description
from 
exact_gltofoliomapping
left join exact_glaccounts on 
exact_glaccounts.AccountID = exact_gltofoliomapping.Exact_GLAccountID 
where FolioPlus_TranCode = pTransactionCode
order by lineno;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spExact_InsertCostCenter` */

/*!50003 DROP PROCEDURE IF EXISTS  `spExact_InsertCostCenter` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spExact_InsertCostCenter`(
pCostCenterCode  varchar(20), 
pDescription     varchar(50), 
pCreatedBy       varchar(20)
)
BEGIN
insert into `exact_costcenter` 
(CostCenterCode, Description, StatusFlag, 
CreatedDate, CreatedBy, UpdatedDate, 
UpdatedBy)
values
(pCostCenterCode, pDescription, 'ACTIVE', 
now(), pCreatedBy, now(), 
pCreatedBy);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_InsertGLaccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_InsertGLaccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_InsertGLaccounts`(
pAccountID       varchar(30), 
pDescription     varchar(50), 
pCostCenterCode  varchar(30), 
pAccountNature   varchar(10), 
pCreatedBy       varchar(30)
)
BEGIN
insert into `exact_glaccounts` 
(AccountID, Description, CostCenterCode, 
AccountNature, StatusFlag, CreatedDate, 
CreatedBy, UpdatedDate, UpdatedBy
)
values
(pAccountID, pDescription, pCostCenterCode, 
pAccountNature, 'ACTIVE', now(), 
pCreatedBy, now(), pCreatedBy
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_InsertJournalEntryCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_InsertJournalEntryCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_InsertJournalEntryCode`(
pJournalEntryCode  varchar(30), 
pDescription       varchar(50), 
pCreatedBy         varchar(30)
)
BEGIN
insert into `exact_journalentrycodes` 
(JournalEntryCode, Description, StatusFlag, 
CreatedBy, CreatedDate, UpdatedBy, 
UpdatedDate)
values
(pJournalEntryCode, pDescription, 'ACTIVE', 
pCreatedBy, now(), pCreatedBy, 
now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_InsertTransactionCodeMapping` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_InsertTransactionCodeMapping` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_InsertTransactionCodeMapping`(
pFolioPlus_TranCode        varchar(30), 
pExact_GLAccountID         varchar(30), 
pLineNo                    int(2), 
pAmountColumnInFolioTrans  varchar(50), 
pCostCenterCode            varchar(30), 
pJournalEntryCode          varchar(30), 
pCreatedBy                 varchar(30)
)
BEGIN
insert into `exact_gltofoliomapping` 
(FolioPlus_TranCode, Exact_GLAccountID, 
LineNo, AmountColumnInFolioTrans, CostCenterCode, 
JournalEntryCode, StatuFlag, CreatedBy, 
CreatedDate, UpdatedBy, UpdatedDate)
values
(pFolioPlus_TranCode, pExact_GLAccountID, 
pLineNo, pAmountColumnInFolioTrans, pCostCenterCode, 
pJournalEntryCode, 'ACTIVE', pCreatedBy, 
now(), pCreatedBy, now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_ReportPostedAndUnpostedDailyHotelRevenue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_ReportPostedAndUnpostedDailyHotelRevenue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_ReportPostedAndUnpostedDailyHotelRevenue`(
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
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`baseAmount`,
(foliotransactions.`baseAmount` * -1) ) as baseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as netBaseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`grossAmount`,
(foliotransactions.`grossAmount` * -1) ) as grossAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`discount`,
(foliotransactions.`discount` * -1) ) as discount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`serviceCharge`,
(foliotransactions.`serviceCharge` * -1) ) as serviceCharge,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`governmentTax`,
(foliotransactions.`governmentTax` * -1) ) as governmentTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`localTax`,
(foliotransactions.`localTax` * -1) ) as localTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`mealAmount`,
(foliotransactions.`mealAmount` * -1) ) as mealAmount,
foliotransactions.`Memo`,
foliotransactions.subFolio,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netAmount`,
(foliotransactions.`netAmount` * -1) ) as netAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as Amount,
foliotransactions.`CREATEDBY`,
if(substring(foliotransactions.`Memo`,-3,3) > 0,substring(foliotransactions.`Memo`,-3,3),folioschedules.roomid) as roomid,
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
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.baseAmount,
(nonguesttransaction.baseAmount * -1) ) as baseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netBaseAmount,
(nonguesttransaction.netBaseAmount * -1) ) as netBaseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.grossAmount,
(nonguesttransaction.grossAmount * -1) ) as grossAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.discount,
(nonguesttransaction.discount * -1) ) as discount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.serviceCharge,
(nonguesttransaction.serviceCharge * -1) ) as serviceCharge,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.governmentTax,
(nonguesttransaction.governmentTax * -1) ) as governmentTax,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.localTax,
(nonguesttransaction.localTax * -1) ) as localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netAmount,
(nonguesttransaction.netAmount * -1) ) as netAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netbaseAmount,
(nonguesttransaction.netbaseAmount * -1) ) as Amount,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
'' as roomtype,
nonguesttransaction.companyName,
'' as REMARKS
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
h.order_date,
h.order_date,
h.order_id,
'POSCHECK#' as TransactionSource,
h.customer_id,
concat(if(substring(h.customer_id,1,1) = 'F', 
pos.fGetHotelFolioAccountID(h.customer_id),h.customer_id),
if(h.employee_id = "","",
concat("E-",h.employee_id))) as customerID,
pos.fGetCustomerNamePerOrder(h.Customer_ID,
h.EMPLOYEE_ID) as GuestName,
(case g.maingroup_id
when 'FOOD' then
'1200'
when 'BEVERAGES' then
'1202'
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
'' as Remarks
from 
pos.`order detail` d
left join 
pos.`order header` h on d.Order_Id = h.Order_Id
left join pos.item i on i.Item_ID = d.Item_Id
left join pos.`group` g on g.group_id = i.group_id
left join pos.payment p on h.order_id = p.order_id
where
g.maingroup_id is not null
and date(p.payment_date) >= pStartDate 
and date(p.payment_date) <= pEndDate 
and p.`status` != 'VOID' 
and p.payment_type IN ('CASH','Credit','ACCOUNT_EMPLOYEE')
and d.operation_status!='CANCELLED'
group by
g.maingroup_id,
h.order_id
)
order by transactionCode, transactionSource, ReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_ReportUnpostedDailyHotelRevenue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_ReportUnpostedDailyHotelRevenue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_ReportUnpostedDailyHotelRevenue`(
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
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`baseAmount`,
(foliotransactions.`baseAmount` * -1) ) as baseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as netBaseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`grossAmount`,
(foliotransactions.`grossAmount` * -1) ) as grossAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`discount`,
(foliotransactions.`discount` * -1) ) as discount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`serviceCharge`,
(foliotransactions.`serviceCharge` * -1) ) as serviceCharge,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`governmentTax`,
(foliotransactions.`governmentTax` * -1) ) as governmentTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`localTax`,
(foliotransactions.`localTax` * -1) ) as localTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`mealAmount`,
(foliotransactions.`mealAmount` * -1) ) as mealAmount,
foliotransactions.`Memo`,
foliotransactions.subFolio,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netAmount`,
(foliotransactions.`netAmount` * -1) ) as netAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as Amount,
foliotransactions.`CREATEDBY`,
if(substring(foliotransactions.`Memo`,-3,3) > 0,substring(foliotransactions.`Memo`,-3,3),folioschedules.roomid) as roomid,
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
transactioncode.tranTypeID = 1 and
foliotransactions.postToLedger = 0 group by folioid, referenceno, transactionsource
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
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.baseAmount,
(nonguesttransaction.baseAmount * -1) ) as baseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netBaseAmount,
(nonguesttransaction.netBaseAmount * -1) ) as netBaseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.grossAmount,
(nonguesttransaction.grossAmount * -1) ) as grossAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.discount,
(nonguesttransaction.discount * -1) ) as discount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.serviceCharge,
(nonguesttransaction.serviceCharge * -1) ) as serviceCharge,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.governmentTax,
(nonguesttransaction.governmentTax * -1) ) as governmentTax,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.localTax,
(nonguesttransaction.localTax * -1) ) as localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netAmount,
(nonguesttransaction.netAmount * -1) ) as netAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netbaseAmount,
(nonguesttransaction.netbaseAmount * -1) ) as Amount,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
'' as roomtype,
nonguesttransaction.companyName,
'' as REMARKS
from nonguesttransaction force index(primary)
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
where
date(nonguesttransaction.transactionDate) >= pStartDate and 
date(nonguesttransaction.`TransactionDate`) <= pEndDate and
nonguesttransaction.statusFlag = 'ACTIVE' and
nonguesttransaction.hotelID = pHotelId and
transactioncode.tranTypeID = 1 and
nonguesttransaction.postedToLedger = 0 group by folioid, referenceno, transactionsource
)
UNION
(
select
pos.payment.payment_date,
pos.payment.payment_date,
pos.payment.order_id,
'POSCHECK#' as TransactionSource,
pos.`order header`.customer_id,
concat(if(substring(pos.`order header`.customer_id,1,1) = 'F', 
pos.fGetHotelFolioAccountID(pos.`order header`.customer_id),pos.`order header`.customer_id),
pos.`order header`.employee_id) as customerID,
pos.fGetCustomerNamePerOrder(pos.`order header`.Customer_ID,
pos.`order header`.EMPLOYEE_ID) as GuestName,
'1201' as transactioncode,
pos.`order header`.total_amount as baseAmount,
pos.`order header`.vat_sales as netBaseAmount,
pos.`order header`.total_amount as grossAmount,
0 as discount,
pos.`order header`.service_charge as serviceCharge,
pos.`order header`.vat_amount as governmentTax,
pos.`order header`.local_Tax as localTax,
0 as mealAmount,
'RESTAURANT - DINE-IN' as `Memo`,
'DINE-IN' as subFolio,
pos.`order header`.total_amount as netAmount,
pos.`order header`.vat_sales as Amount,
pos.`order header`.`CREATEDBY`,
'' as roomid,
'' as roomtype,
'' as companyName,
pos.payment.payment_type as REMARKS
from
pos.`payment`
left join pos.`order header` on pos.payment.order_id = pos.`order header`.order_id
where
date(pos.payment.payment_date) >= pStartDate and 
date(pos.payment.payment_date) <= pEndDate and
pos.payment.`status` != 'VOID' and
(pos.payment.payment_type = 'CASH'
or pos.payment.payment_type = 'Credit'
or pos.payment.payment_type = 'ACCOUNT_EMPLOYEE')
and pos.payment.PostedToLedger = 0
)
order by transactionCode, transactionSource, ReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_SetDailyHotelRevenueAsPosted` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_SetDailyHotelRevenueAsPosted` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_SetDailyHotelRevenueAsPosted`(
in pHotelId int(4),
in pStartDate date,
in pEndDate date
)
BEGIN
update
foliotransactions
left join transactioncode on transactioncode.tranCode = foliotransactions.transactioncode
set 
postToLedger = 1
where
date(foliotransactions.`TransactionDate`) >= pStartDate and 
date(foliotransactions.`TransactionDate`) <= pEndDate and
foliotransactions.status = 'ACTIVE' and
transactioncode.tranTypeID = 1 and
foliotransactions.postToLedger = 0;
update
nonguesttransaction
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
set
nonguesttransaction.postedToLedger = 1
where
date(nonguesttransaction.transactionDate) >= pStartDate and 
date(nonguesttransaction.`TransactionDate`) <= pEndDate and
nonguesttransaction.statusFlag = 'ACTIVE' and
nonguesttransaction.hotelID = pHotelId and
transactioncode.tranTypeID = 1 and
nonguesttransaction.postedToLedger = 0;
update
pos.payment
set
pos.payment.PostedToLedger = 1
where
date(pos.payment.payment_date) >= pStartDate and 
date(pos.payment.payment_date) <= pEndDate and
pos.payment.`status` != 'VOID' and
(pos.payment.payment_type = 'CASH'
or pos.payment.payment_type = 'Credit'
or pos.payment.payment_type = 'ACCOUNT_EMPLOYEE')
and pos.payment.PostedToLedger = 0;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spExact_UpdateCostCenter` */

/*!50003 DROP PROCEDURE IF EXISTS  `spExact_UpdateCostCenter` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spExact_UpdateCostCenter`(
pCostCenterCode  varchar(20), 
pDescription     varchar(50), 
pStatusFlag      varchar(20),
pUpdatedBy       varchar(20)
)
BEGIN
update `exact_costcenter` 
set 
Description = pDescription, 
StatusFlag = pStatusFlag, 
UpdatedDate = now(), 
UpdatedBy = pUpdatedBy
where 
CostCenterCode = pCostCenterCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_UpdateGLaccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_UpdateGLaccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_UpdateGLaccounts`(
pAccountID       varchar(30), 
pDescription     varchar(50), 
pCostCenterCode  varchar(30), 
pAccountNature   varchar(10), 
pStatusFlag      varchar(10), 
pUpdatedBy       varchar(30)
)
BEGIN
update `exact_glaccounts` 
set 
Description = pDescription, 
CostCenterCode = pCostCenterCode, 
AccountNature = pAccountNature, 
StatusFlag = pStatusFlag,
UpdatedDate = now(), 
UpdatedBy = pUpdatedBy
where
AccountID = pAccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spEXACT_UpdateJournalEntryCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spEXACT_UpdateJournalEntryCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spEXACT_UpdateJournalEntryCode`(
pJournalEntryCode  varchar(30), 
pDescription       varchar(50), 
pStatusFlag        varchar(10),
pUpdatedBy         varchar(30)
)
BEGIN
update `exact_journalentrycodes` 
set 
Description = pDescription, 
StatusFlag = pStatusFlag, 
UpdatedBy = pUpdatedBy, 
UpdatedDate = now()
where
JournalEntryCode = pJournalEntryCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spFilterGuest` */

/*!50003 DROP PROCEDURE IF EXISTS  `spFilterGuest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spFilterGuest`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spFilterGuestRecord` */

/*!50003 DROP PROCEDURE IF EXISTS  `spFilterGuestRecord` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spFilterGuestRecord`(
in pAccountName varchar(30),
in pFirstname varchar(50),
in pLastName varchar(50),
in pMiddleName varchar(50),
in pCitizenship varchar(100),
in pSex varchar(6)
)
BEGIN
Select AccountId,AccountName,FirstName,MiddleName,LastName,Sex,CitizenShip from guests where  firstname=pFirstName and lastname=pLastName and middlename=pMiddlename and citizenship=pCitizenship and sex=pSex;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spFilterQuery` */

/*!50003 DROP PROCEDURE IF EXISTS  `spFilterQuery` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spFilterQuery`(
in pFields varchar(100),
in pTable varchar(25),
in pRefField varchar(25),
in pRefData varchar(50)
)
BEGIN
select pFields from pTable where pRefField like pRefData;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spFilterReservation` */

/*!50003 DROP PROCEDURE IF EXISTS  `spFilterReservation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spFilterReservation`(IN pStatus VARCHAR(15))
BEGIN
Select (Folio.FolioID) as `ID`,folio.FolioType,guest.Firstname,guest.Lastname,folio.AccountType,Folio.Status 
from folio,guest
where folio.accountid=guest.accountid and folio.status=pStatus;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAccountContacts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAccountContacts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAccountContacts`(
pAccountID varchar(30),
pHotelID int
)
BEGIN
select * from contactpersons where accountID = pAccountID and hotelID = pHotelID and (personType = 'Contact Person' or personType = 'Decision Maker') and `status` = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAccountID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAccountID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAccountID`(
IN pAccountID int
)
BEGIN
Select accountid from guests where accountid=pAccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAccountIDFromFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAccountIDFromFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAccountIDFromFolio`(pFolioID varchar(12))
BEGIN
Select Accountid from folio where folioid = pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAccountIDofAgent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAccountIDofAgent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAccountIDofAgent`(pfolioid int(10))
BEGIN
select agents.agentID as accountid from agents,folio
where agents.agentID = folio.agentcode and folio.folioid=pfolioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAccountInformation` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAccountInformation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAccountInformation`(
pAccountID varchar(20),
pHotelID int
)
BEGIN
select * from account_information where accountID = pAccountID and hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAccountPrivileges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAccountPrivileges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAccountPrivileges`(
in pAccountId varchar(20),
in pHotelId int(5)
)
BEGIN
select 
AccountPrivileges.*,
privilegeheader.description,
privilegeheader.daysapplied
from
accountPrivileges
left join privilegeheader on accountprivileges.privilegeId = privilegeheader.privilegeId
where
accountPrivileges.AccountID = pAccountId and
accountPrivileges.hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAgentByFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAgentByFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAgentByFolio`(pfolioid varchar(12))
BEGIN
select agentcode from folio where folioid = pfolioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAgentCommissions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAgentCommissions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAgentCommissions`(
pAccountID varchar(11)
)
BEGIN
select * from AgentCommission where Accountid = pAccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAgentInfo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAgentInfo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAgentInfo`(
in paccountid int(4)
)
BEGIN
select *, agency as agentname from agents where agentid = paccountid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAgents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAgents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAgents`()
BEGIN
select agentid as ID,agency as `Name of Agent`,Address,ContactNumber, agency as agentname from agents order by agency;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAllFolioIdsByRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAllFolioIdsByRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAllFolioIdsByRoom`(
in pRoomId varchar(20)
)
BEGIN
select 
folio.folioid,
folioschedules.roomid
from
folio left join folioschedules on folioschedules.folioid = folio.folioId
where folio.status = 'ONGOING'
and folioschedules.roomid = pRoomId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualAverageRoomRate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualAverageRoomRate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAnnualAverageRoomRate`(
in pHotelId int(2),
in pYear int(4)
)
BEGIN
select  sum(rate) as TOTALRATE, 
count(distinct folioschedules.folioid) as TOTALFOLIO,
sum(rate)/count(distinct folioschedules.folioid) as AverageRoomRate
from folioschedules
left join folio on folio.folioid = folioschedules.folioid
where
(folio.status = "ONGOING" or
folio.status = "CLOSED" or
folio.status = "CONFIRMED" or
folio.status = "TENTATIVE") and
( year(folioschedules.fromDate) = pYear ) or
( year(folioschedules.toDate) = pYear );
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualAverageRoomRatePerGuest` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualAverageRoomRatePerGuest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAnnualAverageRoomRatePerGuest`(
in pHotelId int(1),
in pYear int(4)
)
BEGIN
select  sum(rate) as TOTALRATE, 
sum(folio.noofadults) as TOTALFOLIO,
sum(rate)/sum(folio.noofadults) as AverageRoomRate
from folioschedules
left join folio on folio.folioid = folioschedules.folioid
where
(folio.status = "ONGOING" or
folio.status = "CLOSED" or
folio.status = "CONFIRMED" or
folio.status = "TENTATIVE") and
(
( year(folioschedules.fromdate) = pYear ) or
( year(folioschedules.todate) = pYear )
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualCancelledNoShowReservations` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualCancelledNoShowReservations` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAnnualCancelledNoShowReservations`(
in pHotelId int(4),
in pYear int(4)
)
BEGIN
select 
folio.status,
count(if(folio.foliotype != "SHARE",folioschedules.roomid,null)) as Rooms
from 
folio,
folioschedules 
where 
folio.hotelid = pHotelId and
folio.folioid = folioschedules.folioid and
(folio.status = 'CANCELLED' or
folio.status = 'NO SHOW') and 
year(folioschedules.fromdate) = pYear 
group by folio.status,year(folioschedules.fromdate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualGuestAR` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualGuestAR` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAnnualGuestAR`(
in pHotelId int(4),
in pLastYearDate datetime
)
BEGIN
select
foliotransactions.postingdate,
sum(if(foliotransactions.acctside='DEBIT',baseamount,0)) - sum(if(acctside='CREDIT',baseamount,0)) as BALANCE
from
foliotransactions 
left join folio on folio.folioid = foliotransactions.folioid
where
foliotransactions.`status` = 'ACTIVE' and
foliotransactions.postingdate <= pLastYearDate  and
foliotransactions.hotelid = pHotelId
group by
date(pLastYearDate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualHotelRevenue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualHotelRevenue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAnnualHotelRevenue`(pStartYear int, pEndYear int)
BEGIN
select
year(transactiondate) as transactionDate,
sum(header1) as header1,
sum(header2) as header2,
sum(header3) as header3,
sum(header4) as header4,
sum(header5)as header5,
sum(header6)as header6,
sum(header7)as header7,
sum(header8)as header8,
sum(header9)as header9,
sum(header10)as header10,
sum(header11)as header11,
sum(header12)as header12,
sum(header13)as header13,
sum(header14)as header14,
sum(header15)as header15,
sum(header16)as header16,
sum(header17)as header17,
sum(header18)as header18,
sum(header19)as header19,
sum(header20)as header20,
sum(header21)as header21,
sum(header22)as header22,
sum(header23)as header23,
sum(header24)as header24,
sum(header25)as header25,
sum(header26)as header26,
sum(header27)as header27,
sum(header28)as header28,
sum(header29)as header29,
sum(header30)as header30,
sum(header31)as header31,
sum(header32)as header32,
sum(header33)as header33,
sum(header34)as header34,
sum(header35)as header35,
sum(header36)as header36,
sum(header37)as header37,
sum(header38)as header38,
sum(header39)as header39,
sum(header40)as header40,
sum(header41)as header41,
sum(header42)as header42,
sum(header43)as header43,
sum(header44)as header44,
sum(header45)as header45,
sum(header46)as header46,
sum(header47)as header47,
sum(header48)as header48,
sum(header49)as header49,
sum(header50)as header50,
sum(header51)as header51,
sum(header52)as header52,
sum(header53)as header53,
sum(header54)as header54,
sum(header55)as header55,
sum(header56)as header56,
sum(header57)as header57,
sum(header58)as header58,
sum(header59)as header59,
sum(header60)as header60,
sum(header61)as header61,
sum(header62)as header62,
sum(header63)as header63,
sum(header64)as header64,
sum(header65)as header65,
sum(header66)as header66,
sum(header67)as header67,
sum(header68)as header68,
sum(header69)as header69,
sum(header70)as header70,
sum(header71)as header71,
sum(header72)as header72,
sum(header73)as header73,
sum(header74)as header74,
sum(header75)as header75,
sum(header76)as header76,
sum(header77)as header77,
sum(header78)as header78,
sum(header79)as header79,
sum(header80)as header80,
sum(header81)as header81,
sum(header82)as header82,
sum(header83)as header83,
sum(header84)as header84,
sum(header85)as header85,
sum(header86)as header86,
sum(header87)as header87,
sum(header88)as header88,
sum(header89)as header89,
sum(header90)as header90,
sum(header91)as header91,
sum(header92)as header92,
sum(header93)as header93,
sum(header94)as header94,
sum(header95)as header95,
sum(header96)as header96,
sum(header97)as header97,
sum(header98)as header98,
sum(header99)as header99,
sum(header100)as header100,
sum(header101)as header101,
sum(header102)as header102,
sum(header103)as header103,
sum(header104)as header104,
sum(header105)as header105,
sum(header106)as header106,
sum(header107)as header107,
sum(header108)as header108,
sum(header109)as header109,
sum(header110)as header110,
sum(header111)as header111,
sum(header112)as header112,
sum(header113)as header113,
sum(header114)as header114,
sum(header115)as header115,
sum(header116)as header116,
sum(header117)as header117,
sum(header118)as header118,
sum(header119)as header119,
sum(header120)as header120
from
(select * from hotelrevenue) as hotelrevenue where year(transactiondate) between pStartYear and pEndYear group by year(transactiondate) order by transactiondate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualReservationsByAccountType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualReservationsByAccountType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAnnualReservationsByAccountType`(
in pHotelId int(4),
in pYear int(4)
)
BEGIN
select 
folio.accounttype,
count(if(folio.foliotype != "SHARE",folioschedules.roomid,null)) as Rooms
from 
folio,
folioschedules 
where 
folio.hotelid = pHotelId and
folio.folioid = folioschedules.folioid and
year(folioschedules.fromdate) = pYear 
group by folio.accounttype,year(folioschedules.fromdate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualReservationSummaryBySource` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualReservationSummaryBySource` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAnnualReservationSummaryBySource`(
in pHotelId int(4),
in pYear int(4)
)
BEGIN
select 
if(folio.`source`= "WALK IN","WALK IN","RESERVE") as SOURCE,
count(*) as Total
from 
folio 
where (`status` = 'ONGOING' or `status` = 'CLOSED' or 
`status` = 'CONFIRMED') and
year(folio.fromDate) = pYear
and hotelId = pHotelId
group by folio.`source`
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualTotalFunctions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualTotalFunctions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAnnualTotalFunctions`(
in pHotelId int(4),
in pYear int(4)
)
BEGIN
select *
from folio 
where
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
foliotype = 'GROUP' and 
(year(fromdate) = pYear or year(todate) = pYear)
and
hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualTotalRoomStayOver` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualTotalRoomStayOver` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAnnualTotalRoomStayOver`(
in pHotelId int(4),
in pYear int(4)
)
BEGIN
select count(*) from folio 
where
(
(year(fromDate) = pYear) or
(year(toDate) = pYear)
) and
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
foliotype = 'INDIVIDUAL' and
folio.hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualWalkinCorporateFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualWalkinCorporateFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAnnualWalkinCorporateFolio`(
in pHotelId int(5),
in pYear int(4)
)
BEGIN
select 
count(*) as Total,
accounttype
from folio 
left join guests on guests.accountid = folio.accountid
where 
(`status` = 'ONGOING' or
`status` = 'CLOSED' or
`status` = 'CONFIRMED' or
`status` = 'TENTATIVE') and
folio.accounttype = 'CORPORATE' and
year(folio.fromdate) = pYear and
folio.source = 'WALK IN' and
folio.hotelid = pHotelId
group by folio.accounttype;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAnnualWalkinPersonalFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAnnualWalkinPersonalFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAnnualWalkinPersonalFolio`(
in pHotelId int(5),
in pYear int(4)
)
BEGIN
select 
count(*) as Total,
if(date(guests.createtime) = date(folio.createtime),"NEW","OLD") as guestType
from folio 
left join guests on guests.accountid = folio.accountid
where 
(`status` = 'ONGOING' or
`status` = 'CLOSED' or
`status` = 'CONFIRMED' or
`status` = 'TENTATIVE') and
folio.accounttype = "PERSONAL" and
year(folio.fromdate) = pYear and
folio.source = 'WALK IN' and
folio.hotelId = pHotelId
group by guestType;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetApplicablePackages` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetApplicablePackages` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetApplicablePackages`(
in pAuditDate date,
in pHotelID int(5)
)
BEGIN
select 
* 
from 
packageHeader 
where 
fromdate <= pAuditDate and todate >= pAuditDate
and hotelid = photelId and stateFlag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetApplicablePromos` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetApplicablePromos` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetApplicablePromos`(
in pStartDate date,
in pEndDate date,
in pHotelID int(5)
)
BEGIN
select 
* 
from 
packageHeader 
where 
(pStartDate >= fromDate and pStartDate < toDate) or (pEndDate > fromDate and pEndDate < toDate) or
(fromDate between pStartDate and pEndDate) or (toDate between pStartDate and pEndDate)
and hotelid = photelId and stateFlag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAppliedRatesForEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAppliedRatesForEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAppliedRatesForEvents`(pFolioID varchar(20))
BEGIN
select * from event_applied_rates where folioID=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAttributesForEventTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAttributesForEventTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAttributesForEventTypes`(pEventType varchar(40))
BEGIN
select * from event_attributes where eventID=pEventType;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAuditDate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAuditDate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetAuditDate`()
BEGIN
Select * from AuditDateTable order by AuditDate DESC limit 0,1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetAvailableRoomNoByDate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetAvailableRoomNoByDate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetAvailableRoomNoByDate`(
pRoomId varchar(10),
pRoomType varchar(80),
pDate date,
pHotelID int(10)
)
BEGIN
select 
distinct
folioschedules.roomid,
folio.folioid,
folioschedules.fromdate,
folioschedules.todate
from 
folio,
folioschedules 
where 
folio.folioid = folioschedules.folioid  and 
not ( folio.status = 'CLOSED' OR folio.status ='CANCELLED' OR folio.status ='NO SHOW') and
date(folioschedules.todate) < pDate and
folioschedules.roomid=pRoomId and
folioschedules.hotelid = folio.hotelid and
folioschedules.roomtype = pRoomType and
folio.hotelid = pHotelID and
not exists(
select folioid
from folioschedules 
where date(todate) < pDate and
folio.folioid = folioschedules.folioid
)
; 
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetBanquetContractRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetBanquetContractRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetBanquetContractRooms`(pFolioID varchar(30))
BEGIN
select `folio`.`masterFolio` AS `folioid`,
`folioschedules`.`FROMDATE` AS `fromDate`,
`folioschedules`.`TODATE` AS `toDate`,
if((`folioschedules`.`RATETYPE` <> _latin1'APPLIED'),`folioschedules`.`RoomType`,`appliedrates`.`description`) AS `roomtype`,
concat(count(distinct `folioschedules`.`FolioId`),_latin1' rm(s).') AS `qty`,
if((`folioschedules`.`RATETYPE` = _latin1'APPLIED'),concat(_latin1'P ',(cast(`folioschedules`.`RATE`/folio.noOfAdults as decimal(12, 2)) + `fGetMealrates`(`folio`.`masterFolio`)),_latin1'/pax/day'),concat(_latin1'P ',`folioschedules`.`RATE`,_latin1'/rm./day')) AS `rate`,
_latin1'ROOM REQUIREMENTS' AS `header` 
from ((`folio` join `folioschedules`) join `appliedrates`) where ((`folio`.`folioID` = `folioschedules`.`FolioId`) and (`folio`.`noOfAdults` = `appliedrates`.`noOfOccupants`) and (`folio`.`folioType` = _latin1'DEPENDENT')) and folio.masterfolio=pFolioID group by fromdate, `folioschedules`.`RATE` 
union all
select roomblock.folioid,
cast(blockingdetails.blockfrom as datetime) as fromDate,
cast(blockingdetails.blockto as datetime) as toDate,
(select description from appliedrates where noOfOccupants=(select noOfPax/noOfRooms from event_rooms where folioid=roomblock.folioid and roomtype=(select roomtypecode from rooms where roomid=blockingdetails.roomid)) and rateType='ROOM RATES') as roomtype,
concat(count(roomid), ' rm(s).') as qty,
concat('P ', fGetMealRates(roomblock.folioid)+fGetRoomRates(roomblock.folioid,fGetNumberOfPax(roomblock.folioid,(select roomtypecode from rooms where roomid=blockingdetails.roomid))),'/pax/day') as rate,
'ROOM REQUIREMENTS' AS `header` from roomblock, blockingdetails where roomblock.blockid=blockingdetails.blockid and roomblock.folioid!='' and roomblock.folioid=pfolioid group by fromdate, roomtype, folioid order by folioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetBlockedRoomInDate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetBlockedRoomInDate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetBlockedRoomInDate`(
in pDate varchar(20)
)
BEGIN
select roomid from blockingdetails
where date(blockfrom) > pDate and date(blockto) < pDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetBreakDownOfChargePayment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetBreakDownOfChargePayment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetBreakDownOfChargePayment`(pfolioid varchar(20))
BEGIN
select foliotransactions.transactioncode as AccountID,foliotransactions.folioid,foliotransactions.subfolio,transactioncode.memo,sum(foliotransactions.netbaseamount) as Amount
from foliotransactions,transactioncode,folio,cardco
where foliotransactions.transactioncode=transactioncode.trancode and transactioncode.trancode=cardco.vendorid
and foliotransactions.posttoledger='0' and foliotransactions.folioid=folio.folioid and foliotransactions.folioid=pFolioID
group by foliotransactions.transactioncode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCalls` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCalls` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCalls`()
BEGIN
select * from `callmgtsystem`.`log` force index(primary)
where `callmgtsystem`.`log`.PostFlag = 0 and `callmgtsystem`.`log`.Cost > 0
and (`callmgtsystem`.`log`.CallDate <= curdate() and `callmgtsystem`.`log`.CallDate >= adddate(curdate(),-1));
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetChangesLogs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetChangesLogs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetChangesLogs`(
in pStartDate date,
in pEndDate date
)
BEGIN
select * from changes_log
where date(DATE_CHANGED) >= pStartDate and 
date(DATE_CHANGED) <= pEndDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetChargedRecurringCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetChargedRecurringCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetChargedRecurringCharges`(pFolioID varchar(35), pHotelID int(5), pTransactionDate date, pTransactionCode varchar(10))
BEGIN
select hotelid, folioid, transactioncode, transactiondate, memo, baseamount as amount from foliotransactions where folioid=pFolioID and hotelid=pHotelID and date(transactiondate)=pTransactionDate and transactionCode=pTransactionCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCharges`(
in pFolioID varchar(20), 
in photelid int(5),
in pSubFolio varchar(1)
)
BEGIN
select sum(netamount),subfolio
from 
folioTransactions 
where 
acctside = 'DEBIT' and
folioId= pFolioId and 
hotelid = pHotelId AND
`status` = 'ACTIVE' and
subfolio = pSubFolio
group by subfolio;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCheckedInGroups` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCheckedInGroups` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCheckedInGroups`(pDate date, pHotelid int(5))
BEGIN
select folioid from folio where foliotype='GROUP' and pDate>=date(fromdate) and pDate<=date(todate) and folio.status='ONGOING' and hotelid=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetChildFolioRoomEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetChildFolioRoomEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetChildFolioRoomEvents`(pFolioID varchar(25), pHotelID bigint(10))
BEGIN
select roomrate, eventid from roomevents where eventid in (select folioid from folio where masterfolio=pFolioID) and hotelid=photelid and eventtype!='CANCELLED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetChildFolios` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetChildFolios` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetChildFolios`(
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
folio.arrivaldate,
folio.masterfolio,
folio.foliotype,
folio.folioeta
from 
folio
where 
folio.masterfolio=pFolioID and folio.`status`!='REMOVED' and folio.status!='DELETED' and hotelID=pHOtelID or folio.masterfolio in (select 
folio.folioId
from 
folio
where 
folio.masterfolio=pFolioID and hotelID=pHOtelID);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetChildFoliosAllFields` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetChildFoliosAllFields` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetChildFoliosAllFields`(
in pFolioID varchar(12),in photelid int(5)
)
BEGIN
select 
*
from 
folio
where 
folio.masterfolio=pFolioID and `status`!='CLOSED' and `status`!='CANCELLED' and `status`!='DELETED' and hotelid=photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCityLedgerSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCityLedgerSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCityLedgerSummary`()
BEGIN
select acctid,FGetCompany(acctid)as accountname,sum(debit) as debit ,if(FComputePaymentByAcctID(acctid)is NULL,0,FComputePaymentByAcctID(acctid)) as credit,if((sum(debit) -FComputePaymentByAcctID(acctid)) is null,sum(debit),sum(debit) -FComputePaymentByAcctID(acctid)) as balance  from cityledger where closed='0'
group by acctid,FGetCompany(acctid) order by accountname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCommission` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCommission` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCommission`(pfolioID varchar(20),
ptrancode varchar(20)
)
BEGIN
Select distinct percentcommission from agentcommission,folio,foliotransactions
where foliotransactions.folioid =folio.folioid and
folio.agentid = agentcommission.accountid and 
agentcommission.trancode = ptrancode and foliotransactions.folioid=pfolioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCompanyAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCompanyAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCompanyAccount`(
in pCompanyId varchar(50),
in pHotelId int(5)
)
BEGIN
Select companyid, companycode, companyname, companyurl, contactperson, designation, street1, city1, country1, zip1, street2, city2, country2, zip2, street3, city3, country3, zip3, email1, email2, email3, contactnumber1, contactnumber2, contactnumber3, contacttype1, contacttype2, contacttype3, stateflag, account_type, card_no, threshold_value, no_of_visit, total_sales_contribution, x_deal_amount, remarks
, TIN
from 
company
where 
(companyid = pCompanyId or companycode = pCompanyId)and
hotelid = photelid and companycode != '';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCompanyByName` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCompanyByName` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCompanyByName`(
pCompName varchar(100),
pHotelId int(5)
)
BEGIN
select * from company where companyname=pCompName and HotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCompanyFolios` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCompanyFolios` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCompanyFolios`(
in photelid int(5)
)
BEGIN
Select 
folio.companyid,
folio.groupname,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
folioid,
folio.fromdate,
folio.todate
from 	
folio
where 
folio.foliotype = "GROUP" and
(`folio`.`status` = 'ONGOING') and
folio.hotelid = photelid and
masterfolio = "";
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCompanyGuests` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCompanyGuests` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCompanyGuests`(
in pCompanyId varchar(20),
in pHotelId int(5)
)
BEGIN
select distinct
if(foliotype='GROUP', folio.companyid, folio.accountid) as accountid,
if(foliotype='GROUP', if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)), fGetGuestName(folio.accountid)) as GuestName
from
folio
where
folio.companyid = pCompanyId and
folio.hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCompanyInfo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCompanyInfo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCompanyInfo`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCompanyPrivelege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCompanyPrivelege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCompanyPrivelege`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCompanyPrivilege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCompanyPrivilege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCompanyPrivilege`(in pCompanyID varchar(20),in pHotelId int(5))
BEGIN
Select *,transactioncode.memo from CompanyPrivilegeheader,CompanyPrivilegedetails,transactioncode where CompanyPrivilegeheader.companyID=pcompanyID and CompanyPrivilegeheader.hotelId=pHotelId and CompanyPrivilegeheader.privilegeid=CompanyPrivilegedetails.privilegeid and CompanyPrivilegedetails.transactioncode=transactioncode.trancode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCompanyRefCompanyName` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCompanyRefCompanyName` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCompanyRefCompanyName`(
in pCompanyName varchar(100)
)
BEGIN
select * from company where companyname=pCompanyName;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetContactPersons` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetContactPersons` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetContactPersons`(
pFolioID varchar(20),
pHotelID int(5),
pAccountID varchar(20)
)
BEGIN
select * from contactpersons where folioID = pFolioID and hotelID = pHotelID and accountID = pAccountID and `status` = 'ACTIVE' and (personType = 'Contact Person' or personType = 'Decision Maker') order by  personType DESC;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCurrency` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCurrency` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCurrency`(in pCurrencyCode varchar(10))
BEGIN
Select CURRENCYCODE,CURRENCY,CONVERSIONRATE from CurrencyCodes where currencycode=pCurrencyCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCurrencyCodes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCurrencyCodes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCurrencyCodes`(in pHOtelid int(5))
BEGIN
Select * from currencyCodes where hotelid =photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCurrencyRate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCurrencyRate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCurrencyRate`(
in pcurrencycode varchar(15)
)
BEGIN
select currencyrate from currencycodes where currencycode=pcurrencycode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGETCURRENCYRATEANDCODE` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGETCURRENCYRATEANDCODE` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGETCURRENCYRATEANDCODE`()
BEGIN
Select CurrencyCode,ConversionRate from currencyCodes;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCurrentAuditDate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCurrentAuditDate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCurrentAuditDate`(
in pAuditDate varchar(15)
)
BEGIN
Select * from auditdatetable where auditdate = pAuditDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCurrentDayFolioIdByRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCurrentDayFolioIdByRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCurrentDayFolioIdByRoom`(
in pRoomId varchar(20),
in pEventType varchar(50),
in pAuditDate date
)
BEGIN
select eventid from roomevents
where	
roomid = pRoomId and `eventdate` = pAuditDate and eventtype = pEventType
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetCurrentRoomOccupied` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetCurrentRoomOccupied` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetCurrentRoomOccupied`(
in pFolioID VARCHAR(20),
in pHotelId int(5),
in pAuditDate date
)
BEGIN
select 
RoomID
from 
roomevents force index(eventid,`eventdate`)
where 
EventID = pFolioID and 
`eventdate`= pAuditDate and
hotelid = photelid and 
transferFlag <>'1';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyAverageRoomRate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyAverageRoomRate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDailyAverageRoomRate`(
in pHotelId int(2),
in pDate date
)
BEGIN
select  sum(rate) as TOTALRATE, 
count(distinct folioschedules.folioid) as TOTALFOLIO,
sum(rate)/count(distinct folioschedules.folioid) as AverageRoomRate
from folioschedules
left join folio on folio.folioid = folioschedules.folioid
where
(folio.status = "ONGOING" or
folio.status = "CLOSED" or
folio.status = "CONFIRMED" or
folio.status = "TENTATIVE") and
date(folioschedules.fromdate) <= date(pDate) and 
date(folioschedules.todate) >= date(pDate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyAverageRoomRatePerGuest` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyAverageRoomRatePerGuest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDailyAverageRoomRatePerGuest`(
in pHotelId int(1),
in pDate date
)
BEGIN
select  sum(rate) as TOTALRATE, 
sum(folio.noofadults) as TOTALFOLIO,
sum(rate)/sum(folio.noofadults) as AverageRoomRate
from folioschedules
left join folio on folio.folioid = folioschedules.folioid
where
(folio.status = "ONGOING" or
folio.status = "CLOSED" or
folio.status = "CONFIRMED" or
folio.status = "TENTATIVE") and
date(folioschedules.fromdate) <= date(pDate) and 
date(folioschedules.todate) >= date(pDate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyCancelledNoShowReservations` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyCancelledNoShowReservations` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetDailyCancelledNoShowReservations`(
in pHotelId int(4),
in pDate date,
in pEndDate date
)
BEGIN
select 
date(folio.fromdate) as fromDate,
folio.status,
count(if(folio.foliotype != "SHARE" and folio.foliotype!='JOINER',folio.folioid,null)) as Rooms
from 
folio
where 
folio.hotelid = pHotelId and
(folio.status = 'CANCELLED' or
folio.status = 'NO SHOW') and 
date(folio.fromdate) >= pDate and date(folio.fromdate) <= pEndDate
group by folio.status,date(folio.fromdate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyFolioComputation` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyFolioComputation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetDailyFolioComputation`(
in pHotelId int(4),
in pDate date)
BEGIN
select date(startDate) as fromDate, description, sum(roomCount) as rooms from
(
select 
date(folio.fromdate) as startDate,
folio.status as description,
count(if(folio.foliotype!='JOINER',folio.folioid,null)) as roomCount
from 
folio
where 
folio.hotelid = pHotelId and
(folio.status = 'CANCELLED' or
folio.status = 'NO SHOW') and 
date(folio.updateTime) = pDate
group by folio.fromdate, description
UNION ALL
select 
date(folio.fromdate) as startDate,
folio.accounttype as description,
count(if(folio.foliotype!='JOINER',folio.folioid,null)) as roomCount
from 
folio
where 
folio.hotelid = pHotelId and
date(folio.fromdate) = pDate and
folio.source!='WALK IN' and (folio.status = 'ONGOING' or folio.status = 'CLOSED' OR `status` = 'CONFIRMED' or `status` = 'TENTATIVE') and folio.foliotype!='JOINER' and folio.foliotype!='GROUP'
group by folio.fromdate, description
UNION ALL
select 
date(folio.fromdate) as startDate,
if(folio.`source`= "WALK IN","WALK IN","RESERVE") as description,
count(*) as roomCount
from 
folio 
where (`status` = 'ONGOING' or `status` = 'CLOSED' OR `status` = 'CONFIRMED' or `status` = 'TENTATIVE') and
date(folio.fromdate) = pDate and
hotelId = pHotelId and folio.foliotype!='JOINER' and folio.foliotype!='GROUP'
group by folio.fromdate, description
UNION ALL
select 
pDate as startDate,
'FUNCTIONS' as description,
count(folio.folioid) as roomCount
from folio, folioschedules
where
(folio.status = 'ONGOING' or folio.status = 'CLOSED' OR `status` = 'CONFIRMED' or `status` = 'TENTATIVE') and
foliotype = 'GROUP' and (date(folio.fromDate) = pDate or (pDate >= date(folio.fromDate) and pDate < date(folio.todate))) and
folio.hotelid = pHotelId and folio.folioid=folioschedules.folioid and folioschedules.roomid!='' group by folio.folioid, startDate
UNION ALL
select 
pDate as startDate,
'ROOMS STAY-OVER' as description,
count(*) as roomCount
from folio 
where
date(folio.fromdate) < pDate and date(folio.todate)>pdate
and 
(folio.status = 'ONGOING' or (folio.status = 'CLOSED' AND date(folio.todate)>=pDate)) and
foliotype != 'JOINER' AND foliotype != 'GROUP' and
folio.hotelId = pHotelId group by description
UNION ALL
select 
date(folio.fromdate) as startDate,
if(fGetGuestsCreateTime(folio.accountid) = date(folio.createtime),"WALK IN NEW","WALK IN OLD") as description,
count(folioid) as roomCount
from folio 
where 
(`status` = 'ONGOING' or
`status` = 'CLOSED' or
`status` = 'CONFIRMED' or
`status` = 'TENTATIVE') and
folio.accounttype = "PERSONAL" and
date(folio.fromdate) = pDate and
folio.source = 'WALK IN' and
foliotype != 'JOINER' AND foliotype != 'GROUP' and
folio.hotelId = pHotelId
group by startDate, description
UNION ALL
select 
date(folio.fromdate) as startDate,
'WALK IN CORPORATE' as description,
count(folioid) as roomCount
from folio 
where 
(`status` = 'ONGOING' or
`status` = 'CLOSED' or
`status` = 'CONFIRMED' or
`status` = 'TENTATIVE') and
folio.accounttype = "CORPORATE" and
date(folio.fromdate) = pDate and
folio.source = 'WALK IN' and
foliotype != 'JOINER' AND foliotype != 'GROUP' and
folio.hotelId = pHotelId
group by startDate, description
UNION ALL
select  distinct
pDate as startDate,
'AVERAGEROOMRATE' as description,
(select sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netbaseamount * -1, foliotransactions.netbaseamount))+if(fGetDailyNonGuestRoomTotal(pDate) is null, 0, fGetDailyNonGuestRoomTotal(pDate))+if(fGetDailyFOCRoomTotal(pDate) is null, 0, fGetDailyFOCRoomTotal(pDate))+if(fGetDailyFOCNonGuestRoomTotal(pDate) is null, 0, fGetDailyFOCNonGuestRoomTotal(pDate)) from foliotransactions where transactioncode='1000' and date(transactiondate)=pDate group by transactioncode)/count(distinct folioschedules.folioid) as roomCount
from folioschedules
left join folio on folio.folioid = folioschedules.folioid
where
(folio.status = "ONGOING" or
folio.status = "CLOSED" or
folio.status = "CONFIRMED" or
folio.status = "TENTATIVE") and
foliotype != 'JOINER' AND foliotype != 'GROUP' and
pDate>=date(folioschedules.fromdate) and pDate<date(folioschedules.todate)
group by description
UNION ALL
select distinct
pDate as startDate,
'AVERAGEROOMRATEPERGUEST' as description,
(select sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netbaseamount * -1, foliotransactions.netbaseamount)) from foliotransactions where transactioncode='1000' and date(transactiondate)=pDate group by transactioncode)/(sum(folio.noofadults)) as roomCount
from folio
left join folioschedules on folio.folioid = folioschedules.folioid
where
(folio.status = "ONGOING" or
folio.status = "CLOSED" or
folio.status = "CONFIRMED" or
folio.status = "TENTATIVE") and
pDate>=date(folioschedules.fromdate) and pDate<date(folioschedules.todate) and
foliotype != 'JOINER' AND foliotype != 'GROUP'
group by startDate, description
) as folios group by description
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyGuestAR` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyGuestAR` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDailyGuestAR`(
in pHotelId int(4),
in pDate datetime
)
BEGIN
select
foliotransactions.postingdate,
sum(if(foliotransactions.acctside='DEBIT',baseamount,0)) - sum(if(acctside='CREDIT',baseamount,0)) as BALANCE
from
foliotransactions 
left join folio on folio.folioid = foliotransactions.folioid
where
foliotransactions.`status` = 'ACTIVE' and
foliotransactions.postingdate <= pDate and
foliotransactions.hotelid = pHotelId
group by
date(pDate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyReservationsByAccountType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyReservationsByAccountType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetDailyReservationsByAccountType`(
in pHotelId int(4),
in pDate date,
in pEndDate date
)
BEGIN
select 
date(folio.fromdate) as fromdate,
folio.accounttype,
count(if(folio.foliotype != "SHARE" and folio.foliotype!='JOINER',folio.folioid,null)) as Rooms
from 
folio
where 
folio.hotelid = pHotelId and
date(folio.fromdate) >= pdate and date(folio.fromdate) <= pEndDate
group by folio.accounttype,date(folio.fromdate)
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyReservationSummaryBySource` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyReservationSummaryBySource` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDailyReservationSummaryBySource`(
in pHotelId int(4),
in pDate date,
in pEndDate date
)
BEGIN
select 
date(folio.fromdate) as fromDate,
if(folio.`source`= "WALK IN","WALK IN","RESERVE") as FOLIOSOURCE,
count(*) as Total
from 
folio 
where (`status` = 'ONGOING' or `status` = 'CLOSED' or 
`status` = 'CONFIRMED' or `status`='TENTATIVE') and
date(folio.fromdate) >= pDate and date(folio.fromdate) <= pEndDate and
hotelId = pHotelId and folio.foliotype!='JOINER' and folio.foliotype!='SHARE'
group by folio.fromdate, FOLIOSOURCE
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyTotalFunctions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyTotalFunctions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDailyTotalFunctions`(
in pHotelId int(4),
in pDate date
)
BEGIN
select count(folioid) as rooms
from folio 
where
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
foliotype = 'GROUP' and (date(fromdate) <= pDate and
date(toDate) >= pDate) and
hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyTotalRoomStayOver` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyTotalRoomStayOver` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDailyTotalRoomStayOver`(
in pHotelId int(4),
in pDate date
)
BEGIN
select count(*) from folio 
where
date(fromdate) < pDate and
date(toDate) > pDate
and 
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
foliotype = 'INDIVIDUAL' and
folio.hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyWalkinCorporateFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyWalkinCorporateFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDailyWalkinCorporateFolio`(
in pHotelId int(5),
in pDate date
)
BEGIN
select 
count(*) as Total,
accounttype
from folio 
left join guests on guests.accountid = folio.accountid
where 
(`status` = 'ONGOING' or
`status` = 'CLOSED' or
`status` = 'CONFIRMED' or
`status` = 'TENTATIVE') and
folio.accounttype = 'CORPORATE' and
date(folio.fromdate) = pDate and
folio.source = 'WALK IN' and
folio.hotelid = pHotelId
group by folio.accounttype;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDailyWalkinPersonalFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDailyWalkinPersonalFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDailyWalkinPersonalFolio`(
in pHotelId int(5),
in pDate date
)
BEGIN
select 
count(*) as Total,
if(date(guests.createtime) = date(folio.createtime),"NEW","OLD") as guestType
from folio 
left join guests on guests.accountid = folio.accountid
where 
(`status` = 'ONGOING' or
`status` = 'CLOSED' or
`status` = 'CONFIRMED' or
`status` = 'TENTATIVE') and
folio.accounttype = "PERSONAL" and
date(folio.fromdate) = pDate and
folio.source = 'WALK IN' and
folio.hotelId = pHotelId
group by guestType;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDataToApplyCommission` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDataToApplyCommission` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetDataToApplyCommission`(pfolioID varchar(20),in psubfolio varchar(1),in pHotelID int(5))
BEGIN
select foliotransactions.transactioncode,foliotransactions.subfolio,folio.AgentID ,sum(foliotransactions.netbaseamount) as NetAmount from foliotransactions,folio
where  folio.folioid=foliotransactions.folioid and  folio.folioid=pfolioID and foliotransactions.posttoledger="0" and foliotransactions.hotelid=pHotelID and subfolio=psubfolio
group by transactioncode,folio.AgentID,foliotransactions.subfolio;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDataToBePostedToLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDataToBePostedToLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetDataToBePostedToLedger`(pfolioid int(10))
BEGIN
select * from vdatatobepostedtoledger where folioid=pfolioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDataToPostServiceCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDataToPostServiceCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetDataToPostServiceCharge`(
pFolioid varchar(20),
pHotelid int(5)
)
BEGIN
select 
transactioncode.departmentId,
foliotransactions.transactioncode as trancode,
sum(foliotransactions.servicecharge) as amount 
from 
transactioncode,
foliotransactions
where 
transactioncode.trancode = foliotransactions.transactioncode and 
foliotransactions.folioid = pFolioid and 
foliotransactions.hotelid = pHotelid and 
foliotransactions.posttoledger="0"
group by 
transactioncode.departmentId,
foliotransactions.transactioncode
having sum(foliotransactions.servicecharge) > 0;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDateMealTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDateMealTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetDateMealTypes`(
pFolioID varchar(20), 
pDate date
)
BEGIN
select distinct mealType 
from event_meal_requirements 
where folioID=pFolioID and 
date(eventDate)=pDate 
order by cast(`event_meal_requirements`.`starttime` as time);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDateRangeMarketSegment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDateRangeMarketSegment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDateRangeMarketSegment`(
	in pFromDate date,
	in pToDate date
	)
BEGIN
	select 
	folio.purpose as `Market Segment`, 
	(select roomtypecode from rooms where roomid=folioschedules.roomid) as `Room Type`, 
	folioschedules.roomid as `Room ID`, 
	date(folio.fromdate) as `Date`, 
	(select count(roomevents.RoomID) from roomevents where roomevents.EventID = folio.folioID group by roomevents.EventID) as `Total Count`,
	
	sum(
		(select sum(if(foliotransactions.acctside = 'CREDIT', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) 
		from foliotransactions 
		left join transactioncode 
		on foliotransactions.transactionCode = transactioncode.tranCode 
		where transactioncode.acctSide = 'DEBIT' 
		and foliotransactions.folioId = folio.folioID
		group by folio.folioID)
	) as `Total Revenue` 
	from 
	folioschedules left join folio on folio.folioID = folioschedules.FolioId
	where 
	folio.folioid=folioschedules.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and folio.Status!='WAIT LIST'
	and date(folio.fromdate) between pFromDate and pToDate
	group by folio.groupName order by folio.Status, folio.purpose
	;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDateRangeNationalityReport` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDateRangeNationalityReport` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetDateRangeNationalityReport`(pStartDate date, pEndDate date)
BEGIN
select 
countryname, 
nationality, 
fCountPaxPerNationality(pStartDate, pEndDate, countryname, nationality) as pax,
fGetFolioCount(pStartDate, pEndDate) as totalPax,
(select count(roomid) from folioschedules where roomtype!='FUNCTION' and date(fromdate) between pStartDate and pEndDate) as totalRoomsOccupied,
(select sum(rate*days) from folioschedules where roomtype!='FUNCTION' and date(fromdate) between pStartDate and pEndDate) as totalRoomRates,
fGetTotalRooms() as totalRooms
from countries;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDateRangeStatisticalReport` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDateRangeStatisticalReport` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDateRangeStatisticalReport`(
	in pFrom date,
	in pTO date,
	in pSortType varchar(20)
	)
BEGIN
	declare reportFields varchar(1000);	
	set reportFields = "";
	case pSortType
		when 'EVENT TYPE' then set reportFields = concat(reportFields,'eventtype as `Event Type`, if(substring(folio.companyid,1,1)=''G'',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)=''G'',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, folio.accountType as `Account Type`,  groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, ');
		when 'CLIENT TYPE' then set reportFields = concat(reportFields,'if(substring(folio.companyid,1,1)=''G'',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, folio.accountType as `Account Type`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)=''G'',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, ');
		when 'SOURCE' then set reportFields = concat(reportFields,'folio.source as `Source`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)=''G'',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)=''G'',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, folio.accountType as `Account Type`, groupname as `Event Name`, folio.purpose as `Market Segment`, ');
		when 'MARKET SEGMENT' then set reportFields = concat(reportFields,'folio.purpose as `Market Segment`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)=''G'',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, if(substring(folio.companyid,1,1)=''G'',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, folio.accountType as `Account Type`, groupname as `Event Name`, folio.source as `Source`, ');
		when 'COMPANY NAME' then set reportFields = concat(reportFields,'if(substring(folio.companyid,1,1)=''G'',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, folio.purpose as `Market Segment`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)=''G'',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, folio.accountType as `Account Type`, groupname as `Event Name`, folio.source as `Source`, ');
		when 'ACCOUNT TYPE' then set reportFields = concat(reportFields,'folio.accountType as `Account Type`, if(substring(folio.companyid,1,1)=''G'',(select account_type from company where companyid=folio.companyid), (select account_type from guests where accountid=folio.companyid)) as `Client Type`, eventtype as `Event Type`, if(substring(folio.companyid,1,1)=''G'',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as `Company Name`, groupname as `Event Name`, folio.source as `Source`, folio.purpose as `Market Segment`, ');
	end case;
	set @sqlString = concat('select '
			,reportFields
			,'sum(
				(select sum(if(foliotransactions.acctside = ''CREDIT'', foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) 
				from foliotransactions 
				left join transactioncode 
				on foliotransactions.transactionCode = transactioncode.tranCode 
				where transactioncode.acctSide = ''DEBIT'' 
				and foliotransactions.folioId = folio.folioID
				group by folio.folioID)
			) as `Total Revenue` '
			,'from folio, event_booking_info where folio.folioid=event_booking_info.folioid and folio.status!=''CANCELLED'' and folio.status!=''NO SHOW'' and date(folio.fromdate) between '''
			,DATE_FORMAT(pFrom,'%Y-%m-%d')
			,''' and '''
			,DATE_FORMAT(pTo,'%Y-%m-%d')
			,''' group by folio.folioid order by `'
			,pSortType
			,'`, `total revenue` desc'
			);
	
	prepare stmt from @sqlString;
	execute stmt;
	deallocate prepare stmt;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDatesForEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDatesForEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDatesForEvents`(pFolioID varchar(20), pEventDate date)
BEGIN
select * from event_meal_requirements where folioID=pFolioID and date(eventDate)=pEventDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDeletedRoomIDs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDeletedRoomIDs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDeletedRoomIDs`(pHotelId int(5))
BEGIN
select roomid from rooms where stateflag = 'DELETED' and hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetDetailsForRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetDetailsForRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetDetailsForRequirements`(pReqCode varchar(40))
BEGIN
select * from requirement_details where requirementID=pReqCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetEngineeringJobsHistory` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetEngineeringJobsHistory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetEngineeringJobsHistory`()
BEGIN
select servicename, assignedperson, enggjobno, roomid, startdate, enddate, starttime, endtime from engineeringjobs, engineeringservices where engineeringjobs.enggserviceid=engineeringservices.enggserviceid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetEventAttendance` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetEventAttendance` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetEventAttendance`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
select * from event_attendance where FolioID = pFolioID and HotelID = pHotelID LIMIT 1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetEventContacts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetEventContacts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetEventContacts`(
pFolioID varchar(30),
pHotelID int,
pAccountID varchar(30)
)
BEGIN
select contactpersons.contactID, 
contactpersons.lastName, 
contactpersons.firstName, 
contactpersons.middleName, 
contactpersons.designation, 
contactpersons.personType, 
contactpersons.address, 
contactpersons.telNo, 
contactpersons.mobileNo, 
contactpersons.faxNo, 
contactpersons.email, 
contactpersons.birthdate 
from event_contacts left join contactpersons on event_contacts.contactID = contactpersons.contactID where event_contacts.folioID = pFolioID and event_contacts.hotelID = pHotelID and event_contacts.accountID = pAccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetEventEMDActions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetEventEMDActions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetEventEMDActions`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
select * from event_EMD_actions where folioID = pFolioID and hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetEventEndorsement` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetEventEndorsement` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetEventEndorsement`(
pFolioID varchar(20),
pHotelID varchar(20)
)
BEGIN
select * from event_endorsement where folioID = pFolioID and hotelID = pHotelID LIMIT 1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetEventOfficers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetEventOfficers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetEventOfficers`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
select event_officers.ID, event_officers.userID, event_officers.folioID, users.lastName, users.firstName, event_officers.hotelID 
from event_officers 
left join users 
on users.userID = event_officers.userID 
where event_officers.folioID = pFolioID 
and event_officers.hotelID = pHotelID 
and event_officers.status = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetEventOfficersFullName` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetEventOfficersFullName` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetEventOfficersFullName`(
pHotelID int
)
BEGIN
select distinct concat(users.firstName, ' ' ,users.lastName) as FullName 
from event_officers 
left join users 
on users.userID = event_officers.userID 
where event_officers.hotelID = pHotelID 
and event_officers.status = 'ACTIVE'
and users.Stateflag = 'ACTIVE'
and concat(users.firstName, ' ' ,users.lastName) is not null;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetEventRoomVenues` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetEventRoomVenues` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetEventRoomVenues`(pFolioID varchar(20))
BEGIN
select * from event_room_venues where folioID=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetEventsFromTo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetEventsFromTo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetEventsFromTo`(
pStartDate datetime,
pEndDate datetime,
pHotelID int
)
BEGIN
select RoomID, folioschedules.folioID, folioschedules.fromdate, folioschedules.todate, groupName from folioschedules 
left join folio on folioschedules.folioID = folio.folioID where folioschedules.status = 'ACTIVE' and 
folioschedules.hotelID=pHotelID and folio.Status<>'CANCELLED' and folio.Status<>'WAIT LIST' and 
((date(folioschedules.fromdate) >= date(pStartDate) and 
date(folioschedules.fromdate) <= date(pEndDate)) or (date(folioschedules.todate) >= date(pStartDate) and 
date(folioschedules.todate) <= date(pEndDate)) or (date(folioschedules.fromdate) <= date(pStartDate) and 
date(folioschedules.todate) >= date(pEndDate))) order by RoomID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetEventTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetEventTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetEventTypes`()
BEGIN
select * from event_type where `status` = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetExpectedCheckIn` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetExpectedCheckIn` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetExpectedCheckIn`(
in pAuditDate date,
in photelid int(5)
)
BEGIN
select 
Distinct
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.todate,
folio.status,
folio.folioid
from 
folio,
folioschedules 
where 
folio.folioid = folioschedules.folioid  and 
not (folio.status = 'CLOSED' OR folio.status ='CANCELLED' OR folio.status ='NO SHOW') and
date(folioschedules.fromdate) = pAuditDate and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = pHotelID union(
select distinct
'' as roomid,
'' as roomtype,
folio.todate,
folio.status,
folio.folioid
from folio where folio.foliotype='GROUP' and not (folio.status = 'CLOSED' OR folio.status ='CANCELLED' OR folio.status ='NO SHOW') and
date(folio.fromdate) = pAuditDate and
folio.hotelid = pHotelID)
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetExpectedCheckInFunctionCount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetExpectedCheckInFunctionCount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetExpectedCheckInFunctionCount`(
in pDate date,
in pHotelId int(2)
)
BEGIN
select 
count(distinct folio.folioid) as Total
from 
folio left join folioschedules on
folioschedules.folioid = folio.folioid
where 
(folio.status = 'CONFIRMED' or folio.status = 'TENTATIVE') and
date(folio.fromdate) = pDate and
folio.hotelid = pHotelId and
folioschedules.roomtype = 'FUNCTION'
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spgetexpectedcheckinroomcount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spgetexpectedcheckinroomcount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spgetexpectedcheckinroomcount`(
in pDate date,
in pHotelId int(2)
)
BEGIN
select 
count(distinct folio.folioid) as Total
from 
folio left join folioschedules on
folioschedules.folioid = folio.folioid
where 
(folio.status = 'CONFIRMED' or folio.status = 'TENTATIVE') and
date(folio.fromdate) = pDate and
folio.hotelid = pHotelId and
folioschedules.roomtype != 'FUNCTION'
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetExpectedCheckOuts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetExpectedCheckOuts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetExpectedCheckOuts`(
in pAuditDate date,
in photelid int(5)
)
BEGIN
select 
Distinct
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.todate,
folio.status
from 
folio,
folioschedules 
where 
folio.folioid = folioschedules.folioid  and 
not (folio.status = 'CLOSED' OR folio.status ='CANCELLED' OR folio.status ='NO SHOW') and
date(folio.departuredate) = pAuditDate and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = pHotelID and
folioschedules.roomtype!='FUNCTION'
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetExpectedEndOOO` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetExpectedEndOOO` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetExpectedEndOOO`(
in pAuditDate date,
in photelid int(5)
)
BEGIN
select 
Distinct
roomevents.roomid,
engineeringjobs.startdate,
engineeringjobs.enddate,
engineeringjobs.stateflag as `status`
from 
engineeringjobs,
roomevents 
where 
engineeringjobs.enggjobno = roomevents.eventid  and 
not (stateflag = 'DELETED') and
date(engineeringjobs.enddate) = pAuditDate
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFloorLayoutImage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFloorLayoutImage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFloorLayoutImage`(
in photelid int(5),
in pfloor varchar(10)
)
BEGIN
select floorlayoutimage
from floors
where
hotelid = photelid and `floor` = pfloor;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFloors` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFloors` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFloors`()
BEGIN
select  hotelid,`floor`,floorlayoutimage
from
floors
where
not stateflag = 'DELETED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFOActualRoomSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFOActualRoomSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFOActualRoomSales`(
in pHotelId int(4),
in pDate date
)
BEGIN
select 
(sum(if(acctside='DEBIT',foliotransactions.netamount,0.00)) - 
sum(if(acctside='CREDIT',foliotransactions.netamount,0.00))) as RoomSale
from 
foliotransactions
where 
foliotransactions.transactionCode = '1000' and
(foliotransactions.transactionDate) = pDate
and foliotransactions.status = 'ACTIVE'
and foliotransactions.hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFOExpectedArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFOExpectedArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFOExpectedArrival`(
in pHotelId int(4),
in pDate date
)
BEGIN
select 
count(if(folio.foliotype != "JOINER" and folio.status!='WAIT LIST' and folio.status!='DELETED' and folio.status!='REMOVED' and folio.status!='CANCELLED',folioschedules.folioid,0))+(select count(*) from blockingdetails,roomblock where DATE(blockfrom)=pDate and blockingdetails.blockid=roomblock.blockid and roomblock.folioid!='')  as Rooms,
sum(folio.noofadults + folio.noofchild) as Pax,
(select distinct count(folio.folioid) from folio, folioschedules where pDate = date(folioschedules.fromdate) and folioschedules.folioid = folio.folioid and roomid != '' and foliotype='GROUP' and folio.status!='CANCELLED' and folio.status!='NO SHOW') as functionRoom,
(select distinct count(folio.folioid) from folio, folioschedules where date(folioschedules.fromdate)=pDate and folio.folioid=folioschedules.folioid and folio.status='WAIT LIST' and folio.foliotype!='JOINER') as waitList
from 
folio,
folioschedules 
where 
folio.hotelid = pHotelId and
folio.folioid = folioschedules.folioid and
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW' and
folio.status != 'REMOVED' and
folio.status != 'DELETED') and 
folio.status != 'WAIT LIST' and
date(folioschedules.fromdate) = pDate and
folioschedules.roomtype != 'FUNCTION'
group by pDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFOExpectedDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFOExpectedDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFOExpectedDeparture`(
in pHotelId int(4),
in pDate date
)
BEGIN
select sum(rooms) as rooms, sum(pax) as pax, sum(functionRoom) as functionRoom from
(
select 
count(folioschedules.roomid) as Rooms,
sum(folio.noofadults + folio.noofchild) as Pax,
0 as functionRoom
from 
folio,
folioschedules
where 
folio.hotelid = pHotelId and
folio.folioid = folioschedules.folioid and
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW' and
folio.status != 'DELETED' and
folio.status != 'REMOVED' and
folio.status != 'WAIT LIST') and
(pDate = date(folioschedules.todate)) and
folioschedules.roomtype != 'FUNCTION' and
folio.foliotype!='JOINER'
union (select count(*) as rooms, 0 as pax, 0 as functionRoom from blockingdetails,roomblock where pDate = date(blockto) and blockingdetails.blockid=roomblock.blockid and roomblock.folioid!='')
union (select distinct 0 as rooms, 0 as pax, count(folio.folioid) as functionRoom from folio, folioschedules where ((pDate = date(folioschedules.todate) and folio.status!='CLOSED' and folio.status!='CANCELLED') or (pDate = date(folioschedules.todate) and folio.status!='CANCELLED')) and foliotype='GROUP' and folio.folioid=folioschedules.folioid)
) as expectedInHouse
group by pDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFOExpectedInHouse` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFOExpectedInHouse` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFOExpectedInHouse`(
in pHotelId int(4),
in pDate date
)
BEGIN
select sum(rooms) as rooms, sum(pax) as pax, sum(functionRoom) as functionRoom from
(
select 
count(folioschedules.roomid) as Rooms,
sum(folio.noofadults + folio.noofchild) as Pax,
0 as functionRoom
from 
folio,
folioschedules
where 
folio.hotelid = pHotelId and
folio.folioid = folioschedules.folioid and
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW' and
folio.status != 'DELETED' and
folio.status != 'REMOVED' and
folio.status != 'WAIT LIST') and
(pDate >= date(folioschedules.fromdate) and pDate <=
date(folioschedules.todate)) and
folioschedules.roomtype != 'FUNCTION' and
folio.foliotype!='JOINER'
union (select count(*) as rooms, 0 as pax, 0 as functionRoom from blockingdetails,roomblock where pDate >= date(blockfrom) and pDate <= date(blockto) and blockingdetails.blockid=roomblock.blockid and roomblock.folioid!='')
union (select distinct 0 as rooms, 0 as pax, count(folio.folioid) as functionRoom from folio, folioschedules where ((pDate > date(folioschedules.todate) and if(pDate <= (select auditdate from auditdatetable where meridian='AM'), folio.status!='CLOSED', false) and folio.status!='CANCELLED') or (pDate between date(folioschedules.fromdate) and date(folioschedules.todate) and folio.status!='CANCELLED')) and foliotype='GROUP' and folio.folioid=folioschedules.folioid)
) as expectedInHouse
group by pDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFOExpectedRoomSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFOExpectedRoomSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFOExpectedRoomSales`(
in pHotelId int(4),
in pDate datetime
)
BEGIN
select 
sum(roomevents.roomrate) as RoomSale
from 
roomevents
where 
roomevents.hotelid = pHotelId and
date(roomevents.eventdate) = date(pDate) and
(roomevents.eventtype != 'CANCELLED' and
roomevents.eventtype != 'NO SHOW' and 
roomevents.eventtype != "")
group by roomevents.eventdate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolio`(in pFolioID varchar(20), in pHotelID int(5))
BEGIN
set sql_big_selects=1;
Select * from Folio force index(primary) where folioID = pFolioID and hotelId=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioId` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioId` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioId`(
in pRoomId varchar(10)
)
BEGIN
select eventid from roomevents
where	
roomid = pRoomId and `eventdate` = curdate() and (eventtype = 'IN HOUSE' or eventtype='RESERVATION');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioIdFromRoomEventsByRoomId` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioIdFromRoomEventsByRoomId` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioIdFromRoomEventsByRoomId`(
in pRoomId varchar(20)
)
BEGIN
Select DISTINCT 
Eventid as folioid
from roomevents 
where eventtype ='IN HOUSE' and RoomID = pRoomId limit 0,1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioInclusions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioInclusions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioInclusions`(in pFolioID varchar(20),in pHOtelId int(5))
BEGIN
select 
*
from 	folioinclusions
where 
folioinclusions.folioid=pFolioid and 
folioinclusions.hotelId=pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioPackage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioPackage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioPackage`(in pFolioID varchar(20),in pHOtelId int(5))
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioPrivilege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioPrivilege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioPrivilege`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioRouting` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioRouting` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioRouting`(in pFolioID varchar(20),in pHOtelId int(5))
BEGIN
Select TransactionCode, HotelID, FolioID, SubFOlio, Basis, PercentCharged, 
AmountCharged, CreateTime, CreatedBy, UpdateTime, UpdatedBy from FOlioRouting where folioid=pFolioID and hotelID=pHOtelID
order by transactionCode, subfolio;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetFolioStatus`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
select `status` from folio where folioid = pFolioID and hotelID = pHotelID LIMIT 1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFoliosToCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFoliosToCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFoliosToCharge`(in pDate datetime, in pHotelID int(5))
BEGIN
select distinct folio.folioid from folio, folioschedules where (folioschedules.roomid='' or folioschedules.roomid is null) and folio.folioid=folioschedules.folioid and pDate<folioschedules.todate
and folioschedules.hotelid=pHotelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFoliotoCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFoliotoCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFoliotoCharge`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioTransaction`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioTransactionByTransactionCodeReferenceNo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioTransactionByTransactionCodeReferenceNo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetFolioTransactionByTransactionCodeReferenceNo`(
in pTransactionCode varchar(50),
in pReferenceNo varchar(50)
)
BEGIN
select * from foliotransactions
where
transactionCode = pTransactionCode and
referenceNo = pReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioTransactionByTransactionNo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioTransactionByTransactionNo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetFolioTransactionByTransactionNo`(
in pFolioTransactionNo int(20)
)
BEGIN
select * from foliotransactions
where
folioTransactionNo = pFolioTransactionNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioTransactionLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioTransactionLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioTransactionLedger`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioTransactionRefTranCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioTransactionRefTranCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioTransactionRefTranCode`(
in pTranCode varchar(20),
in pHotelId int(5)
)
BEGIN
Select * FROM transactionCode where trancode=pTrancode and hotelID =pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioTransactions`(
in pFolioID varchar(20),
in pSubFolio varchar(50),
in pHotelID int(5)
)
BEGIN
Select       
*
from 
foliotransactions
where 
folioid=pFolioID and 
subfolio=pSubFolio and 
hotelID=pHOtelID and
`status`='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioTransactionsNonAuditCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioTransactionsNonAuditCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetFolioTransactionsNonAuditCharges`(
pFolioID varchar(20),
pHotelID int(5)
)
BEGIN
Select       
*
from 
foliotransactions 
where 
folioid=pFolioID and 
hotelID=pHOtelID and
acctSide='DEBIT' and 
auditFlag='0' and 
`status`='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioTransPackage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioTransPackage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioTransPackage`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioTransPrivilege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioTransPrivilege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioTransPrivilege`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFolioTransRouting` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFolioTransRouting` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFolioTransRouting`(
in pfolioid varchar(20),
in ptrancode varchar(20),
in photelid int(5)
)
BEGIN
select * from foliorouting
where
folioid = pfolioid and
transactioncode = pTrancode and
hotelid = photelid
order by subfolio asc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFoodDates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFoodDates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFoodDates`(pFolioID varchar(20))
BEGIN
select distinct eventDate from event_meal_requirements where folioID=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFORoomCount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFORoomCount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFORoomCount`(
in pHotelId int(4)
)
BEGIN
select count(roomid) from rooms where
hotelid = pHotelid and
rooms.stateflag != 'DELETED' and rooms.roomtypecode!='FUNCTION';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFO_ExpectedArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFO_ExpectedArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFO_ExpectedArrival`(
in pHotelId int(4),
in pDate date
)
BEGIN
select 
count(if(folio.foliotype != "SHARE",folioschedules.roomid,null)) as Rooms,
sum(folio.noofadults + folio.noofchild) as Pax
from 
folio,
folioschedules 
where 
folio.hotelid = pHotelId and
folio.folioid = folioschedules.folioid and
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW') and 
date(folioschedules.fromdate) = pDate
group by date(folioschedules.fromdate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFO_ExpectedDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFO_ExpectedDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFO_ExpectedDeparture`(
in pHotelId int(4),
in pDate date
)
BEGIN
select 
count(if(folio.foliotype != "SHARE",folioschedules.roomid,null)) as Rooms,
sum(folio.noofadults + folio.noofchild) as Pax
from 
folio,
folioschedules 
where 
folioschedules.roomid != "" and
folio.hotelid = pHotelId and
folio.folioid = folioschedules.folioid and
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW') and 
date(folioschedules.todate) = pDate
group by date(folio.hotelid);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFO_ExpectedInHouse` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFO_ExpectedInHouse` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFO_ExpectedInHouse`(
in pHotelId int(4),
in pDate date
)
BEGIN
select 
count(if(folio.foliotype!="SHARE",folioschedules.roomid,null)) as Rooms,
sum(folio.noofadults + folio.noofchild) as Pax
from 
folio,
folioschedules 
where 
folio.hotelid = pHotelId and
folio.folioid = folioschedules.folioid and
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW') and 
folioschedules.roomid != "" and
(date(folioschedules.fromdate) <= pDate and
date(folioschedules.todate) >= pDate)
group by date(folio.hotelid);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFO_RoomCount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFO_RoomCount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetFO_RoomCount`(
in pHotelId int(4)
)
BEGIN
select count(roomid) from rooms where
hotelid = pHotelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetFunctionStatusAndCleaningSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetFunctionStatusAndCleaningSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetFunctionStatusAndCleaningSummary`(
in pHotelId int(4)
)
BEGIN
select 
rooms.stateflag,
rooms.cleaningstatus,
count(*) as Total
from rooms, roomtypes
where
rooms.roomtypecode = roomtypes.roomtypecode and
roomtypes.roomsupertype = 'FUNCTION' and
rooms.hotelId = pHotelId and rooms.stateflag != 'DELETED'
group by rooms.stateflag,rooms.cleaningstatus;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupBlockings` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupBlockings` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGroupBlockings`(
in pHotelId int(4)
)
BEGIN
set sql_big_selects = 1;
select 
folio.folioid,
folio.fromdate,
folio.todate,
fGetEventTotalRequiredRooms(folio.folioid) as RequiredRooms,
fGetEventTotalBlockedRooms(folio.folioid) as BlockedRooms,
folio.status,
folio.remarks
from
folio
left join folioledger on
folioledger.folioid = folio.folioid
where 
foliotype = 'GROUP' and
folio.hotelid = pHotelId and
folio.status != 'CANCELLED' and
folio.status != 'CLOSED'
group by
folio.folioid
order by
folio.folioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupBooking` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupBooking` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetGroupBooking`(
pFieldName varchar(100)
)
BEGIN
select * from groupbookingdropdown where `StatusFlag` = 'ACTIVE' and FieldName = pFieldName;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupBookingDropDown` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupBookingDropDown` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetGroupBookingDropDown`()
BEGIN
select * from groupbookingdropdown where `StatusFlag` = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupBookingDropDownFieldNames` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupBookingDropDownFieldNames` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetGroupBookingDropDownFieldNames`()
BEGIN
select distinct FieldName from groupbookingdropdown where `StatusFlag` = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupBookingForExportToExcel` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupBookingForExportToExcel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetGroupBookingForExportToExcel`(
)
BEGIN
select 
date_format(folio.fromdate, '%m/%e/%y') as FromDate,
date_format(folio.toDate, '%m/%e/%y') as ToDate,
folio.status,
concat('[', FOLIOSCHEDULES.ROOMID, '] ', folio.groupname, ' - ', if(eventtype is null, '', event_booking_info.eventType), ' / ',folio.folioid) as eventtype,
if(date_format(folioschedules.starttime,'%H') > 0,0,1) as WholeDayEvent,
if(folioschedules.starttime is null, '00:00', folioschedules.starttime) as starttime,
if(folioschedules.endtime is null, '00:00', folioschedules.endtime) as endtime,
folioschedules.roomid as RoomID
from 
folio left join 
event_booking_info on event_booking_info.folioId = folio.folioId 
left join folioschedules on folioschedules.folioid = folio.folioid
where
folio.foliotype = 'GROUP' and
not(folio.status = 'CLOSED'
or folio.status = 'CANCELLED' 
or folio.status = 'NO SHOW');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupCancellations` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupCancellations` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetGroupCancellations`(pAuditDate date)
BEGIN
select distinct
folio.folioid,
if(foliotype='GROUP', folio.folioid, folio.masterfolio) as masterfolio,
foliotype,
groupname,
if(substr(folio.companyid,1,1)='G', fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
if(foliotype='GROUP', folioschedules.roomid, 'NONE') as grouproom,
folioschedules.roomid as room,
date(folioschedules.fromdate) as blockfrom,
date(folioschedules.todate) as blockto,
if(foliotype='DEPENDENT', fGetGroupTotalPax(folio.masterfolio), fGetGroupTotalPax(folio.folioid)) as totalPax,
if(foliotype='DEPENDENT', fGetGroupArrivalDate(folio.masterfolio), date_format(folio.fromdate,'%c/%d/%y')) as groupArrivalDate,
if(foliotype='DEPENDENT', fGetGroupDepartureDate(folio.masterfolio), date_format(folio.todate,'%c/%d/%y')) as groupDepartureDate,
if(foliotype='DEPENDENT', fGetGroupAccountType(folio.masterfolio), accounttype) as groupAccountType,
folio.status,
(select distinct roomtypecode from rooms where rooms.roomid=room) as roomtype,
folio.reason_for_cancel
from folio left join folioschedules on (folio.folioid=folioschedules.folioid) where (foliotype='GROUP' or foliotype='DEPENDENT') and folio.status='CANCELLED' and date(folio.updateTime)=pAuditDate union all
select distinct
roomblock.folioid as folioid,
roomblock.folioid as masterfolio,
'DEPENDENT' as foliotype,
(select groupname from folio where folioid = roomblock.folioid) as groupname,
'' as companyname,
if((select folioschedules.roomid from folioschedules where folioid=roomblock.folioid limit 1)!='',
(select folioschedules.roomid from folioschedules where folioid=roomblock.folioid limit 1), 'NONE') as grouproom,
blockingdetails.roomid as room,
blockingdetails.blockfrom as blockfrom,
blockingdetails.blockto as blockto,
0 as totalPax,
(select date_format(fromdate,'%c/%d/%y') from folio where folioid=roomblock.folioid) as groupArrivalDate,
(select date_format(todate,'%c/%d/%y') from folio where folioid=roomblock.folioid) as groupDepartureDate,
fGetGroupAccountType(roomblock.folioid) as groupAccountType,
'BLOCKED' as `status`,
(select distinct `rooms`.`roomtypecode` AS `roomtypecode` from `rooms` where `rooms`.`roomid` = `room`) as roomType,
'' as reason_for_cancel
from roomblock, blockingdetails where roomblock.blockid=blockingdetails.blockid and (select date(updatetime) from folio where folioid=roomblock.folioid)=pAuditDate and (select folio.status from folio where folioid=roomblock.folioid)='CANCELLED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupedRoomingList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupedRoomingList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGroupedRoomingList`()
BEGIN
select folio.folioid,
if(foliotype='GROUP', folio.folioid, masterfolio) as masterfolio,
foliotype,
groupname,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
noOfAdults,
folioschedules.roomid,
folioschedules.roomtype,
date(folio.fromdate) as fromdate,
date(folio.todate) as todate,
folio.status,
foliotype
from folio left join folioschedules on folio.folioid=folioschedules.folioid where foliotype = 'GROUP'
union all
select companyID as folioid,
'' as masterfolio,
foliotype,
'' as groupname,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
0 as noOfAdults,
'' as roomid,
'' as roomtype,
curdate() as fromdate,
curdate() as todate,
folio.status,
foliotype
from folio where foliotype!='JOINER' and foliotype!='GROUP' and foliotype!='DEPENDENT' and (folio.status='ONGOING' or folio.status='CONFIRMED' or folio.status='TENTATIVE') and companyid!=''
group by folio.companyid order by masterfolio, folioid
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupExpectedCheckIn` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupExpectedCheckIn` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetGroupExpectedCheckIn`(pAuditDate date)
BEGIN
select distinct
folio.folioid,
if(foliotype='GROUP', folio.folioid, folio.masterfolio) as masterfolio,
foliotype,
groupname,
if(substr(folio.companyid,1,1)='G', fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
if(foliotype='GROUP', folioschedules.roomid, 'NONE') as grouproom,
folioschedules.roomid as room,
date(folioschedules.fromdate) as blockfrom,
date(folioschedules.todate) as blockto,
if(foliotype='DEPENDENT', fGetGroupTotalPax(folio.masterfolio), fGetGroupTotalPax(folio.folioid)) as totalPax,
if(foliotype='DEPENDENT', fGetGroupArrivalDate(folio.masterfolio), folio.fromdate) as groupArrivalDate,
if(foliotype='DEPENDENT', fGetGroupDepartureDate(folio.masterfolio), folio.todate) as groupDepartureDate,
if(foliotype='DEPENDENT', fGetGroupAccountType(folio.masterfolio), accounttype) as groupAccountType,
folio.status,
(select distinct roomtypecode from rooms where rooms.roomid=room) as roomtype
from folio left join folioschedules on (folio.folioid=folioschedules.folioid) where (foliotype='GROUP' or foliotype='DEPENDENT') and folio.status!='NO SHOW' and folio.status!='CLOSED' and folio.status!='CANCELLED' and folio.status!='ONGOING' and date(folioschedules.fromdate)=pAuditDate union all
select distinct
roomblock.folioid as folioid,
roomblock.folioid as masterfolio,
'DEPENDENT' as foliotype,
(select groupname from folio where folioid = roomblock.folioid) as groupname,
'' as companyname,
if((select folioschedules.roomid from folioschedules where folioid=roomblock.folioid limit 1)!='',
(select folioschedules.roomid from folioschedules where folioid=roomblock.folioid limit 1), 'NONE') as grouproom,
blockingdetails.roomid as room,
blockingdetails.blockfrom as blockfrom,
blockingdetails.blockto as blockto,
0 as totalPax,
(select fromdate from folio where folioid=roomblock.folioid) as groupArrivalDate,
(select todate from folio where folioid=roomblock.folioid) as groupDepartureDate,
fGetGroupAccountType(roomblock.folioid) as groupAccountType,
'BLOCKED' as `status`,
(select distinct `rooms`.`roomtypecode` AS `roomtypecode` from `rooms` where `rooms`.`roomid` = `room`) as roomType from roomblock, blockingdetails where roomblock.blockid=blockingdetails.blockid and date(blockingdetails.blockfrom)=pAuditDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupExpectedCheckOut` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupExpectedCheckOut` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetGroupExpectedCheckOut`(pAuditDate date)
BEGIN
select distinct
folio.folioid,
if(foliotype='GROUP', folio.folioid, folio.masterfolio) as masterfolio,
foliotype,
groupname,
if(substr(folio.companyid,1,1)='G', fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
if(foliotype='GROUP' and folioschedules.roomid!='', folioschedules.roomid, 'NONE') as grouproom,
folioschedules.roomid as room,
date(folioschedules.fromdate) as blockfrom,
date(folioschedules.todate) as blockto,
if(foliotype='DEPENDENT', fGetGroupTotalPax(folio.masterfolio), fGetGroupTotalPax(folio.folioid)) as totalPax,
if(foliotype='DEPENDENT', fGetGroupArrivalDate(folio.masterfolio), date_format(folio.fromdate,'%c/%d/%y')) as groupArrivalDate,
if(foliotype='DEPENDENT', fGetGroupDepartureDate(folio.masterfolio), date_format(folio.todate,'%c/%d/%y')) as groupDepartureDate,
if(foliotype='DEPENDENT', fGetGroupAccountType(folio.masterfolio), accounttype) as groupAccountType,
folio.status,
(select distinct roomtypecode from rooms where rooms.roomid=room) as roomtype
from folio left join folioschedules on (folio.folioid=folioschedules.folioid) where (foliotype='GROUP' or foliotype='DEPENDENT') and folio.status!='NO SHOW' and folio.status!='CLOSED' and folio.status!='CANCELLED' and date(folioschedules.todate)=pAuditDate union all
select distinct
roomblock.folioid as folioid,
roomblock.folioid as masterfolio,
'DEPENDENT' as foliotype,
(select groupname from folio where folioid = roomblock.folioid) as groupname,
'' as companyname,
if((select folioschedules.roomid from folioschedules where folioid=roomblock.folioid limit 1)!='',
(select folioschedules.roomid from folioschedules where folioid=roomblock.folioid limit 1), 'NONE') as grouproom,
blockingdetails.roomid as room,
blockingdetails.blockfrom as blockfrom,
blockingdetails.blockto as blockto,
0 as totalPax,
(select date_format(fromdate,'%c/%d/%y') from folio where folioid=roomblock.folioid) as groupArrivalDate,
(select date_format(todate,'%c/%d/%y') from folio where folioid=roomblock.folioid) as groupDepartureDate,
fGetGroupAccountType(roomblock.folioid) as groupAccountType,
'BLOCKED' as `status`,
(select distinct `rooms`.`roomtypecode` AS `roomtypecode` from `rooms` where `rooms`.`roomid` = `room`) as roomType from roomblock, blockingdetails where roomblock.blockid=blockingdetails.blockid and date(blockingdetails.blockto)=pAuditDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupIndividualFolios` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupIndividualFolios` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGroupIndividualFolios`(
in photelid int(5)
)
BEGIN
Select 
guests.accountid as companyid,
folio.groupname,
concat(guests.lastname, ', ', guests.firstname) as companyname,
folioid
from 	
folio,guests
where 
guests.accountid = folio.companyid and
(folio.accountType!="PERSONAL") and 
`status` = 'ONGOING' and folio.hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spgetgrouplist` */

/*!50003 DROP PROCEDURE IF EXISTS  `spgetgrouplist` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spgetgrouplist`(
in pHotelId int(4)
)
BEGIN
set sql_big_selects = 1;
select 
folio.folioid,
folio.groupname,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
folio.fromdate,
folio.todate,
sum(folioledger.balancenet) as Balance,
sum(folioledger.charges) as Charges,
fGetEventTotalRequiredRooms(folio.folioid) as RequiredRooms,
fGetEventTotalBlockedRooms(folio.folioid) as BlockedRooms,
folio.status,
folio.remarks
from
folio
left join folioledger on
folioledger.folioid = folio.folioid
where 
foliotype = 'GROUP' and
folio.hotelid = pHotelId and
folio.status != 'CANCELLED' and
folio.status != 'CLOSED'
group by
folio.folioid
order by
folio.folioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spgetgroupreservationlist` */

/*!50003 DROP PROCEDURE IF EXISTS  `spgetgroupreservationlist` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spgetgroupreservationlist`(
in pHotelId int(4)
)
BEGIN
set sql_big_selects = 1;
select 
folio.folioid,
folio.groupname,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
folio.fromdate,
folio.todate,
sum(folioledger.balancenet) as Balance,
sum(folioledger.charges) as Charges,
fGetEventTotalRequiredRooms(folio.folioid) as RequiredRooms,
fGetEventTotalBlockedRooms(folio.folioid) as BlockedRooms,
folio.status,
folio.remarks,
'' as roomsBlocked
from
folio
left join folioledger on
folioledger.folioid = folio.folioid
where 
foliotype = 'GROUP' and
folio.hotelid = pHotelId and
folio.status != 'ONGOING' and
folio.status != 'CANCELLED' and
folio.status != 'CLOSED'
group by
folio.folioid
order by
folio.folioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGroupRoomBlocks` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGroupRoomBlocks` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetGroupRoomBlocks`(pDate date)
BEGIN
select reason, roomid, blockfrom, blockto from roomblock, blockingdetails 
where roomblock.blockid=blockingdetails.blockid and folioid!=''
and pDate between date(blockFrom) and date(blockTo)
order by blockfrom;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestByCriteria` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestByCriteria` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestByCriteria`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestFolioHistory` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestFolioHistory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestFolioHistory`(
in pAccountID varchar(20),
in pHotelID int(5)
)
BEGIN
select *, fGetDriverName(folio.folioid) as driver
from folio
where 
if(foliotype='GROUP', folio.companyid = pAccountid, folio.accountid = pAccountid) and 
folio.hotelid= pHotelId and
folio.status!='CANCELLED' aND folio.status!='DELETED' and folio.status != 'REMOVED' and folio.status != 'NO SHOW'
union
select distinct folio.*, fGetDriverName(folio.folioid) as driver
from folio, folioledger
where 
folioledger.accountid = pAccountid and 
folio.hotelid= pHotelId and 
folio.status != 'CANCELLED' aND 
folio.status != 'DELETED' and
FOLIO.STATUS != 'REMOVED' AND
folio.status != 'NO SHOW' and
folioledger.folioid=folio.folioid and
folio.foliotype != 'DEPENDENT'
order by folioid desc
limit 0, 15;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestFolioInfo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestFolioInfo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestFolioInfo`(
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
folio.status,
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestInfo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestInfo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestInfo`(
in pfolioid varchar(20)
)
BEGIN
select 
folio.folioid,
date(folioschedules.fromdate) as ARRIVALDATE,
DATE(folioschedules.todate) as DEPARTUREDATE,
concat(folioschedules.roomid," ",folioschedules.roomtype) as ROOM,
folioschedules.roomid,folioschedules.roomtype,
folioschedules.RATE,
folioschedules.DAYS,
folio.noofadults,
folio.noofchild,
folio.updatedby,
guests.TITLE,
guests.LASTNAME,
guests.FIRSTNAME,
guests.MIDDLENAME,
guests.CITIZENSHIP,	
guests.PASSPORTID,
folio.source,
guests.TelephoneNo,
company.companyname,
folio.remarks,
concat(guests.street," ",guests.city," ", guests.country, " ",guests.zip) as ADDRESS
from
folioschedules,
guests,
folio left join company on company.companyid = folio.companyid
where
guests.accountid = folio.accountid and
folioschedules.folioid = if(folio.folioType = 'JOINER',folio.masterFolio ,folio.folioid) and
folio.folioid = pfolioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestLatestCompanyId` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestLatestCompanyId` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetGuestLatestCompanyId`(
pAccountId varchar(20),
pHotelId int(4)
)
BEGIN
select 
companyID 
from folio 
where 
accountID = pAccountId and 
companyID != "" and
hotelId = pHotelId
order by folioid desc limit 0,1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestListDefaults` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestListDefaults` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestListDefaults`()
BEGIN
select * 
from guestlistdefaults;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestListSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestListSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestListSummary`(
in pAuditDate date
)
BEGIN
(select 
folio.status, 
count(distinct folioschedules.folioid) as Total
from folio
left join folioschedules 
on folioschedules.folioid = folio.folioid
where
foliotype <> 'JOINER' and
(folio.status = 'CONFIRMED' or
folio.status = 'TENTATIVE' or
folio.status = 'WAIT LIST')
group by folio.status
)UNION
(select 
folio.status, 
count(distinct folioschedules.folioid) as Total
from folio
left join folioschedules 
on (folioschedules.folioid = folio.folioid)
where
foliotype <> 'JOINER' and
(folio.status = 'ONGOING') AND
pAuditDate >= date(folioschedules.fromdate) and pAuditDate <= date(folioschedules.todate)
group by folio.status
)
UNION(
select 
'EXPECTED CHECK-IN' as `status`, 
count(distinct folio.folioid)  as Total
from folio
where
foliotype <> 'JOINER' and
date(folio.fromdate) = pAuditDate and
(folio.status = 'CONFIRMED' or
folio.status = 'TENTATIVE')
group by 'EXPECTED CHECK-IN'
)UNION(
select 
'EXPECTED CHECK-OUT' as `status`, 
count(distinct folio.folioid)  as Total
from folio
where
(
foliotype <> 'JOINER') and
date(folio.toDate) = pAuditDate and
(folio.status = 'ONGOING')
group by 
'EXPECTED CHECK-OUT'
)UNION(
select 
`status`, 
count(distinct folio.folioid) as Total 
from folio
where
(
foliotype <> 'JOINER') and
(`status` = 'CLOSED')
and
date(folio.departuredate) = pAuditDate
group by `status`)
UNION(
select 
`status`, 
count(distinct folio.folioid) as Total 
from folio
where
(
foliotype <> 'JOINER') and
(`status` = 'CANCELLED' or
`status` = 'NO SHOW')
and
date(folio.updatetime) = pAuditDate
group by `status`);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestPrivelege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestPrivelege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestPrivelege`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestPrivilege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestPrivilege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestPrivilege`(in pAccountId varchar(20),in pHotelId int(5))
BEGIN
Select *,transactioncode.memo from guestprivilegeheader,guestprivilegedetails,transactioncode where guestPrivilegeheader.accountid=pAccountId and guestPrivilegeheader.hotelId=pHotelId and guestPrivilegeheader.privilegeid=guestprivilegedetails.privilegeid and guestprivilegedetails.trancode=transactioncode.trancode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestRecord` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestRecord` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestRecord`(
in pAccountid varchar(12),
in pHotelID int(5)
)
BEGIN
set sql_big_selects = 1;
Select * from Guests force index(primary) where accountid=pAccountid and HotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestRefName` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestRefName` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestRefName`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestsList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestsList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestsList`(
in pHotelID int(4)
)
BEGIN
set sql_big_selects=1;
select 
folio.folioid,
guests.accountID,
concat(guests.lastname,', ',guests.firstname) as guestName,
guests.concierge,
guests.remark,
guests.ACCOUNT_TYPE,
guests.THRESHOLD_VALUE,
folio.groupname,
company.companyName,
folio.fromdate,
folio.todate,
sum(folioledger.balancenet) as Balance,
folio.status,
folio.remarks,	
folio.foliotype,
folio.masterfolio,
concat(folio.noofadults,'/',folio.noofchild) as Pax,
folio.folioETA,
folio.folioETD,
folio.REASON_FOR_CANCEL,
folio.sales_executive,
folio.createdBy,
folio.updateTime
from
folio force index(folioid)
left join folioledger on
folioledger.folioid = folio.folioid
left join company on
company.companyid = folio.companyid
left join guests on
guests.accountid = folio.accountid
where 
foliotype <> 'GROUP'
and folio.hotelid = pHotelID
group by
folio.folioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetGuestsToTransfer` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetGuestsToTransfer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetGuestsToTransfer`()
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
folio.status = 'ONGOING' and
folioschedules.arrivaldate = adddate(curdate(),1);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetHKForecast` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetHKForecast` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetHKForecast`(
pFromDate datetime,
pToDate datetime		
)
BEGIN
select EVENTDATE,count(*) as TotalRooms,count(EventType) as TotalCheckOut from RoomEvents
WHERE date(EVENTDATE) between pFromDate and pToDate
group by date(EVENTDATE);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetHKForecastDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetHKForecastDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetHKForecastDetail`(
pFromDate datetime,
pToDate datetime
)
BEGIN
select EVENTDATE,RoomID,EventType from RoomEvents
WHERE date(EVENTDATE) between pFromDate and pToDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetHK_Housekeepers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetHK_Housekeepers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetHK_Housekeepers`()
BEGIN
select CONCAT(housekeeperid,'-',lastname,',',firstname) as HouseKeeper from hk_housekeepers where stateflag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetHouseKeepingLogs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetHouseKeepingLogs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetHouseKeepingLogs`()
BEGIN
select Hk_Date,roomid, concat(housekeepers.housekeeperid,'-',housekeepers.`firstname`,' ',housekeepers.`lastname`) as housekeeper, TransID, Time from `hk_log`,`housekeepers`
WHERE 
(housekeepers.`housekeeperid`=hk_log.`housekeeperid` and TransID ='FINISH' and parseFlag=0) or 		(housekeepers.`housekeeperid`=hk_log.`housekeeperid` and parseFlag=0);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetHouseKeeping_Logs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetHouseKeeping_Logs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetHouseKeeping_Logs`(IN pStatus VARCHAR(30), IN pDate DATE)
BEGIN
if pStatus='ALL' then
(
Select rooms.`roomid` as RoomId,rooms.roomtypecode as RoomType,starttime as StartTime,endtime as EndTime,
elapsedtime as Duration,concat(hk_housekeepers.housekeeperid,'-',lastname,', ',firstname) as Housekeeper,cleaningstatus,rooms.stateflag
from
rooms left join hk_housekeepingjobs on  hk_housekeepingjobs.`roomid`=rooms.`roomid`
left join hk_housekeepers on hk_housekeepers.housekeeperid=hk_housekeepingjobs.housekeeperid
WHERE housekeepingdate =pDate and rooms.stateflag!='DELETED'
)
Union
(Select rooms.`roomid` as RoomId,rooms.roomtypecode as RoomType,'' as StartTime,'' as EndTime,
'' as Duration,'' as Housekeeper,cleaningstatus,rooms.stateflag
from rooms
WHERE  rooms.`roomid` not in(Select roomid from `hk_housekeepingjobs` WHERE housekeepingdate=pDate) and rooms.stateflag!='DELETED'
);
else
(
Select rooms.`roomid` as RoomId,rooms.roomtypecode as RoomType,starttime as StartTime,endtime as EndTime,
elapsedtime as Duration,concat(hk_housekeepers.housekeeperid,'-',lastname,', ',firstname) as Housekeeper,cleaningstatus,rooms.stateflag
from
rooms
left join hk_housekeepingjobs on  hk_housekeepingjobs.`roomid`=rooms.`roomid`
left join hk_housekeepers on hk_housekeepers.housekeeperid=hk_housekeepingjobs.housekeeperid
WHERE cleaningstatus=pStatus and housekeepingdate =pDate and rooms.stateflag!='DELETED'
)
UNION
(Select rooms.`roomid` as RoomId,rooms.roomtypecode as RoomType,'' as StartTime,'' as EndTime,
'' as Duration,'' as Housekeeper,cleaningstatus,rooms.stateflag
from rooms
WHERE cleaningstatus=pStatus and rooms.`roomid` not in(Select roomid from `hk_housekeepingjobs` WHERE housekeepingdate=pDate) and rooms.stateflag!='DELETED'
)
;
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetIncumbentOfficers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetIncumbentOfficers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetIncumbentOfficers`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
select * from event_incumbent_officers left join contactpersons on event_incumbent_officers.contactID = contactpersons.contactID where event_incumbent_officers.folioID = pFolioID and event_incumbent_officers.hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetIndividualFolios` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetIndividualFolios` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetIndividualFolios`(
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
folio.accountid,
guests.threshold_value
from 	
folio,guests 
where 
guests.accountid = folio.accountid and
folio.folioType != "GROUP" and folio.foliotype != 'JOINER' and 
`status` = 'ONGOING' and folio.hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetIndividualRoomingList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetIndividualRoomingList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetIndividualRoomingList`(pAccountId varchar(30))
BEGIN
select distinct folio.folioid,
if(foliotype='GROUP', folio.folioid, masterfolio) as groupFolio,
foliotype,
groupname,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
fGetGuestName(folio.accountid) as accountName,
noOfAdults,
folioschedules.roomid,
folioschedules.roomtype,
date(folio.fromdate) as fromdate,
date(folio.todate) as todate
from folio left join folioschedules on folio.folioid=folioschedules.folioid where foliotype != 'GROUP' and 
folio.status!='CANCELLED' and folio.status!='NO SHOW' and folio.status!='CLOSED' and folio.companyid=pAccountId
order by roomid, folioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetIndividualRoomsToCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetIndividualRoomsToCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetIndividualRoomsToCharge`(
in pDate date,
in pHotelId int(5)
)
BEGIN
select
eventid,
roomid,
max(roomrate) as roomrate
from 	
roomevents, folio
where 	
eventDate = pDate and
eventType = 'IN HOUSE' and
transferflag = '0' and
roomevents.hotelid = photelid and
(chargeflag='0' or eventid not in (select folioid from foliotransactions where transactioncode='1000' and date(transactiondate)=pDate and foliotransactions.status<>'VOID' and foliotransactions.acctside<>'CREDIT' and adjustmentFlag<>'1'))
and folio.folioid=roomevents.eventid and folio.foliotype!='GROUP'
group by eventid order by roomid;
end */$$
DELIMITER ;

/* Procedure structure for procedure `spGetItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetItem`(
in pItem_ID varchar(20),
in pResto_id int(10)
)
BEGIN
Select *,maingroup_id from `item`, `group`
where item_id=pItem_ID and item.group_id=group.group_id
AND ITEM.RESTO_ID=pResto_id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetLastPocessedAuditDate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetLastPocessedAuditDate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetLastPocessedAuditDate`(
)
BEGIN
Select SystemDate from auditdatetable where  Meridian="PROCESSED" order by SystemDate DESC limit 0,1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetLatestReferenceNo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetLatestReferenceNo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetLatestReferenceNo`(
pFolioId varchar(30),
pMonth int,
pYear int,
pHotelID int
)
BEGIN
select referenceNo from folio where folioId <> pFolioId and month(fromDate) = pMonth and Year(fromDate) = pYear and hotelID = pHotelID order by referenceNo DESC LIMIT 1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetLedgerType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetLedgerType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetLedgerType`( pTrancode varchar(11))
BEGIN
select ledger from transactioncode where trancode=ptrancode;	
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetLoggedUserPersonalInfo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetLoggedUserPersonalInfo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetLoggedUserPersonalInfo`(
in puserid varchar(20)
)
BEGIN
select 
UserId,
`Password`,
EmployeeIdNo,
LastName,
FirstName,
Department,
Designation,
Stateflag,
HotelId   
from users
where
userid = puserid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetLookUpValue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetLookUpValue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetLookUpValue`(
in pCategory varchar(25)
)
BEGIN
select Code,Description from Lookuptable where category=pCategory;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMainItemGroup` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMainItemGroup` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetMainItemGroup`(pGroupID varchar(30))
BEGIN
select maingroup_id from `group` where group_id=pGroupID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMarketingOfficers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMarketingOfficers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMarketingOfficers`(
pHotelID int
)
BEGIN
select distinct sales_Executive from folio left join users on users.UserId=folio.sales_Executive where 
folio.hotelID = pHotelID and users.Stateflag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMealDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMealDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMealDetails`(pMealID bigint(20), pMealDate date, pFolioID varchar(30))
BEGIN
select event_meal_details.mealID, event_meal_details.menuCode, event_meal_details.menuItemCode, event_meal_details.description, event_meal_details.remarks, event_meal_details.price from event_meal_details, event_meal_requirements where event_meal_details.mealID=pMealID and event_meal_details.mealID=event_meal_requirements.mealID and date(event_meal_requirements.eventDate)=pMealDate and folioid=pFolioID order by event_meal_details.id, event_meal_details.description;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMealHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMealHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMealHeader`(pFolioID varchar(20), pEventDate date)
BEGIN
select * from event_meal_header where folioID=pFolioID and date(eventDate)=pEventDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMealHeaderDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMealHeaderDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMealHeaderDetails`(pFolioID varchar(20), pMealType varchar(30))
BEGIN
select * from event_meal_header where folioID=pFolioID and mealType=pMealType;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spgetMealItemsForMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spgetMealItemsForMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spgetMealItemsForMenu`(pMenuID varchar(30))
BEGIN
select distinct meal_menu.description as menu_description, meal_menu.menuID, meal_items.description as item_description, meal_items.itemID from meal_menu, meal_items, meal_menu_detail where meal_menu.`status`='active' and meal_items.`status`='active' and meal_menu.menuID=meal_menu_detail.menuID and meal_menu_detail.itemID=meal_items.itemID and cast(meal_menu.menuID as char)=pMenuID order by meal_menu_detail.id, meal_menu.description, meal_items.description;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMealMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMealMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMealMenu`()
BEGIN
select * from meal_menu where `status`='active' order by description;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMealMenuItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMealMenuItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMealMenuItem`()
BEGIN
select distinct * from meal_items where meal_items.`status`='active' order by description;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetMenu`(
in pMenu_id varchar(10)
)
BEGIN
Select * from `menu`
where menu_id=pMenu_id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMenus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMenus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetMenus`(
pMenu varchar(30) 
)
BEGIN
Select * from Menus where menu=pMenu order by menu;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyAverageRoomRate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyAverageRoomRate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMonthlyAverageRoomRate`(
in pHotelId int(2),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select  sum(rate) as TOTALRATE, 
count(distinct folioschedules.folioid) as TOTALFOLIO,
sum(rate)/count(distinct folioschedules.folioid) as AverageRoomRate
from folioschedules
left join folio on folio.folioid = folioschedules.folioid
where
(folio.status = "ONGOING" or
folio.status = "CLOSED" or
folio.status = "CONFIRMED" or
folio.status = "TENTATIVE") and
(month(folioschedules.fromdate) = pMonth and year(folioschedules.fromDate) = pYear) or
(month(folioschedules.toDate) = pMonth and year(folioschedules.toDate) = pYear);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyAverageRoomRatePerGuest` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyAverageRoomRatePerGuest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMonthlyAverageRoomRatePerGuest`(
in pHotelId int(1),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select  sum(rate) as TOTALRATE, 
sum(folio.noofadults) as TOTALFOLIO,
sum(rate)/sum(folio.noofadults) as AverageRoomRate
from folioschedules
left join folio on folio.folioid = folioschedules.folioid
where
(folio.status = "ONGOING" or
folio.status = "CLOSED" or
folio.status = "CONFIRMED" or
folio.status = "TENTATIVE") and
(
(month(folioschedules.fromdate) = pMonth and 
year(folioschedules.fromdate) = pYear ) or
(month(folioschedules.todate) = pMonth and 
year(folioschedules.todate) = pYear )
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyCancelledNoShowReservations` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyCancelledNoShowReservations` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetMonthlyCancelledNoShowReservations`(
in pHotelId int(4),
in pMonth int(4),
in pYear int(4)
)
BEGIN
select 
folio.status,
count(if(folio.foliotype != "SHARE",folioschedules.roomid,null)) as Rooms
from 
folio,
folioschedules 
where 
folio.hotelid = pHotelId and
folio.folioid = folioschedules.folioid and
(folio.status = 'CANCELLED' or
folio.status = 'NO SHOW') and 
month(folioschedules.fromdate) = pMonth and
year(folioschedules.fromdate) = pYear 
group by folio.status,month(folioschedules.fromdate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyGuestAR` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyGuestAR` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMonthlyGuestAR`(
in pHotelId int(4),
in pDate datetime
)
BEGIN
select
foliotransactions.postingdate,
sum(if(foliotransactions.acctside='DEBIT',baseamount,0)) - sum(if(acctside='CREDIT',baseamount,0)) as BALANCE
from
foliotransactions 
left join folio on folio.folioid = foliotransactions.folioid
where
foliotransactions.`status` = 'ACTIVE' and
foliotransactions.postingdate <= concat(last_day(pDate),' ',time(pDate))  and
foliotransactions.hotelid = pHotelId
group by
date(concat(last_day(pDate),' ',time(pDate)));
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyHotelRevenue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyHotelRevenue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetMonthlyHotelRevenue`(pStartMonth int, pEndMonth int, pStartYear int, pEndYear int)
BEGIN
select
transactionDate as dateOfTransaction,
concat(monthname(transactiondate), ' ', year(transactiondate)) as transactionDate,
sum(header1) as header1,
sum(header2) as header2,
sum(header3) as header3,
sum(header4) as header4,
sum(header5)as header5,
sum(header6)as header6,
sum(header7)as header7,
sum(header8)as header8,
sum(header9)as header9,
sum(header10)as header10,
sum(header11)as header11,
sum(header12)as header12,
sum(header13)as header13,
sum(header14)as header14,
sum(header15)as header15,
sum(header16)as header16,
sum(header17)as header17,
sum(header18)as header18,
sum(header19)as header19,
sum(header20)as header20,
sum(header21)as header21,
sum(header22)as header22,
sum(header23)as header23,
sum(header24)as header24,
sum(header25)as header25,
sum(header26)as header26,
sum(header27)as header27,
sum(header28)as header28,
sum(header29)as header29,
sum(header30)as header30,
sum(header31)as header31,
sum(header32)as header32,
sum(header33)as header33,
sum(header34)as header34,
sum(header35)as header35,
sum(header36)as header36,
sum(header37)as header37,
sum(header38)as header38,
sum(header39)as header39,
sum(header40)as header40,
sum(header41)as header41,
sum(header42)as header42,
sum(header43)as header43,
sum(header44)as header44,
sum(header45)as header45,
sum(header46)as header46,
sum(header47)as header47,
sum(header48)as header48,
sum(header49)as header49,
sum(header50)as header50,
sum(header51)as header51,
sum(header52)as header52,
sum(header53)as header53,
sum(header54)as header54,
sum(header55)as header55,
sum(header56)as header56,
sum(header57)as header57,
sum(header58)as header58,
sum(header59)as header59,
sum(header60)as header60,
sum(header61)as header61,
sum(header62)as header62,
sum(header63)as header63,
sum(header64)as header64,
sum(header65)as header65,
sum(header66)as header66,
sum(header67)as header67,
sum(header68)as header68,
sum(header69)as header69,
sum(header70)as header70,
sum(header71)as header71,
sum(header72)as header72,
sum(header73)as header73,
sum(header74)as header74,
sum(header75)as header75,
sum(header76)as header76,
sum(header77)as header77,
sum(header78)as header78,
sum(header79)as header79,
sum(header80)as header80,
sum(header81)as header81,
sum(header82)as header82,
sum(header83)as header83,
sum(header84)as header84,
sum(header85)as header85,
sum(header86)as header86,
sum(header87)as header87,
sum(header88)as header88,
sum(header89)as header89,
sum(header90)as header90,
sum(header91)as header91,
sum(header92)as header92,
sum(header93)as header93,
sum(header94)as header94,
sum(header95)as header95,
sum(header96)as header96,
sum(header97)as header97,
sum(header98)as header98,
sum(header99)as header99,
sum(header100)as header100,
sum(header101)as header101,
sum(header102)as header102,
sum(header103)as header103,
sum(header104)as header104,
sum(header105)as header105,
sum(header106)as header106,
sum(header107)as header107,
sum(header108)as header108,
sum(header109)as header109,
sum(header110)as header110,
sum(header111)as header111,
sum(header112)as header112,
sum(header113)as header113,
sum(header114)as header114,
sum(header115)as header115,
sum(header116)as header116,
sum(header117)as header117,
sum(header118)as header118,
sum(header119)as header119,
sum(header120)as header120
from
(select * from hotelrevenue) as hotelrevenue where month(transactiondate) between pStartMonth and pEndMonth and year(transactiondate) between pStartYear and pEndYear group by concat(monthname(transactiondate), ' ', year(transactiondate)) order by dateOfTransaction;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyReservationsByAccountType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyReservationsByAccountType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetMonthlyReservationsByAccountType`(
in pHotelId int(4),
in pMonth int(4),
in pYear int(4)
)
BEGIN
select 
folio.accounttype,
count(if(folio.foliotype != "SHARE",folioschedules.roomid,null)) as Rooms
from 
folio,
folioschedules 
where 
folio.hotelid = pHotelId and
folio.folioid = folioschedules.folioid and
month(folioschedules.fromdate) = pMonth and
year(folioschedules.fromdate) = pYear 
group by folio.accounttype,month(folioschedules.fromdate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyReservationSummaryBySource` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyReservationSummaryBySource` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMonthlyReservationSummaryBySource`(
in pHotelId int(4),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select 
if(folio.`source`= "WALK IN","WALK IN","RESERVE") as SOURCE,
count(*)  as Total
from 
folio 
where (`status` = 'ONGOING' or `status` = 'CLOSED' or 
`status` = 'CONFIRMED') and
month(folio.fromdate) = pMonth and year(folio.fromDate) = pYear
and hotelId = pHotelId
group by folio.`source`
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyTotalFunctions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyTotalFunctions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMonthlyTotalFunctions`(
in pHotelId int(4),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select *
from folio 
where
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
foliotype = 'GROUP' and 
((month(fromdate) = pMonth and
year(fromdate) = pYear) or
(month(todate) = pMonth and
year(todate) = pYear))
and
hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyTotalRoomStayOver` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyTotalRoomStayOver` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMonthlyTotalRoomStayOver`(
in pHotelId int(4),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select count(*) from folio 
where
(
(month(fromDate) = pMonth and
year(fromDate) = pYear) or
(month(toDate) = pMonth and
year(toDate) = pYear)
) and
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
foliotype = 'INDIVIDUAL' and
folio.hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyWalkinCorporateFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyWalkinCorporateFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMonthlyWalkinCorporateFolio`(
in pHotelId int(5),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select 
count(*) as Total,
accounttype
from folio 
left join guests on guests.accountid = folio.accountid
where 
(`status` = 'ONGOING' or
`status` = 'CLOSED' or
`status` = 'CONFIRMED' or
`status` = 'TENTATIVE') and
folio.accounttype = 'CORPORATE' and
month(folio.fromdate) = pMonth and
year(folio.fromdate) = pYear and
folio.source = 'WALK IN' and
folio.hotelid = pHotelId
group by folio.accounttype;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetMonthlyWalkinPersonalFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetMonthlyWalkinPersonalFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetMonthlyWalkinPersonalFolio`(
in pHotelId int(5),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select 
count(*) as Total,
if(date(guests.createtime) = date(folio.createtime),"NEW","OLD") as guestType
from folio 
left join guests on guests.accountid = folio.accountid
where 
(`status` = 'ONGOING' or
`status` = 'CLOSED' or
`status` = 'CONFIRMED' or
`status` = 'TENTATIVE') and
folio.accounttype = "PERSONAL" and
month(folio.fromdate) = pMonth and
year(folio.fromdate) = pYear and
folio.source = 'WALK IN' and
folio.hotelId = pHotelId
group by guestType;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetName` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetName` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetName`(
in pAccountID varchar(20),photelID int(5)
)
BEGIN
select concat(firstname," ",lastname) from guests where accountid=pAccountID and hotelid=pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetOutOfOrderRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetOutOfOrderRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetOutOfOrderRooms`()
BEGIN
select roomid, roomtypecode
from
rooms
where
stateflag = 'OUT OF ORDER';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetOutOfOrderRoomsReport` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetOutOfOrderRoomsReport` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetOutOfOrderRoomsReport`()
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetPackageDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetPackageDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetPackageDetails`(in pPackageID varchar(20))
BEGIN
select distinct packageDetails.transactionCOde,packageDetails.percentOff,packageDetails.amountOff,transactionCode.Memo,packagedetails.basis,packageHeader.daysapplied from packageDetails,transactioncode,packageheader where packageheader.packageid = packagedetails.packageid and packagedetails.packageid=pPackageID and packagedetails.transactioncode=transactioncode.trancode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetPackageHeaderInfo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetPackageHeaderInfo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetPackageHeaderInfo`(
in pPackageId varchar(20),
in pHotelId int(5)
)
BEGIN
Select * FROM packageHeader where PackageId=pPackageId and hotelID =pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetPackages` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetPackages` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetPackages`(in pHotelID int(5))
BEGIN
select * from packageHeader where hotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetPayments` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetPayments` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetPayments`(
in pFolioID varchar(20), 
in photelid int(5),
in pSubFolio varchar(1)
)
BEGIN
select sum(netamount),subfolio
from 
folioTransactions 
where 
acctside = 'CREDIT' and
folioId= pFolioId and 
hotelid = pHotelId AND
`status` = 'ACTIVE' and
subfolio = pSubFolio
group by subfolio;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetPercentSrvCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetPercentSrvCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetPercentSrvCharge`(
ptrancode varchar(20),
pdeptid varchar(20),
pHotelid int(5)
)
BEGIN
select percentSrvChrg from servicecharge
where trancode=ptrancode and deptid = pdeptid and hotelid=pHotelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRangeRoomUtilization` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRangeRoomUtilization` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRangeRoomUtilization`(
pStartDate date,
pEndDate date,
pHotelId int
)
BEGIN
select rooms.roomtypecode, rooms.roomdescription, 
if(sum((HOUR(subtime(folioschedules.endTime, folioschedules.startTime)) * (datediff(folioschedules.todate,folioschedules.fromdate) + 1))) is null, 0,sum((HOUR(subtime(folioschedules.endTime, folioschedules.startTime)) * (datediff(folioschedules.todate,folioschedules.fromdate) + 1)))) as hours 
from rooms left join 
((select folioschedules.startTime, folioschedules.endTime, if(folioschedules.fromdate < pStartDate, pStartDate, folioschedules.fromdate) as fromdate, if(folioschedules.todate > pEndDate, pEndDate, folioschedules.todate) as todate, folioschedules.roomId from folioschedules left join folio on folioschedules.folioId = folio.folioId where folio.status = 'CLOSED' and folioschedules.HOTELID = pHotelId and folio.HotelId = pHotelId and ((folioschedules.fromdate >= pStartDate and folioschedules.fromdate <=pEndDate) or (folioschedules.todate >= pStartDate and folioschedules.todate <= pEndDate))) as folioschedules) 
on rooms.roomId = folioschedules.roomId 
where rooms.hotelid = pHotelId and rooms.stateflag != 'DELETED'
group by rooms.roomdescription;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRangeTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRangeTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRangeTransactions`(
pHotelId varchar(100),
pFrom datetime,
pTo datetime
)
BEGIN
select foliotransactions.folioId, foliotransactions.transactionDate, folio.groupName, foliotransactions.transactionCode, transactioncode.memo as transaction, foliotransactions.memo, foliotransactions.acctSide,foliotransactions.netAmount, folio.status from foliotransactions left join transactioncode on foliotransactions.transactionCode = transactioncode.tranCode left join folio on foliotransactions.folioId = folio.folioId where foliotransactions.transactionDate >= pFrom and foliotransactions.transactionDate <= pTo and foliotransactions.hotelId = pHotelId and foliotransactions.status = 'ACTIVE' order by transactionDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRateAmount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRateAmount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRateAmount`(
in pRateTypeCode varchar(100),
in pRoomTypeCode varchar(50)
)
BEGIN
select rateamount from ratetypes where RATECODE=pRateTypeCode and roomtypecode=pRoomTypeCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRateType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRateType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRateType`(
pRoomType varchar(80),
pHotelId int(2)
)
BEGIN
select ratecode from ratetypes where roomtypecode=pRoomType and HotelID=pHotelId
order by ratecode desc, rateamount desc, hasbreakfast desc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRateTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRateTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRateTypes`()
BEGIN
Select * from RATECODES order by ratecode desc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRecurringCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRecurringCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRecurringCharge`(
in pFolioID varchar(20),
in pHOtelId int(5))
BEGIN
Select * 
from 
foliorecurringcharge 
where folioid=pFolioID and hotelID=pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetReferenceTime` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetReferenceTime` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetReferenceTime`()
BEGIN
Select reftime,`min`,`max` from referencetime;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRequirements`(pRequirementCode varchar(40))
BEGIN
select * from requirement_details where requirementCode=pRequirementCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoleMenus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoleMenus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoleMenus`(
in pRoleName varchar(30),
in pHotelId int(5)
)
BEGIN
select * 
from 
rolemenu 
where
rolename = pRoleName and
hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRolePrivileges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRolePrivileges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRolePrivileges`(
in pRoleName varchar(50),
in pHotelId int(4)
)
BEGIN
select * from role_privileges
where roleName = pRoleName and
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoleSystemPrivileges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoleSystemPrivileges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoleSystemPrivileges`(
in pRoleName varchar(50)
)
BEGIN
select * from `role_privileges`
where 
roleName = pRoleName;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoleUIPrivileges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoleUIPrivileges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoleUIPrivileges`(
in pRoleName varchar(100)
)
BEGIN
select * from 
role_ui_privileges
where
roleName = pRoleName and
statusFlag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoom`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomAmenity` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomAmenity` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomAmenity`(in pRoomID int(11))
BEGIN
Select AmenityId from RoomAmenities where RoomId =pRoomID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomAndTypeOccupied` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomAndTypeOccupied` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomAndTypeOccupied`(in pFrom date,
in pTo date,
in pHOtelID int(5)
)
BEGIN
select distinct roomevents.roomid,rooms.roomtypecode from 
roomevents,rooms
where roomevents.roomid=rooms.roomid and 
(date(roomevents.eventdate) > pFrom and date(roomevents.eventdate) 
<pTo) and !(roomevents.eventtype = 'CLOSED' or roomevents.eventtype = 'NO SHOW'
or roomevents.eventtype ='CANCELLED') and rooms.roomtypecode!='FUNCTION' 
union
select folioschedules.roomid, folioschedules.roomtype as roomtypecode from folioschedules, folio where ((date(folioschedules.fromdate)=pFrom and date(folioschedules.todate)=pTo) or pFrom between date(folioschedules.fromdate) and date(folioschedules.todate)) and folioschedules.folioid=folio.folioid and !(folio.status='CLOSED' or folio.status='NO SHOW' or folio.status='CANCELLED' or folio.status='REMOVED' or folio.status='DELETED') and folioschedules.roomtype!='FUNCTION' and (date(folioschedules.fromDate)<pTo and date(folioschedules.toDate)>pFrom) and folioschedules.roomid!=''
union
select engineeringjobs.roomid, rooms.roomtypecode from engineeringjobs, rooms where engineeringjobs.roomid=rooms.roomid and ((date(engineeringjobs.startdate)=pFrom and date(engineeringjobs.enddate)=pTo) or (pFrom > date(engineeringjobs.startdate) and pFrom < date(engineeringjobs.enddate)))
order by roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomAndTypeOccupiedOrig` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomAndTypeOccupiedOrig` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomAndTypeOccupiedOrig`(in pFrom date,
in pTo date,
in pHOtelID int(5)
)
BEGIN
select distinct roomevents.roomid,rooms.roomtypecode from 
roomevents,rooms
where roomevents.roomid=rooms.roomid and 
(date(roomevents.eventdate) >=pFrom and date(roomevents.eventdate) 
<pTo) and !(roomevents.eventtype = 'CLOSED' or roomevents.eventtype = 'NO SHOW'
or roomevents.eventtype ='CANCELLED');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomBlockInfoById` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomBlockInfoById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomBlockInfoById`(
in pBlockId int(11)
)
BEGIN
select blockingdetails.blockid, blockingdetails.roomid, blockingdetails.blockfrom, blockingdetails.blockto, roomblock.reason, roomblock.folioID
from blockingdetails
left join roomblock on roomblock.blockid = blockingdetails.blockid
where
blockingdetails.blockid = pBlockId union
select blockingdetails.blockid, blockingdetails.roomid, blockingdetails.blockfrom, blockingdetails.blockto, roomblock.reason, roomblock.folioid
from blockingdetails left join roomblock on roomblock.blockid = blockingdetails.blockid where roomblock.folioid=(select folioid from roomblock where blockid=pBlockID and folioid!='') union
select pBlockId as blockid, folioschedules.roomid, date(folioschedules.fromDate) as blockfrom, date(folioschedules.toDate) as blockto, (select reason from roomblock where blockid=pBlockId) as reason, folio.masterfolio from folioschedules, folio where folio.folioid=folioschedules.folioid and folio.masterfolio=(select folioid from roomblock where blockid=pBlockID and folioid!='') and folio.status!='CANCELLED' and folio.status!='DELETED' and folio.STATUS!='NO SHOW' and folio.status!='REMOVED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomBlocksConflict` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomBlocksConflict` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomBlocksConflict`(
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
<=pTo) and 
!(roomevents.eventtype='CLOSED' or roomevents.eventtype='NO SHOW' or roomevents.eventtype='CANCELLED')and roomevents.roomid in (pRoom)
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomCharges`(
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
end */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomChargeTranCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomChargeTranCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomChargeTranCode`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomCleaningStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomCleaningStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomCleaningStatus`(
in pHotelId int(4),
in pRoomId varchar(50)
)
BEGIN
select cleaningstatus from rooms
where roomid = pRoomId and hotelid = pHotelId and
roomtypecode != 'FUNCTION';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomEvent`(
in pEventNo int(5),
in pHotelid int(5)
)
BEGIN
select * from roomevents
where
eventno = pEventNo and
hotelid = pHotelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomEventByRoomForAvailability` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomEventByRoomForAvailability` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomEventByRoomForAvailability`(
in pDate date,
in pHotelId int(4),
in pRoomId varchar(20)
)
BEGIN
select rooms.roomid,
if(roomevents.eventtype is null,"",roomevents.eventtype) as eventtype
from rooms force index(PRIMARY) left join roomevents on roomevents.roomid = rooms.roomid
and roomevents.eventdate = pDate
where rooms.hotelid = pHotelId
and rooms.roomid = pRoomId
order by rooms.roomtypecode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomEvents`(
in pEventID int(11)
)
BEGIN
Select * from roomevents where eventid=pEventID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomEventsFolioId` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomEventsFolioId` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomEventsFolioId`(
in pRoomNo varchar(20),
in pEventDate date,
in pEventType varchar(50),
in pHotelId int(4)
)
BEGIN
select eventid,
folio.fromdate,
folio.todate
from roomevents 
left join folio on folio.folioid = roomevents.eventid
where 
roomid = pRoomNo
and eventdate = pEventDate 
and eventtype = pEventType
and roomevents.hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomHistory` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomHistory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomHistory`()
BEGIN
select folio.folioid,
folio.status,
folioschedules.roomid,
folioschedules.fromdate,
folioschedules.todate,
folioschedules.roomtype,
folioschedules.ratetype,
folioschedules.rate,
folio.remarks,
if(foliotype='GROUP', if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)), fGetGuestName(folio.accountid)) as GuestsName
from
folio left join folioschedules on folioschedules.folioid = folio.folioid
where
folio.status = 'CLOSED' or folio.status = 'ONGOING'
or folio.status = 'CONFIRMED'
order by
folioschedules.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomIDs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomIDs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomIDs`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomingList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomingList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomingList`(pFolioid varchar(30))
BEGIN
select 
folio.folioid,
if(foliotype='GROUP', folio.folioid, masterfolio) as groupFolio,
foliotype,
groupname,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
fGetGuestName(folio.accountid) as accountName,
noOfAdults,
folioschedules.roomid,
folioschedules.roomtype,
date(folio.arrivaldate) as fromdate,
date(folio.departuredate) as todate,
'' as remarks
from folio left join folioschedules on folio.folioid=folioschedules.folioid where foliotype = 'DEPENDENT' and 
folio.status='ONGOING' and (folio.masterfolio=pFolioid or folio.folioid=pFolioid)
union  
select folio.folioid,
masterfolio as groupFolio,
foliotype,
groupname,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
fGetGuestName(folio.accountid) as accountName,
noOfAdults,
folioschedules.roomid,
folioschedules.roomtype,
date(folio.arrivaldate) as fromdate,
date(folio.departuredate) as todate,
folio.remarks
from folio left join folioschedules on (folio.masterfolio=folioschedules.folioid) where foliotype = 'JOINER' and (select foliotype from folio where folioid=folio.masterfolio)='DEPENDENT' and 
folio.status='ONGOING' and (select masterfolio from folio where folioid=folio.masterfolio)=pFolioid
order by roomid, folioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomOccupancyStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomOccupancyStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomOccupancyStatus`(
in pHotelId int(4),
in pRoomId varchar(50)
)
BEGIN
select stateflag from rooms
where roomid = pRoomId and hotelid = pHotelId and
roomtypecode != 'FUNCTION';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomPromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomPromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomPromo`(in pRoomID varchar(12))
BEGIN
Select promos.percentoff,roomTypes.roomtypeid from promos,roomtypes,rooms
where rooms.roomid = pRoomid and
roomtypes.roomtypeid = rooms.roomtypeid and
roomtypes.promocode= promos.promocode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomRate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomRate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomRate`(
in proomid varchar(10), in pHotelId int(4) )
BEGIN
select ratetypes.rateamount,roomtypes.roomtypecode from ratetypes,roomtypes,rooms
where (rooms.roomid = proomid and
roomtypes.roomtypecode = rooms.roomtypecode and
ratetypes.roomtypecode = roomtypes.roomtypecode and rooms.hotelid = pHotelId);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomRevenuePerDateRange` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomRevenuePerDateRange` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomRevenuePerDateRange`(
in pHotelId int(4),
in pStartDate date,
in pEndDate date
)
BEGIN
select 
eventdate,
roomid,
(select noOfAdults from folio where folio.folioid=eventid) as totalPax,
(select roomtypecode from rooms where rooms.roomid=roomevents.roomid) AS roomType,
sum(roomrate) as RoomRevenue from roomevents
where
eventdate between pStartDate and pEndDate and
HotelId = pHotelId and
eventtype != 'CANCELLED' and 
eventtype != 'NO SHOW' and
roomid != ''
group by eventdate, roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomRevenuePerDay` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomRevenuePerDay` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomRevenuePerDay`(
in pHotelId int(4),
in pDate date
)
BEGIN
select 
eventdate,
roomid,
(select noOfAdults from folio where folio.folioid=eventid) as totalPax,
(select roomtypecode from rooms where rooms.roomid=roomevents.roomid) AS roomType,
if((select sum(netAmount) from foliotransactions where roomevents.roomid = foliotransactions.roomID and foliotransactions.HotelID = pHotelId and date(roomevents.eventdate) = date(foliotransactions.transactionDate)  and foliotransactions.transactioncode = '1000') is null, 0, (select sum(netAmount) from foliotransactions where roomevents.roomid = foliotransactions.roomID and foliotransactions.HotelID = pHotelId and date(roomevents.eventdate) = date(foliotransactions.transactionDate)  and foliotransactions.transactioncode = '1000')) as RoomRevenue
from roomevents
where
eventDate = pDate and
HotelId = pHotelId and
eventtype != 'CANCELLED' and 
eventtype != 'NO SHOW' and 
roomid != ''
group by roomid,pDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomRevenuePerMonth` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomRevenuePerMonth` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomRevenuePerMonth`(
in pHotelId int(4),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select roomid,
eventdate,
(select noOfAdults from folio where folio.folioid=eventid) as totalPax,
(select roomtypecode from rooms where rooms.roomid=roomevents.roomid) AS roomType,
sum(roomrate) as RoomRevenue from roomevents
where
month(eventDate) = pMonth and
year(eventDate) = pYear and
HotelId = pHotelId and
eventtype != 'CANCELLED' and 
eventtype != 'NO SHOW' and
roomid != ''
group by roomid,pMonth,pYear;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomRevenuePerYear` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomRevenuePerYear` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomRevenuePerYear`(
in pHotelId int(4),
in pYear int(4)
)
BEGIN
select roomid,
eventdate,
(select noOfAdults from folio where folio.folioid=eventid) as totalPax,
(select roomtypecode from rooms where rooms.roomid=roomevents.roomid) AS roomType,
sum(roomrate) as RoomRevenue from roomevents
where
year(eventDate) = pYear and
HotelId = pHotelId and
eventtype != 'CANCELLED' and 
eventtype != 'NO SHOW' and
roomid != ''
group by roomid,pYear;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomsBlocked` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomsBlocked` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomsBlocked`(pEvent text)
BEGIN
select blockingdetails.roomid, blockfrom, blockto, blockingdetails.blockid from blockingdetails, roomblock, rooms where blockingdetails.blockid=roomblock.blockid and roomblock.folioid=pEvent and rooms.roomid=blockingdetails.roomid order by roomtypecode asc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomsBlockedByFolioID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomsBlockedByFolioID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomsBlockedByFolioID`(
pFolioID varchar(20))
BEGIN
select 
blockingdetails.roomid, 
blockfrom, 
blockto, 
blockingdetails.blockid,
folioid
from 
blockingdetails, 
roomblock, 
rooms 
where 
blockingdetails.blockid = roomblock.blockid 
and roomblock.folioId = pFolioID 
and rooms.roomid = blockingdetails.roomid 
order by roomtypecode asc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomsByMasterFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomsByMasterFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomsByMasterFolio`(pFolioID varchar(20))
BEGIN
select roomid from folioschedules, folio where folio.folioid=folioschedules.folioid and folio.masterfolio=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomScheculeByDateRange` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomScheculeByDateRange` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomScheculeByDateRange`(
pRoomId varchar(10),
pRoomType varchar(80),
pDate date,
pHotelID int(10)
)
BEGIN
set sql_big_selects = 1;
select 
folioschedules.roomid,
folio.folioid,
folioschedules.fromdate,
folioschedules.todate
from 
folio force index(primary),
folioschedules force index(primary)
where 
folio.folioid = folioschedules.folioid  and 
not ( folio.status = 'CLOSED' OR folio.status ='CANCELLED' OR folio.status ='NO SHOW') 
and folioschedules.roomid=pRoomId and
folioschedules.hotelid = folio.hotelid and
folioschedules.roomtype = pRoomType and (
date(pDate) >= date(folioschedules.fromdate) and date(pDate) <= date(folioschedules.todate)
)
and folio.hotelid = 1
and
not exists
(
select 
folioschedules.roomid,
folio.folioid,
folioschedules.fromdate,
folioschedules.todate
from 
folio force index(primary),
folioschedules force index(primary)
where 
folio.folioid = folioschedules.folioid  and 
not ( folio.status = 'CLOSED' OR folio.status ='CANCELLED' OR folio.status ='NO SHOW') 
and folioschedules.roomid=pRoomId and
folioschedules.hotelid = folio.hotelid and
folioschedules.roomtype = pRoomType and
(date(pDate) = date(folioschedules.fromdate) or date(pDate) = date(folioschedules.todate))
and folio.hotelid = 1
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomScheduleByDateRange` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomScheduleByDateRange` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomScheduleByDateRange`(
pRoomId varchar(10),
pRoomType varchar(80),
pDate date,
pHotelID int(10)
)
BEGIN
set sql_big_selects = 1;
select 
folioschedules.roomid,
folio.folioid,
folioschedules.fromdate,
folioschedules.todate
from 
folio force index(primary),
folioschedules force index(primary)
where 
folio.folioid = folioschedules.folioid  and 
not ( folio.status = 'CLOSED' OR folio.status ='CANCELLED' OR folio.status ='NO SHOW') 
and folioschedules.roomid=pRoomId and
folioschedules.hotelid = folio.hotelid and
folioschedules.roomtype = pRoomType and (
date(pDate) between date(folioschedules.fromdate) and date(folioschedules.todate)
)
and folio.hotelid = pHotelId
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomsDestinationForTransfer` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomsDestinationForTransfer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomsDestinationForTransfer`(
in pAuditDate date
)
BEGIN
select * from roomevents where eventdate = pAuditDate and
eventtype = 'IN HOUSE' and
transferflag = 0;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomStatusAndCleaningSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomStatusAndCleaningSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomStatusAndCleaningSummary`(
in pHotelId int(4)
)
BEGIN
select 
rooms.stateflag,
rooms.cleaningstatus,
count(*) as Total
from rooms
where
rooms.roomtypecode != 'FUNCTION' and
rooms.hotelId = pHotelId and rooms.stateflag != 'DELETED'
group by rooms.stateflag,rooms.cleaningstatus;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomsToCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomsToCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomsToCharge`(
in pDate date,
in pHotelId int(5)
)
BEGIN
select
eventid,
roomid,
max(roomrate) as roomrate
from 	
roomevents
where 	
eventDate = pDate and
eventType = 'IN HOUSE' and
transferflag = '0' and
hotelid = photelid and
(chargeflag='0' or eventid not in (select folioid from foliotransactions where transactioncode='1000' and date(transactiondate)=pDate and foliotransactions.status<>'VOID' and foliotransactions.acctside<>'CREDIT' and adjustmentFlag<>'1'))
group by eventid, roomid order by roomid;
end */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomsToTransfer` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomsToTransfer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetRoomsToTransfer`(
in pAuditDate date
)
BEGIN
select * from roomevents where
transferflag = 1 and
eventdate = pAuditDate and
eventtype = 'IN HOUSE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomSuperTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomSuperTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomSuperTypes`()
BEGIN
select * from roomsupertype where stateflag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomToCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomToCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomToCharge`(
in pDate date,
in pHotelId int(5),
in pFolioID varchar(20)
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
transferflag = '0' and
hotelid = photelid and
eventid=pFolioID;
end */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomType`(in pRoomID varchar(12))
BEGIN
Select roomTypes.roomtypecode from Rooms,RoomTypes where rooms.roomtypecode=roomtypes.roomtypecode and rooms.roomid=pRoomID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomTypeCalendarEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomTypeCalendarEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomTypeCalendarEvents`()
BEGIN
Select distinct roomtypecode from roomtypes where roomtypecode = 'MAIN COMPLEX' or roomtypecode = 'PICC FORUM';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomTypeDateOccupied` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomTypeDateOccupied` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomTypeDateOccupied`(in pFrom date,
in pTo date,
in pHOtelID int(5)
)
BEGIN
select distinct roomevents.roomid,rooms.roomtypecode,roomevents.eventdate from 
roomevents,rooms
where roomevents.roomid=rooms.roomid and 
(date(roomevents.eventdate) >=pFrom and date(roomevents.eventdate) 
<=pTo) and !(roomevents.eventtype = 'CLOSED' or roomevents.eventtype = 'NO SHOW'
or roomevents.eventtype ='CANCELLED');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoomTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoomTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoomTypes`()
BEGIN
Select distinct roomtypecode from roomtypes;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetRoutingDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetRoutingDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetRoutingDetails`(in pFolioID varchar(20),in pHOtelId int(5),in pTCode varchar(20))
BEGIN
select
TransactionCode, HotelID, FolioID, SubFOlio, Basis, PercentCharged, 
AmountCharged, CreateTime, CreatedBy, UpdateTime, UpdatedBy from FOlioRouting where folioid=pFolioID and hotelID=pHOtelID and transactioncode=pTCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetSalesForecast` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetSalesForecast` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetSalesForecast`(IN pFromDate VARCHAR(50), IN pToDate VARCHAR(50), IN pHotelId INTEGER(5))
BEGIN
select pFromDate,rooms.`roomtypecode` as RoomType,sum(roomevents.roomrate) as Amount,date(EventDate)  as EDate from rooms
left join roomevents on rooms.roomid=roomevents.roomid
where EventDate >= date(pFromDate) and EventDate <= date(pToDate)
and (roomevents.eventtype != 'NO SHOW' and roomevents.eventtype != 'CANCELLED')
group by rooms.`roomtypecode`,date(EventDate) ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetSchedule` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetSchedule` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetSchedule`(in pFolioID varchar(20), in pHotelID int(5))
BEGIN
Select 	
*
from 
folioschedules force index(hotelid,folioid)
where 
folioID=pFolioID  and 
hotelID=pHOtelID
and `status` = 'ACTIVE'
order by FromDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetSequenceID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetSequenceID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetSequenceID`()
BEGIN
update sequence set id = last_insert_id(id+1);
Select last_insert_id() as id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetServiceCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetServiceCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetServiceCharge`()
BEGIN
select * from TransactionCode where Memo = 'SERVICE CHARGE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetShareFolioIds` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetShareFolioIds` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetShareFolioIds`(
in pMasterFolioId varchar(20),
in pHotelId int(5)
)
BEGIN
select folioid from folio where masterfolio = pMasterFolioId and
hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetSpecificGroupBookingDropDown` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetSpecificGroupBookingDropDown` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetSpecificGroupBookingDropDown`(
pFieldName varchar(50)
)
BEGIN
select * from groupbookingdropdown where FieldName = pFieldName and StatusFlag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetStatementOfAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetStatementOfAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetStatementOfAccount`(pFolioID varchar(30))
BEGIN
SELECT FOLIO.FOLIOID, FOLIO.ACCOUNTID, FGETGUESTNAME(FOLIO.ACCOUNTID) AS GUESTNAME, FOLIO.COMPANYID, if(substring(cityledger.acctid,1,1)='G',fGetCompanyName(cityledger.acctid), fGetGuestName(cityledger.acctid)) AS BILLEDTO, if(substring(cityledger.acctid,1,1)='G',fGetCompanyADDRESS(cityledger.acctid), FGETGUESTADDRESS(cityledger.acctid)) AS ADDRESS, FOLIO.ARRIVALDATE, FOLIO.DEPARTUREDATE, foliotransactions.transactiondate, foliotransactions.memo, foliotransactions.referenceno, if(foliotransactions.acctside='DEBIT', foliotransactions.netbaseamount, 0.00) as Debit, if(foliotransactions.acctside='CREDIT', foliotransactions.netbaseamount, 0.00) as Credit
FROM FOLIO left join FOLIOTRANSACTIONS on folio.folioid=foliotransactions.folioid and foliotransactions.transactioncode!='4200', cityledger where folio.folioid=pFolioID and folio.folioid=cityledger.reffolio;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetSubAccountForPackageDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetSubAccountForPackageDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetSubAccountForPackageDetail`(pDescription text, pPackageID varchar(5))
BEGIN
select subaccount from event_package_detail where description=pDescription and packageID=pPackageID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetSummaryOfCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetSummaryOfCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetSummaryOfCharges`(
pFolioID varchar(20),
pHotelID varchar(20),
pContingencyCode varchar(20)
)
BEGIN
select contractAmount
, if(Amount is null,0,Amount) as amount
, if((select sum(baseAmount*tax/100*qtyHrs) from foliorecurringcharge where folioID = pFolioID and hotelID = pHotelID group by folioID) is null,0,(select sum(baseAmount*tax/100*qtyHrs) from foliorecurringcharge where folioID = pFolioID and hotelID = pHotelID group by folioID)) as vat
, if((select sum(baseAmount * qtyHrs * (100 - discount)/ 100) from foliorecurringcharge where transactioncode = '1000' and folioID = pFolioID and hotelID = pHotelID group by folioID) is null,0,(select sum(baseAmount * qtyHrs * (100 - discount)/ 100) from foliorecurringcharge where transactioncode = '1000' and folioID = pFolioID and hotelID = pHotelID group by folioID)) as roomAmount
, IF((SELECT SUM(baseAmount) FROM foliorecurringcharge WHERE folioID = pFolioID AND TransactionCode = '3300' AND hotelID = pHotelID GROUP BY folioID) IS NULL,0,(SELECT SUM(baseAmount) FROM foliorecurringcharge WHERE folioID = pFolioID AND TransactionCode = '3300' AND hotelID = pHotelID GROUP BY folioID)) AS refund
from event_endorsement
left join (select Amount, folioID, hotelID from foliorecurringcharge where FolioID = pFolioID and TransactionCode = pContingencyCode and HotelID = pHotelID) as recurring on event_endorsement.folioID = recurring.folioID and event_endorsement.hotelID = recurring.hotelID where event_endorsement.folioID = pFolioID and event_endorsement.hotelID = pHotelID LIMIT 1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetSystemPrivileges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetSystemPrivileges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetSystemPrivileges`()
BEGIN
select * from `system_privileges`;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTotalBlockFunctionCount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTotalBlockFunctionCount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetTotalBlockFunctionCount`(
in pAuditDate date
)
BEGIN
select 
count(*) as TotalBlock 
from 
blockingdetails left join
rooms on rooms.roomid = blockingdetails.roomid 
where
rooms.roomtypecode = 'FUNCTION' and
date(blockfrom) <= pAuditDate and date(blockto) > pAuditDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTotalBlockRoomsCount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTotalBlockRoomsCount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetTotalBlockRoomsCount`(
in pAuditDate date
)
BEGIN
select 
count(*) as TotalBlock 
from 
blockingdetails left join
rooms on rooms.roomid = blockingdetails.roomid 
where
rooms.roomtypecode != 'FUNCTION' and
date(blockfrom) <= pAuditDate and date(blockto) > pAuditDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTotalOutOfOrderFunctionCount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTotalOutOfOrderFunctionCount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetTotalOutOfOrderFunctionCount`(
in pAuditDate date
)
BEGIN
select 
count(*) as Total
from 
engineeringjobs left join
rooms on rooms.roomid = engineeringjobs.roomid left join roomtypes on rooms.roomtypecode=roomtypes.roomtypecode
where
roomtypes.roomsupertype = 'FUNCTION' and
date(startdate) <= pAuditDate and date(enddate) >= pAuditDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTotalOutOfOrderRoomsCount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTotalOutOfOrderRoomsCount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetTotalOutOfOrderRoomsCount`(
in pAuditDate date
)
BEGIN
select 
count(*) as Total
from 
engineeringjobs left join
rooms on rooms.roomid = engineeringjobs.roomid 
where
rooms.roomtypecode != 'FUNCTION' and
date(startdate) <= pAuditDate and date(enddate) >= pAuditDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranCodeGovtTax` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranCodeGovtTax` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTranCodeGovtTax`()
BEGIN
select trancode from transactioncode where
memo = 'GOVERNMENT TAX' or memo = 'VAT TAX';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranCodeLocalCall` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranCodeLocalCall` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTranCodeLocalCall`(
in photelid int(5)
)
BEGIN
select * from transactioncode where
(memo = 'TELEPHONE CHARGES' or memo = 'TELEPHONE CHARGES') and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranCodeLocalTax` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranCodeLocalTax` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTranCodeLocalTax`()
BEGIN
select trancode from transactioncode where
memo = 'LOCAL TAX';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranCodeLongDistanceCall` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranCodeLongDistanceCall` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTranCodeLongDistanceCall`(
in photelid int(5)
)
BEGIN
select * from transactioncode where
(memo = 'IDD CALL' or memo = 'TELEPHONE CHARGES') and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranCodeMemo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranCodeMemo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTranCodeMemo`()
BEGIN
select Trancode,Memo,AcctSide,ServiceCharge,GovtTax,LocalTax from transactioncode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranCodeNDDCall` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranCodeNDDCall` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTranCodeNDDCall`(
in photelid int(5)
)
BEGIN
select * from transactioncode where
(memo = 'NDD CALL' or memo='TELEPHONE CHARGES') and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranCodeRoomCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranCodeRoomCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTranCodeRoomCharge`()
BEGIN
select trancode from transactioncode where
memo = 'ROOM CHARGE' or memo = 'ROOM CHARGES';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranCodeServiceCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranCodeServiceCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTranCodeServiceCharge`()
BEGIN
select trancode from transactioncode where
memo = 'SERVICE CHARGE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTransactionCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTransactionCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTransactionCode`(
in pTranCode varchar(20),
in pHotelId int(5)
)
BEGIN
select * 
from transactionCode 
where 
tranCode=pTranCode and 
hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTransactionCodes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTransactionCodes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTransactionCodes`(in pHotelID int(5))
BEGIN
select * from TransactionCode
where HotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTransactionCodesGLAccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTransactionCodesGLAccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTransactionCodesGLAccounts`(in pHotelID int(5))
BEGIN
select 
transactioncode_glaccounts.TransactionCode,
transactioncode_glaccounts.subAccount,
TransactionCode.memo,
GLAccountCode,
GLCostCenterAccount,
FolioTransactionFieldName
from
transactioncode_glaccounts
left join TransactionCode on
transactioncode_glaccounts.transactioncode = TransactionCode.trancode
where TransactionCode.HotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTransactionCodesWithSubAccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTransactionCodesWithSubAccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTransactionCodesWithSubAccounts`(pHotelID int(5))
BEGIN
select trancode, memo, memo as subAccount, acctside from transactioncode where trancode not in (select distinct transactioncode from transctioncode_subaccount) and stateflag!='DELETED' and hotelid=pHotelID union all
select transactioncode as trancode, concat((select memo from transactioncode where trancode=transactioncode),' - ',subaccountcode) as memo, subAccountcode as subaccount, (select acctside from transactioncode where trancode=transactioncode) as acctside from transctioncode_subaccount where hotelid=pHotelid order by trancode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTransactionTerminalId` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTransactionTerminalId` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTransactionTerminalId`(
in pHotelId int(5),
in pFolioId varchar(20),
in pSubFolio varchar(5),
in pPostingDate varchar(20),
in pTransactionCode varchar(10)
)
BEGIN
select terminalid from foliotransactions 
where
hotelid = pHotelId and
folioid = pFolioId and
subfolio = pSubFolio and
postingdate = pPostingDate and
transactioncode = pTransactionCode  ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranslation` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranslation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetTranslation`(pValue varchar(20))
BEGIN
select english from translations where defaultValue = pValue;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranslations` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranslations` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetTranslations`()
BEGIN
select defaultValue, english from translations;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetTranTypeId` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetTranTypeId` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetTranTypeId`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetUnPostedFolioTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetUnPostedFolioTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetUnPostedFolioTransactions`(
in pAuditDate date
)
BEGIN
select * from foliotransactions where auditflag = 0 and date(transactiondate) < pAuditDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetUser` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetUser` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spGetUser`(
pUserId varchar(30)
)
BEGIN
select LastName, FirstName from users where UserId = pUserId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetUserOldPass` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetUserOldPass` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetUserOldPass`(
in pUserId varchar(20),
in pHotelID int(5)
)
BEGIN
Select aes_decrypt(`password`,'password')
from 
users
where
userid = puserId and hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetUserRoles` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetUserRoles` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetUserRoles`(
in pUserId varchar(20),
in pHotelId int(5)
)
BEGIN
select userroles.rolename,
roles.description
from userRoles,roles
where
userroles.rolename = roles.rolename and
userroles.hotelid = roles.hotelid and
userid = pUserId and
userroles.hotelid = photelid and
userroles.stateflag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetUserRolesAll` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetUserRolesAll` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetUserRolesAll`(
in pHotelId int(5)
)
BEGIN
select userroles.UserId, users.EmployeeIdNo, users.LastName, users.FirstName, users.Department, users.Designation, 
users.Stateflag, users.HotelId, userroles.rolename, concat(users.firstName, ' ' ,users.lastName) as FullName, 
users.UserId as sales_Executive from users left join userroles on users.UserId=userroles.UserId right join 
roles on userroles.rolename = roles.rolename where users.stateflag <> 'DELETED' and userroles.StateFlag <> 'DELETED' 
and EXISTS (select roles.RoleName from roles where roles.RoleName = userroles.RoleName) and userroles.HotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGetVoidedFolioTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGetVoidedFolioTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetVoidedFolioTransactions`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spGroupFolioTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spGroupFolioTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spGroupFolioTransactions`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_CheckHousekeeperPinCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_CheckHousekeeperPinCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_CheckHousekeeperPinCode`(
pPinCode varchar(15)
)
BEGIN
select housekeeperid 
from hk_housekeepers 
where md5(pPinCode) = pincode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_CheckIfRoomIsOccupied` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_CheckIfRoomIsOccupied` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_CheckIfRoomIsOccupied`(
in pRoomID varchar(20)
)
BEGIN
select eventNo from
roomevents
where eventtype = 'IN HOUSE'
and roomid= pRoomID
order by eventNo
limit 0,1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_CheckRoomIfHKJobStarted` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_CheckRoomIfHKJobStarted` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_CheckRoomIfHKJobStarted`(
pRoomid varchar(10),
pHKType int(10)
)
BEGIN
Select 
roomId 
from 
hk_housekeepingjobs 
where 
roomid = pRoomId and
housekeepingType = if(pHKType=1,'CLEANING','MAKE-UP') and 
housekeepingdate = curdate() and
isFinished = 0;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_DeleteHousekeepingType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_DeleteHousekeepingType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_DeleteHousekeepingType`(
pId int(5)
)
BEGIN
delete from hk_housekeepingtypes
where Id=pId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_DeleteMinibarItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_DeleteMinibarItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_DeleteMinibarItem`(
pItem_code int(11),
pUsername varchar(30)
)
BEGIN
update hk_minibaritems set statusFlag = 'DELETED', 
updatedBy = pUsername ,
updatedDate = now() where itemCode = pItem_code;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_DeleteMinibarItemCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_DeleteMinibarItemCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_DeleteMinibarItemCategory`(
pCategoryID int(11),
pUsername varchar(30)
)
BEGIN
update hk_minibarItemCategory 
set `statusFlag` = 'DELETED',
updateTime = now(),
updateBy= pUsername
where categoryID = pCategoryID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_DeleteStepProcedure` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_DeleteStepProcedure` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_DeleteStepProcedure`(
pId              int(10)   
)
BEGIN
update hk_stepprocedures
set `STATUS`='DELETED',
LastChanged=now()
where 
Id=pId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_GetActiveHousekeepingJobPerRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_GetActiveHousekeepingJobPerRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_GetActiveHousekeepingJobPerRoom`(
in pHotelId int(4),
in pRoomId varchar(15),
in pHousekeeperId varchar(20)
)
BEGIN
Select 
housekeepingJobNo 
from 
hk_housekeepingjobs 
where 
isFinished = 0 and 
hotelId = pHotelId and
roomId = pRoomId and
housekeeperId = pHousekeeperId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_GetActiveHousekeepingJobs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_GetActiveHousekeepingJobs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_GetActiveHousekeepingJobs`()
BEGIN
Select * 
from 
hk_housekeepingjobs 
where isFinished = 0;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_GetHouseKeepersWithSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_GetHouseKeepersWithSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_GetHouseKeepersWithSales`(
pFrom date,
pTo date
)
BEGIN
select distinct 
housekeeperid,
concat(lastname,', ' ,firstname) as name 
from hk_housekeepers,
hk_minibarSales
where hk_minibarSales.housekeeper_id =  housekeeperid  and 
voided = 0 and 
hk_minibarSales.salesdate between pFrom and pTo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_GetHouseKeepingLogs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_GetHouseKeepingLogs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_GetHouseKeepingLogs`(
pDate DATE
)
BEGIN
(
Select 
rooms.`roomid` as RoomId,
rooms.roomtypecode as RoomType,
time(starttime) as StartTime,
time(endtime) as EndTime,
elapsedtime as Duration,
concat(hk_housekeepers.housekeeperid,'-',
hk_housekeepers.lastname,', ',
hk_housekeepers.firstname) as Housekeeper,
hk_housekeepingjobs.housekeepingtype as Remarks,
hk_housekeepingjobs.verifiedby,
time(hk_housekeepingjobs.timeverified) as timeverified,
hk_housekeepingjobs.housekeepingjobno
from
rooms left join hk_housekeepingjobs on  hk_housekeepingjobs.roomid = rooms.roomid
left join 
hk_housekeepers on hk_housekeepers.housekeeperid = hk_housekeepingjobs.housekeeperid
WHERE (hk_housekeepingjobs.housekeepingdate = pDate and isFinished = 0)
)
Union
(
Select 
rooms.`roomid` as RoomId,
rooms.roomtypecode as RoomType,
'' as StartTime,
'' as EndTime,
'' as Duration,
'' as Housekeeper,
'' as remarks,
'' as verifiedby,
'' as timeverified,
'' as housekeepingjobno
from rooms
WHERE  rooms.`roomid` not in(Select roomid from `hk_housekeepingjobs` WHERE housekeepingdate=pDate)
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_GetMinibarSalesDetailsInRange` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_GetMinibarSalesDetailsInRange` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_GetMinibarSalesDetailsInRange`( 
pFrom Date,
pTo Date
)
BEGIN
select 
hk_minibarsalesdetails.id as 'Transaction No.',
sales_id as 'Sales No.',
item_code as 'Item Code',
hk_minibaritems.description as Description,
hk_minibaritemcategory.categoryName as Category,
qty as Quantity,unit_price as 'Unit Price' 
from 
hk_minibarsales, hk_minibarsalesdetails
left join hk_minibaritems on 
hk_minibaritems.itemCode = hk_minibarsalesdetails.item_code
left join hk_minibaritemcategory on 	
hk_minibaritemcategory.categoryId = hk_minibaritems.categoryId
where 
hk_minibarsales.id = hk_minibarsalesdetails.sales_id and 
hk_minibarsalesdetails.voided=0 and
hk_minibarsales.salesdate between pFrom and pTo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_GetMinibarSalesInRange` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_GetMinibarSalesInRange` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_GetMinibarSalesInRange`( 
pFrom date,
pTo date
)
BEGIN
Select 
id as 'Sales No.',
salesdate as 'Sales Date',
housekeeper_id as 'Housekeeper',
room_id as 'Room No.',
amount as Amount, 
total_qty as Quantity 
from 
hk_minibarsales 
where voided = 0 and  
salesdate between pFrom and pTo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_GetSupervisorFullName` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_GetSupervisorFullName` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_GetSupervisorFullName`(
pHkID varchar(30),
pPin varchar(30)
)
BEGIN
Select concat(lastname,",",firstname) as Name 
from hk_housekeepers where 
housekeeperId = pHkID and 
pincode = md5(pPin);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_GetUnfinishedTasks` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_GetUnfinishedTasks` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_GetUnfinishedTasks`(
in pRoomNo varchar(20),
in pHousekeeperId varchar(20)
)
BEGIN
Select * 
from 
hk_housekeepingjobs 
where 
isFinished = 0 and 
roomid != pRoomNo and 
housekeeperId = pHousekeeperId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_HousekeepingReport` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_HousekeepingReport` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_HousekeepingReport`(
pFromDate date,
pToDate date
)
BEGIN
SELECT 
hk_housekeepingjobs.roomid,
concat('ROOM',rooms.roomid) as name,
roomtypecode,
concat(hk_housekeepingjobs.housekeeperid,'-',
hk_housekeepers.lastname,', ',
hk_housekeepers.firstname) as Housekeeper,
housekeepingdate,
starttime,
endtime,
elapsedtime,
concat(hk_housekeepingjobs.housekeepingtype,'-',remarks)  as remarks,
verifiedby,
timeverified
from 
hk_housekeepers,
hk_housekeepingjobs,
rooms
where 
hk_housekeepers.housekeeperid=hk_housekeepingjobs.housekeeperid
and housekeepingdate BETWEEN pFromDate and pToDate
and rooms.roomid=hk_housekeepingjobs.roomid ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_HousekeepingReportByHousekeepers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_HousekeepingReportByHousekeepers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_HousekeepingReportByHousekeepers`(
pFromDate date,
pToDate date
)
BEGIN
SELECT 
hk_housekeepingjobs.roomid,
concat("ROOM",rooms.roomid) as RoomName,
roomtypecode,
concat(hk_housekeepingjobs.housekeeperid,'-',
hk_housekeepers.lastname,', ',
hk_housekeepers.firstname) as Housekeeper,
housekeepingdate,
time(starttime) as starttime,
time(endtime) as endtime,
time(elapsedtime) as elapsedtime,
concat(hk_housekeepingjobs.housekeepingtype,'-',remarks) as remarks,
verifiedby,
timeverified
from 
hk_housekeepers,
hk_housekeepingjobs,
rooms
where 
hk_housekeepers.housekeeperid = hk_housekeepingjobs.housekeeperid
and housekeepingdate BETWEEN pFromDate and pToDate
and rooms.roomid = hk_housekeepingjobs.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_InsertHousekeepingJob` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_InsertHousekeepingJob` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_InsertHousekeepingJob`(
pHousekeepingDate   date,
pHousekeeperId      varchar(20),
pHousekeepingType   varchar(20),
pRoomId             varchar(20),
pStartTime          datetime,
pEndTime            varchar(20),
pRemarks            varchar(100),
pVerifiedBy         varchar(50),
pTimeVerified       varchar(20),
pHotelId            int(4),
pCreatedBy          varchar(50)
)
BEGIN
insert into `hk_housekeepingjobs` 
(
housekeepingDate, 
housekeeperId, 
housekeepingType, 
roomId, 
startTime, 
endTime, 
elapsedTime, 
remarks, 
isFinished, 
verifiedBy, 
timeVerified, 
hotelId, 
createTime, 
createdBy, 
updateTime, 
updatedBy, 
stateFlag)
values
(
pHousekeepingDate, 
pHousekeeperId, 
pHousekeepingType, 
pRoomId, 
pStartTime, 
pEndTime, 
timediff(pEndTime,pStartTime), 
pRemarks, 
0, 
pVerifiedBy, 
pTimeVerified, 
pHotelId, 
now(), 
pCreatedBy, 
now(), 
pCreatedBy, 
"ACTIVE"
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_InsertHousekeepingType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_InsertHousekeepingType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_InsertHousekeepingType`(
pId              int(10)   ,      
pName            varchar(30),
pCode            varchar(10)  
)
BEGIN
insert into hk_housekeepingtypes 
(Id, Name, Code, `Status`, CreatedDate, 
LastUpdateDate, Lastchanged)
values
(pId, pName, pCode,'ACTIVE', now(), 
now(), now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_InsertMinibarCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_InsertMinibarCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_InsertMinibarCategory`(
pCategoryName varchar(200),
pUsername varchar(30)
)
BEGIN
Insert into hk_minibarItemCategory
(categoryName,createTime,createdBy,updateTime,updateBy)
values(pCategoryName,now(),pUsername,now(),pUsername);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_InsertMinibarItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_InsertMinibarItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_InsertMinibarItem`(
pItemCode int(11),
pDescription text,
pUnitPrice double(12,2),
pCategory int(11),
pUsername varchar(30)
)
BEGIN
insert into hk_minibaritems
(itemCode,categoryId,
description,unitPrice,
createdDate,createdBy,updatedDate,updatedBy)
values(pItemCode,pCategory,
pDescription,
pUnitPrice,now(),
pUsername,now(),pUsername);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_InsertMiniBarSale` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_InsertMiniBarSale` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_InsertMiniBarSale`(
pHouseKeeper_id varchar(11),
pRoom_id varchar(15),
pAmount double(12,2),
pTotal_qty int(3)
)
BEGIN
Insert into 
hk_minibarsales
(salesdate,
housekeeper_id,
room_id,
amount,
total_qty,
date_created,
created_by,
updated_by,
update_time)
values(
now(),
pHouseKeeper_id,
pRoom_id,
pAmount,
pTotal_qty,
now(),'admin','admin',now());
Select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_InsertMinibarSales_Detail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_InsertMinibarSales_Detail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_InsertMinibarSales_Detail`(
pSales_Id int(11),
pItem_code int(11),
pQty int(11)
)
BEGIN
Insert into 
hk_minibarsalesdetails
(sales_id,item_code,qty,unit_price)
values(pSales_Id,pItem_code,pQty,fHK_GetUnitPrice(pItem_code));
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_InsertStepProcedure` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_InsertStepProcedure` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_InsertStepProcedure`(
pId              int(10)   ,
pName            varchar(30),
pUseSoundFile    tinyint(4)  ,
pSoundFile       varchar(255) ,
pTextToSpeak     text ,  
pRank            int(10), 
pisBefore        tinyint(4),
pmaxDigit        int(10),
pExpectedDigit   int(3)    
)
BEGIN
insert into `hk_stepprocedures` 
(Id, Name, UseSoundFile, SoundFile, 
TextToSpeak, Rank, isBefore, maxDigit, 
ExpectedDigit, CreatedDate, LastUpdateDate, 
LastChanged)
values
(pId, pName, pUseSoundFile, pSoundFile, 
pTextToSpeak, pRank, pisBefore, pmaxDigit, 
pExpectedDigit, now(), now(), 
now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_ReportDateRangeMinibarSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_ReportDateRangeMinibarSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_ReportDateRangeMinibarSales`(
pStartDate date,
pEndDate date
)
BEGIN
Select 
hk_minibarSales.id,
hk_minibarSales.salesdate,
concat(hk_housekeepers.lastname,",",
hk_housekeepers.firstname) as name,
hk_minibarSales.room_id,
hk_minibarSales.total_qty,
hk_minibarSales.amount as TotalAmount,
hk_minibaritems.description,
hk_minibaritemcategory.categoryName as Category,
hk_minibarSalesDetails.qty,
hk_minibarSalesDetails.unit_price,
(hk_minibarSalesDetails.qty * hk_minibarSalesDetails.unit_price) as amount
from 
hk_minibarSales,
hk_minibarItems
left join hk_minibaritemcategory on hk_minibaritemcategory.categoryId = 
hk_minibarItems.categoryId,
hk_minibarSalesDetails,
hk_housekeepers
where 
hk_minibarSales.id = hk_minibarSalesDetails.sales_id and 
hk_minibarSalesDetails.item_Code = hk_minibarItems.itemCode and 
hk_minibarSales.housekeeper_id = hk_housekeepers.housekeeperid and 
hk_minibarSales.voided = 0 and 
hk_minibarSalesDetails.voided = 0 and 
(salesdate between pStartDate and pEndDate) 
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_ReportHousekeepingSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_ReportHousekeepingSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_ReportHousekeepingSummary`(
pFromDate date,
pToDate date
)
BEGIN
SELECT 
count(roomid) as totalRoomId,
concat(hk_housekeepingjobs.housekeeperid,'-',
hk_housekeepers.lastname,', ',hk_housekeepers.firstname) as Housekeeper,
sum(time_to_sec(time(starttime))) as starttime,
sum(time_to_sec(time(endtime))) as endtime,
sum(time_to_sec(time(elapsedtime))) as elapsedtime
from 
hk_housekeepers,
hk_housekeepingjobs
where 
hk_housekeepers.housekeeperid=hk_housekeepingjobs.housekeeperid
and housekeepingdate BETWEEN pFromDate and pToDate
group by hk_housekeepers.housekeeperid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_SelectAfterStepProcedures` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_SelectAfterStepProcedures` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_SelectAfterStepProcedures`()
BEGIN
select 	
id,
isBefore as IsBefore,
maxDigit as MaxDigit,
Name,
Rank,
SoundFile,
TextToSpeak,
UseSoundFile,
ExpectedDigit  
from 
hk_stepprocedures 
where (isBefore=0 and `Status`='ACTIVE') order by Rank;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_SelectBeforeStepProcedures` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_SelectBeforeStepProcedures` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_SelectBeforeStepProcedures`()
BEGIN
select 
id,
isBefore as IsBefore,
maxDigit as MaxDigit,
Name,
Rank,
SoundFile,
TextToSpeak,
UseSoundFile,
ExpectedDigit  
from 
hk_stepprocedures 
where (isBefore=1 and `Status`='ACTIVE') order by Rank;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_SelectHousekeepingTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_SelectHousekeepingTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_SelectHousekeepingTypes`()
BEGIN
select * from hk_housekeepingtypes where `status`='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_SelectMinbarItemsList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_SelectMinbarItemsList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_SelectMinbarItemsList`(
pCategory int(11) 
)
BEGIN
Select 
CategoryName,
itemCode,
description,
unitPrice 
from 
hk_minibaritemcategory,
hk_minibaritems 
where hk_minibaritemcategory.categoryID = hk_minibaritems.categoryId and  
hk_minibaritems.statusFlag = 'ACTIVE' and 
hk_minibaritemcategory.categoryId = pCategory;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_SelectMinibarCategories` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_SelectMinibarCategories` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_SelectMinibarCategories`()
BEGIN
Select * 
from 
hk_minibarItemCategory 
where statusFlag != 'DELETED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_SelectMinibarItemPerCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_SelectMinibarItemPerCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_SelectMinibarItemPerCode`(
in pItemCode varchar(20)
)
BEGIN
Select * 
from hk_minibarItems 
where statusFlag = 'ACTIVE'
and itemCode = pItemCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_SelectMinibarItems` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_SelectMinibarItems` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_SelectMinibarItems`()
BEGIN
Select * 
from hk_minibarItems 
where statusFlag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_SelectMiniBarSalesStepProcedures` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_SelectMiniBarSalesStepProcedures` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_SelectMiniBarSalesStepProcedures`()
BEGIN
select 	
id,
isBefore as IsBefore,
maxDigit as MaxDigit,
Name,
Rank,
SoundFile,
TextToSpeak,
UseSoundFile,
ExpectedDigit  
from 
hk_stepprocedures 
where 
(isBefore=3 and `Status`='ACTIVE') order by Rank;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_SelectStepProcedures` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_SelectStepProcedures` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_SelectStepProcedures`()
BEGIN
select * from hk_stepprocedures where `Status`='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_SelectVerifyStepProcedures` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_SelectVerifyStepProcedures` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_SelectVerifyStepProcedures`()
BEGIN
select 
id,
isBefore as IsBefore,
maxDigit as MaxDigit,
Name,
Rank,
SoundFile,
TextToSpeak,
UseSoundFile,
ExpectedDigit  
from 
hk_stepprocedures 
where 
(isBefore=2 and `Status`='ACTIVE') order by Rank;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_UpdateHousekeepingJobEndTime` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_UpdateHousekeepingJobEndTime` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_UpdateHousekeepingJobEndTime`(
pHKJobNo int(20)
)
BEGIN
update hk_housekeepingJobs
set 
endTime = now(),
elapsedTime = timediff(now(),startTime),
isFinished = 1
where
housekeepingJobNo = pHKJobNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_UpdateHousekeepingType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_UpdateHousekeepingType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_UpdateHousekeepingType`(
pId              int(10)   ,      
pName            varchar(30),
pCode            varchar(10) 
)
BEGIN
update hk_housekeepingtypes
set
Name     =   pName     ,
Code     = pCode , 
Lastchanged=now()	
where
Id      =    pId ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_UpdateMinibarItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_UpdateMinibarItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_UpdateMinibarItem`(
pItem_Code int(11),
pDescription text,
pUnit_Price double(12,2),
pCategory int(11),
pUsername varchar(30)
)
BEGIN
update hk_minibaritems 
set 
description = pDescription,
categoryId = pCategory,
unitPrice = pUnit_Price,
updatedBy = pUsername,
updatedDate = now()
where itemCode = pItem_Code and statusFlag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_UpdateMinibarItemCategory` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_UpdateMinibarItemCategory` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_UpdateMinibarItemCategory`(
pCategoryID int(11),
pCategoryName varchar(200),
pUsername varchar(30)
)
BEGIN
update hk_minibarItemCategory 
set 
categoryName = pCategoryName,
updateTime = now(),
updateBy = pUsername
where categoryID = pCategoryID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_UpdateStepProcedure` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_UpdateStepProcedure` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_UpdateStepProcedure`(
pId              int(10)   ,
pName            varchar(30),
pUseSoundFile    tinyint(4)  ,
pSoundFile       varchar(255) ,
pTextToSpeak     text ,  
pRank            int(10), 
isBefore        tinyint(4),
pmaxDigit        int(10),
pExpectedDigit   int(3)  
)
BEGIN
update hk_stepprocedures
set
Name=pName,
UseSoundFile=pUseSoundFile ,
SoundFile=pSoundFile ,
TextToSpeak     =pTextToSpeak  ,  
Rank     =pRank, 
isBefore=isBefore,
maxDigit=pmaxDigit,
ExpectedDigit =pExpectedDigit ,
LastChanged=now()
where
Id =pId ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_VerifyHouseKeepingJob` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_VerifyHouseKeepingJob` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_VerifyHouseKeepingJob`(
pVisor varchar(50),
pJobno int(10),
pTimeVerified varchar(15)
)
BEGIN
update 
hk_housekeepingjobs 
set 
verifiedby = pVisor,
TimeVerified = now()
where housekeepingjobno = pJobno;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_VerifyHouseKeepingJobByRoomID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_VerifyHouseKeepingJobByRoomID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_VerifyHouseKeepingJobByRoomID`(
pVisor varchar(50),
pRoomID varchar(10)
)
BEGIN
update 
hk_housekeepingjobs 
set 
verifiedby = pVisor,TimeVerified = now()
where 
roomid = pRoomID and 
housekeepingdate = curdate() and 
isFinished=1 and 
(verifiedby is null or verifiedby='') ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_VoidMinibarSaleDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_VoidMinibarSaleDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_VoidMinibarSaleDetail`(
pTransID int(11),
pUsername varchar(30)
)
BEGIN
update 
hk_minibarsalesdetails 
set voided = 1,
update_time = now(),
updated_by = pUsername 
where id = pTransID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHK_VoidMinibarSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHK_VoidMinibarSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHK_VoidMinibarSales`(
pID int(11),
pUsername varchar(30)
)
BEGIN
update hk_minibarsales 
set voided = 1,
update_time = now(),
updated_by = pUsername 
where id = pID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spHousekeepingReportByHousekeepers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spHousekeepingReportByHousekeepers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spHousekeepingReportByHousekeepers`(
pFromDate date,
pToDate date
)
BEGIN
SELECT 
hk_housekeepingjobs.roomid,
concat("ROOM",rooms.roomid) as RoomName,
roomtypecode,
concat(hk_housekeepingjobs.housekeeperid,'-',
hk_housekeepers.lastname,', ',
hk_housekeepers.firstname) as Housekeeper,
housekeepingdate,
time(starttime) as starttime,
time(endtime) as endtime,
time(elapsedtime) as elapsedtime,
concat(hk_housekeepingtypes.Name,'-',memo) as remarks,
verifiedby,
timeverified
from 
hk_housekeepers,
hk_housekeepingjobs,
rooms,
hk_housekeepingtypes
where 
hk_housekeepers.housekeeperid = hk_housekeepingjobs.housekeeperid
and housekeepingdate BETWEEN pFromDate and pToDate
and rooms.roomid = hk_housekeepingjobs.roomid and
hk_housekeepingjobs.housekeepingtypecode = hk_housekeepingtypes.id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertAccountInformation` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertAccountInformation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertAccountInformation`(
pAccountID varchar(20),
pHotelID int,
pAffiliations text,
pOfficeOfficers text,
pNatureOfBusiness text,
pPillarsOfOrganization text,
pAnniversary datetime
)
BEGIN
insert into account_information set
accountID = pAccountID,
hotelID = pHotelID,
affiliations = pAffiliations,
officeOfficers = pOfficeOfficers,
natureOfBusiness = pNatureOfBusiness,
pillarsOfOrganization = pPillarsOfOrganization,
anniversary = pAnniversary;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertAccountingAdjustment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertAccountingAdjustment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertAccountingAdjustment`(
pHotelID             int(5),
pTransactionDate     date, 
pTransactionCode     varchar(20),
pSubAccount              varchar(100), 
pReferenceNo             varchar(20),
pTransactionSource       varchar(20), 
pMemo                    varchar(500), 
pAcctSide                varchar(10), 
pCurrencyCode            varchar(10), 
pConversionRate          decimal(12,5), 
pCurrencyAmount          decimal(12,5), 
pBaseAmount              decimal(12,5), 
pGrossAmount             decimal(12,5), 
pDiscount                decimal(12,5), 
pServiceCharge           decimal(12,5), 
pServiceChargeInclusive  tinyint(1), 
pGovernmentTax           decimal(12,5), 
pGovernmentTaxInclusive  tinyint(1), 
pLocalTax                decimal(12,5), 
pLocalTaxInclusive       tinyint(1), 
pNetBaseAmount           decimal(12,5), 
pNetAmount               decimal(12,5), 
pReferenceFolioId        varchar(20), 
pRoomNumber              varchar(20), 
pAccountId               varchar(20), 
pGuestName               varchar(200), 
pCompanyName             varchar(20), 
pArrivalDate             datetime, 
pDepartureDate           datetime, 
pReferenceDriverId       varchar(20), 
pCarCompany              varchar(100), 
pMakeModel               varchar(100), 
pPlateNumber             varchar(10), 
pCreditCardNo          varchar(20), 
pChequeNo               varchar(20), 
pAccountName            varchar(100), 
pBankName               varchar(100), 
pChequeDate             date, 
pFOCGrantedBy          varchar(100), 
pCreditCardType        varchar(20), 
pApprovalSlip           varchar(20), 
pCreditCardExpiry      datetime, 
pTerminalID              varchar(10), 
pShiftCode               varchar(10),
pCreatedBy               varchar(50)
)
BEGIN
insert into `accountingadjustments` 
(
hotelID, 
postingDate, 
transactionDate, 
transactionCode, 
subAccount, 
referenceNo, 
transactionSource, 
memo, 
acctSide, 
currencyCode, 
conversionRate, 
currencyAmount, 
baseAmount, 
grossAmount, 
discount, 
serviceCharge, 
serviceChargeInclusive, 
governmentTax, 
governmentTaxInclusive, 
localTax, 
localTaxInclusive, 
netBaseAmount, 
netAmount, 
referenceFolioId, 
roomNumber, 
accountId, 
guestName, 
companyName, 
arrivalDate, 
departureDate, 
referenceDriverId, 
carCompany, 
makeModel, 
plateNumber, 
creditCardNo, 
chequeNo, 
accountName, 
bankName, 
chequeDate, 
FOCGrantedBy, 
creditCardType, 
approvalSlip, 
creditCardExpiry, 
terminalID, 
shiftCode, 
statusFlag, 
postedToLedger, 
auditFlag, 
createdDate, 
createdBy, 
updatedDate, 
updatedBy
)
values
(
pHotelID, 
now(), 
pTransactionDate, 
pTransactionCode, 
pSubAccount, 
pReferenceNo, 
pTransactionSource, 
pMemo, 
pAcctSide, 
pCurrencyCode, 
pConversionRate, 
pCurrencyAmount, 
pBaseAmount, 
pGrossAmount, 
pDiscount, 
pServiceCharge, 
pServiceChargeInclusive, 
pGovernmentTax, 
pGovernmentTaxInclusive, 
pLocalTax, 
pLocalTaxInclusive, 
pNetBaseAmount, 
pNetAmount, 
pReferenceFolioId, 
pRoomNumber, 
pAccountId, 
pGuestName, 
pCompanyName, 
pArrivalDate, 
pDepartureDate, 
pReferenceDriverId, 
pCarCompany, 
pMakeModel, 
pPlateNumber, 
pCreditCardNo, 
pChequeNo, 
pAccountName, 
pBankName, 
pChequeDate, 
pFOCGrantedBy, 
pCreditCardType, 
pApprovalSlip, 
pCreditCardExpiry, 
pTerminalID, 
pShiftCode, 
'ACTIVE', 
0, 
0, 
now(), 
pCreatedBy, 
now(), 
pCreatedBy)
;
update 
drivers 
set 
totalCommission = totalCommission + if(pReferenceDriverId != "", pNetAmount, 0)
where driverId = pReferenceDriverId;
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertAccountPrivilege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertAccountPrivilege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertAccountPrivilege`(
pHotelID          int(5),     
pAccountID        varchar(20),       
pPrivilegeID      varchar(20),    
pCreatedBy        varchar(20)       
)
BEGIN
insert into `accountprivileges` 
(HotelID, AccountID, PrivilegeID, 
stateFlag, CreatedDate, CreatedBy, 
UpdatedDate, UpdatedBy)
values
(pHotelID, pAccountID, pPrivilegeID, 
"ACTIVE", now(), pCreatedBy, 
now(), pCreatedBy);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertAgent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertAgent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertAgent`(
in pAddress    	text,
in pAgency      varchar(150), 
in pContactNo   varchar(50), 
in pContactPerson  varchar(100),
in pHOTEL_ID    int(4),
in pCREATED_BY  varchar(50)
)
BEGIN
insert into `agents` 
(agency, contactPerson, address, 
contactNumber, CREATED_DATE, 
CREATED_BY, UPDATED_DATE, UPDATED_BY, 
HOTEL_ID)
values
(pAgency, pContactPerson, address, 
pContactPerson, now(), 
pContactNo, now(), pCREATED_BY, 
pHOTEL_ID)
;
select last_insert_id()
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertAmenity` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertAmenity` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertAmenity`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertAppliedRates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertAppliedRates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertAppliedRates`(
pDescription text,
pOccupants int(5),
pHotelID int(10),
pUser varchar(20), 
pRateType varchar(20))
BEGIN
insert into appliedRates (description, rateType, noOfOccupants, `status`, hotelID, createdby, createtime, updatedby, updatetime) values(pDescription, pRateType, pOccupants, 'active', pHotelID, pUser, now(), pUser, now());
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertAudit` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertAudit` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertAudit`(in pAuditDate Date,
in pShiftCode int(3),
in pMeridian varchar(15),
in pTriggeredBy varchar(30)
)
BEGIN
insert into auditdateTable (AuditDate,ShiftCode,Meridian,SystemDate,TriggeredBy)
values(pAuditDate,pShiftCode,pMeridian,now(),pTriggeredBy);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertBackOfficeConfig` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertBackOfficeConfig` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertBackOfficeConfig`(
pBACK_OFFICE_CODE        varchar(100),
pBACK_OFFICE_NAME        varchar(200),
pBACK_OFFICE_VERSION     varchar(150),
pPOSTING_SCHEDULE        enum('DAILY','WEEKLY','MONTHLY','ANNUAL'),
pPOSTING_SCHEDULE_YEAR   varchar(10),
pPOSTING_SCHEDULE_MONTH  datetime,
pPOSTING_SCHEDULE_DAY    varchar(10),
pPOSTING_SCHEDULE_TIME   varchar(12),
pCONNECTION_STRING       text,
pHOTEL_ID                int(4),
pCREATED_BY              varchar(50)
)
BEGIN
insert into `back_office_config` 
(BACK_OFFICE_CODE, BACK_OFFICE_NAME, BACK_OFFICE_VERSION, 
POSTING_SCHEDULE, POSTING_SCHEDULE_YEAR, 
POSTING_SCHEDULE_MONTH, POSTING_SCHEDULE_DAY, 
POSTING_SCHEDULE_TIME, CONNECTION_STRING, 
HOTEL_ID, CREATED_BY, CREATE_TIME, UPDATED_BY, 
UPDATE_TIME)
values
(pBACK_OFFICE_CODE, pBACK_OFFICE_NAME, pBACK_OFFICE_VERSION, 
pPOSTING_SCHEDULE, pPOSTING_SCHEDULE_YEAR, 
monthname(pPOSTING_SCHEDULE_MONTH), pPOSTING_SCHEDULE_DAY, 
pPOSTING_SCHEDULE_TIME, pCONNECTION_STRING, 
pHOTEL_ID, pCREATED_BY, now(), pCREATED_BY, 
now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertBlockDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertBlockDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertBlockDetails`(
in pBlockid int(11),
in pRoomId varchar(11),
in pBlockFrom date,
in pBlockTo date
)
BEGIN
Insert into blockingdetails(blockid,roomid,blockfrom,blockto)
values(pBlockid,pRoomId,pBlockFrom,pBlockTo);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertCallCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertCallCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertCallCharges`(  
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertCallLog` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertCallLog` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertCallLog`(pDay varchar(10),
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertCashier` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertCashier` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertCashier`(
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
in pnetamount double(9,2)
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
netamount
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
pnetamount
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertCashier_Logs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertCashier_Logs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertCashier_Logs`(
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
pHOTELID             int(5), 
pCREATEDBY           varchar(20),
pRemarks	     text
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
pHOTELID, 
now(), 
pCREATEDBY, 
now(), 
pCREATEDBY,
pRemarks
)
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertCityLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertCityLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertCityLedger`(
pAcctID         varchar(20), 
pDate           date, 
pRefno          varchar(20), 
pDebit          double(12,2), 
pCredit         double(12,2), 
pReffolio       varchar(200), 
pSubfolio       varchar(1), 
pHOTELID        int(5),
pCREATEDBY      varchar(20)
)
BEGIN
insert into `cityledger` 
(AcctID, Date, refno, debit, credit, 
reffolio, subfolio, HOTELID, CREATETIME, 
CREATEDBY, UPDATETIME, UPDATEDBY, posttoacctng, 
closed)
values
(pAcctID, pDate, pRefno, pDebit, pCredit, 
pReffolio, pSubfolio, pHOTELID, now(), 
pCREATEDBY, now(), pCREATEDBY, '0', 
'0');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertCityLedgerPayment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertCityLedgerPayment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertCityLedgerPayment`(
pAcctID varchar(20), 
prefno varchar(20),
pdebit decimal(12,2),
pcredit decimal(12,2), 
preffolio varchar(20), 
psubfolio varchar(20), 
pHOTELID int(4), 
pCREATEDBY varchar(20)
)
BEGIN
insert into `cityledger` 
(AcctID, Date, refno, debit, credit, 
reffolio, subfolio, HOTELID, 
CREATETIME, CREATEDBY, UPDATETIME, 
UPDATEDBY, posttoacctng)
values
(pAcctID, curdate(), prefno, pdebit, pcredit, 
preffolio, psubfolio, pHOTELID, 
now(), pCREATEDBY, now(), 
pCREATEDBY, 0);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertCompanyAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertCompanyAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertCompanyAccount`(
in pcompanyid varchar(20),
in `pcompanycode` text,         
in `pcompanyname` text,
in `pcompanyurl` text,                  
in `pcontactperson` varchar(200),         
in `pdesignation` varchar(200),           
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
in pcreatedby varchar(20),
in pAccount_Type varchar(100),
in pCard_No varchar(100),
in pThreshold_Value double(12,2),
in pNo_Of_Visit int(4),
in pTotal_Sales_Contribution double(12,2),
in pX_DEAL_AMOUNT double(12,2),
in pRemarks text,
in pTIN varchar(20)
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
pcreatedby,
pAccount_Type,
pCard_No,
pThreshold_Value,
0,
pTotal_Sales_Contribution,
pX_DEAL_AMOUNT,
pRemarks,
pTin
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertContact` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertContact` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertContact`(
pContactNumber  varchar(100),
pContactType    varchar(20),
pContactName    varchar(100),
pFullName       varchar(200),
pDesignation    varchar(50),
pCompany        varchar(100),
pAddress        varchar(200),
pEmailAddress   varchar(100),
pRemarks        varchar(500),
pCreatedBy      varchar(20),
pHotelId        int(4)
)
BEGIN
insert into `contacts` 
(contactNumber, contactType, contactName, 
fullName, designation, company, address, 
emailAddress, remarks, statusFlag, createdBy, 
createTime, updatedBy, updateTime, hotelId
)
values
(pContactNumber, pContactType, pContactName, 
pFullName, pDesignation, pCompany, pAddress, 
pEmailAddress, pRemarks, 'ACTIVE', pCreatedBy, 
now(), pCreatedBy, now(), pHotelId
);
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertContactPerson` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertContactPerson` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertContactPerson`(
pLastName varchar(50),
pFirstName varchar(50),
pMiddleName varchar(50),
pDesignation varchar(50),
pPersonType varchar(50),
pAddress varchar(100),
pTelNo varchar(50),
pMobileNo varchar(50),
pFaxNo varchar(50),
pEmail varchar(50),
pFolioID varchar(20),
pAccountID varchar(20),
pHotelID int(5),
pCreatedBy varchar(50),
pBirthdate datetime
)
BEGIN
set @contactID = fGetContactPersonSeq();
insert into contactpersons set
contactID = @contactID,
lastName = pLastName,
firstName = pFirstName,
middleName = pMiddleName,
designation = pDesignation,
personType = pPersonType,
address = pAddress,
telNo = pTelNo,
mobileNo = pMobileNo,
faxNo = pFaxNo,
email = pEmail,
folioID = pFolioID,
accountID = pAccountID,
hotelID = pHotelID,
createdBy = pCreatedBy,
birthdate = pBirthdate,
createdOn = now();
select @contactID as contactID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertContractAmendment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertContractAmendment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertContractAmendment`(pAmendmentID varchar(50),
pFolioID varchar(30),
pOldValue text,
pNewValue text,
pUser varchar(30),
pHotelID int(5))
BEGIN
insert into ContractAmmendments (AmmendmentID, FolioID, OldValue, NewValue, CreatedBy, CreateTime, UpdatedBy, UpdateTime, HotelID) values (pAmendmentID, pFolioID, pOldValue, pNewValue, pUser, now(), pUser, now(), pHotelID);
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertCurrencyCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertCurrencyCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertCurrencyCode`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertDepartment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertDepartment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertDepartment`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertDriver` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertDriver` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertDriver`(
in pLicenseNumber    varchar(100),
in pLastName         varchar(50), 
in pFirstName        varchar(50), 
in pMiddleName       varchar(100),
in pCREATED_BY       varchar(50), 
in pHOTEL_ID         int(4),
in pCompany	varchar(60),
in pCarModel	varchar(50),
in pBrand	varchar(50),
in pPlateNumber	varchar(10)
)
BEGIN
insert into `drivers` 
(licenseNumber, lastName, firstName, 
middleName, totalCommission, CREATED_DATE, 
CREATED_BY, UPDATED_DATE, UPDATED_BY, 
HOTEL_ID, company, carModel, brand, plateNumber)
values
(pLicenseNumber, pLastName, pFirstName, 
pMiddleName, 0.00, now(), 
pCREATED_BY, now(), pCREATED_BY, 
pHOTEL_ID, pCompany, pCarModel, pBrand, pPlateNumber)
;
select last_insert_id()
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEngineeringJob` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEngineeringJob` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertEngineeringJob`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEngineeringService` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEngineeringService` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertEngineeringService`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEvent`(pFolioID varchar(20),
pEventType varchar(40),
pBookingDate datetime,
pLiveIn int(5),
pLiveOut int(5),
pGuaranteed int(5),
pBillingArrangement text,
pAuthorizedSignatory text,
pLobbyPosting text,
pCreatedBy varchar(20),
pHotelID int(2),
pEventPackage bigint(10),
pPackageAmount double(12,2),
pContactPerson text,
pContactAddress text,
pContactPosition varchar(200),
pContactNumber varchar(20),
pMobileNumber varchar(30),
pFaxNumber varchar(20),
pTotal double(12,2),
pEmailAdd varchar(100)
)
BEGIN
insert into event_booking_info values (
pFolioID, 
pEventType, 
pBookingDate, 
pLiveIn, 
pLiveOut, 
pGuaranteed, 
pBillingArrangement, 
pAuthorizedSignatory, 
pLobbyPosting, 
pHotelID, 
now(), 
pCreatedBy, 
now(), 
pCreatedBy, 
pEventPackage, 
pPackageAmount, 
pContactPerson, 
pContactAddress, 
pContactPosition, 
pContactNumber,
pMobileNumber,
pFaxNumber,
pTotal,
0,
pEmailAdd);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventAppliedRates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventAppliedRates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEventAppliedRates`(pFolioID varchar(20),
pRateType varchar(5),
pDescription text,
pRateAmount double(10,2),
pUser varchar(20),
pOccupants int(5))
BEGIN
insert into event_applied_rates values(pFolioID, pRateType, pDescription, pRateAmount, pOccupants, pUser, now(), pUser, now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventAttendance` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventAttendance` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEventAttendance`(
pFolioID varchar(20),
pHotelID int,
pGeographicalScope varchar(50),
pForeignParticipants int,
pLocalParticipants int,
pForeignBased int,
pLocalBased int,
pNoOfVisitors int,
pActualAttendees int,
pRemarks text,
pCreatedBy varchar(20)
)
BEGIN
insert into event_attendance set
FolioID = pFolioID,
HotelID = pHotelID,
GeographicalScope = pGeographicalScope,
ForeignParticipants = pForeignParticipants,
LocalParticipants = pLocalParticipants,
ForeignBased = pForeignBased,
LocalBased = pLocalBased,
NoOfVisitors = pNoOfVisitors,
ActualAttendees = pActualAttendees,
Remarks = pRemarks,
CreatedBy = pCreatedBy,
CreatedOn = now();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventAttributes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventAttributes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEventAttributes`(pEventID bigint(10), pKey varchar(40), pUser varchar(20))
BEGIN
insert into event_attributes values(pEventID, pKey, now(), pUser, now(), pUser);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventContact` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventContact` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEventContact`(
pContactID varchar(30),
pFolioID varchar(30),
pHotelID int,
pAccountID varchar(30)
)
BEGIN
insert into event_contacts set
contactID = pContactID,
folioID = pFolioID,
hotelID = pHotelID,
accountID = pAccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEventDetails`(pFolioID varchar(20), pHeader text, pDescription text, pUser varchar(30))
BEGIN
insert into event_details values (pFolioID, pHeader, pDescription, now(), pUser, now(), pUser);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventEMDAction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventEMDAction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEventEMDAction`(
pFolioID varchar(20),
pAction varchar(100),
pHotelID int,
pCreatedBy varchar(20)
)
BEGIN
insert into event_EMD_actions set
folioID = pFolioID,
hotelID = pHotelID,
`action` = pAction,
createdBy = pCreatedby;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventEndorsement` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventEndorsement` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEventEndorsement`(
pFolioID varchar(20),
pLetterOfProposal varchar(30),
pContractAmount decimal(10,2),
pDueDate1 datetime,
pDueDate2 datetime,
pDueDate3 datetime,
pLetterOfAgreement varchar(20),
pPickupDate datetime,
pSentToClientDate datetime,
pSignedDate datetime,
pHotelID int,
pConcessions text,
pGiveaways text,
pCreatedBy varchar(20)
)
BEGIN
insert into event_endorsement
set 
folioID = pFolioID,
letterOfProposal = pLetterOfProposal,
contractAmount = pContractAmount,
dueDate1 = pDueDate1,
dueDate2 = pDueDate2,
dueDate3 = pDueDate3,
letterOfAgreement = pLetterOfAgreement,
pickupDate = pPickupDate,
sentToClientDate = pSentToClientDate,
signedDate = pSignedDate,
hotelID = pHotelID,
concessions = pConcessions,
giveaways = pGiveaways,
createdBy = pCreatedBy,
createdOn = now();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventOfficer` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventOfficer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEventOfficer`(
pUserID varchar(30),
pFolioID varchar(20),
pHotelID int,
pCreatedBy varchar(20)
)
BEGIN
insert into event_officers set ID = fGetSequence('eventOfficer','1'), userID = pUserID ,folioID = pFolioID, hotelID = pHotelID, createdBy = pCreatedBy, createdOn = now();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventPackage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventPackage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertEventPackage`(pDescription text, pDaysApplied int(5), pEventType varchar(40), pPackageAmount double(12,2), pHoteliD int(10), pUser varchar(20), pMinimumPax int(5), pMaximumPax int(5))
BEGIN
insert into event_package_header (description, daysApplied, eventType, packageAmount, hotelID, `status`, createdby, createtime, updatedby, updatetime, minimumpax, maximumpax) values(pDescription, pDaysApplied, pEventType, pPackageAmount, pHotelID, 'active', pUser, now(), pUser, now(), pMinimumPax, pMaximumPax);
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventPackageDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventPackageDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertEventPackageDetails`(pPackageID bigint(20), pTransactionCode int(10), pDescription text, pAmount double(12,2), pSubAccount varchar(50))
BEGIN
insert into event_package_detail values(pPackageID, pTransactionCode, pDescription, pAmount, ltrim(pSubAccount));
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventPackageRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventPackageRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertEventPackageRequirements`(pPackageID bigint(20), pHeader text, pDetail text)
BEGIN
insert into event_package_requirement values(pPackageID, pHeader, pDetail);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEventRequirements`(pFolioID varchar(20), pCode varchar(50), pDescription text, pUser varchar(30), pSchedule text)
BEGIN
insert into event_requirements (folioID, requirementID, description, createtime, createdby, updatetime, updatedby, remarks) values (pFolioID, pCode, pDescription, now(), pUser, now(), pUser, pSchedule);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventRoomVenues` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventRoomVenues` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertEventRoomVenues`(pFolioID varchar(20), pRoomVenue varchar(35), pFromDate date, pToDate date, pStartTime varchar(15), pEndTime varchar(15), pUser varchar(30))
BEGIN
insert into event_room_venues values(pFolioID, pRoomVenue, pFromDate, pToDate, pStartTime, pEndTime, pUser, now(), pUser, now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertEventTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertEventTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertEventTypes`(in pEventType varchar(40), in pDescription text, pUser varchar(20), pBanquet int(2))
BEGIN
insert into event_type(eventType, description, `status`, createtime, createdby, updatetime, updatedby, banquetType) values(pEventType, pDescription, 'ACTIVE', now(), pUser, now(), pUser, pBanquet);
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFloor` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFloor` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertFloor`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertFolio`(
pHotelID            int(5), 
pFolioID            varchar(20), 
pAccountID          varchar(20), 
pReferenceNo        varchar(20),
pFolioType          varchar(25), 
pGroupName          text, 
pAccountType        varchar(25), 
pNoOfAdults         int(2), 
pNoOfChild          int(2), 
pMasterFolio        varchar(20), 
pCompanyID          varchar(20), 
pAgentID            varchar(20), 
pSource             varchar(50), 
pFromDate           datetime, 
pToDate             datetime, 
pArrivalDate        datetime, 
pDepartureDate      datetime, 
pPackageId          varchar(20), 
pStatus             varchar(15), 
pRemarks            text, 
pTerminal_Id        varchar(20), 
pShift_Code         varchar(20), 
pSupervisor_Id      varchar(50), 
pSales_Executive    varchar(20), 
pPayment_Mode       varchar(20), 
pPurpose            varchar(50), 
pReason_For_Cancel  text, 
pTaxExempted        tinyint(1), 
pFolioETA	    varchar(10),
pFolioETD	    varchar(10),
pCreatedBy           varchar(20)
)
BEGIN
insert into folio
(
hotelID, 
folioID, 
accountID, 
referenceNo,
folioType, 
groupName, 
accountType, 
noOfAdults, 
noOfChild, 
masterFolio, 
companyID, 
agentID, 
source, 
fromDate, 
toDate, 
arrivalDate, 
departureDate, 
packageId, 
`status`, 
remarks, 
terminal_Id, 
shift_Code, 
supervisor_Id, 
sales_Executive, 
payment_Mode, 
purpose, 
reason_For_Cancel, 
taxExempted, 
folioETA,
folioETD,
createTime, 
createdBy, 
updateTime, 
updatedBy
)
values
(
pHotelID, 
pFolioID, 
pAccountID, 
pReferenceNo,
pFolioType, 
pGroupName, 
pAccountType, 
pNoOfAdults, 
pNoOfChild, 
pMasterFolio, 
pCompanyID, 
pAgentID, 
pSource, 
pFromDate, 
pToDate, 
pArrivalDate, 
pDepartureDate, 
pPackageId, 
pStatus, 
pRemarks, 
pTerminal_Id, 
pShift_Code, 
pSupervisor_Id, 
pSales_Executive, 
pPayment_Mode, 
pPurpose, 
pReason_For_Cancel, 
pTaxExempted, 
pFolioETA,
pFolioETD,
now(), 
pCreatedBy, 
now(), 
pCreatedBy
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFolioInclusions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFolioInclusions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertFolioInclusions`(
in pHotelId int(5),
in pFolioID varchar(20),
in pMemo text,
in pCreatedby varchar(20)
)
BEGIN
insert into 
FolioInclusions
(hotelid, folioid, memo, createdby, createtime, updatedby, updatetime)
values
(
pHotelId,
pFolioID,
pMemo,
pCreatedBy,
now(),
pCreatedBy,
now()
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFolioLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFolioLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertFolioLedger`(
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
in pPostToLedger varchar(2),
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFolioPackages` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFolioPackages` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertFolioPackages`(
in pHotelId int(5),
in pFolioID varchar(20),
in pTransactionCode varchar(20),
in pBasis varchar(2),
in pPercentOff decimal(5,2),
in pAmountOff decimal(12,2),
in pDaysApplied varchar(50),
in pCreatedby varchar(20),
in pDateFrom datetime,
in pDateTo datetime
)
BEGIN
insert into 
foliopackage
(hotelid, folioid, transactioncode, basis, percentoff, amountoff, daysapplied, datefrom, dateto, createtime, createdby, updatetime, updatedby)
values
(
pHotelId,
pFolioID,
pTransactionCode,
pBasis,
pPercentOff,
pAmountOff,
pDaysApplied,
pDateFrom,
pDateTo,
now(),
pCreatedBy,
now(),
pCreatedBy
)
on duplicate key update 
Basis = pBasis,
PercentOff = pPercentOff,
AmountOff = pAmountOff,
DaysApplied = pDaysApplied,
updatedBy = pCreatedBy,
updatetime = now()
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFolioPrivilege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFolioPrivilege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertFolioPrivilege`(
in pHotelID          int(5),
in pFolioID          varchar(20),
in pTransactionCode  varchar(20),
in pBasis            varchar(1),
in pPercentoff       decimal(5,2),
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
) on duplicate
key update percentOff = if(pPercentOff > percentOff,pPercentOff , percentOff),
amountOff = if(pAmountOff > amountOff, pAmountOff, amountOff);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFolioRecurringCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFolioRecurringCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertFolioRecurringCharge`(
pHotelID int(5),
pFolioID varchar(20),
pTransactionCode  varchar(20),
pMemo TEXT,
pAmount decimal(12,2),
pFromDate datetime,
pTodate datetime,
pCreatedBy varchar(20),
pSummaryFlag int(2),
pPackageID int(5),
pSubAccount varchar(50),
pRoomID  varchar(20),
pQtyHrs int,
pDiscount decimal(4,2),
pRateType varchar(30),
pBaseAmount decimal(12,2),
pTax decimal(4,2)
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
pCreatedBy,
pSummaryFlag,
pPackageID,
pSubAccount,
pRoomID,
pQtyHrs,
pDiscount,
pRateType,
pBaseAmount,
pTax
)
on duplicate key update
Amount = pAmount,
FromDate = pFromDate,
Todate = pTodate,
updatedby = pCreatedBy,
updateTime = now(),
summaryFlag  = pSummaryFlag,
packageID = pPackageID,
subAccount=pSubAccount
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFolioRouting` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFolioRouting` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertFolioRouting`(
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
insert into folioRouting
values
(
photelid,
pfolioid,
pSubFolio,
pTransactionCode,
pBasis,
pPercentCharged,
pAmountCharged,
now(),
pCreatedby,
now(),
pUpdatedBy
)
on duplicate key update 
Basis = pBasis, 
PercentCharged = pPercentCharged,
AmountCharged = pAmountCharged,
updateTime = now(), 
updatedby = pUpdatedBy;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFolioSchedule` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFolioSchedule` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertFolioSchedule`(
pHOTELID     int(5),        
pFolioId     varchar(20),        
pRoomID      varchar(10),        
pRoomType    varchar(80),     
pFROMDATE    datetime,          
pTODATE      datetime,         
pDays        int(3),        
pRATETYPE    varchar(25),      
pRATE        decimal(12,2),       
pBREAKFAST   varchar(20),       
pCREATEDBY   varchar(20),         
pUPDATEDBY   varchar(20),
pTerminalId  varchar(20),
pShiftCode   varchar(20),
pSupervisorId varchar(50),
pStartTime   time,
pEndTime     time,
pVenue 	     text,
pSetup       text,
pRemarks     text,
pGuaranteedPax int(5),
pActivity    varchar(30)
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
CREATETIME,
TERMINAL_ID,
SHIFT_CODE,
SUPERVISOR_ID,
startTime,
endTime,
venue,
setup,
remarks,
guaranteedPax,
activity,
id
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
now(),
pTerminalId,
pShiftCode,
pSupervisorId,
pStartTime,
pEndTime,
pVenue,
pSetup,
pRemarks,
pGuaranteedPax,
pActivity,
fGetSequence('folioschedules', pHOTELID)
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFolioTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFolioTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertFolioTransaction`(	
pHotelId                 int(5),
pFolioId                 varchar(20),
pSubFolio                varchar(1),
pAccountId               varchar(20),
pTransactionDate         datetime,
pTransactionCode         varchar(20),
pSubAccount              varchar(100),
pReferenceNo             varchar(20),
pTransactionSource       varchar(20),
pMemo                    varchar(500),
pAcctSide                varchar(10),
pCurrencyCode            varchar(10),
pConversionRate          decimal(12,5),
pCurrencyAmount          decimal(12,5),
pBaseAmount              decimal(12,5),
pGrossAmount             decimal(12,5),
pDiscount                decimal(12,5),
pServiceCharge           decimal(12,5),
pServiceChargeInclusive  tinyint(1),
pGovernmentTax           decimal(12,5),
pGovernmentTaxInclusive  tinyint(1),
pLocalTax                decimal(12,5),
pLocalTaxInclusive       tinyint(1),
pNetBaseAmount           decimal(12,5),
pNetAmount               decimal(12,5),
pCreditCardNo            varchar(20),
pChequeNo                varchar(20),
pAccountName             varchar(100),
pBankName                varchar(100),
pChequeDate              date,
pFOCGrantedBy            varchar(100),
pCreditCardType          varchar(20),
pApprovalSlip            varchar(20),
pCreditCardExpiry        date,
pRouteSequence           varchar(100),
pSourceFolio             varchar(20),
pSourceSubFolio          varchar(1),
pTerminalID              varchar(10),
pShiftCode               varchar(10),
pCreatedBy               varchar(20),
pSummaryFlag		 int(1),
pPackageID		 varchar(5),
pMealAmount		decimal(12,5),
pAdjustmentFlag		varchar(1),
pRoomID			varchar(20)
)
BEGIN
insert into `foliotransactions` (
hotelId, 
folioId, 
subFolio, 
accountId, 
transactionDate, 
postingDate, 
transactionCode, 
subAccount, 
referenceNo, 
transactionSource, 
memo, 
acctSide, 
currencyCode, 
conversionRate, 
currencyAmount, 
baseAmount, 
grossAmount, 
discount, 
serviceCharge, 
serviceChargeInclusive, 
governmentTax, 
governmentTaxInclusive, 
localTax, 
localTaxInclusive, 
netBaseAmount, 
netAmount, 
creditCardNo, 
chequeNo, 
accountName, 
bankName, 
chequeDate, 
FOCGrantedBy, 
creditCardType, 
approvalSlip, 
creditCardExpiry, 
routeSequence, 
sourceFolio, 
sourceSubFolio, 
terminalID, 
shiftCode, 
`status`, 
postToLedger, 
createTime, 
createdBy, 
updateTime, 
updatedBy, 
auditFlag,
summaryFlag,
packageID,
mealAmount,
adjustmentFlag,
roomID )
values (
pHotelId , 
pFolioId, 
pSubFolio, 
pAccountId, 
pTransactionDate, 
now(), 
pTransactionCode, 
pSubAccount, 
pReferenceNo, 
pTransactionSource, 
pMemo, 
pAcctSide, 
pCurrencyCode, 
pConversionRate, 
pCurrencyAmount, 
pBaseAmount, 
pGrossAmount, 
pDiscount, 
pServiceCharge, 
pServiceChargeInclusive, 
pGovernmentTax, 
pGovernmentTaxInclusive, 
pLocalTax, 
pLocalTaxInclusive, 
pNetBaseAmount, 
pNetAmount, 
pCreditCardNo, 
pChequeNo, 
pAccountName, 
pBankName, 
pChequeDate, 
pFOCGrantedBy, 
pCreditCardType, 
pApprovalSlip, 
pCreditCardExpiry, 
pRouteSequence, 
pSourceFolio, 
pSourceSubFolio, 
pTerminalID, 
pShiftCode, 
'ACTIVE', 
0, 
now(), 
pCreatedBy, 
now(), 
pCreatedBy, 0,
pSummaryFlag,
pPackageID,
pMealAmount,
pAdjustmentFlag,
pRoomID
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertFoodRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertFoodRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertFoodRequirements`(pFolioID varchar(20),
pEventDate datetime,
pVenue varchar(30),
pPax int(5),
pStartTime varchar(25),
pEndTime varchar(25),
pOver text,
pSetup text,
pRemarks text,
pTotalCost double(12,2),
pUser varchar(20),
pMealID int(5),
pMealType varchar(30),
pLiveIn int(5),
pLiveOut int(5))
BEGIN
insert into event_meal_requirements
(folioID, eventDate, venue, pax, startTime, endTime, over, setup, remarks, totalMealCost, createtime, createdby, updatetime, updatedby, mealID, mealType, liveInPax, LiveOutPax)
values(pFolioID, pEventDate, pVenue, pPax, pStartTime, pEndTime, pOver, pSetup, pRemarks, pTotalCost, now(), pUser, now(), pUser, pMealID, pMealType, pLiveIn, pLiveOut);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertGroup` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertGroup` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertGroup`(
pGROUP_ID     varchar(20),
pMAINGROUP_ID VARCHAR(20),
pDESCRIPTION  varchar(100), 
pCREATEDBY    varchar(30),
pRESTOID	int(5)
)
BEGIN
insert into `pos`.`group` 
(RESTO_ID, GROUP_ID, MAINGROUP_ID, DESCRIPTION, STATUS, CREATEDBY, 
CREATETIME, UPDATEDBY, UPDATETIME)
values
(pRESTOID, pGROUP_ID, pMAINGROUP_ID, pDESCRIPTION, 'ACTIVE', pCREATEDBY, 
now(), pCREATEDBY, now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertGroupBookingDropDown` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertGroupBookingDropDown` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertGroupBookingDropDown`(
pFieldName varchar(50),
pValue varchar(150),
pCreatedBy varchar(50)
)
BEGIN
insert into groupbookingdropdown set
FieldName = pFieldName,
`Value` = pValue,
CreatedBy = pCreatedBy,
UpdatedBy = pCreatedBy,
UpdatedDate = now(),
CreatedDate = now();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertGroupFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertGroupFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertGroupFolio`(
IN pFolioID varchar(12),
IN pAccountID varchar(12),
in pEventID varchar(12),
IN pFolioType VARCHAR(25), 
in pOrgName text,
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertGuest` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertGuest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertGuest`(
paccountid     varchar(20)   ,       
paccountname   varchar(50)   ,
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
pCREATEDBY     varchar(20)   ,
pBIRTH_DATE     date	     ,
pACCOUNT_TYPE     varchar(50)   ,
pCARD_NO varchar(100),
pTHRESHOLD_VALUE double(12,2),
pTOTAL_SALES_CONTRIBUTION double(12,2),
pCreditCardType            varchar(50),
pCreditCardNo              varchar(50),
pCreditCardExpiry          varchar(10),
pTaxExempted tinyint(1),
pCreateTime datetime
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
0, 
pmemo, 
pconcierge, 
premarks,
'ACTIVE', 
pHOTELID, 
now(), 
pCREATEDBY, 
now(), 
pCREATEDBY,
if(pBIRTH_DATE = '0001-01-01','1900-01-01',pBIRTH_DATE),
pACCOUNT_TYPE,
pCARD_NO,
pTHRESHOLD_VALUE,
pTOTAL_SALES_CONTRIBUTION,
pCreditCardType,
pCreditCardNo,
pCreditCardExpiry,
pTaxExempted
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertHotel` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertHotel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertHotel`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertHouseKeeper` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertHouseKeeper` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertHouseKeeper`(
in photelid int(5),
IN phousekeeperid VARCHAR(20), 
IN plastname VARCHAR(50), 
IN pfirstname VARCHAR(50), 
IN pmiddlename VARCHAR(50),
in pcreatedby varchar(20)
)
BEGIN
insert into hk_housekeepers
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
pcreatedby,
''
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertHousekeepingJob` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertHousekeepingJob` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertHousekeepingJob`(
pHousekeepingDate   date,
pHousekeeperId      varchar(20),
pHousekeepingType   varchar(20),
pRoomId             varchar(20),
pStartTime          datetime,
pEndTime            varchar(20),
pRemarks            varchar(100),
pVerifiedBy         varchar(50),
pTimeVerified       varchar(20),
pHotelId            int(4),
pCreatedBy          varchar(50)
)
BEGIN
insert into `hk_housekeepingjobs` 
(
housekeepingDate, 
housekeeperId, 
housekeepingType, 
roomId, 
startTime, 
endTime, 
elapsedTime, 
remarks, 
isFinished, 
verifiedBy, 
timeVerified, 
hotelId, 
createTime, 
createdBy, 
updateTime, 
updatedBy, 
stateFlag)
values
(
pHousekeepingDate, 
pHousekeeperId, 
pHousekeepingType, 
pRoomId, 
pStartTime, 
pEndTime, 
timediff(pEndTime,pStartTime), 
pRemarks, 
0, 
pVerifiedBy, 
pTimeVerified, 
pHotelId, 
now(), 
pCreatedBy, 
now(), 
pCreatedBy, 
"ACTIVE"
);
update rooms set cleaningstatus = 'CLEAN' where roomid = proomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertHouseKeepingLog` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertHouseKeepingLog` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertHouseKeepingLog`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertIncumbentOfficer` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertIncumbentOfficer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertIncumbentOfficer`(
pContactID varchar(20),
pFolioID varchar(20),
pHotelID int,
pCreatedBy varchar(20)
)
BEGIN
insert into event_incumbent_officers set contactID = pContactID, folioID = pFolioID, hotelID = pHotelID, createdBy = pCreatedBy, createdOn = now();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertMealDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertMealDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertMealDetails`(pMealID bigint(20),
pmenuCode varchar(20),
pMenuItemCode varchar(20),
pDescription text,
pRemarks text,
pUser varchar(30),
pPrice double (12,2))
BEGIN
insert into event_meal_details (mealID, menuCode, menuItemCode, description, remarks, price, createTime, createdBy, updateTime, updatedBy) values
(pMealID, pmenuCode, pMenuItemCode, pDescription, pRemarks, pPrice, now(), pUser, now(), pUser);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertMealGroup` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertMealGroup` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertMealGroup`(pDescription varchar(100), pMainGroupId varchar(20), pHotelID int(10), pUser varchar(20))
BEGIN
insert into meal_group(description,mainGroupId, `status`, hotelID, createdby, createtime, updatedby, updatetime) values(pDescription, pMainGroupId,'active', pHotelID, pUser, now(), pUser, now());
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertMealHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertMealHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertMealHeader`(pMealID bigint(20),
pFolioID varchar(20),
pMealType varchar(30),
pReadyTime varchar(15),
pDeliverTime varchar(15),
pUser varchar(30),
pEventDate datetime,
pMealCost double(12,2),
pPaxLiveIn int(5),
pPaxLiveOut int(5))
BEGIN
insert into event_meal_header (mealID, folioID, mealType, readyTime, deliverTime, createtime, createdby, updatetime, updatedby, eventDate, mealCost, paxLiveIn, paxLiveOut)
values (pMealID, pFolioID, pMealType, pReadyTime, pDeliverTime, now(), pUser, now(), pUser, pEventDate, pMealCost, pPaxLiveIn, pPaxLiveOut);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertMealItems` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertMealItems` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertMealItems`(pMealID varchar(30), pDescription text, pGroupID bigint(10), pUnit varchar(25), pUnitCost double(12,2), pSellingPrice double(12,2), pVat double(12,2), pServiceCharge double(12,2), pHotelID int(10), pUser varchar(20))
BEGIN
insert into meal_items(itemID, description, groupID, unit, unit_cost, selling_price, vat, service_charge, `status`, hotelID, createdby, createtime, updatedby, updatetime)
values (pMealID, pDescription, pGroupID, pUnit, pUnitCost, pSellingPrice, pVat, pServiceCharge, 'active', pHotelID, pUser, now(), pUser, now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertMealMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertMealMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertMealMenu`(pDescription text, pPrice double(12,2), pVat double(12,2), pServiceCharge double(12,2), pHotelID int(10), pUser varchar(20))
BEGIN
insert into meal_menu (description, price, vat, service_charge, `status`, hotel_id, createdby, createtime, updatedby, updatetime) values (pDescription, pPrice, pVat, pServiceCharge, 'active', pHotelID, pUser, now(), pUser, now());
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertMealMenuDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertMealMenuDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertMealMenuDetail`(pMenuID varchar(30), pItemID varchar(30))
BEGIN
insert into meal_menu_detail (menuID, itemID, quantity) values (pMenuID, pItemID, 0);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertMenuDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertMenuDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertMenuDetail`(
pMENU_ID     varchar(10),  
pITEM_ID     varchar(10),   
pQUANTITY  	int
)
BEGIN
insert into `pos`.`menu detail` 
(MENU_ID, ITEM_ID, QUANTITY)
values
(pMENU_ID, pITEM_ID, pQUANTITY);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertNewCompany` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertNewCompany` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertNewCompany`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertNonGuestTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertNonGuestTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertNonGuestTransaction`(
pHotelID             int(5),
pTransactionDate     date, 
pTransactionCode     varchar(20),
pSubAccount              varchar(100), 
pReferenceNo             varchar(20),
pTransactionSource       varchar(20), 
pMemo                    varchar(500), 
pAcctSide                varchar(10), 
pCurrencyCode            varchar(10), 
pConversionRate          decimal(12,5), 
pCurrencyAmount          decimal(12,5), 
pBaseAmount              decimal(12,5), 
pGrossAmount             decimal(12,5), 
pDiscount                decimal(12,5), 
pServiceCharge           decimal(12,5), 
pServiceChargeInclusive  tinyint(1), 
pGovernmentTax           decimal(12,5), 
pGovernmentTaxInclusive  tinyint(1), 
pLocalTax                decimal(12,5), 
pLocalTaxInclusive       tinyint(1), 
pNetBaseAmount           decimal(12,5), 
pNetAmount               decimal(12,5), 
pReferenceFolioId        varchar(20), 
pRoomNumber              varchar(20), 
pAccountId               varchar(20), 
pGuestName               varchar(200), 
pCompanyName             varchar(200), 
pArrivalDate             datetime, 
pDepartureDate           datetime, 
pReferenceDriverId       varchar(20), 
pCarCompany              varchar(100), 
pMakeModel               varchar(100), 
pPlateNumber             varchar(10), 
pCreditCardNo          varchar(20), 
pChequeNo               varchar(20), 
pAccountName            varchar(100), 
pBankName               varchar(100), 
pChequeDate             date, 
pFOCGrantedBy          varchar(100), 
pCreditCardType        varchar(20), 
pApprovalSlip           varchar(20), 
pCreditCardExpiry      datetime, 
pTerminalID              varchar(10), 
pShiftCode               varchar(10),
pCreatedBy               varchar(50)
)
BEGIN
insert into `nonguesttransaction` 
(
hotelID, 
postingDate, 
transactionDate, 
transactionCode, 
subAccount, 
referenceNo, 
transactionSource, 
memo, 
acctSide, 
currencyCode, 
conversionRate, 
currencyAmount, 
baseAmount, 
grossAmount, 
discount, 
serviceCharge, 
serviceChargeInclusive, 
governmentTax, 
governmentTaxInclusive, 
localTax, 
localTaxInclusive, 
netBaseAmount, 
netAmount, 
referenceFolioId, 
roomNumber, 
accountId, 
guestName, 
companyName, 
arrivalDate, 
departureDate, 
referenceDriverId, 
carCompany, 
makeModel, 
plateNumber, 
creditCardNo, 
chequeNo, 
accountName, 
bankName, 
chequeDate, 
FOCGrantedBy, 
creditCardType, 
approvalSlip, 
creditCardExpiry, 
terminalID, 
shiftCode, 
statusFlag, 
postedToLedger, 
auditFlag, 
createdDate, 
createdBy, 
updatedDate, 
updatedBy
)
values
(
pHotelID, 
now(), 
pTransactionDate, 
pTransactionCode, 
pSubAccount, 
pReferenceNo, 
pTransactionSource, 
pMemo, 
pAcctSide, 
pCurrencyCode, 
pConversionRate, 
pCurrencyAmount, 
pBaseAmount, 
pGrossAmount, 
pDiscount, 
pServiceCharge, 
pServiceChargeInclusive, 
pGovernmentTax, 
pGovernmentTaxInclusive, 
pLocalTax, 
pLocalTaxInclusive, 
pNetBaseAmount, 
pNetAmount, 
pReferenceFolioId, 
pRoomNumber, 
pAccountId, 
pGuestName, 
pCompanyName, 
pArrivalDate, 
pDepartureDate, 
pReferenceDriverId, 
pCarCompany, 
pMakeModel, 
pPlateNumber, 
pCreditCardNo, 
pChequeNo, 
pAccountName, 
pBankName, 
pChequeDate, 
pFOCGrantedBy, 
pCreditCardType, 
pApprovalSlip, 
pCreditCardExpiry, 
pTerminalID, 
pShiftCode, 
'ACTIVE', 
0, 
0, 
now(), 
pCreatedBy, 
now(), 
pCreatedBy)
;
update 
drivers 
set 
totalCommission = totalCommission + if(pReferenceDriverId != "", pNetAmount, 0)
where driverId = pReferenceDriverId;
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertPackageDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertPackageDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertPackageDetails`(
pPackageID        varchar(20), 
pTransactionCode  varchar(20),   
pBasis            varchar(1),        
pPercentOff       decimal(5,2),   
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertPackageHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertPackageHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertPackageHeader`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertPaymentLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertPaymentLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertPaymentLedger`(
pAcctID        varchar(20),
pDate          date,
pRefno         varchar(20),
pMemo	       text,
pAmountPaid    double(12,2),
pWithHoldingTax double(12,2),
pDebit         double(12,2),
pCredit        double(12,2),
pReffolio      varchar(20),
pSubfolio      varchar(1),
pHOTELID       int(5),
pCREATEDBY     varchar(20)
)
BEGIN
insert into `paymentledger` 
(acctid, date, refno,memo, amountPaid,withHoldingTax, debit, credit, 
reffolio, subfolio, HOTELID, CREATETIME, 
CREATEDBY, UPDATETIME, UPDATEDBY, posttoacctng, 
closed)
values
(pAcctid, pDate, pRefno,pMemo, pAmountPaid, pWithHoldingTax, pDebit, pCredit, 
pReffolio, pSubfolio, pHOTELID, now(), 
pCREATEDBY,now(), pCREATEDBY,'0', 
'0');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertPrivilegeDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertPrivilegeDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertPrivilegeDetails`(
pPrivilegeID        varchar(20), 
pTransactionCode  varchar(20),   
pBasis            varchar(1),        
pPercentOff       decimal(5,2),   
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertPrivilegeHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertPrivilegeHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertPrivilegeHeader`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertPromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertPromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertPromo`(in ppromocode int,in ppromoname varchar(20),in ppercentoff int,in pstartdate date,in penddate date, in pbreakfastflag bool)
BEGIN
insert into promos(promocode,promoname,percentoff,startdate,enddate,breakfastflag)
values(ppromocode,ppromoname,ppercentoff,pstartdate,penddate,pbreakfastflag);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRateCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRateCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRateCode`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRateType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRateType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRateType`(
in proomtypecode varchar(50),
in pratecode varchar(50),
in proomid varchar(10),
in prateamount double(13,2),
in pHasBreakfast varchar(1),
in pBreakfastAmount double(12,2),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into ratetypes
values(
proomtypecode,
pratecode,
proomid,
prateamount,
pHasBreakfast,
pBreakfastAmount,
photelid,
now(),
pcreatedby,
now(),
pcreatedby,
'ACTIVE');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRequirementDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRequirementDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertRequirementDetail`(pRequirementID bigint(20), pDescription text, pUser varchar(20))
BEGIN
insert into requirement_details values(pRequirementID, pDescription, now(), pUser, now(), pUser);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRequirementHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRequirementHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertRequirementHeader`(in pDescription text, in pTransactionCode varchar(20), in pHotelID bigint(20), in pUser varchar(20))
BEGIN
insert into requirement_header (requirementDescription, transactionCode, hotelID, `status`, createtime, createdby, updatetime, updatedby) values (pDescription, pTransactionCode, pHotelID, 'ACTIVE', now(), pUser, now(), pUser);
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRestaurantLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRestaurantLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertRestaurantLedger`(
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
insert into `restaurantledger` 
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRole`(
pRoleName     varchar(30),
pDescription  varchar(100), 
pHotelId      int(5),    
pCreatedBy    varchar(30)
)
BEGIN
insert into `roles` 
(RoleName, Description, HotelId,
CreatedBy, CreateTime, UpdatedBy, UpdateTime
)
values
(pRoleName, pDescription, pHotelId, 
pCreatedBy, now(), pCreatedBy, now()
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoleMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoleMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRoleMenu`(
pRoleName   varchar(30),       
pMenu        varchar(50),         
pEnable      tinyint(1),
pHotelId     int(5),    
pCreatedBy   varchar(30) 
)
BEGIN
insert into `rolemenu` 
(RoleName, Menu, `Enable`, HotelId, 
stateFlag, CreatedBy, CreateTime, UpdatedBy, 
UpdateTime)
values
(pRoleName, pMenu, pEnable, pHotelId, 
'ACTIVE',pCreatedBy,now(),pCreatedBy,now())
on duplicate key update 
`Enable` = pEnable, 
updatedby = pCreatedby, 		
updateTime = now();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoleSystemPrivilege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoleSystemPrivilege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRoleSystemPrivilege`(
pHotelId               int(4),
pRoleName              varchar(50),
pPrivilegeDescription  varchar(500),
pIsAllowed             tinyint(1),
pCreatedBy             varchar(50)
)
BEGIN
insert into `role_privileges` 
(hotelId, roleName, privilegeDescription, 
isAllowed, createdBy, createTime, updatedBy, 
updateTime)
values
(pHotelId, pRoleName, pPrivilegeDescription, 
pIsAllowed, pCreatedBy, now(), pCreatedBy, 
now())
on duplicate key update 
isAllowed = pIsAllowed, 
updatedby = pCreatedby, 		
updateTime = now();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoleUIPrivilege` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoleUIPrivilege` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertRoleUIPrivilege`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertRoom`(
in proomid varchar(10),
in photelid int(5),
in proomtypecode varchar(50),
in pfloor int(4),
in pwindows tinyint(1),
in pdirfacing varchar(10),
in padjleft varchar(10),
in padjright varchar(10),
in proomimage varchar(80),
in psmokingtype tinyint(1),
in ptelephoneno varchar(15),
in pbedsplittable tinyint(1),
in pcreatedby varchar(20),
in pRoomDescription varchar(100),
in pRoomArea decimal
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
pbedsplittable,
now(),
pcreatedby,
now(),
pcreatedby,
pRoomDescription,
pRoomArea
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoomAmenity` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoomAmenity` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRoomAmenity`(
in proomid int,in pamenityid int
)
BEGIN
insert into roomamenities(roomid,amenityid)
values (proomid,pamenityid);
update amenities set amenities.stateflag = 'ASSIGNED'
where amenities.amenityid = pamenityid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoomBlock` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoomBlock` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRoomBlock`(
in pBlockid int(11),
in pReason text,
in pFolioID varchar(20),
in pHotelID int(11)
)
BEGIN
Insert into RoomBlock(blockid,reason, FolioID, HotelID)
values(pBlockID,pReason,pFolioID, pHotelID);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoomEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoomEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRoomEvents`(
pEventID     varchar(20),        
pRoomID      varchar(10),       
pEVENTDATE   datetime,      
pEventType   varchar(25),       
pRoomRate    decimal(12,2),       
pCREATEDBY   varchar(20),      
pHOTELID  int(5),
pTransferFlag tinyint(1),
pStartTime time,
pEndTime time
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
HOTELID,
transferFlag,
startTime,
endTime)  
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
pHOTELID  ,
pTransferFlag,
pStartTime,
pEndTime
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoomRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoomRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertRoomRequirements`(
pFolioID varchar(20),
pRoomType varchar(80),
pNoOfPax int(5),
pGuaranteedPax int(5),
pNoOfRooms int(5),
pGuaranteedRooms int(5),
pBlockedRooms int(5),
pRemarks text,
pUser varchar(30))
BEGIN
insert into event_rooms(folioID, roomType, noOfPax, guaranteedPax, noOfRooms, guaranteedRooms, blockedRooms, remarks, createdby, createtime, updatedby, updatetime)
values
(pFolioID, pRoomType, pNoOfPax, pGuaranteedPax, pNoOfRooms, pGuaranteedRooms, pBlockedRooms, pRemarks, pUser, now(), pUser, now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoomSchedule` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoomSchedule` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRoomSchedule`(
in pScheduleNo varchar(12),
in pRoomID varchar(12),
in pDate date,
in pEvent int(5),
in pEventType varchar(20)
)
BEGIN
insert into RoomSchedule(scheduleno,roomid,`date`,eventID,eventType)
values(pScheduleNO,pRoomnID,pDate,pEvent,pEventType);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoomSuperType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoomSuperType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRoomSuperType`(
in pRoomSuperType varchar(50),
in pDescription varchar(100),
in photelid int(5),
in pcreatedby varchar(20)
)
BEGIN
insert into roomsupertype
values(	
pRoomSuperType,
pDescription,
'ACTIVE',
photelid,
now(),
pcreatedby,
now(),
pcreatedby);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertRoomType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertRoomType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertRoomType`(
in proomtypecode varchar(80),
in pmaxoccupants int,
in pnoofbeds int,
in pnoofadult int,
in pnoofchild int ,
in psharetype varchar(15),
in photelid int(5),
in pcreatedby varchar(20),
in pRoomSuperType varchar(50)
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
pcreatedby,
pRoomSuperType);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertSchedule` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertSchedule` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertSchedule`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertShiftEndorsement` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertShiftEndorsement` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertShiftEndorsement`(
pLogDate                 datetime,
pTerminalNo              varchar(5),
pShiftCode               varchar(5),
pLoggedUser              varchar(50),
pEndorsementDescription  text,
pHotelId                 int(1)
)
BEGIN
insert into `shiftendorsements` 
(logDate, TerminalNo, shiftCode, 
loggedUser, endorsementDescription, 
statusFlag, endorsementRemarks, acknowledgedBy, 
acknowledgeAtTerminal, acknowledgeAtShiftCode, 
priorityLevel, createdBy, createTime, 
updatedBy, updateTime, hotelId)
values
(pLogDate, pTerminalNo, pShiftCode, 
pLoggedUser, pEndorsementDescription, 
'ACTIVE', '', '', 
0, 0, 
1, pLoggedUser, now(), 
pLoggedUser, now(), pHotelId);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertTransactionCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertTransactionCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertTransactionCode`(
pTranCode                  varchar(20),
pTranTypeId                varchar(20),
pMemo                      varchar(100),
pAcctSide                  varchar(10),
pServiceCharge             double(5,2),
pServiceChargeInclusive    tinyint(1),
pGovtTax                   double(5,2),
pGovtTaxInclusive          tinyint(1),
pLocalTax                  double(5,2),
pLocalTaxInclusive         tinyint(1),
pDefaultTransactionSource  varchar(100),
pDefaultAmount             double(12,2),
pWarningAmount             double(12,2),
pDepartmentId              varchar(20),
pLedger                    varchar(10),
pDebitSide                 varchar(20),
pCreditSide                varchar(20),
pHotelId                   int(5),
pCreatedBy                 varchar(20)
)
BEGIN
insert into `transactioncode` 
(tranCode, tranTypeId, memo, acctSide, 
serviceCharge, serviceChargeInclusive, 
govtTax, govtTaxInclusive, localTax, 
localTaxInclusive, defaultTransactionSource, 
defaultAmount, warningAmount, 
departmentId, ledger, debitSide, 
creditSide, hotelId, createTime, 
createdBy, updateTime, updatedBy, 
stateFlag)
values
(pTranCode, pTranTypeId, pMemo, pAcctSide, 
pServiceCharge, pServiceChargeInclusive, 
pGovtTax, pGovtTaxInclusive, pLocalTax, 
pLocalTaxInclusive, pDefaultTransactionSource, 
pDefaultAmount, pWarningAmount, 
pDepartmentId, pLedger, pDebitSide, 
pCreditSide, pHotelId, now(), 
pCreatedBy, now(), pCreatedBy, 
'ACTIVE');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertTransactionCodeSubAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertTransactionCodeSubAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertTransactionCodeSubAccount`(
pTransactionCode         varchar(20), 
pSubAccountCode          varchar(20), 
pLocalTax                double(5,2), 
pLocalTaxInclusive       tinyint(1), 
pGovernmentTax           double(5,2), 
pGovernmentTaxInclusive  tinyint(1), 
pServiceCharge           double(5,2), 
pServiceChargeInclusive  tinyint(1), 
pCreatedBy               varchar(50), 
pHotelId                 int(4)
)
BEGIN
insert into `transctioncode_subaccount` 
(transactionCode, subAccountCode, localTax, 
localTaxInclusive, governmentTax, governmentTaxInclusive, 
serviceCharge, serviceChargeInclusive, 
statusFlag, createdBy, createdDate, updatedBy, 
updatedDate, hotelId)
values
(pTransactionCode, pSubAccountCode, pLocalTax, 
pLocalTaxInclusive, pGovernmentTax, pGovernmentTaxInclusive, 
pServiceCharge, pServiceChargeInclusive, 
'ACTIVE', pCreatedBy, now(), pCreatedBy, 
now(), pHotelId)
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertTransactionSourceDocument` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertTransactionSourceDocument` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spInsertTransactionSourceDocument`(
in pDescription          varchar(100) , 
in pAbbreviation         varchar(10) , 
in pCreatedBy            varchar(50) 
)
BEGIN
insert into `transactionsourcedocuments` 
(description, abbreviation, 
statusFlag, createdBy, createdDate, updatedBy, 
updatedDate)
values
(pDescription, pAbbreviation, 
'ACTIVE', pCreatedBy, now(), pCreatedBy, 
now());
select last_insert_id();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertTranType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertTranType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertTranType`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertUser` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertUser` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertUser`(
in pUserId           varchar(30),
in pPassword         varchar(20),
in pEmployeeIdNo      varchar(20),
in pLastName          varchar(30),      
in pFirstName         varchar(30),   
in pDepartment        varchar(100),  
in pDesignation       varchar(50),
in pHotelId 		int(5),
in pcreatedBy	varchar(20)
)
BEGIN
select count(*) into @exist from users where UserId = pUserId and HotelId = pHotelId and Stateflag = 'DELETED';
if(@xist > 0) then 
update users set 
`Password` = pPassword,
EmployeeIdNo = pEmployeeIdNo,
LastName = pLastName,
FirstName = pFirstName,
Department = pDepartment,
Designation = pDesignation,
Stateflag = 'ACTIVE' 
where UserId = pUserId and HotelId = pHotelId and Stateflag = 'DELETED';
else
insert into users
(
UserId,
`Password`,
EmployeeIdNo,
LastName,
FirstName,
Department,
Designation,
Stateflag,
HotelId
)
values
(
pUserId,
md5(pPassword),
pEmployeeIdNo,
pLastName,
pFirstName,
pDepartment,
pDesignation,
'ACTIVE',
pHotelId
);
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spInsertUserRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `spInsertUserRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertUserRole`(
in pUserId varchar(20),
in pRoleName varchar(30),
in pHotelId int(5),
in pCreatedBy varchar(20)
)
BEGIN
select count(*) into @exist from userroles where UserId = pUserId and HotelId = pHotelId and RoleName = pRoleName;
if(@exist > 0) then 
update userroles set 
UpdatedBy = pCreatedBy where UserId = pUserId and HotelId = pHotelId and RoleName = pRoleName;
else
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
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_deleteGLAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_deleteGLAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_deleteGLAccount`(pAccountID varchar(30), pUser varchar(30))
BEGIN
update peachtree_glaccounts set `status`='DELETED', updatedBy=pUser, updatedAt=now() where accountID = pAccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_deleteMapping` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_deleteMapping` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPeachtree_deleteMapping`(pTransactionCode varchar(20), pGLAccount varchar(30), pUser varchar(30))
BEGIN
delete from peachtree_accountmapping where peachtree_accountmapping.transactionCode = pTransactionCode
and peachtree_accountmapping.accountID = pGLAccount;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_getAccountMapping` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_getAccountMapping` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_getAccountMapping`()
BEGIN
SELECT
peachtree_accountmapping.accountID
, peachtree_glaccounts.description
, peachtree_accountmapping.transactionCode
, transactioncode.memo
FROM
transactioncode
INNER JOIN peachtree_accountmapping 
ON (transactioncode.tranCode = peachtree_accountmapping.transactionCode)
INNER JOIN peachtree_glaccounts 
ON (peachtree_glaccounts.accountID = peachtree_accountmapping.accountID);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_GetAllPTemplates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_GetAllPTemplates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_GetAllPTemplates`()
BEGIN
select * from `peachtree_template`;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_getFolioPayments` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_getFolioPayments` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_getFolioPayments`(pDate datetime, pPostToLedger varchar(1))
BEGIN
SELECT
now() as depositTicketID
, folio.accountID
, folio.companyID
, foliotransactions.folioTransactionNo
, foliotransactions.transactionDate
, foliotransactions.memo
, (select accountID from peachtree_accountmapping where foliotransactions.transactionCode = peachtree_accountmapping.transactionCode
and peachtree_accountmapping.mappingType='CASH') as cashAccount
, foliotransactions.netAmount
, (select accountID from peachtree_accountmapping where '4100' = peachtree_accountmapping.transactionCode
and peachtree_accountmapping.mappingType='ACCOUNTS RECEIVABLE') as glAccount
FROM
foliotransactions
LEFT JOIN folio 
ON (foliotransactions.folioId = folio.folioID)
WHERE acctSide = 'CREDIT' AND DATE(foliotransactions.transactionDate) = DATE(pDate) ORDER BY foliotransactions.folioId
AND foliotransactions.postToLedger = pPostToLedger;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_getFolioTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_getFolioTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_getFolioTransactions`(pDate datetime, pPostToLedger varchar(1))
BEGIN
SELECT
foliotransactions.folioTransactionNo
, folio.accountID
, folio.companyID
, (SELECT company.companyname
FROM company WHERE company.companyid=folio.companyID) as companyName
, folio.folioID
, foliotransactions.transactionDate
, foliotransactions.discount
, foliotransactions.createdBy
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = '4100'
and mappingType = "ACCOUNTS RECEIVABLE") as transactionCode
, foliotransactions.netAmount as amount
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = foliotransactions.transactionCode
and mappingType = "SALES") as salesGLCode
, foliotransactions.localTax
, foliotransactions.governmentTax
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = '1800'
and mappingType = "SALES TAX PAYABLE") as taxGLCode
, foliotransactions.memo
FROM
foliotransactions
LEFT JOIN folio 
ON (foliotransactions.folioId = folio.folioID)
WHERE acctSide = 'DEBIT' AND DATE(foliotransactions.transactionDate) = DATE(pDate)
AND foliotransactions.transactionCode != '1201'
AND foliotransactions.postToLedger = pPostToLedger
ORDER BY foliotransactions.folioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_getGLAccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_getGLAccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_getGLAccounts`()
BEGIN
SELECT
accountID
, description
, `type`
, `status`
FROM
peachtree_glaccounts
WHERE `status`='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_getHotelTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_getHotelTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_getHotelTransactions`(pDate datetime, pPostToLedger varchar(1))
BEGIN
SELECT
transactionDate
, transactionId
, transactionCode
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = nonguesttransaction.transactionCode
and peachtree_accountmapping.mappingType = 'SALES') as debitCode
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = nonguesttransaction.transactionCode
and peachtree_accountmapping.mappingType = 'CASH') as creditCode
, memo
, netAmount
, acctSide
FROM
nonguesttransaction
WHERE
nonguesttransaction.transactionCode = '6000'
AND
date(nonguesttransaction.transactionDate) = date(pDate)
AND
nonguesttransaction.postedToLedger = pPostToLedger;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_GetNewCompanies` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_GetNewCompanies` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPeachtree_GetNewCompanies`(
pHotelID int(4),
pExportDate date
)
BEGIN
(select companyid as accountid,
companycode as accountname,
'' as firstname,
companyname as lastname,
street1 as street,
city1 as city,
zip1 as zip,
country1 as country,
contactnumber1 as TelephoneNo,
contactnumber2 as MobileNo,
contactnumber3 as FaxNo,
companyurl as emailaddress,
stateflag,
createtime,
(select accountID from peachtree_glaccounts where `type`='Income' and `description`='Sales' LIMIT 1) as GLAccount
from company
where
HOTELID = pHotelID AND
date(updatetime) = pExportDate OR
date(createtime) = pExportDate
order by createtime asc);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_GetNewCustomers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_GetNewCustomers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPeachtree_GetNewCustomers`(
pHotelID int(4),
pExportDate date
)
BEGIN
(select accountid,
accountname,
firstname,
lastname,
street,
city,
zip,
country,
TelephoneNo,
MobileNo,
FaxNo,
emailaddress,
stateflag,
(select accountID from peachtree_glaccounts where `type`='Income' and `description`='Sales' LIMIT 1) as GLAccount,
createtime
from guests
where
HOTELID = pHotelID AND
date(updatetime) = pExportDate OR
date(createtime) = pExportDate
order by createtime asc);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_getNonGuestReceipts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_getNonGuestReceipts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_getNonGuestReceipts`(pDate datetime, pPostToLedger varchar(1))
BEGIN
SELECT
now() as depositTicketID
, (select `value` from system_config where `key`='DEFAULT_WALK_IN_ACCOUNT') as accountID
, transactionId
, transactionDate
, nonguesttransaction.memo
, (select accountID from peachtree_accountmapping where nonguesttransaction.transactionCode = peachtree_accountmapping.transactionCode
and peachtree_accountmapping.mappingType='CASH') as cashAccount
, netAmount
, (select accountID from peachtree_accountmapping where nonguesttransaction.transactionCode = peachtree_accountmapping.transactionCode
and peachtree_accountmapping.mappingType='ACCOUNTS RECEIVABLE') as glAccount
FROM
nonguesttransaction
WHERE acctSide = 'CREDIT' AND nonguesttransaction.transactionCode != '6000' AND DATE(nonguesttransaction.transactionDate) = DATE(pDate)
AND nonguesttransaction.postedToLedger = pPostToLedger;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_getNonGuestTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_getNonGuestTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_getNonGuestTransactions`(pDate date, pPostToLedger varchar(1))
BEGIN
SELECT
transactionId
, (select `value` from system_config where `key`='DEFAULT_WALK_IN_ACCOUNT') as accountID
, transactionDate
, discount
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = nonguesttransaction.transactionCode
and mappingType = "ACCOUNTS RECEIVABLE") as transactionCode
, netAmount
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = nonguesttransaction.transactionCode
and mappingType = "SALES") as salesGLCode
, localTax
, governmentTax
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = nonguesttransaction.transactionCode
and mappingType = "SALES TAX PAYABLE") as taxGLCode
, memo
FROM
nonguesttransaction
WHERE acctSide = 'DEBIT' AND nonguesttransaction.transactionCode != '6000' AND DATE(nonguesttransaction.transactionDate) = DATE(pDate)
AND nonguesttransaction.postedToLedger = pPostToLedger;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_GetPTemplateFields` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_GetPTemplateFields` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_GetPTemplateFields`(
pTemplateID varchar(30)
)
BEGIN
select * from peachtree_templatefields
WHERE	
peachtree_templatefields.TemplateID = pTemplateID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_getRestoTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_getRestoTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPeachtree_getRestoTransactions`(pDate datetime, pPostToLedger varchar(1))
BEGIN
SELECT
foliotransactions.folioTransactionNo
, `order detail`.ID
, folio.accountID
, folio.companyID
, `order header`.CUSTOMER_ID as folioID
, `order header`.ORDER_DATE as transactionDate
, `order detail`.DISCOUNT as discount
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = '4100'
and mappingType = "ACCOUNTS RECEIVABLE") as transactionCode
, `order detail`.UNIT_PRICE as amount
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = foliotransactions.transactionCode
and mappingType = "SALES") as salesGLCode
, foliotransactions.governmentTax
, foliotransactions.localTax
, (select accountID from peachtree_accountmapping where peachtree_accountmapping.transactionCode = '1800'
and mappingType = "SALES TAX PAYABLE") as taxGLCode
, `order detail`.DESCRIPTION as memo
, `order detail`.ITEM_ID as itemID
, `order detail`.QUANTITY as quantity
FROM
pos.`order detail`
LEFT JOIN pos.`order header`
ON (`order detail`.ORDER_ID = `order header`.ORDER_ID)
LEFT JOIN foliotransactions
ON (foliotransactions.referenceNo = `order header`.ORDER_ID)
LEFT JOIN folio
ON (`order header`.CUSTOMER_ID = folio.folioID)
LEFT JOIN guests
ON (folio.accountID = guests.accountid)
WHERE acctSide = 'DEBIT' AND DATE(foliotransactions.transactionDate) = DATE(pDate)
AND foliotransactions.postToLedger = pPostToLedger
ORDER BY foliotransactions.folioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_insertAccountMapping` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_insertAccountMapping` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_insertAccountMapping`(pAccountID varchar(30), pTransactionCode varchar(20), pMappingType varchar(30), pUser varchar(30))
BEGIN
insert into peachtree_accountMapping(accountID, transactionCode, mappingType, createdBy, createdAt, updatedBy, updatedAt)
values (pAccountID, pTransactionCode, pMappingType, pUser, now(), pUser, now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_insertGLAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_insertGLAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_insertGLAccount`(pAccountID varchar(30), pDescription varchar(100), pType varchar(30), pUser varchar(30))
BEGIN
set @entry=0;
select count(*) into @entry from peachtree_glaccounts where accountID = pAccountID LIMIT 1;
if @entry = 0 then
insert into peachtree_glaccounts(accountID, description, `type`, createdBy, createdAt, updatedBy, updatedAt)
values(pAccountID, pDescription, pType, pUser, now(), pUser, now());
else
update peachtree_glaccounts set description=pDescription, `type`=pType, updatedBy=pUser, updatedAt=now();
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_insertTemplateFields` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_insertTemplateFields` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_insertTemplateFields`(pTemplate varchar(30), pField varchar(50), pDescription varchar(100), pUser varchar(30))
BEGIN
insert into peachtree_templatefields (TemplateID, `Name`, Description, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate)
values(pTemplate, pField, pDescription, pUser, now(), pUser, now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_insertTemplates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_insertTemplates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_insertTemplates`(pName varchar(30), pDescription varchar(50), pOutputExtension varchar(20), pUser varchar(30))
BEGIN
insert into peachtree_template (`Name`, `Description`, `OutputExtension`, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate)
values (pName, pDescription, pOutputExtension, pUser, now(), pUser, now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_ReportPostedAndUnpostedDailyHotelRevenue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_ReportPostedAndUnpostedDailyHotelRevenue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPeachtree_ReportPostedAndUnpostedDailyHotelRevenue`(
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
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`baseAmount`,
(foliotransactions.`baseAmount` * -1) ) as baseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as netBaseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`grossAmount`,
(foliotransactions.`grossAmount` * -1) ) as grossAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`discount`,
(foliotransactions.`discount` * -1) ) as discount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`serviceCharge`,
(foliotransactions.`serviceCharge` * -1) ) as serviceCharge,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`governmentTax`,
(foliotransactions.`governmentTax` * -1) ) as governmentTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`localTax`,
(foliotransactions.`localTax` * -1) ) as localTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`mealAmount`,
(foliotransactions.`mealAmount` * -1) ) as mealAmount,
foliotransactions.`Memo`,
foliotransactions.subFolio,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netAmount`,
(foliotransactions.`netAmount` * -1) ) as netAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as Amount,
foliotransactions.`CREATEDBY`,
if(substring(foliotransactions.`Memo`,-3,3) > 0,substring(foliotransactions.`Memo`,-3,3),folioschedules.roomid) as roomid,
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
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.baseAmount,
(nonguesttransaction.baseAmount * -1) ) as baseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netBaseAmount,
(nonguesttransaction.netBaseAmount * -1) ) as netBaseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.grossAmount,
(nonguesttransaction.grossAmount * -1) ) as grossAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.discount,
(nonguesttransaction.discount * -1) ) as discount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.serviceCharge,
(nonguesttransaction.serviceCharge * -1) ) as serviceCharge,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.governmentTax,
(nonguesttransaction.governmentTax * -1) ) as governmentTax,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.localTax,
(nonguesttransaction.localTax * -1) ) as localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netAmount,
(nonguesttransaction.netAmount * -1) ) as netAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netbaseAmount,
(nonguesttransaction.netbaseAmount * -1) ) as Amount,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
'' as roomtype,
nonguesttransaction.companyName,
'' as REMARKS
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
h.order_date,
h.order_date,
h.order_id,
'POSCHECK#' as TransactionSource,
h.customer_id,
concat(if(substring(h.customer_id,1,1) = 'F', 
pos.fGetHotelFolioAccountID(h.customer_id),h.customer_id),
if(h.employee_id = "","",
concat("E-",h.employee_id))) as customerID,
pos.fGetCustomerNamePerOrder(h.Customer_ID,
h.EMPLOYEE_ID) as GuestName,
(case g.maingroup_id
when 'FOOD' then
'1200'
when 'BEVERAGES' then
'1202'
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
'' as Remarks
from 
pos.`order detail` d
left join 
pos.`order header` h on d.Order_Id = h.Order_Id
left join pos.item i on i.Item_ID = d.Item_Id
left join pos.`group` g on g.group_id = i.group_id
left join pos.payment p on h.order_id = p.order_id
where
g.maingroup_id is not null
and date(p.payment_date) >= pStartDate 
and date(p.payment_date) <= pEndDate 
and p.`status` != 'VOID' 
and p.payment_type IN ('CASH','Credit','ACCOUNT_EMPLOYEE')
and d.operation_status!='CANCELLED'
group by
g.maingroup_id,
h.order_id
)
order by transactionCode, transactionSource, ReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_updateFieldTemplates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_updateFieldTemplates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_updateFieldTemplates`(pTemplateID int(5), pStatusFlag varchar(10), pUser varchar(30))
BEGIN
update peachtree_templatefields set statusflag=pStatusFlag, updatedBy=pUser, updatedDate=now() where ID=pTemplateID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPeachtree_updateTemplates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPeachtree_updateTemplates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spPeachtree_updateTemplates`(pTemplateID int(5), pGenerate tinyint(1), pUser varchar(30))
BEGIN
update peachtree_template set Generate=pGenerate, updatedBy=pUser, updatedDate=now() where ID=pTemplateID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostAP` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostAP` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostAP`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostAR` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostAR` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostAR`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostCallCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostCallCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostCallCharge`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostCallToTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostCallToTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostCallToTransactions`(in pfolioid int(4),
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostCityLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostCityLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostCityLedger`(
in pAcctID varchar(20), 
in prefno varchar(20), 
in pdebit varchar(20), 
in pcredit varchar(20), 
in preffolio varchar(200), 
in psubfolio varchar(50),
in pHOTELID int(5), 
in pCREATEDBY varchar(20),
in pAuditDate date
)
BEGIN
insert into cityledger (                          
`AcctID` ,
`Date` ,
`refno` ,
`debit` ,
`credit`,
`reffolio`,
`subfolio` ,
`HOTELID` ,
`CREATETIME`,
`CREATEDBY` ,
`UPDATETIME` ,
`UPDATEDBY` ,
`posttoacctng`,
`closed` )   values	
(
pAcctID,
pAuditDate,
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
'0',
'0'
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostComledger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostComledger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostComledger`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostCreditCardLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostCreditCardLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostCreditCardLedger`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostCS` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostCS` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostCS`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostDepledger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostDepledger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostDepledger`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostGroupPackage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostGroupPackage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostGroupPackage`(pFolioID varchar(30))
BEGIN
update event_booking_info set packagePosted=1 where folioid=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostRoomCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostRoomCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostRoomCharge`(
in ptrandate varchar(20),
in proomid varchar(10),
in preferenceno varchar(20),
in pamount double(13,2),
in ptrancode varchar(5)
)
BEGIN
insert into transactions(trandate,roomid,referenceno,amount,trancode)
values(ptrandate,proomid,preferenceno,pamount,ptrancode);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostSalesLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostSalesLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostSalesLedger`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spPostsrvchrgledger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spPostsrvchrgledger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spPostsrvchrgledger`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spQuickbooks_getGlAccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spQuickbooks_getGlAccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spQuickbooks_getGlAccounts`()
BEGIN
END */$$
DELIMITER ;

/* Procedure structure for procedure `spQuickbooks_getMappingList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spQuickbooks_getMappingList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spQuickbooks_getMappingList`()
BEGIN
END */$$
DELIMITER ;

/* Procedure structure for procedure `spQuickbooks_insertGLAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spQuickbooks_insertGLAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spQuickbooks_insertGLAccount`(pName varchar(30), pType varchar(30), pUser varchar(30))
BEGIN
END */$$
DELIMITER ;

/* Procedure structure for procedure `spQuickbooks_insertMapping` */

/*!50003 DROP PROCEDURE IF EXISTS  `spQuickbooks_insertMapping` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spQuickbooks_insertMapping`(pGlAccount varchar(10), pTransactionCode varchar(10), pMappingType varchar(10), pUser varchar(30))
BEGIN
END */$$
DELIMITER ;

/* Procedure structure for procedure `spRecallFolioTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spRecallFolioTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spRecallFolioTransaction`(
in pFolioTransactionNo int(20),
in pReferenceNo varchar(100),
in pUpdatedBy varchar(20)
)
BEGIN
update foliotransactions
set 
`status` = 'ACTIVE',
referenceNo = pReferenceNo,
updatedby = pUpdatedBy,
updatetime = now()
where
FolioTransactionNo = pFolioTransactionNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spRemoveFolioTransactionForTransfer` */

/*!50003 DROP PROCEDURE IF EXISTS  `spRemoveFolioTransactionForTransfer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spRemoveFolioTransactionForTransfer`(
in pTransactionCode varchar(20),
in pTranDate 	    date,
in pPostingDate 	    datetime,
in pFolioID          varchar(20),
in pSubFolio         varchar(1),
in pHotelID          int(5) 
)
BEGIN
delete from folioTransactions
where
transactioncode = pTransactionCode and
date(transactiondate) = pTranDate and
postingdate = pPostingdate and
folioid = pfolioid and
subfolio = pSubFolio and
hotelid = pHotelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spRemovePackage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spRemovePackage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spRemovePackage`(in pFolioID varchar(20), IN photelid int(5))
BEGIN
Update folio set `packageid`="" where folioID=pFolioID and hotelid=photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spRemoveUserRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `spRemoveUserRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spRemoveUserRole`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportAccount`(
pAccountID varchar(20),
pHotelID int
)
BEGIN
if locate('I',pAccountID) > 0 then
select concat(guests.lastname,', ',guests.firstname) as clientName, account_information.natureOfBusiness, concat(guests.street, ' ', guests.city, ' ', guests.country) as address, guests.TelephoneNo as telephone, guests.FaxNo as fax, guests.emailaddress as email, '' as website, account_information.affiliations, (select if(group_concat(distinct concat(contactpersons.lastName, ' ', contactpersons.firstName)) is null,'',group_concat(distinct concat(contactpersons.lastName, contactpersons.firstName))) from contactpersons where contactpersons.status = 'ACTIVE' and personType = 'Decision Maker' and contactpersons.accountID = guests.accountID) as decisionMaker, date_format(account_information.anniversary,'%M %e %Y') as anniversary, account_information.officeOfficers, account_information.pillarsOfOrganization, date_format(guests.createtime,'%M %e %Y') as clientSince from guests left join account_information on guests.accountID = account_information.accountID where guests.accountID = pAccountID and guests.hotelID = pHotelID;
else
select company.companyname as clientName, account_information.natureOfBusiness, concat(company.street1,' ',company.city1,' ',company.country1) as address, company.contactnumber1 as telephone, company.contactnumber2 as fax, company.email1 as email, company.companyURL as website, account_information.affiliations, (select if(group_concat(distinct concat(contactpersons.lastName, contactpersons.firstName)) is null,'',group_concat(distinct concat(contactpersons.lastName, contactpersons.firstName))) from contactpersons where contactpersons.status = 'ACTIVE' and personType = 'Decision Maker' and contactpersons.accountID = company.companyid) as decisionMaker, date_format(account_information.anniversary,'%M %e %Y') as anniversary, account_information.officeOfficers, account_information.pillarsOfOrganization, date_format(company.createtime,'%M %e %Y') as clientSince from company left join account_information on company.companyid = account_information.accountID where company.companyid = pAccountID and company.hotelID = pHotelID;
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAccountEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAccountEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportAccountEvent`(
pFolioID varchar(20),
pHotelID int,
pContigency varchar(20)
)
BEGIN
select date_format(fromDate,'%Y') as `year`, 
folio.groupName as title, event_booking_info.eventType, 
concat(date_format(fromdate,'%e-%b-%Y'),' to ', date_format(todate,'%e-%b-%Y')) as eventDate, 
(select group_concat(RoomID) from folioschedules where folioschedules.folioid = folio.folioid) as rooms, 
concat(users.LastName, ', ', users.FirstName) as mo,
if((select group_concat(concat(firstName,' ' ,lastName)) from contactpersons where folioId = folio.folioId and accountId = folio.companyId and personType = 'EventOfficer' and `status` = 'ACTIVE') is null,' ',(select group_concat(concat(firstName,' ' ,lastName)) from contactpersons where folioId = folio.folioId and accountId = folio.companyId and personType = 'EventOfficer' and `status` = 'ACTIVE')) as eo, 
if((select sum(netAmount) from foliotransactions where foliotransactions.folioID = folio.folioID and foliotransactions.hotelID = folioID and acctSide = 'DEBIT' and transactionCode <> pContigency) is null, 0, (select sum(netAmount) from foliotransactions where foliotransactions.folioID = folio.folioID and foliotransactions.hotelID = folioID and acctSide = 'DEBIT' and transactionCode <> pContigency)) as charges, 
event_endorsement.concessions, 
event_endorsement.giveaways, 
folio.remarks 
from folio left join event_booking_info on folio.folioID = event_booking_info.folioID left join event_endorsement on folio.folioID = event_endorsement.folioID left join users on folio.sales_Executive = users.userid where folio.folioID = pFolioID and folio.hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportActualGroupArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportActualGroupArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportActualGroupArrival`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select 
folio.folioid,
folio.companyid,
folio.accounttype,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as GuestName,
folioschedules.roomid, 
folioschedules.roomtype,
folio.arrivalDate,
folio.DepartureDate,
folio.noOfadults as Pax,
folio.remarks,
folioschedules.todate as departure,
folioschedules.fromdate as arrival,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyname,
fGetFolioBalance(folio.FolioId) as Balance,
rooms.floor
from
folioschedules left join rooms on rooms.roomid = folioschedules.roomid,
folio
where
folioschedules.folioid = folio.folioid and
date(folio.fromdate) = pAuditDate and
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid
order by folioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportActualGuestDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportActualGuestDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportActualGuestDeparture`(
in pHotelID int(5),
in pAuditDate date
)
BEGIN
select 
folio.folioid,
guests.accountid,
guests.account_type,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folio.remarks,
folioschedules.days,
folioschedules.roomid, folioschedules.roomtype,
folioschedules.fromdate,
date(folio.todate) as todate,
folio.arrivaldate,
folio.departuredate,
folio.noOfadults as Pax,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), folio.groupname) as companyname,
fGetFolioBalance(folio.FolioId) as Balance,
rooms.floor
from
guests,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid,
folio
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
date(folioschedules.todate) = pAuditDate and
folio.status = 'CLOSED' and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = pHotelID and folioschedules.roomtype!='FUNCTION';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportActualGuestsArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportActualGuestsArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportActualGuestsArrival`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select 
folio.folioid,
guests.accountid,
guests.account_type,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folioschedules.roomid, 
folioschedules.roomtype,
folio.arrivalDate,
folio.DepartureDate,
folio.noOfadults as Pax,
folio.remarks,
folioschedules.todate as departure,
folioschedules.fromdate as arrival,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), folio.groupname) as companyname,
fGetFolioBalance(folio.FolioId) as Balance,
rooms.floor
from
guests,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid,
folio
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
date(folioschedules.fromdate) = pAuditDate and
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid and folioschedules.roomtype!='FUNCTION'
order by guests.lastname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportActualGuestsDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportActualGuestsDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportActualGuestsDeparture`(
in photelid int(5),
in pAuditDate date
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
date(folio.departuredate) = pAuditDate and
folio.status = 'CLOSED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAdjustmentTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAdjustmentTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAdjustmentTransactions`()
BEGIN
(
select 
accountingadjustments.postingDate,
accountingadjustments.transactionDate,
accountingadjustments.referenceNo,
accountingadjustments.transactionSource as ReferenceType,
accountingadjustments.referenceFolioId as FolioId,
accountingadjustments.accountId,
accountingadjustments.guestName as GuestName,
if(accountingadjustments.statusFlag='VOID', 'VOID',accountingadjustments.transactioncode) as transactioncode,
if(accountingadjustments.statusFlag='VOID', 'VOIDED TRANSACTIONS', accountingadjustments.memo) as TransactionDescription,
accountingadjustments.baseAmount,
if(accountingadjustments.acctside='CREDIT' AND fGetTransactionCodeAcctSide(accountingadjustments.transactioncode)='DEBIT', 0-accountingadjustments.grossAmount,accountingadjustments.grossAmount) as grossAmount,
if(accountingadjustments.acctside='CREDIT' AND fGetTransactionCodeAcctSide(accountingadjustments.transactioncode)='DEBIT', 0-accountingadjustments.discount,accountingadjustments.discount) as discount,
if(accountingadjustments.acctside='CREDIT' AND fGetTransactionCodeAcctSide(accountingadjustments.transactioncode)='DEBIT', 0-accountingadjustments.servicecharge,accountingadjustments.servicecharge) as serviceCharge,
if(accountingadjustments.acctside='CREDIT' AND fGetTransactionCodeAcctSide(accountingadjustments.transactioncode)='DEBIT', 0-(accountingadjustments.governmentTax + 
accountingadjustments.localTax),accountingadjustments.governmentTax + 
accountingadjustments.localTax) as Tax,
0 as mealAmount,
accountingadjustments.memo,
"A " as subFolio,
if(accountingadjustments.AcctSide='DEBIT',accountingadjustments.netAmount,0.00) as DEBIT,
if(accountingadjustments.AcctSide='CREDIT',accountingadjustments.netAmount,0.00) as CREDIT,
accountingadjustments.CREATEDBY,
accountingadjustments.roomNumber as roomid,
"" as roomtype,
accountingadjustments.companyName,
fGetTransactionDescription(accountingadjustments.transactioncode) as description
from accountingadjustments force index(primary)
left join transactioncode on transactioncode.tranCode = accountingadjustments.transactioncode
)
order by transactioncode, ReferenceType, ReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAllCashierTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAllCashierTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAllCashierTransaction`(
in pAuditDate date,
in pHotelId int(5),
in filter varchar(20)
)
BEGIN
(select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
cashiers_logs.updatedby,
foliotransactions.transactionDate,
foliotransactions.referenceno,
concat((fGetCurrentRoomOccupied(foliotransactions.folioid, foliotransactions.hotelid, pAuditDate)),' ', if(substring(foliotransactions.accountid,1,1)='G',fGetCompanyName(foliotransactions.accountid), fGetGuestName(foliotransactions.accountid))) as TransactionSource,
foliotransactions.transactioncode,
foliotransactions.transactionsource as referenceSource,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
foliotransactions.folioid,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT
from 	
transactioncode,
cashiers_logs
left join foliotransactions on foliotransactions.terminalid = cashiers_logs.terminalid and foliotransactions.shiftcode = cashiers_logs.shiftcode
where
foliotransactions.transactioncode = transactioncode.trancode and 
if(filter <> "ALL",
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 8 or transactioncode.trantypeid = 7 or
transactioncode.trantypeid = 9 or transactioncode.trantypeid = 11) and
(foliotransactions.transactioncode !='3100' and foliotransactions.transactioncode !='3200'and foliotransactions.transactioncode !='2501'),
((transactioncode.trantypeid != 1) or ((transactioncode.trantypeid=1 or transactioncode.trantypeid = 11 or transactioncode.trantypeid=9 or transactioncode.trantypeid=7) and foliotransactions.status='VOID')) and
(foliotransactions.transactioncode !='3100' and foliotransactions.transactioncode !='3200'and foliotransactions.transactioncode !='2501' ))
and
cashiers_logs.hotelid = pHotelid and
cashiers_logs.transactiondate = pAuditDate and
date(foliotransactions.transactiondate) = pAuditDate and
cashiers_logs.type = 'CLOSE'
)
UNION(
select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
cashiers_logs.updatedby,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
if(nonguesttransaction.guestName="","WALK-IN",nonguesttransaction.guestName) as TransactionSource,
nonguesttransaction.transactionCode,
nonguesttransaction.transactionsource as referenceSource,
nonguesttransaction.memo,
nonguesttransaction.statusFlag as `status`,
nonguesttransaction.acctSide,
nonguesttransaction.referenceFolioId as folioId,
if(nonguesttransaction.acctside='DEBIT',nonguesttransaction.baseamount,0.00) as CHARGES,  
if(nonguesttransaction.acctside='CREDIT',nonguesttransaction.baseamount,0.00) as CREDIT
from cashiers_logs left join nonguesttransaction on (nonguesttransaction.terminalid = cashiers_logs.terminalid and nonguesttransaction.shiftcode = cashiers_logs.shiftcode) left join
transactioncode on nonguesttransaction.transactionCode = transactioncode.trancode
where
nonguesttransaction.transactionDate = pAuditDate and
nonguesttransaction.hotelID = pHotelId and
cashiers_logs.hotelid = pHotelid and
cashiers_logs.transactiondate = pAuditDate and
cashiers_logs.type = 'CLOSE' and
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 8 or transactioncode.trantypeid = 7 or
(transactioncode.trantypeid = 1 or 
transactioncode.trantypeid = 9 and nonguesttransaction.statusflag='VOID')) and
(nonguesttransaction.transactioncode !='3100' and nonguesttransaction.transactioncode !='3200'and nonguesttransaction.transactioncode !='2501' )
)
UNION
(
select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
cashiers_logs.updatedby,
cashiers_logs.transactionDate,
'' AS referenceno,
'' as TransactionSource,
'' AS transactioncode,
'' as referenceSource,
'' AS memo,
'ACTIVE' AS `status`,
'' AS acctside,
'' AS folioid,
0.00 as CHARGES,  
0.00 as CREDIT
from 	
cashiers_logs
where
cashiers_logs.hotelid = pHotelid and
date(cashiers_logs.transactiondate) = pAuditDate and
cashiers_logs.type = 'CLOSE'
order by transactiondate
)
order by transactiondate, referenceSource, referenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAllCashierTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAllCashierTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAllCashierTransactions`(
in pterminalid int(4),
in pHotelId int(5),
in pAuditDate date
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
foliotransactions.transactionsource as referenceSource,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT,
fGetTransactionDescription(foliotransactions.transactioncode) as description
from 	cashiers,
foliotransactions
where
cashiers.terminalid = foliotransactions.terminalid and
foliotransactions.terminalid = pterminalid and date(foliotransactions.transactiondate) = pAuditDate and
foliotransactions.hotelid = cashiers.hotelid and
cashiers.hotelid = pHotelId and
(date(foliotransactions.postingdate)=pAuditDate or (date(foliotransactions.postingdate)=date_add(pAuditDate, interval -1 day) and foliotransactions.transactionDate=pAuditDate))
order by transactiondate, referenceSource, referenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAllCashierTransaction_Orig` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAllCashierTransaction_Orig` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAllCashierTransaction_Orig`(
in pAuditDate date,
in pHotelId int(5),
in filter varchar(20)
)
BEGIN
(select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
cashiers_logs.updatedby,
foliotransactions.transactionDate,
foliotransactions.referenceno,
concat((select roomid from folioschedules where folioid=foliotransactions.folioid limit 1),'  ',guests.lastname,', ',guests.firstname) as TransactionSource,
foliotransactions.transactioncode,
foliotransactions.transactionsource as referenceSource,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
foliotransactions.folioid,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT
from 	
transactioncode,
cashiers_logs
left join foliotransactions on foliotransactions.terminalid = cashiers_logs.terminalid and foliotransactions.shiftcode = cashiers_logs.shiftcode
left join guests on guests.accountid = foliotransactions.accountid
where
foliotransactions.transactioncode = transactioncode.trancode and 
if(filter <> "ALL",
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 8) and
(foliotransactions.transactioncode !='3100' and foliotransactions.transactioncode !='3200'and foliotransactions.transactioncode !='4200' and foliotransactions.transactioncode !='2501'),
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 8) and
(foliotransactions.transactioncode !='3100' and foliotransactions.transactioncode !='3200'and foliotransactions.transactioncode !='4200' and foliotransactions.transactioncode !='2501' ))
and
cashiers_logs.hotelid = pHotelid and
cashiers_logs.transactiondate = pAuditDate and
date(foliotransactions.transactiondate) = pAuditDate and
cashiers_logs.type = 'CLOSE'
)
UNION(
select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
cashiers_logs.updatedby,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
if(nonguesttransaction.guestName="","WALK-IN",nonguesttransaction.guestName) as TransactionSource,
nonguesttransaction.transactionCode,
nonguesttransaction.transactionsource as referenceSource,
nonguesttransaction.memo,
nonguesttransaction.statusFlag as `status`,
nonguesttransaction.acctSide,
nonguesttransaction.referenceFolioId as folioId,
if(nonguesttransaction.acctside='DEBIT',nonguesttransaction.baseamount,0.00) as CHARGES,  
if(nonguesttransaction.acctside='CREDIT',nonguesttransaction.baseamount,0.00) as CREDIT
from cashiers_logs left join nonguesttransaction on (nonguesttransaction.terminalid = cashiers_logs.terminalid and nonguesttransaction.shiftcode = cashiers_logs.shiftcode) left join
transactioncode on nonguesttransaction.transactionCode = transactioncode.trancode
where
nonguesttransaction.transactionDate = pAuditDate and
nonguesttransaction.hotelID = pHotelId and
cashiers_logs.hotelid = pHotelid and
cashiers_logs.transactiondate = pAuditDate and
cashiers_logs.type = 'CLOSE' and
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 8) and
(nonguesttransaction.transactioncode !='3100' and nonguesttransaction.transactioncode !='3200'and nonguesttransaction.transactioncode !='4200' and nonguesttransaction.transactioncode !='2501' )
)
order by transactiondate, referenceSource, referenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAllCashierVoidTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAllCashierVoidTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAllCashierVoidTransaction`(
in pAuditDate date,
in pHotelId int(5),
in filter varchar(20)
)
BEGIN
(select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
cashiers_logs.updatedby,
foliotransactions.transactionDate,
foliotransactions.referenceno,
concat((fGetCurrentRoomOccupied(foliotransactions.folioid, foliotransactions.hotelid, pAuditDate)),' ', if(substring(foliotransactions.accountid,1,1)='G',fGetCompanyName(foliotransactions.accountid), fGetGuestName(foliotransactions.accountid))) as TransactionSource,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
foliotransactions.folioid,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT
from 	
transactioncode,
cashiers_logs
left join foliotransactions on foliotransactions.terminalid = cashiers_logs.terminalid and foliotransactions.shiftcode = cashiers_logs.shiftcode
left join folioschedules on folioschedules.folioid = foliotransactions.folioid
left join guests on guests.accountid = foliotransactions.accountid
where
foliotransactions.transactioncode = transactioncode.trancode and 
if(filter <> "ALL",
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 8) and
(foliotransactions.transactioncode !='3100' and foliotransactions.transactioncode !='3200'and foliotransactions.transactioncode !='4200' and foliotransactions.transactioncode !='2501'),
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 8) and
(foliotransactions.transactioncode !='3100' and foliotransactions.transactioncode !='3200'and foliotransactions.transactioncode !='4200' and foliotransactions.transactioncode !='2501' ))
and
cashiers_logs.hotelid = pHotelid and
cashiers_logs.transactiondate = pAuditDate and
date(foliotransactions.transactiondate) = pAuditDate and
cashiers_logs.type = 'CLOSE' and
foliotransactions.status = 'VOID'
order by transactiondate
)
UNION(
select
nonguesttransaction.terminalID as Terminal,
nonguesttransaction.terminalID as cashierId,
nonguesttransaction.shiftCode,
0 as openingbalance,
0 as openingadjustment,
0 as beginningbalance,
0 as chargeinamount,
0 as cash,
0 as creditcard,
0 as cheque,	
0 as others,
"" as remarks,
nonguesttransaction.UPDATEDBY,
0 as adjustment,
0 as netamount,
0 as amountremitted,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
if(nonguesttransaction.guestName="","WALK-IN",nonguesttransaction.guestName) as TransactionSource,
nonguesttransaction.transactionCode,
nonguesttransaction.memo,
nonguesttransaction.statusFlag as `status`,
nonguesttransaction.acctSide,
nonguesttransaction.referenceFolioId as folioId,
if(nonguesttransaction.acctside='DEBIT',nonguesttransaction.baseamount,0.00) as CHARGES,  
if(nonguesttransaction.acctside='CREDIT',nonguesttransaction.baseamount,0.00) as CREDIT
from nonguesttransaction left join
transactioncode on nonguesttransaction.transactionCode = transactioncode.trancode
where
nonguesttransaction.transactionDate = pAuditDate and
nonguesttransaction.hotelID = pHotelId and
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 8) and
(nonguesttransaction.transactioncode !='3100' and nonguesttransaction.transactioncode !='3200'and nonguesttransaction.transactioncode !='4200' and nonguesttransaction.transactioncode !='2501' )
and nonguesttransaction.statusFlag = 'VOID'
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAllHousekeepingJobs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAllHousekeepingJobs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAllHousekeepingJobs`(
in photelid int(5)
)
BEGIN
select 
hk_housekeepingjobs.roomid,
hk_housekeepingjobs.housekeepingdate,
hk_housekeepingjobs.starttime,
hk_housekeepingjobs.endtime,
hk_housekeepingjobs.elapsedtime,
concat(hk_housekeepers.lastname,", ",hk_housekeepers.firstname) as Housekeeper,
hk_housekeepingjobs.updatedby,
hk_housekeepingjobs.remarks as memo
from
hk_housekeepingjobs,
hk_housekeepers
where
hk_housekeepers.housekeeperid = hk_housekeepingjobs.housekeeperid and
hk_housekeepingjobs.hotelid = hk_housekeepers.hotelid and
hk_housekeepingjobs.hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAllIndividualFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAllIndividualFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAllIndividualFolio`(
in photelid int(5),
in pAuditDate date
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
date(folioschedules.fromdate) <= pAuditDate and
foliotransactions.folioid = folio.folioid and
foliotransactions.status = 'ACTIVE' and
folio.hotelid = photelid 
order by foliotransactions.transactiondate
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualActualGuestsArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualActualGuestsArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualActualGuestsArrival`(
in photelid int(5),
in pYear int
)
BEGIN
select 
folio.folioid,
guests.accountid,
guests.account_type,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folioschedules.roomid, 
folioschedules.roomtype,
folio.arrivalDate,
folio.DepartureDate,
folio.noOfadults as Pax,
folio.remarks,
folioschedules.todate as departure,
folioschedules.fromdate as arrival,
company.companyname,
fGetFolioBalance(folio.FolioId) as Balance,
rooms.floor
from
guests,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid,
folio left join company on company.companyid = folio.companyid
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
year(folio.arrivaldate) = pYear and
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid and folioschedules.roomtype!='FUNCTION'
order by guests.lastname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualActualGuestsDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualActualGuestsDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualActualGuestsDeparture`(
in photelid int(5),
in pYear int(4)
)
BEGIN
select 
folio.folioid,
guests.accountid,
guests.account_type,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folio.remarks,
folioschedules.days,
folioschedules.roomid, folioschedules.roomtype,
folioschedules.fromdate,
date(folio.todate) as todate,
folio.arrivaldate,
folio.departuredate,
folio.noOfadults as Pax,
company.companyname,
fGetFolioBalance(folio.FolioId) as Balance,
rooms.floor
from
guests,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid,
folio
left join company on company.companyid = folio.companyid
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
( year(folioschedules.todate) = pYear ) and
folio.status = 'CLOSED' and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid AND folioschedules.roomtype!='FUNCTION';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualCancelledReservations` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualCancelledReservations` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualCancelledReservations`(
in pHotelID int(5),
in pYear int(4)
)
BEGIN
select 
folio.folioid,
if(folio.foliotype!='GROUP', folio.accountid, folio.companyid) as accountid,
if(folio.foliotype!='GROUP', fGetGuestName(folio.accountid), concat(folio.groupname, ' (', (if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid))), ')')) as GuestName,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.roomid) as roomid, 
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.roomtype) as roomtype,
folio.remarks,
folio.noofadults,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.days) as days,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.rate) as rate,
folio.fromdate,
folio.todate as departure,
folio.reason_for_cancel,
folio.updatetime
from
folio left join folioschedules on (folioschedules.folioid = folio.folioid)
where
( year(folio.updatetime) = pYear ) and
(folio.status = 'CANCELLED' or folio.status='NO SHOW') and
folio.hotelid = photelid and foliotype!='DEPENDENT' AND foliotype!='JOINER';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualCashierTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualCashierTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualCashierTransactions`(
in pHotelId int(5),
in pYear int
)
BEGIN
set sql_big_selects = 1;
(
select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
cashiers_logs.updatedby,
foliotransactions.transactionDate,
foliotransactions.referenceno,
concat(folioschedules.roomid,'  ',guests.lastname,', ',guests.firstname) as TransactionSource,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT
from 	
transactioncode force index(primary),
cashiers_logs force index(primary)
left join foliotransactions force index(primary) on foliotransactions.terminalid = cashiers_logs.terminalid and foliotransactions.shiftcode = cashiers_logs.shiftcode
left join folioschedules force index(primary) on folioschedules.folioid = foliotransactions.folioid
left join guests force index(primary) on guests.accountid = foliotransactions.accountid
where
foliotransactions.transactioncode = transactioncode.trancode and 
cashiers_logs.hotelid = pHotelid and
year(foliotransactions.transactionDate) = pYear and
cashiers_logs.type = 'CLOSE'
order by transactiondate
)
UNION(
select
nonguesttransaction.terminalID as Terminal,
nonguesttransaction.terminalID as cashierId,
nonguesttransaction.shiftCode,
0 as openingbalance,
0 as openingadjustment,
0 as beginningbalance,
0 as chargeinamount,
0 as cash,
0 as creditcard,
0 as cheque,	
0 as others,
"" as remarks,
0 as adjustment,
0 as netamount,
0 as amountremitted,
nonguesttransaction.updatedby,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
if(nonguesttransaction.guestName="","WALK-IN",nonguesttransaction.guestName) as TransactionSource,
nonguesttransaction.transactionCode,
nonguesttransaction.memo,
nonguesttransaction.statusFlag as `status`,
nonguesttransaction.acctSide,
if(nonguesttransaction.acctside='DEBIT',nonguesttransaction.baseamount,0.00) as CHARGES,  
if(nonguesttransaction.acctside='CREDIT',nonguesttransaction.baseamount,0.00) as CREDIT
from nonguesttransaction force index(primary)
where
nonguesttransaction.hotelID = pHotelId and
year(nonguesttransaction.transactionDate) = pYear
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualCityTransferTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualCityTransferTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualCityTransferTransactions`(
in pHotelId int(4),
in pYear int
)
BEGIN
select 
(select roomid from folioschedules where folioid=folio.folioid limit 1) as roomid,
foliotransactions.folioid,
foliotransactions.accountid,
fGetGuestName(folio.accountid) as guestname,
folio.companyid,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyname,
foliotransactions.postingdate,
foliotransactions.baseamount,
foliotransactions.updatedby
from foliotransactions left join folio on folio.folioid = foliotransactions.folioid
where foliotransactions.transactioncode='4200' and
year(foliotransactions.transactiondate) = pYear and 
foliotransactions.hotelid = pHotelId
union select roomNumber as roomID,
referenceFolioID as folioID,
accountID,
guestName,
accountID as companyID,
companyName,
postingdate,
baseamount,
updatedby
from nonguesttransaction
where transactioncode ='4200' and
year(transactiondate) = pYear and 
hotelid = pHotelId and
statusflag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualDriversSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualDriversSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualDriversSales`(pYear int, pHotelid int)
BEGIN
select drivers.*, netAmount as commission, transactiondate, referenceNo, referenceFolioId, accountId, roomNumber, guestName  from drivers, nonguesttransaction where referencedriverid=driverid and nonguesttransaction.hotelid=pHotelid and year(transactiondate) = pYear and statusflag!='VOID' order by lastname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualExpectedGuestsArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualExpectedGuestsArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualExpectedGuestsArrival`(
in photelid int(5),
in pYear int(4)
)
BEGIN
select 
concat(guests.lastname, " , ", guests.firstname) as GuestName,
guests.memo,
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.todate as departure,
FOLIO.remarks,
folioschedules.fromdate as arrival,
company.companyname,
(folio.noofadults + folio.noofchild) as pax,
rooms.floor
from 
guests,
folio left join company on company.companyid = folio.companyid,
folioschedules  left join rooms on folioschedules.roomid=rooms.roomid
where 
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW' and
folio.status != 'ONGOING' and
folio.status != 'CLOSED') and
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and 
( year(folioschedules.fromdate) = pYear) and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid
order by folioschedules.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualExpectedGuestsDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualExpectedGuestsDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualExpectedGuestsDeparture`(
in photelid int(5),
in pYear int(4)
)
BEGIN
select 
folio.folioid,
concat(guests.firstname,"  ",guests.lastname) as GuestName,
folioschedules.roomid,
folioschedules.roomtype,
folio.remarks,
rooms.floor
from 
guests,
folio,
folioschedules left join rooms on folioschedules.roomid=rooms.roomid
where 
folio.status != 'CANCELLED' and
folio.status != 'NO SHOW' and
guests.accountid = folio.accountid and
folio.folioid = folioschedules.folioid  and 
folio.status = 'ONGOING' and
( year(folioschedules.todate) = pYear )
and
folio.hotelid = guests.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = pHotelID
order by guests.lastname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualMarketSegment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualMarketSegment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualMarketSegment`(pYear int(5))
BEGIN
SELECT MarketSegment, CurrentMonth, CurrentYear, ROOMTYPE, SUM(NOOFEVENTS) as NoOfEvents, SUM(TOTALREVENUE) as TotalRevenue FROM
(select
folio.folioid,
folio.purpose as MarketSegment,
monthname(folioschedules.fromDate) as CurrentMonth,
year(folioschedules.fromdate) as CurrentYear,
(select group_concat(distinct if(roomtypecode <> 'PICC FORUM','MAIN COMPLEX',roomtypecode)) 
		from folioschedules 
		left join rooms on folioschedules.roomid = rooms.roomid 
		where folioId = folio.folioId) as RoomType,
count(distinct folioschedules.folioid) as `NoOfEvents`,
if (month(folioschedules.fromdate)>=month(now()),
COALESCE((select sum(amount * (datediff(todate, fromdate) + 1)) from foliorecurringcharge where foliorecurringcharge.folioid=folioschedules.folioid and foliorecurringcharge.roomid=roomid), 0),
COALESCE((select sum(grossAmount) from foliotransactions where folioschedules.folioid=foliotransactions.folioid and acctSide='DEBIT' and foliotransactions.roomid=roomid), 0)) as TotalRevenue
from
folio,
folioschedules,
rooms
where folioschedules.roomid=rooms.roomid
and pYear between year(folioschedules.fromdate) and year(folioschedules.todate) and folio.folioid=folioschedules.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW'
group by folioid, marketsegment, roomtypecode
order by month(folioschedules.fromdate)) T
GROUP BY MarketSegment, ROOMTYPE, CURRENTMONTH, CURRENTYEAR;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualMealAmount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualMealAmount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualMealAmount`(
in pYear int(5),
in pHotelId int(5)
)
BEGIN
select 
date(foliotransactions.transactiondate) as transactiondate,
'1002' as transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.mealAmount * -1, foliotransactions.mealAmount)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
year(foliotransactions.transactiondate) = pYear and
foliotransactions.status = 'ACTIVE' and foliotransactions.transactioncode='1000'
group by foliotransactions.transactioncode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualNoOfEventsAndRevenue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualNoOfEventsAndRevenue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualNoOfEventsAndRevenue`(pYear int)
BEGIN
SELECT CurrentMonth, CurrentYear, ROOMTYPE, SUM(NOOFEVENTS) as NoOfEvents, SUM(TOTALREVENUE) as TotalRevenue FROM
(select
folio.folioid,
monthname(folioschedules.fromDate) as CurrentMonth,
year(folioschedules.fromdate) as CurrentYear,
roomtypecode as RoomType,
count(distinct folioschedules.folioid) as `NoOfEvents`,
if (month(folioschedules.fromdate)>=month(now()),
COALESCE((select sum(amount * (datediff(todate, fromdate) + 1)) from foliorecurringcharge where foliorecurringcharge.folioid=folioschedules.folioid and foliorecurringcharge.roomid=roomid), 0),
COALESCE((select sum(grossAmount) from foliotransactions where folioschedules.folioid=foliotransactions.folioid and acctSide='DEBIT' and foliotransactions.roomid=roomid), 0)) as TotalRevenue
from
folio,
folioschedules,
rooms
where folioschedules.roomid=rooms.roomid
and (pYear between year(folioschedules.fromdate) and year(folioschedules.todate) or pYear - 1 between year(folioschedules.fromdate) and year(folioschedules.todate)) and folio.folioid=folioschedules.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW'
group by folioid, roomtypecode
order by month(folioschedules.fromdate)) T
GROUP BY ROOMTYPE, CURRENTMONTH, CURRENTYEAR;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualOutOfOrderRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualOutOfOrderRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualOutOfOrderRooms`(
in pHotelId int(5),
in pYear int(4)
)
BEGIN
select distinct
roomevents.eventdate,
roomevents.roomid,
engineeringjobs.assignedperson,
engineeringjobs.startdate,
engineeringjobs.starttime,
engineeringjobs.enddate,
engineeringjobs.endtime,
engineeringservices.servicename
from 
roomevents left join
engineeringjobs on engineeringjobs.roomid = roomevents.roomid
left join engineeringservices on 
engineeringservices.enggserviceid = engineeringjobs.enggserviceid
where 
eventtype = 'ENGINEERING JOB' and
(year(eventdate) = pYear) and 
roomevents.hotelid = pHotelId
order by eventdate,roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualRoomOccupancyGraph` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualRoomOccupancyGraph` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualRoomOccupancyGraph`(
in pHotelId int(4),
in pYear int(4)
)
BEGIN
select roomevents.eventdate,((count(distinct roomevents.roomid)/FGetTotalRooms()) * 100) as Occupancy ,roomevents.eventtype from roomevents
where (roomevents.eventtype = "IN HOUSE" or roomevents.eventtype = "RESERVATION" or roomevents.eventtype = "CHECK OUT") and
year(roomevents.eventdate) = pYear
group by roomevents.eventdate,roomevents.eventtype
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualSales`(
in pHotelid int(5),
in pYear int(4)
)
BEGIN
(
select
foliotransactions.transactiondate,
foliotransactions.folioid,
foliotransactions.referenceno, 
foliotransactions.netamount,
foliotransactions.updatetime,
foliotransactions.transactionsource,
folioschedules.updatedby,
folioschedules.roomid,
concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE,
concat(guests.lastname,", ",guests.firstname) as GuestName
from 	foliotransactions
left join guests on guests.accountid = foliotransactions.accountid,
folioschedules,
transactioncode,
trantypes 
where 	
folioschedules.folioid = foliotransactions.folioid and
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
trantypes.trantypeid = '1' and
( Year(transactiondate) = pYear) and
folioschedules.hotelid = foliotransactions.hotelid and
transactioncode.hotelid = foliotransactions.hotelid and
trantypes.hotelid = foliotransactions.hotelid and
foliotransactions.hotelid = photelid and
foliotransactions.status = 'ACTIVE'
order by transactiondate
)
UNION
(
select
nonguesttransaction.transactiondate,
nonguesttransaction.referenceFolioId as folioid,
nonguesttransaction.referenceNo, 
nonguesttransaction.netamount,
nonguesttransaction.updatedDate as updateTime,
nonguesttransaction.transactionSource,
nonguesttransaction.updatedby,
nonguesttransaction.roomNumber as roomid,
concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE,
nonguesttransaction.guestName as GuestName
from 
nonguesttransaction force index(primary)
left join transactioncode on transactioncode.trancode = nonguesttransaction.transactionCode 
left join trantypes on transactioncode.trantypeid = trantypes.trantypeid
where 
nonguesttransaction.acctSide = 'DEBIT' and
trantypes.trantypeid = '1' and
( Year(transactionDate) = pYear ) and
nonguesttransaction.hotelid = pHotelid and
nonguesttransaction.statusflag = 'ACTIVE'
order by transactiondate
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualSalesExecutive` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualSalesExecutive` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualSalesExecutive`(pYear int, pHotelID int(2), pSalesExecutive varchar(30))
BEGIN
if(pSalesExecutive!='ALL') then
select 
(fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'DEBIT', folioid) +
fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'DEBIT', folioid)) -
(fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('7', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'CREDIT', folioid)) as totalSales,sales_executive, folioid, if(foliotype='GROUP', concat(if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)), ' [', folio.groupname, ']'), concat(fGetGuestName(folio.accountid), ' [', folio.groupname, ']')) as companyName, 
source, arrivalDate as arrival, departureDate as departure from folio where sales_executive=pSalesExecutive and folio.status='CLOSED' and folio.foliotype!='JOINER' and 
year(departureDate)=pYear
order by totalSales desc, sales_executive;
else
select 
(fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'DEBIT', folioid) +
fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'DEBIT', folioid)) -
(fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('7', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'CREDIT', folioid)) as totalSales,sales_executive, folioid, if(foliotype='GROUP', concat(if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)), ' [', folio.groupname, ']'), concat(fGetGuestName(folio.accountid), ' [', folio.groupname, ']')) as companyName, 
source, arrivalDate as arrival, departureDate as departure from folio where folio.status='CLOSED' and folio.foliotype!='JOINER' and 
year(departureDate)=pYear order by totalSales, sales_executive desc;
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualSalesProduction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualSalesProduction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualSalesProduction`(pYear int(5), pHotelID int(5))
BEGIN
select date_format(fromdate, '%d-%b-%Y') as fromDate, date_format(todate, '%d-%b-%Y') as toDate, folio.folioid, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName, groupname, eventType, (fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'DEBIT', folio.folioid) +
fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'DEBIT', folio.folioid)) -
(fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'CREDIT', folio.folioid) +
fGetTotalFolioAmountForSalesExecutive('7', pHotelID, 'A', 'CREDIT', folio.folioid) +
fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'CREDIT', folio.folioid)) as packageAmount, if(folio.status='CANCELLED', 'LOST/UNREALIZED', if(folio.status='CLOSED' or folio.status='ONGOING', 'REALIZED', folio.status)) as `status`, reason_for_cancel as reason
from folio left join event_booking_info on (folio.folioid=event_booking_info.folioid) where foliotype='GROUP' and year(fromdate)=pYear and folio.hotelid=pHotelId
order by `status`, fromdate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualSalesSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualSalesSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualSalesSummary`(
in pHotelid int(5),
in pYear int
)
BEGIN
(
select transactioncode, sum(baseamount) as BaseAmount, sum(grossAmount) as GrossAmount, sum(netAmount) as NetAmount, sum(netbaseamount) as NetBaseAmount, sum(discount) as Discount, sum(govttax) as GovtTax, sum(mealamount) as MealAmount, sum(localtax) as LocalTax, sum(servicecharge) as ServiceCharge, sum(transactioncount) as TransactionCount, TransactionDescription, acctside, sum(monthtodate) as MonthToDate, sum(yeartodate) as YearToDate from
(select 
foliotransactions.transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.baseAmount * -1, foliotransactions.baseAmount)) as BaseAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as GrossAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netAmount * -1, foliotransactions.netAmount)) as NetAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netBaseAmount * -1, foliotransactions.netBaseAmount)) as NetBaseAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.discount * -1, foliotransactions.discount)) as Discount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.governmentTax * -1, foliotransactions.governmentTax)) as GovtTax,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.mealAmount * -1, foliotransactions.mealAmount)) as MealAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.localtax * -1, foliotransactions.localtax)) as LocalTax,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.servicecharge * -1, foliotransactions.servicecharge)) as ServiceCharge,
count(foliotransactions.transactioncode) as TransactionCount,
transactioncode.memo as TransactionDescription,
transactioncode.acctside,
fGetTransactionNetBaseAmountMonthToDate(
foliotransactions.transactioncode,
foliotransactions.acctside,
transactiondate,
pHotelId
) as MonthToDate,
fGetTransactionNetBaseAmountYearToDate(
foliotransactions.transactioncode,
foliotransactions.acctside,
transactiondate,
pHotelId
) as YearToDate
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary),
trantypes  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
year(transactiondate) = pYear and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactioncode, foliotransactions.acctside
UNION all
select 
nonguesttransaction.transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.baseAmount * -1, nonguesttransaction.baseAmount)) as BaseAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.grossAmount * -1, nonguesttransaction.grossAmount)) as GrossAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netAmount * -1, nonguesttransaction.netAmount)) as NetAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netBaseAmount * -1, nonguesttransaction.netBaseAmount)) as NetBaseAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.discount * -1, nonguesttransaction.discount)) as Discount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.governmentTax * -1, nonguesttransaction.governmentTax)) as GovtTax,
0 as MealAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.localtax * -1, nonguesttransaction.localtax)) as LocalTax,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.servicecharge * -1, nonguesttransaction.servicecharge)) as ServiceCharge,
count(nonguesttransaction.transactioncode) as TransactionCount,
concat(transactioncode.memo, "-WALK IN") as TransactionDescription,
nonguesttransaction.acctside,
fGetNonGuestTransactionNetBaseAmountMonthToDate(
nonguesttransaction.transactioncode,
nonguesttransaction.acctside,
transactiondate,
pHotelId
)  as MonthToDate,
fGetNonGuestTransactionNetBaseAmountYearToDate(
nonguesttransaction.transactioncode,
transactioncode.acctside,
transactiondate,
pHotelId
)  as YearToDate
from
nonguesttransaction  force index(primary),
transactioncode force index(primary)
where 
year(transactiondate) = pYear and
nonguesttransaction.statusFlag = 'ACTIVE' and
nonguesttransaction.transactioncode=transactioncode.trancode
group by nonguesttransaction.transactioncode,nonguesttransaction.acctside) as transactionTable group by transactioncode
order by transactioncode asc, acctside desc
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualSalesSummaryBySubAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualSalesSummaryBySubAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualSalesSummaryBySubAccount`(
in pHotelid int(5),
in pYear int
)
BEGIN
(
select 
foliotransactions.subaccount,
if(foliotransactions.acctside = "DEBIT",
SUM(foliotransactions.baseamount),0) as DEBIT,
if(foliotransactions.acctside = "CREDIT",
SUM(foliotransactions.baseamount),0) as CREDIT,
count(foliotransactions.transactioncode) as Trans,
concat(transactioncode.trancode," - ",transactioncode.memo) as TRANCODE,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary),
trantypes  force index(primary)
where 	
foliotransactions.subaccount != "" and
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
year(transactiondate) = pYear
group by foliotransactions.subaccount, foliotransactions.acctside
order by foliotransactions.subaccount asc, foliotransactions.acctside desc
)
UNION
(
select
nonguesttransaction.subaccount,
if(nonguesttransaction.acctside = "DEBIT",
SUM(nonguesttransaction.baseamount),0) as DEBIT,
if(nonguesttransaction.acctside = "CREDIT",
SUM(nonguesttransaction.baseamount),0) as CREDIT,
count(nonguesttransaction.transactioncode) as Trans,
concat(nonguesttransaction.transactionCode," - ",nonguesttransaction.memo, " - WALK IN") as TRANCODE,
nonguesttransaction.acctside
from
nonguesttransaction  force index(primary)
where 
nonguesttransaction.subaccount != ""  and
year(transactiondate) = pYear
group by nonguesttransaction.subaccount,nonguesttransaction.acctside
order by nonguesttransaction.subaccount asc, nonguesttransaction.acctside desc
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualTransactionRegister` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualTransactionRegister` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualTransactionRegister`(
pHotelId int(4),
pYear int(4)
)
BEGIN
(
select
foliotransactions.postingDate,
foliotransactions.transactiondate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource` as ReferenceType,
foliotransactions.`FolioID`,
guests.accountid,
concat(guests.`lastname`,", " , guests.`firstname`) as GuestName,
foliotransactions.transactioncode,
foliotransactions.`Memo`,
if(AcctSide='DEBIT',foliotransactions.`netbaseamount`,0.00) as DEBIT,
if(AcctSide='CREDIT',foliotransactions.`netbaseamount`,0.00) as CREDIT,
foliotransactions.`CREATEDBY`,
(select roomid from folioschedules where folioid=foliotransactions.folioid limit 1) as roomid,
(select roomtype from folioschedules where folioid=foliotransactions.folioid limit 1) as roomtype,
if(foliotype="DEPENDENT", folio.groupname, company.companyName) as companyName,
fGetTransactionDescription(foliotransactions.transactioncode) as description
from
foliotransactions
left join folio on foliotransactions.folioid = folio.folioid
left join company on folio.companyid = company.companyid,
`guests`
where
foliotransactions.`AccountID`=guests.`accountid`
and 
(year(foliotransactions.`TransactionDate`) = pYear ) and
foliotransactions.Status='ACTIVE'
order by folioschedules.roomid
)
UNION
(
select 
nonguesttransaction.postingDate,
nonguesttransaction.transactiondate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource as ReferenceType,
nonguesttransaction.referenceFolioId as `FolioID`,
nonguesttransaction.accountId,
nonguesttransaction.guestName as GuestName,
nonguesttransaction.transactioncode,
nonguesttransaction.`Memo`,
if(AcctSide='DEBIT',nonguesttransaction.netamount,0.00) as DEBIT,
if(AcctSide='CREDIT',nonguesttransaction.netamount,0.00) as CREDIT,
nonguesttransaction.`CREATEDBY`,
nonguesttransaction.roomNumber as roomid,
"" as roomtype,
nonguesttransaction.companyName,
fGetTransactionDescription(nonguesttransaction.transactioncode) as description
from
nonguesttransaction force index(primary)
where
year(nonguesttransaction.transactionDate) = pYear 
order by nonguesttransaction.roomNumber
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualTransactions`(
in photelid int(5),
in pYear int(4)
)
BEGIN
select 	
foliotransactions.*,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT,
folioschedules.roomid,
concat(guests.lastname,", ",guests.firstname) as GuestName
from foliotransactions 
left join folioschedules on foliotransactions.folioid = folioschedules.folioid
left join guests on guests.accountid = foliotransactions.accountid
where
YEAR(transactiondate) = pYear and
foliotransactions.hotelid = photelid
order by `status`,transactiondate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportAnnualVoidTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportAnnualVoidTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportAnnualVoidTransactions`(
in pHotelId int(4),
in pYear int(4)
)
BEGIN
(
select
foliotransactions.postingDate,
foliotransactions.transactiondate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource` as ReferenceType,
foliotransactions.`FolioID`,
concat(guests.`lastname`,", " , guests.`firstname`) as GuestName,
foliotransactions.transactioncode,
foliotransactions.`Memo`,
if(AcctSide='DEBIT',foliotransactions.`netAmount`,0.00) as DEBIT,
if(AcctSide='CREDIT',foliotransactions.`netAmount`,0.00) as CREDIT,
foliotransactions.`UPDATEDBY` as CREATEDBY,
folioschedules.roomid,
company.companyName
from
foliotransactions
left join folioschedules on folioschedules.folioid = foliotransactions.folioid
left join folio on folioschedules.folioid = folio.folioid
left join company on folio.companyid = company.companyid,
`guests`
where
foliotransactions.`AccountID`=guests.`accountid` and
( year(foliotransactions.`updatetime`) = pYear) and
foliotransactions.Status='VOID'
order by folioschedules.roomid
)
UNION
(
select
nonguesttransaction.postingDate,
nonguesttransaction.transactiondate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource as ReferenceType,
nonguesttransaction.referenceFolioId as FolioID,
nonguesttransaction.guestName as GuestName,
nonguesttransaction.transactioncode,
nonguesttransaction.`Memo`,
if(AcctSide='DEBIT', nonguesttransaction.netAmount,0.00) as DEBIT,
if(AcctSide='CREDIT',nonguesttransaction.netAmount,0.00) as CREDIT,
nonguesttransaction.`UPDATEDBY` as CREATEDBY,
nonguesttransaction.roomNumber as roomid,
nonguesttransaction.companyName
from
nonguesttransaction force index(primary)
where
nonguesttransaction.statusFlag = 'VOID' and
year(nonguesttransaction.updatedDate) = pYear
order by nonguesttransaction.roomNumber
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportBanquetEventContractHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportBanquetEventContractHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportBanquetEventContractHeader`(pFolioID varchar(25), pHotelID int(5))
BEGIN
select distinct folio.folioid, 
if(folioschedules.days is not null, 
if(folioschedules.fromdate=folioschedules.todate, date_format(folioschedules.fromdate, '%b. %e, %Y'), concat(date_format(folioschedules.fromdate, '%b. %e, %Y'),' - ', date_format(folioschedules.todate, '%b. %e, %Y'))), 
concat(date_format(folio.fromdate, '%b. %e, %Y'),' - ', date_format(folio.todate, '%b. %e, %Y'))) as fromdate,
if(folioschedules.todate is not null, folioschedules.todate, folio.todate) as todate, 
if(folioschedules.days is not null, if(folioschedules.fromdate=folioschedules.todate, '1 day only', concat(folioschedules.days + 1, ' day/s only')), concat(datediff(folio.todate, folio.fromdate) + 1, ' day/s only')) as days, 
event_booking_info.eventtype, 
concat(event_booking_info.noOfPaxLiveIn, ' persons') as liveInPax, 
concat(event_booking_info.noOfPaxLiveOut, ' persons') as liveOutPax, 
(select folioschedules.venue from folioschedules where folioschedules.folioid=folio.folioid order by fromdate limit 1) as venue,
(select concat(date_format(folioschedules.starttime, '%h:%i %p'), ' - ', date_format(folioschedules.endtime, '%h:%i %p')) from folioschedules where folioschedules.folioid=folio.folioid order by fromdate limit 1) as time,
folio.groupname, 
event_booking_info.contactperson, 
event_booking_info.contactaddress, 
event_booking_info.contactNumber, 
event_booking_info.mobileNumber,
event_booking_info.faxNumber,
event_booking_info.billingarrangement, 
concat('P ', format(event_booking_info.totalEstimatedCost, 2)) as packageamount, 
event_booking_info.authorizedsignatory,
event_booking_info.lobbyPosting,
concat(users.firstname, ' ', users.lastname) as sales_executive,
folio.masterfolio,
sum(foliotransactions.currencyAmount) as payments,
group_concat(foliotransactions.referenceno) as referenceno,
'EVENT DETAILS' as header,
(event_booking_info.noOfPaxLiveIn+event_booking_info.noOfPaxLiveOut) as totalPax,
folioschedules.setup,
event_booking_info.contactPosition,
(select `value` from system_config where `key`='SALES_EXECUTIVE_MANAGER') AS salesExecutiveManager,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
cast(group_concat(if(folioschedules.days is not null, 
if(folioschedules.fromdate=folioschedules.todate, 
concat(date_format(folioschedules.fromdate, '%b. %e, %Y'), ' ', concat(date_format(folioschedules.starttime, '%h:%i %p'), ' - ', date_format(folioschedules.endtime, '%h:%i %p'))), concat(date_format(folioschedules.fromdate, '%b. %e, %Y'),' - ', date_format(folioschedules.todate, '%b. %e, %Y'), ' ', concat(date_format(folioschedules.starttime, '%h:%i %p'), ' - ', date_format(folioschedules.endtime, '%h:%i %p')))), 
concat(date_format(folio.fromdate, '%b. %e, %Y'),' - ', date_format(folio.todate, '%b. %e, %Y'), ' ', concat(date_format(folioschedules.starttime, '%h:%i %p'), ' - ', date_format(folioschedules.endtime, '%h:%i %p')))) separator ' / ') as char(10000)) as wholeSched,
count(folioschedules.folioid) as countSched,
event_booking_info.emailAddress,
folio.remarks
from folio left join users on (folio.sales_executive=users.userid) left join foliotransactions on (foliotransactions.folioid=folio.folioid and foliotransactions.acctside='CREDIT') left join folioschedules on (folio.folioid=folioschedules.folioid) left join event_booking_info on (folio.folioid=event_booking_info.folioid)
where 
folio.folioid=pFolioID and 
folio.hotelid=pHotelID group by folio.folioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportBanquetEventContractMeals` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportBanquetEventContractMeals` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportBanquetEventContractMeals`(pFolioID varchar(25))
BEGIN
select distinct concat('MENU: ', event_meal_header.mealtype) as mealtype, event_meal_details.description, event_meal_header.folioid from event_meal_header, event_meal_details where event_meal_header.mealid=event_meal_details.mealid and event_meal_header.folioid=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportBanquetEventContractRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportBanquetEventContractRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportBanquetEventContractRequirements`(pFolioID varchar(25))
BEGIN
select distinct * from event_requirements where folioid=pFolioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportBanquetWeddingDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportBanquetWeddingDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportBanquetWeddingDetails`(pFolioID varchar(30))
BEGIN
select event_details.* from event_details, event_booking_info where event_details.folioid=pFolioID and event_details.folioid=event_booking_info.folioid and event_booking_info.eventType='WEDDING';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportBookingsInquiries` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportBookingsInquiries` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportBookingsInquiries`(
pStartDate datetime,
pEndDate datetime,
pHotelId int
)
BEGIN
select folioId as CN, groupName as Event, 
(select group_concat(RoomID) from folioschedules where folioId = folio.folioId and hotelId = pHotelId) as Rooms, 
cast((select group_concat(distinct if(date_format(fromdate,'%b') = date_format(todate,'%b'), if(date_format(fromdate,'%e') = date_format(todate,'%e'), date_format(todate,'%b %e'), concat(date_format(fromdate,'%b %e'),'-',date_format(todate,'%e'))), concat(date_format(fromdate,'%b %e'),'-',date_format(todate,'%b %e')))) from folioschedules where folioId = folio.folioId and hotelId = pHotelId) as char) as eventDate, 
date_format(folio.createTime,'%e-%b-%y') as reservationDate, 
if(substring(folio.companyID,1,1) = 'G',(select companyname as organizer from company where folio.companyID = company.companyID and hotelId = pHotelId)  ,(select concat(firstname, ' ', lastname) as organizer from guests where folio.companyID = guests.accountid and hotelId = pHotelId)) as organizer, 
if((select NEW_VALUE from changes_log where remarks = concat('BOOKING STATUS : ',folio.folioId)) is null, '' , (select NEW_VALUE from changes_log where remarks = concat('BOOKING STATUS : ',folio.folioId))) as bookingStatus , 
folio.purpose as clientType, 
folio.source as bookingSource, 
ucase(folio.status) as `status`, 
if(concat(users.FirstName, ' ', users.LastName) is null,'',concat(users.FirstName, ' ', users.LastName)) as mo,
folio.reasonType 
from folio 
left join 
users 
on folio.sales_executive = users.userid 
where 
folio.createTime <= pEndDate 
and folio.createTime >= pStartDate 
and folio.hotelId = pHotelId 
and folio.status in ('TENTATIVE','WAIT LIST','CONFIRMED','CANCELLED');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportCalendarOfEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportCalendarOfEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportCalendarOfEvents`(
pStartDate datetime,
pEndDate datetime,
pHotelId int,
pStatus varchar(15)
)
BEGIN
if(pStatus = 'ALL') then 
	select 
	folio.referenceNo, 
	folio.folioId, 
	date_format(folio.createTime,'%e-%b-%y') as bookingDate, 
	folio.accountType as clientType, 
	folio.source, 
	cast((select group_concat(distinct if(date_format(fromdate,'%b') = date_format(todate,'%b'), if(date_format(fromdate,'%e') = date_format(todate,'%e'), date_format(todate,'%b %e'), concat(date_format(fromdate,'%b %e'),'-',date_format(todate,'%e'))), concat(date_format(fromdate,'%b %e'),'-',date_format(todate,'%b %e')))) from folioschedules where folioId = folio.folioId and hotelId = pHotelId) as char) as `date`, 
	concat(folioETA, '-', folioETD) as `time`,
	(select group_concat(RoomID) from folioschedules where folioId = folio.folioId and hotelid = pHotelId) as venue, 
	folio.groupName as eventTitle, 
	if(substring(folio.companyID,1,1) = 'G',(select companyname as organizer from company where folio.companyID = company.companyID and hotelid = pHotelId)  ,(select concat(firstname, ' ', lastname) as organizer from guests where folio.companyID = guests.accountid and hotelid = pHotelId)) as organizer, 
	event_booking_info.noofpaxguaranteed, 
	if(event_endorsement.contractAmount is null,0.00,event_endorsement.contractAmount) as contractAmount, 
	folio.purpose as marketsegment, 
	event_booking_info.eventtype, 
	folio.status, 
	if(concat(users.FirstName, ' ', users.LastName) is null,'',concat(users.FirstName, ' ', users.LastName)) as mo, 
	if((select group_concat(concat(firstName,' ' ,lastName)) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioId = folio.folioId and event_officers.hotelID = pHotelId) is null,' ',(select group_concat(concat(firstName,' ' ,lastName)) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioId = folio.folioId and event_officers.hotelID = pHotelId)) as eo,
	event_attendance.LocalParticipants, 
	event_attendance.ForeignParticipants, 
	event_attendance.NoOfVisitors, 
	event_attendance.ForeignBased, 
	event_attendance.LocalBased, 
	event_attendance.GeographicalScope,
	(select group_concat(distinct if(roomtypecode <> 'PICC FORUM','MAIN COMPLEX',roomtypecode)) from folioschedules left join rooms on folioschedules.roomid = rooms.roomid where folioId = folio.folioId and folioschedules.hotelid = pHotelId) as roomtype 
	from folio left join event_booking_info on folio.folioID = event_booking_info.folioID left join event_endorsement on folio.folioID = event_endorsement.folioID left join users on folio.sales_executive = users.userid left join event_attendance on folio.folioID = event_attendance.folioID where folio.fromDate >= pStartDate and folio.fromDate <= pEndDate and folio.hotelId = pHotelId and (folio.status = 'CONFIRMED' or folio.status = 'TENTATIVE') order by roomtype, folio.fromDate ASC;
else 
	select 
	folio.referenceNo, 
	folio.folioId,  
	date_format(folio.createTime,'%e-%b-%y') as bookingDate, 
	folio.accountType as clientType, 
	folio.source, 
	cast((select group_concat(distinct if(date_format(fromdate,'%b') = date_format(todate,'%b'), if(date_format(fromdate,'%e') = date_format(todate,'%e'), date_format(todate,'%b %e'), concat(date_format(fromdate,'%b %e'),'-',date_format(todate,'%e'))), concat(date_format(fromdate,'%b %e'),'-',date_format(todate,'%b %e')))) from folioschedules where folioId = folio.folioId and hotelId = pHotelId) as char) as `date`, 
	concat(folioETA, '-', folioETD) as `time`,
	(select group_concat(RoomID) from folioschedules where folioId = folio.folioId and hotelid = pHotelId) as venue, 
	folio.groupName as eventTitle, 
	if(substring(folio.companyID,1,1) = 'G',(select companyname as organizer from company where folio.companyID = company.companyID and hotelid = pHotelId)  ,(select concat(firstname, ' ', lastname) as organizer from guests where folio.companyID = guests.accountid and hotelid = pHotelId)) as organizer, 
	event_booking_info.noofpaxguaranteed, 	
	if(event_endorsement.contractAmount is null,0.00,event_endorsement.contractAmount) as contractAmount, 
	folio.purpose as marketsegment, 
	event_booking_info.eventtype, 
	folio.status, 
	if(concat(users.FirstName, ' ', users.LastName) is null,'',concat(users.FirstName, ' ', users.LastName)) as mo, 
	if((select group_concat(concat(firstName,' ' ,lastName)) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioId = folio.folioId and event_officers.hotelID = pHotelId) is null,' ',(select group_concat(concat(firstName,' ' ,lastName)) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioId = folio.folioId and event_officers.hotelID = pHotelId)) as eo, 
	event_attendance.LocalParticipants, 
	event_attendance.ForeignParticipants, 
	event_attendance.NoOfVisitors, 
	event_attendance.ForeignBased, 
	event_attendance.LocalBased, 
	event_attendance.GeographicalScope, 
	(select group_concat(distinct if(roomtypecode <> 'PICC FORUM','MAIN COMPLEX',roomtypecode)) from folioschedules left join rooms on folioschedules.roomid = rooms.roomid where folioId = folio.folioId and folioschedules.hotelid = pHotelId) as roomtype 
	from folio left join event_booking_info on folio.folioID = event_booking_info.folioID left join event_endorsement on folio.folioID = event_endorsement.folioID left join users on folio.sales_executive = users.userid left join event_attendance on folio.folioID = event_attendance.folioID where folio.fromDate >= pStartDate and folio.fromDate <= pEndDate and folio.hotelId = pHotelId and folio.status = pStatus order by roomtype, folio.fromDate ASC;
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportCancelledReservation` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportCancelledReservation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportCancelledReservation`(
in pHotelID int(5),
in pAuditDate varchar(15)
)
BEGIN
if not(pAuditDate = "") then
select 
folio.folioid,
if(folio.foliotype!='GROUP', folio.accountid, folio.companyid) as accountid,
if(folio.foliotype!='GROUP', fGetGuestName(folio.accountid), concat(folio.groupname, ' (', (if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid))), ')')) as GuestName,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.roomid) as roomid, 
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.roomtype) as roomtype,
folio.remarks,
folio.noofadults,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.days) as days,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.rate) as rate,
folio.fromdate,
folio.todate as departure,
folio.reason_for_cancel,
folio.updatetime
from
folioschedules right join
folio on (folioschedules.folioid = folio.folioid)
where
date(folio.updatetime) = cast(pAuditDate as date) and
(folio.status = 'CANCELLED' or folio.status = 'NO SHOW') and
folio.hotelid = photelid  order by roomid;
else
select 
folio.folioid,
if(folio.foliotype!='GROUP', folio.accountid, folio.companyid) as accountid,
if(folio.foliotype!='GROUP', fGetGuestName(folio.accountid), concat(folio.groupname, ' (', (if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid))), ')')) as GuestName,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.roomid) as roomid, 
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.roomtype) as roomtype,
folio.remarks,
folio.noofadults,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.days) as days,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.rate) as rate,
folio.fromdate,
folio.todate as departure,
folio.reason_for_cancel,
folio.updatetime
from
folioschedules right join
folio on (folioschedules.folioid = folio.folioid)
where
(folio.status = 'CANCELLED' or folio.status = 'NO SHOW') and
folio.hotelid = photelid  order by roomid;
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportCashierChargesTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportCashierChargesTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportCashierChargesTransaction`(
in pterminalid int(4),
in pHotelId int(5),
in pAuditDate date
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
foliotransactions.folioid,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT,
fGetTransactionDescription(foliotransactions.transactioncode) as description
from 	cashiers
left join foliotransactions on foliotransactions.terminalid = cashiers.terminalid and date(foliotransactions.transactiondate) = pAuditDate
left join transactioncode on transactioncode.trancode = foliotransactions.transactioncode and
transactioncode.trantypeid = 1
where
cashiers.terminalid = pterminalid and
cashiers.hotelid = pHotelId
order by transactiondate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportCashierPaymentTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportCashierPaymentTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportCashierPaymentTransaction`(
in pterminalid int(4),
in pCashierId varchar(5),
in pShiftCode varchar(5),
in pHotelId int(5),
in pAuditDate date
)
BEGIN
(
select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.updatedby,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
foliotransactions.transactionDate,
foliotransactions.referenceno,
concat((fGetCurrentRoomOccupied(foliotransactions.folioid, foliotransactions.hotelid, pAuditDate)),' ', if(substring(foliotransactions.accountid,1,1)='G',fGetCompanyName(foliotransactions.accountid), fGetGuestName(foliotransactions.accountid))) as TransactionSource,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
foliotransactions.folioid,
if(foliotransactions.acctside='DEBIT',foliotransactions.netAmount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.netAmount,0.00) as CREDIT,
fGetTransactionDescription(foliotransactions.transactioncode) as description
from 	
cashiers_logs
left join foliotransactions on cashiers_logs.terminalid = foliotransactions.terminalid and cashiers_logs.shiftcode = foliotransactions.shiftcode and foliotransactions.transactioncode !='3100' and 
foliotransactions.transactioncode != '3200' and
date(foliotransactions.transactiondate) = pAuditDate 
left join transactioncode on transactioncode.trancode = foliotransactions.transactioncode  and foliotransactions.status = 'ACTIVE'
where
cashiers_logs.terminalid = pTerminalid and 
cashiers_logs.shiftcode = pShiftCode and
cashiers_logs.cashierid = pCashierId and
cashiers_logs.hotelid = pHotelid and
date(cashiers_logs.transactiondate) = pAuditDate and
cashiers_logs.type = 'CLOSE' and
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 8 or transactioncode.trantypeid = 7 or
transactioncode.trantypeid = 9 or transactioncode.trantypeid = 11)
order by transactiondate
)
UNION(
select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.updatedby,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
if(nonguesttransaction.guestName="","WALK-IN",nonguesttransaction.guestName) as TransactionSource,
nonguesttransaction.transactionCode,
nonguesttransaction.memo,
nonguesttransaction.statusFlag as `status`,
nonguesttransaction.acctSide,
nonguesttransaction.referenceFolioId as folioId,
if(nonguesttransaction.acctside='DEBIT',nonguesttransaction.netAmount,0.00) as CHARGES,  
if(nonguesttransaction.acctside='CREDIT',nonguesttransaction.netAmount,0.00) as CREDIT,
fGetTransactionDescription(nonguesttransaction.transactioncode) as description
from cashiers_logs left join nonguesttransaction on (nonguesttransaction.terminalid = cashiers_logs.terminalid and nonguesttransaction.shiftcode = cashiers_logs.shiftcode)
left join transactioncode on transactioncode.trancode = nonguesttransaction.transactioncode
where
cashiers_logs.terminalid = pTerminalid and 
cashiers_logs.shiftcode = pShiftCode and
cashiers_logs.cashierid = pCashierId and
cashiers_logs.hotelid = pHotelid and
date(cashiers_logs.transactiondate) = pAuditDate and
cashiers_logs.type = 'CLOSE' and
date(nonguesttransaction.transactiondate)=pAuditDate
and
(transactioncode.trantypeid = 2 or transactioncode.trantypeid = 3 or 
transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or 
transactioncode.trantypeid = 8 or transactioncode.trantypeid = 7 or
transactioncode.trantypeid = 9 or transactioncode.trantypeid = 11) and
nonguesttransaction.statusFlag = 'ACTIVE'
)
UNION
(
select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.updatedby,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
cashiers_logs.transactionDate,
'' AS referenceno,
'' as TransactionSource,
'' AS transactioncode,
'' AS memo,
'ACTIVE' AS `status`,
'' AS acctside,
'' AS folioid,
0.00 as CHARGES,  
0.00 as CREDIT,
'' as description
from 	
cashiers_logs
where
cashiers_logs.terminalid = pTerminalid and 
cashiers_logs.shiftcode = pShiftCode and
cashiers_logs.cashierid = pCashierId and
cashiers_logs.hotelid = pHotelid and
date(cashiers_logs.transactiondate) = pAuditDate and
cashiers_logs.type = 'CLOSE'
order by transactiondate
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportCashierVoidTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportCashierVoidTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportCashierVoidTransactions`(
in pterminalid int(4),
in pCashierId varchar(5),
in pShiftCode varchar(5),
in pHotelId int(5),
in pAuditDate date
)
BEGIN
(
select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.updatedby,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
foliotransactions.transactionDate,
foliotransactions.referenceno,
concat((fGetCurrentRoomOccupied(foliotransactions.folioid, foliotransactions.hotelid, pAuditDate)),' ', if(substring(foliotransactions.accountid,1,1)='G',fGetCompanyName(foliotransactions.accountid), fGetGuestName(foliotransactions.accountid))) as TransactionSource,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
foliotransactions.folioid,
if(foliotransactions.acctside='DEBIT',foliotransactions.netAmount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.netAmount,0.00) as CREDIT
from 	
cashiers_logs
left join foliotransactions on foliotransactions.terminalid = cashiers_logs.terminalid and foliotransactions.shiftcode = cashiers_logs.shiftcode and foliotransactions.transactioncode !='3100' and 
foliotransactions.transactioncode != '3200' and
foliotransactions.transactiondate = pAuditDate
left join transactioncode on transactioncode.trancode = foliotransactions.transactioncode
left join folioschedules on folioschedules.folioid = foliotransactions.folioid
left join guests on guests.accountid = foliotransactions.accountid
where
cashiers_logs.terminalid = pTerminalid and 
cashiers_logs.shiftcode = pShiftCode and
cashiers_logs.cashierid = pCashierId and
cashiers_logs.hotelid = pHotelid and
cashiers_logs.transactiondate = pAuditDate and
cashiers_logs.type = 'CLOSE'
and
foliotransactions.status = 'VOID'
order by transactiondate
)
UNION(
select
nonguesttransaction.terminalID as Terminal,
nonguesttransaction.terminalID as cashierId,
nonguesttransaction.shiftCode,
0 as openingbalance,
0 as openingadjustment,
0 as beginningbalance,
0 as chargeinamount,
0 as cash,
0 as creditcard,
0 as cheque,	
0 as others,
"" as remarks,
nonguesttransaction.UPDATEDBY,
0 as adjustment,
0 as netamount,
0 as amountremitted,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
if(nonguesttransaction.guestName="","WALK-IN",nonguesttransaction.guestName) as TransactionSource,
nonguesttransaction.transactionCode,
nonguesttransaction.memo,
nonguesttransaction.statusFlag as `status`,
nonguesttransaction.acctSide,
nonguesttransaction.referenceFolioId as folioId,
if(nonguesttransaction.acctside='DEBIT',nonguesttransaction.netAmount,0.00) as CHARGES,  
if(nonguesttransaction.acctside='CREDIT',nonguesttransaction.netAmount,0.00) as CREDIT
from nonguesttransaction
left join transactioncode on transactioncode.trancode = nonguesttransaction.transactioncode
where
nonguesttransaction.terminalID = pterminalid and
nonguesttransaction.shiftCode = pShiftCode and
nonguesttransaction.transactionDate = pAuditDate and
nonguesttransaction.hotelID = pHotelId
and
nonguesttransaction.statusFlag = 'VOID'
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportCityLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportCityLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportCityLedger`(
in pHotelId int(5),
pDate date
)
BEGIN
select 
cityledger.reffolio,
cityledger.subfolio,
cityledger.debit,
cityledger.credit,
cityledger.updatedby,
folio.accountid,
fGetGuestName(folio.accountid) as GuestName,
folio.companyid,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName
from
cityledger left join folio on folio.folioid = cityledger.reffolio
where cityledger.Date=pDate
order by folio.companyid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportCityLedger1` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportCityLedger1` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportCityLedger1`(
in pHotelId int(5),
pDate date
)
BEGIN
select 
cityledger.reffolio,
cityledger.subfolio,
cityledger.debit,
cityledger.credit,
cityledger.updatedby,
folio.accountid,
fGetGuestName(folio.accountid) as GuestName,
folio.companyid,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName
from
cityledger left join folio on folio.folioid = cityledger.reffolio
where cityledger.Date=pDate
order by folio.companyid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportCityLedgerSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportCityLedgerSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportCityLedgerSummary`()
BEGIN
select
sum(cityledger.debit) as debit,
sum(cityledger.credit) as credit,
if(cityledger.reffolio="",cityledger.acctid,folio.companyid) as companyid,
company.companyname
from
cityledger left join folio on folio.folioid = cityledger.reffolio
left join guests on guests.accountid = folio.accountid
left join company on company.companyid = if(cityledger.reffolio="",cityledger.acctid,folio.companyid)
group by folio.companyid
order by folio.companyid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportCityTransferTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportCityTransferTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportCityTransferTransactions`(
in pAuditDate date
)
BEGIN
select 
(select roomid from folioschedules where folioid=folio.folioid limit 1) as roomid,
foliotransactions.folioid,
foliotransactions.accountid,
if(folio.foliotype!='GROUP', fGetGuestName(folio.accountid), concat(folio.groupname, ' (', (if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid))), ')')) as GuestName,
folio.companyid as companyid,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyname,
foliotransactions.postingdate,
foliotransactions.baseamount,
foliotransactions.updatedby
from foliotransactions left join folio on folio.folioid = foliotransactions.folioid
left join folioschedules on foliotransactions.folioid = folioschedules.folioid
where foliotransactions.transactioncode='4200' and
date(foliotransactions.postingdate) = pAuditDate
union
select roomNumber as roomID,
referenceFolioID as folioID,
accountID,
guestName,
accountID as companyID,
companyName,
postingdate,
baseamount,
updatedby
from nonguesttransaction
where transactioncode ='4200' and
date(transactiondate) >= pAuditDate and 
statusflag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spreportdailyhotelrevenue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spreportdailyhotelrevenue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spreportdailyhotelrevenue`(
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
concat(guests.`firstName`," " , guests.`lastName`) as GuestName,
foliotransactions.transactioncode,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`baseAmount`,
(foliotransactions.`baseAmount` * -1) ) as baseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as netBaseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`grossAmount`,
(foliotransactions.`grossAmount` * -1) ) as grossAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`discount`,
(foliotransactions.`discount` * -1) ) as discount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`serviceCharge`,
(foliotransactions.`serviceCharge` * -1) ) as serviceCharge,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`governmentTax`,
(foliotransactions.`governmentTax` * -1) ) as governmentTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`localTax`,
(foliotransactions.`localTax` * -1) ) as localTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`mealAmount`,
(foliotransactions.`mealAmount` * -1) ) as mealAmount,
foliotransactions.`Memo`,
foliotransactions.subFolio,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netAmount`,
(foliotransactions.`netAmount` * -1) ) as netAmount,
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
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.baseAmount,
(nonguesttransaction.baseAmount * -1) ) as baseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netBaseAmount,
(nonguesttransaction.netBaseAmount * -1) ) as netBaseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.grossAmount,
(nonguesttransaction.grossAmount * -1) ) as grossAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.discount,
(nonguesttransaction.discount * -1) ) as discount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.serviceCharge,
(nonguesttransaction.serviceCharge * -1) ) as serviceCharge,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.governmentTax,
(nonguesttransaction.governmentTax * -1) ) as governmentTax,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.localTax,
(nonguesttransaction.localTax * -1) ) as localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netAmount,
(nonguesttransaction.netAmount * -1) ) as netAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netbaseAmount,
(nonguesttransaction.netbaseAmount * -1) ) as Amount,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
'' as roomtype,
nonguesttransaction.companyName,
'' as REMARKS
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
'' as Remarks
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
'' as Remarks
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
group by
i.function_id,
h.order_id
)
order by transactionCode, transactionSource, ReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDailyRevenue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDailyRevenue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDailyRevenue`(
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
concat(guests.`firstName`," " , guests.`lastName`) as GuestName,
foliotransactions.transactioncode,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`baseAmount`,
(foliotransactions.`baseAmount` * -1) ) as baseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as netBaseAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`grossAmount`,
(foliotransactions.`grossAmount` * -1) ) as grossAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`discount`,
(foliotransactions.`discount` * -1) ) as discount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`serviceCharge`,
(foliotransactions.`serviceCharge` * -1) ) as serviceCharge,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`governmentTax`,
(foliotransactions.`governmentTax` * -1) ) as governmentTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`localTax`,
(foliotransactions.`localTax` * -1) ) as localTax,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`mealAmount`,
(foliotransactions.`mealAmount` * -1) ) as mealAmount,
foliotransactions.`Memo`,
foliotransactions.subFolio,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netAmount`,
(foliotransactions.`netAmount` * -1) ) as netAmount,
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
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.baseAmount,
(nonguesttransaction.baseAmount * -1) ) as baseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netBaseAmount,
(nonguesttransaction.netBaseAmount * -1) ) as netBaseAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.grossAmount,
(nonguesttransaction.grossAmount * -1) ) as grossAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.discount,
(nonguesttransaction.discount * -1) ) as discount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.serviceCharge,
(nonguesttransaction.serviceCharge * -1) ) as serviceCharge,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.governmentTax,
(nonguesttransaction.governmentTax * -1) ) as governmentTax,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.localTax,
(nonguesttransaction.localTax * -1) ) as localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netAmount,
(nonguesttransaction.netAmount * -1) ) as netAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netbaseAmount,
(nonguesttransaction.netbaseAmount * -1) ) as Amount,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
'' as roomtype,
nonguesttransaction.companyName,
'' as REMARKS
from nonguesttransaction force index(primary)
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
where
date(nonguesttransaction.transactionDate) >= pStartDate and 
date(nonguesttransaction.`TransactionDate`) <= pEndDate and
nonguesttransaction.statusFlag = 'ACTIVE' and
nonguesttransaction.hotelID = pHotelId and
transactioncode.tranTypeID = 1 group by folioid, referenceno, transactionsource
)
order by transactionCode, transactionSource, ReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDailyTotalMealAmount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDailyTotalMealAmount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDailyTotalMealAmount`(
in pTranDate date,
in pEndDate date,
in pHotelId int(5)
)
BEGIN
select 
date(foliotransactions.transactiondate) as transactiondate,
'1002' as transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.mealAmount * -1, foliotransactions.mealAmount)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
date(foliotransactions.transactiondate) >= pTrandate and date(foliotransactions.transactiondate)<=pEndDate and
foliotransactions.status = 'ACTIVE' and foliotransactions.transactioncode='1000'
group by foliotransactions.transactiondate, foliotransactions.transactioncode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDailyTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDailyTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDailyTransactions`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select 	
foliotransactions.*,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT,
folioschedules.roomid,
concat(guests.lastname,", ",guests.firstname) as GuestName
from foliotransactions 
left join folioschedules on foliotransactions.folioid = folioschedules.folioid
left join guests on guests.accountid = foliotransactions.accountid
where
date(transactiondate) = pAuditDate and
foliotransactions.hotelid = photelid
order by `status`,transactiondate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeActualGuestsArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeActualGuestsArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeActualGuestsArrival`(
in photelid int(5),
in pStartDate varchar(20),
in pEndDate varchar(20)
)
BEGIN
select 
folio.folioid,
guests.accountid,
guests.account_type,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folioschedules.roomid, 
folioschedules.roomtype,
folio.arrivalDate,
folio.DepartureDate,
folio.noOfadults as Pax,
folio.remarks,
folioschedules.todate as departure,
folioschedules.fromdate as arrival,
company.companyname,
fGetFolioBalance(folio.FolioId) as Balance,
rooms.floor
from
guests,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid,
folio left join company on company.companyid = folio.companyid
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
( date(folio.arrivaldate) >= pStartDate and date(folio.arrivaldate) <= pEndDate ) and
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid
order by folio.arrivaldate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeActualGuestsDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeActualGuestsDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeActualGuestsDeparture`(
in photelid int(5),
in pStartDate varchar(20),
in pEndDate varchar(20)
)
BEGIN
select 
folio.folioid,
guests.accountid,
guests.account_type,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folioschedules.roomid, 
folioschedules.roomtype,
folio.arrivalDate,
folio.DepartureDate,
folio.noOfadults as Pax,
folio.remarks,
folioschedules.todate as departure,
folioschedules.fromdate as arrival,
company.companyname,
fGetFolioBalance(folio.FolioId) as Balance,
rooms.floor
from
guests,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid,
folio left join company on company.companyid = folio.companyid
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
( date(folio.DepartureDate) >= pStartDate and date(folio.DepartureDate) <= pEndDate ) and
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid
order by folio.arrivaldate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeCancelledReservations` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeCancelledReservations` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeCancelledReservations`(
in pHotelID int(5),
in pStartDate date,
in pEndDate date
)
BEGIN
select 
folio.folioid,
if(folio.foliotype!='GROUP', folio.accountid, folio.companyid) as accountid,
if(folio.foliotype!='GROUP', fGetGuestName(folio.accountid), concat(folio.groupname, ' (', (if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid))), ')')) as GuestName,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.roomid) as roomid, 
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.roomtype) as roomtype,
folio.remarks,
folio.noofadults,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.days) as days,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.rate) as rate,
folio.fromdate,
folio.todate as departure,
folio.reason_for_cancel,
folio.updatetime
from
folioschedules right join
folio on (folioschedules.folioid = folio.folioid)
where
(date(folio.updatetime) >= pStartDate and
date(folio.updatetime) <= pEndDate ) and
(folio.status = 'CANCELLED' or folio.status = 'NO SHOW') and
folio.hotelid = photelid AND foliotype!='DEPENDENT' and foliotype != 'JOINER';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeCashierTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeCashierTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeCashierTransactions`(
in pHotelId int(5),
in pStartDate date,
in pEndDate date
)
BEGIN
(
select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
cashiers_logs.updatedby,
foliotransactions.transactionDate,
foliotransactions.referenceno,
concat((select roomid from folioschedules where folioid=foliotransactions.folioid limit 1),'  ',guests.lastname,', ',guests.firstname) as TransactionSource,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT
from 	
transactioncode,
cashiers_logs
left join foliotransactions on foliotransactions.terminalid = cashiers_logs.terminalid and foliotransactions.shiftcode = cashiers_logs.shiftcode
left join guests on guests.accountid = foliotransactions.accountid
where
foliotransactions.transactioncode = transactioncode.trancode and 
cashiers_logs.hotelid = pHotelid and
(date(foliotransactions.transactionDate) >= pStartDate and
date(foliotransactions.transactionDate) <= pEndDate ) and
cashiers_logs.type = 'CLOSE'
order by transactiondate
)
UNION(
select
nonguesttransaction.terminalID as Terminal,
nonguesttransaction.terminalID as cashierId,
nonguesttransaction.shiftCode,
0 as openingbalance,
0 as openingadjustment,
0 as beginningbalance,
0 as chargeinamount,
0 as cash,
0 as creditcard,
0 as cheque,	
0 as others,
"" as remarks,
0 as adjustment,
0 as netamount,
0 as amountremitted,
nonguesttransaction.updatedby,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
concat(nonguesttransaction.roomNumber," ",nonguesttransaction.guestName) as TransactionSource,
nonguesttransaction.transactionCode,
nonguesttransaction.memo,
nonguesttransaction.statusFlag as `status`,
nonguesttransaction.acctSide,
if(nonguesttransaction.acctside='DEBIT',nonguesttransaction.baseamount,0.00) as CHARGES,  
if(nonguesttransaction.acctside='CREDIT',nonguesttransaction.baseamount,0.00) as CREDIT
from nonguesttransaction force index(primary)
where
nonguesttransaction.hotelID = pHotelId and
(date(nonguesttransaction.transactionDate) >= pStartDate and
date(nonguesttransaction.transactionDate) <= pEndDate )
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeChargesNonGuestTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeChargesNonGuestTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeChargesNonGuestTransactions`(
in pStartDate date,
in pEndDate date,
in pHotelId int(4)
)
BEGIN
select 
nonguesttransaction.*,
concat(drivers.lastName," ",drivers.firstName) as Driver
from nonguesttransaction
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
left join trantypes on trantypes.trantypeid = transactioncode.tranTypeId
left join drivers on drivers.driverId = nonguesttransaction.referenceDriverId
where
date(nonguesttransaction.transactiondate) >= pStartDate and 
date(nonguesttransaction.transactiondate) <= pEndDate and
nonguesttransaction.hotelId = pHotelId AND
nonguesttransaction.statusflag = 'ACTIVE' and
(trantypes.trantypeId = 1);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeDriversSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeDriversSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeDriversSales`(pStartDate date, pEndDate date, pHotelid int(5))
BEGIN
select drivers.*, netAmount as commission, transactiondate, referenceNo, referenceFolioId, accountId, roomNumber, guestName from drivers, nonguesttransaction where referencedriverid=driverid and nonguesttransaction.hotelid=pHotelid and date(transactiondate) between pStartDate and pEndDate and statusflag!='VOID' order by lastname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeExpectedGuestsArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeExpectedGuestsArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeExpectedGuestsArrival`(
in photelid int(5),
in pStartDate varchar(20),
in pEndDate varchar(20)
)
BEGIN
select 
concat(guests.lastname, " , ", guests.firstname) as GuestName,
guests.memo,
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.todate as departure,
FOLIO.remarks,
folioschedules.fromdate as arrival,
company.companyname,
(folio.noofadults + folio.noofchild) as pax,
rooms.floor
from 
guests,
folio left join company on company.companyid = folio.companyid,
folioschedules  left join rooms on folioschedules.roomid=rooms.roomid
where 
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW' and
folio.status != 'ONGOING' and
folio.status != 'CLOSED') and
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and 
( date(folioschedules.fromdate) >= pStartDate and 
date(folioschedules.fromdate) <= pEndDate) and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid
order by folioschedules.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeExpectedGuestsDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeExpectedGuestsDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeExpectedGuestsDeparture`(
in photelid int(5),
in pStartDate date,
in pEndDate date
)
BEGIN
select 
concat(guests.lastname, " , ", guests.firstname) as GuestName,
guests.memo,
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.todate as departure,
FOLIO.remarks,
folioschedules.fromdate as arrival,
company.companyname,
folio.noofadults as Pax,
rooms.floor
from 
guests,
folio left join company on company.companyid = folio.companyid,
folioschedules left join rooms on folioschedules.roomid=rooms.roomid
where 
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW') and
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and 
( date(folioschedules.todate) >= pStartDate and
date(folioschedules.todate) <= pEndDate ) and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid
order by guests.lastname
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeNonGuestTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeNonGuestTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeNonGuestTransactions`(
in pStartDate date,
in pEndDate date,
in pHotelId int(4)
)
BEGIN
select 
nonguesttransaction.*,
concat(drivers.lastName," ",drivers.firstName) as Driver
from nonguesttransaction
left join drivers on drivers.driverId = nonguesttransaction.referenceDriverId
where
date(nonguesttransaction.transactiondate) >= pStartDate and 
date(nonguesttransaction.transactiondate) <= pEndDate and
nonguesttransaction.hotelId = pHotelId AND
nonguesttransaction.statusflag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeOutOfOrderRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeOutOfOrderRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeOutOfOrderRooms`(
in pHotelId int(5),
in pStartDate date,
in pEndDate date
)
BEGIN
select distinct
roomevents.eventdate,
roomevents.roomid,
engineeringjobs.assignedperson,
engineeringjobs.startdate,
engineeringjobs.starttime,
engineeringjobs.enddate,
engineeringjobs.endtime,
engineeringservices.servicename
from 
roomevents left join
engineeringjobs on engineeringjobs.roomid = roomevents.roomid
left join engineeringservices on 
engineeringservices.enggserviceid = engineeringjobs.enggserviceid
where 
eventtype = 'ENGINEERING JOB' and
(date(eventdate) >= pStartDate and date(eventdate) <= pEndDate) and 
roomevents.hotelid = pHotelId
order by eventdate,roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangePaidOutNonGuestTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangePaidOutNonGuestTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangePaidOutNonGuestTransactions`(
in pStartDate date,
in pEndDate date,
in pHotelId int(4)
)
BEGIN
select 
nonguesttransaction.*,
concat(drivers.lastName," ",drivers.firstName) as Driver
from nonguesttransaction
left join drivers on drivers.driverId = nonguesttransaction.referenceDriverId
where
date(nonguesttransaction.transactiondate) >= pStartDate and 
date(nonguesttransaction.transactiondate) <= pEndDate and
nonguesttransaction.hotelId = pHotelId AND
nonguesttransaction.statusflag = 'ACTIVE' and
(nonguesttransaction.transactioncode = '6000'
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangePaymentsNonGuestTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangePaymentsNonGuestTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangePaymentsNonGuestTransactions`(
in pStartDate date,
in pEndDate date,
in pHotelId int(4)
)
BEGIN
select 
nonguesttransaction.*,
concat(drivers.lastName," ",drivers.firstName) as Driver
from nonguesttransaction
left join drivers on drivers.driverId = nonguesttransaction.referenceDriverId
where
date(nonguesttransaction.transactiondate) >= pStartDate and 
date(nonguesttransaction.transactiondate) <= pEndDate and
nonguesttransaction.hotelId = pHotelId AND
nonguesttransaction.statusflag = 'ACTIVE' and
(nonguesttransaction.transactioncode = '2000' or
nonguesttransaction.transactioncode = '2100' or
nonguesttransaction.transactioncode = '2200' or
nonguesttransaction.transactioncode = '2201' or
nonguesttransaction.transactioncode = '2300' or
nonguesttransaction.transactioncode = '2400' or
nonguesttransaction.transactioncode = '2500' or
nonguesttransaction.transactioncode = '2501' or
nonguesttransaction.transactioncode = '2600' or
nonguesttransaction.transactioncode = '3200' or
nonguesttransaction.transactioncode = '3300' or
nonguesttransaction.transactioncode = '4000' or
nonguesttransaction.transactioncode = '4100' or
nonguesttransaction.transactioncode = '4200'
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeRoomOccupancyGraph` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeRoomOccupancyGraph` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeRoomOccupancyGraph`(
in pHotelId int(4),
in pStartDate date,
in pEndDate date
)
BEGIN
select roomevents.eventdate,((count(distinct roomevents.roomid)/FGetTotalRooms()) * 100) as Occupancy ,roomevents.eventtype from roomevents
where (roomevents.eventtype = "IN HOUSE" or roomevents.eventtype = "RESERVATION" or roomevents.eventtype = "CHECK OUT") and
(date(roomevents.eventdate) >= pStartDate and date(roomevents.eventdate) <= pEndDate)
group by roomevents.eventdate,roomevents.eventtype
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeSales`(
in pHotelid int(5),
in pStartDate date,
in pEndDate date
)
BEGIN
(
select
foliotransactions.transactiondate,
foliotransactions.folioid,
foliotransactions.referenceno, 
foliotransactions.netamount,
foliotransactions.updatetime,
foliotransactions.transactionsource,
folioschedules.updatedby,
folioschedules.roomid,
concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE,
concat(guests.lastname,", ",guests.firstname) as GuestName
from 	foliotransactions
left join guests on guests.accountid = foliotransactions.accountid,
folioschedules,
transactioncode,
trantypes 
where 	
folioschedules.folioid = foliotransactions.folioid and
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
trantypes.trantypeid = '1' and
( date(transactiondate) >= pStartDate and date(transactiondate) <= pEndDate ) and
folioschedules.hotelid = foliotransactions.hotelid and
transactioncode.hotelid = foliotransactions.hotelid and
trantypes.hotelid = foliotransactions.hotelid and
foliotransactions.hotelid = photelid and
foliotransactions.status = 'ACTIVE'
order by transactiondate
)
UNION
(
select
nonguesttransaction.transactiondate,
nonguesttransaction.referenceFolioId as folioid,
nonguesttransaction.referenceNo, 
nonguesttransaction.netamount,
nonguesttransaction.updatedDate as UPDATETIME,
nonguesttransaction.transactionSource,
nonguesttransaction.updatedby,
nonguesttransaction.roomNumber as roomid,
concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE,
nonguesttransaction.guestName as GuestName
from 
nonguesttransaction force index(primary)
left join transactioncode on transactioncode.trancode = nonguesttransaction.transactionCode 
left join trantypes on transactioncode.trantypeid = trantypes.trantypeid
where 
nonguesttransaction.acctSide = 'DEBIT' and
trantypes.trantypeid = '1' and
( date(transactionDate) >= pStartDate and date(transactionDate) <= pEndDate ) and
nonguesttransaction.hotelid = pHotelid and
nonguesttransaction.statusflag = 'ACTIVE'
order by transactiondate
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeSalesExecutive` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeSalesExecutive` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeSalesExecutive`(pStartDate date, pEndDate date, pHotelID int(2), pSalesExecutive varchar(30))
BEGIN
if(pSalesExecutive!='ALL') then
select 
(fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'DEBIT', folioid) +
fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'DEBIT', folioid)) -
(fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('7', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'CREDIT', folioid)) as totalSales,sales_executive, folioid, if(foliotype='GROUP', concat(if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)), ' [', folio.groupname, ']'), concat(fGetGuestName(folio.accountid), ' [', folio.groupname, ']')) as companyName, 
source, arrivalDate as arrival, departureDate as departure from folio where sales_executive=pSalesExecutive and folio.status='CLOSED' and folio.foliotype!='JOINER' and date(departureDate)>=pStartDate and date(departureDate)<=pEndDate order by totalSales desc, sales_executive;
else
select 
(fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'DEBIT', folioid) +
fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'DEBIT', folioid)) -
(fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('7', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'CREDIT', folioid)) as totalSales,sales_executive, folioid, if(foliotype='GROUP', concat(if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)), ' [', folio.groupname, ']'), concat(fGetGuestName(folio.accountid), ' [', folio.groupname, ']')) as companyName, 
source, arrivalDate as arrival, departureDate as departure from folio where folio.status='CLOSED' and folio.foliotype!='JOINER' and date(departureDate)>=pStartDate and date(departureDate)<=pEndDate order by totalSales, sales_executive desc;
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeSalesProduction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeSalesProduction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeSalesProduction`(pFromDate date, pToDate date, pHotelID int(5))
BEGIN
select date_format(fromdate, '%d-%b-%Y') as fromDate, date_format(todate, '%d-%b-%Y') as toDate, folio.folioid, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName, groupname, eventType, (fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'DEBIT', folio.folioid) +
fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'DEBIT', folio.folioid)) -
(fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'CREDIT', folio.folioid) +
fGetTotalFolioAmountForSalesExecutive('7', pHotelID, 'A', 'CREDIT', folio.folioid) +
fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'CREDIT', folio.folioid)) as packageAmount, if(folio.status='CANCELLED', 'LOST/UNREALIZED', if(folio.status='CLOSED' or folio.status='ONGOING', 'REALIZED', folio.status)) as `status`, reason_for_cancel as reason
from folio left join event_booking_info on (folio.folioid=event_booking_info.folioid) where foliotype='GROUP' and 
date(fromdate) >= pFromDate and date(fromDate) <= pToDate
and folio.hotelid=pHotelId
order by `status`, fromdate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeSalesSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeSalesSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeSalesSummary`(
in pHotelid int(5),
in pStartDate date,
in pEndDate date
)
BEGIN
(
select transactioncode, sum(baseamount) as BaseAmount, sum(grossAmount) as GrossAmount, sum(netAmount) as NetAmount, sum(netbaseamount) as NetBaseAmount, sum(discount) as Discount, sum(govttax) as GovtTax, sum(mealamount) as MealAmount, sum(localtax) as LocalTax, sum(servicecharge) as ServiceCharge, sum(transactioncount) as TransactionCount, TransactionDescription, acctside, sum(monthtodate) as MonthToDate, sum(yeartodate) as YearToDate from
(select 
foliotransactions.transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.baseAmount * -1, foliotransactions.baseAmount)) as BaseAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as GrossAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netAmount * -1, foliotransactions.netAmount)) as NetAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netBaseAmount * -1, foliotransactions.netBaseAmount)) as NetBaseAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.discount * -1, foliotransactions.discount)) as Discount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.governmentTax * -1, foliotransactions.governmentTax)) as GovtTax,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.mealAmount * -1, foliotransactions.mealAmount)) as MealAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.localtax * -1, foliotransactions.localtax)) as LocalTax,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.servicecharge * -1, foliotransactions.servicecharge)) as ServiceCharge,
count(foliotransactions.transactioncode) as TransactionCount,
transactioncode.memo as TransactionDescription,
foliotransactions.acctside,
fGetTransactionNetBaseAmountMonthToDate(
foliotransactions.transactioncode,
foliotransactions.acctside,
transactiondate,
pHotelId
) as MonthToDate,
fGetTransactionNetBaseAmountYearToDate(
foliotransactions.transactioncode,
transactioncode.acctside,
transactiondate,
pHotelId
) as YearToDate
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary),
trantypes  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
(date(transactiondate) >= pStartDate and date(transactiondate) <= pEndDate) and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactioncode, foliotransactions.acctside
UNION all
select 
nonguesttransaction.transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.baseAmount * -1, nonguesttransaction.baseAmount)) as BaseAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.grossAmount * -1, nonguesttransaction.grossAmount)) as GrossAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netAmount * -1, nonguesttransaction.netAmount)) as NetAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netBaseAmount * -1, nonguesttransaction.netBaseAmount)) as NetBaseAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.discount * -1, nonguesttransaction.discount)) as Discount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.governmentTax * -1, nonguesttransaction.governmentTax)) as GovtTax,
0 as MealAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.localtax * -1, nonguesttransaction.localtax)) as LocalTax,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.servicecharge * -1, nonguesttransaction.servicecharge)) as ServiceCharge,
count(nonguesttransaction.transactioncode) as TransactionCount,
concat(transactioncode.memo, "-WALK IN") as TransactionDescription,
nonguesttransaction.acctside,
fGetNonGuestTransactionNetBaseAmountMonthToDate(
nonguesttransaction.transactioncode,
nonguesttransaction.acctside,
transactiondate,
pHotelId
)  as MonthToDate,
fGetNonGuestTransactionNetBaseAmountYearToDate(
nonguesttransaction.transactioncode,
transactioncode.acctside,
transactiondate,
pHotelId
)  as YearToDate
from
nonguesttransaction  force index(primary),
transactioncode force index(primary)
where 	
(date(transactiondate) >= pStartDate and date(transactiondate) <= pEndDate) and
nonguesttransaction.statusFlag = 'ACTIVE' and nonguesttransaction.transactioncode=transactioncode.trancode
group by nonguesttransaction.transactioncode,nonguesttransaction.acctside) as transactionTable
group by transactioncode order by transactioncode asc, acctside desc);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDateRangeVoidTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDateRangeVoidTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDateRangeVoidTransactions`(
in pHotelId int(4),
in pStartDate date,
in pEndDate date
)
BEGIN
(
select
foliotransactions.postingDate,
foliotransactions.transactiondate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource` as ReferenceType,
foliotransactions.`FolioID`,
concat(guests.`lastname`,", " , guests.`firstname`) as GuestName,
foliotransactions.transactioncode,
foliotransactions.`Memo`,
if(AcctSide='DEBIT',foliotransactions.netAmount,0.00) as DEBIT,
if(AcctSide='CREDIT',foliotransactions.netAmount,0.00) as CREDIT,
foliotransactions.`UPDATEDBY` as CREATEDBY,
folioschedules.roomid,
company.companyName
from
foliotransactions
left join folioschedules on folioschedules.folioid = foliotransactions.folioid
left join folio on folioschedules.folioid = folio.folioid
left join company on folio.companyid = company.companyid,
`guests`
where
foliotransactions.`AccountID`=guests.`accountid` and
( date(foliotransactions.transactiondate) >= pStartDate and 
date(foliotransactions.transactiondate) <= pEndDate ) and
foliotransactions.Status='VOID'
order by folioschedules.roomid
)
UNION
(
select
nonguesttransaction.postingDate,
nonguesttransaction.transactiondate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource as ReferenceType,
nonguesttransaction.referenceFolioId as FolioID,
nonguesttransaction.guestName as GuestName,
nonguesttransaction.transactioncode,
nonguesttransaction.`Memo`,
if(AcctSide='DEBIT', nonguesttransaction.netAmount,0.00) as DEBIT,
if(AcctSide='CREDIT',nonguesttransaction.netAmount,0.00) as CREDIT,
nonguesttransaction.`UPDATEDBY` as CREATEDBY,
nonguesttransaction.roomNumber as roomid,
nonguesttransaction.companyName
from
nonguesttransaction force index(primary)
where
nonguesttransaction.statusFlag = 'VOID' and
( date(nonguesttransaction.transactiondate) >= pStartDate and 
date(nonguesttransaction.transactiondate) <= pEndDate)
order by nonguesttransaction.roomNumber
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportDependentFolios` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportDependentFolios` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportDependentFolios`(
in pMasterFolio varchar(30),
in pHotelId int(4)
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportEDRoomTransfer` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportEDRoomTransfer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportEDRoomTransfer`(
IN photelid int(5),
in pAuditDate date
)
BEGIN
select folioid
from folioschedules 
where date(fromdate) = adddate(pAuditDate,1);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportEventAttendance` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportEventAttendance` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportEventAttendance`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
select  folio.groupName, concat(DATE_FORMAT(folio.fromDate,'%M %e, %Y'), ' - ', DATE_FORMAT(folio.toDate,'%M %e, %Y')) as eventDate, folio.purpose as marketSegment, folio.ReferenceNo , GeographicalScope, ForeignParticipants, LocalParticipants, ForeignBased, LocalBased, NoOfVisitors, ActualAttendees, event_attendance.Remarks
from event_attendance left join folio on event_attendance.folioID = folio.folioID
where event_attendance.FolioID = pFolioID and event_attendance.HotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportEventOrder` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportEventOrder` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportEventOrder`(
pFolioID varchar(20),
pRemarks text,
pHotelID int
)
BEGIN
select requirement_header.requirementID, requirement_header.requirementDescription, if(event_requirements.description is null, ' ', event_requirements.description) as description from requirement_header left join ((select * from event_requirements where folioID = pFolioID and remarks = pRemarks) as event_requirements) on requirement_header.requirementDescription = event_requirements.requirementID where hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportEventOrderPayments` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportEventOrderPayments` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportEventOrderPayments`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
select transactionSource, referenceNo, chequeDate, netAmount from foliotransactions where folioId = pFolioID and hotelId = pHotelID and acctSide = 'CREDIT';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportEventOrderSub` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportEventOrderSub` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportEventOrderSub`(
pFolioID varchar(20),
pRoomID varchar(10),
pDate datetime,
pHotelID int
)
BEGIN
select concat(date_format(pDate,'%M %e,%Y %W '),date_format(startTime,'%l%p'),'-',date_format(endTime,'%l%p')) as dates, if(activity='','Actual',activity) as activity from folioschedules where FolioId = pFolioID and RoomID = pRoomID and HOTELID = pHotelID
order by startTime asc, activity desc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportEventRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportEventRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportEventRequirements`(pFolioID varchar(30))
BEGIN
select requirementid, group_concat(description) from event_requirements where folioid=pFolioID group by requirementid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportEventsOrganized` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportEventsOrganized` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportEventsOrganized`(
pAccountID varchar(20),
pHotelID int
)
BEGIN
select groupName as title, 
count(groupName) as frequency, 
cast(group_concat(concat(date_format(fromDate,'%e-%b-%Y'), ' to ',date_format(toDate,'%e-%b-%Y'))) as char) as `date`,
(select group_concat(RoomID) from folioschedules where folioschedules.folioid = folio.folioid) as venue from folio 
where folio.status!='CANCELLED' and folio.status!='DELETED' and folio.status != 'REMOVED' and folio.status != 'NO SHOW' and companyID = pAccountID and hotelID = pHotelID
group by groupName;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportExpectedGuestsArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportExpectedGuestsArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportExpectedGuestsArrival`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select 
concat(guests.lastname, " , ", guests.firstname) as GuestName,
guests.memo,
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.todate as departure,
folio.remarks,
folio.folioid,
folioschedules.fromdate as arrival,
company.companyname,
(folio.noofadults + folio.noofchild) as pax,
fGetFolioBalance(folio.FolioId) as Balance,
guests.account_type,
rooms.floor
from 
guests,
folio left join company on company.companyid = folio.companyid,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid
where 
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW' and 
folio.status != 'ONGOING' and
folio.status != 'CLOSED') and
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and 
date(folioschedules.fromdate) = pAuditDate and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid and
folio.foliotype != 'DEPENDENT' and
folioschedules.roomtype!='FUNCTION'
order by folioschedules.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportExpectedGuestsDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportExpectedGuestsDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportExpectedGuestsDeparture`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select 
folio.folioid,
concat(guests.lastname, " , ", guests.firstname) as GuestName,
guests.memo,
guests.account_type,
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.todate as departure,
folio.remarks,
folioschedules.fromdate as arrival,
company.companyname,
folio.noofadults as Pax,
fGetFolioBalance(folio.FolioId) as Balance,
rooms.floor
from 
guests,
folio left join company on company.companyid = folio.companyid,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid
where 
(folio.status = 'ONGOING' or folio.status = 'CONFIRMED' or folio.status = 'TENTATIVE') and
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and 
date(folioschedules.todate) = pAuditDate and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid and
folio.foliotype != 'DEPENDENT' and
folioschedules.roomtype!='FUNCTION'
order by guests.lastname
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportGroupBill` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportGroupBill` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportGroupBill`(
in pFolioId varchar(20),
in pHotelId int(5)
)
BEGIN
select distinct
folio.folioid,
folio.foliotype,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
event_booking_info.contactAddress as CityAdd,
event_booking_info.contactAddress as CountryAdd,
foliotransactions.transactiondate,
foliotransactions.postingdate,
foliotransactions.referenceno,
foliotransactions.transactioncode,
foliotransactions.memo,
if(foliotransactions.summaryFlag!=0, fGetPackageName(foliotransactions.packageID), foliotransactions.memo) as packageName,
foliotransactions.netbaseamount,
foliotransactions.governmenttax,
foliotransactions.localtax,
foliotransactions.discount,
foliotransactions.updatedby,
if(acctside='DEBIT',foliotransactions.netamount,0.00) as CHARGES,  
if(acctside='CREDIT',foliotransactions.netamount,0.00) as CREDIT,
foliotransactions.summaryFlag,
foliotransactions.transactionSource
from
folio left join event_booking_info on (folio.folioid = event_booking_info.folioid)
left join foliotransactions on foliotransactions.folioid = folio.folioid 
and foliotransactions.status = 'ACTIVE' and foliotransactions.summaryFlag=0 and
((foliotransactions.transactionCode!=1000 and foliotransactions.baseAmount!=0.00) or
(foliotransactions.transactionCode=1000 and foliotransactions.baseAmount!=0.00)) and foliotransactions.subfolio='A'
where
folio.folioid = pFolioId and 	
folio.hotelid = pHotelId
order by foliotransactions.transactiondate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportGroupBill2` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportGroupBill2` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportGroupBill2`(
in pFolioId varchar(20),
in pHotelId int(5)
)
BEGIN
select 
folio.folioid,
folio.foliotype,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
event_booking_info.contactAddress as CityAdd,
event_booking_info.contactAddress as CountryAdd,
foliotransactions.transactiondate,
foliotransactions.postingdate,
foliotransactions.referenceno,
foliotransactions.packageID as transactionCode,
foliotransactions.memo,
fGetPackageName(foliotransactions.packageID) as packageName,
(select distinct sum(netbaseamount) from foliotransactions where folioid=pFolioID and foliotransactions.status = 'ACTIVE' and foliotransactions.acctside='DEBIT' and foliotransactions.summaryFlag!=0 ) as netbaseamount,
(select distinct sum(governmenttax) from foliotransactions where folioid=pFolioID and foliotransactions.status = 'ACTIVE' and foliotransactions.summaryFlag!=0 ) as governmenttax,
(select distinct sum(localtax) from foliotransactions where folioid=pFolioID and foliotransactions.status = 'ACTIVE' and foliotransactions.summaryFlag!=0 ) as localtax,
(select distinct sum(discount) from foliotransactions where folioid=pFolioID and foliotransactions.status = 'ACTIVE' and foliotransactions.summaryFlag!=0 ) as discount,
foliotransactions.updatedby,
(select distinct sum(netamount) from foliotransactions where folioid=pFolioID and acctside='DEBIT' and foliotransactions.status = 'ACTIVE' and foliotransactions.summaryFlag!=0 ) as CHARGES,  
(select distinct sum(netamount) from foliotransactions where folioid=pFolioID and acctside='CREDIT' and foliotransactions.status = 'ACTIVE' and foliotransactions.summaryFlag!=0 ) as CREDIT,
foliotransactions.summaryFlag,
foliotransactions.transactionSource,
(select distinct sum(netamount) from foliotransactions where folioid=pFolioID and foliotransactions.status = 'ACTIVE' and foliotransactions.summaryFlag!=0 ) as netamount
from
folio left join event_booking_info on (folio.folioid = event_booking_info.folioid)
left join foliotransactions on foliotransactions.folioid = folio.folioid 
and foliotransactions.status = 'ACTIVE' and foliotransactions.subfolio='A'
where
folio.folioid = pFolioId and 	
folio.hotelid = pHotelId and foliotransactions.summaryFlag!=0 
group by summaryFlag;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportGroupBillPICC` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportGroupBillPICC` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportGroupBillPICC`(
in pFolioId varchar(20),
in pHotelId int(5)
)
BEGIN
select distinct
folio.folioid,
folio.foliotype,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
event_booking_info.contactAddress as CityAdd,
event_booking_info.contactAddress as CountryAdd,
foliotransactions.transactiondate,
foliotransactions.postingdate,
foliotransactions.referenceno,
foliotransactions.transactioncode,
foliotransactions.memo,
if(foliotransactions.summaryFlag!=0, if(fGetPackageName(foliotransactions.packageID) is null,'',fGetPackageName(foliotransactions.packageID)), foliotransactions.memo) as packageName,
if(foliotransactions.acctside='CREDIT', foliotransactions.netbaseamount * -1, foliotransactions.netbaseamount) as netbaseamount,
if(foliotransactions.acctside='CREDIT', foliotransactions.governmenttax * -1, foliotransactions.governmenttax) as governmenttax,
if(foliotransactions.acctside='CREDIT', foliotransactions.localtax * -1, foliotransactions.localtax) as localtax,
if(foliotransactions.acctside='CREDIT', foliotransactions.discount * -1, foliotransactions.discount) as discount,
foliotransactions.updatedby,
if(acctside='DEBIT',foliotransactions.netamount,0.00) as CHARGES,  
if(acctside='CREDIT',foliotransactions.netamount,0.00) as CREDIT,
foliotransactions.summaryFlag,
foliotransactions.transactionSource,
foliotransactions.acctSide,
foliotransactions.roomid,
(select roomdescription from rooms where roomid=foliotransactions.roomid) as RoomDescription
from
folio left join event_booking_info on (folio.folioid = event_booking_info.folioid)
left join foliotransactions on foliotransactions.folioid = folio.folioid 
and foliotransactions.status = 'ACTIVE' and
((foliotransactions.transactionCode!=1000 and foliotransactions.baseAmount!=0.00) or
(foliotransactions.transactionCode=1000 and foliotransactions.baseAmount!=0.00)) and foliotransactions.subfolio='A'
where
folio.folioid = pFolioId and 	
folio.hotelid = pHotelId and
foliotransactions.transactioncode != '3300'
order by foliotransactions.acctSide DESC,foliotransactions.transactiondate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportGroupBillPICCCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportGroupBillPICCCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportGroupBillPICCCharges`(
in pFolioId varchar(20),
in pHotelId int(5)
)
BEGIN
select distinct
folio.folioid,
folio.foliotype,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
event_booking_info.contactAddress as CityAdd,
event_booking_info.contactAddress as CountryAdd,
foliotransactions.transactiondate,
foliotransactions.postingdate,
foliotransactions.referenceno,
foliotransactions.transactioncode,
foliotransactions.memo,
if(foliotransactions.summaryFlag!=0, if(fGetPackageName(foliotransactions.packageID) is null,'',fGetPackageName(foliotransactions.packageID)), foliotransactions.memo) as packageName,
if(foliotransactions.acctside='CREDIT', foliotransactions.netbaseamount * -1, foliotransactions.netbaseamount) as netbaseamount,
if(foliotransactions.acctside='CREDIT', foliotransactions.governmenttax * -1, foliotransactions.governmenttax) as governmenttax,
if(foliotransactions.acctside='CREDIT', foliotransactions.localtax * -1, foliotransactions.localtax) as localtax,
if(foliotransactions.acctside='CREDIT', foliotransactions.discount * -1, foliotransactions.discount) as discount,
foliotransactions.updatedby,
if(acctside='DEBIT',foliotransactions.netamount,0.00) as CHARGES,  
if(acctside='CREDIT',foliotransactions.netamount,0.00) as CREDIT,
foliotransactions.summaryFlag,
foliotransactions.transactionSource,
foliotransactions.acctSide,
foliotransactions.roomid,
(select roomdescription from rooms where roomid=foliotransactions.roomid) as RoomDescription
from
folio left join event_booking_info on (folio.folioid = event_booking_info.folioid)
left join foliotransactions on foliotransactions.folioid = folio.folioid 
and foliotransactions.status = 'ACTIVE' and
((foliotransactions.transactionCode!=1000 and foliotransactions.baseAmount!=0.00) or
(foliotransactions.transactionCode=1000 and foliotransactions.baseAmount!=0.00)) and foliotransactions.subfolio='A'
where
folio.folioid = pFolioId and 	
folio.hotelid = pHotelId and
foliotransactions.transactioncode != '3300' and 
foliotransactions.acctSide <> 'CREDIT' 
order by foliotransactions.acctSide DESC,foliotransactions.transactiondate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportGroupReservation` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportGroupReservation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportGroupReservation`(
pFolioID varchar(20),
pHotelID int
)
BEGIN
select concat(date_format(folioschedules.fromdate, '%b %e, %Y'), ' - ' , date_format(folioschedules.todate, '%b %e, %Y')) as `date`, date_format(folioschedules.fromdate, '%a') as `day` , folioschedules.venue, concat(date_format(folioschedules.startTime, '%l:%i %p'), ' - ', date_format(folioschedules.endTime, '%l:%i %p')) as `time`, if(folioschedules.activity = '',' ',folioschedules.activity) as activity, folioschedules.guaranteedPax, if(folioschedules.setup = '',' ',folioschedules.setup) as setup, folio.status as `status` from folio left join folioschedules on  folio.folioID = folioschedules.FolioId where folioschedules.FolioId = pFolioID and folioschedules.HOTELID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportGuestsLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportGuestsLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportGuestsLedger`(
in pHotelId int(5),
in pReportDate date
)
BEGIN
select
folio.folioid,
if(fGetCurrentRoomOccupied(folio.folioid,pHotelId, pReportDate) is null,fGetCurrentRoomOccupied(folio.masterfolio,pHotelId, pReportDate),fGetCurrentRoomOccupied(folio.folioid,pHotelId, pReportDate)) as RoomId,
if(folio.accountId != "", CONCAT(GUESTS.LASTNAME," , ", GUESTS.FIRSTNAME), folio.groupName) AS GuestName,
sum(if(acctside='DEBIT',foliotransactions.netamount,0)) as CHARGES,
sum(if(acctside='CREDIT',foliotransactions.netamount,0)) as PAYMENT,
folio.remarks,	
folio.status,
company.companyName as CompanyName,
date(folio.fromdate) as checkInDate,
date(folio.todate) as checkOutDate
from
folio 
left join guests on guests.accountid = folio.accountid
left join company on company.companyid = folio.companyid
left join foliotransactions on foliotransactions.folioid = folio.folioid
and foliotransactions.`status` = 'ACTIVE' and
foliotransactions.transactiondate <= pReportDate
where
folio.hotelid = pHotelId and
(folio.status = 'ONGOING' or folio.status = 'CONFIRMED' or folio.status = 'TENTATIVE'
or folio.status = 'CLOSED') and
(date(folio.fromDate) <= pReportDate and date(folio.toDate) >= pReportDate) and folio.foliotype != 'GROUP' and folio.foliotype != 'SHARE' and folio.foliotype != 'JOINER'
group by folioid
order by roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportHighBalanceGuests` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportHighBalanceGuests` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportHighBalanceGuests`(
in pHotelId int(5),
in pReportDate date
)
BEGIN
select
folio.folioid,
if(fGetCurrentRoomOccupied(folio.folioid,pHotelId, pReportDate) is null,fGetCurrentRoomOccupied(folio.masterfolio,pHotelId, pReportDate),fGetCurrentRoomOccupied(folio.folioid,pHotelId, pReportDate)) as RoomId,
if(folio.accountId != "", CONCAT(GUESTS.LASTNAME," , ", GUESTS.FIRSTNAME), folio.groupName) AS GuestName,
if(folio.accountId != "", guests.threshold_value, company.threshold_value) AS CreditLimit,
fGetFolioBalance(folio.folioid) as Balance,
folio.remarks,	
folio.status,
company.companyName as CompanyName,
folio.fromdate as checkInDate,
folio.todate as checkOutDate
from
folio 
left join folioledger on folioledger.folioid = folio.folioid
left join guests on guests.accountid = folio.accountid
left join company on company.companyid = folio.companyid
where
fGetFolioBalance(folio.folioid) > 0 and
(fGetFolioBalance(folio.folioid) >= guests.threshold_value 
or fGetFolioBalance(folio.folioid) >= company.threshold_value)
and
folio.hotelid = pHotelId and
(folio.status = 'ONGOING' or folio.status = 'CONFIRMED' or folio.status = 'TENTATIVE'
or folio.status = 'CLOSED') and
(date(folio.fromDate) <= pReportDate and date(folio.toDate) >= pReportDate) and folio.foliotype != 'SHARE'
group by folioid
order by fGetFolioBalance(folio.folioid) desc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportHousekeepingJobs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportHousekeepingJobs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportHousekeepingJobs`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select 
hk_housekeepingjobs.roomId,
rooms.roomtypecode,
hk_housekeepingjobs.housekeepingDate,
hk_housekeepingjobs.startTime,
hk_housekeepingjobs.endTime,
hk_housekeepingjobs.remarks,
hk_housekeepingjobs.housekeepingType,
hk_housekeepingjobs.elapsedTime,
concat(	hk_housekeepingjobs.housekeeperid, "-", hk_housekeepers.lastname,", ",hk_housekeepers.firstname) as HOUSEKEEPER,
hk_housekeepingjobs.updatedBy
from
hk_housekeepingjobs
left join hk_housekeepers on hk_housekeepers.housekeeperId = hk_housekeepingjobs.housekeeperid
left join rooms on rooms.roomid = hk_housekeepingjobs.roomId
where
hk_housekeepingjobs.housekeepingDate = pAuditDate and
hk_housekeepingjobs.hotelId = photelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportIndividualGuestBill` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportIndividualGuestBill` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportIndividualGuestBill`(
in pfolioid varchar(20),
in photelid int(5),
in pAuditDate date
)
BEGIN
(select distinct
folio.folioid,
folio.remarks,
(folio.noofadults+folio.noofchild) as TotalGuests,
folio.foliotype,
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.ratetype,
folio.arrivaldate as ARRIVALDATE,
folio.departuredate as DEPARTUREDATE,  
if(folio.foliotype='GROUP', if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)), fGetGuestName(folio.accountid)) as GuestName,
if(folio.foliotype='GROUP', (select contactaddress from event_booking_info where folioid=folio.folioid), concat(guests.street,", ",guests.city)) as CityAdd,
concat(guests.country, " ",guests.zip) as CountryAdd,
foliotransactions.postingdate,
foliotransactions.transactiondate,
foliotransactions.SubFolio,
foliotransactions.referenceno,
foliotransactions.transactionsource,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.netbaseamount,
foliotransactions.governmenttax,
foliotransactions.localtax,
foliotransactions.discount,
foliotransactions.grossAmount,
foliotransactions.servicecharge,
foliotransactions.updatedby,
if(foliotransactions.subfolio='A', company.companyid, fGetAccountIDOfLedger(folio.folioid, subfolio)) as companyid,
if(foliotransactions.subfolio='A', company.companyname, if(substring(fGetAccountIDOfLedger(folio.folioid, subfolio), 1, 1)='G',fGetCompanyName(fGetAccountIDOfLedger(folio.folioid, subfolio)), fGetGuestName(fGetAccountIDOfLedger(folio.folioid, subfolio)))) as companyName,
if(acctside='DEBIT',foliotransactions.netamount,0.00) as CHARGES,  
if(acctside='CREDIT',foliotransactions.netamount,0.00) as CREDIT
from
folio
left join foliotransactions on foliotransactions.folioid = folio.folioid and
foliotransactions.status = 'ACTIVE' left join company on company.companyid = folio.companyid
left join guests on guests.accountid = folio.accountid ,
(select * from folioschedules where folioid = pfolioid limit 0,1) folioschedules
where
folio.folioid = pfolioid 
and folio.hotelid = pHotelId
order by foliotransactions.transactiondate);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportIndividualGuestBillSubReport` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportIndividualGuestBillSubReport` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportIndividualGuestBillSubReport`(
in pfolioid varchar(20)
)
BEGIN
Select 
folioid,
transactioncode,
GovernmentTax,
servicecharge,
netbaseamount,
if(memo='CASH','PAYMENTS',memo) as memo,
if(acctside='DEBIT',netbaseamount,0.00) as CHARGES,  
if(acctside='CREDIT',netbaseamount,0.00) as CREDIT
from 
foliotransactions 
WHERE 
folioid=pfolioid and foliotransactions.status = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportIndividualGuestSubReport` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportIndividualGuestSubReport` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportIndividualGuestSubReport`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportInHouseGroups` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportInHouseGroups` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportInHouseGroups`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select distinct
folio.folioid,
(folio.noofadults + folio.noofchild) as noofadults,
folio.accountid,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as GuestName,
event_booking_info.contactAddress as Address1,
event_booking_info.contactNumber as telephoneNo,
'' as citizenship,
folioschedules.ratetype as account_type,
folioschedules.roomid,
folioschedules.rate,
folio.remarks,
folioschedules.fromdate AS arrivaldate,
folioschedules.todate AS departuredate,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), folio.groupname) as companyname,
rooms.floor,
folio.folioType,
folioschedules.breakfast
from
event_booking_info,
folio,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid
where
event_booking_info.folioid = folio.folioid and
folioschedules.folioid = folio.folioid and
folio.status = 'ONGOING' and
(pAuditDate >= date(folioschedules.todate) or pAuditDate <= date(folioschedules.todate)) and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid and foliotype='GROUP' group by folio.folioid
order by folioschedules.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportInHouseGuestList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportInHouseGuestList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportInHouseGuestList`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select 	distinct
folio.folioid,
(folio.noofadults + folio.noofchild) as noofadults,
folio.accountid,
concat(guests.lastname," , ",guests.firstname) as GuestName,
concat(guests.street,", ",guests.city, ", ",guests.country) as Address1,
guests.telephoneNo,
guests.citizenship,
folioschedules.ratetype as account_type,
folioschedules.roomid,
folioschedules.rate,
folio.remarks,
folioschedules.fromdate AS arrivaldate,
folioschedules.todate AS departuredate,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), folio.groupname) as companyname,
rooms.floor,
folio.folioType,
folioschedules.breakfast
from
guests,
folio,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
folio.status = 'ONGOING' and
(pAuditDate between date(folioschedules.fromdate) and date(folioschedules.todate)) and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid and foliotype!='GROUP'
order by folioschedules.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportInHouseGuests` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportInHouseGuests` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportInHouseGuests`(
in photelid int(5),
in pAuditDate date
)
BEGIN
set sql_big_selects=1;
select 	distinct
folio.folioid,
(folio.noofadults + folio.noofchild) as noofadults,
folio.accountid,
if(foliotype='GROUP', if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)), fGetGuestName(folio.accountid)) as GuestName,
'' as Address1,
'' as telephoneNo,
'' as citizenship,
folioschedules.ratetype as account_type,
if(foliotype='NON-STAYING', '', folioschedules.roomid) as roomid,
folioschedules.rate,
folio.remarks,
folioschedules.fromdate AS arrivaldate,
folioschedules.todate AS departuredate,
if(substring(folio.companyid,1,1)='G', fGetCompanyName(folio.companyid), folio.groupname) as companyname,
rooms.floor,
folio.folioType,
folioschedules.breakfast
from
folio,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid
where
if(foliotype='NON-STAYING', true, folioschedules.folioid = folio.folioid) and
folio.status = 'ONGOING' and
if(foliotype='NON-STAYING' or foliotype='GROUP', true, (pAuditDate between date(folioschedules.fromdate) and date(folioschedules.todate)))
group by folioid order by roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportLOP` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportLOP` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportLOP`(
pFolioId varchar(30),
pHotelId int
)
BEGIN
select cast((select group_concat(distinct if(date_format(fromdate,'%b') = date_format(todate,'%b'), if(date_format(fromdate,'%e') = date_format(todate,'%e'), date_format(todate,'%b %e %Y'), concat(date_format(fromdate,'%b %e'),'-',date_format(todate,'%e %Y'))), concat(date_format(fromdate,'%b %e %Y'),'-',date_format(todate,'%b %e %Y')))) from folioschedules where folioId = folio.folioId and hotelId = pHotelId) as char) as eventDate, (select group_concat(RoomDescription) from folioschedules left join rooms on rooms.roomid = folioschedules.RoomID where folioId = folio.folioId and folioschedules.hotelId = pHotelId) as Rooms, if(concat(users.FirstName, ' ', users.LastName) is null,'',concat(users.FirstName, ' ', users.LastName)) as mo from folio left join users on folio.sales_executive = users.userid where folio.hotelId = pHotelId and folio.folioid = pFolioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportLostBusiness` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportLostBusiness` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportLostBusiness`(
pStartDate date,
pEndDate date,
pHotelId int
)
BEGIN
select groupName as event, (select group_concat(RoomID) from folioschedules where folioId = folio.folioId and hotelId = pHotelId) as venue, if(event_endorsement.contractAmount is null,0.00,event_endorsement.contractAmount) as estRevenue, cast((select group_concat(distinct if(date_format(fromdate,'%b') = date_format(todate,'%b'), if(date_format(fromdate,'%e') = date_format(todate,'%e'), date_format(todate,'%b %e'), concat(date_format(fromdate,'%b %e'),'-',date_format(todate,'%e'))), concat(date_format(fromdate,'%b %e'),'-',date_format(todate,'%b %e')))) from folioschedules where folioId = folio.folioId and hotelId = pHotelId) as char) as `date`  , date_format(folio.createTime,'%e-%b-%y') as bookingDate, date_format(folio.updateTime,'%e-%b-%y') as cancelDate, folio.purpose as marketsegment, event_booking_info.eventtype, if(folio.cancelBookingType is null,'',folio.cancelBookingType) as cancelBookingType, if(substring(folio.companyID,1,1) = 'G',(select companyname as organizer from company where folio.companyID = company.companyID and hotelId = pHotelId)  ,(select concat(firstname, ' ', lastname) as organizer from guests where folio.companyID = guests.accountid and hotelId = pHotelId)) as organizer, if(folio.reasonType is null, '', folio.reasonType) as reasonType, folio.reason_for_cancel as reason, if(concat(users.FirstName, ' ', users.LastName) is null,'',concat(users.FirstName, ' ', users.LastName)) as mo from folio left join event_endorsement on folio.folioId = event_endorsement.folioId left join event_booking_info on folio.folioId = event_booking_info.folioId left join users on folio.sales_executive = users.userid where folio.fromDate >= pStartDate and folio.fromDate <= pEndDate and folio.hotelId = pHotelId and folio.status = 'CANCELLED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyActualGuestsArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyActualGuestsArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyActualGuestsArrival`(
in photelid int(5),
in pMonth int,
in pYear int
)
BEGIN
select 
folio.folioid,
guests.accountid,
guests.account_type,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folioschedules.roomid, 
folioschedules.roomtype,
folio.arrivalDate,
folio.DepartureDate,
folio.noOfadults as Pax,
folio.remarks,
folioschedules.todate as departure,
folioschedules.fromdate as arrival,
company.companyname,
fGetFolioBalance(folio.FolioId) as Balance,
rooms.floor
from
guests,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid,
folio left join company on company.companyid = folio.companyid
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
(month(folio.arrivaldate) = pMonth and year(folio.arrivaldate) = pYear) and
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid and folioschedules.roomtype!='FUNCTION';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyActualGuestsDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyActualGuestsDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyActualGuestsDeparture`(
in photelid int(5),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select 
folio.folioid,
guests.accountid,
guests.account_type,
concat(guests.lastname,", ",guests.firstname) as GuestName,
folio.remarks,
folioschedules.days,
folioschedules.roomid, folioschedules.roomtype,
folioschedules.fromdate,
date(folio.todate) as todate,
folio.arrivaldate,
folio.departuredate,
folio.noOfadults as Pax,
company.companyname,
fGetFolioBalance(folio.FolioId) as Balance,
rooms.floor
from
guests,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid,
folio
left join company on company.companyid = folio.companyid
where
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and
(month(folio.departuredate) = pMonth and year(folio.departuredate) = pYear) and
folio.status = 'CLOSED' and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid and folioschedules.roomtype!='FUNCTION';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyCancelledReservations` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyCancelledReservations` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyCancelledReservations`(
in pHotelID int(5),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select
folio.folioid,
if(folio.foliotype!='GROUP', folio.accountid, folio.companyid) as accountid,
if(folio.foliotype!='GROUP', fGetGuestName(folio.accountid), concat(folio.groupname, ' (', (if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid))), ')')) as GuestName,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.roomid) as roomid, 
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.roomtype) as roomtype,
folio.remarks,
folio.noofadults,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.days) as days,
if (folioschedules.roomid is null or folioschedules.roomid='', '', folioschedules.rate) as rate,
folio.fromdate,
folio.todate as departure,
folio.reason_for_cancel,
folio.updatetime
from
folio left join folioschedules on (folioschedules.folioid = folio.folioid)
where
( month(folio.updatetime) = pMonth and
year(folio.updatetime) = pYear ) and
(folio.status = 'CANCELLED' or folio.status = 'NO SHOW') and
folio.hotelid = photelid and foliotype!='DEPENDENT' and foliotype != 'JOINER';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyCashierTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyCashierTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyCashierTransactions`(
in pHotelId int(5),
in pMonth int,
in pYear int
)
BEGIN
set sql_big_selects =1;
(
select
cashiers_logs.terminalid as Terminal,
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
cashiers_logs.remarks,
cashiers_logs.adjustment,
cashiers_logs.netamount,
cashiers_logs.amountremitted,
cashiers_logs.updatedby,
foliotransactions.transactionDate,
foliotransactions.referenceno,
concat(folioschedules.roomid,'  ',guests.lastname,', ',guests.firstname) as TransactionSource,
foliotransactions.transactioncode,
foliotransactions.memo,
foliotransactions.`status`,
foliotransactions.acctside,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT
from 	
transactioncode force index(primary),
cashiers_logs force index(primary)
left join foliotransactions force index(folioid) on foliotransactions.terminalid = cashiers_logs.terminalid and foliotransactions.shiftcode = cashiers_logs.shiftcode
left join folioschedules force index(folioid) on folioschedules.folioid = foliotransactions.folioid
left join guests force index(primary) on guests.accountid = foliotransactions.accountid
where
foliotransactions.transactioncode = transactioncode.trancode and 
cashiers_logs.hotelid = pHotelid and
(month(foliotransactions.transactionDate) = pMonth and 
year(foliotransactions.transactionDate) = pYear) and
cashiers_logs.type = 'CLOSE'
order by transactiondate
)
UNION(
select
nonguesttransaction.terminalID as Terminal,
nonguesttransaction.terminalID as cashierId,
nonguesttransaction.shiftCode,
0 as openingbalance,
0 as openingadjustment,
0 as beginningbalance,
0 as chargeinamount,
0 as cash,
0 as creditcard,
0 as cheque,	
0 as others,
"" as remarks,
0 as adjustment,
0 as netamount,
0 as amountremitted,
nonguesttransaction.updatedby,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
concat(nonguesttransaction.roomNumber," ",nonguesttransaction.guestName) as TransactionSource,
nonguesttransaction.transactionCode,
nonguesttransaction.memo,
nonguesttransaction.statusFlag as `status`,
nonguesttransaction.acctSide,
if(nonguesttransaction.acctside='DEBIT',nonguesttransaction.baseamount,0.00) as CHARGES,  
if(nonguesttransaction.acctside='CREDIT',nonguesttransaction.baseamount,0.00) as CREDIT
from nonguesttransaction
where
nonguesttransaction.hotelID = pHotelId and
(month(nonguesttransaction.transactionDate) = pMonth and 
year(nonguesttransaction.transactionDate) = pYear)
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyCityTransferTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyCityTransferTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyCityTransferTransactions`(
in pHotelId int(4),
in pMonth int,
in pYear int
)
BEGIN
select 
(select roomid from folioschedules where folioid=folio.folioid limit 1) as roomid,
foliotransactions.folioid,
foliotransactions.accountid,
fGetGuestName(folio.accountid) as GuestName,
folio.companyid,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
foliotransactions.postingdate,
foliotransactions.baseamount,
foliotransactions.updatedby
from foliotransactions left join folio on folio.folioid = foliotransactions.folioid
where foliotransactions.transactioncode='4200' and
(month(foliotransactions.transactiondate) = pMonth and 
year(foliotransactions.transactiondate) = pYear) and 
foliotransactions.hotelid = pHotelId
union
select roomNumber as roomID,
referenceFolioID as folioID,
accountID,
guestName,
accountID as companyID,
companyName,
postingdate,
baseamount,
updatedby
from nonguesttransaction
where transactioncode ='4200' and
(month(transactiondate) = pMonth and 
year(transactiondate) = pYear) and 
hotelid = pHotelId and
statusflag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyDriversSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyDriversSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyDriversSales`(pMonth int, pYear int, pHotelid int)
BEGIN
select drivers.*, netAmount as commission, transactiondate, referenceNo, referenceFolioId, accountId, roomNumber, guestName  from drivers, nonguesttransaction where referencedriverid=driverid and nonguesttransaction.hotelid=pHotelid and month(transactiondate) = pMonth and year(transactiondate) = pYear and statusflag!='VOID' order by lastname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyExecutive` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyExecutive` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyExecutive`(pMonth int, pYear int, pHotelID int(2), pSalesExecutive varchar(30))
BEGIN
if(pSalesExecutive!='ALL') then
select 
(fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'DEBIT', folioid) +
fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'DEBIT', folioid)) -
(fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('7', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'CREDIT', folioid)) as totalSales,sales_executive, folioid, 
if(foliotype='GROUP', concat(if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)), ' [', folio.groupname, ']'), concat(fGetGuestName(folio.accountid), ' [', folio.groupname, ']')) as companyName, 
source, arrivalDate as arrival, departureDate as departure from folio where sales_executive=pSalesExecutive and folio.status='CLOSED' and folio.foliotype!='JOINER' and 
month(departureDate)=pMonth and year(departureDate)=pYear
order by totalSales desc, sales_executive;
else
select 
(fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'DEBIT', folioid) +
fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'DEBIT', folioid)) -
(fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('7', pHotelID, 'A', 'CREDIT', folioid) +
fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'CREDIT', folioid)) as totalSales,sales_executive, folioid, if(foliotype='GROUP', concat(if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)), ' [', folio.groupname, ']'), concat(fGetGuestName(folio.accountid), ' [', folio.groupname, ']')) as companyName, source, arrivalDate as arrival, departureDate as departure from folio where folio.status='CLOSED' and folio.foliotype!='JOINER' and 
month(departureDate)=pMonth and year(departureDate)=pYear order by totalSales, sales_executive desc;
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyExpectedGuestsArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyExpectedGuestsArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyExpectedGuestsArrival`(
in photelid int(5),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select 
concat(guests.lastname, " , ", guests.firstname) as GuestName,
guests.memo,
folioschedules.roomid,
folioschedules.roomtype,
folioschedules.todate as departure,
FOLIO.remarks,
folioschedules.fromdate as arrival,
company.companyname,
(folio.noofadults + folio.noofchild) as pax,
rooms.floor
from 
guests,
folio left join company on company.companyid = folio.companyid,
folioschedules  left join rooms on folioschedules.roomid=rooms.roomid
where 
(folio.status != 'CANCELLED' and
folio.status != 'NO SHOW' and
folio.status != 'ONGOING' and
folio.status != 'CLOSED') and
guests.accountid = folio.accountid and
folioschedules.folioid = folio.folioid and 
( month(folioschedules.fromdate) = pMonth and year(folioschedules.fromdate) = pYear) and
guests.hotelid = folio.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid
order by folioschedules.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyExpectedGuestsDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyExpectedGuestsDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyExpectedGuestsDeparture`(
in photelid int(5),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select 
folio.folioid,
concat(guests.firstname,"  ",guests.lastname) as GuestName,
folioschedules.roomid,
folioschedules.roomtype,
folio.remarks,
rooms.floor
from 
guests,
folio,
folioschedules left join rooms on folioschedules.roomid=rooms.roomid
where 
guests.accountid = folio.accountid and
folio.folioid = folioschedules.folioid  and 
folio.status = 'ONGOING' and
( month(folioschedules.todate) = pMonth and 
year(folioschedules.todate) = pYear )
and
folio.hotelid = guests.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = pHotelID
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyGroupDeparture` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyGroupDeparture` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyGroupDeparture`(
in photelid int(5),
in pMonth int(2),
in pYear int(4))
BEGIN
select folio.folioid,
folio.companyid,
folio.accounttype,
folio.groupname as GuestName,
folioschedules.roomid,
folioschedules.roomtype,
folio.arrivaldate,
folio.departuredate,
folio.noofadults as pax,
folio.remarks,
date(folio.departuredate) as departure,
`folioschedules`.`FROMDATE` AS `arrival`,
if((substr(`folio`.`companyID`,1,1) = _latin1'G'),`fGetCompanyName`(`folio`.`companyID`),`fGetGuestName`(`folio`.`companyID`)) AS `companyname`,
`fGetFolioBalance`(`folio`.`folioID`) AS `Balance`,
`rooms`.`floor` AS `floor` 
from folio right join folioschedules on (folioschedules.FolioId = folio.folioID) left join rooms on (rooms.roomid = folioschedules.RoomID) where folio.folioType = 'GROUP' and folio.Status = 'CLOSED' and
(month(folio.departuredate) = pMonth and year(folio.departuredate) = pYear) and folio.hotelid=photelid order by folio.folioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyMealAmount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyMealAmount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyMealAmount`(
in pMonth int(5),
in pYear int(5),
in pHotelId int(5)
)
BEGIN
select 
date(foliotransactions.transactiondate) as transactiondate,
'1002' as transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.mealAmount * -1, foliotransactions.mealAmount)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
month(foliotransactions.transactiondate) = pMonth and
year(foliotransactions.transactiondate) = pYear and
foliotransactions.status = 'ACTIVE' and foliotransactions.transactioncode='1000'
group by foliotransactions.transactioncode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyOutOfOrderRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyOutOfOrderRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyOutOfOrderRooms`(
in pHotelId int(5),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select distinct
roomevents.eventdate,
roomevents.roomid,
engineeringjobs.assignedperson,
engineeringjobs.startdate,
engineeringjobs.starttime,
engineeringjobs.enddate,
engineeringjobs.endtime,
engineeringservices.servicename
from 
roomevents left join
engineeringjobs on engineeringjobs.roomid = roomevents.roomid
left join engineeringservices on 
engineeringservices.enggserviceid = engineeringjobs.enggserviceid
where 
eventtype = 'ENGINEERING JOB' and
(month(eventdate) = pMonth and year(eventdate) = pYear) and 
roomevents.hotelid = pHotelId
order by eventdate,roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyRoomOccupancyGraph` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyRoomOccupancyGraph` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyRoomOccupancyGraph`(
in pHotelId int(4),
in pMonth int(2),
in pYear int(4)
)
BEGIN
select roomevents.eventdate,((count(distinct roomevents.roomid)/FGetTotalRooms()) * 100) as Occupancy ,roomevents.eventtype from roomevents
where (roomevents.eventtype = "IN HOUSE" or roomevents.eventtype = "RESERVATION" or roomevents.eventtype = "CHECK OUT") and
month(roomevents.eventdate) = pMonth and year(roomevents.eventdate) = pYear
group by roomevents.eventdate,roomevents.eventtype
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlySales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlySales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlySales`(
in pHotelid int(5),
in pMonth int(2),
in pYear int(4)
)
BEGIN
(
select
foliotransactions.transactiondate,
foliotransactions.folioid,
foliotransactions.referenceno, 
foliotransactions.netamount,
foliotransactions.updatetime,
foliotransactions.transactionsource,
folioschedules.updatedby,
folioschedules.roomid,
concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE,
concat(guests.lastname,", ",guests.firstname) as GuestName
from 	foliotransactions
left join guests on guests.accountid = foliotransactions.accountid,
folioschedules,
transactioncode,
trantypes 
where 	
folioschedules.folioid = foliotransactions.folioid and
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
trantypes.trantypeid = '1' and
( month(transactiondate) = pMonth and Year(transactiondate) = pYear) and
folioschedules.hotelid = foliotransactions.hotelid and
transactioncode.hotelid = foliotransactions.hotelid and
trantypes.hotelid = foliotransactions.hotelid and
foliotransactions.hotelid = photelid and
foliotransactions.status = 'ACTIVE'
order by transactiondate
)
UNION
(
select
nonguesttransaction.transactiondate,
nonguesttransaction.referenceFolioId as folioid,
nonguesttransaction.referenceNo, 
nonguesttransaction.netamount,
nonguesttransaction.updatedDate as updateTime,
nonguesttransaction.transactionSource,
nonguesttransaction.updatedby,
nonguesttransaction.roomNumber as roomid,
concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE,
nonguesttransaction.guestName as GuestName
from 
nonguesttransaction force index(primary)
left join transactioncode on transactioncode.trancode = nonguesttransaction.transactionCode 
left join trantypes on transactioncode.trantypeid = trantypes.trantypeid
where 
nonguesttransaction.acctSide = 'DEBIT' and
trantypes.trantypeid = '1' and
( month(transactionDate) = pMonth and Year(transactionDate) = pYear) and
nonguesttransaction.hotelid = pHotelid and
nonguesttransaction.statusflag = 'ACTIVE'
order by transactiondate
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlySalesProduction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlySalesProduction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlySalesProduction`(pMonth int(5), pYear int(5), pHotelID int(5))
BEGIN
select date_format(fromdate, '%d-%b-%Y') as fromDate, date_format(todate, '%d-%b-%Y') as toDate, folio.folioid, if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName, groupname, eventType, (fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'DEBIT', folio.folioid) +
fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'DEBIT', folio.folioid)) -
(fGetFolioTransferDebitForSalesExecutive('4100', pHotelID, 'A', 'CREDIT', folio.folioid) +
fGetTotalFolioAmountForSalesExecutive('7', pHotelID, 'A', 'CREDIT', folio.folioid) +
fGetTotalFolioAmountForSalesExecutive('1', pHotelID, 'A', 'CREDIT', folio.folioid)) as packageAmount, if(folio.status='CANCELLED', 'LOST/UNREALIZED', if(folio.status='CLOSED' or folio.status='ONGOING', 'REALIZED', folio.status)) as `status`, reason_for_cancel as reason
from folio left join event_booking_info on (folio.folioid=event_booking_info.folioid) where foliotype='GROUP' and month(fromdate)=pMonth and year(fromdate)=pYear and folio.hotelid=pHotelId
order by `status`, fromdate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlySalesSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlySalesSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlySalesSummary`(
in pHotelid int(5),
in pMonth int,
in pYear int
)
BEGIN
(
select transactioncode, sum(baseamount) as BaseAmount, 
sum(grossAmount) as GrossAmount, 
sum(netAmount) as NetAmount, 
sum(netbaseamount) as NetBaseAmount, 
sum(discount) as Discount, 
sum(govttax) as GovtTax, 
sum(mealamount) as MealAmount, 
sum(localtax) as LocalTax, 
sum(servicecharge) as ServiceCharge, 
sum(transactioncount) as TransactionCount, 
TransactionDescription, 
acctside, 
sum(monthtodate) as MonthToDate, 
sum(yeartodate) as YearToDate 
from
(select 
foliotransactions.transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.baseAmount * -1, foliotransactions.baseAmount)) as BaseAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as GrossAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netAmount * -1, foliotransactions.netAmount)) as NetAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netBaseAmount * -1, foliotransactions.netBaseAmount)) as NetBaseAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.discount * -1, foliotransactions.discount)) as Discount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.governmentTax * -1, foliotransactions.governmentTax)) as GovtTax,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.mealAmount * -1, foliotransactions.mealAmount)) as MealAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.localtax * -1, foliotransactions.localtax)) as LocalTax,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.servicecharge * -1, foliotransactions.servicecharge)) as ServiceCharge,
count(foliotransactions.transactioncode) as TransactionCount,
transactioncode.memo as TransactionDescription,
transactioncode.acctside,
fGetTransactionNetBaseAmountMonthToDate(
foliotransactions.transactioncode,
foliotransactions.acctside,
foliotransactions.transactionDate,
pHotelId
) as MonthToDate,
fGetTransactionNetBaseAmountYearToDate(
foliotransactions.transactioncode,
foliotransactions.acctside,
transactionDate,
pHotelId
) as YearToDate
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
month(transactiondate) = pMonth and
year(transactiondate) = pYear and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactioncode,foliotransactions.acctside
UNION all
select 
nonguesttransaction.transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.baseAmount * -1, nonguesttransaction.baseAmount)) as BaseAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.grossAmount * -1, nonguesttransaction.grossAmount)) as GrossAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netAmount * -1, nonguesttransaction.netAmount)) as NetAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netBaseAmount * -1, nonguesttransaction.netBaseAmount)) as NetBaseAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.discount * -1, nonguesttransaction.discount)) as Discount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.governmentTax * -1, nonguesttransaction.governmentTax)) as GovtTax,
0 as MealAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.localtax * -1, nonguesttransaction.localtax)) as LocalTax,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.servicecharge * -1, nonguesttransaction.servicecharge)) as ServiceCharge,
count(nonguesttransaction.transactioncode) as TransactionCount,
concat(transactioncode.memo, "-WALK IN") as TransactionDescription,
transactioncode.acctside,
fGetNonGuestTransactionNetBaseAmountMonthToDate(
nonguesttransaction.transactioncode,
nonguesttransaction.acctside,
nonguesttransaction.transactionDate,
pHotelId
)  as MonthToDate,
fGetNonGuestTransactionNetBaseAmountYearToDate(
nonguesttransaction.transactioncode,
nonguesttransaction.acctside,
transactionDate,
pHotelId
)  as YearToDate
from
nonguesttransaction  force index(primary),
transactioncode force index(primary)
where 	
month(transactiondate) = pMonth and
year(transactiondate) = pYear and
nonguesttransaction.statusFlag = 'ACTIVE' and
nonguesttransaction.transactioncode=transactioncode.trancode
group by nonguesttransaction.transactioncode,nonguesttransaction.acctside
) as TransactionTable group by transactionCode 
order by transactioncode asc, acctside desc);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlySalesSummary1` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlySalesSummary1` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlySalesSummary1`(
in pHotelid int(5),
in pMonth int,
in pYear int
)
BEGIN
select transactiondate, transactioncode, sum(netbaseamount) as NetBaseAmount, acctside from
(select 
date(foliotransactions.transactiondate) as transactiondate,
foliotransactions.transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netBaseAmount * -1, foliotransactions.netBaseAmount)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary),
trantypes  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
month(foliotransactions.transactiondate) = pMonth and
year(foliotransactions.transactiondate) = pYear and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactioncode,foliotransactions.acctside
UNION
select 
date(nonguesttransaction.transactiondate) as transactiondate,
nonguesttransaction.transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netBaseAmount * -1, nonguesttransaction.netBaseAmount)) as NetBaseAmount,
transactioncode.acctside
from
nonguesttransaction  force index(primary), transactioncode
where 	
month(nonguesttransaction.transactiondate) = pMonth and
year(nonguesttransaction.transactiondate) = pYear and
nonguesttransaction.statusFlag = 'ACTIVE' and nonguesttransaction.transactioncode=transactioncode.trancode
group by nonguesttransaction.transactioncode,nonguesttransaction.acctside
) as foliotransactions group by transactioncode, acctside order by transactioncode asc, acctside desc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlySalesSummaryBySubAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlySalesSummaryBySubAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlySalesSummaryBySubAccount`(
in pHotelid int(5),
in pMonth int,
in pYear int
)
BEGIN
(
select 
foliotransactions.subaccount,
if(foliotransactions.acctside = "DEBIT",
SUM(foliotransactions.baseamount),0) as DEBIT,
if(foliotransactions.acctside = "CREDIT",
SUM(foliotransactions.baseamount),0) as CREDIT,
count(foliotransactions.transactioncode) as Trans,
concat(transactioncode.trancode," - ",transactioncode.memo) as TRANCODE,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary),
trantypes  force index(primary)
where 	
foliotransactions.subaccount != "" and
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
month(foliotransactions.transactiondate) = pMonth and
year(foliotransactions.transactiondate) = pYear
group by foliotransactions.subaccount,foliotransactions.acctside
order by foliotransactions.subaccount asc, foliotransactions.acctside desc
)
UNION
(
select 
nonguesttransaction.subaccount,
if(nonguesttransaction.acctside = "DEBIT",
SUM(nonguesttransaction.baseamount),0) as DEBIT,
if(nonguesttransaction.acctside = "CREDIT",
SUM(nonguesttransaction.baseamount),0) as CREDIT,
count(nonguesttransaction.transactioncode) as Trans,
concat(nonguesttransaction.transactionCode," - ",nonguesttransaction.memo, " - WALK IN") as TRANCODE,
nonguesttransaction.acctside
from
nonguesttransaction  force index(primary)
where 	
nonguesttransaction.subaccount != "" and
month(nonguesttransaction.transactiondate) = pMonth and
year(nonguesttransaction.transactiondate) = pYear
group by nonguesttransaction.subaccount,nonguesttransaction.acctside
order by nonguesttransaction.subaccount asc, nonguesttransaction.acctside desc
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyTransactionRegister` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyTransactionRegister` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyTransactionRegister`(
in pHotelId int(4),
in pMonth int(4),
in pYear int(4)
)
BEGIN
(
select
foliotransactions.postingDate,
foliotransactions.transactiondate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource` as ReferenceType,
foliotransactions.`FolioID`,
guests.accountid,
concat(guests.`lastname`,", " , guests.`firstname`) as GuestName,
foliotransactions.transactioncode,
foliotransactions.`Memo`,
if(AcctSide='DEBIT',foliotransactions.`netbaseamount`,0.00) as DEBIT,
if(AcctSide='CREDIT',foliotransactions.`netbaseamount`,0.00) as CREDIT,
foliotransactions.`CREATEDBY`,
(select roomid from folioschedules where folioid=foliotransactions.folioid limit 1) as roomid,
(select roomtype from folioschedules where folioid=foliotransactions.folioid limit 1) as roomtype,
if(foliotype="DEPENDENT", folio.groupname, company.companyName) as companyName,
fGetTransactionDescription(foliotransactions.transactioncode) as description
from
foliotransactions
left join folio on foliotransactions.folioid = folio.folioid
left join company on folio.companyid = company.companyid,
`guests`
where
foliotransactions.`AccountID`=guests.`accountid`
and 
month(foliotransactions.`TransactionDate`) = pMonth and
year(foliotransactions.`TransactionDate`) = pyear and
foliotransactions.Status='ACTIVE'
order by folioschedules.roomid
)
UNION
(
select 
nonguesttransaction.postingDate,
nonguesttransaction.transactiondate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource as ReferenceType,
nonguesttransaction.referenceFolioId as `FolioID`,
nonguesttransaction.accountId,
nonguesttransaction.guestName as GuestName,
nonguesttransaction.transactioncode,
nonguesttransaction.`Memo`,
if(AcctSide='DEBIT',nonguesttransaction.netamount,0.00) as DEBIT,
if(AcctSide='CREDIT',nonguesttransaction.netamount,0.00) as CREDIT,
nonguesttransaction.`CREATEDBY`,
nonguesttransaction.roomNumber as roomid,
"" as roomtype,
nonguesttransaction.companyName,
fGetTransactionDescription(nonguesttransaction.transactioncode) as description
from
nonguesttransaction force index(primary)
where
month(nonguesttransaction.transactionDate) = pMonth and
year(nonguesttransaction.transactionDate) = pyear
order by nonguesttransaction.roomNumber
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyTransactions`(
in photelid int(5),
in pMonth int(4),
in pYear int(4)
)
BEGIN
select 	
foliotransactions.*,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT,
folioschedules.roomid,
concat(guests.lastname,", ",guests.firstname) as GuestName
from foliotransactions 
left join folioschedules on foliotransactions.folioid = folioschedules.folioid
left join guests on guests.accountid = foliotransactions.accountid
where
MONTH(transactiondate) = pMonth and
YEAR(transactiondate) = pYear and
foliotransactions.hotelid = photelid
order by `status`,transactiondate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportMonthlyVoidTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportMonthlyVoidTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportMonthlyVoidTransactions`(
in pHotelId int(4),
in pMonth int(2),
in pYear int(4)
)
BEGIN
(select
foliotransactions.postingDate,
foliotransactions.transactiondate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource` as ReferenceType,
foliotransactions.`FolioID`,
concat(guests.`lastname`,", " , guests.`firstname`) as GuestName,
foliotransactions.transactioncode,
foliotransactions.`Memo`,
if(AcctSide='DEBIT',foliotransactions.netAmount,0.00) as DEBIT,
if(AcctSide='CREDIT',foliotransactions.netAmount,0.00) as CREDIT,
foliotransactions.`UPDATEDBY` as CREATEDBY,
folioschedules.roomid,
company.companyName
from
foliotransactions
left join folioschedules on folioschedules.folioid = foliotransactions.folioid
left join folio on folioschedules.folioid = folio.folioid
left join company on folio.companyid = company.companyid,
`guests`
where
foliotransactions.`AccountID`=guests.`accountid` and
( month(foliotransactions.transactiondate) = pMonth and 
year(foliotransactions.transactiondate) = pYear) and
foliotransactions.Status='VOID'
order by folioschedules.roomid
)
UNION
(
select
nonguesttransaction.postingDate,
nonguesttransaction.transactiondate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource as ReferenceType,
nonguesttransaction.referenceFolioId as FolioID,
nonguesttransaction.guestName as GuestName,
nonguesttransaction.transactioncode,
nonguesttransaction.`Memo`,
if(AcctSide='DEBIT', nonguesttransaction.netAmount,0.00) as DEBIT,
if(AcctSide='CREDIT',nonguesttransaction.netAmount,0.00) as CREDIT,
nonguesttransaction.`UPDATEDBY` as CREATEDBY,
nonguesttransaction.roomNumber as roomid,
nonguesttransaction.companyName
from
nonguesttransaction force index(primary)
where
nonguesttransaction.statusFlag = 'VOID' and
( month(nonguesttransaction.transactiondate) = pMonth and 
year(nonguesttransaction.transactiondate) = pYear)
order by nonguesttransaction.roomNumber
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportOutOfOrderRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportOutOfOrderRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportOutOfOrderRooms`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select distinct
roomevents.eventdate,
roomevents.roomid,
engineeringjobs.assignedperson,
engineeringjobs.startdate,
engineeringjobs.starttime,
engineeringjobs.enddate,
engineeringjobs.endtime,
engineeringservices.servicename
from 
roomevents left join
engineeringjobs on engineeringjobs.enggjobno = roomevents.EventID
left join engineeringservices on 
engineeringservices.enggserviceid = engineeringjobs.enggserviceid
where 
eventtype = 'ENGINEERING JOB' and
(date(eventdate) = pAuditDate ) and 
roomevents.hotelid = pHotelId
order by eventdate,roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportParamCityTransferTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportParamCityTransferTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportParamCityTransferTransactions`(
in pHotelId int(4),
in pStartDate date,
in pEndDate date
)
BEGIN
select 
(select roomid from folioschedules where folioid=folio.folioid limit 1) as roomid,
foliotransactions.folioid,
foliotransactions.accountid,
fGetGuestName(folio.accountid) as GuestName,
folio.companyid,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
foliotransactions.postingdate,
foliotransactions.baseamount,
foliotransactions.updatedby
from foliotransactions left join folio on folio.folioid = foliotransactions.folioid
where foliotransactions.transactioncode ='4200' and
(date(foliotransactions.transactiondate) >= pStartDate and 
date(foliotransactions.transactiondate) <= pEndDate) and 
foliotransactions.hotelid = pHotelId and
foliotransactions.status = 'ACTIVE'
union
select roomNumber as roomID,
referenceFolioID as folioID,
accountID,
guestName,
accountID as companyID,
companyName,
postingdate,
baseamount,
updatedby
from nonguesttransaction
where transactioncode ='4200' and
(date(transactiondate) >= pStartDate and 
date(transactiondate) <= pEndDate) and 
hotelid = pHotelId and
statusflag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportParamInHouseGuestsForecast` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportParamInHouseGuestsForecast` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportParamInHouseGuestsForecast`(
in photelid int(5),
in pReportDate date
)
BEGIN
select distinct
folio.folioid,
folio.noofadults,
fGetGuestName(folio.accountid) as GuestName,
folioschedules.roomid,
folioschedules.rate,
folio.status,
folio.remarks,
folio.fromdate AS arrivaldate,
folio.todate AS departuredate,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
rooms.floor,
folio.folioType,
(select eventtype from event_booking_info where folioid=folio.folioid) as EventType,
(select noOfPaxLiveOut from event_booking_info where folioid=folio.folioid) as totalAttendees
from
folio,
folioschedules left join rooms on rooms.roomid = folioschedules.roomid
where
folioschedules.folioid = folio.folioid and
(folio.status = 'ONGOING' or folio.status = 'CONFIRMED' or folio.status = 'WAIT LIST' or folio.status = 'TENTATIVE' or folio.status = 'CLOSED') and
if (folioschedules.roomtype = 'FUNCTION' and pReportDate <= (select auditdate from auditdatetable where meridian='AM'), ((pReportDate > date(folioschedules.todate) and folio.status!='CLOSED') or (pReportDate >= date(folioschedules.fromdate) and pReportDate < date(folioschedules.todate))), (pReportDate >= date(folioschedules.fromdate) and pReportDate < date(folioschedules.todate))) and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid group by folioid
union 
select distinct 
roomblock.folioid,
0 as noofadults,
fGetGuestName(folio.accountid) as GuestName,
blockingdetails.roomid,
0 as rate,
'BLOCKED' as `status`,
'' as remarks,
blockingdetails.blockfrom AS arrivaldate,
blockingdetails.blockto AS departuredate,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,
'' as `floor`,
'DEPENDENT' as foliotype,
'' as EventType,
0 as totalAttendees
from roomblock, blockingdetails, folio where roomblock.blockid=blockingdetails.blockid and roomblock.folioid!='' and folio.folioid=roomblock.folioid and (pReportDate >= date(blockfrom) and pReportDate < date(blockto))
order by `status`, roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportParamTransactionRegister` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportParamTransactionRegister` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportParamTransactionRegister`(pHotelId int(4),
pStartDate date,
pEndDate date
)
BEGIN
(
select
foliotransactions.postingDate,
foliotransactions.transactionDate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource` as ReferenceType,
foliotransactions.`FolioID`,
if(folio.foliotype='GROUP', folio.companyid, folio.accountid) as accountid,
if(folio.foliotype='GROUP', folio.groupname, fGetGuestName(folio.accountid)) as GuestName,
if(foliotransactions.status='VOID', 'VOID',foliotransactions.transactioncode) as transactioncode,
if(foliotransactions.status='VOID', 'VOIDED TRANSACTIONS', foliotransactions.memo) as TransactionDescription,
foliotransactions.baseAmount,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-foliotransactions.grossAmount,foliotransactions.grossAmount) as grossAmount,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-foliotransactions.discount,foliotransactions.discount) as discount,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-foliotransactions.servicecharge,foliotransactions.servicecharge) as serviceCharge,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-(foliotransactions.governmentTax + 
foliotransactions.localTax),foliotransactions.governmentTax + 
foliotransactions.localTax) as Tax,
foliotransactions.governmentTax,
foliotransactions.localTax,
foliotransactions.mealAmount,
foliotransactions.`Memo`,
foliotransactions.subFolio,
foliotransactions.netAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,0.00) as DEBIT,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`netBaseAmount`,0.00) as CREDIT,
foliotransactions.`CREATEDBY`,
(select roomid from folioschedules where folioid=foliotransactions.folioid limit 1) as roomid,
(select roomtype from folioschedules where folioid=foliotransactions.folioid limit 1) as roomtype,
if(foliotype="DEPENDENT", folio.groupname, company.companyName) as companyName,
fGetTransactionDescription(foliotransactions.transactioncode) as description
from
foliotransactions
left join transactioncode on transactioncode.tranCode = foliotransactions.transactioncode
left join folio on foliotransactions.folioid = folio.folioid
left join company on folio.companyid = company.companyid
left join guests on guests.accountid = folio.accountid
where
date(foliotransactions.`TransactionDate`) >= pStartDate and 
date(foliotransactions.`TransactionDate`) <= pEndDate
)
UNION
(
select
nonguesttransaction.postingDate,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource as ReferenceType,
nonguesttransaction.referenceFolioId as FolioId,
nonguesttransaction.accountId,
if(nonguesttransaction.guestName="","WALK-IN GUEST",nonguesttransaction.guestName) as GuestName,
if(nonguesttransaction.statusFlag='VOID', 'VOID',nonguesttransaction.transactioncode) as transactioncode,
if(nonguesttransaction.statusFlag='VOID', 'VOIDED TRANSACTIONS', nonguesttransaction.memo) as TransactionDescription,
nonguesttransaction.baseAmount,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-nonguesttransaction.grossAmount,nonguesttransaction.grossAmount) as grossAmount,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-nonguesttransaction.discount,nonguesttransaction.discount) as discount,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-nonguesttransaction.servicecharge,nonguesttransaction.servicecharge) as serviceCharge,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-(nonguesttransaction.governmentTax + 
nonguesttransaction.localTax),nonguesttransaction.governmentTax + 
nonguesttransaction.localTax) as Tax,
nonguesttransaction.governmentTax,
nonguesttransaction.localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
nonguesttransaction.netAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netAmount,0.00) as DEBIT,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.netAmount,0.00) as CREDIT,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
"" as roomtype,
nonguesttransaction.companyName,
fGetTransactionDescription(nonguesttransaction.transactioncode) as description
from nonguesttransaction force index(primary)
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
where
date(nonguesttransaction.transactionDate) >= pStartDate and 
date(nonguesttransaction.`TransactionDate`) <= pEndDate and
nonguesttransaction.hotelID = pHotelId
)
order by transactionCode, ReferenceType, ReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportParamTransactionRegister_IAL` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportParamTransactionRegister_IAL` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportParamTransactionRegister_IAL`(
pHotelId int(4),
pStartDate date,
pEndDate date
)
BEGIN
(
select
foliotransactions.postingDate,
foliotransactions.transactionDate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource` as ReferenceType,
foliotransactions.`FolioID`,
if(folio.foliotype='GROUP', folio.companyid, folio.accountid) as accountid,
if(folio.foliotype='GROUP', folio.groupname, fGetGuestName(folio.accountid)) as GuestName,
if(foliotransactions.status='VOID', 'VOID',foliotransactions.transactioncode) as transactioncode,
if(foliotransactions.status='VOID', 'VOIDED TRANSACTIONS', foliotransactions.memo) as TransactionDescription,
foliotransactions.baseAmount,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-foliotransactions.grossAmount,foliotransactions.grossAmount) as grossAmount,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-foliotransactions.discount,foliotransactions.discount) as discount,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-foliotransactions.servicecharge,foliotransactions.servicecharge) as serviceCharge,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-(foliotransactions.governmentTax + 
foliotransactions.localTax),foliotransactions.governmentTax + 
foliotransactions.localTax) as Tax,
foliotransactions.governmentTax,
foliotransactions.localTax,
foliotransactions.mealAmount,
foliotransactions.`Memo`,
foliotransactions.subFolio,
foliotransactions.netAmount,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,0.00) as DEBIT,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`netBaseAmount`,0.00) as CREDIT,
foliotransactions.`CREATEDBY`,
(select roomid from folioschedules where folioid=foliotransactions.folioid limit 1) as roomid,
(select roomtype from folioschedules where folioid=foliotransactions.folioid limit 1) as roomtype,
if(foliotype="DEPENDENT", folio.groupname, company.companyName) as companyName,
fGetTransactionDescription(foliotransactions.transactioncode) as description,
cast((select group_concat(RateType) from folioschedules where folioschedules.FolioId = folio.folioid and folioschedules.HotelId = pHotelId) as char) as rate
from
foliotransactions
left join transactioncode on transactioncode.tranCode = foliotransactions.transactioncode
left join folio on foliotransactions.folioid = folio.folioid
left join company on folio.companyid = company.companyid
left join guests on guests.accountid = folio.accountid
where
date(foliotransactions.`TransactionDate`) >= pStartDate and 
date(foliotransactions.`TransactionDate`) <= pEndDate
)
UNION
(
select
nonguesttransaction.postingDate,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource as ReferenceType,
nonguesttransaction.referenceFolioId as FolioId,
nonguesttransaction.accountId,
if(nonguesttransaction.guestName="","WALK-IN GUEST",nonguesttransaction.guestName) as GuestName,
if(nonguesttransaction.statusFlag='VOID', 'VOID',nonguesttransaction.transactioncode) as transactioncode,
if(nonguesttransaction.statusFlag='VOID', 'VOIDED TRANSACTIONS', nonguesttransaction.memo) as TransactionDescription,
nonguesttransaction.baseAmount,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-nonguesttransaction.grossAmount,nonguesttransaction.grossAmount) as grossAmount,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-nonguesttransaction.discount,nonguesttransaction.discount) as discount,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-nonguesttransaction.servicecharge,nonguesttransaction.servicecharge) as serviceCharge,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-(nonguesttransaction.governmentTax + 
nonguesttransaction.localTax),nonguesttransaction.governmentTax + 
nonguesttransaction.localTax) as Tax,
nonguesttransaction.governmentTax,
nonguesttransaction.localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
nonguesttransaction.netAmount,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netAmount,0.00) as DEBIT,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.netAmount,0.00) as CREDIT,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
"" as roomtype,
nonguesttransaction.companyName,
fGetTransactionDescription(nonguesttransaction.transactioncode) as description,
cast((select group_concat(RateType) from folioschedules where folioschedules.FolioId = nonguesttransaction.referenceFolioId and folioschedules.HotelId = pHotelId) as char) as rate
from nonguesttransaction force index(primary)
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
where
date(nonguesttransaction.transactionDate) >= pStartDate and 
date(nonguesttransaction.`TransactionDate`) <= pEndDate and
nonguesttransaction.hotelID = pHotelId
)
order by transactionCode, ReferenceType, ReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportRestaurantLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportRestaurantLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportRestaurantLedger`(
in pAuditDate date,
in pHotelId int(5)
)
BEGIN
select * from restaurantLedger where `date` = pAuditdate
and hotelid = pHotelId and posttoacctng = 0;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportRoomAvailability` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportRoomAvailability` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportRoomAvailability`(
in photelid int(5)
)
BEGIN
select roomid,roomtypecode,stateflag,cleaningstatus,`floor` from rooms
where stateflag = 'VACANT' and hotelid = photelid
order by roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportRoomCleaningStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportRoomCleaningStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportRoomCleaningStatus`(
in pAuditDate date,
in pHotelId int(4)
)
BEGIN
select 
rooms.floor,
rooms.roomid,
rooms.roomtypecode,
if(fGetRoomEngineeringJobDescription(pAuditDate,rooms.roomid) is null, rooms.cleaningstatus, "OUT OF ORDER") as cleaningstatus,
if(fGetRoomEngineeringJobDescription(pAuditDate,rooms.roomid) is null, rooms.stateflag, "-") as stateFlag,
fGetRoomEngineeringJobDescription(pAuditDate,rooms.roomid) as Remarks,
fGetRoomOccupancyStatus1(pAuditDate,rooms.roomid) as Status1,
fGetRoomOccupancyStatus2(pAuditDate,rooms.roomid) as Status2
from 
rooms
where 
rooms.stateflag <> 'DELETED' and
rooms.hotelid = photelid
order by rooms.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportRoomOccupancy` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportRoomOccupancy` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportRoomOccupancy`(
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
(eventtype = 'IN HOUSE' or eventtype = 'CLOSED') and 
roomevents.hotelid = photelid and
eventdate between pDateFrom and pDAteTo order by eventtype, eventid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportRoomOccupancyGraph` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportRoomOccupancyGraph` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportRoomOccupancyGraph`(
in pDate date
)
BEGIN
select roomevents.eventdate,((count(distinct roomevents.roomid)/FGetTotalRooms()) * 100) as Occupancy ,roomevents.eventtype from roomevents
where (roomevents.eventtype = "IN HOUSE" or roomevents.eventtype = "RESERVATION" or roomevents.eventtype = "CHECK OUT") and
date(roomevents.eventdate) = pDate
group by roomevents.eventdate,roomevents.eventtype
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportRoomRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportRoomRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportRoomRequirements`(pFolioID varchar(30))
BEGIN
select event_rooms.*, max(rate) as rate, days from event_rooms left join folio on (event_rooms.folioid=folio.masterfolio) left join folioschedules on (folioschedules.folioid=folio.folioid and event_rooms.roomtype=folioschedules.roomtype) where event_rooms.folioid=pFolioID group by event_rooms.roomtype;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportRoomTransfer` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportRoomTransfer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportRoomTransfer`(
in photelid int(5),
in pAuditDate date
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
(folio.status = 'ONGOING' or folio.status = 'CLOSED' or folio.status = 'CONFIRMED') and
date(folioschedules.todate) = pAuditDate and
folio.hotelid = guests.hotelid and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = photelid  and
exists(
select folioid
from folioschedules 
where date(fromdate) = pAuditDate and
folio.folioid = folioschedules.folioid
)
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportSales`(
in pTrandate date,
in pHotelid int(5)
)
BEGIN
(
select
foliotransactions.transactiondate,
foliotransactions.folioid,
foliotransactions.referenceno, 
foliotransactions.netamount,
foliotransactions.updatetime,
foliotransactions.transactionsource,
folioschedules.updatedby,
folioschedules.roomid,
concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE,
concat(guests.lastname,", ",guests.firstname) as GuestName
from 	foliotransactions
left join guests on guests.accountid = foliotransactions.accountid,
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
order by transactiondate
)
UNION
(
select
nonguesttransaction.transactiondate,
nonguesttransaction.referenceFolioId as folioid,
nonguesttransaction.referenceNo, 
nonguesttransaction.netamount,
nonguesttransaction.updatedDate,
nonguesttransaction.transactionSource,
nonguesttransaction.updatedby,
nonguesttransaction.roomNumber as roomid,
concat(transactioncode.trancode,"-",transactioncode.memo) as TRANCODE,
nonguesttransaction.guestName as GuestName
from 
nonguesttransaction force index(primary)
left join transactioncode on transactioncode.trancode = nonguesttransaction.transactionCode 
left join trantypes on transactioncode.trantypeid = trantypes.trantypeid
where 
nonguesttransaction.acctSide = 'DEBIT' and
trantypes.trantypeid = '1' and
date(transactiondate) = pTrandate and
nonguesttransaction.hotelid = pHotelid and
nonguesttransaction.statusflag = 'ACTIVE'
order by transactiondate
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportSalesAndMarketingRevenue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportSalesAndMarketingRevenue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportSalesAndMarketingRevenue`(
pStartDate date,
pEndDate date
)
BEGIN
select 
folio.folioid,
company.companyName,
concat(guests.firstname,' ', guests.lastname) as GuestName,
folio.status,
folioschedules.roomid,
folio.fromdate,
folio.todate,
datediff(folio.todate,folio.fromdate) as RoomNights,
folio.sales_executive,
folio.noOfAdults,
folio.noOfChild,
guests.citizenship,
folioschedules.roomtype,
folioschedules.ratetype,
sum(if(foliotransactions.transactionCode = '1000', foliotransactions.netbaseamount,0)) as '1000',
sum(if(foliotransactions.transactionCode = '1000', foliotransactions.mealAmount,0)) as 'BreakfastRevenue',
sum(if(foliotransactions.transactionCode = '1001', foliotransactions.netbaseamount,0)) as '1001',
sum(if(foliotransactions.transactionCode = '1201' and foliotransactions.subAccount != 'BANQUET', foliotransactions.netBaseAmount,0)) as '1201',
sum(if(foliotransactions.transactionCode = '1201' and foliotransactions.subAccount = 'BANQUET', foliotransactions.netBaseAmount,0)) as 'BanquetRevenue',
sum(if(foliotransactions.transactionCode = '1100', foliotransactions.netbaseamount,0)) as '1100',
sum(if(foliotransactions.transactionCode = '1205', foliotransactions.netbaseamount,0)) as '1205',
sum(if(foliotransactions.transactionCode = '1300', foliotransactions.netbaseamount,0)) as '1300',
sum(if(foliotransactions.transactionCode = '1601', foliotransactions.netbaseamount,0)) as '1601',
sum(if(foliotransactions.transactionCode = '1701', foliotransactions.netbaseamount,0)) as '1701',
sum(if(foliotransactions.transactionCode = '1302', foliotransactions.netbaseamount,0)) as '1302',
sum(if(foliotransactions.transactionCode = '1400', foliotransactions.netbaseamount,0)) as '1400',
sum(if(foliotransactions.transactionCode = '1402', foliotransactions.netbaseamount,0)) as '1402',
sum(if(foliotransactions.transactionCode = '1600', foliotransactions.netbaseamount,0)) as '1600',
sum(foliotransactions.governmentTax) as 'GovernmentTax',
sum(foliotransactions.localTax) as 'LocalTax',
sum(foliotransactions.serviceCharge) as 'ServiceCharge'
from
folio
left join company on company.companyid = folio.companyid
left join folioschedules on folioschedules.folioid = folio.folioid
left join guests on guests.accountid = folio.accountid
left join foliotransactions on foliotransactions.folioid = folio.folioid
where
((folio.fromdate between pStartDate and pEndDate) or
(folio.todate between pStartDate and pEndDate)) and
foliotype != 'JOINER' and
(folio.status = 'ONGOING' or folio.status = 'CLOSED')
group by
folio.folioId
order by 
folio.sales_executive,
company.companyName,
folio.fromdate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportSalesSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportSalesSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportSalesSummary`(
in pTranDate date,
in pHotelId int(5)
)
BEGIN
select transactioncode, sum(baseamount) as BaseAmount, sum(grossAmount) as GrossAmount, sum(netAmount) as NetAmount, sum(netbaseamount) as NetBaseAmount, sum(discount) as Discount, sum(govttax) as GovtTax, sum(mealamount) as MealAmount, sum(localtax) as LocalTax, sum(servicecharge) as ServiceCharge, sum(transactioncount) as TransactionCount, TransactionDescription, acctside, sum(monthtodate) as MonthToDate, sum(yeartodate) as YearToDate from
(select 
foliotransactions.transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.baseAmount * -1, foliotransactions.baseAmount)) as BaseAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.grossAmount * -1, foliotransactions.grossAmount)) as GrossAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netAmount * -1, foliotransactions.netAmount)) as NetAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netBaseAmount * -1, foliotransactions.netBaseAmount)) as NetBaseAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.discount * -1, foliotransactions.discount)) as Discount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.governmentTax * -1, foliotransactions.governmentTax)) as GovtTax,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.mealAmount * -1, foliotransactions.mealAmount)) as MealAmount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.localtax * -1, foliotransactions.localtax)) as LocalTax,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.servicecharge * -1, foliotransactions.servicecharge)) as ServiceCharge,
count(foliotransactions.transactioncode) as TransactionCount,
transactioncode.memo as TransactionDescription,
foliotransactions.acctside,
fGetTransactionNetBaseAmountMonthToDate(
foliotransactions.transactioncode,
foliotransactions.acctside,
pTranDate,
pHotelId
) as MonthToDate,
fGetTransactionNetBaseAmountYearToDate(
foliotransactions.transactioncode,
transactioncode.acctside,
pTranDate,
pHotelId
) as YearToDate
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
date(transactiondate) = pTrandate and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactioncode
UNION all
select 
nonguesttransaction.transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.baseAmount * -1, nonguesttransaction.baseAmount)) as BaseAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.grossAmount * -1, nonguesttransaction.grossAmount)) as GrossAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netAmount * -1, nonguesttransaction.netAmount)) as NetAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netBaseAmount * -1, nonguesttransaction.netBaseAmount)) as NetBaseAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.discount * -1, nonguesttransaction.discount)) as Discount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.governmentTax * -1, nonguesttransaction.governmentTax)) as GovtTax,
0 as MealAmount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.localtax * -1, nonguesttransaction.localtax)) as LocalTax,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.servicecharge * -1, nonguesttransaction.servicecharge)) as ServiceCharge,
count(nonguesttransaction.transactioncode) as TransactionCount,
concat(transactioncode.memo, "-WALK IN") as TransactionDescription,
nonguesttransaction.acctside,
fGetNonGuestTransactionNetBaseAmountMonthToDate(
nonguesttransaction.transactioncode,
nonguesttransaction.acctside,
pTranDate,
pHotelId
)  as MonthToDate,
fGetNonGuestTransactionNetBaseAmountYearToDate(
nonguesttransaction.transactioncode,
transactioncode.acctside,
pTranDate,
pHotelId
)  as YearToDate
from
nonguesttransaction  force index(primary),
transactioncode  force index(primary)
where 	
nonguesttransaction.transactioncode = transactioncode.trancode and 
date(transactiondate) = pTrandate and
nonguesttransaction.hotelId = pHotelId and
nonguesttransaction.statusFlag = 'ACTIVE'
group by nonguesttransaction.transactioncode
) as transactionTable group by transactioncode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportSalesSummary1` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportSalesSummary1` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportSalesSummary1`(
in pTranDate date,
in pHotelId int(5)
)
BEGIN
select transactiondate, transactioncode, sum(netbaseamount) as NetBaseAmount, acctside from
(
select 
date(foliotransactions.transactiondate) as transactiondate,
'DISCOUNT' AS transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.discount * -1, foliotransactions.discount)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
date(foliotransactions.transactiondate) = pTrandate and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactiondate, foliotransactions.transactioncode
UNION ALL
select 
date(foliotransactions.transactiondate) as transactiondate,
'LOCAL TAX' AS transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.localTax * -1, foliotransactions.localTax)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
date(foliotransactions.transactiondate) = pTrandate and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactiondate, foliotransactions.transactioncode
UNION ALL
select 
date(foliotransactions.transactiondate) as transactiondate,
'SERVICE CHARGE' AS transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.serviceCharge * -1, foliotransactions.serviceCharge)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
date(foliotransactions.transactiondate) = pTrandate and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactiondate, foliotransactions.transactioncode
UNION ALL
select 
date(foliotransactions.transactiondate) as transactiondate,
'GOVERNMENT TAX' AS transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.governmentTax * -1, foliotransactions.governmentTax)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
date(foliotransactions.transactiondate) = pTrandate and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactiondate, foliotransactions.transactioncode
UNION ALL
select 
date(foliotransactions.transactiondate) as transactiondate,
foliotransactions.transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netBaseAmount * -1, foliotransactions.netBaseAmount)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
date(foliotransactions.transactiondate) = pTrandate and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactiondate, foliotransactions.transactioncode
UNION ALL
select 
date(foliotransactions.transactiondate) as transactiondate,
'ROOM SALES' AS transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netBaseAmount * -1, foliotransactions.netBaseAmount)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
date(foliotransactions.transactiondate) = pTrandate and
foliotransactions.status = 'ACTIVE' and
(foliotransactions.transactioncode='1000' or
foliotransactions.transactioncode='1001' or
foliotransactions.transactioncode='1002')
group by foliotransactions.transactiondate
UNION ALL
select 
date(foliotransactions.transactiondate) as transactiondate,
'ROOM SALES' AS transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.mealAmount * -1, foliotransactions.mealAmount)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
date(foliotransactions.transactiondate) = pTrandate and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactiondate
UNION ALL
select 
date(nonguesttransaction.transactiondate) as transactiondate,
'ROOM SALES' AS transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netBaseAmount * -1, nonguesttransaction.netBaseAmount)) as NetBaseAmount,
transactioncode.acctside
from
nonguesttransaction ,
transactioncode  force index(primary)
where 	
nonguesttransaction.transactioncode=transactioncode.trancode and 
date(nonguesttransaction.transactiondate) = pTrandate and
nonguesttransaction.statusflag = 'ACTIVE' and
(nonguesttransaction.transactioncode='1000' or
nonguesttransaction.transactioncode='1001' or
nonguesttransaction.transactioncode='1002')
group by nonguesttransaction.transactiondate
UNION ALL
select 
date(foliotransactions.transactiondate) as transactiondate,
'1002' AS transactioncode,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.mealAmount * -1, foliotransactions.mealAmount)) as NetBaseAmount,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary)
where 	
foliotransactions.transactioncode=transactioncode.trancode and 
date(foliotransactions.transactiondate) = pTrandate and
foliotransactions.status = 'ACTIVE' and
foliotransactions.transactioncode='1000'
group by foliotransactions.transactiondate
UNION all
select 
date(nonguesttransaction.transactiondate) as transactiondate,
nonguesttransaction.transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netBaseAmount * -1, nonguesttransaction.netBaseAmount)) as NetBaseAmount,
transactioncode.acctside
from
nonguesttransaction  force index(primary),
transactioncode  force index(primary)
where 	
nonguesttransaction.transactioncode = transactioncode.trancode and 
date(nonguesttransaction.transactiondate) = pTrandate and
nonguesttransaction.hotelId = pHotelId and
nonguesttransaction.statusFlag = 'ACTIVE'
group by nonguesttransaction.transactiondate, nonguesttransaction.transactioncode
UNION ALL
select 
date(nonguesttransaction.transactiondate) as transactiondate,
'DISCOUNT' as transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.discount * -1, nonguesttransaction.discount)) as NetBaseAmount,
transactioncode.acctside
from
nonguesttransaction  force index(primary),
transactioncode  force index(primary)
where 	
nonguesttransaction.transactioncode = transactioncode.trancode and 
date(nonguesttransaction.transactiondate) = pTrandate and
nonguesttransaction.hotelId = pHotelId and
nonguesttransaction.statusFlag = 'ACTIVE'
group by nonguesttransaction.transactiondate, nonguesttransaction.transactioncode
UNION ALL
select 
date(nonguesttransaction.transactiondate) as transactiondate,
'LOCAL TAX' AS transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.localTax * -1, nonguesttransaction.localTax)) as NetBaseAmount,
transactioncode.acctside
from
nonguesttransaction  force index(primary),
transactioncode  force index(primary)
where 	
nonguesttransaction.transactioncode = transactioncode.trancode and 
date(nonguesttransaction.transactiondate) = pTrandate and
nonguesttransaction.hotelId = pHotelId and
nonguesttransaction.statusFlag = 'ACTIVE'
group by nonguesttransaction.transactiondate, nonguesttransaction.transactioncode
UNION ALL
select 
date(nonguesttransaction.transactiondate) as transactiondate,
'GOVERNMENT TAX' as transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.governmentTax * -1, nonguesttransaction.governmentTax)) as NetBaseAmount,
transactioncode.acctside
from
nonguesttransaction  force index(primary),
transactioncode  force index(primary)
where 	
nonguesttransaction.transactioncode = transactioncode.trancode and 
date(nonguesttransaction.transactiondate) = pTrandate and
nonguesttransaction.hotelId = pHotelId and
nonguesttransaction.statusFlag = 'ACTIVE'
group by nonguesttransaction.transactiondate, nonguesttransaction.transactioncode
UNION ALL
select 
date(nonguesttransaction.transactiondate) as transactiondate,
'SERVICE CHARGE' as transactioncode,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.serviceCharge * -1, nonguesttransaction.serviceCharge)) as NetBaseAmount,
transactioncode.acctside
from
nonguesttransaction  force index(primary),
transactioncode  force index(primary)
where 	
nonguesttransaction.transactioncode = transactioncode.trancode and 
date(nonguesttransaction.transactiondate) = pTrandate and
nonguesttransaction.hotelId = pHotelId and
nonguesttransaction.statusFlag = 'ACTIVE'
group by nonguesttransaction.transactiondate, nonguesttransaction.transactioncode
) as transactionTable group by transactiondate, transactioncode order by transactiondate, transactioncode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportSalesSummaryBySubAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportSalesSummaryBySubAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportSalesSummaryBySubAccount`(
in pTrandate date,
in pHotelid int(5)
)
BEGIN
select date(transDate) as transactiondate, subaccount, sum(debit) as DEBIT, count(trans) AS Trans, TRANCODE, acctside from 
(select 
date(foliotransactions.transactiondate) as transDate,
foliotransactions.subaccount,
sum(if(foliotransactions.acctside = "CREDIT", foliotransactions.netBaseAmount * -1, foliotransactions.netBaseAmount)) as DEBIT,
count(foliotransactions.transactioncode) as Trans,
concat(transactioncode.trancode," - ",transactioncode.memo) as TRANCODE,
transactioncode.acctside
from
foliotransactions  force index(FolioID,SubFolio,AccountID),
transactioncode  force index(primary),
trantypes  force index(primary)
where 	
foliotransactions.subaccount != "" and
foliotransactions.transactioncode=transactioncode.trancode and 
transactioncode.trantypeid=trantypes.trantypeid and
date(foliotransactions.transactiondate) = pTrandate and
foliotransactions.status = 'ACTIVE'
group by foliotransactions.transactiondate, foliotransactions.subaccount
UNION all
select 
date(nonguesttransaction.transactiondate) as transDate,
nonguesttransaction.subaccount,
sum(if(nonguesttransaction.acctside = "CREDIT", nonguesttransaction.netBaseAmount * -1, nonguesttransaction.netBaseAmount))  as DEBIT,
count(nonguesttransaction.transactioncode) as Trans,
concat(nonguesttransaction.transactioncode," - ",nonguesttransaction.memo , " - WALK IN") as TRANCODE,
nonguesttransaction.acctside
from
nonguesttransaction  force index(primary)
where 	
nonguesttransaction.subaccount != "" and
date(nonguesttransaction.transactiondate) = pTrandate and
hotelId = pHotelId and
nonguesttransaction.statusFlag = 'ACTIVE'
group by nonguesttransaction.transactiondate, nonguesttransaction.subaccount
) as transactionTable group by transactiondate, subaccount order by subaccount asc, acctside desc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportTransactionRegister` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportTransactionRegister` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportTransactionRegister`(
pAuditDate date
)
BEGIN
(
select 
foliotransactions.postingDate,
foliotransactions.transactionDate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource` as ReferenceType,
foliotransactions.`FolioID`,
guests.accountid,
concat(guests.`lastname`,", " , guests.`firstname`) as GuestName,
if(foliotransactions.status='VOID', 'VOID',foliotransactions.transactioncode) as transactioncode,
if(foliotransactions.status='VOID', 'VOIDED TRANSACTIONS', foliotransactions.memo) as TransactionDescription,
foliotransactions.baseAmount,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-foliotransactions.grossAmount,foliotransactions.grossAmount) as grossAmount,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-foliotransactions.discount,foliotransactions.discount) as discount,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-foliotransactions.servicecharge,foliotransactions.servicecharge) as serviceCharge,
if(foliotransactions.acctside='CREDIT' AND fGetTransactionCodeAcctSide(foliotransactions.transactioncode)='DEBIT', 0-(foliotransactions.governmentTax + 
foliotransactions.localTax),foliotransactions.governmentTax + 
foliotransactions.localTax) as Tax,
foliotransactions.mealAmount,
foliotransactions.`Memo`,
foliotransactions.subFolio,
if(foliotransactions.AcctSide='DEBIT',foliotransactions.`netBaseAmount`,0.00) as DEBIT,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`netBaseAmount`,0.00) as CREDIT,
foliotransactions.`CREATEDBY`,
(select roomid from folioschedules where folioid=foliotransactions.folioid limit 1) as roomid,
(select roomtype from folioschedules where folioid=foliotransactions.folioid limit 1) as roomtype,
if(foliotype="DEPENDENT", folio.groupname, company.companyName) as companyName,
fGetTransactionDescription(foliotransactions.transactioncode) as description
from
foliotransactions
left join transactioncode on transactioncode.tranCode = foliotransactions.transactioncode
left join folio on foliotransactions.folioid = folio.folioid
left join company on folio.companyid = company.companyid
left join guests on guests.accountid = folio.accountid
where
date(foliotransactions.`TransactionDate`) = pAuditDate
)
UNION
(
select 
nonguesttransaction.postingDate,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource as ReferenceType,
nonguesttransaction.referenceFolioId as FolioId,
nonguesttransaction.accountId,
nonguesttransaction.guestName as GuestName,
if(nonguesttransaction.statusFlag='VOID', 'VOID',nonguesttransaction.transactioncode) as transactioncode,
if(nonguesttransaction.statusFlag='VOID', 'VOIDED TRANSACTIONS', nonguesttransaction.memo) as TransactionDescription,
nonguesttransaction.baseAmount,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-nonguesttransaction.grossAmount,nonguesttransaction.grossAmount) as grossAmount,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-nonguesttransaction.discount,nonguesttransaction.discount) as discount,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-nonguesttransaction.servicecharge,nonguesttransaction.servicecharge) as serviceCharge,
if(nonguesttransaction.acctside='CREDIT' AND fGetTransactionCodeAcctSide(nonguesttransaction.transactioncode)='DEBIT', 0-(nonguesttransaction.governmentTax + 
nonguesttransaction.localTax),nonguesttransaction.governmentTax + 
nonguesttransaction.localTax) as Tax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
if(nonguesttransaction.AcctSide='DEBIT',nonguesttransaction.netAmount,0.00) as DEBIT,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.netAmount,0.00) as CREDIT,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
"" as roomtype,
nonguesttransaction.companyName,
fGetTransactionDescription(nonguesttransaction.transactioncode) as description
from nonguesttransaction force index(primary)
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
where
date(nonguesttransaction.transactionDate) = pAuditDate 
)
order by transactioncode, ReferenceType, ReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportTransactionsDateRange` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportTransactionsDateRange` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportTransactionsDateRange`(
in photelid int(5),
in pStartDate date,
in pEndDate date
)
BEGIN
select 	
foliotransactions.*,
if(foliotransactions.acctside='DEBIT',foliotransactions.baseamount,0.00) as CHARGES,  
if(foliotransactions.acctside='CREDIT',foliotransactions.baseamount,0.00) as CREDIT,
folioschedules.roomid,
concat(guests.lastname,", ",guests.firstname) as GuestName
from foliotransactions 
left join folioschedules on foliotransactions.folioid = folioschedules.folioid
left join guests on guests.accountid = foliotransactions.accountid
where
(date(transactiondate) >= pStartDate and
date(transactiondate) <= pEndDate ) and
foliotransactions.hotelid = photelid
order by `status`,transactiondate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportTrunkLineSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportTrunkLineSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportTrunkLineSummary`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportVoidedTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportVoidedTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spReportVoidedTransactions`(
in pReportDate date,
in pHotelId int(4)
)
BEGIN
(
select
foliotransactions.postingDate,
foliotransactions.transactiondate,
foliotransactions.`ReferenceNo`,
foliotransactions.`TransactionSource` as ReferenceType,
foliotransactions.`FolioID`,
if(folio.foliotype!='GROUP', fGetGuestName(folio.accountid), if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid))) as GuestName,
foliotransactions.transactioncode,
foliotransactions.`Memo`,
if(AcctSide='DEBIT',foliotransactions.netAmount,0.00) as DEBIT,
if(AcctSide='CREDIT',foliotransactions.netAmount,0.00) as CREDIT,
foliotransactions.`UPDATEDBY` as CREATEDBY,
folioschedules.roomid,
fGetCompanyName(folio.companyid) as companyName
from
foliotransactions
left join folioschedules on folioschedules.folioid = foliotransactions.folioid
left join folio on folioschedules.folioid = folio.folioid
where
date(foliotransactions.transactiondate) = pReportDate and
foliotransactions.Status='VOID'
order by folioschedules.roomid
)
UNION all
(
select
nonguesttransaction.postingDate,
nonguesttransaction.transactiondate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource as ReferenceType,
nonguesttransaction.referenceFolioId as FolioID,
nonguesttransaction.guestName as GuestName,
nonguesttransaction.transactioncode,
nonguesttransaction.`Memo`,
if(AcctSide='DEBIT', nonguesttransaction.netAmount,0.00) as DEBIT,
if(AcctSide='CREDIT',nonguesttransaction.netAmount,0.00) as CREDIT,
nonguesttransaction.`UPDATEDBY` as CREATEDBY,
nonguesttransaction.roomNumber as roomid,
nonguesttransaction.companyName
from
nonguesttransaction force index(primary)
where
date(nonguesttransaction.transactiondate) = pReportDate and
nonguesttransaction.statusFlag = 'VOID'
order by nonguesttransaction.roomNumber
);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spReportWeeklySchedule` */

/*!50003 DROP PROCEDURE IF EXISTS  `spReportWeeklySchedule` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spReportWeeklySchedule`(
pHotelId int,
pStartDate datetime,
pEndDate datetime
)
BEGIN
select * from (
select folio.groupName,folioschedules.activity,folioschedules.FolioId,folioschedules.venue,
roomevents.EVENTDATE,roomevents.startTime,roomevents.endTime,
if((select group_concat(concat(firstName,' ' ,lastName)) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioId = folio.folioId and event_officers.hotelID = '1') is null,' ',(select group_concat(concat(firstName,' ' ,lastName)) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioId = folio.folioId and event_officers.hotelID = '1')) as eo
from folioschedules left join folio on folioschedules.FolioId = folio.folioID left join roomevents on roomevents.EventID=folioschedules.FolioId
where (roomevents.EventType = 'RESERVATION' or roomevents.EventType = 'IN HOUSE') and roomevents.HOTELID = pHotelId and date(roomevents.EVENTDATE) >= date(pStartDate) and date(roomevents.EVENTDATE) <= date(pEndDate) 
order by roomevents.EVENTDATE,roomevents.startTime) as weeklySchedules 
group by EVENTDATE,startTime,endTime,activity,venue,groupName,eo
order by venue
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spResetEventPlus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spResetEventPlus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spResetEventPlus`()
BEGIN
delete from account_information;
delete from accountingadjustments;
delete from accountprivileges;
delete from agentcommission;
delete from agents;
delete from apledger;
delete from arledger;
delete from auditdatetable;
insert into auditdatetable values (date_format(date_sub(now(),INTERVAL 1
DAY),'%Y-%m-%d'),0,'PROCESSED',date_sub(now(),INTERVAL 1
DAY),'ADMIN'),(date_format(now(),'%Y-%m-%d'),0,'PM',now(),'ADMIN');
delete from blockingdetails;
delete from cardco;
delete from cashiers;
insert into cashiers set terminalid = '1', terminal = 'Cash Terminal 1',
cashierid = '1' , shiftcode = '1' , openingbalance = 0.00 ,
openingadjustment = 0.00, beginningbalance = 0.00, chargeinamount =
0.00, cash = 0.00, creditcard = 0.00, cheque = 0.00, others = 0.00,
adjustment = 0.00, amountremitted = 0.00, netamount = 0.00, `status` =
'CLOSE', HOTELID = 1;
delete from cashiers_logs;
delete from changes_log;
delete from cityledger;
delete from comledger;
delete from contactpersons;
delete from company;
delete from contacts;
delete from contractammendments;
delete from creditcardledger;
delete from csledger;
delete from depledger;
delete from drivers;
delete from drivers_commission;
delete from engineeringjobs;
delete from event_applied_rates;
delete from event_attendance;
delete from event_attributes;
delete from event_booking_info;
delete from event_contacts;
delete from event_details;
delete from event_emd_actions;
delete from event_endorsement;
delete from event_incumbent_officers;
delete from event_meal_details;
delete from event_meal_requirements;
delete from event_officers;
delete from event_package_detail;
delete from event_package_header;
delete from event_package_requirement;
delete from event_requirements;
delete from event_room_venues;
delete from event_rooms;
delete from folio;
delete from folio_merge_history;
delete from folioinclusions;
delete from folioledger;
delete from foliopackage;
delete from folioprivilege;
delete from foliorecurringcharge;
delete from foliorouting;
delete from folioschedules;
delete from foliotransactions;
delete from guests;
delete from hk_housekeepers;
delete from hk_housekeepingjobs;
delete from hk_minibar_sales;
delete from hk_minibar_sales_details;
delete from hk_minibarsales;
delete from hk_minibarsalesdetails;
delete from hk_stepprocedures;
delete from hotel;
insert into hotel set HotelID = '1', HotelName = 'Jinisys Software
Inc.', NoOfFloors = '0', NoOfRooms = '0', checkInTime = '02:00 PM',
checkOutTime = '12:00 PM', stateFlag = 'ACTIVE', CreatedBy = 'ADMIN';
delete from hotelrevenue;
delete from nonguesttransaction;
delete from packagedetails;
delete from packageheader;
delete from paymentledger;
delete from phonetransactions;
delete from privilegedetails;
delete from privilegeheader;
delete from restaurantledger;
delete from roomblock;
delete from roomevents;
delete from salesledger;
update seq_autopost set id = 0;
update seq_company set id = 0;
update seq_enggjob set id = 0;
update seq_event set id = 0;
update seq_folio set id = 0;
update seq_guest set id = 0;
update seq_housekeepingjob set id = 0;
update seq_packages set id = 0;
update seq_privileges set id = 0;
update seq_resledger set id = 0;
update sequence set sequenceNo = 0;
delete from servicecharge;
delete from shiftendorsements;
delete from srvchrgledger;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spResetUserPassword` */

/*!50003 DROP PROCEDURE IF EXISTS  `spResetUserPassword` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spResetUserPassword`(
in pUserId varchar(100),
in pPassword varchar(50),
in pHotelId int(4),
in pUpdatedBy varchar(100)
)
BEGIN
update users 
set 
`password` = md5(pPassword),
updateTime = now(),
updatedBy = pUpdatedBy
where
UserId = pUserId and
HotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spRoomIsCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spRoomIsCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spRoomIsCharge`( in pRoomid varchar(20),
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
EventType <> 'CLOSED'
or EventType<>'CANCELLED');
END */$$
DELIMITER ;

/* Procedure structure for procedure `spRoomOCcupancyReport` */

/*!50003 DROP PROCEDURE IF EXISTS  `spRoomOCcupancyReport` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spRoomOCcupancyReport`(
pAuditDate date
)
BEGIN
select distinct
rooms.roomid,
rooms.roomtypecode,
concat(guests.lastName, ", ",guests.FirstName) as GuestName,
folio.fromDate as ArrivalDate,
folio.toDate as DepartureDate,
folio.noofadults,
company.companyName,
folio.remarks,
FGetTotalRooms() as totalRoomCount,
fGetTotalOutOfOrderRooms(pAuditDate) as OutOfOrderRooms
from 
rooms
left join roomevents on roomevents.roomid = rooms.roomid
left join folio on folio.folioid = roomevents.eventid
left join guests on guests.accountid = folio.accountid
left join company on company.companyId = folio.companyId
left join folioschedules on folioschedules.folioid = folio.folioid
where
date(roomevents.eventdate) = pAuditDate and
roomevents.transferflag = 0 and
(folio.status = 'ONGOING' or folio.status = 'CLOSED') and
( date(folio.fromDate) <= pAuditDate and date(folio.toDate) > pAuditDate) and
rooms.roomtypecode != 'FUNCTION'
order by rooms.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spRoomTransferView` */

/*!50003 DROP PROCEDURE IF EXISTS  `spRoomTransferView` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spRoomTransferView`()
BEGIN
select folioid from folioschedules
where
departuredate = now();
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_DeleteGLaccountMapping` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_DeleteGLaccountMapping` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_DeleteGLaccountMapping`(pTransactionCode varchar(50), pGLAccountID varchar(30))
BEGIN
delete from sap_folio_glmapping where tranCode=pTransactionCode and glaccountid=pGlAccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_DeleteGLaccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_DeleteGLaccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_DeleteGLaccounts`(pAccountID varchar(50), pCreatedBy varchar(30))
BEGIN
delete from sap_glaccounts where accountID=pAccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_GetAllGLaccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_GetAllGLaccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_GetAllGLaccounts`(
in pHotelID int(4)
)
BEGIN
select * from SAP_GLAccounts where statusflag!='DELETED'
order by AccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_GetAllTemplates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_GetAllTemplates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSAP_GetAllTemplates`()
BEGIN
select ID, Name, Description, OutputExtension, Generate, CreatedBy, CreatedDate, 
UpdatedBy, UpdatedDate from `sap_template` 
where Generate = 1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_GetFolioGLMapping` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_GetFolioGLMapping` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_GetFolioGLMapping`()
BEGIN
select * from sap_folio_glmapping where statuflag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_GetNewCustomers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_GetNewCustomers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_GetNewCustomers`(
pExportDate date
)
BEGIN
Select * from
(
(
select 
accountid,
lastname,
firstname,
concat(firstname, ' ',lastname) as ContactPerson,
telephoneno,
faxno,
mobileno,
concat(street,' ',city, ' ',zip, ' ',country) as Address,
createtime
from guests
where
date(createtime) > pExportDate
)
UNION ALL
(
Select 
companyid as accountid,
companyname as lastname,
'' as firstname,
ContactPerson,
contactnumber1 as telephoneno,
contactnumber2 as fax,
contactnumber3 as mobile,
concat(street1,' ',city1,' ',zip1,' ',country1) as Address,
createtime
from company
where date(createTime) > pExportDate
)
) customers 
order by createtime asc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_GetNewGuests` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_GetNewGuests` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_GetNewGuests`(
pHotelID int(4),
pExportDate date
)
BEGIN
(select guests.*, concat(guests.firstname, " ", guests.lastname) as contactperson, concat(guests.firstname, " ", guests.lastname) as companycode, (select `value` from system_config where `key`='SAP_INDIVIDUAL_GROUPCODE') as groupCode from guests, cityledger
where
date(cityledger.date) >= pExportDate and cityledger.acctid=guests.accountid
order by guests.createtime asc)
union all
(select companyid as accountid,
companycode as accountname,
'' as title,
companyname as lastname,
'' as firstname,
'' as middlename,
'' as sex,
street1 as street,
city1 as city,
country1 as country,
zip1 as zip,
companyurl as emailaddress,
'' as citizenship,
'' as passportid,
contactnumber1 as telephoneno,
contactnumber2 as mobileno,
contactnumber3 as faxno,
'' as guestimage,
no_of_visit as noofvisits,
'' as memo,
'' as concierge,
remarks as remark,
stateflag,
company.hotelid,
company.createtime,
company.createdby,
company.updatetime,
company.updatedby,
now() as birthdate,
account_type,
card_no,
threshold_value,
total_sales_contribution,
'' as creditcardtype,
'' as creditcardno,
now() creditcardexpiry,
0 as taxexempted,
contactperson,
companycode, (select `value` from system_config where `key`='SAP_COMPANY_GROUPCODE') as groupCode from company, cityledger
where
date(cityledger.date) >= pExportDate and cityledger.acctid=company.companyid
order by company.createtime asc);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_GetTemplateFields` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_GetTemplateFields` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSAP_GetTemplateFields`(
pTemplateID int(4)
)
BEGIN
select * from sap_templatefields
WHERE	
StatusFlag = 'ACTIVE'
AND TemplateID = pTemplateID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_GetTranCodeGLaccountMapping` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_GetTranCodeGLaccountMapping` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_GetTranCodeGLaccountMapping`(
in pTransactionCode varchar(20)
)
BEGIN
select 
sap_folio_glmapping.*, 
sap_glaccounts.description
from 
sap_folio_glmapping
left join sap_glaccounts on 
sap_glaccounts.AccountID = sap_folio_glmapping.GLAccountID 
where TranCode = pTransactionCode
order by lineno;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_InsertFolioGLMapping` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_InsertFolioGLMapping` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_InsertFolioGLMapping`(pTranCode varchar(30),
pGLAccountID varchar(30),
pLineNo int(2),
pAmountCol varchar(50),
pCostCenterCode varchar(30),
pStatusFlag varchar(10),
pUser varchar(30))
BEGIN
insert into sap_folio_glmapping values (pTranCode, pGLAccountID, pLineNo, pAmountCol, pCostCenterCode, pStatusFlag, pUser, now(), pUser, now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_InsertGLaccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_InsertGLaccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_InsertGLaccounts`(pAccountID varchar(50), pDescription varchar(200), pCostCenterCode varchar(50), pAccountNature varchar(20), pCreatedBy varchar(30))
BEGIN
insert into sap_glAccounts values(pAccountID, pDescription, pCostCenterCode, pAccountNature, 'ACTIVE', now(), pCreatedBy, now(), pCreatedBy);
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_ReportPostedAndUnpostedDailyHotelPayments` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_ReportPostedAndUnpostedDailyHotelPayments` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_ReportPostedAndUnpostedDailyHotelPayments`(
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
transactioncode.trantypeid,
foliotransactions.`FolioID`,
guests.accountid,
concat(guests.`lastname`,", " , guests.`firstname`) as GuestName,
foliotransactions.transactioncode,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`baseAmount`,
(foliotransactions.`baseAmount` * -1) ) as baseAmount,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as netBaseAmount,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`grossAmount`,
(foliotransactions.`grossAmount` * -1) ) as grossAmount,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`discount`,
(foliotransactions.`discount` * -1) ) as discount,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`serviceCharge`,
(foliotransactions.`serviceCharge` * -1) ) as serviceCharge,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`governmentTax`,
(foliotransactions.`governmentTax` * -1) ) as governmentTax,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`localTax`,
(foliotransactions.`localTax` * -1) ) as localTax,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`mealAmount`,
(foliotransactions.`mealAmount` * -1) ) as mealAmount,
foliotransactions.`Memo`,
foliotransactions.subFolio,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`netAmount`,
(foliotransactions.`netAmount` * -1) ) as netAmount,
if(foliotransactions.AcctSide='CREDIT',foliotransactions.`netBaseAmount`,
(foliotransactions.`netBaseAmount` * -1) ) as Amount,
foliotransactions.`CREATEDBY`,
if(substring(foliotransactions.`Memo`,-3,3) > 0,substring(foliotransactions.`Memo`,-3,3),folioschedules.roomid) as roomid,
folioschedules.roomtype,
company.companyName,
'' as REMARKS,
foliotransactions.creditcardno,
foliotransactions.chequeno,
foliotransactions.accountname,
foliotransactions.bankname,
foliotransactions.chequedate,
foliotransactions.focgrantedby,
foliotransactions.creditcardtype,
foliotransactions.approvalslip,
foliotransactions.creditcardexpiry,
concat(date(folio.arrivaldate), ' to ', date(folio.departuredate)) as daterange
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
(transactioncode.tranTypeID = 2 or transactioncode.tranTypeID = 3 or transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or transactioncode.trantypeid = 9) group by folioid, referenceno, transactionsource
)
UNION
(
select
nonguesttransaction.postingDate,
nonguesttransaction.transactionDate,
nonguesttransaction.referenceNo,
nonguesttransaction.transactionSource,
transactioncode.trantypeid,
nonguesttransaction.referenceFolioId as FolioId,
nonguesttransaction.accountId,
if(nonguesttransaction.guestName="","WALK-IN GUEST",nonguesttransaction.guestName) as GuestName,
nonguesttransaction.transactionCode,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.baseAmount,
(nonguesttransaction.baseAmount * -1) ) as baseAmount,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.netBaseAmount,
(nonguesttransaction.netBaseAmount * -1) ) as netBaseAmount,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.grossAmount,
(nonguesttransaction.grossAmount * -1) ) as grossAmount,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.discount,
(nonguesttransaction.discount * -1) ) as discount,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.serviceCharge,
(nonguesttransaction.serviceCharge * -1) ) as serviceCharge,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.governmentTax,
(nonguesttransaction.governmentTax * -1) ) as governmentTax,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.localTax,
(nonguesttransaction.localTax * -1) ) as localTax,
0 as mealAmount,
nonguesttransaction.memo,
"A " as subFolio,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.netAmount,
(nonguesttransaction.netAmount * -1) ) as netAmount,
if(nonguesttransaction.AcctSide='CREDIT',nonguesttransaction.netbaseAmount,
(nonguesttransaction.netbaseAmount * -1) ) as Amount,
nonguesttransaction.CREATEDBY,
nonguesttransaction.roomNumber as roomid,
'' as roomtype,
nonguesttransaction.companyName,
'' as REMARKS,
nonguesttransaction.creditcardno,
nonguesttransaction.chequeno,
nonguesttransaction.accountname,
nonguesttransaction.bankname,
nonguesttransaction.chequedate,
nonguesttransaction.focgrantedby,
nonguesttransaction.creditcardtype,
nonguesttransaction.approvalslip,
nonguesttransaction.creditcardexpiry,
'' as daterange
from nonguesttransaction force index(primary)
left join transactioncode on transactioncode.tranCode = nonguesttransaction.transactioncode
where
date(nonguesttransaction.transactionDate) >= pStartDate and 
date(nonguesttransaction.`TransactionDate`) <= pEndDate and
nonguesttransaction.statusFlag = 'ACTIVE' and
nonguesttransaction.hotelID = pHotelId and
(transactioncode.tranTypeID = 2 or transactioncode.tranTypeID = 3 or transactioncode.trantypeid = 4 or transactioncode.trantypeid = 5 or transactioncode.trantypeid = 9) group by folioid, referenceno, transactionsource
)
order by transactionCode, transactionSource, ReferenceNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_RestoDataDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_RestoDataDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_RestoDataDetail`(pOrderID varchar(20))
BEGIN
select * from pos.`order detail` where order_id=pOrderID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_RestoDataHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_RestoDataHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_RestoDataHeader`(pStartDate date, pEndDate date)
BEGIN
select order_id, if(customer_id='WALK-IN CUSTOMER', 'WALK-IN', accountid) as customerID, '' AS comments, order_date from pos.`order header` as OrderHeader left join folio on OrderHeader.customer_id=folio.folioid where date(OrderHeader.order_date) between pStartDate and pEndDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSAP_UpdateGLaccounts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSAP_UpdateGLaccounts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSAP_UpdateGLaccounts`(pAccountID varchar(50), pDescription varchar(200), pCostCenterCode varchar(50), pAccountNature varchar(20), pStatusFlag varchar(20), pCreatedBy varchar(30))
BEGIN
update sap_glaccounts set description=pDescription, costCenterCode=pCostCenterCode, accountNature=pAccountNature, statusFlag=pStatusFlag, updatedBy=pCreatedBy, updatedDate=now() where accountID=pAccountID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSearchAccountName` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSearchAccountName` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSearchAccountName`(
in pAccountName varchar(30)
)
BEGIN
Select AccountId,AccountName,FirstName,MiddleName,LastName,Age,Sex,CitizenShip from guestS where accountname=pAccountname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSearchGuestRefName` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSearchGuestRefName` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSearchGuestRefName`(
in plastname varchar(30),
in  pfirstname varchar(30),
in  pmiddlename varchar(30)
)
BEGIN
Select * from guests where lastname=plastname and firstname=pfirstname and middlename=pmiddlename;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectAccountingAdjustments` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectAccountingAdjustments` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectAccountingAdjustments`()
BEGIN
select *,drivers.lastName, drivers.firstName from accountingadjustments
left join drivers on drivers.driverId = accountingadjustments.referenceDriverId
where
accountingadjustments.statusFlag = 'ACTIVE' order by postingdate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectActiveGroup` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectActiveGroup` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSelectActiveGroup`(pRESTOID INT(5))
BEGIN
select GROUP_ID,DESCRIPTION, MAINGROUP_ID from `group` where `STATUS`='ACTIVE'
AND RESTO_ID=pRESTOID
order by group_id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spselectactiveitems` */

/*!50003 DROP PROCEDURE IF EXISTS  `spselectactiveitems` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spselectactiveitems`(pRestoID int(10))
BEGIN
select ITEM_ID, item.GROUP_ID, MAINGROUP_ID, item.DESCRIPTION, 
UNIT,UNIT_COST, SELLING_PRICE, EVAT*100 as EVAT, SERVICE_CHARGE*100 AS SERVICE_CHARGE,
item.KITCHEN_DESIGNATION, item.availability
from item, `group` where item.group_id=group.group_id
and ITEM.resto_id=pRestoID AND GROUP.RESTO_ID=pRestoID and item.status='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectActiveMainGroup` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectActiveMainGroup` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSelectActiveMainGroup`()
BEGIN
select id,DESCRIPTION from `main_item_group` where `STATUS`='ACTIVE'
order by id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectActiveMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectActiveMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSelectActiveMenu`()
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectAllAppliedRates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectAllAppliedRates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectAllAppliedRates`()
BEGIN
select * from appliedRates where `status`='active';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectAllEndorsements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectAllEndorsements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectAllEndorsements`(
in pHotelId int(4)
)
BEGIN
set sql_big_selects = 1;
select * from shiftendorsements force index(primary)
where hotelId = pHotelId
order by logdate asc, statusFlag desc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectAllFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectAllFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectAllFolio`()
BEGIN
Select folio.*,
if(folio.companyid='','',if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid))) as CompanyName, fGetFolioBalance(folio.folioid) as balance
from folio where folio.status!='DELETED' and folio.status!='CANCELLED' and folio.status!='CLOSED' order by arrivalDate asc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectAmenities` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectAmenities` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectAmenities`(
in photelid int(5)
)
BEGIN
select 	amenityid,
name,
description
from amenities
where stateflag != 'DELETED' and hotelid = photelid
order by amenityid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectAmenitiesForRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectAmenitiesForRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectAmenitiesForRoom`(
in photelid int(5)
)
BEGIN
select amenityid,name
from amenities
where (stateflag = 'ACTIVE' or stateflag = 'UNASSIGNED') AND
hotelid = photelid
order by amenityid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectBackofficeConfig` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectBackofficeConfig` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectBackofficeConfig`(
in pHotelId int(4)
)
BEGIN
select * from back_office_config
where HOTEL_ID = pHotelId
limit 0,1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectBlockedRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectBlockedRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectBlockedRooms`(
in pStartDate date,
in pEndDate date
)
BEGIN
select 
roomblock.blockId,
blockingdetails.roomid,
rooms.roomtypecode as RoomType,
blockingdetails.blockfrom,
blockingdetails.blockto,
roomblock.reason 
from roomblock left join blockingdetails on blockingdetails.blockid = roomblock.blockid
left join rooms on rooms.roomid = blockingdetails.roomid
where 
(
date(blockingdetails.blockfrom) between pStartDate and pEndDate or 
date(blockingdetails.blockto) between pStartDate and pEndDate or
pStartDate between date(blockfrom) and date(blockto) or
pEndDate between date(blockfrom) and date(blockto)
) and 
blockingdetails.blockfrom<pEndDate and blockto>pStartDate
order by roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectBlockID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectBlockID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectBlockID`()
BEGIN
select blockid from roomblock
order by blockid desc
limit 0,1;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectBlocks` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectBlocks` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectBlocks`(
in pStartDate date,
in pEndDate date
)
BEGIN
select 
roomblock.blockId,
blockingdetails.roomid,
rooms.roomtypecode as RoomType,
blockingdetails.blockfrom,
blockingdetails.blockto,
roomblock.reason 
from roomblock left join blockingdetails on blockingdetails.blockid = roomblock.blockid
left join rooms on rooms.roomid = blockingdetails.roomid
where 
( date(blockingdetails.blockfrom) >= pStartDate ) OR
( date(blockingdetails.blockto) <= pEndDate );
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCashiers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCashiers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectCashiers`()
BEGIN
select * from cashiers;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCashierTerminals` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCashierTerminals` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectCashierTerminals`()
BEGIN
select * from Cashiers;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCashTerminals` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCashTerminals` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectCashTerminals`(
pHotelId int(5)
)
BEGIN
select * from Cashiers where hotelid = pHotelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCompany` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCompany` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectCompany`(
in photelid int(5)
)
BEGIN
select 
*
from company 
where stateflag <>'DELETED' and hotelid = photelid order by companyname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCompanyByCompanyID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCompanyByCompanyID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectCompanyByCompanyID`(
in pCompanyID varchar(50),
in pHotelID int(5))
BEGIN
select 
*
from 
company 
where 
CompanyID = pCompanyID and
stateflag <> 'DELETED' and 
hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCompanyByName` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCompanyByName` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectCompanyByName`(
in pCompanyName varchar(50),
in pHotelID int(5))
BEGIN
select 
*
from 
company 
where 
CompanyName = pCompanyName and
stateflag <> 'DELETED' and 
hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCompanyByNameUsingLike` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCompanyByNameUsingLike` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectCompanyByNameUsingLike`(
in pCompanyName varchar(50),
in pHotelID int(5))
BEGIN
select 
*
from 
company 
where 
CompanyName like pCompanyName and
stateflag <> 'DELETED' and 
hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCompanyFoliosForToolTip` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCompanyFoliosForToolTip` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectCompanyFoliosForToolTip`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select 	distinct
folio.status,
folio.folioid,
folio.foliotype,
folio.noofadults,
folio.groupname,
folio.companyid,
if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyname,
event_booking_info.contactPerson,
event_booking_info.contactAddress as Address,
folioschedules.roomid,
folioschedules.rate,
folio.remarks,
folioschedules.fromdate AS arrivaldate,
folioschedules.todate AS departuredate,
folioschedules.roomtype,
event_booking_info.noOfPaxLiveIn as liveInPax,
event_booking_info.noOfPaxLiveOut as liveOutPax
from
folio force index(primary) left join event_booking_info on folio.folioid=event_booking_info.folioid,
folioschedules force index(primary)
where
folio.foliotype = 'GROUP' and
folioschedules.folioid = folio.folioid and
(folio.status = 'ONGOING' or folio.status = 'CONFIRMED' or folio.status='TENTATIVE')
and
( pAuditDate >= date(folioschedules.fromdate) and  pAuditDate <= date(folioschedules.todate) ) and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = pHotelId
order by folioschedules.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectContacts` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectContacts` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectContacts`(
in pHotelId int(4)
)
BEGIN
select * from contacts
where statusFlag = 'ACTIVE' and
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCountries` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCountries` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSelectCountries`()
BEGIN
select * from countries;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCurrencyCodes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCurrencyCodes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectCurrencyCodes`(
in photelid int(5)
)
BEGIN
Select * from currencycodes 
Where HOTELID=photelid AND stateFlag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectCurrentDayRoomStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectCurrentDayRoomStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectCurrentDayRoomStatus`(
in pDate date,
in pHotelID int(5)
)
BEGIN
set sql_big_selects = 1;
select distinct
rooms.roomid,
rooms.roomtypecode,
roomtypes.roomsupertype,
rooms.cleaningstatus,
roomevents.eventtype,
rooms.RoomDescription
from rooms use index(roomid)
left join roomevents use index(roomid,eventtype,eventdate) on 
rooms.roomid = roomevents.roomid and 
roomevents.hotelid=pHotelID and
roomevents.EventDate= pdate and 
roomevents.eventtype<>'CLOSED'  and
roomevents.eventtype <> 'NO SHOW' and 
roomevents.eventtype <> 'CANCELLED' and
roomevents.transferFlag <>'1',
roomtypes
where
rooms.stateFlag != 'DELETED' and rooms.roomtypecode=roomtypes.roomtypecode
order by rooms.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectDayEndProcessConfig` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectDayEndProcessConfig` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSelectDayEndProcessConfig`(
in pHotelId int(4)
)
BEGIN
select * from dayEndProcessConfig
where statusFlag = 'ACTIVE' and
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectDepartments` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectDepartments` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectDepartments`(
in pHotelId int(5)
)
BEGIN
select * from department
where
hotelid = pHotelId and
stateflag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectDrivers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectDrivers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectDrivers`(
in pHotelId int(4)
)
BEGIN
select * from drivers
where HOTEL_ID = pHotelId and
STATUS_FLAG = 'ACTIVE'
order by lastname, firstname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectEngineeringJobs` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectEngineeringJobs` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectEngineeringJobs`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectEngineeringServices` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectEngineeringServices` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectEngineeringServices`(
in photelid int(5)
)
BEGIN
select * from engineeringservices
where 
stateflag = 'ACTIVE' and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectEventPackage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectEventPackage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectEventPackage`(pHotelID int(5), pPackageID varchar(10))
BEGIN
select * from event_package_header where `status`='active' and hotelID=pHotelID and packageID=pPackageID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectEventPackageDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectEventPackageDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectEventPackageDetails`(pPackageID bigint(20))
BEGIN
select * from event_package_detail where packageID=pPackageID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectEventPackageRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectEventPackageRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectEventPackageRequirements`(pPackageID varchar(20))
BEGIN
select * from event_package_requirement where packageID=pPackageID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectEventPackages` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectEventPackages` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectEventPackages`(pHotelID int(5))
BEGIN
select * from event_package_header where `status`='active' and hotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectFolioForRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectFolioForRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectFolioForRoom`()
BEGIN
select folio.folioid,folioschedules.roomid,folioschedules.arrivaldate,folio.status from folio,folioschedules 
where folio.folioid=folioschedules.folioid and folio.status='ONGOING' order by folioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectFolios` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectFolios` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectFolios`()
BEGIN
select * from folio;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectFolioTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectFolioTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectFolioTransactions`(in photelID int(5))
BEGIN
Select * FROM FOLIOTRANSACTIONS where hotelID =pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectFolioTransactionsByDate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectFolioTransactionsByDate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectFolioTransactionsByDate`(pdate date)
BEGIN
select * from foliotransactions where date(trandate)=pdate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectFolioTransactionsByMonth` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectFolioTransactionsByMonth` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectFolioTransactionsByMonth`(pmonth int(1),
pyear int(4))
BEGIN
Select * from foliotransactions where month(trandate) =pmonth and year(trandate)=pyear; 
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectFolioTransactionsByRange` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectFolioTransactionsByRange` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectFolioTransactionsByRange`( pFromDate date,
pToDate date)
BEGIN
Select * from foliotransactions where (date(trandate) >= pFromDate and date(trandate)<=pToDate) and posttoledger='0';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectFolioTransactionsForBilling` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectFolioTransactionsForBilling` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectFolioTransactionsForBilling`(
in pfolioid int(4)
)
BEGIN
select * from foliotransactions
where
folioid = pfolioid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectGetReservationList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectGetReservationList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectGetReservationList`()
BEGIN
Select distinct folioSchedules.roomid,(roomtypes.roomtypename) as `Room Type`,
CONCAT(guest.firstname,' ',guest.Lastname) as Name,event.eventtype,
folio.accountType,folio.`status` from folio,guest,event,rooms,folioSchedules,roomtypes where 
folio.eventid=event.eventid and folio.accountid=guest.accountid
and folioSchedules.FolioId=folio.folioid and rooms.roomtypeid=roomtypes.roomtypeid and
folioSchedules.roomid=rooms.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectGetRoomList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectGetRoomList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectGetRoomList`()
BEGIN
Select room.roomid
, roomtype.name,roomtype.roomrate,(roompromo.name) as RoomPromo,roompromo.percentoff, 
roomtype.maxoccupants,room.floor, room.smokingtype, room.windows,
room.stateflag, room.amount, room.breakfastflag, room.shareflag
from `room`,roomtype,`roompromo`,`roompromoasgt` 
where room.roomtypeid=roomtype.roomtypeid and 
roompromoasgt.roompromoid=roompromo.roompromoid and roomtype.roomtypeid=roompromoasgt.roomtypeid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectGroupFolioRecurringCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectGroupFolioRecurringCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectGroupFolioRecurringCharges`(
in pHotelId int(4)
)
BEGIN
select 
foliorecurringcharge.TransactionCode, 
foliorecurringcharge.Memo,
foliorecurringcharge.Amount,
folio.companyId,
folio.folioid,
foliorecurringcharge.subAccount
from foliorecurringcharge,folio
where
foliorecurringcharge.hotelid = folio.hotelId and
foliorecurringcharge.folioid = folio.folioid and
folio.folioType = "GROUP" and
folio.hotelid = pHotelId and
( curdate() >= date(foliorecurringcharge.FromDate) and
curdate() <= date(foliorecurringcharge.ToDate) )
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectGuest` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectGuest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectGuest`()
BEGIN
set sql_big_selects = 1;
Select * from guests force index(accountid)
WHERE 
stateflag <> 'DELETED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectGuestByAccountID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectGuestByAccountID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectGuestByAccountID`(
in pAccountID varchar(20),
in pHotelID int(5))
BEGIN
select 
*
from 
guests 
where 
accountid = pAccountID and
stateflag <> 'DELETED' and 
hotelid = photelid
order by lastname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectGuestByName` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectGuestByName` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectGuestByName`(
in pLastName varchar(20),
in pFirstName varchar(20),
in pHotelID int(5))
BEGIN
select 
*
from 
guests 
where 
LastName = pLastName and
FirstName = pFirstName and
stateflag <> 'DELETED' and 
hotelid = photelid
order by lastname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectGuestByNameUsingLike` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectGuestByNameUsingLike` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectGuestByNameUsingLike`(
in pLastName varchar(50),
in pFirstName varchar(50),
in pHotelID int(5))
BEGIN
select 
*
from 
guests 
where 
LastName like pLastName and
FirstName like pFirstName and
stateflag <> 'DELETED' and 
hotelid = photelid
order by lastname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectGuestForToolTip` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectGuestForToolTip` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectGuestForToolTip`(
in photelid int(5),
in pAuditDate date
)
BEGIN
select 	distinct
folio.status,
folio.folioid,
folio.foliotype,
folio.noofadults,
guests.accountid,
concat(guests.lastname," , ",guests.firstname) as GuestName,
concat(guests.street,", ",guests.city, ", ",guests.country) as Address1,
guests.telephoneNo,
guests.citizenship,
folioschedules.roomid,
folioschedules.rate,
folio.remarks,
folioschedules.fromdate AS arrivaldate,
folioschedules.todate AS departuredate,
company.companyname,
rooms.roomtypecode,
folio.source,
folio.folioETA,
folio.folioETD
from
guests force index(primary),
folio force index(primary) left join company on company.companyid = folio.companyid,
folioschedules force index(primary)
left join rooms on rooms.roomid = folioschedules.roomid
where
folio.accountid = guests.accountid and
folioschedules.folioid = folio.folioid and
(folio.status = 'ONGOING' or folio.status = 'CONFIRMED')and
( pAuditDate >= date(folioschedules.fromdate) and  pAuditDate <= date(folioschedules.todate) ) and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = pHotelId
order by folioschedules.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectGuestForToolTipCalendar` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectGuestForToolTipCalendar` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectGuestForToolTipCalendar`(
in photelid int(5)
)
BEGIN
set sql_big_selects = 1;
select 	distinct
folio.status,
folio.folioid,
folio.foliotype,
folio.noofadults,
guests.accountid,
concat(guests.lastname," , ",guests.firstname) as GuestName,
concat(guests.street,", ",guests.city, ", ",guests.country) as Address1,
guests.telephoneNo,
guests.citizenship,
folioschedules.roomid,
folioschedules.rate,
folio.remarks,
folioschedules.fromdate AS arrivaldate,
folioschedules.todate AS departuredate,
company.companyname,
rooms.roomtypecode,
folio.source,
folio.groupname
from
folio force index(primary) 
left join guests on guests.accountid = folio.accountid
left join company on company.companyid = folio.companyid,
folioschedules force index(primary)
left join rooms on rooms.roomid = folioschedules.roomid
where
folioschedules.folioid = folio.folioid and
(folio.status = 'ONGOING' or folio.status = 'CONFIRMED' or folio.status = 'TENTATIVE')and
folioschedules.hotelid = folio.hotelid and
folio.hotelid = pHotelId
order by folioschedules.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectGuests` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectGuests` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectGuests`(in pHotelID int(5))
BEGIN
select 
*
from 
guests 
where 
stateflag <> 'DELETED' and 
hotelid = photelid
order by lastname, firstname;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectHKLog` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectHKLog` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectHKLog`()
BEGIN
Select * from hk_log;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectHotel` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectHotel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectHotel`()
BEGIN
Select * from Hotel Where stateFlag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectHouseKeepers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectHouseKeepers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectHouseKeepers`(
in pHotelId int(5)
)
BEGIN
select *
from hk_housekeepers
where stateflag <> 'DELETED' and hotelId = pHotelId
order by housekeeperid
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectItemForMenuDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectItemForMenuDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectItemForMenuDetail`()
BEGIN
Select ITEM_ID,DESCRIPTION from item where `STATUS`='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectJoinerFolioByMasterFolioID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectJoinerFolioByMasterFolioID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectJoinerFolioByMasterFolioID`(
in pFolioId varchar(50),
in pHotelId int(4)
)
BEGIN
select 
folio.*,
guests.lastname,
guests.firstname,
guests.middlename,
guests.street,
guests.city,
guests.country,
guests.citizenship,
guests.passportid
from folio
left join guests on folio.accountid = guests.accountid
where masterfolio = pFolioId
and folio.hotelid = pHotelId and
not(folio.Status = "CANCELLED" or folio.status = "CLOSED" or folio.status = 'REMOVED')
and (select foliotype from folio where folioid=pFolioID) != 'GROUP';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectMenuDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectMenuDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectMenuDetails`(
pMENU_ID varchar(10)
)
BEGIN
select `menu detail`.ITEM_ID,DESCRIPTION,QUANTITY from item,`menu detail`
where  
`menu detail`.ITEM_ID=item.ITEM_ID
and MENU_ID=pMENU_ID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectMenus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectMenus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectMenus`(
)
BEGIN
Select * from menus;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectNonGuestTransactions` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectNonGuestTransactions` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectNonGuestTransactions`(
in pAuditDate date
)
BEGIN
select *,drivers.lastName, drivers.firstName from nonguesttransaction
left join drivers on drivers.driverId = nonguesttransaction.referenceDriverId
where
date(nonguesttransaction.transactiondate) = pAuditDate and
nonguesttransaction.statusFlag = 'ACTIVE' order by postingdate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectPackageDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectPackageDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectPackageDetails`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectPackageHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectPackageHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectPackageHeader`(
pHotelId int(5)
)
BEGIN
SELECT * FROM packageheader WHERE HotelID=pHotelId AND stateFlag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectPrivilegeDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectPrivilegeDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectPrivilegeDetails`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectPrivilegeHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectPrivilegeHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectPrivilegeHeader`(
pHotelId int(5)
)
BEGIN
SELECT * FROM privilegeheader WHERE HotelID=pHotelId AND stateFlag='ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectPrivileges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectPrivileges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectPrivileges`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectPromos` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectPromos` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectPromos`()
BEGIN
select promos.promoname,promos.percentoff,
promos.startdate,promos.enddate,
promos.promocode
from promos where promos.stateflag <> 'deleted'
order by promos.promocode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRateCodes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRateCodes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRateCodes`( in photelid int(5))
BEGIN
select *
from ratecodes where hotelid = photelid and stateflag = 'ACTIVE'
order by ratecode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRateTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRateTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRateTypes`(
in photelid int(5)
)
BEGIN
select 	
*
from ratetypes 
where hotelid = photelid and statusFlag != 'DELETED'
order by rateamount desc, ratecode desc, hasbreakfast asc;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectReservationList` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectReservationList` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectReservationList`()
BEGIN
Select (Folio.FolioID) as `ID`,folio.FolioType,guest.Firstname,guest.Lastname,folio.AccountType,Folio.Status 
from folio,guest
where folio.accountid=guest.accountid and folio.status<>'CLOSED' and folio.status<>'No Show' and folio.status<>'Cancelled';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoleMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoleMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoleMenu`(
pRoleName varchar(30),
pHotelId int(5)
)
BEGIN
Select * 
FROM 
rolemenu 
Where 
RoleName=pRoleName and 
HotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoles` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoles` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoles`(
pHotelId int(5)
)
BEGIN
Select * from Roles Where  HotelId=pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoomAmenities` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoomAmenities` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoomAmenities`(
in proomid varchar(10),
in photelid int(5)
)
BEGIN
select roomamenities.amenityid,amenities.name
from roomamenities,amenities
where roomamenities.amenityid = amenities.amenityid and roomamenities.roomid = proomid
and roomamenities.hotelid  = photelid AND roomamenities.stateflag <> 'DELETED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoomBlockForToolTip` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoomBlockForToolTip` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoomBlockForToolTip`(
in pHotelId int(5),
in pAuditDate date
)
BEGIN
select 
blockingdetails.roomid, 
"BLOCKING" as eventtype,
roomblock.blockid,
roomblock.reason,
date(blockingdetails.blockfrom) as FromDate,
date(blockingdetails.blockto) as ToDate,
fGetRoomStatus(blockingdetails.roomid) as cleaningStatus
from 
roomblock force index(primary) left join blockingdetails on
blockingdetails.blockid = roomblock.blockid
left join
rooms on rooms.roomid = blockingdetails.roomid 
where
rooms.roomtypecode != 'FUNCTION' and
date(blockfrom) <= pAuditDate and date(blockto) > pAuditDate and
roomblock.hotelid = pHotelId
order by blockingdetails.roomid
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoomByCleaningStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoomByCleaningStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoomByCleaningStatus`(
in pcleaningstatus varchar(11)
)
BEGIN
select rooms.roomid,
rooms.roomtypecode,rooms.stateflag,
rooms.cleaningstatus
from rooms
where rooms.stateflag <> 'deleted'
and rooms.cleaningstatus = pcleaningstatus;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoomEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoomEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoomEvent`(
in pDate date,
in pEndDate date
)
BEGIN
set  sql_big_selects=1;
select 
if(roomevents.eventtype = 'ENGINEERING JOB',"",
concat(Guests.Lastname, ", ", Guests.Firstname)) as GuestName ,
if(roomevents.eventtype = 'ENGINEERING JOB', "" , Company.CompanyName) as Company,
folio.groupname,
folio.foliotype,
roomevents.`eventdate`,
roomevents.roomid ,
roomevents.eventtype,
roomevents.eventid,
roomevents.transferflag,
roomevents.startTime,
roomevents.endTime,
rooms.roomtypecode,
roomtypes.roomsupertype,
if(folio.status is null, "",folio.status) as foliostatus
from roomevents force index(`primary`) 
left join folio force index(folioid) on (roomevents.eventid = folio.folioid)
left join guests on (guests.accountid = folio.accountid)
left join company on folio.companyid = company.companyid
left join rooms on (rooms.roomid = roomevents.roomid) left join roomtypes on (rooms.roomtypecode=roomtypes.roomtypecode)
where  ( roomevents.eventdate between pDate and pEndDate ) 
And roomevents.eventtype<>'CLOSED' And roomevents.eventtype<>'NO SHOW' and roomevents.eventtype<>'CANCELLED'
order by roomevents.eventid,roomevents.roomid,roomevents.eventdate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoomEventsForFloorOccupancy` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoomEventsForFloorOccupancy` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoomEventsForFloorOccupancy`(
in pHotelId int(4),
in pAuditDate date
)
BEGIN
select distinct
rooms.roomid,
rooms.floor,
rooms.xcoordinate,
rooms.ycoordinate,
roomevents.eventdate,
roomevents.eventtype 
from
rooms left join roomevents on roomevents.roomid = rooms.roomid and
roomevents.eventdate = pAuditDate and roomevents.eventtype <> "CLOSED"
where
rooms.hotelid= pHotelId
order by roomid,`floor`;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoomId` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoomId` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoomId`()
BEGIN
select rooms.roomid
from rooms where rooms.stateflag <> 'deleted'
order by rooms.roomid
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoomIDByRoomSuperType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoomIDByRoomSuperType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoomIDByRoomSuperType`(
in proomsupertype varchar(50),
in photelid int(5)
)
BEGIN
select rooms.roomid
from rooms, roomtypes
where rooms.stateflag <> 'DELETED' and 
rooms.roomtypecode = roomtypes.roomtypecode and 
rooms.hotelid = photelid and roomtypes.roomsupertype=proomsupertype
order by rooms.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoomIDByRoomType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoomIDByRoomType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoomIDByRoomType`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRooms`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectRoomTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectRoomTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectRoomTypes`(
in photelid int(5)
)
BEGIN
select *
from roomtypes
where roomtypes.statusflag <> 'DELETED' and hotelid = photelid
order by roomtypes.roomtypecode
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectShareFolioByMasterFolioID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectShareFolioByMasterFolioID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectShareFolioByMasterFolioID`(
in pFolioId varchar(50),
in pHotelId int(4)
)
BEGIN
select 
folio.*,
guests.lastname,
guests.firstname,
guests.middlename,
guests.street,
guests.city,
guests.country,
guests.citizenship,
guests.passportid
from folio
left join guests on folio.accountid = guests.accountid
where masterfolio = pFolioId
and folio.hotelid = pHotelId and
not(folio.Status = "CANCELLED" or folio.status = "CLOSED" or folio.status = 'REMOVED')
and (select foliotype from folio where folioid=pFolioID)!='GROUP';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectSystemConfig` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectSystemConfig` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectSystemConfig`()
BEGIN
select * from system_config;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectSystemConfiguration` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectSystemConfiguration` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSelectSystemConfiguration`()
BEGIN
select * from system_config where system_file = 0;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectTransactionCodes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectTransactionCodes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectTransactionCodes`(
in pHotelId int(5)
)
BEGIN
select * from transactioncode
where stateFlag = 'ACTIVE' and hotelId = pHotelId
order by trancode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectTransactionSourceDocuments` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectTransactionSourceDocuments` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSelectTransactionSourceDocuments`()
BEGIN
select * from transactionsourcedocuments where statusFlag = 'ACTIVE';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectTransactionTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectTransactionTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectTransactionTypes`(
in photelid int(5)
)
BEGIN
select * 
from 
TranTypes 
where stateflag = 'ACTIVE' and
hotelid = photelid
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectTransctioncode_SubAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectTransctioncode_SubAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectTransctioncode_SubAccount`(
in pHotelId int(4)
)
BEGIN
select * from transctioncode_subaccount
where statusFlag = 'ACTIVE' and hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectUsers` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectUsers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectUsers`(
)
BEGIN
select
*
from users
where
stateflag <> 'DELETED';
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSelectYesterdayRoomOccupancy` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSelectYesterdayRoomOccupancy` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSelectYesterdayRoomOccupancy`(
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
(roomevents.eventtype = 'IN HOUSE' or roomevents.eventtype = 'CLOSED')
order by rooms.roomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetActualArrival` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetActualArrival` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetActualArrival`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetAuditToProcessed` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetAuditToProcessed` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetAuditToProcessed`(
in pAuditDate varchar(15)
)
BEGIN
update auditdatetable set meridian="PROCESSED" where AuditDate=pAuditDate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetChildFolioStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetChildFolioStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetChildFolioStatus`(
in pMasterFolio varchar(20),
in pStatus varchar(15),
in pHotelID int(5),
in pUpdateTime dateTime,
in pReason text
)
BEGIN
Update folio set `status`=pStatus, updateTime=pUpdateTime, reason_for_cancel=pReason where masterfolio=pMasterFolio and hotelID=pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetChildFollioStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetChildFollioStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetChildFollioStatus`(
in pMasterFolio varchar(12),
in pStatus varchar(15)
)
BEGIN
Update folio set `status`=pStatus where masterfolio=pMasterFolio;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetCompanyNoOfVisits` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetCompanyNoOfVisits` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetCompanyNoOfVisits`(
in pCompanyId varchar(20),
in pHotelId int(4)
)
BEGIN
update company 
set NO_OF_VISIT = NO_OF_VISIT + 1 
where companyid=pCompanyId
and hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetEventType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetEventType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetEventType`(
in pEventType varchar(20),
in pEventID varchar(20),
in pHOtelId int(5)
)
BEGIN
update Roomevents set eventtype=pEventType where EventID=pEventID and hotelID=pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetFolioScheduleType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetFolioScheduleType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetFolioScheduleType`(
in pTYpe varchar(30),
in pFolioID varchar(12),
in pHOtelID int(5)
)
BEGIN
update FolioSchedules set `type`=pType where folioId=pFolioID and hotelID =pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetFolioTransactionStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetFolioTransactionStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetFolioTransactionStatus`(
in pfolioid varchar(12),
in ptrandate datetime,
in ptrancode varchar(5),
in pStatus varchar(10)
)
BEGIN
update foliotransactions set `status`=pStatus 
where folioid=pfolioid 	and transactiondate=ptrandate and transactioncode=ptrancode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetFolioTransactionToAudited` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetFolioTransactionToAudited` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetFolioTransactionToAudited`(
in pAuditDate date,
in pHotelId int(4)
)
BEGIN
update foliotransactions 
set 
auditFlag = 1 where
date(transactionDate) = pAuditDate
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetMasterFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetMasterFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetMasterFolio`(
in pMasterFolio varchar(20),
in pFolioID varchar(20),
in pHotelID int(5)
)
BEGIN
Update folio set MasterFolio=pMasterFolio
where folioID=pFolioID and hotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetNoOfVisits` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetNoOfVisits` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetNoOfVisits`(
in pAccountId varchar(20),
in pHotelId int(4)
)
BEGIN
update guests 
set noofvisits = noofvisits + 1,
ACCOUNT_TYPE = if(noofvisits >= 3, "EXECUTIVE",ACCOUNT_TYPE)
where accountid=pAccountid
and hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetOccupiedRoomsDirty` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetOccupiedRoomsDirty` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetOccupiedRoomsDirty`(
in pHotelid int(5)
)
BEGIN
update 
rooms
set 
cleaningstatus = 'DIRTY'
where 
roomtypecode != 'FUNCTION' and
stateflag = 'OCCUPIED' and
hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetPosted` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetPosted` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetPosted`(in pfolioid varchar(20),in pHOtelID int(5))
BEGIN
update foliotransactions set posttoledger = "1" 
where folioid=pfolioid  and hotelid=pHOtelID;
update folioledger set posttoledger="1" 
where folioid=pfolioid  and hotelid=pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetReferenceNo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetReferenceNo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSetReferenceNo`(
pFolioID varchar(20),
pReferenceNo varchar(20),
pHotelID int
)
BEGIN
update folio set
referenceNo = pReferenceNo
where
folioID = pFolioID and
hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetRoomAsCharged` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetRoomAsCharged` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetRoomAsCharged`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetRoomCleaningStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetRoomCleaningStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetRoomCleaningStatus`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetRoomEventPosted` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetRoomEventPosted` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSetRoomEventPosted`(
in pFolioId varchar(20),
in pROomId varchar(20),
in pEventDate date,
in pHotelId int(4)
)
BEGIN
update roomevents
set chargeFlag = 1
where
eventId = pFolioId and
roomId = pRoomId and
eventDate = date(pEventDate) and
transferFlag = 0 and
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetRoomStateFlag` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetRoomStateFlag` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spSetRoomStateFlag`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spSetTransactionsToAudit` */

/*!50003 DROP PROCEDURE IF EXISTS  `spSetTransactionsToAudit` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spSetTransactionsToAudit`(
pHotelId int,
pFolioId varchar(30)
)
BEGIN
update foliotransactions set auditFlag = '1' where folioId = pFolioId and hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spTransferFolioTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spTransferFolioTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spTransferFolioTransaction`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUnconfirmEventReservation` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUnconfirmEventReservation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUnconfirmEventReservation`(
	pEventId varchar(20)
	, pUser varchar(20)
)
BEGIN
	update folio
		set folio.Status = 'TENTATIVE'
		, folio.referenceNo = ''
		, folio.updateTime = now()
		, folio.updatedBy = pUser
	where folio.folioID = pEventId and folio.Status = 'CONFIRMED';
    END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateAccountInformation` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateAccountInformation` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateAccountInformation`(
pAccountID varchar(20),
pHotelID int,
pAffiliations text,
pOfficeOfficers text,
pNatureOfBusiness text,
pPillarsOfOrganization text,
pAnniversary datetime
)
BEGIN
update account_information set
affiliations = pAffiliations,
officeOfficers = pOfficeOfficers,
natureOfBusiness = pNatureOfBusiness,
pillarsOfOrganization = pPillarsOfOrganization,
anniversary = pAnniversary
where
accountID = pAccountID and hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateAgent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateAgent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateAgent`(
in pAgentId         int(10),
in pAddress    	text,
in pAgency         varchar(150), 
in pContactNo        varchar(50), 
in pContactPerson       varchar(100),
in pUPDATED_BY       varchar(50), 
in pHOTEL_ID         int(4)
)
BEGIN
update agents
set 
address = pAddress,
agency = pAgency, 
contactNumber = pContactNo, 
contactPerson = pContactPerson,
UPDATED_DATE = now(), 
UPDATED_BY = pUPDATED_BY
where
agentID = pAgentId and
HOTEL_ID = pHOTEL_ID
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateAllJoinerFolioStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateAllJoinerFolioStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateAllJoinerFolioStatus`(
in pStatus varchar(20),
in pMasterFolio varchar(20),
in pHotelId int(4),
in pUpdatedBy varchar(50)
)
BEGIN
update folio
set
`status` = pStatus,
updatedby = pUpdatedBy,
updatetime = now()
where
MasterFolio = pMasterFolio and
hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateAllShareFolioStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateAllShareFolioStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateAllShareFolioStatus`(
in pStatus varchar(20),
in pMasterFolio varchar(20),
in pHotelId int(4),
in pUpdatedBy varchar(50)
)
BEGIN
update folio
set
`status` = pStatus,
updatedby = pUpdatedBy,
updatetime = now()
where
MasterFolio = pMasterFolio and
hotelid = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateAmenity` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateAmenity` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateAmenity`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateAppliedRates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateAppliedRates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateAppliedRates`(
pAppliedRateID bigint(10),
pDescription text,
pOccupants int(5),
pHotelID int(10),
pUser varchar(20),
pRateType varchar(20))
BEGIN
update appliedRates set description=pDescription, noOfOccupants=pOccupants, updatedby=pUser, updatetime=now(), rateType=pRateType where appliedRateID=pAppliedRateID and hotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateCallCharge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateCallCharge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateCallCharge`(
in pCallNo int(4)
)
BEGIN
update callcharges
set PostedToFolio = 1
where
CallNo = pCallNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateCashier` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateCashier` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateCashier`(
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
pHotelId             int(5),
pUpatedBy            varchar(20),
pRemarks	     text,
pAuditDate datetime
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
UpdateTime = pAuditDate, 
UPDATEDBY = pUpatedBy,
Remarks = pRemarks
where
terminalid = pTerminalId and
cashierid = pCashierId and
HOTELID = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateCashierShiftAmount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateCashierShiftAmount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateCashierShiftAmount`(
in pAcctside varchar(20),
in pTransactioncode varchar(20),
in pBaseamount double(12,2),
in pTerminalid int(4),
in pShiftcode int(4),
in pAuditDate date
)
BEGIN
if (pAcctside = 'CREDIT') then
case pTransactioncode
when '2000' then  
update cashiers set cash = cash + pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '2100' then   
update cashiers set creditcard = creditcard + pBaseamount 
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '2200' then   
update cashiers set cheque = cheque + pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '2300' or '4200' then    
update cashiers set chargeinamount = chargeinamount + pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '2600' then     
update cashiers set others = others + pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '2800' then     
update cashiers set others = others + pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
else
update cashiers set others = others
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
end case;
else
case pTransactionCode
when '6000' then
update cashiers set cash = cash - pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '3300' then
update cashiers set cash = cash - pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
else
update cashiers set others = others
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
end case;
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateCashierShiftAmountVoid` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateCashierShiftAmountVoid` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateCashierShiftAmountVoid`(
in pAcctside varchar(20),
in pTransactioncode varchar(20),
in pBaseamount double(12,2),
in pTerminalid int(4),
in pShiftcode int(4),
in pAuditDate date
)
BEGIN
if (pAcctside = 'CREDIT') then
case pTransactioncode
when '2000' then  
update cashiers set cash = cash - pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '2100' then   
update cashiers set creditcard = creditcard - pBaseamount 
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '2200' then   
update cashiers set cheque = cheque - pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '2300' then    
update cashiers set chargeinamount = chargeinamount - pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '2600' then     
update cashiers set others = others - pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '2800' then     
update cashiers set others = others - pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '6000' then
update cashiers set cash = cash - pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
else
update cashiers set others = others
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
end case;
else
case pTransactionCode
when '6000' then
update cashiers set cash = cash + pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
when '3300' then
update cashiers set cash = cash + pBaseamount
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
else
update cashiers set others = others
where cashiers.terminalid = pTerminalid
and cashiers.shiftcode = pShiftcode and date(UPDATETIME) = pAuditDate;
end case;
end if;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateCompanyAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateCompanyAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateCompanyAccount`(
in `pcompanyid` varchar(20),       
in `pcompanycode` varchar(50),         
in `pcompanyname` varchar(150),
in `pcompanyurl` varchar(100),                  
in `pcontactperson` varchar(200),         
in `pdesignation` varchar(200),         
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
in photelid int(5),
in pAccount_Type varchar(100),
in pCard_No varchar(100),
in pThreshold_Value double(12,2),
in pX_DEAL_AMOUNT double(12,2),
in pRemarks text,
in pTIN varchar(20)
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
updatetime = now(),
Account_Type = pAccount_Type,
Card_No = pCard_No,
Threshold_Value = pThreshold_Value,
X_DEAL_AMOUNT = pX_DEAL_AMOUNT,
Remarks = pRemarks,
TIN = pTin
where
`companyid` = `pcompanyid` and 
hotelid = photelid
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateCompanyAccountTotalSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateCompanyAccountTotalSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateCompanyAccountTotalSales`(
in pAccountId varchar(20),
in pAmount double(12,2),
in pHotelId int(4)
)
BEGIN
update company
set
TOTAL_SALES_CONTRIBUTION = TOTAL_SALES_CONTRIBUTION + pAmount
where
companyid = pAccountId and HotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateCompanyInfoFromFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateCompanyInfoFromFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateCompanyInfoFromFolio`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateContact` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateContact` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateContact`(
pId int(10),
pContactNumber  varchar(100),
pContactType    varchar(20),
pContactName    varchar(100),
pFullName       varchar(200),
pDesignation    varchar(50),
pCompany        varchar(100),
pAddress        varchar(200),
pEmailAddress   varchar(100),
pRemarks        varchar(500),
pUpdatedBy      varchar(20),
pHotelId        int(4)
)
BEGIN
update `contacts` 
set
contactNumber = pContactNumber,
contactType = pContactType,
contactName = pContactName, 
fullName = pFullName,
designation = pDesignation,
company = pCompany,
address = pAddress, 
emailAddress = pEmailAddress,
remarks = pRemarks, 
updatedBy = pUpdatedBy,
updateTime = now()
where
id = pId and hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateContactPerson` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateContactPerson` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateContactPerson`(
pContactID varchar(20),
pLastName varchar(50),
pFirstName varchar(50),
pMiddleName varchar(50),
pDesignation varchar(50),
pPersonType varchar(50),
pAddress varchar(100),
pTelNo varchar(50),
pMobileNo varchar(50),
pFaxNo varchar(50),
pEmail varchar(50),
pFolioID varchar(20),
pAccountID varchar(20),
pHotelID int(5),
pCreatedBy varchar(50),
pBirthdate datetime
)
BEGIN
update contactpersons set
lastName = pLastName,
firstName = pFirstName,
middleName = pMiddleName,
designation = pDesignation,
personType = pPersonType,
address = pAddress,
telNo = pTelNo,
mobileNo = pMobileNo,
faxNo = pFaxNo,
email = pEmail,
`status` = 'ACTIVE',
folioID = pFolioID,
accountID = pAccountID,
hotelID = pHotelID,
updatedBy = pCreatedBy,
birthdate = pBirthdate,
updatedOn = now() where contactID = pContactID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateCurrencyCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateCurrencyCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateCurrencyCode`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateDayEndProcessConfig` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateDayEndProcessConfig` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateDayEndProcessConfig`(
pHotelId            int(4),
pProcessType        enum('MANUAL','SCHEDULED'),
pScheduleTime       varchar(15),
pTerminalNo         int(2),
pNotifySchedule     int(10),
pReportsToGenerate  text,
pBackUpDatabase tinyint(1),
pUpdatedBy          varchar(50)
)
BEGIN
update `dayendprocessconfig` 
set 
processType = pProcessType, 
scheduleTime = pScheduleTime, 
terminalNo = pTerminalNo, 
notifySchedule = pNotifySchedule, 
reportsToGenerate = pReportsToGenerate, 
backupDatabase = pBackUpDatabase,
updatedBy = pUpdatedBy, 
updatedDate = now()
where
hotelId = pHotelId; 
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateDepartment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateDepartment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateDepartment`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateDriver` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateDriver` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateDriver`(
in pDriverId         int(10),
in pLicenseNumber    varchar(100),
in pLastName         varchar(50), 
in pFirstName        varchar(50), 
in pMiddleName       varchar(100),
in pUPDATED_BY       varchar(50), 
in pHOTEL_ID         int(4),
in pCompany	varchar(60),
in pCarModel	varchar(50),
in pBrand	varchar(50),
in pPlateNumber	varchar(10)
)
BEGIN
update drivers
set 
licenseNumber = pLicenseNumber,
lastName = pLastName, 
firstName = pFirstName, 
middleName = pMiddleName,
UPDATED_DATE = now(), 
UPDATED_BY = pUPDATED_BY,
company = pCompany,
carModel = pCarModel,
brand = pBrand,
plateNumber = pPlateNumber
where
driverId = pDriverId and
HOTEL_ID = pHOTEL_ID
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateEngineeringJob` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateEngineeringJob` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateEngineeringJob`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateEngineeringService` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateEngineeringService` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateEngineeringService`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateEvent` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateEvent` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateEvent`(pFolioID varchar(20),
pEventType varchar(40),
pLiveIn int(5),
pLiveOut int(5),
pGuaranteed int(5),
pBillingArrangement text,
pAuthorizedSignatory text,
pLobbyPosting text,
pCreatedBy varchar(20),
pHotelID int(2),
pEventPackage bigint(10),
pPackageAmount double(12,2),
pContactPerson text,
pContactAddress text,
pContactPosition varchar(200),
pContactNumber varchar(20),
pMobileNumber varchar(30),
pFaxNumber varchar(20),
pTotal double(12,2),
pEmailAdd varchar(100)
)
BEGIN
update event_booking_info set 
eventType=pEventType, 
noOfPaxLiveIn=pLiveIn, 
noOfPaxLiveOut=pLiveOut, 
noOfPaxGuaranteed=pGuaranteed, 
billingArrangement=pBillingArrangement, 
authorizedSignatory=pAuthorizedSignatory, 
lobbyPosting=pLobbyPosting, 
hotelID=pHotelID, 
updatetime=now(), 
updatedby=pCreatedBy, 
eventPackage=pEventPackage, 
packageAmount=pPackageAmount, 
contactperson=pContactperson, 
contactaddress=pContactaddress, 
contactposition=pContactposition, 
contactnumber=pContactnumber,
mobileNumber=pMobileNumber,
faxNumber=pFaxNumber,
totalEstimatedCost=pTotal,
emailAddress=pEmailAdd
where folioID=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateEventAttendance` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateEventAttendance` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateEventAttendance`(
pFolioID varchar(20),
pHotelID int,
pGeographicalScope varchar(50),
pForeignParticipants int,
pLocalParticipants int,
pForeignBased int,
pLocalBased int,
pNoOfVisitors int,
pActualAttendees int,
pRemarks text,
pUpdatedBy varchar(20)
)
BEGIN
update event_attendance set
GeographicalScope = pGeographicalScope,
ForeignParticipants = pForeignParticipants,
LocalParticipants = pLocalParticipants,
ForeignBased = pForeignBased,
LocalBased = pLocalBased,
NoOfVisitors = pNoOfVisitors,
ActualAttendees = pActualAttendees,
Remarks = pRemarks,
UpdatedBy = pUpdatedBy,
UpdatedOn = now()
where
FolioID = pFolioID and HotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateEventEndorsement` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateEventEndorsement` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateEventEndorsement`(
pFolioID varchar(20),
pLetterOfProposal varchar(30),
pContractAmount decimal(10,2),
pDueDate1 datetime,
pDueDate2 datetime,
pDueDate3 datetime,
pLetterOfAgreement varchar(20),
pPickupDate datetime,
pSentToClientDate datetime,
pSignedDate datetime,
pHotelID int,
pConcessions text,
pGiveaways text,
pUpdatedBy varchar(20)
)
BEGIN
update event_endorsement set
letterOfProposal = pLetterOfProposal,
contractAmount = pContractAmount,
dueDate1 = pDueDate1,
dueDate2 = pDueDate2,
dueDate3 = pDueDate3,
letterOfAgreement = pLetterOfAgreement,
pickupDate = pPickupDate,
sentToClientDate = pSentToClientDate,
signedDate = pSignedDate,
hotelID = pHotelID,
concessions = pConcessions,
giveaways = pGiveaways,
updatedBy = pUpdatedBy,
updatedOn = now()
where folioID = pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateEventOfficer` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateEventOfficer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateEventOfficer`(
pID varchar(20),
pUserID varchar(30),
pFolioID varchar(20),
pHotelID int,
pUpdatedBy varchar(20)
)
BEGIN
update event_officers set userID = pUserID ,folioID = pFolioID, hotelID = pHotelID, updatedBy = pUpdatedBy, updatedOn = now(), `status` = 'ACTIVE' where ID = pID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateEventPackage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateEventPackage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateEventPackage`(pPackageID bigint(20), pDescription text, pDaysApplied int(5), pEventType varchar(40), pPackageAmount double(12,2), pHotelID int(10), pUser varchar(20), pMinimumPax int, pMaximumPax int)
BEGIN
update event_package_header set description=pDescription, daysApplied=pDaysApplied, eventType=pEventType, packageAmount=pPackageAmount, updatedby= pUser, updatetime=now(), MinimumPax=pMinimumPax, MaximumPax=pMaximumPax where hotelID=pHotelID and packageID=pPackageID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateEventTypes` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateEventTypes` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateEventTypes`(
in pTypeID   	          int(10),
in pEventType    	  varchar(40), 
in pDescription 	  text,
in pUPDATED_BY      	  varchar(50),
in pBanquet		  int(2)
)
BEGIN
update event_type
set 
eventType = pEventType,
description = pDescription,
UPDATETIME = now(), 
UPDATEDBY = pUPDATED_BY,
banquetType = pBanquet
where
typeID = pTypeID ;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFloorLayoutImage` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFloorLayoutImage` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFloorLayoutImage`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolio` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolio` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolio`(
in pHotelID            int(5),
in pFolioID            varchar(20),
in pAccountID          varchar(20),
in pReferenceNo        varchar(20),
in pFolioType          varchar(25),
in pGroupName          text,
in pAccountType        varchar(25),
in pNoOfAdults         int(2),
in pNoOfChild          int(2),
in pMasterFolio        varchar(20),
in pCompanyID          varchar(20),
in pAgentID            varchar(20),
in pSource             varchar(50),
in pFromDate           datetime,
in pToDate             datetime,
in pArrivalDate        datetime,
in pDepartureDate      datetime,
in pPackageId          varchar(20),
in pStatus             varchar(15),
in pRemarks            text,
in pTerminal_Id        varchar(20),
in pShift_Code         varchar(20),
in pSupervisor_Id      varchar(50),
in pSales_Executive    varchar(20),
in pPayment_Mode       varchar(20),
in pPurpose            varchar(50),
in pReason_For_Cancel  text,
in pTaxExempted        tinyint(1),
in pFolioETA	       varchar(10),
in pFolioETD 	       varchar(10),
in pUpdatedBy          varchar(20)
)
BEGIN
update `folio` 
set
accountID = pAccountID, 
referenceNo = pReferenceNo,
folioType = pFolioType, 
groupName = pGroupName, 
accountType = pAccountType, 
noOfAdults = pNoOfAdults, 
noOfChild = pNoOfChild, 
masterFolio = pMasterFolio, 
companyID = pCompanyID, 
agentID = pAgentID, 
source = pSource, 
fromDate = pFromDate, 
toDate = pToDate, 
arrivalDate = pArrivalDate, 
departureDate = pDepartureDate, 
packageId = pPackageId, 
`Status` = pStatus, 
remarks = pRemarks, 
terminal_Id = pTerminal_Id, 
shift_Code = pShift_Code, 
supervisor_Id = pSupervisor_Id, 
sales_Executive = pSales_Executive, 
payment_Mode = pPayment_Mode, 
purpose = pPurpose, 
reason_For_Cancel = pReason_For_Cancel, 
taxExempted = pTaxExempted,
folioETA = pFolioETA,
folioETD = pFolioETD,
updateTime = now(), 
updatedBy = pUpdatedBy
where
hotelID = pHotelID and 
folioID = pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioBalance` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioBalance` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioBalance`(in pFolioID varchar(12))
BEGIN
update folio set balance=totalcharges-totalPayments where folioid=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioLedger` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioLedger` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioLedger`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioLedgerCharges` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioLedgerCharges` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioLedgerCharges`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioLedgerChargesVOID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioLedgerChargesVOID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioLedgerChargesVOID`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioLedgerPayments` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioLedgerPayments` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioLedgerPayments`(
in pfolioid varchar(20),
in photelid int(5),
in psubfolio varchar(1),
in pPayCash decimal(12,2),
in pPayCard decimal(12,2),
in pPayCheque decimal(12,2),
in pPaygiftCheque decimal(12,2),
in pbalanceforwarded decimal(12,2),
in pDiscount decimal(12,2),
in pupdatedby varchar(20),
in pLocalTax decimal(12,2),
in pGovtTax decimal (12,2),
in pServiceCharge decimal(12,2)
)
BEGIN
update folioledger
set 
paycash = paycash + pPayCash,
paycard = paycard + pPayCard,
paycheque = paycheque + pPayCheque,
paygiftcheque = PaygiftCheque + pPaygiftCheque,
balanceforwarded = balanceforwarded + pbalanceforwarded,
discount = discount + pDiscount,
balancenet = balancenet - 
(pPayCash+pPayCard+pPayCheque+pPaygiftCheque+pbalanceforwarded+pDiscount),
updatetime = now(),
updatedby = pupdatedby,
localTax = localTax - pLocalTax,
governmenttax = governmentTax - pGovtTax,
serviceCharge = serviceCharge - pServiceCharge
where
folioid = pfolioid and
hotelid = photelid and
subfolio = psubfolio;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioLedgerPaymentsVOID` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioLedgerPaymentsVOID` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioLedgerPaymentsVOID`(
in pfolioid varchar(20),
in photelid int(5),
in psubfolio varchar(1),
in pPayCash decimal(12,2),
in pPayCard decimal(12,2),
in pPayCheque decimal(12,2),
in pPaygiftCheque decimal(12,2),
in pbalanceforwarded decimal(12,2),
in pDiscount decimal(12,2),
in pupdatedby varchar(20),
in pLocalTax decimal(12,2),
in pGovtTax decimal (12,2),
in pServiceCharge decimal(12,2)
)
BEGIN
update folioledger
set 
paycash = paycash - pPayCash,
paycard = paycard - pPayCard,
paycheque = paycheque - pPayCheque,
paygiftcheque = PaygiftCheque - pPaygiftCheque,
balanceforwarded = balanceforwarded - pbalanceforwarded,
discount = discount - pDiscount,
balancenet = balancenet + 
(pPayCash+pPayCard+pPayCheque+pPaygiftCheque+pbalanceforwarded+pDiscount),
updatetime = now(),
updatedby = pupdatedby,
localTax = localTax - pLocalTax,
governmenttax = governmentTax - pGovtTax,
serviceCharge = serviceCharge - pServiceCharge
where
folioid = pfolioid and
hotelid = photelid and
subfolio = psubfolio;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioLedger_Merge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioLedger_Merge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioLedger_Merge`(
in newAccountId varchar(20),
in oldAccountId varchar(20),
in pHotelId int(4)
)
BEGIN
update folioledger set accountId = newAccountId
where accountId = oldAccountId and
hotelId = pHotelId
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioLedger_MergeCompany` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioLedger_MergeCompany` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioLedger_MergeCompany`(
in newAccountId varchar(20),
in oldAccountId varchar(20),
in pHotelId int(4)
)
BEGIN
update folioledger set accountId = newAccountId
where accountId = oldAccountId and
hotelId = pHotelId
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioRateType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioRateType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioRateType`(in pRateType varchar(25))
BEGIN
update folio set rateType=pRateType where folioID=pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioSchedules` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioSchedules` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioSchedules`(    
pFolioId     varchar(20),        
pRoomID      varchar(10),        
pRoomType    varchar(80),     
pFROMDATE    datetime,          
pTODATE      datetime,         
pDays        int(3),        
pRATETYPE    varchar(25),      
pRATE        decimal(12,2),       
pBREAKFAST   varchar(20),       
pUPDATEDBY   varchar(20),
pHotelID     int(5),
pStartTime   time,
pEndTime     time,
pVenue	     text,
pSetup       text,
pRemarks     text
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
UPDATEDBY=pUPDATEDBY,
startTime=pStartTime,
endTime=pEndTime,
venue=pVenue,
setup=pSetup,
remarks=pRemarks,
`status` = 'ACTIVE'
where folioID=pFolioID and 
RoomID=pRoomID and 
hotelID =pHotelID and
fromDate = pFromDate and
toDate = pTodate;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioSchedulesEarlyCheckOut` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioSchedulesEarlyCheckOut` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioSchedulesEarlyCheckOut`(    
pFolioId     varchar(20),        
pRoomID      varchar(10),        
pRoomType    varchar(80),     
pFROMDATE    datetime,          
pTODATE      datetime,   
pDays        int(3),        
pRATETYPE    varchar(25),      
pRATE        decimal(12,2),       
pBREAKFAST   varchar(20),       
pUPDATEDBY   varchar(20),
pHotelID     int(5)
)
BEGIN
update 
folioSchedules 
set 
TODATE = pTODATE,  
Days = pDays,   
updatetime = now(),
UPDATEDBY = pUPDATEDBY
where 
folioID = pFolioID and 
RoomID = pRoomID and 
hotelID = pHotelID and
fromDate = pFromDate and
RoomType = pRoomType and
RATETYPE = pRATETYPE and  
RATE = pRATE and
BREAKFAST = pBREAKFAST;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioStatus`(
in pStatus varchar(15),
in pFolioID varchar(20),
in pHotelID int(5),
in pReason text,
in pUpdateTime datetime
)
BEGIN
Update folio 
set `status`=pStatus,
REASON_FOR_CANCEL = pReason,
updateTime=pUpdateTime
where folioID=pFolioID 
and hotelID=pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioStatusAndRemarks` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioStatusAndRemarks` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioStatusAndRemarks`(
in pStatus varchar(15),
in pFolioID varchar(20),
in pRemarks text,
in pHotelID int(5))
BEGIN
Update folio set `status`=pStatus ,
Remarks=pRemarks
where folioID=pFolioID and hotelID=pHOtelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioStatusToCancelled` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioStatusToCancelled` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateFolioStatusToCancelled`(
in pFolioId varchar(20),
in pReason text,
in pHotelId int(5),
in pUpdatedBy varchar(20),
in pCancelledTime datetime
)
BEGIN
Update folio 
set 
`Status` = 'CANCELLED',
REASON_FOR_CANCEL = pReason,
updatedBy = pUpdatedBy,
updateTime = pCancelledTime
where folioId = pFolioId and 
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioStatusToCheckedIn` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioStatusToCheckedIn` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateFolioStatusToCheckedIn`(
in pFolioId varchar(20),
in pHotelId int(5),
in pUpdatedBy varchar(20),
in pUpdateDate datetime
)
BEGIN
Update folio 
set 
`Status` = 'ONGOING',
arrivaldate = pupdatedate,
updateTime = now(),
updatedBy = pUpdatedBy
where folioId = pFolioId and 
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioStatusToCheckedOut` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioStatusToCheckedOut` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateFolioStatusToCheckedOut`(
in pFolioId varchar(20),
in pRemarks text,
in pCheckOutDate date,
in pHotelId int(5),
in pUpdatedBy varchar(20),
in pUpdateTime datetime
)
BEGIN
Update folio 
set 
`Status` = 'CLOSED',
remarks = pRemarks,
departureDate = pUpdateTime,
toDate = date(pCheckOutDate),
updateTime = now(),
updatedBy = pUpdatedBy
where folioId = pFolioId and 
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioStatusToConfirmed` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioStatusToConfirmed` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateFolioStatusToConfirmed`(
in pFolioId varchar(20),
in pHotelId int(5),
in pUpdatedBy varchar(20)
)
BEGIN
Update folio 
set 
`Status` = 'CONFIRMED',
updateTime = now(),
updatedBy = pUpdatedBy
where folioId = pFolioId and 
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioStatusToNoShow` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioStatusToNoShow` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateFolioStatusToNoShow`(
in pFolioId varchar(20),
in pHotelId int(5),
in pUpdatedBy varchar(20),
in pCancelledTime datetime
)
BEGIN
Update folio 
set 
`Status` = 'NO SHOW',
reason_for_cancel='NO SHOW',
updatedBy = pUpdatedBy,
updateTime=pCancelledTime
where folioId = pFolioId and 
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioStatusToTentative` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioStatusToTentative` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateFolioStatusToTentative`(
in pFolioId varchar(20),
in pHotelId int(5),
in pUpdatedBy varchar(20)
)
BEGIN
Update folio 
set 
`Status` = 'TENTATIVE',
updateTime = now(),
updatedBy = pUpdatedBy
where folioId = pFolioId and 
hotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioTransaction`(
pHotelId                 int(5),
pFolioId                 varchar(20),
pSubFolio                varchar(1),
pAccountId               varchar(20),
pTransactionDate         datetime,
pPostingDate             datetime,
pTransactionCode         varchar(20),
pSubAccount              varchar(100),
pReferenceNo             varchar(20),
pTransactionSource       varchar(20),
pMemo                    varchar(500),
pAcctSide                varchar(10),
pCurrencyCode            varchar(10),
pConversionRate          decimal(12,4),
pCurrencyAmount          decimal(12,2),
pBaseAmount              decimal(12,2),
pGrossAmount             decimal(12,2),
pDiscount                decimal(12,2),
pServiceCharge           decimal(12,2),
pServiceChargeInclusive  tinyint(1),
pGovernmentTax           decimal(12,2),
pGovernmentTaxInclusive  tinyint(1),
pLocalTax                decimal(12,2),
pLocalTaxInclusive       tinyint(1),
pNetBaseAmount           decimal(12,2),
pNetAmount               decimal(12,2),
pCreditCardNo            varchar(20),
pChequeNo                varchar(20),
pAccountName             varchar(100),
pBankName                varchar(100),
pChequeDate              date,
pFOCGrantedBy            varchar(100),
pCreditCardType          varchar(20),
pApprovalSlip            varchar(20),
pCreditCardExpiry        date,
pRouteSequence           varchar(100),
pSourceFolio             varchar(20),
pSourceSubFolio          varchar(1),
pTerminalID              varchar(10),
pShiftCode               varchar(10),
pPostToLedger            varchar(1),
pUpdatedBy               varchar(20),
pRoomID			 varchar(20)
)
BEGIN
update `foliotransactions` 
set
subAccount = pSubAccount, 
referenceNo = pReferenceNo, 
transactionSource = pTransactionSource, 
memo = pMemo, 
acctSide = pAcctSide, 
currencyCode = pCurrencyCode, 
conversionRate = pConversionRate, 
currencyAmount = pCurrencyAmount, 
baseAmount = pBaseAmount, 
grossAmount = pGrossAmount, 
discount = pDiscount, 
serviceCharge = pServiceCharge, 
serviceChargeInclusive = pServiceChargeInclusive, 
governmentTax = pGovernmentTax, 
governmentTaxInclusive = pGovernmentTaxInclusive, 
localTax = pLocalTax, 
localTaxInclusive = pLocalTaxInclusive, 
netBaseAmount = pNetBaseAmount, 
netAmount = pNetAmount, 
creditCardNo = pCreditCardNo, 
chequeNo = pChequeNo, 
accountName = pAccountName, 
bankName = pBankName, 
chequeDate = pChequeDate, 
FOCGrantedBy = pFOCGrantedBy, 
creditCardType = pCreditCardType, 
approvalSlip = pApprovalSlip, 
creditCardExpiry = pCreditCardExpiry, 
routeSequence = pRouteSequence, 
sourceFolio = pSourceFolio, 
sourceSubFolio = pSourceSubFolio, 
terminalID = pTerminalID, 
shiftCode = pShiftCode, 
updateTime = now(), 
updatedBy = pUpdatedBy,
roomID = pRoomID
where
hotelId = pHotelId and
hotelId = pFolioId and
subFolio = pSubFolio and
accountId = pAccountId and
transactionDate = pTransactionDate and
postingDate = pPostingDate and
transactionCode = pTransactionCode;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioTransactionForTransfer` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioTransactionForTransfer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateFolioTransactionForTransfer`(
pFolioTransactionNo      int(20),
pFolioId                 varchar(20),
pSubFolio                varchar(1),
pAccountId               varchar(20),
pRouteSequence           varchar(100),
pSourceFolio             varchar(20),
pSourceSubFolio          varchar(1),
pUpdatedBy               varchar(20)
)
BEGIN
update foliotransactions set 
folioId = pFolioId,
subFolio = pSubFolio,
accountId = pAccountId,
routeSequence = pRouteSequence,
sourceFolio = pSourceFolio,
sourceSubFolio = pSourceSubFolio,
updateTime = now(),
updatedBy = pUpdatedBy
where
folioTransactionNo = pFolioTransactionNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioTransactions_Merge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioTransactions_Merge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioTransactions_Merge`(
in newAccountId varchar(20),
in oldAccountId varchar(20),
in pHotelId int(4)
)
BEGIN
update foliotransactions set accountId = newAccountId
where accountId = oldAccountId and
hotelId = pHotelId
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolioTransactions_MergeCompany` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolioTransactions_MergeCompany` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolioTransactions_MergeCompany`(
in newAccountId varchar(20),
in oldAccountId varchar(20),
in pHotelId int(4)
)
BEGIN
update foliotransactions set accountId = newAccountId
where accountId = oldAccountId and
hotelId = pHotelId
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolio_Merge` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolio_Merge` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolio_Merge`(
in newAccountId varchar(20),
in oldAccountId varchar(20),
in pHotelId int(4)
)
BEGIN
update folio set accountId = newAccountId
where accountId = oldAccountId and
hotelId = pHotelId
;
insert into folio_merge_history
(oldAccountId, newAccountId, 
createdBy, createdDate)
values
(oldAccountId, newAccountId, 
'USER', now());
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFolio_MergeCompany` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFolio_MergeCompany` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateFolio_MergeCompany`(
in newAccountId varchar(20),
in oldAccountId varchar(20),
in pHotelId int(4)
)
BEGIN
update folio set companyId = newAccountId
where companyId = oldAccountId and
hotelId = pHotelId
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateFoodRequirements` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateFoodRequirements` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateFoodRequirements`(pFolioID varchar(20),
pEventDate datetime,
pVenue varchar(30),
pPax int(5),
pStartTime varchar(25),
pEndTime varchar(25),
pOver text,
pSetup text,
pRemarks text,
pTotalCost double(12,2),
pUser varchar(20),
pMealID int(5),
pMealType varchar(30),
pLiveIn int(5),
pLiveOut int(5))
BEGIN
update event_meal_requirements set
venue=pVenue, pax=pPax, startTime=pStartTime, endTime=pEndTime, over=pOver, setup=pSetup, remarks=pRemarks, totalMealCost=pTotalCost, updatetime=now(), updatedby=pUser,  eventDate=pEventDate, liveInPax=pLiveIn, LiveOutPax=pLiveOut where
folioID=pFolioID and mealID = pMealID and mealType=pMealType;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateGroup` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateGroup` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateGroup`(pGroupID bigint(20), pDescription varchar(100), pMainGroupId varchar(20), pHotelID int(10), pUser varchar(20))
BEGIN
update meal_group set description=pDescription, mainGroupId = pMainGroupId, updatedby=pUser, updatetime=now() where groupID=pGroupID and hotelID=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateGroupBookingDropDown` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateGroupBookingDropDown` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateGroupBookingDropDown`(
pFieldName varchar(50),
pValue varchar(150),
pId int,
pUpdatedBy varchar(20)
)
BEGIN
update groupbookingdropdown set
FieldName = pFieldName,
`Value` = pValue,
UpdatedBy = pUpdatedBy,
UpdatedDate = now()
where
ID = pId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateGuest` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateGuest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateGuest`(
in paccountid varchar(20),
in paccountname varchar(50),
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
in pupdatedby varchar(20),
in pBIRTH_DATE     date	     ,
in pACCOUNT_TYPE     varchar(50)   ,
in pCARD_NO varchar(100),
in pTHRESHOLD_VALUE double(12,2),
in pCreditCardType            varchar(50),
in pCreditCardNo              varchar(50),
in pCreditCardExpiry          varchar(10),
in pTaxExempted tinyint(1)
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
updatedby = pupdatedby,
BIRTH_DATE = pBIRTH_DATE,
ACCOUNT_TYPE = pACCOUNT_TYPE,
CARD_NO = pCARD_NO,
THRESHOLD_VALUE = pTHRESHOLD_VALUE,
creditCardType = pCreditCardType,
creditCardNo = pCreditCardNo,
creditCardExpiry = pCreditCardExpiry,
taxExempted = pTaxExempted
where
`accountid` = `paccountid` and
hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateGuestAccountTotalSales` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateGuestAccountTotalSales` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateGuestAccountTotalSales`(
in pAccountId varchar(20),
in pAmount double(12,2),
in pHotelId int(4)
)
BEGIN
update guests
set
TOTAL_SALES_CONTRIBUTION = TOTAL_SALES_CONTRIBUTION + pAmount,
ACCOUNT_TYPE = if(TOTAL_SALES_CONTRIBUTION >= 20000.00,"ELITE",ACCOUNT_TYPE)
where
accountid = pAccountId and HotelId = pHotelId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateHKParseFlag` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateHKParseFlag` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateHKParseFlag`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateHotel` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateHotel` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateHotel`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateHouseKeeper` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateHouseKeeper` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateHouseKeeper`(
in photelid int(5),
IN phousekeeperid VARCHAR(20), 
IN plastname VARCHAR(50), 
IN pfirstname VARCHAR(50), 
IN pmiddlename VARCHAR(50),
in pupdatedby varchar(20)
)
BEGIN
update hk_housekeepers
set 
lastname = plastname,
firstname = pfirstname,
middlename = pmiddlename,
updatetime = now(),
updatedby = pupdatedby
where housekeeperid = phousekeeperid and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateHouseKeepingJobDetail` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateHouseKeepingJobDetail` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateHouseKeepingJobDetail`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateHouseKeepingLog` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateHouseKeepingLog` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateHouseKeepingLog`(IN pRoomId VARCHAR(10), IN pStatus VARCHAR(30), IN pHouseKeeperId VARCHAR(10), IN pStartTime VARCHAR(20), IN pEndTime VARCHAR(20), IN pDuration VARCHAR(20))
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateItem` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateItem` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateItem`(
pITEM_ID varchar(20),
pGROUP_ID varchar(20),
pDESCRIPTION varchar(100),
pUNIT varchar(10),
pUNIT_COST DECIMAL(12,2),
pPRICE decimal(12,2),
pVAT DECIMAL(12,2),
pSERVICE_CHARGE DECIMAL(12,2),
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
SERVICE_CHARGE=pSERVICE_CHARGE,
KITCHEN_DESIGNATION = pKITCHEN_DESIGNATION,
UpdatedBy=pUpdatedBy,
UpdateTime=now(),
AVAILABILITY = pAVAILABILITY
Where 
ITEM_ID=pITEM_ID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateJoinerFolioStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateJoinerFolioStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateJoinerFolioStatus`(
in pStatus varchar(20),
in pMasterFolio varchar(20),
in pFolioId varchar(20),
in pHotelId int(4),
in pUpdatedBy varchar(50)
)
BEGIN
update folio
set
`status` = pStatus,
updatedby = pUpdatedBy,
updatetime = now()
where
MasterFolio = pMasterFolio and
hotelid = pHotelId and
FolioId = pFolioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateJoinerFolioStatusToCheckedIn` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateJoinerFolioStatusToCheckedIn` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateJoinerFolioStatusToCheckedIn`(
in pMasterFolio varchar(20),
in pFolioId varchar(20),
in pHotelId int(4),
in pUpdatedBy varchar(50),
in pArrivalTime datetime
)
BEGIN
update folio
set
`status` = "ONGOING",
arrivaldate = pArrivalTime,
updatetime = now(),
updatedby = pUpdatedBy
where
masterFolio = pMasterFolio and
hotelid = pHotelId and
folioId = pFolioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateJoinerFolioStatusToCheckedOut` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateJoinerFolioStatusToCheckedOut` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateJoinerFolioStatusToCheckedOut`(
in pMasterFolio varchar(20),
in pFolioId varchar(20),
in pCheckOutDate date,
in pHotelId int(4),
in pUpdatedBy varchar(50)
)
BEGIN
update folio
set
`status` = "CLOSED",
departuredate = now(),
toDate = pCheckOutDate,
updatetime = now(),
updatedby = pUpdatedBy
where
masterFolio = pMasterFolio and
hotelid = pHotelId and
folioId = pFolioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateLog` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateLog` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateLog`(
in pCallNumber int(11)
)
BEGIN
update `callmgtsystem`.`log` 
set PostFlag = 1
where
CallNumber = pCallNumber;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateMainGroup` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateMainGroup` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateMainGroup`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateMealItems` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateMealItems` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateMealItems`(pItemID varchar(30), pDescription text, pGroupID bigint(10), pUnit varchar(25), pUnitCost double(12,2), pSellingPrice double(12,2), pVat double(12,2), pServiceCharge double(12,2), pHotelID int(10), pUser varchar(20))
BEGIN
update meal_items set description=pDescription, groupID=pGroupID, unit=pUnit, unit_cost=pUnitCost, selling_price=pSellingPrice, vat=pVat, service_charge=pServiceCharge, `status`='active', updatedby=pUser, updatetime=now() where hotelID=pHotelID and itemID=pItemID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateMealMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateMealMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateMealMenu`(pMenuID bigint(10), pDescription text, pPrice double(12,2), pVat double(12,2), pServiceCharge double(12,2), pHotelID int(10), pUser varchar(20))
BEGIN
update meal_menu set description=pDescription, price=pPrice, vat=pVat, service_charge=pServiceCharge, updatedby=pUser, updatetime=now() where hotel_id=pHotelID and menuID=pMenuID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateMenu` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateMenu` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateMenu`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateMenuRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateMenuRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateMenuRole`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateNumberOfBlockedRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateNumberOfBlockedRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateNumberOfBlockedRooms`(pFolioID varchar(20), pRoomType varchar(80), pNoOfRooms int(5))
BEGIN
update event_rooms set blockedRooms=blockedRooms - pNoOfRooms where folioID=pFolioID and roomType=pRoomType;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdatePackageDetails` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdatePackageDetails` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdatePackageDetails`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdatePackageHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdatePackageHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdatePackageHeader`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdatePrivilegeHeader` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdatePrivilegeHeader` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdatePrivilegeHeader`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdatePromo` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdatePromo` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdatePromo`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRateCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRateCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRateCode`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRateType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRateType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRateType`(	
in proomtypecode varchar(50),
in pratecode varchar(50),
in proomid varchar(10),
in prateamount double(13,2),
in pHasBreakfast varchar(1),
in pBreakfastAmount double(12,2),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update ratetypes
set	
rateamount = prateamount,
updatedby = pupdatedby,
hasBreakfast = pHasBreakfast,
breakfastAmount = pBreakfastAmount,
updatetime = now()
where 
roomtypecode = proomtypecode and
ratecode = pratecode and
roomID = proomid and
hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateReason` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateReason` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateReason`(
pFolioID varchar(20),
pReasonType varchar(50),
pBookingType varchar(100)
)
BEGIN
update folio set
reasonType = pReasonType,
cancelBookingType = pBookingType
where
FolioID = pFolioID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRefTime` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRefTime` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRefTime`(in pReftime varchar(20),
in pMin int(3),
in pMax int(3)
)
BEGIN
Update referencetime set reftime = pReftime,`min` = pMin, `max`=pMax;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRequirement` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRequirement` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRequirement`(
in pRequirementID         int(10),
in pDescription    	  text, 
in pTransactionCode	  varchar(20),
in pHOTEL_ID        	  int(4),
in pUPDATED_BY      	  varchar(50)
)
BEGIN
update requirement_header
set 
requirementDescription = pDescription,
transactionCode = pTransactionCode,
UPDATETIME = now(), 
UPDATEDBY = pUPDATED_BY
where
requirementID = pRequirementID and
hotelID = pHOTEL_ID
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRole`(
pRoleName     varchar(30),
pDescription  varchar(100), 
pHotelId      int(5),    
pUpdatedBy    varchar(30)
)
BEGIN
Update Roles set Description=pDescription,UpdatedBy=pUpdatedBy,
UpdateTime=now()
Where HotelId=pHotelId and RoleName=pRoleName;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoom` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoom` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoom`(
in proomid varchar(10),
in photelid int(5),
in proomtypecode varchar(50),
in pfloor int(4),
in pwindows tinyint(1),
in pdirfacing varchar(10),
in padjleft varchar(10),
in padjright varchar(10),
in proomimage varchar(80),
in psmokingtype tinyint(1),
in ptelephoneNo varchar(15),
in pbedsplittable tinyint(1),
in pupdatedby varchar(20),
in pRoomDescription varchar(100),
in pRoomArea decimal
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
bedsplittable = pbedsplittable,
updatetime = now(),
updatedby = pupdatedby,
RoomDescription = pRoomDescription,
roomArea = pRoomArea
where roomid = proomid and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomBlocked` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomBlocked` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomBlocked`(pBlockID int(11), pRoomID varchar(12), pBlockfrom varchar(30), pBlockTo varchar(30))
BEGIN
update blockingdetails set blockfrom=pBlockFrom, blockto=pBlockTo where blockid=pBlockID and roomid=pRoomID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomCleaningStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomCleaningStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomCleaningStatus`(
in pcleaningstatus varchar(11), in proomid int
)
BEGIN
update rooms set rooms.cleaningstatus = pcleaningstatus
where rooms.roomid = proomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomCoordinates` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomCoordinates` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomCoordinates`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomEvents` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomEvents` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomEvents`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomEventsForEarlyCheckOut` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomEventsForEarlyCheckOut` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomEventsForEarlyCheckOut`(    
pFolioId     varchar(20),             
pCheckOutDate    date,          
pUPDATEDBY   varchar(20),
pHotelID     int(5)
)
BEGIN
update 
roomevents
set 
EventType = 'CANCELLED'
where 
EventId = pFolioID and 
date(eventDate) > pCheckOutDate and
hotelID = pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomEventsRate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomEventsRate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomEventsRate`(
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
eventType  <> "CLOSED";
end */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomEventsRate1` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomEventsRate1` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomEventsRate1`(
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
UpdateTime = now(),
TransferFlag = '1'
where
EventId = pFolioId and
RoomId = pRoomId and
EventDate = pDateTo and
HotelId = pHotelId and
eventType  <> "CLOSED";
end */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomRate` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomRate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomRate`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomStatus`(
in pstateflag varchar(20),
in proomid varchar(10)
)
BEGIN
update rooms
set
stateflag = pstateflag 	
where
roomid = proomid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomSuperType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomSuperType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomSuperType`(
in pRoomSuperType varchar(50),
in pDescription varchar(100),
in photelid int(5),
in pupdatedby varchar(20)
)
BEGIN
update roomsupertype
set	
description = pDescription,
updatedby = pupdatedby,
updatetime = now()
where roomsupertype = proomsupertype and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateRoomType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateRoomType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateRoomType`(
in proomtypecode varchar(80),
in pmaxoccupants int(2),
in pnoofbeds int(2),
in pnoofadult int(2),
in pnoofchild int(2), 
in psharetype varchar(15),
in photelid int(5),
in pupdatedby varchar(20),
in pRoomSuperType varchar(50)
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
updatetime = now(),
RoomSuperType = pRoomSuperType
where roomtypecode = proomtypecode and hotelid = photelid;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateSchedule` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateSchedule` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateSchedule`(
pHOTELID     int(5),        
pFolioId     varchar(20),        
pRoomID      varchar(10),        
pRoomType    varchar(80),     
pFROMDATE    datetime,          
pTODATE      datetime,         
pDays        int(3),        
pRATETYPE    varchar(25),      
pRATE        decimal(12,2),       
pBREAKFAST   varchar(20),              
pUPDATEDBY   varchar(20),
pTerminalId  varchar(20),
pShiftCode   varchar(20),
pSupervisorId varchar(50),
pStartTime   time,
pEndTime     time,
pVenue 	     text,
pSetup       text,
pRemarks     text,
pGuaranteedPax int(5),
pActivity    varchar(30),
pId varchar(10)
)
BEGIN
update folioschedules set       
RoomID = pRoomID,        
RoomType = pRoomType,     
FROMDATE = pFROMDATE,          
TODATE = pTODATE,         
Days = pDays,        
RATETYPE = pRATETYPE,      
RATE = pRATE,       
BREAKFAST = pBREAKFAST,             
UPDATEDBY = pUPDATEDBY,
UPDATETIME = now(),
TERMINAL_ID = pTerminalId,
SHIFT_CODE = pShiftCode,
SUPERVISOR_ID = pSupervisorId,
startTime = pStartTime,
endTime = pEndTime,
venue = pVenue,
setup = pSetup,
remarks = pRemarks,
guaranteedPax = pGuaranteedPax,
activity = pActivity,
`status` = 'ACTIVE'
where id = pId and HOTELID = pHOTELID and FolioId = pFolioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateSchedule_EarlyCheckOut` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateSchedule_EarlyCheckOut` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateSchedule_EarlyCheckOut`(
in pFolioId  varchar(100),
in pRoomId varchar(20),
in pHotelId int(4)
)
BEGIN
update folioschedules
set
toDate = curdate(),
days = datediff(curdate(),date(FromDate))
where
FolioId = pFolioId and
RoomId = pRoomId;
update folio
set 
departuredate = curdate()
where
FolioId = pFolioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateShareFolioStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateShareFolioStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateShareFolioStatus`(
in pStatus varchar(20),
in pMasterFolio varchar(20),
in pFolioId varchar(20),
in pHotelId int(4),
in pUpdatedBy varchar(50)
)
BEGIN
update folio
set
`status` = pStatus,
updatedby = pUpdatedBy,
updatetime = now()
where
MasterFolio = pMasterFolio and
hotelid = pHotelId and
FolioId = pFolioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateShareFolioStatusToCheckedIn` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateShareFolioStatusToCheckedIn` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateShareFolioStatusToCheckedIn`(
in pMasterFolio varchar(20),
in pFolioId varchar(20),
in pHotelId int(4),
in pUpdatedBy varchar(50)
)
BEGIN
update folio
set
`status` = "ONGOING",
arrivaldate = now(),
updatetime = now(),
updatedby = pUpdatedBy
where
masterFolio = pMasterFolio and
hotelid = pHotelId and
folioId = pFolioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateShareFolioStatusToCheckedOut` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateShareFolioStatusToCheckedOut` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateShareFolioStatusToCheckedOut`(
in pMasterFolio varchar(20),
in pFolioId varchar(20),
in pCheckOutDate date,
in pHotelId int(4),
in pUpdatedBy varchar(50)
)
BEGIN
update folio
set
`status` = "CLOSED",
departuredate = now(),
toDate = pCheckOutDate,
updatetime = now(),
updatedby = pUpdatedBy
where
masterFolio = pMasterFolio and
hotelid = pHotelId and
folioId = pFolioId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateShiftEndorsement` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateShiftEndorsement` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateShiftEndorsement`(
pId                      int(10),
pEndorsementDescription  text,
pUpdatedBy               varchar(50)
)
BEGIN
update shiftendorsements set
endorsementDescription = pEndorsementDescription,
updatedBy = pUpdatedBy,
updateTime = now()
where
id = pId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateSystemConfig` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateSystemConfig` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateSystemConfig`(
in pKey varchar(200),
in pValue varchar(200),
in pDescription text,
in pUser varchar(20)
)
BEGIN
update system_config
set `value` = pValue,
description = pDescription,
updated_by = pUser,
update_date = now()
where
`key` = pKey;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateSystemConfiguration` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateSystemConfiguration` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateSystemConfiguration`(
pKEY          varchar(100),
pVALUE        varchar(200),
pDESCRIPTION  varchar(500),
pUPDATED_BY   varchar(20)
)
BEGIN
update system_config 
set `value` = pValue,
description = pDescription,
UPDATE_DATE = now(),
UPDATED_BY = pUPDATED_BY
where `key`= pKey;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateSystemConfigValue` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateSystemConfigValue` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateSystemConfigValue`(
in pKey varchar(200),
in pValue varchar(200),
in pUser varchar(20)
)
BEGIN
update system_config
set `value` = pValue,
updated_by = pUser,
update_date = now()
where
`key` = pKey;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateTotalBlockedRooms` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateTotalBlockedRooms` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateTotalBlockedRooms`(pFolioID varchar(20), pRoomType varchar(80), pNoOfRooms int(5))
BEGIN
update event_rooms set blockedRooms = pNoOfRooms 
where folioID = pFolioID 
and roomType=pRoomType;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateTotalNetAgentComm` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateTotalNetAgentComm` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateTotalNetAgentComm`(
in pHotelID int(5),
in pFolioID varchar(20),
in pSubFolio varchar(1),
in pCommission decimal(12,2),
in pTotalNet decimal(12,2)
)
BEGIN
Update folioledger set AgentCommission = AgentCommission + pCommission,TotalNet =TotalNet+pTotalNet
where Folioid=pFolioID and subfolio = pSubFolio and Hotelid=pHotelID;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateTransactionCode` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateTransactionCode` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateTransactionCode`(
pTranCode                  varchar(20),
pTranTypeId                varchar(20),
pMemo                      varchar(100),
pAcctSide                  varchar(10),
pServiceCharge             double(5,2),
pServiceChargeInclusive    tinyint(1),
pGovtTax                   double(5,2),
pGovtTaxInclusive          tinyint(1),
pLocalTax                  double(5,2),
pLocalTaxInclusive         tinyint(1),
pDefaultTransactionSource  varchar(100),
pDefaultAmount             double(12,2),
pWarningAmount             double(12,2),
pDepartmentId              varchar(20),
pLedger                    varchar(10),
pDebitSide                 varchar(20),
pCreditSide                varchar(20),
pHotelId                   int(5),
pUpdatedBy                 varchar(20)
)
BEGIN
update `transactioncode` 
set
tranTypeId = pTranTypeId, 
memo = pMemo, 
acctSide = pAcctSide, 
serviceCharge = pServiceCharge, 
serviceChargeInclusive = pServiceChargeInclusive, 
govtTax = pGovtTax, 
govtTaxInclusive = pGovtTaxInclusive, 
localTax = pLocalTax, 
localTaxInclusive = pLocalTaxInclusive, 
defaultTransactionSource = pDefaultTransactionSource, 
defaultAmount = pDefaultAmount,
warningAmount = pWarningAmount, 
departmentId = pDepartmentId, 
ledger = pLedger, 
debitSide = pDebitSide, 
creditSide = pCreditSide, 
updateTime = now(), 
updatedBy = pUpdatedBy
where
trancode = pTrancode and hotelId = pHotelid
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateTransactionCodeSubAccount` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateTransactionCodeSubAccount` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateTransactionCodeSubAccount`(
pTransactionCode         varchar(20), 
pSubAccountCode          varchar(20), 
pLocalTax                double(5,2), 
pLocalTaxInclusive       tinyint(1), 
pGovernmentTax           double(5,2), 
pGovernmentTaxInclusive  tinyint(1), 
pServiceCharge           double(5,2), 
pServiceChargeInclusive  tinyint(1), 
pUpdatedBy               varchar(50), 
pHotelId                 int(4)
)
BEGIN
update `transctioncode_subaccount` 
set 
localTax = pLocalTax, 
localTaxInclusive = pLocalTaxInclusive, 
governmentTax = pGovernmentTax, 
governmentTaxInclusive = pGovernmentTaxInclusive, 
serviceCharge = pServiceCharge, 
serviceChargeInclusive = pServiceChargeInclusive, 
updatedBy = pUpdatedBy, 
updatedDate = now()
where
transactionCode = pTransactionCode and 
subAccountCode = pSubAccountCode and
hotelId = pHotelId
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateTransactionSourceDocument` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateTransactionSourceDocument` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`%` PROCEDURE `spUpdateTransactionSourceDocument`(
in pTransactionSourceId  int(10),
in pDescription          varchar(100),
in pAbbreviation         varchar(10),
in pUpdatedBy            varchar(50)
)
BEGIN
update transactionsourcedocuments	
set 
description = pDescription,
abbreviation = pAbbreviation,
updatedDate = now(),
updatedBy = pUpdatedBy
where
transactionSourceId = pTransactionSourceId
;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateTranType` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateTranType` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateTranType`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spUpdateUser` */

/*!50003 DROP PROCEDURE IF EXISTS  `spUpdateUser` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdateUser`(
in pUserId           varchar(20),
in pEmployeeIdNo      varchar(20),
in pLastName          varchar(30),      
in pFirstName         varchar(30),   
in pDepartment        varchar(100),  
in pDesignation       varchar(50),
in pHotelId int(5)
)
BEGIN
update users
set       
EmployeeIdNo = pEmployeeIdNo , 
LastName = pLastName,       
FirstName = pFirstName,      
Department = pDepartment,    
Designation = pDesignation,
hotelId = pHotelId,
stateflag = 'ACTIVE'
where
UserId = pUserId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spVerifyLogin` */

/*!50003 DROP PROCEDURE IF EXISTS  `spVerifyLogin` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spVerifyLogin`(
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
END */$$
DELIMITER ;

/* Procedure structure for procedure `spVoidAccountingAdjustment` */

/*!50003 DROP PROCEDURE IF EXISTS  `spVoidAccountingAdjustment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spVoidAccountingAdjustment`(
in pTransactionId int(20),
in pUpdatedBy varchar(50),
in pHotelId int(4),
in pBaseAmount double(12,2),
in pReferenceDriverId varchar(20)
)
BEGIN
update accountingadjustments
set
statusFlag = 'VOID',
referenceNo = concat(referenceNo,  "(VOID)"),
UPDATEDBY = pUpdatedBy,
UPDATEDDATE = now()
where
transactionId = pTransactionId and
hotelID = pHotelId;
update drivers set totalCommission = totalCommission - if(pReferenceDriverId != "", pBaseAmount,0)
where driverId = pReferenceDriverId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spVoidFolioTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spVoidFolioTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spVoidFolioTransaction`(
in pFolioTransactionNo int(20),
in pUpdatedby varchar(20)
)
BEGIN
update foliotransactions
set 
`status` = "VOID",
ReferenceNo = concat(ReferenceNo,"(VOID)"),
updatedby = pupdatedby,
updatetime = now()
where
folioTransactionNo = pFolioTransactionNo;
END */$$
DELIMITER ;

/* Procedure structure for procedure `spVoidNonGuestTransaction` */

/*!50003 DROP PROCEDURE IF EXISTS  `spVoidNonGuestTransaction` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `spVoidNonGuestTransaction`(
in pTransactionId int(20),
in pUpdatedBy varchar(50),
in pHotelId int(4),
in pBaseAmount double(12,2),
in pReferenceDriverId varchar(20)
)
BEGIN
update nonguesttransaction
set
statusFlag = 'VOID',
referenceNo = concat(referenceNo,  "(VOID)"),
UPDATEDBY = pUpdatedBy,
UPDATEDDATE = now()
where
transactionId = pTransactionId and
hotelID = pHotelId;
update drivers set totalCommission = totalCommission - if(pReferenceDriverId != "", pBaseAmount,0)
where driverId = pReferenceDriverId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `test` */

/*!50003 DROP PROCEDURE IF EXISTS  `test` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `test`(
in whereCondition varchar(50)
)
BEGIN
select * from folio 
where whereCondition;
END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;