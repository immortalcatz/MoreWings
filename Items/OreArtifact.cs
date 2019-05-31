using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWings.Items
{
    public class OreArtifact : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Spawns all ores from MoreWings into your world\nOnly use if your world doesn't have these ores");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.maxStack = 1;
            item.rare = -12;
            item.consumable = true;
        }
        public override bool UseItem(Player player)
        {
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);
                WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(2, 6), mod.TileType("PinkQuartz"), false, 0f, 0f, false, true);
                return true;
            }
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);
                WorldGen.TileRunner(x, y, (double)WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(2, 6), mod.TileType("ZincOre"), false, 0f, 0f, false, true);
                return true;
            }
        }
    }
}