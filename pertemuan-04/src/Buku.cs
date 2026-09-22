
namespace Pertemuan04;

public class Buku
{
    private readonly string _isbn = "";
    private readonly string _judul = "";
    private int _stokTotal;
    private int _stokTersedia;

    public string Isbn { get { return _isbn; } }
    public string Judul { get { return _judul; } }
    public int StokTotal { get { return _stokTotal; } }
    public int StokTersedia { get { return _stokTersedia; } }

    private int _batasHariPinjam = 7;
    public int BatasHariPinjam
    {
        get
        {
            return _batasHariPinjam;
        }
        set
        {
            if (value < 1 || value > 30) throw new ArgumentOutOfRangeException();
            _batasHariPinjam = value;
        }
    }

    public Buku(string isbn, string judul, int stokTotal)
    {
        if (judul == null || judul.Trim() == "" || stokTotal < 0 || isbn == null)
        {
            throw new ArgumentException();
        }

        _stokTotal = _stokTersedia = stokTotal;
        _judul = judul;

        string checkIsbn = isbn.Replace("-", "").Replace(" ", "");
        if (checkIsbn.Length != 13 || !checkIsbn.All(char.IsDigit))
        {
            throw new ArgumentException();
        }

        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            int digit = checkIsbn[i] - '0';
            sum += (i % 2 == 0) ? digit : digit * 3;
        }
        if ((10 - (sum % 10)) % 10 != (checkIsbn[12] - '0'))
        {
            throw new ArgumentException();
        }

        _isbn = checkIsbn;
    }

    public void Pinjam()
    {
        if (_stokTersedia <= 0)
        {
            throw new InvalidOperationException();
        }
        _stokTersedia--;
    }

    public void Kembalikan()
    {
        if (_stokTersedia >= _stokTotal)
        {
            throw new InvalidOperationException();
        }
        _stokTersedia++;
    }

    public double PersentaseTersedia
    {
        get
        {
            if (StokTotal == 0) { return 0; }
            return (double)StokTersedia / (double)StokTotal * 100.0f;
        }
    }

    public string Status
    {
        get
        {
            if (_stokTersedia > 0) return "Tersedia";
            return "Habis";
        }
    }

}
