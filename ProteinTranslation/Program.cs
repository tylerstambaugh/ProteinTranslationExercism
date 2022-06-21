
string[] outputStringArray = ProteinTranslation.Proteins("AUGUUUUGG");

foreach (string s in outputStringArray)
{
    Console.WriteLine($"{s.ToString()}");
}

Console.ReadLine();


public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {

        if (strand.Length % 3 != 0)
        {
            throw new InvalidDataException(strand);
        }

        List<string> codonList = new List<string>();
        List<string> proteinList = new List<string>();

        string codonBuilder = "";
        string codon = "";

        for (int i = 0; i < strand.Length; i++)
        {
            codonBuilder += strand[i];
            if (codonBuilder.Length == 3)
            {
                codon = codonBuilder;
                Console.WriteLine($"codon = {codon}");
                codonList.Add(codon);
                codonBuilder = "";
            }
        }

        bool exitLoop = false;
        foreach (string s in codonList)
        {
            if (!exitLoop)
            {
                switch (s)
                {
                    case "AUG":
                        proteinList.Add("Methionine");
                        break;
                    case "UUU":
                    case "UUC":
                        proteinList.Add("Phenylalanine");
                        break;
                    case "UUA":
                    case "UUG":
                        proteinList.Add("Leucine");
                        break;
                    case "UCU":
                    case "UCC":
                    case "UCA":
                    case "UCG":
                        proteinList.Add("Serine");
                        break;
                    case "UAU":
                    case "UAC":
                        proteinList.Add("Tyrosine");
                        break;
                    case "UGU":
                    case "UGC":
                        proteinList.Add("Cysteine");
                        break;
                    case "UGG":
                        proteinList.Add("Tryptophan");
                        break;
                    case "UAA":
                    case "UAG":
                    case "UGA":
                        exitLoop = true;
                        break;

                    default:
                        break;
                }
            }
        }

        return proteinList.ToArray();

    }
}