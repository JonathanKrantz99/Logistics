Running application:
1. Navigate to Db folder in Logistics.Infrastructure. In ApplicationDbContext line 19, replace "{server}" with your server name.
2. Set Logistics.Infrastructure as startup project.
3. In Package Manager Console, type Update-Database and enter.
4. Set Logistics.Api as startup project.
5. Start application.

User description:
Skapa varuhus: Post request mot /api/Warehouse. Viktigt att ange en riktig svensk address.

Skapa leverant�rer: Post request mot /api/Supplier

Skapa produkter: Post request mot /api/Product

L�gga till produkter i varuhus: Post request mot /api/Warehouse/{warehouseId}/Stock/Add
Ange vilken produkt och fr�n vilken leverant�r som ska l�ggas till. Viktigt �r att f�rst l�gga till en
leverant�r p� en produkt genom ett Post request mot /api/Product/{productId}/Supplier/{supplierId}/Add

Anv�nd olika endpoints under Warehouse f�r att flytta/l�gga till/ta bort produkter.

Reflections:
Jag valde att anv�nda mig utav DDD och CQRS med hj�lp av mediatR biblioteket. Anledningen till detta �r att jag tycker att koden f�r en
bra och tydlig struktur. Allting har sin egna klass och det �r l�tt att fels�ka, ex:

N�got kr�nglar med uppdatering av warehouse, d� letar vi upp 
warehouse mappen, hitta update mappen och kollar i klassen som hanterar uppdateringen. I detta fall "UpdateWarehouseCommandHandler", h�r i 
ligger allt som har med uppdatering av warehouse att g�ra.

Det g�r det ocks� l�tt att l�gga till/�ndra funktioner n�r man har en tydlig struktur.