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
    InventoryManager _inventory = new InventoryManager();
    InGameManager _ingame = new InGameManager();
    public static UIManager UI { get { return Instance._ui; } }
    public static InventoryManager Inventory { get { return Instance._inventory; } }
    public static InGameManager InGame { get { return Instance._ingame; } }

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

        // Debug: 게임 시작시 실행(원래는 NewGame/Load시 실행)
        // Inventory.Init("NewGame");
        s_instance._inventory.Init("NewGame");
    }
}
