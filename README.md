<h2>Personnummersvalidering</h2>

Tillsammans har vår grupp skapat ett GitHub-projekt som består av en personnummerskontroll/applikation. Detta projekt inkluderar även enhetstester och användning av GitHub Actions samt användning av Docker.

<h2>Lokal körning av koden</h2>

För att kunna köra applikationen lokalt så behöver dessa steg följas:

1. Ladda ner och installera .NET 6.0. https://dotnet.microsoft.com/en-us/download/dotnet/6.0
2. Ladda ner och installera Git. https://git-scm.com/downloads
3. Klona projektet till valfri mapp från GitHub-repot i en terminal med hjälp av kommandot:
git clone https://github.com/SodenSys/PersonNummer-Grupp5.git

Efter att du klonat projektet så är det bara att öppna upp projektet i din valda kodeditor och sedan köra koden genom kommandot 'dotnet run' i terminalen.

<h4>Körning i Docker</h4>

Om du hellre vill köra applikationen som en Docker-container istället så behöver
dessa steg följas:

1. Ladda ner och installera Docker Desktop. https://www.docker.com/products/docker-desktop/
2. Öppna Docker Desktop.
3. Öppna terminalen och navigera till mappen där du klonade projektet.
4. Kör följande kommando för att hämta och köra Docker-containern:
docker run -it sodensys/personnummergrupp5
(5). Om du sitter på en Git-terminal så behöver du skriva:
winpty docker run -it sodensys/personnummergrupp5

<h4>Svenska Regler för Personnummerkontroll</h4>

Ett svenskt personnummer innehåller 12 siffror (ÅÅÅÅMMDD-XXXX).
De fyra första siffrorna (ÅÅÅÅ) består av födelseår, de andra två (MM) av födelsemånad, och
de efter (DD) födelsedatum.
De fyra sista siffrorna är en individuell kod för att identifiera en person (XXXX). Det går även
att identifiera ett personnummer med tio siffror (ÅÅMMDD-XXXX).
De fyra sista siffrorna har även några fler syften, de två första siffrorna (**XX**XX) talar om
personens födelseplats.
Den tredje siffran (XX**X**X) talar även om ifall individen är en kvinna eller man, jämn siffra står
för kvinna och udda för män.
Den sista siffran (XXX**X**) är en kontrollsiffra.

<h4>Vår applikation/Kod</h4>

Koden som vi har gjort kontrollerar och säkerställer att det angivna personnummret
följer de svenska reglerna som finns för det. Nedan så har vi listat några av kodens
funktioner samt hur koden genomför sina kontroller.

1. Verifierar så att personnumret är giltigt enligt Luhn-algoritmen
● Vi har implementerat Luhn-algoritmen i vår kod för att kunna säkerställa giltigheten
av personnumret.
2. Kontrollerar födelseplats samt kön av person
● Koden analyserar de sista siffrorna och kan på så sätt identifera kön samt
fördelseplats av individ.
3. Säkerställer så att inmatningen blir korrekt
● Det finns implementerade kontroller som ser till att endast en inmatning av 10 siffror
blir giltig. Skrivs det något annat så kommer ett felmeddelande fram och ber
användaren om korrekt inmatning.

● Det kontrolleras även så att det inte blir en inmatning som överstiger månad 12 samt
dag 31, då det går emot reglerna för ett svenskt personnummer.

Sammanfattningsvis så har vår grupp skapat en personnummers applikation med möjlighet
för både lokal körning och körning av Docker-container. Vår applikation är uppbyggd efter de
svenska reglerna som behöver följas i samband med Luhn-algoritmen. Tillsammans med
användning av enhetstesterna, Docker och GitHub Actions så anser vi att vi har skapat ett
lyckat projekt.
