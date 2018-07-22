using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System.Collections.Generic;

namespace VirtualBrightPlayz.SCPSL.Mod1
{
    internal class DClassEventHandler1 : IEventHandlerSetRole, IEventHandlerRoundRestart, IEventHandlerPlayerDie, IEventHandlerRoundStart
    {
        private Plugin plugin;
        private bool oneSevenThreeSpawned;
        private bool roundStarted;
        private List<int> players = new List<int>();

        public DClassEventHandler1(Plugin dClass)
        {
            this.plugin = dClass;
            oneSevenThreeSpawned = false;
            roundStarted = false;
            players.Clear();
        }

        void IEventHandlerPlayerDie.OnPlayerDie(PlayerDeathEvent ev)
        {
            players.Remove(ev.Player.PlayerId);
        }

        void IEventHandlerRoundRestart.OnRoundRestart(RoundRestartEvent ev)
        {
            oneSevenThreeSpawned = false;
            roundStarted = false;
            players.Clear();
        }

        void IEventHandlerRoundStart.OnRoundStart(RoundStartEvent ev)
        {
            roundStarted = true;
        }

        void IEventHandlerSetRole.OnSetRole(PlayerSetRoleEvent ev)
        {
            if (roundStarted && ev.Role == Role.CHAOS_INSUGENCY)
            {
                ev.Player.ChangeRole(Role.NTF_COMMANDER);
            }
            else if (ev.Role == Role.SPECTATOR || players.Contains(ev.Player.PlayerId))
            {
                return;
            }
            else if (!players.Contains(ev.Player.PlayerId))
            {
                plugin.Info("Spawning player " + ev.Player.Name);
                if (!oneSevenThreeSpawned)
                {
                    players.Add(ev.Player.PlayerId);
                    oneSevenThreeSpawned = true;
                    ev.Player.ChangeRole(Role.SCP_173);
                }
                else
                {
                    players.Add(ev.Player.PlayerId);
                    ev.Player.ChangeRole(Role.CLASSD);
                }
            }
        }
    }
}