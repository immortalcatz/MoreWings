using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWings.Items.Pets
{
	public class Devil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chunk of Flesh");
			Tooltip.SetDefault("Summons a Red Devil to follow behind you");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = mod.ProjectileType("Devil");
			item.buffType = mod.BuffType("Devil");
		}
        class MyGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (npc.type == NPCID.WallofFlesh && !Main.expertMode)
                {
                    if (Main.rand.NextFloat() < .50f)
                        Item.NewItem(npc.getRect(), mod.ItemType("Devil"));
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