// See https://aka.ms/new-console-template for more information
int[] arr1 = new int[5];
for (int i = 0; i < arr1.Length; i++)
{
    Console.WriteLine("Enter a number:");
    arr1[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Array 1 contents : " + string.Join(",", arr1));

int[] arr2 = new int[5];
for (int i =0; i < arr2.Length; i++)
{
    arr2[i] = arr1[i];
}

Console.WriteLine("Array 2 contents : " + string.Join(",", arr2));