using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Luciful.Common.Systems
{
    public abstract class CommanderSpecial
    {
        /// <summary>
        /// Triggers whenever the special is activated.
        /// </summary>
        public abstract void OnActivate(Projectile projectile, NPC target);
    }
}
