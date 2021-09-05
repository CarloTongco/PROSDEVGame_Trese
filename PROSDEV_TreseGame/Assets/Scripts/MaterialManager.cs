using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    #region Singleton

    public static MaterialManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Material[] materials;
}
