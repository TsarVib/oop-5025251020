namespace Pertemuan04;

public class Perpustakaan
{
    private readonly List<Buku> _daftarBuku = new();
    public IReadOnlyList<Buku> DaftarBuku => _daftarBuku.AsReadOnly();


    public int JumlahJudul => DaftarBuku.Count;

    public void Tambah(Buku buku)
    {
        if (buku == null)
            throw new ArgumentNullException();

        bool exist = DaftarBuku.Any(b => b.Isbn == buku.Isbn);

        if (exist)
            throw new InvalidOperationException();

        _daftarBuku.Add(buku);
    }

    public Buku? Cari(string isbn)
    {
        Buku? buku = DaftarBuku.FirstOrDefault(b => b.Isbn == isbn);
        return buku;
    }

    public void PinjamBuku(string isbn, AkunAnggota akun)
    {
        if (akun == null)
            throw new ArgumentNullException();
        if (isbn == null || isbn.Trim() == "")
            throw new ArgumentException();
        if (akun.Denda > 0 || akun.JumlahPinjamanAktif == AkunAnggota.MaksPinjaman)
            throw new InvalidOperationException();

        Buku? buku = Cari(isbn) ?? throw new ArgumentException();

        buku.Pinjam();
        akun.CatatPinjam();
    }

    public void KembalikanBuku(string isbn, AkunAnggota akun)
    {
        if (akun == null)
            throw new ArgumentNullException();
        if (akun.JumlahPinjamanAktif <= 0)
            throw new InvalidOperationException();
        if (isbn == null || isbn.Trim() == "")
            throw new ArgumentException();

        Buku? buku = Cari(isbn) ?? throw new ArgumentException();

        buku.Kembalikan();
        akun.CatatKembali();
    }
}
