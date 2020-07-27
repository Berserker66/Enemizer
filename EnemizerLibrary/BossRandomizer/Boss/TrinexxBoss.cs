﻿namespace EnemizerLibrary
{
    public class TrinexxBoss : Boss
    {
        public TrinexxBoss() : base(BossType.Trinexx)
        {
            BossPointer = new byte[] { 0xBA, 0xE5 };
            BossGraphics = 23;
            BossSpriteId = SpriteConstants.TrinexxSprite;
            BossNode = "turtle-trinexx";

            Requirements = "Fire Rod,Ice Rod";

            BossSpriteArray = new byte[]
            {
                0x05, 0x07, 0xCB, // trinexx body?
                0x05, 0x07, 0xCC, // trinexx ice head?
                0x05, 0x07, 0xCD, // trinexx fire head?
            };
        }
    }
}
