using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent (typeof(TextMeshProUGUI))]
public class TextMeshProTextData : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }


    public void UpdateTheGUIText(string textToUpdate)
    {
        _textMeshProUGUI.text = textToUpdate;
    }

}
