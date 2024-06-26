# AspNetCore.Redis

<h2>Caching Nedir ?</h2>
<p>
  Yazılım süreçlerinde verilere daha hızlı erişebilmek için bu verilerin
  bellekte saklanması olayına caching denmektedir.
</p>
<p>
  Bilgisayar sistemlerinde kullanılan bellek türlerinin hız ve kapasite farkları
  mevcuttur. Örnek olarak, sabit disk'e nazaran RAM anlık olarak işlem
  yapılabilecek verilerin tutulduğu ortam olduğu için haliyle verilere erişimin
  söz konusu olduğu durumlarda daha hızlı bir davranış sergileyecektir.
</p>
<p>
  Bu da bizlere yazılımlarımızda belirli verisel işlemler sürecinde hız
  kazandıracak ve performans açısından bir optimizasyon sağlayacaktır.
</p>

<h2>Caching'in Yazılıma Katkıları Nelerdir ?</h2>
<ul>
  <li><b>Veri Erişimini Hızlandırır</b></li>
  <p>Caching, verilerin hızlı erişimini sağlar</p>
  <li><b>Performans Artışı</b></li>
  <p>
    Caching, verilerin hızlı bir şekilde erişilebilir olmasını sağladığı için
    performans arttırır. Özellikle veritabanı sorguları gibi yavaş ve maliyetli
    işlemlerde, verilerin önceden sakladığı cache'den alınması yerine göre büyük
    performans farkları yaratabilir.
  </p>
  <li><b>Sunucu Yükünü Azaltır</b></li>
  <p>
    Caching, verileri önceden cache'de sakladığı için ihtiyaç dahilinde aynı
    verilerin tekrar tekrar elde edilme maliyetini sunucudan soyutlar ve böylece
    sunucunun iş yükünü azaltır.
  </p>
  <li><b>Çevrimiçi Uygulamalar için Kritik Arz Eder</b></li>
  <p>
    Çevrimiçi uygulamalarda, kullanıcıların verilere hızlı bir şekilde
    erişebilmeleri ve işlem yapabilmeleri önemlidir. Caching özellikle bu
    ihtiyacı karşılayan bir yaklaşımdır.
  </p>
</ul>

<h2>Hangi Veriler Cache'lenir ?</h2>
<p>
  Cache'lenecek veriler, sıklıkla ve hızlı bir şekilde erişilecek veriler
  olmalıdır. Örneğin; sık ve sürekli kullanılan veritabanı sorguları neticesinde
  ki veriler, konfigürasyon verileri, menü bilgileri, yetkiler, vs. gibi yazılım
  tarafından sürekli ihtiyaç duyulacak verileri cache'lemekte fayda vardır.
</p>
<p>
  Hatta resim ve video dosyaları gibi static yapılanmalarda cache'lenebilir.
</p>
<p>
  Ancak unutulmamalıdır ki, yazılım sürecinde kullanılan her veri
  cache'lenmemelidir. Örnek olarak, sürekli güncellenen veya kişisel olan
  veriler cache'lenmemelidir. Ayrıca güvenlik açısından risk teşkil eden veriler
  de mümkün mertebe cache'lenmemeksizin işlenmelidir.
</p>
<p><b>Cache'lenmemesi Gereken Veriler</b></p>
<ul>
  <li>Güncellenen veriler</li>
  <li>Kişisel veriler</li>
  <li>Güvenlik açısından risk teşkil eden veriler</li>
  <li>Özel veriler</li>
  <li>Geçici veriler</li>
</ul>

