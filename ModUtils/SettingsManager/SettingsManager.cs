using HarmonyLib;
using VoxelTycoon.Modding;

namespace ModUtils
{
    public class SettingsManager : Mod
    {
        private static SettingsManagerWindow _window = SettingsManagerWindow.Create();

        protected override void OnModsInitialized()
        {
            InGamePopUpMenuPatch.Patch();
        }
        
        protected override void OnGameStarted()
        {
            _window.Title = S.ModSettings;
        }

        protected override void Deinitialize()
        {
            InGamePopUpMenuPatch.Unpatch();
        }

        public static void ShowWindow()
        {
            _window.Show();
        }

        public static SettingsManagerControl AddTab(string pageName)
        {
            return _window.AddPage(pageName);
        }
    }
}