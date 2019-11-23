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
    public Image CoffeeLevelBar;

    //burgers
    public Text BurgerCostText;
    public Text BurgerLevelText;
    public double burgercost;
    public int burgerlevel;
    public Image BurgerLevelBar;

    //mowing
    public Text MowingCostText;
    public Text MowingLevelText;
    public double mowingcost;
    public int mowinglevel;
    public Image MowingLevelBar;

    //mining
    public Text MiningCostText;
    public Text MiningLevelText;
    public double miningcost;
    public int mininglevel;
    public Image MiningLevelBar;
    
    //auto
    public Text CarCostText;
    public Text CarLevelText;
    public double carcost;
    public int carlevel;
    public Image CarLevelBar;

    //nuclear
    public Text NuclearCostText;
    public Text NuclearLevelText;
    public double nuclearcost;
    public int nuclearlevel;
    public Image NuclearLevelBar;

    //tech
    public Text TechCostText;
    public Text TechLevelText;
    public double techcost;
    public int techlevel;
    public Image TechLevelBar;

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

        miningcost = 2000;
        mininglevel = 0;

        carcost = 5000;
        carlevel = 0;

        nuclearcost = 20000;
        nuclearlevel = 0;

        techcost = 50000;
        techlevel = 0;
        
        Load();
    }

    public void Load(){

    }

    public void Save(){

    }

    public void Update(){
        
        MoneyText.text = truncation(money);
        MoneyPerSecText.text = truncation(moneypersecond) + " per second";

        moneypersecond = coffeelevel + (5*burgerlevel) + (20*mowinglevel) + (50*mininglevel) + (100*carlevel) + (250*nuclearlevel) + (500*techlevel);

        QuantityText.text = "x" + quantity;

        CoffeeCostText.text = "+" + quantity + "\n\n" + "Cost:\n" + truncation(((coffeecost/(-0.05))*(1-(Math.Pow(1.05, quantity))))) + " money";
        CoffeeLevelText.text = coffeelevel + "/6000 shops"; 

        BurgerCostText.text = "+" + quantity + "\n\n" + "Cost:\n" + truncation(((burgercost/(-0.05))*(1-(Math.Pow(1.05, quantity))))) + " money";
        BurgerLevelText.text = burgerlevel + "/5000 joints";

        MowingCostText.text = "+" + quantity + "\n\n" + "Cost:\n" + truncation(((mowingcost/(-0.05))*(1-(Math.Pow(1.05, quantity))))) + " money";
        MowingLevelText.text = mowinglevel + "/4000 mowers";
        
        MiningCostText.text = "+" + quantity + "\n\n" + "Cost:\n" + truncation(((miningcost/(-0.05))*(1-(Math.Pow(1.05, quantity))))) + " money";
        MiningLevelText.text = mininglevel + "/3000 shafts";

        CarCostText.text = "+" + quantity + "\n\n" + "Cost:\n" + truncation(((carcost/(-0.05))*(1-(Math.Pow(1.05, quantity))))) + " money";
        CarLevelText.text = carlevel + "/2500 dealers";

        NuclearCostText.text = "+" + quantity + "\n\n" + "Cost:\n" + truncation(((nuclearcost/(-0.05))*(1-(Math.Pow(1.05, quantity))))) + " money";
        NuclearLevelText.text = nuclearlevel + "/2000 plants";

        TechCostText.text = "+" + quantity + "\n\n" + "Cost:\n" + truncation(((techcost/(-0.05))*(1-(Math.Pow(1.05, quantity))))) + " money";
        TechLevelText.text = techlevel + "/1000 firms";

        money += moneypersecond * Time.deltaTime;
    }

    public string truncation (double value){
        if(value >= 1000000000000000000){
            return string.Format("{0:0.00}", Math.Round(value/1000000000000000000, 2)) + " Quin.";
        }
        else if(value >= 1000000000000000){
            return string.Format("{0:0.00}", Math.Round(value/1000000000000000, 2)) + " Quad.";
        }
        else if(value >= 1000000000000){
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
        if(money >= ((coffeecost/(-0.05))*(1-(Math.Pow(1.05, quantity))))  && coffeelevel < 6000){
            money -= ((coffeecost/(-0.05))*(1-(Math.Pow(1.05, quantity)))) ;
            coffeelevel += quantity;
            coffeecost *= Math.Pow(1.05, quantity);
            float temp1 = 6000;
            CoffeeLevelBar.fillAmount = (float) (coffeelevel/temp1);
        }
    }

    public void BurgerClick(){
          if(money >= ((burgercost/(-0.05))*(1-(Math.Pow(1.05, quantity))))   && burgerlevel < 5000){
            money -= ((burgercost/(-0.05))*(1-(Math.Pow(1.05, quantity)))) ;
            burgerlevel += quantity;
            burgercost *= Math.Pow(1.05, quantity);
            float temp2 = 5000;
            BurgerLevelBar.fillAmount = (float) (burgerlevel/temp2);
        }
    }

    public void MowingClick(){
          if(money >= ((mowingcost/(-0.05))*(1-(Math.Pow(1.05, quantity)))) && mowinglevel < 4000){
            money -= ((mowingcost/(-0.05))*(1-(Math.Pow(1.05, quantity))));
            mowinglevel += quantity;
            mowingcost *= Math.Pow(1.05, quantity);
            float temp3 = 4000;
            MowingLevelBar.fillAmount = (float) (mowinglevel/temp3);
        }
    }

     public void MiningClick(){
          if(money >= ((miningcost/(-0.05))*(1-(Math.Pow(1.05, quantity)))) && mininglevel < 3000){
            money -= ((miningcost/(-0.05))*(1-(Math.Pow(1.05, quantity))));
            mininglevel += quantity;
            miningcost *= Math.Pow(1.05, quantity);
            float temp4 = 3000;
            MiningLevelBar.fillAmount = (float) (mininglevel/temp4);
        }
    }

     public void CarClick(){
          if(money >= ((carcost/(-0.05))*(1-(Math.Pow(1.05, quantity)))) && carlevel < 2500){
            money -= ((carcost/(-0.05))*(1-(Math.Pow(1.05, quantity))));
            carlevel += quantity;
            carcost *= Math.Pow(1.05, quantity);
            float temp5 = 2500;
            CarLevelBar.fillAmount = (float) (carlevel/temp5);
        }
    }

     public void NuclearClick(){
          if(money >= ((nuclearcost/(-0.05))*(1-(Math.Pow(1.05, quantity)))) && nuclearlevel < 2000){
            money -= ((nuclearcost/(-0.05))*(1-(Math.Pow(1.05, quantity))));
            nuclearlevel += quantity;
            nuclearcost *= Math.Pow(1.05, quantity);
            float temp6 = 2000;
            NuclearLevelBar.fillAmount = (float) (nuclearlevel/temp6);
        }
    }

     public void TechClick(){
          if(money >= ((techcost/(-0.05))*(1-(Math.Pow(1.05, quantity)))) && techlevel < 1000){
            money -= ((techcost/(-0.05))*(1-(Math.Pow(1.05, quantity))));
            techlevel += quantity;
            techcost *= Math.Pow(1.05, quantity);
            float temp7 = 1000;
            TechLevelBar.fillAmount = (float) (techlevel/temp7);
        }
    }
}
