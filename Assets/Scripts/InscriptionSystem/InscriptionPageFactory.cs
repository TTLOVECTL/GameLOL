using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 生产符文页的工厂
/// </summary>
public class InscriptionPageFactory  {

    private static InscriptionPageFactory instance = null;

    private InscriptionPageFactory() {
    }

    public static InscriptionPageFactory Instance {
        get {
            if (instance == null) {
                instance = new InscriptionPageFactory();
            }
            return instance;
        }
    }
}
