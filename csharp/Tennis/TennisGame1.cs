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
            if (EqualScore()) return GetScoreForEqualScore(m_score1);
            
            if (SomePlayerOverThreePoints()) return ScoreNameWithSomePLayerOverThree(m_score1, m_score2);
            
            return GetScoreNameForThreeOrLess(m_score1)
                +"-"
                +GetScoreNameForThreeOrLess(m_score2);
        }

        private bool SomePlayerOverThreePoints()
        {
            return m_score1 >= 4 || m_score2 >= 4;
        }

        private string ScoreNameWithSomePLayerOverThree(int player1Score, int player2Score)
        {
            var minusResult = player1Score - player2Score;
            if (minusResult == 1) return "Advantage player1";
            if (minusResult == -1) return "Advantage player2";
            if (minusResult >= 2) return "Win for player1";
            return "Win for player2";
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
            if (score == 0) return "Love";
            if (score == 1) return "Fifteen";
            return "Thirty";
        }
    }
}

