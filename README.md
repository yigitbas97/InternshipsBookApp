# InternshipsBookApp
Bu uygulama staj defterini online bir platformda oluşturup istenilen her an düzenleyebilmek fikriyle yapılmıştır. Kullanıcılar üye olduktan sonra staj defteri oluşturup, deftere sayfa ekleyebilirler. Oluşturdukları defterleri ve sayfaları düzeneyebilirler. İsterlerse seçtikleri defteri pdf dosyası halinde indirebilirler.

----------------------------------------------------------------------------------------------------

Kullanılan Teknolojiler ve Yöntemler

•	Asp.Net Core MVC -> Sunum Katmanı

•	MSSQL -> Veritabanı

•	Entity Framework  -> ORM Aracı

•	LINQ -> Veri Sorgulama

•	Html,Css,Javascript,Bootstrap -> Görsel Tasarım 

•	CkEditor4 -> Editor, resim ekleme, kod eklentisi ekleme

•	IronPdf -> Pdf işlemleri

•	Uygulama Code First stratejisiyle geliştirilmiştir.

----------------------------------------------------------------------------------------------------


Uygulama Özellikleri

•	Staj Defteri -> Ekle, Oku, Sil, Güncelle, Pdf Kaydet

•	Sayfa -> Ekle, Oku, Sil ,Güncelle , Deftere Kaydet

----------------------------------------------------------------------------------------------------

Güvenlik

•	Kullanıcılara ait parolalar oldukları gibi saklanmazlar. Hash algoritmasıyla şifrelenerek saklanırlar. Kullanıcı parolasını girdiğinde parola  tekrar şifrelenir ve şifrelenmiş hali veritabanındaki haliyle karşılaştırılır. Admin dahil kimse parolanızı göremez.
