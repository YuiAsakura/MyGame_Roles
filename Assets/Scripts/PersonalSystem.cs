using UnityEngine;

public class PersonalSystem : MonoBehaviour
{
    private TimeCounter timeCounter;

    // 個性値
    public int seeking;     // 探求力
    public int decision;    // 決断力
    public int sensitive;   // 感受力
    public int patience;    // 忍耐力
    public int insight;     // 洞察力

    private void Start()
    {
        Initialize();

        // シーン内のTimeCounterコンポーネントを探して取得する
        timeCounter = FindObjectOfType<TimeCounter>();
        if (timeCounter != null)
        {
            // TimeCounterのOnTimeUpイベントにSeekRole()メソッドを登録する
            timeCounter.OnTimeUp += SeekRole;
        }
    }

    void Update()
    {

    }

    private void Initialize()
    {
        // 個性値を初期化
        seeking = 0; decision = 0; sensitive = 0; patience = 0; insight = 0;
    }

    private void SeekRole()
    {
        Debug.Log("Set Role");
        GameRoot.I.ThisRole = "Player";
    }
}
