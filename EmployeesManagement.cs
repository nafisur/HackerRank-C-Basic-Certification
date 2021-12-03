class Solution
{
    public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
    {
        return employees.
        GroupBy(e => e.Company).
        OrderBy(e => e.Key).
        Select(grp => new
        {
            CompanyName = grp.Key,
            Average = (int)Math.Round(grp.Average(e => e.Age))
        }).
        ToDictionary(item => item.CompanyName.ToString(), item => item.Average);
    }
    public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
    {
        return employees.
        GroupBy(e => e.Company).
        OrderBy(e => e.Key).
        Select(grp => new
        {
            CompanyName = grp.Key,
            Count = (int)grp.Count()
        }).
        ToDictionary(item => item.CompanyName.ToString(), item => item.Count);
    }
    public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
    {
        return employees.
        GroupBy(e => e.Company).
        OrderBy(e => e.Key).
        Select(grp => new
        {
            CompanyName = grp.Key,
            Emp = employees.Where(p => p.Company == grp.Key && p.Age == (int)grp.Max(e => e.Age)).FirstOrDefault()
        }).ToDictionary(item => item.CompanyName.ToString(), item => item.Emp);
    }
}