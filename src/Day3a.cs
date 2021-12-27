using System.Collections;

public partial class Day3 {
    public static int Day3a(string[] rawInput) {
        var bits = new BitArray(12);
        int[] result = new int[2];

        for (int r = 0; r < 2; r++) {
            string[] input = rawInput;
            for (int i = 0; i < 12; i++)
                // if current bit row has more 1s, set current bit
                bits[11-i] = rawInput.Where(binary => binary[i] == '1').Count() > rawInput.Where(binary => binary[i] == '0').Count() ? true : false;
        }
        
        // convert bits to int and invert
        bits.CopyTo(result, 0); // gamma
        bits.Not();
        bits.CopyTo(result, 1); // epsilon
        return result[0] * result[1];
    }
}