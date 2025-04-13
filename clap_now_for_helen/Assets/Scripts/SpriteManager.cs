using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;
    public Image[] images;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        //Invoke("Test", 2);

    }

    void Test()
    {
        ChangeSprite("Helen", "helenAnnoyed");
    }

    public void ChangeSprite(string imageName, Sprite newSprite)
    {
        Image image = Array.Find(images, image => image.name == imageName);
        image.sprite = newSprite;
    }

    public void ChangeSprite(string imageName, string spriteFileName)
    {
        var sprite = Resources.Load<Sprite>(spriteFileName);
        ChangeSprite(imageName, sprite);
    }

    public void ChangeSprites(string imageName, string[] spriteFileNames)
    {
        foreach (var spriteFileName in spriteFileNames)
            ChangeSprite(imageName, spriteFileName);
    }
}
