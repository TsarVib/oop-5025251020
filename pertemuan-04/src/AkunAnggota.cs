namespace Pertemuan04;

public class AkunAnggota
{
    public const int MaksPinjaman = 3;

    public string NomorAnggota { get; }

    public string Nama { get; init; } = "";
    public int Denda { get; private set; }

    public int JumlahPinjamanAktif { get; private set; }

    public AkunAnggota(string nomorAnggota)
    {
        if (nomorAnggota == null || nomorAnggota.Trim() == "")
            throw new ArgumentException();
        NomorAnggota = nomorAnggota;
    }

    public void TambahDenda(int rupiah)
    {
        if (rupiah <= 0)
            throw new ArgumentOutOfRangeException();
        Denda += rupiah;
    }

    public int BayarDenda(int rupiah)
    {
        if (rupiah <= 0)
            throw new ArgumentOutOfRangeException();
        if (rupiah > Denda)
            throw new InvalidOperationException();
        Denda -= rupiah;
        return Denda;
    }

    internal void CatatPinjam()
    {
        JumlahPinjamanAktif++;
    }

    internal void CatatKembali()
    {
        JumlahPinjamanAktif--;
        if (JumlahPinjamanAktif < 0)
            JumlahPinjamanAktif = 0;
    }
}
