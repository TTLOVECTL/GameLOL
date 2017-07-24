using System.Collections;
using UnityEditor;
using UnityEngine;
public class MyEditorChangeToSprite : AssetPostprocessor
{
    //纹理导入之前调用，针对入到的纹理进行设置  
    public void OnPreprocessTexture()
    {
        TextureImporter impor = this.assetImporter as TextureImporter;
        impor.textureType = TextureImporterType.Sprite;
        impor.mipmapEnabled = false;

    }
    public void OnPostprocessTexture(Texture2D tex)
    {
        //Debug.Log("OnPostProcessTexture=" + this.assetPath);
    }


}