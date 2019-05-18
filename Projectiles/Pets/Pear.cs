using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreWings.Projectiles.Pets
{
	public class Pear : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 1;
			Main.projPet[projectile.type] = true;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }

		public override void SetDefaults()
		{
			projectile.CloneDefaults(492);
			aiType = 492;
        }

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false;
			return true;
		}

        const int range = 500;
        int rangeHypoteneus = (int)Math.Sqrt(range * range + range * range);

        public override void AI()
		{
			Player player = Main.player[projectile.owner];
			MWPlayer modPlayer = player.GetModPlayer<MWPlayer>(mod);
            if (!player.active)
            {
                projectile.active = false;
                return;
            }
            if (player.dead)
			{
				modPlayer.pear = false;
			}
			if (modPlayer.pear)
			{
				projectile.timeLeft = 2;
			}
            if (Vector2.Distance(player.Center, projectile.Center) > rangeHypoteneus)
            {
                projectile.Center = new Vector2(Main.rand.Next((int)player.Center.X - range, (int)player.Center.X + range), Main.rand.Next((int)player.Center.Y - range, (int)player.Center.Y + range));
                projectile.ai[0] = 0;
                Vector2 vectorToPlayer = player.Center - projectile.Center;
                projectile.velocity += 2f * Vector2.Normalize(vectorToPlayer);
            }
        }
	}
}