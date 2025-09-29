using UnityEngine;

// Event一覧を管理するスクリプト
// EventLaunchをアタッチした各オブジェクトに設定した関数が呼び出される
public class EventList : MonoBehaviour
{
    public MessageSystem messageSystem;

    private string[] eventMassage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ev01bench()
    {
        Debug.Log("event 01 bench");
        eventMassage = new string[] {
            "SHOW_YESNO_OPTIONS_HERE",
            "ベンチで休みますか？\n時間を消費します",
            "OK",
        };
        messageSystem.ShowMessages(eventMassage);
        GameRoot.I.isEvent = false;
    }
}
