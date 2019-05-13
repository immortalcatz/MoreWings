using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MoreWings.Items
{
    public class BatWings : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "Tooltip0" && item.type == ItemID.BatWings)
                {
                    tooltipLine.text = "Flight time: 130\nHorizontal speed: 0\nAcceleration: 0";
                }
            }
        }
    }
}