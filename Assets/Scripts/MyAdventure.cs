using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class MyAdventure : MonoBehaviour
{
    private enum States
    {
        start,
        Intro,
        geluid_horen,
        geluid_Ja,
        geluid_verder_film_kijken,
        geluid_niet_film_kijken,
        geluid_Nee,
        loopt_naar_de_gang,



    }

    private States currentStates = States.start;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Welkom bij HorrorNight!");
        Terminal.WriteLine("Dit is een leuke spannende");
        Terminal.WriteLine("horror game.");
        Terminal.WriteLine("Alles is hoofdletter gevoelig");
        Terminal.WriteLine("Type START om met het spel te beginnen.");
        Terminal.WriteLine("------------------------------");

    }

    void OnUserInput(string input)
    {
        if (currentStates == States.start)
        {
            if (input == "START")
            {
                StartIntro();
            }
            //else if (input == "1337")
            //{
            //Terminal.WriteLine("jij bent leet");
            //}
            else
            {
                Terminal.WriteLine("Type START om door te gaan!");
            }
        }
        else if (currentStates == States.Intro)
        {
            if (input == "VERDER")
            {
                GeluidHoren();
            }
            else
            {
                Terminal.WriteLine("Je invoer is niet juist");
            }
        }
        else if (currentStates == States.geluid_horen)
        {
            if (input == "JA")
            {
                geluid_Ja();
            }
            else
            {
                Terminal.WriteLine("je invoer is niet juist");
            }
        }

        else if (currentStates == States.geluid_Ja)
        {
            if (input == "FILM VERDER KIJKEN")
            {
                geluid_verder_film_kijken();
            }
            else
            {
                Terminal.WriteLine("Je invoer is niet juist");
            }
        }

        if (currentStates == States.geluid_horen)
        {
            if (input == "NEE")
            {
                geluid_Nee();
            }
            else
            {
                //Terminal.WriteLine("je invoer is niet juist.");
            }
        }

    }

    void StartIntro()

    {
        currentStates = States.Intro;
        Terminal.ClearScreen();
        Terminal.WriteLine("Het is 10 september 2019 op een ");
        Terminal.WriteLine("donkere koude nacht.");
        Terminal.WriteLine("Je bent alleen thuis.");
        Terminal.WriteLine("Het was de perfecte nacht voor ");
        Terminal.WriteLine("een horror film.");
        Terminal.WriteLine("Type VERDER om het spel te beginnen");
        currentStates = States.Intro;
    }


    void GeluidHoren()
    {
        currentStates = States.geluid_horen;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je hoort allemaal rare geluiden");
        Terminal.WriteLine("beneden en buiten het huis.");
        Terminal.WriteLine("wil je uit het raam kijken?");
        Terminal.WriteLine("Type JA als je wilt kijken");
        Terminal.WriteLine("Type NEE als je niet wilt kijken");

    }

    void geluid_Ja()
    {
        currentStates = States.geluid_Ja;
        Terminal.ClearScreen();
        Terminal.WriteLine("*je kijkt uit het raam*");
        Terminal.WriteLine("kijkt naar links...");
        Terminal.WriteLine("Je ziet niks");
        Terminal.WriteLine("Kijkt naar rechts...");
        Terminal.WriteLine("je ziet een Man");
        Terminal.WriteLine("Type 'Blijf kijken'");
        Terminal.WriteLine("als je wilt kijkt naar de man");
        Terminal.WriteLine("Type 'film verder kijken'");
        Terminal.WriteLine("als je film verder wilt kijken");
// moet kijken of ik die verder kijken of blijf kijken er moet laten of eruit moet halen//
    }

    void geluid_verder_film_kijken()
    {
        currentStates = States.geluid_verder_film_kijken;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je hoort iets op de gang op je af lopen");
        Terminal.WriteLine("je gaat kijken");
    }

    void geluid_Nee()
    {
        currentStates = States.geluid_Nee;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je loopt naar de gang");
        Terminal.WriteLine("want je hoorde allemaal geluiden.");
        Terminal.WriteLine("Wil je ouders roepen type: OUDERS ROEPEN");
        Terminal.WriteLine("wil je naar beneden type: NAAR BENEDEN");
    }
}
