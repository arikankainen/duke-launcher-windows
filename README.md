# Duke Launcher

Duke Launcher on moninpelikäynnistin ikivanhoille Duke Nukem 3D ja Shadow Warrior peleille, joita ajetaan DOSBoxilla samassa lähiverkossa.

![Duke Launcher](/docs/main.png)

## Valmistelut

Pura paketin tiedostot haluamaasi kansioon, jonne on täydet kirjoitusoikeudet. Luo seuraavaksi lähiverkon kesken jaettu kansio, jonne kaikilla pelaajilla on luku- ja kirjoitusoikeudet omilta koneiltaan. Tähän kansioon luodaan alikansiot `Duke Nukem 3D` sekä `Shadow Warrior`, joihin kopioidaan molempien pelien kartat joita on tarkoitus pelata. Käynnistä sen jälkeen `Duke.exe`.

Kansioiden valinta:

- `Game folder`: kansio jossa Duke Nukem 3D sijaitsee
- `DOSBox folder`: kansio johon DOSBox on asennettu
- `Capture folder`: kansio jonne DOSBoxin kuvakaappaukset tallentuvat
- `Shared folder`: kansio jonne jaetut pelitiedostot tallennetaan

## Käyttö

`Maps`-laatikossa näkyy kaikki valitun pelin kartat jotka on tallennettu jaettuun kansioon. Karttoja voi poistaa ja listan voi päivittää omista napeistaan. Karttojen alla voidaan näyttää kuvakaappaus kartasta.Kuvakaappaukset tallentuvat oletuksena DOSBoxilla kansioon `C:\Users\xxx\AppData\Local\DOSBox\capture` tai vastaavaan. Voit ottaa tietystä kartasta pelitilanteessa kuvan DOSBoxin näppäinyhdistelmällä `CTRL-F5`. Pelistä poistuttaessa Duke Launcher haistelee onko kuvakaappauskansioon ilmestynyt uusia kuvia pelin aloittamisen jälkeen, ja jos on, se kopioi viimeisimmän kuvan kartan kanssa samaan kansioon, samalla nimellä kuin itse kartta. Kuva näytetään ohjelmassa esikatselukuvana kun kyseinen kartta on valittu. Kuvan yläpuolella näkyy päivämäärä koska karttaa on viimeksi pelattu, ja kuvan alle voi tallentaa kuvauksen kartasta. Karttalistan yläpuolella on nappi josta voidaan valita käyttöön satunnainen mappi tietystä määrästä kauiten sitten pelatuista mapeista. Jos ruksi otetaan pois, valitaan mappi satunnaisesti kaikista mapeista.

Ylhäällä keskellä on oma laatikkonsa verkkoadaptereille. Varmista että valittuna on oikea adapteri ennen peliä. Alta löytyy chatti, johon kirjoitetut viestit tallentuvat jaettuun kansioon tiedostoina. Viestejä säilytetään tunnin ajan, eli ne näkyvät vaikka joku avaisi oman Duke Launcherinsa vasta viestien kirjoituksen jälkeen (tunnin sisällä). Paikalla olevat käyttäjät näkyvät `Users online` -laatikossa. Käyttäjänimenä näytetään Windowsin kirjautumisnimi, mutta `User name` -kenttään voi kirjoittaa muunkin nimen, kunhan kukaan muu ei käytä samaa nimeä. Käyttäjät jotka ovat pelissä, katoavat listalta.

Jaettuun kansioon voi myös tallentaa päivitetyn version Duke Launcherista (jos sellaista tulee), jolloin jokainen lähiverkon Duke Launcher voidaan päivittää automaattisesti `Check for program updates` -nappulalla. Ohjelma myös tarkistaa aina käynnistyessään löytyykö jaetusta kansiosta päivitystä, ja ilmoittaa siitä chattilaatikossa.

`Select game` -valintalaatikolla voidaan valita pelataanko Dukea vai Shadow Warrioria (lyh. SW). Huom! Molemmille peleille täytyy määritellä oma pelikansio. Muut kansiot ovat yhteisiä. Pelivalinnan alla voidaan valita kuinka monta pelaajaa on tulossa peliin. `Auto` -valinnalla peli käynnistetään niin monen pelaajan kesken kun sillä hetkellä käyttäjiä on näkyvissä. Määrä voidaan myös valita itse (`1-8`). Jos esimerkiksi valitaan nelinpeli, ja käyttäjiä on vain kolme, jää Duke Launcher odottamaan että neljäs pelaaja ilmestyy mukaan, ja käynnistää pelin vasta sitten. Peli käynnistetään alla olevasta `Launch game` -napista. Alla on `Run setup` -nappi, jolla voidaan käynnistää pelin asetukset. Valintaruksilla voidaan myös valita halutaanko pelata koko ruudun tilassa vai ei.

