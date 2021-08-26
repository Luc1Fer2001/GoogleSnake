using Assets.Scripts.Enums;

public interface IFood
{
    int ScoreAmount { get; }
    FoodType FoodType { get; }
    void Collect();

}
