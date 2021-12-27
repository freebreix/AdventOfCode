public partial class Day2 {
    public static int Day2a(string[] rawInput) {
        int h = 0, d = 0;
        foreach (var line in rawInput) {
            var cmd = line.Split(' ');
            h += cmd[0] == "forward" ? int.Parse(cmd[1]) : 0;
            d += cmd[0] == "up" ? int.Parse(cmd[1])*-1 : cmd[0] == "down" ? int.Parse(cmd[1]) : 0;
        }
        return h*d;
    }
}