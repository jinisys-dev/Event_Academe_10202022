call spGetDateRangeMarketSegment('2012-06-01', '2012-06-30');

SELECT  folio.folioid,  guests.accountID,  if(folio.foliotype='GROUP', fGetGuestName(folio.companyid), concat(guests.lastname,', ',guests.firstname)) as guestName,  guests.concierge,  guests.remark,  guests.ACCOUNT_TYPE,  guests.THRESHOLD_VALUE,  if(foliotype='JOINER', fGetGroupName(folio.masterfolio), folio.groupname) as groupname,  company.companyName,  folio.fromdate,  folio.todate,  sum(folioledger.balancenet) as Balance,  folio.status,  folio.remarks,  folio.foliotype,  folio.masterfolio,  concat(folio.noofadults,'/',folio.noofchild) as Pax,  folio.folioETA,  folio.folioETD,  folio.REASON_FOR_CANCEL,  folio.sales_executive,  folio.createdBy,  folio.updatedBy,  folio.updateTime,  folio.createTime,  fGetEventTotalRequiredRooms(folio.folioid) as RequiredRooms,  fGetEventTotalBlockedRooms(folio.folioid) as BlockedRooms,  (select group_concat(concat(users.firstName, ' ' , users.lastName, ' ')) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioID = folio.folioid and event_officers.status = 'ACTIVE') as eventOfficers,  folio.referenceNo  FROM  folio force index(folioid)  left join folioledger on  folioledger.folioid = folio.folioid  left join company on  company.companyid = folio.companyid  left join guests on  guests.accountid = folio.accountid  WHERE   foliotype = 'GROUP' and ( date(folio.fromdate) >= date('2012-06-01') and date(folio.fromdate) <= date('2012-07-01') ) and folio.hotelid = 1  GROUP BY  folio.folioid
foliotype = 'GROUP' and ( date(folio.fromdate) >= date('2012-06-01') and date(folio.fromdate) <= date('2012-07-01') )

SELECT folio.folioid, folio.purpose as `Market Segment`, folio.status, if(foliotype='JOINER', fGetGroupName(folio.masterfolio), 
folio.groupname) as groupname,  company.companyName,  folio.fromdate,  folio.todate, folio.REASON_FOR_CANCEL,  folio.sales_executive,
folio.createdBy,  folio.updatedBy,  folio.updateTime,  folio.createTime,  fGetEventTotalRequiredRooms(folio.folioid) as RequiredRooms, 
fGetEventTotalBlockedRooms(folio.folioid) as BlockedRooms,  (select group_concat(concat(users.firstName, ' ' , users.lastName, ' '))
from event_officers left join users on event_officers.userID = users.userID where event_officers.folioID = folio.folioid and 
event_officers.status = 'ACTIVE') as eventOfficers,  folio.referenceNo  FROM  folio force index(folioid)  left join folioledger on 
folioledger.folioid = folio.folioid  left join company on  company.companyid = folio.companyid  left join guests on 
guests.accountid = folio.accountid  WHERE   foliotype = 'GROUP' and ( date(folio.fromdate) >= date('2012-06-01') and 
date(folio.fromdate) <= date('2012-06-30') ) and folio.hotelid = 1 and (folio.Status='CONFIRMED' or folio.Status='TENTATIVE') order by folio.Status, folio.purpose;

select folio.folioID, folio.purpose as `Market Segment`, if(foliotype='JOINER', fGetGroupName(folio.masterfolio), folio.groupname)
as groupname, folio.Status, (select roomtypecode from rooms where roomid=folioschedules.roomid) as `Room Type`, 
folioschedules.roomid as `Room ID`, date(folio.fromdate) as `Date` from folioschedules left join folio 
on folio.folioID = folioschedules.FolioId left join company on company.companyid = folio.folioID where 
folio.folioid=folioschedules.folioid and folio.status!='CANCELLED' and folio.status!='NO SHOW' and folio.Status!='WAIT LIST' 
and (date(folio.fromdate) >= date('2012-06-01') and 
date(folio.fromdate) <= date('2012-06-30')) group by folio.groupName order by folio.Status, folio.purpose;

call spGetDateRangeMarketSegment('2012-06-01', '2012-06-30');