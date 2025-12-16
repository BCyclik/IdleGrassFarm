using UnityEngine;

public class Upgrader_Sickle : Upgrader 
{
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