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
            employees.Add(new Employee() { FirstName = n, LastName = "Miller" });
        });
        var faker = new Faker<Employee>()
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
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Anthony"",
    ""lastName"": ""Miller"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Ryan"",
    ""lastName"": ""Miller"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Halie"",
    ""lastName"": ""Hayes"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Sonya"",
    ""lastName"": ""Koss"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Blanche"",
    ""lastName"": ""Frami"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Olga"",
    ""lastName"": ""Mann"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Karine"",
    ""lastName"": ""Lubowitz"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Perry"",
    ""lastName"": ""Kemmer"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Kaylah"",
    ""lastName"": ""Kohler"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Mona"",
    ""lastName"": ""Lockman"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Lee"",
    ""lastName"": ""Beatty"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Milo"",
    ""lastName"": ""Bailey"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Raleigh"",
    ""lastName"": ""Thiel"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Taryn"",
    ""lastName"": ""Dibbert"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Michelle"",
    ""lastName"": ""Bechtelar"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Beth"",
    ""lastName"": ""Gleichner"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Carmella"",
    ""lastName"": ""Shanahan"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Telly"",
    ""lastName"": ""O'Reilly"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Zion"",
    ""lastName"": ""Renner"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Landen"",
    ""lastName"": ""Doyle"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Callie"",
    ""lastName"": ""Hintz"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Francesca"",
    ""lastName"": ""Welch"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Ara"",
    ""lastName"": ""Morissette"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Lionel"",
    ""lastName"": ""McClure"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Rachael"",
    ""lastName"": ""Sauer"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Aimee"",
    ""lastName"": ""Kunze"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Kaia"",
    ""lastName"": ""Waelchi"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Sage"",
    ""lastName"": ""Tromp"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Brice"",
    ""lastName"": ""Schaden"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Vincenza"",
    ""lastName"": ""Prosacco"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Gay"",
    ""lastName"": ""O'Conner"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Franz"",
    ""lastName"": ""Emard"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Lincoln"",
    ""lastName"": ""Hoppe"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Misael"",
    ""lastName"": ""Leuschke"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Alexis"",
    ""lastName"": ""Walsh"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Ima"",
    ""lastName"": ""Veum"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Theresia"",
    ""lastName"": ""Kub"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Devan"",
    ""lastName"": ""Lubowitz"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Eleazar"",
    ""lastName"": ""Stokes"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Lilian"",
    ""lastName"": ""Gleason"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Esteban"",
    ""lastName"": ""Rolfson"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Leonora"",
    ""lastName"": ""Kunde"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Chance"",
    ""lastName"": ""Will"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Evangeline"",
    ""lastName"": ""Reichel"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Sheila"",
    ""lastName"": ""Weimann"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Vena"",
    ""lastName"": ""Murazik"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Jess"",
    ""lastName"": ""Torphy"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Xzavier"",
    ""lastName"": ""Mosciski"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Magali"",
    ""lastName"": ""Boehm"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Helmer"",
    ""lastName"": ""Frami"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""King"",
    ""lastName"": ""Ondricka"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }},
  {{
    ""firstName"": ""Kimberly"",
    ""lastName"": ""Fadel"",
    ""bonusRate"": 0,
    ""salary"": 0,
    ""start"": ""0001-01-01T00:00:00"",
    ""title"": """"
  }}
]
";
}

/*

 [
  {
    "firstName": "Mike",
    "lastName": "Miller",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Anthony",
    "lastName": "Miller",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Ryan",
    "lastName": "Miller",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Halie",
    "lastName": "Hayes",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Sonya",
    "lastName": "Koss",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Blanche",
    "lastName": "Frami",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Olga",
    "lastName": "Mann",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Karine",
    "lastName": "Lubowitz",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Perry",
    "lastName": "Kemmer",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Kaylah",
    "lastName": "Kohler",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Mona",
    "lastName": "Lockman",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Lee",
    "lastName": "Beatty",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Milo",
    "lastName": "Bailey",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Raleigh",
    "lastName": "Thiel",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Taryn",
    "lastName": "Dibbert",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Michelle",
    "lastName": "Bechtelar",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Beth",
    "lastName": "Gleichner",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Carmella",
    "lastName": "Shanahan",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Telly",
    "lastName": "O'Reilly",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Zion",
    "lastName": "Renner",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Landen",
    "lastName": "Doyle",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Callie",
    "lastName": "Hintz",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Francesca",
    "lastName": "Welch",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Ara",
    "lastName": "Morissette",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Lionel",
    "lastName": "McClure",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Rachael",
    "lastName": "Sauer",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Aimee",
    "lastName": "Kunze",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Kaia",
    "lastName": "Waelchi",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Sage",
    "lastName": "Tromp",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Brice",
    "lastName": "Schaden",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Vincenza",
    "lastName": "Prosacco",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Gay",
    "lastName": "O'Conner",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Franz",
    "lastName": "Emard",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Lincoln",
    "lastName": "Hoppe",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Misael",
    "lastName": "Leuschke",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Alexis",
    "lastName": "Walsh",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Ima",
    "lastName": "Veum",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Theresia",
    "lastName": "Kub",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Devan",
    "lastName": "Lubowitz",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Eleazar",
    "lastName": "Stokes",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Lilian",
    "lastName": "Gleason",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Esteban",
    "lastName": "Rolfson",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Leonora",
    "lastName": "Kunde",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Chance",
    "lastName": "Will",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Evangeline",
    "lastName": "Reichel",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Sheila",
    "lastName": "Weimann",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Vena",
    "lastName": "Murazik",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Jess",
    "lastName": "Torphy",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Xzavier",
    "lastName": "Mosciski",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Magali",
    "lastName": "Boehm",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Helmer",
    "lastName": "Frami",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "King",
    "lastName": "Ondricka",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  },
  {
    "firstName": "Kimberly",
    "lastName": "Fadel",
    "bonusRate": 0,
    "salary": 0,
    "start": "0001-01-01T00:00:00",
    "title": ""
  }
]
 */