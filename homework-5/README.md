# mustafa-gundogdu-homework-5

*BackgroundWorker olu�turulacak. https://jsonplaceholder.typicode.com/posts bu linketeki her bir dakikada �al���p bu bilgileri �ekip veri taban�na kay�t eden bir repository olu�turulacak.
Post diye tablo olu�turulacak migration ile user, id, title, body postun kolonlar� olacak.

#Steps
* 1-> First.App.Domain katman�nda Post class'� olu�turulup BaseEntity den miras ald�k 
* 2-> First.App.EntityFramework katman�nda configurations klas�r�nde PostConfiguration olu�turuldu ve appDbContext e dbset eklendi.
* 3-> First.App.Business katman�nda Post i�lemleri yapacak olan interface ve service class� olu�turuldu
* 4-> Kuyruk yap�s� i�in First.App.Business katman�nda IBackgroundQueue ve BackgroundQueue eklendi ve kuyruk yap�s� generic olarak olu�turuldu
* 5-> PostAPI olu�turuldu ve Background klas�r� olu�turuldu
* 6-> �ncelikle her 60 saniyede bir �al��acak PostBackgroundCallWorker olu�turuldu bu s�n�fta gelen postlar kuyru�a eklendi
* 7-> Kuyruktaki verileri database e eklemek i�in ise PostBackgroundSaveWorker olu�turuldu kuyruktan FIFO mant��� ile s�rayla ekleme i�lemi yap�ld�
* 8-> PostController ile veritaban�ndaki postlar� g�r�nt�leme i�lemleri yap�ld�...