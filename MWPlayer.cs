using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace MoreWings
{
	public class MWPlayer : ModPlayer
	{
		public bool Pear = false;

        public override void SetupStartInventory(IList<Item> items)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("Pear"));
            item.stack = 1;
            items.Add(item);
        }
    }
}
