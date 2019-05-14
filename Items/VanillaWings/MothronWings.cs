using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MoreWings.Items.VanillaWings
{
    public class MothronWings : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "Tooltip0" && item.type == ItemID.MothronWings)
                {
                    tooltipLine.text = "Flight time: 160\nHorizontal speed: 0\nAcceleration: 0";
                }
            }
        }
    }
}