<h2>Caching Zararları Nelerdir ?</h2>
<ul>
  <li><b>Bellek Yükü</b></li>
  <p>
    Verileri bellekte saklamak demek, bellekteki yükün artması demektir. Caching
    işlemi zaten kapasitesi sınırlı olan belleğin yükünü arttırarak performansı
    da bir nebze olumsuz etkileyebilir.
  </p>
  <li><b>Güncellik Sorunu</b></li>
  <p>
    Cache'lenmiş veriler, veritabanındaki fizik fiziksel ortamlarında
    değişikliğe uğrayabilirler. Eğer ki bu değişiklik cache'de ki verilere de
    yansıtılmaz ise yazılım tarafından tutarsız verilerin kullanılması durumu
    söz konusu olabilir.
  </p>
  <li><b>Güvenlik Sorunları</b></li>
  <p>Kritik arz eden verilerin cache'lenmesi tehlike doğurabilir.</p>
  <li><b>Yasa Dışı Kullanım</b></li>
  <p>
    Yasa dışı kullanım açısından önemli verilerin (finans, sağlık, kimlik
    bilgileri vs) cache'lenmesi hukuki problemlere sebebiyet verebilir.
  </p>

  <h2>Bir Cache Mekanizmasının Temel Bileşenleri Nelerdir ?</h2>

  <ul>
    <li><b>Cache Belleği</b></li>
    <p>
      Verilerin saklandığı bellektir. Verileri hızlı bir şekilde erişilebilir
      hale getirmek için kullanılır.
    </p>
    <li><b>Cache Bellek Yönetimi</b></li>
    <p>
      Cache belleğinde saklanan verileri yönetmek için kullanılır. Örnek olarak;
      verilerin saklanma süreleri, silinme sıklıkları veya güncellik durumları
      gibi yapılandırmalar sağlanabilir.
    </p>
    <li><b>Cache Algoritması</b></li>
    <p>
      Verilerin cache belleğine nasıl eklenip silineceğini belirleyen
      algoritmadır.
    </p>
  </ul>

  <h2>Caching Yaklaşımları</h2>
  <ul>
    <li><b>In-Memory Caching</b></li>
    <p>
      Verileri uygulamanın çalıştığı bilgisayarın RAM'inde cache'leyen
      yaklaşımdır.
    </p>
    <li><b>Distributed Caching</b></li>
    <p>
      Verileri birden fazla fiziksel makinada cache'leyen ve böylece verileri
      farklı noktalarda tutarak tek bir noktada saklamaktan daha güvenli bir
      davranış sergileyen yaklaşımdır.
    </p>
    <p>
      Bu yaklaşımla veriler bölünerek farklı makinalara dağıtılmaktadır. Haliyle
      büyük veri setleri için daha uygun ve ideal bir yaklaşımdır.
    </p>
  </ul>

  <h2>Redis Nedir ?</h2>
  <p>
    Redis(Remote Dictionary Server); open source olan ve bellekte veri
    yapılarını yüksek performanslı bir şekilde cache'lemek için kullanılan bir
    veritabanıdır. Caching işlemlerinin yanında message broker olarak da
    kullanılabilmektedir. Yapısal olarak key-value veri modelinde çalışmaktadır
    ve NoSQL veritabanıdır.
  </p>
</ul>
<h2>Redis Veri Türleri</h2>

<h3>Redis String</h3>
<p>Redis'in en temel, en basit veri türüdür. Metinsel değerlerle birlikte her türlü veriyi saklamak için kullanılır. Hatta binary olarak resim, dosya vs. verileri de saklayabilmektedir.</p>

<table>
  <tr>
    <th>İşlem</th>
    <th>Kod</th>
    <th>Örnek</th>
  </tr>
  <tr>
    <td>Ekleme</td>
    <td>SET</td>
    <td>SET isim firat</td>
  </tr>
  <tr>
    <td>Okuma</td>
    <td>GET</td>
    <td>GET isim</td>
  </tr>
  <tr>
    <td>karakter Okuma</td>
    <td>GETRANGE</td>
    <td>GETRANGE isim 0 2</td>
  </tr>
  <tr>
    <td>Arttırılabilir</td>
    <td>INCR</td>
    <td>INCR sayi</td>
  </tr>
  <tr>
    <td>Arttırılabilir</td>
    <td>INCRBY</td>
    <td>INCRBY sayi 10</td>
  </tr>
  <tr>
    <td>Azaltılabilir</td>
    <td>DECR</td>
    <td>DECR sayi</td>
  </tr>
  <tr>
    <td>Azaltılabilir</td>
    <td>DECRBY</td>
    <td>DECRBY sayi 10</td>
  </tr>
  <tr>
    <td>Üzerine Ekleme</td>
    <td>APPEND</td>
    <td>APPEND name alcin</td>
  </tr>
