using System;
using UnityEngine;
using UnityEngine.UI;
using VoxelTycoon;
using VoxelTycoon.Game.UI;
using VoxelTycoon.UI;
using VoxelTycoon.UI.Controls;
using VoxelTycoon.UI.Windows;

namespace ModUtils
{
    internal class SettingsManagerWindow : TabbedRichWindow
    {
        public static int TabsAmount = 0;
        
        protected override void InitializeFrame()
        {
            base.InitializeFrame();
            Draggable = true;
            Priority = 1001;
            Title = "null";
            Width = new float?(500f);
        }
        internal static SettingsManagerWindow Create()
        {
            return UIManager.Current.CreateWindow<SettingsManagerWindow>(FitWindowStrategy.Tile);
        }

        public override void TryClose()
        {
            this.Hide();
        }

        internal SettingsManagerControl AddPage(string pageName)
        {
            TabsAmount++;
            LayoutElement layoutElement = Instantiate<LayoutElement>(R.Game.UI.Settings.SettingsPage);
            layoutElement.preferredHeight = Mathf.Min(layoutElement.preferredHeight, (float)UIManager.Current.GetAvailableScreenHeight(250));
            base.AddTab(pageName, layoutElement.transform, UIColors.Solid.ContentBackground, TabContentHideMode.Deactivate);
            return new SettingsManagerControl(layoutElement.transform.Find("Viewport/Content"));
        }
    }
}