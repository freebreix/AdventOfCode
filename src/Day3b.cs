public partial class Day3 {
    public static int Day3b(string[] rawInput) {
        int[] result = new int[2];

        for (int r = 0; r < 2; r++) {
            string[] input = rawInput;
            for (int i = 0; i < 12; i++) {
                int o = input.Where(binary => binary[i] == '1').Count(), z = input.Where(binary => binary[i] == '0').Count();
                if ((input = input.Where(binary => binary[i] == (o > z || o == z ? r == 0 ? '0':'1' : r == 0 ? '1':'0')).ToArray()).Count() == 1) {
                    result[r] = Convert.ToInt32(input.First(), 2);
                    break;
                }
            }
        }
        return result[0] * result[1];
    }
}