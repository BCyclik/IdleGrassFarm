using UnityEngine;

public class Upgrader_Inventory : Upgrader 
{
    protected override bool IsCurrency(Player player)
    {
        int level = player.character.inventory.Level;

        bool value = player.RedCoins >= DataBase.RedCoinInventoryLevelUpCost * level && 
                    player.YellowCoins >= DataBase.YellowCoinInventoryLevelUpCost * level;

        return value;
    }
    protected override void Upgrade(Player player)
    {
        int level = player.character.inventory.Level;

        player.RedCoins -= DataBase.RedCoinInventoryLevelUpCost * level;
        player.YellowCoins -= DataBase.YellowCoinInventoryLevelUpCost * level;

        player.character.inventory.LevelUp(Gain);

        Debug.Log($"[Upgrader_Inventory] Upgrade({player.character.inventory.Level})");
    }
}