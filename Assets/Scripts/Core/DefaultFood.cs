using UnityEngine;

public class DefaultFood : MonoBehaviour, IFood
{
    public int scoreAmount { get; }

    public void Collect()
    {
        Destroy(gameObject);
    }
}
