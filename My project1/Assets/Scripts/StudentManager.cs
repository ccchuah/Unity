using System.Collections.Generic;
using UnityEngine;

public class Student
{
    public int studentId;

    public Student(int id)
    {
        studentId = id;
    }
}

public class StudentManager : MonoBehaviour
{
    void Start()
    {
        int rows = 8;
        int cols = 4;

        Dictionary<Vector2Int, Student> studentsDict = new Dictionary<Vector2Int, Student>();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int studentId = i + j;
                Student student = new Student(studentId);
                studentsDict[new Vector2Int(i, j)] = student;
            }
        }
        foreach (var kvp in studentsDict)
        {
            Vector2Int index = kvp.Key;
            Student student = kvp.Value;
            Debug.Log("Row: " + index.x + ", Column: " + index.y + ", Student ID: " + student.studentId);
        }
    }
}