using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCombi : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform skin;
    public Transform skeleton;
    public BoneData boneData;
    public RuntimeAnimatorController controller;

    private SkinnedMeshRenderer skinMesh;
    void Start()
    {
        skinMesh = skin.GetComponent<SkinnedMeshRenderer>();
        Combination();

        skeleton.GetComponent<Animator>().runtimeAnimatorController = controller;
    }

    private void Combination()
    {
        Transform[] childs = skeleton.GetComponentsInChildren<Transform>();
        List<Transform> boones = new List<Transform>();

        Dictionary<string, Transform> boneDir = new Dictionary<string, Transform>();
       // Hashtable boneDir = new Hashtable();
        foreach(var item in childs)
        {

            boneDir.Add(item.name, item);

            if (item.name == boneData.rootBoneName)
                skinMesh.rootBone = item;
       
        }

        for(int i = 0;i< boneData.boneNames.Length;i++)
        {
            string boneName = boneData.boneNames[i];

            Transform bone = null;
            if(boneDir.TryGetValue(boneName,out bone))
            {
                boones.Add(bone);
            }
        }

        skinMesh.bones = boones.ToArray();
    }
}
