using UnityEngine;
using UnityEngine.Events;

public class EventLaunch : MonoBehaviour
{
    // このbool変数がtrueのときのみ、イベントをチェック
    private bool isPlayerColliding = false;

    // イベント発生時に実行したい処理をInspectorから登録するためのUnityEvent
    public UnityEvent OnInteraction;

    // プレイヤーがトリガーに侵入したとき
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーのタグをチェックして、プレイヤーが接触したことを記録
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = true;
            // Debug.Log("approched");
        }
    }

    // プレイヤーがトリガーから出たとき
    private void OnCollisionExit2D(Collision2D collision)
    {
        // プレイヤーのタグをチェックして、プレイヤーが接触していないことを記録
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = false;
            // Debug.Log("distant");
        }
    }

    void Update()
    {
        // プレイヤーが接触中で、かつスペースキーが押されたとき、かつプレイヤーが操作可能
        if (isPlayerColliding && Input.GetKeyDown(KeyCode.Space) && GameRoot.I.isActive_Move == true)
        {
            GameRoot.I.isEvent = true;
            GameRoot.I.eventCount[0]++;     // 総イベント実行回数を1増加

            // UnityEventに登録されたすべてのメソッドを実行
            OnInteraction?.Invoke();
        }
        
    }
}
