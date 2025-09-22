using UnityEngine;

public class PersonalSystem : MonoBehaviour
{
    // 個性値
    public int seeking;     // 探求力
    public int decision;    // 決断力
    public int sensitive;   // 感受力
    public int patience;    // 忍耐力
    public int insight;     // 洞察力

    void Start()
    {
        Initialize();
    }

    void Update()
    {

    }

    private void Initialize()
    {
        // 個性値を初期化
        seeking = 0; decision = 0; sensitive = 0; patience = 0; insight = 0;
    }
}
