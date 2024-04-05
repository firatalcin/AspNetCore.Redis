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
