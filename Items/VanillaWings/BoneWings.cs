using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MoreWings.Items.VanillaWings
{
    public class BoneWings : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "Tooltip0" && item.type == ItemID.BoneWings)
                {
                    tooltipLine.text = "Flight time: 140\nHorizontal speed: 7\nAcceleration: 1";
                }
            }
        }
    }
}