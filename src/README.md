# Velo Games Sanal Staj Programı #1

Velo Games Sanal Staj Programı için yapılmış olan ilk görevdir.

**Program Çerçevesi**

- Bir kitaptan elimizde belirli bir sayıda var. **CopyCount**.
- Bir kitabı ödünç verdiğimizde kitabın geri getirilmesi gereken tarihi not edilir. Bu tarihlerin sayısı ödünç verilen kitap sayısına eşittir. **DueDates.Count**.
- Boşta olan kopya sayısı **AvailableCount()** isimli fonksiyonla **CopyCount - DueDates.Count** olarak hesaplanır.
- Ödünç al aksiyonunda **AvailableCount() > 0** koşulu kontrol edilir. Koşul sağlanırsa geri getirilmesi gereken tarihlere yeni bir tarih eklenir sağlanmazsa hata verilir.
- İade et aksiyonunda **DueDates.Count > 0** koşulu kontrol edilir. Koşul sağlanırsa geri getirilmesi gereken tarihler arasından en yakın tarih listeden çıkartılır sağlanmazsa hata verilir.

**Not:** ISBN numarası bir kitabın ismi değişerek yeniden basılacaksa ya da yayımcı firma değişecekse değişir. Bizim projemizde ismi farklı olan kitapları farklı kitaplar gibi düşüneceğimizden ve yayımcı firma bilgisini verilerimiz arasında bulundurmadığımızdan ISBN numarasını eşsiz(unique) kabul ediyoruz.

**Not:** Yaptığımız sistem çerçevesinde kitap iade işlemlerinde kullanıcı ve kitap eşleşmesi yapmadığımız için iade işleminde getirilmesi gereken tarihiak en yakın olanı baz alarak listeden siliyoruz.

#### 1. Açılışta Verilerin Yüklenmesi

![load](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/03c54e57-2eeb-4eee-95c4-c898fb5ff51b)

#### 2. Menü

![menu](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/1a5f3816-348b-4161-a686-caa8ce21565c)

#### 3. Kitap Ekleme Ekranı

![add book](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/06d28c05-a9a5-459d-bd09-aa60d44c6775)

#### 4. Kitap Listeleme Ekranı

![list](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/e9d6b21b-5547-49eb-9dbd-b51cc1c599b0)

#### 5. Kitap Arama Ekranı (Tek Sonuç Bulunması)

![search single](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/a9173e93-3f7b-40a2-a850-4353edd730ff)

#### 6. Kitap Arama Ekranı (Çok Sonuç Bulunması)

![search multiple](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/8106ab82-ff35-41aa-a0f7-a143ba169554)

#### 7. Kitap Ödünç Alma Ekranı

![loaned](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/d83024d0-b641-4644-9e11-03646dd479ef)

#### 8. Kitap Ödünç Alma Ekranı (Hata)

![loaned fail](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/efb72b9e-3cf8-43a2-b8b6-23d55ad9b715)

#### 9. Kitap İade Alma Ekranı

![return](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/6aa915e2-8d73-44a1-a1cf-70330e99b50d)

#### 10. Kitap İade Alma Ekranı (Hata)

![return fail](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/423f20c9-0ebd-4e77-abcb-5ff52c7484f1)

#### 11. Süresi Geçmiş Kitap Listesi

![expired](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/9d53ac16-0b55-4184-8dbc-1e5b30657f66)

#### 12. Kapanışta Verilerin Kaydedilmesi

![save](https://github.com/tamererdogan/velo-tutorial-one/assets/29844065/9aa93e16-6bec-42e5-a01f-512f417f6100)
