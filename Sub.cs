class Subject
    {
        public string SubjectName { get; set; }
        public List<Student> Students { get; set; }

        public Subject(string name)
        {
            SubjectName = name;
            Students = new List<Student>();
        }

        public void AddStudent(Student s)
        {
            Students.Add(s);
        }

        public void ShowStats()
        {
            if (Students.Count == 0) return;

            Console.WriteLine($"Max: {Students.Max(s => s.Score)}");
            Console.WriteLine($"Min: {Students.Min(s => s.Score)}");
            Console.WriteLine($"Avg: {Students.Average(s => s.Score):F2}");
        }
