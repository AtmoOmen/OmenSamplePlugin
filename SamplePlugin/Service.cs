using DailyRoutines.Managers;
using Dalamud.Game;
using Dalamud.Game.ClientState.Objects;
using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace SamplePlugin;

public class Service
{
    public const string CommandName = "/omspp";

    public static void Init(DalamudPluginInterface pluginInterface)
    {
        PluginInterface = pluginInterface;
        pluginInterface.Create<Service>();

        Config = pluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Config.Init();

        WindowManager.Init();
        CommandHandler();
    }

    public static void Uninit()
    {
        WindowManager.Uninit();
        Config.Uninit();
    }

    private static void CommandHandler()
    {
        const string helpMessage = "A useful message to display in /xlhelp";

        Command.RemoveHandler(CommandName);
        Command.AddHandler(CommandName, new CommandInfo(OnCommand) { HelpMessage = helpMessage });
    }

    private static void OnCommand(string command, string args)
    {
        WindowManager.ConfigWindow.IsOpen = !WindowManager.ConfigWindow.IsOpen;
    }

    [PluginService] public static IAddonLifecycle AddonLifecycle { get; private set; } = null!;
    [PluginService] public static IAddonEventManager AddonEvent { get; private set; } = null!;
    [PluginService] public static IAetheryteList AetheryteList { get; private set; } = null!;
    [PluginService] public static IBuddyList BuddyList { get; private set; } = null!;
    [PluginService] public static IChatGui Chat { get; private set; } = null!;
    [PluginService] public static IClientState ClientState { get; private set; } = null!;
    [PluginService] public static ICommandManager Command { get; set; } = null!;
    [PluginService] public static ICondition Condition { get; private set; } = null!;
    [PluginService] public static IContextMenu ContextMenu { get; private set; } = null!;
    [PluginService] public static IDataManager Data { get; private set; } = null!;
    [PluginService] public static IDtrBar DtrBar { get; private set; } = null!;
    [PluginService] public static IDutyState DutyState { get; private set; } = null!;
    [PluginService] public static IFateTable Fate { get; private set; } = null!;
    [PluginService] public static IFlyTextGui FlyText { get; private set; } = null!;
    [PluginService] public static IFramework Framework { get; private set; } = null!;
    [PluginService] public static IGameConfig GameConfig { get; private set; } = null!;
    [PluginService] public static IGameGui Gui { get; private set; } = null!;
    [PluginService] public static IGameInteropProvider Hook { get; private set; } = null!;
    [PluginService] public static IGameInventory Inventory { get; private set; } = null!;
    [PluginService] public static IGameLifecycle Lifecycle { get; private set; } = null!;
    [PluginService] public static IGameNetwork Network { get; private set; } = null!;
    [PluginService] public static IGamepadState Gamepad { get; private set; } = null!;
    [PluginService] public static IJobGauges JobGauges { get; private set; } = null!;
    [PluginService] public static IKeyState KeyState { get; private set; } = null!;
    [PluginService] public static ILibcFunction LibcFunction { get; private set; } = null!;
    [PluginService] public static INotificationManager DalamudNotice { get; private set; } = null!;
    [PluginService] public static IObjectTable ObjectTable { get; private set; } = null!;
    [PluginService] public static IPartyFinderGui PartyFinder { get; private set; } = null!;
    [PluginService] public static IPartyList PartyList { get; private set; } = null!;
    [PluginService] public static IPluginLog Log { get; private set; } = null!;
    [PluginService] public static ITargetManager Target { get; private set; } = null!;
    [PluginService] public static ITextureProvider Texture { get; private set; } = null!;
    [PluginService] public static ITitleScreenMenu TitleScreenMenu { get; private set; } = null!;
    [PluginService] public static IToastGui Toast { get; private set; } = null!;
    public static DalamudPluginInterface PluginInterface { get; private set; } = null!;
    public static SigScanner SigScanner { get; private set; } = new();
    public static Configuration Config { get; private set; } = null!;
    public static WindowManager WindowManager { get; private set; } = new();
}
