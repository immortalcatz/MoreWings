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
			DisplayName.SetDefault("Pear.");
			Main.projFrames[projectile.type] = 1;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
			ProjectileID.Sets.LightPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.penetrate = -1;
			projectile.netImportant = true;
			projectile.timeLeft *= 5;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.scale = 0.8f;
			projectile.tileCollide = false;
		}

		const int fadeInTicks = 30;
		const int fullBrightTicks = 200;
		const int fadeOutTicks = 30;
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
				modPlayer.Pear = false;
			}
			if (modPlayer.Pear)
			{
				projectile.timeLeft = 2;
			}
			projectile.rotation += projectile.velocity.X / 20f;
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.9f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f, ((255 - projectile.alpha) * 0.3f) / 255f);
			if (projectile.velocity.Length() > 1f)
			{
				projectile.velocity *= .98f;
			}
			if (projectile.velocity.Length() == 0)
			{
				projectile.velocity = Vector2.UnitX.RotatedBy(Main.rand.NextFloat() * Math.PI * 2);
				projectile.velocity *= 2f;
			}
			projectile.ai[0]++;
			if (projectile.ai[0] < fadeInTicks)
			{
				projectile.alpha = (int)(255 - 255 * projectile.ai[0] / fadeInTicks);
			}
			else if (projectile.ai[0] < fadeInTicks + fullBrightTicks)
			{
				projectile.alpha = 0;
				if (Main.rand.Next(6) == 0)
				{
					int num145 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0f, 0f, 200, default(Color), 0.8f);
					Main.dust[num145].velocity *= 0.3f;
				}
			}
			else if (projectile.ai[0] < fadeInTicks + fullBrightTicks + fadeOutTicks)
			{
				projectile.alpha = (int)(255 * (projectile.ai[0] - fadeInTicks - fullBrightTicks) / fadeOutTicks);
			}
			else
			{
				projectile.Center = new Vector2(Main.rand.Next((int)player.Center.X - range, (int)player.Center.X + range), Main.rand.Next((int)player.Center.Y - range, (int)player.Center.Y + range));
				projectile.ai[0] = 0;
				Vector2 vectorToPlayer = player.Center - projectile.Center;
				projectile.velocity = 2f * Vector2.Normalize(vectorToPlayer);
			}
			if (Vector2.Distance(player.Center, projectile.Center) > rangeHypoteneus)
			{
				projectile.Center = new Vector2(Main.rand.Next((int)player.Center.X - range, (int)player.Center.X + range), Main.rand.Next((int)player.Center.Y - range, (int)player.Center.Y + range));
				projectile.ai[0] = 0;
				Vector2 vectorToPlayer = player.Center - projectile.Center;
				projectile.velocity += 2f * Vector2.Normalize(vectorToPlayer);
			}
			if ((int)projectile.ai[0] % 100 == 0)
			{
				projectile.velocity = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(90));
			}
		}
	}
}