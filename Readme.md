using System.ComponentModel;

@startuml
class Course
{
  - courseId : string
  - courseName : string
  + AddStudent(student : Student)
  + CalculateGrade(score : double) : string
}

class Student
{
  - studentId : string
  - fullName : string
  - score : double
  + GetGrade() : string
}

class GradeCalculator
{
  + GetGrade(score : double) : string
}

Course "1" --> "*" Student : contains
Student --> GradeCalculator : uses
@enduml