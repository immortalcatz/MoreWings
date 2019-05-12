using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWings.Items
{
	public class AngelWings : GlobalItem
	{
		public virtual void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			if (item.type == 493)
            {
                Tooltip.SetDefault("Flight time: 100" + "\nHorizontal speed: 6.25" + "\nAcceleration: ");
            }
		}
	}
}
