# 🧠 Explicació de `Program.cs`

L'arxiu `Program.cs` és el nucli del projecte. Funciona com una guia pràctica que demostra l'ús de les principals col·leccions de C#, dividida en **4 blocs** ben diferenciats. Cada bloc primer mostra el concepte amb tipus simples (strings, enters) i després ho repeteix amb objectes `Pokemon` per fer-ho més concret.

---

## 🔵 Bloc 1 — `List<T>` (línies 12–46)

Una `List<T>` és una col·lecció **ordenada que permet duplicats** i accés per índex.

### Amb strings

Es crea una llista d'usuaris amb 4 noms inicials:

```csharp
List<string> listUsers = new() { "Dani", "Alba", "Lucas", "Itziar" };
```

Després es realitzen diverses operacions:

| Operació | Mètode | Resultat |
|---|---|---|
| Afegir al final | `Add("Tomás")` | `["Dani", "Alba", "Lucas", "Itziar", "Tomás"]` |
| Eliminar per valor | `Remove("Dani")` | `["Alba", "Lucas", "Itziar", "Tomás"]` |
| Eliminar per posició | `RemoveAt(0)` | `["Lucas", "Itziar", "Tomás"]` |
| Inserir en posició | `Insert(0, "Dani")` | `["Dani", "Lucas", "Itziar", "Tomás"]` |
| Buidar la llista | `Clear()` | `[]` |

S'itera amb `foreach` per imprimir cada usuari, i dins del bucle es comprova si l'usuari actual és "Lucas". Abans de buidar la llista, s'usa `Contains("Dani")` per verificar si encara existeix (no hi és, perquè va ser eliminat).

### Amb objectes `Pokemon`

Es crea una `List<Pokemon>` i s'afegeixen Bulbasaur i Pikachu. Es demostra:
- `Contains(pikachu)` → comprova si un objecte concret és a la llista comparant per referència.
- `Find(lambda)` → cerca Bulbasaur pel seu nom usant una expressió lambda. Retorna `null` si no el troba, d'aquí el tipus `Pokemon?`.

```csharp
Pokemon? bulbasaur = pokemons.Find(pokemon => pokemon.Name.Equals("Bulbasaur"));
```

---

## 🟡 Bloc 2 — `Dictionary<TKey, TValue>` (línies 54–102)

Un `Dictionary` és una col·lecció de parells **clau → valor**. Les claus són úniques i permeten accés directe al valor en temps constant O(1).

### Amb strings

Es crea un diccionari que simula una agenda amb DNI com a clau i nom com a valor:

```csharp
Dictionary<int, string> usersDNI = new()
{
    { 111, "Daniel Moreno" },
    { 222, "Alba Sanchez" }
};
```

Operacions demostrades:

| Operació | Codi | Efecte |
|---|---|---|
| Afegir | `Add(333, "Manolito Bakery")` | Nou parell clau-valor |
| Modificar | `usersDNI[111] = "Pepito los palotes"` | Sobreescriu el valor de la clau 111 |
| Eliminar | `Remove(333)` | Elimina l'entrada amb clau 333 |

Per **cercar** un valor, es mostren dues formes:

- **Opció 1 — `ContainsKey`**: primer comprova si la clau existeix i després accedeix al valor. Pot llançar una excepció si s'accedeix directament a una clau inexistent.
- **Opció 2 — `TryGetValue`**: més segura, retorna `false` si la clau no existeix en lloc de llançar una excepció, i assigna el valor al `out` si la troba.

```csharp
// Opció 1
if (usersDNI.ContainsKey(key))
    Console.WriteLine(usersDNI[key]);

// Opció 2 (recomanada)
if (usersDNI.TryGetValue(222, out string nameUser))
    Console.WriteLine(nameUser);
```

Per **iterar**, es mostren també dues formes:

```csharp
// Opció 1 — KeyValuePair explícit
foreach (KeyValuePair<int, string> user in usersDNI)
    Console.WriteLine($"{user.Key} → {user.Value}");

// Opció 2 — Desestructuració (més neta)
foreach (var (dni, name) in usersDNI)
    Console.WriteLine($"{dni} → {name}");
```

### Amb objectes `Pokemon`

Es crea un `Dictionary<int, Pokemon>` usant l'ID com a clau. S'itera amb desestructuració per imprimir l'ID, nom i tipus de cada Pokémon, i s'afegeix Ninetales al final.

---

## 🟢 Bloc 3 — `HashSet<T>` (línies 109–192)

Un `HashSet<T>` és una col·lecció **sense duplicats i sense ordre garantit**. És ideal quan el que importa és saber si un element existeix, no la seva posició.

