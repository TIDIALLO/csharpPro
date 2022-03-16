using System.Diagnostics; // Trace
using System.IO; // File
using System.Numerics; // BigInteger

namespace Packt.Shared;
public static class NumbersToWords 
{
    private static string[] smallNumbers = new string[]{
        "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
        "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
        "sixteen", "seventeen", "eighteen", "nineteen"
    };
    // Tens number names from twenty upwards
    private static string[] tens = new string[]{
        "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy",
        "eighty", "ninety"
    };
    // Scale number names for use during recombination
    private static string[] scaleNumbers = new string[]
    {
        "", "thousand", "million", "billion", "trillion",
        "quadrillion", "quintillion"
    };

    private static int groups = 7; // i.e. up to quintillion

    public static string ToWords(this int number)
    {
      return ToWords((BigInteger)number);
    }

    public static string ToWords(this long number)
    {
      return ToWords((BigInteger)number);
    }

    public static string ToWords(this BigInteger number){
        /*   Convert A Number into Words
        by Richard Carr, published at http://www.blackwasp.co.uk/numbertowords.aspx */
        /* Zero Rule.
        If the value is 0 then the number in words is 'zero' and no other rules apply.*/

        if (number == 0){
            return "zero";
        }
        /*
            Règle à trois chiffres.
        La valeur entière est divisée en groupes de trois chiffres à partir du
        du côté de la main droite. Chaque ensemble de trois chiffres est ensuite traité individuellement
        en nombre de centaines, de dizaines et d'unités. Une fois converti en texte, le
        les groupes à trois chiffres sont recombinés avec l'ajout de l'échelle pertinente
        nombre (mille, million, milliard).
        */

        // Tableau pour contenir le nombre spécifié de groupes à trois chiffres
        int[] digitGroups = new int[groups];
     
        // Ensure a positive number to extract from
        var positive = BigInteger.Abs(number);

      // Extract the three-digit groups
        for (int i = 0; i < groups; i++)
        {
            digitGroups[i] = (int)(positive % 1000);
            positive /= 1000;
        }

        // write to a text file in the project folder
        Trace.Listeners.Add(new TextWriterTraceListener(
        File.AppendText("log.txt")));
        
      // text writer is buffered, so this option calls 
      // Flush() on all listeners after writing 
        Trace.AutoFlush = true;

        // log tableau de numéros de groupe
        for(int x = 0; x < digitGroups.Length; x++)
        {
            Trace.WriteLine(string.Format(
            format: "digitGroups[{0}] = {1}",
            arg0: x,
            arg1: digitGroups[x]));
        }

        // Convert each three-digit group to words
        string[] groupTexts = new string[groups];

        for (int i = 0; i < groups; i++)
        {
             // call a local function (see below)
            groupTexts[i] = ThreeDigitGroupToWords(digitGroups[i]);
        }
        // log array of group texts
        for (int x = 0; x < groupTexts.Length; x++)
        {
            Trace.WriteLine(string.Format(
            format: "groupTexts[{0}] = {1}",
            arg0: x,
            arg1: groupTexts[x]));
        }

        /*
            Règles de recombinaison.
        Lors de la recombinaison des groupes à trois chiffres traduits, chaque groupe, à l'exception du
        last est suivi d'un nom en grand nombre et d'une virgule, sauf si le groupe est
        vide et donc pas du tout inclus. Une exception est lorsque la finale
        le groupe n'inclut pas de centaines et il y a plus d'un non vide
        grouper. Dans ce cas, la virgule finale est remplacée par 'et'. par exemple.
        'un milliard, un million et douze'.
        */
        // Recombine the three-digit groups
        string combined = groupTexts[0];
        bool appendAnd;

        // Determine whether an 'and' is needed
        appendAnd = (digitGroups[0] > 0) && (digitGroups[0] < 100);

        // Determine whether an 'and' is needed
        appendAnd = (digitGroups[0] > 0) && (digitGroups[0] < 100);

      // Process the remaining groups in turn, smallest to largest
        for (int i = 1; i < groups; i++)
        {
            // Only add non-zero items
            if (digitGroups[i] != 0)
            {
            // Build the string to add as a prefix
            string prefix = groupTexts[i] + " " + scaleNumbers[i];

            if (combined.Length != 0)
            {
                prefix += appendAnd ? " and " : ", ";
            }

            // Opportunity to add 'and' is ended
            appendAnd = false;

            // Add the three-digit group to the combined string
            combined = prefix + combined;
            }
        }

        // Converts a three-digit group into English words
      string ThreeDigitGroupToWords(int threeDigits)
      {
        // Initialise the return text
        string groupText = "";

        // Determine the hundreds and the remainder
        int hundreds = threeDigits / 100;
        int tensUnits = threeDigits % 100;

        /* 
         Règles des centaines.
          Si la partie des centaines d'un groupe à trois chiffres n'est pas nulle, le nombre de
          des centaines est ajouté comme un mot. Si le groupe à trois chiffres est exactement divisible
          par cent, le texte « cent » est ajouté. Sinon, le texte
          "cent et" est ajouté. par exemple. 'deux cent' ou 'cent douze'
        */

        if (hundreds != 0)
        {
          groupText += smallNumbers[hundreds] + " hundred";

          if (tensUnits != 0)
          {
            groupText += " and ";
          }
        }

        // Determine the tens and units
        int tens = tensUnits / 10;
        int units = tensUnits % 10;

        /*
            Règles des dizaines.
           Si la section des dizaines d'un groupe à trois chiffres est de deux ou plus, le
           Le mot '-ty' (vingt, trente, etc.) est ajouté au texte et suivi du
           nom du troisième chiffre (sauf si le troisième chiffre est un zéro, qui est ignoré).
           Si les dizaines et les unités sont toutes deux égales à zéro, aucun texte n'est ajouté. Pour toute autre valeur,
           le nom du numéro à un ou deux chiffres est ajouté comme cas particulier.
        */
        if (tens >= 2)
        {
          groupText += NumbersToWords.tens[tens];
          if (units != 0)
          {
            groupText += " " + smallNumbers[units];
          }
        }
        else if (tensUnits != 0)
          groupText += smallNumbers[tensUnits];

        return groupText;

        * Negative Rule.
         Negative numbers are always preceded by the text 'negative'.
      */
      if (number < 0)
      {
        combined = "negative " + combined;
      }

      return combined;
    }

}
