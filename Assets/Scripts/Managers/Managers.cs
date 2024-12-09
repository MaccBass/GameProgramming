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
    StatusManager _status = new StatusManager();
    PrepareManager _prepare = new PrepareManager();
    InGameManager _ingame = new InGameManager();
    MarketManager _market = new MarketManager();
    public static InventoryManager Inventory { get { return Instance._inventory; } }
    public static StatusManager Status { get { return Instance._status; } }
    public static PrepareManager Prepare { get { return Instance._prepare; } }
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
    }
}
