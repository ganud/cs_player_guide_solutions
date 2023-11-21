
PotionType potion = PotionType.Water;
while (true)
{
    Console.WriteLine($"You have a {potion} Potion");
    Console.WriteLine($"Add an ingredient from \n1 - Stardust \n2 - Snake_Venom \n3 - Dragon_Breath \n4 - Shadow_Glass \n5 - Eyeshine_Gem");
    string choice = Console.ReadLine();
    if ( choice == "Complete")
    {
        Console.WriteLine($"Finished with a {potion} Potion");
        break;
    }
    Ingredients ingredients = choice switch
    {
        "1" => Ingredients.Stardust,
        "2" => Ingredients.Snake_Venom,
        "3" => Ingredients.Dragon_Breath,
        "4" => Ingredients.Shadow_Glass,
        "5" => Ingredients.Eyeshine_Gem,
    };

    potion = brewPotion(potion, ingredients);
    if (potion == PotionType.Ruined )
    {
        Console.WriteLine("Try again");
        potion = PotionType.Water;
    }
}
PotionType brewPotion(PotionType potion, Ingredients ingredient) {
    if (potion == PotionType.Water && ingredient == Ingredients.Stardust) { return PotionType.Elixer; }
    else if (potion == PotionType.Elixer && ingredient == Ingredients.Snake_Venom) { return PotionType.Poison; }
    else if (potion == PotionType.Elixer && ingredient == Ingredients.Dragon_Breath) { return PotionType.Flying; }
    else if (potion == PotionType.Elixer && ingredient == Ingredients.Shadow_Glass) { return PotionType.Invisibility; }
    else if (potion == PotionType.Elixer && ingredient == Ingredients.Eyeshine_Gem) { return PotionType.Night_Sight; }
    else if (potion == PotionType.Night_Sight && ingredient == Ingredients.Shadow_Glass) { return PotionType.Cloudy_Brew; }
    else if (potion == PotionType.Invisibility && ingredient == Ingredients.Eyeshine_Gem) { return PotionType.Cloudy_Brew; }
    else if (potion == PotionType.Cloudy_Brew && ingredient == Ingredients.Stardust) { return PotionType.Wraith; }
    else { return PotionType.Ruined; }
}


enum PotionType { Water, Elixer, Poison, Flying, Invisibility, Night_Sight, Cloudy_Brew, Wraith, Ruined}
enum Ingredients { Stardust, Snake_Venom, Dragon_Breath, Shadow_Glass, Eyeshine_Gem}

