class Parent
{
    // สิ่งที่ให้ลูกใช้
}

class Child : Parent
{
    // สืบทอดจาก Parent
}
class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }
}
class Student : Person
{
    public string StudentID { get; set; }

    public Student(string id, string name) : base(name)
    {
        StudentID = id;
    }
}