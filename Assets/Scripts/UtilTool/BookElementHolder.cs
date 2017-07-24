using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InscriptionSystem;

[System.Serializable]
public class BookElementHolder : ScriptableObject {
    public int a = 1;
    public List<Inscription> inscription;
}
