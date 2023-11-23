using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedRacer : MonoBehaviour
{
    public string carMaker;
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";

    public int carWeight = 1609;
    public int yearMade = 2009;

    public float maxAcceleration = 0.98f;

    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;

    public TextMeshProUGUI fuelConsText;
    public TextMeshProUGUI carInfoText;
    public TextMeshProUGUI carWeightText;
    public TextMeshProUGUI yearText;
    public TextMeshProUGUI frontEngineText;

    void Start()
    {
        print("The racer model is " + carModel + ". Car maker is " + carMaker + ". It has a " + engineType + " engine.");
        carInfoText.text = "The racer model is " + carModel + ". Car maker is " + carMaker + ". It has a " + engineType + " engine.";

        CheckWeight();

        if (yearMade <= 2009)
        {
            print("It was first introduced in " + yearMade);
            yearText.text = "It was first introduced in " + yearMade;

            int carAge = CalculateAge(yearMade);

            print("That makes it " + carAge + " years old.");
            yearText.text = "That makes it " + carAge + " years old.";

        }
        else
        {
            print("The car was introduced in the 2010's.");
            yearText.text = "The car was introduced in the 2010's.";
            print(carModel + " has a maximum acceleration of " + maxAcceleration);
            yearText.text = carModel + " has a maximum acceleration of " + maxAcceleration;
        }

        print(CheckCharacteristics());

        frontEngineText.text = CheckCharacteristics();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }

    public class Fuel
    {
        public int fuelLevel;

        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
        
    }

    public void ConsumeFuel()
    {
        carFuel.fuelLevel = carFuel.fuelLevel - 10;

    }

    public void CheckFuelLevel()
    {
        switch(carFuel.fuelLevel)
        {
            case 70:
                print("fuel level is nearing two-thirds.");
                fuelConsText.text = "fuel level is nearing two-thirds.";
                break;
            case 50:
                print("fuel level is at half amount.");
                fuelConsText.text = "fuel level is at half amount.";
                break;
            case 10:
                print("Warning! Fuel level is critically low.");
                fuelConsText.text = "Warning! Fuel level is critically low..";
                break;
            default:
                print("Nothing to report.");
                fuelConsText.text = "Nothing to report.";
                break;
        }
    }

    public Fuel carFuel = new Fuel(100);

    void CheckWeight()
    {
        if(carWeight < 1500)
        {
            print(carModel + " weights less than 1500 kg.");
            carWeightText.text = carModel + " weights less than 1500 kg.";
        }
        else
        {
            print(carModel + " weights over 1500 kg.");
            carWeightText.text = carModel + " weights over 1500 kg.";
        }
    }

    int CalculateAge(int yearMade)
    {
        int year = 2023 - yearMade;
        return year;
    }

    string CheckCharacteristics()
    {
        if (isCarTypeSedan)
        {
            string sedanMessage = "The car type is a sedan.";
            return sedanMessage;
        }
        else if (hasFrontEngine)
        {
            string frontEngineMessage = "The car isn't a sedan, but has a front engine.";
            return frontEngineMessage;
        }
        else
        {
            return "The car is neither a sedan nor does it have a front engine.";
        }
    }
}
