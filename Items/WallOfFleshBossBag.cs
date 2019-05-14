using Terraria;
using Terraria.ModLoader;

namespace MoreWings.Items
{
    public class WallOfFleshBossBag : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (Main.rand.NextFloat() < .50f)
            {
                player.QuickSpawnItem(mod.ItemType("Devil"));
            }
        }
    }
}