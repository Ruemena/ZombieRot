namespace ZombieRot
{
    using System.ComponentModel;

    using Exiled.API.Interfaces;

    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        [Description("The base amount of damage to deal every tick - may be increased")]
        public float Damage { get; set; } = 2f;
        [Description("In seconds, how often to deal damage and how often to increase the damage (if ExponentialDamage is enabled)")]
        public float TickTime { get; set; } = 7;

        [Description("Added to the damage every TickTime to produce a new damage value - set to 0 for no flat increase in damage over time. Note that this is added before IncreaseMultiplier")]
        public float IncreaseValue { get; set; } = 0.25f;
        [Description("Multiplied by the damage every TickTime to produce a new damage value - set to 1 for no multiplicative increase in damage over time")]
        public float IncreaseMultiplier { get; set; } = 1f;
    }
}
    