</table>

<h3>Redis List</h3>
<p>Değerleri koleksiyonel olarak tutan bir türdür.</p>

<table>
  <tr>
    <th>İşlem</th>
    <th>Kod</th>
    <th>Örnek</th>
  </tr>
  <tr>
    <td>Baştan Veri Ekleme</td>
    <td>LPUSH</td>
    <td>LPUSH ogrenciler emre</td>
  </tr>
  <tr>
    <td>Verileri Listeleme</td>
    <td>LRANGE</td>
    <td>LRANGE ogrenciler 0 2 / LRANGE ogrenciler 0 -1</td>
  </tr>
  <tr>
    <td>Sona Veri Ekleme</td>
    <td>RPUSH</td>
    <td>RPUSH ogrenciler baris</td>
  </tr>
  <tr>
    <td>İlk Datayı Çıkarma</td>
    <td>LPOP</td>
    <td>LPOP ogrenciler</td>
  </tr>
  <tr>
    <td>Son Datayı Çıkarma</td>
    <td>RPOP</td>
    <td>RPOP ogrenciler</td>
  </tr>
  <tr>
    <td>İndexe göre datayı getirme</td>
    <td>LINDEX</td>
    <td>LINDEX ogrenciler 2</td>
  </tr>
</table>

<h3>Redis Set</h3>
<p>Verileri rastgele bir düzende unique bir biçimde tutan veri türüdür.</p>

<table>
  <tr>
    <th>İşlem</th>
    <th>Kod</th>
    <th>Örnek</th>
  </tr>
  <tr>
    <td>Ekleme</td>
    <td>SADD</td>
    <td>SADD color blue</td>
  </tr>
  <tr>
    <td>Silme</td>
    <td>SREM</td>
    <td>SREM color white</td>
  </tr>
</table>

<h3>Redis Sorted Set</h3>
<p>Set'in düzenli bir sırayla tutan versiyonudur.</p>

<table>
  <tr>
    <th>İşlem</th>
    <th>Kod</th>
    <th>Örnek</th>
  </tr>
  <tr>
    <td>Ekleme</td>
    <td>ZADD</td>
    <td>ZADD araclar 1 silgi</td>
  </tr>
  <tr>
    <td>Getir</td>
    <td>ZRANGE</td>
    <td>ZRANGE araclar 0 2 / ZRANGE araclar 0 2 WITHSCORES</td>
  </tr>
  <tr>
    <td>Silme</td>
    <td>ZREM</td>
    <td>ZREM araclar 2</td>
  </tr>
</table>

<h3>Redis Hash</h3>
<p>Key-Value formatında veri tutan türdür.</p>

<table>
  <tr>
    <th>İşlem</th>
    <th>Kod</th>
    <th>Örnek</th>
  </tr>
  <tr>
    <td>Ekleme</td>
    <td>HMSET</td>
    <td>HMSET sozluk pen kalem</td>
  </tr>
  <tr>
    <td>Okuma</td>
    <td>HMGET</td>
    <td>HMGET sozluk pen</td>
  </tr>
  <tr>
    <td>Silme</td>
    <td>HDEL</td>
    <td>HDEL sozluk pen</td>
  </tr>
  <tr>
    <td>Tümünü Getir</td>
    <td>HGETALL</td>
    <td>HGETALL sozluk</td>
  </tr>
</table>

<h2>In-Memory Cache İşlem Sırası</h2>

<ol>
  <li><b>AddMemoryCache</b> servisi uygulamaya ekleyiniz.</li>
  <li><b>IMemoryCache</b> referansı inject ediniz.</li>
  <li><b>Set</b> metodu ile veriyi cache'leyebilir, Get metodu ile cache'lenmiş veriyi elde edebilirsiniz.</li>
  <li><b>Remove</b> fonksiyonuyla cache'lenmiş veriyi silebilirsiniz.</li>
  <li><b>TryGetValue</b> metodu ile kontrollü bir şekilde cache'den veri okuyabilirsiniz.</li>
</ol>

<h2>In-Memory Cache Absolute & Sliding Expiration</h2>

