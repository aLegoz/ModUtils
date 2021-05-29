using System;
using System.Reflection;
using HarmonyLib;
using VoxelTycoon.Game.UI;
using VoxelTycoon.UI;

namespace ModUtils
{
    public static class InGamePopUpMenuPatch
    {
        private const string HarmonyID = "com.in.game.popup.menu.patch";
        private static Harmony _harmony = new Harmony(HarmonyID);
        private static MethodInfo _mOriginal = AccessTools.Method(typeof(InGameMenuPopup), "AddItems");
        private static MethodInfo _mPostfix = SymbolExtensions.GetMethodInfo(() => AddItemsPostfix( default ));
        
        public static void Patch()
        {
            _harmony.Patch(_mOriginal, null, new HarmonyMethod(_mPostfix));
        }

        public static void Unpatch()
        {
            _harmony.Unpatch(_mOriginal, HarmonyPatchType.All, HarmonyID);
        }
        private static void AddItemsPostfix(InGameMenuPopup __instance)
        {
            FontIcon icon = FontIcon.FaSolid("");
            string itemName = "Mod settings";
            AddItem(__instance, icon, itemName, () => SettingsManager.ShowWindow());
        }
        
        private static void AddItem(InGameMenuPopup instance, FontIcon icon, string name, Action action)
        {
            object[] param = new object[] {icon, name, action};
            MethodInfo mAddItem = typeof(InGameMenuPopup).GetMethod("AddItem", BindingFlags.NonPublic | BindingFlags.Instance); 
            mAddItem.Invoke(instance, param);
        }
    }
}