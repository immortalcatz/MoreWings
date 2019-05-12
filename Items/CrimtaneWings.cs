using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWings.Items
{
    [AutoloadEquip(EquipType.Wings)]
    public class CrimtaneWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimtane Soul");
            Tooltip.SetDefault("Flight time: 40" + "\nHorizontal speed: 5" + "\nAcceleration: 0.8" + "\n It's radiating with the power of the crimson");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(0, 3, 40, 0);
            item.rare = 2;
            item.accessory = true;
        }
        public override void UpdateVanity(Player player, EquipType type)
       {
           if (player.wingFrame != 0)
           {
                Dust.NewDust(player.position, player.width, player.height, 50, 0f, 0f, 150, default(Color), 1f);
            }
        }
         public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 40;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.50f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 1.5f;
            constantAscend = 0.1f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 5f;
            acceleration *= 0.8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TissueSample, 20);
            recipe.AddIngredient(ItemID.Feather, 7);
            recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(mod.ItemType("ConcentratedGel"), 1);
            recipe.AddTile(305);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}