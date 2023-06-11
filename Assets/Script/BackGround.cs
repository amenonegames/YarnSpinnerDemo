using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class BackGround: MonoBehaviour
{
    [SerializeField]
    private Image _image;
    
    [YarnCommand("ChangeBackground")]
    public void ChangeImage(string spriteName)
    {
        var sprite = Resources.Load<Sprite>(spriteName);
        if (sprite == null)
        {
            Debug.LogError($"Sprite {spriteName} not found");
            return;
        }
        
        _image.sprite = sprite;

    }           
}