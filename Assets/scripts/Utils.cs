using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{
    public static string getSeparatedNumberStr(double num)
    {

        string numStr = num.ToString();
        if (numStr.Length > 3)
        {
            string tempTxt = "";
            int c = 0;
            for (int i = numStr.Length - 1; i >= 0; i--)
            {

                if (c%3 == 0)
                {
                    tempTxt = numStr[i] + " " + tempTxt;
                   // Debug.Log("c=3");
                }
                else tempTxt = numStr[i] + tempTxt;
                c++;
            }
            return tempTxt;
        }

        return num.ToString();
    }

    public static bool isCoinsSufficient(string priceTxt)
    {
        int savedCoins = getCurrentCoins();
        Debug.Log("utl: savedddd ="+ savedCoins);
        Debug.Log("utl: price txt =" + priceTxt);
        int price = int.Parse(priceTxt.Replace(" ", ""));
        int restCoins = savedCoins - price;

        if (restCoins < 0)
        { // Coins not sufficient 
            return false;

        }
        return true;
    }
    public static bool isGemsSufficient(string gemsTxt)
    {
        int savedGems = getCurrentGems();
       
        int gems = int.Parse(gemsTxt.Replace(" ", ""));
        int restCoins = savedGems - gems;

        if (restCoins < 0)
        { // Coins not sufficient 
            return false;

        }
        return true;
    }
    public  static int getCurrentCoins()
    {
        if (SaveSystem.LoadPlayer() != null)
        {
            return SaveSystem.LoadPlayer().coins;
        }
        return 0;
    }

    public static int getCurrentGems()
    {
        if (SaveSystem.LoadPlayer() != null)
        {
            return SaveSystem.LoadPlayer().GEMS;
        }
        return 0;
    }

    public static void decreaseCoins(int amount)
    {
        int coins = getCurrentCoins();
        PlayerData playerData = SaveSystem.LoadPlayer();

       if(amount<=coins) playerData.coins = coins-amount;

       SaveSystem.savePlayer(playerData);
    }

    public static void decreaseGems(int amount)
    {
        int gems = getCurrentGems();
        PlayerData playerData = SaveSystem.LoadPlayer();

        if (amount <= gems) playerData.GEMS = gems - amount;

        SaveSystem.savePlayer(playerData);
    }

    public static void increaseCoins(int amount)
    {
        int coins = getCurrentCoins();
        PlayerData playerData = SaveSystem.LoadPlayer();

         playerData.coins = coins + amount;

        SaveSystem.savePlayer(playerData);
    }
    public static void increaseGemss(int amount)
    {
        int gems = getCurrentGems();
        PlayerData playerData = SaveSystem.LoadPlayer();

         playerData.GEMS = gems + amount;

        SaveSystem.savePlayer(playerData);
    }

    public static void ShowScaleObj(GameObject obj)
    {
        obj.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(obj, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutElastic);

    }
}
