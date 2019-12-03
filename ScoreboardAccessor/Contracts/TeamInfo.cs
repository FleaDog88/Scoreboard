using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreboardAccessor.Contracts
{
    public class TeamInfo
    {
        public string TeamName { get; set; }

        public int Score { get; set; }

        public int Timeouts { get; set; }

        public List<string> Roster { get; set; }
    }
}
