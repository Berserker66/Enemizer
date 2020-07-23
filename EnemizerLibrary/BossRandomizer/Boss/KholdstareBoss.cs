﻿namespace EnemizerLibrary
{
    public class KholdstareBoss : Boss
    {
        public KholdstareBoss() : base(BossType.Kholdstare)
        {
            BossPointer = new byte[] { 0x01, 0xEA };
            BossGraphics = 22;
            BossSpriteId = SpriteConstants.KholdstareSprite;
            BossNode = "ice-kholdstare";

            Requirements = "Fire Rod;Bombos,L1 Sword";

            BossSpriteArray = new byte[]
            {
                0x05, 0x07, 0xA3, // shell
                0x05, 0x07, 0xA4, // falling ice
                0x05, 0x07, 0xA2  // kholdstare
            };
        }
    }
}
