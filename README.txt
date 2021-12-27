Dotnet runtime Installation (Debian):

sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-6.0

sudo apt-get install -y dotnet-runtime-6.0

Für weitere Info: https://docs.microsoft.com/en-us/dotnet/core/install/linux-debian


Ausführung:

dotnet run
dann Klassenname eingeben (z.B.: Day3b)

Klassen befinden sich in /src