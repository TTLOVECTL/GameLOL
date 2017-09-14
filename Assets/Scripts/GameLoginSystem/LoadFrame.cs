using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing.Imaging;
using System.Drawing;

public class LoadFrame : MonoBehaviour {

    //public string loadingGifPath;

    public List<Texture2D> gifFrames = new List<Texture2D>();
	// Use this for initialization
    void Start()
    {
        string path = Application.streamingAssetsPath + "/load.gif";
        var gifImage = Image.FromFile(path);
        var dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
        int frameCount = gifImage.GetFrameCount(dimension);
        for (int i = 0; i < frameCount; i++)
        {
            gifImage.SelectActiveFrame(dimension, i);
            var frame = new Bitmap(gifImage.Width, gifImage.Height);
            System.Drawing.Graphics.FromImage(frame).DrawImage(gifImage, Point.Empty);
            var frameTexture = new Texture2D(frame.Width, frame.Height);
            for (int x = 0; x < frame.Width; x++)
                for (int y = 0; y < frame.Height; y++)
                {
                    System.Drawing.Color sourceColor = frame.GetPixel(x, y);
                    frameTexture.SetPixel(frame.Width - 1 - x, y, new Color32(sourceColor.R, sourceColor.G, sourceColor.B, sourceColor.A)); // for some reason, x is flipped
                }
            frameTexture.Apply();
            gifFrames.Add(frameTexture);
            float scale = (float)Screen.height / 400;
            GetComponent<RectTransform>().localScale = new Vector2(scale, scale);
        }
    }

    private static string GetPlatformPath(string flodername, string filename)
    {
        string filePath =
#if UNITY_ANDROID && !UNITY_EDITOR
        "jar:file://" + Application.dataPath + "!/assets/" + flodername + "/";  
#elif UNITY_IPHONE && !UNITY_EDITOR
        Application.dataPath + "/Raw/";  
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR
 "file://" + Application.dataPath + "/StreamingAssets" + "/" + flodername + "/";
#else
        string.Empty;
#endif

        return filePath += filename;
    }
}
