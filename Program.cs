using System;
using System.Linq;
using System.Text;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            TestExercise4();
            
        }

        private static void TestExercise4()
        {   
            // A = 0
            // L = 11
            // H = 7
            // L H = (18) - 
            string key = "ZIMA";
            string plaintext = "SLUNECNEATEPLEPOCASICTVRTKEMPROZATIMKONCIVNASLEDUJICICHDVOUDNECHSEZATAHNEVETSINUUZEMIZASAHNEDESTNAHORACHANASEVEROVYCHODEVEVSECHPOLOHACHSNIHOVIKENDUBUDEPOLOJASNOTEPLOTYVNOCIKLESNOUPODNULUPRESDENBUDEMAXIMALNESESTSTUPNU";
            string groundTrueCipherText = "RTGNDKZEZBQPKMBOBIEIBBHRSSQMOZAZZBUMJWZCHDZARTQDTRUCHKTDUWGDMMOHRMLASITNDDQTRQZUTHQMHHMSZPZECMETMITOQIOHZVMSDDQRNDKCGWPEUMHSDKTPNTAHZKTSMQTOUQWEMLGBTLQPNTAJZAZOSMBLNBKVMWOIJTQSMWGPNLZUKCBRDAPEMJGDDUMXHUMLMMEERBETTXZU";
            string cipherText = VigenerCipherEncrypt(plaintext,key);

            if(cipherText.Equals(groundTrueCipherText))
            {
                Console.WriteLine("SUCCESS");
            }
        }

        private static string VigenerCipherEncrypt(string plaintext, string key)
        {
            StringBuilder cipherText = new StringBuilder();

            for (int i = 0; i < plaintext.Length; i++)
            {
                int letterIndex = i % key.Length;
                // keyMappedToText.Append(key.ElementAt(letterIndex));

                int keyLetterIndex = (int)key.ElementAt(letterIndex) - 'A';
                int textLetterIndex = (int)plaintext.ElementAt(i) - 'A';
                int cipherLetterIndex = (keyLetterIndex + textLetterIndex) % 26;
                char cipherLetter = (char)('A' + cipherLetterIndex);
                cipherText.Append(cipherLetter);

            }
            
            return cipherText.ToString();
        }

        private static void TestExercise3()
        {
            int n;
            formPermut permutationGenerator = new formPermut();
            char[] arr2 = new char[] { 'A', 'B', 'C' };
            var alphabet = Enumerable.Range('A', 26).Select(n => (char)n);
        
            n = 26;    

            permutationGenerator.FindRandomPermutation(alphabet.ToArray(),n);
            
            foreach(var item in alphabet)
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();
            foreach(var item in permutationGenerator.randomCharPermutation)
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine();

            var cipherAlphabet = permutationGenerator.randomCharPermutation.ToArray();
            string plaintext = "AHOJTOHLEJETAJNAZPRAVA";
            string cipherText = SubstitutionCipherEncrypt(plaintext,cipherAlphabet);
            Console.WriteLine("Plain: " + plaintext);
            Console.WriteLine("Cipher: " + cipherText);
            Console.WriteLine();

            string plaintext2 = SubstitutionCipherDecrypt(cipherText,cipherAlphabet);
            Console.WriteLine("Cipher: " + cipherText);
            Console.WriteLine("Plain: " + plaintext2);
        }

        private static string SubstitutionCipherDecrypt(string cipherText, char[] cipherAlphabet)
        {
            if (!cipherText.All(Char.IsLetter))
                return ">> INVALID TEXT FORMAT << (only letters allowed)";

            var alphabet = Enumerable.Range('A', 26).Select(n => (char)n).ToArray();

            StringBuilder pt = new StringBuilder();
            foreach (var item in cipherText.ToUpper())
            {
                int cipherLetterIndex = Array.IndexOf(cipherAlphabet, item);
                char plainTextLetter = alphabet[cipherLetterIndex];
                pt.Append(plainTextLetter);
            }

            return pt.ToString();
        }

        private static string SubstitutionCipherEncrypt(string plaintext, char[] cipherAlphabet)
        {
            if (!plaintext.All(Char.IsLetter))
                return ">> INVALID PLAIN TEXT FORMAT << (only letters allowed)";

            StringBuilder ct = new StringBuilder();
            foreach (var item in plaintext.ToUpper())
            {
                int letterIndex = (int)item - 'A';
                char cipherLetter = cipherAlphabet[letterIndex];
                ct.Append(cipherLetter);
            }

            return ct.ToString();
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
