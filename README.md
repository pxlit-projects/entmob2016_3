# Groepsleden

- Arno Bruynseels - 3AONd - 11308331
- Alessio Costa - 3AONa - 11302791
- Niels Carmans - 3AONa - 11301011
- Robbert Braeken - 3AONa - 11304704

# Inleiding

Als groep hebben we besloten om een applicatie te ontwikkelen die instaat voor het registreren en het verwerken van data omtrent de weersomstandigheden in een serre voor groentetelers.
Deze informatie zal verzamelt worden door een TI sensorTag.

Op basis van de verzamelde informatie zal de toepassing conclusies trekken en de gebruiker hiervan op de hoogte houden.

# Omschrijving

De sensor gaat drie verschillende parameters opmeten.

- Luchtvochtigheid
- Hoeveelheid licht
- Temperatuur

Voor elke soort groenten is er een ideaal bereik van elk van deze parameters. Deze waarden gaan we bepalen op resultaten die we door opzoekwerk gevonden hebben. Als we echter geen relevante informatie over een bepaalde groentesoort gevonden hebben zullen we deze invullen met fictieve waarden.

Het toestel gaat constant data verzamelen en deze periodiek uploaden. Het is de bedoeling om deze data te gebruiken om een visueel overzicht te bekomen van de bovenstaande parameters via de applicatie.

De toepassing zal een overzichtspagina bevatten waar de gebruiker alle verzamelde informatie kan raadplegen. Via deze pagina zal de gebruiker ook in staat zijn om een tijdsoverzicht te bekijken van metingen over een bepaalde periode.

Het systeem zal op basis van de metingen conclusies trekken over de huidige omstandigheden en deze melden aan de gebruiker. De conclusie zal een beschrijving bevatten met eventuele handelingen die de gebruiker kan uitvoeren.
Doordat het systeem de gebruiker tijdig noticifeert kan er vroegtijdig ingegrepen worden indien er grenswaarden overschreden zijn voor een zo optimaal mogelijke teelt te hebben.

De gebruiker zal het soort groenten kunnen kiezen waardoor het systeem weet hoe de data geïnterpreteerd moet worden. Als uitbreiding zal er een optie beschikbaar zijn om specifieke groenten toe te voegen, te verwijderen en te bewerken.

Alle data die de sensorTag registreert zal opgeslagen worden in een database.

De front-end van het systeem zal ontwikkeld worden in C# voor de UWP toepassingen en in Xamarin voor de iOS/Android toepassingen. De back-end zal in Java Spring ontwikkeld worden.

## Voorbeeld situatie

De temperatuur in de serre is te hoog van de specifieke groente. De sensorTag gaat deze temperatuur registreren en vergelijken met de grenswaarden. Indien deze grenswaarden overschreden worden ontvangt de gebruiker een notificatie met de gepaste melding dat de temperatuur momenteel te hoog is. Hierbij krijgt hij ook de actie te zien die hij moet uitvoeren om de temperatuur te doen dalen.

## Project Architectuur

![alt text](https://github.com/pxlit-projects/entmob2016_3/blob/master/3 - Architectuur/Architectuur.png "Architectuur")

**Architectuuromschrijving**

- Datavoorziening: De TI sensorTag gaat gegevens registreren en doorsturen naar de UWP-applicatie via Bluetooth. Vervolgens gaat de UWP-applicatie deze verzamelde gegevens doorsturen naar de Spring back-end via een REST call.

- UWP: _Desktop_ applicatie die de gegevens met behulp van de Spring back-end via een REST call gaat visualiseren. Aanpassingen in de gegevens zijn eveneens mogelijk via REST calls.

- Android app: _Mobiele_ applicatie die de gegevens met behulp van de Spring back-end via een REST call gaat visualiseren. Aanpassingen in de gegevens zijn eveneens mogelijk via REST calls.

- Spring: Back-end met verschillende Spring componenten die al het dataverkeer gaat verwerken.

- Database: De opslag van gegevens met behulp van een MySQL-database.

## Database Architectuur

![alt text](https://github.com/pxlit-projects/entmob2016_3/blob/master/5 - Database/Architectuur.png "Architectuur")

**Omschrijving en relaties**

De _GROWABLE_ITEMS_ representeren de groenten. Elke item heeft een aantal basisgegevens zoals een naam, een omschrijving en een afbeelding. Daarbuiten heeft elk item expliciet 1 relatie naar temperatuur (_TEMPERATURE_), luchtvochtigheid (_MOISTURE_) en hoeveelheid licht (_LIGHT_). Elk van deze hebben een minimum- en een maximumwaarde. De reden waardoor deze gegevens apart worden bijgehouden is omdat een het mogelijk is dat er meerdere items dezelfde waarden kunnen hebben voor bijvoorbeeld temperatuur.

De _USERS_ staan invoor de authenticatie tot de API en heeft een relatie met 1 of meerdere _USERGROUPS_ waar bepaalde permissies aanhangen.
