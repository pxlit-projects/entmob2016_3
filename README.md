# Groepsleden

Arno Bruynseels - 3AONd - 11308331
Alessio Costa - 3AONa - 11302791
Niels Carmans - 3AONa - 11301011
Robbert Braeken - 3AONa - 11304704

# Inleiding

Als groep hebben we besloten om een applicatie te ontwikkelen die instaat voor het registreren en het verwerken van data omtrent de weersomstandigheden in een serre voor groentetelers.
Deze informatie zal verzamelt worden door een TI sensorTag.

Op basis van de verzamelde informatie zal de toepassing conclusies trekken en de gebruiker hiervan op de hoogte houden.

# Omschrijving

De sensor gaat drie verschillende parameters opmeten.

Luchtvochtigheid
Hoeveelheid licht
Temperatuur

Voor elke soort groenten is er een ideaal bereik van elk van deze parameters. Het toestel gaat constant data verzamelen en deze periodiek uploaden. Het is de bedoeling om deze data te gebruiken om een visueel overzicht te bekomen van de bovenstaande parameters via de applicatie.

De toepassing zal een overzichtspagina bevatten waar de gebruiker alle verzamelde informatie kan raadplegen. Via deze pagina zal de gebruiker ook in staat zijn om een tijdsoverzicht te bekijken van metingen over een bepaalde periode.

Het systeem zal op basis van de metingen conclusies trekken over de huidige omstandigheden en deze melden aan de gebruiker. De conclusie zal een beschrijving bevatten met eventuele handelingen die de gebruiker kan uitvoeren.

De gebruiker zal het soort groenten kunnen kiezen waardoor het systeem weet hoe de data geïnterpreteerd moet worden. Als uitbreiding zal er een optie beschikbaar zijn om specifieke groenten toe te voegen, te verwijderen en te bewerken.

Alle data die de sensorTag registreert zal opgeslagen worden in een database.

De front-end van het systeem zal ontwikkeld worden in C# voor de UWP toepassingen en in Xamarin voor de iOS/Android toepassingen. De back-end zal in Java Spring ontwikkeld worden.