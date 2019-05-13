using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MoreWings.Items.ModdedWings
{
	[AutoloadEquip(EquipType.Wings)]
	public class MechanicalWaders : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Demonic Waders");
            Tooltip.SetDefault("Flight time: 90" + "\nHorizontal speed: 8" + "\nAcceleration: 1.2" + "\nAllows you to run" + "\nCounts as wings" + "\nGives you great mobility on ice");     
		}

		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 20;
            item.value = Item.sellPrice(0, 30, 50, 0);
            item.rare = 5;
			item.accessory = true;
		}	

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 90;
            player.accRunSpeed = 6.25f;
            player.iceSkate = true;
            player.moveSpeed += 07;
        }

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.86f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1.2f;
			maxAscentMultiplier = 2f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 8f;
			acceleration *= 1.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostsparkBoots, 1);
            recipe.AddIngredient(492, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddTile(305);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}