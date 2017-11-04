﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnemizerLibrary
{
    public class RoomGroupRequirement
    {
        public List<int> Rooms { get; set; }
        public int? GroupId { get; set; }
        public int? Subgroup0 { get; set; }
        public int? Subgroup1 { get; set; }
        public int? Subgroup2 { get; set; }
        public int? Subgroup3 { get; set; }

        public RoomGroupRequirement()
        {
        }
        public RoomGroupRequirement(int? GroupId, int? Subgroup0, int? Subgroup1, int? Subgroup2, int? Subgroup3, params int[] Rooms)
        {
            if(GroupId == null && Subgroup0 == null && Subgroup1 == null && Subgroup2 == null && Subgroup3 == null)
            {
                throw new Exception("RoomGroupRequirement needs at least one non-null GroupId or Subgroup.");
            }

            if (Rooms != null)
            {
                this.Rooms = Rooms.ToList();
            }
            this.GroupId = GroupId;
            this.Subgroup0 = Subgroup0;
            this.Subgroup1 = Subgroup1;
            this.Subgroup2 = Subgroup2;
            this.Subgroup3 = Subgroup3;
        }
    }

    public class RoomGroupRequirementCollection
    {
        public List<RoomGroupRequirement> RoomRequirements { get; set; }

        public RoomGroupRequirementCollection()
        {
            RoomRequirements = new List<RoomGroupRequirement>();

            FillRoomRequirements();
        }

        public SpriteRequirement GetGroupRequirementForRoom(Room room)
        {
            var ret = new SpriteRequirement(0);
            foreach (var req in RoomRequirements.Where(x => x.Rooms.Contains(room.RoomId)))
            {
                if (req.GroupId != null)
                {
                    ret.GroupId.Add((byte)req.GroupId);
                }
                if(req.Subgroup0 != null)
                {
                    ret.SubGroup0.Add((byte)req.Subgroup0);
                }
                if (req.Subgroup1 != null)
                {
                    ret.SubGroup1.Add((byte)req.Subgroup1);
                }
                if (req.Subgroup2 != null)
                {
                    ret.SubGroup2.Add((byte)req.Subgroup2);
                }
                if (req.Subgroup3 != null)
                {
                    ret.SubGroup3.Add((byte)req.Subgroup3);
                }
            }
            return ret;
        }

        void FillRoomRequirements()
        {
            RoomRequirements.Add(new RoomGroupRequirement(1, 70, 73, 28, 82, 
                //RoomIdConstants.R33_HyruleCastle_KeyRatRoom, // don't think we need this
                RoomIdConstants.R228_Cave_LostOldManFinalCave,
                RoomIdConstants.R240_Cave_LostOldManStartingCave//,
                //RoomIdConstants.R263_Library_BombFarmRoom // don't think we need this
                ));

            RoomRequirements.Add(new RoomGroupRequirement(5, 75, 77, 74, 90,
                RoomIdConstants.R243_House_OldWoman_SahasrahlasWifeMaybe,
                RoomIdConstants.R265_WitchHut,
                RoomIdConstants.R270_Cave0x10E,
                RoomIdConstants.R271_Shop0x10F,
                RoomIdConstants.R272_Shop0x110,
                RoomIdConstants.R273_ArcherGame,
                RoomIdConstants.R282_Mutant,
                RoomIdConstants.R284_BombShop,
                RoomIdConstants.R290_FortuneTellers));
            // TODO: these probably can be combined with above safely but leave for now
            RoomRequirements.Add(new RoomGroupRequirement(null, 75, null, null, null,
                RoomIdConstants.R255_Cave0xFF,
                RoomIdConstants.R274_CaveShop0x112,
                RoomIdConstants.R287_Shop0x11F));
            RoomRequirements.Add(new RoomGroupRequirement(null, null, 77, null, 21,
                RoomIdConstants.R289_SmithHouse));

            RoomRequirements.Add(new RoomGroupRequirement(7, 75, 77, 57, 54,
                RoomIdConstants.R8_Cave_HealingFairy,
                RoomIdConstants.R44_Cave0x2C_HookshotCaveBackdoor,
                RoomIdConstants.R276_WishingWell_Cave0x114,
                RoomIdConstants.R277_WishingWell_BigFairy));

            RoomRequirements.Add(new RoomGroupRequirement(13, 81, null, null, null, 
                RoomIdConstants.R85_CastleSecretEntrance_UncleDeathRoom,
                RoomIdConstants.R258_SickKid,
                RoomIdConstants.R260_LinksHouse));

            RoomRequirements.Add(new RoomGroupRequirement(14, 71, 73, 76, 80,
                RoomIdConstants.R18_Sanctuary,
                RoomIdConstants.R261_ShabadooHouse,
                RoomIdConstants.R266_Aginah));

            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 80,
                RoomIdConstants.R264_ChickenHouse));

            RoomRequirements.Add(new RoomGroupRequirement(15, 79, 77, 74, 80,
                RoomIdConstants.R244_House_AngryBrothers,
                RoomIdConstants.R245_House_AngryBrothers2,
                RoomIdConstants.R257_ScaredLadyHouses,
                RoomIdConstants.R259_Inn_BushHouse,
                RoomIdConstants.R262_ChestGame_BombHouse,
                RoomIdConstants.R280_Shop0x118,
                RoomIdConstants.R281_BlindsHouse));

            RoomRequirements.Add(new RoomGroupRequirement(18, 85, 61, 66, 67,
                RoomIdConstants.R32_AgahnimsTower_Agahnim,
                RoomIdConstants.R48_AgahnimsTower_MaidenSacrificeChamber));

            RoomRequirements.Add(new RoomGroupRequirement(24, 85, 26, 66, 67, 
                RoomIdConstants.R13_GanonsTower_Agahnim2));

            RoomRequirements.Add(new RoomGroupRequirement(34, 33, 65, 69, 51, 
                RoomIdConstants.R0_Ganon));

            RoomRequirements.Add(new RoomGroupRequirement(40, 14, null, 74, 80,
                RoomIdConstants.R225_Cave_LostWoodsHP,
                RoomIdConstants.R256_ShopInLostWoods0x100,
                RoomIdConstants.R293_Cave0x125,
                RoomIdConstants.R292_UnknownCave_BonkCave,
                RoomIdConstants.R294_CheckerBoardCave));
            // this has to be here because of the damn shutter door. hard code one enemy group to make sure it doesn't go in with the above
            RoomRequirements.Add(new RoomGroupRequirement(null, 14, 30, null, null,
                RoomIdConstants.R291_MiniMoldormCave));

            RoomRequirements.Add(new RoomGroupRequirement(23, 64, null, null, 63)); //, 
                //RoomIdConstants.R164_TurtleRock_Trinexx));

            RoomRequirements.Add(new RoomGroupRequirement(9, null, null, null, 29,
                //RoomIdConstants.R28_GanonsTower_IceArmos,
                //RoomIdConstants.R200_EasternPalace_ArmosKnights,
                RoomIdConstants.R227_Cave_HalfMagic));

            RoomRequirements.Add(new RoomGroupRequirement(11, null, null, null, 61));//,
                //RoomIdConstants.R144_MiseryMire_Vitreous));

            // combine??
            RoomRequirements.Add(new RoomGroupRequirement(22, null, null, null, 49));//,
                //RoomIdConstants.R51_DesertPalace_Lanmolas,
                //RoomIdConstants.R108_GanonsTower_LanmolasRoom));
            RoomRequirements.Add(new RoomGroupRequirement(22, null, null, 60, null));//,
                //RoomIdConstants.R222_IcePalace_Kholdstare));

            RoomRequirements.Add(new RoomGroupRequirement(21, null, null, 58, 62));//,
                //RoomIdConstants.R90_PalaceofDarkness_HelmasaurKing));

            // Freezor
            RoomRequirements.Add(new RoomGroupRequirement(28, null, null, 38, 82,
                RoomIdConstants.R14_IcePalace_EntranceRoom,
                RoomIdConstants.R126_IcePalace_HiddenChest_BombableFloorRoom,
                RoomIdConstants.R142_IcePalace0x8E,
                RoomIdConstants.R158_IcePalace_BigChestRoom, //));
            //RoomRequirements.Add(new RoomGroupRequirement(41, null, null, 38, null, // R190 is in this originally
                RoomIdConstants.R190_IcePalace_BlockPuzzleRoom));

            RoomRequirements.Add(new RoomGroupRequirement(12, null, null, 48, null));//,
                //RoomIdConstants.R7_TowerofHera_Moldorm,
                //RoomIdConstants.R77_GanonsTower_MoldormRoom));

            RoomRequirements.Add(new RoomGroupRequirement(26, null, null, 56, null));//,
                //RoomIdConstants.R41_SkullWoods_Mothula));

            RoomRequirements.Add(new RoomGroupRequirement(20, null, null, 57, null));//,
                //RoomIdConstants.R6_SwampPalace_Arrghus));

            RoomRequirements.Add(new RoomGroupRequirement(32, null, 44, 59, null));//,
                //RoomIdConstants.R172_ThievesTown_BlindTheThief));

            RoomRequirements.Add(new RoomGroupRequirement(3, 93, null, null, null,
                RoomIdConstants.R81_HyruleCastle_ThroneRoom));

            RoomRequirements.Add(new RoomGroupRequirement(42, 21, null, null, null,
                RoomIdConstants.R286_HypeCave));

            // Moving Canonball Shooters
            RoomRequirements.Add(new RoomGroupRequirement(10, 47, null, 46, null,
                RoomIdConstants.R92_GanonsTower_Ganon_BallZ,
                RoomIdConstants.R117_DesertPalace_BigKeyChestRoom,
                RoomIdConstants.R185_EasternPalace_LobbyCannonballsRoom, // Force?
                RoomIdConstants.R217_EasternPalace_CanonballRoom));      // Force?

            // Pirogusu
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, 34, null,
                RoomIdConstants.R54_SwampPalace_BigChestRoom,
                RoomIdConstants.R70_SwampPalace_CompassChestRoom,
                RoomIdConstants.R102_SwampPalace_HiddenChest_HiddenDoorRoom,
                RoomIdConstants.R118_SwampPalace_WaterDrainRoom));

            // Babasu
            RoomRequirements.Add(new RoomGroupRequirement(null, null, 32, null, null,
                RoomIdConstants.R62_IcePalace_StalfosKnights_ConveyorHellway,
                RoomIdConstants.R159_IcePalace0x9F));

            // Wallmaster
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, 35, null,
                RoomIdConstants.R57_SkullWoods_GibdoKey_MothulaHoleRoom,
                RoomIdConstants.R73_SkullWoods_GibdoTorchPuzzleRoom,
                RoomIdConstants.R86_SkullWoods_KeyPot_TrapRoom,
                RoomIdConstants.R87_SkullWoods_BigKeyRoom,
                RoomIdConstants.R104_SkullWoods_KeyChest_TrapRoom,
                RoomIdConstants.R141_GanonsTower_Tile_TorchPuzzleRoom));

            // Guruguru bar - 31
            // Cane Platform - 39
            RoomRequirements.Add(new RoomGroupRequirement(37, 31, null, 39, 82,
                RoomIdConstants.R36_TurtleRock_DoubleHokku_Bokku_BigchestRoom,
                RoomIdConstants.R180_TurtleRock_Pre_TrinexxRoom,
                RoomIdConstants.R181_TurtleRock_DarkMaze,
                RoomIdConstants.R198_TurtleRock0xC6,
                RoomIdConstants.R199_TurtleRock_TorchPuzzle,
                RoomIdConstants.R214_TurtleRock_EntranceRoom));

            // Bumpers
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 82,
                RoomIdConstants.R23_TowerofHera_MoldormFallRoom,
                RoomIdConstants.R42_PalaceofDarkness_BigHubRoom,
                RoomIdConstants.R68_ThievesTown_BigChestRoom,
                RoomIdConstants.R76_GanonsTower_Mini_HelmasaurConveyorRoom,
                RoomIdConstants.R86_SkullWoods_KeyPot_TrapRoom,
                RoomIdConstants.R88_SkullWoods_BigChestRoom,
                RoomIdConstants.R89_SkullWoods_FinalSectionEntranceRoom,
                RoomIdConstants.R103_SkullWoods_CompassChestRoom,
                RoomIdConstants.R104_SkullWoods_KeyChest_TrapRoom,
                RoomIdConstants.R126_IcePalace_HiddenChest_BombableFloorRoom,
                RoomIdConstants.R139_GanonsTower_BlockPuzzle_SpikeSkip_MapChestRoom,
                RoomIdConstants.R235_Cave0xEB,
                RoomIdConstants.R251_Cave0xFB));
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 83,
                RoomIdConstants.R23_TowerofHera_MoldormFallRoom,
                RoomIdConstants.R42_PalaceofDarkness_BigHubRoom,
                RoomIdConstants.R76_GanonsTower_Mini_HelmasaurConveyorRoom,
                RoomIdConstants.R89_SkullWoods_FinalSectionEntranceRoom,
                RoomIdConstants.R103_SkullWoods_CompassChestRoom,
                RoomIdConstants.R104_SkullWoods_KeyChest_TrapRoom,
                RoomIdConstants.R126_IcePalace_HiddenChest_BombableFloorRoom,
                RoomIdConstants.R139_GanonsTower_BlockPuzzle_SpikeSkip_MapChestRoom,
                RoomIdConstants.R235_Cave0xEB,
                RoomIdConstants.R251_Cave0xFB));

            // crystal switches
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 82,
                RoomIdConstants.R11_PalaceofDarkness_TurtleRoom,
                RoomIdConstants.R19_TurtleRock_Hokku_BokkuKeyRoom2,
                RoomIdConstants.R27_PalaceofDarkness_Mimics_MovingWallRoom,
                RoomIdConstants.R30_IcePalace_BombFloor_BariRoom,
                RoomIdConstants.R42_PalaceofDarkness_BigHubRoom,
                RoomIdConstants.R43_PalaceofDarkness_MapChest_FairyRoom,
                RoomIdConstants.R49_TowerofHera_HardhatBeetlesRoom,
                RoomIdConstants.R61_GanonsTower_TorchRoom2,
                RoomIdConstants.R62_IcePalace_StalfosKnights_ConveyorHellway,
                RoomIdConstants.R91_GanonsTower_SpikePitRoom,
                RoomIdConstants.R107_GanonsTower_MimicsRooms,
                RoomIdConstants.R119_TowerofHera_EntranceRoom,
                RoomIdConstants.R135_TowerofHera_TileRoom,
                RoomIdConstants.R139_GanonsTower_BlockPuzzle_SpikeSkip_MapChestRoom,
                RoomIdConstants.R145_MiseryMire_FinalSwitchRoom,
                RoomIdConstants.R146_MiseryMire_DarkBombWall_SwitchesRoom,
                RoomIdConstants.R155_GanonsTower_ManySpikes_WarpMazeRoom,
                RoomIdConstants.R157_GanonsTower_CompassChest_InvisibleFloorRoom,
                RoomIdConstants.R161_MiseryMire_FishRoom,
                RoomIdConstants.R171_ThievesTown_MovingSpikes_KeyPotRoom,
                RoomIdConstants.R182_TurtleRock_ChainChompsRoom,
                RoomIdConstants.R191_IcePalaceCloneRoom_SwitchRoom,
                RoomIdConstants.R193_MiseryMire_CompassChest_TileRoom,
                RoomIdConstants.R196_TurtleRock_FinalCrystalSwitchPuzzleRoom,
                RoomIdConstants.R239_Cave_CrystalSwitch_5ChestsRoom));
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 83,
                RoomIdConstants.R11_PalaceofDarkness_TurtleRoom,
                RoomIdConstants.R19_TurtleRock_Hokku_BokkuKeyRoom2,
                RoomIdConstants.R27_PalaceofDarkness_Mimics_MovingWallRoom,
                RoomIdConstants.R30_IcePalace_BombFloor_BariRoom,
                RoomIdConstants.R42_PalaceofDarkness_BigHubRoom,
                RoomIdConstants.R43_PalaceofDarkness_MapChest_FairyRoom,
                RoomIdConstants.R49_TowerofHera_HardhatBeetlesRoom,
                RoomIdConstants.R53_SwampPalace_BigKey_BSRoom,
                RoomIdConstants.R62_IcePalace_StalfosKnights_ConveyorHellway,
                RoomIdConstants.R91_GanonsTower_SpikePitRoom,
                RoomIdConstants.R107_GanonsTower_MimicsRooms,
                RoomIdConstants.R119_TowerofHera_EntranceRoom,
                RoomIdConstants.R135_TowerofHera_TileRoom,
                RoomIdConstants.R139_GanonsTower_BlockPuzzle_SpikeSkip_MapChestRoom,
                RoomIdConstants.R145_MiseryMire_FinalSwitchRoom,
                RoomIdConstants.R146_MiseryMire_DarkBombWall_SwitchesRoom,
                RoomIdConstants.R155_GanonsTower_ManySpikes_WarpMazeRoom,
                RoomIdConstants.R157_GanonsTower_CompassChest_InvisibleFloorRoom,
                RoomIdConstants.R161_MiseryMire_FishRoom,
                RoomIdConstants.R171_ThievesTown_MovingSpikes_KeyPotRoom,
                RoomIdConstants.R182_TurtleRock_ChainChompsRoom,
                RoomIdConstants.R191_IcePalaceCloneRoom_SwitchRoom,
                RoomIdConstants.R193_MiseryMire_CompassChest_TileRoom,
                RoomIdConstants.R196_TurtleRock_FinalCrystalSwitchPuzzleRoom,
                RoomIdConstants.R239_Cave_CrystalSwitch_5ChestsRoom));

            // lazer eye
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 82,
                RoomIdConstants.R19_TurtleRock_Hokku_BokkuKeyRoom2,
                RoomIdConstants.R35_TurtleRock_WestExittoBalcony,
                RoomIdConstants.R150_GanonsTower_Torches1Room,
                RoomIdConstants.R165_GanonsTower_WizzrobesRooms,
                RoomIdConstants.R195_MiseryMire_BigChestRoom,
                RoomIdConstants.R197_TurtleRock_LaserBridge,
                RoomIdConstants.R213_TurtleRock_LaserKeyRoom
                ));
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 83,
                RoomIdConstants.R19_TurtleRock_Hokku_BokkuKeyRoom2,
                RoomIdConstants.R35_TurtleRock_WestExittoBalcony,
                RoomIdConstants.R150_GanonsTower_Torches1Room,
                RoomIdConstants.R165_GanonsTower_WizzrobesRooms,
                RoomIdConstants.R197_TurtleRock_LaserBridge,
                RoomIdConstants.R213_TurtleRock_LaserKeyRoom
                ));

            // statues
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 82,
                RoomIdConstants.R26_PalaceofDarkness_BigChestRoom,
                RoomIdConstants.R38_SwampPalace_StatueRoom,
                RoomIdConstants.R43_PalaceofDarkness_MapChest_FairyRoom,
                RoomIdConstants.R64_AgahnimsTower_FinalBridgeRoom,
                RoomIdConstants.R74_PalaceofDarkness_EntranceRoom,
                RoomIdConstants.R87_SkullWoods_BigKeyRoom,
                RoomIdConstants.R107_GanonsTower_MimicsRooms,
                RoomIdConstants.R123_GanonsTower));
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 83,
                //RoomIdConstants.R26_PalaceofDarkness_BigChestRoom,
                RoomIdConstants.R38_SwampPalace_StatueRoom,
                RoomIdConstants.R43_PalaceofDarkness_MapChest_FairyRoom,
                RoomIdConstants.R64_AgahnimsTower_FinalBridgeRoom,
                RoomIdConstants.R74_PalaceofDarkness_EntranceRoom,
                RoomIdConstants.R87_SkullWoods_BigKeyRoom,
                RoomIdConstants.R107_GanonsTower_MimicsRooms,
                RoomIdConstants.R123_GanonsTower,
                RoomIdConstants.R206_IcePalace_HoletoKholdstareRoom));

            // --- Requires 82 only
            // Pull switch (handle)
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 82,
                RoomIdConstants.R2_HyruleCastle_SwitchRoom,
                RoomIdConstants.R88_SkullWoods_BigChestRoom,
                RoomIdConstants.R100_ThievesTown_WestAtticRoom,
                RoomIdConstants.R140_GanonsTower_EastandWestDownstairs_BigChestRoom,
                RoomIdConstants.R267_SwampFloodwayRoom));

            // floor drop
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 82,
                RoomIdConstants.R26_PalaceofDarkness_BigChestRoom,
                RoomIdConstants.R61_GanonsTower_TorchRoom2,
                RoomIdConstants.R68_ThievesTown_BigChestRoom,
                RoomIdConstants.R86_SkullWoods_KeyPot_TrapRoom,
                RoomIdConstants.R94_IcePalace_LonelyFirebar,
                RoomIdConstants.R124_GanonsTower_EastSideCollapsingBridge_ExplodingWallRoom,
                RoomIdConstants.R149_GanonsTower_FinalCollapsingBridgeRoom,
                RoomIdConstants.R195_MiseryMire_BigChestRoom));

            // --- Requires 83 only
            // pull switch (toungue)
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 83,
                RoomIdConstants.R4_TurtleRock_CrystalRollerRoom,
                RoomIdConstants.R63_IcePalace_MapChestRoom,
                RoomIdConstants.R206_IcePalace_HoletoKholdstareRoom));

            // push switch (swamp)
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, null, 83,
                RoomIdConstants.R53_SwampPalace_BigKey_BSRoom,
                RoomIdConstants.R55_SwampPalace_MapChest_WaterFillRoom,
                RoomIdConstants.R118_SwampPalace_WaterDrainRoom));

            // force water teketite
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, 34, null,
                RoomIdConstants.R40_SwampPalace_EntranceRoom));

            // force wizzrobe
            RoomRequirements.Add(new RoomGroupRequirement(null, null, null, 37, null,
                RoomIdConstants.R151_MiseryMire_TorchPuzzle_MovingWallRoom));
        }
    }
}
