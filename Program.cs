using UseCollections.Core.Enums;
using UseCollections.Core.Models;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(new string('*', 20));
        Console.WriteLine("Using list");
        Console.WriteLine(new string('*', 20));

        List<string> listUsers = new() { "Dani", "Alba", "Lucas", "Itziar" };

        listUsers.Add("Tomás"); //Add an element to the end of the list
        listUsers.Remove("Dani"); //Remove an element from the list. "Dani" will be removed and "Alba" will be the first element of the list
        listUsers.RemoveAt(0); // Remove at postion element of the list. "Lucas" will be the firs element after the removal

        // Iterate over the list and print each user
        foreach (string user in listUsers)
        {
            if(user.Equals("Lucas")) Console.WriteLine("Lucas is in the list");

            Console.WriteLine(user);
        }

        Console.WriteLine(listUsers.Contains("Dani") ? "Dani is in the list" : "He is not here!");

        listUsers.Insert(0, "Dani"); // Insert an element at a specific position in the list. "Dani" will be the first element of the list again

        listUsers.Clear(); // Clear the list, removing all elements

        //With objects

        List<Pokemon> pokemons = new List<Pokemon>();
        
        pokemons.Add(new Pokemon(1, "Bulbasaur", PokemonType.Grass));

        Pokemon pikachu = new Pokemon(2, "Pikachu", PokemonType.Electric);

        pokemons.Add(pikachu);

        Console.WriteLine(pokemons.Contains(pikachu) ? "Pikachu is in the list" : "He is not here!");

        Pokemon? bulbasaur = pokemons.Find(pokemon => pokemon.Name.Equals("Bulbasaur"));

        Console.WriteLine(bulbasaur != null ? "Bulbasaur is in the list" : "Bulbasaur is not here!");


        Console.WriteLine(new string('*', 20));
        Console.WriteLine("Using dictionaries");
        Console.WriteLine(new string('*', 20));

        //Create a dictionary key-value
        Dictionary<int, string> usersDNI = new()
        {
            {111, "Daniel Moreno" },
            {222, "Alba Sanchez" }
        };

        
        usersDNI.Add(333, "Manolito Bakery"); //Add user
        usersDNI[111] = "Pepito los palotes"; //Modify value
        usersDNI.Remove(333); //Remove user by key

        int key = 111;

        //Search user by key option 1
        if (usersDNI.ContainsKey(key))
        {
            Console.WriteLine($"El usuario con DNI {key} se llama {usersDNI[key]}");
        }

        //Search user by key option 2
        if (usersDNI.TryGetValue(222, out string nameUser)){
            Console.WriteLine($"El usuario con DNI {222} se llama {nameUser}");
        }

        //Iterate the dictionary option 1
        foreach(KeyValuePair<int, string> user in usersDNI)
        {
            Console.WriteLine($"Usuario con DNI: {user.Key}, y nombre {user.Value}");
        }

        //Iterate the dictionary option 2
        foreach (var (dni,name) in usersDNI)
        {
            Console.WriteLine($"Usuario con DNI: {dni}, y nombre {name}");
        }

        //With objects
        Dictionary<int, Pokemon> listPokemons = new() {
            { 1 , pikachu },
            { 2 , new Pokemon(2,"Charmander", PokemonType.Fire)},
            { 3 , bulbasaur }
        };

        foreach( var (id, pokemon) in listPokemons)
        {
            Console.WriteLine($"ID: {id} - Pokemon: {pokemon.Name} - Type: {pokemon.Type}");
        }

        listPokemons.Add(4, new Pokemon(2, "Ninetales", PokemonType.Fire));

        Console.WriteLine(new string('*', 20));
        Console.WriteLine("Using Set");
        Console.WriteLine(new string('*', 20));

        //Create the set
        HashSet<string> techList = new() { "C#", "Python", "Java" };

        //Add element, return false if we can't add it.
        Console.WriteLine($"Can I add Java?: {techList.Add("Java")}");
        Console.WriteLine($"Can I add JAVA?: {techList.Add("JAVA")}");

        //Check if the elements exists
        Console.WriteLine($"Is C# in the set? : {techList.Contains("C#")}");

        //Remove elements
        techList.Remove("Pyhton");

        //Iterate a HashSet (Not order guaranted!!!)
        foreach(string tech in techList)
        {
            Console.WriteLine(tech);
        }

        //Intersection (Common elements)
        HashSet<string> techList2 = new() { "Python", "Java", "C", "C++", "Scratch" };

        Console.WriteLine("Intersection (Common elements)");
        techList.IntersectWith(techList2);

        foreach (string tech in techList)
        {
            Console.WriteLine(tech);
        }

        //Union (All elements without repeat)
        HashSet<string> techList3 = new() { "C", "C++", "Scratch" };

        Console.WriteLine("Union (All elements without repeat)");
        techList2.Union(techList3);

        foreach (string tech in techList2)
        {
            Console.WriteLine(tech);
        }

        //Difference (Elements in the first set and Not in the second set)
        HashSet<string> techList4 = new() { "C", "C++", "Scratch", ".NET", "Python" };
        HashSet<string> techList5 = new() { "C", "C++", "Scratch" };
        
        techList4.ExceptWith(techList5);

        Console.WriteLine("Difference (Elements in the first set and Not in the second set)");
        foreach (string tech in techList4)
        {
            Console.WriteLine(tech);
        }

        //Symmetric difference (Elemments not in both sets at the same time)
        HashSet<string> techList6 = new() { "C", "C++", "Scratch", ".NET", "Python" };
        HashSet<string> techList7 = new() { "C", "C++", "Scratch", ".NET" };

        techList6.SymmetricExceptWith(techList7);

        Console.WriteLine("Symmetric difference (Elemments not in both sets at the same time)");
        foreach (string tech in techList6)
        {
            Console.WriteLine(tech);
        }


        //With objects

        HashSet<Pokemon> pokedex = new() { pikachu, new Pokemon(2, "Charmander", PokemonType.Fire), bulbasaur };

        Console.WriteLine($"Pokemons in pokedex");
        foreach (Pokemon pokemon in pokedex)
        {
            Console.WriteLine($"Pokemon name: {pokemon.Name}");
        }

        HashSet<Pokemon> listPokedex2 = new() { pikachu, bulbasaur };

        pokedex.ExceptWith(listPokedex2);

        Console.WriteLine($"Pokemons in pokedex afert difference");
        foreach (Pokemon pokemon in pokedex)
        {
            Console.WriteLine($"Pokemon name: {pokemon.Name}");
        }

        Console.WriteLine(new string('*', 20));
        Console.WriteLine("Using Tuple");
        Console.WriteLine(new string('*', 20));

        //Without name
        var trainerData = ( 1, "Ash", 16 );

        Console.WriteLine($"ID: {trainerData.Item1}, Name: {trainerData.Item2}, Years: {trainerData.Item3}");

        //With name
        var pokemonData = (Id: 1, Name: "Mew", Damage: 50);

        Console.WriteLine($"ID: {pokemonData.Id}, Name: {pokemonData.Name}, Damage: {pokemonData.Damage}");

        var dataToCalc = (valueA: 10, valueB: 20);

        var resultCalcFixed = CalculateData(2, 3);
        
        //Usint the tuple option 1 (pro mode)
        var resultCalc = CalculateData(dataToCalc.valueA, dataToCalc.valueB);

        Console.WriteLine($"The sum is: {resultCalc.sum} and the product: {resultCalc.product}");

        //Usint the tuple option 2 (pro mode ++)
        var (sumNumbers, productNumbers) = CalculateData(dataToCalc.valueA, dataToCalc.valueB);

        Console.WriteLine($"The sum is: {sumNumbers} and the product: {productNumbers}");


        //NEWIE MODE
        int sum = 0, product = 0;

        CalculateData(10, 20, out sum, out product);

        Console.WriteLine($"The sum is: {sum} and the product: {product}");

        //With objects

        var pokemonsStart = (pikachu, bulbasaur);

        var pokemonsStartName = (pokemon1: pikachu, pokemon2: bulbasaur); 

        Console.WriteLine($"First pokemon {pokemonsStart.pikachu.Name} - Second pokemon {pokemonsStart.bulbasaur.Name}");
        Console.WriteLine($"First pokemon {pokemonsStartName.pokemon1.Name} - Second pokemon {pokemonsStartName.pokemon2.Name}");

        (Pokemon first, Pokemon second) GetStarterPokemon()
        {
            return (pikachu, bulbasaur);
        }

        (Pokemon first, Pokemon second) GetPokemon()
        {
            Pokemon charmander = new Pokemon(1, "Charmander", PokemonType.Fire);
            Pokemon bulbasaur = new Pokemon(1, "Bulbasaur", PokemonType.Grass);

            return (charmander, bulbasaur);
        }

        var starters = GetPokemon();

        Console.WriteLine($"This are your first pokemons: \n First Pokemon: {starters.first.Name} \n Second Pokemon: {starters.second.Name}");

    }

    //PRO MODE
    public static (int sum, int product) CalculateData(int a, int b)
    {
        return (a + b, a * b);
    }

    //NEWIE MODE
    public static void CalculateData(int a, int b, out int sum, out int product)
    {
        sum = a + b;
        product = a * b;
    }

}