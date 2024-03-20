using System;
using System.Collections.Generic;

namespace ChillyBonezMod
{
    // Token: 0x020000A3 RID: 163
    public class DoubleTargetting : BaseCombatTargettingSO
    {
        // Token: 0x170000BB RID: 187
        // (get) Token: 0x06000273 RID: 627 RVA: 0x00016461 File Offset: 0x00014661
        public override bool AreTargetAllies
        {
            get
            {
                return false;
            }
        }

        // Token: 0x170000BC RID: 188
        // (get) Token: 0x06000274 RID: 628 RVA: 0x00016464 File Offset: 0x00014664
        public override bool AreTargetSlots
        {
            get
            {
                return false;
            }
        }

        // Token: 0x06000275 RID: 629 RVA: 0x00016468 File Offset: 0x00014668
        public override TargetSlotInfo[] GetTargets(SlotsCombat slots, int casterSlotID, bool isCasterCharacter)
        {
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            bool flag = this.firstTargetting != null;
            if (flag)
            {
                foreach (TargetSlotInfo targetSlotInfo in this.firstTargetting.GetTargets(slots, casterSlotID, isCasterCharacter))
                {
                    list.Add(targetSlotInfo);
                }
            }
            bool flag2 = this.secondTargetting != null;
            if (flag2)
            {
                foreach (TargetSlotInfo targetSlotInfo2 in this.secondTargetting.GetTargets(slots, casterSlotID, isCasterCharacter))
                {
                    list.Add(targetSlotInfo2);
                }
            }
            return list.ToArray();
        }

        // Token: 0x0400013B RID: 315
        public BaseCombatTargettingSO firstTargetting;

        // Token: 0x0400013C RID: 316
        public BaseCombatTargettingSO secondTargetting;
    }
}
