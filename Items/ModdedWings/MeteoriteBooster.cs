using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MoreWings.Items.ModdedWings
{
	[AutoloadEquip(EquipType.Wings)]
	public class MeteoriteBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
            Tooltip.SetDefault("Flight time: 55" + "\nHorizontal speed: 6" + "\nAcceleration: 1");
                
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
            item.value = Item.sellPrice(0, 2, 80, 0);
            item.rare = 3;
			item.accessory = true;
		}	

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 55;
        }

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.86f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 1.7f;
			constantAscend = 0.12f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 6f;
			acceleration *= 1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 60);
            recipe.AddIngredient(ItemID.MeteoriteBar, 20);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(mod.ItemType("ConcentratedGel"), 2);
            recipe.AddTile(305);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}