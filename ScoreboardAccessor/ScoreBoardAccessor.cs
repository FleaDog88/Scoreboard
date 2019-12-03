using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ScoreboardAccessor
{
    public class ScoreBoardAccessor
    {
        public ScoreBoardAccessor(ScoreBoardDisplay score)
        {
            Score = score;
        }

        public ScoreBoardDisplay Score { get; set; }

        public ScoreBoardDisplay GetScoreBoardDisplay()
        {
            return Score;
        }

        public ScoreBoardDisplay AddHomeScore()
        {
            Score.HomeScore += 1;
            return Score;
        }
        public ScoreBoardDisplay AddVisitorScore()
        {
            Score.VisitorScore += 1;
            return Score;
        }

        public ScoreBoardDisplay EditHomeTeam(string TeamName)
        {
            Score.HomeTeam = TeamName;
            return Score;
        }

        public ScoreBoardDisplay EditVisitorTeam(string TeamName)
        {
            Score.VisitorTeam = TeamName;
            return Score;
        }

    }
}
