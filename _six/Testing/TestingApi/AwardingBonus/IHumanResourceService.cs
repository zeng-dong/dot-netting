using Bogus;
using System.Text.Json;
using TestingDomain.Users;

namespace TestingApi.AwardingBonus;

public interface IHumanResourceService
{
    IList<Employee> ThoseDeservingBonus();
}

public class HumanResourceService : IHumanResourceService
{
    static readonly List<string> Names = new() { "Mike", "Anthony", "Ryan" };

    public IList<Employee> ThoseDeservingBonus()
    {
        return Fixed();
    }

    public IList<Employee> Fixed()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Deserialize<List<Employee>>(input, options);
    }

    public IList<Employee> Random()
    {
        var employees = new List<Employee>();
        Names.ForEach(n =>
        {
            employees.Add(new Employee() { FirstName = n, LastName = "Miller", Salary = 1000000 });
        });
        var faker = new Faker<Employee>()
            .RuleFor(o => o.Salary, f => (int)f.Finance.Amount(50000, 200000, 0))
            .RuleFor(o => o.FirstName, f => f.Name.FirstName())
            .RuleFor(o => o.LastName, f => f.Name.LastName());
        employees.AddRange(faker.Generate(50));

        return employees;
    }

    readonly string input = $@"
[
  {{
    ""firstName"": ""Mike"",
    ""lastName"": ""Miller"",
    ""bonusRate"": 0,
    ""salary"": 1000000,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Anthony"",
    ""lastName"": ""Miller"",
    ""bonusRate"": 0,
    ""salary"": 1000000,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Ryan"",
    ""lastName"": ""Miller"",
    ""bonusRate"": 0,
    ""salary"": 1000000,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Jonas"",
    ""lastName"": ""Deckow"",
    ""bonusRate"": 0,
    ""salary"": 99385,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Cristina"",
    ""lastName"": ""Auer"",
    ""bonusRate"": 0,
    ""salary"": 171352,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Talia"",
    ""lastName"": ""Leffler"",
    ""bonusRate"": 0,
    ""salary"": 120633,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Elmira"",
    ""lastName"": ""Koss"",
    ""bonusRate"": 0,
    ""salary"": 64248,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Cordie"",
    ""lastName"": ""Corwin"",
    ""bonusRate"": 0,
    ""salary"": 84277,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Cora"",
    ""lastName"": ""Morar"",
    ""bonusRate"": 0,
    ""salary"": 184320,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Giovanna"",
    ""lastName"": ""Dickens"",
    ""bonusRate"": 0,
    ""salary"": 185857,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Courtney"",
    ""lastName"": ""Wolff"",
    ""bonusRate"": 0,
    ""salary"": 195168,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Paris"",
    ""lastName"": ""Wuckert"",
    ""bonusRate"": 0,
    ""salary"": 72832,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Brenda"",
    ""lastName"": ""Schultz"",
    ""bonusRate"": 0,
    ""salary"": 78487,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Nick"",
    ""lastName"": ""Oberbrunner"",
    ""bonusRate"": 0,
    ""salary"": 180534,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Rick"",
    ""lastName"": ""Herman"",
    ""bonusRate"": 0,
    ""salary"": 157028,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Zola"",
    ""lastName"": ""Moen"",
    ""bonusRate"": 0,
    ""salary"": 199248,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Andy"",
    ""lastName"": ""Nitzsche"",
    ""bonusRate"": 0,
    ""salary"": 78717,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Janice"",
    ""lastName"": ""Gottlieb"",
    ""bonusRate"": 0,
    ""salary"": 132590,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Mariam"",
    ""lastName"": ""Blick"",
    ""bonusRate"": 0,
    ""salary"": 82489,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Lorena"",
    ""lastName"": ""Halvorson"",
    ""bonusRate"": 0,
    ""salary"": 62200,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Tessie"",
    ""lastName"": ""Schuppe"",
    ""bonusRate"": 0,
    ""salary"": 81746,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Corine"",
    ""lastName"": ""Batz"",
    ""bonusRate"": 0,
    ""salary"": 180101,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Jess"",
    ""lastName"": ""Hintz"",
    ""bonusRate"": 0,
    ""salary"": 57163,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Rahsaan"",
    ""lastName"": ""Towne"",
    ""bonusRate"": 0,
    ""salary"": 176798,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Viola"",
    ""lastName"": ""Gorczany"",
    ""bonusRate"": 0,
    ""salary"": 112181,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Gudrun"",
    ""lastName"": ""Brakus"",
    ""bonusRate"": 0,
    ""salary"": 91543,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Crawford"",
    ""lastName"": ""Volkman"",
    ""bonusRate"": 0,
    ""salary"": 194882,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Andreanne"",
    ""lastName"": ""Hegmann"",
    ""bonusRate"": 0,
    ""salary"": 100256,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Abraham"",
    ""lastName"": ""Mohr"",
    ""bonusRate"": 0,
    ""salary"": 110998,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Sedrick"",
    ""lastName"": ""Grant"",
    ""bonusRate"": 0,
    ""salary"": 123962,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Marques"",
    ""lastName"": ""Skiles"",
    ""bonusRate"": 0,
    ""salary"": 111116,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Karlie"",
    ""lastName"": ""Morar"",
    ""bonusRate"": 0,
    ""salary"": 101579,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Jolie"",
    ""lastName"": ""Dickinson"",
    ""bonusRate"": 0,
    ""salary"": 185270,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Madaline"",
    ""lastName"": ""Botsford"",
    ""bonusRate"": 0,
    ""salary"": 89483,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Mariana"",
    ""lastName"": ""Zemlak"",
    ""bonusRate"": 0,
    ""salary"": 119207,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Dock"",
    ""lastName"": ""Hermann"",
    ""bonusRate"": 0,
    ""salary"": 140451,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Jeff"",
    ""lastName"": ""D'Amore"",
    ""bonusRate"": 0,
    ""salary"": 98215,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Walker"",
    ""lastName"": ""Wolf"",
    ""bonusRate"": 0,
    ""salary"": 166558,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Mason"",
    ""lastName"": ""Bins"",
    ""bonusRate"": 0,
    ""salary"": 151289,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Lindsey"",
    ""lastName"": ""Wunsch"",
    ""bonusRate"": 0,
    ""salary"": 112679,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Amos"",
    ""lastName"": ""Funk"",
    ""bonusRate"": 0,
    ""salary"": 141423,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Martine"",
    ""lastName"": ""Reynolds"",
    ""bonusRate"": 0,
    ""salary"": 116998,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Jonathon"",
    ""lastName"": ""McLaughlin"",
    ""bonusRate"": 0,
    ""salary"": 118098,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Jamel"",
    ""lastName"": ""Cartwright"",
    ""bonusRate"": 0,
    ""salary"": 159906,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Telly"",
    ""lastName"": ""Fisher"",
    ""bonusRate"": 0,
    ""salary"": 141247,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Francesca"",
    ""lastName"": ""Morar"",
    ""bonusRate"": 0,
    ""salary"": 119989,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Kellie"",
    ""lastName"": ""Waelchi"",
    ""bonusRate"": 0,
    ""salary"": 70254,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Raphael"",
    ""lastName"": ""Christiansen"",
    ""bonusRate"": 0,
    ""salary"": 173893,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Maryjane"",
    ""lastName"": ""Dickens"",
    ""bonusRate"": 0,
    ""salary"": 165242,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Lorenz"",
    ""lastName"": ""Greenfelder"",
    ""bonusRate"": 0,
    ""salary"": 197846,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Althea"",
    ""lastName"": ""Mann"",
    ""bonusRate"": 0,
    ""salary"": 185154,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Nelda"",
    ""lastName"": ""Johnson"",
    ""bonusRate"": 0,
    ""salary"": 119106,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Ivory"",
    ""lastName"": ""Maggio"",
    ""bonusRate"": 0,
    ""salary"": 81067,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }}
]
";
}