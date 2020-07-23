﻿using System.Collections.Generic;

namespace EnemizerLibrary
{
    public abstract class Dungeon
    {
        public string Name { get; set; }
        public int Priority { get; set; } = 255;
        public int? DungeonCrystalTypeAddress { get; set; }
        public int? DungeonCrystalAddress { get; set; }
        public BossType BossType { get; set; } // TODO: need?
        public Boss SelectedBoss { get; set; }
        public int BossRoomId { get; set; }
        public string LogicalBossRoomId { get; set; }
        public int DungeonRoomSpritePointerAddress { get; set; }
        public int? BossDropItemAddress { get; set; }

        public int ShellX { get; set; }
        public int ShellY { get; set; }
        public bool ClearLayer2 { get; set; }

        public List<BossType> DisallowedBosses { get; protected set; } = new List<BossType>();

        public DungeonType DungeonType { get; protected set; } = DungeonType.NotSet;

        public byte[] ExtraSprites = new byte[0];

        protected Dungeon(int priority)
        {
            Priority = priority;
        }
    }

}
