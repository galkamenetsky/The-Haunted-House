using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteFromAtlas : MonoBehaviour
{
    [SerializeField] private SpriteAtlas spriteAtlas;
    [SerializeField] private string spriteName;
    void Start()
    {
        GetComponent<Image>().sprite = spriteAtlas.GetSprite(spriteName);
    }
}
