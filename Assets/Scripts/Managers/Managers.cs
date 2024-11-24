using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    public static Managers Instance { get { Init(); return s_instance; } }

    // Each Managers
    UIManager _ui = new UIManager();
    ItemManager _item = new ItemManager();
    public static UIManager UI { get { return Instance._ui; } }
    public static ItemManager Item { get { return Instance._item; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    static void Init()
    {
        GameObject go = GameObject.Find("@Managers");
        if (go == null)
        {
            go = new GameObject { name = "@Managers" };
            go.AddComponent<Managers>();
        }
        DontDestroyOnLoad(go);
        s_instance = go.GetComponent<Managers>();
    }
}
