
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
public class CommonMenu
{
    [MenuItem("Assets/提取皮肤和骨骼名字", false, 500)]
    static void CreateAvatarBoneData()
    {
        if (Selection.activeGameObject != null)
        {
            CreateXAvatarBoneData(Selection.activeGameObject);
        }
    }

    static void CreateXAvatarBoneData(GameObject seleObj)
    {   
        string goPath = AssetDatabase.GetAssetPath(seleObj);
        string outPath = Path.GetDirectoryName(goPath) + "/" + Path.GetFileNameWithoutExtension(goPath);

        SkinnedMeshRenderer skinMesh = seleObj.GetComponentInChildren<SkinnedMeshRenderer>();

        BoneData boneData = ScriptableObject.CreateInstance<BoneData>();

        boneData.rootBoneName = skinMesh.rootBone.name;
        List<string> bones = new List<string>();
        for(var i = 0;i< skinMesh.bones.Length;i++)
        {
            bones.Add(skinMesh.bones[i].name);
        }
        boneData.boneNames = bones.ToArray();

        AssetDatabase.CreateAsset(boneData, outPath +"_gutou.asset");

        //输出蒙皮和骨骼
        GameObject obj = GameObject.Instantiate(skinMesh.gameObject);
        SkinnedMeshRenderer nmesh = obj.GetComponent<SkinnedMeshRenderer>();
        nmesh.rootBone = null;
        nmesh.bones = null;
        obj.name = "mengpi_skin";
        PrefabUtility.SaveAsPrefabAsset(obj, outPath + "_pifu.prefab");
        GameObject.DestroyImmediate(obj);

    }
}
