using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    public static Managers Instance { get { Init(); return s_instance; } }

    // Each Managers
    InventoryManager _inventory = new InventoryManager();
    InGameManager _ingame = new InGameManager();
    MarketManager _market = new MarketManager();
    public static InventoryManager Inventory { get { return Instance._inventory; } }
    public static InGameManager InGame { get { return Instance._ingame; } }
    public static MarketManager Market { get { return Instance._market; } }

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
        s_instance._inventory.Init("NewGame");
        s_instance._market.Init();
    }
}
