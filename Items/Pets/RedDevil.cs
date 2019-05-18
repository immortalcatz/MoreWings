using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWings.Items.Pets
{
	public class RedDevil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chunk of Flesh");
			Tooltip.SetDefault("Summons a Red Devil to follow behind you");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 24));
        }
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = mod.ProjectileType("RedDevil");
			item.buffType = mod.BuffType("RedDevil");
            item.value = Item.sellPrice(0, 2, 50, 0);
            item.width = 20;
            item.height = 26;
        }
        class MyGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (npc.type == NPCID.WallofFlesh && !Main.expertMode)
                {
                    if (Main.rand.NextFloat() < .10f)
                        Item.NewItem(npc.getRect(), mod.ItemType("RedDevil"));
                }
            }
        }
		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}