using UnityEngine;

public class PersonalSystem : MonoBehaviour
{
    private TimeCounter timeCounter;

    // 個性値セット
    private int seeking;    // 探求力
    private int decision;   // 決断力
    private int sensitive;  // 感受力
    private int patience;   // 忍耐力
    private int insight;    // 洞察力

    private void Start()
    {
        //Initialize();

        // シーン内のTimeCounterコンポーネントを探して取得する
        timeCounter = FindObjectOfType<TimeCounter>();
        if (timeCounter != null)
        {
            // TimeCounterのOnTimeUpイベントにSeekRole()メソッドを登録する
            timeCounter.OnTimeUp += SeekRole;
        }
    }

    private void SetScores()
    {
        seeking = GameRoot.I.seeking;
        decision = GameRoot.I.decision;
        sensitive = GameRoot.I.sensitive;
        patience = GameRoot.I.patience;
        insight = GameRoot.I.insight;
    }

    /* GameRootで実装
    private void Initialize()
    {
        // 個性値を初期化
        seeking = 0; decision = 0; sensitive = 0; patience = 0; insight = 0;
    }
    */

    private void SeekRole()
    {
        SetScores();

        // 役職ごとのスコアを計算する
        // 役職に対応する個性値を組み合わせることで、特定のプレイスタイルを評価する
        int warriorScore = decision + seeking;
        int knightScore = patience + decision;
        int fighterScore = seeking + sensitive;
        int mageScore = insight + sensitive;
        int clericScore = patience + sensitive;

        Debug.Log($"scores: warrior{warriorScore} knight{knightScore} fighter{fighterScore} mage{mageScore} cleric{clericScore}");

        // 旅人はデフォルトの役職とするか、特定の条件でなるようにする
        int travelerScore = seeking;

        // 各役職のスコアを配列に格納
        int[] scores = new int[] { warriorScore, knightScore, fighterScore, mageScore, clericScore, travelerScore };

        // 最大スコアを決定
        int maxScore = 0;
        int maxIndex = -1;

        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] > maxScore)
            {
                maxScore = scores[i];
                maxIndex = i;
            }
        }

        // 役職を決定
        string role = "旅人(Traveler)"; // どの役職にも該当しない場合のデフォルト値

        if (maxIndex != -1)
        {
            switch (maxIndex)
            {
                case 0:
                    role = "戦士(Warrior)";
                    break;
                case 1:
                    role = "騎士(Knight)";
                    break;
                case 2:
                    role = "格闘家(Fighter)";
                    break;
                case 3:
                    role = "魔法使い(Mage)";
                    break;
                case 4:
                    role = "僧侶(Cleric)";
                    break;
                case 5:
                    // seekingが突出している場合、より積極的に旅人とする
                    if (seeking > patience && seeking > decision && seeking > sensitive && seeking > insight)
                    {
                        role = "旅人";
                    }
                    else
                    {
                        // スコアが同じ場合はランダム、またはデフォルト値に
                        // このサンプルではデフォルトの「旅人」を返す
                        role = "旅人";
                    }
                    break;
            }
        }

        GameRoot.I.ThisRole = role;
    }
}
