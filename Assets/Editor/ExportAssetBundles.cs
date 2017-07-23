using System.Collections;
using UnityEngine;
using UnityEditor;
using InscriptionSystem;
using EquipmentSystem;

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

        //InscriptionHolder holder = ScriptableObject.CreateInstance<InscriptionHolder>();
        //holder.inscription = ExcelReader.IninInscription("Inscription.xlsx");        
        //string path = "Assets/Assets/Inscription.asset";
        EquipmentHolder holder = ScriptableObject.CreateInstance<EquipmentHolder>();
        //holder.equipemntList = ExcelReader.InitEquiment("Equipment.xlsx");
        holder.equipmentLeaf = new System.Collections.Generic.List<EquipmentLeaf>();
        holder.equipmentComponent = new System.Collections.Generic.List<EquipmentComponent>();
        foreach (BaseEquipment ba in ExcelReader.InitEquiment("Equipment.xlsx")) {
            if (ba.equipmentType == EqunipmentType.SMALL)
            {
                holder.equipmentLeaf.Add((EquipmentLeaf)ba);
            }
            else {
                holder.equipmentComponent.Add((EquipmentComponent)ba);
            }
        }
        string path = "Assets/Assets/Equipment.asset";
        AssetDatabase.CreateAsset(holder, path);
    }
}