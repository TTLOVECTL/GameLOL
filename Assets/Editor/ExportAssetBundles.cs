using System.Collections;
using UnityEngine;
using UnityEditor;

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


        //string path=EditorUtility.SaveFolderPanel("Save Resource", "", "New Resource");
        //if (path.Length == 0)
        //{
        //    return; 
        //}

        //Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        //AssetBundleBuild[] buildMap = new AssetBundleBuild[1];

        //buildMap[0].assetBundleName = "classover";
        //string[] resourcesAssets = new string[selection.Length];
        //int count = 0;
        //foreach (Object s in selection)
        //{
        //    AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(s)).assetBundleName = buildMap[0].assetBundleName;
        //    resourcesAssets[count] = AssetDatabase.GetAssetPath(s);
        //    count++;
        //}
        //buildMap[0].assetNames = resourcesAssets;

        //BuildPipeline.BuildAssetBundles(path, buildMap, BuildAssetBundleOptions.AppendHashToAssetBundleName, BuildTarget.StandaloneWindows64);

    }

    [MenuItem("Assetbundles/Create Assetbundles %Q")]
    public static void ExcuteBuild()
    {
        //string path = EditorUtility.SaveFilePanel("Save Resource", "", "New Resource", "asset");

        BookElementHolder holder = ScriptableObject.CreateInstance<BookElementHolder>();
        holder.inscription = InscriptionFactory.Instance._inscription;
        Debug.Log(holder.inscription.Count);
        string path = "Assets/TT.asset";
        AssetDatabase.CreateAsset(holder, path);
    }

    //private string 
}