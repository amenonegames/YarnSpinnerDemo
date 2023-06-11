using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class Enemy: MonoBehaviour
{
    [SerializeField]
    private Image _image;
    
    [YarnCommand("ChangeImage")]
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
    
    
    [YarnCommand("Shake")]
    public IEnumerator Shake(float duration, float magnitude)
    {
        var originalPos =  transform.localPosition;
        var elapsed = 0f;
        while (elapsed < duration)
        {
            var x = Random.Range(-1f, 1f) * magnitude;
            var y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}