Alta löytyy myös nappi `Terminate all`, joka tappaa kaikkien käyttäjien DOSBoxin, eli kaikkien peli päättyy siihen. `Solo mode` -napin päällekytkemällä (muuttuu vihreäksi) voi karttoja testata yksinään vaikka muita olisikin paikalla. Testipelit ei päivitä kartan pelauspäivämäärää. Yksinpelimoodi menee päälle myös muilla käyttäjillä.

Duke Launcherit eivät siis kommunikoi suoraan toistensa kanssa yhtään mitenkään, vaan kaikki kommunikointi tapahtuu jaetun kansion kautta tallentamalla sinne tietyn nimisiä tiedostoja. Tästä syystä kaikessa toiminnassa on pientä viivettä.

## Toiminta vähän syvällisemmin

Kun joku käynnistää pelin, käyttäjästä tulee palvelin, ja tapahtuu automaattisesti seuraavaa:

- Jaettuun kansioon tallennetaan tiedosto server, joka pitää sisällään ajan, valitun pelin, käyttäjänimen, ip-osoitteen johon muiden käyttäjien DOSBox ottaa yhteyden, sekä kartan nimen jonka jokainen käynnistää. Kyseinen kartta kopioidaan jaetusta kansiosta jokaisen pelikansioon.
- Duken/SW:n `commit.dat`-tiedostoon muutetaan pelaajien määrä, esim. `NUMPLAYERS = 4`.
- Duken/SW:n `cfg`-tiedostoon muutetaan pelaajan nimi, esim. `PlayerName = AriK`. `cfg`-tiedostona käytetään aakkosjärjestyksessä ensimmäistä `cfg`-tiedostoa (oletuksena pelkästään `duke3d.cfg`). Varmista siis jos käytössä on useita `cfg`-tiedostoja, että käytät aakkosellisesti ensimmäistä.
- Luodaan Duken/SW:n kansioon battitiedosto `dukebat.bat` joka pitää sisällään seuraavat komennot:

```
ipxnet startserver
commit.exe -map kartta.map
exit
```

- Käynnistetään DOSBox ajamaan juuri luotu batti, jolloin DOSBox tekee itsestään serverin ja käynnistää Duken/SW:n `commit.exe`:n, jolla siis käynnistetään verkkopeli.
  Samaan aikaan muiden pelaajien Duke Launcher huomaa että jaettuun kansioon on ilmestynyt tiedosto `server`, ja käyttäjistä tulee samalla hetkellä asiakkaita jotka ottavat automaattisesti yhteyden serveriin seuraavasti:
- `server`-tiedostosta luetaan sinne kirjoitetut tiedot, ja niiden perusteella muokataan `commit.dat` kuten serverin tapauksessakin. Homma etenee muutenkin samalla tavalla, paitsi battitiedostoon tulee esim. seuraavat rivit:

```
ipxnet connect 192.168.1.50
commit.exe -map kartta.map
exit
```

- Kun luotu batti käynnistetään, ottaa DOSBox yhteyden serverin ip-osoitteeseen, ja `commit.exe` käynnistää pelin. Jos kaikki meni hyvin, on verkkopeli nyt käynnissä.

## Vaatimukset

- Windows XP tai uudempi
- DOSBox v0.74
- Duke Nukem 3D ja/tai Shadow Warrior (rekisteröity DOS-versio)
- DOSBoxin `dosbox-0.74.conf` -tiedostossa ei saa olla käytössä mount -komentoa joka "mounttaa" jonkun kansion `C`-asemaksi, koska DOSBoxilla ei voi käynnistää battitiedostoja jos `C`-asema on jo käytössä. Samasta tiedostosta pitää muuttaa `ipx=false` muotoon `ipx=true`.

## Lataus

En ota mitään vastuuta ohjelman mahdollisesti aiheuttamista vahingoista; kukin käyttää ohjelmaa omalla vastuullaan. Toiminta testattu Windows XP, Windows 7 ja Windows 10 -käyttöjärjestelmillä. Vaatimuksena myös .NET Framework 4, joka tulee ainakin Windows 10:n tapauksessa esiasennettuna.

**[Lataa uusin versio](https://github.com/arikankainen/duke-launcher-windows/releases)**
