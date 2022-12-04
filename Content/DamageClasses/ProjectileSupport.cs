using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Luciful.Content.DamageClasses
{
    public class ProjectileSupport : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == Generic) return StatInheritanceData.Full;
            else return StatInheritanceData.None;
        }

        public override void SetDefaultStats(Player player)
        {
            player.GetCritChance<ProjectileSupport>() += 5;
        }

        public override bool UseStandardCritCalcs => true;
    }
}
