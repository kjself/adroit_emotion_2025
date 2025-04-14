using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;
    public Image[] images;

    public Sprite[] sprites;
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
    public void ChangeSprite(string imageName, string newSpriteName)
    {
        print("Sprite trying to change to: " + newSpriteName);
        print(sprites);

        Sprite sprite = null;
        foreach (Sprite s in sprites)
        {
            if (s.name == newSpriteName)
            {
                sprite = s;
            }
        }
        //Sprite sprite = Array.Find(sprites, sprite => sprite.name == newSpriteName);
        if(sprite != null)
        {
            ChangeSprite(imageName, sprite);
        }
    }

    //public void ChangeSprite(string imageName, string spriteFileName)
    //{
    //    var sprite = Resources.Load<Sprite>(spriteFileName);
    //    ChangeSprite(imageName, sprite);
    //}

    public void ChangeSprites(string imageName, string[] spriteFileNames)
    {
        foreach (var spriteFileName in spriteFileNames)
            ChangeSprite(imageName, spriteFileName);
    }
}
