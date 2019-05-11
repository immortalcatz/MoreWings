using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MoreWings.Items
{
    [AutoloadEquip(EquipType.Wings)]
    public class DirtWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Flight time: 25" + "\nAcceleration: 0.8"); 
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 0, 1, 50);
            item.rare = 1;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 25;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.25f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 1.2f;
            constantAscend = 0.135f;
        }
        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 5f;
            acceleration *= 0.8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 100);
            recipe.AddIngredient(ItemID.Feather, 5);
            recipe.AddIngredient(mod.ItemType("ConcentratedGel"), 1);
            recipe.AddTile(305);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}