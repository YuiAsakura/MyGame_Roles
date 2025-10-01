using UnityEngine;
using System.Collections;

public class StartEvent : MonoBehaviour
{
    private IEnumerator Start()
    {
        string[] storyMessages = new string[] {
            "操作方法",
            "AWSDで移動",
            "スペースで決定"
        };
        yield return StartCoroutine(MessageSystem.I.ShowMessages(storyMessages));
    }
}
