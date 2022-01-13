using UnityEngine;

[CreateAssetMenu(fileName ="ChestScriptableObject",menuName = "ScriptableObjects/NewChestScriptableObject")]
public class ChestScriptableObject : ScriptableObject
{
    public ChestType chestType;
    public int minCoins;
    public int maxCoins;
    public int minGems;
    public int maxGems;
    public int UnlockTime;
}

