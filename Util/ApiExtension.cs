using ACulinaryArtillery;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Vintagestory.API.Common;

namespace Vintagestory.GameContent
{
    public static class ApiAdditions
    {
        private static readonly ConditionalWeakTable<ICoreAPI, ACARecipeRegistrySystem> registries = new();

        private static ACARecipeRegistrySystem Registry(ICoreAPI api)
        {
            return registries.GetValue(api, api => api.ModLoader.GetModSystem<ACARecipeRegistrySystem>());
        }

        public static List<CookingRecipe> GetMixingRecipes(this ICoreAPI api)
        {
            return Registry(api).MixingRecipes;
        }

        public static List<SimmerRecipe> GetSimmerRecipes(this ICoreAPI api)
        {
            return Registry(api).SimmerRecipes;
        }

        public static List<DoughRecipe> GetKneadingRecipes(this ICoreAPI api)
        {
            return Registry(api).DoughRecipes;
        }
    }
}
