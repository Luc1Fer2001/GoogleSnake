using SmartValues;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 5)]
public class PlayerData : ScriptableObject
{
    [SerializeField] private XPToLevel _xpToLevel;
    public SavedIntValue Xp { get; private set; }
    public DependentIntValue Level { get; private set; }

    private void Awake()
    {
        Xp = new SavedIntValue("Xp");
        Level = new DependentIntValue(_xpToLevel.LevelsList, Xp);
    }
}
