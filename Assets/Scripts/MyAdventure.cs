using System;
using System.ComponentModel.Design;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MyAdventure : MonoBehaviour
{
    private enum States
    {
        start,
        Intro,
        geluid_horen,
        geluid_Ja,
        raam_kijken,
        geluid_verder_film_kijken,
        geluid_verder_naar_beneden,
        geluid_niet_film_kijken,
        raam_dicht,
        geluid_gang,
        geluid_andere_kamer,
        raam_spring_vrij,
        ouders_roepen,
        geluid_Nee,
        raam_wacht,
        naar_de_deur_lopen,
        naar_boven_gaan,
        naar_beneden,
        keuken_lopen,
        deur_lopen,
        kast_verstoppen,
        onder_bed,
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
        print(currentStates);
    }

    void OnUserInput(string input)
    {
        print("input is: " + input);
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
        else if (currentStates == States.geluid_Ja)
        {
            if (input == "BLIJF KIJKEN")
            {
                raam_kijken();
            }
            else if (input == "FILM VERDER KIJKEN")
            {
                geluid_gang();
            }

//            else
//            {
//                Terminal.WriteLine("Je invoer is niet juist");
//            }
        }
        else if (currentStates == States.raam_kijken)
        {
            if (input == "OPNIEUW SPELEN") ;
            {
                ShowMainMenu();
            }
        }

        else if (currentStates == States.geluid_gang)
        {
            if (input == "NAAR ANDERE KAMER GAAN")
            {
                geluid_andere_kamer();
            }
            else if (input == "NAAR BENEDEN GAAN")
            {
                geluid_verder_naar_beneden();
            }
        }

        else if (currentStates == States.geluid_Nee)
        {
            if (input == "NAAR BENEDEN GAAN")
            {
                geluid_verder_naar_beneden();
            }
            else if (input == "OUDERS ROEPEN")
            {
                ouders_roepen();
            }
        }

        else if (currentStates == States.ouders_roepen)
        {
            if (input == "NAAR BENEDEN GAAN")
            {
                geluid_verder_naar_beneden();
            }
        }

        else if (currentStates == States.geluid_andere_kamer)
        {
            if (input == "RAAM DICHT") ;
            {
                raam_dicht();
            }
        }

        else if (currentStates == States.raam_dicht)
        {
            if (input == "UIT RAAM SPRINGEN")
            {
                raam_spring_vrij();
            }
            else if (input == "WACHT")
            {
                raam_wacht();
            }
        }

        else if (currentStates == States.raam_wacht)
        {
            if (input == "TERUG NAAR BEGINSCHERM")
            {
                ShowMainMenu();
            }
        }


        else if (currentStates == States.raam_spring_vrij)
        {
            if (input == "TERUG NAAR BEGINSCHERM")
            {
                ShowMainMenu();
            }
        }

        else if (currentStates == States.geluid_niet_film_kijken)
        {
            if (input == "NAAR DE KEUKEN LOPEN")
            {
                geluid_verder_naar_beneden();
            }
            else
            {
                Terminal.WriteLine("Je invoer is niet juist");
            }
        }

        else if (currentStates == States.geluid_verder_naar_beneden)
        {
            if (input == "NAAR DE KEUKEN LOPEN")
            {
                keuken_lopen();
            }
            else if (input == "NAAR VOORDEUR LOPEN")
            {
                deur_lopen();
            }
        }

        else if (currentStates == States.geluid_verder_naar_beneden)
        {
            if (input == "TERUG NAAR BEGINSCHERM")
            {
                ShowMainMenu();
            }
        }
        else if (currentStates == States.keuken_lopen)
        {
            if (input == "NAAR DE DEUR LOPEN")
            {
                naar_de_deur_lopen();
            }
            else if (input == "NAAR BOVEN GAAN")
            {
                naar_boven_gaan();
            }
        }

        else if (currentStates == States.naar_de_deur_lopen)
        {
            if (input == "TERUG NAAR BEGINSCHERM")
            {
                ShowMainMenu();
            }
        }

        else if (currentStates == States.deur_lopen)
        {
            if (input == "TERUG NAAR BEGINSCHERM")
            {
                ShowMainMenu();
            }
        }
        else if (currentStates == States.naar_boven_gaan)
        {
            if (input == "IN KAST VERSTOPPEN")
            {
                kast_verstoppen();
            }
            else if (input == "ONDER BED VERSTOPPEN")
            {
                onder_bed();
            }
        }
        else if (currentStates == States.kast_verstoppen)
        {
            if (input == "")
            {
                
            }
        }
    }

    void ShowMainMenu()
    {
        currentStates = States.start;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welkom bij HorrorNight!");
        Terminal.WriteLine("Dit is een leuke spannende");
        Terminal.WriteLine("horror game.");
        Terminal.WriteLine("Alles MOET in HOOFDLETTERS!");
        Terminal.WriteLine("Type START om met het spel te beginnen.");
        Terminal.WriteLine("------------------------------");
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
        Terminal.WriteLine("");
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
        Terminal.WriteLine("");
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
        Terminal.WriteLine("Type 'BLIJF KIJKEN'");
        Terminal.WriteLine("als je wilt kijkt naar de man");
        Terminal.WriteLine("Type 'FILM VERDER KIJKEN'");
        Terminal.WriteLine("als je film verder wilt kijken");
        Terminal.WriteLine("");
    }

    void raam_kijken()
    {
        currentStates = States.raam_kijken;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je focust je te veel op de man die buiten staat");
        Terminal.WriteLine("Hierdoor is de moordenaar binnengekomen");
        Terminal.WriteLine("Het is het einde van de game keer terug naar de beginscherm om");
        Terminal.WriteLine("het spel opnieuw te spelen");
        Terminal.WriteLine("Type: OPNIEUW SPELEN");
        Terminal.WriteLine("");
    }

    void geluid_gang()
    {
        currentStates = States.geluid_gang;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je hoort iets op de gang op je af lopen");
        Terminal.WriteLine("je gaat kijken maar je ziet niks");
        Terminal.WriteLine("Wil je naar beneden gaan?");
        Terminal.WriteLine("Type: NAAR BENEDEN GAAN");
        Terminal.WriteLine("Of");
        Terminal.WriteLine("Wil je naar een andere kamer gaan?");
        Terminal.WriteLine("Type: NAAR ANDERE KAMER GAAN");
        Terminal.WriteLine("");
    }

    void geluid_andere_kamer()
    {
        currentStates = States.geluid_andere_kamer;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je ziet dat de kamer deur op een kiertje staat");
        Terminal.WriteLine("Je doet de deur rustig open");
        Terminal.WriteLine("Je kijkt en je ziet dat de raam open staat");
        Terminal.WriteLine("Type: *RAAM DICHT*");
        Terminal.WriteLine("of");
        Terminal.WriteLine("Type: *LOOP KAMER BINNEN* om naar binnen te gaan");
        Terminal.WriteLine("");
    }

    void raam_dicht()
    {
        currentStates = States.raam_dicht;
        Terminal.ClearScreen();
        Terminal.WriteLine("je loopt heel voorzicht naar de raam");
        Terminal.WriteLine("Je hoort allemaal geluiden op de gang");
        Terminal.WriteLine("je hoort het geluid steeds harden en");
        Terminal.WriteLine("het op je af komen");
        Terminal.WriteLine("Je heb nu 2 keuzes");
        Terminal.WriteLine("Type: UIT RAAM SPRINGEN");
        Terminal.WriteLine("Als je uit het raam wilt springen");
        Terminal.WriteLine("Type: WACHT");
        Terminal.WriteLine("Als je wilt wachten tot het in je kamer komt");
        Terminal.WriteLine("");
    }

    void raam_spring_vrij()
    {
        currentStates = States.raam_spring_vrij;
        Terminal.ClearScreen();
        Terminal.WriteLine("JE HEBT HET SPEL VOLTOOID!");
        Terminal.WriteLine("Je bent uit het huis ontsnapt");
        Terminal.WriteLine("zonder dat er iets met je is overkomen");
        Terminal.WriteLine("keer terug naar begin scherm");
        Terminal.WriteLine("Type: TERUG NAAR BEGINSCHERM");
        Terminal.WriteLine("");
    }

    void raam_wacht()
    {
        currentStates = States.raam_wacht;
        Terminal.ClearScreen();
        Terminal.WriteLine("Het geluid word steeds harder");
        Terminal.WriteLine("Het komt steeds dichterbij");
        Terminal.WriteLine("Opeens hoor je niks meer");
        Terminal.WriteLine("Je denkt dat het weg is gegaan");
        Terminal.WriteLine(".....");
        Terminal.WriteLine("BAM!!");
        Terminal.WriteLine("deur wordt ingetrapt");
        Terminal.WriteLine("Je ziet de moordenaar en je bent door");
        Terminal.WriteLine("Type: TERUG NAAR BEGINSCHERM");
    }

    void geluid_verder_naar_beneden()
    {
        currentStates = States.geluid_verder_naar_beneden;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je hoort geluid beneden");
        Terminal.WriteLine("je gaat naar beneden");
        Terminal.WriteLine("je loopt heel rustig van de trap af");
        Terminal.WriteLine("je ziet dat de deur open staat");
        Terminal.WriteLine("Je kijkt naar de keuken");
        Terminal.WriteLine("en je ziet dat de keukenla open staat");
        Terminal.WriteLine("Type: *NAAR DE KEUKEN LOPEN*");
        Terminal.WriteLine("als je wilt kijken");
        Terminal.WriteLine("of");
        Terminal.WriteLine("Type *NAAR VOORDEUR LOPEN* om te kijken");
        Terminal.WriteLine("");
    }

    void keuken_lopen()
    {
        currentStates = States.keuken_lopen;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je loopt naar de keuken toe");
        Terminal.WriteLine("In de keuken la zie je een aantal scherpen menssen zitten");
        Terminal.WriteLine("*Je pakt een mes*");
        Terminal.WriteLine("Type: NAAR DE DEUR LOPEN");
        Terminal.WriteLine("als je naar de deur wilt gaan die open staat");
        Terminal.WriteLine("of");
        Terminal.WriteLine("Type: NAAR BOVEN GAAN");
        Terminal.WriteLine("Als je met je mes terug naar je kamer wilt gaan");
        Terminal.WriteLine("");
    }

    void naar_de_deur_lopen()
    {
        currentStates = States.naar_de_deur_lopen;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je loopt rustig naar de deur toe");
        Terminal.WriteLine("je kijkt goed naar de deur openingen");
        Terminal.WriteLine("Als je in de deur opening staat ");
        Terminal.WriteLine("komt er opeens iemand die je vermoord");
        Terminal.WriteLine("Je bent nu dood gegaan");
        Terminal.WriteLine("De moordenaar heeft je dood gemaakt");
        Terminal.WriteLine("Type: TERUG NAAR BEGINSCHERM");
        Terminal.WriteLine("");
    }

    void naar_boven_gaan()
    {
        currentStates = States.naar_boven_gaan;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je rent met de scherpe mes die je hebt naar boven");
        Terminal.WriteLine("doordat je iets hoort laat je mes vallen");
        Terminal.WriteLine("Je raapt de mes op en rent door naar je kamer");
        Terminal.WriteLine("Je komt aan in je kamer ");
        Terminal.WriteLine("Type: IN KAST VERSTOPPEN");
        Terminal.WriteLine("of");
        Terminal.WriteLine("Type: ONDER BED VERSTOPPEN");
        Terminal.WriteLine("");
    }

    void kast_verstoppen()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je bent verstopt in de kast");
        Terminal.WriteLine("de moordenaar loopt je kamer binnen");
        Terminal.WriteLine("Hij kijk onder de bed en gaat er weer vandoor");
        Terminal.WriteLine("Na een aantal minuten hoor je helemaal niks meer");
        Terminal.WriteLine("het is dood stil in het huis");
        Terminal.WriteLine("je komt uit de kast en gaat om hulp vragen");
        Terminal.WriteLine("Je hebt het spel voltooid!");
        Terminal.WriteLine("Goed gedaan");
        Terminal.WriteLine("Type: TERUG NAAR BEGINSCHERM");
        Terminal.WriteLine("")
    }

    void onder_bed()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("de moordenaar loopt je kamer binnen");
        Terminal.WriteLine("Hij loopt gelijk op de kast af");
        Terminal.WriteLine("de  moordenaar onderzoekt nog de kamer");
        Terminal.WriteLine("op het moment dat je denkt dat de");
        Terminal.WriteLine("moordenaar weg wilt gaan kijkt die nog onder het bed");
        Terminal.WriteLine("je bent dood.");
        Terminal.WriteLine("Type: TERUG NAAR BEGINSCHERM");
    }

    void deur_lopen()
    {
        currentStates = States.deur_lopen;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je loopt rustig naar de deur toe");
        Terminal.WriteLine("je kijkt goed naar de deur openingen");
        Terminal.WriteLine("Als je in de deur opening staat ");
        Terminal.WriteLine("komt er opeens iemand die je vermoord");
        Terminal.WriteLine("Je bent nu dood gegaan");
        Terminal.WriteLine("De moordenaar heeft je dood gemaakt");
        Terminal.WriteLine("Type: TERUG NAAR BEGINSCHERM");
        Terminal.WriteLine("");
    }

    void geluid_Nee()
    {
        currentStates = States.geluid_Nee;
        Terminal.ClearScreen();
        Terminal.WriteLine("Je loopt naar de gang");
        Terminal.WriteLine("want je hoorde allemaal geluiden.");
        Terminal.WriteLine("Wil je ouders roepen type: OUDERS ROEPEN");
        Terminal.WriteLine("wil je naar beneden type: NAAR BENEDEN GAAN");
        Terminal.WriteLine("");
    }


    void ouders_roepen()
    {
        currentStates = States.ouders_roepen;
        Terminal.ClearScreen();
        Terminal.WriteLine("MAMA????");
        Terminal.WriteLine("PAPA????");
        Terminal.WriteLine("ZIJN JULLIE THUISS???");
        Terminal.WriteLine("Type: NAAR BENEDEN GAAN");
        Terminal.WriteLine("Om naar beneden te gaan.");
        Terminal.WriteLine("");
    }
}