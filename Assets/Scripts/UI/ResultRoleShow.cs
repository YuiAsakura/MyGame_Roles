using UnityEngine;
using TMPro;

public class ResultRoleShow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ResultRole;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 役職名を表示する
        ResultRole.text = $"xxx> your role is [ {GameRoot.I.ThisRole} ]";
    }
}
