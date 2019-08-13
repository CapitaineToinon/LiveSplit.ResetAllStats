using LiveSplit.ResetAllStats;
using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;

[assembly: ComponentFactory(typeof(RASFactory))]
namespace LiveSplit.ResetAllStats
{
    internal class RASFactory : IComponentFactory
    {
        public string ComponentName => "Reset All Stats for a specific steam game";
        public string Description => "Reset All Stats for a specific steam game by CapitaineToinon";
        public string UpdateName => ComponentName;

        public ComponentCategory Category => ComponentCategory.Other;
        public string UpdateURL => "https://raw.githubusercontent.com/CapitaineToinon/LiveSplit.ResetAllStats/master/LiveSplit.ResetAllStats/";
        public string XMLURL => UpdateURL + "Components/update.LiveSplit.ResetAllStats.xml";

        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public IComponent Create(LiveSplitState state)
        {
            return new RASComponent(state);
        }
    }
}