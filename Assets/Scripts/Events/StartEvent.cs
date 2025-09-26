using UnityEngine;

public class StartEvent : MonoBehaviour
{
    public MessageSystem messageSystem;

    void Start()
    {
        string[] storyMessages = new string[] {
            "操作方法",
            "AWSDで移動",
            "スペースで決定"
        };
        messageSystem.ShowMessages(storyMessages);
    }
}
