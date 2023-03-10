using System;
using System.Linq;
using System.Text;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            TestExercise3();
        }
        private static void TestExercise3()
        {

        }
        private static void TestExercise2()
        {
            String ciphertext = "LTTLQJHMHJSDSNUTRTHNZENAFYJQZRXPTSYWTQTZEIFOJOJONHMMJXQTOJXYJXYFQJGJEUJHSJKNWRFU" +
                "WTYTUWNUWFANQFXUJHNFQSNITUQSJPITUWTMQNEJHJHMWTRJYJSUTPFEIJPIDEEFIFYJSJPIJSFNSYJWSJYZMJXQTEPTS" +
                "YWTQZOJEIFSJSNAIFYFGFENPTRUWTRNYTAFSDHMMJXJQ";

            int alphabetsize = 26;
            for(int i = 1; i <= alphabetsize; i++)
            {
                String pt = CipherShiftDecrypt(ciphertext, i);
                Console.WriteLine("Key: " + i);
                Console.WriteLine("Plain: " + pt);
                Console.WriteLine();
                Console.WriteLine();
            }

            // Plain: GOOGLECHCENYNIPOMOCIUZIVATELUMSKONTROLOUZDAJEJEJICHHESLOJESTESTALEBEZPECNEFIRMAPROTOPRIPRAVILASPECIALNIDOPLNEKDOPROHLIZECECHROMETENPOKAZDEKDYZZADATENEKDENAINTERNETUHESLOZKONTROLUJEZDANENIVDATABAZIKOMPROMITOVANYCHHESEL
        }

        private static void TestExercise1()
        {
            String plaintext = "TeStahoj";
            int key = 8;
            String ciphertext = CipherShiftEncrypt(plaintext, key);
            Console.WriteLine("Plain: " + plaintext);
            Console.WriteLine("Cipher: " + ciphertext);

            String plaintext2 = CipherShiftDecrypt(ciphertext, key);
            Console.WriteLine("Cipher: " + ciphertext);
            Console.WriteLine("Plain: " + plaintext2);
        }

        private static string CipherShiftEncrypt(string plaintext, int key)
        {
            if (!plaintext.All(Char.IsLetter))
                return ">> INVALID PLAIN TEXT FORMAT << (only letters allowed)";

            StringBuilder cipherText_sb = new StringBuilder();
            foreach (var letter in plaintext.ToUpper())
            {
                char newLetter = letter;

                newLetter += (char)key;
                if (newLetter > 'Z')
                {
                    newLetter = (char)('A' + (char)(newLetter - 'Z' - 1));
                }
                cipherText_sb.Append(newLetter);
            }
            return cipherText_sb.ToString();
        }

        private static string CipherShiftDecrypt(string cipherText, int key)
        {
            StringBuilder planText_sb = new StringBuilder();
            foreach (var letter in cipherText)
            {
                char newLetter = letter;

                newLetter -= (char)key;
                if (newLetter < 'A')
                {
                    newLetter = (char)('Z' - (char)('A' - newLetter - 1));
                }
                planText_sb.Append(newLetter);
            }
            return planText_sb.ToString();
        }
    }
}
