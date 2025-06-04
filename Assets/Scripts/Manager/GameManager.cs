using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    [Header("ゲームのフレームレート")]
    int gameFrameRate = 120;
    [SerializeField]
    [Header("プレイヤーのゲームオブジェクト")]
    GameObject player;
    private void Awake()
    {
        instance = this;
        Init();
    }
    void Init()
    {
        Application.targetFrameRate = gameFrameRate;
    }
    public GameObject GetPlayer()
    {
        return player;
    }
    void Update()
    {
        
    }
}
