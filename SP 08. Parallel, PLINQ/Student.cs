// Parallel, PLINQ
class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email {  get; set; }
    public string Group { get; set; }
    public double Mark {  get; set; }

    public override string ToString()
    {
        return @$"
Id:       {Id}
Firstname:{FirstName}
LastName: {LastName}
Age:      {Age}
Email:    {Email}
Mark:     {Mark}
Group:    {Group}";
    }
}
