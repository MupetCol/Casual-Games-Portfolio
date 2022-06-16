using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsHungry { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
        IsHungry = true;
    }

    // VIRTUAL Keyword allows subclases to override the method
    public virtual void MakeSound()
    {

    }

    public virtual void Eat()
    {
        if (IsHungry)
        {
            Debug.Log(Name + " is eating");
        }
        else
        {
            Debug.Log(Name + " is not Hungry");
        }
    }

    public virtual void Play()
    {
        Debug.Log(Name + " is Playing");
    }

}
