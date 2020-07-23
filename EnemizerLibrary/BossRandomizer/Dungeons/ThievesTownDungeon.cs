﻿namespace EnemizerLibrary
{
    public class ThievesTownDungeon : Dungeon
    {
        public ThievesTownDungeon(int priority = 255) : base(priority)
        {
            Name = "Thieves' Town";
            DungeonType = DungeonType.ThievesTown;
            DungeonCrystalTypeAddress = CrystalConstants.ThievesTownCrystalTypeAddress;
            DungeonCrystalAddress = CrystalConstants.ThievesTownCrystalAddress;
            SelectedBoss = null;
            BossRoomId = 172;
            LogicalBossRoomId = "thieves-blind";
            DungeonRoomSpritePointerAddress = 0x04D786;
            BossDropItemAddress = 0x180156;

            ShellX = 0x2B;
            ShellY = 0x28; // 0x26 trinexx
            ClearLayer2 = true;
        }
    }
}
