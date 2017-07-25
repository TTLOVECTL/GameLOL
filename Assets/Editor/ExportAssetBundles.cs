using System.Collections;
using UnityEngine;
using UnityEditor;
using InscriptionSystem;

public class ExportAssetBundles : MonoBehaviour
{
    [MenuItem("Assets/Build AssetBundle From Selection %E")]
    static void ExportResource()
    {
        string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "assetbundle");

        if (path.Length != 0)
        {
            // 选择的要保存的对象
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            //打包
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.StandaloneWindows);
        }
    }

    [MenuItem("Assetbundles/Create Assetbundles %Q")]
    public static void ExcuteBuild()
    {

        //BookElementHolder holder = ScriptableObject.CreateInstance<BookElementHolder>();
        InscriptionHolder holder = ScriptableObject.CreateInstance<InscriptionHolder>();
        holder.inscription = ExcelReader.IninInscription("Inscription.xlsx");        
        string path = "Assets/Assets/Inscription.asset";
        //string path = "Assets/QQ.asset";
        AssetDatabase.CreateAsset(holder, path);
    }
}