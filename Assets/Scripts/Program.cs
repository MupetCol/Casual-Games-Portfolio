using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    void Start()
    {
        //Radio myRadio = new Radio(false, "Sony");
        //myRadio.SwitchOn();
        //myRadio.ListenRadio();

        //TV myTv = new TV(false, "Samsung");
        //myTv.SwitchOn();
        //myTv.WatchTV();

        //Dog dog = new Dog("Pongo", 13);
        //Debug.Log(dog.Name + " is " + dog.Age + " years old");
        //dog.Eat();
        //dog.MakeSound();
        //dog.Play();

        Tickets ticket1 = new Tickets(10);
        Tickets ticket2 = new Tickets(10);
        Tickets ticket3 = new Tickets(15);
        //Implementing an existing interface in a way that benefits us
        Debug.Log(ticket1.Equals(ticket2));
        Debug.Log(ticket1.Equals(ticket3));

    }




}
