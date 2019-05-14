using Terraria;
using Terraria.ModLoader;

namespace MoreWings.Buffs
{
	public class Devil : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Red Devil");
			Description.SetDefault("\"But can you trust it?\"");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<MWPlayer>(mod).Devil = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Devil")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Devil"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}