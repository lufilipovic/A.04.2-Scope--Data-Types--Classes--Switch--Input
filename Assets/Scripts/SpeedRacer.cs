using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void Start()
    {
        print("The racer model is " + carModel + ". Car maker is " + carMaker + ". It has a " + engineType + " engine.");

        CheckWeight();

        if (yearMade <= 2009)
        {
            print("It was first introduced in " + yearMade);
            int carAge = CalculateAge(yearMade);
            print("That makes it " + carAge + " years old.");

        }
        else
        {
            print("The car was introduced in the 2010's.");
            print(carModel + " has a maximum acceleration of " + maxAcceleration);
        }

        print(CheckCharacteristics());
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

    void ConsumeFuel()
    {
        carFuel.fuelLevel = carFuel.fuelLevel - 10;

    }

    void CheckFuelLevel()
    {
        switch(carFuel.fuelLevel)
        {
            case 70:
                print("fuel level is nearing two-thirds.");
                break;
            case 50:
                print("fuel level is at half amount.");
                break;
            case 10:
                print("Warning! Fuel level is critically low.");
                break;
            default:
                print("Nothing to report.");
                break;
        }
    }

    public Fuel carFuel = new Fuel(100);

    void CheckWeight()
    {
        if(carWeight < 1500)
        {
            print(carModel + " weights less than 1500 kg.");
        }
        else
        {
            print(carModel + " weights over 1500 kg.");
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
