// See https://aka.ms/new-console-template for more information
using Football_scores;

Console.WriteLine("Hello, World!");

int[] teamA = { 4, 5, 6 };
int[] teamB = { 1, 4, 7 };
Calculator calculator = new Calculator();

calculator.CalculateWinTie(teamA, teamB);
