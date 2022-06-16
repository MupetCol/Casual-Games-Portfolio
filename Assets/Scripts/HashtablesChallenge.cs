using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashtablesChallenge : MonoBehaviour
{
    // Hash tables are non generic version of dictionaries
    Hashtable studentsTable = new Hashtable();
    void Start()
    {
        // Testing for the Dictionary Challenge
        Dictionary<int, string> myDit = new Dictionary<int, string>()
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "two" },
            { 5, "five" }
 
        };

        Debug.Log(myDit[1]);
        //

        Student[] students = new Student[5];
        students[0] = new Student(1, "Daniel", 99);
        students[1] = new Student(2, "Andrea", 69);
        students[2] = new Student(3, "Carlos", 57);
        students[3] = new Student(4, "Diana", 59);
        students[4] = new Student(1, "Andres", 19);

        foreach (Student s in students)
        {
            if (studentsTable.ContainsKey(s.id))
            {
                Debug.Log("Sorry a student with the same ID already exists");
                continue;
            }
            else
            {
                studentsTable.Add(s.id, s);
            }
        }

        foreach(Student obj in studentsTable.Values)
        {
            Debug.Log(obj.name);
        }

    }

    
}

class Student
{
    public int id { get; set; }
    public string name { get; set; }
    public float GPA { get; set; }

    public Student(int id, string name, float GPA)
    {
        this.id = id;
        this.name = name;
        this.GPA = GPA;
    }
}
