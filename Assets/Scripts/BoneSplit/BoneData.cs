using UnityEngine;
using System.Collections;

public class BoneData : ScriptableObject
{
    [SerializeField]
    public string rootBoneName;
    [SerializeField]
    public string[] boneNames;
}
