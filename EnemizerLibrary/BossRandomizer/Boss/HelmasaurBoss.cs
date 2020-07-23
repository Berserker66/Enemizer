﻿namespace EnemizerLibrary
{
    public class HelmasaurBoss : Boss
    {
        public HelmasaurBoss() : base(BossType.Helmasaur)
        {
            BossPointer = new byte[] { 0x49, 0xE0 };
            BossGraphics = 21;
            BossSpriteId = SpriteConstants.HelmasaurKingSprite;
            BossNode = "pod-helmasaur";

            BossSpriteArray = new byte[]
            {
                0x06, 0x07, 0x92 // helmasaur
            };
        }
    }
}
