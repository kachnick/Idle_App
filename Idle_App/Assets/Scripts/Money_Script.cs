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

        CoffeeCostText.text = "+" + quantity + "\n" + "Cost:\n" + truncation(((coffeecost/(-0.1))*(1-(Math.Pow(1.1, quantity))))) + " money";
        CoffeeLevelText.text = coffeelevel + "/5000 shops";

        BurgerCostText.text = "+" + quantity + "\n" + "Cost:\n" + truncation(((burgercost/(-0.1))*(1-(Math.Pow(1.1, quantity))))) + " money";
        BurgerLevelText.text = burgerlevel + "/4000 joints";

        MowingCostText.text = "+" + quantity + "\n" + "Cost:\n" + truncation(((mowingcost/(-0.1))*(1-(Math.Pow(1.1, quantity))))) + " money";
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
        if(money >= ((coffeecost/(-0.1))*(1-(Math.Pow(1.1, quantity))))  && coffeelevel < 5000){
            money -= ((coffeecost/(-0.1))*(1-(Math.Pow(1.1, quantity)))) ;
            coffeelevel += quantity;
            coffeecost *= Math.Pow(1.1, quantity);
        }
    }

    public void BurgerClick(){
          if(money >= ((burgercost/(-0.1))*(1-(Math.Pow(1.1, quantity))))   && burgerlevel < 4000){
            money -= ((burgercost/(-0.1))*(1-(Math.Pow(1.1, quantity)))) ;
            burgerlevel += quantity;
            burgercost *= Math.Pow(1.1, quantity);
        }
    }

    public void MowingClick(){
          if(money >= ((mowingcost/(-0.1))*(1-(Math.Pow(1.1, quantity)))) && mowinglevel < 2500){
            money -= ((mowingcost/(-0.1))*(1-(Math.Pow(1.1, quantity))));
            mowinglevel += quantity;
            mowingcost *= Math.Pow(1.1, quantity);
        }
    }
}