<h3>Absolute Time Nedir ?</h3>
<p> Cache'de ki datanın ne kadar tutulacağına dair net ömrünün belirtilmesidir. Belirtilen ömür sona erdiğinde cache direkt olarak temizlenir.</p>
<h3>Sliding Time Nedir ?</h3>
<p>Cache'lenmiş datanın memory'de belirtilen süre periyodu zarfında tutulmasını belirtir. Belirtilen süre periyodu içerisinde cache'e yapılan erişim neticesinde de datanın ömrü bir o kadar uzatılacaktır. Aksi taktirde belirtilen süre zarfında bir erişim söz konusu olmazsa cache temizlenecektir.</p>

<h2>Distributed Cache İşlem Sırası</h2>

<ol>
  <li><b>StackExchangeRedis</b> kütüphanesini uygulamaya yükleyiniz.</li>
  <li><b>AddStackExchangeRedisCache</b> servisini uygulamaya ekleyiniz.</li>
  <li><b>IDistributedCache</b> referansını inject ediniz.</li>
  <li><b>SetString</b> metodu ile metinsel, <b>Set</b> metodu ile ise, binary olarak verilerinizi redis'e cache'leyebilirsiniz. Aynı şekilde <b>GetString</b> ve <b>Get</b> fonksiyonlarıyla cache'lenmiş verileri elde edebilirsiniz.</li>
  <li><b>Remove</b> fonksiyonu ile cache'lenmiş verileri silebilirsiniz.</li>
</ol>

<h2>Redis API ile Message Broker</h2>

<p>Redis her ne kadar caching süreçlerinde kullanıyor olsa da özünde bir pub/sub işlemi yapabilen message broker özelliği barındırmaktadır.</p>

<ol>
<li>.Net Core'da Redis API üzerinden pub/sub işlemini gerçekleştirebilmek için StackExchange.Redis kütüphanesini uygulamanıza yükleyiniz.</li>
<li>
  <p>Ardından <b>ConnectionMultiplexer</b> sınıfı üzerinden Redis sunucusuna bir bağlantı oluşturunuz.</p>
  <p><b>ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync("localhost:6379");</b></p>
</li>
<li>
  <p>Devamında ise bu bağlantı üzerinden bir subscriber oluşturunuz.</p>
  <p><b>ISubscriber subscriber = redis.GetSubscriber();</b></p>
</li>
<li>
  <p>Bu aşamadan sonra davranışlarınız publisher ve consumer olmak üzere ikiye ayrılacaktır.</p>
  <p>Publish metodunu çağırarak istediğiniz kanala mesajınızı yayınlayabilirsiniz</p>
  <p><b>await subscriber.PublishAsync("example-channel", message);</b></p>
  <p>Subscribe metodunu çağırarak istediğiniz kanaldan mesajları okuyabilirsiniz</p>
  <p><b>await subscriber.SubscriberAsync("example-channel", (channel, message) => {Console.WriteLine(message)});</b></p>
</li>
</ol>

<h2>Redis Replication Davranışı Nedir ?</h2>
<p>Replication bir Redis sunucusundaki tüm verisel yapıın farklı bir sunucu tarafından birebir modellenmesi/çoğaltılması/replike edilmesidir.</p>

<h2>Replication Davranışındaki Temel Terminolojiler Nelerdir ? </h2>
<p>Replication davranışında modellenecek/replikası alınacak olan sunucuya <b>master</b> adını veriyoruz.</p>
<p>Master'ın replikası olan sunucuya ise <b>slave</b> adını veriyoruz.</p>
<p>Replication özelliğinde master ve slave arasında kurulan bir bağlantı üzerinden master'daki tüm değişiklikler anlık olarak slave sunuculara aktarılıyor olacaktır. Bu bağlantı koptuğu takdirde otomatik olarak yeniden sağlanarak, verisel güvence sergilenmeye çalışılacaktır.</p>
<p>Bu davranış sayesinde master sunucunda olabilecek arıza beya kesinti durumlarında sorumluluğu slave sunucuların otomatik devralmasıyla kesintisiz bir hizmez sağlayabiliyor olacağız.</p>
<p>Eğer ki, master ile slave arasında verisel bir eşitleme durumu tam olarak gerçekleşmemişse Redis bunun olabilmesi için talepte bulunacak ve master'dan güncel verilerin slave'e aktarılması için kaynak tüketimine devam edilecektir.</p>
<p>Ayrıca şunu da bilmekte fayda vardır ki, bir master'ın birden fazla replikasyonu da mevcut olabilir. Böylece, birden fazla slave sunucunun olmasıyla yüksek kullanılabilirlik, yedekleme ve kurtarma, veri ölçeklendirme ve coğrafi olarak dağıtılmış sistemler gibi senaryolarda yararlı çalışmalar gerçekleştirilebilir.</p>
<p>Slave sunucular sadece readonly'dir.</p>

