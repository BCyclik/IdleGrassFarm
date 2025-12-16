using UnityEngine;

public class Upgrader_Sickle : Upgrader 
{    
    protected override int GetCostRed(Player player)
    {
        int level = player.character.sickle.Level;

        return DataBase.RedCoinSickleLevelUpCost * level;
    }

    protected override int GetCostYellow(Player player)
    {
        int level = player.character.sickle.Level;

        return DataBase.YellowCoinSickleLevelUpCost * level;
    }
    protected override bool IsCurrency(Player player)
    {
        int level = player.character.sickle.Level;

        bool value = player.RedCoins >= DataBase.RedCoinSickleLevelUpCost * level && 
                    player.YellowCoins >= DataBase.YellowCoinSickleLevelUpCost * level;

        return value;
    }
    protected override void Upgrade(Player player)
    {
        int level = player.character.sickle.Level;

        player.RedCoins -= DataBase.RedCoinSickleLevelUpCost * level;
        player.YellowCoins -= DataBase.YellowCoinSickleLevelUpCost * level;

        player.character.sickle.LevelUp(Gain);

        Debug.Log($"[Upgrader_Sickle] Upgrade({player.character.sickle.Level})");
    }
}