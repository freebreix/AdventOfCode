public partial class Day2 {
    public static int Day2b(string[] rawInput) {
			int h = 0, d = 0, a = 0;
			foreach (var line in rawInput) {
				var cmd = line.Split(' ');
				int f = cmd[0] == "forward" ? int.Parse(cmd[1]) : 0;
				h += f;
				d += f*a;
				a += cmd[0] == "up" ? int.Parse(cmd[1])*-1 : cmd[0] == "down" ? int.Parse(cmd[1]) : 0;
			}
			return h*d;
		}
}