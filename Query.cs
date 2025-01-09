namespace ApexVizFunctions;

public class Query
{
    public Person GetPerson() => new Person("Luke Skywalker");
}

public class Person
{
    public Person(string name)
    {
        Name = name;
    }

    public string Name { get; }
}

public class RaceResult
{
    public int PaxPosition { get; set; }
    public int ClassPosition { get; set; }
    public string Class { get; set; }
    public int Number { get; set; }
    public string Driver { get; set; }
    public string Car { get; set; }
    public decimal Total { get; set; }
    public decimal Factor { get; set; }
    public decimal PaxTime { get; set; }
    public decimal Diff { get; set; }
    public decimal FromFirst { get; set; }
}