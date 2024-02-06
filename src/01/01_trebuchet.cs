using System.Linq;

namespace AdventOfCode {
    
    static public partial class AdventOfCode {
        /* --- Day 1: Trebuchet?! ---

        Something is wrong with global snow production, and you've been selected to take a look. The Elves have even given you a map; on it, they've used stars to mark the top fifty locations that are likely to be having problems.
        You've been doing this long enough to know that to restore snow operations, you need to check all fifty stars by December 25th.

        Collect stars by solving puzzles. Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!

        You try to ask why they can't just use a weather machine ("not powerful enough") and where they're even sending you ("the sky") and why your map looks mostly blank ("you sure ask a lot of questions") and hang on did you just say the sky ("of course, where do you think snow comes from") when you realize that the Elves are already loading you into a trebuchet ("please hold still, we need to strap you in").

        As they're making the final adjustments, they discover that their calibration document (your puzzle input) has been amended by a very young Elf who was apparently just excited to show off her art skills. Consequently, the Elves are having trouble reading the values on the document.

        The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover. On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.

        For example:

        1abc2
        pqr3stu8vwx
        a1b2c3d4e5f
        treb7uchet

        In this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.

        Consider your entire calibration document. What is the sum of all of the calibration values?
        */
        static public void Day01() {
                Console.WriteLine("Day 01.");
                var document = File.ReadLines(@"D:\Repos\adventOfCode\src\01\01_trebuchet.txt");

                Console.WriteLine(document);

                int sum = 0;
                foreach ( var line in document) {
                    Console.WriteLine($"current line: {line}");
                    int firstDigit = -1;
                    int secondDigit = -1;
                    int left = 0;
                    int right = line.Length - 1;
                    while (firstDigit < 0 || secondDigit < 0) {
                        if (firstDigit < 0 && Char.IsDigit(line[left])) firstDigit = (int)Char.GetNumericValue( line[left]);
                        if (secondDigit < 0 && Char.IsDigit(line[right])) secondDigit = (int)Char.GetNumericValue(line[right]);

                        if (firstDigit < 0)left++;
                        if (secondDigit < 0)right--;
                    }
                    Console.WriteLine($"found digits: {firstDigit} {secondDigit}");
                    int value = Convert.ToInt32($"{firstDigit}{secondDigit}");
                    Console.WriteLine(value);
                    sum += value;
                }

                Console.WriteLine($"The resulting sum is {sum}");
        }
        /*
        --- Part Two ---

        Your calculation isn't quite right. It looks like some of the digits are actually spelled out with letters: one, two, three, four, five, six, seven, eight, and nine also count as valid "digits".

        Equipped with this new information, you now need to find the real first and last digit on each line. For example:

        two1nine
        eightwothree
        abcone2threexyz
        xtwone3four
        4nineeightseven2
        zoneight234
        7pqrstsixteen

        In this example, the calibration values are 29, 83, 13, 24, 42, 14, and 76. Adding these together produces 281.

        What is the sum of all of the calibration values?
        */

        static public void Day01_2() {
            Console.WriteLine("Day 01 - Part 2");

            var document = File.ReadLines(@"D:\Repos\adventOfCode\src\01\01_trebuchet.txt");
            int sum = 0;

            Console.WriteLine("... finding digits ...");
            foreach (var line in document) {
                int left = 0;
                int right = line.Length - 1;

                int firstDigit = -1;
                int secondDigit = -1;

                while (firstDigit < 0 || secondDigit < 0) {
                    if (firstDigit < 0) {
                        if (char.IsDigit(line[left]))
                        {
                            firstDigit = (int)Char.GetNumericValue(line[left]);
                        }
                        else {
                            int foundDigit = FindDigitInSubstring(line, left);
                            if (foundDigit >= 0) firstDigit = foundDigit;
                        }
                    }
                    if (secondDigit < 0) {
                        if (Char.IsDigit(line[right]))
                        {
                            secondDigit = (int)Char.GetNumericValue(line[right]);
                        }
                        else {
                            int foundDigit = FindDigitInSubstring(line, right);
                            if (foundDigit >= 0) secondDigit = foundDigit;
                        }
                    }


                    if (firstDigit < 0)left++;
                    if (secondDigit < 0)right--;
                }
                int value = Convert.ToInt32($"{firstDigit}{secondDigit}");
                Console.WriteLine($"Found value: {value}");
                sum += value;
                Console.WriteLine($"sum: {sum}");
            }

            Console.WriteLine($"... Finished.");
            Console.WriteLine($"Final sum: {sum}");
            Console.WriteLine("... End of program.");
        }

        private static int FindDigitInSubstring(string line, int start) {
            foreach(var digit in Digit.GetValues(typeof(Digit))) {
                int len = digit.ToString().Length;
                if (start + len > line.Length) continue;
                var sub = line.Substring(start, len);
                try {
                    Digit myEnum = (Digit)Enum.Parse(typeof(Digit), sub);
                    return (int)myEnum;
                } catch(Exception e) {
                    continue;
                }
            }

            return -1;

        }

    }
    public enum Digit{
        zero,
        one, 
        two , 
        three, 
        four, 
        five, 
        six, 
        seven, 
        eight, 
        nine
    }
    
}


