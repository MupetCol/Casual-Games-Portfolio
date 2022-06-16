using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    public bool IsHappy { get; set; }

    public Dog(string name, int age): base(name, age)
    {
        IsHappy = true;
    }

    // simple override of the virtual method Eat
    public override void Eat()
    {
        // to call the eat method from our base class we use the keyword "base" followed by the method name
        base.Eat();
    }

    // simple override of the virtual method MakeSound
    public override void MakeSound()
    {
        //Each animal makes a different sound so the implement their own MakeSound
        Debug.Log("WUUUUUF!");
    }

    // simple override of the virtual method Play
    public override void Play()
    {
        // Dogss only play if they are happy
        if (IsHappy)
        {
            base.Play();
        }
    }
}
