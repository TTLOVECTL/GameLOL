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
        //string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "asset");

        BookElementHolder holder = ScriptableObject.CreateInstance<BookElementHolder>();
        //holder.attribute = ExcelReader.InitAttrtibute("Attribute.xlsx");
        holder.inscription = ExcelReader.IninInscription("Inscription.xlsx");
        
        //InscriptionFactory.Instance.inscription;
        //foreach (Inscription ip in holder.inscription) {
        //    Debug.Log(ip.inscriptionAttribute.Count);
        //}        
        string path = "Assets/QQ.asset";
        AssetDatabase.CreateAsset(holder, path);
    }
}