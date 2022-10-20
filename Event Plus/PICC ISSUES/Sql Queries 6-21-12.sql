call spGetEventOfficersFullName('1');
call spGetMarketingOfficers('1');

call spSelectUsers();

call spGetUserRolesAll('1');
call spgetuserroles('ADPERAZ','1');

select * from userroles where rolename like '%event%' or rolename like '%marketing%';

call spSelectRooms('1'); 
call spGetEventsFromTo('2012-07-01','2012-07-31','1');

call spReportWeeklySchedule(1,'2012-06-18','2012-06-24');

select * from (
select folio.groupName,folioschedules.activity,folioschedules.FolioId,folioschedules.venue,
roomevents.EVENTDATE,roomevents.startTime,roomevents.endTime,
if((select group_concat(concat(firstName,' ' ,lastName)) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioId = folio.folioId and event_officers.hotelID = '1') is null,' ',(select group_concat(concat(firstName,' ' ,lastName)) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioId = folio.folioId and event_officers.hotelID = '1')) as eo
from folioschedules left join folio on folioschedules.FolioId = folio.folioID left join roomevents on roomevents.EventID=folioschedules.FolioId
where (roomevents.EventType = 'RESERVATION' or roomevents.EventType = 'IN HOUSE') and roomevents.HOTELID = '1' and date(roomevents.EVENTDATE) >= date('2012-06-18') and date(roomevents.EVENTDATE) <= date('2012-06-24') 
order by roomevents.EVENTDATE,roomevents.startTime) as weeklySchedules 
group by EVENTDATE,startTime,endTime,activity,venue,groupName,eo
order by venue;

select folio.groupName,folioschedules.activity,folioschedules.FolioId,folioschedules.venue,roomevents.EVENTDATE,roomevents.startTime,roomevents.endTime from folioschedules left join folio on folioschedules.FolioId=folio.folioID left join roomevents on roomevents.EventID=folioschedules.FolioId where (folioschedules.FolioId='F-0000000244' or folioschedules.FolioId='F-0000000302') and date(roomevents.EVENTDATE) >= date('2012-06-18') and date(roomevents.EVENTDATE) <= date('2012-06-24');

select folio.groupName,folioschedules.activity,folioschedules.FolioId,folioschedules.venue,
roomevents.EVENTDATE,roomevents.startTime,roomevents.endTime,
if((select group_concat(concat(firstName,' ' ,lastName)) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioId = folio.folioId and event_officers.hotelID = '1') is null,' ',(select group_concat(concat(firstName,' ' ,lastName)) from event_officers left join users on event_officers.userID = users.userID where event_officers.folioId = folio.folioId and event_officers.hotelID = '1')) as eo
from folioschedules left join folio on folioschedules.FolioId = folio.folioID left join roomevents on roomevents.EventID=folioschedules.FolioId
where (roomevents.EventType = 'RESERVATION' or roomevents.EventType = 'IN HOUSE') and roomevents.HOTELID = '1' and date(roomevents.EVENTDATE) >= date('2012-06-18') and date(roomevents.EVENTDATE) <= date('2012-06-24') 
order by roomevents.EVENTDATE,roomevents.startTime