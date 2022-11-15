using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    TMP_Text text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UIz
        text.text = $"Score {Gamemanager.score}";
    }
}
