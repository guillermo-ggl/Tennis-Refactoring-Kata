namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (EqualScore())
            {
                score = GetScoreForEqualScore(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                score=GetScoreNameForThreeOrLess(m_score1)
                    +"-"
                    +GetScoreNameForThreeOrLess(m_score2);
            }
            return score;
        }

        private string GetScoreForEqualScore(int tempScore)
        {
            if (tempScore > 2) return "Deuce";
            
            return GetScoreNameForTwoOrLess(tempScore) + "-All";
        }

        private bool EqualScore()
        {
            return m_score1 == m_score2;
        }

        private static string GetScoreNameForThreeOrLess(int score)
        {
            if (score == 3) return "Forty";

            return GetScoreNameForTwoOrLess(score);
        }
        
        private static string GetScoreNameForTwoOrLess(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
            }

            return "";
        }
    }
}

