# Simulator of an Infrastructure System
 
Kreirana je WPF aplikacija za monitoring izmerenih vrednosti elemenata sistema/mreže (NetworkService). Pored aplikacije za monitoring, koristiće se i simulatorska 
aplikacija (MeteringSimulator, već implementirana) koja će u nasumično izabranim vremenskim trenucima, slati nasumične brojne vrednosti, koje će aplikacija za 
monitoring obraditi i iskoristiti. 

Svaka nova brojevna vrednost dolazi od simulatorske aplikacije zajedno sa indeksom entiteta u listi unutar NetworkService aplikacije za kojeg je to nova vrednost, 
što se memoriše u Log fajlu (.txt) na disku sistema, uz vremenski trenutak kada se promena desila. 

Samu aplikaciju čine tri View-a:
* Network Entities: Omogućeno je dodavanje i brisanje entiteta za monitoring i osnovne podaci o njima su čuvani u vidu tabele (novodobijena 
brojevna vrednost se prikazuje u jednoj od kolona tabele). Korisnik ima priliku da pretražuje ili filtrira prikaz u tabeli. Nakon dodavanja ili brisanja objekata, 
simulatorska aplikacija mora da se restartuje (njeno funkcionisanje se NE SME menjati) i ona će tada sama da prikupi podatke koliko ukupno postoji objekata u 
(NetworkService) aplikaciji, za koje treba da daje podatke o stanju. Ispod tabele postoji forma za dodavanje novog entiteta u skladu sa njegovim atributima.

* Network Display: Sadrži prostor gde će se nalaziti vizuelni prikazi entiteta i simulirati njihovo mesto u sistemu/mreži. Njihov raspored nije bitan i njega 
određuje korisnik tako što pomera te prikaze (slike) drag&drop tehnikom. Dodatno je omogućena vizuelna izmena ukoliko novoizmerena vrednost bude ispod ili iznad 
zadate granice. Vizuelna izmena može biti u vidu notifikacije, promene boje, ili promene statusne slike. Pored svega je omogućeno da se objekti mogu spajati linijama.

* Measurement Graph: Na osnovu podataka zapisanih u Log fajlu, prikazana je istorija stanja pomoću grafikona. Grafikoni će se konstantno menjati, jer se konstantno 
dobijaju nove informacije, ali idu unazad pet poslednjih merenja. 

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

A WPF application has been created to monitor the measured values of system / network elements (NetworkService). In addition to the monitoring application, a simulator application (MeteringSimulator, already implemented) will be used, which will send randomly selected values ​​at randomly selected time points, which the monitoring application will process and use. 

Each new numeric value comes from the simulator application along with the index of the entities in the list within the NetworkService application for which it is the new value, which is stored in the Log file (.txt) on the system disk, with the time the change occurred. 

The application itself consists of three Views:
* Network Entities: It is possible to add and delete monitoring entities and basic data about them are stored in the form of a table (the newly obtained numerical value is displayed in one of the columns of the table). The user has the opportunity to search or filter the display in the table. After adding or deleting objects, the simulator application must be restarted (its functioning MUST NOT be changed) and it will then collect data on the total number of objects in the (NetworkService) application, for which it should provide status data. Below the table is a form for adding a new entity according to its attributes. 

* Network Display: Contains the space where visual representations of entities will be located and simulates their place in the system / network. Their layout is not important and it is determined by the user by moving these views (images) using drag & drop technique. Additionally, visual modification is enabled if the newly measured value is below or above the set limit. Visual changes can be in the form of notifications, color changes, or status image changes. In addition, it is possible for objects to be connected by lines. 

* Measurement Graph: Based on the data recorded in the Log file, the status history is displayed using a graph. The charts will be constantly changing, because new information is constantly being obtained, but the last five measurements are going backwards.
