﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EnemizerLibrary
{
    public class OverworldAreaCollection
    {
        public List<OverworldArea> OverworldAreas { get; set; } = new List<OverworldArea>();
        RomData romData;
        Random rand;
        SpriteRequirementCollection spriteRequirementCollection;
        SpriteGroupCollection spriteGroupCollection;

        public OverworldAreaCollection(RomData romData, Random rand, SpriteGroupCollection spriteGroupCollection, SpriteRequirementCollection spriteRequirementCollection)
        {
            this.romData = romData;
            this.rand = rand;
            this.spriteGroupCollection = spriteGroupCollection;
            this.spriteRequirementCollection = spriteRequirementCollection;

            LoadAreas();
        }

        void LoadAreas()
        {
            //for (int i = 0; i < 0x112; i++) // after 0x111 is special stuff we don't want to touch
            for (int i = 0; i < 0x82; i++) // stop before unknown special areas
            {
                var owArea = new OverworldArea(romData, i, rand, spriteGroupCollection, spriteRequirementCollection);
                OverworldAreas.Add(owArea);
            }
            for (int i = 0x90; i < 0xD0; i++) // post-aga LW areas
            {
                var owArea = new OverworldArea(romData, i, rand, spriteGroupCollection, spriteRequirementCollection);
                OverworldAreas.Add(owArea);
            }
        }

        public void UpdateRom()
        {
            foreach(var a in OverworldAreas)
            {
                a.UpdateRom();
            }
        }

        public void RandomizeAreaSpriteGroups(SpriteGroupCollection spriteGroups)
        {
            // TODO: this needs to be updated???

            foreach (var a in OverworldAreas.Where(x => OverworldAreaConstants.DoNotRandomizeAreas.Contains(x.AreaId) == false))
            {
                List<SpriteRequirement> doNotUpdateSprites = spriteRequirementCollection
                                                            .DoNotRandomizeSprites
                                                            .Where(x => //x.CanSpawnInRoom(a)
                                                                        //&& 
                                                                        a.Sprites.Select(y => y.SpriteId).ToList().Contains(x.SpriteId)
                                                                )
                                                            .ToList();

                var possibleSpriteGroups = spriteGroups.GetPossibleOverworldSpriteGroups(doNotUpdateSprites).ToList();

                //Debug.Assert(possibleSpriteGroups.Count > 0);

                a.GraphicsBlockId = (byte)possibleSpriteGroups[rand.Next(possibleSpriteGroups.Count)].GroupId;
            }

            OverworldGroupRequirementCollection owReqs = new OverworldGroupRequirementCollection();
            // force any areas we need to
            foreach (var sg in owReqs.OverworldRequirements)
            {
                foreach (var forcedR in OverworldAreas.Where(x => sg.Areas.Contains(x.AreaId)))
                {
                    forcedR.GraphicsBlockId = (byte)sg.GroupId;
                }
            }
        }

    }
}