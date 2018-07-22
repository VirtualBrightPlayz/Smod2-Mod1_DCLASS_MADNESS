using Smod2;
using Smod2.Attributes;

namespace VirtualBrightPlayz.SCPSL.Mod1
{
    [PluginDetails(author = "VirtualBrightPlayz",
        description = "D-Class vs. SCP-173",
        id = "virtualbrightplayz.scpsl.mod1",
        name = "D-Class Madness",
        version = "1.0",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0)]
    public class DClass : Plugin
    {
        public override void OnDisable()
        {
        }

        public override void OnEnable()
        {
            this.Info("D-Class Madness plugin enabled.");
        }

        public override void Register()
        {
            this.AddEventHandlers(new DClassEventHandler1(this));
        }
    }
}
