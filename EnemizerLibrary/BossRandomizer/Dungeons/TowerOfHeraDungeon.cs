﻿namespace EnemizerLibrary
{
    public class TowerOfHeraDungeon : Dungeon
    {
        public TowerOfHeraDungeon(int priority = 255) : base(priority)
        {
            Name = "Tower of Hera";
            DungeonType = DungeonType.TowerOfHera;
            DungeonCrystalTypeAddress = CrystalConstants.TowerOfHeraCrystalTypeAddress;
            DungeonCrystalAddress = CrystalConstants.TowerOfHeraCrystalAddress;
            SelectedBoss = null;
            BossRoomId = 7;
            LogicalBossRoomId = "hera-moldorm";
            DungeonRoomSpritePointerAddress = 0x04D63C;
            BossDropItemAddress = 0x180152;

            DisallowedBosses.Add(BossType.Armos);
            DisallowedBosses.Add(BossType.Arrghus);
            DisallowedBosses.Add(BossType.Blind);
            DisallowedBosses.Add(BossType.Lanmola); // still broken. will spawn on top left after first cycle.
            DisallowedBosses.Add(BossType.Trinexx);

            ShellX = 0x18;
            ShellY = 0x16;
        }
    }
}
