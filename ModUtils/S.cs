using VoxelTycoon;
using VoxelTycoon.Localization;

namespace ModUtils
{
    public static class S
    {
        private const string ModTag = "mod_utils/";
        private static Locale locale = LazyManager<LocaleManager>.Current.Locale;
        
        public static DisplayString ModSettings => locale.GetString($"{ModTag}mod_settings");
        
    }
}