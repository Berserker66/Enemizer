﻿namespace EnemizerLibrary
{
    public class MiseryMireDungeon : Dungeon
    {
        public MiseryMireDungeon(int priority = 255) : base(priority)
        {
            Name = "Misery Mire";
            DungeonType = DungeonType.MiseryMire;
            DungeonCrystalTypeAddress = CrystalConstants.MiseryMireCrystalTypeAddress;
            DungeonCrystalAddress = CrystalConstants.MiseryMireCrystalAddress;
            SelectedBoss = null;
            BossRoomId = 144;
            LogicalBossRoomId = "mire-vitreous";
            DungeonRoomSpritePointerAddress = 0x04D74E;
            BossDropItemAddress = 0x180158;

            ShellX = 0x0B;
            ShellY = 0x28;
            ClearLayer2 = true;
        }
    }
}
