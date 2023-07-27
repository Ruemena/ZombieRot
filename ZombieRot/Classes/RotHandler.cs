using Exiled.API.Features;
using MEC;
using ZombieRot.Types;

namespace ZombieRot
{
    public class RotHandler
    {
        private readonly ZombieRot Instance = ZombieRot.Instance;
        private Dictionary<Player, Zombie> zombiePair = new();


        public bool ContainsKey(Player player)
        {
            if (zombiePair.ContainsKey(player)) return true; else return false;
        }
        public void RemoveZombieTicker(Player player)
        {
            if (zombiePair.ContainsKey(player))
            {
                Log.Debug("Removing zombie ticker");
                Timing.KillCoroutines(zombiePair[player].CoroutineHandle);
                zombiePair.Remove(player);
            } else
            {
                throw new Exception($"Player {player} not found in zombiePair");
            }
        }
        public void ClearZombieTickers()
        {
            foreach (KeyValuePair<Player, Zombie> entry in zombiePair)
            {
                Zombie zombie = entry.Value;
                Timing.KillCoroutines(zombie.CoroutineHandle);
            }
            zombiePair = new(); // reset
        }
        public void CreateZombieTicker(Player player)
        {
            Log.Debug("Creating a zombie ticker for " + player.DisplayNickname);
            CoroutineHandle cH = Timing.RunCoroutine(TickZombie(player, Instance.Config.TickTime));
            zombiePair.Add(player, new Zombie(cH, Instance.Config.Damage));
        }
        private IEnumerator<float> TickZombie(Player player, float tickTime)
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(tickTime);
                Zombie zombie = zombiePair[player];
                player.Hurt(zombie.Damage);
                zombie.Damage += Instance.Config.IncreaseValue;
                zombie.Damage *= Instance.Config.IncreaseMultiplier;
            }
        }
    }
}