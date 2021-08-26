using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class DefaultFood : MonoBehaviour, IFood
    {
        public int ScoreAmount { get; }
        public FoodType FoodType { get; }

        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}
