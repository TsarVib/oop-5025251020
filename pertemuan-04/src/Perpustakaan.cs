namespace Pertemuan04;

public class Perpustakaan
{
    private readonly List<Buku> _daftarBuku = new();
    public IReadOnlyList<Buku> DaftarBuku => _daftarBuku.AsReadOnly();


    public int JumlahJudul => DaftarBuku.Count;

    public void Tambah(Buku buku)
    {
        if (buku == null)
        {
            throw new ArgumentNullException();
        }
        bool exist = DaftarBuku.Any(b => b.Isbn == buku.Isbn);
        if (exist)
        {
            throw new InvalidOperationException();
        }

        _daftarBuku.Add(buku);
    }

    public Buku? Cari(string isbn)
    {
        Buku? buku = DaftarBuku.FirstOrDefault(b => b.Isbn == isbn);
        return buku;
    }

    public void PinjamBuku(string isbn, AkunAnggota akun)
    {
        // TODO(Level 10): "Tell, don't ask" -- Perpustakaan memutuskan semuanya.
        //   akun null -> ArgumentNullException; ISBN tidak ada ->
        //   ArgumentException; akun.Denda > 0 -> InvalidOperationException;
        //   akun.JumlahPinjamanAktif sudah sama dengan AkunAnggota.MaksPinjaman
        //   -> InvalidOperationException; selain itu panggil buku.Pinjam()
        //   (boleh melempar kalau stok habis) lalu akun.CatatPinjam().
        throw new NotImplementedException("Level 10 belum diimplementasikan");
    }

    public void KembalikanBuku(string isbn, AkunAnggota akun)
    {
        // TODO(Level 10): akun null -> ArgumentNullException; ISBN tidak ada ->
        //   ArgumentException; akun.JumlahPinjamanAktif = 0 ->
        //   InvalidOperationException; selain itu panggil buku.Kembalikan() lalu
        //   akun.CatatKembali().
        throw new NotImplementedException("Level 10 belum diimplementasikan");
    }
}
