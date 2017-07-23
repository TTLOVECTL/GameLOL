using UnityEditor;

public class ChangeToSprite : AssetPostprocessor
{
    private static bool isRun = false;
    private const string path = "UGUI Tools/Import With Sprite";

    [MenuItem(path)]
    static void DoSprite()
    {
        bool flag = Menu.GetChecked(path);
        isRun = !flag;
        Menu.SetChecked(path, !flag);    
    }

    //纹理导入之前调用，针对导入的纹理进行设置
    public void OnPreprocessTexture()
    {
        if (isRun)
        {
            TextureImporter impor = this.assetImporter as TextureImporter;
            impor.textureType = TextureImporterType.Sprite;
            impor.spriteImportMode = SpriteImportMode.Single;
            impor.mipmapEnabled = false;
            
        }

    }


}