using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
// Jeffrey Nyberg
// Lab09
// 11/17/2026
// Snow Cinema - Movie Theater Manager
// Write TWO generic methods, then use them with different types.
// Answer to Question: I only used one version of InBoth. This is because of <T>, a placeholder data type so that the method can work with many types of data at once.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Snow Cinema ===");
        Console.WriteLine();

        // ===================== PART 1: Sold on Both Days (HashSet) =====================
        Console.WriteLine("===== Part 1: Sold on Both Days =====");

        List<string> fridayGenres = new List<string> { "Action", "Comedy", "Action", "Drama" };
        List<string> saturdayGenres = new List<string> { "Comedy", "Horror", "Action" };

        List<int> fridayScreens = new List<int> { 1, 3, 1, 2 };
        List<int> saturdayScreens = new List<int> { 1, 2, 4, 2 };

        // Done for you:
        HashSet<string> bothGenres = InBoth(fridayGenres, saturdayGenres);
        Console.Write("Genres: ");
        PrintSet(bothGenres);

        // TODO 3: Call InBoth with fridayScreens and saturdayScreens.
        //         Print the result with PrintSet.
        HashSet<int> Screenings = InBoth(fridayScreens,saturdayScreens);
        Console.Write("Screens: ");
        PrintSet(Screenings);



        // ===================== PART 2: Theater Records (Dictionary) =====================
        Console.WriteLine();
        Console.WriteLine("===== Part 2: Theater Records =====");

        // Movie title -> list of star ratings (done for you)
        Console.WriteLine("-- Customer ratings --");
        Dictionary<string, List<int>> ratings = new Dictionary<string, List<int>>();
        ratings = AddToGroup(ratings, "Space Race", 5);
        ratings = AddToGroup(ratings, "Ocean Quest", 3);
        ratings = AddToGroup(ratings, "Space Race", 4);
        PrintGroups(ratings);

        // The KEY is a tuple (movie, showtime) -> list of booked seat numbers
        Console.WriteLine("-- Seat bookings --");
        Dictionary<(string, string), List<int>> bookings = new Dictionary<(string, string), List<int>>();
        // TODO 4: Use AddToGroup to add these, then print with PrintGroups:
        bookings = AddToGroup(bookings, ("Space Race", "4:00 PM"), 12);
        bookings = AddToGroup(bookings, ("Space Race", "7:00 PM"), 5);
        bookings = AddToGroup(bookings, ("Space Race", "4:00 PM"), 13);
        PrintGroups(bookings);
        //   ("Space Race", "4:00 PM") -> seat 12
        //   ("Space Race", "7:00 PM") -> seat 5
        //   ("Space Race", "4:00 PM") -> seat 13


        // ===================== PART 3: Counts =====================
        Console.WriteLine();
        Console.WriteLine("===== Part 3: Counts =====");

        // Done for you:
        Console.WriteLine("Ratings for Space Race: " + CountInGroup(ratings, "Space Race"));
        Console.WriteLine("Seats at Space Race 7:00 PM: " + CountInGroup(bookings, ("Space Race", "7:00 PM")));

        // TODO 5 (part b): Call CountInGroup to print how many seats are booked
        //                  for ("Ocean Quest", "4:00 PM").
        // Print: Seats at Ocean Quest 4:00 PM: 0
        Console.WriteLine("Seats at Ocean Quest 4:00 PM: " + CountInGroup(bookings, ("Ocean Quest", "4:00 PM")));
    }

    // ===================== YOUR METHODS =====================
    // The program will NOT build until you write all three methods.

    // TODO 1: Write the InBoth method.
    // Takes in:   two Lists of any type T
    // Gives back: a HashSet of type T with the items that are in BOTH lists
    // Fill in the blanks:
    //   static __________ InBoth<T>(__________ first, __________ second)
    // Hint: copy the first list into a new HashSet, then use IntersectWith.

    public static HashSet<T> InBoth<T>(List<T> first, List<T> second)
    {
        HashSet<T> GenresCopied = new HashSet<T>(first);
        GenresCopied.IntersectWith(second);
        return GenresCopied;
        // Note: We definetly need to review this more in class.
    }

    // TODO 2: Write the AddToGroup method.
    // Takes in:   a Dictionary (key type TKey, value is a List of TValue),
    //             a key of type TKey, and a value of type TValue
    // Gives back: the same Dictionary
    // Fill in the blanks:
    //   static __________ AddToGroup<TKey, TValue>(__________ groups, __________ key, __________ value)
    // Hint: if the key is NOT there (ContainsKey), add it with a new empty list.
    //       Then Add the value to that key's list.

// We also need to review this. I had no idea how it was supposed to be formatted and I had to resort to looking it up :(
    public static Dictionary<TKey, List<TValue>> AddToGroup<TKey, TValue>(Dictionary<TKey, List<TValue>> groups, TKey key, TValue value)
    {
        if (groups.ContainsKey(key) == false)
        {
            groups[key] = new List<TValue>();
        }
        groups[key].Add(value);
        return groups;
    }

    // TODO 5 (part a): Write the CountInGroup method.
    // Takes in:   a Dictionary (key type TKey, value is a List of TValue),
    //             and a key of type TKey
    // Gives back: an int, how many values are in that key's list
    //             (0 if the key is not in the dictionary)
    // Fill in the blanks:
    //   static __________ CountInGroup<TKey, TValue>(__________ groups, __________ key)
    // Hint: use ContainsKey, then the list's Count.

    public static int CountInGroup<TKey, TValue>(Dictionary<TKey, List<TValue>> groups, TKey key)
    {
        if (groups.ContainsKey(key) == false) {return 0;}
        else {return groups[key].Count;}
    }





    // ===================== Helpers (already done, do not change) =====================

    static void PrintSet<T>(HashSet<T> set)
    {
        Console.WriteLine("{ " + string.Join(", ", set) + " }");
    }

    static void PrintGroups<TKey, TValue>(Dictionary<TKey, List<TValue>> groups)
    {
        foreach (var (key, list) in groups)
        {
            Console.WriteLine(key + " -> " + string.Join(", ", list));
        }
    }
}
