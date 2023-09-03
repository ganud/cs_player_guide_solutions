// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Souptype type = Souptype.soup;
MainIngredients ingredient = MainIngredients.mushrooms;
Seasonings seasoning = Seasonings.spicy;

var Soup = (type, ingredient, seasoning);


enum Souptype
{
    soup,
    stew,
    gumbo,
}

enum MainIngredients
{
    mushrooms,
    chicken,
    carrots,
    potatoes,
}

enum Seasonings
{
    spicy,
    salty,
    sweet,
}