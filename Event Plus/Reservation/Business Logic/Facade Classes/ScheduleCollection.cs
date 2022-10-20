using System.Diagnostics;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class ScheduleCollection : CollectionBase
    {

        public ScheduleCollection()
        {
        }
        public void Add(Schedule Sched)
        {
            this.List.Add(Sched);
        }
        public void Remove(Schedule Sched)
        {
            this.List.Remove(Sched);
        }
    }
}