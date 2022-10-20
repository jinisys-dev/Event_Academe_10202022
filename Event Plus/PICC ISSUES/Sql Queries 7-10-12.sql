select concat(date_format(now(),'%M %e,%Y %W '),date_format(startTime,'%l%p'),'-',date_format(endTime,'%l%p')) as dates, activity from folioschedules
call spReportEventOrder('F-0000000308','RH [RECEPTION HALL] : 22-Jul-2012','1');
call spReportEventOrderSub('F-0000000308','RH','2012-07-22','1');

select * from folioschedules where folioschedules.FolioId='F-0000000308' order by createtime;