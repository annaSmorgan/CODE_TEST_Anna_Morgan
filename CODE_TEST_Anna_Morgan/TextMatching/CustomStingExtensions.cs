namespace TextMatching;
public static class CustomStingExtensions
{
    public static char[] ToCharArrayCustom(this string inputString)
    {
        char[] charArray = new char[inputString.Length];

        int positionCounter = 0;

        foreach (char c in inputString)
        {
            charArray[positionCounter] = char.ToLower(c);
            positionCounter++;
        }

        return charArray;
    }
}
