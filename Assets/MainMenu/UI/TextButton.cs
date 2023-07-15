using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text buttonText;
    public string Text { set => this.buttonText.text = value; }
    public void AddListener(UnityAction unityAction) => button.onClick.AddListener(unityAction);
}
