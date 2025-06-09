using UnityEngine;

public class GameManager : Manager<GameManager>
{
    [SerializeField]
    [Header("ゲームのフレームレート")]
    int gameFrameRate = 120;
    [SerializeField]
    [Header("プレイヤーのゲームオブジェクト")]
    GameObject player;
    private void Awake()
    {
        Init();
    }
    public override void Init()
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
