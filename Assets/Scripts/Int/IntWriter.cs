using TMPro;
using UnityEngine;

public class IntWriter : MonoBehaviour
{
    TextMeshProUGUI _text;

    private void Awake() {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void Write(int value){
        _text.text = value.ToString();
    }
}
