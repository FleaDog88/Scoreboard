using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreboardAccessor.Contracts
{
    public class GameStatus
    {
        public TeamInfo HomeTeam { get; set; }

        public TeamInfo VisitorTeam { get; set; }
    }
}