<h2>Redis Sentinel Yapısı Nedir ?</h2>

<p>Redis Sentinel, master/slave replikasyon sistemi üzerinde çalışan bir yönetim servisidir. Sentinel, Redis veritabanının sağlığını izler ve herhangi bir problem, kesinti vs. meydana geldiği taktirde otomatik olarak failover(yük devretme) işlemleri gerçekleştirerek farklı bir sunucu üzerinden Redis hizmetinin kaldığı yerden devam etmesini sağlar.</p>
<p>Redis Sentinel'de <b>master</b>, <b>slave</b>, <b>sentinel</b>, <b>failover</b> olmak üzere dört kritik kavram vardır.</p>

<h3>Master</h3>
<p>Redis veritabanının ana sunucusudur. Tüm yazma ve okuma işlemleri bu sunucu üzerinde gerçekleşir.</p>
<p>Yani o anda aktif olan Redis sunucusunun rolünü ifade eder. Bu ana bilgisayar, diğer yedek Redis bilgisayarlarından(slave) daha öncelikli konumdadur ve bundan dolayı veri yazma ve okuma işlemleri için kullanılır.</p>
<p>Sentinel ise master olan Redis sunucusunun sağlıklı olup olmadığını süreli olarak izleyecek ve sorun olduğu taktirde başka bir yedek Redis sunucusunu otomatik master olarak işaretleyecektir.</p>

<h3>Slave</h3>
<p>Redis veritabanının yedek sunucularını ifade eder. Master sunucunun verilerinin replikasyonunu alır ve sadece okuma işlemleri için kullanılır.</p>
<p>Slave için, master sunucunun yedeklenmiş bir kopyasıdır diyebiliriz.</p>
<p>Redis sentinel yapılanmasının uygulandığı bir mimaride, herhangi bir t zamanda 'master' sunucu yalnızca bir tane olurken slave ise birden fazla olabilir.</p>

<h3>Sentinel</h3>
<p>Redis veritabanının sağlığını izleyen ve otomatik failover işlemlerini gerçekleştiren bir yönetim servisidir.</p>
<p>Sentinel, Redis veritabanının yüksek kullanılabilirliğini sağlamak ve herhangi bir kesintiye mahal vermemeksizin sürdürülebilir kılmak için otomatik olarak çalışmakta ve Redis master sunucusunun sağlıklı olup olmadığını sürekli olarak gözlemlemektedir. Master sunucuda bir problem ya da kesinti meydana geldiği taktirde sentinel sunucusu yedek(slave) Redis sunuculardan birinin yükseltilmesi ve ana bilgisayar yerine master yapılması işinden sorumludur.</p>
<p>Ayrıca Redis Sentinel, sisteme eklenen tüm slave sunucular hakkında bilgi toplamakta ve aralarından bir lider seçmektedir.</p>

<h3>Failover</h3>
<p>Master sunucunun arızalanması durumunda Sentinel tarafından herhangi bir slave'in master olarak atanması işleminin terminolojik karşıtlığıdır.</p>
<p>Başka bir deyişle herhangi bir slave'in mevcut master yerine geçip master olmasına 'failover' denmektedir.</p>
<p>Sentinel sunucusu, failover işlemi gerçekleştirdiği taktirde yeni master'ın IP değerini diğer slave'lere ileterek tüm sunucularının senkronize olmasını sağlamaktadır.</p>
<p>Failover işlemi ardından mevcut master'da slave konumuna geçer.</p>

