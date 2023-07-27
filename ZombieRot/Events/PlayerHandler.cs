using Exiled.API.Features;


using Exiled.Events.EventArgs.Player;

namespace Exiled.ZombieRotEvents
{
    using ZombieRot;
    using PlayerRoles;

    internal sealed class PlayerHandler
    {
        private readonly ZombieRot Instance = ZombieRot.Instance;

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            Log.Debug("Role changed");
            if (ev.Player.Role == RoleTypeId.Scp0492)
            {
                if (Instance.rotHandler.ContainsKey(ev.Player)) 
                    Instance.rotHandler.RemoveZombieTicker(ev.Player);
            } else if (ev.NewRole == RoleTypeId.Scp0492)
            {
                Instance.rotHandler?.CreateZombieTicker(ev.Player);
            }
        }
        public void OnLeft(LeftEventArgs ev)
        {
            if (Instance.rotHandler.ContainsKey(ev.Player))
            {
                Instance.rotHandler.RemoveZombieTicker(ev.Player);
            }
        }   
    }
}