using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSetter : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField]SpriteRenderer renderer;

    private void Update()
    {
        image.sprite = renderer.sprite;
    }
}
