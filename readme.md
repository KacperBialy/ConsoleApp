# Poprawki
1. Źle przekazana nazwa pliku do metody ImportAndPrintData, powinno być data.csv, a najlepiej tak jak w udostępnionym kodzie, obsłużyć pobieranie nazwy pliku z argumentów wejściowych do programu i całkowicie zrezygnować z trzymania pliku data.csv w projekcie. Odblokuję to aplikację na przetwarzanie innych nazw plików. Dodatkowo brak obsługi błędów, w udostępnionym kodzie zostało to poprawione.
2. W klasie Program.cs znajdują się zbędne usingi, warto ustawić sobie jakiś automatyczne formatowanie np. podczas zapisu pliku, które będzie pamiętać za nas o usuwaniu zbędnych rzeczy.
3. W klasie DataReader jest błędnie napisany warunek ``
for (int i = 0; i <= importedLines.Count; i++)
``, w udostępnionym kodzie tworzenie obiektów zostało wydzielone do osobnej klasy SqlStructureCsvReader.cs. i odbywa się ono równolegle z pobieraniem linii z pliku.
4. Brak sprawdzenia, czy liczba zwracanych wartości zgadza się z oczekiwaną, brakuje warunku po wywołaniu 
`var values = importedLine.Split(;)`, w udostępnionym kodzie sprawdzeniem poprawności splitowanych danych zajmuje się prywatna metoda Validate w klasie SqlStructureCsvReader.cs
5. Boxing/unboxing jest długi i w tym przypadku całkowicie niepotrzebny.
``
ImportedObjects = new List<ImportedObject>() { new ImportedObject() };
``
6. Klasa DataReader ma za dużo odpowiedzialności na co wyraźnie wskazują same nazwy metod w tej klasie. Widać tutaj 3 główne odpowiedzialności, czytanie danych, formatowanie danych, wyświetlanie danych. W udostępnionym kodzie każda odpowiedzialność została wydzielona do osobnej klasy SqlStructureCsvReader.cs, SqlStructureFormater.cs oraz DatabaseStructurePrinter.cs. Dodatkowo w udostępnionym projekcie został zmienione nazwy klas na bardziej specjalistyczne, mówiące w lepszy sposób co w danej klasie się znajduje.
7. W pliku DataReader znajdują się również modele, takie jak ImportedObject oraz ImportedObjectBaseClass, warto je wydzielić do osobnego folderu z modelami i osobnych plików. Warto by było również zachować spójność w formatowaniu w klasie ImportedObject.
8. Klasa ImportedObjectBaseClass.cs nie ma większego sensu, gdyż dziedziczy z niej tylko ImportedObject, a dodatkowo ma on jeszcze jedną wspólną właściwość Name.
9. Klasa DataReader za często iteruje po całym zbiorze danych, można to w elegancki sposób uprościć, tworząc struktury, które zostaną utworzone podczas czytania danych z pliku, w udostępnionym projekcie dane zostały wczytane do klas Database.cs, Table.cs oraz Column.cs, co jest zbliżone do rzeczywistej struktury w relacyjnych bazach danych, przez co znacznie upraszcza nam się sposób zliczania ilości tabeli oraz ilości kolum w tabelach, a idąc dalej samo wyświetlanie całej struktury.
10. Brak zamknięcia połączenia z plikiem
`var streamReader = new StreamReader(fileToImport);`, w udostępnionym kodzie zostało to zrealizowane poprzez otoczenie streamReadera w blok using, który automatycznie zadba nam o zamknięcie połącznia, nawet w przypadku błędu.
11. Kod jest strasznie wolny, cały program wykonuje się 3-4 sekundy, w udostępnionym kodzie poprzez zastosowanie odpowiednich struktur, które redukują niepotrzebne iterację udało się zredukować czas do <1s.
12. Brak jakichkolwiek testów, co znacznie utrudnia refaktoryzację i zrozumienie kodu. W udostępnionym projekcie zostały dodane podstawowe testy, pokrywające większość kluczowych funkcjonalności programu, przez co kolejne refaktoryzacje, rozszerzenia, będą znacznie szybsze i bezpieczniejsze.
13. Dodatkowo, należy uważać na wczytywanie danych do pamięci, możemy tutaj przekroczyć dostępną pamięć i dostać OutOfMemoryException. Pewnie warto by było zabezpieczyć wielość pliku, który będziemy obsługiwać lub zastosować implementacje, która będzie wczytywała dane porcjami.


