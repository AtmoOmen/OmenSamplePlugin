using System.Linq;
using Dalamud.Interface.Windowing;
using SamplePlugin;
using SamplePlugin.Windows;

namespace DailyRoutines.Managers;

public class WindowManager
{
    public WindowSystem? WindowSystem { get; private set; }
    public static ConfigWindow? ConfigWindow { get; private set; }

    internal void Init()
    {
        WindowSystem = new("OmenSamplePlugin");
        ConfigWindow = new();
        AddWindows(ConfigWindow);

        Service.PluginInterface.UiBuilder.Draw += DrawUI;
        Service.PluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
    }

    public bool AddWindows(Window? window)
    {
        if (window == null) return false;

        var addedWindows = WindowSystem.Windows;
        if (addedWindows.Contains(window) || addedWindows.Any(x => x.WindowName == window.WindowName))
            return false;

        WindowSystem.AddWindow(window);
        return true;
    }

    public bool RemoveWindows(Window? window)
    {
        if (window == null) return false;

        var addedWindows = WindowSystem.Windows;
        if (!addedWindows.Contains(window))
            return false;

        WindowSystem.RemoveWindow(window);
        return true;
    }

    private void DrawUI()
    {
        WindowSystem?.Draw();
    }

    public void DrawConfigUI()
    {
        if (ConfigWindow != null) ConfigWindow.IsOpen ^= true;
    }

    internal void Uninit()
    {
        WindowSystem.RemoveAllWindows();
        ConfigWindow?.Dispose();
        ConfigWindow = null;
    }
}
