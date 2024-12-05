using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_FoodManager : MonoBehaviour
{
    public static Temp_FoodManager Instance { get; private set; }

    // 모든 Food ScriptableObject를 저장할 리스트
    public List<Food> foodList = new List<Food>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadAllFoods();
    }

    // Food 리스트를 불러오는 메서드
    private void LoadAllFoods()
    {
        // "Foods" 폴더에서 모든 Food ScriptableObject를 로드
        Food[] foods = Resources.LoadAll<Food>("InGameFood");
        foodList.AddRange(foods);
    }

    // 전체 메뉴 리스트 가져오기
    public List<Food> GetAllFoods()
    {
        return new List<Food>(foodList);
    }
}

