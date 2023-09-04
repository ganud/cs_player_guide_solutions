// Declarations
Souptype type = Souptype.Soup;
MainIngredients ingredient = MainIngredients.Mushrooms;
Seasonings seasoning = Seasonings.Spicy;


getSoupType();
getMainIngredients();
getSeasonings();
// Tuple of the soup
var Soup = (type, ingredient, seasoning);
Console.WriteLine($"{seasoning} {ingredient} {type}");
void getSoupType()
{
    Console.WriteLine("Select a soup type: soup, stew, or gumbo");
    string input = Console.ReadLine();
    Console.Clear();
    switch (input)
    {
        case "soup":
            type = Souptype.Soup;
            break;
        case "stew":
            type = Souptype.Stew;
            break;
        case "gumbo":
            type = Souptype.Gumbo;
            break;
        default:
            Console.WriteLine("Invalid soup type");
            getSoupType();
            break;
        
    }
}

void getMainIngredients()
{
    Console.WriteLine("Select from the ingredients: mushrooms, chicken, carrots, or potatoes");
    string input = Console.ReadLine();
    Console.Clear();
    switch (input)
    {
        case "mushrooms":
            ingredient = MainIngredients.Mushrooms;
            break;
        case "chicken":
            ingredient = MainIngredients.Chicken;
            break;
        case "carrots":
            ingredient = MainIngredients.Carrots;
            break;
        case "potatoes":
            ingredient = MainIngredients.Potatoes;
            break;
        default:
            Console.WriteLine("Invalid ingredient");
            getMainIngredients();
            break;

    }
}

void getSeasonings()
{
    Console.WriteLine("Select from the seasonings: spicy, salty, or sweet");
    string input = Console.ReadLine();
    Console.Clear();
    switch (input)
    {
        case "spicy":
            seasoning = Seasonings.Spicy;
            break;
        case "salty":
            seasoning = Seasonings.Salty;
            break;
        case "sweet":
            seasoning = Seasonings.Sweet;
            break;
        default:
            Console.WriteLine("Invalid seasoning");
            getSeasonings();
            break;

    }
}
enum Souptype
{
    Soup,
    Stew,
    Gumbo,
}

enum MainIngredients
{
    Mushrooms,
    Chicken,
    Carrots,
    Potatoes,
}

enum Seasonings
{
    Spicy,
    Salty,
    Sweet,
}