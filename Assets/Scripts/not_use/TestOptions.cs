using UnityEngine;

public class TestOptions : MonoBehaviour
{
    public Options options;

    void Start()
    {
        options.SelectOption();
        //Debug.Log($"selected:{GameRoot.I.selected}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
