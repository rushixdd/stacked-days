namespace ProblemSolvingCSharp.Gemini;

[TestClass]
public class HighScoreLeaderboard
{
    public class LeaderBoard
    {
        SortedDictionary<string, int> playerScore = new SortedDictionary<string, int>();

        public void AddScore(string playerName, int score)
        {
            if (playerScore.ContainsKey(playerName))
            {
                if (playerScore[playerName] < score)
                {
                    playerScore[playerName] = score;
                }
            }
            else
            {
                playerScore.Add(playerName, score);
            }
        }

        public List<string> GetTopPlayers(int count)
        {
            var playerList = new List<KeyValuePair<string, int>>(playerScore);

            playerList.Sort((pair1, pair2) =>
            {
                int scoreComparison = pair2.Value.CompareTo(pair1.Value);

                if (scoreComparison != 0)
                {
                    return scoreComparison;
                }

                return pair1.Key.CompareTo(pair2.Key);
            });

            var topPlayers = new List<string>();
            for (int i = 0; i < count && i < playerList.Count; i++)
            {
                topPlayers.Add(playerList[i].Key);
            }

            return topPlayers;
        }
    }

    [TestMethod]
    public void Test1()
    {
        var board = new LeaderBoard();
        board.AddScore("Alice", 90);
        board.AddScore("Bob", 85);
        board.AddScore("Charlie", 95);
        board.AddScore("Dave", 80);
        board.AddScore("Eve", 70);
        board.AddScore("Frank", 99);
        board.AddScore("Alice", 100);

        var topPlayers = board.GetTopPlayers(3);

        CollectionAssert.AreEqual(new List<string> { "Alice", "Frank", "Charlie" }, topPlayers);
    }
}
