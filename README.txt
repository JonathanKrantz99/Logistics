Running application:
1. Navigate to Db folder in Logistics.Infrastructure. In ApplicationDbContext line 19, replace "{server}" with your server name.
2. Set Logistics.Infrastructure as startup project.
3. In Package Manager Console, type Update-Database and enter.
4. Set Logistics.Api as startup project.
5. Start application.

User description:
Skapa varuhus: Post request mot /api/Warehouse. Viktigt att ange en riktig svensk address.

Skapa leverantörer: Post request mot /api/Supplier

Skapa produkter: Post request mot /api/Product

Lägga till produkter i varuhus: Post request mot /api/Warehouse/{warehouseId}/Stock/Add
Ange vilken produkt och från vilken leverantör som ska läggas till. Viktigt är att först lägga till en
leverantör på en produkt genom ett Post request mot /api/Product/{productId}/Supplier/{supplierId}/Add

Använd olika endpoints under Warehouse för att flytta/lägga till/ta bort produkter.

Reflections:
Jag valde att använda mig utav DDD och CQRS med hjälp av mediatR biblioteket. Anledningen till detta är att jag tycker att koden får en
bra och tydlig struktur. Allting har sin egna klass och det är lätt att felsöka, ex:

Något krånglar med uppdatering av warehouse, då letar vi upp 
warehouse mappen, hitta update mappen och kollar i klassen som hanterar uppdateringen. I detta fall "UpdateWarehouseCommandHandler", här i 
ligger allt som har med uppdatering av warehouse att göra.

Det gör det också lätt att lägga till/ändra funktioner när man har en tydlig struktur.