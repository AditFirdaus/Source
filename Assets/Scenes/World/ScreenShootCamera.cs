using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShootCamera : MonoBehaviour
{
    public static ScreenShootCamera instance;
    public Camera screenshootCamera;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static IEnumerator TakeScreenShoot(string name)
    {
        yield return new WaitForEndOfFrame();
        instance.screenshootCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        instance.screenshootCamera.Render();
        RenderTexture temp = instance.screenshootCamera.targetTexture;
        instance.screenshootCamera.targetTexture = null;

        Texture2D texture = new Texture2D(temp.width, temp.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, temp.width, temp.height), 0, 0);
        texture.Apply();

        Debug.Log(texture);

        var bytes = texture.EncodeToPNG();
        Destroy(texture);

        var path = Application.persistentDataPath + $"/Resources/ScreenShoots/{name}.png";

        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }

        System.IO.File.WriteAllBytes(path, bytes);
    }

    public static Sprite GetScreenShoot(string name)
    {
        Sprite sprite = Resources.Load<Sprite>($"ScreenShoots/{name}");
        Debug.Log(sprite);
        return sprite;
    }
}
