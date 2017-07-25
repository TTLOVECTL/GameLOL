using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InscriptionHolder : ScriptableObject
{
    public  string description = "存储所有的符文信息"; 
    public List<InscriptionSystem.Inscription> inscription;
}
