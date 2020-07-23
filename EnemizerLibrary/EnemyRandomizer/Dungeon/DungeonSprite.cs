﻿using System;

namespace EnemizerLibrary
{
    public class DungeonSprite
    {
        public byte byte0 { get; set; }
        public byte byte1 { get; set; }

        byte spriteId;
        public int SpriteId
        {
            get
            {
                return spriteId + (IsOverlord ? 0x100 : 0);
            }
            set
            {
                spriteId = (byte)value;
                byte0 = (byte)(byte0 & SpriteConstants.SpriteSubtypeByte0RemoveMask);
                byte1 = (byte)(byte1 & SpriteConstants.OverlordRemoveMask);
                IsOverlord = false;
            }
        }

        public int Address { get; set; }
        public bool IsOverlord { get; set; }
        public bool HasAKey { get; set; }
        public string SpriteName
        {
            get
            {
                return SpriteConstants.GetSpriteName(SpriteId);
            }
        }
        public bool IsOnBG2 { get { return (byte0 & 0x80) != 0; } }
        public int HMParam { get { return ((byte0 & 0x60) >> 2) | ((byte1 & 0xE0) >> 5); } }
        public int YCoordPixels { get { return (byte0 & 0x1F) * 16; } }
        public int XCoordPixels { get { return (byte1 & 0x1F) * 16; } }


        RomData romData;

        public DungeonSprite(RomData romData, int address)
        {
            this.romData = romData;
            this.Address = address;

            byte0 = romData[address];
            byte1 = romData[address + 1];
            spriteId = romData[address + 2];

            // overlords should be 00111 (keys are 11000)
            IsOverlord = (byte1 & SpriteConstants.OverlordMask) == SpriteConstants.OverlordMask
                        && (byte0 & SpriteConstants.SpriteSubtypeByte0Mask) != SpriteConstants.SpriteSubtypeByte0Mask;
            if(!IsOverlord && spriteId != SpriteConstants.KeySprite && spriteId != SpriteConstants.WallmasterSprite) // wall masters spawn out if you remove params
            {
                // fix our guards
                RemoveParams();
            }

            if (romData[address + 3] != 0xFF && (romData[address + 5] == SpriteConstants.KeySprite || romData[address + 5] == SpriteConstants.BigKeySprite))
            {
                HasAKey = true;
            }
        }

        void RemoveParams()
        {
            byte0 = (byte)(byte0 & SpriteConstants.SpriteSubtypeByte0RemoveMask);
            byte1 = (byte)(byte1 & SpriteConstants.OverlordRemoveMask);
        }

        public void UpdateRom()
        {
            if (spriteId == 3 && IsOverlord == false)
            {
                throw new Exception("SpriteID 3 will crash the game");
            }

            // TODO: make wall masters work everywhere
            // this does bad things once you leave the room (wrong warp and crash)
            if (spriteId == SpriteConstants.WallmasterSprite)
            {
                //// 5FFB4-5FFB6 set to NOP (probably break something else)
                //romData[0x5FFB4] = AssemblyConstants.NoOp;
                //romData[0x5FFB5] = AssemblyConstants.NoOp;
                //romData[0x5FFB6] = AssemblyConstants.NoOp;

                //romData[0x5FFB8] = 15; // this will make you warp outside

                spriteId = 9;
                byte1 |= SpriteConstants.OverlordMask; // make it an overlord
                IsOverlord = false; // but pretend it's not
            }

            if (IsOverlord == false)
            {
                romData[Address] = byte0;
                romData[Address + 1] = byte1;
            }

            romData[Address + 2] = spriteId;
        }

        public bool CanBeChanged()
        {
            // TODO: put logic in here
            return true;
        }

        public bool NeedsToBeKillable()
        {
            // TODO: put logic in here
            return true;
        }

        // TODO: add any other "logic"
    }
}
