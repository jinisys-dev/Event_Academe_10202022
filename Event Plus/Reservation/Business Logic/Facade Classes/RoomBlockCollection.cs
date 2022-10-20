

using System;
using System.Data;
using System.Diagnostics;
using System.Collections;


namespace Jinisys.Hotel.Reservation.BusinessLayer
{
    public class RoomBlockCollection : CollectionBase
    {

        public RoomBlockCollection()
        {
        }

        public void Add(RoomBlock roomBlock)
        {
            this.List.Add(roomBlock);
        }

        public RoomBlock Find(int roomid, DateTime blockFrom)
        {
            RoomBlock roomBlock;
            foreach (RoomBlock tempLoopVar_roomBlock in this.List)
            {
                roomBlock = tempLoopVar_roomBlock;
                if (roomid.ToString() == roomBlock.RoomID && blockFrom == roomBlock.BlockFrom)
                {
                    return roomBlock;
                }
            }
            return null;
        }

        public void AddReason(string Reason)
        {
            Jinisys.Hotel.Reservation.BusinessLayer.RoomBlock roomBlock;
            foreach (Jinisys.Hotel.Reservation.BusinessLayer.RoomBlock tempLoopVar_roomBlock in this.List)
            {
                roomBlock = tempLoopVar_roomBlock;
                roomBlock.Reason = Reason;
            }
        }

        public void AddBlockID(int BlockID)
        {
            Jinisys.Hotel.Reservation.BusinessLayer.RoomBlock roomBlock;
            foreach (RoomBlock tempLoopVar_roomBlock in this.List)
            {
                roomBlock = tempLoopVar_roomBlock;
                roomBlock.BlockID = BlockID;
            }
        }

        public RoomBlock Item(int index)
        {
            return (RoomBlock)this.List[index];
        }

    }
}
