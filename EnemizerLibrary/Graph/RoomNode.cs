﻿namespace EnemizerLibrary
{
    public class RoomNode : Node
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public RoomNode(string logicalRoomId, int roomId, string roomName, string logicalName)
        {
            this.LogicalId = logicalRoomId;
            this.Name = logicalName;
            this.RoomId = roomId;
            this.RoomName = roomName;
        }
    }
}
