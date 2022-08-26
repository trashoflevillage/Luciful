using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luciful.Common.Systems.GenPasses
{
    internal class GenHelper
    {
        public static int GetWorldSizeMultiplier(int width)
        {
            return (width / 4200) * 2;
        }
    }
}
