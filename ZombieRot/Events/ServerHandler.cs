namespace Exiled.ZombieRotEvents
{
    using Exiled.Events.EventArgs.Server;
    using ZombieRot;

    internal sealed class ServerHandler
    {
        private readonly ZombieRot Instance = ZombieRot.Instance;

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Instance.rotHandler?.ClearZombieTickers();
        }
    }
}