### Amb strings

Es crea un set de tecnologies:

```csharp
HashSet<string> techList = new() { "C#", "Python", "Java" };
```

Es demostren dos intents d'afegir:
- `techList.Add("Java")` → retorna `false`, ja existeix.
- `techList.Add("JAVA")` → retorna `true`, és case-sensitive i es tracta com un element diferent.

Després es mostren les **4 operacions de conjunts** (àlgebra de conjunts):

| Operació | Mètode | Què fa |
|---|---|---|
| Intersecció | `IntersectWith(altre)` | Es queda només amb els elements que estan en **tots dos** sets |
| Unió | `Union(altre)` | Retorna tots els elements de tots dos **sense repetir** (atenció: no modifica el set original) |
| Diferència | `ExceptWith(altre)` | Elimina del set els elements que **també estan** a l'altre |
| Diferència simètrica | `SymmetricExceptWith(altre)` | Es queda amb els elements que estan en **només un** dels dos sets, no en tots dos |

> ⚠️ **Nota important**: al codi, `Union` es crida però no s'assigna el resultat, de manera que `techList2` no es modifica. Això és un comportament a tenir en compte: `Union` retorna un nou `IEnumerable`, a diferència de `IntersectWith`, `ExceptWith` i `SymmetricExceptWith` que sí modifiquen el set original.

### Amb objectes `Pokemon`

Es crea una pokedex amb Pikachu, Charmander i Bulbasaur. Després s'aplica `ExceptWith` amb un segon set que conté Pikachu i Bulbasaur, deixant només Charmander a la pokedex.

---

## 🟣 Bloc 4 — `Tuple` (línies 199–254)

Una tupla permet **agrupar diversos valors en una sola variable** sense necessitat de crear una classe. Són lleugeres i útils per a retorns múltiples.

### Tuples simples

Es mostra la diferència entre tupla **sense nom** (accés per `Item1`, `Item2`...) i **amb nom** (accés per nom de camp):

```csharp
// Sense nom — menys llegible
var trainerData = (1, "Ash", 16);
Console.WriteLine(trainerData.Item1); // 1

// Amb nom — més llegible
var pokemonData = (Id: 1, Name: "Mew", Damage: 50);
Console.WriteLine(pokemonData.Name); // "Mew"
```

### Retorn múltiple des de mètodes

Es comparen dos estils per retornar diversos valors des d'un mètode que calcula la suma i el producte de dos nombres:

```csharp
// ✅ PRO MODE — retorna una tupla amb nom
public static (int sum, int product) CalculateData(int a, int b)
{
    return (a + b, a * b);
}

// ❌ NEWIE MODE — usa paràmetres out (més verbós i antic)
public static void CalculateData(int a, int b, out int sum, out int product)
{
    sum = a + b;
    product = a * b;
}
```

I es mostren dues formes de consumir el resultat de la versió "Pro":

```csharp
// Opció 1 — accedir per nom de camp
var result = CalculateData(10, 20);
Console.WriteLine(result.sum);

// Opció 2 — desestructuració directa (més neta)
var (sum, product) = CalculateData(10, 20);
Console.WriteLine(sum);
```

### Amb objectes `Pokemon`

Es creen tuples de Pokémon amb i sense nom, i dues funcions locals (`GetStarterPokemon` i `GetPokemon`) que retornen una tupla `(Pokemon first, Pokemon second)`. Es crida `GetPokemon` per obtenir els starters i imprimir-los.

---

## 🗺️ Resum visual

```
Program.cs
│
├── 🔵 List<T>
│   ├── Amb strings → Add, Remove, RemoveAt, Insert, Clear, Contains
│   └── Amb Pokemon → Contains (per referència), Find (per lambda)
│
├── 🟡 Dictionary<TKey, TValue>
│   ├── Amb strings → Add, modificar, Remove, ContainsKey, TryGetValue, iteració x2
│   └── Amb Pokemon → Dictionary<int, Pokemon>, iteració amb desestructuració
│
├── 🟢 HashSet<T>
│   ├── Amb strings → Add, Contains, Remove, IntersectWith, Union, ExceptWith, SymmetricExceptWith
│   └── Amb Pokemon → HashSet<Pokemon>, ExceptWith entre pokedex
│
└── 🟣 Tuple
    ├── Tupla sense nom (Item1, Item2...)
    ├── Tupla amb nom (Id, Name...)
    ├── Retorn múltiple: PRO (tupla) vs NEWIE (paràmetres out)
    ├── Desestructuració de tuples
    └── Amb Pokemon → tuples d'objectes, funcions locals
```
