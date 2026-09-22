namespace Pertemuan04;

public class AkunAnggota
{
    public const int MaksPinjaman = 3;

    public string NomorAnggota { get; }

    // TODO(Level 9): Nama hanya boleh diisi saat objek dibuat (ganti set ->
    //   init). Denda TIDAK boleh diubah dari luar kelas sama sekali (setter
    //   private) -- perubahannya hanya lewat TambahDenda()/BayarDenda().
    public string Nama { get; init; } = "";
    public int Denda { get; private set; }

    // TODO(Level 10): JumlahPinjamanAktif hanya boleh diubah dari dalam kelas
    //   (setter private), dan pencatatannya lewat method internal (bukan public)
    //   di bawah -- hanya kode di dalam pustaka (Perpustakaan) yang boleh
    //   memanggilnya, bukan kode pemakai dari luar.
    public int JumlahPinjamanAktif { get; set; }

    public AkunAnggota(string nomorAnggota)
    {
        if (nomorAnggota == null || nomorAnggota.Trim() == "")
            throw new ArgumentException();
        NomorAnggota = nomorAnggota;
    }

    public void TambahDenda(int rupiah)
    {
        if (rupiah <= 0) throw new ArgumentOutOfRangeException();
        Denda += rupiah;
    }

    public int BayarDenda(int rupiah)
    {
        if (rupiah <= 0) throw new ArgumentOutOfRangeException();
        if (rupiah > Denda) throw new InvalidOperationException();
        return rupiah - Denda;
    }

    public void CatatPinjam()
    {
        // TODO(Level 10): naikkan JumlahPinjamanAktif satu.
        throw new NotImplementedException("Level 10 belum diimplementasikan");
    }

    public void CatatKembali()
    {
        // TODO(Level 10): turunkan JumlahPinjamanAktif satu (tidak boleh di
        //   bawah 0).
        throw new NotImplementedException("Level 10 belum diimplementasikan");
    }
}
