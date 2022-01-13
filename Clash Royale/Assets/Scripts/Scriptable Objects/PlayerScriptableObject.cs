using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/NewPlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    public int coins;
    public int gems;
}
