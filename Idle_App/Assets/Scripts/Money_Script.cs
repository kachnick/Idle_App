using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Money_Script : MonoBehaviour
{
    //Money
    public Text MoneyText;
    public double money;

    //Money per second
    public Text MoneyPerSecText;
    public double moneypersecond;

    //quantity per purchase
    public Text QuantityText;
    public int quantity;
    public int qcounter;

    //coffee
    public Text CoffeeCostText;
    public Text CoffeeLevelText;
    public double coffeecost;
    public int coffeelevel;

    //burgers
    public Text BurgerCostText;
    public Text BurgerLevelText;
    public double burgercost;
    public int burgerlevel;

    //mowing
    public Text MowingCostText;
    public Text MowingLevelText;
    public double mowingcost;
    public int mowinglevel;

    public void Start(){
        money = 0;
        moneypersecond = 0;

        quantity = 1;
        qcounter = 0;

        coffeecost = 10;
        coffeelevel = 0;

        burgercost = 100;
        burgerlevel = 0;

        mowingcost = 500;
        mowinglevel = 0;
    }

    public void Update(){

        
        MoneyText.text = "Money: " + truncation(money);
        MoneyPerSecText.text = truncation(moneypersecond) + " money/s";

        moneypersecond = coffeelevel + (5*burgerlevel) + (20*mowinglevel);

        QuantityText.text = "x" + quantity;

        CoffeeCostText.text = "+" + quantity + "\n" + "Cost:\n" + Math.Round(quantity*coffeecost) + " money";
        CoffeeLevelText.text = coffeelevel + "/5000 shops";

        BurgerCostText.text = "+" + quantity + "\n" + "Cost:\n" + Math.Round(quantity*burgercost) + " money";
        BurgerLevelText.text = burgerlevel + "/4000 joints";

        MowingCostText.text = "+" + quantity + "\n" + "Cost:\n" + Math.Round(quantity*mowingcost) + " money";
        MowingLevelText.text = mowinglevel + "/2500 mowers";

        money += moneypersecond * Time.deltaTime;
    }

    public string truncation (double value){
        if(value >= 1000000000000){
            return string.Format("{0:0.00}", Math.Round(value/1000000000000, 2)) + " Tri.";
        }
        else if(value >= 1000000000){
            return string.Format("{0:0.00}", Math.Round(value/1000000000, 2)) + " Bil.";
        }
        else if(value >= 1000000){
            return string.Format("{0:0.00}", Math.Round(value/1000000, 2)) + " Mil.";
        }
        else if(value >= 1000){
            return string.Format("{0:0.00}", Math.Round(value/1000, 2)) + " K";
        }
        else {
            return string.Format("{0:0}", value);
        }

    }

    public void CompassClick(){
        money += 10;
    }

    public void QuantityClick(){
        qcounter++;
        if (qcounter == 0){
            quantity = 1;
        }

        else if(qcounter == 1){
            quantity = 10;
        }

        else if(qcounter == 2){
            quantity = 25;
        }

        else if(qcounter == 3){
            quantity = 100;
            qcounter = -1;
        }
    }

    public void CoffeeClick(){
        if(money >= quantity*coffeecost && coffeelevel < 5000){
            money -= quantity*coffeecost;
            coffeelevel += quantity;
            coffeecost *= 1.1;
        }
    }

    public void BurgerClick(){
          if(money >= quantity*burgercost && burgerlevel < 4000){
            money -= quantity*burgercost;
            burgerlevel += quantity;
            burgercost *= 1.1;
        }
    }

    public void MowingClick(){
          if(money >= quantity*mowingcost && mowinglevel < 2500){
            money -= quantity*mowingcost;
            mowinglevel += quantity;
            mowingcost *= 1.1;
        }
    }
}
