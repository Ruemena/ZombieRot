namespace ZombieRot
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.ZombieRotEvents;

    public class ZombieRot : Plugin<Config>
    {
        public RotHandler? rotHandler;

        private ServerHandler serverHandler;
        private PlayerHandler playerHandler;

        public override string Author { get; } = "Rue";
        public override string Name { get; } = "ZombieRot";
        public override string Prefix { get; } = "ZombieRot";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(7, 2, 0);

        public override PluginPriority Priority { get; } = PluginPriority.Last;

        private ZombieRot() { }
        private static readonly ZombieRot Singleton = new ZombieRot();
        public static ZombieRot Instance => Singleton;

        public override void OnEnabled()
        {
            rotHandler = new RotHandler();

            serverHandler = new ServerHandler();
            playerHandler = new PlayerHandler();

            Exiled.Events.Handlers.Server.RoundEnded += serverHandler.OnRoundEnded;
            Exiled.Events.Handlers.Player.ChangingRole += playerHandler.OnChangingRole;
            Exiled.Events.Handlers.Player.Left += playerHandler.OnLeft;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundEnded -= serverHandler.OnRoundEnded;
            Exiled.Events.Handlers.Player.ChangingRole -= playerHandler.OnChangingRole;
            Exiled.Events.Handlers.Player.Left -= playerHandler.OnLeft;

            serverHandler = null;
            playerHandler = null;
            rotHandler = null;
            base.OnDisabled();
        }
    }
}
