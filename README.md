# AspNetCore.Redis

<h2>Caching Nedir ?</h2>

<p>
Geliştirdiğimiz yazılımları kullanan kişi sayısı arttıkça yavaşlamanın olmamasını isteriz. Çok fazla kullanılan modüllerin kullanıcılara hızlı cevap vermesini isteriz. Tüm bu ve bu doğrultudaki isteklerimize caching yöntimi pozitif yönde katkı sağlamaktadır. Caching sık kullanılan dataları kaydetme tekniğine verilen isimdir. Kaydetme işlemi uygulamayı host eden sunucunun ram belleğinde(In Memory Caching) ve harici bir caching sunusunda(Distributed Caching) gerçekleştirilebilir.
</p>

<p>
Cacheleme, kullanıcılara pozitif yönde bir uygulama deneyimi sağlar. Çok sık erişilmeyen dataları cachelemek gereksiz bir kaynak kullanımına sebeb olacaktır. Çok sık değişen dataları ise cachelememek gerekir. Çünkü istek yapan kullanıcıya yanlış data göndermiş oluruz.

<strong>Cacheleyeceğimiz datanın iki özelliği taşıyor olması gerekir. Birincisi çok güncellenmemeli, İkincisi çok sık erişiliyor olmalı.</strong>
</p>

<h3>Neden Cache Kullanmalıyız ?</h3>
<ul>
    <li>Uygulama kullanıcısına hızlı cevap verebilmek için</li>
    <li>Daha iyi kullanıcı deneyimi sağlamak için</li>
    <li>Veri tabanı tarafındaki gereksiz bandwidth trafiğini azaltmak için</li>
    <li>1 kişi girdiği zamanda 100 kişi girdiği zamanda aynı kullanıcı deneyimi sağlayabilmek için</li>
</ul>

<h3>Cache Stratejileri</h3>
<p><b>On-Demand:</b> Verilerin talep edildiği an cachelenmesine verilen isimdir.</p>
<p><b>Prepopulation:</b> İstek gelmeden uygulama ayağa kalkar kalkmaz verilerin cachelendiği seneryoya verilen isimdir.</p>

<h3>Cache Ömrü</h3>
<p><b>Absolute Time:</b> Verilen süre dolduğunda veri cache’den silinir.</p>
<p><b>Sliding Time:</b> Verilen süre içerisinde cache verisine erişilirse, Cache in süresi siliding time süresi kadar daha uzatılmış olur.(Sadece bu özellik kullanılırsa her zaman eski dataya ulaşılabilir. Bu sorunu engellemek için sliding time la birlikte absolute time da belirtmek gerekir.)</p>

<h2>In-Memory Caching</h2>
<p>In-Memory Cache uygulama ile ilgili verilerin uygulamanın çalıştığı uygulama sunucusunun ram belleğinde tutulması işlemidir. Tutabileceğimiz cache boyutu uygulama sunucusunun ram miktarıyla doğru olarantılıdır.</p>
<p>Uygulamamızın tekbir instance varsa problemsiz bir şekilde kullanılır.</p>
<p>Uygulamamızın birden fazla instance varsa ve bu instance'lara bir “load balancer” yönlendirme yapıyorsa uygulamaya istek yapan kullanıcı farklı zamanlarda farklı instance'lara yönlendirilebilir. Bu durumda kişi farklı zamanlarda farklı cachelere ulaşacağından her isteğinde farklı bir veri görür. Bu tutarsızlığı çözmek için “load balancer” üzerinden “sticky session” özelliği ile uygulamaya istek yapan kullanıcı devamlı aynı uygulama instance'ına gönderilebilir. Sticky Session cookie veya Ip’ye göre yönlendirme yapabilmektedir.</p>
<p>Eğer uygulamamız birden fazla sunucu üzerinde çalışıyorsa In-Memory Cache yerine Distributed Cache kullanmak daha doğru olacaktır.</p>

<h2>Distributed Caching</h2>
<p>Distributed Cache yönteminde, Cache dataları uygulamanın ayağa kalktığı host işletim sisteminin ram belleğinde tutulmaz. Bu yöntemde cache dataları ayrı bir cache service'inde tutulur.</p>
<h3>Avantajları Nelerdir ?</h3>
<ul>
    <li>Veri tutarsızlığının önüne geçilmiş olur</li>
    <li>Uygulamanın ayağa kalktığı host bilgisayar resetlendiğinde cache verileri silinmez.</li>
</ul>
<h3>Dezavantajları Nelerdir ?</h3>
<ul>
    <li>Farklı bir service'den cache dataları istendiği için In-Memory Cache yöntemine göre daha yavaştır.</li>
    <li>In-Memory Cache yöntemine göre kullanımı daha zordur.</li>
</ul>

