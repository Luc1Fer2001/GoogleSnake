using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "XPToLevel", menuName = "ScriptableObjects/XPToLevel", order = 6)]
    public class XPToLevel : ScriptableObject
    {
        [SerializeField] private PlayerData _playerData;

        [SerializeField]
        public List<XPToLevelTable> XPToLevelTables { get; } = new List<XPToLevelTable>();

        public static System.Action<int> OnLevelChanged;

        private int _level;
        public int Level
        {
            get => _level;
            private set
            {
                _level = value;
                OnLevelChanged?.Invoke(value);
            }
        }

        private List<int> _levelsList;

        public List<int> LevelsList
        {
            get
            {
                foreach (var level in XPToLevelTables)
                {
                    _levelsList.Add(level.Level);
                }
                return _levelsList;
            }
        }

        private void Awake()
        {
            _playerData.Xp.OnValueUpdate += SetLevel;
        }

        private void SetLevel(int xp)
        {
            int level = 0;
            for (int i = 0; i < XPToLevelTables.Count; i++)
            {
                if (xp >= XPToLevelTables[i].Xp)
                {
                    level = i;
                }
            }
            Level = level;
        }
    }

    [System.Serializable]
    public class XPToLevelTable
    {
        public int Level;
        public int Xp;
    }
}