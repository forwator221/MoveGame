using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 PlayerPos;

    public int CurrentLevel;
    public int MaxLevel;

    public GameData()
    {
        PlayerPos = new Vector3(-7.5f, 0.75f, -25.5f);
    }
}

