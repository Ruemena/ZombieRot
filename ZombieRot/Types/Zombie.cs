using MEC;

namespace ZombieRot.Types
{
    internal class Zombie
    {
        public CoroutineHandle CoroutineHandle { get; set; }
        public float Damage { get; set; }
        public Zombie (CoroutineHandle cH, float damage)
        {
            CoroutineHandle = cH;
            Damage = damage;
        }
    }
}
